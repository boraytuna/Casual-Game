using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public float mouseSensitivity = 2f; // Mouse sensitivity
    float cameraVerticalRotation = 0f; // Vertical rotation angle

    private void Start()
    {
        // Lock and hide the cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Collect Mouse Input
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Apply horizontal rotation to the player
        player.Rotate(Vector3.up * inputX);

        // Rotate camera around its local x axis for vertical movement
        cameraVerticalRotation -= inputY;

        // Clamp the vertical rotation between -90 and 90 degrees
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);

        // Apply the vertical rotation to the camera
        transform.localEulerAngles = new Vector3(cameraVerticalRotation, transform.localEulerAngles.y, 0);
    }
}
