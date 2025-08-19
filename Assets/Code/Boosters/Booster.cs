using Assets.Code.Player;
using Assets.Code.Score;
using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Boosters
    {/// <summary>
     /// Класс бонусов одного из 3 видов
     /// </summary>
    public class Booster : BoosterBase
    {
        BoosterTypeEnum type;

        PlayerStatsController playerStatsController;
        ScoreController scoreController;

        Action ShootingSpeedUp;
        /// <summary>
        /// Количество очков здоровья которые дает бонус
        /// </summary>
        private int healAmount = 50;

        private void Start()
        {
            scoreController = GameObject.Find("MainObject").GetComponent<ScoreController>();
        }
        /// <summary>
        /// Получает параметры на которые могут воздействовать бонусы
        /// </summary>
        /// <param name="ShootingSpeedUp">Увеличение скорости стрельбы</param>
        /// <param name="playerStatsController">Котроллер характеристик игрока</param>
        public void SetUp(Action ShootingSpeedUp, PlayerStatsController playerStatsController)
        {
            this.ShootingSpeedUp = ShootingSpeedUp;
            this.playerStatsController = playerStatsController;
        }

        public void Activate()
        {
            this.gameObject.SetActive(true);
            ChooseEfect();
        }

        /// <summary>
        /// Выбирает один из 3 возможных эффектов для бонуса
        /// </summary>
        private void ChooseEfect()
        {
            type = (BoosterTypeEnum)UnityEngine.Random.Range(0, 2);

            switch (type)
            {
                case BoosterTypeEnum.Heal: Effect = Heal; break;
                case BoosterTypeEnum.shootingSpeedUP: Effect = ShootingSpeedUP; break;
                case BoosterTypeEnum.ScoreUP: Effect = ScoreUP; break;

                default: Effect = Heal; break;
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            string tag = collision.gameObject.tag;
            if (tag.Equals("Bullet"))
            {
                Effect.Invoke();
                Deactivate();
            }
        }
        /// <summary>
        /// Лечение игрока
        /// </summary>
        private void Heal()
        {
            playerStatsController.Heal(healAmount);
        }
         /// <summary>
         /// Временное увеличение скорости стрельбы
         /// </summary>
        private void ShootingSpeedUP()
        {
            ShootingSpeedUp.Invoke();
        }
        /// <summary>
        /// Дает бонусные очки к финальному счету игрока
        /// </summary>
        private void ScoreUP()
        {
            scoreController.Booster();
        }

        public override void Deactivate()
        {
            this.gameObject.SetActive(false);
        }
    }
}