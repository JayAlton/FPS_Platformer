using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
<<<<<<< Updated upstream

public class Goal : MonoBehaviour
{
    private float levelTime;
    private bool levelFinished;
    
    // Start is called before the first frame update
    void Start()
    {
        levelTime = 0f;
        levelFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelFinished == false)
        {
            levelTime += Time.deltaTime;
        }
    }
    public void SetLevelFinish() {
        levelFinished = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(levelFinished == false) {
            Debug.Log("Level Not Finished!");
        }
        else if(levelFinished == true)
        {
            Debug.Log("Completed in: " + levelTime + " seconds.");
=======
using TMPro;
using System;

public class Goal : MonoBehaviour {
    private bool actiave;
    private GameObject HUD;

    void Start() {
        actiave = false;
        HUD = GameObject.Find("HUD");
    }

    public void setState(Boolean status) {
        actiave = status;
    }


    private void OnTriggerEnter(Collider other) {
        if (!other.TryGetComponent<PlayerStatus>(out var player)) {return;}
  
        if(actiave) {
            actiave = false;
>>>>>>> Stashed changes
            StartCoroutine(DelayedRestart());
        }
    }

<<<<<<< Updated upstream
    private IEnumerator DelayedRestart()
    {
=======
    private IEnumerator DelayedRestart() {
        HUD.SetActive(false);
>>>>>>> Stashed changes
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}