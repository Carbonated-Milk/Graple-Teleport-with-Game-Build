using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Vector2 sizeArray;
    private float length, height, startposX, startposY;
    public Transform cam;
    public float parallaxEffect;
    [HideInInspector] public bool clone = false;
    public bool noTopRepeat;
    // Start is called before the first frame update
    void Start()
    {
        if(cam == null)
        {
            cam = FindObjectOfType<Camera>().transform;
        }


        startposX = transform.position.x;
        startposY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;


        if (!clone)
        {
            GameObject[] clones = new GameObject[(int)sizeArray.x * (int)sizeArray.y];

            for (int i = 0; i < sizeArray.x; i++)
            {
                for(int j = 0; j < sizeArray.y; j++)
                {
                    clones[i + j] = Instantiate(gameObject);
                    clones[i + j].transform.position = transform.position + Vector3.right * length * i + Vector3.up * height * j;
                    clones[i + j].GetComponent<Parallax>().clone = true;
                }
            }
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float tempx = (cam.position.x * (1 - parallaxEffect));
        float tempy = (cam.position.y * (1 - parallaxEffect));

        float distx = (cam.position.x * parallaxEffect);
        float disty = (cam.position.y * parallaxEffect);

        transform.position = new Vector3(startposX + distx, startposY + disty, transform.position.z);

        if (tempx > startposX + length * (int)sizeArray.x/2) startposX += (int)sizeArray.x * length;
        else if (tempx < startposX - length * (int)sizeArray.x / 2) startposX -= (int)sizeArray.x * length;

        if (!noTopRepeat)
        {
            if (tempy > startposY + height * (int)sizeArray.y / 2) startposY += (int)sizeArray.y * height;
            else if (tempy < startposY - height * (int)sizeArray.y / 2) startposY -= (int)sizeArray.y * height;
        }
    }

}
