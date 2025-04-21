using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class XRBallControllerButton : MonoBehaviour
{
    public InputActionReference moveUpButton;
    public InputActionReference moveDownButton;
    public InputActionReference moveLeftButton;
    public InputActionReference moveRightButton;

    public float moveSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 move = Vector3.zero;

        if (moveUpButton.action.IsPressed())
            move += Vector3.forward;
        if (moveDownButton.action.IsPressed())
            move += Vector3.back;
        if (moveLeftButton.action.IsPressed())
            move += Vector3.left;
        if (moveRightButton.action.IsPressed())
            move += Vector3.right;

        rb.AddForce(move.normalized * moveSpeed);
    }
}
