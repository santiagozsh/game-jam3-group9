using UnityEngine;

public class PowerUpTrigger : MonoBehaviour
{
    public PowerUp powerUp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PowerUpManager.instance.ApplyPowerUp(powerUp);
            Destroy(gameObject);
        }
    }
}
