using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

namespace LuaScripting
{
    [CSharpCallLua]
    public delegate void IntAction(int obj);

    [CSharpCallLua]
    public delegate void IntIntAction(int obj, int obj2);

    [CSharpCallLua]
    public delegate void CollisionAction(Collision collision);

    [CSharpCallLua]
    public delegate void CollisionIntAction(Collision collision, int obj);

    [CSharpCallLua]
    public delegate void ColliderAction(Collider collider);

    [CSharpCallLua]
    public delegate void ColliderIntAction(Collider collider, int obj);

    /// <summary>
    /// A static class managing the Lua environment of the project.
    /// </summary>
    public static class LuaManager
    {
        /// <summary>
        /// The parent folder that contains all the lua scripts of the project.
        /// </summary>
        public static readonly string ScriptsBasePath = Application.streamingAssetsPath + "/Scripts";

        /// <summary>
        /// The period of the LuaEnv garbage collection in seconds.
        /// </summary>
        public const float GarbageCollectionInterval = 1f;

        /// <summary>
        /// The project's Lua environment.
        /// </summary>
        public static readonly LuaEnv LuaEnv = new LuaEnv();

        public static LuaTable SettingsLuaEnvironment;

        /// <summary>
        /// A list that contains the enabled LuaDomain components of the scene and calls their Update functions.
        /// </summary>
        public static readonly List<LuaDomain> RegisteredBehaviourList = new List<LuaDomain>();

        /// <summary>
        /// The available lua groups.
        /// </summary>
        public static readonly Dictionary<string, LuaGroupDomain> LuaGroups = new Dictionary<string, LuaGroupDomain>();

        /// <summary>
        /// Registers a LuaDomain to the manager.
        /// </summary>
        /// <param name="behaviour">The lua behaviour.</param>
        /// <returns>The id of the newly registered behaviour.</returns>
        public static int RegisterBehaviour(LuaDomain behaviour)
        {
            RegisteredBehaviourList.Add(behaviour);

            return RegisteredBehaviourList.Count - 1;
        }

        /// <summary>
        /// Unregisters a LuaDomain from the manager.
        /// </summary>
        /// <param name="behaviour">The lua behaviour.</param>
        public static void UnregisterBehaviour(LuaDomain behaviour)
        {
            // Where is the last element?
            var lastId = RegisteredBehaviourList.Count - 1;

            // If there is not only one element in the list.
            if (lastId > 0)
            {
                // Overwrite the element to be removed by the last.
                RegisteredBehaviourList[behaviour.UniqueBehaviourId] = RegisteredBehaviourList[lastId];
                // Update its id.
                RegisteredBehaviourList[behaviour.UniqueBehaviourId].UniqueBehaviourId = behaviour.UniqueBehaviourId;
            }
                
            // Remove the last element which will be either the only element or a duplicate element.
            RegisteredBehaviourList.RemoveAt(lastId);
        }


        /// <summary>
        /// Adds a group domain to the group domain dictionary. Does not run the domain.
        /// </summary>
        /// <param name="group">The group domain to be added.</param>
        public static void AddGroupDomain(LuaGroupDomain group)
        {
            if (LuaGroups.ContainsKey(group.GroupName))
            {
                Debug.LogError($"A group with the name {group.GroupName} already exists.");
            }

            LuaGroups.Add(group.GroupName, group);
        }

        /// <summary>
        /// Runs a group domain.
        /// </summary>
        /// <param name="groupDomainName"></param>
        public static void RunGroupDomain(string groupDomainName)
        {
            var luaGroup = LuaGroups[groupDomainName];

            luaGroup.InitializeMemberIds();
            luaGroup.DoScript();
            RegisterBehaviour(luaGroup);
        }

        /// <summary>
        /// Attaches a metatable to the argument with LuaEnv.Global as the __index metamethod.
        /// </summary>
        /// 
        /// The CS table, print(), typeof(), etc are inside LuaEnv.Global so if you need to use them inside a table, calling this method beforehand is advised.
        /// 
        /// The __index metamethod's table provides default keys that are used when accessing a key that is not in the table.
        ///
        /// Therefore, by defining this metatable is something like setting the all the keys that are inside LuaEnv.Global.
        /// Alternatively, you can set only the keys you want without the metatable as it is shown bellow:
        /// 
        /// LuaEnv.Global.Get("CS", out LuaTable cs);
        /// LuaEnv.Global.Get("print", out LuaFunction printFunc);
        /// LuaEnv.Global.Get("typeof", out LuaFunction typeofFunc);
        /// table.Set("CS", cs);
        /// table.Set("print", printFunc);
        /// table.Set("typeof", typeofFunc);
        /// 
        /// <param name="table">The table where the meta-table will be attached to.</param>
        public static void AttachGlobalTableAsDefault(LuaTable table)
        {
            // Create a new table to serve as a meta-table.
            var meta = LuaEnv.NewTable();
            // Add the Global lua table as the __index meta-method.
            meta.Set("__index", LuaEnv.Global);
            // Set the meta-table to the table.
            table.SetMetaTable(meta);

            // Dispose the new table as it is no longer needed.
            meta.Dispose();
        }

        /// <summary>
        /// Executes a lua script inside a lua table.
        /// </summary>
        /// This function will execute the specified script inside the specified environment table, essentially setting all the variables
        /// and functions defined as key-value elements on the specified environment table.
        /// 
        /// <param name="path">The path of the script relative to the GameManager.ScriptsBasePath folder.</param>
        /// <param name="environment">The lua table in which the script will run.</param>
        /// <param name="debugName">A friendly name that will be used for errors/warnings on the script.</param>
        public static void DoScript(string path, LuaTable environment, string debugName = "chunk")
        {
            var filePath = Path.Combine(ScriptsBasePath, path);

            if (File.Exists(filePath))
            {
                var text = File.ReadAllText(filePath);
            
                LuaEnv.DoString(text, debugName, environment);
            }
            else
            {
                Debug.LogWarning($"File {filePath} does not exist.");
            }
        }

        /// <summary>
        /// This function will dispose the globally used lua environment. You shouldn't need it unless you need to change to another Lua environment
        /// or don't need to use anything related to this environment anymore.
        /// </summary>
        public static void DisposeTheLuaEnv()
        {
            LuaEnv.Dispose();
        }
    }
}
