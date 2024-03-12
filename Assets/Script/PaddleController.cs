using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public static PaddleController Instance;

    [SerializeField] private float paddalSpeed;
    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;

    private float timer = 5;
    private Rigidbody2D paddlePhysic;
    private bool isHitPowerUp = false;
    private bool isHitSpeedUp = false;
    private bool isHitSlowedDown = false;
    private Vector2 originalSize;
    private float yScaleIncreaseFactor = 1.5f;
    private float normalSpeed;
    private float speedIncreaseFactor;
    private float speedDecreaseFactor;

    private void Awake()
    {
        originalSize = transform.localScale;
        Instance = this;
        paddlePhysic = GetComponent<Rigidbody2D>();
        normalSpeed = paddalSpeed;
    }

    void Update()
    {
        PlayerMovement(PaddleMovement());
        
        if (isHitPowerUp)
        {
            PowerUpTimer();
        }
    }

    private void PlayerMovement(Vector2 movement)
    {
        paddlePhysic.velocity = movement;
    }

    private void PowerUpTimer()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            transform.localScale = originalSize;
            paddalSpeed = normalSpeed; 
            isHitPowerUp = false;
            isHitSpeedUp = false;
            isHitSlowedDown = false;
            timer = 5f;
        }
    }

    private Vector2 PaddleMovement()
    {
        if (Input.GetKey(upKey))
        {
            if (isHitPowerUp)
            {
                if (isHitSpeedUp)
                    return Vector2.up * paddalSpeed * speedIncreaseFactor;
                else if (isHitSlowedDown)
                    return Vector2.up * paddalSpeed / speedDecreaseFactor;
                else
                    return Vector2.up * paddalSpeed;
            }

            else
                return Vector2.up * paddalSpeed;

        }

        if (Input.GetKey(downKey))
        {
            if (isHitPowerUp)
            {
                if (isHitSpeedUp)
                    return Vector2.down * paddalSpeed * speedIncreaseFactor;
                else if (isHitSlowedDown)
                    return Vector2.down * paddalSpeed / speedDecreaseFactor;
                else
                    return Vector2.down * paddalSpeed;
            }

            else
                return Vector2.down * paddalSpeed;
        }

        return Vector2.zero;
    }


    public void ActivedExtendPaddle(float magnitude)
    {
        Vector2 newScale = transform.localScale;
        newScale.y *= yScaleIncreaseFactor * magnitude;
        transform.localScale = newScale;
        isHitPowerUp = true;
    }

    public void ActivedIncreasePaddleSpeed(float magnitude)
    {
        isHitPowerUp = true;
        isHitSpeedUp = true;
        speedIncreaseFactor = magnitude;
    }

    public void ActivedSlowedPaddleSpeed(float magnitude)
    {
        isHitPowerUp = true;
        isHitSlowedDown = true;
        speedDecreaseFactor = magnitude;
    }
}
