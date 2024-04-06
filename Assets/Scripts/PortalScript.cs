using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public GameObject winPanel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Comprueba si la colisión es con el jugador
        {
            // Activa el panel de ganar
            if (winPanel != null)
            {
                winPanel.SetActive(true);
            }
        }
    }
}
