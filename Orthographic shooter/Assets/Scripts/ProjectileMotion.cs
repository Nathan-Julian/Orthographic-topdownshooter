using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    public float ProjectileSpeed = 5f;
    public float lifetime = 5;
    public int Totalreflections;

    public GameObject player;

    float killTime;
    int reflections = 0;
    void Start()
    {
        //rotate to face in correct direction, probably won't be issue once projectile gets custom model
        transform.Rotate(90, 0, 0);
        //set killTime to the time when the object should be deleted
        killTime = Time.time + lifetime;

        //setup projectile ignoreCollisions(player and other projectiles)
        Physics.IgnoreLayerCollision(8, 9, true);
        Physics.IgnoreLayerCollision(9, 9, true);
    }

    void FixedUpdate()
    {
        //check if it has been killTime since object was instantiated
        if(killTime <= Time.time)
        {
            Destroy(gameObject);
        }
        move();
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided with" + other.gameObject.name);
        if(other.gameObject.layer == 8) //layer 8 = Projectile_Ignore
        {
            Debug.Log("Ignoring Collision - Layer 8 Projectile_Ignore");
        }
        else if(other.gameObject.layer == 6 & reflections<Totalreflections)
        {
            //collect information about collision normal and projectile direction
            Vector3 surfaceNormal = other.contacts[0].normal;
            Vector3 direction = transform.eulerAngles;
            //math to determine new direction
            //new Vector3 newDirection = (direction.x, surfaceNormal.y - direction.y, direction.z);
            //direction.x, surfaceNormal.y - direction.y, direction.z
            transform.eulerAngles = (new Vector3(direction.x, surfaceNormal.y - direction.y, direction.z));
            reflections++;
        }else
        {
            //has already bounced n times, destroy self
            Destroy(gameObject);
        }
        

    }
    //move function, might add more later?
    void move()
    {
        transform.Translate(transform.up * ProjectileSpeed * Time.fixedDeltaTime, Space.World);
    }
}
