#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class LuaScriptingLuaRoomWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(LuaScripting.LuaRoom);
			Utils.BeginObjectRegister(type, L, translator, 0, 22, 10, 5);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetUpRoom", _m_SetUpRoom);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Activate", _m_Activate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RerunRoomSettings", _m_RerunRoomSettings);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RegisterDomain", _m_RegisterDomain);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UnregisterDomain", _m_UnregisterDomain);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddGroupDomain", _m_AddGroupDomain);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RunGroupDomain", _m_RunGroupDomain);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddIndividualDomain", _m_AddIndividualDomain);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RunScriptInRoom", _m_RunScriptInRoom);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InstantiateCameraRig", _m_InstantiateCameraRig);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InstantiateAndRegisterObject", _m_InstantiateAndRegisterObject);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InstantiateObject", _m_InstantiateObject);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RegisterObject", _m_RegisterObject);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InstantiateIndividualGameObject", _m_InstantiateIndividualGameObject);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InstantiateGroup", _m_InstantiateGroup);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetObject", _m_GetObject);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetGroupDomain", _m_GetGroupDomain);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetIndividualDomain", _m_GetIndividualDomain);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetObjectKeys", _m_GetObjectKeys);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetGroupDomainNames", _m_GetGroupDomainNames);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetIndividualDomainNames", _m_GetIndividualDomainNames);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Dispose", _m_Dispose);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "RoomScriptPath", _g_get_RoomScriptPath);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "RoomName", _g_get_RoomName);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SceneName", _g_get_SceneName);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "RoomSettings", _g_get_RoomSettings);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "PlayMusicGlobal", _g_get_PlayMusicGlobal);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "RegisteredDomains", _g_get_RegisteredDomains);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Groups", _g_get_Groups);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Objects", _g_get_Objects);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IndividualDomains", _g_get_IndividualDomains);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "_registeredDomains", _g_get__registeredDomains);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "RoomName", _s_set_RoomName);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "SceneName", _s_set_SceneName);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "RoomSettings", _s_set_RoomSettings);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "PlayMusicGlobal", _s_set_PlayMusicGlobal);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "_registeredDomains", _s_set__registeredDomains);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					LuaScripting.LuaRoom gen_ret = new LuaScripting.LuaRoom();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to LuaScripting.LuaRoom constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetUpRoom(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.SetUpRoom(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Activate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        System.Collections.IEnumerator gen_ret = gen_to_be_invoked.Activate(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RerunRoomSettings(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.RerunRoomSettings(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterDomain(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LuaScripting.LuaDomain _domain = (LuaScripting.LuaDomain)translator.GetObject(L, 2, typeof(LuaScripting.LuaDomain));
                    
                        int gen_ret = gen_to_be_invoked.RegisterDomain( _domain );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnregisterDomain(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LuaScripting.LuaDomain _domain = (LuaScripting.LuaDomain)translator.GetObject(L, 2, typeof(LuaScripting.LuaDomain));
                    
                    gen_to_be_invoked.UnregisterDomain( _domain );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddGroupDomain(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<LuaScripting.LuaGroupDomain>(L, 2)) 
                {
                    LuaScripting.LuaGroupDomain _group = (LuaScripting.LuaGroupDomain)translator.GetObject(L, 2, typeof(LuaScripting.LuaGroupDomain));
                    
                    gen_to_be_invoked.AddGroupDomain( _group );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string _groupName = LuaAPI.lua_tostring(L, 2);
                    string _groupScriptPath = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.AddGroupDomain( _groupName, _groupScriptPath );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaScripting.LuaRoom.AddGroupDomain!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RunGroupDomain(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _groupDomainName = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.RunGroupDomain( _groupDomainName );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddIndividualDomain(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LuaScripting.LuaIndividualDomain _individualDomain = (LuaScripting.LuaIndividualDomain)translator.GetObject(L, 2, typeof(LuaScripting.LuaIndividualDomain));
                    
                    gen_to_be_invoked.AddIndividualDomain( _individualDomain );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RunScriptInRoom(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _path = LuaAPI.lua_tostring(L, 2);
                    XLua.LuaTable _environment = (XLua.LuaTable)translator.GetObject(L, 3, typeof(XLua.LuaTable));
                    string _debugName = LuaAPI.lua_tostring(L, 4);
                    
                    gen_to_be_invoked.RunScriptInRoom( _path, _environment, _debugName );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InstantiateCameraRig(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        UnityEngine.GameObject gen_ret = gen_to_be_invoked.InstantiateCameraRig(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InstantiateAndRegisterObject(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<string[]>(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    string _objectKey = LuaAPI.lua_tostring(L, 2);
                    string _objectType = LuaAPI.lua_tostring(L, 3);
                    string[] _components = (string[])translator.GetObject(L, 4, typeof(string[]));
                    bool _activate = LuaAPI.lua_toboolean(L, 5);
                    
                        UnityEngine.GameObject gen_ret = gen_to_be_invoked.InstantiateAndRegisterObject( _objectKey, _objectType, _components, _activate );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& translator.Assignable<string[]>(L, 4)) 
                {
                    string _objectKey = LuaAPI.lua_tostring(L, 2);
                    string _objectType = LuaAPI.lua_tostring(L, 3);
                    string[] _components = (string[])translator.GetObject(L, 4, typeof(string[]));
                    
                        UnityEngine.GameObject gen_ret = gen_to_be_invoked.InstantiateAndRegisterObject( _objectKey, _objectType, _components );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string _objectKey = LuaAPI.lua_tostring(L, 2);
                    string _objectType = LuaAPI.lua_tostring(L, 3);
                    
                        UnityEngine.GameObject gen_ret = gen_to_be_invoked.InstantiateAndRegisterObject( _objectKey, _objectType );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _objectKey = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.GameObject gen_ret = gen_to_be_invoked.InstantiateAndRegisterObject( _objectKey );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaScripting.LuaRoom.InstantiateAndRegisterObject!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InstantiateObject(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<string[]>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    string _objectType = LuaAPI.lua_tostring(L, 2);
                    string[] _components = (string[])translator.GetObject(L, 3, typeof(string[]));
                    bool _activate = LuaAPI.lua_toboolean(L, 4);
                    
                        UnityEngine.GameObject gen_ret = gen_to_be_invoked.InstantiateObject( _objectType, _components, _activate );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<string[]>(L, 3)) 
                {
                    string _objectType = LuaAPI.lua_tostring(L, 2);
                    string[] _components = (string[])translator.GetObject(L, 3, typeof(string[]));
                    
                        UnityEngine.GameObject gen_ret = gen_to_be_invoked.InstantiateObject( _objectType, _components );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _objectType = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.GameObject gen_ret = gen_to_be_invoked.InstantiateObject( _objectType );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1) 
                {
                    
                        UnityEngine.GameObject gen_ret = gen_to_be_invoked.InstantiateObject(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaScripting.LuaRoom.InstantiateObject!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterObject(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _objectKey = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.GameObject _objectToRegister = (UnityEngine.GameObject)translator.GetObject(L, 3, typeof(UnityEngine.GameObject));
                    
                    gen_to_be_invoked.RegisterObject( _objectKey, _objectToRegister );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InstantiateIndividualGameObject(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.GameObject>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)) 
                {
                    UnityEngine.GameObject _prefab = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    string _objectDomainName = LuaAPI.lua_tostring(L, 3);
                    string _scriptPath = LuaAPI.lua_tostring(L, 4);
                    
                        UnityEngine.GameObject gen_ret = gen_to_be_invoked.InstantiateIndividualGameObject( _prefab, _objectDomainName, _scriptPath );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 5) || LuaAPI.lua_type(L, 5) == LuaTypes.LUA_TSTRING)) 
                {
                    string _objectName = LuaAPI.lua_tostring(L, 2);
                    string _bundleName = LuaAPI.lua_tostring(L, 3);
                    string _objectDomainName = LuaAPI.lua_tostring(L, 4);
                    string _scriptPath = LuaAPI.lua_tostring(L, 5);
                    
                        UnityEngine.GameObject gen_ret = gen_to_be_invoked.InstantiateIndividualGameObject( _objectName, _bundleName, _objectDomainName, _scriptPath );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaScripting.LuaRoom.InstantiateIndividualGameObject!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InstantiateGroup(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.GameObject>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 5) || LuaAPI.lua_type(L, 5) == LuaTypes.LUA_TSTRING)) 
                {
                    UnityEngine.GameObject _prefab = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    int _membersCount = LuaAPI.xlua_tointeger(L, 3);
                    string _groupName = LuaAPI.lua_tostring(L, 4);
                    string _scriptPath = LuaAPI.lua_tostring(L, 5);
                    
                        LuaScripting.LuaGroupDomain gen_ret = gen_to_be_invoked.InstantiateGroup( _prefab, _membersCount, _groupName, _scriptPath );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 6&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& (LuaAPI.lua_isnil(L, 5) || LuaAPI.lua_type(L, 5) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 6) || LuaAPI.lua_type(L, 6) == LuaTypes.LUA_TSTRING)) 
                {
                    string _objectName = LuaAPI.lua_tostring(L, 2);
                    string _bundleName = LuaAPI.lua_tostring(L, 3);
                    int _membersCount = LuaAPI.xlua_tointeger(L, 4);
                    string _groupName = LuaAPI.lua_tostring(L, 5);
                    string _scriptPath = LuaAPI.lua_tostring(L, 6);
                    
                        LuaScripting.LuaGroupDomain gen_ret = gen_to_be_invoked.InstantiateGroup( _objectName, _bundleName, _membersCount, _groupName, _scriptPath );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaScripting.LuaRoom.InstantiateGroup!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetObject(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _objectKey = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.GameObject gen_ret = gen_to_be_invoked.GetObject( _objectKey );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGroupDomain(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _groupName = LuaAPI.lua_tostring(L, 2);
                    
                        LuaScripting.LuaGroupDomain gen_ret = gen_to_be_invoked.GetGroupDomain( _groupName );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetIndividualDomain(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _domainName = LuaAPI.lua_tostring(L, 2);
                    
                        LuaScripting.LuaIndividualDomain gen_ret = gen_to_be_invoked.GetIndividualDomain( _domainName );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetObjectKeys(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        System.Collections.Generic.List<string> gen_ret = gen_to_be_invoked.GetObjectKeys(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGroupDomainNames(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        System.Collections.Generic.List<string> gen_ret = gen_to_be_invoked.GetGroupDomainNames(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetIndividualDomainNames(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        System.Collections.Generic.List<string> gen_ret = gen_to_be_invoked.GetIndividualDomainNames(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Dispose(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Dispose(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RoomScriptPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.RoomScriptPath);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RoomName(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.RoomName);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SceneName(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.SceneName);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RoomSettings(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.RoomSettings);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PlayMusicGlobal(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.PlayMusicGlobal);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RegisteredDomains(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.RegisteredDomains);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Groups(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Groups);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Objects(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Objects);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IndividualDomains(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.IndividualDomains);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get__registeredDomains(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked._registeredDomains);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RoomName(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.RoomName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SceneName(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.SceneName = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RoomSettings(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.RoomSettings = (LuaScripting.LuaDomain)translator.GetObject(L, 2, typeof(LuaScripting.LuaDomain));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PlayMusicGlobal(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.PlayMusicGlobal = translator.GetDelegate<System.Action<string>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set__registeredDomains(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaRoom gen_to_be_invoked = (LuaScripting.LuaRoom)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked._registeredDomains = (System.Collections.Generic.List<LuaScripting.LuaDomain>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<LuaScripting.LuaDomain>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
