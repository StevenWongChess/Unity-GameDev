using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treasure : MonoBehaviour
{
    [SerializeField] private KeyType keyType;
    public enum KeyType {
        Red, Blue, Yellow
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }
}
