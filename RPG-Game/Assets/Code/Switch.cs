using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public (float, float)[] all_positions;
    public int ith;
    public SwitchDoor door1;
    public SwitchDoor door2;
    public SwitchDoor door3;
    public SwitchDoor door4;
    public int door1_pos;
    public int door2_pos;
    public int door3_pos;

    private void Start()
    {
        door1_pos = 0;
        door2_pos = 0;
        door3_pos = 0;
        all_positions = new (float, float)[]
        {
            // door1
            (3.5f, -2.5f),
            (0.5f, -3.5f),
            // door2
            (-3.5f, -2.5f),
            (-0.5f, -1.5f),
            // door3
            (-3.5f, 1.5f),
            (0.5f, 1.5f)
        };
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (ith == 1)
        {
            door1_pos++;
            door1_pos %= 2;
            door1.transform.position =
                new Vector3(all_positions[door1_pos].Item1, all_positions[door1_pos].Item2, 0);
        }
        else if (ith == 2)
        {
            door2_pos++;
            door2_pos %= 2;
            door2.transform.position = new Vector3(all_positions[2 + door2_pos].Item1,
                all_positions[2 + door2_pos].Item2, 0);
        }
        else if (ith == 3)
        {
            door3_pos++;
            door3_pos %= 2;
            door3.transform.position = new Vector3(all_positions[4 + door3_pos].Item1,
                all_positions[4 + door3_pos].Item2, 0);
        }
        else
        {
            door4.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
