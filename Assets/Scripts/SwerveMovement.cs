using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    [SerializeField] float swerveSpeed = 0.5f;
    [SerializeField] float maxSwerveAmount = 0.5f;


    private SwerveController swerveController;

    private void Awake()
    {
        swerveController = GetComponent<SwerveController>();
    }

    private void Update()
    {
        SwipeCharacter();
    }

    private void SwipeCharacter()
    {
        float swerveCount = swerveController.MoveFactorX * swerveSpeed * Time.deltaTime;
        swerveCount = Mathf.Clamp(swerveCount, -maxSwerveAmount, maxSwerveAmount);    
        transform.Translate(swerveCount, 0f, 0f);
    }
}
