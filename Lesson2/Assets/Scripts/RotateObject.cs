using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 relativeHingePositions = new Vector3(50, 50, 50);
    public Vector3 rotationSpeed = new Vector3(0, 0, 0);
    public Vector3 initialRotation = new Vector3(0, 0, 0);

    private Vector3 pivot;
    private Vector3 rotationMovement;

    void Start()
    {
        pivot = GetHingePosition();
        rotationMovement =
            (Vector3.forward * rotationSpeed.x) +
            (Vector3.up * rotationSpeed.y) +
            (Vector3.left * rotationSpeed.z);
        Rotate(initialRotation);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.localPosition + (transform.rotation * pivot), transform.rotation * Vector3.right);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.localPosition + (transform.rotation * pivot), transform.rotation * Vector3.up);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.localPosition + (transform.rotation * pivot), transform.rotation * Vector3.forward);
    }

    void OnValidate()
    {
        // TODO: currently doesn't work on scale change,
        //          Fix that
        pivot = GetHingePosition();
    }

    // Rotates using the rotationMovement
    public void Rotate(bool reverse = false) => Rotate(rotationMovement * (reverse ? -1 : 1) * Time.deltaTime);

    // Rotates to a given rotation
    public void Rotate(Vector3 rotation)
    {
        transform.localPosition += transform.rotation * pivot;
        transform.Rotate(rotation);
        transform.localPosition -= transform.rotation * pivot;
    }

    private Vector3 GetHingePosition()
    {
        var transformSize = transform.GetComponent<MeshFilter>().mesh.bounds.size;
        var transformLocalScale = transform.transform.localScale;
        return new Vector3(
            GetSingleHinge(transformSize.x, transformLocalScale.x, relativeHingePositions.x),
            GetSingleHinge(transformSize.y, transformLocalScale.y, relativeHingePositions.y),
            GetSingleHinge(transformSize.z, transformLocalScale.z, relativeHingePositions.z)
        );
    }

    private float GetSingleHinge(float size, float localScale, float relativeHingePosition)
    {
        float actualSize = size * localScale;
        float startingEdge = -(actualSize / 2); // position 0 is the middle of the object, so minus half the size is the edge
        float relativePositionBySize = (relativeHingePosition / 100 * actualSize);
        return startingEdge + relativePositionBySize;
    }
}