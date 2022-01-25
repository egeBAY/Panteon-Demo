using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonutRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float force = 40f;
    [SerializeField] private GameObject rotatingStick;

    private void Update()
    {
        RotateStick();
    }

    private void RotateStick()
    {
        rotatingStick.transform.Rotate(rotationSpeed * Time.deltaTime, 0f, 0f);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.tag == "Player" || collision.collider.tag == "Opponent")
        {
            collision.rigidbody.AddForce(Vector3.back * force);
        }
    }
}
