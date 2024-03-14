using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{

    private int maxHealth = 3;
    private int currentHealth;
    private PlayerController playerController;
    private GameObject deathScreen;
    private GameObject HUD;

    [SerializeField] TMP_Text health;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        currentHealth = maxHealth;
        deathScreen = GameObject.Find("Death Screen");
        deathScreen.SetActive(false);
        HUD = GameObject.Find("HUD");
        //HUD already set to flase in Goal script
    }

    void Update()
    {
        if (currentHealth <= 0)
        {           
            StartCoroutine(PlayerDeath());
        }
    }

    public void Hurt(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Health: {currentHealth}");
        health.text = $"HP: {currentHealth}";
    }

    private IEnumerator PlayerDeath()
    {
        playerController.SetAlive(false);
        //Debug.Log("You are DEAD!");
        deathScreen.SetActive(true);
        HUD.SetActive(false);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
