using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MasterParrallax : MonoBehaviour
{
    public ArrayList players = new ArrayList();
    int layer = 31;

    private void Awake()
    {
        FindObjectOfType<PlayerInputManager>().playerJoinedEvent.AddListener(OnPlayerJoined);
        transform.position = Vector3.zero;
    }
    private void Start()
    {
        PlayerInput[] startPlayers = FindObjectsOfType<PlayerInput>();
        foreach(PlayerInput p in startPlayers)
        {
            OnPlayerJoined(p);
        }
    }
    public void OnPlayerJoined(PlayerInput playerInput)
    {

        if (players.Contains(playerInput)) { return; }
        else { players.Add(playerInput); }

        Camera cam = playerInput.transform.parent.gameObject.GetComponentInChildren<Camera>();
        MasterBackground[] backgrounds = GetComponentsInChildren<MasterBackground>();

        Debug.Log("newPlayer");

        foreach(MasterBackground background in backgrounds)
        {
            //Debug.Log(background);
            GameObject newBack = Instantiate(background.gameObject);
            newBack.GetComponent<SpriteRenderer>().enabled = true;
            MasterBackground newP = newBack.GetComponent<MasterBackground>();
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
            c.cullingMask = 1 << 0;
            for (int i = 0; i < 10; i++)
            {
                c.cullingMask |= 1 << i;
            }
        }
        camera.cullingMask |= 1 << layer;
    }
}


public abstract class MasterBackground : MonoBehaviour
{
    [HideInInspector] public Transform cam;

    [HideInInspector] public Camera camera;
}
