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
    public class LuaScriptingLuaGroupDomainWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(LuaScripting.LuaGroupDomain);
			Utils.BeginObjectRegister(type, L, translator, 0, 29, 11, 10);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LoadScriptSymbols", _m_LoadScriptSymbols);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UnloadScriptSymbols", _m_UnloadScriptSymbols);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddMember", _m_AddMember);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddMemberFromPrefab", _m_AddMemberFromPrefab);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveMember", _m_RemoveMember);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetMemberId", _m_GetMemberId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InitializeMembers", _m_InitializeMembers);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Select", _m_Select);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Dispose", _m_Dispose);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BeforeUpdateActions", _m_BeforeUpdateActions);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AfterLateUpdateActions", _m_AfterLateUpdateActions);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateDistanceTable", _m_UpdateDistanceTable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetGroupCenter", _m_GetGroupCenter);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetHoodCenter", _m_GetHoodCenter);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetMemberIdsInCircle", _m_GetMemberIdsInCircle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToGridFormation", _m_ToGridFormation);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetState", _m_SetState);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RegisterGridNeighbours", _m_RegisterGridNeighbours);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetPositions", _m_SetPositions);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetNeighbours", _m_SetNeighbours);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GCAUpdate", _m_GCAUpdate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InfectionUpdate", _m_InfectionUpdate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DistStateUpdate", _m_DistStateUpdate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateStates", _m_UpdateStates);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToggleIndices", _m_ToggleIndices);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HighlightNeigbours", _m_HighlightNeigbours);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DirOfAgent", _m_DirOfAgent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNearestAgentWithState", _m_GetNearestAgentWithState);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DistOfAgents", _m_DistOfAgents);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Dist", _g_get_Dist);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Members", _g_get_Members);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "GroupRoot", _g_get_GroupRoot);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaOnElementAnimatorIK", _g_get_LuaOnElementAnimatorIK);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaOnElementAnimatorMove", _g_get_LuaOnElementAnimatorMove);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaOnElementCollisionEnter", _g_get_LuaOnElementCollisionEnter);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaOnElementCollisionExit", _g_get_LuaOnElementCollisionExit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaOnElementCollisionStay", _g_get_LuaOnElementCollisionStay);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaOnElementTriggerEnter", _g_get_LuaOnElementTriggerEnter);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaOnElementTriggerExit", _g_get_LuaOnElementTriggerExit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaOnElementTriggerStay", _g_get_LuaOnElementTriggerStay);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Members", _s_set_Members);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "GroupRoot", _s_set_GroupRoot);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaOnElementAnimatorIK", _s_set_LuaOnElementAnimatorIK);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaOnElementAnimatorMove", _s_set_LuaOnElementAnimatorMove);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaOnElementCollisionEnter", _s_set_LuaOnElementCollisionEnter);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaOnElementCollisionExit", _s_set_LuaOnElementCollisionExit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaOnElementCollisionStay", _s_set_LuaOnElementCollisionStay);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaOnElementTriggerEnter", _s_set_LuaOnElementTriggerEnter);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaOnElementTriggerExit", _s_set_LuaOnElementTriggerExit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaOnElementTriggerStay", _s_set_LuaOnElementTriggerStay);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "NewGroupDomain", _m_NewGroupDomain_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "LuaScripting.LuaGroupDomain does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadScriptSymbols(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.LoadScriptSymbols(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnloadScriptSymbols(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.UnloadScriptSymbols(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NewGroupDomain_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _groupName = LuaAPI.lua_tostring(L, 1);
                    string _scriptPath = LuaAPI.lua_tostring(L, 2);
                    LuaScripting.LuaRoom _domainRoom = (LuaScripting.LuaRoom)translator.GetObject(L, 3, typeof(LuaScripting.LuaRoom));
                    
                        LuaScripting.LuaGroupDomain gen_ret = LuaScripting.LuaGroupDomain.NewGroupDomain( _groupName, _scriptPath, _domainRoom );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddMember(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<LuaScripting.LuaGroupObject>(L, 2)) 
                {
                    LuaScripting.LuaGroupObject _newMember = (LuaScripting.LuaGroupObject)translator.GetObject(L, 2, typeof(LuaScripting.LuaGroupObject));
                    
                        int gen_ret = gen_to_be_invoked.AddMember( _newMember );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string _objectName = LuaAPI.lua_tostring(L, 2);
                    string _bundleName = LuaAPI.lua_tostring(L, 3);
                    
                        int gen_ret = gen_to_be_invoked.AddMember( _objectName, _bundleName );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaScripting.LuaGroupDomain.AddMember!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddMemberFromPrefab(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.GameObject _prefab = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    
                        int gen_ret = gen_to_be_invoked.AddMemberFromPrefab( _prefab );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveMember(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LuaScripting.LuaGroupObject _member = (LuaScripting.LuaGroupObject)translator.GetObject(L, 2, typeof(LuaScripting.LuaGroupObject));
                    
                    gen_to_be_invoked.RemoveMember( _member );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMemberId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LuaScripting.LuaGroupObject _luaGroupMember = (LuaScripting.LuaGroupObject)translator.GetObject(L, 2, typeof(LuaScripting.LuaGroupObject));
                    
                        int gen_ret = gen_to_be_invoked.GetMemberId( _luaGroupMember );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitializeMembers(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.InitializeMembers(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Select(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    bool _select = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.Select( _select );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Dispose(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Dispose(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BeforeUpdateActions(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.BeforeUpdateActions(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AfterLateUpdateActions(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.AfterLateUpdateActions(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateDistanceTable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.UpdateDistanceTable(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGroupCenter(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.GetGroupCenter(  );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHoodCenter(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _center;translator.Get(L, 2, out _center);
                    float _radius = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.GetHoodCenter( _center, _radius );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMemberIdsInCircle(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _center;translator.Get(L, 2, out _center);
                    float _radius = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        System.Collections.Generic.List<int> gen_ret = gen_to_be_invoked.GetMemberIdsInCircle( _center, _radius );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToGridFormation(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _columns = LuaAPI.xlua_tointeger(L, 2);
                    UnityEngine.Vector3 _topLeftPoint;translator.Get(L, 3, out _topLeftPoint);
                    float _rowDistance = (float)LuaAPI.lua_tonumber(L, 4);
                    float _colDistance = (float)LuaAPI.lua_tonumber(L, 5);
                    
                    gen_to_be_invoked.ToGridFormation( _columns, _topLeftPoint, _rowDistance, _colDistance );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetState(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<int> _activeIds = (System.Collections.Generic.List<int>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<int>));
                    
                    gen_to_be_invoked.SetState( _activeIds );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterGridNeighbours(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _gridColumns = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.RegisterGridNeighbours( _gridColumns );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetPositions(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3[] _positions = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
                    
                    gen_to_be_invoked.SetPositions( _positions );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetNeighbours(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int[][] _neighbours = (int[][])translator.GetObject(L, 2, typeof(int[][]));
                    
                    gen_to_be_invoked.SetNeighbours( _neighbours );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GCAUpdate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LuaScripting.GCA _gca;translator.Get(L, 2, out _gca);
                    
                    gen_to_be_invoked.GCAUpdate( _gca );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InfectionUpdate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LuaScripting.InfectionInfo _infectionInfo;translator.Get(L, 2, out _infectionInfo);
                    
                    gen_to_be_invoked.InfectionUpdate( _infectionInfo );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DistStateUpdate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    LuaScripting.DistUpdateInfo _distUpdateInfo;translator.Get(L, 2, out _distUpdateInfo);
                    
                    gen_to_be_invoked.DistStateUpdate( _distUpdateInfo );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateStates(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _algorithm = LuaAPI.lua_tostring(L, 2);
                    string _algorithmData = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.UpdateStates( _algorithm, _algorithmData );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToggleIndices(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    bool _show = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.ToggleIndices( _show );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HighlightNeigbours(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _memberId = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.HighlightNeigbours( _memberId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DirOfAgent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _agentId = LuaAPI.xlua_tointeger(L, 2);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.DirOfAgent( _agentId );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNearestAgentWithState(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 2, out _position);
                    int _state = LuaAPI.xlua_tointeger(L, 3);
                    
                        int gen_ret = gen_to_be_invoked.GetNearestAgentWithState( _position, _state );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DistOfAgents(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _agentId1 = LuaAPI.xlua_tointeger(L, 2);
                    int _agentId2 = LuaAPI.xlua_tointeger(L, 3);
                    
                        float gen_ret = gen_to_be_invoked.DistOfAgents( _agentId1, _agentId2 );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Dist(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Dist);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Members(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Members);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GroupRoot(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.GroupRoot);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaOnElementAnimatorIK(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaOnElementAnimatorIK);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaOnElementAnimatorMove(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaOnElementAnimatorMove);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaOnElementCollisionEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaOnElementCollisionEnter);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaOnElementCollisionExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaOnElementCollisionExit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaOnElementCollisionStay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaOnElementCollisionStay);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaOnElementTriggerEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaOnElementTriggerEnter);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaOnElementTriggerExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaOnElementTriggerExit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaOnElementTriggerStay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaOnElementTriggerStay);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Members(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Members = (System.Collections.Generic.List<LuaScripting.LuaGroupObject>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<LuaScripting.LuaGroupObject>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_GroupRoot(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.GroupRoot = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaOnElementAnimatorIK(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaOnElementAnimatorIK = translator.GetDelegate<LuaScripting.IntIntAction>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaOnElementAnimatorMove(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaOnElementAnimatorMove = translator.GetDelegate<LuaScripting.IntAction>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaOnElementCollisionEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaOnElementCollisionEnter = translator.GetDelegate<LuaScripting.CollisionIntAction>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaOnElementCollisionExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaOnElementCollisionExit = translator.GetDelegate<LuaScripting.CollisionIntAction>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaOnElementCollisionStay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaOnElementCollisionStay = translator.GetDelegate<LuaScripting.CollisionIntAction>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaOnElementTriggerEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaOnElementTriggerEnter = translator.GetDelegate<LuaScripting.ColliderIntAction>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaOnElementTriggerExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaOnElementTriggerExit = translator.GetDelegate<LuaScripting.ColliderIntAction>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaOnElementTriggerStay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGroupDomain gen_to_be_invoked = (LuaScripting.LuaGroupDomain)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaOnElementTriggerStay = translator.GetDelegate<LuaScripting.ColliderIntAction>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
