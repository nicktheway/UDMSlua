using System.Collections.Generic;
using UnityEngine;

namespace LuaScripting
{
    /// <summary>
    /// A class used to have preset Lua game objects in a scene.
    /// </summary>
    [DefaultExecutionOrder(-1000)]
    public class LuaRoomPresets : MonoBehaviour
    {
        /// <summary>
        /// List for adding groups via the inspector.
        /// </summary>
        public List<LuaGroupDomain> Groups = new List<LuaGroupDomain>();

        /// <summary>
        /// List for adding individual objects via the inspector.
        /// </summary>
        public List<LuaIndividualObject> Individuals = new List<LuaIndividualObject>();

        public GameObject UI;

        private LuaRoom _luaRoom;

        /// <summary>
        /// List to store the active status of the individual objects.
        /// </summary>
        private readonly List<bool> _activeInitialValues = new List<bool>();

        private void Awake()
        {
            DeActivate();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                UI.SetActive(!UI.activeSelf);
            }
        }

        /// <summary>
        /// Deactivates all the lua individual objects.
        /// </summary>
        public void DeActivate()
        {
            foreach (var luaIndividualObject in Individuals)
            {
                _activeInitialValues.Add(luaIndividualObject.gameObject.activeSelf);
                luaIndividualObject.gameObject.SetActive(false);
            }

            foreach (var luaGroupDomain in Groups)
            {
                foreach (var luaGroupObject in luaGroupDomain.Members)
                {
                    luaGroupObject.gameObject.SetActive(false);
                }
            }
        }

        /// <summary>
        /// Resets the active state of the objects.
        /// </summary>
        public void ResetActiveState()
        {
            for (var i = 0; i < Individuals.Count; i++)
            {
                Individuals[i].gameObject.SetActive(true);
                //Individuals[i].gameObject.SetActive(_activeInitialValues[i]);
            }

            
            foreach (var luaGroupDomain in Groups)
            {
                foreach (var luaGroupObject in luaGroupDomain.Members)
                {
                    luaGroupObject.gameObject.SetActive(true);
                }
            }
        }

        public void AssignRoom(LuaRoom luaRoom)
        {
            _luaRoom = luaRoom;
        }

        public void RedoCameraScript()
        {
            var camera = FindObjectOfType<LuaCameraObject>();
            camera.LuaDomain.RedoLuaScript(true, true, true);
        }

        public void RedoSettingsScript()
        {
            _luaRoom?.RerunRoomSettings();
        }
    }
}
