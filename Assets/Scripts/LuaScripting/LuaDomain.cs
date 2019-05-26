using System;
using System.Collections.Generic;
using XLua;

namespace LuaScripting
{
    /// <summary>
    /// Lua environment for game objects.
    /// </summary>
    [Serializable]
    public class LuaDomain
    {
        /// <summary>
        /// The path of the script in the LuaManager.ScriptsBasePath folder.
        /// </summary>
        public string ScriptPath = string.Empty;

        /// <summary>
        /// The lua table which is the environment of this LuaBehaviour. Each LuaBehaviour has a different environment.
        /// </summary>
        public readonly LuaTable LuaEnvironment = LuaManager.LuaEnv.NewTable();

        /// <summary>
        /// The id of the behaviour in the manager's list. Should only be set by the manager.
        /// </summary>
        public int UniqueBehaviourId { get; set; } = -1;

        // Unity Basic Callbacks
        public Action LuaAwake;
        public Action LuaStart;
        public Action LuaUpdate;
        public Action LuaFixedUpdate;
        public Action LuaLateUpdate;
        public Action LuaOnDestroy;
        public Action LuaOnApplicationQuit;

        /// <summary>
        /// Loads symbols from the lua script. Override to load more symbols. Don't forget to call the base function too.
        /// </summary>
        public virtual void LoadScriptSymbols()
        {
            LuaEnvironment.Get("awake", out LuaAwake);
            LuaEnvironment.Get("start", out LuaStart);
            LuaEnvironment.Get("update", out LuaUpdate);
            LuaEnvironment.Get("fixedUpdate", out LuaFixedUpdate);
            LuaEnvironment.Get("lateUpdate", out LuaLateUpdate);
            LuaEnvironment.Get("onDestroy", out LuaOnDestroy);
            LuaEnvironment.Get("onApplicationQuit", out LuaOnApplicationQuit);
        }

        /// <summary>
        /// Unloads symbols from the lua script. Override to unload more symbols. Don't forget to call the base function too.
        /// </summary>
        public virtual void UnloadScriptSymbols()
        {
            LuaAwake = null;
            LuaStart = null;
            LuaUpdate = null;
            LuaFixedUpdate = null;
            LuaLateUpdate = null;
            LuaOnDestroy = null;
            LuaOnApplicationQuit = null;
        }

        /// <summary>
        /// Makes symbols available to the lua script.
        /// </summary>
        protected virtual void SetEnvironmentSymbols()
        {
            // Attaches the global metatable to the LuaEnvironment.
            LuaManager.AttachGlobalTableAsDefault(LuaEnvironment);
        }

        /// <summary>
        /// Executes the Lua script inside the environment and loads the script's symbols.
        /// </summary>
        public virtual void DoScript()
        {
            SetEnvironmentSymbols();

            LuaManager.DoScript(ScriptPath, LuaEnvironment, ScriptPath);

            LoadScriptSymbols();
        }


        /// <summary>
        /// Reruns the lua script.
        /// </summary>
        /// <param name="executeAwake">Should the awake() be executed, if there is one?</param>
        /// <param name="executeStart">Should the start() be executed, if there is one?</param>
        public void RedoLuaScript(bool executeAwake = false, bool executeStart = false)
        {
            UnloadScriptSymbols();

            // Runs the script within the LuaEnvironment.
            LuaManager.DoScript(ScriptPath, LuaEnvironment, ScriptPath);

            // Gets the script's symbols.
            LoadScriptSymbols();

            if (executeAwake)
                LuaAwake?.Invoke();

            if (executeStart)
                LuaStart?.Invoke();
        }

        public virtual void Select(bool select)
        {

        }
    }

    /// <summary>
    /// A lua domain for an individual object.
    /// </summary>
    [Serializable]
    public class LuaIndividualDomain : LuaDomain
    {
        [NonSerialized] public LuaIndividualObject LuaIndividualObject;

        // Unity Callbacks.
        public Action LuaOnEnable;
        public Action LuaOnDisable;
        public IntAction LuaOnAnimatorIK;
        public Action LuaOnAnimatorMove;

        public CollisionAction LuaOnCollisionEnter;
        public CollisionAction LuaOnCollisionExit;
        public CollisionAction LuaOnCollisionStay;
        public ColliderAction LuaOnTriggerEnter;
        public ColliderAction LuaOnTriggerExit;
        public ColliderAction LuaOnTriggerStay;

        /// <summary>
        /// Creates a new individual domain.
        /// </summary>
        /// <param name="scriptPath">The script's path of the domain.</param>
        /// <param name="attachedObject">The game object inside the domain.</param>
        /// <returns></returns>
        public static LuaIndividualDomain NewIndividualDomain(string scriptPath, LuaIndividualObject attachedObject)
        {
            var luaIndividualScript = new LuaIndividualDomain {ScriptPath = scriptPath , LuaIndividualObject = attachedObject};

            luaIndividualScript.DoScript();

            return luaIndividualScript;
        }

        /// <summary>
        /// Loads symbols from the lua script. Override to load more symbols. Don't forget to call the base function too.
        /// </summary>
        public override void LoadScriptSymbols()
        {
            base.LoadScriptSymbols();

            LuaEnvironment.Get("onEnable", out LuaOnEnable);
            LuaEnvironment.Get("onDisable", out LuaOnDisable);
            LuaEnvironment.Get("onAnimatorIK", out LuaOnAnimatorIK);
            LuaEnvironment.Get("onAnimatorMove", out LuaOnAnimatorMove);
            
            LuaEnvironment.Get("onCollisionEnter", out LuaOnCollisionEnter);
            LuaEnvironment.Get("onCollisionExit", out LuaOnCollisionExit);
            LuaEnvironment.Get("onCollisionStay", out LuaOnCollisionStay);
            LuaEnvironment.Get("onTriggerEnter", out LuaOnTriggerEnter);
            LuaEnvironment.Get("onTriggerExit", out LuaOnTriggerExit);
            LuaEnvironment.Get("onTriggerStay", out LuaOnTriggerStay);
        }

        /// <summary>
        /// Unloads symbols from the lua script. Override to unload more symbols. Don't forget to call the base function too.
        /// </summary>
        public override void UnloadScriptSymbols()
        {
            base.UnloadScriptSymbols();

            LuaOnEnable = null;
            LuaOnDisable = null;
            LuaOnAnimatorIK = null;
            LuaOnAnimatorMove = null;
            
            LuaOnCollisionEnter = null;
            LuaOnCollisionExit = null;
            LuaOnCollisionStay = null;
            LuaOnTriggerEnter = null;
            LuaOnTriggerExit = null;
            LuaOnTriggerStay = null;
        }

        /// <summary>
        /// Makes symbols available to the lua script.
        /// </summary>
        protected override void SetEnvironmentSymbols()
        {
            base.SetEnvironmentSymbols();
            LuaEnvironment.Set("self", LuaIndividualObject);
        }

        /// <summary>
        /// Selects the object of the environment.
        /// </summary>
        /// <param name="select"></param>
        public override void Select(bool select)
        {
            LuaIndividualObject.Select(select);
        }
    }

    /// <summary>
    /// A lua domain that is shared between a group of objects.
    /// </summary>
    [Serializable]
    public class LuaGroupDomain : LuaDomain
    {
        public string GroupName = string.Empty;
        public List<LuaGroupObject> Members = new List<LuaGroupObject>();

        // Unity Callbacks
        public IntIntAction LuaOnElementAnimatorIK;
        public IntAction LuaOnElementAnimatorMove;
        public CollisionIntAction LuaOnElementCollisionEnter;
        public CollisionIntAction LuaOnElementCollisionExit;
        public CollisionIntAction LuaOnElementCollisionStay;
        public ColliderIntAction LuaOnElementTriggerEnter;
        public ColliderIntAction LuaOnElementTriggerExit;
        public ColliderIntAction LuaOnElementTriggerStay;

        public override void LoadScriptSymbols()
        {
            base.LoadScriptSymbols();

            LuaEnvironment.Get("onElementAnimatorIK", out LuaOnElementAnimatorIK);
            LuaEnvironment.Get("onElementAnimatorMove", out LuaOnElementAnimatorMove);
            LuaEnvironment.Get("onElementCollisionEnter", out LuaOnElementCollisionEnter);
            LuaEnvironment.Get("onElementCollisionExit", out LuaOnElementCollisionExit);
            LuaEnvironment.Get("onElementCollisionStay", out LuaOnElementCollisionStay);
            LuaEnvironment.Get("onElementTriggerEnter", out LuaOnElementTriggerEnter);
            LuaEnvironment.Get("onElementTriggerExit", out LuaOnElementTriggerExit);
            LuaEnvironment.Get("onElementTriggerStay", out LuaOnElementTriggerStay);
        }

        public override void UnloadScriptSymbols()
        {
            base.UnloadScriptSymbols();

            LuaOnElementAnimatorIK = null;
            LuaOnElementAnimatorMove = null;
            LuaOnElementCollisionEnter = null;
            LuaOnElementCollisionExit = null;
            LuaOnElementCollisionStay = null;
            LuaOnElementTriggerEnter = null;
            LuaOnElementTriggerExit = null;
            LuaOnElementTriggerStay = null;
        }

        protected override void SetEnvironmentSymbols()
        {
            base.SetEnvironmentSymbols();

            LuaEnvironment.Set("Group", this);
            LuaEnvironment.Set("Members", Members);
        }

        /// <summary>
        /// Creates a new group domain. Does not run the domain.
        /// </summary>
        /// <param name="groupName">A name for the group.</param>
        /// <param name="scriptPath">Group's script path in ScriptsBasePath folder.</param>
        /// <param name="members">The group domain's members.</param>
        public static void NewGroupDomain(string groupName, string scriptPath, List<LuaGroupObject> members)
        {
            var luaGroupScript = new LuaGroupDomain {ScriptPath = scriptPath, Members = members};
        }

        /// <summary>
        /// Add a new member to the group.
        /// </summary>
        /// <param name="newMember"></param>
        /// <returns>The member's id of the new member.</returns>
        public int AddMember(LuaGroupObject newMember)
        {
            Members.Add(newMember);

            return Members.Count - 1;
        }

        /// <summary>
        /// Remove a member from the group.
        /// </summary>
        /// <param name="member">The member that will be removed.</param>
        public void RemoveMember(LuaGroupObject member)
        {
            var element = member.GetComponent<LuaGroupObject>();

            // Where is the last element?
            var lastId = Members.Count - 1;

            // If there is not only one element in the list.
            if (lastId > 0)
            {
                // Overwrite the element to be removed by the last.
                Members[element.GroupMemberId] = Members[lastId];
                // Update its id.
                Members[element.GroupMemberId].GetComponent<LuaGroupObject>().GroupMemberId = element.GroupMemberId;
            }
                
            // Remove the last element which will be either the only element or a duplicate element.
            Members.RemoveAt(lastId);
        }

        /// <summary>
        /// Returns the member's index.
        /// </summary>
        /// <param name="luaGroupMember"></param>
        /// <returns></returns>
        public int GetMemberId(LuaGroupObject luaGroupMember)
        {
            return Members.IndexOf(luaGroupMember);
        }

        public void InitializeMemberIds()
        {
            for (var i = 0; i < Members.Count; i++)
            {
                Members[i].GroupMemberId = i;
            }
        }

        /// <summary>
        /// Selects all the members of the group.
        /// </summary>
        /// <param name="select"></param>
        public override void Select(bool select)
        {
            foreach (var member in Members)
            {
                member.Select(select);
            }
        }
    }
}
