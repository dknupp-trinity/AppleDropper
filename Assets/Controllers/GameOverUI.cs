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
    public void Restart()
    {
        Hide();

        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Resume time so scene reload isn't paused
        Time.timeScale = 1f;

        SceneManager.LoadScene(sceneIndex);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
    }
}
