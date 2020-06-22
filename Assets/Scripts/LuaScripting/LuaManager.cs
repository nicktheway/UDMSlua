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

        /// <summary>
        /// Attaches a metatable to the argument with LuaEnv.Global as the __index metamethod.
        /// </summary>
        /// 
        /// The CS table, print(), typeof(), etc are inside LuaEnv.Global so if you need to use them inside a table, calling this method beforehand is advised.
        /// 
        /// The __index metamethod's table provides default keys that are used when accessing a key that is not in the table.
        ///
        /// Therefore, by defining this metatable is something like setting all the keys that are inside LuaEnv.Global.
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
        /// Executes a lua string inside a lua table.
        /// </summary>
        /// This function will execute the specified string inside the specified environment table, essentially setting all the variables
        /// and functions defined as key-value elements on the specified environment table.
        /// 
        /// <param name="scriptlet">The lua code string to run.</param>
        /// <param name="environment">The lua table in which the string will run.</param>
        /// <param name="debugName">A friendly name that will be used for errors/warnings on the script.</param> 
        /// <returns>List of returned values.</returns> 
        public static object[] DoString(string scriptlet, LuaTable environment, string debugName = "chunk")
        {
            return LuaEnv.DoString(scriptlet, debugName, environment);
        }

        /// <summary>
        /// This function will dispose the globally used lua environment. You shouldn't need it unless you need to change to another Lua environment
        /// or don't need to use anything related to this environment anymore.
        /// </summary>
        public static void DisposeTheLuaEnv()
        {
            // TODO: Dispose the rooms.
            
            LuaEnv.Dispose();
        }
    }
}
