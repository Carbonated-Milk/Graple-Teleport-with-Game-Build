using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    InputActions inputs;
    InputActions.PlayerOGActions actions;
    InputActions.Player1Actions actions1;
    InputActions.Player2Actions actions2;
    InputActions.Player3Actions actions3;
    public Camera camera;
    Player player;
    private string objName;

    private Vector2 mousePos;
    private static ArrayList deviceNames = new ArrayList();
    private void Awake()
    {
        player = GetComponent<Player>();
        inputs = new InputActions();
        actions = inputs.PlayerOG;

        AddActions();
        
        /*actions1 = inputs.Player1;
        actions2 = inputs.Player2;
        actions3 = inputs.Player3;
        switch (GameManager.playerCount)
        {
            case 0:
                
                break;
            case 1:
                
                break;
            case 2:
                
                break;
            case 3:
                
                break;
        }
        

        GameManager.playerCount += 1;*/


    }
    private void Jump(InputAction.CallbackContext ctx)
    {
        if (NameCheck(ctx.control.device.name))
        {
            player.jumped = ToBool(ctx.ReadValue<float>());
        }
    }
    private void Aim(InputAction.CallbackContext ctx)
    {
        if (NameCheck(ctx.control.device.name))
        {
            mousePos = ctx.ReadValue<Vector2>();
        }
    }
    private void Move(InputAction.CallbackContext ctx)
    {
        if (NameCheck(ctx.control.device.name))
        {
            player.moverDir = ctx.ReadValue<Vector2>();
        }
    }
    private void Action(InputAction.CallbackContext ctx)
    {
        if (NameCheck(ctx.control.device.name))
        {
            player.OnAction(ctx);
        }
    }
    private void Switch(InputAction.CallbackContext ctx)
    {
        if (NameCheck(ctx.control.device.name))
        {
            player.actionSwitch = !player.actionSwitch;
        }
    }
    private void Respawn(InputAction.CallbackContext ctx)
    {
        if (NameCheck(ctx.control.device.name))
        {
            player.Respawn();
        }
    }

    public void AddActions()
    {
        actions.Aim.performed += Aim;
        actions.Jump.canceled += Jump;
        actions.Jump.performed += Jump;
        actions.Movement.performed += Move;
        actions.Action.performed += Action;
        actions.Action.canceled += Action;
        actions.Switch.performed += Switch;
        actions.Respawn.performed += Respawn;
    }

    private bool NameCheck(string name)
    {
        if(!deviceNames.Contains(name) && name != "Keyboard") { deviceNames.Add(name); }
        if (objName == null) { objName = (string)deviceNames[GameManager.playerCount]; GameManager.playerCount += 1; return false; }
        if ((name == "Keyboard" || name == "Mouse") && (objName == "Keyboard" || objName == "Mouse")) { return true; }
        return name == objName;
    }

    private void Update()
    {
        if(objName == "Keyboard" || objName == "Mouse")
        {
            player.mousePos = camera.ScreenToWorldPoint(mousePos);
        }
    }

    private void OnEnable()
    {
        inputs.Enable();
    }
    private void OnDisable()
    {
        inputs.Disable();
    }
    public bool ToBool(float notBool)
    {
        if (notBool == 0)
        {
            return false;
        }
        else return true;
    }
}
