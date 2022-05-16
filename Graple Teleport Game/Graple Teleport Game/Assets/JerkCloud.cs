using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerkCloud : MonoBehaviour
{
    public GameObject bullet;
    private Transform player;
    public float speed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Shoot());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator Shoot()
    {
        while(true)
        {
            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.position = transform.position;
            newBullet.GetComponent<Rigidbody2D>().velocity = (player.position - transform.position).normalized * speed;
            yield return new WaitForSeconds(1);
        }
    }
}
