using System;
using UnityEngine;

namespace CodeBase
{
    public class Paddle : MonoBehaviour
    {
        public Rigidbody2D Rb { get; private set; }
        public Vector2 direction;

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
            }else 
                direction = Vector2.zero;
            
        }
    }
}