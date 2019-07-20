using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksInterviewDemo
{
	public class TankEffects : MonoBehaviour 
	{
        [SerializeField]
        private ParticleSystem ShootingParticles;

        public void PlayShoot()
        {
            ShootingParticles.Play();
        }
	
	} 
} 


