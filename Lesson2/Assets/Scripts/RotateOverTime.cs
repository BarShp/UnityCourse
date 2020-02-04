using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RotateOverTime : MonoBehaviour
{
    public UnityEvent rotator;
    void Update()
    {
        rotator.Invoke();
    }
}