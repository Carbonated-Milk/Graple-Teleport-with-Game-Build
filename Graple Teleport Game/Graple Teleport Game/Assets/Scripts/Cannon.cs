using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    bool active;
    public float rotateSpeed;
    public GameObject contained;
    public float launchPower;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().Contained(gameObject);
            active = true;
            contained = collision.gameObject;
            StartCoroutine(Shoot());
        }
    }

    public IEnumerator Shoot()
    {
        while(!Input.GetKeyDown("space"))
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
            yield return null;
        }

        contained.GetComponent<Player>().Released();
        contained.GetComponent<Rigidbody2D>().velocity = transform.up * launchPower;
    }
}
