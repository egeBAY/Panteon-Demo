using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    [SerializeField] float charSpeed = 5f;
    

    private Rigidbody _rb;
    private float minBoundaryX = -1.3f;
    private float maxBoundaryX = 1.3f;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();  
    }

    private void Update()
    {
        Vector3 pos = transform.position;

        if (pos.x < minBoundaryX) pos.x = minBoundaryX;
        if (pos.x > maxBoundaryX) pos.x = maxBoundaryX;

        transform.position = pos;
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * charSpeed);
    }
}
