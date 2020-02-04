using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform mainCamera;
    public float moveSpeed;
    public float sprintMultiplier;
    public float jumpForce;

    private Rigidbody rigidBody;
    private float distToGround;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    void Update()
    {
        Move();
        Jump();
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

        rigidBody.MovePosition(rigidBody.position + movementCameraDirection.normalized * speedToAdd * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

}