using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Player : MonoBehaviour
{
    Vector3 respawnPoint;
    public UnityEvent death;
    private Rigidbody2D rb;

    [HideInInspector] public bool canJump;
    [HideInInspector] public bool contained;
    [HideInInspector] public GameObject containedObj;
    void Start()
    {
        contained = false;
        respawnPoint = Vector3.zero;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(contained)
        {
            transform.position = containedObj.transform.position;
            return;
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(Vector2.left * 200 * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(Vector2.right * 200 * Time.deltaTime);
        }

        if (Input.GetKeyDown("space") && canJump)
        {
            rb.AddForce(new Vector2(0f, 200f));
            canJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("RespawnPoint"))
        {
            respawnPoint = collision.transform.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        canJump = true;
        if(collider.transform.CompareTag("Death"))
        {
            OhNo();
        }
    }

    private void OnCollisionExit2D(Collision2D collider)
    {
        canJump = false;
    }

    public void OhNo()
    {
        death.Invoke();
        transform.position = respawnPoint;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }

    public void Contained(GameObject container)
    {
        containedObj = container;
        contained = true;
        GetComponent<Renderer>().enabled = false;
        transform.position = container.transform.position;
        rb.velocity = Vector3.zero;
        //rb.isKinematic = true;
        transform.parent = container.transform;
    }
    public void Released()
    {
        contained = false;
        GetComponent<Renderer>().enabled = true;
        //rb.isKinematic = false;
        transform.parent = null;
    }
}
