using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    public Vector2 onOffTime;
    public Component target;
    void Start()
    {
        StartCoroutine(OnOff());
    }

    public IEnumerator OnOff()
    {
        while(true)
        {
            target.gameObject.SetActive(true);
            yield return new WaitForSeconds(onOffTime.x);
            target.gameObject.SetActive(false);
            yield return new WaitForSeconds(onOffTime.y);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
