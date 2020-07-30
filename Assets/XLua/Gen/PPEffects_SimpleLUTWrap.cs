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
    public class PPEffectsSimpleLUTWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PPEffects.SimpleLUT);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 8, 8);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "LookupTexture", _g_get_LookupTexture);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Amount", _g_get_Amount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TintColor", _g_get_TintColor);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Hue", _g_get_Hue);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Saturation", _g_get_Saturation);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Brightness", _g_get_Brightness);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Contrast", _g_get_Contrast);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Sharpness", _g_get_Sharpness);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "LookupTexture", _s_set_LookupTexture);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Amount", _s_set_Amount);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "TintColor", _s_set_TintColor);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Hue", _s_set_Hue);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Saturation", _s_set_Saturation);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Brightness", _s_set_Brightness);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Contrast", _s_set_Contrast);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Sharpness", _s_set_Sharpness);
            
			
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
					
					PPEffects.SimpleLUT gen_ret = new PPEffects.SimpleLUT();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PPEffects.SimpleLUT constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LookupTexture(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.SimpleLUT gen_to_be_invoked = (PPEffects.SimpleLUT)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LookupTexture);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Amount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.SimpleLUT gen_to_be_invoked = (PPEffects.SimpleLUT)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Amount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TintColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.SimpleLUT gen_to_be_invoked = (PPEffects.SimpleLUT)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.TintColor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Hue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.SimpleLUT gen_to_be_invoked = (PPEffects.SimpleLUT)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Hue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Saturation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.SimpleLUT gen_to_be_invoked = (PPEffects.SimpleLUT)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Saturation);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Brightness(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.SimpleLUT gen_to_be_invoked = (PPEffects.SimpleLUT)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Brightness);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Contrast(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.SimpleLUT gen_to_be_invoked = (PPEffects.SimpleLUT)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Contrast);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Sharpness(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.SimpleLUT gen_to_be_invoked = (PPEffects.SimpleLUT)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Sharpness);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LookupTexture(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.SimpleLUT gen_to_be_invoked = (PPEffects.SimpleLUT)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LookupTexture = (UnityEngine.Rendering.PostProcessing.TextureParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.TextureParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Amount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.SimpleLUT gen_to_be_invoked = (PPEffects.SimpleLUT)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Amount = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TintColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.SimpleLUT gen_to_be_invoked = (PPEffects.SimpleLUT)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.TintColor = (UnityEngine.Rendering.PostProcessing.ColorParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.ColorParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Hue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.SimpleLUT gen_to_be_invoked = (PPEffects.SimpleLUT)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Hue = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Saturation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.SimpleLUT gen_to_be_invoked = (PPEffects.SimpleLUT)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Saturation = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Brightness(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.SimpleLUT gen_to_be_invoked = (PPEffects.SimpleLUT)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Brightness = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Contrast(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.SimpleLUT gen_to_be_invoked = (PPEffects.SimpleLUT)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Contrast = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Sharpness(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PPEffects.SimpleLUT gen_to_be_invoked = (PPEffects.SimpleLUT)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Sharpness = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
