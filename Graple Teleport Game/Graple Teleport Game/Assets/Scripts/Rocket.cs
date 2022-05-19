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
    // Start is called before the first frame update

    private float originalSpeed;
    void Start()
    {
        if(minMaxSpeed == Vector2.zero)
        {
            minMaxSpeed = Vector2.one * speed;
        }
        originalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Launch(collision.gameObject));
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
            yield return null; if (Input.GetKey("a"))
            {
                transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime * speed / originalSpeed);
            }
            if (Input.GetKey("d"))
            {
                transform.Rotate(Vector3.forward * -rotateSpeed * Time.deltaTime * speed / originalSpeed);
            }
            if (Input.GetKey("w"))
            {
                speed += acceleration * Time.deltaTime;
            }
            if (Input.GetKey("s"))
            {
                speed -= acceleration * Time.deltaTime;
            }
            speed = Mathf.Clamp(speed, minMaxSpeed.x, minMaxSpeed.y);
            yield return null;

        }
        player.GetComponent<CircleCollider2D>().enabled = true;
        player.GetComponent<Player>().Released();
        player.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        Destroy(gameObject);
    }
}
