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
    public class UnityEngineRenderingPostProcessingMotionBlurWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.Rendering.PostProcessing.MotionBlur);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 2, 2);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsEnabledAndSupported", _m_IsEnabledAndSupported);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "shutterAngle", _g_get_shutterAngle);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "sampleCount", _g_get_sampleCount);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "shutterAngle", _s_set_shutterAngle);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "sampleCount", _s_set_sampleCount);
            
			
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
					
					UnityEngine.Rendering.PostProcessing.MotionBlur gen_ret = new UnityEngine.Rendering.PostProcessing.MotionBlur();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Rendering.PostProcessing.MotionBlur constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsEnabledAndSupported(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.Rendering.PostProcessing.MotionBlur gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.MotionBlur)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _g_get_shutterAngle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.MotionBlur gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.MotionBlur)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.shutterAngle);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sampleCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.MotionBlur gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.MotionBlur)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.sampleCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shutterAngle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.MotionBlur gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.MotionBlur)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.shutterAngle = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_sampleCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.MotionBlur gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.MotionBlur)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.sampleCount = (UnityEngine.Rendering.PostProcessing.IntParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.IntParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
