using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int hp;
    public int attack;
    public int defense;
    // Start is called before the first frame update
    void Start()
    {
        hp = 20;
        attack = 6;
        defense = 0;
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.GetComponent<Hero>()){
            int damage_out = this.attack - GameController.instance.defense;
            int damage_in = GameController.instance.attack - this.defense;
            this.hp -= Mathf.Max(damage_in, 0);
            while(this.hp > 0){
                GameController.instance.hp -= Mathf.Max(damage_out, 0);
                this.hp -= Mathf.Max(damage_in, 0);
                if(GameController.instance.hp <= 0){
                    Debug.Log(PlayerPrefs.GetInt("HP"));
                    Debug.Log(PlayerPrefs.GetInt("Attack"));
                    Debug.Log(PlayerPrefs.GetInt("Defense"));
                    Debug.Log(PlayerPrefs.GetInt("Coin"));
                    
                    GameController.instance.hp = PlayerPrefs.GetInt("HP", 10);
                    GameController.instance.attack = PlayerPrefs.GetInt("Attack", 10);
                    GameController.instance.defense = PlayerPrefs.GetInt("Defense", 0);
                    GameController.instance.coin = PlayerPrefs.GetInt("Coin", 0);
                    Debug.Log("You've lost the game");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    break;
                }
            }
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
