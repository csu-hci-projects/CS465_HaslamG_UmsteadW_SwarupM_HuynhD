using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PleaseWork : MonoBehaviour
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
    public void onGesture(string gestureName)
    {
        switch (gestureName.ToLower())
        {
            case "forward":
                currentDirection = objectToMove.transform.forward;
                break;
            case "left":
                currentDirection = -objectToMove.transform.right;
                break;
            case "right":
                currentDirection = objectToMove.transform.right;
                break;
            default:
                currentDirection = Vector3.zero;
                break;
        }

                moveTimer = moveDuration;
    }
}
