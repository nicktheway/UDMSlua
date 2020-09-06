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
    public class LuaScriptingLuaGroupObjectWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(LuaScripting.LuaGroupObject);
			Utils.BeginObjectRegister(type, L, translator, 0, 17, 3, 3);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetNeighbours", _m_SetNeighbours);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetState", _m_SetState);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAgentNearest", _m_GetAgentNearest);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DirAttractRepel", _m_DirAttractRepel);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DirAvoidAgent", _m_DirAvoidAgent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DirAvoidNearestAgent", _m_DirAvoidNearestAgent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DirOfNearest", _m_DirOfNearest);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DirToAgent", _m_DirToAgent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DirToHood", _m_DirToHood);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DirToNearest", _m_DirToNearest);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNearestActive", _m_GetNearestActive);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DirToNearestActive", _m_DirToNearestActive);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DistToAgent", _m_DistToAgent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DistToHood", _m_DistToHood);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DistToNearest", _m_DistToNearest);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DistToNearestActive", _m_DistToNearestActive);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetHoodCenter", _m_GetHoodCenter);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "GroupMemberId", _g_get_GroupMemberId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaDomain", _g_get_LuaDomain);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Neighbours", _g_get_Neighbours);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "GroupMemberId", _s_set_GroupMemberId);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaDomain", _s_set_LuaDomain);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Neighbours", _s_set_Neighbours);
            
			
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
					
					LuaScripting.LuaGroupObject gen_ret = new LuaScripting.LuaGroupObject();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to LuaScripting.LuaGroupObject constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetNeighbours(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int[] _neighbours = (int[])translator.GetObject(L, 2, typeof(int[]));
                    
                    gen_to_be_invoked.SetNeighbours( _neighbours );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetState(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _value = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.SetState( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAgentNearest(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int gen_ret = gen_to_be_invoked.GetAgentNearest(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DirAttractRepel(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _agentId = LuaAPI.xlua_tointeger(L, 2);
                    float _distance = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.DirAttractRepel( _agentId, _distance );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DirAvoidAgent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _agentId = LuaAPI.xlua_tointeger(L, 2);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.DirAvoidAgent( _agentId );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DirAvoidNearestAgent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.DirAvoidNearestAgent(  );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DirOfNearest(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.DirOfNearest(  );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DirToAgent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _agentId = LuaAPI.xlua_tointeger(L, 2);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.DirToAgent( _agentId );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DirToHood(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _radius = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.DirToHood( _radius );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DirToNearest(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.DirToNearest(  );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNearestActive(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int gen_ret = gen_to_be_invoked.GetNearestActive(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DirToNearestActive(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.DirToNearestActive(  );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DistToAgent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _agentId = LuaAPI.xlua_tointeger(L, 2);
                    
                        float gen_ret = gen_to_be_invoked.DistToAgent( _agentId );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DistToHood(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _radius = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        float gen_ret = gen_to_be_invoked.DistToHood( _radius );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DistToNearest(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        float gen_ret = gen_to_be_invoked.DistToNearest(  );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DistToNearestActive(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        float gen_ret = gen_to_be_invoked.DistToNearestActive(  );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHoodCenter(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _radius = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.GetHoodCenter( _radius );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GroupMemberId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.GroupMemberId);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaDomain(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaDomain);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Neighbours(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Neighbours);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GroupMemberId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.GroupMemberId = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaDomain(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaDomain = (LuaScripting.LuaDomain)translator.GetObject(L, 2, typeof(LuaScripting.LuaDomain));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Neighbours(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupObject gen_to_be_invoked = (LuaScripting.LuaGroupObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Neighbours = (System.Collections.Generic.List<int>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<int>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
