using System;
using DialogueSystem;
using UnityEngine;

namespace GameSystem
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private DialogueTrigger dialogueTrigger;
        [SerializeField] private DialogueManager dialogueManager;
        
        [Header("UI")]
        [SerializeField] private GameObject hud;
        [SerializeField] private GameObject dialogueBox;
        [SerializeField] private GameObject pauseMenu;

        private void Start()
        {
            pauseMenu.SetActive(false);
            dialogueTrigger.TriggerDialogue();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;

            if (pauseMenu.activeSelf == false)
            {
                Time.timeScale = 0;
                
                if(!dialogueManager.PlayingDialogue)
                    hud.SetActive(false);
                else
                    dialogueBox.SetActive(false);
                
                pauseMenu.SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        public void ClosePauseMenu()
        {
            Time.timeScale = 1;
            
            pauseMenu.SetActive(false);
            
            if (!dialogueManager.PlayingDialogue)
                hud.SetActive(true);
            else
                dialogueBox.SetActive(true);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void EndLevel()
        {
            // 
        }
    }
}
