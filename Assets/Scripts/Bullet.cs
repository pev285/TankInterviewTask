using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksInterviewDemo
{
	public class Bullet : MonoBehaviour 
	{
        private const float LifeDuration = 15f;

        private float LifeTime;
        private BulletEffects Effects;

        private void Awake()
        {
            Effects = GetComponent<BulletEffects>();
        }

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

            Die();
        }

        private void Die()
        {
            Effects.PlayExplosion(transform.position);
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            Die();
        }
    } 
} 


