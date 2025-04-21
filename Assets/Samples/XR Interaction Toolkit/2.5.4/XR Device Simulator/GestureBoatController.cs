using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureMover : MonoBehaviour
{
    public GameObject objectToMove;
    public float moveSpeed = 1f;

    private Vector3 currentDirection = Vector3.zero;
    private float moveDuration = 0.5f; 
    private float moveTimer = 0f;

    void Update()
    {
        if (moveTimer > 0f)
        {
            objectToMove.transform.Translate(currentDirection * moveSpeed * Time.deltaTime);
            moveTimer -= Time.deltaTime;
        }
    }

    public void OnGestureDetected(string gestureName)
    {
        switch (gestureName.ToLower())
        {
            case "forward":
                currentDirection = Vector3.forward;
                break;
            case "left":
                currentDirection = Vector3.left;
                break;
            case "right":
                currentDirection = Vector3.right;
                break;
            default:
                currentDirection = Vector3.zero;
                break;
        }

        moveTimer = moveDuration;
    }
}
