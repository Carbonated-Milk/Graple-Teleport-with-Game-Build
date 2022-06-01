using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    private TMP_Text text;

    public static float coinCount = 0;
    void Awake()
    {
        /*if (GameManager.coinManager == null)
        {
            GameManager.coinManager = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }*/
        GameManager.coinManagers.Add(this);
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddCoin()
    {
        coinCount += 1;
        text.text = coinCount.ToString();
    }

    public void ReloadText()
    {
        text.text = coinCount.ToString();
    }
}
