using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrapBridgeController : MonoBehaviour
{
    public UnityEvent raiseHandler;
    public UnityEvent lowerHandler;

    public void Lower() => lowerHandler.Invoke();
    public void Raise() => raiseHandler.Invoke();

}