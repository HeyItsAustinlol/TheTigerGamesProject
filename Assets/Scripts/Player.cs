using System.Collections;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int enemiesKilled = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Animator animator;
    [SerializeField] GameObject swipe;
    public bool Swiping;

    void Update()
    {
        scoreText.text = $"Score: {score}";

        if (Input.GetKeyDown(KeyCode.KeypadEnter)) score += 10;

        if (Input.GetKeyDown(KeyCode.Space)) Attack();
        
    }

    private void Attack()
    {
        Movement move = GetComponent<Movement>();

        if (move.horizontal) animator.Play("SwipeHorz");
        if (move.up) animator.Play("SwipeUp");
        if (!move.horizontal && !move.up) animator.Play("SwipeDown");

        StartCoroutine(SwipeAnim());
    }

    IEnumerator SwipeAnim()
    {
        if (!Swiping)
        {
            Swiping = true;
            yield return new WaitForSeconds(0.2f);
            Swiping = false;
        }
    }

    public void DoSwipeEffect()
    {
        swipe.GetComponent<Swipe>().SwipeObjects();
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
