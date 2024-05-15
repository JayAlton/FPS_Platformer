using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy_HitReaction : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject scene_controller;
    [SerializeField] private MeshRenderer renderer;
    [SerializeField] Material[] hpMaterialArr;
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip deathsfx;

    void Awake() {
        scene_controller = GameObject.FindGameObjectWithTag("SceneController");
    }


    public void ReactToHit(EnemyAI enemy) {
        if(scene_controller.TryGetComponent<Enemy_Spawner>(out var spawner)) {
            if(enemy.hp <= 0)
            {
                spawner.RegisterKill(this.gameObject);
                StartCoroutine(Death());

            }
            else
            {
                enemy.hp--;
                Debug.Log("Enemy HP: " + enemy.hp);
                switch(enemy.hp)
                {
                    case 0: renderer.material = hpMaterialArr[0]; break;
                    case 1: renderer.material = hpMaterialArr[1]; break;
                    case 2: renderer.material = hpMaterialArr[2]; break;
                    case 3: renderer.material = hpMaterialArr[3]; break;
                    default: renderer.material = hpMaterialArr[0]; break;
                }
            }
        }
    }

    private IEnumerator Death()
    {
        soundSource.PlayOneShot(deathsfx);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
