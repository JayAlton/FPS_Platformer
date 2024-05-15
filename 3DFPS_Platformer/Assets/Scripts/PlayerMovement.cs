
using System.Collections;
using System.Data.Common;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour {
  
    Animator animator;
    int walking;

    private CharacterController controller;
    LayerMask layer;

    float gravity;

    Vector2 velocity;
    float jumpForce;
    float jumpBoost = 0;

    float Transverse_plane_sensitivity;
    float sprintSpeed = 4;
    float sprintBoost;
    float walkSpeed;

    bool falling;
    bool grounded;
    bool ceiling;

    void Start() {
        animator = GetComponentInChildren<Animator>();
        walking = Animator.StringToHash("Walking");


        controller = GetComponent<CharacterController>();
        layer = 1 << LayerMask.NameToLayer ("Player");
        

        Transverse_plane_sensitivity = 5;
        jumpForce = 8;
        gravity = -0.1f;

        falling = false;
        grounded = false;
        ceiling = false;
    }
//Input.GetKey(KeyCode.LeftShift)

    void Update() {
        if (grounded && Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("jump");
            velocity.y = jumpForce + jumpBoost;
            grounded = false;
        } else if (!grounded) {
            if (Input.GetKeyDown(KeyCode.C)) {
                velocity.y -= 0.1f;
            }
            velocity.y += gravity;
        }
        if (grounded && Input.GetKey(KeyCode.LeftShift)) {
            velocity.x = sprintSpeed + sprintBoost;
        } else {velocity.x = 0;}
        //animator.SetBool("Walking", false);


        float up_down = velocity.y;

        float left_right = Input.GetAxis("Horizontal") * Transverse_plane_sensitivity + velocity.x;
        float forward_backward = Input.GetAxis("Vertical") * Transverse_plane_sensitivity + velocity.x;

        Vector3 lef_righ = transform.right * left_right;
        Vector3 for_back = transform.forward * forward_backward;
        Vector3 vertical = transform.up * up_down;

        Vector3 move = lef_righ + for_back + vertical;

        controller.Move(move * Time.deltaTime);
    }

  public void Bounce(float bounceForce)
    {
        velocity.y += bounceForce;
        grounded = false;
    }


    void FixedUpdate() {
        if (!grounded) {Check_Ceiling();}
        
        Check_Ground();
        
       

    }

    void Check_Ground() {
        Vector3 direction = transform.up * -1f;
        if (Physics.Raycast(transform.position, direction, out RaycastHit info, 1.2f, ~layer)) {
            Debug.DrawRay (transform.position, transform.up * -1f, Color.red, 0.0f);
            if (info.transform != null) {
                grounded = true;
                falling = false;
                velocity.y = 0;
            }
        } else {grounded = false;}
    }


    void Check_Ceiling() {
        Vector3 direction = transform.up;
        
        if (Physics.Raycast(transform.position, direction, out RaycastHit info, 1.2f, ~layer)) {
            Debug.Log("called");
            Debug.DrawRay (transform.position, direction, Color.blue, 0.0f);
            if (info.transform != null) {
                falling = true;
            }
        }
    }





    public void Apply_SprintBoost(float Amount, float duration) {
        sprintBoost = Amount;
        StartCoroutine(Deactivate_SprintBoost(duration));
        sprintBoost = 0;
    }

    public void Apply_JumpBoost(float Amount, float duration) {
        jumpBoost = Amount;
        StartCoroutine(Deactivate_JumpBoost(duration));
        jumpBoost = 0;
    }


    private IEnumerator Deactivate_JumpBoost(float duration) {
        yield return new WaitForSeconds(duration);
    }

    private IEnumerator Deactivate_SprintBoost(float duration) {
        yield return new WaitForSeconds(duration);
    }


}