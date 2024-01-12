using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticParallaxEffect : MonoBehaviour
{
    [SerializeField] float speed;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
