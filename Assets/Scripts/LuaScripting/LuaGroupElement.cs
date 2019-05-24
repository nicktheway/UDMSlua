using UnityEngine;

namespace LuaScripting
{
    /// <summary>
    /// A component for gameObjects managed by a LuaGroupBehaviour.
    /// </summary>
    public class LuaGroupElement : MonoBehaviour
    {
        // The lua group behaviour that manages this object.
        public LuaGroupBehaviour GroupBehaviour;

        public int GroupMemberId { get; set; } = -1;

        private void OnDestroy()
        {
            GroupBehaviour.RemoveMember(gameObject);
        }

        private void OnAnimatorIK(int layer)
        {
            GroupBehaviour.OnElementAnimatorIK(layer, GroupMemberId);
        }

        protected virtual void OnCollisionEnter(Collision collision)
        {
            GroupBehaviour.OnElementCollisionEnter(collision, GroupMemberId);
        }

        protected virtual void OnCollisionExit(Collision collision)
        {
            GroupBehaviour.OnElementCollisionExit(collision, GroupMemberId);
        }

        protected virtual void OnCollisionStay(Collision collision)
        {
            GroupBehaviour.OnElementCollisionStay(collision, GroupMemberId);
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            GroupBehaviour.OnElementTriggerEnter(other, GroupMemberId);
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            GroupBehaviour.OnElementTriggerExit(other, GroupMemberId);
        }

        protected virtual void OnTriggerStay(Collider other)
        {
            GroupBehaviour.OnElementTriggerStay(other, GroupMemberId);
        }
    }
}
