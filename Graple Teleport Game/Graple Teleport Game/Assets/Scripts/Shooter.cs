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
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        StartCoroutine(ShootPlayer());
    }

    public IEnumerator FindPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.position, layerMask);
        while (hit.collider.CompareTag("Player"))
        {
            hit = Physics2D.Raycast(transform.position, player.position);
            yield return new WaitForSeconds(.1f);
        }
        StartCoroutine(ShootPlayer());
    }

    public IEnumerator ShootPlayer()
    {
        while (Vector3.SqrMagnitude(transform.position - player.position) < 50 * 50)
        {
            //hit = Physics2D.Raycast(transform.position, player.position, layerMask);
            Vector2 dist = player.position - transform.position;
            int neg = 1;
            if (Physics2D.gravity.x < 0) { neg *= -1; }
            float targetRot = neg * Vector2.Angle(dist, Vector2.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.forward * targetRot), 30f);

            if (Mathf.Abs(transform.rotation.z - transform.rotation.z) < .5)
            {
                ShootBullet();
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
        
        StartCoroutine(FindPlayer());
    }

    public void ShootBullet()
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = transform.GetChild(0).transform.position;
        newBullet.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }
}
