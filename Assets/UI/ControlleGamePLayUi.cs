using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ControlleGamePLayUi : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Botones")]
    [SerializeField]Button botonPausa;
    [SerializeField]Button botonContinuar;
    [SerializeField]Button botonReiniciarjuego;
    [SerializeField]Button botonVolverMenu;
    [SerializeField]Button botonPanelVictoriaVolverMenu;
    [SerializeField]Button botonPanelDerroReiniciar;
    [SerializeField]Button botonPanelComenzardeNuevo;
    [Header("Paneles")]    
    public GameObject panelVictoria;
    public GameObject panelDerrota;



    void Start()
    {

        Button botonDePausa = botonPausa.GetComponent<Button>();
		botonDePausa.onClick.AddListener(PausarJuego);

        Button botonDeContinuar = botonContinuar.GetComponent<Button>();
		botonDeContinuar.onClick.AddListener(ContinuarJuego);

        Button botonReiniciar = botonReiniciarjuego.GetComponent<Button>();
		botonReiniciar.onClick.AddListener(ReiniciarJuego);


        Button elementoPanelVictoriaVolverMenu = botonPanelVictoriaVolverMenu.GetComponent<Button>();
		elementoPanelVictoriaVolverMenu.onClick.AddListener(volverMenu);


        Button elementobotonPanelDerroReiniciar = botonPanelDerroReiniciar.GetComponent<Button>();
		elementobotonPanelDerroReiniciar.onClick.AddListener(ReiniciarJuego);
        Button elementobotonPanelComenzardeNuevo = botonPanelComenzardeNuevo.GetComponent<Button>();
		elementobotonPanelComenzardeNuevo.onClick.AddListener(volverMenu);

        

        Button botonMenu = botonVolverMenu.GetComponent<Button>();
		botonMenu.onClick.AddListener(volverMenu);
        panelVictoria=GameObject.Find("Panel Victoria");
        panelVictoria.SetActive(false);


        panelDerrota=GameObject.Find("Panel Derrota");
        panelDerrota.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PausarJuego()
    {
        Time.timeScale=0.0f;
    }
    void ContinuarJuego()
    {
        Time.timeScale=1.0f;
    }
    void ReiniciarJuego ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale=1.0F;
    }
    void volverMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale=1.0F;
    }

    public void activarPanelVictoria()
    {
        panelVictoria.SetActive(true);
        Time.timeScale=0.0f;
        
    }
    public void activarPanelDerrota()
    {
        panelDerrota.SetActive(true);
        Time.timeScale=0.0f;
    }

}
