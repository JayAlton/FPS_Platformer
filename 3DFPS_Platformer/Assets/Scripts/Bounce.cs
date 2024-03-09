using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounceForce = 15.0f;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null )
        {
            Debug.Log("Bounce!");
            player.Bounce(bounceForce);
            Destroy(this.gameObject);
        }
    }
}
