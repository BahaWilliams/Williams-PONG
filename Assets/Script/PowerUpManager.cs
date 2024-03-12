using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private int maxPowerUpAmount;
    [SerializeField] private List<GameObject> powerUpListTemplate = new List<GameObject>();
    [SerializeField] private Vector2 powerUpMinArea;
    [SerializeField] private Vector2 powerUpMaxArea;
    [SerializeField] private Transform spawnArea;
    [SerializeField] private int spawnInterval;

    private List<GameObject> powerUpList;
    private float spawnTimer;
    private float powerUpLifeTime = 10f;
    private bool isRemoving = false;
    private GameObject powerUp;
    private int powerUpIndexToRemove = 0;

    private void Start()
    {
        powerUpList = new List<GameObject>();
        spawnTimer = 0;
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnInterval)
        {
            GeneratePowerUp();
            spawnTimer -= spawnInterval;
            isRemoving = true;
        }

        if (isRemoving)
        {
            RemovePowerUpFromList();
        }
    }

    private void RemovePowerUpFromList()
    {
        powerUpLifeTime -= Time.deltaTime;

        if (powerUpLifeTime <= 0 && powerUpIndexToRemove < powerUpList.Count)
        {
            GameObject powerUpToRemove = powerUpList[powerUpIndexToRemove];

            if (powerUpToRemove != null)
            {
                powerUpList.RemoveAt(powerUpIndexToRemove);
                Destroy(powerUpToRemove);
            }

            powerUpIndexToRemove++;
            powerUpLifeTime = 7f;
        }

        if (powerUpIndexToRemove >= powerUpList.Count)
        {
            powerUpIndexToRemove = 0;
            isRemoving = false;
        }
    }


    public void GeneratePowerUp()
    {
        GeneratePowerUp(new Vector2(Random.Range(powerUpMinArea.x, powerUpMaxArea.x), Random.Range(powerUpMinArea.y, powerUpMaxArea.y)));
    }

    public void GeneratePowerUp(Vector2 position)
    {
        if(powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }

        if(position.x < powerUpMinArea.x || position.x > powerUpMaxArea.x || position.y < powerUpMinArea.y || position.y > powerUpMaxArea.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpListTemplate.Count);
        powerUp = Instantiate(powerUpListTemplate[randomIndex], position, Quaternion.identity, spawnArea);
        powerUp.SetActive(true);
        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    //Safety Removes
    /*public void RemoveAllPowerUp()
    {
        while (powerUpList.Count < 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }*/
}
