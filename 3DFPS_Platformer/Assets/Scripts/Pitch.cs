using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitch : MonoBehaviour {
    private float limit;
    private float pitch;

    public float sensitivity;

    void Awake() {
        sensitivity = 8f;
    }

    void Start() {
        pitch = 0f;
        limit = 60f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() {
        
        if(Input.GetAxisRaw("Mouse Y") != 0) {
            pitch -= Input.GetAxis("Mouse Y") * sensitivity;
            pitch = Mathf.Clamp(pitch, -limit, limit);

            float yaw = transform.localEulerAngles.y;

            transform.localEulerAngles = new(pitch, yaw, 0);
        }
        if (Input.GetKey(KeyCode.Escape) && Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    
}
