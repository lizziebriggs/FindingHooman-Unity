using GameSystem;
using UnityEngine;

namespace SmellSystem
{
    public class HoomanSmell : Smellable
    {
        [SerializeField] private LevelController levelController;
        
        private void OnTriggerStay(Collider other)
        {
            if (Input.GetKey(KeyCode.E))
            {
                SetMood();
                levelController.FoundOwner = true;
            }
        }
    }
}
