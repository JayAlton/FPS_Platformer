using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy_HitReaction : MonoBehaviour {
<<<<<<< Updated upstream
    private GameObject Spawner;
=======

    private GameObject scene_controller;
>>>>>>> Stashed changes

    void Awake() {
        Spawner = GameObject.FindGameObjectWithTag("Spawner");
    }

    public void ReactToHit() {
<<<<<<< Updated upstream
        if(Spawner.TryGetComponent<Enemy_Spawner>(out var obj)) {
            obj.RegisterKill(this.gameObject);
=======
        if(scene_controller.TryGetComponent<Enemy_Spawner>(out var spawner)) {
            spawner.RegisterKill(this.gameObject);
>>>>>>> Stashed changes
            Destroy(this.gameObject);
        }
    }
}
