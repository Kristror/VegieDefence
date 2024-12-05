using Assets.Code.Player;
using System;
using UnityEngine;

namespace Assets.Code.Enemy
{
    public class EnemyUnit : MonoBehaviour
    {
        [SerializeField] EnemyStats stats;
        [SerializeField] PlayerStats playerStats;


        public static Action onEnemyDeath;

        private float health;
        private int damage;

        private void Start()
        {
            SetStats();
        }

        public void Allive()
        {
            SetStats();
            gameObject.SetActive(true);
        }


        private void SetStats()
        {
            health = stats.MaxHealth;
            damage = stats.Damage;
        }
        void Death()
        {
            onEnemyDeath?.Invoke();
            gameObject.SetActive(false);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            string tag = collision.gameObject.tag;
            if (tag.Equals("Bullet"))
            {
                health -= playerStats.Damage;

                if (health <= 0)
                {
                    Death();
                }
            }
            if(tag.Equals("Player"))
            {
                collision.gameObject.GetComponent<PlayerStatsController>().Hurt(damage);
                Death();
            }
        }
    }
}