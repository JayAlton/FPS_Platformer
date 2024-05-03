using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSun : MonoBehaviour
{
    // Rotation speed (degrees per second) for the sun to complete one rotation in 5 minutes
    public float rotationSpeed = 360f / (5 * 60); // 360 degrees / (5 minutes * 60 seconds)

    // Update is called once per frame
    void FixedUpdate()
    {
        // Rotate the sun around its Y-axis
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
}
