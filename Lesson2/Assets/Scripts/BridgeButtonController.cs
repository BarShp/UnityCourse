using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BridgeButtonController : MonoBehaviour
{
    public UnityEvent triggerHandler;
    void OnTriggerStay(Collider other)
    {
        triggerHandler.Invoke();
    }
}