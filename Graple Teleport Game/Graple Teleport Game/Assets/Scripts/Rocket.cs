using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float flightTime;
    public float speed;
    public float rotateSpeed;
    private Rigidbody2D rb;
    public float acceleration;
    public Vector2 minMaxSpeed;
    private GameObject cargo;
    private float originalSpeed;
    private Player player;
    void Start()
    {
        if(minMaxSpeed == Vector2.zero)
        {
            minMaxSpeed = Vector2.one * speed;
        }
        originalSpeed = speed;

        rb = GetComponent<Rigidbody2D>();
        cargo = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(cargo != null)
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime * speed / originalSpeed * -player.moverDir.x);
            speed += acceleration * Time.deltaTime * player.moverDir.y;
            if(player.jumped)
            {
                Explode();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            cargo = FindObjectOfType<Player>().gameObject;
            player = collision.gameObject.GetComponent<Player>(); 
            StartCoroutine(Launch(collision.gameObject));
        }
        if (collision.gameObject.CompareTag("Death"))
        {
            Explode();
        }
    }

    public IEnumerator Launch(GameObject player)
    {
        transform.tag = "Carrier";
        player.GetComponent<CircleCollider2D>().enabled = false;
        player.GetComponent<Player>().Contained(gameObject);
        float t = Time.time;
        while (Time.time - t < flightTime)
        {
            player.transform.position = transform.position;
            rb.velocity = transform.up * speed;
            yield return null; 
            speed = Mathf.Clamp(speed, minMaxSpeed.x, minMaxSpeed.y);
            yield return null;

        }
        Explode();
    }

    public void Explode()
    {
        if(cargo != null)
        {
            cargo.GetComponent<Player>().Released();
            cargo.GetComponent<CircleCollider2D>().enabled = true;
            cargo.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        }
        Destroy(gameObject);
    }
}
