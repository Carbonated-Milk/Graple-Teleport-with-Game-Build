using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pounder : MonoBehaviour
{
    public float timeInverval;
    private Vector3 originalPos;
    private Vector3 smashPos;
    private bool up = true;
    public float speed;
    void Start()
    {
        originalPos = transform.position;
        smashPos = Physics2D.Raycast(transform.position, -transform.up).point;
        StartCoroutine(Running());
        Physics2D.queriesStartInColliders = false;
    }

    public IEnumerator Running()
    {
        float deltaTime = 0;
        while(true)
        {
            deltaTime += Time.deltaTime;
            if(deltaTime > timeInverval)
            {
                if (up) { StartCoroutine(Pound()); }
                else { StartCoroutine(Release()); }
                deltaTime = 0;
            }
            yield return null;
        }
    }

    public IEnumerator Pound()
    {
        while(transform.position != smashPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, smashPos, speed);
            yield return null;
        }
        up = false;
    }
    public IEnumerator Release()
    {
        while(transform.position != originalPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, originalPos, speed);
            yield return null;
        }
        up = true;
    }

}
