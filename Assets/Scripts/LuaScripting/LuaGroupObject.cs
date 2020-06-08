using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;
using XLua;

namespace LuaScripting
{
    [LuaCallCSharp]
    public partial class LuaGroupObject : LuaGameObject
    {
        public int GroupMemberId { get; set; } = -1;
        public List<int> Neighbours = new List<int>();

        private LuaGroupDomain _luaGroupScript;
        public override LuaDomain LuaDomain { get => _luaGroupScript; set => _luaGroupScript = (LuaGroupDomain) value; }

        protected virtual void Awake()
        {
            Assert.IsNotNull(_luaGroupScript);
        }

        protected virtual void OnDestroy()
        {
            _luaGroupScript.RemoveMember(this);
        }

        protected override void OnCollisionEnter(Collision collision)
        {
            _luaGroupScript.LuaOnElementCollisionEnter?.Invoke(collision, GroupMemberId);
        }

        protected override void OnCollisionExit(Collision collision)
        {
            _luaGroupScript.LuaOnElementCollisionExit?.Invoke(collision, GroupMemberId);
        }

        protected override void OnCollisionStay(Collision collision)
        {
            _luaGroupScript.LuaOnElementCollisionStay?.Invoke(collision, GroupMemberId);
        }

        protected override void OnTriggerEnter(Collider other)
        {
            _luaGroupScript.LuaOnElementTriggerEnter?.Invoke(other, GroupMemberId);
        }

        protected override void OnTriggerExit(Collider other)
        {
            _luaGroupScript.LuaOnElementTriggerExit?.Invoke(other, GroupMemberId);
        }

        protected override void OnTriggerStay(Collider other)
        {
            _luaGroupScript.LuaOnElementTriggerStay?.Invoke(other, GroupMemberId);
        }

        protected override void OnAnimatorIK(int layerIndex)
        {
            _luaGroupScript.LuaOnElementAnimatorIK?.Invoke(layerIndex, GroupMemberId);
        }

        protected override void OnAnimatorMove()
        {
            _luaGroupScript.LuaOnElementAnimatorMove?.Invoke(GroupMemberId);
        }
    }
}
