using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Health : MonoBehaviour
{
    public float health;
    protected float maxHealth; 
    public EnemyTypeAudio enemyAudioType;
    private bool isLeftSide;
    private void Start()
    {
        maxHealth = health;
        if (transform.position.x < 0)
            isLeftSide = true;
        else
            isLeftSide = false;
    }
    public virtual void Damage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            var enemyAudio = FindObjectOfType<EnemyAudio>();
            if (enemyAudio != null)
            {
                enemyAudio.PlayEnemyDeath(enemyAudioType, isLeftSide); 
            }
            Destroy(this.gameObject);
        }
    }
    
}
