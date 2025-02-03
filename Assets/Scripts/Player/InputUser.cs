using CustomUtillity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputUser : SingleTon<InputUser>
{
    [HideInInspector] public Control control;

    [HideInInspector] public Vector2 moveInput;

    public bool MenuIsOpen { get; set; } = false;

    public Action MenuOpen;
    public Action MenuClose;

    protected override void Awake()
    {
        control = new Control();

        control.Movement.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        control.UI.MenuOpen.performed += UIMenuPerformed;

    }

    void OnEnable()
    {
        control.Enable();
    }

    void OnDisable()
    {
        control.Disable();
    }

    void UIMenuPerformed(InputAction.CallbackContext context)
    {
        MenuIsOpen = !MenuIsOpen;

        if (MenuIsOpen)
        {
            MenuOpen?.Invoke();
        }
        else
        {
            MenuClose?.Invoke();
        }
    }
}
