using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void OnTriggerEnter(Collider other)
    {
        levelFinished = true;
        Debug.Log("Completed in: " + levelTime + " seconds.");
        StartCoroutine(DelayedRestart());
       
    }

    private IEnumerator DelayedRestart()
    {
        yield return new WaitForSeconds(3);
        //Debug.Log("Restarting Scene");
        SceneManager.LoadScene(0);
    }
}
