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
    public class K_PathFinderPathFinderSceneWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(K_PathFinder.PathFinderScene);
			Utils.BeginObjectRegister(type, L, translator, 0, 15, 2, 2);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MoveNext", _m_MoveNext);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetCoroutine", _m_SetCoroutine);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Init", _m_Init);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InitComputeShaderRasterization3D", _m_InitComputeShaderRasterization3D);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InitComputeShaderRasterization2D", _m_InitComputeShaderRasterization2D);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Rasterize3D", _m_Rasterize3D);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Rasterize2D", _m_Rasterize2D);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StopAll", _m_StopAll);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Shutdown", _m_Shutdown);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InitDebugBuffers", _m_InitDebugBuffers);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateStaticData", _m_UpdateStaticData);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateDynamicData", _m_UpdateDynamicData);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateGenericDots", _m_UpdateGenericDots);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateGenericLines", _m_UpdateGenericLines);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateGenericTris", _m_UpdateGenericTris);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "sceneNavmeshData", _g_get_sceneNavmeshData);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "gameObjectLibrary", _g_get_gameObjectLibrary);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "sceneNavmeshData", _s_set_sceneNavmeshData);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "gameObjectLibrary", _s_set_gameObjectLibrary);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 3, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "SetAlpha", _m_SetAlpha_xlua_st_);
            
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PATHFINDER_DEBUG_SCENE_BUFFER_COUNT", K_PathFinder.PathFinderScene.PATHFINDER_DEBUG_SCENE_BUFFER_COUNT);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					K_PathFinder.PathFinderScene gen_ret = new K_PathFinder.PathFinderScene();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinderScene constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveNext(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderScene gen_to_be_invoked = (K_PathFinder.PathFinderScene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.MoveNext(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAlpha_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Color _color;translator.Get(L, 1, out _color);
                    float _alpha = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        UnityEngine.Color gen_ret = K_PathFinder.PathFinderScene.SetAlpha( _color, _alpha );
                        translator.PushUnityEngineColor(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCoroutine(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderScene gen_to_be_invoked = (K_PathFinder.PathFinderScene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.IEnumerator _iEnumerator = (System.Collections.IEnumerator)translator.GetObject(L, 2, typeof(System.Collections.IEnumerator));
                    
                    gen_to_be_invoked.SetCoroutine( _iEnumerator );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderScene gen_to_be_invoked = (K_PathFinder.PathFinderScene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Init(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitComputeShaderRasterization3D(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderScene gen_to_be_invoked = (K_PathFinder.PathFinderScene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.ComputeShader _shader = (UnityEngine.ComputeShader)translator.GetObject(L, 2, typeof(UnityEngine.ComputeShader));
                    
                    gen_to_be_invoked.InitComputeShaderRasterization3D( _shader );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitComputeShaderRasterization2D(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderScene gen_to_be_invoked = (K_PathFinder.PathFinderScene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.ComputeShader _shader = (UnityEngine.ComputeShader)translator.GetObject(L, 2, typeof(UnityEngine.ComputeShader));
                    
                    gen_to_be_invoked.InitComputeShaderRasterization2D( _shader );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Rasterize3D(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderScene gen_to_be_invoked = (K_PathFinder.PathFinderScene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3[] _verts = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
                    int[] _tris = (int[])translator.GetObject(L, 3, typeof(int[]));
                    UnityEngine.Bounds _bounds;translator.Get(L, 4, out _bounds);
                    UnityEngine.Matrix4x4 _matrix;translator.Get(L, 5, out _matrix);
                    int _volumeSizeX = LuaAPI.xlua_tointeger(L, 6);
                    int _volumeSizeZ = LuaAPI.xlua_tointeger(L, 7);
                    float _chunkPosX = (float)LuaAPI.lua_tonumber(L, 8);
                    float _chunkPosZ = (float)LuaAPI.lua_tonumber(L, 9);
                    float _voxelSize = (float)LuaAPI.lua_tonumber(L, 10);
                    float _maxSlopeCos = (float)LuaAPI.lua_tonumber(L, 11);
                    bool _flipY = LuaAPI.lua_toboolean(L, 12);
                    bool _debug = LuaAPI.lua_toboolean(L, 13);
                    
                        K_PathFinder.Rasterization.CSRasterization3DResult gen_ret = gen_to_be_invoked.Rasterize3D( _verts, _tris, _bounds, _matrix, _volumeSizeX, _volumeSizeZ, _chunkPosX, _chunkPosZ, _voxelSize, _maxSlopeCos, _flipY, _debug );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Rasterize2D(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderScene gen_to_be_invoked = (K_PathFinder.PathFinderScene)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 11&& translator.Assignable<UnityEngine.Vector3[]>(L, 2)&& translator.Assignable<int[]>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 8)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 9)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 10)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 11)) 
                {
                    UnityEngine.Vector3[] _verts = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
                    int[] _tris = (int[])translator.GetObject(L, 3, typeof(int[]));
                    int _trisLength = LuaAPI.xlua_tointeger(L, 4);
                    int _volumeSizeX = LuaAPI.xlua_tointeger(L, 5);
                    int _volumeSizeZ = LuaAPI.xlua_tointeger(L, 6);
                    float _chunkPosX = (float)LuaAPI.lua_tonumber(L, 7);
                    float _chunkPosZ = (float)LuaAPI.lua_tonumber(L, 8);
                    float _voxelSize = (float)LuaAPI.lua_tonumber(L, 9);
                    float _maxSlopeCos = (float)LuaAPI.lua_tonumber(L, 10);
                    bool _debug = LuaAPI.lua_toboolean(L, 11);
                    
                        K_PathFinder.Rasterization.CSRasterization2DResult gen_ret = gen_to_be_invoked.Rasterize2D( _verts, _tris, _trisLength, _volumeSizeX, _volumeSizeZ, _chunkPosX, _chunkPosZ, _voxelSize, _maxSlopeCos, _debug );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 10&& translator.Assignable<UnityEngine.Vector3[]>(L, 2)&& translator.Assignable<int[]>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 8)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 9)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 10)) 
                {
                    UnityEngine.Vector3[] _verts = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
                    int[] _tris = (int[])translator.GetObject(L, 3, typeof(int[]));
                    int _trisLength = LuaAPI.xlua_tointeger(L, 4);
                    int _volumeSizeX = LuaAPI.xlua_tointeger(L, 5);
                    int _volumeSizeZ = LuaAPI.xlua_tointeger(L, 6);
                    float _chunkPosX = (float)LuaAPI.lua_tonumber(L, 7);
                    float _chunkPosZ = (float)LuaAPI.lua_tonumber(L, 8);
                    float _voxelSize = (float)LuaAPI.lua_tonumber(L, 9);
                    float _maxSlopeCos = (float)LuaAPI.lua_tonumber(L, 10);
                    
                        K_PathFinder.Rasterization.CSRasterization2DResult gen_ret = gen_to_be_invoked.Rasterize2D( _verts, _tris, _trisLength, _volumeSizeX, _volumeSizeZ, _chunkPosX, _chunkPosZ, _voxelSize, _maxSlopeCos );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinderScene.Rasterize2D!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopAll(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderScene gen_to_be_invoked = (K_PathFinder.PathFinderScene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.StopAll(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Shutdown(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderScene gen_to_be_invoked = (K_PathFinder.PathFinderScene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Shutdown(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitDebugBuffers(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderScene gen_to_be_invoked = (K_PathFinder.PathFinderScene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.InitDebugBuffers(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateStaticData(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderScene gen_to_be_invoked = (K_PathFinder.PathFinderScene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<K_PathFinder.PFDebuger.PointData> _dotList = (System.Collections.Generic.List<K_PathFinder.PFDebuger.PointData>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<K_PathFinder.PFDebuger.PointData>));
                    System.Collections.Generic.List<K_PathFinder.PFDebuger.LineData> _lineList = (System.Collections.Generic.List<K_PathFinder.PFDebuger.LineData>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<K_PathFinder.PFDebuger.LineData>));
                    System.Collections.Generic.List<K_PathFinder.PFDebuger.TriangleData> _trisList = (System.Collections.Generic.List<K_PathFinder.PFDebuger.TriangleData>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<K_PathFinder.PFDebuger.TriangleData>));
                    
                    gen_to_be_invoked.UpdateStaticData( _dotList, _lineList, _trisList );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateDynamicData(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderScene gen_to_be_invoked = (K_PathFinder.PathFinderScene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<K_PathFinder.PFDebuger.PointData> _dotList = (System.Collections.Generic.List<K_PathFinder.PFDebuger.PointData>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<K_PathFinder.PFDebuger.PointData>));
                    System.Collections.Generic.List<K_PathFinder.PFDebuger.LineData> _lineList = (System.Collections.Generic.List<K_PathFinder.PFDebuger.LineData>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<K_PathFinder.PFDebuger.LineData>));
                    System.Collections.Generic.List<K_PathFinder.PFDebuger.TriangleData> _trisList = (System.Collections.Generic.List<K_PathFinder.PFDebuger.TriangleData>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<K_PathFinder.PFDebuger.TriangleData>));
                    
                    gen_to_be_invoked.UpdateDynamicData( _dotList, _lineList, _trisList );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateGenericDots(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderScene gen_to_be_invoked = (K_PathFinder.PathFinderScene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<K_PathFinder.PFDebuger.PointData> _dotList = (System.Collections.Generic.List<K_PathFinder.PFDebuger.PointData>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<K_PathFinder.PFDebuger.PointData>));
                    
                    gen_to_be_invoked.UpdateGenericDots( _dotList );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateGenericLines(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderScene gen_to_be_invoked = (K_PathFinder.PathFinderScene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<K_PathFinder.PFDebuger.LineData> _lineList = (System.Collections.Generic.List<K_PathFinder.PFDebuger.LineData>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<K_PathFinder.PFDebuger.LineData>));
                    
                    gen_to_be_invoked.UpdateGenericLines( _lineList );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateGenericTris(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderScene gen_to_be_invoked = (K_PathFinder.PathFinderScene)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<K_PathFinder.PFDebuger.TriangleData> _trisList = (System.Collections.Generic.List<K_PathFinder.PFDebuger.TriangleData>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<K_PathFinder.PFDebuger.TriangleData>));
                    
                    gen_to_be_invoked.UpdateGenericTris( _trisList );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sceneNavmeshData(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderScene gen_to_be_invoked = (K_PathFinder.PathFinderScene)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.sceneNavmeshData);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_gameObjectLibrary(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderScene gen_to_be_invoked = (K_PathFinder.PathFinderScene)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.gameObjectLibrary);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_sceneNavmeshData(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderScene gen_to_be_invoked = (K_PathFinder.PathFinderScene)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.sceneNavmeshData = (K_PathFinder.Serialization2.SceneNavmeshData)translator.GetObject(L, 2, typeof(K_PathFinder.Serialization2.SceneNavmeshData));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_gameObjectLibrary(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderScene gen_to_be_invoked = (K_PathFinder.PathFinderScene)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.gameObjectLibrary = (UnityEngine.GameObject[])translator.GetObject(L, 2, typeof(UnityEngine.GameObject[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
