using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovements : MonoBehaviour
{
    Animator animator;
    ShooterGameInputs gameInput;
    InputAction move;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        gameInput = new ShooterGameInputs();
        move = gameInput.Player.Move;
        move.Enable();
        move.performed += Move_performed;
        move.canceled += Move_canceled;
    }

    private void Move_canceled(InputAction.CallbackContext obj)
    {
        animator.SetBool("IsWalking", false);

    }

    private void Move_performed(InputAction.CallbackContext obj)
    {
        animator.SetBool("IsWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
