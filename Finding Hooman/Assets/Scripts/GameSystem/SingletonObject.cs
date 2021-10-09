using System;
using UnityEngine;

namespace GameSystem
{
    public class SingletonObject : MonoBehaviour
    {
        private static SingletonObject instance;
        public static SingletonObject Instance => instance;

        private void Awake()
        {
            if (!instance && instance != this)
                Destroy(gameObject);

            else instance = this;
        }
    }
}
