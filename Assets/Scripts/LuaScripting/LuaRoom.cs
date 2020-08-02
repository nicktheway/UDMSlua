using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using Utilities;
using XLua;

namespace LuaScripting
{
    /// <summary>
    /// LuaRoom is a class that sets up a Scene and manages LuaDomains inside the scene.
    /// </summary>
    [DefaultExecutionOrder(-1000)]
    [LuaCallCSharp]
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
        /// The room has access to the global music functions
        /// </summary>
        public Action<string> PlayMusicGlobal;

        /// <summary>
        /// A list that contains the registered LuaDomains of the room.
        /// </summary>
        public readonly List<LuaDomain> RegisteredDomains = new List<LuaDomain>();

        /// <summary>
        /// The available lua groups in the room.
        /// </summary>
        public readonly Dictionary<string, LuaGroupDomain> Groups = new Dictionary<string, LuaGroupDomain>();

        /// <summary>
        /// The available registered objects in the room.
        /// </summary>
        public readonly Dictionary<string, GameObject> Objects = new Dictionary<string, GameObject>();


        /// <summary>
        /// The available lua individual objects in the room.
        /// </summary>
        public readonly Dictionary<string, LuaIndividualDomain> IndividualDomains = new Dictionary<string, LuaIndividualDomain>();

#if UNITY_EDITOR
        // For inspector debugging.
        public List<LuaDomain> _registeredDomains;
#endif

        private bool _roomSetUp;

        /// <summary>
        /// Used to set up a new room.
        /// </summary>
        public void SetUpRoom()
        {
            // Set the room's script path.
            RoomScriptPath = Path.Combine(LuaManager.ScriptsBasePath, RoomName);

            // Create the settings domain and run the script.
            LoadRoomSettings();

            // Load room's scene.
            if (SceneUtilities.IsValidSceneName(SceneName))
            {
                SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
                SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByName(SceneName));
            }
            else
            {
                SceneName = "EmptyScene";
                var defaultScene = SceneManager.CreateScene(SceneName);
                SceneManager.MoveGameObjectToScene(gameObject, defaultScene);
            }
            
            // Run the setUpRoom function to set up the scene.
            RoomSettings.LuaEnvironment.Get("setUp", out Action setUpRoom);
            setUpRoom?.Invoke();

            _roomSetUp = true;
        }

        public IEnumerator Activate()
        {
            yield return new WaitForSeconds(0.1f);

            if (gameObject == null)
                yield break;

            gameObject.SetActive(true);
        }

        private void Awake()
        {
            // The room might be already set up if instantiated by the GameManager.
            if (!_roomSetUp)
                SetUpRoom();

            InitializeInspectorDefinedObjects();

            // Add, run and call the awake() for all the groups.
            foreach (var groupKeyValuePair in Groups)
            {
                groupKeyValuePair.Value.LuaAwake?.Invoke();
            }
        }

        /// <summary>
        /// Creates the room's settings domain and runs the settings.lua script.
        /// </summary>
        private void LoadRoomSettings()
        {
            RoomSettings = LuaDomain.NewLuaDomain("RoomSettings", Path.Combine(RoomScriptPath, "settings.lua"), this, false);
            RoomSettings.LuaEnvironment.Set("room", this);
            RoomSettings.LuaEnvironment.Set("setMusic", PlayMusicGlobal);
            RoomSettings.DoScript();

            RoomSettings.LuaEnvironment.Get("scene", out SceneName);
        }

        /// <summary>
        /// Reruns the room's settings.
        /// </summary>
        public void RerunRoomSettings()
        {
            RoomSettings.RedoLuaScript(true, true);
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
                {
                    luaDomain.BeforeUpdateActions();
                    luaDomain.LuaUpdate?.Invoke();
                }  
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
                {
                    luaDomain.LuaLateUpdate?.Invoke();
                    luaDomain.AfterLateUpdateActions();
                }
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

            // Add to the dictionaries
            if (domain is LuaGroupDomain groupDomain)
            {
                if (!Groups.ContainsKey(groupDomain.DomainName))
                {
                    Groups.Add(groupDomain.DomainName, groupDomain);
                }
                else
                {
                    Debug.LogError($"There is already a group named: {groupDomain.DomainName} inside the room.");
                }
            }
            else if (domain is LuaIndividualDomain individualDomain)
            {
                if (!IndividualDomains.ContainsKey(individualDomain.DomainName))
                {
                    IndividualDomains.Add(individualDomain.DomainName, individualDomain);
                }
                else
                {
                    Debug.LogError($"There is already an individual domain named: {individualDomain.DomainName} inside the room.");
                }
            }

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

            // Remove from dictionaries
            if (domain is LuaGroupDomain groupDomain)
            {
                if (Groups.ContainsKey(groupDomain.DomainName))
                {
                    Groups.Remove(groupDomain.DomainName);
                }
            }
            else if (domain is LuaIndividualDomain individualDomain)
            {
                if (IndividualDomains.ContainsKey(individualDomain.DomainName))
                {
                    IndividualDomains.Remove(individualDomain.DomainName);
                }
            }
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
            if (Groups.ContainsKey(group.DomainName))
            {
                Debug.LogError($"A group with the name {group.DomainName} already exists.");
            }

            Groups.Add(group.DomainName, group);
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
        /// Adds an individual domain to the individual domain dictionary. Does not run the domain.
        /// </summary>
        /// <param name="individualDomain">The LuaIndividualDomain to be added.</param>
        public void AddIndividualDomain(LuaIndividualDomain individualDomain)
        {
            if (IndividualDomains.ContainsKey(individualDomain.DomainName))
            {
                Debug.LogError($"An individual domain with the name: {individualDomain.DomainName} already exists in the room.");
            }

            IndividualDomains.Add(individualDomain.DomainName, individualDomain);
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

        /// <summary>
        /// Instantiates the global camera rig into the room.
        /// </summary>
        public GameObject InstantiateCameraRig()
        {
            var cameraRig = AssetManager.LoadAsset<GameObject>("CameraRig", "etc/camerarig");
            Debug.Assert(cameraRig != null);
            cameraRig.SetActive(false);

            var instantiatedCameraRig = Instantiate(cameraRig, transform); 
            instantiatedCameraRig.transform.SetParent(null);

            var luaCameraObject = instantiatedCameraRig.AddComponent<LuaCameraObject>();

            luaCameraObject.LuaDomain = LuaIndividualDomain.NewIndividualDomain("CameraRig", "camera.lua", luaCameraObject, this);

            luaCameraObject.ScriptPath = "camera.lua";

            instantiatedCameraRig.SetActive(true);

            return instantiatedCameraRig;
        }

        /// <summary>
        /// Instantiates a new registered object in the room. Use for simple objects that do not need their own scripts.
        /// </summary> 
        /// <param name="objectKey">The key of the new object in the room.</param>
        /// <param name="objectType">An optional type can be specified for faster object creation. Accepts values from a predefined list, an empty object will be created for values out of that list.</param>
        /// <param name="components">An optional array of component types can specified to add the equivalent components to the new object.</param>
        /// <param name="activate">Should the object be activated? Defaults to true.</param>
        /// <returns>The instantiated game object.</returns>
        public GameObject InstantiateAndRegisterObject(string objectKey, string objectType = "", Type[] components = null, bool activate = true)
        {
            var newObject = InstantiateObject(objectType, components, activate);
            RegisterObject(objectKey, newObject);

            return newObject;
        }

        /// <summary>
        /// Instantiates a new object in the room. Use for simple objects that do not need their own scripts.
        /// </summary> 
        /// <param name="objectType">An optional type can be specified for faster object creation. Accepts values from a predefined list, an empty object will be created for values out of that list.</param>
        /// <param name="components">An optional array of component types can specified to add the equivalent components to the new object.</param>
        /// <param name="activate">Should the object be activated? Defaults to true.</param>
        /// <returns>The instantiated game object.</returns>
        public GameObject InstantiateObject(string objectType = "", Type[] components = null, bool activate = true)
        {
            GameObject newObject;
            switch (objectType)
            {
                case "cube":
                    newObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    break;
                case "sphere":
                    newObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    break;
                case "capsule":
                    newObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                    break;
                case "cylinder":
                    newObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    break;
                case "plane":
                    newObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    break;
                case "quad":
                    newObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
                    break;
                case "light":
                    newObject = new GameObject();
                    newObject.SetActive(false);
                    newObject.AddComponent<Light>();
                    break;
                case "camera":
                    newObject = new GameObject();
                    newObject.SetActive(false);
                    newObject.AddComponent<Camera>();
                    newObject.AddComponent<AudioListener>();
                    break;
                case "vcamera":
                    newObject = new GameObject();
                    newObject.SetActive(false);
                    newObject.AddComponent<CinemachineVirtualCamera>();
                    break;
                default:
                    newObject = new GameObject();
                    break;
            }
            newObject.SetActive(false);

            if (components != null) 
            {
                foreach(var component in components)
                {
                    newObject.AddComponent(component);
                }
            }
            
            // Move the object under the room.
            newObject.transform.SetParent(transform);

            if (activate) newObject.SetActive(true);

            return newObject;
        }


        /// <summary>
        /// Registers a new object.
        /// </summary>
        /// <param name="objectKey">The key of the object in the room.</param>
        /// <param name="objectToRegister">The object to register on that key.</param>
        public void RegisterObject(string objectKey, GameObject objectToRegister)
        {
            Debug.Assert(!Objects.ContainsKey(objectKey));
            Objects.Add(objectKey, objectToRegister);
        }

        /// <summary>
        /// Instantiates a prefab from an AssetBundle with an individual domain inside this room.
        /// </summary>
        /// <param name="objectName">The prefab's name inside the asset bundle.</param>
        /// <param name="bundleName">The Asset Bundle's name.</param>
        /// <param name="objectDomainName">The name of the object.</param>
        /// <param name="scriptPath">The script that will drive this object.</param>
        /// <returns>The instantiated game object.</returns>
        public GameObject InstantiateIndividualGameObject(string objectName, string bundleName, string objectDomainName, string scriptPath)
        {
            var go = AssetManager.LoadAsset<GameObject>(objectName, bundleName);

            return go ? InstantiateIndividualGameObject(go, objectDomainName, scriptPath) : null;
        }

        /// <summary>
        /// Instantiates a prefab with an individual domain inside this room.
        /// </summary>
        /// <param name="prefab">The prefab to instantiate.</param>
        /// <param name="objectDomainName">The name of the object.</param>
        /// <param name="scriptPath">The script that will drive this object.</param>
        /// <returns>Tne instantiated object.</returns>
        public GameObject InstantiateIndividualGameObject(GameObject prefab, string objectDomainName, string scriptPath)
        {
            // Set the prefab inactive so that Instantiate function won't call Awake()/OnEnable()
            prefab.SetActive(false);

            // Instantiate.
            var instantiatedGameObject = Instantiate(prefab, transform);
            instantiatedGameObject.transform.SetParent(null);

            // Add the individual lua object component.
            var luaIndividualObject = instantiatedGameObject.AddComponent<LuaIndividualObject>();
            
            // Create a domain for it.
            var individualDomain = LuaIndividualDomain.NewIndividualDomain(objectDomainName, scriptPath, luaIndividualObject, this);
            luaIndividualObject.LuaDomain = individualDomain;

            // Set the script path to view in the inspector.
            luaIndividualObject.ScriptPath = scriptPath;

            // Set the instantiated object active.
            instantiatedGameObject.SetActive(true);

            return instantiatedGameObject;
        }

        /// <summary>
        /// Instantiates a group of prefabs from an AssetBundle within a group domain inside this room.
        /// </summary>
        /// <param name="objectName">The prefab's name inside the asset bundle.</param>
        /// <param name="bundleName">The Asset Bundle's name.</param>
        /// <param name="membersCount">The number of members in the group.</param>
        /// <param name="groupName">The name of the group.</param>
        /// <param name="scriptPath">The script that will drive this group.</param>
        /// <returns></returns>
        public LuaGroupDomain InstantiateGroup(string objectName, string bundleName, int membersCount, string groupName, string scriptPath)
        {
            var go = AssetManager.LoadAsset<GameObject>(objectName, bundleName);

            return go ? InstantiateGroup(go, membersCount, groupName, scriptPath) : null;
        }

        /// <summary>
        /// Instantiates a prefab membersCount times within a group domain inside this room.
        /// </summary>
        /// <param name="prefab">The prefab to instantiate.</param>
        /// <param name="membersCount">The number of members in the group.</param>
        /// <param name="groupName">The name of the group.</param>
        /// <param name="scriptPath">The script that will drive this group.</param>
        /// <returns>The newly created group domain.</returns>
        public LuaGroupDomain InstantiateGroup(GameObject prefab, int membersCount, string groupName, string scriptPath)
        {
            // Set the prefab inactive so that Instantiate function won't call Awake()/OnEnable()
            prefab.SetActive(false);

            var groupDomain = LuaGroupDomain.NewGroupDomain(groupName, scriptPath, this);
            var members = new List<GameObject>(membersCount);

            // Create a parent object for the group members and put it under the room.
            var parent = new GameObject(groupName);
            parent.transform.SetParent(transform);
            
            for (var i = 0; i < membersCount; i++)
            {
                // Instantiate.
                var instantiatedGameObject = Instantiate(prefab, transform);
                instantiatedGameObject.transform.SetParent(parent.transform);

                var luaGroupObject = instantiatedGameObject.AddComponent<LuaGroupObject>();
                
                groupDomain.AddMember(luaGroupObject);

                members.Add(instantiatedGameObject);
            }

            // After all the members have been instantiated activate them.
            foreach (var member in members)
            {
                member.SetActive(true);
            }

            groupDomain.DoScript();

            return groupDomain;
        }

        /// <summary>
        /// This method is needed in order to properly initialize all the lua domains and game objects that are
        /// defined in the inspector and not through scripting.
        /// </summary>
        private void InitializeInspectorDefinedObjects()
        {
            foreach (var luaRoomPreset in FindObjectsOfType<LuaRoomPresets>())
            {
                // Register the already initialized objects specified in the inspector.
                foreach (var registeredObject in luaRoomPreset.Objects)
                {
                    Objects.Add(registeredObject.ObjectName, registeredObject.GameObject);
                }

                // Create the group domains specified in the inspector.
                foreach (var group in luaRoomPreset.Groups)
                {
                    group.AssignRoom(this);
                    RunGroupDomain(group.DomainName);
                }

                // Create/Assign the domain of each individual lua object.
                foreach (var luaIndividualObject in luaRoomPreset.Individuals)
                {
                    luaIndividualObject.GameObject.LuaDomain =
                        LuaIndividualDomain.NewIndividualDomain(luaIndividualObject.ObjectName, luaIndividualObject.GameObject.ScriptPath, luaIndividualObject.GameObject, this);

                    luaIndividualObject.GameObject.LuaDomain.Enabled = luaIndividualObject.GameObject.enabled;
                }

                luaRoomPreset.ResetActiveState();
                luaRoomPreset.AssignRoom(this);
            }
        }

        /// <summary>
        /// Retrieves one of the room's registered objects from its key.
        /// </summary>
        /// <param name="objectKey">The key with which the object was registered in the room.</param>
        /// <returns>The GameObject or null if no game object is registered with this key in the room.</returns>
        public GameObject GetObject(string objectKey)
        {
            if (Objects.ContainsKey(objectKey))
            {
                return Objects[objectKey];
            }
            Debug.LogWarning($"No object found with key: {objectKey}");

            return null;
        }

        /// <summary>
        /// Retrieves one of the room's group domains from its name.
        /// </summary>
        /// <param name="groupName">The name of the group.</param>
        /// <returns>The group's LuaGroupDomain or null if no group with that name exists in the room.</returns>
        public LuaGroupDomain GetGroupDomain(string groupName)
        {
            if (Groups.ContainsKey(groupName))
            {
                return Groups[groupName];
            }
            Debug.LogWarning($"No group found with name: {groupName}");

            return null;
        }

        /// <summary>
        /// Retrieves one of the room's individual domains from its name.
        /// </summary>
        /// <param name="domainName">The name of the individual domain.</param>
        /// <returns>The LuaIndividualDomain or null if no individual domain with that name exists in the room.</returns>
        public LuaIndividualDomain GetIndividualDomain(string domainName)
        {
            if (IndividualDomains.ContainsKey(domainName))
            {
                return IndividualDomains[domainName];
            }
            Debug.LogWarning($"No individual domain with name: {domainName} found in the room.");

            return null;
        } 

        /// <summary>
        /// Return a list of the keys of the available registered objects in the room.
        /// </summary>
        /// <returns>The keys of the registered room objects.</returns>
        public List<string> GetObjectKeys()
        {
            var list = new List<string>();
            foreach (var pair in Objects)
            {
                if (pair.Value != null) 
                {
                    list.Add(pair.Key);
                }
            }
            return list;
        }

        /// <summary>
        /// Return a list of the names of the registered group domains in the room.
        /// </summary>
        /// <returns>The names of the registered group domains.</returns>
        public List<string> GetGroupDomainNames()
        {
            var list = new List<string>();
            foreach (var pair in Groups)
            {
                if (pair.Value != null) 
                {
                    list.Add(pair.Key);
                }
            }
            return list;
        }

        /// <summary>
        /// Return a list of the names of the registered individual domains in the room.
        /// </summary>
        /// <returns>The names of the registered individual domains.</returns>
        public List<string> GetIndividualDomainNames()
        {
            var list = new List<string>();
            foreach (var pair in IndividualDomains)
            {
                if (pair.Value != null) 
                {
                    list.Add(pair.Key);
                }
            }
            return list;
        }

        public void Dispose()
        {
            // TODO: dispose everything inside the room.
        }
    }
}
