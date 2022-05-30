using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    public float grabSpeed;
    private Transform leg1, leg2;
    // Start is called before the first frame update
    void Start()
    {
        leg1 = transform.GetChild(0).transform;
        leg2 = transform.GetChild(1).transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Transport(collision.GetComponent<Player>());
        }
    }

    private IEnumerator Transport(Player player)
    {
        player.Contained(transform.gameObject);
        yield return StartCoroutine(Grab());

        yield return new WaitForSeconds(3);

        player.Released();
        yield return StartCoroutine(Release());
    }

    private IEnumerator Grab()
    {
        while (leg2.rotation.z > 0)
        {
            leg1.rotation *= Quaternion.Euler(Vector3.forward * grabSpeed * Time.deltaTime);
            leg2.rotation *= Quaternion.Euler(Vector3.forward * -grabSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator Release()
    {
        while (leg2.rotation.z < 20 * Mathf.Deg2Rad)
        {
            leg1.rotation *= Quaternion.Euler(Vector3.forward * -grabSpeed * Time.deltaTime);
            leg2.rotation *= Quaternion.Euler(Vector3.forward * grabSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
