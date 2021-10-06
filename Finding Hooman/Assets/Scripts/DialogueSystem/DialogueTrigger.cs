using UnityEngine;

namespace DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] private DialogueManager dialogueManager;
        [SerializeField] private Dialogue dialogue;

        private void OnTriggerStay(Collider other)
        {
            if(Input.GetKey(KeyCode.E) && !dialogueManager.PlayingDialogue)
                dialogueManager.StartDialogue(dialogue);
        }
    }
}
