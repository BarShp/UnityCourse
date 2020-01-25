using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Meow");
        other.gameObject.SetActive(false);
    }

}