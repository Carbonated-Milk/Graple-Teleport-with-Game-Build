using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public bool suction;
    private Camera cam;
    public float ropeLength;
    public LineRenderer lineRen;

    Rigidbody2D rb;
    Vector2 mousePos;
    public GrapLocation grap;
    float shootLength;
    float grapleRadius;

    public LayerMask ignoreMe;

    public static bool canGraple = true;

    private bool swingType = false;


    void Start()
    {
        lineRen.endColor = lineRen.endColor = Color.white;
        suction = false;

        grap = new GrapLocation();
        grap.SetUpGrap();

        Physics2D.queriesStartInColliders = false;
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        StartCoroutine(RetractHook());
    }
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && canGraple)
        {
            StopAllCoroutines();
            StartCoroutine(ShootHook());
        }
        if (Input.GetMouseButtonUp(0) && grap.active)
        {
            StopAllCoroutines();
            grap.active = true;
            StartCoroutine(RetractHook());
        }

        if (Input.GetKeyDown("q"))
        {
            if(swingType)
            {
                if (grap.active)
                {
                    grapleRadius = (transform.position - grap.grip.position).magnitude;
                }
                lineRen.endColor = lineRen.endColor = Color.white;
                suction = false;
            }
            else
            {
                lineRen.endColor = lineRen.endColor = Color.blue;
                suction = true;
            }
            swingType = !swingType;
        }

        if (grap.grip == null)
        {
            grap.grip = new GameObject().transform;
            TurnOffGrapple();
        }

        if (!((Vector2.Dot(rb.velocity, (Vector2)grap.grip.position - (Vector2)transform.position) > 0 || (Vector2)grap.grip.position == Vector2.zero || !grap.active || suction) && (!grap.active || ((Vector2)transform.position - (Vector2)grap.grip.position).sqrMagnitude <= grapleRadius * grapleRadius || suction)))
        {
            GrappleVelocity((Vector2)grap.grip.position - (Vector2)transform.position);
        }
        
        if(suction && grap.active)
        {
            SuctionVel((Vector2)grap.grip.position - (Vector2)transform.position);
        }

        grap.position = grap.grip.position;
        grap.time = Time.time;

        #region Line Rendering
        if (grap.active)
        {
            lineRen.SetPosition(0, transform.position);
            lineRen.SetPosition(1, (Vector2)grap.grip.position);
        }
        else
        {
            lineRen.SetPosition(0, transform.position);
            lineRen.SetPosition(1, (transform.position + (Vector3)(shootLength * (mousePos - (Vector2)transform.position).normalized)));
        }
        #endregion
    }

    private void SuctionVel(Vector2 grapleVector)
    {
        Vector2 grapleDirection = grapleVector.normalized;
        rb.velocity += (Vector2)(grap.grip.position - transform.position) / 16 * Time.deltaTime * 100;

        if (grap.gripRB != null)
        {
            grap.gripRB.AddForceAtPosition(100 * Physics.gravity * Time.deltaTime * -Vector2.Dot(Vector2.down, grapleDirection), grap.grip.position);

            grap.gripRB.AddForceAtPosition(-(Vector2)(grap.grip.position - transform.position) / 16 * 100, grap.grip.position);
        }
    }

    public void GrappleVelocity(Vector2 grapleVector)
    {
        Vector2 grapleDirection = grapleVector.normalized;

        // Projection to make rope super tight and hold on to thing.
        //This code only works because grapleDirection is normalized.

        if (((Vector2)transform.position - (Vector2)grap.grip.position).sqrMagnitude > grapleRadius * grapleRadius)
        {
            rb.velocity -= grapleDirection * Vector2.Dot(rb.velocity, grapleDirection);
            Vector2 newVel = grapleDirection * Vector2.Dot(grap.ChangeCheck(), grapleDirection) + rb.velocity - grapleDirection * Vector2.Dot(rb.velocity, grapleDirection);
            rb.velocity = newVel;

            transform.position = (Vector2)grap.grip.position + ((Vector2)transform.position - (Vector2)grap.grip.position).normalized * grapleRadius;


            if (grap.gripRB != null)
            {
                grap.gripRB.AddForceAtPosition(-(grapleDirection * Vector2.Dot(grap.ChangeCheck(), grapleDirection) + rb.velocity)/Time.deltaTime, grap.grip.position);

                grap.gripRB.AddForceAtPosition(-grapleDirection * 10, grap.grip.position);
            }
        }

    }

    IEnumerator ShootHook()
    {
        while (shootLength < ropeLength)
        {
            shootLength += 50 * Time.deltaTime;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePos - (Vector2)(transform.position), shootLength, ignoreMe);
            if (hit.collider != null)
            {
                grap.grip.position = hit.point;
                grap.position = grap.grip.position;
                grap.grip.parent = hit.collider.transform;
                grap.active = true;
                //(Vector2)grap.grip.position

                if (hit.collider.GetComponent<Rigidbody2D>())
                {
                    grap.gripRB = hit.collider.GetComponent<Rigidbody2D>();
                }
                SetGrapleRadius();
            }

            yield return null;
        }
        if (!grap.active)
        {
            StartCoroutine(RetractHook());
        }
    }
    IEnumerator RetractHook()
    {
        if (grap.active)
        {
            shootLength = ((Vector2)transform.position - (Vector2)grap.grip.position).magnitude;
            grap.active = false;
        }
        while (shootLength > 0f)
        {
            grap.grip.position = Vector2.zero;
            shootLength -= 50 * Time.deltaTime;
            yield return null;
        }
        TurnOffGrapple();
        grapleRadius = 0f;

        shootLength = 0;

    }

    public void TurnOffGrapple()
    {
        StopAllCoroutines();
        shootLength = 0;
        grapleRadius = 0f;
        grap.grip.position = Vector2.zero;

        grap.TurnOffGrap();
    }

    public void SetGrapleRadius()
    {
        grapleRadius = ((Vector2)grap.grip.position - (Vector2)transform.position).magnitude;
    }
}

public class GrapLocation
{
    public bool active = false;

    public Transform grip;

    public Rigidbody2D gripRB;


    public Vector3 position;
    public float time;
    public void TurnOffGrap()
    {
        active = false;
        gripRB = null;
    }

    public Vector2 ChangeCheck()
    {
        Vector2 newVel = (grip.position - position) / (Time.time - time);
        position = grip.position;
        time = Time.time;
        return newVel;
    }

    internal void SetUpGrap()
    {
        grip = new GameObject().transform;
        position = grip.position;
    }
}
