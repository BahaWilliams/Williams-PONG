using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] public int leftScore;
    [SerializeField] public int rightScore;
    [SerializeField] private BallMovement ballMovement;
    [SerializeField] private GameObject leftWinner;
    [SerializeField] private GameObject rightWinner;
    [SerializeField] private GameObject mainMenuButton;

    private int maxScore = 1;

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

        if (leftScore >= maxScore)
        {
            PauseGame();
            leftWinner.SetActive(true);
            mainMenuButton.SetActive(true);
        }

        else if(rightScore >= maxScore)
        {
            PauseGame();
            rightWinner.SetActive(true);
            mainMenuButton.SetActive(true);
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void BackToMenu()
    {
        GameOver();
    }

    private void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
