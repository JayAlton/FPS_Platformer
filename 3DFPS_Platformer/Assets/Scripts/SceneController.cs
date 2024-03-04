using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private int totalEnemies;
    public GameObject[] largePlatformArray;
    private GameObject[] enemyArray;
    private int kills;

    // Start is called before the first frame update
    void Start()
    {
        kills = 0;
        totalEnemies = largePlatformArray.Length;
        enemyArray = new GameObject[totalEnemies];
    }

    // Update is called once per frame
    void Update()
    {
        
        if(enemyArray[0] == null) {
            Debug.Log("Amount of Enemies to spawn: " + totalEnemies);
            for(int i = 0; i < totalEnemies; i++) {
                enemyArray[i] = Instantiate(enemyPrefab);
                enemyArray[i].transform.position = largePlatformArray[i].transform.position;
                enemyArray[i].transform.rotation = largePlatformArray[i].transform.rotation;
            }
        }
    }
    public void RegisterKill(GameObject enemy) {
        for(int i = 0; i < totalEnemies; i++) {
            if(enemyArray[i].Equals(enemy)) {
                enemyArray[i] = null;
            }
        }
        kills++;
        totalEnemies--;
        if(kills > 5) {
            GetComponent<Goal>().SetLevelFinish();
        } 
    }
}
