using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVChecker : MonoBehaviour
{
    public Camera targetCamera; // Assign this in the Inspector
    public float desiredFOV = 60f; // Set your desired FOV here

    void Update()
    {
        // Check if the camera's FOV is different from the desired FOV
        if (targetCamera.fieldOfView != desiredFOV)
        {
            // Change the camera's FOV to the desired FOV
            targetCamera.fieldOfView = desiredFOV;
        }
    }
}

