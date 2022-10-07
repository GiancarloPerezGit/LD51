using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Health : MonoBehaviour
{
    public float health;
    protected float maxHealth; 

    private void Start()
    {
        maxHealth = health;
    }
    public virtual void Damage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
}
