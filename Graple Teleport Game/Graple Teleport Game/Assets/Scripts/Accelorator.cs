using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelorator : MonoBehaviour
{
    public float acceleration;
    private List<Rigidbody2D> bodies;

    // Update is called once per frame
    void Update()
    {
        foreach(Rigidbody2D body in bodies)
        {
            body.AddForce(transform.up * acceleration * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bodies.Add(collision.GetComponent<Rigidbody2D>());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bodies.Remove(collision.GetComponent<Rigidbody2D>());
    }
}
