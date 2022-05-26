using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalLocation : MonoBehaviour
{
    private Transform playerCam;
    private Material material;
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        playerCam = FindObjectOfType<Camera>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        material.SetVector("_location", playerCam.position);
    }
}
