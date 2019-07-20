using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksInterviewDemo
{
	public class Root : MonoBehaviour 
	{
        public static Root Instance { get; private set; }

        [SerializeField]
        private UI UI;
        [SerializeField]
        Camera MainCamera;

        [SerializeField]
        private Level Level;

        private void Awake()
        {
            Instance = this;
        }

        public UI GetUI()
        {
            return UI;
        }

        public Camera GetMainCamera()
        {
            return MainCamera;
        }

        public Vector3 GetLevelMin()
        {
            return Level.MinPosition;
        }

        public Vector3 GetLevelMax()
        {
            return Level.MaxPosition;
        }

    } 
} 


