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
    public class UnityEngineRenderingPostProcessingRuntimeUtilitiesWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.Rendering.PostProcessing.RuntimeUtilities);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 15, 22, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetLutStrip", _m_GetLutStrip_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CopyTexture", _m_CopyTexture_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "isFloatingPointFormat", _m_isFloatingPointFormat_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Destroy", _m_Destroy_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsResolvedDepthAvailable", _m_IsResolvedDepthAvailable_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DestroyProfile", _m_DestroyProfile_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DestroyVolume", _m_DestroyVolume_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsPostProcessingActive", _m_IsPostProcessingActive_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsTemporalAntialiasingActive", _m_IsTemporalAntialiasingActive_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Exp2", _m_Exp2_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetJitteredPerspectiveProjectionMatrix", _m_GetJitteredPerspectiveProjectionMatrix_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetJitteredOrthographicProjectionMatrix", _m_GetJitteredOrthographicProjectionMatrix_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GenerateJitteredProjectionMatrixFromOriginal", _m_GenerateJitteredProjectionMatrixFromOriginal_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetAllAssemblyTypes", _m_GetAllAssemblyTypes_xlua_st_);
            
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "whiteTexture", _g_get_whiteTexture);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "whiteTexture3D", _g_get_whiteTexture3D);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "blackTexture", _g_get_blackTexture);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "blackTexture3D", _g_get_blackTexture3D);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "transparentTexture", _g_get_transparentTexture);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "transparentTexture3D", _g_get_transparentTexture3D);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "fullscreenTriangle", _g_get_fullscreenTriangle);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "copyStdMaterial", _g_get_copyStdMaterial);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "copyStdFromDoubleWideMaterial", _g_get_copyStdFromDoubleWideMaterial);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "copyMaterial", _g_get_copyMaterial);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "copyFromTexArrayMaterial", _g_get_copyFromTexArrayMaterial);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "copySheet", _g_get_copySheet);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "copyFromTexArraySheet", _g_get_copyFromTexArraySheet);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "scriptableRenderPipelineActive", _g_get_scriptableRenderPipelineActive);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "supportsDeferredShading", _g_get_supportsDeferredShading);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "supportsDepthNormals", _g_get_supportsDepthNormals);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "isSinglePassStereoSelected", _g_get_isSinglePassStereoSelected);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "isSinglePassStereoEnabled", _g_get_isSinglePassStereoEnabled);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "isVREnabled", _g_get_isVREnabled);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "isAndroidOpenGL", _g_get_isAndroidOpenGL);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "defaultHDRRenderTextureFormat", _g_get_defaultHDRRenderTextureFormat);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "isLinearColorSpace", _g_get_isLinearColorSpace);
            
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "UnityEngine.Rendering.PostProcessing.RuntimeUtilities does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLutStrip_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _size = LuaAPI.xlua_tointeger(L, 1);
                    
                        UnityEngine.Texture2D gen_ret = UnityEngine.Rendering.PostProcessing.RuntimeUtilities.GetLutStrip( _size );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CopyTexture_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Rendering.CommandBuffer _cmd = (UnityEngine.Rendering.CommandBuffer)translator.GetObject(L, 1, typeof(UnityEngine.Rendering.CommandBuffer));
                    UnityEngine.Rendering.RenderTargetIdentifier _source;translator.Get(L, 2, out _source);
                    UnityEngine.Rendering.RenderTargetIdentifier _destination;translator.Get(L, 3, out _destination);
                    
                    UnityEngine.Rendering.PostProcessing.RuntimeUtilities.CopyTexture( _cmd, _source, _destination );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_isFloatingPointFormat_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.RenderTextureFormat _format;translator.Get(L, 1, out _format);
                    
                        bool gen_ret = UnityEngine.Rendering.PostProcessing.RuntimeUtilities.isFloatingPointFormat( _format );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Destroy_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Object _obj = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    
                    UnityEngine.Rendering.PostProcessing.RuntimeUtilities.Destroy( _obj );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsResolvedDepthAvailable_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Camera _camera = (UnityEngine.Camera)translator.GetObject(L, 1, typeof(UnityEngine.Camera));
                    
                        bool gen_ret = UnityEngine.Rendering.PostProcessing.RuntimeUtilities.IsResolvedDepthAvailable( _camera );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyProfile_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Rendering.PostProcessing.PostProcessProfile _profile = (UnityEngine.Rendering.PostProcessing.PostProcessProfile)translator.GetObject(L, 1, typeof(UnityEngine.Rendering.PostProcessing.PostProcessProfile));
                    bool _destroyEffects = LuaAPI.lua_toboolean(L, 2);
                    
                    UnityEngine.Rendering.PostProcessing.RuntimeUtilities.DestroyProfile( _profile, _destroyEffects );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyVolume_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rendering.PostProcessing.PostProcessVolume>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Rendering.PostProcessing.PostProcessVolume _volume = (UnityEngine.Rendering.PostProcessing.PostProcessVolume)translator.GetObject(L, 1, typeof(UnityEngine.Rendering.PostProcessing.PostProcessVolume));
                    bool _destroyProfile = LuaAPI.lua_toboolean(L, 2);
                    bool _destroyGameObject = LuaAPI.lua_toboolean(L, 3);
                    
                    UnityEngine.Rendering.PostProcessing.RuntimeUtilities.DestroyVolume( _volume, _destroyProfile, _destroyGameObject );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Rendering.PostProcessing.PostProcessVolume>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    UnityEngine.Rendering.PostProcessing.PostProcessVolume _volume = (UnityEngine.Rendering.PostProcessing.PostProcessVolume)translator.GetObject(L, 1, typeof(UnityEngine.Rendering.PostProcessing.PostProcessVolume));
                    bool _destroyProfile = LuaAPI.lua_toboolean(L, 2);
                    
                    UnityEngine.Rendering.PostProcessing.RuntimeUtilities.DestroyVolume( _volume, _destroyProfile );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Rendering.PostProcessing.RuntimeUtilities.DestroyVolume!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsPostProcessingActive_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Rendering.PostProcessing.PostProcessLayer _layer = (UnityEngine.Rendering.PostProcessing.PostProcessLayer)translator.GetObject(L, 1, typeof(UnityEngine.Rendering.PostProcessing.PostProcessLayer));
                    
                        bool gen_ret = UnityEngine.Rendering.PostProcessing.RuntimeUtilities.IsPostProcessingActive( _layer );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsTemporalAntialiasingActive_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Rendering.PostProcessing.PostProcessLayer _layer = (UnityEngine.Rendering.PostProcessing.PostProcessLayer)translator.GetObject(L, 1, typeof(UnityEngine.Rendering.PostProcessing.PostProcessLayer));
                    
                        bool gen_ret = UnityEngine.Rendering.PostProcessing.RuntimeUtilities.IsTemporalAntialiasingActive( _layer );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Exp2_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        float gen_ret = UnityEngine.Rendering.PostProcessing.RuntimeUtilities.Exp2( _x );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetJitteredPerspectiveProjectionMatrix_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Camera _camera = (UnityEngine.Camera)translator.GetObject(L, 1, typeof(UnityEngine.Camera));
                    UnityEngine.Vector2 _offset;translator.Get(L, 2, out _offset);
                    
                        UnityEngine.Matrix4x4 gen_ret = UnityEngine.Rendering.PostProcessing.RuntimeUtilities.GetJitteredPerspectiveProjectionMatrix( _camera, _offset );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetJitteredOrthographicProjectionMatrix_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Camera _camera = (UnityEngine.Camera)translator.GetObject(L, 1, typeof(UnityEngine.Camera));
                    UnityEngine.Vector2 _offset;translator.Get(L, 2, out _offset);
                    
                        UnityEngine.Matrix4x4 gen_ret = UnityEngine.Rendering.PostProcessing.RuntimeUtilities.GetJitteredOrthographicProjectionMatrix( _camera, _offset );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GenerateJitteredProjectionMatrixFromOriginal_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Rendering.PostProcessing.PostProcessRenderContext _context = (UnityEngine.Rendering.PostProcessing.PostProcessRenderContext)translator.GetObject(L, 1, typeof(UnityEngine.Rendering.PostProcessing.PostProcessRenderContext));
                    UnityEngine.Matrix4x4 _origProj;translator.Get(L, 2, out _origProj);
                    UnityEngine.Vector2 _jitter;translator.Get(L, 3, out _jitter);
                    
                        UnityEngine.Matrix4x4 gen_ret = UnityEngine.Rendering.PostProcessing.RuntimeUtilities.GenerateJitteredProjectionMatrixFromOriginal( _context, _origProj, _jitter );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllAssemblyTypes_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        System.Collections.Generic.IEnumerable<System.Type> gen_ret = UnityEngine.Rendering.PostProcessing.RuntimeUtilities.GetAllAssemblyTypes(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_whiteTexture(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.whiteTexture);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_whiteTexture3D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.whiteTexture3D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_blackTexture(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.blackTexture);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_blackTexture3D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.blackTexture3D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_transparentTexture(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.transparentTexture);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_transparentTexture3D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.transparentTexture3D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fullscreenTriangle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.fullscreenTriangle);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_copyStdMaterial(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.copyStdMaterial);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_copyStdFromDoubleWideMaterial(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.copyStdFromDoubleWideMaterial);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_copyMaterial(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.copyMaterial);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_copyFromTexArrayMaterial(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.copyFromTexArrayMaterial);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_copySheet(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.copySheet);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_copyFromTexArraySheet(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.copyFromTexArraySheet);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_scriptableRenderPipelineActive(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.scriptableRenderPipelineActive);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_supportsDeferredShading(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.supportsDeferredShading);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_supportsDepthNormals(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.supportsDepthNormals);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isSinglePassStereoSelected(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.isSinglePassStereoSelected);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isSinglePassStereoEnabled(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.isSinglePassStereoEnabled);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isVREnabled(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.isVREnabled);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isAndroidOpenGL(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.isAndroidOpenGL);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_defaultHDRRenderTextureFormat(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.defaultHDRRenderTextureFormat);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isLinearColorSpace(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, UnityEngine.Rendering.PostProcessing.RuntimeUtilities.isLinearColorSpace);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
