using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveForce = 100f;
    public float drag = 5f;
    public float decelForce = 50f;

    public Rigidbody PlayerRB;

    Vector3 movement;

    void Update()
    {
        //Get keyboard Input and store in movement vector
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");       

        PlayerRB.drag = drag;
    }

    void FixedUpdate()
    {
        //Add force from movement vector
        PlayerRB.AddForce(movement * moveForce * Time.fixedDeltaTime);

        //if there is no movement input, apply a decelerating force
        if(movement.x == 0 && movement.z == 0)
        {
            PlayerRB.AddForce(-PlayerRB.velocity * decelForce * Time.fixedDeltaTime);
        }
    }
}
