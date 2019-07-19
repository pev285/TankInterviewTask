using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksInterviewDemo
{
    [RequireComponent(typeof(TrajectoryCalculator), typeof(LineRenderer))]
    public class AimLineDraftsman : MonoBehaviour
    {
        private bool IsEnabled;

        private LineRenderer Line;
        private TrajectoryCalculator Trajectory;

        private int PosCount = 10;
        private Vector3[] Positions;

        private void Awake()
        {
            Line = GetComponent<LineRenderer>();
            Trajectory = GetComponent<TrajectoryCalculator>();

            Positions = new Vector3[PosCount];
            Line.positionCount = PosCount;
        }

        private void Update()
        {
            if (IsEnabled)
                Draw();
        }

        public void On()
        {
            IsEnabled = true;
            Line.enabled = true;
        }

        public void Off()
        {
            IsEnabled = false;
            Line.enabled = false;
        }

        private void Draw()
        {
            CalculatePositions();
            Line.SetPositions(Positions);
        }

        private void CalculatePositions()
        {
            var step = 1f / (PosCount-1);

            for (int i = 0; i < PosCount; i++)
                Positions[i] = Trajectory.GetPositionAt(i * step);
        }
    } 
} 

