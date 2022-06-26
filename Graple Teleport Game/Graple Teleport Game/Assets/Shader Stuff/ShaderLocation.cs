using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderLocation : MasterBackground
{
    private Material material;
    void Start()
    {
        if (cam == null)
        {
            material = GetComponent<SpriteRenderer>().material;
            cam = FindObjectOfType<Camera>().transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(material != null)
        {
            Vector3 position = cam.position;
            material.SetVector("_location", position);
        }
        else
        {
            material = GetComponent<SpriteRenderer>().material;
        }
    }
}
