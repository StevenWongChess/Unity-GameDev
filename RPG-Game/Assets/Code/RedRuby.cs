using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRuby : MonoBehaviour
{
    public int value;

    private void Start()
    {
        value = 10;
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hello");
        if (other.gameObject.GetComponent<Hero>())
        {
            other.gameObject.GetComponent<Hero>().hp += value;
            Destroy(this.gameObject);
        }
    }
}
