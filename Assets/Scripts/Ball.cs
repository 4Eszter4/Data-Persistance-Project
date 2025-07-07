using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        //paddleTransform = GameObject.FindWithTag("Paddle").transform;
    }
    
    private void OnCollisionExit(Collision other)
    {
        var velocity = m_Rigidbody.velocity;

        // Get direction from parent (paddle) to ball
        //Vector3 parentPos = transform.parent.position;
        //Vector3 direction = (transform.position - parentPos).normalized;
        // Set velocity in that direction, keeping the same speed
        //velocity = direction * velocity.magnitude;

        //after a collision we accelerate a bit
        velocity += velocity.normalized * 0.01f;

        //check if we are not going totally vertically as this would lead to being stuck, we add a little vertical force
        if (Vector3.Dot(velocity.normalized, Vector3.up) < 0.2f)
        {
            velocity += velocity.y > 0 ? Vector3.up * 0.5f : Vector3.down * 0.5f;
        }

        //max velocity
        if (velocity.magnitude > 3.0f)
        {
            velocity = velocity.normalized * 3.0f;
        }

        m_Rigidbody.velocity = velocity;
    }
}
