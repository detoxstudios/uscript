//uScript Generated Code - Build 0.9.2439
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class SquibEffect_GrenadeLogic : uScriptLogic
{

   #pragma warning disable 414
   GameObject parentGameObject = null;
   uScript_GUI thisScriptsOnGuiListener = null; 
   bool m_RegisteredForEvents = false;
   delegate void ContinueExecution();
   ContinueExecution m_ContinueExecution;
   bool m_Breakpoint = false;
   const int MaxRelayCallCount = 1000;
   int relayCallCount = 0;
   
   //externally exposed events
   
   //external parameters
   
   //local nodes
   System.Single local_2_System_Single = (float) 4;
   
   //owner nodes
   UnityEngine.GameObject owner_Connection_3 = null;
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_Destroy logic_uScriptAct_Destroy_uScriptAct_Destroy_0 = new uScriptAct_Destroy( );
   UnityEngine.GameObject[] logic_uScriptAct_Destroy_Target_0 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_Destroy_DelayTime_0 = (float) 0;
   bool logic_uScriptAct_Destroy_Out_0 = true;
   bool logic_uScriptAct_Destroy_ObjectsDestroyed_0 = true;
   bool logic_uScriptAct_Destroy_WaitOneTick_0 = false;
   
   //event nodes
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      if ( null == owner_Connection_3 || false == m_RegisteredForEvents )
      {
         owner_Connection_3 = parentGameObject;
         if ( null != owner_Connection_3 )
         {
            {
               uScript_Global component = owner_Connection_3.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = owner_Connection_3.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_1;
               }
            }
         }
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
      //reset event listeners if needed
      //this isn't a variable node so it should only be called once per enabling of the script
      //if it's called twice there would be a double event registration (which is an error)
      if ( false == m_RegisteredForEvents )
      {
         if ( null != owner_Connection_3 )
         {
            {
               uScript_Global component = owner_Connection_3.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = owner_Connection_3.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_1;
               }
            }
         }
      }
   }
   
   void SyncEventListeners( )
   {
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != owner_Connection_3 )
      {
         {
            uScript_Global component = owner_Connection_3.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_1;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_Destroy_uScriptAct_Destroy_0.SetParent(g);
   }
   public void Awake()
   {
      
   }
   
   public void Start()
   {
      SyncUnityHooks( );
      m_RegisteredForEvents = true;
      
   }
   
   public void OnEnable()
   {
      RegisterForUnityHooks( );
      m_RegisteredForEvents = true;
   }
   
   public void OnDisable()
   {
      UnregisterEventListeners( );
      m_RegisteredForEvents = false;
   }
   
   public void Update()
   {
      //reset each Update, and increments each method call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      if ( null != m_ContinueExecution )
      {
         ContinueExecution continueEx = m_ContinueExecution;
         m_ContinueExecution = null;
         m_Breakpoint = false;
         continueEx( );
         return;
      }
      UpdateEditorValues( );
      
      //other scripts might have added GameObjects with event scripts
      //so we need to verify all our event listeners are registered
      SyncEventListeners( );
      
      if (true == logic_uScriptAct_Destroy_WaitOneTick_0)
      {
         Relay_WaitOneTick_0();
      }
   }
   
   public void OnDestroy()
   {
   }
   
   void Instance_uScriptStart_1(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_1( );
   }
   
   void Relay_In_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("25166e9c-a1aa-4230-9e5d-86e52dbecd46", "Destroy", Relay_In_0)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               properties.Add((UnityEngine.GameObject)owner_Connection_3);
               logic_uScriptAct_Destroy_Target_0 = properties.ToArray();
            }
            {
               logic_uScriptAct_Destroy_DelayTime_0 = local_2_System_Single;
               
            }
         }
         logic_uScriptAct_Destroy_uScriptAct_Destroy_0.In(logic_uScriptAct_Destroy_Target_0, logic_uScriptAct_Destroy_DelayTime_0);
         logic_uScriptAct_Destroy_WaitOneTick_0 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_GrenadeLogic.uscript at Destroy.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_WaitOneTick_0( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               properties.Add((UnityEngine.GameObject)owner_Connection_3);
               logic_uScriptAct_Destroy_Target_0 = properties.ToArray();
            }
            {
               logic_uScriptAct_Destroy_DelayTime_0 = local_2_System_Single;
               
            }
         }
         logic_uScriptAct_Destroy_WaitOneTick_0 = logic_uScriptAct_Destroy_uScriptAct_Destroy_0.WaitOneTick();
         if ( true == logic_uScriptAct_Destroy_WaitOneTick_0 )
         {
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_GrenadeLogic.uscript at Destroy.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_uScriptStart_1()
   {
      if (true == CheckDebugBreak("7a66b730-9183-4691-870c-140925cb05b1", "uScript Events", Relay_uScriptStart_1)) return; 
      Relay_In_0();
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_GrenadeLogic.uscript:2", local_2_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a6f36cc6-8a96-4752-b3d7-06911a0b17f4", local_2_System_Single);
   }
   bool CheckDebugBreak(string guid, string name, ContinueExecution method)
   {
      if (true == m_Breakpoint) return true;
      
      if (true == uScript_MasterComponent.LatestMasterComponent.HasBreakpoint(guid))
      {
         if (uScript_MasterComponent.LatestMasterComponent.CurrentBreakpoint == guid)
         {
            uScript_MasterComponent.LatestMasterComponent.CurrentBreakpoint = "";
         }
         else
         {
            uScript_MasterComponent.LatestMasterComponent.CurrentBreakpoint = guid;
            UpdateEditorValues( );
            UnityEngine.Debug.Log("uScript BREAK Node:" + name + " ((Time: " + Time.time + "");
            UnityEngine.Debug.Break();
            #if (!UNITY_FLASH)
            m_ContinueExecution = new ContinueExecution(method);
            #endif
            m_Breakpoint = true;
            return true;
         }
      }
      return false;
   }
}
