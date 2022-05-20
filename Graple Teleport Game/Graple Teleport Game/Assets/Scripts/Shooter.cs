using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    Transform player;
    public float speed;
    public float rotateSpeed;
    public LayerMask layerMask;
    public GameObject bullet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player = collision.gameObject.transform;
            StartCoroutine(ShootPlayer());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = null;
            StopAllCoroutines();
        }
    }
    public IEnumerator ShootPlayer()
    {
        while (true)
        {
            //hit = Physics2D.Raycast(transform.position, player.position, layerMask);
            Vector2 dist = player.position - transform.position;
            int neg = 1;
            if (dist.x > 0) { neg *= -1; }
            float targetRot = neg * Vector2.Angle(dist, Vector2.up);
            float specialNum = neg * Vector2.Angle(dist, Vector2.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.forward * specialNum), 60 * Time.deltaTime);
            if (Mathf.Abs(Vector2.Angle(dist, transform.up)) < .5)
            {
                ShootBullet();
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }

    public void ShootBullet()
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = transform.GetChild(0).transform.position;
        newBullet.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }
}
