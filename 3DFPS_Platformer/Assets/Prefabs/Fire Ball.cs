using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    [SerializeField] GameObject fireballPrefab;
    private GameObject fireball;

    public float speed = 5.0f;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterController player = other.GetComponent<CharacterController>(); //change CharacterController to whatever the rigidbody name is

        if (player != null)
        {
            //we can input the code for the player to take damage
        }

        Destroy(this.gameObject);

    }
}
