using System.Collections.Generic;
using UnityEngine;

namespace LuaScripting
{
    public class LuaGroupBehaviour : LuaBehaviour
    {
        [SerializeField] private int _groupId;

        public int GroupID => _groupId;

        public List<GameObject> Members = new List<GameObject>(2);

        protected override void SetEnvironmentSymbols()
        {
            LuaEnvironment.Set("Members", Members);
        }
    }
}
