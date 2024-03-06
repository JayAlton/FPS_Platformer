using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    private new Camera camera;
    private int MouseClick;
    private enum typesOf_Clicks {
        Left_Click = 0,
        Right_Click = 1
    }


    void Awake() {
        camera = GetComponent<Camera>();
        MouseClick = (int)typesOf_Clicks.Left_Click;
    }


    void Update() {
        if (Input.GetMouseButtonDown(MouseClick)) {
          
            Vector3 Screen_midpoint = new(camera.pixelWidth/2, camera.pixelHeight/2, 0);

            Ray ray = camera.ScreenPointToRay(Screen_midpoint);

            if(Physics.Raycast(ray, out RaycastHit hit)) {
                GameObject hit_Object = hit.transform.gameObject;
                if (hit_Object.TryGetComponent<Enemy_HitReaction>(out var target)) {
                    target.ReactToHit();
                }
            }
        }
    }
}
