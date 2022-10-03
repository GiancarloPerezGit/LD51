using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject activeMech;
    public int activeMechNum = 1;

    public GameObject mech1;
    public GameObject mech2;
    public GameObject mech3;
    public GameObject mech4;

    public int chargeLevel;
    private float timeLeft;
    private float timer = 0;

    public void changeMech(int mechNum)
    {
        if(mechNum == 1)
        {
            activeMech = mech1;
        }
        else if(mechNum == 2)
        {
            activeMech = mech2;
        }
        else if (mechNum == 3)
        {
            activeMech = mech3;
        }
        else if (mechNum == 4)
        {
            activeMech = mech4;
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
