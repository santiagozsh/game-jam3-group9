using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Collision coll;
    private Animator anim;
    private SpriteRenderer sprite;
    public GameObject bulletPrefab;

    public float shootCooldown = 1f;
    private float lastShootTime;
    public bool canAttackOnAir;

    public bool bowPowerUp = false;
    private void Start()
    {
        coll = GetComponent<Collision>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleAttack();
    }

    private void HandleAttack()
    {
        if (bowPowerUp && !canAttackOnAir)
        {
            if (Input.GetMouseButtonDown(0) && coll.onGround && Time.time > lastShootTime + shootCooldown)
            {
                anim.SetTrigger("Attack");
                StartCoroutine(DelayForShoot());
                lastShootTime = Time.time;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && Time.time > lastShootTime + shootCooldown)
            {
                anim.SetTrigger("Attack");
                StartCoroutine(DelayForShoot());
                lastShootTime = Time.time;
            }
        }
    }

    IEnumerator DelayForShoot()
    {
        yield return new WaitForSeconds(.5f);
        Shoot();
    }

    private void Shoot()
    {
        Vector3 direction = sprite.flipX ? new Vector3(transform.localScale.x + 4, 0.0f, 0.0f) : new Vector3(transform.localScale.x - 5, 0.0f, 0.0f);
        float bulletRotationZ = sprite.flipX ? 180f : 0f;
        GameObject bullet = Instantiate(bulletPrefab, transform.position + direction * 0.2f, Quaternion.Euler(0f, 0f, bulletRotationZ));
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }
}

