using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boinger : MonoBehaviour
{

    public void OnCollisionEnter2D (Collision2D bounce)
    {
        Vector2 normal = -bounce.GetContact(0).normal;
        Rigidbody2D rb = bounce.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(normal * (700 + rb.velocity.sqrMagnitude));
    }
}