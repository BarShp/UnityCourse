using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpHandler : MonoBehaviour
{
    public GameObject otherExpected;
    public UnityEvent touchActions;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == otherExpected.name)
        {
            touchActions.Invoke();
            gameObject.SetActive(false);
        }
    }
}