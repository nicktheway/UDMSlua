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
    public class K_PathFinderPathFinderAgentWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(K_PathFinder.PathFinderAgent);
			Utils.BeginObjectRegister(type, L, translator, 0, 22, 33, 22);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Awake", _m_Awake);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Update", _m_Update);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnEnable", _m_OnEnable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDisable", _m_OnDisable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDestroy", _m_OnDestroy);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveNextNode", _m_RemoveNextNode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveNextNodeIfCloserSqr", _m_RemoveNextNodeIfCloserSqr);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveNextNodeIfCloserSqrVector2", _m_RemoveNextNodeIfCloserSqrVector2);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveNextNodeIfCloser", _m_RemoveNextNodeIfCloser);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveNextNodeIfCloserVector2", _m_RemoveNextNodeIfCloserVector2);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveNextNodeIfCloserThanRadius", _m_RemoveNextNodeIfCloserThanRadius);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveNextNodeIfCloserThanRadiusVector2", _m_RemoveNextNodeIfCloserThanRadiusVector2);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MovableDistanceLesserThan", _m_MovableDistanceLesserThan);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetRecievePathDelegate", _m_SetRecievePathDelegate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveRecievePathDelegate", _m_RemoveRecievePathDelegate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetRecieveSampleDelegate", _m_SetRecieveSampleDelegate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveRecieveSampleDelegate", _m_RemoveRecieveSampleDelegate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetRecieveCoverDelegate", _m_SetRecieveCoverDelegate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveRecieveCoverDelegate", _m_RemoveRecieveCoverDelegate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetGoalMoveHere", _m_SetGoalMoveHere);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetGoalGetSamplePoints", _m_SetGoalGetSamplePoints);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetGoalFindCover", _m_SetGoalFindCover);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "velocityObstacle", _g_get_velocityObstacle);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "velocity", _g_get_velocity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "preferableVelocity", _g_get_preferableVelocity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "safeVelocity", _g_get_safeVelocity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxAgentVelocity", _g_get_maxAgentVelocity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "avoidanceResponsibility", _g_get_avoidanceResponsibility);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "careDistance", _g_get_careDistance);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxNeighbors", _g_get_maxNeighbors);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxNeighbourDistance", _g_get_maxNeighbourDistance);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "useDeadLockFailsafe", _g_get_useDeadLockFailsafe);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "deadLockVelocityThreshold", _g_get_deadLockVelocityThreshold);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "deadLockFailsafeVelocity", _g_get_deadLockFailsafeVelocity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "deadLockFailsafeTime", _g_get_deadLockFailsafeTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "preferOneSideEvasion", _g_get_preferOneSideEvasion);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "preferOneSideEvasionOffset", _g_get_preferOneSideEvasionOffset);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "properties", _g_get_properties);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "positionVector3", _g_get_positionVector3);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "positionVector2", _g_get_positionVector2);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "radius", _g_get_radius);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "covers", _g_get_covers);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "sampledPoints", _g_get_sampledPoints);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pathFallbackPosition", _g_get_pathFallbackPosition);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "path", _g_get_path);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "haveNextNode", _g_get_haveNextNode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "nextNode", _g_get_nextNode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "nextNodeDirectionVector3", _g_get_nextNodeDirectionVector3);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "nextNodeDirectionVector2", _g_get_nextNodeDirectionVector2);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "PFlayerMask", _g_get_PFlayerMask);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "PFmodifierMask", _g_get_PFmodifierMask);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "queryPath", _g_get_queryPath);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "queryCover", _g_get_queryCover);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "queryCellSample", _g_get_queryCellSample);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "localAvoidanceAgent", _g_get_localAvoidanceAgent);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "velocityObstacle", _s_set_velocityObstacle);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "velocity", _s_set_velocity);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "preferableVelocity", _s_set_preferableVelocity);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "safeVelocity", _s_set_safeVelocity);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxAgentVelocity", _s_set_maxAgentVelocity);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "avoidanceResponsibility", _s_set_avoidanceResponsibility);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "careDistance", _s_set_careDistance);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxNeighbors", _s_set_maxNeighbors);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxNeighbourDistance", _s_set_maxNeighbourDistance);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "useDeadLockFailsafe", _s_set_useDeadLockFailsafe);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "deadLockVelocityThreshold", _s_set_deadLockVelocityThreshold);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "deadLockFailsafeVelocity", _s_set_deadLockFailsafeVelocity);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "deadLockFailsafeTime", _s_set_deadLockFailsafeTime);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "preferOneSideEvasion", _s_set_preferOneSideEvasion);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "preferOneSideEvasionOffset", _s_set_preferOneSideEvasionOffset);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "properties", _s_set_properties);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "PFlayerMask", _s_set_PFlayerMask);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "PFmodifierMask", _s_set_PFmodifierMask);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "queryPath", _s_set_queryPath);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "queryCover", _s_set_queryCover);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "queryCellSample", _s_set_queryCellSample);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "localAvoidanceAgent", _s_set_localAvoidanceAgent);
            
			
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
					
					K_PathFinder.PathFinderAgent gen_ret = new K_PathFinder.PathFinderAgent();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinderAgent constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Awake(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Awake(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Update(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnEnable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnEnable(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDisable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnDisable(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDestroy(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnDestroy(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveNextNode(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool _retainLastNode = LuaAPI.lua_toboolean(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.RemoveNextNode( _retainLastNode );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1) 
                {
                    
                        bool gen_ret = gen_to_be_invoked.RemoveNextNode(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinderAgent.RemoveNextNode!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveNextNodeIfCloserSqr(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    float _sqrDistance = (float)LuaAPI.lua_tonumber(L, 2);
                    bool _retainLastNode = LuaAPI.lua_toboolean(L, 3);
                    
                        bool gen_ret = gen_to_be_invoked.RemoveNextNodeIfCloserSqr( _sqrDistance, _retainLastNode );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _sqrDistance = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.RemoveNextNodeIfCloserSqr( _sqrDistance );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinderAgent.RemoveNextNodeIfCloserSqr!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveNextNodeIfCloserSqrVector2(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    float _sqrDistance = (float)LuaAPI.lua_tonumber(L, 2);
                    bool _retainLastNode = LuaAPI.lua_toboolean(L, 3);
                    
                        bool gen_ret = gen_to_be_invoked.RemoveNextNodeIfCloserSqrVector2( _sqrDistance, _retainLastNode );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _sqrDistance = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.RemoveNextNodeIfCloserSqrVector2( _sqrDistance );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinderAgent.RemoveNextNodeIfCloserSqrVector2!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveNextNodeIfCloser(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    float _distance = (float)LuaAPI.lua_tonumber(L, 2);
                    bool _retainLastNode = LuaAPI.lua_toboolean(L, 3);
                    
                        bool gen_ret = gen_to_be_invoked.RemoveNextNodeIfCloser( _distance, _retainLastNode );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _distance = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.RemoveNextNodeIfCloser( _distance );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinderAgent.RemoveNextNodeIfCloser!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveNextNodeIfCloserVector2(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    float _distance = (float)LuaAPI.lua_tonumber(L, 2);
                    bool _retainLastNode = LuaAPI.lua_toboolean(L, 3);
                    
                        bool gen_ret = gen_to_be_invoked.RemoveNextNodeIfCloserVector2( _distance, _retainLastNode );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _distance = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.RemoveNextNodeIfCloserVector2( _distance );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinderAgent.RemoveNextNodeIfCloserVector2!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveNextNodeIfCloserThanRadius(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool _retainLastNode = LuaAPI.lua_toboolean(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.RemoveNextNodeIfCloserThanRadius( _retainLastNode );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1) 
                {
                    
                        bool gen_ret = gen_to_be_invoked.RemoveNextNodeIfCloserThanRadius(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinderAgent.RemoveNextNodeIfCloserThanRadius!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveNextNodeIfCloserThanRadiusVector2(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool _retainLastNode = LuaAPI.lua_toboolean(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.RemoveNextNodeIfCloserThanRadiusVector2( _retainLastNode );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1) 
                {
                    
                        bool gen_ret = gen_to_be_invoked.RemoveNextNodeIfCloserThanRadiusVector2(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinderAgent.RemoveNextNodeIfCloserThanRadiusVector2!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MovableDistanceLesserThan(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _targetDistance = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.MovableDistanceLesserThan( _targetDistance );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _targetDistance = (float)LuaAPI.lua_tonumber(L, 2);
                    bool _reachLastPoint;
                    
                        bool gen_ret = gen_to_be_invoked.MovableDistanceLesserThan( _targetDistance, out _reachLastPoint );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    LuaAPI.lua_pushboolean(L, _reachLastPoint);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _targetDistance = (float)LuaAPI.lua_tonumber(L, 2);
                    K_PathFinder.PathNode _node;
                    
                        bool gen_ret = gen_to_be_invoked.MovableDistanceLesserThan( _targetDistance, out _node );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _node);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _targetDistance = (float)LuaAPI.lua_tonumber(L, 2);
                    float _distance;
                    
                        bool gen_ret = gen_to_be_invoked.MovableDistanceLesserThan( _targetDistance, out _distance );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    LuaAPI.lua_pushnumber(L, _distance);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _targetDistance = (float)LuaAPI.lua_tonumber(L, 2);
                    float _distance;
                    bool _reachLastPoint;
                    
                        bool gen_ret = gen_to_be_invoked.MovableDistanceLesserThan( _targetDistance, out _distance, out _reachLastPoint );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    LuaAPI.lua_pushnumber(L, _distance);
                        
                    LuaAPI.lua_pushboolean(L, _reachLastPoint);
                        
                    
                    
                    
                    return 3;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _targetDistance = (float)LuaAPI.lua_tonumber(L, 2);
                    float _distance;
                    K_PathFinder.PathNode _node;
                    bool _reachLastPoint;
                    
                        bool gen_ret = gen_to_be_invoked.MovableDistanceLesserThan( _targetDistance, out _distance, out _node, out _reachLastPoint );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    LuaAPI.lua_pushnumber(L, _distance);
                        
                    translator.Push(L, _node);
                        
                    LuaAPI.lua_pushboolean(L, _reachLastPoint);
                        
                    
                    
                    
                    return 4;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinderAgent.MovableDistanceLesserThan!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRecievePathDelegate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<System.Action<K_PathFinder.Path>>(L, 2)&& translator.Assignable<K_PathFinder.AgentDelegateMode>(L, 3)) 
                {
                    System.Action<K_PathFinder.Path> _pathDelegate = translator.GetDelegate<System.Action<K_PathFinder.Path>>(L, 2);
                    K_PathFinder.AgentDelegateMode _mode;translator.Get(L, 3, out _mode);
                    
                    gen_to_be_invoked.SetRecievePathDelegate( _pathDelegate, _mode );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Action<K_PathFinder.Path>>(L, 2)) 
                {
                    System.Action<K_PathFinder.Path> _pathDelegate = translator.GetDelegate<System.Action<K_PathFinder.Path>>(L, 2);
                    
                    gen_to_be_invoked.SetRecievePathDelegate( _pathDelegate );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinderAgent.SetRecievePathDelegate!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveRecievePathDelegate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<K_PathFinder.AgentDelegateMode>(L, 2)) 
                {
                    K_PathFinder.AgentDelegateMode _mode;translator.Get(L, 2, out _mode);
                    
                    gen_to_be_invoked.RemoveRecievePathDelegate( _mode );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.RemoveRecievePathDelegate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinderAgent.RemoveRecievePathDelegate!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRecieveSampleDelegate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<System.Action<System.Collections.Generic.List<K_PathFinder.PointQueryResult<K_PathFinder.CellSamplePoint>>>>(L, 2)&& translator.Assignable<K_PathFinder.AgentDelegateMode>(L, 3)) 
                {
                    System.Action<System.Collections.Generic.List<K_PathFinder.PointQueryResult<K_PathFinder.CellSamplePoint>>> _gridDelegate = translator.GetDelegate<System.Action<System.Collections.Generic.List<K_PathFinder.PointQueryResult<K_PathFinder.CellSamplePoint>>>>(L, 2);
                    K_PathFinder.AgentDelegateMode _mode;translator.Get(L, 3, out _mode);
                    
                    gen_to_be_invoked.SetRecieveSampleDelegate( _gridDelegate, _mode );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Action<System.Collections.Generic.List<K_PathFinder.PointQueryResult<K_PathFinder.CellSamplePoint>>>>(L, 2)) 
                {
                    System.Action<System.Collections.Generic.List<K_PathFinder.PointQueryResult<K_PathFinder.CellSamplePoint>>> _gridDelegate = translator.GetDelegate<System.Action<System.Collections.Generic.List<K_PathFinder.PointQueryResult<K_PathFinder.CellSamplePoint>>>>(L, 2);
                    
                    gen_to_be_invoked.SetRecieveSampleDelegate( _gridDelegate );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinderAgent.SetRecieveSampleDelegate!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveRecieveSampleDelegate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<K_PathFinder.AgentDelegateMode>(L, 2)) 
                {
                    K_PathFinder.AgentDelegateMode _mode;translator.Get(L, 2, out _mode);
                    
                    gen_to_be_invoked.RemoveRecieveSampleDelegate( _mode );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.RemoveRecieveSampleDelegate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinderAgent.RemoveRecieveSampleDelegate!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRecieveCoverDelegate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<System.Action<System.Collections.Generic.List<K_PathFinder.PointQueryResult<K_PathFinder.CoverNamespace.NodeCoverPoint>>>>(L, 2)&& translator.Assignable<K_PathFinder.AgentDelegateMode>(L, 3)) 
                {
                    System.Action<System.Collections.Generic.List<K_PathFinder.PointQueryResult<K_PathFinder.CoverNamespace.NodeCoverPoint>>> _coverDelegate = translator.GetDelegate<System.Action<System.Collections.Generic.List<K_PathFinder.PointQueryResult<K_PathFinder.CoverNamespace.NodeCoverPoint>>>>(L, 2);
                    K_PathFinder.AgentDelegateMode _mode;translator.Get(L, 3, out _mode);
                    
                    gen_to_be_invoked.SetRecieveCoverDelegate( _coverDelegate, _mode );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Action<System.Collections.Generic.List<K_PathFinder.PointQueryResult<K_PathFinder.CoverNamespace.NodeCoverPoint>>>>(L, 2)) 
                {
                    System.Action<System.Collections.Generic.List<K_PathFinder.PointQueryResult<K_PathFinder.CoverNamespace.NodeCoverPoint>>> _coverDelegate = translator.GetDelegate<System.Action<System.Collections.Generic.List<K_PathFinder.PointQueryResult<K_PathFinder.CoverNamespace.NodeCoverPoint>>>>(L, 2);
                    
                    gen_to_be_invoked.SetRecieveCoverDelegate( _coverDelegate );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinderAgent.SetRecieveCoverDelegate!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveRecieveCoverDelegate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<K_PathFinder.AgentDelegateMode>(L, 2)) 
                {
                    K_PathFinder.AgentDelegateMode _mode;translator.Get(L, 2, out _mode);
                    
                    gen_to_be_invoked.RemoveRecieveCoverDelegate( _mode );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.RemoveRecieveCoverDelegate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinderAgent.RemoveRecieveCoverDelegate!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetGoalMoveHere(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 6&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<K_PathFinder.BestFitOptions>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)) 
                {
                    UnityEngine.Vector3 _destination;translator.Get(L, 2, out _destination);
                    K_PathFinder.BestFitOptions _bestFitSearch;translator.Get(L, 3, out _bestFitSearch);
                    bool _applyRaycast = LuaAPI.lua_toboolean(L, 4);
                    bool _collectPathContent = LuaAPI.lua_toboolean(L, 5);
                    bool _ignoreCrouchCost = LuaAPI.lua_toboolean(L, 6);
                    
                    gen_to_be_invoked.SetGoalMoveHere( _destination, _bestFitSearch, _applyRaycast, _collectPathContent, _ignoreCrouchCost );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<K_PathFinder.BestFitOptions>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    UnityEngine.Vector3 _destination;translator.Get(L, 2, out _destination);
                    K_PathFinder.BestFitOptions _bestFitSearch;translator.Get(L, 3, out _bestFitSearch);
                    bool _applyRaycast = LuaAPI.lua_toboolean(L, 4);
                    bool _collectPathContent = LuaAPI.lua_toboolean(L, 5);
                    
                    gen_to_be_invoked.SetGoalMoveHere( _destination, _bestFitSearch, _applyRaycast, _collectPathContent );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<K_PathFinder.BestFitOptions>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Vector3 _destination;translator.Get(L, 2, out _destination);
                    K_PathFinder.BestFitOptions _bestFitSearch;translator.Get(L, 3, out _bestFitSearch);
                    bool _applyRaycast = LuaAPI.lua_toboolean(L, 4);
                    
                    gen_to_be_invoked.SetGoalMoveHere( _destination, _bestFitSearch, _applyRaycast );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<K_PathFinder.BestFitOptions>(L, 3)) 
                {
                    UnityEngine.Vector3 _destination;translator.Get(L, 2, out _destination);
                    K_PathFinder.BestFitOptions _bestFitSearch;translator.Get(L, 3, out _bestFitSearch);
                    
                    gen_to_be_invoked.SetGoalMoveHere( _destination, _bestFitSearch );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 _destination;translator.Get(L, 2, out _destination);
                    
                    gen_to_be_invoked.SetGoalMoveHere( _destination );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 8&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<K_PathFinder.BestFitOptions>(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 7)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8)) 
                {
                    UnityEngine.Vector3 _destination;translator.Get(L, 2, out _destination);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 3);
                    int _costModifierMask = LuaAPI.xlua_tointeger(L, 4);
                    K_PathFinder.BestFitOptions _bestFitSearch;translator.Get(L, 5, out _bestFitSearch);
                    bool _applyRaycast = LuaAPI.lua_toboolean(L, 6);
                    bool _collectPathContent = LuaAPI.lua_toboolean(L, 7);
                    bool _ignoreCrouchCost = LuaAPI.lua_toboolean(L, 8);
                    
                    gen_to_be_invoked.SetGoalMoveHere( _destination, _layerMask, _costModifierMask, _bestFitSearch, _applyRaycast, _collectPathContent, _ignoreCrouchCost );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 7&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<K_PathFinder.BestFitOptions>(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 7)) 
                {
                    UnityEngine.Vector3 _destination;translator.Get(L, 2, out _destination);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 3);
                    int _costModifierMask = LuaAPI.xlua_tointeger(L, 4);
                    K_PathFinder.BestFitOptions _bestFitSearch;translator.Get(L, 5, out _bestFitSearch);
                    bool _applyRaycast = LuaAPI.lua_toboolean(L, 6);
                    bool _collectPathContent = LuaAPI.lua_toboolean(L, 7);
                    
                    gen_to_be_invoked.SetGoalMoveHere( _destination, _layerMask, _costModifierMask, _bestFitSearch, _applyRaycast, _collectPathContent );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 6&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<K_PathFinder.BestFitOptions>(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)) 
                {
                    UnityEngine.Vector3 _destination;translator.Get(L, 2, out _destination);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 3);
                    int _costModifierMask = LuaAPI.xlua_tointeger(L, 4);
                    K_PathFinder.BestFitOptions _bestFitSearch;translator.Get(L, 5, out _bestFitSearch);
                    bool _applyRaycast = LuaAPI.lua_toboolean(L, 6);
                    
                    gen_to_be_invoked.SetGoalMoveHere( _destination, _layerMask, _costModifierMask, _bestFitSearch, _applyRaycast );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<K_PathFinder.BestFitOptions>(L, 5)) 
                {
                    UnityEngine.Vector3 _destination;translator.Get(L, 2, out _destination);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 3);
                    int _costModifierMask = LuaAPI.xlua_tointeger(L, 4);
                    K_PathFinder.BestFitOptions _bestFitSearch;translator.Get(L, 5, out _bestFitSearch);
                    
                    gen_to_be_invoked.SetGoalMoveHere( _destination, _layerMask, _costModifierMask, _bestFitSearch );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.Vector3 _destination;translator.Get(L, 2, out _destination);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 3);
                    int _costModifierMask = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.SetGoalMoveHere( _destination, _layerMask, _costModifierMask );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 7&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<K_PathFinder.BestFitOptions>(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 7)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 2, out _start);
                    UnityEngine.Vector3 _destination;translator.Get(L, 3, out _destination);
                    K_PathFinder.BestFitOptions _bestFitSearch;translator.Get(L, 4, out _bestFitSearch);
                    bool _applyRaycast = LuaAPI.lua_toboolean(L, 5);
                    bool _collectPathContent = LuaAPI.lua_toboolean(L, 6);
                    bool _ignoreCrouchCost = LuaAPI.lua_toboolean(L, 7);
                    
                    gen_to_be_invoked.SetGoalMoveHere( _start, _destination, _bestFitSearch, _applyRaycast, _collectPathContent, _ignoreCrouchCost );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 6&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<K_PathFinder.BestFitOptions>(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 2, out _start);
                    UnityEngine.Vector3 _destination;translator.Get(L, 3, out _destination);
                    K_PathFinder.BestFitOptions _bestFitSearch;translator.Get(L, 4, out _bestFitSearch);
                    bool _applyRaycast = LuaAPI.lua_toboolean(L, 5);
                    bool _collectPathContent = LuaAPI.lua_toboolean(L, 6);
                    
                    gen_to_be_invoked.SetGoalMoveHere( _start, _destination, _bestFitSearch, _applyRaycast, _collectPathContent );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<K_PathFinder.BestFitOptions>(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 2, out _start);
                    UnityEngine.Vector3 _destination;translator.Get(L, 3, out _destination);
                    K_PathFinder.BestFitOptions _bestFitSearch;translator.Get(L, 4, out _bestFitSearch);
                    bool _applyRaycast = LuaAPI.lua_toboolean(L, 5);
                    
                    gen_to_be_invoked.SetGoalMoveHere( _start, _destination, _bestFitSearch, _applyRaycast );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<K_PathFinder.BestFitOptions>(L, 4)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 2, out _start);
                    UnityEngine.Vector3 _destination;translator.Get(L, 3, out _destination);
                    K_PathFinder.BestFitOptions _bestFitSearch;translator.Get(L, 4, out _bestFitSearch);
                    
                    gen_to_be_invoked.SetGoalMoveHere( _start, _destination, _bestFitSearch );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 2, out _start);
                    UnityEngine.Vector3 _destination;translator.Get(L, 3, out _destination);
                    
                    gen_to_be_invoked.SetGoalMoveHere( _start, _destination );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 9&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<K_PathFinder.BestFitOptions>(L, 6)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 7)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 9)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 2, out _start);
                    UnityEngine.Vector3 _destination;translator.Get(L, 3, out _destination);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 4);
                    int _costModifierMask = LuaAPI.xlua_tointeger(L, 5);
                    K_PathFinder.BestFitOptions _bestFitSearch;translator.Get(L, 6, out _bestFitSearch);
                    bool _applyRaycast = LuaAPI.lua_toboolean(L, 7);
                    bool _collectPathContent = LuaAPI.lua_toboolean(L, 8);
                    bool _ignoreCrouchCost = LuaAPI.lua_toboolean(L, 9);
                    
                    gen_to_be_invoked.SetGoalMoveHere( _start, _destination, _layerMask, _costModifierMask, _bestFitSearch, _applyRaycast, _collectPathContent, _ignoreCrouchCost );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 8&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<K_PathFinder.BestFitOptions>(L, 6)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 7)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 8)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 2, out _start);
                    UnityEngine.Vector3 _destination;translator.Get(L, 3, out _destination);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 4);
                    int _costModifierMask = LuaAPI.xlua_tointeger(L, 5);
                    K_PathFinder.BestFitOptions _bestFitSearch;translator.Get(L, 6, out _bestFitSearch);
                    bool _applyRaycast = LuaAPI.lua_toboolean(L, 7);
                    bool _collectPathContent = LuaAPI.lua_toboolean(L, 8);
                    
                    gen_to_be_invoked.SetGoalMoveHere( _start, _destination, _layerMask, _costModifierMask, _bestFitSearch, _applyRaycast, _collectPathContent );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 7&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<K_PathFinder.BestFitOptions>(L, 6)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 7)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 2, out _start);
                    UnityEngine.Vector3 _destination;translator.Get(L, 3, out _destination);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 4);
                    int _costModifierMask = LuaAPI.xlua_tointeger(L, 5);
                    K_PathFinder.BestFitOptions _bestFitSearch;translator.Get(L, 6, out _bestFitSearch);
                    bool _applyRaycast = LuaAPI.lua_toboolean(L, 7);
                    
                    gen_to_be_invoked.SetGoalMoveHere( _start, _destination, _layerMask, _costModifierMask, _bestFitSearch, _applyRaycast );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 6&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<K_PathFinder.BestFitOptions>(L, 6)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 2, out _start);
                    UnityEngine.Vector3 _destination;translator.Get(L, 3, out _destination);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 4);
                    int _costModifierMask = LuaAPI.xlua_tointeger(L, 5);
                    K_PathFinder.BestFitOptions _bestFitSearch;translator.Get(L, 6, out _bestFitSearch);
                    
                    gen_to_be_invoked.SetGoalMoveHere( _start, _destination, _layerMask, _costModifierMask, _bestFitSearch );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 2, out _start);
                    UnityEngine.Vector3 _destination;translator.Get(L, 3, out _destination);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 4);
                    int _costModifierMask = LuaAPI.xlua_tointeger(L, 5);
                    
                    gen_to_be_invoked.SetGoalMoveHere( _start, _destination, _layerMask, _costModifierMask );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinderAgent.SetGoalMoveHere!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetGoalGetSamplePoints(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    float _maxCost = (float)LuaAPI.lua_tonumber(L, 2);
                    bool _richCost = LuaAPI.lua_toboolean(L, 3);
                    bool _ignoreCrouchCost = LuaAPI.lua_toboolean(L, 4);
                    
                    gen_to_be_invoked.SetGoalGetSamplePoints( _maxCost, _richCost, _ignoreCrouchCost );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    float _maxCost = (float)LuaAPI.lua_tonumber(L, 2);
                    bool _richCost = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.SetGoalGetSamplePoints( _maxCost, _richCost );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _maxCost = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.SetGoalGetSamplePoints( _maxCost );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)) 
                {
                    float _maxCost = (float)LuaAPI.lua_tonumber(L, 2);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 3);
                    int _costModifierMask = LuaAPI.xlua_tointeger(L, 4);
                    bool _richCost = LuaAPI.lua_toboolean(L, 5);
                    bool _ignoreCrouchCost = LuaAPI.lua_toboolean(L, 6);
                    
                    gen_to_be_invoked.SetGoalGetSamplePoints( _maxCost, _layerMask, _costModifierMask, _richCost, _ignoreCrouchCost );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    float _maxCost = (float)LuaAPI.lua_tonumber(L, 2);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 3);
                    int _costModifierMask = LuaAPI.xlua_tointeger(L, 4);
                    bool _richCost = LuaAPI.lua_toboolean(L, 5);
                    
                    gen_to_be_invoked.SetGoalGetSamplePoints( _maxCost, _layerMask, _costModifierMask, _richCost );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    float _maxCost = (float)LuaAPI.lua_tonumber(L, 2);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 3);
                    int _costModifierMask = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.SetGoalGetSamplePoints( _maxCost, _layerMask, _costModifierMask );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count >= 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 5) || translator.Assignable<UnityEngine.Vector3>(L, 5))) 
                {
                    float _maxCost = (float)LuaAPI.lua_tonumber(L, 2);
                    bool _richCost = LuaAPI.lua_toboolean(L, 3);
                    bool _ignoreCrouchCost = LuaAPI.lua_toboolean(L, 4);
                    UnityEngine.Vector3[] _positions = translator.GetParams<UnityEngine.Vector3>(L, 5);
                    
                    gen_to_be_invoked.SetGoalGetSamplePoints( _maxCost, _richCost, _ignoreCrouchCost, _positions );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count >= 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    float _maxCost = (float)LuaAPI.lua_tonumber(L, 2);
                    bool _richCost = LuaAPI.lua_toboolean(L, 3);
                    bool _ignoreCrouchCost = LuaAPI.lua_toboolean(L, 4);
                    
                    gen_to_be_invoked.SetGoalGetSamplePoints( _maxCost, _richCost, _ignoreCrouchCost );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count >= 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    float _maxCost = (float)LuaAPI.lua_tonumber(L, 2);
                    bool _richCost = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.SetGoalGetSamplePoints( _maxCost, _richCost );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count >= 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _maxCost = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.SetGoalGetSamplePoints( _maxCost );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count >= 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 7) || translator.Assignable<UnityEngine.Vector3>(L, 7))) 
                {
                    float _maxCost = (float)LuaAPI.lua_tonumber(L, 2);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 3);
                    int _costModifierMask = LuaAPI.xlua_tointeger(L, 4);
                    bool _richCost = LuaAPI.lua_toboolean(L, 5);
                    bool _ignoreCrouchCost = LuaAPI.lua_toboolean(L, 6);
                    UnityEngine.Vector3[] _positions = translator.GetParams<UnityEngine.Vector3>(L, 7);
                    
                    gen_to_be_invoked.SetGoalGetSamplePoints( _maxCost, _layerMask, _costModifierMask, _richCost, _ignoreCrouchCost, _positions );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count >= 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)) 
                {
                    float _maxCost = (float)LuaAPI.lua_tonumber(L, 2);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 3);
                    int _costModifierMask = LuaAPI.xlua_tointeger(L, 4);
                    bool _richCost = LuaAPI.lua_toboolean(L, 5);
                    bool _ignoreCrouchCost = LuaAPI.lua_toboolean(L, 6);
                    
                    gen_to_be_invoked.SetGoalGetSamplePoints( _maxCost, _layerMask, _costModifierMask, _richCost, _ignoreCrouchCost );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count >= 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    float _maxCost = (float)LuaAPI.lua_tonumber(L, 2);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 3);
                    int _costModifierMask = LuaAPI.xlua_tointeger(L, 4);
                    bool _richCost = LuaAPI.lua_toboolean(L, 5);
                    
                    gen_to_be_invoked.SetGoalGetSamplePoints( _maxCost, _layerMask, _costModifierMask, _richCost );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count >= 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    float _maxCost = (float)LuaAPI.lua_tonumber(L, 2);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 3);
                    int _costModifierMask = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.SetGoalGetSamplePoints( _maxCost, _layerMask, _costModifierMask );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinderAgent.SetGoalGetSamplePoints!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetGoalFindCover(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    float _maxMoveCost = (float)LuaAPI.lua_tonumber(L, 2);
                    bool _richCost = LuaAPI.lua_toboolean(L, 3);
                    bool _ignoreCrouchCost = LuaAPI.lua_toboolean(L, 4);
                    
                    gen_to_be_invoked.SetGoalFindCover( _maxMoveCost, _richCost, _ignoreCrouchCost );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    float _maxMoveCost = (float)LuaAPI.lua_tonumber(L, 2);
                    bool _richCost = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.SetGoalFindCover( _maxMoveCost, _richCost );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _maxMoveCost = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.SetGoalFindCover( _maxMoveCost );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 6)) 
                {
                    float _maxMoveCost = (float)LuaAPI.lua_tonumber(L, 2);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 3);
                    int _costModifierMask = LuaAPI.xlua_tointeger(L, 4);
                    bool _richCost = LuaAPI.lua_toboolean(L, 5);
                    bool _ignoreCrouchCost = LuaAPI.lua_toboolean(L, 6);
                    
                    gen_to_be_invoked.SetGoalFindCover( _maxMoveCost, _layerMask, _costModifierMask, _richCost, _ignoreCrouchCost );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 5)) 
                {
                    float _maxMoveCost = (float)LuaAPI.lua_tonumber(L, 2);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 3);
                    int _costModifierMask = LuaAPI.xlua_tointeger(L, 4);
                    bool _richCost = LuaAPI.lua_toboolean(L, 5);
                    
                    gen_to_be_invoked.SetGoalFindCover( _maxMoveCost, _layerMask, _costModifierMask, _richCost );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    float _maxMoveCost = (float)LuaAPI.lua_tonumber(L, 2);
                    int _layerMask = LuaAPI.xlua_tointeger(L, 3);
                    int _costModifierMask = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.SetGoalFindCover( _maxMoveCost, _layerMask, _costModifierMask );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.PathFinderAgent.SetGoalFindCover!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_velocityObstacle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.velocityObstacle);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_velocity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.velocity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_preferableVelocity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.preferableVelocity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_safeVelocity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.safeVelocity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxAgentVelocity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.maxAgentVelocity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_avoidanceResponsibility(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.avoidanceResponsibility);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_careDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.careDistance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxNeighbors(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.maxNeighbors);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxNeighbourDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.maxNeighbourDistance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_useDeadLockFailsafe(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.useDeadLockFailsafe);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_deadLockVelocityThreshold(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.deadLockVelocityThreshold);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_deadLockFailsafeVelocity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.deadLockFailsafeVelocity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_deadLockFailsafeTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.deadLockFailsafeTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_preferOneSideEvasion(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.preferOneSideEvasion);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_preferOneSideEvasionOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.preferOneSideEvasionOffset);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_properties(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.properties);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_positionVector3(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.positionVector3);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_positionVector2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.positionVector2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_radius(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.radius);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_covers(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.covers);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sampledPoints(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.sampledPoints);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pathFallbackPosition(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.pathFallbackPosition);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_path(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.path);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_haveNextNode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.haveNextNode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_nextNode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.nextNode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_nextNodeDirectionVector3(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.nextNodeDirectionVector3);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_nextNodeDirectionVector2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.nextNodeDirectionVector2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PFlayerMask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.PFlayerMask);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PFmodifierMask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.PFmodifierMask);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_queryPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.queryPath);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_queryCover(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.queryCover);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_queryCellSample(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.queryCellSample);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_localAvoidanceAgent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.localAvoidanceAgent);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_velocityObstacle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.velocityObstacle = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_velocity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.velocity = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_preferableVelocity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.preferableVelocity = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_safeVelocity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.safeVelocity = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxAgentVelocity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxAgentVelocity = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_avoidanceResponsibility(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.avoidanceResponsibility = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_careDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.careDistance = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxNeighbors(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxNeighbors = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxNeighbourDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxNeighbourDistance = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_useDeadLockFailsafe(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.useDeadLockFailsafe = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_deadLockVelocityThreshold(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.deadLockVelocityThreshold = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_deadLockFailsafeVelocity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.deadLockFailsafeVelocity = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_deadLockFailsafeTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.deadLockFailsafeTime = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_preferOneSideEvasion(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.preferOneSideEvasion = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_preferOneSideEvasionOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.preferOneSideEvasionOffset = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_properties(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.properties = (K_PathFinder.AgentProperties)translator.GetObject(L, 2, typeof(K_PathFinder.AgentProperties));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PFlayerMask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                K_PathFinder.BitMaskPF gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.PFlayerMask = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PFmodifierMask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                K_PathFinder.BitMaskPF gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.PFmodifierMask = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_queryPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.queryPath = (K_PathFinder.NavMeshPathQueryGeneric)translator.GetObject(L, 2, typeof(K_PathFinder.NavMeshPathQueryGeneric));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_queryCover(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.queryCover = (K_PathFinder.NavMeshPointQuery<K_PathFinder.CoverNamespace.NodeCoverPoint>)translator.GetObject(L, 2, typeof(K_PathFinder.NavMeshPointQuery<K_PathFinder.CoverNamespace.NodeCoverPoint>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_queryCellSample(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.queryCellSample = (K_PathFinder.NavMeshPointQuery<K_PathFinder.CellSamplePoint>)translator.GetObject(L, 2, typeof(K_PathFinder.NavMeshPointQuery<K_PathFinder.CellSamplePoint>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_localAvoidanceAgent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.PathFinderAgent gen_to_be_invoked = (K_PathFinder.PathFinderAgent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.localAvoidanceAgent = (K_PathFinder.LocalAvoidanceAgent)translator.GetObject(L, 2, typeof(K_PathFinder.LocalAvoidanceAgent));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
