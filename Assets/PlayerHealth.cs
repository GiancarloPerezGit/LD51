using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
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
        }

        if(health < (0.3 * maxHealth))
        {
            var botAudio = FindObjectOfType<RobotFeedbackSFX>();
            botAudio.PlayRobotFeedback(botAudio.botCriticalDmg);
        }

    }
}
