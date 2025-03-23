using Assets.Code.Player;
using Assets.Code.Score;
using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Boosters
{
    public class Booster : BoosterBase
    {
        BoosterTypeEnum type;

        PlayerStatsController playerStatsController;
        ScoreController scoreController;

        Action ShootingSpeedUp;

        private void Start()
        {
            scoreController = GameObject.Find("MainObject").GetComponent<ScoreController>();
        }

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

        private void Heal()
        {
            int healAmount = 50;
            playerStatsController.Heal(healAmount);
        }
        private void ShootingSpeedUP()
        {
            ShootingSpeedUp.Invoke();
        }
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