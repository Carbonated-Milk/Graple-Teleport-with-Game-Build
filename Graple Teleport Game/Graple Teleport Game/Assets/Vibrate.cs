using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrate : MonoBehaviour
{
    public Vector4[] vibrations;
    private Vector3 netChange = Vector3.zero;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= netChange;
        netChange = Vector4.zero;
        foreach(Vector4 v in vibrations)
        {
            switch(v.w)
            {
                case 1:
                    netChange += v.y * Mathf.Sin(Time.time * v.x + v.z) * Vector3.right;
                    break;
                case 2:
                    netChange += v.y * Mathf.Sin(Time.time * v.x + v.z) * Vector3.up;
                    break;
                case 3:
                    netChange += v.y * Mathf.Sin(Time.time * v.x + v.z) * Vector3.forward;
                    break;
            }
            
        }
        transform.position += netChange;
    }
}
