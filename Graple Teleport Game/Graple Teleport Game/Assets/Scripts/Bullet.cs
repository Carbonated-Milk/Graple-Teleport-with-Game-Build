using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float trackSpeed;
    public float correctSpeed;
    public bool seeking;
    Rigidbody2D rb;
    public Transform player;
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(seeking)
        {
            Vector2 relPos = player.position - transform.position;
            rb.AddForce(relPos.normalized * trackSpeed * 100 * Time.deltaTime);

            Vector2 speedCorrect = rb.velocity - relPos.normalized * Vector2.Dot(rb.velocity, relPos.normalized);
            rb.AddForce(-speedCorrect * correctSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Player>())
        {
            collision.collider.GetComponent<Player>().Hurt(20);
        }
        Destroy(gameObject);
    }
}
