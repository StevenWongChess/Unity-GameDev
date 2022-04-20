using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goblin : MonoBehaviour
{

    public Vector3 step;
    private float timer = 0;
    private float flag = 0;
    public int hp;
    public int attack;
    public int defense;

    // special effects and ideas here

    // Start is called before the first frame update
    void Start()
    {
        hp = 15;
        attack = 3;
        defense = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Update timer
        timer += Time.deltaTime;
        if (timer > 2)
        {
            // Make Goblin move left and right alternately
            if (flag % 2 == 0)
            {
                step = new Vector3(-1f, 0, 0);
                flag++;
            }else
            {
                step = new Vector3(1f, 0, 0);
                flag--;
            }
            timer = 0;
        }
        transform.position += step * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Hero>())
        {
            int damage_out = this.attack - GameController.instance.defense;
            int damage_in = GameController.instance.attack - this.defense;
            this.hp -= Mathf.Max(damage_in, 0);
            while (this.hp > 0)
            {
                GameController.instance.hp -= Mathf.Max(damage_out, 0);
                this.hp -= Mathf.Max(damage_in, 0);
                if (GameController.instance.hp <= 0)
                {
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
}
