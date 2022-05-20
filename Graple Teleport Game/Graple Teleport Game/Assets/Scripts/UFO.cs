using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    private Transform beam;
    private bool sucking;
    private GameObject enemy;
    private Vector3 ogPlace, ogScale;


    private void Start()
    {
        beam = transform.GetChild(0);
        beam.localScale = Vector3.zero;
        ogPlace = transform.position;
        ogScale = transform.localScale;
    }
    private void Update()
    {
        if (!sucking && enemy == null)
        {
            SetRotation(.3f);
            //transform.position += Mathf.Cos(Time.time) * (Vector3)Physics2D.gravity.normalized/40;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && enemy == null && !sucking)
        {
            StopAllCoroutines();
            StartCoroutine(MoveTo(collision.gameObject));
            enemy = collision.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && enemy == null && !sucking)
        {
            StopAllCoroutines();
            StartCoroutine(MoveTo(collision.gameObject));
            enemy = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy = null;
        }
    }

    public IEnumerator MoveTo(GameObject enemy)
    {

        sucking = true;
        int times = 3;
        yield return StartCoroutine(Small(beam, 1, Vector3.one));
        for (int i = 0; i < times; i++)
        {
            yield return StartCoroutine(Small(transform, 5, Vector3.up));

            transform.position = enemy.transform.position + (Vector3)RandomFunctions.RandomVector() * Random.Range(5f, 10f);
            if (i == times - 1)
            {
                if(Physics2D.gravity == Vector2.zero)
                {
                    transform.position = enemy.transform.position - Vector3.down * 8 * ogScale.y;
                }
                else
                {
                    transform.position = enemy.transform.position - (Vector3)Physics2D.gravity.normalized * 8 * ogScale.y;
                }
            }

            SetRotation(1);

            yield return StartCoroutine(Grow(transform, 5, Vector3.up, ogScale.y));

            if (i != times - 1) { yield return new WaitForSeconds(Random.Range(.5f, 1f)); }
        }
        StartCoroutine(Attack());

    }

    public IEnumerator Attack()
    {
        yield return StartCoroutine(Grow(beam, 1, Vector3.one, 1));

        yield return new WaitForSeconds(5);

        yield return StartCoroutine(Small(beam, 1, Vector3.one));
        sucking = false;

        if (enemy != null)
        {
            StartCoroutine(MoveTo(enemy));
        }
        else
        {
            StartCoroutine(Return());
        }
    }
    public IEnumerator Return()
    {
        yield return StartCoroutine(Small(beam, 1, Vector3.one));
        yield return StartCoroutine(Small(transform, 3, Vector3.up));
        SetRotation(1);
        transform.position = ogPlace;
        yield return StartCoroutine(Grow(transform, 3, Vector3.up, ogScale.y));
    }

    public IEnumerator Small(Transform obj, float time, Vector3 changeVector)
    {
        while (obj.localScale.y > 0)
        {
            obj.localScale -= changeVector * time * Time.deltaTime;
            yield return null;
        }
    }
    public IEnumerator Grow(Transform obj, float time, Vector3 changeVector, float ogScale)
    {
        while (obj.localScale.y < ogScale)
        {
            obj.localScale += changeVector * time * Time.deltaTime;
            yield return null;
        }
    }

    public void SetRotation(float time)
    {
        int neg = 1;
        if(Physics2D.gravity.x < 0) { neg *= -1; }
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(Vector3.forward * neg * Vector2.Angle(-Physics2D.gravity, Vector2.up)), time);
    }
}
