using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    private Camera cam;
    public float ropeLength;
    public LineRenderer lineRen;

    Rigidbody2D rb;
    Vector2 mousePos;
    GrapLocation grap;
    Vector2 lockedPos;
    float shootLength;
    float grapleRadius;

    public static bool grapleCaught;
    public static bool canGraple = true;

    
    void Start()
    {
        grap = new GrapLocation();
        grap.grip = new GameObject().transform;
        Physics2D.queriesStartInColliders = false;
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0) && canGraple)
        {
            StopAllCoroutines();
            StartCoroutine(ShootHook());
        }
        if(Input.GetMouseButtonUp(0))
        {
            StopAllCoroutines();
            StartCoroutine(RetractHook());
        }
        

        if (Vector2.Dot(rb.velocity, (Vector2)grap.grip.position - (Vector2)transform.position) <= 0  && (Vector2)grap.grip.position != Vector2.zero && grap.active)
        {
            GrappleVelocity((Vector2)grap.grip.position - (Vector2)transform.position);
            if(grap.gripRB != null)
            {
                Vector2 neces = -((Vector2)grap.grip.position - (Vector2)transform.position).normalized;
                grap.gripRB.AddForceAtPosition(neces * Vector2.Dot(rb.velocity, neces), grap.grip.position);
            }
        }

        #region Line Rendering
        if (grapleCaught)
        {
            lineRen.SetPosition(0, transform.position);
            lineRen.SetPosition(1, (Vector2)grap.grip.position);
        }
        else
        {
            lineRen.SetPosition(0, transform.position);
            lineRen.SetPosition(1, (transform.position + (Vector3)(shootLength * (mousePos - (Vector2)transform.position).normalized)));
        }
        if(grapleCaught)
        {
            Debug.DrawLine(transform.position, (Vector2)grap.grip.position, Color.cyan);
        }
        #endregion
    }

    public void GrappleVelocity(Vector2 grapleVector)
    {
        Vector2 grapleDirection = grapleVector.normalized;

        // Projection to make rope super tight and hold on to thing.
        //This code only works because grapleDirection is normalized.
        
        if(((Vector2)transform.position - (Vector2)grap.grip.position).sqrMagnitude > grapleRadius * grapleRadius)
        {
            rb.velocity -= grapleDirection * Vector2.Dot(rb.velocity, grapleDirection);
            transform.position = (Vector2)grap.grip.position + ((Vector2)transform.position - (Vector2)grap.grip.position).normalized * grapleRadius;
        }
        
        Debug.DrawLine(transform.position, transform.position + (Vector3)(grapleDirection * rb.velocity.sqrMagnitude / grapleRadius), Color.red);
    }

    IEnumerator ShootHook()
    {
        while (shootLength < ropeLength)
        {

            shootLength += 50 * Time.deltaTime;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePos - (Vector2)(transform.position), shootLength);
            if (hit.collider != null)
            {
                lockedPos = hit.point;
                grapleCaught = true;
                grap.grip.position = hit.point;
                grap.grip.parent = hit.collider.transform;
                grap.active = true;
                //(Vector2)grap.grip.position

                if(hit.collider.GetComponent<Rigidbody2D>())
                {
                    grap.gripRB = hit.collider.GetComponent<Rigidbody2D>();
                }
                SetGrapleRadius();
            }
            
            yield return null;
        }
        if(!grapleCaught)
        {
            StartCoroutine(RetractHook());
        } 
    }
    IEnumerator RetractHook()
    {
        grap.active = false;

        grapleRadius = 0f;
        grapleCaught = false;
        while (shootLength > 0f)
        {
            lockedPos = Vector2.zero;
            shootLength -= 50 * Time.deltaTime;
            yield return null;
        }
        shootLength = 0;
    }

    public void TurnOffGrapple()
    {
        StopAllCoroutines();
        shootLength = 0;
        grapleRadius = 0f;
        grapleCaught = false;
        lockedPos = Vector2.zero;

        grap.active = false;
    }

    public void SetGrapleRadius()
    {
        grapleRadius = (lockedPos - (Vector2)transform.position).magnitude;
    }
}

public class GrapLocation
{
    public bool active = false;

    public Transform grip;

    public Rigidbody2D gripRB;
}
