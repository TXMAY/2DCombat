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
    public Action BaseAttack;

    protected override void Awake()
    {
        control = new Control();

        control.Movement.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        control.UI.MenuOpen.performed += UIMenuPerformed;
        control.Attack.MelleAttack.performed += PlayerBaseAttack;
    }

    #region Unity Function
    void OnEnable()
    {
        control.Enable();
    }

    void OnDisable()
    {
        control.Disable();
    }
    #endregion

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

    private void PlayerBaseAttack(InputAction.CallbackContext context)
    {
        BaseAttack?.Invoke();
    }
}
