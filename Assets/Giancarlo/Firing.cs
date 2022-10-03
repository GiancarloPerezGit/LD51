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

    public float laserDamage;
    public int laserChargeAmount;
    public GameObject laserShot;
    private GameObject laser;

    public float turretDamage;
    public int turretChargeAmount;
    public float turretFireDelay = 2;
    public GameObject turretModel;
    private GameObject turret;

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

    public void LaserFire(InputAction.CallbackContext context)
    {
        if(context.performed && controller.chargeLevel > 4)
        {
            //Add delay before spawning the LaserShot for animation
            laser = Instantiate(laserShot, controller.activeMech.transform.position, laserShot.transform.rotation);
            controller.chargeLevel = 0;
        }
    }

    public void SummonTurret(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //Add delay before spawning the LaserShot for animation
            turret = Instantiate(turretModel, controller.activeMech.transform.position, turretModel.transform.rotation);
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
