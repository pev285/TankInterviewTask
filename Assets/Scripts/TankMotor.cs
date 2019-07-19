﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksInterviewDemo
{
    [RequireComponent(typeof(Rigidbody))]
    public class TankMotor : MonoBehaviour
    {
        private const float MinVerticalAngle = 0f;
        private const float MaxVerticalAngle = 80f;

        private const float MinHorizontalAngle = -20;
        private const float MaxHorizontalAngle = 20;


        [SerializeField]
        private float MovementSpeed = 5f;
        [SerializeField]
        private float HorizontalRotationSpeed = 20f;
        [SerializeField]
        private float VerticalRotationSpeed = 15f;

        [Space(10)]

        [SerializeField]
        private Transform FirePoint;
        [SerializeField]
        private Transform GunHolder;
        [SerializeField]
        private Transform WeaponBase;


        private Rigidbody RB;

        private float VerticalGunAngle;
        private float HorizontalGunAngle;

        private void Awake()
        {
            RB = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            VerticalGunAngle = 0;
            HorizontalGunAngle = 0;
        }


        public void Move(Vector3 localDirection)
        {
            Vector3 localVelocity = localDirection.normalized * MovementSpeed;
            Vector3 velocity = RB.rotation * localVelocity;
            RB.velocity = velocity;
        }

        public void RotateVertical(float angle)
        {
            float rotationAmount = angle * VerticalRotationSpeed * Time.deltaTime;

            VerticalGunAngle += rotationAmount;
            VerticalGunAngle = Mathf.Clamp(VerticalGunAngle, MinVerticalAngle, MaxVerticalAngle);

            GunHolder.localRotation = Quaternion.Euler(-VerticalGunAngle, 0, 0);
        }

        public void RotateHorizontal(float angle)
        {
            float rotationAmount = angle * HorizontalRotationSpeed * Time.deltaTime;

            float tankRotationDelta = 0;
            HorizontalGunAngle += rotationAmount;

            if (HorizontalGunAngle < MinHorizontalAngle)
            {
                tankRotationDelta = HorizontalGunAngle - MinHorizontalAngle;
                HorizontalGunAngle = MinHorizontalAngle;
            }
            else if (HorizontalGunAngle > MaxHorizontalAngle)
            {
                tankRotationDelta = HorizontalGunAngle - MaxHorizontalAngle;
                HorizontalGunAngle = MaxHorizontalAngle;
            }

            SetRotations(HorizontalGunAngle, tankRotationDelta);
        }


        private void SetRotations(float weaponBaseAngle, float delta)
        {
            WeaponBase.localRotation = Quaternion.Euler(0, weaponBaseAngle, 0);

            if (delta != 0)
            {
                Quaternion newRotation = RB.rotation * Quaternion.Euler(0, delta, 0);
                RB.MoveRotation(newRotation);
            }
        }

    }
}


