using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitSpotLight : MonoBehaviour
{
    // Rotation speed variables
    public float yRotationSpeed = 50f; // Speed of rotation around the X axis
    public float zRotationSpeed = 30f; // Speed of rotation around the Z axis

    private void Update()
    {
        // Calculate rotation amount based on time and speed
        float yRotation = yRotationSpeed * Time.deltaTime;
        float zRotation = zRotationSpeed * Time.deltaTime;

        // Apply rotation to the object around the X and Z axes
        transform.Rotate(0f, yRotation, zRotation);
    }
}
