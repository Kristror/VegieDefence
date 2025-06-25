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

        private const float timeForRegenReset = 5;
        private const float timeForAttackReset = 15;
        private const float timeForPointsReset = 10;

        private float timeForAbilityReset;
        private float timeOfLastActivation;


        public void Activate(ClassesEnum playerClass, UpgradeController upgradeController)
        {
            timeOfLastActivation = 0;

            if (playerClass == ClassesEnum.Potato)
            {
                specialAbility = playerStatsController.Regen;
                timeForAbilityReset = timeForRegenReset;
            }

            if (playerClass == ClassesEnum.Onion)
            {
                specialAbility = arealAttack.Attack;
                timeForAbilityReset = timeForAttackReset;
            }
            if (playerClass == ClassesEnum.Pumpkin)
            {
                upgradeController.PumpkinSpecialPoints();
                timeForAbilityReset = timeForPointsReset;
            }
        }

        public void FrameUpdate()
        {
            if (Time.time - timeOfLastActivation >= timeForAbilityReset)
            {
                timeOfLastActivation = Time.time;
                specialAbility?.Invoke();
            }
        }
    }
}