using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Q5{
    public class Ship : MonoBehaviour
    {

        // Outlet
        public GameObject projectilePrefab;
        public Image imageHealthBar;
        public TMP_Text hullUpgradeText;
        public TMP_Text fireSpeedUpgradeText;

        // State Tracking
        public float firingDelay = 1f;
        public float healthMax = 100f;
        public float health = 100f;

        //Methods
        void Start()
        {
            StartCoroutine("FiringTimer");
        }

        void Update()
        {
            if (health > 0)
            {
                transform.position = new Vector2(0, Mathf.Sin(GameController.instance.timeElapsed) * 3f);
            }
        }

        void TakeDamage(float damageAmount)
        {
            health -= damageAmount;
            if (health <= 0)
            {
                Die();
            }

            imageHealthBar.fillAmount = health / healthMax;
        }

        void Die()
        {
            StopCoroutine(("FiringTimer"));
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<Asteroid>())
            {
                TakeDamage(10f);
            }
        }

        void FireProjectile()
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }

        IEnumerator FiringTimer()
        {
            yield return new WaitForSeconds(firingDelay);

            FireProjectile();

            StartCoroutine("FiringTimer");
        }

        public void RepairHull()
        {
            int cost = 100;
            if (health > 0 && health < healthMax && GameController.instance.money >= cost)
            {
                GameController.instance.money -= cost;
                health = healthMax;
                imageHealthBar.fillAmount = health / healthMax;
            }
        }

        public void UpgrageHull()
        {
            int cost = Mathf.RoundToInt((healthMax));
            if (GameController.instance.money >= cost)
            {
                GameController.instance.money -= cost;
                health += 50;
                healthMax += 50;
                imageHealthBar.fillAmount = health / healthMax;
                hullUpgradeText.text = "Hull Strength $" + Mathf.RoundToInt((healthMax)).ToString();
            }
        }

        public void UpgradeFireSpeed()
        {
            int cost = 100 + Mathf.RoundToInt((1f - firingDelay) * 100f);
            if (GameController.instance.money >= cost)
            {
                GameController.instance.money -= cost;
                firingDelay -= 0.05f;
                int newCost = 100 + Mathf.RoundToInt((1f - firingDelay) * 100f);
                fireSpeedUpgradeText.text = "Fire Speed $" + Mathf.RoundToInt((healthMax)).ToString();
            }
        }
    }
}

 