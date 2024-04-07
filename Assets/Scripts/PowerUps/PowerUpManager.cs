using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager instance;
    public GameObject player;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ApplyPowerUp(PowerUp powerUp)
    {
        if (powerUp.name == "Bow")
        {
            player.GetComponent<PlayerAttack>().bowPowerUp = true;
        }
        if (powerUp.name == "DoubleJump")
        {
            player.GetComponent<PlayerMovement>().jumpDelay = 0.2f;
        }
    }
}
