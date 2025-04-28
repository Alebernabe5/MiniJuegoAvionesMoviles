using UnityEngine;

public class Player2D : MonoBehaviour
{

    [SerializeField]
    private FloatingJoystick fj;
    [SerializeField]
    [Range(1, 10)]
    private float velocidad;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(fj.Vertical);
        Debug.Log(fj.Horizontal);

        this.gameObject.transform.Translate(fj.Horizontal * Time.deltaTime * velocidad, fj.Vertical * Time.deltaTime * velocidad, 0.0f); //Conseguimos el desplazamiento del joystick
        
    }
}
