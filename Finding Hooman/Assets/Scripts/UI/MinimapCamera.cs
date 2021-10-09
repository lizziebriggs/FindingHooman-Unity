using UnityEngine;

namespace UI
{
    public class MinimapCamera : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Transform mainCamera;

        private void LateUpdate()
        {
            var newPos = player.position;
            newPos.y = transform.position.y;
            transform.position = newPos;
            
            transform.rotation = Quaternion.Euler(90f, mainCamera.eulerAngles.y, 0f);
        }
    }
}
