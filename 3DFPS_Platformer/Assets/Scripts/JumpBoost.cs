using UnityEngine;
using System.Collections;

public class JumpBoost : MonoBehaviour
{
    public float jumpBoostAmount = 10f; // Amount of speed boost to apply
    public float powerupDuration = 10f; // Duration of the speed boost

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply speed boost to the player
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                // Apply speed boost immediately
                player.ApplyJumpBoost(jumpBoostAmount, powerupDuration);
                // Destroy the powerup object
                Destroy(gameObject);
            }
        }
    }

    
}
