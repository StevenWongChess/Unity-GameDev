using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class JumpController : MonoBehaviour
{
    public static JumpController instance;
    public (float, float)[] all_positions;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        all_positions = new (float, float)[]
        {
            (3.5f, -4.5f),
            (-5.5f, 2.5f),
            (7.5f, 0.5f),
            (5.5f, 2.5f),
            (-2.5f, -4.5f),
            (6.5f, -2.5f),
            (2.5f, -0.5f),
            (-6.5f, 0.5f),
            (1.5f, 3.5f),
            (-1.5f, 0.5f),
            (-5.5f, -2.5f)
        };
    }
    
   public Vector3 jump_to(int in_to)
    {
        int v = in_to - 1;            
        Vector3 tmp = new Vector3(all_positions[v].Item1, all_positions[v].Item2, 0);
        return tmp;
    }
}
