using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 relativeHingePositions = new Vector3(50, 50, 50);
    public Vector3 rotationSpeed = new Vector3(0, 0, 0);

    private Vector3 pivot;
    // private Vector3 rotationSide = Vector3.one;

    void Start()
    {
        pivot = GetHingePosition();
        // Rotate(startingRotation);
    }

    void Update()
    {

        // transform.localPosition += transform.rotation * pivot;
        // transform.Rotate(rotationSide * (reverse ? -1 : 1) * speed * Time.deltaTime);

        transform.localPosition += transform.rotation * pivot;
        transform.Rotate(Vector3.forward * rotationSpeed.x * Time.deltaTime);
        transform.Rotate(Vector3.up * rotationSpeed.y * Time.deltaTime);
        transform.Rotate(Vector3.left * rotationSpeed.z * Time.deltaTime);
        transform.localPosition -= transform.rotation * pivot;

        Debug.DrawRay(transform.localPosition + (transform.rotation * pivot), transform.rotation * Vector3.up, Color.green);
        Debug.DrawRay(transform.localPosition + (transform.rotation * pivot), transform.rotation * Vector3.right, Color.red);
        Debug.DrawRay(transform.localPosition + (transform.rotation * pivot), transform.rotation * Vector3.forward, Color.blue);
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
        // TODO: Make sure it works

        float actualSize = size * localScale;
        return (relativeHingePosition / 100 * actualSize) - actualSize / 2;
    }

    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.localPosition + (transform.rotation * pivot), transform.rotation * Vector3.up);
        Gizmos.DrawRay(transform.localPosition + (transform.rotation * pivot), transform.rotation * Vector3.right);
        Gizmos.DrawRay(transform.localPosition + (transform.rotation * pivot), transform.rotation * Vector3.forward);
    }

    /// <summary>
    /// Called when the script is loaded or a value is changed in the
    /// inspector (Called in the editor only).
    /// </summary>
    void OnValidate()
    {
        pivot = GetHingePosition();
    }
}