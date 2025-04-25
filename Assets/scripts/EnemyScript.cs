using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float velocidad;
    [SerializeField] private GameObject Spawn;
    [SerializeField] private GameObject BalaPrefab;
    private float timer = 5;
    private float limite = 2;
    void Start()
    {
        
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
            limite = Random.Range(1, 5) / 2;
        }
        
    }

    IEnumerator Disparos()
    {
        for(int i = 0; i<2; i++)
        {
            Instantiate(BalaPrefab, Spawn.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerShoot"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
