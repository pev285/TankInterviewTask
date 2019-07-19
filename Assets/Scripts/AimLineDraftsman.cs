using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksInterviewDemo
{
    public class AimLineDraftsman : MonoBehaviour
    {
        private LineRenderer Line;

        private int PosCount = 10;
        private Vector3[] Positions;

        private void Awake()
        {
            Line = GetComponent<LineRenderer>();

            Positions = new Vector3[PosCount];
            Line.SetVertexCount(PosCount);

            Positions[0] = Vector3.zero;
            Positions[1] = new Vector3(250, 10, 250);
        }



        public void Draw()
        {
            Line.SetPositions(Positions);
        }
    } 
} 

