using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.PackageManager;

public class PlayerHealth : Health
{
    public static event Action OnPlayerDeath;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Damage(float amount)
    {
        Debug.Log(maxHealth);
        health -= amount;
        if (health <= 0)
        {
            // Destroy(this.gameObject);
            Debug.Log("Player is dead!");
            var botAudio = FindObjectOfType<RobotFeedbackSFX>();
            botAudio.PlayRobotFeedback(botAudio.botObjLost);
            OnPlayerDeath?.Invoke();
        }

        if(health < (0.4 * maxHealth))
        {
            var botAudio = FindObjectOfType<RobotFeedbackSFX>();
            botAudio.PlayRobotFeedback(botAudio.botCriticalDmg);
        }

    }
}
