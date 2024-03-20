using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    private new Camera camera;
    private int NORMAL_CLICK;

<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
    void Awake() {
        camera = GetComponent<Camera>();
        NORMAL_CLICK = 0; // left mouse click
    }

<<<<<<< Updated upstream
    void Update() {
        if (Input.GetMouseButtonDown(NORMAL_CLICK)) {
          
            Vector3 screen_midpoint = new(camera.pixelWidth/2, camera.pixelHeight/2, 0);

            Ray ray = camera.ScreenPointToRay(screen_midpoint);

            if(Physics.Raycast(ray, out RaycastHit hit)) {
                GameObject hit_Object = hit.transform.gameObject;
  
                if (hit_Object.TryGetComponent<Enemy_HitReaction>(out var target)) {
                    target.ReactToHit();
                } else if (hit_Object.TryGetComponent<Object_HitReaction>(out var obj)) {
                    obj.ReactToHit();

=======

    void Update() {
        if (Input.GetMouseButtonDown(NORMAL_CLICK)) {
  
            Vector3 Screen_midpoint = new(camera.pixelWidth/2, camera.pixelHeight/2, 0);
            Ray ray = camera.ScreenPointToRay(Screen_midpoint);

            if(Physics.Raycast(ray, out RaycastHit hit)) {
                GameObject hit_Object = hit.transform.gameObject;

                if (hit_Object.TryGetComponent<Enemy_HitReaction>(out var target)) {
                    target.ReactToHit();
                }

                if (hit_Object.TryGetComponent<Object_HitReaction>(out var obj))
                {
                    obj.ReactToHit();
>>>>>>> Stashed changes
                }
            }
        }
    }
}
