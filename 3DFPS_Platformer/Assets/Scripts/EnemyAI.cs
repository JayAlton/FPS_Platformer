using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public UnityEngine.Vector3 startPos;
    public Animator aiAnimation;
    public bool moving;
    public bool moveZ;
    public float moveRange;
    public float moveSpeed;
    public float fireRate;
    public float shotDamage;
    public int hp;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector3 newPos = transform.position;
        if(moving) {
            aiAnimation.SetBool("walking", true);
            if(moveSpeed > 5) 
                aiAnimation.SetBool("running", true);
            if(moveZ) {
                newPos.z += moveSpeed * Time.deltaTime;
            } else {
                newPos.x += moveSpeed * Time.deltaTime;
            }
            if(Mathf.Abs(newPos.z - startPos.z) > moveRange ||
                Mathf.Abs(newPos.x - startPos.x) > moveRange)
            {
                moveSpeed *= -1; 
                transform.Rotate(UnityEngine.Vector3.up, 180f);
            }
        }
        transform.position = newPos;
    }


    public void currentPopulation() {
        
    }
}
