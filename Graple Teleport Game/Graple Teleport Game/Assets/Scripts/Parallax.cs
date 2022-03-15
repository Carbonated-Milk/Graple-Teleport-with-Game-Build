using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, height, startposX, startposY;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startposX = transform.position.x;
        startposY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float tempx = (cam.transform.position.x * (1 - parallaxEffect));
        float tempy = (cam.transform.position.y * (1 - parallaxEffect));

        float distx = (cam.transform.position.x * parallaxEffect);
        float disty = (cam.transform.position.y * parallaxEffect);

        transform.position = new Vector3(startposX + distx, startposY + disty, transform.position.z);

        if (tempx > startposX + length) startposX += 2 * length;
        else if (tempx < startposX - length) startposX -= 2 * length;

        if (tempy > startposY + height) startposY += 2 * height;
        else if (tempy < startposY - height) startposY -= 2 * height;
    }
}
