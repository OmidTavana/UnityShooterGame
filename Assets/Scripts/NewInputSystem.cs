using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputSystem : MonoBehaviour
{
    public float moveSpeed=3f;
    ShooterGameInputs inputActions;
    InputAction move,jump;
    // Start is called before the first frame update
    void Start()
    {
        inputActions = new ShooterGameInputs();
        move = inputActions.Player.Move;
        jump = inputActions.Player.Jump;
        jump.Enable();
        move.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDir = move.ReadValue<Vector2>();
        Vector2 jumpDir = jump.ReadValue<Vector2>();
        //Get model RigidBody
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();
        //Add Force To RigidBody
        rigidbody.AddForce(moveDir.x * moveSpeed, jumpDir.y, moveDir.y * moveSpeed);
    }
}
