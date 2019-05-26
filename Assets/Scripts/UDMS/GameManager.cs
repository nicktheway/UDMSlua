using System.Collections;
using System.Collections.Generic;
using System.IO;
using LuaScripting;
using SFB;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Windows;
using XLua;

namespace UDMS
{
    public class GameManager : MonoBehaviour
    {
        public List<LuaDomain> SelectedObjects = new List<LuaDomain>();
        public GameObject UI;

        public static readonly string MusicBasePath = Application.streamingAssetsPath + "/Music";

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
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
                        selectedDomain.RunNewScript(shortPath, combineScripts, !combineScripts, true);
                    }
                }
                
            }
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
