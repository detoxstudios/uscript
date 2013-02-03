//uScript Generated Code - Build 0.9.2215
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class ProximityDoor_DetectPositionGraph : uScriptLogic
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
   UnityEngine.GameObject local_10_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_10_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_14_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_14_UnityEngine_GameObject_previous = null;
   UnityEngine.Vector3 local_15_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   System.Single local_16_System_Single = (float) 0;
   System.Single local_17_System_Single = (float) 0;
   UnityEngine.Vector3 local_19_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.GameObject local_2_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_2_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_20_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_20_UnityEngine_GameObject_previous = null;
   System.Single local_Detection_Radius_System_Single = (float) 16;
   System.Single local_Door_Height_System_Single = (float) 0;
   System.Single local_Player_Distance_System_Single = (float) 0;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_GetDistance logic_uScriptAct_GetDistance_uScriptAct_GetDistance_1 = new uScriptAct_GetDistance( );
   UnityEngine.GameObject logic_uScriptAct_GetDistance_A_1 = null;
   UnityEngine.GameObject logic_uScriptAct_GetDistance_B_1 = null;
   System.Single logic_uScriptAct_GetDistance_Distance_1;
   bool logic_uScriptAct_GetDistance_Out_1 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareFloat logic_uScriptCon_CompareFloat_uScriptCon_CompareFloat_4 = new uScriptCon_CompareFloat( );
   System.Single logic_uScriptCon_CompareFloat_A_4 = (float) 0;
   System.Single logic_uScriptCon_CompareFloat_B_4 = (float) 0;
   bool logic_uScriptCon_CompareFloat_GreaterThan_4 = true;
   bool logic_uScriptCon_CompareFloat_GreaterThanOrEqualTo_4 = true;
   bool logic_uScriptCon_CompareFloat_EqualTo_4 = true;
   bool logic_uScriptCon_CompareFloat_NotEqualTo_4 = true;
   bool logic_uScriptCon_CompareFloat_LessThanOrEqualTo_4 = true;
   bool logic_uScriptCon_CompareFloat_LessThan_4 = true;
   //pointer to script instanced logic node
   uScriptAct_ClampFloat logic_uScriptAct_ClampFloat_uScriptAct_ClampFloat_6 = new uScriptAct_ClampFloat( );
   System.Single logic_uScriptAct_ClampFloat_Target_6 = (float) 0;
   System.Single logic_uScriptAct_ClampFloat_Min_6 = (float) 0;
   System.Single logic_uScriptAct_ClampFloat_Max_6 = (float) 4;
   System.Single logic_uScriptAct_ClampFloat_FloatResult_6;
   System.Int32 logic_uScriptAct_ClampFloat_IntResult_6;
   bool logic_uScriptAct_ClampFloat_Out_6 = true;
   //pointer to script instanced logic node
   uScriptAct_SetGameObjectPosition logic_uScriptAct_SetGameObjectPosition_uScriptAct_SetGameObjectPosition_9 = new uScriptAct_SetGameObjectPosition( );
   UnityEngine.GameObject[] logic_uScriptAct_SetGameObjectPosition_Target_9 = new UnityEngine.GameObject[] {};
   UnityEngine.Vector3 logic_uScriptAct_SetGameObjectPosition_Position_9 = new Vector3( );
   System.Boolean logic_uScriptAct_SetGameObjectPosition_AsOffset_9 = (bool) false;
   bool logic_uScriptAct_SetGameObjectPosition_Out_9 = true;
   //pointer to script instanced logic node
   uScriptAct_GetPositionAndRotation logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_11 = new uScriptAct_GetPositionAndRotation( );
   UnityEngine.GameObject logic_uScriptAct_GetPositionAndRotation_Target_11 = null;
   System.Boolean logic_uScriptAct_GetPositionAndRotation_GetLocal_11 = (bool) false;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Position_11;
   UnityEngine.Quaternion logic_uScriptAct_GetPositionAndRotation_Rotation_11;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_EulerAngles_11;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Forward_11;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Up_11;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Right_11;
   bool logic_uScriptAct_GetPositionAndRotation_Out_11 = true;
   //pointer to script instanced logic node
   uScriptAct_GetComponentsVector3 logic_uScriptAct_GetComponentsVector3_uScriptAct_GetComponentsVector3_12 = new uScriptAct_GetComponentsVector3( );
   UnityEngine.Vector3 logic_uScriptAct_GetComponentsVector3_InputVector3_12 = new Vector3( );
   System.Single logic_uScriptAct_GetComponentsVector3_X_12;
   System.Single logic_uScriptAct_GetComponentsVector3_Y_12;
   System.Single logic_uScriptAct_GetComponentsVector3_Z_12;
   bool logic_uScriptAct_GetComponentsVector3_Out_12 = true;
   //pointer to script instanced logic node
   uScriptAct_SetComponentsVector3 logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_13 = new uScriptAct_SetComponentsVector3( );
   System.Single logic_uScriptAct_SetComponentsVector3_X_13 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsVector3_Y_13 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsVector3_Z_13 = (float) 0;
   UnityEngine.Vector3 logic_uScriptAct_SetComponentsVector3_OutputVector3_13;
   bool logic_uScriptAct_SetComponentsVector3_Out_13 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_0 = null;
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      if ( null == local_2_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_2_UnityEngine_GameObject = GameObject.Find( "First Person Controller" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_2_UnityEngine_GameObject_previous != local_2_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_2_UnityEngine_GameObject_previous = local_2_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_10_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_10_UnityEngine_GameObject = GameObject.Find( "Door" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_10_UnityEngine_GameObject_previous != local_10_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_10_UnityEngine_GameObject_previous = local_10_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_14_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_14_UnityEngine_GameObject = GameObject.Find( "Door" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_14_UnityEngine_GameObject_previous != local_14_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_14_UnityEngine_GameObject_previous = local_14_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_20_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_20_UnityEngine_GameObject = GameObject.Find( "Door_Locator" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_20_UnityEngine_GameObject_previous != local_20_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_20_UnityEngine_GameObject_previous = local_20_UnityEngine_GameObject;
         
         //setup new listeners
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
      //if our game object reference was changed then we need to reset event listeners
      if ( local_10_UnityEngine_GameObject_previous != local_10_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_10_UnityEngine_GameObject_previous = local_10_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_14_UnityEngine_GameObject_previous != local_14_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_14_UnityEngine_GameObject_previous = local_14_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_20_UnityEngine_GameObject_previous != local_20_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_20_UnityEngine_GameObject_previous = local_20_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void SyncEventListeners( )
   {
      if ( null == event_UnityEngine_GameObject_Instance_0 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_0 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_0 )
         {
            {
               uScript_Update component = event_UnityEngine_GameObject_Instance_0.GetComponent<uScript_Update>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_0.AddComponent<uScript_Update>();
               }
               if ( null != component )
               {
                  component.OnUpdate += Instance_OnUpdate_0;
                  component.OnLateUpdate += Instance_OnLateUpdate_0;
                  component.OnFixedUpdate += Instance_OnFixedUpdate_0;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != event_UnityEngine_GameObject_Instance_0 )
      {
         {
            uScript_Update component = event_UnityEngine_GameObject_Instance_0.GetComponent<uScript_Update>();
            if ( null != component )
            {
               component.OnUpdate -= Instance_OnUpdate_0;
               component.OnLateUpdate -= Instance_OnLateUpdate_0;
               component.OnFixedUpdate -= Instance_OnFixedUpdate_0;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_GetDistance_uScriptAct_GetDistance_1.SetParent(g);
      logic_uScriptCon_CompareFloat_uScriptCon_CompareFloat_4.SetParent(g);
      logic_uScriptAct_ClampFloat_uScriptAct_ClampFloat_6.SetParent(g);
      logic_uScriptAct_SetGameObjectPosition_uScriptAct_SetGameObjectPosition_9.SetParent(g);
      logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_11.SetParent(g);
      logic_uScriptAct_GetComponentsVector3_uScriptAct_GetComponentsVector3_12.SetParent(g);
      logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_13.SetParent(g);
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
   
   void Instance_OnUpdate_0(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUpdate_0( );
   }
   
   void Instance_OnLateUpdate_0(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnLateUpdate_0( );
   }
   
   void Instance_OnFixedUpdate_0(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnFixedUpdate_0( );
   }
   
   void Relay_OnUpdate_0()
   {
      if (true == CheckDebugBreak("5cf7a572-ff41-4492-a391-103626f63b61", "Global Update", Relay_OnUpdate_0)) return; 
      Relay_In_1();
   }
   
   void Relay_OnLateUpdate_0()
   {
      if (true == CheckDebugBreak("5cf7a572-ff41-4492-a391-103626f63b61", "Global Update", Relay_OnLateUpdate_0)) return; 
   }
   
   void Relay_OnFixedUpdate_0()
   {
      if (true == CheckDebugBreak("5cf7a572-ff41-4492-a391-103626f63b61", "Global Update", Relay_OnFixedUpdate_0)) return; 
   }
   
   void Relay_In_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("077ba1de-59df-4074-99a1-a4a1dd9335aa", "Get Distance", Relay_In_1)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_20_UnityEngine_GameObject_previous != local_20_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_20_UnityEngine_GameObject_previous = local_20_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_GetDistance_A_1 = local_20_UnityEngine_GameObject;
               
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
               logic_uScriptAct_GetDistance_B_1 = local_2_UnityEngine_GameObject;
               
            }
            {
            }
         }
         logic_uScriptAct_GetDistance_uScriptAct_GetDistance_1.In(logic_uScriptAct_GetDistance_A_1, logic_uScriptAct_GetDistance_B_1, out logic_uScriptAct_GetDistance_Distance_1);
         local_Player_Distance_System_Single = logic_uScriptAct_GetDistance_Distance_1;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetDistance_uScriptAct_GetDistance_1.Out;
         
         if ( test_0 == true )
         {
            Relay_In_4();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript ProximityDoor_DetectPositionGraph.uscript at Get Distance.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_4()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6cd5f51c-eac3-4d37-9e4d-472560a325ff", "Compare Float", Relay_In_4)) return; 
         {
            {
               logic_uScriptCon_CompareFloat_A_4 = local_Player_Distance_System_Single;
               
            }
            {
               logic_uScriptCon_CompareFloat_B_4 = local_Detection_Radius_System_Single;
               
            }
         }
         logic_uScriptCon_CompareFloat_uScriptCon_CompareFloat_4.In(logic_uScriptCon_CompareFloat_A_4, logic_uScriptCon_CompareFloat_B_4);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareFloat_uScriptCon_CompareFloat_4.LessThanOrEqualTo;
         
         if ( test_0 == true )
         {
            Relay_In_6();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript ProximityDoor_DetectPositionGraph.uscript at Compare Float.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d9e3e114-0885-47f6-aba4-f7c13235ebee", "Clamp Float", Relay_In_6)) return; 
         {
            {
               logic_uScriptAct_ClampFloat_Target_6 = local_Player_Distance_System_Single;
               
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
         logic_uScriptAct_ClampFloat_uScriptAct_ClampFloat_6.In(logic_uScriptAct_ClampFloat_Target_6, logic_uScriptAct_ClampFloat_Min_6, logic_uScriptAct_ClampFloat_Max_6, out logic_uScriptAct_ClampFloat_FloatResult_6, out logic_uScriptAct_ClampFloat_IntResult_6);
         local_Door_Height_System_Single = logic_uScriptAct_ClampFloat_FloatResult_6;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_ClampFloat_uScriptAct_ClampFloat_6.Out;
         
         if ( test_0 == true )
         {
            Relay_In_11();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript ProximityDoor_DetectPositionGraph.uscript at Clamp Float.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1263ddea-0adb-4e1a-b0b1-61a6e3e26ccc", "Set Position", Relay_In_9)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_10_UnityEngine_GameObject_previous != local_10_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_10_UnityEngine_GameObject_previous = local_10_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add(local_10_UnityEngine_GameObject);
               logic_uScriptAct_SetGameObjectPosition_Target_9 = properties.ToArray();
            }
            {
               logic_uScriptAct_SetGameObjectPosition_Position_9 = local_19_UnityEngine_Vector3;
               
            }
            {
            }
         }
         logic_uScriptAct_SetGameObjectPosition_uScriptAct_SetGameObjectPosition_9.In(logic_uScriptAct_SetGameObjectPosition_Target_9, logic_uScriptAct_SetGameObjectPosition_Position_9, logic_uScriptAct_SetGameObjectPosition_AsOffset_9);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript ProximityDoor_DetectPositionGraph.uscript at Set Position.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_11()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("31ec951d-5554-4249-9fa0-a5fe8cbd83b1", "Get Position and Rotation", Relay_In_11)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_14_UnityEngine_GameObject_previous != local_14_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_14_UnityEngine_GameObject_previous = local_14_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_GetPositionAndRotation_Target_11 = local_14_UnityEngine_GameObject;
               
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
         logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_11.In(logic_uScriptAct_GetPositionAndRotation_Target_11, logic_uScriptAct_GetPositionAndRotation_GetLocal_11, out logic_uScriptAct_GetPositionAndRotation_Position_11, out logic_uScriptAct_GetPositionAndRotation_Rotation_11, out logic_uScriptAct_GetPositionAndRotation_EulerAngles_11, out logic_uScriptAct_GetPositionAndRotation_Forward_11, out logic_uScriptAct_GetPositionAndRotation_Up_11, out logic_uScriptAct_GetPositionAndRotation_Right_11);
         local_15_UnityEngine_Vector3 = logic_uScriptAct_GetPositionAndRotation_Position_11;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_11.Out;
         
         if ( test_0 == true )
         {
            Relay_In_12();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript ProximityDoor_DetectPositionGraph.uscript at Get Position and Rotation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_12()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("019ec6e0-b038-4551-b5da-39aca4920dd6", "Get Components (Vector3)", Relay_In_12)) return; 
         {
            {
               logic_uScriptAct_GetComponentsVector3_InputVector3_12 = local_15_UnityEngine_Vector3;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_GetComponentsVector3_uScriptAct_GetComponentsVector3_12.In(logic_uScriptAct_GetComponentsVector3_InputVector3_12, out logic_uScriptAct_GetComponentsVector3_X_12, out logic_uScriptAct_GetComponentsVector3_Y_12, out logic_uScriptAct_GetComponentsVector3_Z_12);
         local_16_System_Single = logic_uScriptAct_GetComponentsVector3_X_12;
         local_17_System_Single = logic_uScriptAct_GetComponentsVector3_Z_12;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetComponentsVector3_uScriptAct_GetComponentsVector3_12.Out;
         
         if ( test_0 == true )
         {
            Relay_In_13();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript ProximityDoor_DetectPositionGraph.uscript at Get Components (Vector3).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_13()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ba91f045-31f2-4dd0-a5ea-b5c27a9cf546", "Set Components (Vector3)", Relay_In_13)) return; 
         {
            {
               logic_uScriptAct_SetComponentsVector3_X_13 = local_16_System_Single;
               
            }
            {
               logic_uScriptAct_SetComponentsVector3_Y_13 = local_Door_Height_System_Single;
               
            }
            {
               logic_uScriptAct_SetComponentsVector3_Z_13 = local_17_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_13.In(logic_uScriptAct_SetComponentsVector3_X_13, logic_uScriptAct_SetComponentsVector3_Y_13, logic_uScriptAct_SetComponentsVector3_Z_13, out logic_uScriptAct_SetComponentsVector3_OutputVector3_13);
         local_19_UnityEngine_Vector3 = logic_uScriptAct_SetComponentsVector3_OutputVector3_13;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_13.Out;
         
         if ( test_0 == true )
         {
            Relay_In_9();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript ProximityDoor_DetectPositionGraph.uscript at Set Components (Vector3).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ProximityDoor_DetectPositionGraph.uscript:2", local_2_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "6abcf3f0-00c1-4bec-80f6-9e1b0efdbc2e", local_2_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ProximityDoor_DetectPositionGraph.uscript:Detection Radius", local_Detection_Radius_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "fb8976bc-61ef-4f92-a30b-5a6a9dc6c50f", local_Detection_Radius_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ProximityDoor_DetectPositionGraph.uscript:Player Distance", local_Player_Distance_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a541835c-6199-46fa-a2c7-13cba524797b", local_Player_Distance_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ProximityDoor_DetectPositionGraph.uscript:10", local_10_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "0a8de0d9-1676-4124-b79a-027d21a31f83", local_10_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ProximityDoor_DetectPositionGraph.uscript:14", local_14_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "5d2966b8-8fc4-4ad4-9f41-0748007e06c0", local_14_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ProximityDoor_DetectPositionGraph.uscript:15", local_15_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "5a389494-4b3a-4204-a62c-b5de1d3c09d1", local_15_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ProximityDoor_DetectPositionGraph.uscript:16", local_16_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7f20378d-3d59-476d-8c6e-9da8da9906a1", local_16_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ProximityDoor_DetectPositionGraph.uscript:17", local_17_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "40117e52-584c-49a8-a35b-20bec9a9f5dc", local_17_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ProximityDoor_DetectPositionGraph.uscript:Door Height", local_Door_Height_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "30ff892c-49ce-4fc6-ad37-2dae09a0d4de", local_Door_Height_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ProximityDoor_DetectPositionGraph.uscript:19", local_19_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "743e473f-75f4-47cc-9d7e-1a84c26d8cdd", local_19_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ProximityDoor_DetectPositionGraph.uscript:20", local_20_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "292c0959-6766-4a7f-a53d-874ed29c4594", local_20_UnityEngine_GameObject);
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
