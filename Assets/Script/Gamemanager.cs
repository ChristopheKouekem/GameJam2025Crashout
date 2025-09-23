using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool IsRunning { get; private set; } = true;
    public float gameSpeed = 1f;
    public float speedIncreaseRate = 0.1f; // Wie schnell das Spiel schneller wird
    public float speedIncreaseInterval = 10f;

    private float timer = 0f;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Update()
    {
        if (!IsRunning) return;

        timer += Time.deltaTime;
        if (timer >= speedIncreaseInterval)
        {
            gameSpeed += speedIncreaseRate;
            timer = 0f;
        }
    }

    public void GameOver()
    {
        IsRunning = false;
        Debug.Log("GAME OVER! Final Score: " + ScoreManager.Instance.GetScore());
        // Hier könntest du noch eine Restart- oder GameOver-UI triggern
    }
}
