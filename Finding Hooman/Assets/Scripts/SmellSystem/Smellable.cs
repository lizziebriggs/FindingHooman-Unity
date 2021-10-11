using Player;
using UnityEngine;

namespace SmellSystem
{
    public class Smellable : MonoBehaviour
    {
        [Header("Smell Values")]
        [SerializeField] private ScentFollow smellTrail;
        
        [Header("Mood")]
        [SerializeField] private PlayerMoodController.Mood mood;
        [SerializeField] protected PlayerMoodController moodController;

        protected void SetMood()
        {
            moodController.PlayerMood = mood;
        }

        private void OnTriggerStay(Collider other)
        {
            if (smellTrail.gameObject.activeSelf) return;
            
            if (Input.GetKey(KeyCode.E))
            {
                if (smellTrail)
                {
                    smellTrail.gameObject.SetActive(true);
                    smellTrail.ActivateTrail();
                }
                
                SetMood();
            }
        }
    }
}
