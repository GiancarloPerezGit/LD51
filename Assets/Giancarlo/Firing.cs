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
    private GameObject shot;

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
                shot = Instantiate(basicShot, controller.activeMech.transform.position, basicShot.transform.rotation);
                shot.AddComponent<Bullet>();
                if (controller.activeMech.transform.position.x > 0)
                {
                    shot.GetComponent<Bullet>().target = new Vector3(100, controller.activeMech.transform.position.y, 0);
                }
                else
                {
                    shot.GetComponent<Bullet>().target = new Vector3(-100, controller.activeMech.transform.position.y, 0);
                }
                shot.GetComponent<Bullet>().damage = basicFireDamage;
                shot.GetComponent<Bullet>().fire = true;
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
