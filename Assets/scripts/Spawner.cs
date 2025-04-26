using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject EnemmyPrefab;
    private int nivel = 1;
    private int invocados = 0;
    void Start()
    {
        //Instantiate(EnemmyPrefab,transform.position, Quaternion.identity);
        InvokeRepeating("Spawn",0,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void NormalLevel()
    {

    }
    public void Spawn()
    {
        Vector3 RandomPlace = new Vector3 (transform.position.x,Random.Range(-4.5f,4.5f),0);
        Instantiate(EnemmyPrefab, RandomPlace, Quaternion.identity);
        invocados++;
    }
}
