using System.Collections;
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
		offset = new Vector3(player.position.x, player.position.y + height, player.position.z - distance);
	}

	void LateUpdate()
	{
		float mouseXAxis = Input.GetAxis("Mouse X");
		float mouseYAxis = Input.GetAxis("Mouse Y");

		ChangeCameraAngle(mouseXAxis, mouseYAxis);
		RotateAroundPlayer(mouseXAxis, mouseYAxis);
	}

	private void ChangeCameraAngle(float mouseXAxis, float mouseYAxis)
	{
		pitch -= cameraSpeedV * mouseYAxis;
		yaw += cameraSpeedH * mouseXAxis;
		transform.eulerAngles = new Vector3(Mathf.Clamp(pitch, 10, 55), yaw, 0.0f);
	}

	private void RotateAroundPlayer(float mouseXAxis, float mouseYAxis)
	{
		offset = Quaternion.AngleAxis(mouseXAxis * cameraSpeedH, Vector3.up) * offset;
		transform.position = player.position + offset;
	}
}