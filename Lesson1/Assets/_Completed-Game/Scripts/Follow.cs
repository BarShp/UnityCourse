using System.Collections;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject objectToFollow;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - objectToFollow.transform.position;
    }

    void LateUpdate()
    {
        transform.position = objectToFollow.transform.position + offset;
    }
}