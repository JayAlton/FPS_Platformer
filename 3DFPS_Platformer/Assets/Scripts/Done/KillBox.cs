using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    public int damage = 5;
    private float DURACTION;

    void Awake() {
        DURACTION = 3f;
    }

    void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<PlayerStatus>(out var player)) {
            player.Hurt(damage);
        }
    }


    void OnTriggerExit(Collider other) {
        if (!other.TryGetComponent<PlayerStatus>(out var player)) {return;}
        DURACTION = 5f;
    }

    void OnTriggerStay(Collider other) {
        if (!other.TryGetComponent<PlayerStatus>(out var player)) {return;}
        
        DURACTION -= Time.deltaTime;
        if (DURACTION < 0) {
            player.Hurt(damage);
            DURACTION = 3f;
        }
    }


}
