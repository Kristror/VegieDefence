using Assets.Code.PlayerUpgrades;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.UI
{
    public class PlayerUpgradeUI : MonoBehaviour
    {
        [SerializeField] private Button maxHealthUpgradeButton;
        [SerializeField] private Button damageUpgradeButton;
        [SerializeField] private Button shotingSpeedUpgradeButton;

        [SerializeField] private UpgradeController upgradeController;

        private void Start()
        {
            maxHealthUpgradeButton.onClick.AddListener(HealthUpgrade);
            damageUpgradeButton.onClick.AddListener(DamageUpgrade);
            shotingSpeedUpgradeButton.onClick.AddListener(ShootingSpeedUpgrade);

            upgradeController.SetUpgradeUI(this);
        }

        public void Activate()
        {
            this.gameObject.SetActive(true);
        }

        private void HealthUpgrade()
        {
            upgradeController.MaxHealthUpgrade();
            Deactivate();
        }
        
        private void DamageUpgrade()
        {
            upgradeController.DamageUpgrade();
            Deactivate();
        }
        
        private void ShootingSpeedUpgrade()
        {
            upgradeController.ShootingSpeedUpgrade();
            Deactivate();
        }
        private void Deactivate()
        {
            this.gameObject.SetActive(false);
        }
    }
}