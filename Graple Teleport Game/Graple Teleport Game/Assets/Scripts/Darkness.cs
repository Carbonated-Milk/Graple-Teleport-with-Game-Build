using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    static float light;
    Color ogCol;
    ArrayList colors = new ArrayList();
    SpriteRenderer sr;
    public static bool isCalled;

    private void Awake()
    {
        if (isCalled) { return; }
        StartCoroutine(ChangeLight());
    }
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ogCol = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        sr.color = ogCol * new Color(light, light, light, 1);
    }

    public IEnumerator ChangeLight()
    {
        while (true)
        {
            yield return null;
            //light = Mathf.Clamp01(2f * (Mathf.PerlinNoise(0f, Time.time) - .5f));
            light = Mathf.Clamp01((Frac(-Time.time / 5) - .4f) * 2.5f);
        }
    }

    private float Frac(float num)
    {
        return num - Mathf.Floor(num);
    }
}
    