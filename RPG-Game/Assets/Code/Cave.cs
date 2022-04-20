using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave : MonoBehaviour
{
    // Start is called before the first frame update
    public int in_to;
    public Transform movePoint;

    void Start()
    {
        // movePoint.parent = null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Hero>())
        {
             movePoint.transform.position = JumpController.instance.jump_to(in_to);
             other.gameObject.transform.position = JumpController.instance.jump_to(in_to);
        }
    }   
}
