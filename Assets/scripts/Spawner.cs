using System.Collections;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject EnemmyPrefab;
    [SerializeField] private GameObject EnemmyPrefab2;
    [SerializeField] private TextMeshProUGUI LevelText;
    private int nivelAnterior = 1;
    private int nivel = 1;
    void Start()
    {
        print("nivel" + nivel);
        //Instantiate(EnemmyPrefab,transform.position, Quaternion.identity);
        StartCoroutine(ShowLevel());
        StartCoroutine(NormalLevel());
    }

    // Update is called once per frame
    void Update()
    {
        if (nivel != nivelAnterior)
        {
            nivelAnterior++;
            StartCoroutine(ShowLevel());
            StartCoroutine(NormalLevel());
            
        }

    }
    IEnumerator NormalLevel()
    {
        
        yield return new WaitForSeconds(2f);
        for (int i = 0; i<5; i++)
        {
            InvokeRepeating("Spawn", 0, 0.25f); //se van invocando cada 0.25 hasta que son 5
            yield return new WaitForSeconds(1.25f);
            CancelInvoke("Spawn");
            yield return new WaitForSeconds(4);
        }
        nivel++;
        
        
    }
    public void Spawn()
    {
        Vector3 RandomPlace = new Vector3(transform.position.x, Random.Range(-4.5f, 4.5f), 0);
        if(nivel == 1)
        {
            Instantiate(EnemmyPrefab, RandomPlace, Quaternion.identity);
        }
        else if ( 1 < nivel && nivel < 4)
        {
            float SelectEnemy = Random.Range(0f,1f);
            if(SelectEnemy > 0.5f) 
            {
                Instantiate(EnemmyPrefab2, RandomPlace, Quaternion.identity);
            }
            else
            {
                Instantiate(EnemmyPrefab, RandomPlace, Quaternion.identity);
            }
            
        }
        else if (nivel >= 4)
        {
            Instantiate(EnemmyPrefab2, RandomPlace, Quaternion.identity);
        }

    }
    IEnumerator ShowLevel()
    {
        LevelText.text = "nivel " + nivel;
        float opacidad = 1;
        for (int i = 0; i < 50; i++)
        {
            LevelText.color = new Color(1, 1, 1, opacidad);
            opacidad -= 0.02f;
            yield return new WaitForSeconds(0.1f);
        }
        LevelText.text = "";
        print("nivel " + nivel);
    }
    
}
