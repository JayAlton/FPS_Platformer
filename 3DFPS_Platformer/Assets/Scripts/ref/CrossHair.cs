using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour {
    private new Camera camera;
    private int size;
    private string image;

    void Awake() {
        camera = GetComponent<Camera>();
    }

    void Start() {
        size = 19;
        image = "O";
    }

    void OnGUI() {
        float horizontal_midpoint = camera.pixelWidth/2 - size/2; // offset size/2
        float vertical_midpoint = camera.pixelHeight/2 - size/2;

        Vector2 position = new(horizontal_midpoint, vertical_midpoint);
        Vector2 dimensions = new(size, size);

        GUI.Label(new Rect(position, dimensions), image);
    }
}