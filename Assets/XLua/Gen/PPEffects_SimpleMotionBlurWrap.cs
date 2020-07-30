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
    public class PPEffectsSimpleMotionBlurWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PPEffects.SimpleMotionBlur);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 2, 2);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "BlurAmount", _g_get_BlurAmount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ExtraBlur", _g_get_ExtraBlur);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "BlurAmount", _s_set_BlurAmount);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ExtraBlur", _s_set_ExtraBlur);
            
			
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
					
					PPEffects.SimpleMotionBlur gen_ret = new PPEffects.SimpleMotionBlur();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PPEffects.SimpleMotionBlur constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BlurAmount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.SimpleMotionBlur gen_to_be_invoked = (PPEffects.SimpleMotionBlur)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.BlurAmount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ExtraBlur(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.SimpleMotionBlur gen_to_be_invoked = (PPEffects.SimpleMotionBlur)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.ExtraBlur);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_BlurAmount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.SimpleMotionBlur gen_to_be_invoked = (PPEffects.SimpleMotionBlur)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.BlurAmount = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ExtraBlur(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.SimpleMotionBlur gen_to_be_invoked = (PPEffects.SimpleMotionBlur)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ExtraBlur = (UnityEngine.Rendering.PostProcessing.BoolParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.BoolParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
