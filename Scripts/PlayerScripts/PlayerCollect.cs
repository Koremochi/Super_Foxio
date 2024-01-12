using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCollect : MonoBehaviour
{
    [SerializeField] int score;

    [SerializeField] string gemTag;
    [SerializeField] string lifeTag;
    [SerializeField] string finishTag;
    [SerializeField] Image winGameImage;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip gemTagAudio;
    [SerializeField] AudioClip lifeTagAudio;

    public delegate void OnScoreChange(int score);
    public OnScoreChange scoreChangeCallback;

    void Start()
    {
        if(scoreChangeCallback != null)
        {
            scoreChangeCallback.Invoke(score);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(gemTag))
        {
            score += collision.GetComponent<GemPickUp>().GetGem();

            if (scoreChangeCallback != null)
            {
                scoreChangeCallback.Invoke(score);
            }

            audioSource.PlayOneShot(gemTagAudio, 1f);
            collision.gameObject.SetActive(false);
        }

        else if(collision.CompareTag(lifeTag))
        {
            if(!GetComponent<PlayerHealth>().MaxLifeCountCheck())
            {
                GetComponent<PlayerHealth>().AddLifeCount(collision.GetComponent<LifeUpScript>().GetLives());
                audioSource.PlayOneShot(lifeTagAudio, 1f);
                collision.gameObject.SetActive(false);
            }
        }

        else if(collision.CompareTag(finishTag))
        {
            winGameImage.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
