using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Character;
    public float cameraDistance = 5.0f;
    Vector3 pos;

    void Start()
    {
        pos = transform.position;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(pos.x, pos.y, Character.transform.position.z - Character.transform.forward.z * cameraDistance);
    }
}
