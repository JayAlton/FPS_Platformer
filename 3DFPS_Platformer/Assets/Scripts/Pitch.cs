using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitch : MonoBehaviour {
    public float sensitivity;
    private float limit;
    private float pitch;

    void Awake() {
        sensitivity = 9f;
        pitch = 0f;
    }

    void Start() {
        limit = 45f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() {
        
        if(Input.GetAxis("Mouse Y") != 0) {
            pitch -= Input.GetAxis("Mouse Y") * sensitivity;
            pitch = Mathf.Clamp(pitch, -limit, limit);

            float yaw = transform.localEulerAngles.y;

            transform.localEulerAngles = new(pitch, yaw, 0);
        }

    }
    
}
