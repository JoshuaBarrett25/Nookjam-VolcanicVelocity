using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingCamera : MonoBehaviour
{
    public Transform headLocation;
    public float cameraDistance = 2f;
    public CarMovement carMovement;
    public GameObject _camera;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 headPosition = headLocation.position;
        Vector3 cameraSlerp = Vector3.Slerp(_camera.transform.position, headPosition, cameraDistance);

        Vector3 headRotation = headLocation.rotation.eulerAngles;
        Quaternion rotationSlerp = Quaternion.Slerp(_camera.transform.rotation, Quaternion.Euler(headRotation), 0.25f);

        Vector3 headLean = new Vector3(0, 0, carMovement.turnInput * 1.5f);
        Quaternion localRotationSlerp = Quaternion.Slerp(_camera.transform.localRotation, Quaternion.Euler(headLean), 0.25f);

        // transform.localRotation = Quaternion.Euler(0, 0, carMovement.turnInput * 5); // Rotate the camera to match the car's rotation


        transform.rotation = rotationSlerp;
        _camera.transform.position = cameraSlerp;
        _camera.transform.localRotation =localRotationSlerp;
    }
}
