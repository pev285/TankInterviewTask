using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksInterviewDemo 
{
	public class UI : MonoBehaviour 
	{
        [SerializeField]
        private RectTransform Aim;
        [SerializeField]
        private GameObject BlackImage;
        [SerializeField]
        private GameObject RedImage;

        private void Awake()
        {
            SetAimBlack();
        }

        public void PositionAim(Vector3 position)
        {
            Aim.position = position;
        }

        public void SetAimBlack()
        {
            RedImage.SetActive(false);
            BlackImage.SetActive(true);
        }

        public void SetAimRed()
        {
            RedImage.SetActive(true);
            BlackImage.SetActive(false);
        }
	
	} 
} 


