using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksInterviewDemo
{
	public class TrajectoryCalculator : MonoBehaviour 
	{
        [SerializeField]
        private Transform FirePoint;

        public float FireForce { get; private set; }

        public void SetFireForce(float value)
        {
            FireForce = value;
        }

        public Vector3 GetEarthHitPosition()
        {
            return GetPositionAt(1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t">value from [0,1]. If 0 - returns starting position, if 1 - returns earth hit position</param>
        /// <returns>Returns a point on the firing trajectory</returns>
        public Vector3 GetPositionAt(float t)
        {
            var startPosition = FirePoint.position;
            var fireDirection = FirePoint.forward;

            var g = Physics.gravity;

            return startPosition + t * 10 * fireDirection;
        }
	
	} 
} 


