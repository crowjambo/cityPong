using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 1;
    public Transform bottomTrans;
    public Transform topTrans;
    public string inputAxis;
    bool isColliding = false;

    bool TouchingWalls;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        var move = new Vector3(-Input.GetAxis(inputAxis), 0, 0);
        move = move * force * Time.deltaTime;
        //Debug.Log(move);f
        if (!isColliding)
        {
        }

        var botLimitIsReached = (transform.position.x >= 7f);
        var topLimitIsReached = (transform.position.x <= -7f);

        if (botLimitIsReached)
        {
            transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
        }
        if (topLimitIsReached)
        {
            transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
        }

        transform.Translate(move);



    }


    private void OnCollisionEnter(Collision collision)
    {
        isColliding = true;
        Debug.Log(isColliding);
    }

    private void OnCollisionExit(Collision collision)
    {
        isColliding = false;
    }

}
