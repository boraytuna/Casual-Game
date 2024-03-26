using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7f;
    public float walkingSpeed = 2.5f;
    public float crouchSpeed = 1.5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    public float crouchHeight = 0.5f;
    public float standHeight = 2f;
    public Transform cameraTransform;
    public GameObject currentGround; // Added for ground tracking

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private bool isCrouching;
    private float originalCameraHeight;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        originalCameraHeight = cameraTransform.localPosition.y;
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;

        float currentSpeed = isCrouching ? crouchSpeed : (Input.GetKey(KeyCode.LeftShift) ? walkingSpeed : speed);

        controller.Move(move * currentSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) && isCrouching)
        {
            StandUp();
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Ground")) // Ensure your ground objects are tagged appropriately
        {
            currentGround = hit.gameObject;
        }
    }

    void Crouch()
    {
        controller.height = crouchHeight;
        cameraTransform.localPosition = new Vector3(cameraTransform.localPosition.x, originalCameraHeight - crouchHeight, cameraTransform.localPosition.z);
        isCrouching = true;
    }

    void StandUp()
    {
        controller.height = standHeight;
        cameraTransform.localPosition = new Vector3(cameraTransform.localPosition.x, originalCameraHeight, cameraTransform.localPosition.z);
        isCrouching = false;
    }

    public void DisableMovement()
    {
        enabled = false; // Disables this PlayerMovement script
    }

    public void EnableMovement()
    {
        enabled = true; // Enables this PlayerMovement script
    }

}
