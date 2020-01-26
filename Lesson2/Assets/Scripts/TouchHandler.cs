using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchHandler : MonoBehaviour
{
    public GameObject otherExpected;
    public UnityEvent touchActions;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == otherExpected.name) touchActions.Invoke();
    }
}