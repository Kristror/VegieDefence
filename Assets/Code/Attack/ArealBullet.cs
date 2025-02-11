using System.Collections;
using UnityEngine;

namespace Assets.Code.Attack
{
    public class ArealBullet : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            this.gameObject.SetActive(false);
        }
    }
}