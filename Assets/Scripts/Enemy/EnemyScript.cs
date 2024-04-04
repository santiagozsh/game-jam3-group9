using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform target;
    public GameObject BulletPrefab;

    private int Health = 3;
    private float LastShoot;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        if (target != null) // Asegurarse de que el objetivo no sea nulo
        {
            // Calcula la dirección hacia el jugador
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            // Solo girar si la dirección del jugador está en el eje X
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                // Determinar la escala actual
                Vector3 scale = transform.localScale;

                // Voltear en el eje X dependiendo de la dirección del jugador
                if (direction.x >= 0.0f)
                {
                    scale.x = Mathf.Abs(scale.x);
                }
                else
                {
                    scale.x = -Mathf.Abs(scale.x);
                }

                // Aplicar la escala actualizada
                transform.localScale = scale;
            }
        }

        float distance = Mathf.Abs(target.position.x - transform.position.x);

        if (distance < 5.0f && Time.time > LastShoot + 2f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        // Dirección del proyectil basada en la escala actual del enemigo
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);

        // Determinar la rotación en Z del proyectil basada en la dirección del enemigo en X
        float bulletRotationZ = Mathf.Sign(transform.localScale.x) > 0 ? 0f : 180f;

        // Instanciar el proyectil con un pequeño ajuste de posición
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.2f, Quaternion.Euler(0f, 0f, bulletRotationZ));

        // Obtener el script del proyectil y establecer su dirección
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }
    public void Hit()
    {
        Health -= 1;
        if (Health == 0) Destroy(gameObject);
    }

}
