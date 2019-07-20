using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksInterviewDemo
{
    [RequireComponent(typeof(TankMotor), typeof(TrajectoryCalculator), typeof(AimLineDraftsman))]
	public class TankController : MonoBehaviour 
	{
        [SerializeField]
        private float StartingFireSpeed = 40f;

        private Camera Camera;
        private UI UIcontroller;

        private Vector3 MovementInput;
        private Vector3 RotationInput;

        private bool IsAiming = false;


        private TankMotor Motor;
        private AimLineDraftsman AimLine;
        private TrajectoryCalculator TrajectoryCalculator;

        private void Awake()
        {
            Motor = GetComponent<TankMotor>();
            AimLine = GetComponent<AimLineDraftsman>();
            TrajectoryCalculator = GetComponent<TrajectoryCalculator>();

            TrajectoryCalculator.SetFireSpeed(StartingFireSpeed);
        }

        private void Start()
        {
            UIcontroller = Root.Instance.GetUI();
            Camera = Root.Instance.GetMainCamera();
        }


        private void Update()
        {
            MovementInput.z= Input.GetAxis("Vertical");
            MovementInput.x = Input.GetAxis("Horizontal");

            RotationInput.x = Input.GetAxis("Mouse X");
            RotationInput.y = Input.GetAxis("Mouse Y");

            if (Input.GetKeyDown(KeyCode.Alpha0))
                ToggleAiming();

            if (Input.GetButtonDown("Fire1"))
                Motor.Fire();
        }

        private void FixedUpdate()
        {
            Motor.RotateVertical(RotationInput.y);
            Motor.RotateHorizontal(RotationInput.x);

            Motor.Move(MovementInput);

            AdjustAimPosition();
        }

        private void AdjustAimPosition()
        {
            var worldPos = TrajectoryCalculator.GetEarthHitPosition();
            var screenPos = Camera.WorldToScreenPoint(worldPos);

            UIcontroller.PositionAim(screenPos);

            var min = Root.Instance.GetLevelMin();
            var max = Root.Instance.GetLevelMax();

            if (worldPos.x < min.x || worldPos.z < min.z)
                UIcontroller.SetAimRed();
            else if (worldPos.x > max.x || worldPos.z > max.z)
                UIcontroller.SetAimRed();
            else
                UIcontroller.SetAimBlack();
        }

        private void ToggleAiming()
        {
            IsAiming = !IsAiming;
            if (IsAiming)
                AimLine.On();
            else
                AimLine.Off();
        }

    } 
	
} 


