using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform objectToSpawn;

    void Start()
    {
        Instantiate(objectToSpawn, transform);
        InvokeRepeating("Spawn", 0, 1);
    }

    void Update()
    {

    }

    void Spawn()
    {
        Instantiate(objectToSpawn, transform);
    }
}