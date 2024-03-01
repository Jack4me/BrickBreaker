using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase {
    public class Ball : MonoBehaviour
    {
        private Rigidbody2D Rb { get; set; }
        public float Speed = 500; 
        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
        }

        private void Start() {
        Invoke(nameof(SetRandomTrajectory),1);
        }

        public void SetRandomTrajectory() {
            Vector2 force = Vector2.zero;
            force.x = Random.Range(-1, 1);
            force.y = -1;
            Rb.AddForce(force.normalized * Speed);    
        }
    }
}