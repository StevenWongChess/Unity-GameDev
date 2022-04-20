using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject StoreCanvas;
    public GameObject Hint;

    void Start()
    {
        StoreCanvas.SetActive(false);
        if(Hint != null)
        {
            Hint.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Hero>())
        {
            StoreCanvas.SetActive(true);    
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Hero>())
        {
            StoreCanvas.SetActive(false);    
        }
    }

    public void BuyHP()
    {
        int cost = 5;
        int hp = 2;
        if (GameController.instance.coin >= cost && GameController.instance.hp < 100)
        {
            GameController.instance.coin -= cost;
            GameController.instance.hp += hp;
        }
    }
    
    public void BuyGun()
    {
        int cost = 10;
        int attack = 1;
        if (GameController.instance.coin >= cost)
        {
            GameController.instance.coin -= cost;
            GameController.instance.attack += attack;
        }
    }
    
    public void BuyShield()
    {
        int cost = 20;
        int defense = 1;
        if (GameController.instance.coin >= cost)
        {
            GameController.instance.coin -= cost;
            GameController.instance.defense += defense;
        }
    }

    public void BuyHints()
    {
        int cost = 5;
        if (GameController.instance.coin >= cost)
        {
            GameController.instance.coin -= cost;
            Hint.SetActive(true);
        }
    }
}
