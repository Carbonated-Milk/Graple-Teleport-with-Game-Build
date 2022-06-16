using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class Crane : MonoBehaviour
{
    public float grabSpeed;
    private Transform leg1, leg2;
    private PathFollower pathFollower;
    bool busy = false;
    // Start is called before the first frame update
    void Start()
    {
        leg1 = transform.GetChild(0).transform;
        leg2 = transform.GetChild(1).transform;

        pathFollower = GetComponent<PathFollower>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") &! busy)
        {
            busy = true;
            StartCoroutine(Transport(collision.GetComponent<Player>()));
        }
    }

    private IEnumerator Transport(Player player)
    {
        player.Contained(transform.Find("HoldingPosition").gameObject, true);

        yield return StartCoroutine(Grab());

        yield return StartCoroutine(Move(0 , 1, 5));

        player.Released();
        yield return StartCoroutine(Release());

        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(Move(1, 0, 3));

        busy = false;
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

    private IEnumerator Move(float start, float end, float time)
    {
        float length = pathFollower.pathCreator.path.length;
        float t = 0f;
        while(t < time)
        {
            pathFollower.distanceTravelled = RandomFunctions.SmoothStep(Mathf.Lerp(start, end, t / time)) * length;
            yield return null;
            t += Time.deltaTime;
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
