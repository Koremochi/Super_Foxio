using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickUp : MonoBehaviour
{
    [SerializeField] int gemValue;

    public int GetGem()
    {
        return gemValue;
    }
}
