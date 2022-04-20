using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // private bool isOpen = false;
    [SerializeField] private Treasure.KeyType keyType;
    public Treasure.KeyType GetKeyType() {
        return keyType;
    }

    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}
