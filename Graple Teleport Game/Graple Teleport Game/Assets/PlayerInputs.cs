using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    InputActions inputs;
    InputActions.PlayerActions actions;
    InputActions.Player1Actions actions1;
    InputActions.Player2Actions actions2;
    InputActions.Player3Actions actions3;
    public Camera camera;
    Player player;

    private Vector2 mousePos;
    private bool isKey = false;
    private void Awake()
    {
        player = GetComponent<Player>();
        inputs = new InputActions();
        actions = inputs.Player;
        actions1 = inputs.Player1;
        actions2 = inputs.Player2;
        actions3 = inputs.Player3;
        switch(GameManager.playerCount)
        {
            case 0:
                isKey = true;
                actions.Aim.performed += ctx => mousePos = ctx.ReadValue<Vector2>();
                actions.Jump.canceled += ctx => player.jumped = ToBool(ctx.ReadValue<float>());
                actions.Jump.performed += ctx => player.jumped = ToBool(ctx.ReadValue<float>());
                actions.Movement.performed += ctx => player.moverDir = ctx.ReadValue<Vector2>();
                actions.Action.performed += ctx => player.OnAction(ctx);
                actions.Action.canceled += ctx => player.OnAction(ctx);
                break;
            case 1:
                actions.Jump.canceled += ctx => player.jumped = ToBool(ctx.ReadValue<float>());
                actions1.Jump.performed += ctx => player.jumped = ToBool(ctx.ReadValue<float>());
                actions1.Movement.performed += ctx => player.moverDir = ctx.ReadValue<Vector2>();
                actions1.Action.performed += ctx => player.OnAction(ctx);
                actions1.Action.canceled += ctx => player.OnAction(ctx);
                break;
            case 2:
                actions.Jump.canceled += ctx => player.jumped = ToBool(ctx.ReadValue<float>());
                actions2.Jump.performed += ctx => player.jumped = ToBool(ctx.ReadValue<float>());
                actions2.Movement.performed += ctx => player.moverDir = ctx.ReadValue<Vector2>();
                actions2.Action.performed += ctx => player.OnAction(ctx);
                actions2.Action.canceled += ctx => player.OnAction(ctx);
                break;
            case 3:
                actions.Jump.canceled += ctx => player.jumped = ToBool(ctx.ReadValue<float>());
                actions3.Jump.performed += ctx => player.jumped = ToBool(ctx.ReadValue<float>());
                actions3.Movement.performed += ctx => player.moverDir = ctx.ReadValue<Vector2>();
                actions3.Action.performed += ctx => player.OnAction(ctx);
                actions3.Action.canceled += ctx => player.OnAction(ctx);
                break;
        }
        GameManager.playerCount += 1;

        
    }


    private void Update()
    {
        if(isKey)
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
