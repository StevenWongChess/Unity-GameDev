using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Emotioner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(Time.timeSinceLevelLoad);
        //print(Math.Floor(Time.deltaTime % 2.0f));
        if (Math.Floor(Time.timeSinceLevelLoad % 2.0f) != 0.0f)
        {
            GameController.instance.hp = PlayerPrefs.GetInt("HP", 10);
            GameController.instance.attack = PlayerPrefs.GetInt("Attack", 10);
            GameController.instance.defense = PlayerPrefs.GetInt("Defense", 0);
            GameController.instance.coin = PlayerPrefs.GetInt("Coin", 0);
            Debug.Log("You've lost the game");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
