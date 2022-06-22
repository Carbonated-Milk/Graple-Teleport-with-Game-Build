using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class AutoScroll : MonoBehaviour
{
    public PathFollower pF;
    public int ins = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ins += 1;
            collision.transform.GetComponent<Player>().cam.targetBounds = transform;
            pF.wait = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.GetComponent<Player>().cam.targetBounds = null;
            ins -= 1;
            if(ins == 0)
            {
                pF.distanceTravelled = 0;
                pF.wait = true;
            }
        }
    }
}
