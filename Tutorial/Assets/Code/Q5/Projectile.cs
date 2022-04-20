using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Q5{
    public class Projectile : MonoBehaviour
    {
        // Outlets
        Rigidbody2D rigidbody;

        // State Tracking
        Transform target;

        //Methods
        void Start(){
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void Update(){
            // Todo: Make these dynamic properties 
            float acceleration = GameController.instance.missileSpeed / 2f;
            float maxSpeed = GameController.instance.missileSpeed;

            // Home in on target
            ChooseNearestTarget();
            if(target != null){
                Vector2 directionToTarget = target.position - transform.position;
                float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
                rigidbody.MoveRotation(angle);
            }

            // Acceleration
            rigidbody.AddForce(transform.right * acceleration);

            // Cap max speed
            rigidbody.velocity = Vector2.ClampMagnitude(rigidbody.velocity, maxSpeed);
        }

        void ChooseNearestTarget(){
            Asteroid[] asteroids = FindObjectsOfType<Asteroid>(); // Expensive Function
            float closestDistance = 9999f;
            for(int i = 0; i < asteroids.Length; i++){
                Asteroid asteroid = asteroids[i];
                // Asteroid must be to our right hand side
                if(asteroid.transform.position.x > transform.position.x){
                    Vector2 directionToTarget = asteroid.transform.position - transform.position;
                    // float distance = distanceToTarget.magnitude;
                    float squareDistance = directionToTarget.sqrMagnitude;

                    // filter for the closest target to
                    if(squareDistance < closestDistance){
                        closestDistance = squareDistance;
                        target = asteroid.transform;
                    }
                }
            }
        }

        void OnCollisionEnter2D(Collision2D other){
            if(other.gameObject.GetComponent<Asteroid>()){
                Destroy(other.gameObject);
                Destroy(gameObject);

                GameObject explosion = Instantiate(GameController.instance.explosionPrefab, transform.position, Quaternion.identity);
                Destroy(explosion, 0.25f);
                
                GameController.instance.EarnPoints((10));
            }
        }
    }
}

