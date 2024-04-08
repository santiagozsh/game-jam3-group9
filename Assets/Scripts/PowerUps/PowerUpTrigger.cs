using UnityEngine;

public class PowerUpTrigger : MonoBehaviour
{
    public PowerUp powerUp;
    public AudioClip pickSound;

    public float amplitud = 0.5f; // Amplitud del movimiento hacia arriba y hacia abajo
    public float velocidad = 1f; // Velocidad de la oscilación

    private Vector2 startPosition;

    void Start()
    {
        // Guardar la posición inicial del objeto
        startPosition = transform.position;
    }

    void Update()
    {
        // Calcular el desplazamiento vertical usando la función sinusoidal
        float offsetY = Mathf.Sin(Time.time * velocidad) * amplitud;

        // Aplicar el desplazamiento vertical al objeto
        transform.position = startPosition + new Vector2(0f, offsetY);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PowerUpManager.instance.ApplyPowerUp(powerUp);
            AudioManager.InstanceMusic.sfxAudioSource.clip = null;
            AudioManager.InstanceMusic.sfxAudioSource.Stop();
            AudioManager.InstanceMusic.PlaySound(pickSound);
            Destroy(gameObject);
        }
    }
}
