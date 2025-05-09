using System.Collections;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class ControladorObjetosDanyo : MonoBehaviour
{

    [SerializeField]
    private GameObject limiteI;

    [SerializeField]
    private GameObject limiteD;

    [SerializeField]
    private GameObject [] listadoObjetosDanyo;

    private int[] valorRR;

    private int listadoAleatorio;

    private float posXAleatoria;

    private float velocidadPosicionamiento;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        velocidadPosicionamiento = 1.0f;
        valorRR = new int [listadoObjetosDanyo.Length]; //Hay tanto RR como arrays seleccionados
        //InvokeRepeating("CambiarPosicion", 0.0f, 2.0f); //Te permite invocar las acciones cada x tiempo

        StartCoroutine(CambioDePosicion());
    }

    IEnumerator CambioDePosicion()
    {
        while (true)
        {
            yield return new WaitForSeconds(velocidadPosicionamiento);
            velocidadPosicionamiento = velocidadPosicionamiento - 0.01f;
            if (velocidadPosicionamiento <0.5f)
            {
                velocidadPosicionamiento = 0.5f;
            }
            CambiarPosicion();
        }
    }

    public void CambiarPosicion()
    {
        posXAleatoria = Random.Range(limiteI.gameObject.transform.position.x, limiteD.gameObject.transform.position.x);
        listadoAleatorio = Random.Range(0,listadoObjetosDanyo.Length);

        listadoObjetosDanyo[listadoAleatorio].gameObject.transform.GetChild(valorRR[listadoAleatorio]).gameObject.transform.position = new Vector2(posXAleatoria, limiteI.gameObject.transform.position.y);
        listadoObjetosDanyo[listadoAleatorio].gameObject.transform.GetChild(valorRR[listadoAleatorio]).gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero; //Eliminamos la energia de gravedad

        listadoObjetosDanyo[listadoAleatorio].gameObject.transform.GetChild(valorRR[listadoAleatorio]).gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.2f;

        valorRR[listadoAleatorio]++;

        if (valorRR[listadoAleatorio] >= listadoObjetosDanyo[listadoAleatorio].gameObject.transform.childCount)
        {
            valorRR[listadoAleatorio] = 0;
        }



        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
