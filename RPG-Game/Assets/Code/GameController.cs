using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public int coin = 0;
    public int hp = 10;
    public int attack = 10;
    public int defense = 0;
    
    public TMP_Text coinText;
    public TMP_Text HPText;
    public TMP_Text attackText;
    public TMP_Text defenseText;

    GameObject[] destroyedList;

    void Start()
    {
        if(instance != null)
        {
            hp = PlayerPrefs.GetInt("HP");
            attack = PlayerPrefs.GetInt("Attack");
            defense = PlayerPrefs.GetInt("Defense");
            coin = PlayerPrefs.GetInt("Coin");
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        GameObject.DontDestroyOnLoad(GameObject.Find("Text  - Coins").GetComponent<TMP_Text>());
    }
    
    void Update()
    {
        coinText = GameObject.Find("Text  - Coins").GetComponent<TMP_Text>();
        HPText = GameObject.Find("Text  - HP").GetComponent<TMP_Text>();
        attackText = GameObject.Find("Text  - Attack").GetComponent<TMP_Text>();
        defenseText = GameObject.Find("Text  - Defense").GetComponent<TMP_Text>();
        UpdateDisplay();
    }
    
    //void Awake()
    //{
    //    instance = this;
    //}
    
    public void UpdateDisplay()
    {
        coinText.text = "Coins: " + coin.ToString();
        HPText.text = "HP: " + hp.ToString();
        attackText.text = "Attack: " + attack.ToString();
        defenseText.text = "Defense: " + defense.ToString();
    }
}
