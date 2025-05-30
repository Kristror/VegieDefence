﻿using System.Collections;
using UnityEngine;

namespace Assets.Code.Attack
{
    public class ArealBullet : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(SelfDestruct());
        }

        IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }
    }
}