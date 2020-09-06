using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float force = 0.5f;
    public Rigidbody rb;
    public Transform leftSide;
    public Transform rightSide;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(transform.forward * force);
        rb.AddForce(leftSide.position * force);
    }
}
