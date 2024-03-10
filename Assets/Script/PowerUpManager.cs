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
    private float timer;

    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > spawnInterval)
        {
            GeneratePowerUp();
            timer -= spawnInterval;
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
        GameObject powerUp = Instantiate(powerUpListTemplate[randomIndex], position, Quaternion.identity, spawnArea);
        powerUp.SetActive(true);
        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count < 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }
}
