using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    public Controller controller;
    private void Start()
    {
        controller = GameObject.FindObjectOfType<Controller>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Vector2 direction = context.ReadValue<Vector2>();
            if(controller.activeMechNum == 1)
            {
                if (direction == Vector2.down)
                {
                    controller.changeMech(2);
                }
                else if (direction == Vector2.left)
                {
                    controller.changeMech(4);
                }
            }
            else if (controller.activeMechNum == 2)
            {
                if (direction == Vector2.up)
                {
                    controller.changeMech(1);
                }
                else if (direction == Vector2.left)
                {
                    controller.changeMech(3);
                }
            }
            else if (controller.activeMechNum == 3)
            {
                if (direction == Vector2.up)
                {
                    controller.changeMech(4);
                }
                else if (direction == Vector2.right)
                {
                    controller.changeMech(2);
                }
            }
            else if (controller.activeMechNum == 4)
            {
                if (direction == Vector2.right)
                {
                    controller.changeMech(1);
                }
                else if (direction == Vector2.down)
                {
                    controller.changeMech(3);
                }
            }
        }
    }
}
