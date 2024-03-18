using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float gravity;
    public float jumpForce;
    private bool isGrounded;
    private CharacterController charController;
    [SerializeField] Transform cameraTransform;
    private Vector3 velocity; // Added velocity vector for smoother jumping

    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check for jump input
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        GroundCheck();
        
        // Movement
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        float deltaZ = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;

        // Transform input according to camera rotation
        Vector3 moveDirection = cameraTransform.TransformDirection(new Vector3(deltaX, 0f, deltaZ));


        // Apply gravity
        if (!isGrounded)
        {
            // Apply gravity gradually
            velocity.y += -gravity * Time.fixedDeltaTime;
        }

        // Move the player
        charController.Move(moveDirection + velocity * Time.fixedDeltaTime);
    }

    void Jump()
    {
        // Set initial jump velocity
        velocity.y = jumpForce;
        isGrounded = false;
    }

    void GroundCheck()
    {
        // Perform a Raycast from the player's feet
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.3f))
        {
            // Check if the Raycast hits an object tagged as "Ground"
            if (hit.collider.CompareTag("Ground"))
            {
                isGrounded = true;
                return;
            } else if(hit.collider.CompareTag("MovingPlatform")) {
                isGrounded = true;
                return;
            }
        }

        isGrounded = false;
    }
}
