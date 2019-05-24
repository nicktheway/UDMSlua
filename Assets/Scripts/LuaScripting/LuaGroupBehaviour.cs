using System.Collections.Generic;
using UnityEngine;

namespace LuaScripting
{
    /// <summary>
    /// A class that manages a group of objects via one lua script. Awake/Start/[..]Update callbacks are unique for the whole group.
    /// There are also individual callbacks for each member of the group.
    /// </summary>
    public class LuaGroupBehaviour : LuaBehaviour
    {
        /// <summary>
        /// The members of the group.
        /// </summary>
        public List<GameObject> Members = new List<GameObject>(2);

        // Unity Callbacks.
        private IntIntAction _luaOnElementAnimatorIK;
        private CollisionIntAction _luaOnElementCollisionEnter;
        private CollisionIntAction _luaOnElementCollisionExit;
        private CollisionIntAction _luaOnElementCollisionStay;
        private ColliderIntAction _luaOnElementTriggerEnter;
        private ColliderIntAction _luaOnElementTriggerExit;
        private ColliderIntAction _luaOnElementTriggerStay;

        protected override void SetEnvironmentSymbols()
        {
            LuaEnvironment.Set("Group", this);
            LuaEnvironment.Set("Members", Members);
        }

        protected override void LoadScriptSymbols()
        {
            base.LoadScriptSymbols();

            LuaEnvironment.Get("onElementAnimatorIK", out _luaOnElementAnimatorIK);
            LuaEnvironment.Get("onElementCollisionEnter", out _luaOnElementCollisionEnter);
            LuaEnvironment.Get("onElementCollisionExit", out _luaOnElementCollisionExit);
            LuaEnvironment.Get("onElementCollisionStay", out _luaOnElementCollisionStay);
            LuaEnvironment.Get("onElementTriggerEnter", out _luaOnElementTriggerEnter);
            LuaEnvironment.Get("onElementTriggerExit", out _luaOnElementTriggerExit);
            LuaEnvironment.Get("onElementTriggerStay", out _luaOnElementTriggerStay);
        }

        protected override void UnloadScriptSymbols()
        {
            base.UnloadScriptSymbols();

            _luaOnElementAnimatorIK = null;
            _luaOnElementCollisionEnter = null;
            _luaOnElementCollisionExit = null;
            _luaOnElementCollisionStay = null;
            _luaOnElementTriggerEnter = null;
            _luaOnElementTriggerExit = null;
            _luaOnElementTriggerStay = null;
        }

        protected override void Awake()
        {
            // Set up members added from the inspector.
            for (var i = 0; i < Members.Count; i++)
            {
                SetUpGroupMember(Members[i], i);
            }

            base.Awake();
        }

        public virtual void OnElementAnimatorIK(int layer, int id)
        {
            _luaOnElementAnimatorIK?.Invoke(layer, id);
        }

        public virtual void OnElementCollisionEnter(Collision collision, int id)
        {
            _luaOnElementCollisionEnter?.Invoke(collision, id);
        }

        public virtual void OnElementCollisionStay(Collision collision, int id)
        {
            _luaOnElementCollisionStay?.Invoke(collision, id);
        }

        public virtual void OnElementCollisionExit(Collision collision, int id)
        {
            _luaOnElementCollisionExit?.Invoke(collision, id);
        }

        public virtual void OnElementTriggerEnter(Collider other, int id)
        {
            _luaOnElementTriggerEnter?.Invoke(other, id);
        }

        public virtual void OnElementTriggerStay(Collider other, int id)
        {
            _luaOnElementTriggerStay?.Invoke(other, id);
        }

        public virtual void OnElementTriggerExit(Collider other, int id)
        {
            _luaOnElementTriggerExit?.Invoke(other, id);
        }

        
        /// <summary>
        /// Add a new member to the group.
        /// </summary>
        /// <param name="newMember"></param>
        public void AddMember(GameObject newMember)
        {
            Members.Add(newMember);
            SetUpGroupMember(newMember, Members.Count - 1);
        }

        /// <summary>
        /// Remove a member from the group.
        /// </summary>
        /// <param name="member"></param>
        public void RemoveMember(GameObject member)
        {
            var element = member.GetComponent<LuaGroupElement>();

            // Where is the last element?
            var lastId = Members.Count - 1;

            // If there is not only one element in the list.
            if (lastId > 0)
            {
                // Overwrite the element to be removed by the last.
                Members[element.GroupMemberId] = Members[lastId];
                // Update its id.
                Members[element.GroupMemberId].GetComponent<LuaGroupElement>().GroupMemberId = element.GroupMemberId;
            }
                
            // Remove the last element which will be either the only element or a duplicate element.
            Members.RemoveAt(lastId);
        }

        /// <summary>
        /// Make sure the member knows it belongs in the group.
        /// </summary>
        /// <param name="member">A member of the group.</param>
        /// <param name="id">The index of the member in the group.</param>
        public void SetUpGroupMember(GameObject member, int id)
        {
            var element = member.GetComponent<LuaGroupElement>();

            if (element == null)
            {
                element = member.AddComponent<LuaGroupElement>();
            }

            element.GroupBehaviour = this;
            element.GroupMemberId = id;
        }
    }
}
