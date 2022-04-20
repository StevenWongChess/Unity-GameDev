using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Q2 {
    public class RotatingShipController : MonoBehaviour
    {
        // Outlets
        private Rigidbody2D _rb;

        // Configuration 
        public float speed = 100f;
        public float rotationSpeed = 100f;

        // State Tracking

        // Functions
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            // _rb.AddForce(Vector2.right * 1000f);
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _rb.AddTorque(rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                _rb.AddTorque(-rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                _rb.AddRelativeForce((Vector2.right * speed * Time.deltaTime));
            }
            
        }
    }

}
