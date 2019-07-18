using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksInterviewDemo
{
	public class TankController : MonoBehaviour 
	{
        [SerializeField]
        private float MovementSpeed = 5f;
        [SerializeField]
        private float HRotationSpeed = 15f;

        private Rigidbody RB;
        private Transform Transform;

        private Vector3 MovementInput;
        private Vector3 RotationInput;

        private void Awake()
        {
            RB = GetComponent<Rigidbody>();
            Transform = GetComponent<Transform>();
        }

        private void Update()
        {
            MovementInput.z= Input.GetAxis("Vertical");
            MovementInput.x = Input.GetAxis("Horizontal");

            RotationInput.x = Input.GetAxis("Mouse X");
            RotationInput.y = Input.GetAxis("Mouse Y");
        }

        private void FixedUpdate()
        {
            float horizontalRotationAmount = RotationInput.x * HRotationSpeed * Time.deltaTime;
            //Quaternion newRotation = Quaternion.Euler(0, horizontalRotationAmount, 0)* RB.rotation;
            Quaternion newRotation = RB.rotation * Quaternion.Euler(0, horizontalRotationAmount, 0);

            RB.MoveRotation(newRotation);

            var velocity = MovementInput.normalized * MovementSpeed;
            RB.velocity = RB.rotation * velocity;
        }

    } // END OF CLASS ///
	
} // END OF NAMESPACE ///


