using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksInterviewDemo
{
	public class BulletEffects : MonoBehaviour 
	{
        [SerializeField]
        private GameObject ExplosionPrefab;

        public void PlayExplosion(Vector3 position)
        {
            var explosion = Instantiate(ExplosionPrefab, position, Quaternion.identity);
        }
	} 
} 


