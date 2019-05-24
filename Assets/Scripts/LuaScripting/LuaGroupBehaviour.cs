using System.Collections.Generic;
using UnityEngine;

namespace LuaScripting
{
    public class LuaGroupBehaviour : LuaBehaviour
    {
        /// <summary>
        /// The members of the group.
        /// </summary>
        public List<GameObject> Members = new List<GameObject>(2);

        protected override void SetEnvironmentSymbols()
        {
            LuaEnvironment.Set("Group", this);
            LuaEnvironment.Set("Members", Members);
        }

        protected override void Awake()
        {
            // Set up members added from the inspector.
            foreach (var member in Members)
            {
                SetUpGroupMember(member);
            }

            base.Awake();
        }
        
        /// <summary>
        /// Add a new member to the group.
        /// </summary>
        /// <param name="newMember"></param>
        public void AddMember(GameObject newMember)
        {
            SetUpGroupMember(newMember);
            Members.Add(newMember);
        }

        /// <summary>
        /// Remove a member from the group.
        /// </summary>
        /// <param name="member"></param>
        public void RemoveMember(GameObject member)
        {
            Members.Remove(member);
        }

        /// <summary>
        /// Make sure the member knows it belongs in the group.
        /// </summary>
        /// <param name="member">A member of the group.</param>
        public void SetUpGroupMember(GameObject member)
        {
            var element = member.GetComponent<LuaGroupElement>();

            if (element == null)
            {
                element = member.AddComponent<LuaGroupElement>();
            }

            element.GroupBehaviour = this;
        }
    }
}
