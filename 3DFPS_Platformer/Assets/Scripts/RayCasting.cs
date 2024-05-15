using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip shotSound;
    [SerializeField] AudioSource hitEnemySound;
    [SerializeField] AudioClip destroy;
    private new Camera camera;
    private int MouseClick;
    private enum typesOf_Clicks {
        Left_Click = 0,
        Right_Click = 1
    }

    Animator animator;
    int walking;
    int Running;
    int Idle;
    int Reloading;

    bool isRoadling = false;


    int gun_cap = 5;
    int current_ammo_cap = 5;

    void Awake() {
        camera = GetComponent<Camera>();
        MouseClick = (int)typesOf_Clicks.Left_Click;
        animator = GetComponentInChildren<Animator>();
        walking = Animator.StringToHash("Walking");
        Running = Animator.StringToHash("Running");
        Idle = Animator.StringToHash("Idle");
        Reloading = Animator.StringToHash("Reloading");

    }


    void Update() {
        if (Input.GetMouseButtonDown(MouseClick) && !EventSystem.current.IsPointerOverGameObject() && !isRoadling) {
            Debug.Log("Mouse Click");
            Flash();
          
            Vector3 Screen_midpoint = new(camera.pixelWidth/2, camera.pixelHeight/2, 0);

            Ray ray = camera.ScreenPointToRay(Screen_midpoint);

            if(Physics.Raycast(ray, out RaycastHit hit)) {
                GameObject hit_Object = hit.transform.gameObject;
                soundSource.PlayOneShot(shotSound);
                Debug.Log("Hit Something");
                if (hit_Object.TryGetComponent<Enemy_HitReaction>(out var target)) {
                    target.ReactToHit(hit_Object.GetComponent<EnemyAI>());
                    hitEnemySound.Play(0);
                    Debug.Log("Hit target");
                }
                if (hit_Object.TryGetComponent<Object_HitReaction>(out var obj))
                {
                    obj.ReactToHit();
                    soundSource.PlayOneShot(destroy);
                    Debug.Log("Hit breakable object");
                }
            }
            current_ammo_cap -= 1;
        }

        if (current_ammo_cap <= 0) {
                animator.SetBool(Running, false);
                animator.SetBool(walking, false);
                animator.SetBool(Idle, false);
                animator.SetBool(Reloading, true);
                current_ammo_cap = gun_cap;
                isRoadling = true;
                StartCoroutine(reload_gun(2f));
        } else {
            animator.SetBool(Reloading, false);
        }
    }

    public GameObject[] muzzelFlash;
	public GameObject muzzelSpawn;
	private GameObject holdFlash;

	private void Flash(){

		int randomNumberForMuzzelFlash = Random.Range(0,5);
			holdFlash = Instantiate(muzzelFlash[randomNumberForMuzzelFlash], muzzelSpawn.transform.position /*- muzzelPosition*/, muzzelSpawn.transform.rotation * Quaternion.Euler(0,0,90) ) as GameObject;
			holdFlash.transform.parent = muzzelSpawn.transform;
    }

    private IEnumerator reload_gun(float duration)
    {
        Debug.Log("time: " + duration);
        yield return new WaitForSeconds(duration);
        isRoadling = false;

    }
}

