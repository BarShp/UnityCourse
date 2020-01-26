using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBridgeController : MonoBehaviour
{
    private Transform partA;
    private Transform partB;

    private Vector3 partAEdge;
    private Vector3 partBEdge;

    void Start()
    {
        partA = transform.Find("PartA");
        partB = transform.Find("PartB");

        partAEdge = new Vector3(0, 0, -partA.GetComponent<MeshFilter>().mesh.bounds.size.z * partA.transform.localScale.z / 2);
        partBEdge = new Vector3(0, 0, partB.GetComponent<MeshFilter>().mesh.bounds.size.z * partB.transform.localScale.z / 2);
    }
    void Update()
    {
        // partA.Rotate(Vector3.right * 5 * Time.deltaTime, Space.Self);
        // partA.RotateAround(partA.position, Vector3.right, 5 * Time.deltaTime);
        // partA.Rotate(Vector3.right * 5 * Time.deltaTime, Space.World);
        // partA.transform.rotation += Quaternion.AngleAxis(1, Vector3.forward);
        // Debug.Log(partA.position - new Vector3(0, 0, 5));
        // partA.Rotate((partA.position - new Vector3(0, 0, 5)), 5 * Time.deltaTime, Space.World,);

        // partA.rotation = Quaternion.AngleAxis(5 * Time.deltaTime, Vector3.right);
        // offset = Quaternion.AngleAxis(mouseXAxis * cameraSpeedH, Vector3.up) * offset;
        // transform.position = player.position + offset;

        // Vector3 Pivot = new Vector3(0, 0, -5);
        // partA.position += partA.rotation * Pivot;
        // partA.rotation *= Quaternion.AngleAxis(5 * Time.deltaTime, Vector3.right);
        // partA.position -= partA.rotation * Pivot;

        // Vector3 Pivot = new Vector3(0, 0, -partA.transform.localScale.z * 10 / 2);

        // Debug.DrawRay(partA.position, partA.rotation * Vector3.up, Color.black);
        // Debug.DrawRay(partA.position, partA.rotation * Vector3.right, Color.black);
        // Debug.DrawRay(partA.position, partA.rotation * Vector3.forward, Color.black);

        // TODO: Change edge name to pivot
        Debug.Log("partAEdge: " + partAEdge);
        Debug.Log("Rotation times partAEdge: " + partA.rotation * partAEdge);
        partA.localPosition += partA.rotation * partAEdge;
        partA.Rotate(5 * Time.deltaTime * Vector3.right);
        partA.localPosition -= partA.rotation * partAEdge;
        // partA.GetComponent<MeshCollider>().transform.position = partA.transform.position;
        // partA.GetComponent<MeshCollider>().transform.rotation = partA.transform.rotation;

        Debug.DrawRay(partA.localPosition + (partA.rotation * partAEdge), partA.rotation * Vector3.up, Color.green);
        Debug.DrawRay(partA.localPosition + (partA.rotation * partAEdge), partA.rotation * Vector3.right, Color.red);
        Debug.DrawRay(partA.localPosition + (partA.rotation * partAEdge), partA.rotation * Vector3.forward, Color.blue);

        partB.localPosition += partB.rotation * partBEdge;
        partB.Rotate(5 * Time.deltaTime * Vector3.left);
        partB.localPosition -= partB.rotation * partBEdge;

        Debug.DrawRay(partB.localPosition + (partB.rotation * partBEdge), partB.rotation * Vector3.up, Color.green);
        Debug.DrawRay(partB.localPosition + (partB.rotation * partBEdge), partB.rotation * Vector3.right, Color.red);
        Debug.DrawRay(partB.localPosition + (partB.rotation * partBEdge), partB.rotation * Vector3.forward, Color.blue);
    }
}