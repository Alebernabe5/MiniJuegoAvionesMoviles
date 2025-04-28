using UnityEngine;

public class ControladorObjetosDanyo : MonoBehaviour
{

    [SerializeField]
    private GameObject limiteI;

    [SerializeField]
    private GameObject limiteD;

    [SerializeField]
    private GameObject asteroides1;

    private int posAsteroides1;

    [SerializeField]
    private GameObject asteroides2;

    [SerializeField]
    private GameObject asteroides3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posAsteroides1 = 0;
        InvokeRepeating("CambiarPosicionAsteroides1", 0.0f, 2.0f); //Te permite invocar las acciones cada x tiempo


    }
    public void CambiarPosicionAsteroides1()
    {

        asteroides1.gameObject.transform.GetChild(posAsteroides1).gameObject.transform.position = new Vector2(limiteI.gameObject.transform.position.x, limiteI.gameObject.transform.position.y);
        asteroides1.gameObject.transform.GetChild(posAsteroides1).gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        posAsteroides1++;
        if (posAsteroides1 >= asteroides1.gameObject.transform.childCount)
           {
            posAsteroides1 = 0;
            }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
