using UnityEngine;

public class LABALAScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float velocidad;
    [SerializeField] private int direccion;
    private float inclinacion = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.position + new Vector3(1,0,0)* Time.deltaTime * velocidad;
        transform.Translate(new Vector3(direccion,inclinacion,0) * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish")) // si choca con el borde se destruye
        {
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("PlayerShoot") && this.CompareTag("EnemyShoot")) // si choca con el borde se destruye
        {
            Destroy(this.gameObject);
        }
    }

    public void inclinar(float inclinao)
    {
        inclinacion = inclinao;
    }

    public void SpeedUp()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.red;
        velocidad = velocidad*2;
    }

}
