using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    private Transform beam;
    private bool sucking;
    private GameObject enemy;
    private Vector3 ogPlace;


    private void Start()
    {
        beam = transform.GetChild(0);
        beam.localScale = Vector3.zero;
        ogPlace = transform.position;
    }
    private void Update()
    {
        if (!sucking)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(Vector3.forward * Vector2.Angle(-Physics2D.gravity, Vector2.up)), 0.3f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && enemy == null)
        {
            StartCoroutine(MoveTo(collision.gameObject));
            enemy = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(Return());
            enemy = null;
        }
    }

    public IEnumerator MoveTo(GameObject enemy)
    {
        int times = 3;
        for (int i = 0; i < times; i++)
        {
            yield return StartCoroutine(Small(transform, 3, Vector3.up));

            transform.position = enemy.transform.position + (Vector3)RandomFunctions.RandomVector() * Random.Range(5f, 10f);
            if (i == times - 1)
            {
                transform.position = enemy.transform.position - (Vector3)Physics2D.gravity.normalized * 8;
                Debug.Log(i);
            }

            yield return StartCoroutine(Grow(transform, 3, Vector3.up));

            if (i != times - 1) { yield return new WaitForSeconds(1f); }
        }
        StartCoroutine(Attack());

    }

    public IEnumerator Attack()
    {
        sucking = true;
        yield return StartCoroutine(Grow(beam, 1, Vector3.one));

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
        yield return StartCoroutine(Small(transform, 3, Vector3.up));
        transform.position = ogPlace;
        yield return StartCoroutine(Grow(transform, 3, Vector3.up));
    }

    public IEnumerator Small(Transform obj, float time, Vector3 changeVector)
    {
        while (transform.localScale.y > 0)
        {
            obj.localScale -= changeVector * time * Time.deltaTime;
            yield return null;
        }
    }
    public IEnumerator Grow(Transform obj, float time, Vector3 changeVector)
    {
        while (transform.localScale.y < 1)
        {
            obj.localScale += changeVector * time * Time.deltaTime;
            yield return null;
        }
    }
}
