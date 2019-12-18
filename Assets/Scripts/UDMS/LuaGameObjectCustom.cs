using System;
using UnityEngine;

namespace LuaScripting
{
    /// <summary>
    /// The part of LuaGameObject useful for holding custom UDMS functions.
    /// </summary>
    public abstract partial class LuaGameObject : MonoBehaviour
    {
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
    }
}

