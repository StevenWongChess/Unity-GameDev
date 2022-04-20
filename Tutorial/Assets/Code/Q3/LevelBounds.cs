using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Q3 {
    public class LevelBounds : MonoBehaviour
    {
        // private void OnCollisionEnter2D(Collision2D other) {
        //     print("OnCollision with: " + other.gameObject.name); 
        // }
        private void OnTriggerEnter2D(Collider2D other) {
            // print("OnTrigger with: " + other.name);
            if (other.GetComponent<PlayerController>()) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}














