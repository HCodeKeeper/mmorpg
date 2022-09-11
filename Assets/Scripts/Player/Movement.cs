using System;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField]
        [Range(2,50)]
        private float speed = 2f;
        [SerializeField]
        private float jumpHeight = 5.0f;
        private float gravityValue = -9.81f;
        private bool groundedPlayer;
        private Vector3 verticalVelocity;
        //private LayerMask walkableLayerMask;

        public Transform cam;
        public float turnSmoothTime = 0.1f;
        private float turnSmoothVelocity;

        public CharacterController controller;

        void Start()
        {
            //walkableLayerMask = LayerMask.GetMask("Walkable");
        }

        bool isGrounded()
        {
            float extraHeight = 0.2f;
            return Physics.Raycast(controller.bounds.min, Vector3.down, extraHeight);
        }


        void Update()
        {
            MoveTranslated();
            
            ExpectJump();
            
        }

        void ExpectJump()
        {
            groundedPlayer = isGrounded();
            if (groundedPlayer && verticalVelocity.y < 0)
            {
                verticalVelocity.y = 0f;
            }
            
            if (Input.GetButtonDown("Jump") && groundedPlayer)
            {
                //Debug.Log("Jumped");
                verticalVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            verticalVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(verticalVelocity * Time.deltaTime);
        }

        void MoveTranslated()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(x, 0, z);
            if (direction.magnitude >= 0.1)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                Vector3 vector = moveDirection.normalized * Time.deltaTime * speed;
                
                controller.Move(vector);
            }
        }
    }
}
