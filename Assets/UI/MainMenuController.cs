using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update


    [Header("Activar panel")]
    [SerializeField]GameObject PanelOpciones;

    [Header("Botones")]
    [SerializeField]Button BotonJugar;
    [SerializeField]Button BotonOpciones;
    void Start()
    {
         Button botonIniciarJuego = BotonJugar.GetComponent<Button>();
		botonIniciarJuego.onClick.AddListener(empezarJuego);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void empezarJuego()
    {
        SceneManager.LoadScene("SceneTestUiGamepay");
    }
    
}
