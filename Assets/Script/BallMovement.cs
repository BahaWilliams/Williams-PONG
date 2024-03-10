using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float ballSpeed;
    [SerializeField] private Vector2 resetPosition;
    
    private float originalBallSpeed;

    private Vector2 ballDirection;
    private Rigidbody2D ballPhysics;

    private void Awake()
    {
        ballPhysics = GetComponent<Rigidbody2D>();
        originalBallSpeed = ballSpeed;
    }

    private void Start()
    {
        ResetBall();
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
        Vector2 currentDirection = ballPhysics.velocity.normalized;
        Vector2 newVelocity = currentDirection * (ballSpeed * magnitude);
        ballPhysics.velocity = newVelocity;
    }

    public void ActivedSlowedDown(float magnitude)
    {
        Vector2 currentDirection = ballPhysics.velocity.normalized;
        Vector2 newVelocity = currentDirection * (ballSpeed / magnitude);
        ballPhysics.velocity = newVelocity;
    }
}
