using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float rotateSpeed = 200f;
    Vector3 moveVec;
    Vector3 smoothedVec;
    Vector3 rotateVec = new Vector3(0f, 0f, 0f);
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        moveVec = transform.position;
    }

    // Update is called once per frameaw
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            moveVec = transform.position + transform.TransformDirection(Vector3.forward) * MoveSpeed * Time.deltaTime ;
           

        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveVec = transform.position + transform.TransformDirection(Vector3.back) * MoveSpeed * Time.deltaTime;


        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * -1);
        }
         if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
        else rotateVec.y = 0;

        transform.Rotate(rotateVec*Time.deltaTime);
        transform.position = moveVec;


    }

    void FixedUpdate()
    {

    }
}
