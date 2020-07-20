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
    public class UnityEngineRenderingPostProcessingColorGradingWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.Rendering.PostProcessing.ColorGrading);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 39, 39);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsEnabledAndSupported", _m_IsEnabledAndSupported);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "gradingMode", _g_get_gradingMode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "externalLut", _g_get_externalLut);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tonemapper", _g_get_tonemapper);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "toneCurveToeStrength", _g_get_toneCurveToeStrength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "toneCurveToeLength", _g_get_toneCurveToeLength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "toneCurveShoulderStrength", _g_get_toneCurveShoulderStrength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "toneCurveShoulderLength", _g_get_toneCurveShoulderLength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "toneCurveShoulderAngle", _g_get_toneCurveShoulderAngle);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "toneCurveGamma", _g_get_toneCurveGamma);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ldrLut", _g_get_ldrLut);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ldrLutContribution", _g_get_ldrLutContribution);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "temperature", _g_get_temperature);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tint", _g_get_tint);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "colorFilter", _g_get_colorFilter);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "hueShift", _g_get_hueShift);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "saturation", _g_get_saturation);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "brightness", _g_get_brightness);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "postExposure", _g_get_postExposure);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "contrast", _g_get_contrast);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mixerRedOutRedIn", _g_get_mixerRedOutRedIn);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mixerRedOutGreenIn", _g_get_mixerRedOutGreenIn);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mixerRedOutBlueIn", _g_get_mixerRedOutBlueIn);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mixerGreenOutRedIn", _g_get_mixerGreenOutRedIn);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mixerGreenOutGreenIn", _g_get_mixerGreenOutGreenIn);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mixerGreenOutBlueIn", _g_get_mixerGreenOutBlueIn);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mixerBlueOutRedIn", _g_get_mixerBlueOutRedIn);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mixerBlueOutGreenIn", _g_get_mixerBlueOutGreenIn);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mixerBlueOutBlueIn", _g_get_mixerBlueOutBlueIn);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "lift", _g_get_lift);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "gamma", _g_get_gamma);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "gain", _g_get_gain);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "masterCurve", _g_get_masterCurve);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "redCurve", _g_get_redCurve);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "greenCurve", _g_get_greenCurve);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "blueCurve", _g_get_blueCurve);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "hueVsHueCurve", _g_get_hueVsHueCurve);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "hueVsSatCurve", _g_get_hueVsSatCurve);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "satVsSatCurve", _g_get_satVsSatCurve);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "lumVsSatCurve", _g_get_lumVsSatCurve);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "gradingMode", _s_set_gradingMode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "externalLut", _s_set_externalLut);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "tonemapper", _s_set_tonemapper);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "toneCurveToeStrength", _s_set_toneCurveToeStrength);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "toneCurveToeLength", _s_set_toneCurveToeLength);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "toneCurveShoulderStrength", _s_set_toneCurveShoulderStrength);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "toneCurveShoulderLength", _s_set_toneCurveShoulderLength);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "toneCurveShoulderAngle", _s_set_toneCurveShoulderAngle);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "toneCurveGamma", _s_set_toneCurveGamma);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ldrLut", _s_set_ldrLut);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ldrLutContribution", _s_set_ldrLutContribution);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "temperature", _s_set_temperature);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "tint", _s_set_tint);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "colorFilter", _s_set_colorFilter);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "hueShift", _s_set_hueShift);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "saturation", _s_set_saturation);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "brightness", _s_set_brightness);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "postExposure", _s_set_postExposure);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "contrast", _s_set_contrast);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "mixerRedOutRedIn", _s_set_mixerRedOutRedIn);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "mixerRedOutGreenIn", _s_set_mixerRedOutGreenIn);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "mixerRedOutBlueIn", _s_set_mixerRedOutBlueIn);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "mixerGreenOutRedIn", _s_set_mixerGreenOutRedIn);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "mixerGreenOutGreenIn", _s_set_mixerGreenOutGreenIn);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "mixerGreenOutBlueIn", _s_set_mixerGreenOutBlueIn);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "mixerBlueOutRedIn", _s_set_mixerBlueOutRedIn);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "mixerBlueOutGreenIn", _s_set_mixerBlueOutGreenIn);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "mixerBlueOutBlueIn", _s_set_mixerBlueOutBlueIn);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "lift", _s_set_lift);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "gamma", _s_set_gamma);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "gain", _s_set_gain);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "masterCurve", _s_set_masterCurve);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "redCurve", _s_set_redCurve);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "greenCurve", _s_set_greenCurve);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "blueCurve", _s_set_blueCurve);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "hueVsHueCurve", _s_set_hueVsHueCurve);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "hueVsSatCurve", _s_set_hueVsSatCurve);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "satVsSatCurve", _s_set_satVsSatCurve);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "lumVsSatCurve", _s_set_lumVsSatCurve);
            
			
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
					
					UnityEngine.Rendering.PostProcessing.ColorGrading gen_ret = new UnityEngine.Rendering.PostProcessing.ColorGrading();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Rendering.PostProcessing.ColorGrading constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsEnabledAndSupported(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _g_get_gradingMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.gradingMode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_externalLut(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.externalLut);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tonemapper(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.tonemapper);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_toneCurveToeStrength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.toneCurveToeStrength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_toneCurveToeLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.toneCurveToeLength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_toneCurveShoulderStrength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.toneCurveShoulderStrength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_toneCurveShoulderLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.toneCurveShoulderLength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_toneCurveShoulderAngle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.toneCurveShoulderAngle);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_toneCurveGamma(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.toneCurveGamma);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ldrLut(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.ldrLut);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ldrLutContribution(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.ldrLutContribution);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_temperature(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.temperature);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.tint);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_colorFilter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.colorFilter);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_hueShift(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.hueShift);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_saturation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.saturation);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_brightness(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.brightness);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_postExposure(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.postExposure);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_contrast(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.contrast);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mixerRedOutRedIn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.mixerRedOutRedIn);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mixerRedOutGreenIn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.mixerRedOutGreenIn);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mixerRedOutBlueIn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.mixerRedOutBlueIn);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mixerGreenOutRedIn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.mixerGreenOutRedIn);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mixerGreenOutGreenIn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.mixerGreenOutGreenIn);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mixerGreenOutBlueIn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.mixerGreenOutBlueIn);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mixerBlueOutRedIn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.mixerBlueOutRedIn);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mixerBlueOutGreenIn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.mixerBlueOutGreenIn);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mixerBlueOutBlueIn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.mixerBlueOutBlueIn);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lift(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.lift);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_gamma(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.gamma);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_gain(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.gain);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_masterCurve(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.masterCurve);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_redCurve(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.redCurve);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_greenCurve(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.greenCurve);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_blueCurve(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.blueCurve);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_hueVsHueCurve(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.hueVsHueCurve);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_hueVsSatCurve(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.hueVsSatCurve);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_satVsSatCurve(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.satVsSatCurve);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lumVsSatCurve(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.lumVsSatCurve);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_gradingMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.gradingMode = (UnityEngine.Rendering.PostProcessing.GradingModeParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.GradingModeParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_externalLut(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.externalLut = (UnityEngine.Rendering.PostProcessing.TextureParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.TextureParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tonemapper(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.tonemapper = (UnityEngine.Rendering.PostProcessing.TonemapperParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.TonemapperParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_toneCurveToeStrength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.toneCurveToeStrength = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_toneCurveToeLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.toneCurveToeLength = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_toneCurveShoulderStrength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.toneCurveShoulderStrength = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_toneCurveShoulderLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.toneCurveShoulderLength = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_toneCurveShoulderAngle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.toneCurveShoulderAngle = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_toneCurveGamma(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.toneCurveGamma = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ldrLut(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ldrLut = (UnityEngine.Rendering.PostProcessing.TextureParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.TextureParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ldrLutContribution(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ldrLutContribution = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_temperature(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.temperature = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.tint = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_colorFilter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.colorFilter = (UnityEngine.Rendering.PostProcessing.ColorParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.ColorParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_hueShift(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.hueShift = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_saturation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.saturation = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_brightness(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.brightness = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_postExposure(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.postExposure = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_contrast(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.contrast = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mixerRedOutRedIn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.mixerRedOutRedIn = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mixerRedOutGreenIn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.mixerRedOutGreenIn = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mixerRedOutBlueIn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.mixerRedOutBlueIn = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mixerGreenOutRedIn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.mixerGreenOutRedIn = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mixerGreenOutGreenIn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.mixerGreenOutGreenIn = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mixerGreenOutBlueIn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.mixerGreenOutBlueIn = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mixerBlueOutRedIn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.mixerBlueOutRedIn = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mixerBlueOutGreenIn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.mixerBlueOutGreenIn = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mixerBlueOutBlueIn(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.mixerBlueOutBlueIn = (UnityEngine.Rendering.PostProcessing.FloatParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.FloatParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_lift(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.lift = (UnityEngine.Rendering.PostProcessing.Vector4Parameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.Vector4Parameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_gamma(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.gamma = (UnityEngine.Rendering.PostProcessing.Vector4Parameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.Vector4Parameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_gain(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.gain = (UnityEngine.Rendering.PostProcessing.Vector4Parameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.Vector4Parameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_masterCurve(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.masterCurve = (UnityEngine.Rendering.PostProcessing.SplineParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.SplineParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_redCurve(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.redCurve = (UnityEngine.Rendering.PostProcessing.SplineParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.SplineParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_greenCurve(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.greenCurve = (UnityEngine.Rendering.PostProcessing.SplineParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.SplineParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_blueCurve(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.blueCurve = (UnityEngine.Rendering.PostProcessing.SplineParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.SplineParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_hueVsHueCurve(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.hueVsHueCurve = (UnityEngine.Rendering.PostProcessing.SplineParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.SplineParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_hueVsSatCurve(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.hueVsSatCurve = (UnityEngine.Rendering.PostProcessing.SplineParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.SplineParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_satVsSatCurve(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.satVsSatCurve = (UnityEngine.Rendering.PostProcessing.SplineParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.SplineParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_lumVsSatCurve(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Rendering.PostProcessing.ColorGrading gen_to_be_invoked = (UnityEngine.Rendering.PostProcessing.ColorGrading)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.lumVsSatCurve = (UnityEngine.Rendering.PostProcessing.SplineParameter)translator.GetObject(L, 2, typeof(UnityEngine.Rendering.PostProcessing.SplineParameter));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
