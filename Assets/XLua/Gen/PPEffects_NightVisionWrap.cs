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
    public class PPEffectsNightVisionWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PPEffects.NightVision);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 8, 8);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Timer", _g_get_Timer);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LinesAmount", _g_get_LinesAmount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LinesStrength", _g_get_LinesStrength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "NoiseSaturation", _g_get_NoiseSaturation);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "NoiseStrength", _g_get_NoiseStrength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuminosityThreshold", _g_get_LuminosityThreshold);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Amplification", _g_get_Amplification);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TextureOffset", _g_get_TextureOffset);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Timer", _s_set_Timer);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LinesAmount", _s_set_LinesAmount);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LinesStrength", _s_set_LinesStrength);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "NoiseSaturation", _s_set_NoiseSaturation);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "NoiseStrength", _s_set_NoiseStrength);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuminosityThreshold", _s_set_LuminosityThreshold);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Amplification", _s_set_Amplification);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "TextureOffset", _s_set_TextureOffset);
            
			
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
					
					PPEffects.NightVision gen_ret = new PPEffects.NightVision();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PPEffects.NightVision constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Timer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.NightVision gen_to_be_invoked = (PPEffects.NightVision)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Timer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LinesAmount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.NightVision gen_to_be_invoked = (PPEffects.NightVision)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LinesAmount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LinesStrength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.NightVision gen_to_be_invoked = (PPEffects.NightVision)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LinesStrength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NoiseSaturation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.NightVision gen_to_be_invoked = (PPEffects.NightVision)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.NoiseSaturation);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_NoiseStrength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.NightVision gen_to_be_invoked = (PPEffects.NightVision)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.NoiseStrength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuminosityThreshold(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.NightVision gen_to_be_invoked = (PPEffects.NightVision)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuminosityThreshold);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Amplification(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.NightVision gen_to_be_invoked = (PPEffects.NightVision)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Amplification);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TextureOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.NightVision gen_to_be_invoked = (PPEffects.NightVision)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.TextureOffset);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Timer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.NightVision gen_to_be_invoked = (PPEffects.NightVision)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Timer = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LinesAmount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.NightVision gen_to_be_invoked = (PPEffects.NightVision)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LinesAmount = (UnityEngine.Rendering.PostProcessing.IntParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.IntParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LinesStrength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.NightVision gen_to_be_invoked = (PPEffects.NightVision)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LinesStrength = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NoiseSaturation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.NightVision gen_to_be_invoked = (PPEffects.NightVision)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.NoiseSaturation = (UnityEngine.Rendering.PostProcessing.BoolParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.BoolParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_NoiseStrength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.NightVision gen_to_be_invoked = (PPEffects.NightVision)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.NoiseStrength = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuminosityThreshold(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.NightVision gen_to_be_invoked = (PPEffects.NightVision)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuminosityThreshold = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Amplification(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.NightVision gen_to_be_invoked = (PPEffects.NightVision)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Amplification = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TextureOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.NightVision gen_to_be_invoked = (PPEffects.NightVision)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.TextureOffset = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
