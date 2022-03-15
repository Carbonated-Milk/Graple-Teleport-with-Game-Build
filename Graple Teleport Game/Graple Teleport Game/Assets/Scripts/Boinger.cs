using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boinger : MonoBehaviour
{

    public void OnCollisionEnter2D (Collision2D bounce)
    {
        Rigidbody2D rb = bounce.gameObject.GetComponent<Rigidbody2D>();
        Vector2 dirVec = (bounce.transform.position - transform.position).normalized;
        rb.AddForce(dirVec * (700 + rb.velocity.sqrMagnitude));
    }
}