using UnityEngine;
using TMPro;
using System.Threading; // Falls du TextMeshPro benutzt

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int score = 0;
    public int timer = 0;

    public TMP_Text scoreText; // Im Inspector zuweisen

    void Awake()
    {
        Instance = this;
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
        if (score >= 10)
        {
            scoreText.text = "Nice!";
        }

        if (timer == 11)
        {
            UpdateUI();
        }

    }


    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
            timer++;
        }
    }

    public int GetScore()
    {
        return score;
    }
}
