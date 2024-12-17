using System.Collections;
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

        private void Start()
        {
            backToMenuButton.onClick.AddListener(BackToMenu);
            reviveButton.onClick.AddListener(Revive);
        }

        public void PlayerDeath(string score)
        {
            scoreText.text = score;
        }
                    
        private void BackToMenu()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        private void Revive()
        {
            //Показать рекламу
            //вернуть игроку половину здоровья 
            //продолжить игру

        }
    }
}