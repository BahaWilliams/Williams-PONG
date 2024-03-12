using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float ballSpeed;
    [SerializeField] private Vector2 resetPosition;
    
    public float originalBallSpeed;
    private Vector2 ballDirection;
    private Rigidbody2D ballPhysics;
    private float timer = 2;
    private bool isHitPowerUp = false;

    private void Awake()
    {
        ballPhysics = GetComponent<Rigidbody2D>();
        originalBallSpeed = ballSpeed;
    }

    private void Start()
    {
        ResetBall();
    }

    private void Update()
    {
        if (isHitPowerUp)
        {
            PowerUpTimer();
        }
    }

    private void PowerUpTimer()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            ballSpeed = originalBallSpeed;
            isHitPowerUp = false;
            timer = 5f;
        }
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
        float randomDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        ballDirection = new Vector2(ballSpeed * randomDirection, Random.Range(-4f, 4f));
        ballPhysics.velocity = ballDirection;
    }

    public void ActivateSpeedUp(float magnitude)
    {
        ballSpeed *= magnitude;
        isHitPowerUp = true;
    }

    public void ActivedSlowedDown(float magnitude)
    {
        ballSpeed /= magnitude;
        isHitPowerUp = true;
    }
}
