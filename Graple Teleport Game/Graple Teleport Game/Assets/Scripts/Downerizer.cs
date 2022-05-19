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
        float num = Mathf.Sin(2 * Time.time) / 8 + .875f;
        arrow.color = new Vector4(num, num, 1, 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(newGravity != 0)
            {
                collision.GetComponent<Player>().ChangeDown(new Vector2(transform.right.y, -transform.right.x), newGravity);
            }
            else
            {
                collision.GetComponent<Player>().ChangeDown(new Vector2(transform.right.y, -transform.right.x));
            }
        }
    }
}
