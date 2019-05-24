using System.Collections.Generic;
using UnityEngine;

namespace LuaScripting
{
    public class LuaGroupBehaviour : LuaBehaviour
    {
        public List<GameObject> Members = new List<GameObject>(2);

        protected override void SetEnvironmentSymbols()
        {
            LuaEnvironment.Set("Members", Members);
        }

        
        public void AddMember(GameObject newMember)
        {
            Members.Add(newMember);
        }

        public void RemoveMember(int index)
        {
            Members.RemoveAt(index);
        }
    }
}
