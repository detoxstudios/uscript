//uScript Generated Code - Build 0.9.2439
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("Nested Node Test", "This is a test nested graph. It doesn't do anything special.")]
public class CodeGenTest_Nested : uScriptLogic
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
   [FriendlyName("Node Is Done")]
   public event uScriptEventHandler Node_Is_Done;
   
   //external parameters
   System.Object external_4 = "";
   System.Object[] external_2 = new System.Object[] {};
   System.Object external_5 = "";
   
   //local nodes
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_0 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_0 = "";
   System.Object[] logic_uScriptAct_Log_Target_0 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_0 = "";
   bool logic_uScriptAct_Log_Out_0 = true;
   
   //event nodes
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   public delegate void uScriptEventHandler(object sender, LogicEventArgs args);
   
   public class LogicEventArgs : System.EventArgs
   {
   }
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
   }
   
   void SyncEventListeners( )
   {
   }
   
   void UnregisterEventListeners( )
   {
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_Log_uScriptAct_Log_0.SetParent(g);
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
      
   }
   
   public void OnDestroy()
   {
   }
   
   [FriendlyName("In", "The In socket")]
   public void In( [FriendlyName("Socket 1", "Hooks up to prefix")] System.Object Socket_1, [FriendlyName("Int Name-Test", "The original variable socket")] System.Object[] Int_Name_Test, [FriendlyName("Socket 3", "The final socket to rule them all!")] System.Object Socket_3 )
   {
      
      external_4 = Socket_1;
      external_2 = Int_Name_Test;
      external_5 = Socket_3;
      Relay_In_0( );
   }
   
   void Relay_In_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f2b843e0-e44e-4032-82f3-328a64317d01", "Log", Relay_In_0)) return; 
         {
            {
               logic_uScriptAct_Log_Prefix_0 = external_4;
               
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.AddRange(external_2);
               logic_uScriptAct_Log_Target_0 = properties.ToArray();
            }
            {
               logic_uScriptAct_Log_Postfix_0 = external_5;
               
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_0.In(logic_uScriptAct_Log_Prefix_0, logic_uScriptAct_Log_Target_0, logic_uScriptAct_Log_Postfix_0);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Log_uScriptAct_Log_0.Out;
         
         if ( test_0 == true )
         {
            Relay_Connection_3();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CodeGenTest_Nested.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Connection_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("cdeecf4f-d82d-4659-9fb1-1a283daadd57", "", Relay_Connection_1)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CodeGenTest_Nested.uscript at In.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Connection_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("429c5a6f-de91-49e1-997e-b9ea74572407", "", Relay_Connection_2)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CodeGenTest_Nested.uscript at Int Name-Test.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Connection_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f3f44716-0baa-4f5b-8bbe-e2511623866a", "", Relay_Connection_3)) return; 
         if ( Node_Is_Done != null )
         {
            LogicEventArgs eventArgs = new LogicEventArgs( );
            Node_Is_Done( this, eventArgs );
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CodeGenTest_Nested.uscript at Node Is Done.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Connection_4()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f6c7683f-e353-4178-84e6-07327ebd63e4", "", Relay_Connection_4)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CodeGenTest_Nested.uscript at Socket 1.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Connection_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("89d6993c-759a-4931-91da-6c97b6caed07", "", Relay_Connection_5)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CodeGenTest_Nested.uscript at Socket 3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
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
