using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelorator : MonoBehaviour
{
    public float speedUp;
    public bool insta;
    private List<Rigidbody2D> bodies;

    private void Start()
    {
        bodies = new List<Rigidbody2D>();
    }
    void Update()
    {
        if(!insta)
        {
            foreach (Rigidbody2D body in bodies)
            {
                body.AddForce(transform.up * speedUp * Time.deltaTime);
            }
        }
        else
        {
            foreach (Rigidbody2D body in bodies)
            {
                body.velocity = transform.up * speedUp;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bodies.Add(collision.GetComponent<Rigidbody2D>());
        if(insta)
        {
            GrapplingHook.canGraple = false;
            RandomFunctions.TurnOffGrapple();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bodies.Remove(collision.GetComponent<Rigidbody2D>());
        if (insta)
        {
            GrapplingHook.canGraple = true;
        }
    }
}
