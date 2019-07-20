using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksInterviewDemo 
{
	public class UI : MonoBehaviour 
	{
        [SerializeField]
        private RectTransform AimBase;
        [SerializeField]
        private GameObject AllowedAim;
        [SerializeField]
        private GameObject RestrictedAim;

        private void Awake()
        {
            SetAimAllowed();
        }

        public void PositionAim(Vector3 position)
        {
            AimBase.position = position;
        }

        public void SetAimAllowed()
        {
            AllowedAim.SetActive(true);
            RestrictedAim.SetActive(false);
        }

        public void SetAimRestricted()
        {
            AllowedAim.SetActive(false);
            RestrictedAim.SetActive(true);
        }
	
	} 
} 


