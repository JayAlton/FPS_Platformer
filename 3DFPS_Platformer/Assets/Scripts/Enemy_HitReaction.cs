using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy_HitReaction : MonoBehaviour {
    private GameObject Spawner;

    void Awake() {
        Spawner = GameObject.FindGameObjectWithTag("Spawner");
    }

    public void ReactToHit() {
        if(Spawner.TryGetComponent<Enemy_Spawner>(out var obj)) {
            obj.RegisterKill(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
