using UnityEngine;
using TMPro;
using Assets.Code.Score;
using Assets.Code.Player;
using Assets.Code.PlayerUpgrades;
using Assets.Code.DangerLevels;

namespace Assets.Code.UI
{
    public class PlayerInGameUI : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI playerHPText;
        [SerializeField] private TextMeshProUGUI upgradePointsText;
        [SerializeField] private TextMeshProUGUI dangerLevelText;

        [SerializeField] private ScoreController scoreController;
        [SerializeField] private UpgradeController upgradeController;
        [SerializeField] private DangerLevelController dangerLevelController;

        private PlayerStatsController playerStatsController;

        private const string scoreString = "Score: ";
        private const string healthString = "Health: ";
        private const string upgradePointsString = "Upgrade points: ";
        private const string DangertString = "Danger: ";

        public void Activate()
        {
            this.gameObject.SetActive(true);

            playerStatsController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsController>();

            ScoreController.ScoreUpdated += UpdateScoreText;
            playerStatsController.HpUpdated += UpdatePlayerHPText;
            upgradeController.PointUpdate += UpdateUpgradePointsText;
            dangerLevelController.DangerLevelUpdated += UpdateDangerLevelText;            
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
        
        public void UpdateDangerLevelText()
        {
            dangerLevelText.text = DangertString + dangerLevelController.DangerLevel;
        }
    }
}