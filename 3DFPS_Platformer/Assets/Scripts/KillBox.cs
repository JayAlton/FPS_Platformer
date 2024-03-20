using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{

    public int damage = 5;

   

    private void OnTriggerEnter(Collider other)
    {
        PlayerStatus player = other.GetComponent<PlayerStatus>();
        if (player != null)
        {
            player.Hurt(damage);
        }
    }
}
