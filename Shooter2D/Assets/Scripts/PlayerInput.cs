using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event EventHandler OnFireButtonPressed;
    [SerializeField] private Joystick joystick;

    /*private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        { 
            OnFireButtonPressed(this, EventArgs.Empty);
        }
    }*/
    public Vector2 GetMovementVectorNormalized()
    {
        Vector3 directionVector = Vector3.zero;
        //directionVector.x = Input.GetAxisRaw("Horizontal");
        //directionVector.y = Input.GetAxisRaw("Vertical");
        directionVector.x = joystick.Horizontal;
        directionVector.y = joystick.Vertical;

        return directionVector.normalized;
    }
    public void ShootTrigger()
    { 
        OnFireButtonPressed(this, EventArgs.Empty); 
    }

}
