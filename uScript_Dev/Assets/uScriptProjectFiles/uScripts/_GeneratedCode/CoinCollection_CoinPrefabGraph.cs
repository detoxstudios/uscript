//uScript Generated Code - Build 0.9.2439
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class CoinCollection_CoinPrefabGraph : uScriptLogic
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
   System.String local_13_System_String = "";
   System.String local_15_System_String = "Gold";
   System.String local_18_System_String = "GiveCoins";
   UnityEngine.GameObject local_7_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_7_UnityEngine_GameObject_previous = null;
   System.String local_8_System_String = "";
   System.String local_9_System_String = "PlayerBall";
   
   //owner nodes
   UnityEngine.GameObject owner_Connection_2 = null;
   UnityEngine.GameObject owner_Connection_3 = null;
   UnityEngine.GameObject owner_Connection_5 = null;
   UnityEngine.GameObject owner_Connection_12 = null;
   UnityEngine.GameObject owner_Connection_20 = null;
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_Rotate logic_uScriptAct_Rotate_uScriptAct_Rotate_1 = new uScriptAct_Rotate( );
   UnityEngine.GameObject[] logic_uScriptAct_Rotate_Target_1 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_Rotate_Degrees_1 = (float) 360;
   System.String logic_uScriptAct_Rotate_Axis_1 = "X";
   System.Single logic_uScriptAct_Rotate_Seconds_1 = (float) 2;
   System.Boolean logic_uScriptAct_Rotate_Loop_1 = (bool) true;
   bool logic_uScriptAct_Rotate_Out_1 = true;
   //pointer to script instanced logic node
   uScriptAct_GetGameObjectName logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_6 = new uScriptAct_GetGameObjectName( );
   UnityEngine.GameObject logic_uScriptAct_GetGameObjectName_gameObject_6 = null;
   System.String logic_uScriptAct_GetGameObjectName_name_6;
   bool logic_uScriptAct_GetGameObjectName_Out_6 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_10 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_10 = "";
   System.String logic_uScriptCon_CompareString_B_10 = "";
   bool logic_uScriptCon_CompareString_Same_10 = true;
   bool logic_uScriptCon_CompareString_Different_10 = true;
   //pointer to script instanced logic node
   uScriptAct_GetGameObjectName logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_11 = new uScriptAct_GetGameObjectName( );
   UnityEngine.GameObject logic_uScriptAct_GetGameObjectName_gameObject_11 = null;
   System.String logic_uScriptAct_GetGameObjectName_name_11;
   bool logic_uScriptAct_GetGameObjectName_Out_11 = true;
   //pointer to script instanced logic node
   uScriptCon_StringContains logic_uScriptCon_StringContains_uScriptCon_StringContains_14 = new uScriptCon_StringContains( );
   System.String logic_uScriptCon_StringContains_Target_14 = "";
   System.String logic_uScriptCon_StringContains_Value_14 = "";
   bool logic_uScriptCon_StringContains_True_14 = true;
   bool logic_uScriptCon_StringContains_False_14 = true;
   //pointer to script instanced logic node
   uScriptAct_SendCustomEventInt logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_16 = new uScriptAct_SendCustomEventInt( );
   System.String logic_uScriptAct_SendCustomEventInt_EventName_16 = "";
   System.Int32 logic_uScriptAct_SendCustomEventInt_EventValue_16 = (int) 0;
   uScriptCustomEvent.SendGroup logic_uScriptAct_SendCustomEventInt_sendGroup_16 = uScriptCustomEvent.SendGroup.All;
   UnityEngine.GameObject logic_uScriptAct_SendCustomEventInt_EventSender_16 = null;
   bool logic_uScriptAct_SendCustomEventInt_Out_16 = true;
   //pointer to script instanced logic node
   uScriptAct_SendCustomEventInt logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_17 = new uScriptAct_SendCustomEventInt( );
   System.String logic_uScriptAct_SendCustomEventInt_EventName_17 = "";
   System.Int32 logic_uScriptAct_SendCustomEventInt_EventValue_17 = (int) 0;
   uScriptCustomEvent.SendGroup logic_uScriptAct_SendCustomEventInt_sendGroup_17 = uScriptCustomEvent.SendGroup.All;
   UnityEngine.GameObject logic_uScriptAct_SendCustomEventInt_EventSender_17 = null;
   bool logic_uScriptAct_SendCustomEventInt_Out_17 = true;
   //pointer to script instanced logic node
   uScriptAct_Destroy logic_uScriptAct_Destroy_uScriptAct_Destroy_19 = new uScriptAct_Destroy( );
   UnityEngine.GameObject[] logic_uScriptAct_Destroy_Target_19 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_Destroy_DelayTime_19 = (float) 0.1;
   bool logic_uScriptAct_Destroy_Out_19 = true;
   bool logic_uScriptAct_Destroy_ObjectsDestroyed_19 = true;
   bool logic_uScriptAct_Destroy_WaitOneTick_19 = false;
   
   //event nodes
   System.Int32 event_UnityEngine_GameObject_TimesToTrigger_4 = (int) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_4 = null;
   
   //property nodes
   System.Int32 property_CoinPointsGold_Detox_ScriptEditor_Parameter_CoinPointsGold_21 = (int) 0;
   UnityEngine.GameObject property_CoinPointsGold_Detox_ScriptEditor_Parameter_Instance_21 = null;
   System.Int32 property_CoinPointsSilver_Detox_ScriptEditor_Parameter_CoinPointsSilver_22 = (int) 0;
   UnityEngine.GameObject property_CoinPointsSilver_Detox_ScriptEditor_Parameter_Instance_22 = null;
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   System.Int32 property_CoinPointsGold_Detox_ScriptEditor_Parameter_CoinPointsGold_21_Get_Refresh( )
   {
      CoinCollection_GameplayGlobals_Component component = property_CoinPointsGold_Detox_ScriptEditor_Parameter_Instance_21.GetComponent<CoinCollection_GameplayGlobals_Component>();
      if ( null != component )
      {
         return component.CoinPointsGold;
      }
      else
      {
         return (int) 0;
      }
   }
   
   void property_CoinPointsGold_Detox_ScriptEditor_Parameter_CoinPointsGold_21_Set_Refresh( )
   {
      CoinCollection_GameplayGlobals_Component component = property_CoinPointsGold_Detox_ScriptEditor_Parameter_Instance_21.GetComponent<CoinCollection_GameplayGlobals_Component>();
      if ( null != component )
      {
         component.CoinPointsGold = property_CoinPointsGold_Detox_ScriptEditor_Parameter_CoinPointsGold_21;
      }
   }
   
   System.Int32 property_CoinPointsSilver_Detox_ScriptEditor_Parameter_CoinPointsSilver_22_Get_Refresh( )
   {
      CoinCollection_GameplayGlobals_Component component = property_CoinPointsSilver_Detox_ScriptEditor_Parameter_Instance_22.GetComponent<CoinCollection_GameplayGlobals_Component>();
      if ( null != component )
      {
         return component.CoinPointsSilver;
      }
      else
      {
         return (int) 0;
      }
   }
   
   void property_CoinPointsSilver_Detox_ScriptEditor_Parameter_CoinPointsSilver_22_Set_Refresh( )
   {
      CoinCollection_GameplayGlobals_Component component = property_CoinPointsSilver_Detox_ScriptEditor_Parameter_Instance_22.GetComponent<CoinCollection_GameplayGlobals_Component>();
      if ( null != component )
      {
         component.CoinPointsSilver = property_CoinPointsSilver_Detox_ScriptEditor_Parameter_CoinPointsSilver_22;
      }
   }
   
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      if ( null == property_CoinPointsGold_Detox_ScriptEditor_Parameter_Instance_21 || false == m_RegisteredForEvents )
      {
         property_CoinPointsGold_Detox_ScriptEditor_Parameter_Instance_21 = uScript_MasterComponent.LatestMaster;
      }
      if ( null == property_CoinPointsSilver_Detox_ScriptEditor_Parameter_Instance_22 || false == m_RegisteredForEvents )
      {
         property_CoinPointsSilver_Detox_ScriptEditor_Parameter_Instance_22 = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_7_UnityEngine_GameObject_previous != local_7_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_7_UnityEngine_GameObject_previous = local_7_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == owner_Connection_2 || false == m_RegisteredForEvents )
      {
         owner_Connection_2 = parentGameObject;
         if ( null != owner_Connection_2 )
         {
            {
               uScript_Global component = owner_Connection_2.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = owner_Connection_2.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_0;
               }
            }
         }
      }
      if ( null == owner_Connection_3 || false == m_RegisteredForEvents )
      {
         owner_Connection_3 = parentGameObject;
      }
      if ( null == owner_Connection_5 || false == m_RegisteredForEvents )
      {
         owner_Connection_5 = parentGameObject;
         if ( null != owner_Connection_5 )
         {
            {
               uScript_Triggers component = owner_Connection_5.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = owner_Connection_5.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_4;
               }
            }
            {
               uScript_Triggers component = owner_Connection_5.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = owner_Connection_5.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_4;
                  component.OnExitTrigger += Instance_OnExitTrigger_4;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_4;
               }
            }
         }
      }
      if ( null == owner_Connection_12 || false == m_RegisteredForEvents )
      {
         owner_Connection_12 = parentGameObject;
      }
      if ( null == owner_Connection_20 || false == m_RegisteredForEvents )
      {
         owner_Connection_20 = parentGameObject;
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_7_UnityEngine_GameObject_previous != local_7_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_7_UnityEngine_GameObject_previous = local_7_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //reset event listeners if needed
      //this isn't a variable node so it should only be called once per enabling of the script
      //if it's called twice there would be a double event registration (which is an error)
      if ( false == m_RegisteredForEvents )
      {
         if ( null != owner_Connection_2 )
         {
            {
               uScript_Global component = owner_Connection_2.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = owner_Connection_2.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_0;
               }
            }
         }
      }
      //reset event listeners if needed
      //this isn't a variable node so it should only be called once per enabling of the script
      //if it's called twice there would be a double event registration (which is an error)
      if ( false == m_RegisteredForEvents )
      {
         if ( null != owner_Connection_5 )
         {
            {
               uScript_Triggers component = owner_Connection_5.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = owner_Connection_5.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_4;
               }
            }
            {
               uScript_Triggers component = owner_Connection_5.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = owner_Connection_5.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_4;
                  component.OnExitTrigger += Instance_OnExitTrigger_4;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_4;
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
      if ( null != owner_Connection_2 )
      {
         {
            uScript_Global component = owner_Connection_2.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_0;
            }
         }
      }
      if ( null != owner_Connection_5 )
      {
         {
            uScript_Triggers component = owner_Connection_5.GetComponent<uScript_Triggers>();
            if ( null != component )
            {
               component.OnEnterTrigger -= Instance_OnEnterTrigger_4;
               component.OnExitTrigger -= Instance_OnExitTrigger_4;
               component.WhileInsideTrigger -= Instance_WhileInsideTrigger_4;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_Rotate_uScriptAct_Rotate_1.SetParent(g);
      logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_6.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_10.SetParent(g);
      logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_11.SetParent(g);
      logic_uScriptCon_StringContains_uScriptCon_StringContains_14.SetParent(g);
      logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_16.SetParent(g);
      logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_17.SetParent(g);
      logic_uScriptAct_Destroy_uScriptAct_Destroy_19.SetParent(g);
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
      
      logic_uScriptAct_Rotate_uScriptAct_Rotate_1.Update( );
      if (true == logic_uScriptAct_Destroy_WaitOneTick_19)
      {
         Relay_WaitOneTick_19();
      }
   }
   
   public void OnDestroy()
   {
   }
   
   void Instance_uScriptStart_0(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_0( );
   }
   
   void Instance_OnEnterTrigger_4(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_4 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_4( );
   }
   
   void Instance_OnExitTrigger_4(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_4 = e.GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_4( );
   }
   
   void Instance_WhileInsideTrigger_4(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_4 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_4( );
   }
   
   void Relay_uScriptStart_0()
   {
      if (true == CheckDebugBreak("66ab94f4-4e30-4e33-a778-d9ddfeaf907e", "uScript Events", Relay_uScriptStart_0)) return; 
      Relay_In_1();
   }
   
   void Relay_In_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0cc7ead0-8295-4129-b4b2-be3bb5292918", "Rotate", Relay_In_1)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               properties.Add((UnityEngine.GameObject)owner_Connection_3);
               logic_uScriptAct_Rotate_Target_1 = properties.ToArray();
            }
            {
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_Rotate_uScriptAct_Rotate_1.In(logic_uScriptAct_Rotate_Target_1, logic_uScriptAct_Rotate_Degrees_1, logic_uScriptAct_Rotate_Axis_1, logic_uScriptAct_Rotate_Seconds_1, logic_uScriptAct_Rotate_Loop_1);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_CoinPrefabGraph.uscript at Rotate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnEnterTrigger_4()
   {
      if (true == CheckDebugBreak("579c79e0-e520-4dff-964c-fa13c99f7072", "Trigger Events", Relay_OnEnterTrigger_4)) return; 
      local_7_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_4;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_7_UnityEngine_GameObject_previous != local_7_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_7_UnityEngine_GameObject_previous = local_7_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
      Relay_In_6();
   }
   
   void Relay_OnExitTrigger_4()
   {
      if (true == CheckDebugBreak("579c79e0-e520-4dff-964c-fa13c99f7072", "Trigger Events", Relay_OnExitTrigger_4)) return; 
      local_7_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_4;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_7_UnityEngine_GameObject_previous != local_7_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_7_UnityEngine_GameObject_previous = local_7_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
   }
   
   void Relay_WhileInsideTrigger_4()
   {
      if (true == CheckDebugBreak("579c79e0-e520-4dff-964c-fa13c99f7072", "Trigger Events", Relay_WhileInsideTrigger_4)) return; 
      local_7_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_4;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_7_UnityEngine_GameObject_previous != local_7_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_7_UnityEngine_GameObject_previous = local_7_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
   }
   
   void Relay_In_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7a31028c-b50c-432e-b0c7-c36dc9e87560", "Get GameObject Name", Relay_In_6)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_7_UnityEngine_GameObject_previous != local_7_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_7_UnityEngine_GameObject_previous = local_7_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_GetGameObjectName_gameObject_6 = local_7_UnityEngine_GameObject;
               
            }
            {
            }
         }
         logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_6.In(logic_uScriptAct_GetGameObjectName_gameObject_6, out logic_uScriptAct_GetGameObjectName_name_6);
         local_8_System_String = logic_uScriptAct_GetGameObjectName_name_6;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_6.Out;
         
         if ( test_0 == true )
         {
            Relay_In_10();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_CoinPrefabGraph.uscript at Get GameObject Name.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7088dc95-daf3-4597-9e33-b8aee96ddd9c", "Compare String", Relay_In_10)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_10 = local_8_System_String;
               
            }
            {
               logic_uScriptCon_CompareString_B_10 = local_9_System_String;
               
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_10.In(logic_uScriptCon_CompareString_A_10, logic_uScriptCon_CompareString_B_10);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_10.Same;
         
         if ( test_0 == true )
         {
            Relay_In_11();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_CoinPrefabGraph.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_11()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2f35ac62-52d6-40f1-96b4-fd67eda16e30", "Get GameObject Name", Relay_In_11)) return; 
         {
            {
               logic_uScriptAct_GetGameObjectName_gameObject_11 = owner_Connection_12;
               
            }
            {
            }
         }
         logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_11.In(logic_uScriptAct_GetGameObjectName_gameObject_11, out logic_uScriptAct_GetGameObjectName_name_11);
         local_13_System_String = logic_uScriptAct_GetGameObjectName_name_11;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_11.Out;
         
         if ( test_0 == true )
         {
            Relay_In_14();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_CoinPrefabGraph.uscript at Get GameObject Name.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_14()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("46a64af8-1aa5-479b-abfe-f03c165d0bc2", "String Contains", Relay_In_14)) return; 
         {
            {
               logic_uScriptCon_StringContains_Target_14 = local_13_System_String;
               
            }
            {
               logic_uScriptCon_StringContains_Value_14 = local_15_System_String;
               
            }
         }
         logic_uScriptCon_StringContains_uScriptCon_StringContains_14.In(logic_uScriptCon_StringContains_Target_14, logic_uScriptCon_StringContains_Value_14);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_StringContains_uScriptCon_StringContains_14.True;
         bool test_1 = logic_uScriptCon_StringContains_uScriptCon_StringContains_14.False;
         
         if ( test_0 == true )
         {
            Relay_SendCustomEvent_16();
         }
         if ( test_1 == true )
         {
            Relay_SendCustomEvent_17();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_CoinPrefabGraph.uscript at String Contains.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_SendCustomEvent_16()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("04bb0df0-6bab-4bd9-85f0-e249868a19ce", "Send Custom Event (Int)", Relay_SendCustomEvent_16)) return; 
         {
            {
               logic_uScriptAct_SendCustomEventInt_EventName_16 = local_18_System_String;
               
            }
            {
               logic_uScriptAct_SendCustomEventInt_EventValue_16 = property_CoinPointsGold_Detox_ScriptEditor_Parameter_CoinPointsGold_21_Get_Refresh( );
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_16.SendCustomEvent(logic_uScriptAct_SendCustomEventInt_EventName_16, logic_uScriptAct_SendCustomEventInt_EventValue_16, logic_uScriptAct_SendCustomEventInt_sendGroup_16, logic_uScriptAct_SendCustomEventInt_EventSender_16);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_16.Out;
         
         if ( test_0 == true )
         {
            Relay_In_19();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_CoinPrefabGraph.uscript at Send Custom Event (Int).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_SendCustomEvent_17()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("19e21fd6-abb6-44b3-8c24-fd37f7bfa592", "Send Custom Event (Int)", Relay_SendCustomEvent_17)) return; 
         {
            {
               logic_uScriptAct_SendCustomEventInt_EventName_17 = local_18_System_String;
               
            }
            {
               logic_uScriptAct_SendCustomEventInt_EventValue_17 = property_CoinPointsSilver_Detox_ScriptEditor_Parameter_CoinPointsSilver_22_Get_Refresh( );
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_17.SendCustomEvent(logic_uScriptAct_SendCustomEventInt_EventName_17, logic_uScriptAct_SendCustomEventInt_EventValue_17, logic_uScriptAct_SendCustomEventInt_sendGroup_17, logic_uScriptAct_SendCustomEventInt_EventSender_17);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_17.Out;
         
         if ( test_0 == true )
         {
            Relay_In_19();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_CoinPrefabGraph.uscript at Send Custom Event (Int).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_19()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0d471649-055a-49d9-9f2e-897b9453ca70", "Destroy", Relay_In_19)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               properties.Add((UnityEngine.GameObject)owner_Connection_20);
               logic_uScriptAct_Destroy_Target_19 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Destroy_uScriptAct_Destroy_19.In(logic_uScriptAct_Destroy_Target_19, logic_uScriptAct_Destroy_DelayTime_19);
         logic_uScriptAct_Destroy_WaitOneTick_19 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_CoinPrefabGraph.uscript at Destroy.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_WaitOneTick_19( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               properties.Add((UnityEngine.GameObject)owner_Connection_20);
               logic_uScriptAct_Destroy_Target_19 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Destroy_WaitOneTick_19 = logic_uScriptAct_Destroy_uScriptAct_Destroy_19.WaitOneTick();
         if ( true == logic_uScriptAct_Destroy_WaitOneTick_19 )
         {
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_CoinPrefabGraph.uscript at Destroy.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_CoinPrefabGraph.uscript:7", local_7_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d52708c7-1c65-43bd-9334-95dc9d4c5654", local_7_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_CoinPrefabGraph.uscript:8", local_8_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "6582e603-9837-49ce-b198-1cdebe686660", local_8_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_CoinPrefabGraph.uscript:9", local_9_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "fbbe0fdc-91ab-4b6c-a215-2238c0e022b4", local_9_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_CoinPrefabGraph.uscript:13", local_13_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b07860fd-cae8-410e-ab09-54f8312f6fb9", local_13_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_CoinPrefabGraph.uscript:15", local_15_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "4f047d1f-956f-4dc8-8dac-8e61efa83007", local_15_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_CoinPrefabGraph.uscript:18", local_18_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "33b537dc-f1a5-4f74-81e8-dbf6e166c752", local_18_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "5f1334f7-2d37-4642-b772-cb3a1df76145", property_CoinPointsGold_Detox_ScriptEditor_Parameter_CoinPointsGold_21);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "3817eb6b-843a-4ff8-86c0-ba472924523d", property_CoinPointsSilver_Detox_ScriptEditor_Parameter_CoinPointsSilver_22);
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
