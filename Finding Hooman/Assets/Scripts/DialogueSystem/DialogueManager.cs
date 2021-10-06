using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private DialogueUI dialogueUI;
        [SerializeField] [Range(0f, 0.2f)] private float dialogueSpeed;

        // Be able to hide UI when dialogue is playing
        [Header("UI")]
        [SerializeField] private GameObject moodImage;

        private Queue<string> lines = new Queue<string>();
        private Queue<Sprite> images = new Queue<Sprite>();
        
        private bool playingDialogue;
        public bool PlayingDialogue => playingDialogue;

        private void Start()
        {
            dialogueUI.endOfLine.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (playingDialogue)
            {
                if (Input.GetMouseButtonDown(0))
                    DisplayNextLine();
            }
        }

        public void StartDialogue(Dialogue dialogue)
        {
            HideUI();
            
            playingDialogue = true;
            dialogueUI.gameObject.SetActive(true);
            
            lines.Clear();
            images.Clear();

            foreach (string line in dialogue.lines)
            {
                lines.Enqueue(line);
            }

            foreach (Sprite image in dialogue.dialogueImages)
            {
                images.Enqueue(image);
            }
            
            DisplayNextLine();
        }

        private void EndDialogue()
        {
            playingDialogue = false;
            dialogueUI.gameObject.SetActive(false);
            
            ShowUI();
        }

        private void DisplayNextLine()
        {
            dialogueUI.endOfLine.gameObject.SetActive(false);

            if (lines.Count == 0)
            {
                EndDialogue();
                return;
            }

            // Stop dialogue from showing image if there is no image available
            if (images.Count != lines.Count)
                SetDialogueImageColour(0f);

            else
            {
                Sprite dialogueImage = images.Dequeue();
                SetDialogueImageColour(1f);
                dialogueUI.dialogueImage.sprite = dialogueImage;
            }

            string line = lines.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeLine(line));
        }

        IEnumerator TypeLine(string line)
        {
            dialogueUI.dialogueText.text = "";

            foreach (char letter in line.ToCharArray())
            {
                dialogueUI.dialogueText.text += letter;
                yield return new WaitForSeconds(dialogueSpeed);
            }
            
            dialogueUI.endOfLine.SetActive(true);
        }

        private void SetDialogueImageColour(float alpha)
        {
            Color tempColour = dialogueUI.dialogueImage.color;
            tempColour.a = alpha;
            dialogueUI.dialogueImage.color = tempColour;
        }

        private void HideUI()
        {
            moodImage.SetActive(false);
        }

        private void ShowUI()
        {
            moodImage.SetActive(true);
        }
    }
}
