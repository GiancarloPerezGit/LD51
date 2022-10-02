using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Firing : MonoBehaviour
{
    public Controller controller;
    private bool firing = false;
    private bool primed = false;
    public float basicFireDelay = 1;
    public float basicFireDamage = 1;
    public GameObject basicShot;
    private float timeLeft = 1;



    private void Start()
    {
        controller = GameObject.FindObjectOfType<Controller>();
        timeLeft = basicFireDelay;
    }

    public void BasicFire(InputAction.CallbackContext context)
    {
        if(context.canceled)
        {
            firing = false;
        }
        if(context.performed)
        {
            firing = true;
        }
    }

    private void Update()
    {
        if(primed)
        {
            if(firing)
            {
                primed = false;
                Instantiate(basicShot, controller.activeMech.transform.position, basicShot.transform.rotation);
            }
        }
        else
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0)
            {
                primed = true;
                timeLeft = basicFireDelay;
            }
        }
    }
}
