using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int enemiesKilled = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Animator animator;
    
    void Update()
    {
        scoreText.text = $"Score: {score}";

        if (Input.GetKeyDown(KeyCode.KeypadEnter)) score += 10;

        if (Input.GetKeyDown(KeyCode.Space)) Attack();
        
    }

    private void Attack()
    {
        animator.Play("SwipeAttack");
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
