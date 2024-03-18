using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour {
    [SerializeField] private GameObject PreFab;
    [SerializeField] private GameObject Goal;

    private int population;
    private List<GameObject> enemies;

    public GameObject[] locations;

    void Awake() {
        enemies = new List<GameObject>();
        population = locations.Length;
    }

    void Start() {
        for(int current = 0; current < population; current++) {
            enemies.Add(Instantiate(PreFab));
            enemies[current].SetActive(true);

            float X_axis = locations[current].transform.position.x;
            float Y_axis = locations[current].transform.position.y + 0.5f; // offset
            float Z_axis = locations[current].transform.position.z;

            enemies[current].transform.position = new(X_axis, Y_axis, Z_axis);
            enemies[current].transform.rotation = locations[current].transform.rotation;
        }
    }

    public void RegisterKill(GameObject enemy) {
        if (enemies.Contains(enemy)) {
            enemies.Remove(enemy);
            population--;
        }
        if (population == 0) {
            Goal.GetComponent<Goal>().SetLevelFinish();
        }
    }

}
