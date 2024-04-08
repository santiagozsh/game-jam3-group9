using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    public AudioClip Sound;
    public float LifeTime = 5f; // Tiempo de vida de la bala si no colisiona con nada

    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        if (Sound) 
        { 
            Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
        }
        

        // Inicia el temporizador para destruir la bala si no colisiona con nada
        StartCoroutine(DestroyAfterDelay());
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyScript grunt = other.GetComponent<EnemyScript>();
        PlayerMovement john = other.GetComponent<PlayerMovement>();
        if (grunt != null)
        {
            grunt.Hit();
        }
        if (john != null)
        {
            john.Hit();
        }
            DestroyBullet();
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(LifeTime);
        DestroyBullet();
    }
}
