using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private Collider2D ball;
    [SerializeField] private bool isRight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == ball)
        {
            if(isRight) scoreManager.AddScore(1, "left");

            else scoreManager.AddScore(1, "right");
        }
    }
}
