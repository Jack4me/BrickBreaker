using System;
using UnityEngine;

namespace CodeBase
{
    public class Paddle : MonoBehaviour
    {
        private Rigidbody2D Rb { get; set; }
        public Vector2 direction;
        public float Speed;
        private const float _maxBounceAngele = 75;

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

        private void OnCollisionEnter2D(Collision2D col) {
            Ball ball = col.gameObject.GetComponent<Ball>();
            if (ball != null)
            {
                Vector3 paddlePossition = transform.position;
                Vector2 contactPoint = col.GetContact(0).point;
                float offset = paddlePossition.x - contactPoint.x;
                float width = col.otherCollider.bounds.size.x / 2;

                float currentAngle = Vector2.SignedAngle(Vector2.up, ball.Rb.velocity);
                float bounceAngle = (offset / width) * _maxBounceAngele;
                float newAngle = Mathf.Clamp( currentAngle + bounceAngle, - _maxBounceAngele, _maxBounceAngele);
                Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
                ball.Rb.velocity = rotation * Vector3.up * ball.Rb.velocity.magnitude;
            }
        }
    }
}