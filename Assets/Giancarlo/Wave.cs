using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public int basicEnemyAmount;
    public int mediumEnemyAmount;
    public int advancedEnemyAmount;
    public float timeForWave; 

    private float timer;

    public void Start()
    {
        timer = 0.0f; 
    }
    public void Update()
    {
        timer += Time.deltaTime; 

        if (timer > 10.0f)
        {
            
        }
    }




}
