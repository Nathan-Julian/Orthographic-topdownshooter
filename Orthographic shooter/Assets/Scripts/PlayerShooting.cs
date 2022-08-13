using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Camera cam;

    public float fireRateDelay = 1;

    Vector2 mousePos;
    Vector3 aimPos;

    float timeToShoot = 0;
    bool m1Down;

    void Update()
    {
        //Get mouse input
        mousePos = Input.mousePosition;

        if(Input.GetMouseButton(0))
        {
            m1Down = true;
        }else
        {
            m1Down = false;
        }
    }

    void FixedUpdate() 
    {
        //Convert mouse input to raycast and find pointing coordinates
        Ray rayCastPos = cam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        Physics.Raycast(rayCastPos, out hit);
        aimPos = hit.point;

        Debug.DrawLine(cam.transform.position, aimPos, Color.red);

        //Look towards the aim point, rotate only on y axis
        transform.LookAt(new Vector3(aimPos.x, transform.position.y, aimPos.z));

        //shoot and set timeToShoot to current time plus delay
        if(m1Down == true && timeToShoot <= Time.time)
        {
            Debug.Log("shot");
            timeToShoot = Time.time + fireRateDelay;
        }
    }
}
