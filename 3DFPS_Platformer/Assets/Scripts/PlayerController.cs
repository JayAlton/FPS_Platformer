using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float gravity;
    public float jumpForce;
    private bool isGrounded;
    private bool justLanded;
    private CharacterController charController;
    [SerializeField] Transform cameraTransform;
    private Vector3 velocity; // Added velocity vector for smoother jumping

    void Start()
    {
        charController = GetComponent<CharacterController>();
        justLanded = true;
    }

    void Update()
    {
        // Check for jump input
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        //if c is pressed apply weighdown
        if(Input.GetKeyDown(KeyCode.C) && !isGrounded)
        {
            Debug.Log("weighdown");
            velocity.y += -gravity * 50 * Time.fixedDeltaTime;
        }
    }

    void FixedUpdate()
    {
        GroundCheck();
       // Debug.Log("Y Velocity: " + velocity.y);
        
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

    public void Bounce(float bounceForce)
    {
        velocity.y = bounceForce;
        isGrounded = false;
    }

    void GroundCheck()
    {
        isGrounded = false;
        // Perform a Raycast from the player's feet
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.3f))
        {
            // Check if the Raycast hits an object tagged as "Ground"
            if (hit.collider.CompareTag("Ground"))
            {
                isGrounded = true;
                if (justLanded)
                {
                    justLanded = false;
                    velocity.y = 0;
                }
            } else if(hit.collider.CompareTag("MovingPlatform")) {
                isGrounded = true;
                if(justLanded)
                {
                    justLanded = false;
                    velocity.y = 0;
                }
            }
        } else
        {
            isGrounded = false;
            justLanded = true;
        }
        if(Physics.Raycast(transform.position, Vector3.up, out hit, 1.5f)) {
            if(hit.collider.CompareTag("Ground") || hit.collider.CompareTag("MovingPlatform")) {
                isGrounded = false;
                velocity.y = -gravity * Time.fixedDeltaTime;
                return;
            }
        }
    }
}
