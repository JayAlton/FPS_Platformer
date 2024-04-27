using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip shotSound;
    [SerializeField] AudioClip hitEnemySound;
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
            Debug.Log("Mouse Click");
          
            Vector3 Screen_midpoint = new(camera.pixelWidth/2, camera.pixelHeight/2, 0);

            Ray ray = camera.ScreenPointToRay(Screen_midpoint);

            if(Physics.Raycast(ray, out RaycastHit hit)) {
                GameObject hit_Object = hit.transform.gameObject;
                soundSource.PlayOneShot(shotSound);
                Debug.Log("Hit Something");
                if (hit_Object.TryGetComponent<Enemy_HitReaction>(out var target)) {
                    target.ReactToHit(hit_Object.GetComponent<EnemyAI>());
                    soundSource.PlayOneShot(hitEnemySound);
                    Debug.Log("Hit target");
                }
                if (hit_Object.TryGetComponent<Object_HitReaction>(out var obj))
                {
                    obj.ReactToHit();
                    Debug.Log("Hit breakable object");
                }
            }
        }
    }
}
