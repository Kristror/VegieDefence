using UnityEngine;
using TMPro;
using Assets.Code.Score;
using Assets.Code.Player;
using Assets.Code.PlayerUpgrades;

namespace Assets.Code.UI
{
    public class PlayerInGameUI : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI playerHPText;
        [SerializeField] private TextMeshProUGUI upgradePointsText;

        [SerializeField] private ScoreController scoreController;
        [SerializeField] private UpgradeController upgradeController;

        private PlayerStatsController playerStatsController;

        private const string scoreString = "Score: ";
        private const string healthString = "Health: ";
        private const string upgradePointsString = "Upgrade points: ";

        public void Activate()
        {
            this.gameObject.SetActive(true);

            playerStatsController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsController>();

            ScoreController.ScoreUpdated += UpdateScoreText;
            playerStatsController.HpUpdated += UpdatePlayerHPText;
            upgradeController.PointUpdate += UpdateUpgradePointsText;
        }

        public void UpdateScoreText()
        {
            scoreText.text = scoreString + scoreController.PlayerScore;
        }

        public void UpdatePlayerHPText()
        {
            playerHPText.text = healthString + playerStatsController.PlayerHealth + " / " + playerStatsController.PlayerMaxHealth;
        }
        public void UpdateUpgradePointsText()
        {
            upgradePointsText.text = upgradePointsString + upgradeController.Points;
        }
    }
}