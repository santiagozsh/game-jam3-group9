using UnityEngine;

public class Movement : MonoBehaviour
{
    private Collision coll;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    public Animator anim;

    public float speed = 10;
    public float jumpForce = 50;

    public bool canMove;
    public bool isDashing;
    public bool isJumping;
    public bool isFalling;

    public ParticleSystem dustParticle;

    private void Start()
    {
        coll = GetComponent<Collision>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Walk(dir);
        anim.SetBool("HorizontalMove", dir.x != 0);

        if (coll.onGround)
        {
            GetComponent<BetterJumping>().enabled = true;
            isJumping = false;
            isFalling = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && coll.onGround)
        {
            
            Jump(Vector2.up);
            isJumping = true;
            anim.SetBool("isJumping", isJumping);
            isFalling = false; 
            anim.SetBool("isFalling", isFalling);
        }

        if (rb.velocity.y > 3f)
        {
            isJumping = true;
            isFalling = false;
            anim.SetBool("isFalling", isFalling);
            anim.SetBool("isJumping", isJumping);
        }
        else if (rb.velocity.y < -3f)
        {
            isFalling = true;
            isJumping = false;
            anim.SetBool("isFalling", isFalling);
            anim.SetBool("isJumping", isJumping);
        }
        else
        {
            isJumping = false;
            isFalling = false;
            anim.SetBool("isJumping", isJumping);
            anim.SetBool("isFalling", isFalling);
        }

        if (coll.onGround && !isDashing)
            isDashing = false;

        if (dir.x > 0)
        {
            sprite.flipX = true;
        }
        if (dir.x < 0)
        {
            sprite.flipX = false;
        }
    }

    private void Walk(Vector2 dir)
    {
        if (!canMove)
            return;
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
        
    }

    private void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpForce;
        dustParticle.Play();
    }
}
