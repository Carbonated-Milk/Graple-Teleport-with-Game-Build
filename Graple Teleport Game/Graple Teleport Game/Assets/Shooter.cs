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
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, player.position, layerMask);
        //Debug.Log(hit.collider);
        while (true)
        {
            //hit = Physics2D.Raycast(transform.position, player.position, layerMask);
            Vector2 dist = player.position - transform.position;
            float targetRot = Mathf.Atan2(dist.y, dist.x);
            transform.rotation = Quaternion.Euler(Vector3.forward * (Mathf.Lerp(transform.rotation.z, targetRot, .1f) * Mathf.Rad2Deg));
            //Debug.Log(targetRot);
            if (Mathf.Abs(targetRot - transform.rotation.z) < .5)
            {
                ShootBullet();
                yield return new WaitForSeconds(.5f);
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
