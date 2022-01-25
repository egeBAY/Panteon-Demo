using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 15f;
    [SerializeField] private float rotateForce = 7f;
    public bool isRotateRight;

    private void Update()
    {
        RotatePlatform();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (isRotateRight)
            collision.rigidbody.AddForce(Vector3.right * rotateForce);
        else
            collision.rigidbody.AddForce(Vector3.left * rotateForce);
    }

    private void RotatePlatform()
    {
        if(isRotateRight)
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime * -1);
        else
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime * 1);
    }

}
