using System;
using UnityEngine;

namespace CodeBase {
    public class Paddle : MonoBehaviour {
        private Rigidbody2D Rb { get; set; }
        public Vector2 direction;
        public float Speed;
        private const float MaxBounceAngele = 75;

        private void Awake() {
            Rb = GetComponent<Rigidbody2D>();
        }

        private void Update() {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
                direction = Vector2.left;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                direction = Vector2.right;
            }
            else
                direction = Vector2.zero;
        }

        private void FixedUpdate() {
            if (direction != Vector2.zero) {
                Rb.AddForce(direction * Speed);
            }
        }

        private void OnCollisionEnter2D(Collision2D ballCol) {
            Ball ball = ballCol.gameObject.GetComponent<Ball>();
            if (ball != null) {
                Vector3 paddlePossition = transform.position;
                Vector2 contactPoint = ballCol.GetContact(0).point;
                
                float offset = paddlePossition.x - contactPoint.x;
                float radiusBall = ballCol.otherCollider.bounds.size.x / 2;

                float currentAngle = Vector2.SignedAngle(Vector2.up, ball.Rb.velocity);
                float bounceAngle = (offset / radiusBall) * MaxBounceAngele;
                float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -MaxBounceAngele, MaxBounceAngele);
                Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
                Vector3 direction = rotation * Vector3.up;
                ball.Rb.velocity = direction * ball.Rb.velocity.magnitude;
            }
        }

        public void ResetPaddle() {
            transform.position = new Vector2(0, transform.position.y);
            Rb.velocity = Vector2.zero;
        }
    }
}