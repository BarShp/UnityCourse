using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawnerController : MonoBehaviour
{
    public Transform meteor;

    private float topLimit;
    private float leftLimit;
    private float rightLimit;

    void Start()
    {
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        SpriteRenderer meteorSpriteRenderer = meteor.Find("MeteorAnimator").GetComponent<SpriteRenderer>();
        float objectWidth = meteorSpriteRenderer.size.x;
        float objectHeight = meteorSpriteRenderer.size.y;
        topLimit = screenBounds.y + objectHeight;
        leftLimit = screenBounds.x * -1 + objectWidth;
        rightLimit = screenBounds.x - objectWidth;
        InvokeRepeating("SpawnMeteor", 2, 2);
    }

    void SpawnMeteor()
    {
        Instantiate(meteor, new Vector2(Random.Range(leftLimit, rightLimit), topLimit), Quaternion.identity);
    }
}