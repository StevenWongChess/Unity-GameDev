using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Hero : MonoBehaviour
{
    public static Hero instance;
    public Transform movePoint;

    public LayerMask stopsMovement;
    public LayerMask doorLayer;

    //public GameObject finishLine;
    // Start is called before the first frame update

    public float moveSpeed = 5f;
    public int num_of_keys;
    public int hp;
    public int attack;
    public int defense;
    // In the future;
    // public int mp = 100;
    // Cool skills;

    public Bag heroBag;

    private static int currentLevel = 0;
    
    public bool isPaused;
    
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //num_of_keys = 0;
        //hp = 100;
        //attack = 10;
        //defense = 0;
        movePoint.parent = null;
        heroBag = GetComponent<Bag>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            MenuController.instance.Show();
        }
        
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            Vector2 targetLocation = Vector2.zero;
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                targetLocation = movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }

            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                targetLocation = movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }

            if (!targetLocation.Equals(Vector2.zero))
            {
                Collider2D[] obstacles = Physics2D.OverlapCircleAll(targetLocation, 0.01f, doorLayer);
/*                if (!doorLayerObstacle)
                {
                    Debug.Log("not created");
                }*/
                Collider2D doorLayerObstacle = null;
                foreach (Collider2D obstacle in obstacles)
                {
                    if (obstacle && obstacle.gameObject.GetComponent<Door>())
                    {
                        doorLayerObstacle = obstacle;
                        break;
                    }
                }
                if(doorLayerObstacle)
                {
                    Debug.Log(doorLayerObstacle.gameObject.name);
                    Debug.Log("middle");
                    Door door = doorLayerObstacle.gameObject.GetComponent<Door>();
                    if (!door)
                    {
                        Debug.Log("door is null");
                    }
                    if (!heroBag)
                    {
                        Debug.Log("herobag is null");
                    }
                    if (door && heroBag.ContainsKey(door.GetKeyType()))
                    {
                        Debug.Log("inside");
                        movePoint.position = targetLocation;
                    }
                }
                else if (!Physics2D.OverlapCircle(targetLocation,0.2f, stopsMovement))
                {
                    //movePoint.Translate(Vector3.right*Time.deltaTime*Input.GetAxisRaw("Horizontal"));
                    movePoint.position = targetLocation;
                }
            }
        }
        GameController.instance.UpdateDisplay();
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Reload scence only when colliding with player
        if (other.gameObject.name == "FinishLine")
        {
            PlayerPrefs.SetInt("HP", GameController.instance.hp);
            PlayerPrefs.SetInt("Attack", GameController.instance.attack);
            PlayerPrefs.SetInt("Defense", GameController.instance.defense);
            PlayerPrefs.SetInt("Coin", GameController.instance.coin);
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);
            
            currentLevel++;

            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // print("Level" + currentLevel.ToString());
            string curr = SceneManager.GetActiveScene().name;
            int next = Int32.Parse(curr.Substring(curr.Length - 1, 1));
            next++;
            /* testing
            */
            SceneManager.LoadScene("Level" + next.ToString());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            GameController.instance.coin += 10;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.GetComponent<RedRuby>())
        {
            GameController.instance.hp = 10;
        }
    }
}
