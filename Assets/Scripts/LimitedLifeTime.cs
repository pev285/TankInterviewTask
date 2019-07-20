using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksInterviewDemo
{
	public class LimitedLifeTime : MonoBehaviour 
	{
        public float LifeDuration = 5f;

        private float LifeTime;

        private void Start()
        {
            LifeTime = 0;
        }

        private void Update()
        {
            LifeTime += Time.deltaTime;
            CheckLifeEnd();
        }

        private void CheckLifeEnd()
        {
            if (LifeTime < LifeDuration)
                return;

            Destroy(gameObject);
        }
    } 
} 


