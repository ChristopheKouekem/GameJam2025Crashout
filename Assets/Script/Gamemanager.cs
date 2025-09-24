using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool IsRunning { get; private set; } = true;
    public float fallSpeed = 1f;
    public float speedIncreaseRate = 0.1f; // Wie viel das Spiel schneller wird
    public float speedIncreaseInterval = 10f;

    private float timer = 0f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // optional
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        if (!IsRunning) return;

        timer += Time.deltaTime;
        if (timer >= speedIncreaseInterval)
        {
            fallSpeed += speedIncreaseRate;
            timer = 0f;
        }
    }

    public void GameOver()
    {
        IsRunning = false;
        Time.timeScale = 0f;
        Debug.Log("GAME OVER! Final Score: " + ScoreManager.Instance.GetScore());
        // GameOver UI noch einfügen
    }
}
