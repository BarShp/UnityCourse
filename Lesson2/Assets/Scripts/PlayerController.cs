using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform mainCamera;
    public float moveSpeed;
    public float sprintMultiplier;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Change movement to camera direction
        Vector3 movementCameraDirection = mainCamera.TransformDirection(movement);
        movementCameraDirection.y = 0;

        // Calculate speed
        bool sprintMode = Input.GetKey(KeyCode.LeftShift);
        float speedToAdd = sprintMode ? moveSpeed * sprintMultiplier : moveSpeed;

        transform.position += movementCameraDirection.normalized * speedToAdd * Time.deltaTime;
    }
}