using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed;
    public float scaleSpeed;

    private GameObject player;
    public float speedSizeBoost;

    public float minSize;
    public float maxSize;

    private Rigidbody2D playerRb;
    private Camera cam;
    public static Transform targetBounds;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(targetBounds == null)
        {
            FollowPlayer();
        }
        else
        {
            MovetoBounds();
        }
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position - new Vector3(0, 0, 10), moveSpeed / 100);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, Mathf.Clamp(speedSizeBoost * player.GetComponent<Rigidbody2D>().velocity.magnitude, minSize, maxSize), scaleSpeed / 100);
    }

    public void MovetoBounds()
    {
        transform.position = Vector3.Lerp((Vector2)transform.position, (Vector2)targetBounds.position, moveSpeed / 100);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetBounds.localScale.x/2 * Screen.height / Screen.width, moveSpeed / 100);
    }

    public void RotateCamera(float newAngle)
    {
        StopAllCoroutines();
        StartCoroutine(RotateCameraEnum(newAngle));
    }
    public IEnumerator RotateCameraEnum(float newAngle)
    {
        float changeTime = Time.time;
        while (Time.time - changeTime < 2)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(Vector3.forward * (newAngle) * Mathf.Rad2Deg), 0.05f);
            
            yield return null;
        }
    }
}
