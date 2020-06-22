using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LuaScripting;
using SFB;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using XLua;
using IngameDebugConsole;

namespace UDMS
{
    [DefaultExecutionOrder(-99999)]
    public class GameManager : MonoBehaviour
    {
        public List<LuaDomain> SelectedObjects = new List<LuaDomain>();
        public GameObject UI;

        public static readonly string MusicBasePath = Application.streamingAssetsPath + "/Music";


        private AudioSource _audioSource;

        /// <summary>
        /// The table with the game's global settings.
        /// </summary>
        public LuaTable GameSettings = LuaManager.LuaEnv.NewTable();

        public LuaRoom ActiveLuaRoom;
        private string _newRoomName;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);

            PrepareGameSettingsSymbols();
            ApplyGameSettings();
        }

        private void Start()
        {
            DebugLogConsole.AddCommand("reload", "Reloads the scripts of the selected LuaDomains.", ReloadScriptsOnSelectedDomains);
            DebugLogConsole.AddCommand("room", "Opens panel for selecting a new room/scenario.", ChooseRoom);
            DebugLogConsole.AddCommand("song", "Opens a file panel for selecting a new song to play.", ToggleMainMenu);
            DebugLogConsole.AddCommand("domains", "Prints a list of the room's domains.", PrintRoomDomains);
            DebugLogConsole.AddCommand("objects", "Prints a list of the room's registered objects.", PrintRoomObjects);
            DebugLogConsole.AddCommand("selected", "Prints a list of the currently selected domains.", PrintSelected);
            DebugLogConsole.AddCommand<char, string>("select", "Select a domain of the room by its type and name to perform actions on it. First argument should be the type: 'g' for groups and 'i' for individual domains. Second argument should be the domain's name.", SelectDomain);
            DebugLogConsole.AddCommand<char, string>("deselect", "Deselect a domain of the room by its type and name. First argument should be the type: 'g' for groups and 'i' for individual domains. Second argument should be the domain's name.", DeselectDomain);
            DebugLogConsole.AddCommand("script", "Opens panel for selecting a new script for the selected domains.", ChangeScriptForSelectedDomains);
            DebugLogConsole.AddCommand("combine", "Opens panel for selecting a combinations of scripts for the selected domains.", CombineScriptsForSelectedDomains);
            DebugLogConsole.AddCommand("delete", "Deletes the selected domains.", DeleteSelectedDomains);
            DebugLogConsole.AddCommand<string>("grandpa", "Instantiates a new grandpa individual object inside the room.", InstantiateGrandpa);
            DebugLogConsole.AddCommand("menu", "Toggles the main menu.", ToggleMainMenu);
            DebugLogConsole.AddCommand("ENVDISPOSE", "Disposes the Lua Environment. Not recommended.", DisposeLuaEnvironment);
        }

        private void Update()
        {
            MouseSelectListen();
        }

        private void MouseSelectListen()
        {
            if (Input.GetMouseButtonUp(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
                if (Physics.Raycast(ray, out var hit))
                {
                    var objectHit = hit.transform;

                    var luaBeh = objectHit.GetComponent<LuaGameObject>();
                    if (luaBeh)
                    {
                        if (!SelectedObjects.Contains(luaBeh.LuaDomain))
                        {
                            SelectedObjects.Add(luaBeh.LuaDomain);
                            luaBeh.LuaDomain.Select(true);
                        }
                        else if (SelectedObjects.Contains(luaBeh.LuaDomain))
                        {
                            SelectedObjects.Remove(luaBeh.LuaDomain);
                            luaBeh.LuaDomain.Select(false);
                        }
                    }
                }
            }
            else if (Input.GetMouseButton(1))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
                if (Physics.Raycast(ray, out var hit))
                {
                    var objectHit = hit.transform;

                    var luaGroupObject = objectHit.GetComponent<LuaGroupObject>();
                    if (luaGroupObject)
                    {
                        if (luaGroupObject.LuaDomain is LuaGroupDomain luaGroupDomain)
                        {
                            luaGroupDomain.HighlightNeigbours(luaGroupObject.GroupMemberId);
                        }
                    }
                }
            }
        }

        private void KeyInputListeners()
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                ReloadScriptsOnSelectedDomains();
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                DeleteSelectedDomains();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                ChangeScriptForSelectedDomains();
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                CombineScriptsForSelectedDomains();
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                ToggleMainMenu();
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                InstantiateGrandpa("AutoGrandpa");
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                ChooseRoom();
            }
        }

        private void PrepareGameSettingsSymbols()
        {
            LuaManager.AttachGlobalTableAsDefault(GameSettings);
            GameSettings.Set("self", gameObject);
            GameSettings.Set("Audio", _audioSource);
        }

        public void ApplyGameSettings()
        {
            LuaManager.DoScript("gameSettings.lua", GameSettings, "gameSettings.lua");
        }

        public void PrintSelected()
        {
            var list = new StringBuilder();
            foreach (var selected in SelectedObjects)
            {
                var type = selected is LuaGroupDomain ? 'g' : 'i';
                list.Append($"{type} \"{selected.DomainName}\"\n");
            }
            Debug.Log(list.ToString());
        }

        public void PrintRoomDomains()
        {
            var list = new StringBuilder();
            foreach (var domain in ActiveLuaRoom.RegisteredDomains)
            {
                var type = domain is LuaGroupDomain ? 'g' : 'i';
                // Settings is the only domain that isn't a group nor an individual domain currently.
                if (type == 'i' && !(domain is LuaIndividualDomain)) continue;

                list.Append($"{type} \"{domain.DomainName}\"\n");
            }
            Debug.Log(list.ToString());
        }

        public void PrintRoomObjects()
        {
            var list = new StringBuilder();
            foreach (var key in ActiveLuaRoom.Objects.Keys)
            {
                list.Append($"\"{key}\"\n");
            }
            Debug.Log(list.ToString());
        }

        public void SelectDomain(char type, string domainName)
        {
            switch(type)
            {
                case 'g':
                    SelectGroupDomain(domainName);
                    break;
                case 'i':
                    SelectIndividualDomain(domainName);
                    break;
                default:
                    Debug.LogError("Unsupported type argument. Use 'g' for groups or 'i' for individual domains.");
                    break;
            }
        }

        public void DeselectDomain(char type, string domainName)
        {
            switch(type)
            {
                case 'g':
                    DeselectGroupDomain(domainName);
                    break;
                case 'i':
                    DeselectIndividualDomain(domainName);
                    break;
                default:
                    Debug.LogError("Unsupported type argument. Use 'g' for groups or 'i' for individual domains.");
                    break;
            }
        }

        public void SelectGroupDomain(string groupName)
        {
            if (ActiveLuaRoom.Groups.ContainsKey(groupName))
            {
                var groupDomain = ActiveLuaRoom.Groups[groupName];
                if (SelectedObjects.Contains(groupDomain))
                {
                    Debug.Log($"The group {groupName} is already selected.");
                }
                else 
                {
                    SelectedObjects.Add(groupDomain);
                    groupDomain.Select(true);
                }
            }
            else 
            {
                Debug.LogError($"No group named: {groupName} exists in the room.");
            }
        }

        public void DeselectGroupDomain(string groupName)
        {
            if (ActiveLuaRoom.Groups.ContainsKey(groupName))
            {
                var groupDomain = ActiveLuaRoom.Groups[groupName];
                if (!SelectedObjects.Contains(groupDomain))
                {
                    Debug.Log($"The group {groupName} is already not selected.");
                }
                else 
                {
                    SelectedObjects.Remove(groupDomain);
                    groupDomain.Select(false);
                }
            }
            else 
            {
                Debug.LogError($"No group named: {groupName} exists in the room.");
            }
        }

        public void SelectIndividualDomain(string domainName)
        {
            if (ActiveLuaRoom.IndividualDomains.ContainsKey(domainName))
            {
                var domain = ActiveLuaRoom.IndividualDomains[domainName];
                if (SelectedObjects.Contains(domain))
                {
                    Debug.Log($"The domain {domainName} is already selected.");
                }
                else 
                {
                    SelectedObjects.Add(domain);
                    domain.Select(true);
                }
            }
            else 
            {
                Debug.LogError($"No individual domain named: {domainName} exists in the room.");
            }
        }

        public void DeselectIndividualDomain(string domainName)
        {
            if (ActiveLuaRoom.IndividualDomains.ContainsKey(domainName))
            {
                var domain = ActiveLuaRoom.IndividualDomains[domainName];
                if (!SelectedObjects.Contains(domain))
                {
                    Debug.Log($"The domain {domainName} is already not selected.");
                }
                else 
                {
                    SelectedObjects.Remove(domain);
                    domain.Select(false);
                }
            }
            else 
            {
                Debug.LogError($"No individual domain named: {domainName} exists in the room.");
            }
        }

        public void ReloadScriptsOnSelectedDomains()
        {
            foreach (var selectedDomain in SelectedObjects)
            {
                selectedDomain.RedoLuaScript(true, true);
            }
        }

        public void DeleteSelectedDomains()
        {
            foreach (var selectedDomain in SelectedObjects)
            {
                selectedDomain.Dispose();
            }
            SelectedObjects.Clear();
        }

        public void ChangeScriptForSelectedDomains()
        {
            if (SelectedObjects.Count > 0)
            {
                ChangeScriptOnSelectedDomains();
            }
        }

        public void CombineScriptsForSelectedDomains()
        {
            if (SelectedObjects.Count > 0)
            {
                ChangeScriptOnSelectedDomains(true);
            }
        }

        public void DisposeLuaEnvironment()
        {
            LuaManager.DisposeTheLuaEnv();
        }

        public void ToggleMainMenu()
        {
            UI.SetActive(!UI.activeSelf);
        }

        public void InstantiateGrandpa(string domainName)
        {
            ActiveLuaRoom.InstantiateIndividualGameObject("grandpa Variant", "models/lpfamily", domainName, "agent_alone.lua");
        }

        private void ChangeScriptOnSelectedDomains(bool combineScripts = false)
        {
            var paths = StandaloneFileBrowser.OpenFilePanel("", LuaManager.ScriptsBasePath, "lua", combineScripts);

            if (paths.Length > 0 && paths[0].Length > 0)
            {
                foreach (var path in paths)
                {
                    var shortPath = path.Replace('\\', '/');
                    var basePathPos = shortPath.IndexOf(LuaManager.ScriptsBasePath, System.StringComparison.Ordinal);
                    if (basePathPos == -1)
                    {
                        Debug.LogError($"Invalid room path: {path}. All the rooms must be inside: {LuaManager.ScriptsBasePath}");
                        return;
                    }
                    shortPath = shortPath.Substring(basePathPos + LuaManager.ScriptsBasePath.Length).Trim(new char[] { '/' });

                    foreach (var selectedDomain in SelectedObjects)
                    {
                        selectedDomain.RunNewScript(shortPath, combineScripts, !combineScripts, true, false);
                    }
                }
                
            }
        }

        public void ChooseRoom()
        {
            var paths = StandaloneFileBrowser.OpenFolderPanel("", LuaManager.ScriptsBasePath, false);

            if (paths.Length > 0 && paths[0].Length > 0)
            {
                var path = paths[0];


                var shortPath = path.Replace('\\', '/');
                var basePathPos = shortPath.IndexOf(LuaManager.ScriptsBasePath, System.StringComparison.Ordinal);
                if (basePathPos == -1)
                {
                    Debug.LogError($"Invalid room path: {path}. All the rooms must be inside: {LuaManager.ScriptsBasePath}");
                    return;
                }

                shortPath = shortPath.Substring(basePathPos + LuaManager.ScriptsBasePath.Length).Trim(new char[] { '/' });

                _newRoomName = shortPath;

                if (ActiveLuaRoom != null)
                {
                    StartCoroutine(UnloadScene(ActiveLuaRoom.SceneName));
                }
                else
                {
                    OnPreviousSceneUnloaded(SceneManager.GetSceneByName(_newRoomName));
                }
            }
        }

        private IEnumerator UnloadScene(string sceneName)
        {
            yield return SceneManager.UnloadSceneAsync(sceneName);

            OnPreviousSceneUnloaded(SceneManager.GetSceneByName(_newRoomName));
        }

        private void OnPreviousSceneUnloaded(Scene scene)
        {
            var roomObject = new GameObject("LuaRoom");
            roomObject.SetActive(false);
            var luaRoom = roomObject.AddComponent<LuaRoom>();
            luaRoom.RoomName = _newRoomName;
            luaRoom.PlayMusicGlobal = PlaySong;
            luaRoom.SetUpRoom();
            ActiveLuaRoom = luaRoom;
                
            StartCoroutine(luaRoom.Activate());
        }

        public void ChooseSong()
        {
            var paths = StandaloneFileBrowser.OpenFilePanel("Choose a song.", MusicBasePath, "ogg", false);

            if (paths.Length > 0 && paths[0].Length > 0)
            {
                var path = paths[0];
                
                var shortPath = path.Replace('\\', '/');
                var basePathPos = shortPath.IndexOf(MusicBasePath, System.StringComparison.Ordinal);

                if (basePathPos == -1)
                {
                    Debug.LogError($"Invalid music path: {path}. All music must be inside: {MusicBasePath}");
                    return;
                }
                shortPath = shortPath.Substring(basePathPos + MusicBasePath.Length).Trim(new char[] { '/' });
                PlaySong(shortPath);
            }
        }

        public void PlaySong(string path)
        {
            StartCoroutine(StartSong(Path.Combine(MusicBasePath, path)));
        }

        public IEnumerator StartSong(string path)
        {
            using (var www = UnityWebRequestMultimedia.GetAudioClip(path.StartsWith("file://", System.StringComparison.Ordinal) ? path : "file://" + path, AudioType.OGGVORBIS))
            {
                yield return www.SendWebRequest();
                
                if (www.error != null)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    _audioSource.clip = DownloadHandlerAudioClip.GetContent(www);
                    
                    while (_audioSource.clip.loadState != AudioDataLoadState.Loaded)
                        yield return new WaitForSeconds(0.1f);

                    _audioSource.Play();
                }
            }
        }

   

    }
}
