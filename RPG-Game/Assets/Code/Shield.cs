using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int value;

    void Start()
    {
        value = 1;
    }

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hello"+value.ToString());
        if (other.gameObject.GetComponent<Hero>())
        {
            GameController.instance.defense += value;
            Destroy(this.gameObject);
        }
    }
}
