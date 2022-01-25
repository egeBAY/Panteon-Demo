using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacleMovement : MonoBehaviour
{
    [SerializeField] float obstacleSpeed = 2f;

    private float leftBoundary = -1.3f;
    private float rightBoundary = 1.3f;
    private bool isMovingRight = true;

    private void Update()
    {
        if (isMovingRight)
            HorizontalMovementRight();
        else
            HorizontalMovementLeft();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            GameManager.Instance.GameOver();
        }

        else if (collision.collider.tag == "Opponent")
        {
            OpponentController.Instance.RestartOpponent();
        }
    }

    private void HorizontalMovementRight()
    {
        if (transform.position.x >= rightBoundary)
            isMovingRight = false;
        transform.Translate(Vector3.right * obstacleSpeed * Time.deltaTime);
    }

    private void HorizontalMovementLeft()
    {
        if (transform.position.x <= leftBoundary)
            isMovingRight = true;
        transform.Translate(Vector3.left * obstacleSpeed * Time.deltaTime);
    }
}
