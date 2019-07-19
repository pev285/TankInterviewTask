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
        private float HorizontalRotationSpeed = 15f;
        private float VerticalRotationSpeed = 15f;

        [SerializeField]
        private Transform FirePoint;

        private Rigidbody RB;
        private Transform Transform;

        private AimLineDraftsman AimLine;

        private Vector3 MovementInput;
        private Vector3 RotationInput;



        private void Awake()
        {
            RB = GetComponent<Rigidbody>();
            Transform = GetComponent<Transform>();

            AimLine = GetComponent<AimLineDraftsman>();
        }

        private void Update()
        {
            MovementInput.z= Input.GetAxis("Vertical");
            MovementInput.x = Input.GetAxis("Horizontal");

            RotationInput.x = Input.GetAxis("Mouse X");
            RotationInput.y = Input.GetAxis("Mouse Y");

            if (Input.GetKeyDown(KeyCode.Alpha0))
                AimLine.Draw();
        }

        private void FixedUpdate()
        {
            RotateVertical();
            RotateHorizontal();

            Move();
        }

        private void Move()
        {
            var velocity = MovementInput.normalized * MovementSpeed;
            RB.velocity = RB.rotation * velocity;
        }

        private void RotateVertical()
        {
            float rotationAmount = RotationInput.y * VerticalRotationSpeed * Time.deltaTime;

            //.....
        }

        private void RotateHorizontal()
        {
            float rotationAmount = RotationInput.x * HorizontalRotationSpeed * Time.deltaTime;
            Quaternion newRotation = RB.rotation * Quaternion.Euler(0, rotationAmount, 0);

            RB.MoveRotation(newRotation);
        }
    } 
	
} 


