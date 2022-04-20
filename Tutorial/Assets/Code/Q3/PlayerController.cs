using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Q3 {
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController instance;
        
        // Outlets
        Rigidbody2D _rigidbody2D;
        public Transform aimPivot;
        public GameObject projectilePrefab;
        public int jumpsLeft = 2;
        SpriteRenderer sprite;
        Animator animator;
        public TMP_Text scoreUI;
        // Configuration
    
        // State Tracking
        public int score;
        public bool isPaused;
        
        // Methods
        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            sprite = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            score = PlayerPrefs.GetInt("Score");
        }

        private void FixedUpdate()
        {
            float speed = _rigidbody2D.velocity.magnitude;
            animator.SetFloat("Speed", speed);
            if (speed > 0)
            {
                animator.speed = speed / 3f;
            }
            else
            {
                animator.speed = 1f;
            }
        }

        void Update()
        {
            if (isPaused)
            {
                return;
            }
            // Update UI
            scoreUI.text = score.ToString();
            
            if (Input.GetKey(KeyCode.A))
            {
                _rigidbody2D.AddForce(Vector2.left * 12f * Time.deltaTime, ForceMode2D.Impulse);
                sprite.flipX = true;
            }
        
            if (Input.GetKey(KeyCode.D))
            {
                _rigidbody2D.AddForce(Vector2.right * 12f * Time.deltaTime, ForceMode2D.Impulse);
                sprite.flipX = false;
            }
            
            if(Input.GetKeyDown(KeyCode.Space)){
                if(jumpsLeft > 0){
                    jumpsLeft--;
                    _rigidbody2D.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
                }
            }
            animator.SetInteger("JumpsLeft", jumpsLeft);

            if (Input.GetKey((KeyCode.Escape)))
            {
                MenuController.instance.Show();
            }
            
            // Aim towards Mouse
            Vector3 mousePosition = Input.mousePosition;
            Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 directionFromPlayerToMouse = mousePositionInWorld - transform.position;

            float radiansToMouse = Mathf.Atan2(directionFromPlayerToMouse.y, directionFromPlayerToMouse.x);
            float angleToMouse = radiansToMouse * Mathf.Rad2Deg;

            aimPivot.rotation = Quaternion.Euler(0, 0, angleToMouse);

            if (Input.GetMouseButtonDown(0))
            {
                GameObject newProjectile = Instantiate(projectilePrefab);
                newProjectile.transform.position = transform.position;
                newProjectile.transform.rotation = aimPivot.rotation;
            }
        }   
        
        void OnCollisionStay2D(Collision2D other){
            if(other.gameObject.layer == LayerMask.NameToLayer("Ground")){
                RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, -transform.up, 0.85f);
                // Debug.DrawRay(transform.position, transform.up * 0.7f);
                for(int i = 0; i < hits.Length; i++){
                    RaycastHit2D hit = hits[i];
                    if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground")){
                        jumpsLeft = 2;
                    }
                }
            }
        }
    }
}







