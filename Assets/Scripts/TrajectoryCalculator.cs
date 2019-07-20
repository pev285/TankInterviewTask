using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksInterviewDemo
{
	public class TrajectoryCalculator : MonoBehaviour 
	{
        [SerializeField]
        private Transform FirePoint;

        private float G;

        private void Awake()
        {
            G = -Physics.gravity.y;
        }

        public float FireSpeed { get; private set; }

        public void SetFireSpeed(float value)
        {
            FireSpeed = value;
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
            var direction = FirePoint.forward;
            var startPosition = FirePoint.position;

            var velocity = direction * FireSpeed;

            var startY = startPosition.y;
            var flightTime = GetFlightTime(startY, velocity.y);

            var position = GetPositionByTime(startPosition, velocity, t * flightTime);

            return position;
        }

        private Vector3 GetPositionByTime(Vector3 start, Vector3 velocity, float time)
        {
            var horizontalVelocity = new Vector3(velocity.x, 0, velocity.z);
            Vector3 position = start + time * horizontalVelocity;

            var newY = start.y + velocity.y * time - 0.5f * G * time * time;
            position.y = newY;

            return position;
        }
	
        private float GetFlightTime(float y0, float vy)
        {
            var descr = Mathf.Sqrt(vy * vy + 2 * G * y0);
            var t = (vy + descr) / G;

            return t;
        }
	} 
} 


