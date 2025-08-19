using Assets.Code.UI;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Player
{
    /// <summary>
    /// Отвечает за проведение атаки по области вокруг игрока
    /// </summary>
    public class ArealAttack : MonoBehaviour
    {
        [SerializeField] private GameObject arealBullet;
        

        public void Start()
        {
            GameObject.Find("UI").GetComponentInChildren<DeathScreen>(true).PlayerRevive += Attack;
        }
        public void Attack()
        {
            GameObject.Instantiate(arealBullet);
        }
    }
}