using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;

    Transform currentEnemyDestination;
    SpriteRenderer enemySpriteRenderer;
    Rigidbody2D enemyRB;
    [SerializeField] float enemySpeed;
    [SerializeField] float pointDetectionRange;

    private void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
        currentEnemyDestination = pointA;
    }

    private void Update()
    {
        if(currentEnemyDestination == pointB)
        {
            enemyRB.velocity = new Vector2(enemySpeed, 0);
        }

        else
        {
            enemyRB.velocity = new Vector2(-enemySpeed, 0);
        }

        if(Vector2.Distance(transform.position, currentEnemyDestination.position) < pointDetectionRange)
        {
            if (currentEnemyDestination == pointB)
            {
                Flip();
                currentEnemyDestination = pointA;
            }

            else if (currentEnemyDestination == pointA)
            {
                Flip();
                currentEnemyDestination = pointB;
            }
        }
    }

    void Flip()
    {
        enemySpriteRenderer.flipX = !enemySpriteRenderer.flipX;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("DeathZone"))
        {
            gameObject.SetActive(false);
        }
    }
}
