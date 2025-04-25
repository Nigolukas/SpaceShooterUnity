using UnityEngine;

public class PARALLAX : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Vector2 direccion;
    [SerializeField] private float anchoImagen;
    private Vector2 PosicionInicial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PosicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float espacio = velocidad *Time.time;
        float resto = espacio % anchoImagen;


            transform.position = PosicionInicial + resto*direccion;
    }
}
