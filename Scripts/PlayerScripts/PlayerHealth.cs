using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Image gameOverImage;
    [SerializeField] int startLives;
    [SerializeField] int maximumLives;
    int lifeCount;

    //[SerializeField] Transform respawnPosition;

    public delegate void OnLifeCountChange(int lifeCount);
    public OnLifeCountChange lifeCountChangeCallback;

    private void Start()
    {
        lifeCount = startLives;

        if (lifeCountChangeCallback != null)
        {
            lifeCountChangeCallback.Invoke(lifeCount);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("DeathZone"))
        {
            lifeCount--;
            transform.position = new Vector2(0, -1.98f);

            if (lifeCountChangeCallback != null)
            {
                lifeCountChangeCallback.Invoke(lifeCount);
            }

            if(lifeCount <= 0)
            {
                gameOverImage.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void AddLifeCount(int addLives)
    {
        lifeCount += addLives;

        if (lifeCountChangeCallback != null)
        {
            lifeCountChangeCallback.Invoke(lifeCount);
        }
    }

    public bool MaxLifeCountCheck()
    {
        if (lifeCount >= maximumLives)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
