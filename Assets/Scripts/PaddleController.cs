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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        var test = new Vector3(-Input.GetAxis(inputAxis), 0, 0);
        Debug.Log(test);
        test = test * force * Time.deltaTime;
        Debug.Log(test);
        transform.Translate(test);
        
    }
}
