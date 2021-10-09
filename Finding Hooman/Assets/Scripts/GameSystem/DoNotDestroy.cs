using UnityEngine;

namespace GameSystem
{
    public class DoNotDestroy : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
