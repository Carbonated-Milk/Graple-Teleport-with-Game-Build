using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, height, startposX, startposY;
    public GameObject cam;
    public float parallaxEffect;
    [HideInInspector] public bool clone = false;
    // Start is called before the first frame update
    void Start()
    {
        startposX = transform.position.x;
        startposY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
        if (!clone)
        {
            GameObject[] clones = new GameObject[3];
            clones[0] = Instantiate(gameObject);
            clones[0].transform.position = transform.position + Vector3.up * height;
            clones[1] = Instantiate(gameObject);
            clones[1].transform.position = transform.position + Vector3.right * length;
            clones[2] = Instantiate(gameObject);
            clones[2].transform.position = transform.position + Vector3.right * length + Vector3.up * height;
            foreach (GameObject clone in clones)
            {
                clone.GetComponent<Parallax>().clone = true;
            }
        }
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
