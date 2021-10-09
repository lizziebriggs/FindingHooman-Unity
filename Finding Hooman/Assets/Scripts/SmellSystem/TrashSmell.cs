using Player;
using UnityEngine;

namespace SmellSystem
{
    public class TrashSmell : Smellable
    {
        [Header("Trash Values")]
        [SerializeField] private float distractionTime;
        [SerializeField] private GameObject testTrashOverlay;

        private bool distractionActive;
        private float timer;

        private void Start()
        {
            distractionActive = false;
            timer = 0f;
            testTrashOverlay.SetActive(false);
        }

        private void Update()
        {
            if (!distractionActive) return;

            if (timer >= distractionTime)
            {
                distractionActive = false;
                timer = 0f;
                testTrashOverlay.SetActive(false);
                moodController.PlayerMood = PlayerMoodController.Mood.Sad;
                return;
            }
            
            timer += Time.deltaTime;
        }

        private void OnTriggerStay(Collider other)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("This is trash");

                SetMood();

                distractionActive = true;
                testTrashOverlay.SetActive(true);
            }
        }
    }
}
