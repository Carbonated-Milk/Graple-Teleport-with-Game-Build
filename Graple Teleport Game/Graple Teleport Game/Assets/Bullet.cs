using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
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
            rb.AddForce(relPos.normalized * 500 * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Player>())
        {
            collision.collider.GetComponent<Player>().OhNo();
        }
        Destroy(gameObject);
    }
}
