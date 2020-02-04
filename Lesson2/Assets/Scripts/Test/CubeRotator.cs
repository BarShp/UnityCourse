using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CubeRotator : MonoBehaviour
{
    public UnityEvent rotateForwardHandler;
    public UnityEvent rotateBackwardsHandler;
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            rotateForwardHandler.Invoke();
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            rotateBackwardsHandler.Invoke();
        }
    }
}