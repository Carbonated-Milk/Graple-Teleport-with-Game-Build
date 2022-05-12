using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFunctions : MonoBehaviour
{
    public static GameObject ShootFindVelocity(float shootAngle, float distError, Transform shootPoint, Transform target, GameObject thrownObj, string AudioName)
    {
        FindObjectOfType<AudioManager>().Play(AudioName);

        float shootAngleRad = shootAngle;
        if (shootAngle < Mathf.PI / 2 && shootAngle > -Mathf.PI / 2) { shootAngleRad -= Random.Range(5, 50f) * Mathf.Deg2Rad; }
        else { shootAngleRad += Random.Range(5, 50f) * Mathf.Deg2Rad; }
                //if(shootAngle < Mathf.PI / 2) { shootAngleRad += Random.Range(10, 30) * Mathf.Deg2Rad; }
                //else { shootAngleRad -= Random.Range(10, 30) * Mathf.Deg2Rad; }

                float gravity = Physics.gravity.y;

        float distance = target.position.x - shootPoint.position.x;

        float heightDifference = target.position.y - shootPoint.position.y;

        float objVelocity = Mathf.Sqrt(Mathf.Abs(gravity * distance / (2 * (Mathf.Cos(shootAngleRad) * (Mathf.Sin(shootAngleRad) - Mathf.Cos(shootAngleRad) * heightDifference / distance)))));
        
        //Debug.Log(fruitVelocity);
        if (objVelocity != float.NaN)
        {
            GameObject spawnedObj = Instantiate(thrownObj);
            spawnedObj.transform.position = shootPoint.position;
            spawnedObj.GetComponent<Rigidbody2D>().velocity = -(Vector3.right * Mathf.Cos(shootAngleRad) + Vector3.up * Mathf.Sin(shootAngleRad)) * objVelocity;

            return spawnedObj;
        }

        return null;
    }

    public static Vector3 FindDistError(float shootError)
    {
        float random = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector3 distError = new Vector3(Mathf.Sin(random), 0f, Mathf.Cos(random)) * Random.Range(0f, 1f) * shootError;
        return distError;
    }

    public static IEnumerator Invincibility(float time, bool isVincible)
    {
        isVincible = false;
        yield return new WaitForSeconds(time);
        isVincible = true;
    }

    public static void TurnOffGrapple()
    {
        FindObjectOfType<GrapplingHook>().TurnOffGrapple();
    }
    public static void TurnOffGrapple(Transform obj)
    {
        if(FindObjectOfType<GrapplingHook>().grap.grip.parent == obj)
        {
            FindObjectOfType<GrapplingHook>().TurnOffGrapple();
        }
        
    }
}
