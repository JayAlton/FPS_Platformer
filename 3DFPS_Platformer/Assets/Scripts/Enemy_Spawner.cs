using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject PreFab;
    private int population;
    private int killed;
    private List<GameObject> enemies;
    [SerializeField] private GameObject Goal;


    public GameObject[] Spawn_location;

    void Awake() {
        enemies = new List<GameObject>();
        killed = 0;
        population = Spawn_location.Length;
    }

    void Start() {
        for(int current = 0; current < population; current++) {
            enemies.Add(Instantiate(PreFab)); // make enemies
            enemies[current].SetActive(true);

            float X_axis = Spawn_location[current].transform.position.x;
            float Y_axis = Spawn_location[current].transform.position.y + 0.5f; // offset
            float Z_axis = Spawn_location[current].transform.position.z;

            enemies[current].transform.position = new(X_axis, Y_axis, Z_axis); // in this location
            enemies[current].transform.rotation = Spawn_location[current].transform.rotation;
        }
    }

    public void RegisterKill(GameObject enemy)
    {
        if (enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
            Debug.Log("Enemies left: " + enemies.Count);
            killed += 1;
        }

        if (enemies.Count == 0)
        {
            Debug.Log("All enemies killed! Proceed to goal to finish the level.");
            Goal.GetComponent<Goal>().SetLevelFinish();
        }
    }

}
