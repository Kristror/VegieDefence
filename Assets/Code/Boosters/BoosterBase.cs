using System;
using UnityEngine;

namespace Assets.Code.Boosters
{
    public abstract class BoosterBase : MonoBehaviour
    {
        private float timeOfLife;
        private float timeStart;

        public Action Effect;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            string tag = collision.gameObject.tag;
            if (tag.Equals("Bullet"))
            {
                Effect();
            }
        }

        public void UpdateFrame()
        {
            if (timeStart - Time.time > timeOfLife) Deactivate();
        }

        public abstract void Deactivate();
    }
}