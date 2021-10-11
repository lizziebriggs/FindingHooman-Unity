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
        [SerializeField] private GameObject bigMinimap;
        [SerializeField] private GameObject endScreen;

        private bool foundOwner;

        public bool FoundOwner
        {
            set => foundOwner = value;
        }

        private void Start()
        {
            pauseMenu.SetActive(false);
            bigMinimap.SetActive(false);
            endScreen.SetActive(false);
            dialogueTrigger.TriggerDialogue();

            foundOwner = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OpenMenu(pauseMenu);
            }

            if (dialogueManager.PlayingDialogue) return;

            if (Input.GetKeyDown(KeyCode.M))
            {
                if (!bigMinimap.activeSelf)
                {
                    Time.timeScale = 0;
                    hud.SetActive(false);
                    bigMinimap.SetActive(true);
                }
                
                else if (bigMinimap.activeSelf)
                {
                    Time.timeScale = 1;
                    hud.SetActive(true);
                    bigMinimap.SetActive(false);
                }
            }
            
            if(foundOwner && !dialogueManager.PlayingDialogue)
                OpenMenu(endScreen);
        }

        private void OpenMenu(GameObject menuToOpen)
        {
            if (menuToOpen.activeSelf != false) return;
            
            Time.timeScale = 0;
                
            if(!dialogueManager.PlayingDialogue)
                hud.SetActive(false);
            else
                dialogueBox.SetActive(false);
                
            menuToOpen.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
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
    }
}
