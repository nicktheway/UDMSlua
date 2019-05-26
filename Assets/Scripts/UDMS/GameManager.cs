using System.Collections.Generic;
using System.IO;
using LuaScripting;
using SFB;
using UnityEngine;
using UnityEngine.Windows;

namespace UDMS
{
    public class GameManager : MonoBehaviour
    {
        public List<LuaDomain> SelectedObjects = new List<LuaDomain>();


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
    }
}
