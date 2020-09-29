using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using XLua;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace LuaScripting
{
    [LuaCallCSharp]
    public class LuaCameraObject : LuaIndividualObject
    {
        public CinemachineVirtualCamera[] Cameras;
        public float FOV {get => _fov; set { SetFov(value); }}

        public float PathPosition { get => _pathPosition; set { SetPathPosition(value); }}

        public bool AutoDolly { get => _autoDolly; set { SetAutoDolly(value); }}

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

        public string DollyPath { get => _dollyPath;  set {
            if (_registeredDollyPaths.ContainsKey(value))
            {
                _dollyPath = value;
                SetActiveDollyPath(value);
            }
            else
            {
                _dollyPath = "circular";
                SetActiveDollyPath("circular");
            }
        }}
        private Dictionary<string, CinemachinePathBase> _registeredDollyPaths = new Dictionary<string, CinemachinePathBase>();
        private string _activeCamera = "explorer";
        private string _dollyPath = "circular";
        private float _fov = 40;
        private float _pathPosition = 0;
        private bool _autoDolly = true;

        private CinemachineTrackedDolly _trackedDolly;
        private SceneViewCamera _sceneViewCamera;

        private Transform _followTarget;
        private Transform _lookAtTarget;

        protected override void Awake()
        {
            Cameras = GetComponentsInChildren<CinemachineVirtualCamera>();

            // Dolly Paths and camera
            var _dollyPaths = GetComponentsInChildren<CinemachinePathBase>();
            _registeredDollyPaths.Add("circular", _dollyPaths[0]);
            _registeredDollyPaths.Add("square", _dollyPaths[1]);
            _registeredDollyPaths.Add("custom1", _dollyPaths[2]);
            _trackedDolly = Cameras[1].GetCinemachineComponent<CinemachineTrackedDolly>();
            Debug.Assert(_trackedDolly != null);

            _followTarget = transform.GetChild(2).GetChild(0);
            _lookAtTarget = transform.GetChild(2).GetChild(1);
            ActiveCamera = _activeCamera;
            DollyPath = _dollyPath;
            AutoDolly = _autoDolly;
            FOV = _fov;
            PathPosition = _pathPosition;
            _sceneViewCamera = Cameras[0].GetComponent<SceneViewCamera>();
            if (_sceneViewCamera)
            {
                _sceneViewCamera.Target = _lookAtTarget;
            }
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
        /// Sets the active dolly path's position.
        /// </summary>
        public void SetDollyPathPosition(float x, float y, float z)
        {
            if (_trackedDolly == null) return;

            _trackedDolly.m_Path.transform.position = new Vector3(x, y, z);
        }

        /// <summary>
        /// Sets the active dolly path's scale. Useful for expanding/compressing the path.
        /// </summary>
        public void SetDollyPathScale(float x, float y, float z)
        {
            if (_trackedDolly == null) return;

            _trackedDolly.m_Path.transform.localScale = new Vector3(x, y, z);
        }

        /// <summary>
        /// Creates a new dolly path for the tracked camera. The path is smooth (first and second order continuity is guaranteed).
        /// </summary>
        /// <param name="pathKey">The key of the new dolly path in the paths dictionary.</param>
        /// <param name="waypoints">The waypoints of the path.</param>
        /// <param name="looped">Is the path looped? Defaults to true.</param>
        /// <returns>The created cinemachine path component for the pathKey.</returns>
        public CinemachinePathBase NewSmoothDollyPath(string pathKey, Vector3[] waypoints, bool looped = true)
        {
            if (_registeredDollyPaths.ContainsKey(pathKey))
            {
                Debug.LogError($"There is already a path registered with the key: {pathKey}. Returning that one.");
                return _registeredDollyPaths[pathKey];
            }

            var cmWaypoints = new CinemachineSmoothPath.Waypoint[waypoints.Length];

            for (var i = 0; i < cmWaypoints.Length; i++)
            {
                cmWaypoints[i] = new CinemachineSmoothPath.Waypoint() { position = waypoints[i], roll = 0 };
            }

            var pathObject = new GameObject();
            pathObject.transform.SetParent(transform.GetChild(1));

            var newPath = pathObject.AddComponent<CinemachineSmoothPath>();

            newPath.m_Looped = looped;
            newPath.m_Waypoints = cmWaypoints;

            _registeredDollyPaths.Add(pathKey, newPath);

            return newPath;
        }

        /// <summary>
        /// Creates a new dolly path for the tracked camera. First and second order continuity of the path isn't guaranteed.
        /// </summary>
        /// <param name="pathKey">The key of the new dolly path in the paths dictionary.</param>
        /// <param name="waypoints">The waypoints of the path.</param>
        /// <param name="looped">Is the path looped? Defaults to true.</param>
        /// <returns>The created cinemachine path component for the pathKey.</returns>
        public CinemachinePathBase NewDollyPath(string pathKey, Vector3[] waypoints, bool looped = true)
        {
            if (_registeredDollyPaths.ContainsKey(pathKey))
            {
                Debug.LogError($"There is already a path registered with the key: {pathKey}. Returning that one.");
                return _registeredDollyPaths[pathKey];
            }

            var cmWaypoints = new CinemachinePath.Waypoint[waypoints.Length];

            for (var i = 0; i < cmWaypoints.Length; i++)
            {
                cmWaypoints[i] = new CinemachinePath.Waypoint() { position = waypoints[i], roll = 0 };
            }

            var pathObject = new GameObject();
            pathObject.transform.SetParent(transform.GetChild(1));

            var newPath = pathObject.AddComponent<CinemachinePath>();

            newPath.m_Looped = looped;
            newPath.m_Waypoints = cmWaypoints;

            _registeredDollyPaths.Add(pathKey, newPath);

            return newPath;
        }

        /// <summary>
        /// Checks if a key is registered to a dolly path.
        /// </summary>
        /// <param name="pathKey">The path's key.</param>
        /// <returns>true if it exists, false otherwise.</returns>
        public bool DollyPathKeyExists(string pathKey)
        {
            return _registeredDollyPaths.ContainsKey(pathKey);
        }

        /// <summary>
        /// Returns a cinemachine path from its key.
        /// </summary>
        /// <param name="pathKey">The key of the dolly path.</param>
        /// <returns>The dolly path with that key or null if there is none.</returns>
        public CinemachinePathBase GetDollyPath(string pathKey)
        {
            if (_registeredDollyPaths.ContainsKey(pathKey)) return _registeredDollyPaths[pathKey];

            return null;
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

        private void SetActiveDollyPath(string pathKey)
        {
            if (_trackedDolly == null || Cameras == null || Cameras.Length == 0 || !_registeredDollyPaths.ContainsKey(pathKey))
            {
                return;
            }
            
            _trackedDolly.m_Path = _registeredDollyPaths[pathKey];
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
            _pathPosition = pathPosition;
        }

        private void SetAutoDolly(bool autoDolly)
        {
            if (_trackedDolly == null) return;

            _trackedDolly.m_AutoDolly.m_Enabled = autoDolly;
            _autoDolly = autoDolly;
        }
    }

}