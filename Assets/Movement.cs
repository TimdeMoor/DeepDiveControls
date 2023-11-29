using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private DefaultControls input;
    private Vector2 moveDirection = Vector2.zero;
    private Rigidbody rb;
    private float speed = 10f;

    private void Awake()
    {
        input = new DefaultControls();
        input.LoadBindingOverridesFromJson(PlayerPrefs.GetString("SavedControls"));
        Debug.Log(PlayerPrefs.GetString("SavedControls"));
        rb = GetComponent<Rigidbody>();
    }
    
    private void OnEnable()
    {
        input.Enable();
        input.InGame.Move.performed += OnMovementPerformed;
        input.InGame.Move.canceled += OnMovementCanceled;
    }

    private void OnDisable()
    {
        input.Disable();
        input.InGame.Move.performed -= OnMovementPerformed;
        input.InGame.Move.canceled -= OnMovementCanceled;
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveDirection = value.ReadValue<Vector2>();
        
    }

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        moveDirection = Vector2.zero;
    }
}
