using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using XLua;

namespace LuaScripting
{
    [LuaCallCSharp]
    public class LuaCameraObject : LuaIndividualObject
    {
        public CinemachineVirtualCamera[] Cameras;
        public CinemachineSmoothPath[] DollyTracks;
        public float FOV {get => _fov; set { SetFov(value); }}

        public float PathPosition { get => _pathPosition; set { SetPathPosition(value); }}

        public string ActiveCamera { get => _activeCamera;  set {
            switch(value) {
                case "explorer": {
                    _activeCamera = value;
                    SetActiveCamera(0);
                    break;
                }
                case "dolly": {
                    _activeCamera = value;
                    SetActiveCamera(1);
                    break;
                }
                case "2D": {
                    _activeCamera = value;
                    SetActiveCamera(2);
                    break;
                }
                case "locked": {
                    _activeCamera = value;
                    SetActiveCamera(3);
                    break;
                }
                default: {
                    _activeCamera = "explorer";
                    SetActiveCamera(0);
                    break;
                }
            }
        }}

        public string DollyTrack { get => _dollyTrack;  set {
            switch(value) {
                case "circular": {
                    _dollyTrack = value;
                    SetActiveDollyTrack(0);
                    break;
                }
                case "square": {
                    _dollyTrack = value;
                    SetActiveDollyTrack(1);
                    break;
                }
                case "custom1": {
                    _dollyTrack = value;
                    SetActiveDollyTrack(2);
                    break;
                }
                default: {
                    _dollyTrack = "circular";
                    SetActiveDollyTrack(0);
                    break;
                }
            }
        }}
        private string _activeCamera = "dolly";
        private string _dollyTrack = "circular";
        private float _fov = 40;
        private float _pathPosition = 0;

        private CinemachineTrackedDolly _trackedDolly;

        private Transform _followTarget;
        private Transform _lookAtTarget;

        protected override void Awake()
        {
            Cameras = GetComponentsInChildren<CinemachineVirtualCamera>();
            DollyTracks = GetComponentsInChildren<CinemachineSmoothPath>();
            _trackedDolly = Cameras[1].GetCinemachineComponent<CinemachineTrackedDolly>();
            Debug.Assert(_trackedDolly != null);
            _followTarget = transform.GetChild(2).GetChild(0);
            _lookAtTarget = transform.GetChild(2).GetChild(1);
            ActiveCamera = _activeCamera;
            DollyTrack = _dollyTrack;
            FOV = _fov;
            PathPosition = _pathPosition;
            base.Awake();
        }

        /// <summary>
        /// Makes the camera follow a specific group agent.
        /// </summary>
        /// <param name="groupName">The agent's group name.</param>
        /// <param name="agentId">The id of the agent.</param>
        /// <param name="offset">The offset off the target the camera should follow.</param>
        public void FollowGroupAgent(string groupName, int agentId, Vector3 offset)
        {
            if (!LuaDomain.DomainRoom.Groups.ContainsKey(groupName))
            {
                Debug.LogError($"There is no group named: {groupName}");
                return;
            }

            var group = LuaDomain.DomainRoom.Groups[groupName];

            if (agentId >= group.Members.Count) 
            {
                Debug.LogError($"No agent found with id: {agentId}. Group: {groupName} has only {group.Members.Count} agents and their ids start from zero.");
                return;
            }

            SetFollowTarget(group.Members[agentId].transform, offset);
        }

        /// <summary>
        /// Makes the camera target a specific group agent.
        /// </summary>
        /// <param name="groupName">The agent's group name.</param>
        /// <param name="agentId">The id of the agent.</param>
        /// <param name="offset">The offset off the target the camera should look at.</param>
        public void LookAtGroupAgent(string groupName, int agentId, Vector3 offset)
        {
            if (!LuaDomain.DomainRoom.Groups.ContainsKey(groupName))
            {
                Debug.LogError($"There is no group named: {groupName}");
                return;
            }

            var group = LuaDomain.DomainRoom.Groups[groupName];

            if (agentId >= group.Members.Count) 
            {
                Debug.LogError($"No agent found with id: {agentId}. Group: {groupName} has only {group.Members.Count} agents and their ids start from zero.");
                return;
            }

            SetLookAtTarget(group.Members[agentId].transform, offset);
        }

        public void SetFollowTarget(Transform targetTransform, Vector3 offset)
        {
            _followTarget.SetParent(targetTransform);
            _followTarget.localPosition = offset;
        }

        public void SetLookAtTarget(Transform targetTransform, Vector3 offset)
        {
            _lookAtTarget.SetParent(targetTransform);
            _lookAtTarget.localPosition = offset;
        }

        /// <summary>
        /// Sets the active track's position.
        /// </summary>
        public void SetTrackPosition(float x, float y, float z)
        {
            if (_trackedDolly == null) return;

            _trackedDolly.m_Path.transform.position = new Vector3(x, y, z);
        }

        /// <summary>
        /// Sets the active track's scale. Useful for expanding/compressing the track.
        /// </summary>
        public void SetTrackScale(float x, float y, float z)
        {
            if (_trackedDolly == null) return;

            _trackedDolly.m_Path.transform.localScale = new Vector3(x, y, z);
        }

        /// <summary>
        /// Increases the priority of the camera on specified index while decreasing the others.
        /// That camera will become the active one unless there are cameras with even higher priorities in the scene.
        /// </summary>
        /// <param name="cameraId">The id of the camera to activate.</param>
        private void SetActiveCamera(int cameraId)
        {
            if (Cameras == null || Cameras.Length == 0) 
            {
                return;
            }

            foreach (var camera in Cameras)
            {
                camera.Priority = 10;
            }
            Cameras[cameraId].Priority = 100;
        }

        private void SetActiveDollyTrack(int trackId)
        {
            if (_trackedDolly == null || DollyTracks == null || Cameras == null || Cameras.Length == 0 || DollyTracks.Length == 0)
            {
                return;
            }
            
            _trackedDolly.m_Path = DollyTracks[trackId];
        }

        private void SetFov(float fov)
        {
            if (Cameras == null || Cameras.Length == 0) 
            {
                return;
            }

            foreach (var camera in Cameras)
            {
                camera.m_Lens.FieldOfView = fov;
            }
            _fov = fov;
        }

        private void SetPathPosition(float pathPosition)
        {
            if (_trackedDolly == null) return;

            _trackedDolly.m_PathPosition = pathPosition;
        }
    }

}