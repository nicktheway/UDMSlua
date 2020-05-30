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
    public class LuaScriptingLuaIndividualDomainWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(LuaScripting.LuaIndividualDomain);
			Utils.BeginObjectRegister(type, L, translator, 0, 6, 11, 11);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LoadScriptSymbols", _m_LoadScriptSymbols);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UnloadScriptSymbols", _m_UnloadScriptSymbols);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Select", _m_Select);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Dispose", _m_Dispose);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BeforeUpdateActions", _m_BeforeUpdateActions);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AfterLateUpdateActions", _m_AfterLateUpdateActions);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaIndividualObject", _g_get_LuaIndividualObject);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaOnEnable", _g_get_LuaOnEnable);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaOnDisable", _g_get_LuaOnDisable);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaOnAnimatorIK", _g_get_LuaOnAnimatorIK);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaOnAnimatorMove", _g_get_LuaOnAnimatorMove);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaOnCollisionEnter", _g_get_LuaOnCollisionEnter);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaOnCollisionExit", _g_get_LuaOnCollisionExit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaOnCollisionStay", _g_get_LuaOnCollisionStay);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaOnTriggerEnter", _g_get_LuaOnTriggerEnter);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaOnTriggerExit", _g_get_LuaOnTriggerExit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaOnTriggerStay", _g_get_LuaOnTriggerStay);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaIndividualObject", _s_set_LuaIndividualObject);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaOnEnable", _s_set_LuaOnEnable);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaOnDisable", _s_set_LuaOnDisable);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaOnAnimatorIK", _s_set_LuaOnAnimatorIK);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaOnAnimatorMove", _s_set_LuaOnAnimatorMove);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaOnCollisionEnter", _s_set_LuaOnCollisionEnter);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaOnCollisionExit", _s_set_LuaOnCollisionExit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaOnCollisionStay", _s_set_LuaOnCollisionStay);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaOnTriggerEnter", _s_set_LuaOnTriggerEnter);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaOnTriggerExit", _s_set_LuaOnTriggerExit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LuaOnTriggerStay", _s_set_LuaOnTriggerStay);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "NewIndividualDomain", _m_NewIndividualDomain_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "LuaScripting.LuaIndividualDomain does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NewIndividualDomain_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _scriptPath = LuaAPI.lua_tostring(L, 1);
                    LuaScripting.LuaIndividualObject _attachedObject = (LuaScripting.LuaIndividualObject)translator.GetObject(L, 2, typeof(LuaScripting.LuaIndividualObject));
                    LuaScripting.LuaRoom _domainRoom = (LuaScripting.LuaRoom)translator.GetObject(L, 3, typeof(LuaScripting.LuaRoom));
                    
                        LuaScripting.LuaIndividualDomain gen_ret = LuaScripting.LuaIndividualDomain.NewIndividualDomain( _scriptPath, _attachedObject, _domainRoom );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadScriptSymbols(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.UnloadScriptSymbols(  );
                    
                    
                    
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
            
            
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.AfterLateUpdateActions(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaIndividualObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaIndividualObject);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaOnEnable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaOnEnable);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaOnDisable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaOnDisable);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaOnAnimatorIK(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaOnAnimatorIK);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaOnAnimatorMove(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaOnAnimatorMove);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaOnCollisionEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaOnCollisionEnter);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaOnCollisionExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaOnCollisionExit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaOnCollisionStay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaOnCollisionStay);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaOnTriggerEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaOnTriggerEnter);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaOnTriggerExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaOnTriggerExit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaOnTriggerStay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaOnTriggerStay);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaIndividualObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaIndividualObject = (LuaScripting.LuaIndividualObject)translator.GetObject(L, 2, typeof(LuaScripting.LuaIndividualObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaOnEnable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaOnEnable = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaOnDisable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaOnDisable = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaOnAnimatorIK(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaOnAnimatorIK = translator.GetDelegate<LuaScripting.IntAction>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaOnAnimatorMove(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaOnAnimatorMove = translator.GetDelegate<System.Action>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaOnCollisionEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaOnCollisionEnter = translator.GetDelegate<LuaScripting.CollisionAction>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaOnCollisionExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaOnCollisionExit = translator.GetDelegate<LuaScripting.CollisionAction>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaOnCollisionStay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaOnCollisionStay = translator.GetDelegate<LuaScripting.CollisionAction>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaOnTriggerEnter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaOnTriggerEnter = translator.GetDelegate<LuaScripting.ColliderAction>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaOnTriggerExit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaOnTriggerExit = translator.GetDelegate<LuaScripting.ColliderAction>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LuaOnTriggerStay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                LuaScripting.LuaIndividualDomain gen_to_be_invoked = (LuaScripting.LuaIndividualDomain)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LuaOnTriggerStay = translator.GetDelegate<LuaScripting.ColliderAction>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
