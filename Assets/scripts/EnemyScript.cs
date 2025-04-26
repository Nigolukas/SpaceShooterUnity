using System.Collections;
using TMPro;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float velocidad;
    [SerializeField] private GameObject Spawn;
    [SerializeField] private GameObject BalaPrefab;
    [SerializeField] private EnemyType Tipo;

    private float timer = 5;
    private float limite = 2;
    void Start()
    {
        
    }

    public enum EnemyType
    {
        Enemy1,Enemy2
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * velocidad * Time.deltaTime);
        timer += 1 * Time.deltaTime;
        if(timer > limite)
        {
            StartCoroutine(Disparos());
            timer = 0;
            limite = Random.Range(2, 4); ;
        }
        
    }

    IEnumerator Disparos()
    {
        int disp =  Random.Range(1, 3);
        for(int i = 0; i<disp; i++)
        {
            if (Tipo == EnemyType.Enemy1)
                Instantiate(BalaPrefab, Spawn.transform.position, Quaternion.identity);
            else if(Tipo == EnemyType.Enemy2)
            {
                GameObject bala1 = Instantiate(BalaPrefab, Spawn.transform.position - new Vector3(0, 0.3f, 0), Quaternion.identity);
                GameObject bala2 = Instantiate(BalaPrefab, Spawn.transform.position - new Vector3 (0,0.1f,0), Quaternion.identity);
                GameObject bala3 = Instantiate(BalaPrefab, Spawn.transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
                GameObject bala4 = Instantiate(BalaPrefab, Spawn.transform.position - new Vector3(0, 0.3f, 0), Quaternion.identity);
                LABALAScript BALAAA1 = bala1.GetComponent<LABALAScript>();
                LABALAScript BALAAA2 = bala2.GetComponent<LABALAScript>();
                LABALAScript BALAAA3 = bala3.GetComponent<LABALAScript>();
                LABALAScript BALAAA4 = bala4.GetComponent<LABALAScript>();
                BALAAA1.inclinar(0.3f);
                BALAAA2.inclinar(-0.3f);
                BALAAA3.inclinar(0.1f);
                BALAAA4.inclinar(-0.1f);
            }
            
            yield return new WaitForSeconds(1f);
        }
        
    }

    public void ActualizarScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 10);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerShoot"))
        {
            Destroy(collision.gameObject);
            ActualizarScore();
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Finish")) // si choca con el borde se destruye
        {
            Destroy(this.gameObject);
        }
    }
}
