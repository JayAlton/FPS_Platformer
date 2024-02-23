using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveRange;
    public float moveSpeed;
    public bool moveX;
    private Vector3 startPos;
    private Vector3 currPos;
    private bool moveBack;
  

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        currPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(moveX) {
            if(transform.position.x - moveRange > startPos.x) {
                moveBack = true;
            } else if(transform.position.x + moveRange < startPos.x) {
                moveBack = false;
            }
        } else {
            if(transform.position.z - moveRange > startPos.z) {
                moveBack = true;
            } else if(transform.position.z + moveRange < startPos.z) {
                moveBack = false;
            }
        }

        currPos = transform.position;
        if(moveX) {
            if(moveBack) {
                currPos.x -= moveSpeed * Time.deltaTime;
            } else {
                currPos.x += moveSpeed * Time.deltaTime;
            }
        } else {
            if(moveBack) {
                currPos.z -= moveSpeed * Time.deltaTime;
            } else {
                currPos.z += moveSpeed * Time.deltaTime;
            }
        }
        transform.position = currPos;
    }


}
