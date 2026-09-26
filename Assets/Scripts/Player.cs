using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public int score = 0;
    public int enemiesKilled = 0;
    public TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            score += 10;
        }
    }
    public int updateScore(int newScore)
    {
        score = newScore;
        return score;
    }
    public int addScore(int scoreAddition)
    {
        score += scoreAddition;
        return score;
    }
    public int getScore()
    {
        return score;
    }
    public int getEnemiesKilled()
    {
        return enemiesKilled;
    }
    public int updateEnemiesKilled()
    {
        enemiesKilled++;
        return enemiesKilled;
    }
}
