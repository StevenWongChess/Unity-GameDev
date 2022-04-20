using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadButton : MonoBehaviour
{
    public GameObject Text;

    void Start()
    {
        Text.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            Text.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Text.SetActive(false);
    }

}
