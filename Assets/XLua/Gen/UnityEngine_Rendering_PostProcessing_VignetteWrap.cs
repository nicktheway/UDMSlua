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
    public class UnityEngineRenderingPostProcessingVignetteWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.Rendering.PostProcessing.Vignette);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 9, 9);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsEnabledAndSupported", _m_IsEnabledAndSupported);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "mode", _g_get_mode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "color", _g_get_color);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "center", _g_get_center);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "intensity", _g_get_intensity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "smoothness", _g_get_smoothness);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "roundness", _g_get_roundness);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "rounded", _g_get_rounded);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mask", _g_get_mask);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "opacity", _g_get_opacity);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "mode", _s_set_mode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "color", _s_set_color);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "center", _s_set_center);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "intensity", _s_set_intensity);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "smoothness", _s_set_smoothness);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "roundness", _s_set_roundness);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "rounded", _s_set_rounded);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "mask", _s_set_mask);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "opacity", _s_set_opacity);
            
			
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
					
					UnityEngine.Rendering.PostProcessing.Vignette gen_ret = new UnityEngine.Rendering.PostProcessing.Vignette();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Rendering.PostProcessing.Vignette constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsEnabledAndSupported(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.Rendering.PostProcessing.Vignette gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Vignette)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Rendering.PostProcessing.PostProcessRenderContext _context = (UnityEngine.Rendering.PostProcessing.PostProcessRenderContext)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.PostProcessRenderContext));
                    
                        bool gen_ret = gen_to_be_invoked.IsEnabledAndSupported( _context );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Vignette gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Vignette)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.mode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_color(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Vignette gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Vignette)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.color);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_center(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Vignette gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Vignette)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.center);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_intensity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Vignette gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Vignette)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.intensity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_smoothness(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Vignette gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Vignette)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.smoothness);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_roundness(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Vignette gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Vignette)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.roundness);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rounded(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Vignette gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Vignette)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.rounded);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Vignette gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Vignette)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.mask);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_opacity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Vignette gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Vignette)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.opacity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Vignette gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Vignette)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.mode = (UnityEngine.Rendering.PostProcessing.VignetteModeParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.VignetteModeParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_color(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Vignette gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Vignette)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.color = (UnityEngine.Rendering.PostProcessing.ColorParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.ColorParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_center(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Vignette gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Vignette)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.center = (UnityEngine.Rendering.PostProcessing.Vector2Parameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.Vector2Parameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_intensity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Vignette gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Vignette)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.intensity = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_smoothness(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Vignette gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Vignette)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.smoothness = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_roundness(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Vignette gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Vignette)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.roundness = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_rounded(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Vignette gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Vignette)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.rounded = (UnityEngine.Rendering.PostProcessing.BoolParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.BoolParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Vignette gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Vignette)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.mask = (UnityEngine.Rendering.PostProcessing.TextureParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.TextureParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_opacity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Vignette gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Vignette)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.opacity = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
