using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
<<<<<<< Updated upstream
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour {
    // private int Health = 3;

<<<<<<< Updated upstream:3DFPS_Platformer/Assets/Scripts/PlayerStatus.cs
    // private GameObject deathScreen;
    // private GameObject HUD;
=======
    private int maxHealth = 3;
    private int currentHealth;
    //private PlayerController playerController;
    private GameObject deathScreen;
    private GameObject HUD;
>>>>>>> Stashed changes:3DFPS_Platformer/Assets/Scripts/Player/PlayerStatus.cs

    // [SerializeField] TMP_Text health;

<<<<<<< Updated upstream:3DFPS_Platformer/Assets/Scripts/PlayerStatus.cs
    // void Start() {
    //     deathScreen = GameObject.Find("Death Screen");
    //     deathScreen.SetActive(false);
    //     HUD = GameObject.Find("HUD");
    // }
=======
    // Start is called before the first frame update
    void Start()
    {
        //playerController = GetComponent<PlayerController>();
        currentHealth = maxHealth;
        deathScreen = GameObject.Find("Death Screen");
        deathScreen.SetActive(false);
        HUD = GameObject.Find("HUD");
        //HUD already set to flase in Goal script
    }
>>>>>>> Stashed changes:3DFPS_Platformer/Assets/Scripts/Player/PlayerStatus.cs

    // void Update()
    // {
    //     if (currentHealth <= 0)
    //     {           
    //         StartCoroutine(PlayerDeath());
    //     }
    // }

    // public void Hurt(int damage) {
    //     currentHealth -= damage;
    // }

    // private IEnumerator PlayerDeath() {

    //     deathScreen.SetActive(true);
    //     HUD.SetActive(false);
    //     yield return new WaitForSeconds(3);
    //     SceneManager.LoadScene(0);
    // }
=======
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour {

    public float health;
    private GameObject deathScreen;
    private GameObject HUD;

    void Start() {
 
        health = 21;
        deathScreen = GameObject.Find("Death Screen");
        deathScreen.SetActive(false);
        HUD = GameObject.Find("HUD");
    }

    public void Hurt(int damage){
        health -= damage;
        if (health <= 0) {           
            StartCoroutine(PlayerDeath());
        }
    }

    private IEnumerator PlayerDeath() {
        deathScreen.SetActive(true);
        HUD.SetActive(false);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
>>>>>>> Stashed changes
}
