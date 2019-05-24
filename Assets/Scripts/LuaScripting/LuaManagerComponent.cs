using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace LuaScripting
{
    /// <summary>
    /// This class act like a bridge to the LuaManager class and unity callbacks.
    /// </summary>
    public class LuaManagerComponent : MonoBehaviour
    {
        /// <summary>
        /// The last time Lua Environment's garbage collector run.
        /// </summary>
        private static float _lastGarbageCollectionTime;

        private static int _activeInstances;

#if UNITY_EDITOR
        // To be able to see the list on the inspector.
        [SerializeField] private List<LuaBehaviour> _managedBehaviourList;
#endif

        private void Awake()
        {
            _activeInstances++;
        }

        private void Start()
        {
            Assert.AreEqual(_activeInstances, 1, "There must be only one LuaManagerComponent in the scene.");
        }

        private void Update()
        {
            // Run the OnUpdate function for every LuaBehaviour in the scene.
            foreach (var luaBehaviour in LuaManager.RegisteredBehaviourList)
            {
                luaBehaviour.OnUpdate();
            }

            // Run the Lua garbage collector if needed.
            if (Time.time - _lastGarbageCollectionTime > LuaManager.GarbageCollectionInterval)
            {
                LuaManager.LuaEnv.Tick();
                _lastGarbageCollectionTime = Time.time;
            }

#if UNITY_EDITOR
            // To be able to see the list on the inspector.
            _managedBehaviourList = LuaManager.RegisteredBehaviourList;
#endif
        }

        private void FixedUpdate()
        {
            // Run the OnFixedUpdate function for every LuaBehaviour in the scene.
            foreach (var luaBehaviour in LuaManager.RegisteredBehaviourList)
            {
                luaBehaviour.OnFixedUpdate();
            }
        }

        private void LateUpdate()
        {
            // Run the OnLateUpdate function for every LuaBehaviour in the scene.
            foreach (var luaBehaviour in LuaManager.RegisteredBehaviourList)
            {
                luaBehaviour.OnLateUpdate();
            }
        }
    }
}
