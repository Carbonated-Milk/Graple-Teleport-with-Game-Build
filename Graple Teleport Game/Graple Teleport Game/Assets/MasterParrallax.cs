using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MasterParrallax : MonoBehaviour
{
    int layer = 31;

    private void Awake()
    {
        FindObjectOfType<PlayerInputManager>().playerJoinedEvent.AddListener(OnPlayerJoined);
        transform.position = Vector3.zero;
    }
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Camera cam = playerInput.transform.parent.gameObject.GetComponentInChildren<Camera>();
        Parallax[] parallax = GetComponentsInChildren<Parallax>();

        foreach(Parallax p in parallax)
        {
            Debug.Log(p);
            GameObject newBack = Instantiate(p.gameObject);
            newBack.GetComponent<SpriteRenderer>().enabled = true;
            Parallax newP = newBack.GetComponent<Parallax>();
            newP.cam = cam.transform;
            newP.camera = cam;
            RemoveLayer(cam, layer);
            newBack.layer = layer;
            newP.enabled = true;
        }
        layer -= 1;

    }

    private void RemoveLayer(Camera camera, int layer)
    {
        Camera[] cams = FindObjectsOfType<Camera>();
        foreach(Camera c in cams)
        {
            c.cullingMask = c.cullingMask & ~(1 << layer);
        }
        camera.cullingMask = camera.cullingMask | (1 << layer);
    }
}
