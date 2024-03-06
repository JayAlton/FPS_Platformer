using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour {
    private new Camera camera;

    public int crossHairs_size;
    public string crossHairs_image;

    void Awake() {
        camera = GetComponent<Camera>();
    }

    void Start() {
        crossHairs_size = 19;
        crossHairs_image = "O";
    }

    void OnGUI() {
        float horizontal_midpoint = camera.pixelWidth/2 - crossHairs_size/2;
        float vertical_midpoint = camera.pixelHeight/2 - crossHairs_size/2;
        // ^ rectangle is created on its topleft conner adjust to make to center
        Vector2 crossHair_position = new(horizontal_midpoint, vertical_midpoint);
        Vector2 CrossHair_Dimension = new(crossHairs_size, crossHairs_size);

        GUI.Label(new Rect(crossHair_position, CrossHair_Dimension), crossHairs_image);
    }
}