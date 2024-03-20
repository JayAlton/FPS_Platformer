using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yaw : MonoBehaviour {

    public float sensitivity;

    void Start() {
        sensitivity = 8f;
    }

    void Update() {

        if(Input.GetAxisRaw("Mouse X") != 0) {
            transform.Rotate(0, sensitivity * Input.GetAxis("Mouse X"), 0);
        }
    }
}
