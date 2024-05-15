using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] SettingsPopup settingsPopup;

    // Start is called before the first frame update
    private void Start()
    {
        settingsPopup.Close();
    }

        public void OnOpentSettings() 
        {
            settingsPopup.Open();
        }
}
