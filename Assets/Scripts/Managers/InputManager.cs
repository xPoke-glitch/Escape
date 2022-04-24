using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : Singleton<InputManager>
{
    public bool IsMoving { get; private set; }
    public Vector2 MoveDirection { get; private set; }

    private bool _isInteractPressed;
    private bool _isMenuPressed;
    private bool _isDropItemPressed;

    public void MovePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsMoving = true;
            MoveDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            IsMoving = false;
            MoveDirection = context.ReadValue<Vector2>();
        }
    }

    public void InteractPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            _isInteractPressed = true;
        else if(context.canceled)
            _isInteractPressed = false;
    }

    public void MenuPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            _isMenuPressed = true;
        else if (context.canceled)
            _isMenuPressed = false;
    }

    public void DropItemPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            _isDropItemPressed = true;
        else if (context.canceled)
            _isDropItemPressed = false;
    }

    // for any of the below 'Get' methods, if we're getting it then we're also using it,
    // which means we should set it to false so that it can't be used again until actually
    // pressed again. (GetKeyDown Behaviour)

    public bool GetInteractPressed()
    {
        bool result = _isInteractPressed;
        _isInteractPressed = false;
        return result;
    }

    public bool GetMenuPressed()
    {
        bool result = _isMenuPressed;
        _isMenuPressed = false;
        return result;
    }

    public bool GetDropItemPressed()
    {
        bool result = _isDropItemPressed;
        _isDropItemPressed = false;
        return result;
    }
}
