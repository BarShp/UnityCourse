using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorController : MonoBehaviour
{
    public UnityEvent openHandler;
    public UnityEvent closeHandler;

    public void Open() => openHandler.Invoke();
    public void Close() => closeHandler.Invoke();

}