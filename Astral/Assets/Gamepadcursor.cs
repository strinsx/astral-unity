using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;

public class Gamepadcursor : MonoBehaviour
{
    public InputActionReference moveAction; // Reference to the move action in the Input System
    public float cursorSpeed = 5f; // Cursor movement speed
    public InputActionReference clickAction; // Reference to the click action in the Input System

    private Vector2 moveInput;

    void OnEnable()
    {
        moveAction.action.Enable();
        moveAction.action.performed += OnMove;

        clickAction.action.Enable();
        clickAction.action.performed += OnClick;
    }

    void OnDisable()
    {
        moveAction.action.Disable();
        moveAction.action.performed -= OnMove;

        clickAction.action.Disable();
        clickAction.action.performed -= OnClick;
    }

    void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void OnClick(InputAction.CallbackContext context)
    {
        // Implement your click functionality here
        Debug.Log("Click!");
    }

    void Update()
    {
        Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0f) * cursorSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

}
