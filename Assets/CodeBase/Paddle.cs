using System;
using UnityEngine;

namespace CodeBase
{
    public class Paddle : MonoBehaviour
    {
        private Rigidbody2D Rb { get; set; }
        public Vector2 direction;
        public float Speed;
        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                direction = Vector2.left;
            }
            else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                direction = Vector2.right;
            }
            else 
                direction = Vector2.zero;
            
        }

        private void FixedUpdate() {
            if (direction != Vector2.zero)
            {
                Rb.AddForce(direction * Speed);

            }
        }
    }
}