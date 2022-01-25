using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingStick : MonoBehaviour
{
    [SerializeField] private float force = 50f;


    private void OnCollisionStay(Collision collision)
    {
        if (Vector3.Dot(collision.transform.forward, transform.right) < 0)
            collision.rigidbody.AddForce(transform.right * force);
        else
            collision.rigidbody.AddForce(transform.right * -force);
            
        //collision.rigidbody.AddForce(transform.right * force);
        Debug.DrawLine(transform.position, collision.transform.position, Color.red, Mathf.Infinity);
    }

}
