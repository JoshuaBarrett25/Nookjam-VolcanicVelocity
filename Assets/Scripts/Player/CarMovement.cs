using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [Header("Car Parts")]
    public Rigidbody carRigidbody;
    public WheelCollider frontLeftWC, frontRightWC, backLeftWC, backRightWC;
    public Transform frontLeftWheel, frontRightWheel, backLeftWheel, backRightWheel;

    [Header("Car Tuning")]
    public bool allowDrift = true;
    public float maxSteerAngle, turnSpeed, driveSpeed, reverseSpeed, maxSpeed;

    [Header("Sounds")]
    public float minPitch;
    public float maxPitch;
    private float pitchFromCar;
    [SerializeField] private AudioSource carAudio;

    [Header("Debug")]
    public bool controlsEnabled = true;
    private float moveInput;
    [HideInInspector] public float turnInput;
    public float currentSpeed;
    private bool wheelForce = true;

    [Header("Extra")]
    public bool isModel = false;
    public GameObject wheel;
    private Vector3 wheelRotation;

    private void Awake()
    {
        wheelRotation = wheel.transform.eulerAngles;
    }

    private void Start()
    {
        carAudio.Play();
    }

    private void Update()
    {
        if (controlsEnabled)
        {
            moveInput = Input.GetAxis("Vertical"); // Get the forward / backward input
            turnInput = Input.GetAxis("Horizontal"); // Get the left / right input

            moveInput *= moveInput > 0 ? driveSpeed : reverseSpeed; // If the input is positive, multiply it by the drive speed, otherwise multiply it by the reverse speed

            wheel.transform.localRotation *= Quaternion.Euler(0, 0, turnInput); // Rotate the wheel model

            if (allowDrift)
            {
                Drift();
            }
        }
        else
        {
            moveInput = 0;
            turnInput = 0;
        }

        EngineSound();
    }

    private void Drift()
    {
        float driftValue = Vector3.Dot(carRigidbody.velocity.normalized, transform.forward.normalized); // Get the dot product of the car's velocity and the car's forward vector
        float driftAngle = Mathf.Acos(driftValue) * Mathf.Rad2Deg; // Get the angle between the car's velocity and the car's forward vector

        if (driftAngle > 3 && currentSpeed > maxSpeed / 2)
        {
            wheelForce = false;
        }
        else
        {
            wheelForce = true;
        }
    }

    private void EngineSound()
    {
        pitchFromCar = Mathf.Lerp(minPitch, maxPitch, currentSpeed / maxSpeed); // Calculate the pitch based on the car's current speed
        carAudio.pitch = pitchFromCar;

        carAudio.volume = Mathf.Lerp(1.0f, 2.5f, currentSpeed / maxSpeed); // Calculate the volume based on the car's current speed
    }

    private void FixedUpdate()
    {
        currentSpeed = carRigidbody.velocity.sqrMagnitude * 5f; // Get the car's current speed

        if (Input.GetKey(KeyCode.Space))
        {
            Stop();
        }
        else
        {
            Move();
        }

        //* UPDATE WHEELS
        UpdateWheelRotation(frontLeftWC, frontLeftWheel);
        UpdateWheelRotation(frontRightWC, frontRightWheel);
        UpdateWheelRotation(backLeftWC, backLeftWheel);
        UpdateWheelRotation(backRightWC, backRightWheel);
    }

    public void Move()
    {
        carRigidbody.drag = 0.25f;

        //* STEER
        float steeringAngle = maxSteerAngle * turnInput * turnSpeed; // Calculate the steering angle

        if (!isModel)
        {
            frontLeftWC.steerAngle = steeringAngle; // Set the steering angle of the front wheels
            frontRightWC.steerAngle = steeringAngle;
        }
        else
        {
            frontLeftWC.steerAngle = -steeringAngle; // Set the steering angle of the front wheels
            frontRightWC.steerAngle = -steeringAngle;
        }

        //* CANCEL BRAKES
        frontLeftWC.brakeTorque = 0;
        frontRightWC.brakeTorque = 0;
        backLeftWC.brakeTorque = 0;
        backRightWC.brakeTorque = 0;

        //* ACCELERLATION
        backLeftWC.motorTorque = moveInput; // Set the motor torque of the back wheels
        backRightWC.motorTorque = moveInput;
    }

    public void Stop()
    {
        carRigidbody.drag = 2;

        //* BRAKE
        frontLeftWC.brakeTorque = driveSpeed * 4f;
        frontRightWC.brakeTorque = driveSpeed * 4f;
        backLeftWC.brakeTorque = driveSpeed * 2f;
        backRightWC.brakeTorque = driveSpeed * 2f;
    }

    public void UpdateWheelRotation(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 position = wheelTransform.position;
        Quaternion rotation = wheelTransform.rotation;
        wheelCollider.GetWorldPose(out position, out rotation);
        wheelTransform.position = position;
        wheelTransform.rotation = rotation;
    }
}
