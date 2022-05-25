using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;
    ShooterGame inputActions;
    InputAction move;
    InputAction run;
    bool isRunning = false;
    //Movement Spped
    float MoveSpeed = 0f;
    float ASpeed = 0f;
    float deacclerationASpeed = 0.5f;
    float rotationSpeed=40f;
    float accelationASpeed = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        characterController=GetComponent<CharacterController>();
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
        Vector2 moveVale=move.ReadValue<Vector2>();
        //if move is performed
        if (moveVale.y > 0)
        {
            //active run animation
            if (isRunning)
            {
                if (ASpeed <= 1)
                    ASpeed += accelationASpeed * Time.deltaTime;

                if(MoveSpeed<=9)
                MoveSpeed+=(accelationASpeed+2)*Time.deltaTime;
            }
            //active walk animation
            else
            {
                ASpeed = 0.1f;
                MoveSpeed=4.0f;
            }

        }
        //Run Idle Animation
        else
        {
            if (ASpeed > 0)
                ASpeed -= deacclerationASpeed * Time.deltaTime;
        }
        this.transform.Rotate(new  Vector3(0,Input.GetAxis("Mouse X")*rotationSpeed*Time.deltaTime,0));
        animator.SetFloat("Speed", ASpeed);
        characterController.Move(this.transform.forward*moveVale.y*MoveSpeed*Time.deltaTime);
    }
}
