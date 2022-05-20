using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFade : MonoBehaviour
{
    public Vector4 color1;
    public Vector4 color2;
    public float fadeSpeed;
    private SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        sprite.color = Mathf.Abs(Mathf.Sin(Time.time * fadeSpeed)) * color1 + Mathf.Abs(Mathf.Cos(Time.time * fadeSpeed)) * color2;
    }
}
