using UnityEngine;

public class LABALAScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private int direccion = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.position + new Vector3(1,0,0)* Time.deltaTime * velocidad;
        transform.Translate(new Vector3(direccion,0,0) * velocidad * Time.deltaTime);
    }
}
