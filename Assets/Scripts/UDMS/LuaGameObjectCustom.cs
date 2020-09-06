using UnityEngine;

namespace LuaScripting
{
    /// <summary>
    /// The part of LuaGameObject useful for holding custom UDMS functions.
    /// </summary>
    public abstract partial class LuaGameObject : MonoBehaviour
    {
        public int State = 0;
        public int StateOld = 0;
        public Vector3 PositionOld = Vector3.zero;
        public bool TurnToMoveDir;
        public bool ColorState;

        private Vector3 _framePos;
        private Vector3 _displacement;
        private int _stateOld = 0;

        public void BeforeUpdateActions()
        {
            _framePos = transform.position;
            _stateOld = State;
        }

        public void AfterLateUpdateActions()
        {
            _displacement = transform.position - _framePos;
            PositionOld = _framePos;
            StateOld = _stateOld;
            if (TurnToMoveDir)
            {
                TurnToDirSoft(_displacement, 10);
            }
            if (TextMeshComponent && _showTextMeshObject) TextMeshComponent.transform.rotation = Camera.main.transform.rotation;
            if (ColorState) 
            {
                if (State == 1) SetColor(0, 1, 0);
                else ClearColor();
            }
        }

        public void MoveUp(float distance)
        {
            transform.position += distance * transform.up;
        }

        public void MoveFwd(float distance)
        {
            transform.position += distance * transform.forward;
        }

        public void MoveRight(float distance)
        {
            transform.position += distance * transform.right;
        }

        public void MoveInDir(Vector3 direction, float distance, bool normalized)
        {
            transform.position += (normalized ? Vector3.Normalize(direction) : direction) * distance;
        }

        public void MoveInDirXZ(Vector2 direction, float distance, bool normalized)
        {
            var displacement = (normalized ? direction.normalized : direction) * distance; 
            transform.position += new Vector3(displacement.x, 0, displacement.y);
        }

        public void GoToPoint(Vector3 point, float distance)
        {
            MoveInDir(point - transform.position, distance, true);
        }

        public void GoToPointXZ(Vector2 point, float distance)
        {
            MoveInDirXZ(point - new Vector2(transform.position.x, transform.position.z), distance, true);
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
            direction.Normalize();
            var v0 = new Vector3(Mathf.Sin(transform.eulerAngles.y * Mathf.Deg2Rad), 0, Mathf.Cos(transform.eulerAngles.y * Mathf.Deg2Rad));
            var q1 = Vector3.Cross(v0, direction).magnitude;

            if (q1 < 0.001 && Vector3.Dot(v0, direction) < 0) q1 = 1;
            if (Vector3.Cross(v0, direction).y > 0) transform.Rotate(0, speed * q1, 0);
            if (Vector3.Cross(v0, direction).y < 0) transform.Rotate(0, -speed * q1, 0);
        }

        public Vector3 DirAgentToPnt(Vector3 point)
        {
            return Vector3.Normalize(point - transform.position);
        }

        public Vector3 DirMine()
        {
            return transform.forward;
        }

        public Vector3 DirStayInDisc(float radius)
        {
            if (Vector3.Magnitude(transform.position) > radius)
                return -Vector3.Normalize(transform.position);
            
            return Vector3.Normalize(transform.position);
        }

        public Vector3 Displacement()
        {
            return _displacement;
        }

        public float DistAgentToPnt(Vector3 point)
        {
            return Vector3.Distance(transform.position, point);
        }

        public float DistAgentToPntXZ(Vector2 point)
        {
            return Vector2.Distance(new Vector2(transform.position.x, transform.position.z), point);
        }

        public float DistTravelled()
        {
            return Vector3.Magnitude(_displacement);
        }

        public bool IsActive()
        {
            return State == 1;
        }

        public Vector3 GetPos()
        {
            return transform.position;
        }

        public Vector3 GetAngles()
        {
            return transform.rotation.eulerAngles;
        }
    }
}

