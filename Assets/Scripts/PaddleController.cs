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
        //Debug.Log(move);
        transform.Translate(move);

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag.Equals("TopWall"))
        {
            var move = new Vector3(-1, 0, 0);
            move = move * force * Time.deltaTime;
            transform.Translate(move);
        }
        if (collision.gameObject.tag.Equals("BottomWall"))
        {
            var move = new Vector3(1, 0, 0);
            move = move * force * Time.deltaTime;
            transform.Translate(move);
        }
    }

}
