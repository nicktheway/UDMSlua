﻿#if USE_UNI_LUA
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
    public class LuaScriptingLuaCameraObjectWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(LuaScripting.LuaCameraObject);
			Utils.BeginObjectRegister(type, L, translator, 0, 10, 6, 6);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FollowGroupAgent", _m_FollowGroupAgent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LookAtGroupAgent", _m_LookAtGroupAgent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetFollowTarget", _m_SetFollowTarget);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetLookAtTarget", _m_SetLookAtTarget);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetDollyPathPosition", _m_SetDollyPathPosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetDollyPathScale", _m_SetDollyPathScale);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "NewSmoothDollyPath", _m_NewSmoothDollyPath);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "NewDollyPath", _m_NewDollyPath);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DollyPathKeyExists", _m_DollyPathKeyExists);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetDollyPath", _m_GetDollyPath);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "FOV", _g_get_FOV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "PathPosition", _g_get_PathPosition);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "AutoDolly", _g_get_AutoDolly);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ActiveCamera", _g_get_ActiveCamera);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DollyPath", _g_get_DollyPath);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Cameras", _g_get_Cameras);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "FOV", _s_set_FOV);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "PathPosition", _s_set_PathPosition);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "AutoDolly", _s_set_AutoDolly);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ActiveCamera", _s_set_ActiveCamera);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "DollyPath", _s_set_DollyPath);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Cameras", _s_set_Cameras);
            
			
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
					
					LuaScripting.LuaCameraObject gen_ret = new LuaScripting.LuaCameraObject();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to LuaScripting.LuaCameraObject constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FollowGroupAgent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _groupName = LuaAPI.lua_tostring(L, 2);
                    int _agentId = LuaAPI.xlua_tointeger(L, 3);
                    UnityEngine.Vector3 _offset;translator.Get(L, 4, out _offset);
                    
                    gen_to_be_invoked.FollowGroupAgent( _groupName, _agentId, _offset );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LookAtGroupAgent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _groupName = LuaAPI.lua_tostring(L, 2);
                    int _agentId = LuaAPI.xlua_tointeger(L, 3);
                    UnityEngine.Vector3 _offset;translator.Get(L, 4, out _offset);
                    
                    gen_to_be_invoked.LookAtGroupAgent( _groupName, _agentId, _offset );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetFollowTarget(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Transform _targetTransform = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    UnityEngine.Vector3 _offset;translator.Get(L, 3, out _offset);
                    
                    gen_to_be_invoked.SetFollowTarget( _targetTransform, _offset );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLookAtTarget(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Transform _targetTransform = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    UnityEngine.Vector3 _offset;translator.Get(L, 3, out _offset);
                    
                    gen_to_be_invoked.SetLookAtTarget( _targetTransform, _offset );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDollyPathPosition(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 2);
                    float _y = (float)LuaAPI.lua_tonumber(L, 3);
                    float _z = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    gen_to_be_invoked.SetDollyPathPosition( _x, _y, _z );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDollyPathScale(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 2);
                    float _y = (float)LuaAPI.lua_tonumber(L, 3);
                    float _z = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    gen_to_be_invoked.SetDollyPathScale( _x, _y, _z );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NewSmoothDollyPath(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.Vector3[]>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    string _pathKey = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector3[] _waypoints = (UnityEngine.Vector3[])translator.GetObject(L, 3, typeof(UnityEngine.Vector3[]));
                    bool _looped = LuaAPI.lua_toboolean(L, 4);
                    
                        Cinemachine.CinemachinePathBase gen_ret = gen_to_be_invoked.NewSmoothDollyPath( _pathKey, _waypoints, _looped );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.Vector3[]>(L, 3)) 
                {
                    string _pathKey = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector3[] _waypoints = (UnityEngine.Vector3[])translator.GetObject(L, 3, typeof(UnityEngine.Vector3[]));
                    
                        Cinemachine.CinemachinePathBase gen_ret = gen_to_be_invoked.NewSmoothDollyPath( _pathKey, _waypoints );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaScripting.LuaCameraObject.NewSmoothDollyPath!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NewDollyPath(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.Vector3[]>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    string _pathKey = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector3[] _waypoints = (UnityEngine.Vector3[])translator.GetObject(L, 3, typeof(UnityEngine.Vector3[]));
                    bool _looped = LuaAPI.lua_toboolean(L, 4);
                    
                        Cinemachine.CinemachinePathBase gen_ret = gen_to_be_invoked.NewDollyPath( _pathKey, _waypoints, _looped );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.Vector3[]>(L, 3)) 
                {
                    string _pathKey = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Vector3[] _waypoints = (UnityEngine.Vector3[])translator.GetObject(L, 3, typeof(UnityEngine.Vector3[]));
                    
                        Cinemachine.CinemachinePathBase gen_ret = gen_to_be_invoked.NewDollyPath( _pathKey, _waypoints );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaScripting.LuaCameraObject.NewDollyPath!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DollyPathKeyExists(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _pathKey = LuaAPI.lua_tostring(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.DollyPathKeyExists( _pathKey );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDollyPath(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _pathKey = LuaAPI.lua_tostring(L, 2);
                    
                        Cinemachine.CinemachinePathBase gen_ret = gen_to_be_invoked.GetDollyPath( _pathKey );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FOV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.FOV);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PathPosition(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.PathPosition);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AutoDolly(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.AutoDolly);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ActiveCamera(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.ActiveCamera);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DollyPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.DollyPath);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Cameras(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Cameras);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FOV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.FOV = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PathPosition(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.PathPosition = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AutoDolly(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.AutoDolly = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ActiveCamera(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ActiveCamera = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DollyPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.DollyPath = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Cameras(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaCameraObject gen_to_be_invoked = (LuaScripting.LuaCameraObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Cameras = (Cinemachine.CinemachineVirtualCamera[])translator.GetObject(L, 2, typeof(Cinemachine.CinemachineVirtualCamera[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
