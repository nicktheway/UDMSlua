﻿using System;
using UnityEngine;

namespace LuaScripting
{
    /// <summary>
    /// The part of LuaGameObject useful for holding custom UDMS functions.
    /// </summary>
    public abstract partial class LuaGameObject : MonoBehaviour
    {
        public bool TurnToMoveDir;

        private Vector3 _framePos;
        private Vector3 _displacement;


        public void BeforeUpdateActions()
        {
            _framePos = transform.position;
        }

        public void AfterLateUpdateActions()
        {
            _displacement = transform.position - _framePos;
            if (TurnToMoveDir) TurnToDirSoft(_displacement, 10);
        }

        public void MoveUp(float distance)
        {
            transform.position += distance * Vector3.up;
        }

        public void MoveFwd(float distance)
        {
            transform.position += distance * Vector3.forward;
        }

        public void MoveRight(float distance)
        {
            transform.position += distance * Vector3.right;
        }

        public void MoveInDir(Vector3 direction, float distance, bool normalized)
        {
            transform.position += (normalized ? Vector3.Normalize(direction) : direction) * distance;
        }

        public void GoToPoint(Vector3 point, float distance)
        {
            MoveInDir(point - transform.position, distance, true);
        }

        public void SetDir(Vector3 direction)
        {
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg, 0);
        }

        public void SetPos(Vector3 position)
        {
            transform.position = position;
        }

        public void SetPosX(float x)
        {
            transform.position = new Vector3(x, 0, 0);
        }

        public void SetPosY(float y)
        {
            transform.position = new Vector3(0, y, 0);
        }

        public void SetPosZ(float z)
        {
            transform.position = new Vector3(0, 0, z);
        }

        public void SetRot(Vector3 angles)
        {
            transform.eulerAngles = angles;
        }

        public void SetRotX(float angle)
        {
            transform.eulerAngles = new Vector3(angle, 0, 0);
        }

        public void SetRotY(float angle)
        {
            transform.eulerAngles = new Vector3(0, angle, 0);
        }

        public void SetRotZ(float angle)
        {
            transform.eulerAngles = new Vector3(0, 0, angle);
        }

        public void SetScale(Vector3 scale)
        {
            transform.localScale = scale;
        }

        public void TurnToAngle(float targetAngle, float degrees)
        {
            transform.Rotate(Mathf.Sign(targetAngle - transform.eulerAngles.y) * degrees * Vector3.up);
        }

        public void TurnToDir(Vector3 direction, float speed)
        {
            var targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }

        public void TurnToDirSoft(Vector3 direction, float speed)
        {
            var v0 = new Vector3(Mathf.Sin(transform.eulerAngles.y * Mathf.Deg2Rad), 0, Mathf.Cos(transform.eulerAngles.y * Mathf.Deg2Rad));
            var q1 = Vector3.Cross(v0, direction).magnitude;

            if (q1 < 0.001 && Vector3.Dot(v0, direction) < 0) q1 = 1;
            if (Vector3.Cross(v0, direction).y > 0) transform.Rotate(0, speed * q1, 0);
            if (Vector3.Cross(v0, direction).y < 0) transform.Rotate(0, -speed * q1, 0);
        }
    }
}

