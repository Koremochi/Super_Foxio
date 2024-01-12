using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip enemySplat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(enemySplat, 1f);
            collision.gameObject.SetActive(false);
        }
    }
}
