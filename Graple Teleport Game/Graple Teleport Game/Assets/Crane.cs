using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    private Transform leg1, leg2;
    // Start is called before the first frame update
    void Start()
    {
        leg1 = transform.GetChild(0).transform;
        leg2 = transform.GetChild(1).transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Grab()
    {
        while(leg1.rotation.z > 0)
        {
            leg1.rotation *= Quaternion.Euler(Vector3.forward * -5 * Time.deltaTime);
            leg2.rotation *= Quaternion.Euler(Vector3.forward * 5 * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator Release()
    {
        while (leg1.rotation.z < 40 * Mathf.Deg2Rad)
        {
            leg1.rotation *= Quaternion.Euler(Vector3.forward * 5 * Time.deltaTime);
            leg2.rotation *= Quaternion.Euler(Vector3.forward * -5 * Time.deltaTime);
            yield return null;
        }
    }
}
