using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public float disappearTime;
    public float reappearTime;
    private bool activeCoroutine = false;

    private BoxCollider2D collider;
    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(disappear());
    }

    IEnumerator disappear()
    {
        if (!activeCoroutine)
        {
            yield return new WaitForSeconds(disappearTime);
            collider.enabled = false;
            renderer.enabled = false;
            RandomFunctions.TurnOffGrapple(transform);

            yield return new WaitForSeconds(reappearTime);
            collider.enabled = true;
            renderer.enabled = true;
        }
    }
}
