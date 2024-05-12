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
    List<float> completionTimes;
    Scene currentScene;


    [SerializeField] TMP_Text timeDisplay;
    [SerializeField] TMP_Text newTime;

    // Start is called before the first frame update
    void Start()
    {
        completionTimes = new List<float>();
        levelTime = 0f;
        levelFinished = false;
        goalEntered = false;
        Scoreboard = GameObject.Find("Scoreboard");
        Scoreboard.SetActive(false);
        HUD = GameObject.Find("HUD");
        HUD.SetActive(true);
        LoadLeaderboard();
        currentScene = SceneManager.GetActiveScene();
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
            newTime.text = levelTime + " seconds";
            AddScore();
            goalEntered = true;
            StartCoroutine(DelayedRestart());
        }
    }

    public void AddScore()
    {
        completionTimes.Add(levelTime);
        SortLeaderboard();
    }

    void SortLeaderboard()
    {
        for (int i = completionTimes.Count - 1; i > 0; i--) 
        {
            // If current score is lower than score above it, swap
            if (completionTimes[i] < completionTimes[i - 1])
            {
                // temp variable to hold value
                float temp = completionTimes[i - 1];
                completionTimes[i - 1] = completionTimes[i];
                completionTimes[i] = temp;
            }
        }
        UpdatePrefs();
    }

    void UpdatePrefs()
    {
        string stats = "";

        for(int i = 0; i < completionTimes.Count; i++)
        {
            stats += completionTimes[i].ToString() + ",";
        }

        if (currentScene.name == "Tutorial Level")
        {
            PlayerPrefs.SetString("Tutorial_Leaderboard", stats);
        }
        else if (currentScene.name == "Level 1")
        {
            PlayerPrefs.SetString("Level_1_Leaderboard", stats);
        }
        
        UpdateLeaderboardVisual();
    }

    void UpdateLeaderboardVisual()
    {
        timeDisplay.text = "";

        for (int i = 0;i < completionTimes.Count && i<5; i++)
        {
            timeDisplay.text += (i+1) + "- " + completionTimes[i] + " seconds\n";
        }
    }

    void LoadLeaderboard()
    {
        string stats = "";

        if (currentScene.name == "Tutorial Level")
        {
            stats = PlayerPrefs.GetString("Tutorial_Leaderboard");
        }
        else if (currentScene.name == "Level 1")
        {
            stats = PlayerPrefs.GetString("Level_1_Leaderboard");
        }

        string[] stats2 = stats.Split(',');

        for (int i = 0;i < stats2.Length;i++)
        {
            float loadedInfo = float.Parse(stats2[i]);
            completionTimes.Add(loadedInfo);
            UpdateLeaderboardVisual();
        }
    }

    

    private IEnumerator DelayedRestart()
    {
        Scoreboard.SetActive(true);
        HUD.SetActive(false);
        yield return new WaitForSeconds(5);
        //Debug.Log("Restarting Scene");
        SceneManager.LoadScene(0);
    }
}
