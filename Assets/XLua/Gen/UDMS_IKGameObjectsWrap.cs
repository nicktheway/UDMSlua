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
    public class UDMSIKGameObjectsWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UDMS.IKGameObjects);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 11, 11);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Hips", _g_get_Hips);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Spine", _g_get_Spine);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Head", _g_get_Head);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LeftLeg", _g_get_LeftLeg);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "RightLeg", _g_get_RightLeg);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LeftFoot", _g_get_LeftFoot);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "RightFoot", _g_get_RightFoot);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LeftArm", _g_get_LeftArm);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "RightArm", _g_get_RightArm);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LeftHand", _g_get_LeftHand);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "RightHand", _g_get_RightHand);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Hips", _s_set_Hips);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Spine", _s_set_Spine);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Head", _s_set_Head);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LeftLeg", _s_set_LeftLeg);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "RightLeg", _s_set_RightLeg);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LeftFoot", _s_set_LeftFoot);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "RightFoot", _s_set_RightFoot);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LeftArm", _s_set_LeftArm);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "RightArm", _s_set_RightArm);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LeftHand", _s_set_LeftHand);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "RightHand", _s_set_RightHand);
            
			
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
					
					UDMS.IKGameObjects gen_ret = new UDMS.IKGameObjects();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UDMS.IKGameObjects constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Hips(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Hips);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Spine(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Spine);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Head(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Head);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LeftLeg(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LeftLeg);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RightLeg(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.RightLeg);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LeftFoot(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LeftFoot);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RightFoot(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.RightFoot);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LeftArm(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LeftArm);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RightArm(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.RightArm);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LeftHand(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LeftHand);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RightHand(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.RightHand);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Hips(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Hips = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Spine(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Spine = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Head(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Head = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LeftLeg(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LeftLeg = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RightLeg(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.RightLeg = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LeftFoot(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LeftFoot = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RightFoot(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.RightFoot = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LeftArm(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LeftArm = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RightArm(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.RightArm = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LeftHand(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LeftHand = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_RightHand(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UDMS.IKGameObjects gen_to_be_invoked = (UDMS.IKGameObjects)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.RightHand = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
