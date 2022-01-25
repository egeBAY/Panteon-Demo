using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            GameManager.Instance.GameOver();
        }

        else if(collision.collider.tag == "Opponent")
        {
            OpponentController.Instance.RestartOpponent();
        }
    }
}
