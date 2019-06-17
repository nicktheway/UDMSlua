using System.Collections;
using System.Collections.Generic;
using System.IO;
using LuaScripting;
using SFB;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using XLua;

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

        // Update is called once per frame
        private void Update()
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

            if (Input.GetKeyUp(KeyCode.R))
            {
                foreach (var selectedDomain in SelectedObjects)
                {
                    selectedDomain.RedoLuaScript(true, true);
                }
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                foreach (var selectedDomain in SelectedObjects)
                {
                    selectedDomain.Dispose();
                }
                SelectedObjects.Clear();
            }

            if (Input.GetKeyDown(KeyCode.S) && SelectedObjects.Count > 0)
            {
                ChangeScriptOnSelectedDomains();
            }
            else if (Input.GetKeyDown(KeyCode.C) && SelectedObjects.Count > 0)
            {
                ChangeScriptOnSelectedDomains(true);
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                UI.SetActive(!UI.activeSelf);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                LuaManager.DisposeTheLuaEnv();
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                GetComponent<LuaRoom>().InstantiateIndividualGameObject("grandpa Variant", "models/lpfamily", "agent_alone.lua");
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                ChooseRoom();
            }
        }

        private void ChangeScriptOnSelectedDomains(bool combineScripts = false)
        {
            var paths = StandaloneFileBrowser.OpenFilePanel("", LuaManager.ScriptsBasePath, "lua", combineScripts);

            if (paths.Length > 0)
            {
                foreach (var path in paths)
                {
                    var shortPath = path.Replace('\\', '/');
                    shortPath = shortPath.Replace(LuaManager.ScriptsBasePath, "").TrimStart('/');

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

            if (paths.Length > 0)
            {
                var path = paths[0];

                var shortPath = path.Replace('\\', '/');
                shortPath = shortPath.Replace(LuaManager.ScriptsBasePath, "").TrimStart('/');

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
            luaRoom.SetUpRoom();
            ActiveLuaRoom = luaRoom;
                
            StartCoroutine(luaRoom.Activate());
        }

        public void ChooseSong()
        {
            var paths = StandaloneFileBrowser.OpenFilePanel("Choose a song.", MusicBasePath, "ogg", false);

            if (paths.Length > 0)
            {
                StartCoroutine(StartSong(paths[0]));
            }
        }

        public IEnumerator StartSong(string path)
        {
            using (var www = UnityWebRequestMultimedia.GetAudioClip("file://" + path, AudioType.OGGVORBIS))
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
