using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordGuard : MonoBehaviour
{
    public Vector3 step;
    private float timer = 0;
    private float flag = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update timer
        timer += Time.deltaTime;
        if (timer > 2)
        {
            // Make SwordGuard move up and down alternately
            if (flag % 2 == 0)
            {
                step = new Vector3(0, -0.5f, 0);
                flag++;
            }
            else
            {
                step = new Vector3(0, 0.5f, 0);
                flag--;
            }
            timer = 0;
        }
        transform.position += step * Time.deltaTime;
    }
}
