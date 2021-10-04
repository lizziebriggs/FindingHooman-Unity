using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue/New Dialogue")]
    
    [System.Serializable]
    public class Dialogue : ScriptableObject
    {
        public Sprite[] dialogueImages;
        [TextArea(3, 5)] public string[] lines;
    }
}
