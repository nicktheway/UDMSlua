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
            // Run the Lua garbage collector if needed.
            if (Time.time - _lastGarbageCollectionTime > LuaManager.GarbageCollectionInterval)
            {
                LuaManager.LuaEnv.Tick();
                _lastGarbageCollectionTime = Time.time;
            }
        }
    }
}
