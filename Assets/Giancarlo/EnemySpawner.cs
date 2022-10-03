using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject laneOne;
    public GameObject laneTwo;
    public GameObject laneThree;
    public GameObject laneFour;

    public GameObject basicEnemy;
    public Wave[] waves;

    public TargetDistanceUp targetUp; //the gameobject that the enemies are following when they spawn in
    public TargetDistanceUp targetDown;
    void Start()
    {
        DoWave(waves[0]);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoWave(Wave waveObj)
    {
        //spawn x basic enemies in the four random lanes and make it go towards mech
        SpawnBasicEnemy(waveObj.basicEnemyAmount);
    }


    private void SpawnBasicEnemy(int enemyAmt)
    {
        //create new ref to enemyAmt.
        int amt = enemyAmt; 
        for(int i = 0; i < amt; i++)
        {
            int x = 1;
            switch(x)
            {
                case 0:
                    GameObject go = Instantiate(basicEnemy, laneOne.transform.position, Quaternion.identity);
                    go.GetComponent<EnemyMovement>().Move(targetUp.gameObject.transform.position); 
                    break;

                    case 1:
                    GameObject go1 = Instantiate(basicEnemy, laneOne.transform.position, Quaternion.identity);
                    go1.GetComponent<EnemyMovement>().Move(targetDown.gameObject.transform.position);
                    break;

                case 2:
                    break;

                case 3:
                    break; 
            }
        }
        //while newRef is not 0, choose one of  the random lanes, and spawn enemy.
        //call enemy movement script
    }

}
