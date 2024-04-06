using Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Collision coll;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private int Health = 5;

    public float speed = 8;
    public float jumpForce = 8;
    public float coyoteTime = 1.5f;

    private float coyoteTimer;

    public bool canMove;
    public bool isDashing;
    public bool isJumping;
    public bool isFalling;

    public ParticleSystem dustParticle;

    private ControlleGamePLayUi controlleGamePLayUi;

    private void Start()
    {
        GameObject uiControllerObject = GameObject.Find("Canvas Game Play");
        controlleGamePLayUi = uiControllerObject.GetComponent<ControlleGamePLayUi>();
        coll = GetComponent<Collision>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Walk(dir);
        HandleJumpingAndFalling();
        HandleJump();
        HandleFacingDirection(dir);

        if (coll.onGround)
        {
            coyoteTimer = Time.time + coyoteTime;
        }
        else if (Time.time < coyoteTimer)
        {
            HandleJumpingAndFalling();
        }
    }

    private void HandleJumpingAndFalling()
    {
        if (coll.onGround)
        {
            GetComponent<BetterJumping>().enabled = true;
            isJumping = false;
            isFalling = false;
        }

        if (rb.velocity.y > 3f)
        {
            isJumping = true;
            isFalling = false;
        }
        else if (rb.velocity.y < -3f)
        {
            isFalling = true;
            isJumping = false;
        }
        else
        {
            isJumping = false;
            isFalling = false;
        }

        anim.SetBool("isJumping", isJumping);
        anim.SetBool("isFalling", isFalling);
    }

    private void HandleJump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && (coll.onGround || Time.time < coyoteTimer))
        {
            Jump(Vector2.up);
            isJumping = true;
            isFalling = false;
        }
    }

    private void Walk(Vector2 dir)
    {
        if (!canMove)
            return;
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
        anim.SetBool("HorizontalMove", dir.x != 0);
    }

    private void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpForce;
        dustParticle.Play();
    }

    private void HandleFacingDirection(Vector2 dir)
    {
        if (dir.x > 0)
            sprite.flipX = true;
        else if (dir.x < 0)
            sprite.flipX = false;
    }

    public void Hit()
    {
        anim.SetTrigger("Damage");
        Camera.main.gameObject.GetComponent<ScreenShake>().ShakeCamera(GetComponent<CinemachineImpulseSource>());
        Health -= 1;
        if (Health == 0)
        {
            controlleGamePLayUi.activarPanelDerrota();
            Destroy(gameObject);
        }
    }


}