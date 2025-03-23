using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider OnSolCol;
    public WheelCollider onSagCol;
    public WheelCollider arkaSolCol;
    public WheelCollider arkaSagCol;

    public GameObject onSol;
    public GameObject onSag;
    public GameObject arkaSol;
    public GameObject arkaSag;

    public float maxMotorGucu;
    public float maxDonusacisi;
    public float motor;
    void Start()
    {
        
    }

    
    void Update()
    {
       

    }

    private void FixedUpdate()
    {
        motor = maxMotorGucu * Input.GetAxis("Vertical");
        float donus = maxDonusacisi * Input.GetAxis("Horizontal");

        OnSolCol.steerAngle = donus;
        onSagCol.steerAngle = donus;
        arkaSagCol.motorTorque = motor;
        arkaSolCol.motorTorque = motor;
        SanalTeker();
    }

    void SanalTeker()
    {
        Quaternion rot;
        Vector3 pos;
        OnSolCol.GetWorldPose(out pos,out rot);
        onSol.transform.position = pos;
        onSol.transform.rotation = rot;
        
        onSagCol.GetWorldPose(out pos,out rot);
        onSag.transform.position = pos;
        onSag.transform.rotation = rot;
        
        arkaSolCol.GetWorldPose(out pos,out rot);
        arkaSol.transform.position = pos;
        arkaSol.transform.rotation = rot;
        
        arkaSagCol.GetWorldPose(out pos,out rot);
        arkaSag.transform.position = pos;
        arkaSag.transform.rotation = rot;
    }
}
