using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    
    public void Damage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
}
