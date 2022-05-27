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
    private ParticleSystem particals;
    void Start()
    {
        originalPos = transform.position;
        smashPos = Physics2D.Raycast(transform.position, -transform.up).point;
        StartCoroutine(Running());
        particals = GetComponent<ParticleSystem>();
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
        transform.GetChild(0).tag = "Death";
        while(transform.position != smashPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, smashPos, speed);
            yield return null;
        }
        up = false;
        particals.Play();
    }
    public IEnumerator Release()
    {
        transform.GetChild(0).tag = "Untagged";
        while (transform.position != originalPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, originalPos, speed/2);
            yield return null;
        }
        up = true;
    }

}
