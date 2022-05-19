using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Downerizer : MonoBehaviour
{
    public float newGravity;
    private SpriteRenderer arrow;

    private void Start()
    {
        arrow = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float num = Mathf.Sin(4 * Time.time) / 6 + .9f;
        arrow.color = new Vector4(num, num, 1, 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(transform.right.x < 0)
            {

            }
            
            bool same;
            if(newGravity != 0)
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
