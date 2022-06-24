using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryBackground : MasterBackground
{
    public Vector2 offset;
    private float ogOrthographic;
    private Vector3 ogScale;
    void Start()
    {
        if(cam == null)
        {
            cam = FindObjectOfType<Camera>().transform;
            camera = cam.transform.GetComponent<Camera>();
        }

        ogScale = transform.localScale;
        ogOrthographic = camera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        float sizeScale = camera.orthographicSize / ogOrthographic;
        transform.position = new Vector3(cam.position.x, cam.position.y, transform.position.z) + (Vector3)offset * sizeScale;
        transform.localScale = ogScale * sizeScale;
    }
}


