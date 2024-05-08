using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy_Counter : MonoBehaviour
{
    [SerializeField]
    private GameObject PreFab;
    private int population;
    private int killed;
    private List<GameObject> enemyList = new List<GameObject>();
    [SerializeField] private GameObject Goal;
    [SerializeField] TMP_Text enemiesLeft;


    public GameObject[] enemies;

    void Awake() {
        killed = 0;
        population = enemies.Length;
        for(int i = 0; i < population; i++) {
            enemyList.Add(enemies[i]);
        }
    }

    void Start() {
        /*
        for(int current = 0; current < population; current++) {
            enemies.Add(Instantiate(PreFab)); // make enemies
            enemies[current].SetActive(true);

            float X_axis = Spawn_location[current].transform.position.x;
            float Y_axis = Spawn_location[current].transform.position.y + 0.5f; // offset
            float Z_axis = Spawn_location[current].transform.position.z;

            enemies[current].transform.position = new(X_axis, Y_axis, Z_axis); // in this location
            enemies[current].transform.rotation = Spawn_location[current].transform.rotation;
        }
        */
        enemiesLeft.text = "Enemies left: " + enemies.Length;
    }

    public void RegisterKill(GameObject enemy)
    {
        if (enemyList.Contains(enemy))
        {
            enemyList.Remove(enemy);
            Debug.Log("Enemies left: " + enemyList.Count);
            enemiesLeft.text = "Enemies left: " + enemyList.Count;
            killed += 1;
        }

        if (enemyList.Count == 0)
        {
            Debug.Log("All enemies killed! Proceed to goal to finish the level.");
            Goal.GetComponent<Goal>().SetLevelFinish();
        }
    }

}
