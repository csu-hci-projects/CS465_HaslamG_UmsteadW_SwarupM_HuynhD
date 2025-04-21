using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonMoveBallPlease : MonoBehaviour
{
    public InputActionAsset inputActions;
    public string actionMapName = "Player";
    public string moveActionName = "Move"; 
    public float moveSpeed = 5f;
    public float damping = 0.95f;

    private Rigidbody rb;
    private InputAction moveAction;
    private InputAction forwardAction;
    private InputAction backwardAction;
    private InputAction leftAction;
    private InputAction rightAction;

    void OnEnable()
    {
        var map = inputActions.FindActionMap(actionMapName, true);
        map.Enable(); 
        moveAction = map.FindAction(moveActionName, true);
        forwardAction = map.FindAction("MoveForward", true);
        backwardAction = map.FindAction("MoveBackward", true);
        leftAction = map.FindAction("MoveLeft", true);
        rightAction = map.FindAction("MoveRight", true);

        moveAction.Enable();
        forwardAction.Enable();
        backwardAction.Enable();
        leftAction.Enable();
        rightAction.Enable();
    }


    void OnDisable()
    {
        moveAction?.Disable();
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
        Vector2 joystickInput = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(joystickInput.x, 0, joystickInput.y);

        if (forwardAction.ReadValue<float>() > 0.1f) move += Vector3.forward;
        if (backwardAction.ReadValue<float>() > 0.1f) move += Vector3.back;
        if (leftAction.ReadValue<float>() > 0.1f) move += Vector3.left;
        if (rightAction.ReadValue<float>() > 0.1f) move += Vector3.right;

        rb.velocity = Vector3.Lerp(rb.velocity, move.normalized * moveSpeed, 0.1f);
    }
}
