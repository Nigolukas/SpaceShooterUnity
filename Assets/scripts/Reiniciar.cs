using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void StartGame(string scene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
        
    }

    public void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
