using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

namespace Q5{
    public class GameController : MonoBehaviour{
        // just like what static is in c++
        public static GameController instance;

        // Outlets
        public Transform[] spawnPoints;
        public GameObject[] asteroidPrefebs;
        public GameObject explosionPrefab;
        public TMP_Text textScore;
        public TMP_Text textMoney;
        public TMP_Text missileSpeedUpgradeText;
        public TMP_Text bonusUpgradeText;

        // Config
        public float maxAsteroidDelay = 2f;
        public float minAsteroidDelay = 0.2f;

        // State Tracking
        public float timeElapsed;
        public float asteroidDelay;
        public int score;
        public int money;
        public float missileSpeed = 2f;
        public float bonusMultiplier = 1f;

        // Start is called before the first frame update
        void Awake(){
            instance = this;
        }

        void Start()
        {
            StartCoroutine("AsteroidSpawnTimer");

            score = 0;
            money = 0;
        }

        // Update is called once per frame
        void Update()
        {
            timeElapsed += Time.deltaTime;

            float decreaseDelayOverTime = maxAsteroidDelay - (maxAsteroidDelay - minAsteroidDelay) / 30f * timeElapsed;
            asteroidDelay = Mathf.Clamp(decreaseDelayOverTime, minAsteroidDelay, maxAsteroidDelay);

            UpdateDisplay();
            
            // for debugging
            // if(Input.GetKeyDown(KeyCode.Space)){
            //     SpawnAsteroid();
            // }
        }

        void UpdateDisplay()
        {
            textScore.text = score.ToString();
            textMoney.text = money.ToString();
        }
        public void EarnPoints(int pointAmount)
        {
            score += Mathf.RoundToInt(pointAmount * bonusMultiplier);
            money += Mathf.RoundToInt(pointAmount * bonusMultiplier);
        }

        void SpawnAsteroid(){
            // Pick random spawn point and asteroid
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject randomAsteroidPrefab = asteroidPrefebs[Random.Range(0, asteroidPrefebs.Length)];

            Instantiate(randomAsteroidPrefab, randomSpawnPoint.position, Quaternion.identity); // no rotation
        }

        IEnumerator AsteroidSpawnTimer(){
            yield return new WaitForSeconds(asteroidDelay);
            SpawnAsteroid();
            StartCoroutine("AsteroidSpawnTimer");
        }

        public void UpgradeMissileSpeed()
        {
            int cost = Mathf.RoundToInt(missileSpeed * 25);
            if (cost <= money)
            {
                money -= cost;
                missileSpeed += 1f;
                missileSpeedUpgradeText.text = "Missile Speed $" + Mathf.RoundToInt((25 * missileSpeed)).ToString();
            }
        }

        public void UpgradeBonus()
        {
            int cost = Mathf.RoundToInt(100 * bonusMultiplier);
            if(cost <= money)
            {
                money -= cost;
                bonusMultiplier += 1f;
                bonusUpgradeText.text = "Multiplier $" + Mathf.RoundToInt((100 * bonusMultiplier)).ToString();
            }
        }
    }
}

