using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendPaddlePowerUp : MonoBehaviour
{
    [SerializeField] private Collider2D ball;
    [SerializeField] private GameObject leftPaddleController;
    [SerializeField] private GameObject rightPaddleController;
    [SerializeField] private float increasePaddleSize;
    [SerializeField] private PowerUpManager PowerUpManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            leftPaddleController.GetComponent<PaddleController>().ActivedExtendPaddle(increasePaddleSize);
            rightPaddleController.GetComponent<PaddleController>().ActivedExtendPaddle(increasePaddleSize);
            PowerUpManager.RemovePowerUp(gameObject);
        }
    }
}
