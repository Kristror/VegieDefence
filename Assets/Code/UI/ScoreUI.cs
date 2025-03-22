using UnityEngine;
using TMPro;
using Assets.Code.Score;

namespace Assets.Code.UI
{
    public class ScoreUI : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private ScoreController scoreController;


        private string score = "Score: ";

        public void Activate()
        {
            this.gameObject.SetActive(true);
            ScoreController.ScoreUpdated += UpdateScore;
        }

        public void UpdateScore()
        {
            scoreText.text = score + scoreController.PlayerScore;
        }
    }
}