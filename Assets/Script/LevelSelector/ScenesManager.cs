using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    private int nextSceneLoad;

    private void Start()
    {
        // Lee el nivel alcanzado o establece 1 si no hay datos guardados.
        nextSceneLoad = PlayerPrefs.GetInt("levelAt", 1);
    }

    public void levelSelectorMenu()
    {
        SceneManager.LoadScene(1);

        // Guarda el progreso si el nivel alcanzado es mayor al guardado.
        if (nextSceneLoad > PlayerPrefs.GetInt("levelAt", 1))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            PlayerPrefs.Save();
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextSceneLoad);

        // Actualiza y guarda el progreso si es necesario.
        if (nextSceneLoad > PlayerPrefs.GetInt("levelAt", 1))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            PlayerPrefs.Save();
        }
    }

    public void QuitGame()
    {
        // Asegura que los datos persistentes se guarden antes de salir.
        PlayerPrefs.Save();
        Application.Quit();
    }

    public void RestartGame()
    {
        // Reinicia la escena actual.
        int actualScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(actualScene);
    }

    public void NextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        // Pasa a la siguiente escena o reinicia si es la última.
        currentIndex = (currentIndex + 1) % totalScenes;
        SceneManager.LoadScene(currentIndex);
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
