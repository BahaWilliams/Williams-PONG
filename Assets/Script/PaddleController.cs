using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float paddalSpeed;
    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;

    Rigidbody2D paddlePhysic;

    private void Awake()
    {
        paddlePhysic = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMovement(PaddleMovement());
    }

    private void PlayerMovement(Vector2 movement)
    {
        paddlePhysic.velocity = movement;
    }

    private Vector2 PaddleMovement()
    {
        if (Input.GetKey(upKey))
            return Vector2.up * paddalSpeed;

        if (Input.GetKey(downKey))
            return Vector2.down * paddalSpeed;

        return Vector2.zero;
    }
}
