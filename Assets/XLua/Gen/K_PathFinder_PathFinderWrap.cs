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
    public class K_PathFinderPathFinderWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(K_PathFinder.PathFinder);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 62, 24, 12);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "CallThisWhenSceneObjectIsGone", _m_CallThisWhenSceneObjectIsGone_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PathFinderInit", _m_PathFinderInit_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Update", _m_Update_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "UpdateRVO", _m_UpdateRVO_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddMainThreadDelegate", _m_AddMainThreadDelegate_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddPathfinderThreadDelegate", _m_AddPathfinderThreadDelegate_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddAgentProperties", _m_AddAgentProperties_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RemoveAgentProperties", _m_RemoveAgentProperties_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ResetAgentPropertiesFlags", _m_ResetAgentPropertiesFlags_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetAllGraphs", _m_GetAllGraphs_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetOnNavmeshGenerationCompleteDelegate", _m_SetOnNavmeshGenerationCompleteDelegate_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DrawAreaSellector", _m_DrawAreaSellector_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetMaxThreads", _m_SetMaxThreads_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetCurrentTerrainMethod", _m_SetCurrentTerrainMethod_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ChangeTargetState", _m_ChangeTargetState_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetArea", _m_GetArea_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "TryGetAreaIndex", _m_TryGetAreaIndex_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetCellForRaycast", _m_GetCellForRaycast_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Raycast", _m_Raycast_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RaycastForMoveTemplate", _m_RaycastForMoveTemplate_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "TryGetGraph", _m_TryGetGraph_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "TryGetGraphFrom", _m_TryGetGraphFrom_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "TryGetClosestCell_Internal", _m_TryGetClosestCell_Internal_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "TryGetClosestCell", _m_TryGetClosestCell_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "TryGetNearestHull", _m_TryGetNearestHull_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "TryGetCell", _m_TryGetCell_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "QueueGraph", _m_QueueGraph_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RemoveGraph", _m_RemoveGraph_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "StringToLayer", _m_StringToLayer_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToGrid", _m_ToGrid_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToChunkPosition", _m_ToChunkPosition_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddAreaHash", _m_AddAreaHash_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RemoveAreaHash", _m_RemoveAreaHash_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetAreaHash", _m_GetAreaHash_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetAreaByHash", _m_GetAreaByHash_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CloneHashData", _m_CloneHashData_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SaveCurrentSceneData", _m_SaveCurrentSceneData_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ClearCurrenSceneData", _m_ClearCurrenSceneData_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadCurrentSceneData", _m_LoadCurrentSceneData_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CheckNavmeshIntegrity", _m_CheckNavmeshIntegrity_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ProcessCellContent", _m_ProcessCellContent_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RemoveCellContent", _m_RemoveCellContent_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DebugCellsContent", _m_DebugCellsContent_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CountContent", _m_CountContent_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RemoveChunkContent", _m_RemoveChunkContent_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ProcessChunkContent", _m_ProcessChunkContent_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddDeltaCostValue", _m_AddDeltaCostValue_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RemoveDeltaCostValue", _m_RemoveDeltaCostValue_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DebugDeltaCost", _m_DebugDeltaCost_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RegisterNavmeshSample", _m_RegisterNavmeshSample_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "UnregisterNavmeshSample", _m_UnregisterNavmeshSample_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "UnregisterNavmeshSampleAndReturnResult", _m_UnregisterNavmeshSampleAndReturnResult_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RegisterLocalAvoidanceAgent", _m_RegisterLocalAvoidanceAgent_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "UnregisterLocalAvoidanceAgent", _m_UnregisterLocalAvoidanceAgent_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LineLineIntersection", _m_LineLineIntersection_xlua_st_);
            
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "VERSION", K_PathFinder.PathFinder.VERSION);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "CELL_GRID_SIZE", K_PathFinder.PathFinder.CELL_GRID_SIZE);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "defaultLayer", K_PathFinder.PathFinder.defaultLayer);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ignoreLayer", K_PathFinder.PathFinder.ignoreLayer);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "allLayers", K_PathFinder.PathFinder.allLayers);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "allLayersExceptIgnore", K_PathFinder.PathFinder.allLayersExceptIgnore);
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "settings", _g_get_settings);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "areaCount", _g_get_areaCount);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "getDefaultArea", _g_get_getDefaultArea);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "getUnwalkableArea", _g_get_getUnwalkableArea);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "areInit", _g_get_areInit);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "gridLowest", _g_get_gridLowest);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "gridHighest", _g_get_gridHighest);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "multithread", _g_get_multithread);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "terrainCollectionType", _g_get_terrainCollectionType);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "colliderCollectorType", _g_get_colliderCollectorType);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "eventCellContentWorkCount", _g_get_eventCellContentWorkCount);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "eventCellContentHaveWork", _g_get_eventCellContentHaveWork);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "sceneInstance", _g_get_sceneInstance);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "mainThreadDelegateQueue", _g_get_mainThreadDelegateQueue);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "pathFinderDelegateQueue", _g_get_pathFinderDelegateQueue);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "gridSize", _g_get_gridSize);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "queryBatcher", _g_get_queryBatcher);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "dotShader", _g_get_dotShader);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "lineShader", _g_get_lineShader);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "trisShader", _g_get_trisShader);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "navmeshThreadState", _g_get_navmeshThreadState);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "cellDeltaCostArray", _g_get_cellDeltaCostArray);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "deltaCostMaxGroupCount", _g_get_deltaCostMaxGroupCount);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "navmeshPositionResults", _g_get_navmeshPositionResults);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "sceneInstance", _s_set_sceneInstance);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "mainThreadDelegateQueue", _s_set_mainThreadDelegateQueue);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "pathFinderDelegateQueue", _s_set_pathFinderDelegateQueue);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "gridSize", _s_set_gridSize);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "queryBatcher", _s_set_queryBatcher);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "dotShader", _s_set_dotShader);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "lineShader", _s_set_lineShader);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "trisShader", _s_set_trisShader);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "navmeshThreadState", _s_set_navmeshThreadState);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "cellDeltaCostArray", _s_set_cellDeltaCostArray);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "deltaCostMaxGroupCount", _s_set_deltaCostMaxGroupCount);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "navmeshPositionResults", _s_set_navmeshPositionResults);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "K_PathFinder.PathFinder does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CallThisWhenSceneObjectIsGone_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    K_PathFinder.PathFinder.CallThisWhenSceneObjectIsGone(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PathFinderInit_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    K_PathFinder.PathFinder.PathFinderInit(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    K_PathFinder.PathFinder.Update(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateRVO_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    K_PathFinder.PathFinder.UpdateRVO(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddMainThreadDelegate_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Action _action = translator.GetDelegate<System.Action>(L, 1);
                    
                    K_PathFinder.PathFinder.AddMainThreadDelegate( _action );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddPathfinderThreadDelegate_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Action _action = translator.GetDelegate<System.Action>(L, 1);
                    
                    K_PathFinder.PathFinder.AddPathfinderThreadDelegate( _action );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddAgentProperties_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    K_PathFinder.AgentProperties _prop = (K_PathFinder.AgentProperties)translator.GetObject(L, 1, typeof(K_PathFinder.AgentProperties));
                    
                    K_PathFinder.PathFinder.AddAgentProperties( _prop );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveAgentProperties_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    K_PathFinder.AgentProperties _prop = (K_PathFinder.AgentProperties)translator.GetObject(L, 1, typeof(K_PathFinder.AgentProperties));
                    
                    K_PathFinder.PathFinder.RemoveAgentProperties( _prop );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetAgentPropertiesFlags_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    K_PathFinder.PathFinder.ResetAgentPropertiesFlags(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllGraphs_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Collections.Generic.List<K_PathFinder.Graphs.Graph> _listToPopulate = (System.Collections.Generic.List<K_PathFinder.Graphs.Graph>)translator.GetObject(L, 1, typeof(System.Collections.Generic.List<K_PathFinder.Graphs.Graph>));
                    
                    K_PathFinder.PathFinder.GetAllGraphs( _listToPopulate );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetOnNavmeshGenerationCompleteDelegate_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Action _action = translator.GetDelegate<System.Action>(L, 1);
                    
                    K_PathFinder.PathFinder.SetOnNavmeshGenerationCompleteDelegate( _action );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DrawAreaSellector_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _current = LuaAPI.xlua_tointeger(L, 1);
                    
                        int gen_ret = K_PathFinder.PathFinder.DrawAreaSellector( _current );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMaxThreads_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                    K_PathFinder.PathFinder.SetMaxThreads( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCurrentTerrainMethod_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    K_PathFinder.TerrainCollectorType _type;translator.Get(L, 1, out _type);
                    
                    K_PathFinder.PathFinder.SetCurrentTerrainMethod( _type );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangeTargetState_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    K_PathFinder.PathFinder.MainThreadState _state;translator.Get(L, 1, out _state);
                    
                    K_PathFinder.PathFinder.ChangeTargetState( _state );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetArea_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _id = LuaAPI.xlua_tointeger(L, 1);
                    
                        K_PathFinder.Area gen_ret = K_PathFinder.PathFinder.GetArea( _id );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _name = LuaAPI.lua_tostring(L, 1);
                    
                        K_PathFinder.Area gen_ret = K_PathFinder.PathFinder.GetArea( _name );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinder.GetArea!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryGetAreaIndex_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<K_PathFinder.Area>(L, 1)) 
                {
                    K_PathFinder.Area _area = (K_PathFinder.Area)translator.GetObject(L, 1, typeof(K_PathFinder.Area));
                    int _index;
                    
                        bool gen_ret = K_PathFinder.PathFinder.TryGetAreaIndex( _area, out _index );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    LuaAPI.xlua_pushinteger(L, _index);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _areaName = LuaAPI.lua_tostring(L, 1);
                    int _index;
                    
                        bool gen_ret = K_PathFinder.PathFinder.TryGetAreaIndex( _areaName, out _index );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    LuaAPI.xlua_pushinteger(L, _index);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinder.TryGetAreaIndex!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCellForRaycast_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 4, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.Graphs.Cell _cell;
                    
                        bool gen_ret = K_PathFinder.PathFinder.GetCellForRaycast( ref _x, ref _y, ref _z, _properties, out _cell );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    LuaAPI.lua_pushnumber(L, _x);
                        
                    LuaAPI.lua_pushnumber(L, _y);
                        
                    LuaAPI.lua_pushnumber(L, _z);
                        
                    translator.Push(L, _cell);
                        
                    
                    
                    
                    return 5;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Raycast_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 7&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 6)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    float _directionX = (float)LuaAPI.lua_tonumber(L, 4);
                    float _directionZ = (float)LuaAPI.lua_tonumber(L, 5);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 6, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    int _layerMask = LuaAPI.xlua_tointeger(L, 7);
                    
                    K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directionX, _directionZ, _properties, out _hit, _layerMask );
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 6)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    float _directionX = (float)LuaAPI.lua_tonumber(L, 4);
                    float _directionZ = (float)LuaAPI.lua_tonumber(L, 5);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 6, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    
                    K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directionX, _directionZ, _properties, out _hit );
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 8&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 6)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 8)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    float _directionX = (float)LuaAPI.lua_tonumber(L, 4);
                    float _directionZ = (float)LuaAPI.lua_tonumber(L, 5);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 6, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 7);
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    int _layerMask = LuaAPI.xlua_tointeger(L, 8);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directionX, _directionZ, _properties, _maxRange, out _hit, _layerMask );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 7&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 6)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    float _directionX = (float)LuaAPI.lua_tonumber(L, 4);
                    float _directionZ = (float)LuaAPI.lua_tonumber(L, 5);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 6, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 7);
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directionX, _directionZ, _properties, _maxRange, out _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 9&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 6)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7)&& translator.Assignable<K_PathFinder.Area>(L, 8)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 9)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    float _directionX = (float)LuaAPI.lua_tonumber(L, 4);
                    float _directionZ = (float)LuaAPI.lua_tonumber(L, 5);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 6, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 7);
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 8, typeof(K_PathFinder.Area));
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    int _layerMask = LuaAPI.xlua_tointeger(L, 9);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directionX, _directionZ, _properties, _maxRange, _expectedArea, out _hit, _layerMask );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 8&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 6)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7)&& translator.Assignable<K_PathFinder.Area>(L, 8)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    float _directionX = (float)LuaAPI.lua_tonumber(L, 4);
                    float _directionZ = (float)LuaAPI.lua_tonumber(L, 5);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 6, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 7);
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 8, typeof(K_PathFinder.Area));
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directionX, _directionZ, _properties, _maxRange, _expectedArea, out _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 9&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 6)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7)&& translator.Assignable<K_PathFinder.Passability>(L, 8)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 9)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    float _directionX = (float)LuaAPI.lua_tonumber(L, 4);
                    float _directionZ = (float)LuaAPI.lua_tonumber(L, 5);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 6, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 7);
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 8, out _expectedPassability);
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    int _layerMask = LuaAPI.xlua_tointeger(L, 9);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directionX, _directionZ, _properties, _maxRange, _expectedPassability, out _hit, _layerMask );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 8&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 6)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7)&& translator.Assignable<K_PathFinder.Passability>(L, 8)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    float _directionX = (float)LuaAPI.lua_tonumber(L, 4);
                    float _directionZ = (float)LuaAPI.lua_tonumber(L, 5);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 6, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 7);
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 8, out _expectedPassability);
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directionX, _directionZ, _properties, _maxRange, _expectedPassability, out _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 1, out _position);
                    UnityEngine.Vector2 _directionXZ;translator.Get(L, 2, out _directionXZ);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 3, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    int _layerMask = LuaAPI.xlua_tointeger(L, 4);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _position, _directionXZ, _properties, out _hit, _layerMask );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 3)) 
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 1, out _position);
                    UnityEngine.Vector2 _directionXZ;translator.Get(L, 2, out _directionXZ);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 3, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _position, _directionXZ, _properties, out _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 1, out _position);
                    UnityEngine.Vector2 _directionXZ;translator.Get(L, 2, out _directionXZ);
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 3);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 4, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    int _layerMask = LuaAPI.xlua_tointeger(L, 5);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _position, _directionXZ, _maxRange, _properties, out _hit, _layerMask );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 4)) 
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 1, out _position);
                    UnityEngine.Vector2 _directionXZ;translator.Get(L, 2, out _directionXZ);
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 3);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 4, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _position, _directionXZ, _maxRange, _properties, out _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 8&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 6)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 7)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 8)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 6, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    bool _checkResult = LuaAPI.lua_toboolean(L, 7);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 8);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, ref _hit, _checkResult, _layerMask );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 7&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 6)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 7)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 6, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    bool _checkResult = LuaAPI.lua_toboolean(L, 7);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, ref _hit, _checkResult );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 6)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 6, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, ref _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 9&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 7)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 9)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 6);
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 7, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    bool _checkResult = LuaAPI.lua_toboolean(L, 8);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 9);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRange, ref _hit, _checkResult, _layerMask );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 8&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 7)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 6);
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 7, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    bool _checkResult = LuaAPI.lua_toboolean(L, 8);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRange, ref _hit, _checkResult );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 7&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 7)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 6);
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 7, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRange, ref _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 10&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 6)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7)&& translator.Assignable<K_PathFinder.Area>(L, 8)&& translator.Assignable<K_PathFinder.Passability>(L, 9)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 10)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    float _directionX = (float)LuaAPI.lua_tonumber(L, 4);
                    float _directionZ = (float)LuaAPI.lua_tonumber(L, 5);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 6, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 7);
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 8, typeof(K_PathFinder.Area));
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 9, out _expectedPassability);
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    int _layerMask = LuaAPI.xlua_tointeger(L, 10);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directionX, _directionZ, _properties, _maxRange, _expectedArea, _expectedPassability, out _hit, _layerMask );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 9&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 6)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7)&& translator.Assignable<K_PathFinder.Area>(L, 8)&& translator.Assignable<K_PathFinder.Passability>(L, 9)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    float _directionX = (float)LuaAPI.lua_tonumber(L, 4);
                    float _directionZ = (float)LuaAPI.lua_tonumber(L, 5);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 6, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 7);
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 8, typeof(K_PathFinder.Area));
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 9, out _expectedPassability);
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directionX, _directionZ, _properties, _maxRange, _expectedArea, _expectedPassability, out _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 12&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 6)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7)&& translator.Assignable<K_PathFinder.Area>(L, 8)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 9)&& translator.Assignable<K_PathFinder.Passability>(L, 10)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 11)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 12)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    float _directionX = (float)LuaAPI.lua_tonumber(L, 4);
                    float _directionZ = (float)LuaAPI.lua_tonumber(L, 5);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 6, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 7);
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 8, typeof(K_PathFinder.Area));
                    bool _checkArea = LuaAPI.lua_toboolean(L, 9);
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 10, out _expectedPassability);
                    bool _checkPassability = LuaAPI.lua_toboolean(L, 11);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 12);
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directionX, _directionZ, _properties, _maxRange, _expectedArea, _checkArea, _expectedPassability, _checkPassability, _layerMask, out _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 6&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<K_PathFinder.Area>(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)) 
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 1, out _position);
                    UnityEngine.Vector2 _directionXZ;translator.Get(L, 2, out _directionXZ);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 3, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 4);
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 5, typeof(K_PathFinder.Area));
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    int _layerMask = LuaAPI.xlua_tointeger(L, 6);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _position, _directionXZ, _properties, _maxRange, _expectedArea, out _hit, _layerMask );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<K_PathFinder.Area>(L, 5)) 
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 1, out _position);
                    UnityEngine.Vector2 _directionXZ;translator.Get(L, 2, out _directionXZ);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 3, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 4);
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 5, typeof(K_PathFinder.Area));
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _position, _directionXZ, _properties, _maxRange, _expectedArea, out _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 6&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<K_PathFinder.Passability>(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)) 
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 1, out _position);
                    UnityEngine.Vector2 _directionXZ;translator.Get(L, 2, out _directionXZ);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 3, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 4);
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 5, out _expectedPassability);
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    int _layerMask = LuaAPI.xlua_tointeger(L, 6);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _position, _directionXZ, _properties, _maxRange, _expectedPassability, out _hit, _layerMask );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<K_PathFinder.Passability>(L, 5)) 
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 1, out _position);
                    UnityEngine.Vector2 _directionXZ;translator.Get(L, 2, out _directionXZ);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 3, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 4);
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 5, out _expectedPassability);
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _position, _directionXZ, _properties, _maxRange, _expectedPassability, out _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 9&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& translator.Assignable<float[]>(L, 6)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 7)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 9)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float[] _maxRanges = (float[])translator.GetObject(L, 6, typeof(float[]));
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 7, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    bool _checkResult = LuaAPI.lua_toboolean(L, 8);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 9);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRanges, ref _hit, _checkResult, _layerMask );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 8&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& translator.Assignable<float[]>(L, 6)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 7)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float[] _maxRanges = (float[])translator.GetObject(L, 6, typeof(float[]));
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 7, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    bool _checkResult = LuaAPI.lua_toboolean(L, 8);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRanges, ref _hit, _checkResult );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 7&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& translator.Assignable<float[]>(L, 6)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 7)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float[] _maxRanges = (float[])translator.GetObject(L, 6, typeof(float[]));
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 7, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRanges, ref _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 10&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& translator.Assignable<K_PathFinder.Area>(L, 7)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 8)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 9)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 10)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 6);
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 7, typeof(K_PathFinder.Area));
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 8, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    bool _checkResult = LuaAPI.lua_toboolean(L, 9);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 10);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRange, _expectedArea, ref _hit, _checkResult, _layerMask );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 9&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& translator.Assignable<K_PathFinder.Area>(L, 7)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 8)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 9)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 6);
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 7, typeof(K_PathFinder.Area));
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 8, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    bool _checkResult = LuaAPI.lua_toboolean(L, 9);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRange, _expectedArea, ref _hit, _checkResult );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 8&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& translator.Assignable<K_PathFinder.Area>(L, 7)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 8)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 6);
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 7, typeof(K_PathFinder.Area));
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 8, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRange, _expectedArea, ref _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 10&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& translator.Assignable<K_PathFinder.Passability>(L, 7)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 8)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 9)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 10)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 6);
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 7, out _expectedPassability);
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 8, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    bool _checkResult = LuaAPI.lua_toboolean(L, 9);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 10);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRange, _expectedPassability, ref _hit, _checkResult, _layerMask );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 9&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& translator.Assignable<K_PathFinder.Passability>(L, 7)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 8)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 9)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 6);
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 7, out _expectedPassability);
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 8, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    bool _checkResult = LuaAPI.lua_toboolean(L, 9);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRange, _expectedPassability, ref _hit, _checkResult );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 8&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& translator.Assignable<K_PathFinder.Passability>(L, 7)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 8)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 6);
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 7, out _expectedPassability);
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 8, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRange, _expectedPassability, ref _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 7&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<K_PathFinder.Area>(L, 5)&& translator.Assignable<K_PathFinder.Passability>(L, 6)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7)) 
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 1, out _position);
                    UnityEngine.Vector2 _directionXZ;translator.Get(L, 2, out _directionXZ);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 3, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 4);
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 5, typeof(K_PathFinder.Area));
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 6, out _expectedPassability);
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    int _layerMask = LuaAPI.xlua_tointeger(L, 7);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _position, _directionXZ, _properties, _maxRange, _expectedArea, _expectedPassability, out _hit, _layerMask );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 6&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<K_PathFinder.Area>(L, 5)&& translator.Assignable<K_PathFinder.Passability>(L, 6)) 
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 1, out _position);
                    UnityEngine.Vector2 _directionXZ;translator.Get(L, 2, out _directionXZ);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 3, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 4);
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 5, typeof(K_PathFinder.Area));
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 6, out _expectedPassability);
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _position, _directionXZ, _properties, _maxRange, _expectedArea, _expectedPassability, out _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 10&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& translator.Assignable<float[]>(L, 6)&& translator.Assignable<K_PathFinder.Area>(L, 7)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 8)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 9)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 10)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float[] _maxRanges = (float[])translator.GetObject(L, 6, typeof(float[]));
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 7, typeof(K_PathFinder.Area));
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 8, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    bool _checkResult = LuaAPI.lua_toboolean(L, 9);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 10);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRanges, _expectedArea, ref _hit, _checkResult, _layerMask );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 9&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& translator.Assignable<float[]>(L, 6)&& translator.Assignable<K_PathFinder.Area>(L, 7)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 8)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 9)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float[] _maxRanges = (float[])translator.GetObject(L, 6, typeof(float[]));
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 7, typeof(K_PathFinder.Area));
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 8, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    bool _checkResult = LuaAPI.lua_toboolean(L, 9);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRanges, _expectedArea, ref _hit, _checkResult );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 8&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& translator.Assignable<float[]>(L, 6)&& translator.Assignable<K_PathFinder.Area>(L, 7)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 8)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float[] _maxRanges = (float[])translator.GetObject(L, 6, typeof(float[]));
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 7, typeof(K_PathFinder.Area));
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 8, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRanges, _expectedArea, ref _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 10&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& translator.Assignable<float[]>(L, 6)&& translator.Assignable<K_PathFinder.Passability>(L, 7)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 8)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 9)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 10)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float[] _maxRanges = (float[])translator.GetObject(L, 6, typeof(float[]));
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 7, out _expectedPassability);
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 8, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    bool _checkResult = LuaAPI.lua_toboolean(L, 9);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 10);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRanges, _expectedPassability, ref _hit, _checkResult, _layerMask );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 9&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& translator.Assignable<float[]>(L, 6)&& translator.Assignable<K_PathFinder.Passability>(L, 7)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 8)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 9)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float[] _maxRanges = (float[])translator.GetObject(L, 6, typeof(float[]));
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 7, out _expectedPassability);
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 8, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    bool _checkResult = LuaAPI.lua_toboolean(L, 9);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRanges, _expectedPassability, ref _hit, _checkResult );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 8&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& translator.Assignable<float[]>(L, 6)&& translator.Assignable<K_PathFinder.Passability>(L, 7)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 8)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float[] _maxRanges = (float[])translator.GetObject(L, 6, typeof(float[]));
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 7, out _expectedPassability);
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 8, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRanges, _expectedPassability, ref _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 11&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& translator.Assignable<K_PathFinder.Area>(L, 7)&& translator.Assignable<K_PathFinder.Passability>(L, 8)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 9)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 10)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 11)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 6);
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 7, typeof(K_PathFinder.Area));
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 8, out _expectedPassability);
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 9, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    bool _checkResult = LuaAPI.lua_toboolean(L, 10);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 11);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRange, _expectedArea, _expectedPassability, ref _hit, _checkResult, _layerMask );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 10&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& translator.Assignable<K_PathFinder.Area>(L, 7)&& translator.Assignable<K_PathFinder.Passability>(L, 8)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 9)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 10)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 6);
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 7, typeof(K_PathFinder.Area));
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 8, out _expectedPassability);
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 9, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    bool _checkResult = LuaAPI.lua_toboolean(L, 10);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRange, _expectedArea, _expectedPassability, ref _hit, _checkResult );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 9&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& translator.Assignable<K_PathFinder.Area>(L, 7)&& translator.Assignable<K_PathFinder.Passability>(L, 8)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 9)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 6);
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 7, typeof(K_PathFinder.Area));
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 8, out _expectedPassability);
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 9, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRange, _expectedArea, _expectedPassability, ref _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 13&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& translator.Assignable<K_PathFinder.Area>(L, 7)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8)&& translator.Assignable<K_PathFinder.Passability>(L, 9)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 10)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 11)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 12)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 13)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 6);
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 7, typeof(K_PathFinder.Area));
                    bool _checkArea = LuaAPI.lua_toboolean(L, 8);
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 9, out _expectedPassability);
                    bool _checkPassability = LuaAPI.lua_toboolean(L, 10);
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 11, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    bool _checkResult = LuaAPI.lua_toboolean(L, 12);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 13);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRange, _expectedArea, _checkArea, _expectedPassability, _checkPassability, ref _hit, _checkResult, _layerMask );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 12&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& translator.Assignable<K_PathFinder.Area>(L, 7)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8)&& translator.Assignable<K_PathFinder.Passability>(L, 9)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 10)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 11)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 12)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float _maxRange = (float)LuaAPI.lua_tonumber(L, 6);
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 7, typeof(K_PathFinder.Area));
                    bool _checkArea = LuaAPI.lua_toboolean(L, 8);
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 9, out _expectedPassability);
                    bool _checkPassability = LuaAPI.lua_toboolean(L, 10);
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 11, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    bool _checkResult = LuaAPI.lua_toboolean(L, 12);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRange, _expectedArea, _checkArea, _expectedPassability, _checkPassability, ref _hit, _checkResult );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 11&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& translator.Assignable<float[]>(L, 6)&& translator.Assignable<K_PathFinder.Area>(L, 7)&& translator.Assignable<K_PathFinder.Passability>(L, 8)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 9)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 10)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 11)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float[] _maxRanges = (float[])translator.GetObject(L, 6, typeof(float[]));
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 7, typeof(K_PathFinder.Area));
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 8, out _expectedPassability);
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 9, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    bool _checkResult = LuaAPI.lua_toboolean(L, 10);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 11);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRanges, _expectedArea, _expectedPassability, ref _hit, _checkResult, _layerMask );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 10&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& translator.Assignable<float[]>(L, 6)&& translator.Assignable<K_PathFinder.Area>(L, 7)&& translator.Assignable<K_PathFinder.Passability>(L, 8)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 9)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 10)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float[] _maxRanges = (float[])translator.GetObject(L, 6, typeof(float[]));
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 7, typeof(K_PathFinder.Area));
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 8, out _expectedPassability);
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 9, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    bool _checkResult = LuaAPI.lua_toboolean(L, 10);
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRanges, _expectedArea, _expectedPassability, ref _hit, _checkResult );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 9&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<UnityEngine.Vector2[]>(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& translator.Assignable<float[]>(L, 6)&& translator.Assignable<K_PathFinder.Area>(L, 7)&& translator.Assignable<K_PathFinder.Passability>(L, 8)&& translator.Assignable<K_PathFinder.RaycastHitNavMesh2[]>(L, 9)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    UnityEngine.Vector2[] _directions = (UnityEngine.Vector2[])translator.GetObject(L, 4, typeof(UnityEngine.Vector2[]));
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    float[] _maxRanges = (float[])translator.GetObject(L, 6, typeof(float[]));
                    K_PathFinder.Area _expectedArea = (K_PathFinder.Area)translator.GetObject(L, 7, typeof(K_PathFinder.Area));
                    K_PathFinder.Passability _expectedPassability;translator.Get(L, 8, out _expectedPassability);
                    K_PathFinder.RaycastHitNavMesh2[] _hit = (K_PathFinder.RaycastHitNavMesh2[])translator.GetObject(L, 9, typeof(K_PathFinder.RaycastHitNavMesh2[]));
                    
                        bool gen_ret = K_PathFinder.PathFinder.Raycast( _x, _y, _z, _directions, _properties, _maxRanges, _expectedArea, _expectedPassability, ref _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinder.Raycast!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RaycastForMoveTemplate_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 8&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& translator.Assignable<K_PathFinder.Graphs.Cell>(L, 7)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 8)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    float _dirX = (float)LuaAPI.lua_tonumber(L, 4);
                    float _dirY = (float)LuaAPI.lua_tonumber(L, 5);
                    float _range = (float)LuaAPI.lua_tonumber(L, 6);
                    K_PathFinder.Graphs.Cell _cell = (K_PathFinder.Graphs.Cell)translator.GetObject(L, 7, typeof(K_PathFinder.Graphs.Cell));
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    int _layerMask = LuaAPI.xlua_tointeger(L, 8);
                    
                    K_PathFinder.PathFinder.RaycastForMoveTemplate( _x, _y, _z, _dirX, _dirY, _range, _cell, out _hit, _layerMask );
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 7&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)&& translator.Assignable<K_PathFinder.Graphs.Cell>(L, 7)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    float _dirX = (float)LuaAPI.lua_tonumber(L, 4);
                    float _dirY = (float)LuaAPI.lua_tonumber(L, 5);
                    float _range = (float)LuaAPI.lua_tonumber(L, 6);
                    K_PathFinder.Graphs.Cell _cell = (K_PathFinder.Graphs.Cell)translator.GetObject(L, 7, typeof(K_PathFinder.Graphs.Cell));
                    K_PathFinder.RaycastHitNavMesh2 _hit;
                    
                    K_PathFinder.PathFinder.RaycastForMoveTemplate( _x, _y, _z, _dirX, _dirY, _range, _cell, out _hit );
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinder.RaycastForMoveTemplate!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryGetGraph_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 3)) 
                {
                    int _x = LuaAPI.xlua_tointeger(L, 1);
                    int _z = LuaAPI.xlua_tointeger(L, 2);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 3, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.Graphs.Graph _graph;
                    
                        bool gen_ret = K_PathFinder.PathFinder.TryGetGraph( _x, _z, _properties, out _graph );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _graph);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 2&& translator.Assignable<K_PathFinder.XZPosInt>(L, 1)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 2)) 
                {
                    K_PathFinder.XZPosInt _pos;translator.Get(L, 1, out _pos);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 2, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.Graphs.Graph _graph;
                    
                        bool gen_ret = K_PathFinder.PathFinder.TryGetGraph( _pos, _properties, out _graph );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _graph);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 7&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& translator.Assignable<System.Collections.Generic.List<K_PathFinder.Graphs.Graph>>(L, 6)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 7)) 
                {
                    int _x = LuaAPI.xlua_tointeger(L, 1);
                    int _z = LuaAPI.xlua_tointeger(L, 2);
                    int _sizeX = LuaAPI.xlua_tointeger(L, 3);
                    int _sizeZ = LuaAPI.xlua_tointeger(L, 4);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    System.Collections.Generic.List<K_PathFinder.Graphs.Graph> _populate = (System.Collections.Generic.List<K_PathFinder.Graphs.Graph>)translator.GetObject(L, 6, typeof(System.Collections.Generic.List<K_PathFinder.Graphs.Graph>));
                    bool _addNulls = LuaAPI.lua_toboolean(L, 7);
                    
                    K_PathFinder.PathFinder.TryGetGraph( _x, _z, _sizeX, _sizeZ, _properties, _populate, _addNulls );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 5)&& translator.Assignable<System.Collections.Generic.List<K_PathFinder.Graphs.Graph>>(L, 6)) 
                {
                    int _x = LuaAPI.xlua_tointeger(L, 1);
                    int _z = LuaAPI.xlua_tointeger(L, 2);
                    int _sizeX = LuaAPI.xlua_tointeger(L, 3);
                    int _sizeZ = LuaAPI.xlua_tointeger(L, 4);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 5, typeof(K_PathFinder.AgentProperties));
                    System.Collections.Generic.List<K_PathFinder.Graphs.Graph> _populate = (System.Collections.Generic.List<K_PathFinder.Graphs.Graph>)translator.GetObject(L, 6, typeof(System.Collections.Generic.List<K_PathFinder.Graphs.Graph>));
                    
                    K_PathFinder.PathFinder.TryGetGraph( _x, _z, _sizeX, _sizeZ, _properties, _populate );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinder.TryGetGraph!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryGetGraphFrom_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    K_PathFinder.XZPosInt _pos;translator.Get(L, 1, out _pos);
                    K_PathFinder.Directions _direction;translator.Get(L, 2, out _direction);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 3, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.Graphs.Graph _graph;
                    
                        bool gen_ret = K_PathFinder.PathFinder.TryGetGraphFrom( _pos, _direction, _properties, out _graph );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _graph);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryGetClosestCell_Internal_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 4, typeof(K_PathFinder.AgentProperties));
                    UnityEngine.Vector3 _resultPosition;
                    K_PathFinder.Graphs.Cell _resultCell;
                    bool _outside;
                    
                        bool gen_ret = K_PathFinder.PathFinder.TryGetClosestCell_Internal( _x, _y, _z, _properties, out _resultPosition, out _resultCell, out _outside );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.PushUnityEngineVector3(L, _resultPosition);
                        
                    translator.Push(L, _resultCell);
                        
                    LuaAPI.lua_pushboolean(L, _outside);
                        
                    
                    
                    
                    return 4;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryGetClosestCell_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<K_PathFinder.PathFinderAgent>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    K_PathFinder.PathFinderAgent _agent = (K_PathFinder.PathFinderAgent)translator.GetObject(L, 1, typeof(K_PathFinder.PathFinderAgent));
                    int _layerMask = LuaAPI.xlua_tointeger(L, 2);
                    
                        K_PathFinder.NavmeshSampleResult gen_ret = K_PathFinder.PathFinder.TryGetClosestCell( _agent, _layerMask );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<K_PathFinder.PathFinderAgent>(L, 1)) 
                {
                    K_PathFinder.PathFinderAgent _agent = (K_PathFinder.PathFinderAgent)translator.GetObject(L, 1, typeof(K_PathFinder.PathFinderAgent));
                    
                        K_PathFinder.NavmeshSampleResult gen_ret = K_PathFinder.PathFinder.TryGetClosestCell( _agent );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<K_PathFinder.PathFinderAgent>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    K_PathFinder.PathFinderAgent _agent = (K_PathFinder.PathFinderAgent)translator.GetObject(L, 1, typeof(K_PathFinder.PathFinderAgent));
                    K_PathFinder.Graphs.Cell _cell;
                    int _layerMask = LuaAPI.xlua_tointeger(L, 2);
                    
                        K_PathFinder.NavmeshSampleResultType gen_ret = K_PathFinder.PathFinder.TryGetClosestCell( _agent, out _cell, _layerMask );
                        translator.Push(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 1&& translator.Assignable<K_PathFinder.PathFinderAgent>(L, 1)) 
                {
                    K_PathFinder.PathFinderAgent _agent = (K_PathFinder.PathFinderAgent)translator.GetObject(L, 1, typeof(K_PathFinder.PathFinderAgent));
                    K_PathFinder.Graphs.Cell _cell;
                    
                        K_PathFinder.NavmeshSampleResultType gen_ret = K_PathFinder.PathFinder.TryGetClosestCell( _agent, out _cell );
                        translator.Push(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 2&& translator.Assignable<K_PathFinder.PathFinderAgent>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    K_PathFinder.PathFinderAgent _agent = (K_PathFinder.PathFinderAgent)translator.GetObject(L, 1, typeof(K_PathFinder.PathFinderAgent));
                    K_PathFinder.Graphs.Cell _cell;
                    UnityEngine.Vector3 _closestPoint;
                    int _layerMask = LuaAPI.xlua_tointeger(L, 2);
                    
                        K_PathFinder.NavmeshSampleResultType gen_ret = K_PathFinder.PathFinder.TryGetClosestCell( _agent, out _cell, out _closestPoint, _layerMask );
                        translator.Push(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    translator.PushUnityEngineVector3(L, _closestPoint);
                        
                    
                    
                    
                    return 3;
                }
                if(gen_param_count == 1&& translator.Assignable<K_PathFinder.PathFinderAgent>(L, 1)) 
                {
                    K_PathFinder.PathFinderAgent _agent = (K_PathFinder.PathFinderAgent)translator.GetObject(L, 1, typeof(K_PathFinder.PathFinderAgent));
                    K_PathFinder.Graphs.Cell _cell;
                    UnityEngine.Vector3 _closestPoint;
                    
                        K_PathFinder.NavmeshSampleResultType gen_ret = K_PathFinder.PathFinder.TryGetClosestCell( _agent, out _cell, out _closestPoint );
                        translator.Push(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    translator.PushUnityEngineVector3(L, _closestPoint);
                        
                    
                    
                    
                    return 3;
                }
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 4, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.Graphs.Cell _cell;
                    int _layerMask = LuaAPI.xlua_tointeger(L, 5);
                    
                        K_PathFinder.NavmeshSampleResultType gen_ret = K_PathFinder.PathFinder.TryGetClosestCell( _x, _y, _z, _properties, out _cell, _layerMask );
                        translator.Push(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 4)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 4, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.Graphs.Cell _cell;
                    
                        K_PathFinder.NavmeshSampleResultType gen_ret = K_PathFinder.PathFinder.TryGetClosestCell( _x, _y, _z, _properties, out _cell );
                        translator.Push(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 4, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.Graphs.Cell _cell;
                    UnityEngine.Vector3 _closestPoint;
                    int _layerMask = LuaAPI.xlua_tointeger(L, 5);
                    
                        K_PathFinder.NavmeshSampleResultType gen_ret = K_PathFinder.PathFinder.TryGetClosestCell( _x, _y, _z, _properties, out _cell, out _closestPoint, _layerMask );
                        translator.Push(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    translator.PushUnityEngineVector3(L, _closestPoint);
                        
                    
                    
                    
                    return 3;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 4)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 4, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.Graphs.Cell _cell;
                    UnityEngine.Vector3 _closestPoint;
                    
                        K_PathFinder.NavmeshSampleResultType gen_ret = K_PathFinder.PathFinder.TryGetClosestCell( _x, _y, _z, _properties, out _cell, out _closestPoint );
                        translator.Push(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    translator.PushUnityEngineVector3(L, _closestPoint);
                        
                    
                    
                    
                    return 3;
                }
                if(gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 4, typeof(K_PathFinder.AgentProperties));
                    UnityEngine.Vector3 _resultPosition;
                    K_PathFinder.Graphs.Cell _resultCell;
                    int _layer = LuaAPI.xlua_tointeger(L, 5);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 6);
                    
                        K_PathFinder.NavmeshSampleResultType gen_ret = K_PathFinder.PathFinder.TryGetClosestCell( _x, _y, _z, _properties, out _resultPosition, out _resultCell, _layer, _layerMask );
                        translator.Push(L, gen_ret);
                    translator.PushUnityEngineVector3(L, _resultPosition);
                        
                    translator.Push(L, _resultCell);
                        
                    
                    
                    
                    return 3;
                }
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 4, typeof(K_PathFinder.AgentProperties));
                    UnityEngine.Vector3 _resultPosition;
                    K_PathFinder.Graphs.Cell _resultCell;
                    int _layer = LuaAPI.xlua_tointeger(L, 5);
                    
                        K_PathFinder.NavmeshSampleResultType gen_ret = K_PathFinder.PathFinder.TryGetClosestCell( _x, _y, _z, _properties, out _resultPosition, out _resultCell, _layer );
                        translator.Push(L, gen_ret);
                    translator.PushUnityEngineVector3(L, _resultPosition);
                        
                    translator.Push(L, _resultCell);
                        
                    
                    
                    
                    return 3;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 4)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 4, typeof(K_PathFinder.AgentProperties));
                    UnityEngine.Vector3 _resultPosition;
                    K_PathFinder.Graphs.Cell _resultCell;
                    
                        K_PathFinder.NavmeshSampleResultType gen_ret = K_PathFinder.PathFinder.TryGetClosestCell( _x, _y, _z, _properties, out _resultPosition, out _resultCell );
                        translator.Push(L, gen_ret);
                    translator.PushUnityEngineVector3(L, _resultPosition);
                        
                    translator.Push(L, _resultCell);
                        
                    
                    
                    
                    return 3;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector3 _pos;translator.Get(L, 1, out _pos);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 2, typeof(K_PathFinder.AgentProperties));
                    int _layerMask = LuaAPI.xlua_tointeger(L, 3);
                    
                        K_PathFinder.NavmeshSampleResult gen_ret = K_PathFinder.PathFinder.TryGetClosestCell( _pos, _properties, _layerMask );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 2)) 
                {
                    UnityEngine.Vector3 _pos;translator.Get(L, 1, out _pos);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 2, typeof(K_PathFinder.AgentProperties));
                    
                        K_PathFinder.NavmeshSampleResult gen_ret = K_PathFinder.PathFinder.TryGetClosestCell( _pos, _properties );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector3 _pos;translator.Get(L, 1, out _pos);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 2, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.Graphs.Cell _cell;
                    int _layerMask = LuaAPI.xlua_tointeger(L, 3);
                    
                        K_PathFinder.NavmeshSampleResultType gen_ret = K_PathFinder.PathFinder.TryGetClosestCell( _pos, _properties, out _cell, _layerMask );
                        translator.Push(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 2)) 
                {
                    UnityEngine.Vector3 _pos;translator.Get(L, 1, out _pos);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 2, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.Graphs.Cell _cell;
                    
                        K_PathFinder.NavmeshSampleResultType gen_ret = K_PathFinder.PathFinder.TryGetClosestCell( _pos, _properties, out _cell );
                        translator.Push(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector3 _pos;translator.Get(L, 1, out _pos);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 2, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.Graphs.Cell _cell;
                    UnityEngine.Vector3 _closestPoint;
                    int _layerMask = LuaAPI.xlua_tointeger(L, 3);
                    
                        K_PathFinder.NavmeshSampleResultType gen_ret = K_PathFinder.PathFinder.TryGetClosestCell( _pos, _properties, out _cell, out _closestPoint, _layerMask );
                        translator.Push(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    translator.PushUnityEngineVector3(L, _closestPoint);
                        
                    
                    
                    
                    return 3;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 2)) 
                {
                    UnityEngine.Vector3 _pos;translator.Get(L, 1, out _pos);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 2, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.Graphs.Cell _cell;
                    UnityEngine.Vector3 _closestPoint;
                    
                        K_PathFinder.NavmeshSampleResultType gen_ret = K_PathFinder.PathFinder.TryGetClosestCell( _pos, _properties, out _cell, out _closestPoint );
                        translator.Push(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    translator.PushUnityEngineVector3(L, _closestPoint);
                        
                    
                    
                    
                    return 3;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinder.TryGetClosestCell!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryGetNearestHull_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<K_PathFinder.PathFinderAgent>(L, 1)) 
                {
                    K_PathFinder.PathFinderAgent _agent = (K_PathFinder.PathFinderAgent)translator.GetObject(L, 1, typeof(K_PathFinder.PathFinderAgent));
                    K_PathFinder.Graphs.Cell _cell;
                    
                        bool gen_ret = K_PathFinder.PathFinder.TryGetNearestHull( _agent, out _cell );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 1&& translator.Assignable<K_PathFinder.PathFinderAgent>(L, 1)) 
                {
                    K_PathFinder.PathFinderAgent _agent = (K_PathFinder.PathFinderAgent)translator.GetObject(L, 1, typeof(K_PathFinder.PathFinderAgent));
                    UnityEngine.Vector3 _closestPoint;
                    
                        bool gen_ret = K_PathFinder.PathFinder.TryGetNearestHull( _agent, out _closestPoint );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.PushUnityEngineVector3(L, _closestPoint);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 1&& translator.Assignable<K_PathFinder.PathFinderAgent>(L, 1)) 
                {
                    K_PathFinder.PathFinderAgent _agent = (K_PathFinder.PathFinderAgent)translator.GetObject(L, 1, typeof(K_PathFinder.PathFinderAgent));
                    K_PathFinder.Graphs.Cell _cell;
                    UnityEngine.Vector3 _closestPoint;
                    
                        bool gen_ret = K_PathFinder.PathFinder.TryGetNearestHull( _agent, out _cell, out _closestPoint );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    translator.PushUnityEngineVector3(L, _closestPoint);
                        
                    
                    
                    
                    return 3;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 2)) 
                {
                    UnityEngine.Vector3 _pos;translator.Get(L, 1, out _pos);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 2, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.Graphs.Cell _cell;
                    
                        bool gen_ret = K_PathFinder.PathFinder.TryGetNearestHull( _pos, _properties, out _cell );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 2)) 
                {
                    UnityEngine.Vector3 _pos;translator.Get(L, 1, out _pos);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 2, typeof(K_PathFinder.AgentProperties));
                    UnityEngine.Vector3 _closestPoint;
                    
                        bool gen_ret = K_PathFinder.PathFinder.TryGetNearestHull( _pos, _properties, out _closestPoint );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.PushUnityEngineVector3(L, _closestPoint);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 2)) 
                {
                    UnityEngine.Vector3 _pos;translator.Get(L, 1, out _pos);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 2, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.Graphs.Cell _cell;
                    UnityEngine.Vector3 _closestPoint;
                    
                        bool gen_ret = K_PathFinder.PathFinder.TryGetNearestHull( _pos, _properties, out _cell, out _closestPoint );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    translator.PushUnityEngineVector3(L, _closestPoint);
                        
                    
                    
                    
                    return 3;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinder.TryGetNearestHull!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryGetCell_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<K_PathFinder.PathFinderAgent>(L, 1)) 
                {
                    K_PathFinder.PathFinderAgent _agent = (K_PathFinder.PathFinderAgent)translator.GetObject(L, 1, typeof(K_PathFinder.PathFinderAgent));
                    K_PathFinder.Graphs.Cell _cell;
                    
                        bool gen_ret = K_PathFinder.PathFinder.TryGetCell( _agent, out _cell );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 1&& translator.Assignable<K_PathFinder.PathFinderAgent>(L, 1)) 
                {
                    K_PathFinder.PathFinderAgent _agent = (K_PathFinder.PathFinderAgent)translator.GetObject(L, 1, typeof(K_PathFinder.PathFinderAgent));
                    K_PathFinder.Graphs.Cell _cell;
                    UnityEngine.Vector3 _closestPoint;
                    
                        bool gen_ret = K_PathFinder.PathFinder.TryGetCell( _agent, out _cell, out _closestPoint );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    translator.PushUnityEngineVector3(L, _closestPoint);
                        
                    
                    
                    
                    return 3;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 4)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 4, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.Graphs.Cell _cell;
                    
                        bool gen_ret = K_PathFinder.PathFinder.TryGetCell( _x, _y, _z, _properties, out _cell );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 4)) 
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    float _z = (float)LuaAPI.lua_tonumber(L, 3);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 4, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.Graphs.Cell _cell;
                    UnityEngine.Vector3 _closestPoint;
                    
                        bool gen_ret = K_PathFinder.PathFinder.TryGetCell( _x, _y, _z, _properties, out _cell, out _closestPoint );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    translator.PushUnityEngineVector3(L, _closestPoint);
                        
                    
                    
                    
                    return 3;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 2)) 
                {
                    UnityEngine.Vector3 _pos;translator.Get(L, 1, out _pos);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 2, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.Graphs.Cell _cell;
                    
                        bool gen_ret = K_PathFinder.PathFinder.TryGetCell( _pos, _properties, out _cell );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 2)) 
                {
                    UnityEngine.Vector3 _pos;translator.Get(L, 1, out _pos);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 2, typeof(K_PathFinder.AgentProperties));
                    K_PathFinder.Graphs.Cell _cell;
                    UnityEngine.Vector3 _closestPoint;
                    
                        bool gen_ret = K_PathFinder.PathFinder.TryGetCell( _pos, _properties, out _cell, out _closestPoint );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _cell);
                        
                    translator.PushUnityEngineVector3(L, _closestPoint);
                        
                    
                    
                    
                    return 3;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinder.TryGetCell!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_QueueGraph_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    int _x = LuaAPI.xlua_tointeger(L, 1);
                    int _z = LuaAPI.xlua_tointeger(L, 2);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 3, typeof(K_PathFinder.AgentProperties));
                    int _sizeX = LuaAPI.xlua_tointeger(L, 4);
                    int _sizeZ = LuaAPI.xlua_tointeger(L, 5);
                    
                    K_PathFinder.PathFinder.QueueGraph( _x, _z, _properties, _sizeX, _sizeZ );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    int _x = LuaAPI.xlua_tointeger(L, 1);
                    int _z = LuaAPI.xlua_tointeger(L, 2);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 3, typeof(K_PathFinder.AgentProperties));
                    int _sizeX = LuaAPI.xlua_tointeger(L, 4);
                    
                    K_PathFinder.PathFinder.QueueGraph( _x, _z, _properties, _sizeX );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 3)) 
                {
                    int _x = LuaAPI.xlua_tointeger(L, 1);
                    int _z = LuaAPI.xlua_tointeger(L, 2);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 3, typeof(K_PathFinder.AgentProperties));
                    
                    K_PathFinder.PathFinder.QueueGraph( _x, _z, _properties );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector2>(L, 1)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 2)) 
                {
                    UnityEngine.Vector2 _worldTopPosition;translator.Get(L, 1, out _worldTopPosition);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 2, typeof(K_PathFinder.AgentProperties));
                    
                    K_PathFinder.PathFinder.QueueGraph( _worldTopPosition, _properties );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 2)) 
                {
                    UnityEngine.Vector3 _worldPosition;translator.Get(L, 1, out _worldPosition);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 2, typeof(K_PathFinder.AgentProperties));
                    
                    K_PathFinder.PathFinder.QueueGraph( _worldPosition, _properties );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<K_PathFinder.XZPosInt>(L, 1)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 2)) 
                {
                    K_PathFinder.XZPosInt _pos;translator.Get(L, 1, out _pos);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 2, typeof(K_PathFinder.AgentProperties));
                    
                    K_PathFinder.PathFinder.QueueGraph( _pos, _properties );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Bounds>(L, 1)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 2)) 
                {
                    UnityEngine.Bounds _bounds;translator.Get(L, 1, out _bounds);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 2, typeof(K_PathFinder.AgentProperties));
                    
                    K_PathFinder.PathFinder.QueueGraph( _bounds, _properties );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<K_PathFinder.XZPosInt>(L, 1)&& translator.Assignable<K_PathFinder.XZPosInt>(L, 2)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 3)) 
                {
                    K_PathFinder.XZPosInt _pos;translator.Get(L, 1, out _pos);
                    K_PathFinder.XZPosInt _size;translator.Get(L, 2, out _size);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 3, typeof(K_PathFinder.AgentProperties));
                    
                    K_PathFinder.PathFinder.QueueGraph( _pos, _size, _properties );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector2>(L, 1)&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 3)) 
                {
                    UnityEngine.Vector2 _startTop;translator.Get(L, 1, out _startTop);
                    UnityEngine.Vector2 _endTop;translator.Get(L, 2, out _endTop);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 3, typeof(K_PathFinder.AgentProperties));
                    
                    K_PathFinder.PathFinder.QueueGraph( _startTop, _endTop, _properties );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 3)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 1, out _start);
                    UnityEngine.Vector3 _end;translator.Get(L, 2, out _end);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 3, typeof(K_PathFinder.AgentProperties));
                    
                    K_PathFinder.PathFinder.QueueGraph( _start, _end, _properties );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinder.QueueGraph!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveGraph_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<K_PathFinder.GeneralXZData>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    K_PathFinder.GeneralXZData _data;translator.Get(L, 1, out _data);
                    bool _createNewGraphAfter = LuaAPI.lua_toboolean(L, 2);
                    
                    K_PathFinder.PathFinder.RemoveGraph( _data, _createNewGraphAfter );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1&& translator.Assignable<K_PathFinder.GeneralXZData>(L, 1)) 
                {
                    K_PathFinder.GeneralXZData _data;translator.Get(L, 1, out _data);
                    
                    K_PathFinder.PathFinder.RemoveGraph( _data );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)) 
                {
                    int _x = LuaAPI.xlua_tointeger(L, 1);
                    int _z = LuaAPI.xlua_tointeger(L, 2);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 3, typeof(K_PathFinder.AgentProperties));
                    int _sizeX = LuaAPI.xlua_tointeger(L, 4);
                    int _sizeZ = LuaAPI.xlua_tointeger(L, 5);
                    bool _createNewGraphAfter = LuaAPI.lua_toboolean(L, 6);
                    
                    K_PathFinder.PathFinder.RemoveGraph( _x, _z, _properties, _sizeX, _sizeZ, _createNewGraphAfter );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    int _x = LuaAPI.xlua_tointeger(L, 1);
                    int _z = LuaAPI.xlua_tointeger(L, 2);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 3, typeof(K_PathFinder.AgentProperties));
                    int _sizeX = LuaAPI.xlua_tointeger(L, 4);
                    int _sizeZ = LuaAPI.xlua_tointeger(L, 5);
                    
                    K_PathFinder.PathFinder.RemoveGraph( _x, _z, _properties, _sizeX, _sizeZ );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    int _x = LuaAPI.xlua_tointeger(L, 1);
                    int _z = LuaAPI.xlua_tointeger(L, 2);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 3, typeof(K_PathFinder.AgentProperties));
                    int _sizeX = LuaAPI.xlua_tointeger(L, 4);
                    
                    K_PathFinder.PathFinder.RemoveGraph( _x, _z, _properties, _sizeX );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 3)) 
                {
                    int _x = LuaAPI.xlua_tointeger(L, 1);
                    int _z = LuaAPI.xlua_tointeger(L, 2);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 3, typeof(K_PathFinder.AgentProperties));
                    
                    K_PathFinder.PathFinder.RemoveGraph( _x, _z, _properties );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<K_PathFinder.XZPosInt>(L, 1)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    K_PathFinder.XZPosInt _pos;translator.Get(L, 1, out _pos);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 2, typeof(K_PathFinder.AgentProperties));
                    bool _createNewGraphAfter = LuaAPI.lua_toboolean(L, 3);
                    
                    K_PathFinder.PathFinder.RemoveGraph( _pos, _properties, _createNewGraphAfter );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<K_PathFinder.XZPosInt>(L, 1)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 2)) 
                {
                    K_PathFinder.XZPosInt _pos;translator.Get(L, 1, out _pos);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 2, typeof(K_PathFinder.AgentProperties));
                    
                    K_PathFinder.PathFinder.RemoveGraph( _pos, _properties );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Bounds>(L, 1)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Bounds _bounds;translator.Get(L, 1, out _bounds);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 2, typeof(K_PathFinder.AgentProperties));
                    bool _createNewGraphAfter = LuaAPI.lua_toboolean(L, 3);
                    
                    K_PathFinder.PathFinder.RemoveGraph( _bounds, _properties, _createNewGraphAfter );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Bounds>(L, 1)&& translator.Assignable<K_PathFinder.AgentProperties>(L, 2)) 
                {
                    UnityEngine.Bounds _bounds;translator.Get(L, 1, out _bounds);
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 2, typeof(K_PathFinder.AgentProperties));
                    
                    K_PathFinder.PathFinder.RemoveGraph( _bounds, _properties );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count >= 2&& translator.Assignable<K_PathFinder.AgentProperties>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 3) || translator.Assignable<UnityEngine.Bounds>(L, 3))) 
                {
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 1, typeof(K_PathFinder.AgentProperties));
                    bool _createNewGraphAfter = LuaAPI.lua_toboolean(L, 2);
                    UnityEngine.Bounds[] _bounds = translator.GetParams<UnityEngine.Bounds>(L, 3);
                    
                    K_PathFinder.PathFinder.RemoveGraph( _properties, _createNewGraphAfter, _bounds );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count >= 1&& translator.Assignable<K_PathFinder.AgentProperties>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 1, typeof(K_PathFinder.AgentProperties));
                    bool _createNewGraphAfter = LuaAPI.lua_toboolean(L, 2);
                    
                    K_PathFinder.PathFinder.RemoveGraph( _properties, _createNewGraphAfter );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count >= 0&& translator.Assignable<K_PathFinder.AgentProperties>(L, 1)) 
                {
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 1, typeof(K_PathFinder.AgentProperties));
                    
                    K_PathFinder.PathFinder.RemoveGraph( _properties );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinder.RemoveGraph!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StringToLayer_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _layer = LuaAPI.lua_tostring(L, 1);
                    
                        int gen_ret = K_PathFinder.PathFinder.StringToLayer( _layer );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToGrid_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        int gen_ret = K_PathFinder.PathFinder.ToGrid( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToChunkPosition_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _realX = (float)LuaAPI.lua_tonumber(L, 1);
                    float _realZ = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        K_PathFinder.XZPosInt gen_ret = K_PathFinder.PathFinder.ToChunkPosition( _realX, _realZ );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    float _x1 = (float)LuaAPI.lua_tonumber(L, 1);
                    float _x2 = (float)LuaAPI.lua_tonumber(L, 2);
                    float _y1 = (float)LuaAPI.lua_tonumber(L, 3);
                    float _y2 = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        K_PathFinder.Bounds2DInt gen_ret = K_PathFinder.PathFinder.ToChunkPosition( _x1, _x2, _y1, _y2 );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<UnityEngine.Vector2>(L, 1)) 
                {
                    UnityEngine.Vector2 _vector;translator.Get(L, 1, out _vector);
                    
                        K_PathFinder.XZPosInt gen_ret = K_PathFinder.PathFinder.ToChunkPosition( _vector );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<UnityEngine.Vector3>(L, 1)) 
                {
                    UnityEngine.Vector3 _vector;translator.Get(L, 1, out _vector);
                    
                        K_PathFinder.XZPosInt gen_ret = K_PathFinder.PathFinder.ToChunkPosition( _vector );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<UnityEngine.Bounds>(L, 1)) 
                {
                    UnityEngine.Bounds _bounds;translator.Get(L, 1, out _bounds);
                    
                        K_PathFinder.Bounds2DInt gen_ret = K_PathFinder.PathFinder.ToChunkPosition( _bounds );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinder.ToChunkPosition!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddAreaHash_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    K_PathFinder.Area _area = (K_PathFinder.Area)translator.GetObject(L, 1, typeof(K_PathFinder.Area));
                    
                    K_PathFinder.PathFinder.AddAreaHash( _area );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveAreaHash_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    K_PathFinder.Area _area = (K_PathFinder.Area)translator.GetObject(L, 1, typeof(K_PathFinder.Area));
                    
                    K_PathFinder.PathFinder.RemoveAreaHash( _area );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAreaHash_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    K_PathFinder.Area _area = (K_PathFinder.Area)translator.GetObject(L, 1, typeof(K_PathFinder.Area));
                    K_PathFinder.Passability _passability;translator.Get(L, 2, out _passability);
                    
                        int gen_ret = K_PathFinder.PathFinder.GetAreaHash( _area, _passability );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAreaByHash_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    short _value = (short)LuaAPI.xlua_tointeger(L, 1);
                    K_PathFinder.Area _area;
                    K_PathFinder.Passability _passability;
                    
                    K_PathFinder.PathFinder.GetAreaByHash( _value, out _area, out _passability );
                    translator.Push(L, _area);
                        
                    translator.Push(L, _passability);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloneHashData_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        K_PathFinder.AreaPassabilityHashData gen_ret = K_PathFinder.PathFinder.CloneHashData(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SaveCurrentSceneData_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    K_PathFinder.PathFinder.SaveCurrentSceneData(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearCurrenSceneData_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    K_PathFinder.PathFinder.ClearCurrenSceneData(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadCurrentSceneData_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    K_PathFinder.PathFinder.LoadCurrentSceneData(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckNavmeshIntegrity_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    System.Text.StringBuilder _sb = (System.Text.StringBuilder)translator.GetObject(L, 1, typeof(System.Text.StringBuilder));
                    
                    K_PathFinder.PathFinder.CheckNavmeshIntegrity( _sb );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ProcessCellContent_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    K_PathFinder.ICellContentValueExternal _processedContent = (K_PathFinder.ICellContentValueExternal)translator.GetObject(L, 1, typeof(K_PathFinder.ICellContentValueExternal));
                    
                    K_PathFinder.PathFinder.ProcessCellContent( _processedContent );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveCellContent_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    K_PathFinder.ICellContentValueExternal _removedContent = (K_PathFinder.ICellContentValueExternal)translator.GetObject(L, 1, typeof(K_PathFinder.ICellContentValueExternal));
                    
                    K_PathFinder.PathFinder.RemoveCellContent( _removedContent );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DebugCellsContent_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    K_PathFinder.PathFinder.DebugCellsContent(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CountContent_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _x = LuaAPI.xlua_tointeger(L, 1);
                    int _z = LuaAPI.xlua_tointeger(L, 2);
                    
                        int gen_ret = K_PathFinder.PathFinder.CountContent( _x, _z );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveChunkContent_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    K_PathFinder.IChunkContent _removedContent = (K_PathFinder.IChunkContent)translator.GetObject(L, 1, typeof(K_PathFinder.IChunkContent));
                    
                    K_PathFinder.PathFinder.RemoveChunkContent( _removedContent );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ProcessChunkContent_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    K_PathFinder.IChunkContent _processedContent = (K_PathFinder.IChunkContent)translator.GetObject(L, 1, typeof(K_PathFinder.IChunkContent));
                    
                    K_PathFinder.PathFinder.ProcessChunkContent( _processedContent );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddDeltaCostValue_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    K_PathFinder.DeltaCostValue _value = (K_PathFinder.DeltaCostValue)translator.GetObject(L, 1, typeof(K_PathFinder.DeltaCostValue));
                    
                    K_PathFinder.PathFinder.AddDeltaCostValue( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveDeltaCostValue_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    K_PathFinder.DeltaCostValue _value = (K_PathFinder.DeltaCostValue)translator.GetObject(L, 1, typeof(K_PathFinder.DeltaCostValue));
                    
                    K_PathFinder.PathFinder.RemoveDeltaCostValue( _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DebugDeltaCost_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    K_PathFinder.PFDebuger.DebugSet _set = (K_PathFinder.PFDebuger.DebugSet)translator.GetObject(L, 1, typeof(K_PathFinder.PFDebuger.DebugSet));
                    
                    K_PathFinder.PathFinder.DebugDeltaCost( _set );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterNavmeshSample_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<K_PathFinder.AgentProperties>(L, 1)) 
                {
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 1, typeof(K_PathFinder.AgentProperties));
                    
                        int gen_ret = K_PathFinder.PathFinder.RegisterNavmeshSample( _properties );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 6&& translator.Assignable<K_PathFinder.AgentProperties>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)) 
                {
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 1, typeof(K_PathFinder.AgentProperties));
                    float _x = (float)LuaAPI.lua_tonumber(L, 2);
                    float _y = (float)LuaAPI.lua_tonumber(L, 3);
                    float _z = (float)LuaAPI.lua_tonumber(L, 4);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 5);
                    bool _set = LuaAPI.lua_toboolean(L, 6);
                    
                        int gen_ret = K_PathFinder.PathFinder.RegisterNavmeshSample( _properties, _x, _y, _z, _layerMask, _set );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<K_PathFinder.AgentProperties>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    K_PathFinder.AgentProperties _properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 1, typeof(K_PathFinder.AgentProperties));
                    UnityEngine.Vector3 _position;translator.Get(L, 2, out _position);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 3);
                    bool _set = LuaAPI.lua_toboolean(L, 4);
                    
                        int gen_ret = K_PathFinder.PathFinder.RegisterNavmeshSample( _properties, _position, _layerMask, _set );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinder.RegisterNavmeshSample!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnregisterNavmeshSample_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _id = LuaAPI.xlua_tointeger(L, 1);
                    
                    K_PathFinder.PathFinder.UnregisterNavmeshSample( _id );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1&& translator.Assignable<int[]>(L, 1)) 
                {
                    int[] _ids = (int[])translator.GetObject(L, 1, typeof(int[]));
                    
                    K_PathFinder.PathFinder.UnregisterNavmeshSample( _ids );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<int[]>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int[] _ids = (int[])translator.GetObject(L, 1, typeof(int[]));
                    int _idsLength = LuaAPI.xlua_tointeger(L, 2);
                    
                    K_PathFinder.PathFinder.UnregisterNavmeshSample( _ids, _idsLength );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinder.UnregisterNavmeshSample!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnregisterNavmeshSampleAndReturnResult_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _id = LuaAPI.xlua_tointeger(L, 1);
                    
                        K_PathFinder.NavmeshSampleResult_Internal gen_ret = K_PathFinder.PathFinder.UnregisterNavmeshSampleAndReturnResult( _id );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterLocalAvoidanceAgent_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    K_PathFinder.LocalAvoidanceAgent _agent = (K_PathFinder.LocalAvoidanceAgent)translator.GetObject(L, 1, typeof(K_PathFinder.LocalAvoidanceAgent));
                    
                    K_PathFinder.PathFinder.RegisterLocalAvoidanceAgent( _agent );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnregisterLocalAvoidanceAgent_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    K_PathFinder.LocalAvoidanceAgent _agent = (K_PathFinder.LocalAvoidanceAgent)translator.GetObject(L, 1, typeof(K_PathFinder.LocalAvoidanceAgent));
                    
                    K_PathFinder.PathFinder.UnregisterLocalAvoidanceAgent( _agent );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LineLineIntersection_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector3 _intersection;
                    UnityEngine.Vector3 _linePoint1;translator.Get(L, 1, out _linePoint1);
                    UnityEngine.Vector3 _lineVec1;translator.Get(L, 2, out _lineVec1);
                    UnityEngine.Vector3 _linePoint2;translator.Get(L, 3, out _linePoint2);
                    UnityEngine.Vector3 _lineVec2;translator.Get(L, 4, out _lineVec2);
                    
                        bool gen_ret = K_PathFinder.PathFinder.LineLineIntersection( out _intersection, _linePoint1, _lineVec1, _linePoint2, _lineVec2 );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.PushUnityEngineVector3(L, _intersection);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_settings(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, K_PathFinder.PathFinder.settings);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_areaCount(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, K_PathFinder.PathFinder.areaCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_getDefaultArea(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, K_PathFinder.PathFinder.getDefaultArea);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_getUnwalkableArea(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, K_PathFinder.PathFinder.getUnwalkableArea);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_areInit(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, K_PathFinder.PathFinder.areInit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_gridLowest(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, K_PathFinder.PathFinder.gridLowest);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_gridHighest(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, K_PathFinder.PathFinder.gridHighest);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_multithread(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, K_PathFinder.PathFinder.multithread);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_terrainCollectionType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, K_PathFinder.PathFinder.terrainCollectionType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_colliderCollectorType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, K_PathFinder.PathFinder.colliderCollectorType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_eventCellContentWorkCount(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, K_PathFinder.PathFinder.eventCellContentWorkCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_eventCellContentHaveWork(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, K_PathFinder.PathFinder.eventCellContentHaveWork);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sceneInstance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, K_PathFinder.PathFinder.sceneInstance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mainThreadDelegateQueue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, K_PathFinder.PathFinder.mainThreadDelegateQueue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pathFinderDelegateQueue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, K_PathFinder.PathFinder.pathFinderDelegateQueue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_gridSize(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, K_PathFinder.PathFinder.gridSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_queryBatcher(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, K_PathFinder.PathFinder.queryBatcher);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_dotShader(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, K_PathFinder.PathFinder.dotShader);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lineShader(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, K_PathFinder.PathFinder.lineShader);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_trisShader(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, K_PathFinder.PathFinder.trisShader);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_navmeshThreadState(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, K_PathFinder.PathFinder.navmeshThreadState);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cellDeltaCostArray(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, K_PathFinder.PathFinder.cellDeltaCostArray);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_deltaCostMaxGroupCount(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, K_PathFinder.PathFinder.deltaCostMaxGroupCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_navmeshPositionResults(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, K_PathFinder.PathFinder.navmeshPositionResults);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_sceneInstance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    K_PathFinder.PathFinder.sceneInstance = (K_PathFinder.PathFinderScene)translator.GetObject(L, 1, typeof(K_PathFinder.PathFinderScene));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mainThreadDelegateQueue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    K_PathFinder.PathFinder.mainThreadDelegateQueue = (System.Collections.Generic.Queue<System.Action>)translator.GetObject(L, 1, typeof(System.Collections.Generic.Queue<System.Action>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pathFinderDelegateQueue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    K_PathFinder.PathFinder.pathFinderDelegateQueue = (System.Collections.Generic.Queue<System.Action>)translator.GetObject(L, 1, typeof(System.Collections.Generic.Queue<System.Action>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_gridSize(RealStatePtr L)
        {
		    try {
                
			    K_PathFinder.PathFinder.gridSize = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_queryBatcher(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    K_PathFinder.PathFinder.queryBatcher = (K_PathFinder.PFTools.ThreadPoolWorkBatcher<K_PathFinder.PFTools.IThreadPoolWorkBatcherMember>)translator.GetObject(L, 1, typeof(K_PathFinder.PFTools.ThreadPoolWorkBatcher<K_PathFinder.PFTools.IThreadPoolWorkBatcherMember>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_dotShader(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    K_PathFinder.PathFinder.dotShader = (UnityEngine.Shader)translator.GetObject(L, 1, typeof(UnityEngine.Shader));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_lineShader(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    K_PathFinder.PathFinder.lineShader = (UnityEngine.Shader)translator.GetObject(L, 1, typeof(UnityEngine.Shader));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_trisShader(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    K_PathFinder.PathFinder.trisShader = (UnityEngine.Shader)translator.GetObject(L, 1, typeof(UnityEngine.Shader));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_navmeshThreadState(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    K_PathFinder.PathFinder.navmeshThreadState = (K_PathFinder.PathFinder.PathFinderActionState[])translator.GetObject(L, 1, typeof(K_PathFinder.PathFinder.PathFinderActionState[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_cellDeltaCostArray(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    K_PathFinder.PathFinder.cellDeltaCostArray = (float[])translator.GetObject(L, 1, typeof(float[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_deltaCostMaxGroupCount(RealStatePtr L)
        {
		    try {
                
			    K_PathFinder.PathFinder.deltaCostMaxGroupCount = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_navmeshPositionResults(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    K_PathFinder.PathFinder.navmeshPositionResults = (K_PathFinder.NavmeshSampleResult_Internal[])translator.GetObject(L, 1, typeof(K_PathFinder.NavmeshSampleResult_Internal[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
