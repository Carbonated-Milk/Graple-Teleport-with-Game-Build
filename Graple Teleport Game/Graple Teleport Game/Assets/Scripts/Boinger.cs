using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boinger : MonoBehaviour
{
    public bool mathBounce;
    public float bouncePow;

    public void OnCollisionEnter2D(Collision2D bounce)
    {
        Vector2 normal = -bounce.GetContact(0).normal;
        Rigidbody2D rb = bounce.gameObject.GetComponent<Rigidbody2D>();
        if (mathBounce)
        {
            Vector2 newVel = bounce.relativeVelocity - 2 * normal * Vector2.Dot(bounce.relativeVelocity, normal);
            rb.velocity = newVel.normalized * bounce.relativeVelocity.magnitude * bouncePow;
        }
        else
        {
            rb.AddForce(normal * (700 + rb.velocity.sqrMagnitude));
        }
    }
}