using System;
using UnityEngine;
using XLua;

namespace LuaScripting
{
    /// <summary>
    /// A component similar to MonoBehaviour that executes Lua scripts.
    /// </summary>
    public class LuaBehaviour : MonoBehaviour
    {
        /// <summary>
        /// The path of the script in the LuaManager.ScriptsBasePath folder.
        /// </summary>
        public string ScriptPath = string.Empty;

        /// <summary>
        /// The lua table which is the environment of this LuaBehaviour. Each LuaBehaviour has a different environment.
        /// </summary>
        public readonly LuaTable LuaEnvironment = LuaManager.LuaEnv.NewTable();

        // Unity Basic Callbacks
        private Action _luaAwake;
        private Action _luaStart;
        private Action _luaUpdate;
        private Action _luaFixedUpdate;
        private Action _luaLateUpdate;
        private Action _luaOnDestroy;
        private Action _luaOnEnable;
        private Action _luaOnDisable;
        private Action<int> _luaOnAnimatorIK;
        private Action _luaOnAnimatorMove;
        private Action _luaOnApplicationQuit;
        private Action<Collision> _luaOnCollisionEnter;
        private Action<Collision> _luaOnCollisionExit;
        private Action<Collision> _luaOnCollisionStay;
        private Action<Collider> _luaOnTriggerEnter;
        private Action<Collider> _luaOnTriggerExit;
        private Action<Collider> _luaOnTriggerStay;

        /// <summary>
        /// The id of the behaviour in the manager's list. Should only be set by the manager.
        /// </summary>
        public int UniqueBehaviourId { get; set; } = -1;

        /// <summary>
        /// Makes symbols available to the lua script.
        /// </summary>
        protected virtual void SetEnvironmentSymbols()
        {
            LuaEnvironment.Set("self", this);
        }

        /// <summary>
        /// Loads symbols from the lua script. Override to load more symbols. Don't forget to call the base function too.
        /// </summary>
        protected virtual void LoadScriptSymbols()
        {
            LuaEnvironment.Get("awake", out _luaAwake);
            LuaEnvironment.Get("start", out _luaStart);
            LuaEnvironment.Get("update", out _luaUpdate);
            LuaEnvironment.Get("fixedUpdate", out _luaFixedUpdate);
            LuaEnvironment.Get("lateUpdate", out _luaLateUpdate);
            LuaEnvironment.Get("onDestroy", out _luaOnDestroy);
            LuaEnvironment.Get("onEnable", out _luaOnEnable);
            LuaEnvironment.Get("onDisable", out _luaOnDisable);
            LuaEnvironment.Get("onAnimatorIK", out _luaOnAnimatorIK);
            LuaEnvironment.Get("onAnimatorMove", out _luaOnAnimatorMove);
            LuaEnvironment.Get("onApplicationQuit", out _luaOnApplicationQuit);
            LuaEnvironment.Get("onCollisionEnter", out _luaOnCollisionEnter);
            LuaEnvironment.Get("onCollisionExit", out _luaOnCollisionExit);
            LuaEnvironment.Get("onCollisionStay", out _luaOnCollisionStay);
            LuaEnvironment.Get("onTriggerEnter", out _luaOnTriggerEnter);
            LuaEnvironment.Get("onTriggerExit", out _luaOnTriggerExit);
            LuaEnvironment.Get("onTriggerStay", out _luaOnTriggerStay);
        }

        /// <summary>
        /// Unloads symbols from the lua script. Override to unload more symbols. Don't forget to call the base function too.
        /// </summary>
        protected virtual void UnloadScriptSymbols()
        {
            _luaAwake = null;
            _luaStart = null;
            _luaUpdate = null;
            _luaFixedUpdate = null;
            _luaLateUpdate = null;
            _luaOnDestroy = null;
            _luaOnEnable = null;
            _luaOnDisable = null;
            _luaOnAnimatorIK = null;
            _luaOnAnimatorMove = null;
            _luaOnApplicationQuit = null;
            _luaOnCollisionEnter = null;
            _luaOnCollisionExit = null;
            _luaOnCollisionStay = null;
            _luaOnTriggerEnter = null;
            _luaOnTriggerExit = null;
            _luaOnTriggerStay = null;
        }

        /// <summary>
        /// Reruns the lua script.
        /// </summary>
        /// <param name="executeAwake">Should the awake() be executed, if there is one?</param>
        /// <param name="executeStart">Should the start() be executed, if there is one?</param>
        protected void RedoLuaScript(bool executeAwake = false, bool executeStart = false)
        {
            UnloadScriptSymbols();

            // Runs the script within the LuaEnvironment.
            LuaManager.DoScript(ScriptPath, LuaEnvironment, ScriptPath);

            // Gets the script's symbols.
            LoadScriptSymbols();

            if (executeAwake)
                _luaAwake?.Invoke();

            if (executeStart)
                _luaStart?.Invoke();
        }

        protected virtual void Awake()
        {
            // Passes symbols to the LuaEnvironment.
            SetEnvironmentSymbols();

            // Attaches the global metatable to the LuaEnvironment.
            LuaManager.AttachGlobalTableAsDefault(LuaEnvironment);

            // Runs the script within the LuaEnvironment.
            LuaManager.DoScript(ScriptPath, LuaEnvironment, ScriptPath);

            // Gets the script's symbols.
            LoadScriptSymbols();

            // Runs script's awake() if there is one.
            _luaAwake?.Invoke();
        }

        protected virtual void Start()
        {
            _luaStart?.Invoke();
        }

        public virtual void OnUpdate()
        {
            _luaUpdate?.Invoke();
        }

        public virtual void OnFixedUpdate()
        {
            _luaFixedUpdate?.Invoke();
        }

        public virtual void OnLateUpdate()
        {
            _luaLateUpdate?.Invoke();
        }

        protected virtual void OnAnimatorIK(int layerIndex)
        {
            _luaOnAnimatorIK?.Invoke(layerIndex);
        }

        protected virtual void OnAnimatorMove()
        {
            _luaOnAnimatorMove?.Invoke();
        }

        protected virtual void OnApplicationQuit()
        {
            _luaOnApplicationQuit?.Invoke();
        }

        protected virtual void OnCollisionEnter(Collision collision)
        {
            _luaOnCollisionEnter?.Invoke(collision);
        }

        protected virtual void OnCollisionExit(Collision collision)
        {
            _luaOnCollisionExit?.Invoke(collision);
        }

        protected virtual void OnCollisionStay(Collision collision)
        {
            _luaOnCollisionStay?.Invoke(collision);
        }

        protected virtual void OnDestroy()
        {
            _luaOnDestroy?.Invoke();

            // UnloadScriptSymbols();
        }

        protected virtual void OnDisable()
        {
            // Unregister the LuaBehaviour to the manager.
            LuaManager.UnregisterBehaviour(this);

            _luaOnDisable?.Invoke();
        }

        protected virtual void OnEnable()
        {
            // Register the LuaBehaviour to the manager.
            UniqueBehaviourId = LuaManager.RegisterBehaviour(this);

            _luaOnEnable?.Invoke();
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            _luaOnTriggerEnter?.Invoke(other);
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            _luaOnTriggerExit?.Invoke(other);
        }

        protected virtual void OnTriggerStay(Collider other)
        {
            _luaOnTriggerStay?.Invoke(other);
        }
    }
}
