using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    Animator animator;
    ShooterGame inputActions;
    InputAction move;
    InputAction run;
    bool isRunning = false;
    float speed = 0f;
    float deacclerationSpeed = 0.5f;
    float accelationSpeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        inputActions = new ShooterGame();
        move = inputActions.Player.Move;
        run = inputActions.Player.Run;
        move.Enable();
        run.Enable();
        run.performed += Run_performed;
        run.canceled += Run_canceled;
    }

    private void Run_canceled(InputAction.CallbackContext obj)
    {
        isRunning = false;
    }

    private void Run_performed(InputAction.CallbackContext obj)
    {
        isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if move is performed
        if (move.ReadValue<Vector2>().y > 0)
        {

            //active run animation
            if (isRunning)
            {
                if (speed <= 1)
                    speed += accelationSpeed * Time.deltaTime;
            }
            //active walk animation
            else
            {
                speed = 0.1f;
            }

        }
        //Run Idle Animation
        else
        {
            if (speed > 0)
                speed -= deacclerationSpeed * Time.deltaTime;
        }
        animator.SetFloat("Speed", speed);

    }
}
