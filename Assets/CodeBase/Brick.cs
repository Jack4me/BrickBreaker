using System;
using UnityEngine;

namespace CodeBase {
    public class Brick : MonoBehaviour {
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public Sprite[] States { get; private set; }
        [field: SerializeField] public bool Unbreakeble { get; private set; }

        [field: SerializeField] public int Points { get; private set; } = 100;

        // [SerializeField] private int _pointTest;
        //
        // public int PointTest
        // {
        //     get { return _pointTest; }
        //     
        // }
        private GameManager _gameManager;
        private SpriteRenderer _sprite;

        private void Awake() {
            _sprite = GetComponent<SpriteRenderer>();
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void Start() {
            ResetBricks();
        }

        public void ResetBricks() {
            if (!Unbreakeble) {
                Health = States.Length;
                _sprite.sprite = States[Health - 1];
            }
        }

        private void Hit() {
            if (Unbreakeble) {
                return;
            }

            Health--;
            if (Health <= 0) {
                gameObject.SetActive(false);
            }
            else {
                _sprite.sprite = States[Health - 1];
            }

            _gameManager ??= FindObjectOfType<GameManager>();
            // if (_gameManager == null) {
            //     _gameManager=   FindObjectOfType<GameManager>();
            // }

            _gameManager.Hit(this);
        }

        private void OnCollisionEnter2D(Collision2D col) {
            if (col.gameObject.GetComponent<Ball>()) {
                Hit();
            }
        }
    }
}