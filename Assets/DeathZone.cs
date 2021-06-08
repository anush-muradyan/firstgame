using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class DeathZone : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            other.gameObject.SetActive(false);
        }
    }
}