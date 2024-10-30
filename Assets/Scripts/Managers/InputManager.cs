using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class InputManager
{
    private static Controls controls;


    public static void Init(Player myPlayer)
    {
        controls = new Controls();

        controls.Game.Movement.performed += ctx => 
        {
            myPlayer.setMovementDirection(ctx.ReadValue<Vector3>());
        
        };


        controls.Game.Jump.started += ctx =>
        {
            myPlayer.jump();
        };

        controls.Game.Look.performed += ctx =>
        {
            myPlayer.setLookDirection(ctx.ReadValue<Vector2>());
        };

        controls.Game.Sprint.performed += ctx =>
        {
            myPlayer.sprintSpeed = true;
        };
        controls.Game.Sprint.canceled += ctx =>
        {
            myPlayer.sprintSpeed = false;
        };


        controls.Game.Enable();


    }

}