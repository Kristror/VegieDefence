using Assets.Code.PlayerUpgrades;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Code.Player
{
    public class PlayerController 
    {
        private ClassesEnum playerClass;

        public  PlayerStatsController  playerStatsController;
        private PlayerMovement playerMovment;
        private PlayerShooting playerShooting;
        private PlayerSpriteController playerSpriteController;
        private ClassesSpecialAbilities classesSpecialAbilities;


        public PlayerController(GameObject playerPrefab, PlayerStats playerStats, ClassesEnum playerClass,UpgradeController upgradeController)
        {
            GameObject playerObject = GameObject.Instantiate(playerPrefab);

            playerStatsController = playerObject.GetComponent<PlayerStatsController>();
            playerMovment = playerObject.GetComponent<PlayerMovement>();
            playerShooting = playerObject.GetComponent<PlayerShooting>();
            playerSpriteController = playerObject.GetComponent<PlayerSpriteController>();
            classesSpecialAbilities = playerObject.GetComponent<ClassesSpecialAbilities>();

            playerStatsController.SetClass(playerClass);
            playerSpriteController.SetPlayerSprite(playerClass);
            classesSpecialAbilities.Activate(playerClass, upgradeController);
        }

        public void FrameUpdate() 
        {
            playerMovment.FrameUpdate();
            playerShooting.FrameUpdate();
            classesSpecialAbilities .FrameUpdate();
        }  
    }
}