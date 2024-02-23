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
    private Vector3 lastPlatformPosition;
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
        if(Input.GetKey(KeyCode.LeftShift)) {
            velocity.z = deltaZ * 2;
        }
        velocity = rotation * velocity;
        //velocity = Vector3.ClampMagnitude(velocity, speed);
        velocity.y += gravity;
        velocity = transform.TransformDirection(velocity);
        charController.Move(velocity * Time.deltaTime);

        if (transform.parent != null)
        {
            Vector3 platformDeltaPosition = transform.parent.position - lastPlatformPosition;
            transform.position += platformDeltaPosition;
            lastPlatformPosition = transform.parent.position;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            // Attach the player to the platform
            transform.parent = collision.transform;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            // Detach the player from the platform
            transform.parent = null;
        }
    }
}
