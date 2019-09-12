using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementClass : MonoBehaviour
{
    Rigidbody rb;
    BoxCollider bc;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        
        
    }

    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        frontDriverW.steerAngle = m_steeringAngle;
        frontPassengerW.steerAngle = m_steeringAngle;
       
    }

    private void Accelerate()
    {
        rearDriverW.motorTorque = m_verticalInput * motorForce *Mathf.Log10(maxSpeed+1 - rb.velocity.magnitude);
        rearPassengerW.motorTorque = m_verticalInput * motorForce;
    }


    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        Debug.Log("Speed: " + rb.velocity.magnitude);
    }
    
    private void Update()
    {
        Debug.Log(frontDriverW.rpm*rearPassengerW.radius);
    }

    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;
    

    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;

    private float MotorTorque;

    public float maxSpeed = 500;
    public float maxSteerAngle = 30;
    public float motorForce = 50;
    
}
