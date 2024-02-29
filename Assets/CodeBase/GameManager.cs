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

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
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
    }
}