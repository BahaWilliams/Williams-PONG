using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI leftScore;
    [SerializeField] private TextMeshProUGUI rightScore;
    [SerializeField] private ScoreManager scoreManager;

    private void Update()
    {
        leftScore.text = scoreManager.leftScore.ToString();
        rightScore.text = scoreManager.rightScore.ToString();
    }
}
