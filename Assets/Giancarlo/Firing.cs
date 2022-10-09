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
    private MechAudio mechAudio; 

    private Animator animator;
    public float bulletSpeed;
    public float shotIntensity;

    private void Start()
    {
        mechAudio = FindObjectOfType<MechAudio>(); 
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
        if (context.performed && controller.chargeLevel <= laserChargeAmount) //if play context but you dont have enough charge 
        {
            //play robot low battery 
           var robotAudio = FindObjectOfType<RobotFeedbackSFX>(); //will have a delay in it, so it doesnt spam
            robotAudio.PlayRobotFeedback(robotAudio.botOpWeaponsCharging);
        }
        if (context.performed && controller.chargeLevel >= laserChargeAmount)
        {
            //Add delay before spawning the LaserShot for animation
            laser = Instantiate(laserShot, controller.activeGun.transform.position, laserShot.transform.rotation);
            controller.ChangeChargeLevel(-laserChargeAmount);
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

    public void AnimateShooting()
    {
        animator = controller.activeSprite.GetComponent<Animator>();
        animator.Play("Shoot", 0, 0);
    }

    private void Update()
    {
        if(primed)
        {
            if (controller.canShoot)
            {
                if (firing)
                {
                    primed = false;
                    shot = Instantiate(basicShot, controller.activeGun.transform.position, basicShot.transform.rotation);
                    shot.AddComponent<Bullet>();

                    AnimateShooting();
                    CineMachineShake.Instance.ShakeCamera(shotIntensity, .1f, controller.activeCam);
                    
                    if (controller.activeMech.transform.position.x > 0)
                    {
                        shot.GetComponent<Bullet>().target = new Vector3(100, controller.activeMech.transform.position.y, 0);
                        shot.GetComponent<Bullet>().transform.Rotate(0.0f, 180.0f, 0.0f);
                    }
                    else
                    {
                        shot.GetComponent<Bullet>().target = new Vector3(-100, controller.activeMech.transform.position.y, 0);
                    }
                    shot.GetComponent<Bullet>().speed = bulletSpeed;
                    shot.GetComponent<Bullet>().damage = basicFireDamage;
                    shot.GetComponent<Bullet>().fire = true;
                }
                else
                {
                    shot.GetComponent<Bullet>().target = new Vector3(-100, controller.activeMech.transform.position.y, 0);
                }
                shot.GetComponent<Bullet>().damage = basicFireDamage;
                shot.GetComponent<Bullet>().fire = true;
                shot.transform.parent = this.transform;
                mechAudio?.PlayLaserBlast();
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
