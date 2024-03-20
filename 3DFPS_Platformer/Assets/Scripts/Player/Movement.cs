using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour {

    private CharacterController character;

    private float current_position;
    private float desire_position;
    private float previous_position;
    private float displacement;

    private bool upwards;
    private bool downwards;
    private bool on_ground;

    public float velocity;
    public float jump_height;
    public float acceleration;
    public float delta_time;

    private float left_right;
    private float forward_backward;
<<<<<<< Updated upstream
    public float speed;
=======
    public float sensitivity;
>>>>>>> Stashed changes


    void Awake() {
        character = GetComponent<CharacterController>();
        current_position = transform.position.y;
<<<<<<< Updated upstream
      
=======
        desire_position = 0f;
>>>>>>> Stashed changes
        previous_position = transform.position.y;
        displacement = 0f;

        upwards = false;
        downwards = true;
        on_ground = false;
    }

    void Start() {
        velocity = 7.5f;
        jump_height = 3f;
        delta_time = 1f;
        acceleration = 2 * (jump_height - velocity * delta_time) / (delta_time * delta_time);
        left_right = 0f;
        forward_backward = 0f;
<<<<<<< Updated upstream
        speed = 9.8f;


        desire_position = current_position + jump_height;
=======
        sensitivity = 9.8f;
>>>>>>> Stashed changes
    }

    void Update() {

        vertical_collision();

        vertical_motion();
        
          // sprint
<<<<<<< Updated upstream
        float temp = speed;
        if (Input.GetKey(KeyCode.LeftShift)) {
            temp = speed * 2;
=======
        float temp = sensitivity;
        if (Input.GetKey(KeyCode.LeftShift)) {
            temp = sensitivity * 2;
>>>>>>> Stashed changes
        }        

        
        movement(temp);

    }


    private void vertical_collision() {
         if(Math.Abs(previous_position - current_position) <= 0) {
            if (!upwards) {
                on_ground = true;
                downwards = false;
                upwards = false;
            } else {
                downwards = true;
                upwards = false;
            }
        }
    }

    private void vertical_motion() {
        if (Input.GetAxisRaw("Jump") != 0 && on_ground) {
            desire_position = transform.position.y + jump_height;
            upwards = true;
            on_ground = false;
        } 

        if (upwards) {
<<<<<<< Updated upstream
            if (velocity >= 0) {
=======
            if (velocity >= 3f) {
>>>>>>> Stashed changes
                velocity += acceleration * Time.deltaTime;
            }
            displacement = velocity * Time.deltaTime;
        }
        
        if (downwards) {
            if (velocity <= 7.5f) {
                velocity -= acceleration * Time.deltaTime;
            }
            displacement = -velocity * Time.deltaTime;}

        if(current_position >= desire_position) {
            upwards = false;
            downwards = true;
            velocity = 9f;
        }
    }

<<<<<<< Updated upstream
    private void movement(float temp_speed) {
        left_right = Input.GetAxis("Horizontal") * Time.deltaTime * temp_speed;
        forward_backward = Input.GetAxis("Vertical") * Time.deltaTime * temp_speed;
=======
    private void movement(float temp_sensitivity) {
        left_right = Input.GetAxis("Horizontal") * Time.deltaTime * temp_sensitivity;
        forward_backward = Input.GetAxis("Vertical") * Time.deltaTime * temp_sensitivity;
>>>>>>> Stashed changes

        Vector3 up_down = transform.up * displacement;
        Vector3 lef_righ = transform.right * left_right;
        Vector3 for_back = transform.forward * forward_backward;

        Vector3 move = up_down + lef_righ + for_back;

        previous_position = transform.position.y;

        character.Move(move);

        current_position = transform.position.y;
    }


<<<<<<< Updated upstream
}

/// movine
// void GroundCheck()
//     {
//         // Perform a Raycast from the player's feet
//         RaycastHit hit;
//         if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.3f))
//         {
//             // Check if the Raycast hits an object tagged as "Ground"
//             if (hit.collider.CompareTag("Ground"))
//             {
//                 isGrounded = true;
//                 return;
//             } else if(hit.collider.CompareTag("MovingPlatform")) {
//                 isGrounded = true;
//                 Transform trans = hit.transform;

//                 return;
//             }
//         }

//         isGrounded = false;
//     }
=======
}
>>>>>>> Stashed changes
