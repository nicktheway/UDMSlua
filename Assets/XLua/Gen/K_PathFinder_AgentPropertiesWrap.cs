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
    public class K_PathFinderAgentPropertiesWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(K_PathFinder.AgentProperties);
			Utils.BeginObjectRegister(type, L, translator, 0, 2, 28, 28);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnEnable", _m_OnEnable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDestroy", _m_OnDestroy);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "radius", _g_get_radius);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "height", _g_get_height);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxSlope", _g_get_maxSlope);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxStepHeight", _g_get_maxStepHeight);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "voxelBleed", _g_get_voxelBleed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "voxelsPerChunk", _g_get_voxelsPerChunk);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "includedLayers", _g_get_includedLayers);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ignoredTags", _g_get_ignoredTags);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "checkHierarchyTag", _g_get_checkHierarchyTag);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "doNavMesh", _g_get_doNavMesh);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "canJump", _g_get_canJump);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "JumpDown", _g_get_JumpDown);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "JumpUp", _g_get_JumpUp);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "canCrouch", _g_get_canCrouch);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "crouchHeight", _g_get_crouchHeight);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "canCover", _g_get_canCover);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "canHalfCover", _g_get_canHalfCover);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "fullCover", _g_get_fullCover);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "halfCover", _g_get_halfCover);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "coverExtraSamples", _g_get_coverExtraSamples);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "samplePoints", _g_get_samplePoints);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "samplePointsDencity", _g_get_samplePointsDencity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "walkMod", _g_get_walkMod);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "crouchMod", _g_get_crouchMod);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "jumpUpMod", _g_get_jumpUpMod);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "jumpDownMod", _g_get_jumpDownMod);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "offsetMultiplier", _g_get_offsetMultiplier);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "internal_flagList", _g_get_internal_flagList);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "radius", _s_set_radius);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "height", _s_set_height);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxSlope", _s_set_maxSlope);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxStepHeight", _s_set_maxStepHeight);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "voxelBleed", _s_set_voxelBleed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "voxelsPerChunk", _s_set_voxelsPerChunk);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "includedLayers", _s_set_includedLayers);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ignoredTags", _s_set_ignoredTags);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "checkHierarchyTag", _s_set_checkHierarchyTag);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "doNavMesh", _s_set_doNavMesh);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "canJump", _s_set_canJump);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "JumpDown", _s_set_JumpDown);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "JumpUp", _s_set_JumpUp);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "canCrouch", _s_set_canCrouch);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "crouchHeight", _s_set_crouchHeight);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "canCover", _s_set_canCover);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "canHalfCover", _s_set_canHalfCover);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "fullCover", _s_set_fullCover);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "halfCover", _s_set_halfCover);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "coverExtraSamples", _s_set_coverExtraSamples);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "samplePoints", _s_set_samplePoints);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "samplePointsDencity", _s_set_samplePointsDencity);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "walkMod", _s_set_walkMod);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "crouchMod", _s_set_crouchMod);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "jumpUpMod", _s_set_jumpUpMod);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "jumpDownMod", _s_set_jumpDownMod);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "offsetMultiplier", _s_set_offsetMultiplier);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "internal_flagList", _s_set_internal_flagList);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Create", _m_Create_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					K_PathFinder.AgentProperties gen_ret = new K_PathFinder.AgentProperties();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to K_PathFinder.AgentProperties constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Create_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    K_PathFinder.AgentProperties.Create(  );
                    
                    
                    
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
            
            
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnEnable(  );
                    
                    
                    
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
            
            
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnDestroy(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_radius(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.radius);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_height(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.height);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxSlope(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.maxSlope);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxStepHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.maxStepHeight);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_voxelBleed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.voxelBleed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_voxelsPerChunk(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.voxelsPerChunk);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_includedLayers(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.includedLayers);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ignoredTags(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.ignoredTags);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_checkHierarchyTag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.checkHierarchyTag);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_doNavMesh(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.doNavMesh);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_canJump(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.canJump);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_JumpDown(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.JumpDown);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_JumpUp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.JumpUp);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_canCrouch(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.canCrouch);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_crouchHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.crouchHeight);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_canCover(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.canCover);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_canHalfCover(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.canHalfCover);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fullCover(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.fullCover);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_halfCover(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.halfCover);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_coverExtraSamples(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.coverExtraSamples);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_samplePoints(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.samplePoints);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_samplePointsDencity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.samplePointsDencity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_walkMod(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.walkMod);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_crouchMod(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.crouchMod);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_jumpUpMod(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.jumpUpMod);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_jumpDownMod(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.jumpDownMod);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_offsetMultiplier(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.offsetMultiplier);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_internal_flagList(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.internal_flagList);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_radius(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.radius = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_height(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.height = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxSlope(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxSlope = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxStepHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxStepHeight = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_voxelBleed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.voxelBleed = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_voxelsPerChunk(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.voxelsPerChunk = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_includedLayers(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                UnityEngine.LayerMask gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.includedLayers = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ignoredTags(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ignoredTags = (System.Collections.Generic.List<string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<string>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_checkHierarchyTag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.checkHierarchyTag = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_doNavMesh(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.doNavMesh = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_canJump(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.canJump = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_JumpDown(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.JumpDown = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_JumpUp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.JumpUp = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_canCrouch(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.canCrouch = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_crouchHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.crouchHeight = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_canCover(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.canCover = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_canHalfCover(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.canHalfCover = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_fullCover(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.fullCover = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_halfCover(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.halfCover = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_coverExtraSamples(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.coverExtraSamples = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_samplePoints(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.samplePoints = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_samplePointsDencity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.samplePointsDencity = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_walkMod(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.walkMod = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_crouchMod(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.crouchMod = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_jumpUpMod(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.jumpUpMod = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_jumpDownMod(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.jumpDownMod = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_offsetMultiplier(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.offsetMultiplier = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_internal_flagList(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                K_PathFinder.AgentProperties gen_to_be_invoked = (K_PathFinder.AgentProperties)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.internal_flagList = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
