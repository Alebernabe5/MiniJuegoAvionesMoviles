using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    private int puntuacion;
    private int record;

    [SerializeField]
    private GameObject puntuacionUI;

    [SerializeField]
    private GameObject recordUI;

    [SerializeField]
    private GameObject panelDerrota;

    public void ActualizarPuntuacion(int incremento)
    { 
        puntuacion = puntuacion + incremento;
        ActualizarPuntiacionUI(puntuacion);

        //Actualizar la puntuacion del record
        record = PlayerPrefs.GetInt("RECORD");

        if (puntuacion > record)
        {
            PlayerPrefs.SetInt("RECORD", puntuacion);
            record = PlayerPrefs.GetInt("RECORD");
            ActualizarRecordUI(record);
        }
    }
    public void ActualizarPuntiacionUI(int puntos)
    { 
        puntuacionUI.gameObject.GetComponent<TMP_Text>().text = puntos.ToString(); //Recogemos el parametro y lo mostramos en la puntuacion
    } 
    
    public void ActualizarRecordUI(int puntosRecord)
    { 
        recordUI.gameObject.GetComponent<TMP_Text>().text = puntosRecord.ToString(); //Recogemos el parametro y lo mostramos en la puntuacion
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1.0f;
        puntuacion = 0;
        record = 0;

        ActualizarPuntiacionUI(puntuacion);
        ActualizarRecordUI(record);

        if (PlayerPrefs.HasKey("RECORD"))
        {
            //Existe
            record = PlayerPrefs.GetInt("RECORD");
            ActualizarRecordUI(record);
        }
        else
        {
            PlayerPrefs.SetInt("RECORD", 0);
            record = PlayerPrefs.GetInt("RECORD");
            ActualizarRecordUI(record);

        }

    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("Juego");
    }

    public void MostrarPanelDerrota() 
    { 
    panelDerrota.gameObject.SetActive(true);
        Invoke("DetenerJuego", 2.0f);
        
    }

    public void DetenerJuego() 
    {
        Time.timeScale = 0.0f; //con esto hago que se pare el juego
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
