using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool collected;

    private Vector3 position;
    private Vector3 scale;
    private void Start()
    {
        position = transform.position;
        scale = transform.localScale;
    }
    private void Update()
    {
        transform.position = position + Vector3.up * Mathf.Sin(Time.time) / 2;
        transform.localScale = scale - Vector3.right * (1 + Mathf.Sin(Time.time)/2) / 8;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!collected)
        {
            GameManager.audioManager.Play("Coin");
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<ParticleSystem>().Play();
            GameManager.AddCoin();
            Destroy(this.gameObject, 3);
            collected = true;
        }
    }
}
