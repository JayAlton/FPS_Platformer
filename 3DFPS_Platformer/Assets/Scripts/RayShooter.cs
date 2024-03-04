using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera cam; //reference to main camera

    // Start is called before the first frame update
    void Start()
    {
        //Use GetComponent<Camera> to get a reference to the camera 
        // The camera (as is this script) is attached to the player object
        cam = GetComponent<Camera>();
        
        // Hide the cursor at the ecenter of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Run the following code on Left Mouse button click
        if (Input.GetMouseButtonDown(0)) {
            //Use a Vector3 to store the location of the middle of the screeen
            //Divide the width and height by 2 to get the midpoint; these become
            // the x and y values of the vector, with z being 0
            Vector3 point = new Vector3(cam.pixelWidth/2, cam.pixelHeight/2, 0);

            //Create a ray bu calling ScreenPointToRay
            // Pass in the point, as this is used as the origin for the ray
            Ray ray = cam.ScreenPointToRay(point);

            //Create a RayCastHit object to figure out where the ray hit
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                // Get a reference to the object that was hit, then
                // get a regerence to that object's ReactiveTarget script,
                // if there is one
                GameObject hitObject = hit.transform.gameObject;
                EnemyAI target = hitObject.GetComponent<EnemyAI>();
                
                // If the ray had hit an enemy, (that is, if "target" isn't null),
                // indicate that an enemy was hit. Otherwise, place a sphere.
                if (target != null) {
                    Debug.Log("Target hit at: " + hit.point);
                    target.ReactToHit();
                } else {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }
    
    private IEnumerator SphereIndicator(Vector3 pos) {
        //Create a new game object that's a sphere
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        //Then place it at the given position
        sphere.transform.position = pos;

        // Then wait one second
        yield return new WaitForSeconds(1);

        // Then Destroy the sphere
        Destroy(sphere);
    }

    private void OnGUI() {
        //Font Size
        int size = 12; 

        // Coords at which the crosshairs are drawn
        float posX = cam.pixelWidth/2 - size/4;
        float posY = cam.pixelHeight/2 - size/2;

        //Draw the crosshairs as text
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}
