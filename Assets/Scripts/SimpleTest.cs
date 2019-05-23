using System;
using LuaScripting;
using UnityEngine;
using XLua;

public class SimpleTest : MonoBehaviour
{
    private static readonly string ScriptsPath = Application.streamingAssetsPath + "/Scripts";

    public int ObjectId = 0;

    /// <summary>
    /// The path of the script in the Streaming Assets folder.
    /// </summary>
    public string ScriptPath = "test.lua";

    private readonly LuaTable _scriptEnv = LuaManager.LuaEnv.NewTable();

    // Unity Callbacks
    private Action _luaAwake;
    private Action _luaStart;
    private Action _luaUpdate;
    private Action _luaOnDestroy;
    private Action _luaOnAnimatorIK;

    // Input Callbacks
    private Action _onSpaceButtonDown;

    private void Awake()
    {
        LuaManager.AttachGlobalTableAsDefault(_scriptEnv);

        SetScriptSymbols();

        //DoScript();
        LuaManager.DoScript(ScriptPath, _scriptEnv, "LUL");

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
        LuaManager.DoScript(ScriptPath, _scriptEnv, "LUL");
        LoadScriptMethods();
    }

    private void OnDestroy()
    {
        _luaOnDestroy?.Invoke();

        UnloadScriptMethods();
    }


    private void SetScriptSymbols()
    {
        // self <-> this, like in python.
        _scriptEnv.Set("self", this);
    }

    private void LoadScriptMethods()
    {
        _scriptEnv.Get("awake", out _luaAwake);
        _scriptEnv.Get("start", out _luaStart);
        _scriptEnv.Get("update", out _luaUpdate);
        _scriptEnv.Get("onDestroy", out _luaOnDestroy);
        _scriptEnv.Get("onAnimatorIK", out _luaOnAnimatorIK);

        _scriptEnv.Get("onSpaceButtonDown", out _onSpaceButtonDown);
    }

    private void UnloadScriptMethods()
    {
        _luaAwake  = null;
        _luaStart  = null;
        _luaUpdate = null;
        _luaOnDestroy = null;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        _luaOnAnimatorIK?.Invoke();
    }
}
