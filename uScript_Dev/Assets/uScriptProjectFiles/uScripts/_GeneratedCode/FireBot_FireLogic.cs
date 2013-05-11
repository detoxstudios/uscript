//uScript Generated Code - Build 0.9.2275
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
   System.String local_11_System_String = "Fire";
   System.Int32 local_13_System_Int32 = (int) 10;
   System.Single local_15_System_Single = (float) 0;
   UnityEngine.GameObject local_2_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_2_UnityEngine_GameObject_previous = null;
   System.Single local_20_System_Single = (float) 0;
   System.String local_22_System_String = "Award Points";
   System.String local_29_System_String = "";
   System.String local_31_System_String = "WaterBall";
   UnityEngine.Vector3 local_7_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   System.Single local_Time_Till_Spawn_System_Single = (float) 4;
   
   //owner nodes
   UnityEngine.GameObject owner_Connection_8 = null;
   UnityEngine.GameObject owner_Connection_16 = null;
   UnityEngine.GameObject owner_Connection_19 = null;
   UnityEngine.GameObject owner_Connection_21 = null;
   
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
   bool logic_uScriptAct_Delay_DrivenDelay_1 = false;
   //pointer to script instanced logic node
   uScriptAct_SpawnPrefab logic_uScriptAct_SpawnPrefab_uScriptAct_SpawnPrefab_6 = new uScriptAct_SpawnPrefab( );
   System.String logic_uScriptAct_SpawnPrefab_PrefabName_6 = "";
   System.String logic_uScriptAct_SpawnPrefab_ResourcePath_6 = "";
   UnityEngine.GameObject logic_uScriptAct_SpawnPrefab_SpawnPoint_6 = null;
   System.String logic_uScriptAct_SpawnPrefab_SpawnedName_6 = "";
   UnityEngine.Vector3 logic_uScriptAct_SpawnPrefab_LocationOffset_6 = new Vector3( );
   UnityEngine.GameObject logic_uScriptAct_SpawnPrefab_SpawnedGameObject_6;
   System.Int32 logic_uScriptAct_SpawnPrefab_SpawnedInstancedID_6;
   bool logic_uScriptAct_SpawnPrefab_Immediate_6 = true;
   //pointer to script instanced logic node
   uScriptAct_SendCustomEventInt logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_10 = new uScriptAct_SendCustomEventInt( );
   System.String logic_uScriptAct_SendCustomEventInt_EventName_10 = "";
   System.Int32 logic_uScriptAct_SendCustomEventInt_EventValue_10 = (int) 0;
   uScriptCustomEvent.SendGroup logic_uScriptAct_SendCustomEventInt_sendGroup_10 = uScriptCustomEvent.SendGroup.All;
   UnityEngine.GameObject logic_uScriptAct_SendCustomEventInt_EventSender_10 = null;
   bool logic_uScriptAct_SendCustomEventInt_Out_10 = true;
   //pointer to script instanced logic node
   uScriptAct_SetComponentsVector3 logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_23 = new uScriptAct_SetComponentsVector3( );
   System.Single logic_uScriptAct_SetComponentsVector3_X_23 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsVector3_Y_23 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsVector3_Z_23 = (float) 0;
   UnityEngine.Vector3 logic_uScriptAct_SetComponentsVector3_OutputVector3_23;
   bool logic_uScriptAct_SetComponentsVector3_Out_23 = true;
   //pointer to script instanced logic node
   uScriptAct_Destroy logic_uScriptAct_Destroy_uScriptAct_Destroy_25 = new uScriptAct_Destroy( );
   UnityEngine.GameObject[] logic_uScriptAct_Destroy_Target_25 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_Destroy_DelayTime_25 = (float) 0;
   bool logic_uScriptAct_Destroy_Out_25 = true;
   bool logic_uScriptAct_Destroy_ObjectsDestroyed_25 = true;
   bool logic_uScriptAct_Destroy_WaitOneTick_25 = false;
   //pointer to script instanced logic node
   uScriptAct_SetRandomFloat logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_27 = new uScriptAct_SetRandomFloat( );
   System.Single logic_uScriptAct_SetRandomFloat_Min_27 = (float) -3.5;
   System.Single logic_uScriptAct_SetRandomFloat_Max_27 = (float) 3.5;
   System.Single logic_uScriptAct_SetRandomFloat_TargetFloat_27;
   bool logic_uScriptAct_SetRandomFloat_Out_27 = true;
   //pointer to script instanced logic node
   uScriptAct_GetGameObjectName logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_28 = new uScriptAct_GetGameObjectName( );
   UnityEngine.GameObject logic_uScriptAct_GetGameObjectName_gameObject_28 = null;
   System.String logic_uScriptAct_GetGameObjectName_name_28;
   bool logic_uScriptAct_GetGameObjectName_Out_28 = true;
   //pointer to script instanced logic node
   uScriptCon_StringContains logic_uScriptCon_StringContains_uScriptCon_StringContains_30 = new uScriptCon_StringContains( );
   System.String logic_uScriptCon_StringContains_Target_30 = "";
   System.String logic_uScriptCon_StringContains_Value_30 = "";
   bool logic_uScriptCon_StringContains_True_30 = true;
   bool logic_uScriptCon_StringContains_False_30 = true;
   
   //event nodes
   System.Int32 event_UnityEngine_GameObject_TimesToTrigger_9 = (int) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_9 = null;
   
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
               }
            }
         }
      }
      if ( null == owner_Connection_16 || false == m_RegisteredForEvents )
      {
         owner_Connection_16 = parentGameObject;
         if ( null != owner_Connection_16 )
         {
            {
               uScript_Triggers component = owner_Connection_16.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = owner_Connection_16.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_9;
               }
            }
            {
               uScript_Triggers component = owner_Connection_16.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = owner_Connection_16.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_9;
                  component.OnExitTrigger += Instance_OnExitTrigger_9;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_9;
               }
            }
         }
      }
      if ( null == owner_Connection_19 || false == m_RegisteredForEvents )
      {
         owner_Connection_19 = parentGameObject;
      }
      if ( null == owner_Connection_21 || false == m_RegisteredForEvents )
      {
         owner_Connection_21 = parentGameObject;
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
               }
            }
         }
      }
      //reset event listeners if needed
      //this isn't a variable node so it should only be called once per enabling of the script
      //if it's called twice there would be a double event registration (which is an error)
      if ( false == m_RegisteredForEvents )
      {
         if ( null != owner_Connection_16 )
         {
            {
               uScript_Triggers component = owner_Connection_16.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = owner_Connection_16.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_9;
               }
            }
            {
               uScript_Triggers component = owner_Connection_16.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = owner_Connection_16.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_9;
                  component.OnExitTrigger += Instance_OnExitTrigger_9;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_9;
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
            }
         }
      }
      if ( null != owner_Connection_16 )
      {
         {
            uScript_Triggers component = owner_Connection_16.GetComponent<uScript_Triggers>();
            if ( null != component )
            {
               component.OnEnterTrigger -= Instance_OnEnterTrigger_9;
               component.OnExitTrigger -= Instance_OnExitTrigger_9;
               component.WhileInsideTrigger -= Instance_WhileInsideTrigger_9;
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
      logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_10.SetParent(g);
      logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_23.SetParent(g);
      logic_uScriptAct_Destroy_uScriptAct_Destroy_25.SetParent(g);
      logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_27.SetParent(g);
      logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_28.SetParent(g);
      logic_uScriptCon_StringContains_uScriptCon_StringContains_30.SetParent(g);
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
      if (true == logic_uScriptAct_Destroy_WaitOneTick_25)
      {
         Relay_WaitOneTick_25();
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
   
   void Instance_OnEnterTrigger_9(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_9 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_9( );
   }
   
   void Instance_OnExitTrigger_9(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_9 = e.GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_9( );
   }
   
   void Instance_WhileInsideTrigger_9(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_9 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_9( );
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
         if (true == CheckDebugBreak("b46e289d-0686-4d41-b0cd-66c99b7532d7", "Set Random Float", Relay_In_0)) return; 
         {
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_0.In(logic_uScriptAct_SetRandomFloat_Min_0, logic_uScriptAct_SetRandomFloat_Max_0, out logic_uScriptAct_SetRandomFloat_TargetFloat_0);
         local_15_System_Single = logic_uScriptAct_SetRandomFloat_TargetFloat_0;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_0.Out;
         
         if ( test_0 == true )
         {
            Relay_In_23();
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
            Relay_In_27();
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
               Relay_In_27();
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
      if (true == CheckDebugBreak("348b50da-7c28-46b4-9a93-63aaf1caea76", "uScript Events", Relay_uScriptStart_3)) return; 
      Relay_In_1();
   }
   
   void Relay_FinishedSpawning_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2b964ac8-40bb-4863-afb6-328675adf224", "Spawn Prefab", Relay_FinishedSpawning_6)) return; 
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
         if (true == CheckDebugBreak("2b964ac8-40bb-4863-afb6-328675adf224", "Spawn Prefab", Relay_In_6)) return; 
         {
            {
               logic_uScriptAct_SpawnPrefab_PrefabName_6 = local_11_System_String;
               
            }
            {
            }
            {
               logic_uScriptAct_SpawnPrefab_SpawnPoint_6 = owner_Connection_19;
               
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
   
   void Relay_OnEnterTrigger_9()
   {
      if (true == CheckDebugBreak("87300f90-11d0-46bb-9672-45ffdc33f12e", "Trigger Events", Relay_OnEnterTrigger_9)) return; 
      local_2_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_9;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_2_UnityEngine_GameObject_previous != local_2_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_2_UnityEngine_GameObject_previous = local_2_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
      Relay_In_28();
   }
   
   void Relay_OnExitTrigger_9()
   {
      if (true == CheckDebugBreak("87300f90-11d0-46bb-9672-45ffdc33f12e", "Trigger Events", Relay_OnExitTrigger_9)) return; 
      local_2_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_9;
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
   
   void Relay_WhileInsideTrigger_9()
   {
      if (true == CheckDebugBreak("87300f90-11d0-46bb-9672-45ffdc33f12e", "Trigger Events", Relay_WhileInsideTrigger_9)) return; 
      local_2_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_9;
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
   
   void Relay_SendCustomEvent_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("200aeaf4-ac1f-4569-a2e9-fbcfd4c5cf9e", "Send Custom Event (Int)", Relay_SendCustomEvent_10)) return; 
         {
            {
               logic_uScriptAct_SendCustomEventInt_EventName_10 = local_22_System_String;
               
            }
            {
               logic_uScriptAct_SendCustomEventInt_EventValue_10 = local_13_System_Int32;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_10.SendCustomEvent(logic_uScriptAct_SendCustomEventInt_EventName_10, logic_uScriptAct_SendCustomEventInt_EventValue_10, logic_uScriptAct_SendCustomEventInt_sendGroup_10, logic_uScriptAct_SendCustomEventInt_EventSender_10);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_10.Out;
         
         if ( test_0 == true )
         {
            Relay_In_25();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_FireLogic.uscript at Send Custom Event (Int).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_23()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("df8a1609-5712-489b-a154-f0f5670820ac", "Set Components (Vector3)", Relay_In_23)) return; 
         {
            {
               logic_uScriptAct_SetComponentsVector3_X_23 = local_20_System_Single;
               
            }
            {
            }
            {
               logic_uScriptAct_SetComponentsVector3_Z_23 = local_15_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_23.In(logic_uScriptAct_SetComponentsVector3_X_23, logic_uScriptAct_SetComponentsVector3_Y_23, logic_uScriptAct_SetComponentsVector3_Z_23, out logic_uScriptAct_SetComponentsVector3_OutputVector3_23);
         local_7_UnityEngine_Vector3 = logic_uScriptAct_SetComponentsVector3_OutputVector3_23;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_23.Out;
         
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
   
   void Relay_In_25()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d66ab67f-0def-4372-b869-83fb08fd18e6", "Destroy", Relay_In_25)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               properties.Add((UnityEngine.GameObject)owner_Connection_21);
               logic_uScriptAct_Destroy_Target_25 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Destroy_uScriptAct_Destroy_25.In(logic_uScriptAct_Destroy_Target_25, logic_uScriptAct_Destroy_DelayTime_25);
         logic_uScriptAct_Destroy_WaitOneTick_25 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_FireLogic.uscript at Destroy.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_WaitOneTick_25( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               properties.Add((UnityEngine.GameObject)owner_Connection_21);
               logic_uScriptAct_Destroy_Target_25 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Destroy_WaitOneTick_25 = logic_uScriptAct_Destroy_uScriptAct_Destroy_25.WaitOneTick();
         if ( true == logic_uScriptAct_Destroy_WaitOneTick_25 )
         {
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_FireLogic.uscript at Destroy.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_In_27()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("41bb50dd-a938-4114-a423-ae67ca875302", "Set Random Float", Relay_In_27)) return; 
         {
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_27.In(logic_uScriptAct_SetRandomFloat_Min_27, logic_uScriptAct_SetRandomFloat_Max_27, out logic_uScriptAct_SetRandomFloat_TargetFloat_27);
         local_20_System_Single = logic_uScriptAct_SetRandomFloat_TargetFloat_27;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_27.Out;
         
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
   
   void Relay_In_28()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1605c02e-1c38-4d55-aa9f-ca72764e5fd2", "Get GameObject Name", Relay_In_28)) return; 
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
               logic_uScriptAct_GetGameObjectName_gameObject_28 = local_2_UnityEngine_GameObject;
               
            }
            {
            }
         }
         logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_28.In(logic_uScriptAct_GetGameObjectName_gameObject_28, out logic_uScriptAct_GetGameObjectName_name_28);
         local_29_System_String = logic_uScriptAct_GetGameObjectName_name_28;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_28.Out;
         
         if ( test_0 == true )
         {
            Relay_In_30();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_FireLogic.uscript at Get GameObject Name.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_30()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("cc709be3-527b-4313-b3eb-e2a8d6448715", "String Contains", Relay_In_30)) return; 
         {
            {
               logic_uScriptCon_StringContains_Target_30 = local_29_System_String;
               
            }
            {
               logic_uScriptCon_StringContains_Value_30 = local_31_System_String;
               
            }
         }
         logic_uScriptCon_StringContains_uScriptCon_StringContains_30.In(logic_uScriptCon_StringContains_Target_30, logic_uScriptCon_StringContains_Value_30);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_StringContains_uScriptCon_StringContains_30.True;
         
         if ( test_0 == true )
         {
            Relay_SendCustomEvent_10();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_FireLogic.uscript at String Contains.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_FireLogic.uscript:2", local_2_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "57de6d55-8225-4b40-bbdc-ce323bcada47", local_2_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_FireLogic.uscript:7", local_7_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "49701a60-8aad-4793-a525-f97630d21530", local_7_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_FireLogic.uscript:11", local_11_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "6d7143d7-ce4b-497a-b073-a230d23e76d1", local_11_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_FireLogic.uscript:13", local_13_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ae75804d-009c-496a-89f6-954ea2d00558", local_13_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_FireLogic.uscript:Time Till Spawn", local_Time_Till_Spawn_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "47dba5df-17cd-4c0b-a868-f91b36964b20", local_Time_Till_Spawn_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_FireLogic.uscript:15", local_15_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c0b3f713-4ef6-47d8-82b0-1212af0f24e3", local_15_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_FireLogic.uscript:20", local_20_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "62748849-e1f3-427a-9770-16ba60190851", local_20_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_FireLogic.uscript:22", local_22_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "02adb1d4-420f-4db5-a973-46cebdbaf546", local_22_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_FireLogic.uscript:29", local_29_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "23199ebb-18ef-44b9-998a-0f615cfea7f5", local_29_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_FireLogic.uscript:31", local_31_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f4d40e47-7a8f-4c24-bc3e-9a69bdf18476", local_31_System_String);
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
