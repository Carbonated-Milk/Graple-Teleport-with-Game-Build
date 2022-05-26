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
    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
        material = renderer.material;
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
            RandomFunctions.TurnOffGrapple(transform);
            StartCoroutine(Smaller());

            yield return new WaitForSeconds(reappearTime);
            StartCoroutine(Bigger());
            collider.enabled = true;
        }
    }

    IEnumerator Smaller()
    {
        while(material.GetFloat("_Fade") > 0)
        {
            material.SetFloat("_Fade", material.GetFloat("_Fade") - 3 * Time.deltaTime);
                yield return null;
        }
    }
    IEnumerator Bigger()
    {
        while (material.GetFloat("_Fade") < 1)
        {
            material.SetFloat("_Fade", material.GetFloat("_Fade") + 3 * Time.deltaTime);
            yield return null;
        }
    }
}
