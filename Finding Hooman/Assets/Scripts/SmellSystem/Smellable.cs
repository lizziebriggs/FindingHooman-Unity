using UnityEngine;

namespace SmellSystem
{
    public class Smellable : MonoBehaviour
    {
        [Header("Smell Values")]
        [SerializeField] private Color colour;
        [SerializeField] private Transform direction;

        private void OnTriggerStay(Collider other)
        {
            if (Input.GetKey(KeyCode.E))
            {
                // Direct smell shader in the defined direction
                // with chosen colour
                
                Debug.Log("Sniff sniff");
            }
        }
    }
}
