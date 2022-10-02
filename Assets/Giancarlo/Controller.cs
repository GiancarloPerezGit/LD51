using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject activeMech;
    public int activeMechNum = 1;

    public GameObject mech1;
    public GameObject mech2;
    public GameObject mech3;
    public GameObject mech4;

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
}
