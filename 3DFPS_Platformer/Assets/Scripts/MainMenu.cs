using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void PlayLevelOne () {
        SceneManager.LoadSceneAsync(1);
    }
      public void PlayLevelTwo () {
        SceneManager.LoadSceneAsync(2);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Cleared Scores.");
    }
}
