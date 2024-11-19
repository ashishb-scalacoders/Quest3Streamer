using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionObject : MonoBehaviour
{
    public Transform cameraTransform; // Assign your camera's transform here in the inspector
    public float distanceFromCamera = 0.5f;
    public float heightFromHeadset = 0f; // Adjust this to set the height from the ground
    private bool hasPositioned = false;

    void OnEnable()
    {
        if (!hasPositioned)
        {
            PositionInFrontOfCamera();
            hasPositioned = true;
        }
    }

    void OnDisable()
    {
        hasPositioned = false; // Reset the flag when the object is disabled
    }

    void PositionInFrontOfCamera()
    {
        if (cameraTransform == null)
        {
            Debug.LogError("Camera Transform is not assigned!");
            return;
        }

        // Calculate the new position in front of the camera
        Vector3 newPosition = cameraTransform.position + cameraTransform.forward * distanceFromCamera;
        // newPosition.y = heightFromGround; // Set the object's height from the ground
        newPosition.y = cameraTransform.position.y - heightFromHeadset;

        // Set the object's position
        transform.position = newPosition;

        // Optionally align the object's rotation with the camera
        transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
    }
}

