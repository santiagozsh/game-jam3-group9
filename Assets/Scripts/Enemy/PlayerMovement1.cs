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
    Animator animator;
    SpriteRenderer sprite;

    private float LastShoot;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            grounded = true;
        }
        else grounded = false;

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }
        if (horizontal > 0)
        {
            sprite.flipX = true;
        }
        else if (horizontal < 0)
        {
            sprite.flipX = false;
        }

    }


    private void Jump()
    {
        rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, 0);
        rigidBody2D.velocity += Vector2.up * jumpForce;

    }

    private void FixedUpdate()
    {
        if (horizontal != 0)
        {
            animator.SetBool("HorizontalMove", true);
            rigidBody2D.velocity = new Vector2(horizontal * speed, rigidBody2D.velocity.y);
        }
        else
        {
            animator.SetBool("HorizontalMove", false);
        }
    }


    public void Hit()
    {
        Health -= 1;
        if (Health == 0) Destroy(gameObject);
    }
}
