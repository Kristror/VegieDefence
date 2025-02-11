using Assets.Code.UI;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Player
{
    public class ArealAttack : MonoBehaviour
    {
        [SerializeField] private GameObject arealObject;

        public void Start()
        {
            DeathScreen.PlayerRevive += Attack;
        }
        public void Attack()
        {
            GameObject.Instantiate(arealObject);
        }
    }
}