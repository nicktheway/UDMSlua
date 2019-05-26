using System;
using UnityEngine;

namespace LuaScripting
{
    public class LuaIndividualObject : LuaGameObject
    {
        [SerializeField] private string _scriptPath = string.Empty;

        private LuaIndividualDomain _luaIndividualScript;

        public override LuaDomain LuaDomain { get => _luaIndividualScript; set => _luaIndividualScript = (LuaIndividualDomain) value; }

        protected virtual void Awake()
        {
            _luaIndividualScript = LuaIndividualDomain.NewIndividualDomain(_scriptPath, this);

            _luaIndividualScript.LuaAwake?.Invoke();
        }

        protected virtual void Start()
        {
            _luaIndividualScript.LuaStart?.Invoke();
        }

        protected virtual void OnEnable()
        {
            if (_luaIndividualScript == null)
                _luaIndividualScript = LuaIndividualDomain.NewIndividualDomain(_scriptPath, this);

            _luaIndividualScript.UniqueBehaviourId = LuaManager.RegisterBehaviour(LuaDomain);
            _luaIndividualScript.LuaOnEnable?.Invoke();
        }

        protected virtual void OnDisable()
        {
            LuaManager.UnregisterBehaviour(LuaDomain);
            _luaIndividualScript.LuaOnDisable?.Invoke();
        }

        protected virtual void OnDestroy()
        {
            _luaIndividualScript.LuaOnDestroy?.Invoke();
        }

        protected override void OnCollisionEnter(Collision collision)
        {
            _luaIndividualScript.LuaOnCollisionEnter?.Invoke(collision);
        }

        protected override void OnCollisionExit(Collision collision)
        {
            _luaIndividualScript.LuaOnCollisionExit?.Invoke(collision);
        }

        protected override void OnCollisionStay(Collision collision)
        {
            _luaIndividualScript.LuaOnCollisionStay?.Invoke(collision);
        }

        protected override void OnTriggerEnter(Collider other)
        {
            _luaIndividualScript.LuaOnTriggerEnter?.Invoke(other);
        }

        protected override void OnTriggerExit(Collider other)
        {
            _luaIndividualScript.LuaOnTriggerExit?.Invoke(other);
        }

        protected override void OnTriggerStay(Collider other)
        {
            _luaIndividualScript.LuaOnTriggerStay?.Invoke(other);
        }

        protected override void OnAnimatorIK(int layerIndex)
        {
            _luaIndividualScript.LuaOnAnimatorIK?.Invoke(layerIndex);
        }

        protected override void OnAnimatorMove()
        {
            _luaIndividualScript.LuaOnAnimatorMove?.Invoke();
        }

        protected virtual void OnApplicationQuit()
        {
            _luaIndividualScript.LuaOnApplicationQuit?.Invoke();
        }
    }
}
