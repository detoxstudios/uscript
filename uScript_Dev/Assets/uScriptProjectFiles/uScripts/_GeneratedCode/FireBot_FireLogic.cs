//uScript Generated Code - Build 1.0.3109
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class FireBot_FireLogic : uScriptLogic
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
   System.String local_10_System_String = "Fire";
   System.Int32 local_12_System_Int32 = (int) 10;
   System.Single local_14_System_Single = (float) 0;
   System.Single local_19_System_Single = (float) 0;
   UnityEngine.GameObject local_2_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_2_UnityEngine_GameObject_previous = null;
   System.String local_21_System_String = "Award Points";
   System.String local_28_System_String = "";
   System.String local_30_System_String = "WaterBall";
   UnityEngine.Vector3 local_7_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   System.Single local_Time_Till_Spawn_System_Single = (float) 4;
   
   //owner nodes
   UnityEngine.GameObject owner_Connection_8 = null;
   UnityEngine.GameObject owner_Connection_15 = null;
   UnityEngine.GameObject owner_Connection_18 = null;
   UnityEngine.GameObject owner_Connection_20 = null;
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_SetRandomFloat logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_0 = new uScriptAct_SetRandomFloat( );
   System.Single logic_uScriptAct_SetRandomFloat_Min_0 = (float) -3.5;
   System.Single logic_uScriptAct_SetRandomFloat_Max_0 = (float) 3.5;
   System.Single logic_uScriptAct_SetRandomFloat_TargetFloat_0;
   bool logic_uScriptAct_SetRandomFloat_Out_0 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_1 = new uScriptAct_Delay( );
   System.Single logic_uScriptAct_Delay_Duration_1 = (float) 0;
   System.Boolean logic_uScriptAct_Delay_SingleFrame_1 = (bool) false;
   bool logic_uScriptAct_Delay_Immediate_1 = true;
   bool logic_uScriptAct_Delay_AfterDelay_1 = true;
   bool logic_uScriptAct_Delay_Stopped_1 = true;
   bool logic_uScriptAct_Delay_DrivenDelay_1 = false;
   //pointer to script instanced logic node
   uScriptAct_SpawnPrefab logic_uScriptAct_SpawnPrefab_uScriptAct_SpawnPrefab_6 = new uScriptAct_SpawnPrefab( );
   System.String logic_uScriptAct_SpawnPrefab_PrefabName_6 = "";
   System.String logic_uScriptAct_SpawnPrefab_ResourcePath_6 = "";
   UnityEngine.GameObject logic_uScriptAct_SpawnPrefab_SpawnPoint_6 = default(UnityEngine.GameObject);
   System.String logic_uScriptAct_SpawnPrefab_SpawnedName_6 = "";
   UnityEngine.Vector3 logic_uScriptAct_SpawnPrefab_LocationOffset_6 = new Vector3( );
   UnityEngine.GameObject logic_uScriptAct_SpawnPrefab_SpawnedGameObject_6;
   System.Int32 logic_uScriptAct_SpawnPrefab_SpawnedInstancedID_6;
   bool logic_uScriptAct_SpawnPrefab_Immediate_6 = true;
   //pointer to script instanced logic node
   uScriptAct_SendCustomEventInt logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_9 = new uScriptAct_SendCustomEventInt( );
   System.String logic_uScriptAct_SendCustomEventInt_EventName_9 = "";
   System.Int32 logic_uScriptAct_SendCustomEventInt_EventValue_9 = (int) 0;
   uScriptCustomEvent.SendGroup logic_uScriptAct_SendCustomEventInt_sendGroup_9 = uScriptCustomEvent.SendGroup.All;
   UnityEngine.GameObject logic_uScriptAct_SendCustomEventInt_EventSender_9 = default(UnityEngine.GameObject);
   bool logic_uScriptAct_SendCustomEventInt_Out_9 = true;
   //pointer to script instanced logic node
   uScriptAct_SetComponentsVector3 logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_22 = new uScriptAct_SetComponentsVector3( );
   System.Single logic_uScriptAct_SetComponentsVector3_X_22 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsVector3_Y_22 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsVector3_Z_22 = (float) 0;
   UnityEngine.Vector3 logic_uScriptAct_SetComponentsVector3_OutputVector3_22;
   bool logic_uScriptAct_SetComponentsVector3_Out_22 = true;
   //pointer to script instanced logic node
   uScriptAct_Destroy logic_uScriptAct_Destroy_uScriptAct_Destroy_24 = new uScriptAct_Destroy( );
   UnityEngine.GameObject[] logic_uScriptAct_Destroy_Target_24 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_Destroy_DelayTime_24 = (float) 0;
   bool logic_uScriptAct_Destroy_Out_24 = true;
   bool logic_uScriptAct_Destroy_ObjectsDestroyed_24 = true;
   bool logic_uScriptAct_Destroy_WaitOneTick_24 = false;
   //pointer to script instanced logic node
   uScriptAct_SetRandomFloat logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_26 = new uScriptAct_SetRandomFloat( );
   System.Single logic_uScriptAct_SetRandomFloat_Min_26 = (float) -3.5;
   System.Single logic_uScriptAct_SetRandomFloat_Max_26 = (float) 3.5;
   System.Single logic_uScriptAct_SetRandomFloat_TargetFloat_26;
   bool logic_uScriptAct_SetRandomFloat_Out_26 = true;
   //pointer to script instanced logic node
   uScriptAct_GetGameObjectName logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_27 = new uScriptAct_GetGameObjectName( );
   UnityEngine.GameObject logic_uScriptAct_GetGameObjectName_gameObject_27 = default(UnityEngine.GameObject);
   System.String logic_uScriptAct_GetGameObjectName_name_27;
   bool logic_uScriptAct_GetGameObjectName_Out_27 = true;
   //pointer to script instanced logic node
   uScriptCon_StringContains logic_uScriptCon_StringContains_uScriptCon_StringContains_29 = new uScriptCon_StringContains( );
   System.String logic_uScriptCon_StringContains_Target_29 = "";
   System.String logic_uScriptCon_StringContains_Value_29 = "";
   bool logic_uScriptCon_StringContains_True_29 = true;
   bool logic_uScriptCon_StringContains_False_29 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_31 = default(UnityEngine.GameObject);
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_2_UnityEngine_GameObject_previous != local_2_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_2_UnityEngine_GameObject_previous = local_2_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == owner_Connection_8 || false == m_RegisteredForEvents )
      {
         owner_Connection_8 = parentGameObject;
         if ( null != owner_Connection_8 )
         {
            {
               uScript_Global component = owner_Connection_8.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = owner_Connection_8.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_3;
                  component.uScriptLateStart += Instance_uScriptLateStart_3;
               }
            }
         }
      }
      if ( null == owner_Connection_15 || false == m_RegisteredForEvents )
      {
         owner_Connection_15 = parentGameObject;
         if ( null != owner_Connection_15 )
         {
            {
               uScript_Trigger component = owner_Connection_15.GetComponent<uScript_Trigger>();
               if ( null == component )
               {
                  component = owner_Connection_15.AddComponent<uScript_Trigger>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_31;
                  component.OnExitTrigger += Instance_OnExitTrigger_31;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_31;
               }
            }
         }
      }
      if ( null == owner_Connection_18 || false == m_RegisteredForEvents )
      {
         owner_Connection_18 = parentGameObject;
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
      if ( local_2_UnityEngine_GameObject_previous != local_2_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_2_UnityEngine_GameObject_previous = local_2_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //reset event listeners if needed
      //this isn't a variable node so it should only be called once per enabling of the script
      //if it's called twice there would be a double event registration (which is an error)
      if ( false == m_RegisteredForEvents )
      {
         if ( null != owner_Connection_8 )
         {
            {
               uScript_Global component = owner_Connection_8.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = owner_Connection_8.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_3;
                  component.uScriptLateStart += Instance_uScriptLateStart_3;
               }
            }
         }
      }
      //reset event listeners if needed
      //this isn't a variable node so it should only be called once per enabling of the script
      //if it's called twice there would be a double event registration (which is an error)
      if ( false == m_RegisteredForEvents )
      {
         if ( null != owner_Connection_15 )
         {
            {
               uScript_Trigger component = owner_Connection_15.GetComponent<uScript_Trigger>();
               if ( null == component )
               {
                  component = owner_Connection_15.AddComponent<uScript_Trigger>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_31;
                  component.OnExitTrigger += Instance_OnExitTrigger_31;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_31;
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
      if ( null != owner_Connection_8 )
      {
         {
            uScript_Global component = owner_Connection_8.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_3;
               component.uScriptLateStart -= Instance_uScriptLateStart_3;
            }
         }
      }
      if ( null != owner_Connection_15 )
      {
         {
            uScript_Trigger component = owner_Connection_15.GetComponent<uScript_Trigger>();
            if ( null != component )
            {
               component.OnEnterTrigger -= Instance_OnEnterTrigger_31;
               component.OnExitTrigger -= Instance_OnExitTrigger_31;
               component.WhileInsideTrigger -= Instance_WhileInsideTrigger_31;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_0.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_1.SetParent(g);
      logic_uScriptAct_SpawnPrefab_uScriptAct_SpawnPrefab_6.SetParent(g);
      logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_9.SetParent(g);
      logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_22.SetParent(g);
      logic_uScriptAct_Destroy_uScriptAct_Destroy_24.SetParent(g);
      logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_26.SetParent(g);
      logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_27.SetParent(g);
      logic_uScriptCon_StringContains_uScriptCon_StringContains_29.SetParent(g);
      owner_Connection_8 = parentGameObject;
      owner_Connection_15 = parentGameObject;
      owner_Connection_18 = parentGameObject;
      owner_Connection_20 = parentGameObject;
   }
   public void Awake()
   {
      
      logic_uScriptAct_SpawnPrefab_uScriptAct_SpawnPrefab_6.FinishedSpawning += uScriptAct_SpawnPrefab_FinishedSpawning_6;
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
      
      logic_uScriptAct_SpawnPrefab_uScriptAct_SpawnPrefab_6.Update( );
      if (true == logic_uScriptAct_Delay_DrivenDelay_1)
      {
         Relay_DrivenDelay_1();
      }
      if (true == logic_uScriptAct_Destroy_WaitOneTick_24)
      {
         Relay_WaitOneTick_24();
      }
   }
   
   public void OnDestroy()
   {
      logic_uScriptAct_SpawnPrefab_uScriptAct_SpawnPrefab_6.FinishedSpawning -= uScriptAct_SpawnPrefab_FinishedSpawning_6;
   }
   
   void Instance_uScriptStart_3(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_3( );
   }
   
   void Instance_uScriptLateStart_3(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptLateStart_3( );
   }
   
   void Instance_OnEnterTrigger_31(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_31 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_31( );
   }
   
   void Instance_OnExitTrigger_31(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_31 = e.GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_31( );
   }
   
   void Instance_WhileInsideTrigger_31(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_31 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_31( );
   }
   
   void uScriptAct_SpawnPrefab_FinishedSpawning_6(object o, System.EventArgs e)
   {
      //fill globals
      //links to SpawnedGameObject = 0
      //links to SpawnedInstancedID = 0
      //relay event to nodes
      Relay_FinishedSpawning_6( );
   }
   
   void Relay_In_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b46e289d-0686-4d41-b0cd-66c99b7532d7", "Set_Random_Float", Relay_In_0)) return; 
         {
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_0.In(logic_uScriptAct_SetRandomFloat_Min_0, logic_uScriptAct_SetRandomFloat_Max_0, out logic_uScriptAct_SetRandomFloat_TargetFloat_0);
         local_14_System_Single = logic_uScriptAct_SetRandomFloat_TargetFloat_0;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_0.Out;
         
         if ( test_0 == true )
         {
            Relay_In_22();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_FireLogic.uscript at Set Random Float.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4d08f396-5b96-46d8-866e-cd817bf051a1", "Delay", Relay_In_1)) return; 
         {
            {
               logic_uScriptAct_Delay_Duration_1 = local_Time_Till_Spawn_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_1.In(logic_uScriptAct_Delay_Duration_1, logic_uScriptAct_Delay_SingleFrame_1);
         logic_uScriptAct_Delay_DrivenDelay_1 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_1.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_In_26();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_FireLogic.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4d08f396-5b96-46d8-866e-cd817bf051a1", "Delay", Relay_Stop_1)) return; 
         {
            {
               logic_uScriptAct_Delay_Duration_1 = local_Time_Till_Spawn_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_1.Stop(logic_uScriptAct_Delay_Duration_1, logic_uScriptAct_Delay_SingleFrame_1);
         logic_uScriptAct_Delay_DrivenDelay_1 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_1.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_In_26();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_FireLogic.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_DrivenDelay_1( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               logic_uScriptAct_Delay_Duration_1 = local_Time_Till_Spawn_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_Delay_DrivenDelay_1 = logic_uScriptAct_Delay_uScriptAct_Delay_1.DrivenDelay();
         if ( true == logic_uScriptAct_Delay_DrivenDelay_1 )
         {
            if ( logic_uScriptAct_Delay_uScriptAct_Delay_1.AfterDelay == true )
            {
               Relay_In_26();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_FireLogic.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_uScriptStart_3()
   {
      if (true == CheckDebugBreak("348b50da-7c28-46b4-9a93-63aaf1caea76", "uScript_Events", Relay_uScriptStart_3)) return; 
      Relay_In_1();
   }
   
   void Relay_uScriptLateStart_3()
   {
      if (true == CheckDebugBreak("348b50da-7c28-46b4-9a93-63aaf1caea76", "uScript_Events", Relay_uScriptLateStart_3)) return; 
   }
   
   void Relay_FinishedSpawning_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2b964ac8-40bb-4863-afb6-328675adf224", "Spawn_Prefab", Relay_FinishedSpawning_6)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_FireLogic.uscript at Spawn Prefab.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2b964ac8-40bb-4863-afb6-328675adf224", "Spawn_Prefab", Relay_In_6)) return; 
         {
            {
               logic_uScriptAct_SpawnPrefab_PrefabName_6 = local_10_System_String;
               
            }
            {
            }
            {
               logic_uScriptAct_SpawnPrefab_SpawnPoint_6 = owner_Connection_18;
               
            }
            {
            }
            {
               logic_uScriptAct_SpawnPrefab_LocationOffset_6 = local_7_UnityEngine_Vector3;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SpawnPrefab_uScriptAct_SpawnPrefab_6.In(logic_uScriptAct_SpawnPrefab_PrefabName_6, logic_uScriptAct_SpawnPrefab_ResourcePath_6, logic_uScriptAct_SpawnPrefab_SpawnPoint_6, logic_uScriptAct_SpawnPrefab_SpawnedName_6, logic_uScriptAct_SpawnPrefab_LocationOffset_6, out logic_uScriptAct_SpawnPrefab_SpawnedGameObject_6, out logic_uScriptAct_SpawnPrefab_SpawnedInstancedID_6);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_FireLogic.uscript at Spawn Prefab.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_SendCustomEvent_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("200aeaf4-ac1f-4569-a2e9-fbcfd4c5cf9e", "Send_Custom_Event__Int_", Relay_SendCustomEvent_9)) return; 
         {
            {
               logic_uScriptAct_SendCustomEventInt_EventName_9 = local_21_System_String;
               
            }
            {
               logic_uScriptAct_SendCustomEventInt_EventValue_9 = local_12_System_Int32;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_9.SendCustomEvent(logic_uScriptAct_SendCustomEventInt_EventName_9, logic_uScriptAct_SendCustomEventInt_EventValue_9, logic_uScriptAct_SendCustomEventInt_sendGroup_9, logic_uScriptAct_SendCustomEventInt_EventSender_9);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_9.Out;
         
         if ( test_0 == true )
         {
            Relay_In_24();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_FireLogic.uscript at Send Custom Event (Int).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_22()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("df8a1609-5712-489b-a154-f0f5670820ac", "Set_Components__Vector3_", Relay_In_22)) return; 
         {
            {
               logic_uScriptAct_SetComponentsVector3_X_22 = local_19_System_Single;
               
            }
            {
            }
            {
               logic_uScriptAct_SetComponentsVector3_Z_22 = local_14_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_22.In(logic_uScriptAct_SetComponentsVector3_X_22, logic_uScriptAct_SetComponentsVector3_Y_22, logic_uScriptAct_SetComponentsVector3_Z_22, out logic_uScriptAct_SetComponentsVector3_OutputVector3_22);
         local_7_UnityEngine_Vector3 = logic_uScriptAct_SetComponentsVector3_OutputVector3_22;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_22.Out;
         
         if ( test_0 == true )
         {
            Relay_In_6();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_FireLogic.uscript at Set Components (Vector3).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_24()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d66ab67f-0def-4372-b869-83fb08fd18e6", "Destroy", Relay_In_24)) return; 
         {
            {
               int index = 0;
               if ( logic_uScriptAct_Destroy_Target_24.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_Destroy_Target_24, index + 1);
               }
               logic_uScriptAct_Destroy_Target_24[ index++ ] = owner_Connection_20;
               
            }
            {
            }
         }
         logic_uScriptAct_Destroy_uScriptAct_Destroy_24.In(logic_uScriptAct_Destroy_Target_24, logic_uScriptAct_Destroy_DelayTime_24);
         logic_uScriptAct_Destroy_WaitOneTick_24 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_FireLogic.uscript at Destroy.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_WaitOneTick_24( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               int index = 0;
               if ( logic_uScriptAct_Destroy_Target_24.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_Destroy_Target_24, index + 1);
               }
               logic_uScriptAct_Destroy_Target_24[ index++ ] = owner_Connection_20;
               
            }
            {
            }
         }
         logic_uScriptAct_Destroy_WaitOneTick_24 = logic_uScriptAct_Destroy_uScriptAct_Destroy_24.WaitOneTick();
         if ( true == logic_uScriptAct_Destroy_WaitOneTick_24 )
         {
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_FireLogic.uscript at Destroy.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_In_26()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("41bb50dd-a938-4114-a423-ae67ca875302", "Set_Random_Float", Relay_In_26)) return; 
         {
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_26.In(logic_uScriptAct_SetRandomFloat_Min_26, logic_uScriptAct_SetRandomFloat_Max_26, out logic_uScriptAct_SetRandomFloat_TargetFloat_26);
         local_19_System_Single = logic_uScriptAct_SetRandomFloat_TargetFloat_26;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_26.Out;
         
         if ( test_0 == true )
         {
            Relay_In_0();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_FireLogic.uscript at Set Random Float.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_27()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1605c02e-1c38-4d55-aa9f-ca72764e5fd2", "Get_GameObject_Name", Relay_In_27)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_2_UnityEngine_GameObject_previous != local_2_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_2_UnityEngine_GameObject_previous = local_2_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_GetGameObjectName_gameObject_27 = local_2_UnityEngine_GameObject;
               
            }
            {
            }
         }
         logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_27.In(logic_uScriptAct_GetGameObjectName_gameObject_27, out logic_uScriptAct_GetGameObjectName_name_27);
         local_28_System_String = logic_uScriptAct_GetGameObjectName_name_27;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_27.Out;
         
         if ( test_0 == true )
         {
            Relay_In_29();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_FireLogic.uscript at Get GameObject Name.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_29()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("cc709be3-527b-4313-b3eb-e2a8d6448715", "String_Contains", Relay_In_29)) return; 
         {
            {
               logic_uScriptCon_StringContains_Target_29 = local_28_System_String;
               
            }
            {
               logic_uScriptCon_StringContains_Value_29 = local_30_System_String;
               
            }
         }
         logic_uScriptCon_StringContains_uScriptCon_StringContains_29.In(logic_uScriptCon_StringContains_Target_29, logic_uScriptCon_StringContains_Value_29);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_StringContains_uScriptCon_StringContains_29.True;
         
         if ( test_0 == true )
         {
            Relay_SendCustomEvent_9();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_FireLogic.uscript at String Contains.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnEnterTrigger_31()
   {
      if (true == CheckDebugBreak("b0b8ad6b-7ffb-4ef8-8825-0853cabe32c4", "Trigger_Event", Relay_OnEnterTrigger_31)) return; 
      local_2_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_31;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_2_UnityEngine_GameObject_previous != local_2_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_2_UnityEngine_GameObject_previous = local_2_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
      Relay_In_27();
   }
   
   void Relay_OnExitTrigger_31()
   {
      if (true == CheckDebugBreak("b0b8ad6b-7ffb-4ef8-8825-0853cabe32c4", "Trigger_Event", Relay_OnExitTrigger_31)) return; 
      local_2_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_31;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_2_UnityEngine_GameObject_previous != local_2_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_2_UnityEngine_GameObject_previous = local_2_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
   }
   
   void Relay_WhileInsideTrigger_31()
   {
      if (true == CheckDebugBreak("b0b8ad6b-7ffb-4ef8-8825-0853cabe32c4", "Trigger_Event", Relay_WhileInsideTrigger_31)) return; 
      local_2_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_31;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_2_UnityEngine_GameObject_previous != local_2_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_2_UnityEngine_GameObject_previous = local_2_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_FireLogic.uscript:2", local_2_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "57de6d55-8225-4b40-bbdc-ce323bcada47", local_2_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_FireLogic.uscript:7", local_7_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "49701a60-8aad-4793-a525-f97630d21530", local_7_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_FireLogic.uscript:10", local_10_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "6d7143d7-ce4b-497a-b073-a230d23e76d1", local_10_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_FireLogic.uscript:12", local_12_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ae75804d-009c-496a-89f6-954ea2d00558", local_12_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_FireLogic.uscript:Time Till Spawn", local_Time_Till_Spawn_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "47dba5df-17cd-4c0b-a868-f91b36964b20", local_Time_Till_Spawn_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_FireLogic.uscript:14", local_14_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c0b3f713-4ef6-47d8-82b0-1212af0f24e3", local_14_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_FireLogic.uscript:19", local_19_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "62748849-e1f3-427a-9770-16ba60190851", local_19_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_FireLogic.uscript:21", local_21_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "02adb1d4-420f-4db5-a973-46cebdbaf546", local_21_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_FireLogic.uscript:28", local_28_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "23199ebb-18ef-44b9-998a-0f615cfea7f5", local_28_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_FireLogic.uscript:30", local_30_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f4d40e47-7a8f-4c24-bc3e-9a69bdf18476", local_30_System_String);
   }
   bool CheckDebugBreak(string guid, string name, ContinueExecution method)
   {
      if (true == m_Breakpoint) return true;
      
      if (true == uScript_MasterComponent.FindBreakpoint(guid))
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
