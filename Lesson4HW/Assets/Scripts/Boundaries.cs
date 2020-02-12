using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boundaries : MonoBehaviour
{
    public UnityEvent boundaryTouchedHandler;

    private float leftLimit;
    private float rightLimit;
    private float topLimit;
    private float bottomLimit;

    void Start()
    {
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        float objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        float objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
        leftLimit = screenBounds.x * -1 + objectWidth;
        rightLimit = screenBounds.x - objectWidth;
        topLimit = screenBounds.y - objectHeight;
        bottomLimit = screenBounds.y * -1 + objectHeight;
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, leftLimit, rightLimit);
        viewPos.y = Mathf.Clamp(viewPos.y, bottomLimit, topLimit);
        transform.position = viewPos;

        if (viewPos.x == leftLimit || viewPos.x == rightLimit || viewPos.y == bottomLimit || viewPos.y == topLimit)
        {
            boundaryTouchedHandler.Invoke();
        }
    }
}