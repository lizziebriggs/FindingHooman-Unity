using DialogueSystem;
using UnityEngine;

namespace GameSystem
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private DialogueTrigger dialogueTrigger;

        private void Start()
        {
            dialogueTrigger.TriggerDialogue();
        }

        private void EndLevel()
        {
            
        }
    }
}
