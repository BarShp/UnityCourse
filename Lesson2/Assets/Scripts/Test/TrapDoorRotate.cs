using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrapDoorRotate : MonoBehaviour
{
    public float speed;
    public bool hingeOnLeft;
    public float startingRotation;

    private Vector3 pivot;
    private Vector3 rotationSide = Vector3.left;

    void Start()
    {
        float edgeOnZ = transform.GetComponent<MeshFilter>().mesh.bounds.size.z * transform.transform.localScale.z / 2;
        if (hingeOnLeft)
        {
            edgeOnZ *= -1;
            rotationSide *= -1;
        }
        pivot = new Vector3(0, 0, edgeOnZ);
        Rotate(startingRotation);
    }

    public void Raise() => Rotate(true);
    public void Lower() => Rotate();

    private void Rotate(float rotation)
    {
        transform.localPosition += transform.rotation * pivot;
        transform.Rotate(rotationSide * rotation);
        transform.localPosition -= transform.rotation * pivot;
    }
    private void Rotate(bool reverse = false)
    {
        transform.localPosition += transform.rotation * pivot;
        transform.Rotate(rotationSide * (reverse ? -1 : 1) * speed * Time.deltaTime);
        transform.localPosition -= transform.rotation * pivot;
    }
}