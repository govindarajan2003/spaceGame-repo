using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class controlsHandler : MonoBehaviour
{

    [Header("General settings")]
    [Tooltip("how fast ship moves")][SerializeField] float speedTuner=10f;
    [Tooltip("limits the ship movement on the x-axis")][SerializeField] float xClamp=3.5f;
    [Tooltip("limits the ship movement on the y axis")][SerializeField] float yclamp =3.3f;
    
    [Header("PitchYawRoll Controller")]
    [Header("Screen Position Based Tuning")]
    [Tooltip("enhance the pitchDueToPosition")][SerializeField] float positionPitchFactor =-2f;
    [Tooltip("enhance the yawDueToPosition")][SerializeField] float  positionYawFactor =5f;

    [Header("Player Input Based Tuning")]
    [Tooltip("enhance the pitchDueToControl")][SerializeField] float controlPitchFactor = -10f;
    [Tooltip("enhance the rollDueToControl")][SerializeField] float controlRollFactor =-20f;

    [Header("Laser Settings")]
    [SerializeField] GameObject[] lasers;
    
  
    float xThrow,yThrow;



    void Update()
    {
        movementController();
        rotationController();
        shootingController();
    }

    private void movementController()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");
        

        float xOffset = xThrow * Time.deltaTime * speedTuner;
        float xRawPosition = transform.localPosition.x + xOffset;
        float xNewPosition = Mathf.Clamp(xRawPosition, -xClamp, xClamp);

        float yOffset = yThrow * Time.deltaTime * speedTuner;
        float yRawPosition = transform.localPosition.y + yOffset;
        float yNewPosition = Mathf.Clamp(yRawPosition, -yclamp, yclamp);

        transform.localPosition = new Vector3(xNewPosition, yNewPosition, 0);
    }
    
    private void rotationController()
    {
        float pitchDueToPosition =transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControl;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yaw = yawDueToPosition ;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch,yaw, roll);

    }

    void shootingController()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            setActivationStateLaser(true);
        }
        else
        {
            setActivationStateLaser(false);
        }
        
    }
    private void setActivationStateLaser(bool activationState)
    {
        foreach(GameObject seperateLaser in lasers)
        {
            var emmisionToggle = seperateLaser.GetComponent<ParticleSystem>().emission;
            emmisionToggle.enabled = activationState;
        }
    }



}
