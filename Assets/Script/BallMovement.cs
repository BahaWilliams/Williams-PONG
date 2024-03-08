using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float ballSpeed;
    [SerializeField] private Vector2 resetPosition;

    Vector2 ballDirection;
    Rigidbody2D ballPhysics;

    private void Awake()
    {
        ballPhysics = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        float randomY = Random.Range(-4f, 4f);
        ballDirection = new Vector2(ballSpeed, randomY);
        ballPhysics.velocity = ballDirection;
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
    }
}
