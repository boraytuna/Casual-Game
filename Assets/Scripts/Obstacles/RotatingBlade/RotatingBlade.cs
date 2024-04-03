using UnityEngine;

public class RotatingBlade : MonoBehaviour
{
    public float rotationSpeed = 90f; // Rotation speed in degrees per second
    public bool clockwise = true; // Control the direction of rotation

    void Update()
    {
        float direction = clockwise ? 1f : -1f;
        transform.Rotate(0, direction * rotationSpeed * Time.deltaTime, 0);
    }
}
