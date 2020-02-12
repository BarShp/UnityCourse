using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletController : MonoBehaviour
{
    public float speed = 10;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * speed;
    }

    // void Update()
    // {
    //     rb.MovePosition(new Vector3(rb.position.x, rb.position.y + speed * Time.deltaTime));
    // }

    void OnCollisionEnter2D(Collision2D other)
    {
        // TODO: change name check to type check
        if (other.gameObject.GetComponent<MeteorController>() != null)
        {
            other.gameObject.GetComponent<MeteorController>().Explode();
            Destroy();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}