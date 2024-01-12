using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUpScript : MonoBehaviour
{
    [SerializeField] int lifeValue;

    public int GetLives()
    {
        return lifeValue;
    }
}
