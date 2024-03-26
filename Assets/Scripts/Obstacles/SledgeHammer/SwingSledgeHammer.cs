using UnityEngine;

public class SwingSledgeHammer : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.5f;
    [SerializeField]
    private float startingAngle = 0f; // Add this line to set the starting angle from the inspector
    [SerializeField]
    private bool rotateClockwise = true; // Control the direction of rotation

    private void Update()
    {
        float timeSinceStart = Time.time * speed;

        // Depending on the direction, calculate the rotation angle
        float angleZ;
        if (rotateClockwise)
        {
            // For clockwise rotation, oscillate from the starting angle to -80 degrees
            angleZ = startingAngle + Mathf.Sin(timeSinceStart) * -80f; // This will go from startingAngle to -80
        }
        else
        {
            // For counter-clockwise rotation, oscillate from the starting angle to 80 degrees
            angleZ = startingAngle + Mathf.Sin(timeSinceStart) * 80f; // This will go from startingAngle to 80
        }

        transform.rotation = Quaternion.Euler(0, 0, angleZ);
    }
}
