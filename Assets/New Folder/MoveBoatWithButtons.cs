using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class MoveBoatWithButtons : MonoBehaviour
{
    public InputActionAsset inputActions;
    public string actionMapName = "Player";
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private InputAction forwardAction;
    private InputAction backwardAction;
    private InputAction leftAction;
    private InputAction rightAction;

    void OnEnable()
    {
        var map = inputActions.FindActionMap(actionMapName, true);
        map.Enable(); 

        forwardAction = map.FindAction("MoveForward", true);
        backwardAction = map.FindAction("MoveBackward", true);
        leftAction = map.FindAction("MoveLeft", true);
        rightAction = map.FindAction("MoveRight", true);

        forwardAction.Enable();
        backwardAction.Enable();
        leftAction.Enable();
        rightAction.Enable();
    }

    void OnDisable()
    {
        forwardAction?.Disable();
        backwardAction?.Disable();
        leftAction?.Disable();
        rightAction?.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        Vector3 move = Vector3.zero;

        if (forwardAction.ReadValue<float>() > 0.1f) move += Vector3.forward;
        if (backwardAction.ReadValue<float>() > 0.1f) move += Vector3.back;
        if (leftAction.ReadValue<float>() > 0.1f) move += Vector3.left;
        if (rightAction.ReadValue<float>() > 0.1f) move += Vector3.right;

    }
}
