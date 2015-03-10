//uScript Generated Code - Build 1.0.2830
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class TeleportCube_TeleportGraph : uScriptLogic
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
   UnityEngine.GameObject local_1_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_1_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_2_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_2_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_6_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_6_UnityEngine_GameObject_previous = null;
   UnityEngine.Vector3 local_7_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.GameObject local_8_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_8_UnityEngine_GameObject_previous = null;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_Teleport logic_uScriptAct_Teleport_uScriptAct_Teleport_0 = new uScriptAct_Teleport( );
   UnityEngine.GameObject[] logic_uScriptAct_Teleport_Target_0 = new UnityEngine.GameObject[] {};
   UnityEngine.GameObject logic_uScriptAct_Teleport_Destination_0 = default(UnityEngine.GameObject);
   System.Boolean logic_uScriptAct_Teleport_UpdateRotation_0 = (bool) false;
   bool logic_uScriptAct_Teleport_Out_0 = true;
   //pointer to script instanced logic node
   uScriptAct_MoveToLocation logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_3 = new uScriptAct_MoveToLocation( );
   UnityEngine.GameObject[] logic_uScriptAct_MoveToLocation_targetArray_3 = new UnityEngine.GameObject[] {};
   UnityEngine.Vector3 logic_uScriptAct_MoveToLocation_location_3 = new Vector3( );
   System.Boolean logic_uScriptAct_MoveToLocation_asOffset_3 = (bool) false;
   System.Single logic_uScriptAct_MoveToLocation_totalTime_3 = (float) 4;
   bool logic_uScriptAct_MoveToLocation_Out_3 = true;
   bool logic_uScriptAct_MoveToLocation_Cancelled_3 = true;
   //pointer to script instanced logic node
   uScriptAct_GetPositionAndRotation logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_4 = new uScriptAct_GetPositionAndRotation( );
   UnityEngine.GameObject logic_uScriptAct_GetPositionAndRotation_Target_4 = default(UnityEngine.GameObject);
   System.Boolean logic_uScriptAct_GetPositionAndRotation_GetLocal_4 = (bool) false;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Position_4;
   UnityEngine.Quaternion logic_uScriptAct_GetPositionAndRotation_Rotation_4;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_EulerAngles_4;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Forward_4;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Up_4;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Right_4;
   bool logic_uScriptAct_GetPositionAndRotation_Out_4 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_5 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_21 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_21 = default(UnityEngine.GameObject);
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      if ( null == local_1_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_1_UnityEngine_GameObject = GameObject.Find( "Cube" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_1_UnityEngine_GameObject_previous != local_1_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_1_UnityEngine_GameObject_previous = local_1_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_2_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_2_UnityEngine_GameObject = GameObject.Find( "Teleport_Point" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_2_UnityEngine_GameObject_previous != local_2_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_2_UnityEngine_GameObject_previous = local_2_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_6_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_6_UnityEngine_GameObject = GameObject.Find( "Teleport_Trigger" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_6_UnityEngine_GameObject_previous != local_6_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_8_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_8_UnityEngine_GameObject = GameObject.Find( "Cube" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_8_UnityEngine_GameObject_previous != local_8_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_8_UnityEngine_GameObject_previous = local_8_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_1_UnityEngine_GameObject_previous != local_1_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_1_UnityEngine_GameObject_previous = local_1_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_2_UnityEngine_GameObject_previous != local_2_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_2_UnityEngine_GameObject_previous = local_2_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_6_UnityEngine_GameObject_previous != local_6_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_8_UnityEngine_GameObject_previous != local_8_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_8_UnityEngine_GameObject_previous = local_8_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void SyncEventListeners( )
   {
      if ( null == event_UnityEngine_GameObject_Instance_5 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_5 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_5 )
         {
            {
               uScript_Global component = event_UnityEngine_GameObject_Instance_5.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_5.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_5;
                  component.uScriptLateStart += Instance_uScriptLateStart_5;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_21 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_21 = GameObject.Find( "Teleport_Trigger" ) as UnityEngine.GameObject;
         if ( null != event_UnityEngine_GameObject_Instance_21 )
         {
            {
               uScript_Trigger component = event_UnityEngine_GameObject_Instance_21.GetComponent<uScript_Trigger>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_21.AddComponent<uScript_Trigger>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_21;
                  component.OnExitTrigger += Instance_OnExitTrigger_21;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_21;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != event_UnityEngine_GameObject_Instance_5 )
      {
         {
            uScript_Global component = event_UnityEngine_GameObject_Instance_5.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_5;
               component.uScriptLateStart -= Instance_uScriptLateStart_5;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_21 )
      {
         {
            uScript_Trigger component = event_UnityEngine_GameObject_Instance_21.GetComponent<uScript_Trigger>();
            if ( null != component )
            {
               component.OnEnterTrigger -= Instance_OnEnterTrigger_21;
               component.OnExitTrigger -= Instance_OnExitTrigger_21;
               component.WhileInsideTrigger -= Instance_WhileInsideTrigger_21;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_Teleport_uScriptAct_Teleport_0.SetParent(g);
      logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_3.SetParent(g);
      logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_4.SetParent(g);
   }
   public void Awake()
   {
      
      logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_3.Finished += uScriptAct_MoveToLocation_Finished_3;
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
      
      logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_3.Update( );
   }
   
   public void OnDestroy()
   {
      logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_3.Finished -= uScriptAct_MoveToLocation_Finished_3;
   }
   
   void Instance_uScriptStart_5(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_5( );
   }
   
   void Instance_uScriptLateStart_5(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptLateStart_5( );
   }
   
   void Instance_OnEnterTrigger_21(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_21 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_21( );
   }
   
   void Instance_OnExitTrigger_21(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_21 = e.GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_21( );
   }
   
   void Instance_WhileInsideTrigger_21(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_21 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_21( );
   }
   
   void uScriptAct_MoveToLocation_Finished_3(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_3( );
   }
   
   void Relay_In_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4780ae9d-31f4-4e2f-9e76-68b8486b9ee0", "Teleport", Relay_In_0)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_1_UnityEngine_GameObject_previous != local_1_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_1_UnityEngine_GameObject_previous = local_1_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_1_UnityEngine_GameObject);
               logic_uScriptAct_Teleport_Target_0 = properties.ToArray();
            }
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
               logic_uScriptAct_Teleport_Destination_0 = local_2_UnityEngine_GameObject;
               
            }
            {
            }
         }
         logic_uScriptAct_Teleport_uScriptAct_Teleport_0.In(logic_uScriptAct_Teleport_Target_0, logic_uScriptAct_Teleport_Destination_0, logic_uScriptAct_Teleport_UpdateRotation_0);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Teleport_uScriptAct_Teleport_0.Out;
         
         if ( test_0 == true )
         {
            Relay_In_4();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript TeleportCube_TeleportGraph.uscript at Teleport.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("107f42dc-0bb6-43bb-9471-9d364183d2b6", "Move_To_Location", Relay_Finished_3)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript TeleportCube_TeleportGraph.uscript at Move To Location.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("107f42dc-0bb6-43bb-9471-9d364183d2b6", "Move_To_Location", Relay_In_3)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_8_UnityEngine_GameObject_previous != local_8_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_8_UnityEngine_GameObject_previous = local_8_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_8_UnityEngine_GameObject);
               logic_uScriptAct_MoveToLocation_targetArray_3 = properties.ToArray();
            }
            {
               logic_uScriptAct_MoveToLocation_location_3 = local_7_UnityEngine_Vector3;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_3.In(logic_uScriptAct_MoveToLocation_targetArray_3, logic_uScriptAct_MoveToLocation_location_3, logic_uScriptAct_MoveToLocation_asOffset_3, logic_uScriptAct_MoveToLocation_totalTime_3);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript TeleportCube_TeleportGraph.uscript at Move To Location.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Cancel_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("107f42dc-0bb6-43bb-9471-9d364183d2b6", "Move_To_Location", Relay_Cancel_3)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_8_UnityEngine_GameObject_previous != local_8_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_8_UnityEngine_GameObject_previous = local_8_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_8_UnityEngine_GameObject);
               logic_uScriptAct_MoveToLocation_targetArray_3 = properties.ToArray();
            }
            {
               logic_uScriptAct_MoveToLocation_location_3 = local_7_UnityEngine_Vector3;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_3.Cancel(logic_uScriptAct_MoveToLocation_targetArray_3, logic_uScriptAct_MoveToLocation_location_3, logic_uScriptAct_MoveToLocation_asOffset_3, logic_uScriptAct_MoveToLocation_totalTime_3);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript TeleportCube_TeleportGraph.uscript at Move To Location.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_4()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ecc1bb87-4d86-499a-83f5-2ec0f8573f24", "Get_Position_and_Rotation", Relay_In_4)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_6_UnityEngine_GameObject_previous != local_6_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_GetPositionAndRotation_Target_4 = local_6_UnityEngine_GameObject;
               
            }
            {
            }
            {
            }
            {
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
         logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_4.In(logic_uScriptAct_GetPositionAndRotation_Target_4, logic_uScriptAct_GetPositionAndRotation_GetLocal_4, out logic_uScriptAct_GetPositionAndRotation_Position_4, out logic_uScriptAct_GetPositionAndRotation_Rotation_4, out logic_uScriptAct_GetPositionAndRotation_EulerAngles_4, out logic_uScriptAct_GetPositionAndRotation_Forward_4, out logic_uScriptAct_GetPositionAndRotation_Up_4, out logic_uScriptAct_GetPositionAndRotation_Right_4);
         local_7_UnityEngine_Vector3 = logic_uScriptAct_GetPositionAndRotation_Position_4;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_4.Out;
         
         if ( test_0 == true )
         {
            Relay_In_3();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript TeleportCube_TeleportGraph.uscript at Get Position and Rotation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_uScriptStart_5()
   {
      if (true == CheckDebugBreak("86791c12-a06f-4221-bfa8-cd3e7e1fc5bb", "uScript_Events", Relay_uScriptStart_5)) return; 
      Relay_In_4();
   }
   
   void Relay_uScriptLateStart_5()
   {
      if (true == CheckDebugBreak("86791c12-a06f-4221-bfa8-cd3e7e1fc5bb", "uScript_Events", Relay_uScriptLateStart_5)) return; 
   }
   
   void Relay_OnEnterTrigger_21()
   {
      if (true == CheckDebugBreak("e3edc2ec-9f1a-4b2c-8957-d55171e106ea", "Trigger_Event", Relay_OnEnterTrigger_21)) return; 
      Relay_In_0();
   }
   
   void Relay_OnExitTrigger_21()
   {
      if (true == CheckDebugBreak("e3edc2ec-9f1a-4b2c-8957-d55171e106ea", "Trigger_Event", Relay_OnExitTrigger_21)) return; 
   }
   
   void Relay_WhileInsideTrigger_21()
   {
      if (true == CheckDebugBreak("e3edc2ec-9f1a-4b2c-8957-d55171e106ea", "Trigger_Event", Relay_WhileInsideTrigger_21)) return; 
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "TeleportCube_TeleportGraph.uscript:1", local_1_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "5c4e3242-fbe5-4f75-8f44-2f0ef1a4c888", local_1_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "TeleportCube_TeleportGraph.uscript:2", local_2_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "06db380b-6438-42f9-9fa7-637e8e170a69", local_2_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "TeleportCube_TeleportGraph.uscript:6", local_6_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ebb7cde2-728b-4c0f-a454-47a83b0b339b", local_6_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "TeleportCube_TeleportGraph.uscript:7", local_7_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "2988dd27-0a89-463f-9099-4f680d2c8fce", local_7_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "TeleportCube_TeleportGraph.uscript:8", local_8_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "5d3893ea-b3c6-4a77-8338-ceb1938502e1", local_8_UnityEngine_GameObject);
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
