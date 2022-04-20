using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public List<Treasure.KeyType> keyList;

    private void Awake() {
        keyList = new List<Treasure.KeyType>();
    }

    public void AddKey(Treasure.KeyType keyType) {
        Debug.Log(keyType + " is collected");
        keyList.Add(keyType);
    }
    
    public void RemoveKey(Treasure.KeyType keyType) {
        Debug.Log(keyType + " is used");
        keyList.Remove((keyType));
    }

    public bool ContainsKey(Treasure.KeyType keyType) {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Treasure treasure = col.GetComponent<Treasure>();
        if (treasure != null)
        {
            AddKey(treasure.GetKeyType());
            Destroy(treasure.gameObject);
        }

        Door door = col.GetComponent<Door>();
        if (door != null)
        {
            if (ContainsKey(door.GetKeyType()))
            {
                RemoveKey(door.GetKeyType());
                door.OpenDoor();
            }
        }

        // if(col.CompareTag(“col_judge”))
        // {
        //     Debug.Log("hello");
        // }
    }
}
