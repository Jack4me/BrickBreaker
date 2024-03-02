using System;
using UnityEngine;

namespace CodeBase {
    public class Brick : MonoBehaviour {
        public int Health;
        private SpriteRenderer Sprite;
        public Sprite[] States;
        public bool unbreakeble;
        public int Points = 100;

        private void Awake() {
            Sprite = GetComponent<SpriteRenderer>();
        }

        private void Start() {
            ResetBricks();
        }

        public void ResetBricks() {
            if (!unbreakeble) {
                Health = States.Length;
                Sprite.sprite = States[Health - 1];
            }
        }

        private void Hit() {
            if (unbreakeble) {
                return;
            }

            Health--;
            if (Health <= 0) {
                gameObject.SetActive(false);
            }
            else {
                Sprite.sprite = States[Health - 1];
            }

            FindObjectOfType<GameManager>().Hit(this);
        }

        private void OnCollisionEnter2D(Collision2D col) {
            if (col.gameObject.name == "Ball") {
                Hit();
            }
        }
    }
}