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

    void Start()
    {

        Button botonDePausa = botonPausa.GetComponent<Button>();
		botonDePausa.onClick.AddListener(PausarJuego);

        Button botonDeContinuar = botonContinuar.GetComponent<Button>();
		botonDeContinuar.onClick.AddListener(ContinuarJuego);

        Button botonReiniciar = botonReiniciarjuego.GetComponent<Button>();
		botonReiniciar.onClick.AddListener(ReiniciarJuego);

        Button botonMenu = botonVolverMenu.GetComponent<Button>();
		botonMenu.onClick.AddListener(volverMenu);
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
    }
    void volverMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
