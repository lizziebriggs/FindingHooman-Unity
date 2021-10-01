using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        
        [Header("Movement")]
        [SerializeField] private float walkSpeed;
        [SerializeField] private float runSpeed;
        [SerializeField] private float acceleration;
        [SerializeField] private float jumpHeight;
        [SerializeField] private float jumpSpeed;

        private float currentSpeed;
        private Vector3 directionToMove;
        private Vector3 directionVector;
        private bool grounded;

        private void Start()
        {
            if (!rb) rb = GetComponent<Rigidbody>();

            currentSpeed = walkSpeed;
        }

        private void FixedUpdate()
        {
            // Running transitions
            if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && grounded)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                    SpeedUp();
                else
                    SlowDown();
            }
            
            // Jump
            if(Input.GetKey(KeyCode.Space) && grounded)
                Jump();
            
            // Movement input
            var trans = rb.transform;
            
            transform.Rotate(0, Input.GetAxis("Horizontal") * currentSpeed, 0);
            directionToMove.z = Input.GetAxis("Vertical");
            directionVector = (trans.right * directionToMove.x) + (trans.forward * directionToMove.z);
            rb.MovePosition(trans.position + Time.deltaTime * currentSpeed * directionVector);
        }

        private void SlowDown()
        {
            if (currentSpeed >= walkSpeed)
                currentSpeed -= acceleration * Time.deltaTime;
        }

        private void SpeedUp()
        {
            if (currentSpeed <= runSpeed)
                currentSpeed += acceleration * Time.deltaTime;
        }

        private void Jump()
        {
            rb.AddForce(new Vector3(0, jumpHeight, 0) * jumpSpeed, ForceMode.Impulse);
            grounded = false;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Ground") && !grounded)
                grounded = true;
        }
    }
}
