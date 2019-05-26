using System.Collections.Generic;
using LuaScripting;
using UnityEngine;

namespace UDMS
{
    public class GameManager : MonoBehaviour
    {
        public List<LuaGameObject> SelectedObjects = new List<LuaGameObject>();


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
                        if (!SelectedObjects.Contains(luaBeh))
                        {
                            SelectedObjects.Add(luaBeh);
                            luaBeh.LuaDomain.Select(true);
                        }
                        else if (SelectedObjects.Contains(luaBeh))
                        {
                            SelectedObjects.Remove(luaBeh);
                            luaBeh.LuaDomain.Select(false);
                        }
                    }
                }
            }
            
        }
    }
}
