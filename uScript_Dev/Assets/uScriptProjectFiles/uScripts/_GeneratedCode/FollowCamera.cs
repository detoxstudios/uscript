//uScript Generated Code - Build 1.0.2830
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class FollowCamera : uScriptLogic
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
   [FriendlyName("Out")]
   public event uScriptEventHandler Out;
   
   //external parameters
   UnityEngine.GameObject external_35 = default(UnityEngine.GameObject);
   System.Single external_34 = (float) 0;
   System.Single external_33 = (float) 0;
   System.Object external_30 = "";
   System.Single external_32 = (float) 0;
   UnityEngine.GameObject[] external_31 = new UnityEngine.GameObject[] {};
   
   //local nodes
   UnityEngine.Vector3 local_10_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 local_11_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Quaternion local_12_UnityEngine_Quaternion = new Quaternion( (float)0, (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 local_13_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 local_15_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 local_18_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Quaternion local_19_UnityEngine_Quaternion = new Quaternion( (float)0, (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 local_23_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 local_24_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 local_28_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 local_7_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 local_8_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 local_9_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 local_Raw_unfiltered_camera_position_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_GetPositionAndRotation logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_0 = new uScriptAct_GetPositionAndRotation( );
   UnityEngine.GameObject logic_uScriptAct_GetPositionAndRotation_Target_0 = default(UnityEngine.GameObject);
   System.Boolean logic_uScriptAct_GetPositionAndRotation_GetLocal_0 = (bool) false;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Position_0;
   UnityEngine.Quaternion logic_uScriptAct_GetPositionAndRotation_Rotation_0;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_EulerAngles_0;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Forward_0;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Up_0;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Right_0;
   bool logic_uScriptAct_GetPositionAndRotation_Out_0 = true;
   //pointer to script instanced logic node
   uScriptAct_VectorsFromQuaternion logic_uScriptAct_VectorsFromQuaternion_uScriptAct_VectorsFromQuaternion_1 = new uScriptAct_VectorsFromQuaternion( );
   UnityEngine.Quaternion logic_uScriptAct_VectorsFromQuaternion_quaternion_1 = new Quaternion( );
   UnityEngine.Vector3 logic_uScriptAct_VectorsFromQuaternion_forward_1;
   UnityEngine.Vector3 logic_uScriptAct_VectorsFromQuaternion_up_1;
   UnityEngine.Vector3 logic_uScriptAct_VectorsFromQuaternion_right_1;
   bool logic_uScriptAct_VectorsFromQuaternion_Out_1 = true;
   //pointer to script instanced logic node
   uScriptAct_ScaleVector3 logic_uScriptAct_ScaleVector3_uScriptAct_ScaleVector3_2 = new uScriptAct_ScaleVector3( );
   UnityEngine.Vector3 logic_uScriptAct_ScaleVector3_v_2 = new Vector3( );
   System.Single logic_uScriptAct_ScaleVector3_s_2 = (float) 0;
   UnityEngine.Vector3 logic_uScriptAct_ScaleVector3_result_2;
   bool logic_uScriptAct_ScaleVector3_Out_2 = true;
   //pointer to script instanced logic node
   uScriptAct_SetComponentsVector3 logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_3 = new uScriptAct_SetComponentsVector3( );
   System.Single logic_uScriptAct_SetComponentsVector3_X_3 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsVector3_Y_3 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsVector3_Z_3 = (float) 0;
   UnityEngine.Vector3 logic_uScriptAct_SetComponentsVector3_OutputVector3_3;
   bool logic_uScriptAct_SetComponentsVector3_Out_3 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector3 logic_uScriptAct_AddVector3_uScriptAct_AddVector3_4 = new uScriptAct_AddVector3( );
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_A_4 = new Vector3[] {};
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_B_4 = new Vector3[] {};
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_Result_4;
   bool logic_uScriptAct_AddVector3_Out_4 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector3 logic_uScriptAct_AddVector3_uScriptAct_AddVector3_5 = new uScriptAct_AddVector3( );
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_A_5 = new Vector3[] {};
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_B_5 = new Vector3[] {};
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_Result_5;
   bool logic_uScriptAct_AddVector3_Out_5 = true;
   //pointer to script instanced logic node
   uScriptAct_ScaleVector3 logic_uScriptAct_ScaleVector3_uScriptAct_ScaleVector3_14 = new uScriptAct_ScaleVector3( );
   UnityEngine.Vector3 logic_uScriptAct_ScaleVector3_v_14 = new Vector3( );
   System.Single logic_uScriptAct_ScaleVector3_s_14 = (float) 0;
   UnityEngine.Vector3 logic_uScriptAct_ScaleVector3_result_14;
   bool logic_uScriptAct_ScaleVector3_Out_14 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector3 logic_uScriptAct_AddVector3_uScriptAct_AddVector3_16 = new uScriptAct_AddVector3( );
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_A_16 = new Vector3[] {};
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_B_16 = new Vector3[] {};
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_Result_16;
   bool logic_uScriptAct_AddVector3_Out_16 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector3 logic_uScriptAct_AddVector3_uScriptAct_AddVector3_17 = new uScriptAct_AddVector3( );
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_A_17 = new Vector3[] {};
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_B_17 = new Vector3[] {};
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_Result_17;
   bool logic_uScriptAct_AddVector3_Out_17 = true;
   //pointer to script instanced logic node
   uScriptAct_GetPositionAndRotation logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_20 = new uScriptAct_GetPositionAndRotation( );
   UnityEngine.GameObject logic_uScriptAct_GetPositionAndRotation_Target_20 = default(UnityEngine.GameObject);
   System.Boolean logic_uScriptAct_GetPositionAndRotation_GetLocal_20 = (bool) false;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Position_20;
   UnityEngine.Quaternion logic_uScriptAct_GetPositionAndRotation_Rotation_20;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_EulerAngles_20;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Forward_20;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Up_20;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Right_20;
   bool logic_uScriptAct_GetPositionAndRotation_Out_20 = true;
   //pointer to script instanced logic node
   uScriptAct_VectorsFromQuaternion logic_uScriptAct_VectorsFromQuaternion_uScriptAct_VectorsFromQuaternion_21 = new uScriptAct_VectorsFromQuaternion( );
   UnityEngine.Quaternion logic_uScriptAct_VectorsFromQuaternion_quaternion_21 = new Quaternion( );
   UnityEngine.Vector3 logic_uScriptAct_VectorsFromQuaternion_forward_21;
   UnityEngine.Vector3 logic_uScriptAct_VectorsFromQuaternion_up_21;
   UnityEngine.Vector3 logic_uScriptAct_VectorsFromQuaternion_right_21;
   bool logic_uScriptAct_VectorsFromQuaternion_Out_21 = true;
   //pointer to script instanced logic node
   uScriptAct_SetComponentsVector3 logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_22 = new uScriptAct_SetComponentsVector3( );
   System.Single logic_uScriptAct_SetComponentsVector3_X_22 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsVector3_Y_22 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsVector3_Z_22 = (float) 0;
   UnityEngine.Vector3 logic_uScriptAct_SetComponentsVector3_OutputVector3_22;
   bool logic_uScriptAct_SetComponentsVector3_Out_22 = true;
   //pointer to script instanced logic node
   uScriptAct_FilterVector logic_uScriptAct_FilterVector_uScriptAct_FilterVector_25 = new uScriptAct_FilterVector( );
   System.Object logic_uScriptAct_FilterVector_Target_25 = "";
   System.Single logic_uScriptAct_FilterVector_FilterConstant_25 = (float) 0;
   UnityEngine.Vector3 logic_uScriptAct_FilterVector_Value3_25;
   UnityEngine.Vector4 logic_uScriptAct_FilterVector_Value4_25;
   bool logic_uScriptAct_FilterVector_Out_25 = true;
   //pointer to script instanced logic node
   uScriptAct_SetGameObjectPosition logic_uScriptAct_SetGameObjectPosition_uScriptAct_SetGameObjectPosition_26 = new uScriptAct_SetGameObjectPosition( );
   UnityEngine.GameObject[] logic_uScriptAct_SetGameObjectPosition_Target_26 = new UnityEngine.GameObject[] {};
   UnityEngine.Vector3 logic_uScriptAct_SetGameObjectPosition_Position_26 = new Vector3( );
   System.Boolean logic_uScriptAct_SetGameObjectPosition_AsOffset_26 = (bool) false;
   System.Boolean logic_uScriptAct_SetGameObjectPosition_AsLocal_26 = (bool) false;
   bool logic_uScriptAct_SetGameObjectPosition_Out_26 = true;
   //pointer to script instanced logic node
   uScriptAct_LookAt logic_uScriptAct_LookAt_uScriptAct_LookAt_27 = new uScriptAct_LookAt( );
   UnityEngine.GameObject[] logic_uScriptAct_LookAt_Target_27 = new UnityEngine.GameObject[] {};
   System.Object logic_uScriptAct_LookAt_Focus_27 = "";
   System.Single logic_uScriptAct_LookAt_time_27 = (float) 0;
   uScriptAct_LookAt.LockAxis logic_uScriptAct_LookAt_lockAxis_27 = uScriptAct_LookAt.LockAxis.None;
   bool logic_uScriptAct_LookAt_Out_27 = true;
   
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
      
      logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_0.SetParent(g);
      logic_uScriptAct_VectorsFromQuaternion_uScriptAct_VectorsFromQuaternion_1.SetParent(g);
      logic_uScriptAct_ScaleVector3_uScriptAct_ScaleVector3_2.SetParent(g);
      logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_3.SetParent(g);
      logic_uScriptAct_AddVector3_uScriptAct_AddVector3_4.SetParent(g);
      logic_uScriptAct_AddVector3_uScriptAct_AddVector3_5.SetParent(g);
      logic_uScriptAct_ScaleVector3_uScriptAct_ScaleVector3_14.SetParent(g);
      logic_uScriptAct_AddVector3_uScriptAct_AddVector3_16.SetParent(g);
      logic_uScriptAct_AddVector3_uScriptAct_AddVector3_17.SetParent(g);
      logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_20.SetParent(g);
      logic_uScriptAct_VectorsFromQuaternion_uScriptAct_VectorsFromQuaternion_21.SetParent(g);
      logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_22.SetParent(g);
      logic_uScriptAct_FilterVector_uScriptAct_FilterVector_25.SetParent(g);
      logic_uScriptAct_SetGameObjectPosition_uScriptAct_SetGameObjectPosition_26.SetParent(g);
      logic_uScriptAct_LookAt_uScriptAct_LookAt_27.SetParent(g);
   }
   public void Awake()
   {
      
      logic_uScriptAct_LookAt_uScriptAct_LookAt_27.Finished += uScriptAct_LookAt_Finished_27;
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
      
      logic_uScriptAct_LookAt_uScriptAct_LookAt_27.Update( );
   }
   
   public void OnDestroy()
   {
      logic_uScriptAct_LookAt_uScriptAct_LookAt_27.Finished -= uScriptAct_LookAt_Finished_27;
   }
   
   void uScriptAct_LookAt_Finished_27(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_27( );
   }
   
   [FriendlyName("Reset Position", "")]
   public void Reset_Position( [FriendlyName("Follow Object", "")] UnityEngine.GameObject Follow_Object, [FriendlyName("Follow Distance", "")] System.Single Follow_Distance, [FriendlyName("Follow Height", "")] System.Single Follow_Height, [FriendlyName("Look At Object", "")] System.Object Look_At_Object, [FriendlyName("Filter Value", "")] System.Single Filter_Value, [FriendlyName("Camera", "")] UnityEngine.GameObject[] Camera )
   {
      
      external_35 = Follow_Object;
      external_34 = Follow_Distance;
      external_33 = Follow_Height;
      external_30 = Look_At_Object;
      external_32 = Filter_Value;
      external_31 = Camera;
      Relay_In_0( );
   }
   
   [FriendlyName("Update Position", "")]
   public void Update_Position( [FriendlyName("Follow Object", "")] UnityEngine.GameObject Follow_Object, [FriendlyName("Follow Distance", "")] System.Single Follow_Distance, [FriendlyName("Follow Height", "")] System.Single Follow_Height, [FriendlyName("Look At Object", "")] System.Object Look_At_Object, [FriendlyName("Filter Value", "")] System.Single Filter_Value, [FriendlyName("Camera", "")] UnityEngine.GameObject[] Camera )
   {
      
      external_35 = Follow_Object;
      external_34 = Follow_Distance;
      external_33 = Follow_Height;
      external_30 = Look_At_Object;
      external_32 = Filter_Value;
      external_31 = Camera;
      Relay_In_20( );
   }
   
   void Relay_In_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("78534c31-e3c4-4341-a86d-c766ea69ca16", "Get_Position_and_Rotation", Relay_In_0)) return; 
         {
            {
               logic_uScriptAct_GetPositionAndRotation_Target_0 = external_35;
               
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
         logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_0.In(logic_uScriptAct_GetPositionAndRotation_Target_0, logic_uScriptAct_GetPositionAndRotation_GetLocal_0, out logic_uScriptAct_GetPositionAndRotation_Position_0, out logic_uScriptAct_GetPositionAndRotation_Rotation_0, out logic_uScriptAct_GetPositionAndRotation_EulerAngles_0, out logic_uScriptAct_GetPositionAndRotation_Forward_0, out logic_uScriptAct_GetPositionAndRotation_Up_0, out logic_uScriptAct_GetPositionAndRotation_Right_0);
         local_11_UnityEngine_Vector3 = logic_uScriptAct_GetPositionAndRotation_Position_0;
         local_12_UnityEngine_Quaternion = logic_uScriptAct_GetPositionAndRotation_Rotation_0;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_0.Out;
         
         if ( test_0 == true )
         {
            Relay_In_1();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Get Position and Rotation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0d4fd339-b841-46fa-8ae1-bc349efb27ba", "Vectors_From_Quaternion", Relay_In_1)) return; 
         {
            {
               logic_uScriptAct_VectorsFromQuaternion_quaternion_1 = local_12_UnityEngine_Quaternion;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_VectorsFromQuaternion_uScriptAct_VectorsFromQuaternion_1.In(logic_uScriptAct_VectorsFromQuaternion_quaternion_1, out logic_uScriptAct_VectorsFromQuaternion_forward_1, out logic_uScriptAct_VectorsFromQuaternion_up_1, out logic_uScriptAct_VectorsFromQuaternion_right_1);
         local_10_UnityEngine_Vector3 = logic_uScriptAct_VectorsFromQuaternion_forward_1;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_VectorsFromQuaternion_uScriptAct_VectorsFromQuaternion_1.Out;
         
         if ( test_0 == true )
         {
            Relay_In_2();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Vectors From Quaternion.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1bf6c46a-ace1-4ab6-bd15-14641139d28b", "Scale_Vector3", Relay_In_2)) return; 
         {
            {
               logic_uScriptAct_ScaleVector3_v_2 = local_10_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_ScaleVector3_s_2 = external_34;
               
            }
            {
            }
         }
         logic_uScriptAct_ScaleVector3_uScriptAct_ScaleVector3_2.In(logic_uScriptAct_ScaleVector3_v_2, logic_uScriptAct_ScaleVector3_s_2, out logic_uScriptAct_ScaleVector3_result_2);
         local_9_UnityEngine_Vector3 = logic_uScriptAct_ScaleVector3_result_2;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_ScaleVector3_uScriptAct_ScaleVector3_2.Out;
         
         if ( test_0 == true )
         {
            Relay_In_3();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Scale Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("23fd76d7-99d6-4e9e-a628-78544c436abc", "Set_Components__Vector3_", Relay_In_3)) return; 
         {
            {
            }
            {
               logic_uScriptAct_SetComponentsVector3_Y_3 = external_33;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_3.In(logic_uScriptAct_SetComponentsVector3_X_3, logic_uScriptAct_SetComponentsVector3_Y_3, logic_uScriptAct_SetComponentsVector3_Z_3, out logic_uScriptAct_SetComponentsVector3_OutputVector3_3);
         local_8_UnityEngine_Vector3 = logic_uScriptAct_SetComponentsVector3_OutputVector3_3;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_3.Out;
         
         if ( test_0 == true )
         {
            Relay_In_4();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Set Components (Vector3).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_4()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("71056900-ddea-4f42-960c-75687ef9bbae", "Add_Vector3", Relay_In_4)) return; 
         {
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_11_UnityEngine_Vector3);
               logic_uScriptAct_AddVector3_A_4 = properties.ToArray();
            }
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_9_UnityEngine_Vector3);
               logic_uScriptAct_AddVector3_B_4 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_uScriptAct_AddVector3_4.In(logic_uScriptAct_AddVector3_A_4, logic_uScriptAct_AddVector3_B_4, out logic_uScriptAct_AddVector3_Result_4);
         local_7_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_Result_4;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_uScriptAct_AddVector3_4.Out;
         
         if ( test_0 == true )
         {
            Relay_In_5();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3e30a62d-ea61-4404-b987-21ac2329313d", "Add_Vector3", Relay_In_5)) return; 
         {
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_8_UnityEngine_Vector3);
               logic_uScriptAct_AddVector3_A_5 = properties.ToArray();
            }
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_7_UnityEngine_Vector3);
               logic_uScriptAct_AddVector3_B_5 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_uScriptAct_AddVector3_5.In(logic_uScriptAct_AddVector3_A_5, logic_uScriptAct_AddVector3_B_5, out logic_uScriptAct_AddVector3_Result_5);
         local_Raw_unfiltered_camera_position_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_Result_5;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_uScriptAct_AddVector3_5.Out;
         
         if ( test_0 == true )
         {
            Relay_Reset_25();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_14()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0b77edeb-e055-4932-a28f-bf72729f0a0b", "Scale_Vector3", Relay_In_14)) return; 
         {
            {
               logic_uScriptAct_ScaleVector3_v_14 = local_18_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_ScaleVector3_s_14 = external_34;
               
            }
            {
            }
         }
         logic_uScriptAct_ScaleVector3_uScriptAct_ScaleVector3_14.In(logic_uScriptAct_ScaleVector3_v_14, logic_uScriptAct_ScaleVector3_s_14, out logic_uScriptAct_ScaleVector3_result_14);
         local_15_UnityEngine_Vector3 = logic_uScriptAct_ScaleVector3_result_14;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_ScaleVector3_uScriptAct_ScaleVector3_14.Out;
         
         if ( test_0 == true )
         {
            Relay_In_22();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Scale Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_16()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("83aa72fc-ce56-4700-8a72-a6b5391c35a8", "Add_Vector3", Relay_In_16)) return; 
         {
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_13_UnityEngine_Vector3);
               logic_uScriptAct_AddVector3_A_16 = properties.ToArray();
            }
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_24_UnityEngine_Vector3);
               logic_uScriptAct_AddVector3_B_16 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_uScriptAct_AddVector3_16.In(logic_uScriptAct_AddVector3_A_16, logic_uScriptAct_AddVector3_B_16, out logic_uScriptAct_AddVector3_Result_16);
         local_Raw_unfiltered_camera_position_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_Result_16;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_uScriptAct_AddVector3_16.Out;
         
         if ( test_0 == true )
         {
            Relay_Filter_25();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_17()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9121d6e0-1a0e-4927-92c1-6670a5153bb6", "Add_Vector3", Relay_In_17)) return; 
         {
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_23_UnityEngine_Vector3);
               logic_uScriptAct_AddVector3_A_17 = properties.ToArray();
            }
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_15_UnityEngine_Vector3);
               logic_uScriptAct_AddVector3_B_17 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_uScriptAct_AddVector3_17.In(logic_uScriptAct_AddVector3_A_17, logic_uScriptAct_AddVector3_B_17, out logic_uScriptAct_AddVector3_Result_17);
         local_24_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_Result_17;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_uScriptAct_AddVector3_17.Out;
         
         if ( test_0 == true )
         {
            Relay_In_16();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_20()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3549075d-acff-4b0d-962b-9fdf417c082c", "Get_Position_and_Rotation", Relay_In_20)) return; 
         {
            {
               logic_uScriptAct_GetPositionAndRotation_Target_20 = external_35;
               
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
         logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_20.In(logic_uScriptAct_GetPositionAndRotation_Target_20, logic_uScriptAct_GetPositionAndRotation_GetLocal_20, out logic_uScriptAct_GetPositionAndRotation_Position_20, out logic_uScriptAct_GetPositionAndRotation_Rotation_20, out logic_uScriptAct_GetPositionAndRotation_EulerAngles_20, out logic_uScriptAct_GetPositionAndRotation_Forward_20, out logic_uScriptAct_GetPositionAndRotation_Up_20, out logic_uScriptAct_GetPositionAndRotation_Right_20);
         local_23_UnityEngine_Vector3 = logic_uScriptAct_GetPositionAndRotation_Position_20;
         local_19_UnityEngine_Quaternion = logic_uScriptAct_GetPositionAndRotation_Rotation_20;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_20.Out;
         
         if ( test_0 == true )
         {
            Relay_In_21();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Get Position and Rotation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_21()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6258056e-4ae8-43ac-a162-75b669923487", "Vectors_From_Quaternion", Relay_In_21)) return; 
         {
            {
               logic_uScriptAct_VectorsFromQuaternion_quaternion_21 = local_19_UnityEngine_Quaternion;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_VectorsFromQuaternion_uScriptAct_VectorsFromQuaternion_21.In(logic_uScriptAct_VectorsFromQuaternion_quaternion_21, out logic_uScriptAct_VectorsFromQuaternion_forward_21, out logic_uScriptAct_VectorsFromQuaternion_up_21, out logic_uScriptAct_VectorsFromQuaternion_right_21);
         local_18_UnityEngine_Vector3 = logic_uScriptAct_VectorsFromQuaternion_forward_21;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_VectorsFromQuaternion_uScriptAct_VectorsFromQuaternion_21.Out;
         
         if ( test_0 == true )
         {
            Relay_In_14();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Vectors From Quaternion.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_22()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2b4bbe79-fa6a-4d9d-9c2f-37e29dfc26bf", "Set_Components__Vector3_", Relay_In_22)) return; 
         {
            {
            }
            {
               logic_uScriptAct_SetComponentsVector3_Y_22 = external_33;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_22.In(logic_uScriptAct_SetComponentsVector3_X_22, logic_uScriptAct_SetComponentsVector3_Y_22, logic_uScriptAct_SetComponentsVector3_Z_22, out logic_uScriptAct_SetComponentsVector3_OutputVector3_22);
         local_13_UnityEngine_Vector3 = logic_uScriptAct_SetComponentsVector3_OutputVector3_22;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_22.Out;
         
         if ( test_0 == true )
         {
            Relay_In_17();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Set Components (Vector3).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Reset_25()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("84bd8b46-e35f-4566-b614-dae40904b04c", "Filter_Vector", Relay_Reset_25)) return; 
         {
            {
               logic_uScriptAct_FilterVector_Target_25 = local_Raw_unfiltered_camera_position_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_FilterVector_FilterConstant_25 = external_32;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_FilterVector_uScriptAct_FilterVector_25.Reset(logic_uScriptAct_FilterVector_Target_25, logic_uScriptAct_FilterVector_FilterConstant_25, out logic_uScriptAct_FilterVector_Value3_25, out logic_uScriptAct_FilterVector_Value4_25);
         local_28_UnityEngine_Vector3 = logic_uScriptAct_FilterVector_Value3_25;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_FilterVector_uScriptAct_FilterVector_25.Out;
         
         if ( test_0 == true )
         {
            Relay_In_26();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Filter Vector.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Filter_25()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("84bd8b46-e35f-4566-b614-dae40904b04c", "Filter_Vector", Relay_Filter_25)) return; 
         {
            {
               logic_uScriptAct_FilterVector_Target_25 = local_Raw_unfiltered_camera_position_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_FilterVector_FilterConstant_25 = external_32;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_FilterVector_uScriptAct_FilterVector_25.Filter(logic_uScriptAct_FilterVector_Target_25, logic_uScriptAct_FilterVector_FilterConstant_25, out logic_uScriptAct_FilterVector_Value3_25, out logic_uScriptAct_FilterVector_Value4_25);
         local_28_UnityEngine_Vector3 = logic_uScriptAct_FilterVector_Value3_25;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_FilterVector_uScriptAct_FilterVector_25.Out;
         
         if ( test_0 == true )
         {
            Relay_In_26();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Filter Vector.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_26()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c7675a15-a39f-42df-8c89-83a069b9fadd", "Set_Position", Relay_In_26)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               properties.AddRange(external_31);
               logic_uScriptAct_SetGameObjectPosition_Target_26 = properties.ToArray();
            }
            {
               logic_uScriptAct_SetGameObjectPosition_Position_26 = local_28_UnityEngine_Vector3;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SetGameObjectPosition_uScriptAct_SetGameObjectPosition_26.In(logic_uScriptAct_SetGameObjectPosition_Target_26, logic_uScriptAct_SetGameObjectPosition_Position_26, logic_uScriptAct_SetGameObjectPosition_AsOffset_26, logic_uScriptAct_SetGameObjectPosition_AsLocal_26);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetGameObjectPosition_uScriptAct_SetGameObjectPosition_26.Out;
         
         if ( test_0 == true )
         {
            Relay_In_27();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Set Position.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_27()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("35bebe5b-6892-4821-a5b6-7a5741312623", "Look_At", Relay_Finished_27)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Look At.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_27()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("35bebe5b-6892-4821-a5b6-7a5741312623", "Look_At", Relay_In_27)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               properties.AddRange(external_31);
               logic_uScriptAct_LookAt_Target_27 = properties.ToArray();
            }
            {
               logic_uScriptAct_LookAt_Focus_27 = external_30;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_LookAt_uScriptAct_LookAt_27.In(logic_uScriptAct_LookAt_Target_27, logic_uScriptAct_LookAt_Focus_27, logic_uScriptAct_LookAt_time_27, logic_uScriptAct_LookAt_lockAxis_27);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_LookAt_uScriptAct_LookAt_27.Out;
         
         if ( test_0 == true )
         {
            Relay_Connection_29();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Look At.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Connection_29()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6e9dfb19-76cb-4cd9-9741-b93717832800", "", Relay_Connection_29)) return; 
         if ( Out != null )
         {
            LogicEventArgs eventArgs = new LogicEventArgs( );
            Out( this, eventArgs );
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Out.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Connection_30()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("dc6bfc7c-3837-4f55-8a54-34d01a7569ef", "", Relay_Connection_30)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Look At Object.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Connection_31()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9c1738fc-eff7-4410-99d3-dfccd026c7ef", "", Relay_Connection_31)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Camera.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Connection_32()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("edcd070b-77ea-4cd2-843e-31e512757456", "", Relay_Connection_32)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Filter Value.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Connection_33()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f419229a-a57c-4f1b-a03f-f63c845c89b9", "", Relay_Connection_33)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Follow Height.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Connection_34()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ece575a2-622f-40c3-9ce3-cb4374899a9c", "", Relay_Connection_34)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Follow Distance.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Connection_35()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7b00e6c2-3acb-400f-b9aa-299ffa029742", "", Relay_Connection_35)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Follow Object.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Connection_36()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b9177f01-0354-4b61-8ece-2734b8a59cea", "", Relay_Connection_36)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Update Position.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Connection_37()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("046c3866-97bf-4635-9db3-bf26659bd125", "", Relay_Connection_37)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera.uscript at Reset Position.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FollowCamera.uscript:7", local_7_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "1bb832ec-2596-4c65-9e27-a01bba0059f6", local_7_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FollowCamera.uscript:8", local_8_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "cc8b80bd-3c6c-4893-8edb-fd38484f1c57", local_8_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FollowCamera.uscript:9", local_9_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "bb2cdc08-2b69-43da-bdeb-ec306381327a", local_9_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FollowCamera.uscript:10", local_10_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "6238c68d-54de-48f2-a39b-64609dfce1ac", local_10_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FollowCamera.uscript:11", local_11_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a9f5e8e0-eb6e-4829-aca4-8b500ebe0972", local_11_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FollowCamera.uscript:12", local_12_UnityEngine_Quaternion);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "472c4a23-fb57-415b-9faa-958865265a70", local_12_UnityEngine_Quaternion);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FollowCamera.uscript:13", local_13_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b9b1c51b-c5ea-437d-a474-aef51bfe304f", local_13_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FollowCamera.uscript:15", local_15_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "1d4afb5b-7d9d-4f5a-9b06-1f477671261a", local_15_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FollowCamera.uscript:18", local_18_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "0f43aca8-72d5-4549-9a81-c0ffd686eece", local_18_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FollowCamera.uscript:19", local_19_UnityEngine_Quaternion);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "50851465-0aea-4823-b087-3b36d31a58e9", local_19_UnityEngine_Quaternion);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FollowCamera.uscript:23", local_23_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "8f7ffcf4-52bb-4253-8eb9-3dbc303b7ade", local_23_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FollowCamera.uscript:24", local_24_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "dfaf6b19-bbc2-48b3-8dc6-3ea58169e713", local_24_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FollowCamera.uscript:28", local_28_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "fa7117af-aea6-4b9c-8181-f745aea6e915", local_28_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FollowCamera.uscript:Raw unfiltered camera position", local_Raw_unfiltered_camera_position_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7b782428-949c-477c-bb36-c9d10d039d2d", local_Raw_unfiltered_camera_position_UnityEngine_Vector3);
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
