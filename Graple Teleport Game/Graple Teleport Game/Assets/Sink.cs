using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    public float viscocity;
    public Vector2 speed;
    private ArrayList trapped = new ArrayList();
    private ArrayList players = new ArrayList();
    void Start()
    {
        Material material = GetComponent<SpriteRenderer>().material;
        material.SetVector("_move", speed);
    }

    // Update is called once per frame
    void Update()
    {
        Material material = GetComponent<SpriteRenderer>().material;
        material.SetVector("_move", speed);

        foreach (Rigidbody2D rb in trapped)
        {
            float num = 1;
            if(rb.velocity.y - speed.y > 0) { num = .001f; }
            rb.velocity = Vector2.MoveTowards(rb.velocity, speed, viscocity * num);
        }
        foreach (Player p in players)
        {
            p.canJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            trapped.Add(collision.gameObject.GetComponent<Rigidbody2D>());
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            players.Add(collision.gameObject.GetComponent<Player>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            trapped.Remove(collision.gameObject.GetComponent<Rigidbody2D>());
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            players.Remove(collision.gameObject.GetComponent<Player>());
        }
    }
}
