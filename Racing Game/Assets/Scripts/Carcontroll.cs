using System;
using System.Collections.Generic;
using UnityEngine;

public class CarControll : MonoBehaviour
{
    // =========================
    // PLAYER INPUT
    // =========================

    // Left (-1) and Right (+1) steering input.
    private float horizontalInput;

    // Forward (+1) and Reverse (-1) throttle input.
    private float verticalInput;

    // True while the Spacebar is being held.
    private bool isBraking;


    // =========================
    // CAR SETTINGS (Inspector)
    // =========================

    [Header("Car Settings")]

    [Tooltip("How much power is sent to the drive wheels. Higher = faster acceleration.")]
    [SerializeField] private float motorForce = 1500f;

    [Tooltip("How hard the brakes stop the car when Space is held.")]
    [SerializeField] private float brakeForce = 3000f;

    [Tooltip("Maximum steering angle in degrees.")]
    [SerializeField] private float maxSteerAngle = 30f;


    // =========================
    // WHEEL COLLIDERS
    // =========================
    // These are the invisible physics wheels.
    // They control suspension, traction and collisions.
    // Drag your WheelCollider components here.

    [Header("Wheel Colliders")]

    [Tooltip("Front Left Wheel Collider")]
    [SerializeField] private WheelCollider frontLeftCollider;

    [Tooltip("Front Right Wheel Collider")]
    [SerializeField] private WheelCollider frontRightCollider;

    [Tooltip("Rear Left Wheel Collider")]
    [SerializeField] private WheelCollider rearLeftCollider;

    [Tooltip("Rear Right Wheel Collider")]
    [SerializeField] private WheelCollider rearRightCollider;


    // =========================
    // WHEEL VISUALS
    // =========================
    // These are the actual 3D wheel models.
    // They follow the WheelColliders every frame.

    [Header("Wheel Meshes")]

    [Tooltip("3D Model for the Front Left Wheel")]
    [SerializeField] private Transform frontLeftTransform;

    [Tooltip("3D Model for the Front Right Wheel")]
    [SerializeField] private Transform frontRightTransform;

    [Tooltip("3D Model for the Rear Left Wheel")]
    [SerializeField] private Transform rearLeftTransform;

    [Tooltip("3D Model for the Rear Right Wheel")]
    [SerializeField] private Transform rearRightTransform;


    // =========================
    // UPDATE LOOP
    // =========================

    private void Update()
    {
        // Read keyboard/controller input every frame.
        GetInput();
    }

    private void FixedUpdate()
    {
        // Physics should always be done in FixedUpdate.
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }


    // =========================
    // INPUT
    // =========================

    private void GetInput()
    {
        // Horizontal:
        // A / Left Arrow = -1
        // D / Right Arrow = +1
        horizontalInput = Input.GetAxis("Horizontal");

        // Vertical:
        // W / Up Arrow = +1
        // S / Down Arrow = -1
        verticalInput = Input.GetAxis("Vertical");

        // Hold Space to brake.
        isBraking = Input.GetKey(KeyCode.Space);
    }


    // =========================
    // MOTOR
    // =========================

    private void HandleMotor()
    {
        // This car is Rear Wheel Drive (RWD).
        // Only the rear wheels receive engine power.
        rearLeftCollider.motorTorque = verticalInput * motorForce;
        rearRightCollider.motorTorque = verticalInput * motorForce;

        // Decide whether braking is active.
        float currentBrakeForce = isBraking ? brakeForce : 0f;

        // Apply brakes.
        ApplyBrake(currentBrakeForce);
    }


    // Applies braking force to all four wheels.
    private void ApplyBrake(float force)
    {
        frontLeftCollider.brakeTorque = force;
        frontRightCollider.brakeTorque = force;
        rearLeftCollider.brakeTorque = force;
        rearRightCollider.brakeTorque = force;
    }


    // =========================
    // STEERING
    // =========================

    private void HandleSteering()
    {
        // Calculate steering angle.
        // Example:
        // maxSteerAngle = 30
        // horizontalInput = 0.5
        // Steering = 15 degrees.
        float currentSteerAngle = horizontalInput * maxSteerAngle;

        // Only the front wheels steer.
        frontLeftCollider.steerAngle = currentSteerAngle;
        frontRightCollider.steerAngle = currentSteerAngle;
    }


    // =========================
    // VISUAL WHEELS
    // =========================

    private void UpdateWheels()
    {
        // Make each wheel mesh match its WheelCollider.
        UpdateSingleWheel(frontLeftCollider, frontLeftTransform);
        UpdateSingleWheel(frontRightCollider, frontRightTransform);
        UpdateSingleWheel(rearLeftCollider, rearLeftTransform);
        UpdateSingleWheel(rearRightCollider, rearRightTransform);
    }


    // Copies the WheelCollider's position and rotation
    // to the visible wheel mesh.
    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;

        // Unity calculates the wheel's true position and
        // rotation based on suspension, steering, and tire rotation. :contentReference[oaicite:0]{index=0}
        wheelCollider.GetWorldPose(out pos, out rot);

        // Move the wheel mesh.
        wheelTransform.position = pos;

        // Rotate the wheel mesh.
        wheelTransform.rotation = rot;
    }
}