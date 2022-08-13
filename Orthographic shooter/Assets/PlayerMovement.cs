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

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        //PlayerRB.MovePosition(PlayerRB.position + movement * moveForce * Time.fixedDeltaTime);
        PlayerRB.AddForce(movement * moveForce * Time.fixedDeltaTime);
        PlayerRB.drag = drag;
        if(movement.x == 0 && movement.z == 0)
        {
            Debug.Log("no input, applying decel Force");
            PlayerRB.AddForce(-PlayerRB.velocity * decelForce * Time.fixedDeltaTime);
        }
        Debug.Log(movement);
    }
}
