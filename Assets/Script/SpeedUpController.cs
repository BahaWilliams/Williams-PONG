using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpController : MonoBehaviour
{
    [SerializeField] private Collider2D ball;
    [SerializeField] private BallMovement BallMovement;
    [SerializeField] private float incraseSpeed;
    [SerializeField] private PowerUpManager PowerUpManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == ball)
        {
            BallMovement.ActivateSpeedUp(incraseSpeed);
            PowerUpManager.RemovePowerUp(gameObject);
        }
    }
}
