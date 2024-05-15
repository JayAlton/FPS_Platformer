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


    [SerializeField] TMP_Text timeDisplay;
    
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
            //timeDisplay.text = "Completed in: " + levelTime + " seconds.";
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

        PlayerPrefs.SetString("Leaderboard", stats);

        UpdateLeaderboardVisual();
    }

    void UpdateLeaderboardVisual()
    {
        timeDisplay.text = "";

        // possible error here
        for (int i = 0;i < completionTimes.Count;i++)
        {
            timeDisplay.text += completionTimes[i] + "\n";
        }
    }

    void LoadLeaderboard()
    {
        string stats = PlayerPrefs.GetString("Leaderboard");

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
        yield return new WaitForSeconds(10);
        //Debug.Log("Restarting Scene");
        SceneManager.LoadScene(0);
    }
}
