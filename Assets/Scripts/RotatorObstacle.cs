using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorObstacle : MonoBehaviour
{
    [SerializeField] private float rotatorSpeed = 10f;


    private void Update()
    {
        RotateRotator();
    }


    private void RotateRotator()
    {
        transform.Rotate(0f, rotatorSpeed * Time.deltaTime * 1, 0f);
    }
}
