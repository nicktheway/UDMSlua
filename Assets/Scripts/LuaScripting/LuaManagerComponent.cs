using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace LuaScripting
{
    /// <summary>
    /// This class act like a bridge to the LuaManager class and unity callbacks.
    /// </summary>
    [DefaultExecutionOrder(-9999)]
    public class LuaManagerComponent : MonoBehaviour
    {
        /// <summary>
        /// The last time Lua Environment's garbage collector run.
        /// </summary>
        private static float _lastGarbageCollectionTime;

        private static int _activeInstances;


        [SerializeField] private List<LuaGroupDomain> _groups = new List<LuaGroupDomain>();
#if UNITY_EDITOR
        // To be able to see the list on the inspector.
        [SerializeField] private List<LuaDomain> _managedBehaviourList;
#endif

        private void Awake()
        {
            _activeInstances++;
            foreach (var group in _groups)
            {
                LuaManager.AddGroupDomain(group);
                
                LuaManager.RunGroupDomain(group.GroupName);
                group.LuaAwake?.Invoke();
            }
        }

        private void Start()
        {
            Assert.AreEqual(_activeInstances, 1, "There must be only one LuaManagerComponent in the scene.");

            // TODO: Separate settings to run before everything and register there/or a settings c# class singleton and binding.
            LuaManager.SettingsLuaEnvironment = GetComponent<LuaIndividualObject>().LuaDomain.LuaEnvironment;
            foreach (var luaBehaviour in LuaManager.RegisteredBehaviourList)
            {
                luaBehaviour.LuaEnvironment.Set("Settings", LuaManager.SettingsLuaEnvironment);
            }

            foreach (var group in _groups)
            {
                group.LuaStart?.Invoke();
                group.LuaEnvironment.Set("Settings", LuaManager.SettingsLuaEnvironment);
            }
        }

        private void Update()
        {
            // Run the OnUpdate function for every LuaBehaviour in the scene.
            foreach (var luaBehaviour in LuaManager.RegisteredBehaviourList)
            {
                luaBehaviour.LuaUpdate?.Invoke();
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
                luaBehaviour.LuaFixedUpdate?.Invoke();
            }
        }

        private void LateUpdate()
        {
            // Run the OnLateUpdate function for every LuaBehaviour in the scene.
            foreach (var luaBehaviour in LuaManager.RegisteredBehaviourList)
            {
                luaBehaviour.LuaLateUpdate?.Invoke();
            }
        }
    }
}
