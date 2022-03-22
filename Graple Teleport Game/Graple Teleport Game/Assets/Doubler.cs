using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doubler : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("clone");
        if (other.GetComponent<Rigidbody2D>())
        {
            GameObject clone = Instantiate(other.gameObject);
            clone.transform.position = Vector2.zero;
        }
    }
}
