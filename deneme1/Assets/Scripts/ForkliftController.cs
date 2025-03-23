using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftController : MonoBehaviour
{
    [Header("Hareket Ayarları")]
    [SerializeField] private float motorTorque = 100;
    [SerializeField] private float brakeForce = 30;
    [SerializeField] private float maxSteerAngle = 30;

    [Header("Fork Ayarları")]
    [SerializeField] private Transform forkTransform; // Fork'un Transform'u
    [SerializeField] private float forkSpeed = 2.0f; // Fork'un hareket hızı
    [SerializeField] private float minForkHeight = 0.5f; // Fork'un minimum yüksekliği
    [SerializeField] private float maxForkHeight = 3.0f; // Fork'un maksimum yüksekliği

    [Header("Tekerlek Colliderları")]
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [Header("Tekerlek Transformları")]
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    private float horizontalInput;
    private float verticalInput;
    private float forkInput;
    private bool isBrake;
    private float brakeTorque;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody ekleyelim
        if (rb == null)
        {
            Debug.LogError("Forklift'te Rigidbody yok! Lütfen ekleyin.");
        }
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleTorque();
        HandleSteering();
        HandleForkMovement(); // Fork hareketini kontrol et
        UpdateWheelTransforms(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelTransforms(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelTransforms(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelTransforms(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal"); // Direksiyon
        verticalInput = Input.GetAxis("Vertical"); // İleri - Geri
        forkInput = Input.GetAxis("Fork"); // Fork yukarı-aşağı
        isBrake = Input.GetKey(KeyCode.Space); // Fren
    }

    private void HandleTorque()
    {
        if (rb == null) return; // Rigidbody yoksa çalıştırma

        frontLeftWheelCollider.motorTorque = verticalInput * motorTorque;
        frontRightWheelCollider.motorTorque = verticalInput * motorTorque;
        rearLeftWheelCollider.motorTorque = verticalInput * motorTorque;
        rearRightWheelCollider.motorTorque = verticalInput * motorTorque;

        brakeTorque = (isBrake) ? brakeForce : 0;
        frontLeftWheelCollider.brakeTorque = brakeTorque;
        frontRightWheelCollider.brakeTorque = brakeTorque;
        rearLeftWheelCollider.brakeTorque = brakeTorque;
        rearRightWheelCollider.brakeTorque = brakeTorque;
    }

    private void HandleSteering()
    {
        float steerAngle = horizontalInput * maxSteerAngle;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }

    private void HandleForkMovement()
    {
        if (forkTransform != null)
        {
            float newHeight = forkTransform.localPosition.y + (forkInput * forkSpeed * Time.deltaTime);
            newHeight = Mathf.Clamp(newHeight, minForkHeight, maxForkHeight); // Yüksekliği sınırla
            forkTransform.localPosition = new Vector3(forkTransform.localPosition.x, newHeight, forkTransform.localPosition.z);
        }
    }

    private void UpdateWheelTransforms(WheelCollider collider, Transform transform)
    {
        Vector3 pos;
        Quaternion rot;
        collider.GetWorldPose(out pos, out rot);
        transform.position = pos;
        transform.rotation = rot;
    }
}
