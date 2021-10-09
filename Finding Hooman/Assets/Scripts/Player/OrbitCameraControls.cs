using UnityEngine;

namespace Player
{
    public class OrbitCameraControls : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private Transform playerToFollow;
        [SerializeField] private bool rotateAroundPlayer;
        [SerializeField] private float rotateSpeed;
        [SerializeField] [Range(0f, 1f)] private float smoothing;
        
        private Vector3 positionOffset;

        private void Start()
        {
            Time.timeScale = 1;
            
            // Calculate offset from position in scene at play
            positionOffset = transform.position - playerToFollow.position;
        }

        private void LateUpdate()
        {
            // Camera doesn't move whilst pause menu is up
            if (Time.timeScale == 0) return;
            
            if (rotateAroundPlayer)
            {
                Quaternion turnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotateSpeed, Vector3.up);
                positionOffset = turnAngle * positionOffset;
            }
            
            Vector3 newPos = playerToFollow.position + positionOffset;
            transform.position = Vector3.Slerp(transform.position, newPos, smoothing);
            
            transform.LookAt(playerToFollow);
        }
    }
}
