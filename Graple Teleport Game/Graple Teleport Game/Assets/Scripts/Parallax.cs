using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MasterBackground
{
    public Vector2 sizeArray;

    public bool scaling;
    public float sizeAdjust;
    private float length, height, startposX, startposY;
    public float parallaxEffect, parralaxY;
    [HideInInspector] public bool clone = false;
    public bool noTopRepeat;
    public bool localized;
    public bool screenRepeat;

    [HideInInspector] public Vector2 initialScale;
    void Start()
    {
        if(cam == null)
        {
            cam = FindObjectOfType<Camera>().transform;
            camera = cam.transform.GetComponent<Camera>();
        }
        


        startposX = transform.position.x;
        startposY = transform.position.y;

        if(parralaxY == 0) { parralaxY = parallaxEffect; }

        if (screenRepeat)
        {
            length = cam.GetComponent<Camera>().orthographicSize * 10 * Screen.width / Screen.height;
            height = cam.GetComponent<Camera>().orthographicSize * 10;
        }
        else
        {
            length = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
            height = GetComponentInChildren<SpriteRenderer>().bounds.size.y;
        }


        if (!clone)
        {
            initialScale = transform.localScale;

            Array();

        }
    }

    // Update is called once per frame
    void Update()
    {
        float tempx = (cam.position.x * (1 - parallaxEffect));
        float tempy = (cam.position.y * (1 - parralaxY));

        float distx = (cam.position.x * parallaxEffect);
        float disty = (cam.position.y * parralaxY);

        transform.position = new Vector3(startposX + distx, startposY + disty, transform.position.z);
        if (!localized)
        {
            if (tempx > startposX + length * (int)sizeArray.x / 2) startposX += (int)sizeArray.x * length;
            else if (tempx < startposX - length * (int)sizeArray.x / 2) startposX -= (int)sizeArray.x * length;

            if (!noTopRepeat)
            {
                if (tempy > startposY + height * (int)sizeArray.y / 2) startposY += (int)sizeArray.y * height;
                else if (tempy < startposY - height * (int)sizeArray.y / 2) startposY -= (int)sizeArray.y * height;
            }
        }

        if (scaling)
        {
            SpeedScale(transform.GetChild(0));
        }

    }

    private void SpeedScale(Transform image)
    {
        Vector3 camPos = cam.position;

        float imageBigger = camera.orthographicSize * sizeAdjust;
        imageBigger /= 20;

        Vector3 pointDist = new Vector3(camPos.x - transform.position.x, camPos.y - transform.position.y, 0f);

        float pointX = pointDist.x * imageBigger;
        float pointY = pointDist.y * imageBigger;

        image.transform.localScale = imageBigger * initialScale;
        image.transform.localPosition = (Vector2)cam.position - new Vector2(pointX + transform.position.x, pointY + transform.position.y);

    }

    void Array()
    {
        if (localized) { sizeArray = Vector2.one; }
        GameObject[] clones = new GameObject[(int)sizeArray.x * (int)sizeArray.y];

        for (int i = 0; i < sizeArray.x; i++)
        {
            /*for (int j = 0; j < sizeArray.y; j++)
            {
                clones[i + j] = new GameObject();
                clones[i + j].transform.position = transform.position + Vector3.right * length * i + Vector3.up * height * j;
                CopyComponent(this, clones[i + j]);
                clones[i + j].GetComponent<Parallax>().clone = true;

                GameObject empty = new GameObject();
                empty.transform.localScale = transform.localScale;
                CopyComponent(GetComponent<SpriteRenderer>(), empty);
                empty.transform.parent = clones[i + j].transform;

                empty.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
                empty.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder;
                empty.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
                empty.GetComponent<SpriteRenderer>().maskInteraction = GetComponent<SpriteRenderer>().maskInteraction;

                empty.transform.localPosition = Vector3.zero;
                Destroy(GetComponent<SpriteRenderer>());

                if (localized) { clones[i + j].transform.position -= parallaxEffect * clones[i + j].transform.position; }
            }*/
            for (int j = 0; j < sizeArray.y; j++)
            {
                clones[i + j] = new GameObject();
                clones[i + j].transform.position = transform.position + Vector3.right * length * i + Vector3.up * height * j;
                CopyComponent(this, clones[i + j]);
                clones[i + j].GetComponent<Parallax>().clone = true;

                GameObject copy = Instantiate(gameObject);
                copy.transform.parent = clones[i + j].transform;
                Destroy(copy.GetComponent<Parallax>());

                copy.transform.localPosition = Vector3.zero;

                if (localized) { clones[i + j].transform.position -= parallaxEffect * clones[i + j].transform.position; }
            }
            Destroy(gameObject);
        }

        void CopyComponent(Component original, GameObject destination)
        {
            System.Type type = original.GetType();
            Component copy = destination.AddComponent(type);
            // Copied fields can be restricted with BindingFlags
            System.Reflection.FieldInfo[] fields = type.GetFields();
            foreach (System.Reflection.FieldInfo field in fields)
            {
                field.SetValue(copy, field.GetValue(original));
            }
        }

    }
}
