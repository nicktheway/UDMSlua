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
    public class UnityEngineRenderingPostProcessingPostProcessManagerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.Rendering.PostProcessing.PostProcessManager);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 1, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetActiveVolumes", _m_GetActiveVolumes);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetHighestPriorityVolume", _m_GetHighestPriorityVolume);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "QuickVolume", _m_QuickVolume);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "settingsTypes", _g_get_settingsTypes);
            
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 1, 0);
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "instance", _g_get_instance);
            
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "UnityEngine.Rendering.PostProcessing.PostProcessManager does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetActiveVolumes(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.Rendering.PostProcessing.PostProcessManager gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.PostProcessManager)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Rendering.PostProcessing.PostProcessLayer>(L, 2)&& translator.Assignable<System.Collections.Generic.List<UnityEngine.Rendering.PostProcessing.PostProcessVolume>>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    UnityEngine.Rendering.PostProcessing.PostProcessLayer _layer = (UnityEngine.Rendering.PostProcessing.PostProcessLayer)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.PostProcessLayer));
                    System.Collections.Generic.List<UnityEngine.Rendering.PostProcessing.PostProcessVolume> _results = (System.Collections.Generic.List<UnityEngine.Rendering.PostProcessing.PostProcessVolume>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<UnityEngine.Rendering.PostProcessing.PostProcessVolume>));
                    bool _skipDisabled = LuaAPI.lua_toboolean(L, 4);
                    bool _skipZeroWeight = LuaAPI.lua_toboolean(L, 5);
                    
                    gen_to_be_invoked.GetActiveVolumes( _layer, _results, _skipDisabled, _skipZeroWeight );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Rendering.PostProcessing.PostProcessLayer>(L, 2)&& translator.Assignable<System.Collections.Generic.List<UnityEngine.Rendering.PostProcessing.PostProcessVolume>>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Rendering.PostProcessing.PostProcessLayer _layer = (UnityEngine.Rendering.PostProcessing.PostProcessLayer)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.PostProcessLayer));
                    System.Collections.Generic.List<UnityEngine.Rendering.PostProcessing.PostProcessVolume> _results = (System.Collections.Generic.List<UnityEngine.Rendering.PostProcessing.PostProcessVolume>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<UnityEngine.Rendering.PostProcessing.PostProcessVolume>));
                    bool _skipDisabled = LuaAPI.lua_toboolean(L, 4);
                    
                    gen_to_be_invoked.GetActiveVolumes( _layer, _results, _skipDisabled );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rendering.PostProcessing.PostProcessLayer>(L, 2)&& translator.Assignable<System.Collections.Generic.List<UnityEngine.Rendering.PostProcessing.PostProcessVolume>>(L, 3)) 
                {
                    UnityEngine.Rendering.PostProcessing.PostProcessLayer _layer = (UnityEngine.Rendering.PostProcessing.PostProcessLayer)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.PostProcessLayer));
                    System.Collections.Generic.List<UnityEngine.Rendering.PostProcessing.PostProcessVolume> _results = (System.Collections.Generic.List<UnityEngine.Rendering.PostProcessing.PostProcessVolume>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<UnityEngine.Rendering.PostProcessing.PostProcessVolume>));
                    
                    gen_to_be_invoked.GetActiveVolumes( _layer, _results );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Rendering.PostProcessing.PostProcessManager.GetActiveVolumes!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHighestPriorityVolume(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.Rendering.PostProcessing.PostProcessManager gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.PostProcessManager)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Rendering.PostProcessing.PostProcessLayer>(L, 2)) 
                {
                    UnityEngine.Rendering.PostProcessing.PostProcessLayer _layer = (UnityEngine.Rendering.PostProcessing.PostProcessLayer)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.PostProcessLayer));
                    
                        UnityEngine.Rendering.PostProcessing.PostProcessVolume gen_ret = gen_to_be_invoked.GetHighestPriorityVolume( _layer );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.LayerMask>(L, 2)) 
                {
                    UnityEngine.LayerMask _mask;translator.Get(L, 2, out _mask);
                    
                        UnityEngine.Rendering.PostProcessing.PostProcessVolume gen_ret = gen_to_be_invoked.GetHighestPriorityVolume( _mask );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Rendering.PostProcessing.PostProcessManager.GetHighestPriorityVolume!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_QuickVolume(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.Rendering.PostProcessing.PostProcessManager gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.PostProcessManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _layer = LuaAPI.xlua_tointeger(L, 2);
                    float _priority = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Rendering.PostProcessing.PostProcessEffectSettings[] _settings = translator.GetParams<UnityEngine.Rendering.PostProcessing.PostProcessEffectSettings>(L, 4);
                    
                        UnityEngine.Rendering.PostProcessing.PostProcessVolume gen_ret = gen_to_be_invoked.QuickVolume( _layer, _priority, _settings );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_instance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.Rendering.PostProcessing.PostProcessManager.instance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_settingsTypes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.PostProcessManager gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.PostProcessManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.settingsTypes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
