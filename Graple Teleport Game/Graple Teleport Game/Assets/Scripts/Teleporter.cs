using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public bool straitTeleport;
    public float fixedSpeed;
    public GameObject otherTele;
    protected Vector2 down;
    protected Vector2 right;
    //public List[TeleportObj] teleportObjects;
    // Start is called before the first frame update

    protected Dictionary<int, bool> rightDict = new Dictionary<int, bool>();
    void Start()
    {
        FixedUpdate();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rotation = gameObject.transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        right = new Vector2(Mathf.Sin(rotation), -Mathf.Cos(rotation));
        down = new Vector2(Mathf.Cos(rotation), Mathf.Sin(rotation));
    }

    private bool getRight(GameObject obj)
    {
        return Vector2.Dot(right, (Vector2)(obj.transform.position - gameObject.transform.position)) > 0;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        rightDict[other.gameObject.GetInstanceID()] = getRight(other.gameObject);
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        bool newRight = getRight(other.gameObject);
        int id = other.gameObject.GetInstanceID();
        if (!rightDict[id] == newRight)
        {
            rightDict[id] = newRight;
            Teleport(other.gameObject, getRight(other.gameObject));
        }
    }
    
    public void swap(GameObject obj)
    {
        try
        {
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            Vector2 difference = rb.position - (Vector2)gameObject.transform.position;
            float rotation = gameObject.transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
            float newRotation = otherTele.transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
            float rotationDiff = newRotation - rotation;
            float newX = difference.x * Mathf.Cos(rotationDiff) - difference.y * Mathf.Sin(rotationDiff);
            float newY = difference.x * Mathf.Sin(rotationDiff) + difference.y * Mathf.Cos(rotationDiff);
            Vector2 newDifference = new Vector2(newX, newY);
            rb.position = (Vector2)otherTele.transform.position + newDifference;

            float newVelX = rb.velocity.x * Mathf.Cos(rotationDiff) - rb.velocity.y * Mathf.Sin(rotationDiff);
            float newVelY = rb.velocity.x * Mathf.Sin(rotationDiff) + rb.velocity.y * Mathf.Cos(rotationDiff);
            rb.velocity = new Vector2(newVelX, newVelY);
            if (fixedSpeed != 0) { rb.velocity = rb.velocity.normalized * fixedSpeed; }
        }
        catch(MissingComponentException _)
        {
            
        }
    }

    public void Teleport(GameObject teleported, bool side)
    {
        GameManager.audioManager.Play("Teleport");
        if (teleported.CompareTag("Player"))
        {
            RandomFunctions.TurnOffGrapple();
        }
        Rigidbody2D rb = teleported.GetComponent<Rigidbody2D>();
        float teleRot = otherTele.transform.rotation.eulerAngles.z - transform.rotation.eulerAngles.z;
        teleRot *= Mathf.Deg2Rad;
        if (straitTeleport)
        {
            if(side)
            {
                rb.velocity = -otherTele.transform.up * rb.velocity.magnitude;
            }
            else
            {
                rb.velocity = otherTele.transform.up * rb.velocity.magnitude;
            }
        }
        else
        {
            
            float vX = Mathf.Cos(teleRot) * rb.velocity.x - Mathf.Sin(teleRot) * rb.velocity.y;
            float vY = Mathf.Cos(teleRot) * rb.velocity.y + Mathf.Sin(teleRot) * rb.velocity.x;
            rb.velocity = new Vector2(vX, vY);
        }
        teleported.transform.position = otherTele.transform.position;
        if (fixedSpeed != 0) { rb.velocity = rb.velocity.normalized * fixedSpeed; }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            Teleport(collision.gameObject);
            if(collision.gameObject.CompareTag("Player"))
            {
                FindObjectOfType<GrapplingHook>().TurnOffGrapple();
            }
        }
    }*/
}
