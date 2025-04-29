using UnityEngine;

public class MisilPlayer : MonoBehaviour
{

    private int posDestruccion;
    private int incremento;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        posDestruccion = 300;
        incremento = 5;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        other.gameObject.transform.position = new Vector2(posDestruccion, 300);
        this.gameObject.transform.position = new Vector2(posDestruccion, 400);

        posDestruccion = posDestruccion + incremento;
    }
}
