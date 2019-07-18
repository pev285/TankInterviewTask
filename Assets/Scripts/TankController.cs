using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksInterviewDemo
{
	public class TankController : MonoBehaviour 
	{
        private float MovementSpeed;

        private Rigidbody RB;
        private Transform Transform;

        private float VerticalAxis;
        private float HorizontalAxis;

        private float Mouse;

        private void Awake()
        {
            RB = GetComponent<Rigidbody>();
            Transform = GetComponent<Transform>();
        }

        private void Update()
        {
            VerticalAxis = Input.GetAxis("Vertical");
            HorizontalAxis = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            var velocity = new Vector3(HorizontalAxis, VerticalAxis, 0).normalized * MovementSpeed;

            RB.velocity = velocity;
        }

    } // END OF CLASS ///
	
} // END OF NAMESPACE ///


