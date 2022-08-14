using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    public float ProjectileSpeed = 5f;
    public float lifetime = 5;

    Quaternion direction;
    float killTime;

    void Start()
    {
        transform.Rotate(90, 0, 0);
        killTime = Time.time + lifetime;
    }

    void FixedUpdate()
    {
        if(killTime <= Time.time)
        {
            Destroy(gameObject);
        }
        move();
    }

    void OnCollisionEnter(Collision other)
    {
        Vector3 surfaceNormal = other.contacts[0].normal;
    }

    void move()
    {
        transform.Translate(transform.up * ProjectileSpeed * Time.fixedDeltaTime, Space.World);
    }
}
