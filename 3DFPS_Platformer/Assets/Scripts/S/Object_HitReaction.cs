using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_HitReaction : MonoBehaviour
{
    public void ReactToHit()
    {
        Destroy(this.gameObject);
    }
}
