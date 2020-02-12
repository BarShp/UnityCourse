using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    public float maxSpeed = 5;
    public float minSpeed = 1;

    private Animator animator;
    private Rigidbody2D rb;
    private float bottomLimit;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-0.8f, 0.8f), -1) * Random.Range(minSpeed, maxSpeed);

        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        SpriteRenderer meteorSpriteRenderer = transform.Find("MeteorAnimator").GetComponent<SpriteRenderer>();
        float objectHeight = meteorSpriteRenderer.bounds.extents.y;
        bottomLimit = screenBounds.y * -1 - objectHeight;
    }

    void Update()
    {
        if (transform.position.y <= bottomLimit)
        {
            Destroy();
        }
    }

    public void Explode()
    {
        animator.SetTrigger("Explode");
        Destroy(GetComponent<BoxCollider2D>());
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}