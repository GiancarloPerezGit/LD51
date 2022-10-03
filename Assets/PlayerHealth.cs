using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Damage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            // Destroy(this.gameObject);
            Debug.Log("Player is dead!");
        }
    }
}