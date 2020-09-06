using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float maxForce = 3;
    public float force = 0.5f;
    public Rigidbody rb;
    public Transform leftSide;
    public Transform rightSide;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(leftSide.position * force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(transform.forward * force);
        //rb.AddForce(leftSide.position * force);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Border"))
        {
            var collisionPoint = collision.contacts[0].point;
            Debug.Log("collision detected");
            rb.AddForce(collisionPoint * -force, ForceMode.Impulse);
            if (force <= maxForce)
            {
                force += 0.1f;
            }
        }
            
    }
}
