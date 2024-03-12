using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpPaddleController : MonoBehaviour
{
    [SerializeField] private Collider2D ball;
    [SerializeField] private GameObject leftPaddleController;
    [SerializeField] private GameObject rightPaddleController;
    [SerializeField] private float increasePaddleSpeed;
    [SerializeField] private PowerUpManager PowerUpManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            leftPaddleController.GetComponent<PaddleController>().ActivedIncreasePaddleSpeed(increasePaddleSpeed);
            rightPaddleController.GetComponent<PaddleController>().ActivedIncreasePaddleSpeed(increasePaddleSpeed);
            PowerUpManager.RemovePowerUp(gameObject);
        }
    }
}
