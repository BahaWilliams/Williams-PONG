using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] public int leftScore;
    [SerializeField] public int rightScore;
    [SerializeField] private BallMovement ballMovement;

    private int maxScore = 10;

    public void AddScore(int increment, string side)
    {

        if (side == "left")
        {
            leftScore += increment;
            ballMovement.ResetBall();
        }

        else if (side == "right")
        {
            rightScore += increment;
            ballMovement.ResetBall();
        }

        if (leftScore >= maxScore || rightScore >= maxScore)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
