using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Cinemachine;


public class Controller : MonoBehaviour
{
    public GameObject activeMech;
    public GameObject activeGun;
    public GameObject activeSprite;

    public int activeMechNum = 1;

    public GameObject previousMech;
    public GameObject previousSprite;

    public GameObject mech1;
    public GameObject mech2;
    public GameObject mech3;
    public GameObject mech4;

    [SerializeField]
    private CinemachineVirtualCamera vcamTopRight;
    [SerializeField]
    private CinemachineVirtualCamera vcamBottomRight;
    [SerializeField]
    private CinemachineVirtualCamera vcamBottomLeft;
    [SerializeField]
    private CinemachineVirtualCamera vcamTopLeft;

    [SerializeField]
    private CinemachineVirtualCamera vcamWide;

    public CinemachineVirtualCamera activeCam;

    public int chargeLevel;
    private float timeLeft = 10;
    private float timer = 0;
    public GameObject chargeLevelUI;
    private bool gameEnded = false;

    public bool canShoot = true;
    public float teleportTimer = 0.2f;

    private void Start()
    {
        vcamWide.Priority = 1;
        activeCam = vcamWide;

        vcamTopRight.Priority = 0;
        vcamBottomRight.Priority = 0;
        vcamBottomLeft.Priority = 0;
        vcamTopLeft.Priority = 0;
    }
    
    public void changeMech(int mechNum)
    {
        if(mechNum == 1)
        {
            assignActiveMech(mech1);

            vcamTopRight.Priority = 1;
            vcamBottomRight.Priority = 0;
            vcamBottomLeft.Priority = 0;
            vcamTopLeft.Priority = 0;

            activeCam = vcamTopRight;
        }
        else if(mechNum == 2)
        {
            assignActiveMech(mech2);

            vcamTopRight.Priority = 0;
            vcamBottomRight.Priority = 1;
            vcamBottomLeft.Priority = 0;
            vcamTopLeft.Priority = 0;

            activeCam = vcamBottomRight;
        }
        else if (mechNum == 3)
        {
            assignActiveMech(mech3);

            vcamTopRight.Priority = 0;
            vcamBottomRight.Priority = 0;
            vcamBottomLeft.Priority = 1;
            vcamTopLeft.Priority = 0;

            activeCam = vcamBottomLeft;
        }
        else if (mechNum == 4)
        {
            assignActiveMech(mech4);

            vcamTopRight.Priority = 0;
            vcamBottomRight.Priority = 0;
            vcamBottomLeft.Priority = 0;
            vcamTopLeft.Priority = 1;

            activeCam = vcamTopLeft;
        }
        activeMechNum = mechNum;
        FindObjectOfType<MechAudio>().PlayTeleportSFX();
        TeleportIn();
        TeleportOut();
    }

    private void assignActiveMech(GameObject mech)
    {
        previousMech = activeMech;
        previousSprite = activeSprite;

        activeMech = mech;
        activeGun = mech.transform.Find("Gun").gameObject;
        activeSprite = mech.transform.Find("Sprite").gameObject;
    }


    public void TeleportIn()
    {
        
        Animator animator = activeSprite.GetComponent<Animator>();
        animator.Play("TeleportIN");
        animator.SetTrigger("EndTeleIn");

        canShoot = false;
    }

    public void TeleportOut()
    {
        if (previousMech)
        {
            Animator prevMechAnimator = previousSprite.GetComponent<Animator>();
            prevMechAnimator.Play("TeleportOUT");
            prevMechAnimator.SetTrigger("EndTeleOut");
        }
    }



    public void ChangeChargeLevel(int amount)
    {
        chargeLevel += amount;
        for(int i = 0; i <= 5; i++)
        {
            if(i <= chargeLevel && i != 0)
            {
                chargeLevelUI.transform.GetChild(i - 1).GetComponent<SpriteRenderer>().color = Color.green;
            }
            else if(i > 0)
            {
                chargeLevelUI.transform.GetChild(i - 1).GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
    public void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += EndGameLost;
        EnemySpawner.OnPlayerWin += EndGameWon;
    }
    public void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= EndGameLost;
        EnemySpawner.OnPlayerWin -= EndGameWon;
    }
    public void EndGameLost()
    {
        if(gameEnded == false)
        {
            //splash screen stuff 
            //disable all weapons and bots 
            var allEnemies = FindObjectsOfType<EnemyDamage>();
            foreach (var i in allEnemies) Destroy(i.gameObject); 
            FindObjectOfType<EnemySpawner>().stopSpawning = true;
            //switch to respective music 
            FindObjectOfType<MusicManager>().PlayLoseLick();
            gameEnded = true;
        }
    }

    public void EndGameWon()
    {
        if (gameEnded == false)
        {
            //splash screen stuff 
            //disable all weapons and bots 
            FindObjectOfType<EnemySpawner>().stopSpawning = true;

            //switch to respective music 
            FindObjectOfType<MusicManager>().PlayWinLick();
            gameEnded = true;
        }
    }

    private void Update()
    {
        //timer += Time.deltaTime; 
        if(chargeLevel < 5)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                ChangeChargeLevel(1);
                timeLeft = 10;
            }
        }

        if (canShoot == false)
        {
            teleportTimer -= Time.deltaTime;
            if (teleportTimer <=0)
            {
                canShoot = true;
                teleportTimer = 0.2f;
            }

        }
        
        

        //if(timer > 2)
        //{
        //    chargeLevel += 1;

        //    if (chargeLevel > 5)
        //        chargeLevel = 5;

        //    timer = 0;
        //}

    }
}
