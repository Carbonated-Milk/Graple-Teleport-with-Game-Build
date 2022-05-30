using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doubler : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>())
        {
            GameObject clone = Instantiate(other.gameObject);
            clone.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
