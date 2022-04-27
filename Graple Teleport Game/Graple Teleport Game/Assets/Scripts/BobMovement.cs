using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobMovement : MonoBehaviour
{
    public Transform bounds;

    public float horizontalSpeed;

    public float bobSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.right * Mathf.Sin(horizontalSpeed * Mathf.PI * Time.time) * bounds.localScale.x/2 + Vector2.up * Mathf.Sin(bobSpeed * Mathf.PI * Time.time) * bounds.localScale.y/2 + (Vector2)bounds.position;
    }
}
