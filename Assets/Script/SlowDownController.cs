using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownController : MonoBehaviour
{
    [SerializeField] private Collider2D ball;
    [SerializeField] private BallMovement BallMovement;
    [SerializeField] private float decreaseSpeed;
    [SerializeField] private PowerUpManager PowerUpManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            BallMovement.ActivedSlowedDown(decreaseSpeed);
            PowerUpManager.RemovePowerUp(gameObject);
        }
    }
}
