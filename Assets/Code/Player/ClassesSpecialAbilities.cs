using Assets.Code.PlayerUpgrades;
using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Player
{
    public class ClassesSpecialAbilities: MonoBehaviour
    {
        
        [SerializeField] PlayerStatsController playerStatsController;
        [SerializeField] ArealAttack arealAttack;

        private Action specialAbility;

        private const float timeForAbilityReset = 5;
        private float timeOfLastActivation;


        public void Activate(ClassesEnum playerClass, UpgradeController upgradeController)
        {
            timeOfLastActivation = 0;

            if (playerClass == ClassesEnum.Potato) specialAbility = playerStatsController.Regen;
            if (playerClass == ClassesEnum.Onion) specialAbility = arealAttack.Attack; 
            if (playerClass == ClassesEnum.Pumpkin) upgradeController.PumpkinSpecialPoints();
        }

        public void FrameUpdate()
        {
            specialAbility?.Invoke();
        }
    }
}