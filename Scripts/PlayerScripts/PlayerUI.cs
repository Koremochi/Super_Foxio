using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI lifeText;

    PlayerHealth playerLife;
    PlayerCollect playerCollect;

    private void Start()
    {
        playerLife = GetComponent<PlayerHealth>();
        playerCollect = GetComponent<PlayerCollect>();


        playerLife.lifeCountChangeCallback += LivesUpdate;
        playerCollect.scoreChangeCallback += ScoreUpdate;
    }

    void LivesUpdate(int lifeCount)
    {
        lifeText.text = lifeCount.ToString();
    }

    void ScoreUpdate(int score)
    {
        scoreText.text = score.ToString();
    }
}
