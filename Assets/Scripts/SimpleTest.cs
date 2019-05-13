using System;
using System.IO;
using UnityEngine;
using XLua;

public class SimpleTest : MonoBehaviour
{
    private static readonly string ScriptsPath = Application.streamingAssetsPath + "/Scripts";
    private static readonly LuaEnv LuaEnv = new XLua.LuaEnv();

    public int ObjectId = 0;

    /// <summary>
    /// The path of the script in the Streaming Assets folder.
    /// </summary>
    public string ScriptPath = "test.lua";

    private readonly LuaTable _scriptEnv = LuaEnv.NewTable();

    // Unity Callbacks
    private Action _luaAwake;
    private Action _luaStart;
    private Action _luaUpdate;
    private Action _luaOnDestroy;

    // Input Callbacks
    private Action _onSpaceButtonDown;

    private void Awake()
    {
        

        SetScriptSymbols();

        DoScript();

        LoadScriptMethods();

        _luaAwake?.Invoke();
    }

    private void Start()
    {
        _luaStart?.Invoke();
    }

    private void Update()
    {
        _luaUpdate?.Invoke();

        if (Input.GetKeyDown(KeyCode.R))
        {
            RedoScript();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _onSpaceButtonDown?.Invoke();
        }
    }

    private void RedoScript()
    {
        UnloadScriptMethods();
        DoScript();
        LoadScriptMethods();
    }

    private void OnDestroy()
    {
        _luaOnDestroy?.Invoke();

        UnloadScriptMethods();

        //LuaEnv.Dispose();
    }


    private void DoScript(string chunkName = "chunk")
    {
        var filePath = Path.Combine(ScriptsPath, ScriptPath);

        if (File.Exists(filePath))
        {
            var text = File.ReadAllText(filePath);

            LuaEnv.DoString(text, chunkName, _scriptEnv);
        }
    }

    private void SetScriptSymbols()
    {
        // Set a separate Lua environment for each script to prevent global variables and function conflicts to some extent.
        var meta = LuaEnv.NewTable();
        meta.Set("__index", LuaEnv.Global);
        _scriptEnv.SetMetaTable(meta);
        meta.Dispose();

        // self <-> this, like in python.
        _scriptEnv.Set("self", this);
    }

    private void LoadScriptMethods()
    {
        _scriptEnv.Get("awake", out _luaAwake);
        _scriptEnv.Get("start", out _luaStart);
        _scriptEnv.Get("update", out _luaUpdate);
        _scriptEnv.Get("onDestroy", out _luaOnDestroy);

        _scriptEnv.Get("onSpaceButtonDown", out _onSpaceButtonDown);
    }

    private void UnloadScriptMethods()
    {
        _luaAwake  = null;
        _luaStart  = null;
        _luaUpdate = null;
        _luaOnDestroy = null;
    }
}
