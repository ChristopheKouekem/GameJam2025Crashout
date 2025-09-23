using UnityEngine;
using TMPro; // Falls du TextMeshPro benutzt

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private int score = 0;

    public TMP_Text scoreText; // Im Inspector zuweisen

    void Awake()
    {
        Instance = this;
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public int GetScore()
    {
        return score;
    }
}
