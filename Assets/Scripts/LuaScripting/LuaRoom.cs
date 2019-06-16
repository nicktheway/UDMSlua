using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

namespace LuaScripting
{
    /// <summary>
    /// LuaRoom is a class that sets up a Scene and manages LuaDomains inside the scene.
    /// </summary>
    [DefaultExecutionOrder(-1000)]
    public class LuaRoom : MonoBehaviour
    {
        public string RoomName = string.Empty;

        public string RoomScriptPath { get; private set; }

        // TODO: Move to using asset bundles.
        /// <summary>
        /// The room's scene. If there is no scene with this name, a new scene will be created.
        /// </summary>
        public string SceneName;

        /// <summary>
        /// The room's settings domain. Contains a table with the non-local variables and functions of the settings.lua script of the room.
        /// </summary>
        [HideInInspector] public LuaDomain RoomSettings;

        /// <summary>
        /// A list that contains the registered LuaDomains of the room.
        /// </summary>
        public readonly List<LuaDomain> RegisteredDomains = new List<LuaDomain>();

#if UNITY_EDITOR
        // For inspector debugging.
        public List<LuaDomain> _registeredDomains;
#endif

        /// <summary>
        /// The available lua groups in the room.
        /// </summary>
        public readonly Dictionary<string, LuaGroupDomain> Groups = new Dictionary<string, LuaGroupDomain>();

        /// <summary>
        /// List for adding groups via the inspector.
        /// </summary>
        [SerializeField] private List<LuaGroupDomain> _groups = new List<LuaGroupDomain>();

        public void CreateLuaGameObject()
        {

        }

        public void RerunRoomSettings()
        {
            RoomSettings.RedoLuaScript(true, true);
        }

        private void Awake()
        {
            // Set the room's script path.
            RoomScriptPath = Path.Combine(LuaManager.ScriptsBasePath, RoomName);

            // Create the settings domain and run the script.
            RoomSettings = LuaDomain.NewLuaDomain(Path.Combine(RoomScriptPath, "settings.lua"), this);
            RoomSettings.LuaEnvironment.Set("self", gameObject);
            RoomSettings.DoScript();

            // Create the group domains specified in the inspector.
            foreach (var group in _groups)
            {
                group.AssignRoom(this);
                AddGroupDomain(group);
                RunGroupDomain(group.GroupName);
            }

            // Create/Assign the domain of each individual lua object.
            // TODO: remove find, do it with a pattern.
            foreach (var luaGameObject in FindObjectsOfType<LuaGameObject>())
            {
                if (luaGameObject is LuaIndividualObject luaIndividualObject)
                {
                    luaIndividualObject.LuaDomain =
                        LuaIndividualDomain.NewIndividualDomain(luaIndividualObject.ScriptPath, luaIndividualObject, this);

                    luaIndividualObject.LuaDomain.Enabled = luaIndividualObject.enabled;

                    luaIndividualObject.LuaDomain.AssignRoom(this);
                }
            }

            // Add, run and call the awake() for all the groups.
            foreach (var groupKeyValuePair in Groups)
            {
                groupKeyValuePair.Value.LuaAwake?.Invoke();
            }
        }

        private void Start()
        {
            // Run the start function of the groups.
            foreach (var luaDomain in RegisteredDomains)
            {
                if (luaDomain.Enabled && luaDomain is LuaGroupDomain)
                    luaDomain.LuaStart?.Invoke();
            }
        }

        private void Update()
        {
            // Run the OnUpdate function for every luaDomain in the room.
            foreach (var luaDomain in RegisteredDomains)
            {
                if (luaDomain.Enabled)
                    luaDomain.LuaUpdate?.Invoke();
            }

#if UNITY_EDITOR
            _registeredDomains = RegisteredDomains;
#endif
        }

        private void FixedUpdate()
        {
            // Run the OnFixedUpdate function for every luaDomain in the room.
            foreach (var luaDomain in RegisteredDomains)
            {
                if (luaDomain.Enabled)
                    luaDomain.LuaFixedUpdate?.Invoke();
            }
        }

        private void LateUpdate()
        {
            // Run the OnLateUpdate function for every luaDomain in the room.
            foreach (var luaDomain in RegisteredDomains)
            {
                if (luaDomain.Enabled)
                    luaDomain.LuaLateUpdate?.Invoke();
            }
        }

        /// <summary>
        /// Registers a LuaDomain to the room.
        /// </summary>
        /// <param name="domain">The lua domain.</param>
        /// <returns>The id of the newly registered domain.</returns>
        public int RegisterDomain(LuaDomain domain)
        {
            RegisteredDomains.Add(domain);

            return RegisteredDomains.Count - 1;
        }

        /// <summary>
        /// Unregisters a LuaDomain from the room.
        /// </summary>
        /// <param name="domain">The lua domain.</param>
        public void UnregisterDomain(LuaDomain domain)
        {
            // Where is the last element?
            var lastId = RegisteredDomains.Count - 1;

            // If there is not only one element in the list.
            if (lastId > 0)
            {
                // Overwrite the element to be removed by the last.
                RegisteredDomains[domain.UniqueDomainId] = RegisteredDomains[lastId];
                // Update its id.
                RegisteredDomains[domain.UniqueDomainId].UniqueDomainId = domain.UniqueDomainId;
            }
                
            // Remove the last element which will be either the only element or a duplicate element.
            RegisteredDomains.RemoveAt(lastId);
        }

        /// <summary>
        /// Creates a new group and adds it to the group domain dictionary. Does not run the domain.
        /// </summary>
        /// <param name="groupName">The name of the group. Must be unique in the room.</param>
        /// <param name="groupScriptPath">The path of the script that will control the group.</param>
        public void AddGroupDomain(string groupName, string groupScriptPath)
        {
            var newGroup = LuaGroupDomain.NewGroupDomain(groupName, groupScriptPath, this);

            AddGroupDomain(newGroup);
        }


        /// <summary>
        /// Adds a group domain to the group domain dictionary. Does not run the domain.
        /// </summary>
        /// <param name="group">The group domain to be added.</param>
        public void AddGroupDomain(LuaGroupDomain group)
        {
            if (Groups.ContainsKey(group.GroupName))
            {
                Debug.LogError($"A group with the name {group.GroupName} already exists.");
            }

            Groups.Add(group.GroupName, group);
        }

        /// <summary>
        /// Runs a group domain.
        /// </summary>
        /// <param name="groupDomainName"></param>
        public void RunGroupDomain(string groupDomainName)
        {
            var luaGroup = Groups[groupDomainName];

            luaGroup.InitializeMembers();
            luaGroup.DoScript();
        }

        /// <summary>
        /// Executes a lua script in the room's path inside a lua table.
        /// </summary>
        /// This function will execute the specified script inside the specified environment table, essentially setting all the variables
        /// and functions defined as key-value elements on the specified environment table.
        /// 
        /// <param name="path">The path of the script relative to the room's folder.</param>
        /// <param name="environment">The lua table in which the script will run.</param>
        /// <param name="debugName">A friendly name that will be used for errors/warnings on the script.</param>
        public void RunScriptInRoom(string path, LuaTable environment, string debugName)
        {
            LuaManager.DoScript(Path.Combine(RoomScriptPath, path), environment, debugName);
        }
    }
}
