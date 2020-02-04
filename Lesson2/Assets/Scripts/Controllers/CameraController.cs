using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float height;
    public float distance;
    public float cameraSpeedH;
    public float cameraSpeedV;
    public Transform player;

    private float yaw;
    private float pitch;
    private Vector3 offset;

    void Start()
    {
        pitch = transform.eulerAngles.x;
        yaw = transform.eulerAngles.y;
        transform.position = player.position + new Vector3(0, height, -distance);
        offset = transform.position - player.position;
    }

    void Update()
    {
        float mouseXAxis = Input.GetAxis("Mouse X");
        float mouseYAxis = Input.GetAxis("Mouse Y");

        ChangeCameraAngle(mouseXAxis, mouseYAxis);
        RotateAroundPlayer(mouseXAxis);
    }

    private void ChangeCameraAngle(float mouseXAxis, float mouseYAxis)
    {
        pitch -= cameraSpeedV * mouseYAxis;
        yaw += cameraSpeedH * mouseXAxis;
        transform.eulerAngles = new Vector3(Mathf.Clamp(pitch, 10, 55), yaw, 0.0f);
    }

    private void RotateAroundPlayer(float mouseXAxis)
    {
        offset = Quaternion.AngleAxis(mouseXAxis * cameraSpeedH, Vector3.up) * offset;
        transform.position = player.position + offset;
    }
}