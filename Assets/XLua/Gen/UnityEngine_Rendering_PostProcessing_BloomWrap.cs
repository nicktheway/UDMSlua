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
    public class UnityEngineRenderingPostProcessingBloomWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.Rendering.PostProcessing.Bloom);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 10, 10);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsEnabledAndSupported", _m_IsEnabledAndSupported);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "intensity", _g_get_intensity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "threshold", _g_get_threshold);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "softKnee", _g_get_softKnee);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "clamp", _g_get_clamp);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "diffusion", _g_get_diffusion);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "anamorphicRatio", _g_get_anamorphicRatio);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "color", _g_get_color);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "fastMode", _g_get_fastMode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "dirtTexture", _g_get_dirtTexture);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "dirtIntensity", _g_get_dirtIntensity);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "intensity", _s_set_intensity);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "threshold", _s_set_threshold);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "softKnee", _s_set_softKnee);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "clamp", _s_set_clamp);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "diffusion", _s_set_diffusion);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "anamorphicRatio", _s_set_anamorphicRatio);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "color", _s_set_color);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "fastMode", _s_set_fastMode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "dirtTexture", _s_set_dirtTexture);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "dirtIntensity", _s_set_dirtIntensity);
            
			
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
					
					UnityEngine.Rendering.PostProcessing.Bloom gen_ret = new UnityEngine.Rendering.PostProcessing.Bloom();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Rendering.PostProcessing.Bloom constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsEnabledAndSupported(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.Rendering.PostProcessing.Bloom gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Bloom)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _g_get_intensity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Bloom gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Bloom)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.intensity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_threshold(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Bloom gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Bloom)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.threshold);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_softKnee(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Bloom gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Bloom)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.softKnee);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_clamp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Bloom gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Bloom)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.clamp);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_diffusion(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Bloom gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Bloom)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.diffusion);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_anamorphicRatio(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Bloom gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Bloom)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.anamorphicRatio);
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
			
                UnityEngine.Rendering.PostProcessing.Bloom gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Bloom)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.color);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fastMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Bloom gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Bloom)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.fastMode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_dirtTexture(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Bloom gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Bloom)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.dirtTexture);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_dirtIntensity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Bloom gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Bloom)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.dirtIntensity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_intensity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Bloom gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Bloom)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.intensity = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_threshold(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Bloom gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Bloom)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.threshold = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_softKnee(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Bloom gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Bloom)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.softKnee = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_clamp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Bloom gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Bloom)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.clamp = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_diffusion(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Bloom gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Bloom)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.diffusion = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_anamorphicRatio(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Bloom gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Bloom)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.anamorphicRatio = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
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
			
                UnityEngine.Rendering.PostProcessing.Bloom gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Bloom)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.color = (UnityEngine.Rendering.PostProcessing.ColorParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.ColorParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_fastMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Bloom gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Bloom)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.fastMode = (UnityEngine.Rendering.PostProcessing.BoolParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.BoolParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_dirtTexture(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Bloom gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Bloom)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.dirtTexture = (UnityEngine.Rendering.PostProcessing.TextureParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.TextureParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_dirtIntensity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.Bloom gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.Bloom)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.dirtIntensity = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
