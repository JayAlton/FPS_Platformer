using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Goal : MonoBehaviour
{
    private float levelTime;
    private bool levelFinished;
    // Purpose: prevents user from activating the goal again during the brief downtime from delayed restart
    private bool goalEntered;
    private GameObject Scoreboard;
    private GameObject HUD;
    

    [SerializeField] TMP_Text timeDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        levelTime = 0f;
        levelFinished = false;
        goalEntered = false;
        Scoreboard = GameObject.Find("Scoreboard");
        Scoreboard.SetActive(false);
        HUD = GameObject.Find("HUD");
        HUD.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        levelTime += Time.deltaTime;
        
    }
    public void SetLevelFinish() {
        levelFinished = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(levelFinished == false) {
            Debug.Log("Level Not Finished!");
        }
        else if(levelFinished == true && goalEntered == false)
        {
            Debug.Log("Completed in: " + levelTime + " seconds.");
            timeDisplay.text = "Completed in: " + levelTime + " seconds.";
            goalEntered = true;
            StartCoroutine(DelayedRestart());
        }
        
       
    }

    private IEnumerator DelayedRestart()
    {
        Scoreboard.SetActive(true);
        HUD.SetActive(false);
        yield return new WaitForSeconds(3);
        //Debug.Log("Restarting Scene");
        SceneManager.LoadScene(0);
    }
}
