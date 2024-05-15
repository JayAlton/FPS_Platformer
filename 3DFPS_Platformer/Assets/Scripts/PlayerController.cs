
using UnityEngine;
using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float speedBoost;
    private float originalSpeed;
    private float walkSpeed;
    private float sprintSpeed;
    public float gravity;
    public float jumpForce;
    private float jumpBoost;
    private bool isGrounded;
    private bool justLanded;
    private CharacterController charController;
    [SerializeField] Transform cameraTransform;
    private Vector3 velocity; // Added velocity vector for smoother jumping


    Animator animator;
    int walking;
    int Running;
    int Idle;


    void Start()
    {
        charController = GetComponent<CharacterController>();
        justLanded = true;
        walkSpeed = speed;
        sprintSpeed = 1.75f * speed;
        originalSpeed = speed;
        speedBoost = 0;
        jumpBoost = 0;
        animator = GetComponentInChildren<Animator>();
        walking = Animator.StringToHash("Walking");
        Running = Animator.StringToHash("Running");
        Idle = Animator.StringToHash("Idle");

        animator.SetBool(Running, false);
        animator.SetBool(walking, false);
        animator.SetBool(Idle, true);


    }

    void Update()
    {
        bool isRunning = animator.GetBool(Running);

        // Check for jump input
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        //if c is pressed apply weighdown
        if(Input.GetKeyDown(KeyCode.C) && !isGrounded)
        {
            
            velocity.y += -gravity * 50 * Time.fixedDeltaTime;
        }

        if(Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            animator.SetBool(Running, true);
            animator.SetBool(walking, false);
            animator.SetBool(Idle, false);
            Sprint(true);
        } else
        {
            Sprint(false);
            animator.SetBool(Running, false);
        }
    }

    void FixedUpdate()
    {
        GroundCheck();

        bool iswalking = animator.GetBool(walking);
        bool isRunning = animator.GetBool(Running);
        bool isIdle = animator.GetBool(Idle);

        if ((Input.GetAxis("Horizontal") != 0 ||  Input.GetAxis("Vertical") != 0) && !isRunning) {
            animator.SetBool(walking, true);
            animator.SetBool(Idle, false);
            Debug.Log("weighdown");
        } else {
            animator.SetBool(walking, false);
            animator.SetBool(Idle, true);
        } 
        
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
        velocity.y = jumpForce + jumpBoost;
        isGrounded = false;
    }

    void Sprint(bool sprint)
    {
        if(sprint)
        {
            speed = sprintSpeed + speedBoost;
        }
        else
        {
            speed = walkSpeed + speedBoost;
        }
    }

    public void ApplySpeedBoost(float boostAmount, float duration)
    {
        // Increase player speed by the boostAmount
        speedBoost = boostAmount;
        Debug.Log("SpeedBoost");
        StartCoroutine(DeactivateSpeedBoost(this, duration));
    }

    public void ResetSpeed()
    {
        // Reset player speed to the original value
        speedBoost = 0;
    }
    private IEnumerator DeactivateSpeedBoost(PlayerController player, float duration)
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Reset player speed after powerup duration
        player.ResetSpeed();
        Debug.Log("Deactivate Speed");
    }

    public void ApplyJumpBoost(float boostAmount, float duration)
    {
        // Increase player speed by the boostAmount
        jumpBoost = boostAmount;
        Debug.Log("Jump Boost active");
        StartCoroutine(DeactivateJumpBoost(this, duration));
    }

    public void ResetJump()
    {
        // Reset player speed to the original value
        jumpBoost = 0;
    }
    private IEnumerator DeactivateJumpBoost(PlayerController player, float duration)
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Reset player speed after powerup duration
        player.ResetJump();
        Debug.Log("Deactivate Jump Boost");
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
        if (Physics.Raycast(transform.position, Vector3.down, out hit, transform.localScale.y + 0.3f))
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
