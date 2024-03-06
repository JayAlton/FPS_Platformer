using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy_HitReaction : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject scene_controller;

    void Awake() {
        scene_controller = GameObject.FindGameObjectWithTag("SceneController");
    }


    public void ReactToHit() {
        if(scene_controller.TryGetComponent<Enemy_Spawner>(out var spawner)) {
            spawner.RegisterKill(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
