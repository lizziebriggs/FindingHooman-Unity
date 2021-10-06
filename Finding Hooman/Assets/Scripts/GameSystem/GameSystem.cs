using UnityEngine;

namespace GameSystem
{
    public class GameSystem : MonoBehaviour
    {
        public static GameSystem Instance;

        private void Start()
        {
            Instance = GetComponent<GameSystem>();
            DontDestroyOnLoad(this);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

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
