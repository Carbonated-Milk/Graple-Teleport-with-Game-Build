using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boinger : MonoBehaviour
{
    public float plinkoNum;
    public bool mathBounce;
    public float bouncePow;

    public void Start()
    {
        if (plinkoNum == 0) plinkoNum = 7;
    }

    public void OnCollisionEnter2D(Collision2D bounce)
    {
        Vector2 normal = -bounce.GetContact(0).normal;
        Rigidbody2D rb = bounce.gameObject.GetComponent<Rigidbody2D>();
        GameManager.audioManager.Play("Boing");
        if (mathBounce)
        {
            Vector2 newVel = bounce.relativeVelocity - 2 * normal * Vector2.Dot(bounce.relativeVelocity, normal);
            rb.velocity = newVel.normalized * Mathf.Min(bounce.relativeVelocity.magnitude * bouncePow, 100f);
        }
        else
        {
            rb.AddForce(normal * (plinkoNum * 100 + rb.velocity.sqrMagnitude));
        }
    }
}