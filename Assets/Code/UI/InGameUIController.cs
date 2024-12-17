using UnityEditor;
using UnityEngine;

namespace Assets.Code.UI
{
    public class InGameUIController : MonoBehaviour
    {
        [SerializeField] DeathScreen deathScreen;

        public void PlayerDeath()
        {
            deathScreen.PlayerDeath("0");
        }
    }
}