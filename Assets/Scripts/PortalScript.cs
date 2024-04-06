using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    private ControlleGamePLayUi controlleGamePLayUi;

    private void Start()
    {
        GameObject uiControllerObject = GameObject.Find("Canvas Game Play");
        controlleGamePLayUi = uiControllerObject.GetComponent<ControlleGamePLayUi>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Comprueba si la colisión es con el jugador
        {
            controlleGamePLayUi.activarPanelVictoria();

        }
    }
}
