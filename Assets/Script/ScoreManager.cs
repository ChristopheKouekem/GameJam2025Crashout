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
        if (score >= 10 && score <= 15)
        {
            scoreText.text = "Nice!";
        }

        if (timer >= 11 && timer <= 49)
        {
            UpdateUI();
        }

        if (score == 50)
        {
            scoreText.text = "Super Nice!";
        }

        if (score == 100)
        {
            scoreText.text = "Excellent!!";
        }

        if (score == 30)
        {
            scoreText.text = "Crazy!!";
        }

        if (score == 70)
        {
            scoreText.text = "Goat?!";
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
