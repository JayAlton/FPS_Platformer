using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float gravity;
    public float jumpForce;
    private bool isGrounded;
    private Vector3 velocity;
    private CharacterController charController;
    [SerializeField] private Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = charController.isGrounded;

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        float deltaY = velocity.y;
        if(isGrounded && Input.GetButtonDown("Jump")) {
            deltaY = jumpForce;
        }

        float rotationAngle = cameraTransform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0f, rotationAngle, 0f);
    
        //move the character 
        velocity = new Vector3(deltaX, deltaY, deltaZ);
        velocity = rotation * velocity;
        //velocity = Vector3.ClampMagnitude(velocity, speed);
        velocity.y += gravity;
        velocity = transform.TransformDirection(velocity);
        charController.Move(velocity * Time.deltaTime);
    }

}
