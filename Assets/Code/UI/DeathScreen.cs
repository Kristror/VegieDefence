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

        [SerializeField] RecordController recordController;

        public static Action PlayerRevive;

        public  Action ShowInGameUI;

        private void Start()
        {
            backToMenuButton.onClick.AddListener(BackToMenu);
            reviveButton.onClick.AddListener(Revive);
        }

        public void PlayerDeath(Action ShowInGameUI)
        {
            this.gameObject.SetActive(true);
            this.ShowInGameUI = ShowInGameUI;

            long score = ScoreController.PLayerScore;
            scoreText.text = score.ToString(); ;

            recordController.UpdateScore(score);
        }
                    
        private void BackToMenu()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        private void Revive()
        {
            ShowInGameUI?.Invoke();
            this.gameObject.SetActive(false);
            Time.timeScale = 1;
            PlayerRevive?.Invoke();
        }
    }
}