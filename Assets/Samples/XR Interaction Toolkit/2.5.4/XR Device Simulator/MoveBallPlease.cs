using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class MoveBallPlease : MonoBehaviour
{
    public InputActionAsset inputActions;
    public string actionMapName = "Player";
    public string moveActionName = "Move";
    public float moveSpeed = 5f;
    public float damping = 0.95f; 

    private Rigidbody rb;
    private InputAction moveAction;

    void OnEnable()
    {
        var map = inputActions.FindActionMap(actionMapName, true);
        moveAction = map.FindAction(moveActionName, true);
        moveAction.Enable();
    }

    void OnDisable()
    {
        moveAction?.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;  
    }

    void FixedUpdate()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);

    }
}
