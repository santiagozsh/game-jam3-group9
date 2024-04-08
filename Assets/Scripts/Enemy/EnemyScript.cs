using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform target;
    public GameObject bulletPrefab;
    public Animator animator;
    public AudioClip damageSound;

    private int health = 3;
    private float lastShoot;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                // Determinar la escala actual
                Vector3 scale = transform.localScale;

                if (direction.x >= 0.0f)
                {
                    scale.x = Mathf.Abs(scale.x);
                }
                else
                {
                    scale.x = -Mathf.Abs(scale.x);
                }
                transform.localScale = scale;
            }
        }

        float distance = Mathf.Abs(target.position.x - transform.position.x);

        if (distance < 5.0f && Time.time > lastShoot + 2f)
        {
            Shoot();
            lastShoot = Time.time;
        }
    }

    private void Shoot()
    {

        animator.SetTrigger("Attack");
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        float bulletRotationZ = Mathf.Sign(transform.localScale.x) > 0 ? 0f : 180f;
        GameObject bullet = Instantiate(bulletPrefab, transform.position + direction * 0.2f, Quaternion.Euler(0f, 0f, bulletRotationZ));
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }
    bool delay = true;

    void AttackDelay()
    {
        delay = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (delay)
        {
            PlayerMovement john = other.GetComponent<PlayerMovement>();
            if (john != null)
            {
                john.Hit();
                delay = false;
                Invoke("AttackDelay", 2f);
            }

        }
    }

    public void Hit()
    {
        health -= 1;
        AudioManager.InstanceMusic.sfxAudioSource.clip = null;
        AudioManager.InstanceMusic.sfxAudioSource.Stop();
        AudioManager.InstanceMusic.PlaySound(damageSound);
        if (health == 0) Destroy(gameObject);
    }

}
