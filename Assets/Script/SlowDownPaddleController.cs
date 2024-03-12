using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownPaddleController : MonoBehaviour
{
    [SerializeField] private Collider2D ball;
    [SerializeField] private GameObject leftPaddleController;
    [SerializeField] private GameObject rightPaddleController;
    [SerializeField] private float decreasePaddleSpeed;
    [SerializeField] private PowerUpManager PowerUpManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            leftPaddleController.GetComponent<PaddleController>().ActivedSlowedPaddleSpeed(decreasePaddleSpeed);
            rightPaddleController.GetComponent<PaddleController>().ActivedSlowedPaddleSpeed(decreasePaddleSpeed);
            PowerUpManager.RemovePowerUp(gameObject);
        }
    }
}
