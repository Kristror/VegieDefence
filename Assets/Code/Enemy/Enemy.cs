using UnityEngine;

namespace Assets.Code.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float health;
        [SerializeField] private int damage;

        public void SetDamage(int newDamage)
        {
            damage = newDamage;
        }

        public void SetHp(int newHP)
        {
            health = newHP;
        }

        public void Allive()
        {
            gameObject.SetActive(true);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            string tag = collision.gameObject.tag;
            Debug.Log(tag);
            if (tag == "Bullet")
            {
                //убавить здоровье
                Death();
            }
            if(tag == "Player")
            {
                //нанести урон
                Death();
            }
        }

        void Death()
        {
            gameObject.SetActive(false);
        }
    }
}