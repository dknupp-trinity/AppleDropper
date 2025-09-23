using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public int lives = 3;

    public float timeElapsed = 0f;
    public TextMeshProUGUI timeText;


    public int score = 0;
    public TextMeshProUGUI scoreText;



    public float treeSpeed = 1;
    public TextMeshProUGUI treeSpeedText;

    public float dropInterval = 1f;
    public TextMeshProUGUI dropIntervalText;

    public float gravity = 0.1f;
    public TextMeshProUGUI gravityText;

    // Game over state
    private bool isGameOver = false;


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
    }


    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        int intTime = Mathf.FloorToInt(timeElapsed);
        timeText.text = "Time: " + intTime + "s";
        treeSpeed = 1 + (intTime / 10f);


        dropInterval = Mathf.Max(0.1f, 1f - intTime * 0.01f);

        gravity = 0.1f + (intTime / 50f);
        treeSpeedText.text = "Tree Speed: " + treeSpeed.ToString("F1");
        gravityText.text = "Gravity Multiplier: " + gravity.ToString("F2");
        dropIntervalText.text = "Drop Interval: " + dropInterval.ToString("F2") + "s";
        scoreText.text = "Score: " + score;

        // Detect game over
        if (!isGameOver && lives <= 0)
        {
            GameOver();
        }
    }

    // Called when the player has no lives left
    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        if (GameOverUI.Instance != null)
        {
            GameOverUI.Instance.Show();
        }
    }

    // Reset the main game state (used after restarting the scene)
    public void ResetGame()
    {
        isGameOver = false;
        timeElapsed = 0f;
        score = 0;
        lives = 3;
        Time.timeScale = 1f;

        // Update UI if references are set
        if (timeText != null) timeText.text = "Time: 0s";
        if (scoreText != null) scoreText.text = "Score: 0";
        if (treeSpeedText != null) treeSpeedText.text = "Tree Speed: " + treeSpeed.ToString("F1");
        if (gravityText != null) gravityText.text = "Gravity Multiplier: " + gravity.ToString("F2");
        if (dropIntervalText != null) dropIntervalText.text = "Drop Interval: " + dropInterval.ToString("F2") + "s";
    }
}
