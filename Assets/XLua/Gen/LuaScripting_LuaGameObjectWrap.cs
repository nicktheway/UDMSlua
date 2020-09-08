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
    public class LuaScriptingLuaGameObjectWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(LuaScripting.LuaGameObject);
			Utils.BeginObjectRegister(type, L, translator, 0, 39, 8, 7);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Select", _m_Select);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToggleTextMeshObject", _m_ToggleTextMeshObject);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetColor", _m_SetColor);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetText", _m_SetText);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearColor", _m_ClearColor);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RerunDomain", _m_RerunDomain);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Destroy", _m_Destroy);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BeforeUpdateActions", _m_BeforeUpdateActions);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AfterLateUpdateActions", _m_AfterLateUpdateActions);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MoveUp", _m_MoveUp);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MoveFwd", _m_MoveFwd);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MoveRight", _m_MoveRight);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MoveInDir", _m_MoveInDir);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MoveInDirXZ", _m_MoveInDirXZ);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GoToPoint", _m_GoToPoint);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GoToPointXZ", _m_GoToPointXZ);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetDir", _m_SetDir);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetPos", _m_SetPos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetPosX", _m_SetPosX);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetPosY", _m_SetPosY);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetPosZ", _m_SetPosZ);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetRot", _m_SetRot);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetRotX", _m_SetRotX);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetRotY", _m_SetRotY);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetRotZ", _m_SetRotZ);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetScale", _m_SetScale);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "TurnToAngle", _m_TurnToAngle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "TurnToDir", _m_TurnToDir);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "TurnToDirSoft", _m_TurnToDirSoft);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DirAgentToPnt", _m_DirAgentToPnt);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DirMine", _m_DirMine);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DirStayInDisc", _m_DirStayInDisc);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Displacement", _m_Displacement);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DistAgentToPnt", _m_DistAgentToPnt);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DistAgentToPntXZ", _m_DistAgentToPntXZ);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DistTravelled", _m_DistTravelled);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsActive", _m_IsActive);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPos", _m_GetPos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAngles", _m_GetAngles);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "TextMeshComponent", _g_get_TextMeshComponent);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaDomain", _g_get_LuaDomain);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "State", _g_get_State);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "StateOld", _g_get_StateOld);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "PositionOld", _g_get_PositionOld);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EulerAnglesOld", _g_get_EulerAnglesOld);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TurnToMoveDir", _g_get_TurnToMoveDir);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ColorState", _g_get_ColorState);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaDomain", _s_set_LuaDomain);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "State", _s_set_State);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "StateOld", _s_set_StateOld);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "PositionOld", _s_set_PositionOld);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "EulerAnglesOld", _s_set_EulerAnglesOld);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "TurnToMoveDir", _s_set_TurnToMoveDir);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ColorState", _s_set_ColorState);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "LuaScripting.LuaGameObject does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Select(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_ToggleTextMeshObject(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    bool _show = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.ToggleTextMeshObject( _show );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetColor(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    float _r = (float)LuaAPI.lua_tonumber(L, 2);
                    float _g = (float)LuaAPI.lua_tonumber(L, 3);
                    float _b = (float)LuaAPI.lua_tonumber(L, 4);
                    float _a = (float)LuaAPI.lua_tonumber(L, 5);
                    
                    gen_to_be_invoked.SetColor( _r, _g, _b, _a );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    float _r = (float)LuaAPI.lua_tonumber(L, 2);
                    float _g = (float)LuaAPI.lua_tonumber(L, 3);
                    float _b = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    gen_to_be_invoked.SetColor( _r, _g, _b );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Color>(L, 2)) 
                {
                    UnityEngine.Color _color;translator.Get(L, 2, out _color);
                    
                    gen_to_be_invoked.SetColor( _color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaScripting.LuaGameObject.SetColor!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetText(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _text = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.SetText( _text );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearColor(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ClearColor(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RerunDomain(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.RerunDomain(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Destroy(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Destroy(  );
                    
                    
                    
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
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.AfterLateUpdateActions(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveUp(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _distance = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.MoveUp( _distance );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveFwd(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _distance = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.MoveFwd( _distance );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveRight(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _distance = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.MoveRight( _distance );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveInDir(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _direction;translator.Get(L, 2, out _direction);
                    float _distance = (float)LuaAPI.lua_tonumber(L, 3);
                    bool _normalized = LuaAPI.lua_toboolean(L, 4);
                    
                    gen_to_be_invoked.MoveInDir( _direction, _distance, _normalized );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveInDirXZ(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector2 _direction;translator.Get(L, 2, out _direction);
                    float _distance = (float)LuaAPI.lua_tonumber(L, 3);
                    bool _normalized = LuaAPI.lua_toboolean(L, 4);
                    
                    gen_to_be_invoked.MoveInDirXZ( _direction, _distance, _normalized );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoToPoint(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _point;translator.Get(L, 2, out _point);
                    float _distance = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    gen_to_be_invoked.GoToPoint( _point, _distance );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoToPointXZ(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector2 _point;translator.Get(L, 2, out _point);
                    float _distance = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    gen_to_be_invoked.GoToPointXZ( _point, _distance );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDir(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _direction;translator.Get(L, 2, out _direction);
                    
                    gen_to_be_invoked.SetDir( _direction );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetPos(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 2, out _position);
                    
                    gen_to_be_invoked.SetPos( _position );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetPosX(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.SetPosX( _x );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetPosY(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.SetPosY( _y );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetPosZ(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _z = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.SetPosZ( _z );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRot(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _angles;translator.Get(L, 2, out _angles);
                    
                    gen_to_be_invoked.SetRot( _angles );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRotX(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _angle = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.SetRotX( _angle );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRotY(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _angle = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.SetRotY( _angle );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRotZ(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _angle = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.SetRotZ( _angle );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetScale(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _scale;translator.Get(L, 2, out _scale);
                    
                    gen_to_be_invoked.SetScale( _scale );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TurnToAngle(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _targetAngle = (float)LuaAPI.lua_tonumber(L, 2);
                    float _degrees = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    gen_to_be_invoked.TurnToAngle( _targetAngle, _degrees );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TurnToDir(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _direction;translator.Get(L, 2, out _direction);
                    float _speed = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    gen_to_be_invoked.TurnToDir( _direction, _speed );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TurnToDirSoft(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _direction;translator.Get(L, 2, out _direction);
                    float _speed = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    gen_to_be_invoked.TurnToDirSoft( _direction, _speed );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DirAgentToPnt(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _point;translator.Get(L, 2, out _point);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.DirAgentToPnt( _point );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DirMine(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.DirMine(  );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DirStayInDisc(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _radius = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.DirStayInDisc( _radius );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Displacement(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.Displacement(  );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DistAgentToPnt(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _point;translator.Get(L, 2, out _point);
                    
                        float gen_ret = gen_to_be_invoked.DistAgentToPnt( _point );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DistAgentToPntXZ(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector2 _point;translator.Get(L, 2, out _point);
                    
                        float gen_ret = gen_to_be_invoked.DistAgentToPntXZ( _point );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DistTravelled(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        float gen_ret = gen_to_be_invoked.DistTravelled(  );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsActive(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        bool gen_ret = gen_to_be_invoked.IsActive(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPos(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.GetPos(  );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAngles(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.GetAngles(  );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TextMeshComponent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.TextMeshComponent);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaDomain(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaDomain);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_State(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.State);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StateOld(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.StateOld);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PositionOld(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.PositionOld);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EulerAnglesOld(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.EulerAnglesOld);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TurnToMoveDir(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.TurnToMoveDir);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ColorState(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.ColorState);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaDomain(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaDomain = (LuaScripting.LuaDomain)translator.GetObject(L, 2, typeof(LuaScripting.LuaDomain));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_State(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.State = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_StateOld(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.StateOld = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PositionOld(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.PositionOld = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EulerAnglesOld(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.EulerAnglesOld = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TurnToMoveDir(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.TurnToMoveDir = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ColorState(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaGameObject gen_to_be_invoked = (LuaScripting.LuaGameObject)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ColorState = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
