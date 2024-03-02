using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace CodeBase
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int score;
        [SerializeField] private int lives;
        private Ball _ball;
        private Paddle _paddle;
        private Brick[] _bricks;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnLevelLoaded;
        }

        private void Start()
        {
            
            NewGame();
        }

        private void NewGame()
        {
            score = 0;
            lives = 3;
            LoadLevel(1);
        }

        public void LoadLevel(int level)
        {
            SceneManager.LoadScene("Level" + level);
        }

        public void Hit(Brick brick) {
            score += brick.Points;
        }

        public void Miss() {
            lives--;
            if (lives>0) {
                ResetLevel();
            }
            else {
                GameOver();
            }
        }

        private void GameOver() {
            NewGame();
        }

        private void ResetLevel() {
            _ball.ResetBall();
            _paddle.ResetPaddle();
            for (int i = 0; i < _bricks.Length; i++) {
                _bricks[i].ResetBricks();
            }
        }

        public void OnLevelLoaded(Scene scene, LoadSceneMode loadSceneMode) {
            _ball = FindObjectOfType<Ball>();
            _paddle = FindObjectOfType<Paddle>();
            _bricks = FindObjectsOfType<Brick>();
        }
    }
}