using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;
    private PlayerController playerController;
    private GameObject deathScreen;
    private GameObject HUD;

    [SerializeField] private Image healthBarFill;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        currentHealth = maxHealth;
        deathScreen = GameObject.Find("Death Screen");
        deathScreen.SetActive(false);
        HUD = GameObject.Find("HUD");
        //HUD already set to false in Goal script
    }

    public void Hurt(int damage)
    {
        currentHealth -= damage;
        // Debug.Log($"Health: {currentHealth}");
        // health.text = $"HP: {currentHealth}";
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
          if (currentHealth <= 0) {           
            StartCoroutine(PlayerDeath());
        }
        UpdateHealthBar();
    }
    private void UpdateHealthBar() {
        healthBarFill.fillAmount = (currentHealth/maxHealth);
    }

    private IEnumerator PlayerDeath()
    {
       // playerController.SetAlive(false);
        //Debug.Log("You are DEAD!");
        deathScreen.SetActive(true);
        HUD.SetActive(false);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
