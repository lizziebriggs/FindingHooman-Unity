using System;
using UnityEngine;

namespace GameSystem
{
    public class SingletonObject : MonoBehaviour
    {
        private static SingletonObject Instance;

        private void Awake()
        {
            // Enforce singleton
            if (!Instance)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);
        }
    }
}
