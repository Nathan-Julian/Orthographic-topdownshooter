using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Camera cam;

    Vector2 mousePos;
    Vector3 aimPos;

    void Update()
    {
        //Get mouse input
        mousePos = Input.mousePosition;
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
    }
}
