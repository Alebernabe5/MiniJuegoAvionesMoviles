using UnityEngine;

public class Player2D : MonoBehaviour
{

    [SerializeField]
    private FloatingJoystick fj;
    [SerializeField]
    [Range(1, 10)]
    private float velocidad;

    [SerializeField]
    private GameObject explosiones;

    [SerializeField]
    private GameObject[] sonidos;

    [SerializeField]
    private GameObject misilesPlayer;

    private int valorRR;

    private int i;

    private int valorRRMisil;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        valorRRMisil = 0;
        valorRR = 0;
        InvokeRepeating("Disparar", 0.0f, 1.0f);
    }

    public void Disparar()
    {
        sonidos[1].gameObject.GetComponent<AudioSource>().Play(); //Reproduzco el sonido
        misilesPlayer.gameObject.transform.GetChild(valorRRMisil).gameObject.transform.position = this.gameObject.transform.position; //Cojo el misil y lo posiciono en el player 
        misilesPlayer.gameObject.transform.GetChild(valorRRMisil).gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0.0f, 10.0f);
        valorRRMisil++;

        if (valorRRMisil >= misilesPlayer.gameObject.transform.childCount)
        {
            valorRRMisil = 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        

        this.gameObject.transform.Translate(fj.Horizontal * Time.deltaTime * velocidad, fj.Vertical * Time.deltaTime * velocidad, 0.0f); //Conseguimos el desplazamiento del joystick
        
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
        Debug.Log("El objeto es: "+ other.gameObject.name);
        if (other.gameObject.tag != "MisilPlayer")
        {
            sonidos[0].gameObject.GetComponent<AudioSource>().Play();
            explosiones.gameObject.transform.GetChild(valorRR).gameObject.transform.position = this.gameObject.transform.position;
            explosiones.gameObject.transform.GetChild(valorRR).gameObject.SetActive(true); //Active el sistema de particulas
            Invoke("OcultarExplosion", 0.3f);

            valorRR++;
            if (valorRR >= explosiones.gameObject.transform.childCount)
            {
                valorRR = 0;
            }

            Destroy(other.gameObject); //Destruye el objeto que choca
            Destroy(this.gameObject); //Destruye la propia nave
        }
    }
}
