using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour

{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            GameManager.menuManager.transform.Find("Level Complete").gameObject.SetActive(true);
            GameManager.menuManager.transform.Find("PlayerUI").gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }
}
