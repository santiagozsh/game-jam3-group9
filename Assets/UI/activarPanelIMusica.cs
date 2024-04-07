using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class activarPanelIMusica : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource musicAudioSource;
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Awake()
    {
        GameObject panelMusica = GameObject.FindGameObjectWithTag("PanelMusica");
        if (panelMusica != null)
        {
            musicAudioSource = panelMusica.GetComponent<AudioSource>();
            musicSlider = panelMusica.GetComponentInChildren<Slider>();
            sfxSlider = panelMusica.GetComponentInChildren<Slider>();
        }
        else
        {
            Debug.LogWarning("No se encontró el objeto 'PanelMusica' con la etiqueta 'PanelMusica'.");
        }
    }
}
