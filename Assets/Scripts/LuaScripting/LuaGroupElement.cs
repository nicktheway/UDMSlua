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

        private void OnDestroy()
        {
            GroupBehaviour.RemoveMember(gameObject);
        }
    }
}
