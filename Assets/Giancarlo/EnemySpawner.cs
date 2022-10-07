using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject laneOne;
    public GameObject laneTwo;
    public GameObject laneThree;
    public GameObject laneFour;

    public GameObject basicEnemy;
    public GameObject mediumEnemy;

    public GameObject advancedEnemy;
    public Wave[] waves;

    public TargetDummy targetUp; //the gameobject that the enemies are following when they spawn in
    public TargetDummy targetDown;

    public float newRound = 15.0f;
    private float timer = 0.0f;
    private int waveIndex = 0;
    void Start()
    {
        Debug.Log("Doing Wave " + waveIndex + 1 + "!!! ");
        DoWave(waves[waveIndex]);
        waveIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > newRound)//assumption that a new round starts every 15 secs
        {
            if (waveIndex < waves.Length)
            {
                Debug.Log("Doing Wave " + waveIndex + "!!! ");
                var botAudio = FindObjectOfType<RobotFeedbackSFX>();
                botAudio.PlayRobotFeedback(botAudio.botEnemySpotted);
                DoWave(waves[waveIndex]);
                waveIndex++;
                timer = 0.0f;
            }
        }
        
    }

    public void DoWave(Wave waveObj)
    {
        //spawn x basic enemies in the four random lanes and make them go towards mech
        StartCoroutine(SpawnEnemy(waveObj.basicEnemyAmount, basicEnemy));
        StartCoroutine(SpawnEnemy(waveObj.mediumEnemyAmount, mediumEnemy));
        StartCoroutine(SpawnEnemy(waveObj.advancedEnemyAmount, advancedEnemy));
    }


    private IEnumerator SpawnEnemy(int enemyAmt, GameObject enemyPrefab)
    {
        int amt = enemyAmt; 
        for(int i = 0; i < amt; i++)
        {
            int x = Random.Range(0, 4);
            switch(x)
            {
                case 0:
                    GameObject go = Instantiate(enemyPrefab, laneOne.transform.position, Quaternion.identity);
                    go.transform.Rotate(0.0f,180.0f,0.0f);
                    go.GetComponent<EnemyMovement>().Move(targetUp.gameObject.transform.position);
                    go.transform.parent = this.transform;
                    break;

                    case 1:
                    GameObject go1 = Instantiate(enemyPrefab, laneTwo.transform.position, Quaternion.identity);
                    go1.transform.Rotate(0.0f, 180.0f, 0.0f);
                    go1.GetComponent<EnemyMovement>().Move(targetDown.gameObject.transform.position);
                    go1.transform.parent = this.transform;

                    break;

                case 2:
                    GameObject go2 = Instantiate(enemyPrefab, laneThree.transform.position, Quaternion.identity);
                    go2.GetComponent<EnemyMovement>().Move(targetDown.gameObject.transform.position);
                    go2.transform.parent = this.transform;


                    break;

                case 3:

                    GameObject go3 = Instantiate(enemyPrefab, laneFour.transform.position, Quaternion.identity);
                    go3.GetComponent<EnemyMovement>().Move(targetUp.gameObject.transform.position);
                    go3.transform.parent = this.transform;

                    break; 
            }
            yield return new WaitForSeconds((10 / enemyAmt) + Random.Range(1.0f, 2.0f)); //make it now spawn at exact same time
        }
        
    }

}
