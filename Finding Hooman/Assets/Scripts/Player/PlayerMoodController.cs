using System;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerMoodController : MonoBehaviour
    {
        public enum Mood { Happy, Sad, Curious, Ill }

        private Mood playerMood;
        public Mood PlayerMood
        {
            set
            {
                playerMood = value;

                moodImage.sprite = playerMood switch
                {
                    Mood.Happy => moodImages[(int) Mood.Happy],
                    Mood.Sad => moodImages[(int) Mood.Sad],
                    Mood.Curious => moodImages[(int) Mood.Curious],
                    Mood.Ill => moodImages[(int) Mood.Ill],
                    _ => moodImage.sprite
                };
            }
        }

        [Header("UI")]
        [SerializeField] private Image moodImage;
        [SerializeField] private Sprite[] moodImages;

        private void Start()
        {
            playerMood = Mood.Sad;
            moodImage.sprite = moodImages[(int) Mood.Sad];
        }
    }
}