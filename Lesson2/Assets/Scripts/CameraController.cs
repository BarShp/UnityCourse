using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float height;
    public float distance;

    private Vector3 offest;

    // Start is called before the first frame update
    void Start()
    {
        offest = new Vector3(0, height, -distance) - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offest;
        transform.LookAt(player);
    }
}