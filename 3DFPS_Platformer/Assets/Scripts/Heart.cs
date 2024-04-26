using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public float healHP = 10f; // Amount of HP to heal

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply speed boost to the player
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                // Apply speed boost immediately
                player.AddHeart(healHP);
                // Destroy the powerup object
                Destroy(gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        transform.Rotate(0, 5.0f * Time.fixedDeltaTime, 0);
    }
}
