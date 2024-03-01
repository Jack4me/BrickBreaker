using System;
using UnityEngine;

namespace CodeBase {
    public class Brick : MonoBehaviour {
        public int Health;
        public SpriteRenderer Sprite;
        public Sprite[] States;
        public bool unbreakeble;
        private void Awake() {
            Sprite = GetComponent<SpriteRenderer>();
        }

        private void Start() {
            if (!unbreakeble)
            {
                Health = States.Length;
                Sprite.sprite = States[Health - 1];
            }
        }
    }
}
