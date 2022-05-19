using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryBackground : MonoBehaviour
{
    private Transform cam;
    private Camera camera;
    private float ogOrthographic;
    private Vector3 ogScale;
    void Start()
    {
        cam = FindObjectOfType<Camera>().transform;
        camera = cam.transform.GetComponent<Camera>();

        ogScale = transform.localScale;
        ogOrthographic = camera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cam.position.x, cam.position.y, transform.position.z);
        transform.localScale = ogScale * camera.orthographicSize / ogOrthographic;
    }
}
