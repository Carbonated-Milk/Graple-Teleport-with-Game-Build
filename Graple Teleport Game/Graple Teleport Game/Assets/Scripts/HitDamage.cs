using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDamage : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.CompareTag("Player"))
        {
            other.collider.GetComponent<Player>().Hurt(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Hurt(damage);
        }
    }
}
