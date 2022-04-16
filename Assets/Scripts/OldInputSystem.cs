using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldInputSystem : MonoBehaviour
{
    private float moveSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Get Axis
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //Get model RigidBody
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();
        //Add Force To RigidBody
        rigidbody.AddForce(x * moveSpeed, 0, z * moveSpeed);
    }
}
