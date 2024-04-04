using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce;
    private bool grounded;
    private float horizontal;
    private Rigidbody2D rigidBody2D;
    private int Health = 5;
    public GameObject bulletPrefab;

    private float LastShoot;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        // Detectar Suelo
        // Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            grounded = true;
        }
        else grounded = false;

        // Salto
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();
        }

    }


    private void Jump()
    {
        rigidBody2D.AddForce(Vector2.up * jumpForce);
    }

    private void FixedUpdate()
    {
        // Multiplica el valor horizontal por la velocidad
        rigidBody2D.velocity = new Vector2(horizontal * speed, rigidBody2D.velocity.y);
    }

 
    public void Hit()
    {
        Health -= 1;
        if (Health == 0) Destroy(gameObject);
    }
}
