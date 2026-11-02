using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    
    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Cierra el juego (funciona cuando el juego está exportado)
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }
}