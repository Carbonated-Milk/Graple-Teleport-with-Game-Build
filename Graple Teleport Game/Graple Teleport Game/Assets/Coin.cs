using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool collected;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!collected)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GameManager.AddCoin();
            Destroy(this.gameObject, 3);
        }
    }
}
