using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour {
    [SerializeField] private GameObject PreFab;
    private List<GameObject> enemies;

    void Awake() {
        enemies = new List<GameObject>();
    }

    void Start() {
        GameObject[] Spawn_locations = GameObject.FindGameObjectsWithTag("Spawn");
        Transform location = null;

        for(int current = 0; current < Spawn_locations.Length; current++) {
            enemies.Add(Instantiate(PreFab)); // make enemies
            enemies[current].SetActive(true);
            location = Spawn_locations[current].transform;

            enemies[current].transform.SetPositionAndRotation(location.position, location.rotation);
        }
    }

    public void RegisterKill(GameObject enemy) {
        if (enemies.Contains(enemy)) {
            enemies.Remove(enemy);
        }
        if (enemies.Count == 0) {
            GameObject goal = GameObject.FindGameObjectWithTag("Goal");
            if (goal.TryGetComponent<Goal>(out var other)) {
                other.setState(true);
            }
        }
    }
}
