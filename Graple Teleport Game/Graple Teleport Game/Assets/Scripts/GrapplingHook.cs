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
    Vector2 lockedPos;
    float shootLength;
    float grapleRadius;

    public static bool grapleCaught;

    
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        

        mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines();
            StartCoroutine(ShootHook());
        }
        if(Input.GetMouseButtonUp(0))
        {
            StopAllCoroutines();
            StartCoroutine(RetractHook());
        }
        

        if (Vector2.Dot(rb.velocity, lockedPos - (Vector2)transform.position) <= 0  && lockedPos != Vector2.zero)
        {
            if(grapleRadius == 0)
            {
                SetGrapleRadius();
            }
            GrappleVelocity(lockedPos - (Vector2)transform.position);
        }

        if(grapleCaught)
        {
            lineRen.SetPosition(0, transform.position);
            lineRen.SetPosition(1, lockedPos);
        }
        else
        {
            lineRen.SetPosition(0, transform.position);
            lineRen.SetPosition(1, (transform.position + (Vector3)(shootLength * (mousePos - (Vector2)transform.position).normalized)));
        }

        if(grapleCaught)
        {
            Debug.DrawLine(transform.position, lockedPos, Color.cyan);
        }
        Debug.Log(shootLength);
        //Debug.DrawLine(transform.position, transform.position + (Vector3)(shootLength * (mousePos.normalized - (Vector2)transform.position)));
    }

    public void GrappleVelocity(Vector2 grapleVector)
    {
        Vector2 AddVelocity = Vector2.zero;
        Vector2 grapleDirection = grapleVector.normalized;
        

        // Projection to make rope super tight and hold on to thing.
        //This code only works because grapleDirection is normalized.
        rb.velocity = rb.velocity - grapleDirection * Vector2.Dot(rb.velocity, grapleDirection);
        if(((Vector2)transform.position - lockedPos).sqrMagnitude > grapleRadius * grapleRadius)
        {
            transform.position = lockedPos + ((Vector2)transform.position - lockedPos).normalized * grapleRadius;
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
        //shootLength = (lockedPos - (Vector2)transform.position).magnitude;
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
    }

    public void SetGrapleRadius()
    {
        grapleRadius = (lockedPos - (Vector2)transform.position).magnitude;
    }
}
