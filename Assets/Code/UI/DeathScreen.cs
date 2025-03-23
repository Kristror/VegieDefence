using Assets.Code.Score;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class DeathScreen : MonoBehaviour
    {
        [SerializeField] Button backToMenuButton; 
        [SerializeField] Button reviveButton;
        [SerializeField] TextMeshProUGUI scoreText;
        [SerializeField] TextMeshProUGUI bestcoreText;

        [SerializeField] RecordController recordController;
        [SerializeField] ScoreController scoreController;

        public Action PlayerRevive;

        public Action ShowInGameUI;

        private void Start()
        {
            backToMenuButton.onClick.AddListener(BackToMenu);
            reviveButton.onClick.AddListener(Revive);
        }

        public void PlayerDeath(Action ShowInGameUI)
        {
            this.gameObject.SetActive(true);
            this.ShowInGameUI = ShowInGameUI;

            long score = scoreController.PlayerScore;

            recordController.UpdateScore(score);
            scoreText.text = "Score: " + score.ToString();
            bestcoreText.text = "Best score: " + recordController.BestScore;
        }
                    
        private void BackToMenu()
        {
            Time.timeScale = 1;
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        private void Revive()
        {
            ShowInGameUI?.Invoke();
            this.gameObject.SetActive(false);
            PlayerRevive?.Invoke();
            Time.timeScale = 1;
        }
    }
}