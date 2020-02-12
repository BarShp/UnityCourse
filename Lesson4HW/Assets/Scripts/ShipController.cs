using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed = 1;
    public float fireCooldownRate = 0.2f;
    public Transform bullet;

    private Rigidbody2D rb;
    private float fireCooldown;
    private Vector3 bulletOffset;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        var bulletHeight = bullet.GetComponent<SpriteRenderer>().bounds.extents.y;
        bulletOffset = new Vector3(0, bulletHeight);
    }

    void FixedUpdate()
    {
        Fire();
        Move();
    }

    private void Fire()
    {
        if (fireCooldown == 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(bullet, transform.position + bulletOffset, Quaternion.identity);
                fireCooldown = fireCooldownRate;
            }
        }
        else
        {
            fireCooldown = Mathf.Max(fireCooldown - Time.deltaTime, 0);
        }
    }

    private void Move()
    {
        var horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        var verticalMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        rb.MovePosition(new Vector3(rb.position.x + horizontalMovement, rb.position.y + verticalMovement));
        // transform.position += new Vector3(horizontalMovement, verticalMovement);
    }
}