using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Cinemachine;


public class Controller : MonoBehaviour
{
    public GameObject activeMech;
    public int activeMechNum = 1;

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

    public int chargeLevel;
    private float timeLeft;
    private float timer = 0;

    private void Start()
    {
        vcamWide.Priority = 1;

        vcamTopRight.Priority = 0;
        vcamBottomRight.Priority = 0;
        vcamBottomLeft.Priority = 0;
        vcamTopLeft.Priority = 0;
    }

    public void changeMech(int mechNum)
    {
        if(mechNum == 1)
        {
            activeMech = mech1;

            vcamTopRight.Priority = 1;
            vcamBottomRight.Priority = 0;
            vcamBottomLeft.Priority = 0;
            vcamTopLeft.Priority = 0;
        }
        else if(mechNum == 2)
        {
            activeMech = mech2;

            vcamTopRight.Priority = 0;
            vcamBottomRight.Priority = 1;
            vcamBottomLeft.Priority = 0;
            vcamTopLeft.Priority = 0;
        }
        else if (mechNum == 3)
        {
            activeMech = mech3;

            vcamTopRight.Priority = 0;
            vcamBottomRight.Priority = 0;
            vcamBottomLeft.Priority = 1;
            vcamTopLeft.Priority = 0;
        }
        else if (mechNum == 4)
        {
            activeMech = mech4;

            vcamTopRight.Priority = 0;
            vcamBottomRight.Priority = 0;
            vcamBottomLeft.Priority = 0;
            vcamTopLeft.Priority = 1;
        }
        activeMechNum = mechNum;
    }

    private void Update()
    {
        timer += Time.deltaTime; 
        if(chargeLevel < 5)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                timeLeft = 10;
            }
        }
        

        if(timer > 2)
        {
            chargeLevel += 1;

            if (chargeLevel > 5)
                chargeLevel = 5;

            timer = 0;
        }

    }
}
