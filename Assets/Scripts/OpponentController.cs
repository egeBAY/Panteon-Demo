using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpponentController : MonoBehaviour
{
    public static OpponentController Instance;

    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private Transform destinationTransform;

    public Vector3 startingPos;
    //public int numberOfRays = 17;
    //public float angle = 90;
    private float minBoundaryX = -1.3f;
    private float maxBoundaryX = 1.3f;
    //private float rayRange = 1f;

    private NavMeshAgent navMeshAgent;
    private void Awake()
    {
        if (Instance == null) Instance = this;

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Vector3 pos = transform.position;

        if (pos.x < minBoundaryX) pos.x = minBoundaryX;
        if (pos.x > maxBoundaryX) pos.x = maxBoundaryX;

        transform.position = pos;

        MoveOpponent();
    }


    private void MoveOpponent()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        navMeshAgent.destination = destinationTransform.position;
    }

    public void RestartOpponent()
    {
        transform.position = startingPos;
    }


    //private void ScanFront()
    //{
    //    Vector3 deltaPos = Vector3.zero;

    //    for (int i = 0; i < numberOfRays; i++)
    //    {
    //         var rotation = transform.rotation;
    //         var rotationMod = Quaternion.AngleAxis((i / (float)numberOfRays - 1) * angle * 2 - angle, transform.up);
    //         var direction = rotation * rotationMod * Vector3.forward;
    //        //Gizmos.DrawRay(transform.position + new Vector3(0f,0.3f,0f), direction);

    //        var ray = new Ray(transform.position + new Vector3(0f,0.3f,0f), direction);
    //        RaycastHit hit;

    //        int decide = Random.Range(0, 1);

    //        if (Physics.Raycast(ray, out hit, rayRange))
    //        {
    //            if (hit.collider.tag == "Obstacle" || hit.collider.tag == "Boundary")
    //                deltaPos -= (1f / numberOfRays) * movementSpeed * direction;
    //            //deltaPos += (1f / numberOfRays) * movementSpeed * direction;
    //        }

    //    }

    //    transform.position += deltaPos * Time.deltaTime;
    //}



    //private void OnDrawGizmos()
    //{
    //    for (int i = 0; i < numberOfRays; i++)
    //    {
    //        var rotation = transform.rotation;
    //        var rotationMod = Quaternion.AngleAxis((i / (float)numberOfRays - 1) * angle * 2 - angle, transform.up);
    //        var direction = rotation * rotationMod * Vector3.forward;
    //        Gizmos.DrawRay(transform.position + new Vector3(0f, 0.3f, 0f), direction);

    //    }
    //}
}
