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
    public class PPEffectsDuoToneWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PPEffects.DuoTone);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 4, 4);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "MinLimit", _g_get_MinLimit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MaxLimit", _g_get_MaxLimit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Color1", _g_get_Color1);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Color2", _g_get_Color2);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "MinLimit", _s_set_MinLimit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "MaxLimit", _s_set_MaxLimit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Color1", _s_set_Color1);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Color2", _s_set_Color2);
            
			
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
					
					PPEffects.DuoTone gen_ret = new PPEffects.DuoTone();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PPEffects.DuoTone constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MinLimit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.DuoTone gen_to_be_invoked = (PPEffects.DuoTone)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.MinLimit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxLimit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.DuoTone gen_to_be_invoked = (PPEffects.DuoTone)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.MaxLimit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Color1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.DuoTone gen_to_be_invoked = (PPEffects.DuoTone)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Color1);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Color2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.DuoTone gen_to_be_invoked = (PPEffects.DuoTone)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Color2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MinLimit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.DuoTone gen_to_be_invoked = (PPEffects.DuoTone)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.MinLimit = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaxLimit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.DuoTone gen_to_be_invoked = (PPEffects.DuoTone)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.MaxLimit = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Color1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.DuoTone gen_to_be_invoked = (PPEffects.DuoTone)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Color1 = (UnityEngine.Rendering.PostProcessing.ColorParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.ColorParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Color2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.DuoTone gen_to_be_invoked = (PPEffects.DuoTone)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Color2 = (UnityEngine.Rendering.PostProcessing.ColorParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.ColorParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
