using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suck : MonoBehaviour
{
    public float suckPower;

    public GameObject kcuS;

    private List<GameObject> suckObjects;
    void Start()
    {
        suckObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < suckObjects.Count; i++)
        {
            Vector2 relPos = transform.position - suckObjects[i].transform.position;
            Vector2 forceAdd = relPos.normalized * suckPower / relPos.sqrMagnitude;
            suckObjects[i].GetComponent<Rigidbody2D>().AddForce(forceAdd * Time.deltaTime * 100);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject pranked = collision.gameObject;
        if(suckObjects.Count == 0)
        {
            suckObjects.Add(pranked);
        }
        else
        {
            for (int i = 0; i < suckObjects.Count; i++)
            {
                if (pranked == suckObjects[i])
                {
                    suckObjects.Remove(pranked);
                    if (kcuS == null)
                    {
                        if (pranked.CompareTag("Player"))
                        {
                            pranked.GetComponent<Player>().OhNo();
                        }
                        else
                        {
                            Destroy(pranked);
                        }
                    }
                    else
                    {
                        pranked.transform.position = kcuS.transform.position + transform.position - pranked.transform.position;
                        Rigidbody2D suckRB = pranked.GetComponent<Rigidbody2D>();
                        suckRB.velocity = suckRB.velocity.normalized * 5;
                    }

                }
                else
                {
                    suckObjects.Add(pranked);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < suckObjects.Count; i++)
        {
            if (collision.gameObject == suckObjects[i])
            {
                suckObjects.Remove(collision.gameObject);
                break;
            }
        }
    }
}
