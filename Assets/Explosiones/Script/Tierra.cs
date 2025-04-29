using UnityEngine;

public class Tierra : MonoBehaviour
{

    [SerializeField]
    private GameObject explosiones;


    [SerializeField]
    private GameObject acumulador;

    private int valorRR;

    private int i;

    [SerializeField]
    private GameObject sonidoExplosion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        valorRR = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OcultarExplosion()
    {
        for (i = 0; i < explosiones.gameObject.transform.childCount; i++)
        {
            explosiones.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("El objeto es: " + other.gameObject.name);
        sonidoExplosion.gameObject.GetComponent<AudioSource>().Play();

        explosiones.gameObject.transform.GetChild(valorRR).gameObject.transform.position = other.gameObject.transform.position;
        explosiones.gameObject.transform.GetChild(valorRR).gameObject.SetActive(true); //Active el sistema de particulas
        Invoke("OcultarExplosion", 0.3f);

        valorRR++;
        if (valorRR >= explosiones.gameObject.transform.childCount)
        {
            valorRR = 0;
        }

        Destroy(other.gameObject); //Destruye el objeto que choca
        acumulador.gameObject.GetComponent<UIController>().MostrarPanelDerrota();
       // Destroy(this.gameObject); //Destruye la propia nave
    }
}
