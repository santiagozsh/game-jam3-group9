using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Collision coll;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    public Animator anim;
    private int Health = 5;

    public float speed = 10;
    public float jumpForce = 50;

    public bool canMove;
    public bool isDashing;
    public bool isJumping;
    public bool isFalling;

    public ParticleSystem dustParticle;
    public GameObject bulletPrefab;

    private ControlleGamePLayUi controlleGamePLayUi;
    private void Start()
    {
        GameObject uiControllerObject = GameObject.Find("Canvas Game Play");

        controlleGamePLayUi=uiControllerObject.GetComponent<ControlleGamePLayUi>();
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
        if (Input.GetMouseButtonDown(0) && coll.onGround)
        {
            anim.SetTrigger("Attack");
            StartCoroutine(WaitForShoot());
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && coll.onGround) 
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

    IEnumerator WaitForShoot()
    {
        yield return new WaitForSeconds(.5f);
        Shoot();
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

    public void Hit()
    {
        anim.SetTrigger("Damage");
        Health -= 1;
        if (Health == 0) 
        {

            controlleGamePLayUi.activarPanelDerrota();
            Destroy(gameObject);
        }
    }

    private void Shoot()
    {
        if (sprite.flipX)
        {
            Vector3 direction = new Vector3(transform.localScale.x + 4, 0.0f, 0.0f);
            float bulletRotationZ = 180f;
            GameObject bullet = Instantiate(bulletPrefab, transform.position + direction * 0.2f, Quaternion.Euler(0f, 0f, bulletRotationZ));
            bullet.GetComponent<BulletScript>().SetDirection(direction);
        }
        if (!sprite.flipX)
        {
            Vector3 direction = new Vector3(transform.localScale.x - 5, 0.0f, 0.0f);
            float bulletRotationZ = 0f;
            GameObject bullet = Instantiate(bulletPrefab, transform.position + direction * 0.2f, Quaternion.Euler(0f, 0f, bulletRotationZ));
            bullet.GetComponent<BulletScript>().SetDirection(direction);
        }
    }
}
