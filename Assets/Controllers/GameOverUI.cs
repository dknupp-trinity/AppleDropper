using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance;

    public GameObject gameOverPanel;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void Show()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    public void Hide()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    // Called by the UI Restart button
    public void RestartMainScene()
    {
        Hide();

        //int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        int sceneIndex = 0; // Main game scene index

        // Resume time so scene reload isn't paused
        Time.timeScale = 1f;

        SceneManager.LoadScene(sceneIndex);
    }
    
    public void RestartParticleScene()
    {
        Hide();

        //int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        int sceneIndex = 1; // Particle version index

        // Resume time so scene reload isn't paused
        Time.timeScale = 1f;

        SceneManager.LoadScene(sceneIndex);
    }

    // Called by another UI button to load a different scene by name
    public void LoadSceneByName(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName)) return;
        Hide();
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    // Convenience: load by build index
    public void LoadSceneByIndex(int sceneIndex)
    {
        Hide();
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
    }
}
