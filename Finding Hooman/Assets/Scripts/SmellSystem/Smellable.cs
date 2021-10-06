using Player;
using UnityEngine;

namespace SmellSystem
{
    public class Smellable : MonoBehaviour
    {
        [Header("Smell Values")]
        [SerializeField] private Color colour;
        [SerializeField] private Transform direction;
        
        [Header("Mood")]
        [SerializeField] private PlayerMoodController.Mood mood;
        [SerializeField] protected PlayerMoodController moodController;

        protected void SetMood()
        {
            moodController.PlayerMood = mood;
        }

        private void OnTriggerStay(Collider other)
        {
            if (Input.GetKey(KeyCode.E))
            {
                // Direct smell shader in the defined direction
                // with chosen colour
                
                Debug.Log("Sniff sniff");
                SetMood();
            }
        }
    }
}
