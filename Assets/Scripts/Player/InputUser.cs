using CustomUtillity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputUser : SingleTon<InputUser>
{
    Control control;

    [HideInInspector] public Vector2 moveInput;

    protected override void Awake()
    {
        control = new Control();

        control.Movement.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
    }

    void OnEnable()
    {
        control.Enable();
    }

    void OnDisable()
    {
        control.Disable();
    }
}
