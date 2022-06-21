using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Downerizer : MonoBehaviour
{
    public bool changeStrength;
    public float newGravity;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(transform.right.x < 0)
            {

            }
            
            bool same;
            if(changeStrength)
            {
                same = collision.GetComponent<Player>().ChangeDown(new Vector2(transform.right.y, -transform.right.x), newGravity);
            }
            else
            {
                same = collision.GetComponent<Player>().ChangeDown(new Vector2(transform.right.y, -transform.right.x));
            }

            if(!same)
            {
                GameManager.audioManager.Play("GravitySwap");
            }
        }
    }
}
