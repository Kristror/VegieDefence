using Assets.Code.Player;
using Assets.Code.Score;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Boosters
{
    public class Booster : BoosterBase
    {
        BoosterTypeEnum type;
        public void Activate()
        {
            this.gameObject.SetActive(true);
            ChooseEfect();
        }

        private void ChooseEfect()
        {
            type = (BoosterTypeEnum)Random.Range(0, 2);

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
            PlayerStatsController.Heal(healAmount);
        }
        private void ShootingSpeedUP()
        {
            //Уведомить контроллер, он начнет таймер
            PlayerStatsController.Booster();
        }
        private void ScoreUP()
        {
            ScoreController.Booster();
        }

        public override void Deactivate()
        {
            this.gameObject.SetActive(false);
        }
    }
}