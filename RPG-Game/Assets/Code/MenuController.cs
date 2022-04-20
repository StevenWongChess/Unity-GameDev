using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;
    
    // Outlets
    public GameObject mainMenu;
    public GameObject levelMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Awake()
    {
        instance = this;
        Hide();
    }
    
    public void Show()
    {
        ShowMainMenu();
        gameObject.SetActive(true);
        Time.timeScale = 0;
        Hero.instance.isPaused = true;
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        if (Hero.instance != null)
        {
            Hero.instance.isPaused = false;
        }
    }
    
    void SwitchMenu(GameObject someMenu)
    {
        // Turn off all menus
        mainMenu.SetActive(false);
        levelMenu.SetActive(false);
        
        // Turn on requested menu
        someMenu.SetActive(true);
    }
    
    public void ShowMainMenu()
    {
        SwitchMenu(mainMenu);
    }
    
    public void ShowLevelMenu()
    {
        SwitchMenu(levelMenu);
    }
    
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void RestartLevel()
    {
        GameController.instance.hp = PlayerPrefs.GetInt("HP", 10);
        GameController.instance.attack = PlayerPrefs.GetInt("Attack", 10);
        GameController.instance.defense = PlayerPrefs.GetInt("Defense", 0);
        GameController.instance.coin = PlayerPrefs.GetInt("Coin", 0);
        
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void ResetGame()
    {
        PlayerPrefs.SetInt("HP", 10);
        PlayerPrefs.SetInt("Attack", 10);
        PlayerPrefs.SetInt("Defense", 0);
        PlayerPrefs.SetInt("Coin", 0);
        PlayerPrefs.SetInt("CurrentLevel", 0);

        GameController.instance.hp = 10;
        GameController.instance.attack = 10;
        GameController.instance.defense = 0;
        GameController.instance.coin = 0;    
        SceneManager.LoadScene("Level0");
    }
}
