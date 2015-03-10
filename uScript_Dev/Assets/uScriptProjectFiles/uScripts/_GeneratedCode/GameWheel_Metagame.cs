//uScript Generated Code - Build 1.0.2830
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class GameWheel_Metagame : uScriptLogic
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
   UnityEngine.GameObject local_24_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_24_UnityEngine_GameObject_previous = null;
   System.String local_31_System_String = "One";
   System.Int32 local_34_System_Int32 = (int) 1;
   System.Int32 local_35_System_Int32 = (int) 10;
   System.String local_36_System_String = "Ten";
   System.Int32 local_44_System_Int32 = (int) 25;
   System.String local_45_System_String = "TwentyFive";
   System.Int32 local_48_System_Int32 = (int) 100;
   System.String local_50_System_String = "OneHundred";
   System.String local_58_System_String = "Score:";
   System.String local_59_System_String = "";
   System.Single local_63_System_Single = (float) 0;
   UnityEngine.GameObject local_7_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_7_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_CurrentValue_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_CurrentValue_UnityEngine_GameObject_previous = null;
   System.String local_GOName_System_String = "";
   System.Int32 local_Score_System_Int32 = (int) 0;
   System.Boolean local_Slowing_System_Boolean = (bool) false;
   System.Boolean local_Spinning_System_Boolean = (bool) false;
   public System.Single WheelStopTime = (float) 4;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_GUIButton logic_uScriptAct_GUIButton_uScriptAct_GUIButton_1 = new uScriptAct_GUIButton( );
   System.String logic_uScriptAct_GUIButton_Text_1 = "Spin Wheel";
   System.Int32 logic_uScriptAct_GUIButton_identifier_1 = (int) 0;
   UnityEngine.Rect logic_uScriptAct_GUIButton_Position_1 = new Rect( (float)16, (float)96, (float)128, (float)24 );
   UnityEngine.Texture2D logic_uScriptAct_GUIButton_Texture_1 = default(UnityEngine.Texture2D);
   System.String logic_uScriptAct_GUIButton_ToolTip_1 = "";
   System.String logic_uScriptAct_GUIButton_guiStyle_1 = "";
   bool logic_uScriptAct_GUIButton_Out_1 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_2 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_2;
   bool logic_uScriptAct_SetBool_Out_2 = true;
   bool logic_uScriptAct_SetBool_SetTrue_2 = true;
   bool logic_uScriptAct_SetBool_SetFalse_2 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_3 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_3 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_3 = true;
   bool logic_uScriptCon_CompareBool_False_3 = true;
   //pointer to script instanced logic node
   uScriptAct_GUIButton logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6 = new uScriptAct_GUIButton( );
   System.String logic_uScriptAct_GUIButton_Text_6 = "Disabled";
   System.Int32 logic_uScriptAct_GUIButton_identifier_6 = (int) 0;
   UnityEngine.Rect logic_uScriptAct_GUIButton_Position_6 = new Rect( (float)16, (float)96, (float)128, (float)24 );
   UnityEngine.Texture2D logic_uScriptAct_GUIButton_Texture_6 = default(UnityEngine.Texture2D);
   System.String logic_uScriptAct_GUIButton_ToolTip_6 = "";
   System.String logic_uScriptAct_GUIButton_guiStyle_6 = "";
   bool logic_uScriptAct_GUIButton_Out_6 = true;
   //pointer to script instanced logic node
   uScriptAct_AddRelativeTorque logic_uScriptAct_AddRelativeTorque_uScriptAct_AddRelativeTorque_8 = new uScriptAct_AddRelativeTorque( );
   UnityEngine.GameObject logic_uScriptAct_AddRelativeTorque_Target_8 = default(UnityEngine.GameObject);
   UnityEngine.Vector3 logic_uScriptAct_AddRelativeTorque_Force_8 = new Vector3( (float)0, (float)30, (float)0 );
   System.Single logic_uScriptAct_AddRelativeTorque_Scale_8 = (float) 0;
   System.Boolean logic_uScriptAct_AddRelativeTorque_UseForceMode_8 = (bool) false;
   UnityEngine.ForceMode logic_uScriptAct_AddRelativeTorque_ForceModeType_8 = UnityEngine.ForceMode.Force;
   bool logic_uScriptAct_AddRelativeTorque_Out_8 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_10 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_10 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_10 = true;
   bool logic_uScriptCon_CompareBool_False_10 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_13 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_13 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_13 = true;
   bool logic_uScriptCon_CompareBool_False_13 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_14 = new uScriptAct_Delay( );
   System.Single logic_uScriptAct_Delay_Duration_14 = (float) 0;
   System.Boolean logic_uScriptAct_Delay_SingleFrame_14 = (bool) false;
   bool logic_uScriptAct_Delay_Immediate_14 = true;
   bool logic_uScriptAct_Delay_AfterDelay_14 = true;
   bool logic_uScriptAct_Delay_Stopped_14 = true;
   bool logic_uScriptAct_Delay_DrivenDelay_14 = false;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_15 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_15;
   bool logic_uScriptAct_SetBool_Out_15 = true;
   bool logic_uScriptAct_SetBool_SetTrue_15 = true;
   bool logic_uScriptAct_SetBool_SetFalse_15 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_18 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_18;
   bool logic_uScriptAct_SetBool_Out_18 = true;
   bool logic_uScriptAct_SetBool_SetTrue_18 = true;
   bool logic_uScriptAct_SetBool_SetFalse_18 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_19 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_19;
   bool logic_uScriptAct_SetBool_Out_19 = true;
   bool logic_uScriptAct_SetBool_SetTrue_19 = true;
   bool logic_uScriptAct_SetBool_SetFalse_19 = true;
   //pointer to script instanced logic node
   uScriptAct_InterpolateVector3LinearSmooth logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_21 = new uScriptAct_InterpolateVector3LinearSmooth( );
   UnityEngine.Vector3 logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_21 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_InterpolateVector3LinearSmooth_endValue_21 = new Vector3( (float)0, (float)0, (float)0 );
   System.Single logic_uScriptAct_InterpolateVector3LinearSmooth_time_21 = (float) 0;
   uScript_Lerper.LoopType logic_uScriptAct_InterpolateVector3LinearSmooth_loopType_21 = uScript_Lerper.LoopType.None;
   System.Single logic_uScriptAct_InterpolateVector3LinearSmooth_loopDelay_21 = (float) 0;
   System.Boolean logic_uScriptAct_InterpolateVector3LinearSmooth_smooth_21 = (bool) false;
   System.Int32 logic_uScriptAct_InterpolateVector3LinearSmooth_loopCount_21 = (int) -1;
   UnityEngine.Vector3 logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_21;
   bool logic_uScriptAct_InterpolateVector3LinearSmooth_Started_21 = true;
   bool logic_uScriptAct_InterpolateVector3LinearSmooth_Stopped_21 = true;
   bool logic_uScriptAct_InterpolateVector3LinearSmooth_Interpolating_21 = true;
   bool logic_uScriptAct_InterpolateVector3LinearSmooth_Finished_21 = true;
   bool logic_uScriptAct_InterpolateVector3LinearSmooth_Driven_21 = false;
   //pointer to script instanced logic node
   uScriptAct_SetGameObject logic_uScriptAct_SetGameObject_uScriptAct_SetGameObject_25 = new uScriptAct_SetGameObject( );
   UnityEngine.GameObject logic_uScriptAct_SetGameObject_Value_25 = default(UnityEngine.GameObject);
   UnityEngine.GameObject logic_uScriptAct_SetGameObject_TargetGameObject_25;
   bool logic_uScriptAct_SetGameObject_Out_25 = true;
   //pointer to script instanced logic node
   uScriptAct_GetGameObjectName logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_27 = new uScriptAct_GetGameObjectName( );
   UnityEngine.GameObject logic_uScriptAct_GetGameObjectName_gameObject_27 = default(UnityEngine.GameObject);
   System.String logic_uScriptAct_GetGameObjectName_name_27;
   bool logic_uScriptAct_GetGameObjectName_Out_27 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_30 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_30 = "";
   System.String logic_uScriptCon_CompareString_B_30 = "";
   bool logic_uScriptCon_CompareString_Same_30 = true;
   bool logic_uScriptCon_CompareString_Different_30 = true;
   //pointer to script instanced logic node
   uScriptAct_AddInt logic_uScriptAct_AddInt_uScriptAct_AddInt_32 = new uScriptAct_AddInt( );
   System.Int32[] logic_uScriptAct_AddInt_A_32 = new System.Int32[] {};
   System.Int32[] logic_uScriptAct_AddInt_B_32 = new System.Int32[] {};
   System.Int32 logic_uScriptAct_AddInt_IntResult_32;
   System.Single logic_uScriptAct_AddInt_FloatResult_32;
   bool logic_uScriptAct_AddInt_Out_32 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_37 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_37 = "";
   System.String logic_uScriptCon_CompareString_B_37 = "";
   bool logic_uScriptCon_CompareString_Same_37 = true;
   bool logic_uScriptCon_CompareString_Different_37 = true;
   //pointer to script instanced logic node
   uScriptAct_AddInt logic_uScriptAct_AddInt_uScriptAct_AddInt_38 = new uScriptAct_AddInt( );
   System.Int32[] logic_uScriptAct_AddInt_A_38 = new System.Int32[] {};
   System.Int32[] logic_uScriptAct_AddInt_B_38 = new System.Int32[] {};
   System.Int32 logic_uScriptAct_AddInt_IntResult_38;
   System.Single logic_uScriptAct_AddInt_FloatResult_38;
   bool logic_uScriptAct_AddInt_Out_38 = true;
   //pointer to script instanced logic node
   uScriptAct_AddInt logic_uScriptAct_AddInt_uScriptAct_AddInt_41 = new uScriptAct_AddInt( );
   System.Int32[] logic_uScriptAct_AddInt_A_41 = new System.Int32[] {};
   System.Int32[] logic_uScriptAct_AddInt_B_41 = new System.Int32[] {};
   System.Int32 logic_uScriptAct_AddInt_IntResult_41;
   System.Single logic_uScriptAct_AddInt_FloatResult_41;
   bool logic_uScriptAct_AddInt_Out_41 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_42 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_42 = "";
   System.String logic_uScriptCon_CompareString_B_42 = "";
   bool logic_uScriptCon_CompareString_Same_42 = true;
   bool logic_uScriptCon_CompareString_Different_42 = true;
   //pointer to script instanced logic node
   uScriptAct_AddInt logic_uScriptAct_AddInt_uScriptAct_AddInt_47 = new uScriptAct_AddInt( );
   System.Int32[] logic_uScriptAct_AddInt_A_47 = new System.Int32[] {};
   System.Int32[] logic_uScriptAct_AddInt_B_47 = new System.Int32[] {};
   System.Int32 logic_uScriptAct_AddInt_IntResult_47;
   System.Single logic_uScriptAct_AddInt_FloatResult_47;
   bool logic_uScriptAct_AddInt_Out_47 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_49 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_49 = "";
   System.String logic_uScriptCon_CompareString_B_49 = "";
   bool logic_uScriptCon_CompareString_Same_49 = true;
   bool logic_uScriptCon_CompareString_Different_49 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_53 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_53 = "Unknown GameObject: ";
   System.Object[] logic_uScriptAct_Log_Target_53 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_53 = "";
   bool logic_uScriptAct_Log_Out_53 = true;
   //pointer to script instanced logic node
   uScriptAct_GUILabel logic_uScriptAct_GUILabel_uScriptAct_GUILabel_55 = new uScriptAct_GUILabel( );
   System.String logic_uScriptAct_GUILabel_Text_55 = "";
   UnityEngine.Rect logic_uScriptAct_GUILabel_Position_55 = new Rect( (float)16, (float)140, (float)128, (float)32 );
   UnityEngine.Texture logic_uScriptAct_GUILabel_Texture_55 = default(UnityEngine.Texture);
   System.String logic_uScriptAct_GUILabel_ToolTip_55 = "";
   System.String logic_uScriptAct_GUILabel_guiStyle_55 = "";
   bool logic_uScriptAct_GUILabel_Out_55 = true;
   //pointer to script instanced logic node
   uScriptAct_Concatenate logic_uScriptAct_Concatenate_uScriptAct_Concatenate_56 = new uScriptAct_Concatenate( );
   System.Object[] logic_uScriptAct_Concatenate_A_56 = new System.Object[] {};
   System.Object[] logic_uScriptAct_Concatenate_B_56 = new System.Object[] {};
   System.String logic_uScriptAct_Concatenate_Separator_56 = " ";
   System.String logic_uScriptAct_Concatenate_Result_56;
   bool logic_uScriptAct_Concatenate_Out_56 = true;
   //pointer to script instanced logic node
   uScriptAct_SetRandomFloat logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_62 = new uScriptAct_SetRandomFloat( );
   System.Single logic_uScriptAct_SetRandomFloat_Min_62 = (float) 1.5;
   System.Single logic_uScriptAct_SetRandomFloat_Max_62 = (float) 3;
   System.Single logic_uScriptAct_SetRandomFloat_TargetFloat_62;
   bool logic_uScriptAct_SetRandomFloat_Out_62 = true;
   
   //event nodes
   System.Boolean event_UnityEngine_GameObject_GUIChanged_0 = (bool) false;
   System.String event_UnityEngine_GameObject_FocusedControl_0 = "";
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_0 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_9 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_131 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_131 = default(UnityEngine.GameObject);
   
   //property nodes
   UnityEngine.Vector3 property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_22 = new Vector3( );
   UnityEngine.GameObject property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_22 = default(UnityEngine.GameObject);
   UnityEngine.GameObject property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_22_previous = null;
   UnityEngine.Vector3 property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23 = new Vector3( );
   UnityEngine.GameObject property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_23 = default(UnityEngine.GameObject);
   UnityEngine.GameObject property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_23_previous = null;
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   UnityEngine.Vector3 property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_22_Get_Refresh( )
   {
      UnityEngine.Rigidbody component = property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_22.GetComponent<UnityEngine.Rigidbody>();
      if ( null != component )
      {
         return component.angularVelocity;
      }
      else
      {
         return new Vector3( );
      }
   }
   
   void property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_22_Set_Refresh( )
   {
      UnityEngine.Rigidbody component = property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_22.GetComponent<UnityEngine.Rigidbody>();
      if ( null != component )
      {
         component.angularVelocity = property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_22;
      }
   }
   
   UnityEngine.Vector3 property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23_Get_Refresh( )
   {
      UnityEngine.Rigidbody component = property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_23.GetComponent<UnityEngine.Rigidbody>();
      if ( null != component )
      {
         return component.angularVelocity;
      }
      else
      {
         return new Vector3( );
      }
   }
   
   void property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23_Set_Refresh( )
   {
      UnityEngine.Rigidbody component = property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_23.GetComponent<UnityEngine.Rigidbody>();
      if ( null != component )
      {
         component.angularVelocity = property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23;
      }
   }
   
   
   void SyncUnityHooks( )
   {
      if ( null == property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_22 || false == m_RegisteredForEvents )
      {
         property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_22 = GameObject.Find( "Disc" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_22_previous != property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_22 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_22_previous = property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_22;
         
         //setup new listeners
      }
      if ( null == property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_23 || false == m_RegisteredForEvents )
      {
         property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_23 = GameObject.Find( "Disc" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_23_previous != property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_23 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_23_previous = property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_23;
         
         //setup new listeners
      }
      SyncEventListeners( );
      if ( null == local_7_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_7_UnityEngine_GameObject = GameObject.Find( "Disc" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_7_UnityEngine_GameObject_previous != local_7_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_7_UnityEngine_GameObject_previous = local_7_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_24_UnityEngine_GameObject_previous != local_24_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_24_UnityEngine_GameObject_previous = local_24_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_CurrentValue_UnityEngine_GameObject_previous != local_CurrentValue_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_CurrentValue_UnityEngine_GameObject_previous = local_CurrentValue_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void RegisterForUnityHooks( )
   {
      //if our game object reference was changed then we need to reset event listeners
      if ( property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_22_previous != property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_22 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_22_previous = property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_22;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_23_previous != property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_23 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_23_previous = property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_23;
         
         //setup new listeners
      }
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_7_UnityEngine_GameObject_previous != local_7_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_7_UnityEngine_GameObject_previous = local_7_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_24_UnityEngine_GameObject_previous != local_24_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_24_UnityEngine_GameObject_previous = local_24_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_CurrentValue_UnityEngine_GameObject_previous != local_CurrentValue_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_CurrentValue_UnityEngine_GameObject_previous = local_CurrentValue_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void SyncEventListeners( )
   {
      {
         {
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_22_previous != property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_22 || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_22_previous = property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_22;
                  
                  //setup new listeners
               }
            }
         }
      }
      {
         {
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_23_previous != property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_23 || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_23_previous = property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_23;
                  
                  //setup new listeners
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_0 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_0 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_0 )
         {
            {
               if ( null == thisScriptsOnGuiListener )
               {
                  //OnGUI need unique listeners so calls like GUI.depth will work across uScripts
                  thisScriptsOnGuiListener = event_UnityEngine_GameObject_Instance_0.AddComponent<uScript_GUI>();
               }
               uScript_GUI component = thisScriptsOnGuiListener;
               if ( null != component )
               {
                  component.OnGui += Instance_OnGui_0;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_9 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_9 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_9 )
         {
            {
               uScript_Update component = event_UnityEngine_GameObject_Instance_9.GetComponent<uScript_Update>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_9.AddComponent<uScript_Update>();
               }
               if ( null != component )
               {
                  component.OnUpdate += Instance_OnUpdate_9;
                  component.OnLateUpdate += Instance_OnLateUpdate_9;
                  component.OnFixedUpdate += Instance_OnFixedUpdate_9;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_131 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_131 = GameObject.Find( "Needle" ) as UnityEngine.GameObject;
         if ( null != event_UnityEngine_GameObject_Instance_131 )
         {
            {
               uScript_Trigger component = event_UnityEngine_GameObject_Instance_131.GetComponent<uScript_Trigger>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_131.AddComponent<uScript_Trigger>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_131;
                  component.OnExitTrigger += Instance_OnExitTrigger_131;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_131;
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
            if ( null == thisScriptsOnGuiListener )
            {
               //OnGUI need unique listeners so calls like GUI.depth will work across uScripts
               thisScriptsOnGuiListener = event_UnityEngine_GameObject_Instance_0.AddComponent<uScript_GUI>();
            }
            uScript_GUI component = thisScriptsOnGuiListener;
            if ( null != component )
            {
               component.OnGui -= Instance_OnGui_0;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_9 )
      {
         {
            uScript_Update component = event_UnityEngine_GameObject_Instance_9.GetComponent<uScript_Update>();
            if ( null != component )
            {
               component.OnUpdate -= Instance_OnUpdate_9;
               component.OnLateUpdate -= Instance_OnLateUpdate_9;
               component.OnFixedUpdate -= Instance_OnFixedUpdate_9;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_131 )
      {
         {
            uScript_Trigger component = event_UnityEngine_GameObject_Instance_131.GetComponent<uScript_Trigger>();
            if ( null != component )
            {
               component.OnEnterTrigger -= Instance_OnEnterTrigger_131;
               component.OnExitTrigger -= Instance_OnExitTrigger_131;
               component.WhileInsideTrigger -= Instance_WhileInsideTrigger_131;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_1.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_2.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_3.SetParent(g);
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6.SetParent(g);
      logic_uScriptAct_AddRelativeTorque_uScriptAct_AddRelativeTorque_8.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_10.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_13.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_14.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_15.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_18.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_19.SetParent(g);
      logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_21.SetParent(g);
      logic_uScriptAct_SetGameObject_uScriptAct_SetGameObject_25.SetParent(g);
      logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_27.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_30.SetParent(g);
      logic_uScriptAct_AddInt_uScriptAct_AddInt_32.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_37.SetParent(g);
      logic_uScriptAct_AddInt_uScriptAct_AddInt_38.SetParent(g);
      logic_uScriptAct_AddInt_uScriptAct_AddInt_41.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_42.SetParent(g);
      logic_uScriptAct_AddInt_uScriptAct_AddInt_47.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_49.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_53.SetParent(g);
      logic_uScriptAct_GUILabel_uScriptAct_GUILabel_55.SetParent(g);
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_56.SetParent(g);
      logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_62.SetParent(g);
   }
   public void Awake()
   {
      
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_1.OnButtonDown += uScriptAct_GUIButton_OnButtonDown_1;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_1.OnButtonHeld += uScriptAct_GUIButton_OnButtonHeld_1;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_1.OnButtonUp += uScriptAct_GUIButton_OnButtonUp_1;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_1.OnButtonClicked += uScriptAct_GUIButton_OnButtonClicked_1;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6.OnButtonDown += uScriptAct_GUIButton_OnButtonDown_6;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6.OnButtonHeld += uScriptAct_GUIButton_OnButtonHeld_6;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6.OnButtonUp += uScriptAct_GUIButton_OnButtonUp_6;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6.OnButtonClicked += uScriptAct_GUIButton_OnButtonClicked_6;
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
      
      if (true == logic_uScriptAct_Delay_DrivenDelay_14)
      {
         Relay_DrivenDelay_14();
      }
      if (true == logic_uScriptAct_InterpolateVector3LinearSmooth_Driven_21)
      {
         Relay_Driven_21();
      }
   }
   
   public void OnDestroy()
   {
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_1.OnButtonDown -= uScriptAct_GUIButton_OnButtonDown_1;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_1.OnButtonHeld -= uScriptAct_GUIButton_OnButtonHeld_1;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_1.OnButtonUp -= uScriptAct_GUIButton_OnButtonUp_1;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_1.OnButtonClicked -= uScriptAct_GUIButton_OnButtonClicked_1;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6.OnButtonDown -= uScriptAct_GUIButton_OnButtonDown_6;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6.OnButtonHeld -= uScriptAct_GUIButton_OnButtonHeld_6;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6.OnButtonUp -= uScriptAct_GUIButton_OnButtonUp_6;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6.OnButtonClicked -= uScriptAct_GUIButton_OnButtonClicked_6;
   }
   
   void Instance_OnGui_0(object o, uScript_GUI.GUIEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GUIChanged_0 = e.GUIChanged;
      event_UnityEngine_GameObject_FocusedControl_0 = e.FocusedControl;
      //relay event to nodes
      Relay_OnGui_0( );
   }
   
   void Instance_OnUpdate_9(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUpdate_9( );
   }
   
   void Instance_OnLateUpdate_9(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnLateUpdate_9( );
   }
   
   void Instance_OnFixedUpdate_9(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnFixedUpdate_9( );
   }
   
   void Instance_OnEnterTrigger_131(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_131 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_131( );
   }
   
   void Instance_OnExitTrigger_131(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_131 = e.GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_131( );
   }
   
   void Instance_WhileInsideTrigger_131(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_131 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_131( );
   }
   
   void uScriptAct_GUIButton_OnButtonDown_1(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonDown_1( );
   }
   
   void uScriptAct_GUIButton_OnButtonHeld_1(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonHeld_1( );
   }
   
   void uScriptAct_GUIButton_OnButtonUp_1(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonUp_1( );
   }
   
   void uScriptAct_GUIButton_OnButtonClicked_1(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonClicked_1( );
   }
   
   void uScriptAct_GUIButton_OnButtonDown_6(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonDown_6( );
   }
   
   void uScriptAct_GUIButton_OnButtonHeld_6(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonHeld_6( );
   }
   
   void uScriptAct_GUIButton_OnButtonUp_6(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonUp_6( );
   }
   
   void uScriptAct_GUIButton_OnButtonClicked_6(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonClicked_6( );
   }
   
   void Relay_OnGui_0()
   {
      if (true == CheckDebugBreak("ee65abf7-7032-4aea-8c0d-3c9b55d6c385", "GUI_Events", Relay_OnGui_0)) return; 
      Relay_In_3();
      Relay_In_56();
   }
   
   void Relay_OnButtonDown_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("45e4976e-4411-47f7-b50a-94f80bda031b", "GUI_Button", Relay_OnButtonDown_1)) return; 
         Relay_True_2();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonHeld_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("45e4976e-4411-47f7-b50a-94f80bda031b", "GUI_Button", Relay_OnButtonHeld_1)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonUp_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("45e4976e-4411-47f7-b50a-94f80bda031b", "GUI_Button", Relay_OnButtonUp_1)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonClicked_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("45e4976e-4411-47f7-b50a-94f80bda031b", "GUI_Button", Relay_OnButtonClicked_1)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("45e4976e-4411-47f7-b50a-94f80bda031b", "GUI_Button", Relay_In_1)) return; 
         {
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
         logic_uScriptAct_GUIButton_uScriptAct_GUIButton_1.In(logic_uScriptAct_GUIButton_Text_1, logic_uScriptAct_GUIButton_identifier_1, logic_uScriptAct_GUIButton_Position_1, logic_uScriptAct_GUIButton_Texture_1, logic_uScriptAct_GUIButton_ToolTip_1, logic_uScriptAct_GUIButton_guiStyle_1);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9db2a079-9cca-472c-a62b-cf511b4d1b2b", "Set_Bool", Relay_True_2)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_2.True(out logic_uScriptAct_SetBool_Target_2);
         local_Spinning_System_Boolean = logic_uScriptAct_SetBool_Target_2;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_2.Out;
         
         if ( test_0 == true )
         {
            Relay_In_62();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9db2a079-9cca-472c-a62b-cf511b4d1b2b", "Set_Bool", Relay_False_2)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_2.False(out logic_uScriptAct_SetBool_Target_2);
         local_Spinning_System_Boolean = logic_uScriptAct_SetBool_Target_2;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_2.Out;
         
         if ( test_0 == true )
         {
            Relay_In_62();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("096955b8-d11a-4b0d-ab62-bf02618af1c1", "Compare_Bool", Relay_In_3)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_3 = local_Spinning_System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_3.In(logic_uScriptCon_CompareBool_Bool_3);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_3.True;
         bool test_1 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_3.False;
         
         if ( test_0 == true )
         {
            Relay_In_6();
         }
         if ( test_1 == true )
         {
            Relay_In_1();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonDown_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a6249012-af43-4990-83cc-b774ecfddff7", "GUI_Button", Relay_OnButtonDown_6)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonHeld_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a6249012-af43-4990-83cc-b774ecfddff7", "GUI_Button", Relay_OnButtonHeld_6)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonUp_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a6249012-af43-4990-83cc-b774ecfddff7", "GUI_Button", Relay_OnButtonUp_6)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonClicked_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a6249012-af43-4990-83cc-b774ecfddff7", "GUI_Button", Relay_OnButtonClicked_6)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a6249012-af43-4990-83cc-b774ecfddff7", "GUI_Button", Relay_In_6)) return; 
         {
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
         logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6.In(logic_uScriptAct_GUIButton_Text_6, logic_uScriptAct_GUIButton_identifier_6, logic_uScriptAct_GUIButton_Position_6, logic_uScriptAct_GUIButton_Texture_6, logic_uScriptAct_GUIButton_ToolTip_6, logic_uScriptAct_GUIButton_guiStyle_6);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_8()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7b34533a-b1e2-405c-97b7-c956f87626b5", "Add_Relative_Torque", Relay_In_8)) return; 
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
               logic_uScriptAct_AddRelativeTorque_Target_8 = local_7_UnityEngine_GameObject;
               
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
         logic_uScriptAct_AddRelativeTorque_uScriptAct_AddRelativeTorque_8.In(logic_uScriptAct_AddRelativeTorque_Target_8, logic_uScriptAct_AddRelativeTorque_Force_8, logic_uScriptAct_AddRelativeTorque_Scale_8, logic_uScriptAct_AddRelativeTorque_UseForceMode_8, logic_uScriptAct_AddRelativeTorque_ForceModeType_8);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Add Relative Torque.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnUpdate_9()
   {
      if (true == CheckDebugBreak("0832e513-8d2b-4479-bccf-3f1cd0e4ff14", "Global_Update", Relay_OnUpdate_9)) return; 
   }
   
   void Relay_OnLateUpdate_9()
   {
      if (true == CheckDebugBreak("0832e513-8d2b-4479-bccf-3f1cd0e4ff14", "Global_Update", Relay_OnLateUpdate_9)) return; 
   }
   
   void Relay_OnFixedUpdate_9()
   {
      if (true == CheckDebugBreak("0832e513-8d2b-4479-bccf-3f1cd0e4ff14", "Global_Update", Relay_OnFixedUpdate_9)) return; 
      Relay_In_10();
   }
   
   void Relay_In_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("dd84b8ff-33a8-46ea-8ffc-8dbf84315f45", "Compare_Bool", Relay_In_10)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_10 = local_Spinning_System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_10.In(logic_uScriptCon_CompareBool_Bool_10);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_10.True;
         
         if ( test_0 == true )
         {
            Relay_In_13();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_13()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("89fde440-27d3-4dba-b703-b2fc4b206a42", "Compare_Bool", Relay_In_13)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_13 = local_Slowing_System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_13.In(logic_uScriptCon_CompareBool_Bool_13);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_13.False;
         
         if ( test_0 == true )
         {
            Relay_In_8();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_14()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b4b42d68-5713-4d5a-9edb-a62c43cd9573", "Delay", Relay_In_14)) return; 
         {
            {
               logic_uScriptAct_Delay_Duration_14 = local_63_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_14.In(logic_uScriptAct_Delay_Duration_14, logic_uScriptAct_Delay_SingleFrame_14);
         logic_uScriptAct_Delay_DrivenDelay_14 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_14.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_True_15();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_14()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b4b42d68-5713-4d5a-9edb-a62c43cd9573", "Delay", Relay_Stop_14)) return; 
         {
            {
               logic_uScriptAct_Delay_Duration_14 = local_63_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_14.Stop(logic_uScriptAct_Delay_Duration_14, logic_uScriptAct_Delay_SingleFrame_14);
         logic_uScriptAct_Delay_DrivenDelay_14 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_14.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_True_15();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_DrivenDelay_14( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               logic_uScriptAct_Delay_Duration_14 = local_63_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_Delay_DrivenDelay_14 = logic_uScriptAct_Delay_uScriptAct_Delay_14.DrivenDelay();
         if ( true == logic_uScriptAct_Delay_DrivenDelay_14 )
         {
            if ( logic_uScriptAct_Delay_uScriptAct_Delay_14.AfterDelay == true )
            {
               Relay_True_15();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_True_15()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3e605a1e-573b-44f1-aa6d-b81402e33714", "Set_Bool", Relay_True_15)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_15.True(out logic_uScriptAct_SetBool_Target_15);
         local_Slowing_System_Boolean = logic_uScriptAct_SetBool_Target_15;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_15.Out;
         
         if ( test_0 == true )
         {
            Relay_Begin_21();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_15()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3e605a1e-573b-44f1-aa6d-b81402e33714", "Set_Bool", Relay_False_15)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_15.False(out logic_uScriptAct_SetBool_Target_15);
         local_Slowing_System_Boolean = logic_uScriptAct_SetBool_Target_15;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_15.Out;
         
         if ( test_0 == true )
         {
            Relay_Begin_21();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_18()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("70755466-1749-492f-b813-6d84f8e2a186", "Set_Bool", Relay_True_18)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_18.True(out logic_uScriptAct_SetBool_Target_18);
         local_Spinning_System_Boolean = logic_uScriptAct_SetBool_Target_18;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_18.Out;
         
         if ( test_0 == true )
         {
            Relay_False_19();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_18()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("70755466-1749-492f-b813-6d84f8e2a186", "Set_Bool", Relay_False_18)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_18.False(out logic_uScriptAct_SetBool_Target_18);
         local_Spinning_System_Boolean = logic_uScriptAct_SetBool_Target_18;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_18.Out;
         
         if ( test_0 == true )
         {
            Relay_False_19();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_19()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4f898b0f-bf01-4063-bcfe-64ccbae1640d", "Set_Bool", Relay_True_19)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_19.True(out logic_uScriptAct_SetBool_Target_19);
         local_Slowing_System_Boolean = logic_uScriptAct_SetBool_Target_19;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_19.Out;
         
         if ( test_0 == true )
         {
            Relay_In_27();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_19()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4f898b0f-bf01-4063-bcfe-64ccbae1640d", "Set_Bool", Relay_False_19)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_19.False(out logic_uScriptAct_SetBool_Target_19);
         local_Slowing_System_Boolean = logic_uScriptAct_SetBool_Target_19;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_19.Out;
         
         if ( test_0 == true )
         {
            Relay_In_27();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Begin_21()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5621d114-3076-41c4-9d13-8192510866e2", "Interpolate_Vector3_Linear__Smooth_", Relay_Begin_21)) return; 
         {
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_21 = property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_22_Get_Refresh( );
               
            }
            {
            }
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_time_21 = WheelStopTime;
               
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
         logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_21.Begin(logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_21, logic_uScriptAct_InterpolateVector3LinearSmooth_endValue_21, logic_uScriptAct_InterpolateVector3LinearSmooth_time_21, logic_uScriptAct_InterpolateVector3LinearSmooth_loopType_21, logic_uScriptAct_InterpolateVector3LinearSmooth_loopDelay_21, logic_uScriptAct_InterpolateVector3LinearSmooth_smooth_21, logic_uScriptAct_InterpolateVector3LinearSmooth_loopCount_21, out logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_21);
         logic_uScriptAct_InterpolateVector3LinearSmooth_Driven_21 = true;
         property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23 = logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_21;
         property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_21.Finished;
         
         if ( test_0 == true )
         {
            Relay_False_18();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Interpolate Vector3 Linear (Smooth).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_21()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5621d114-3076-41c4-9d13-8192510866e2", "Interpolate_Vector3_Linear__Smooth_", Relay_Stop_21)) return; 
         {
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_21 = property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_22_Get_Refresh( );
               
            }
            {
            }
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_time_21 = WheelStopTime;
               
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
         logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_21.Stop(logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_21, logic_uScriptAct_InterpolateVector3LinearSmooth_endValue_21, logic_uScriptAct_InterpolateVector3LinearSmooth_time_21, logic_uScriptAct_InterpolateVector3LinearSmooth_loopType_21, logic_uScriptAct_InterpolateVector3LinearSmooth_loopDelay_21, logic_uScriptAct_InterpolateVector3LinearSmooth_smooth_21, logic_uScriptAct_InterpolateVector3LinearSmooth_loopCount_21, out logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_21);
         logic_uScriptAct_InterpolateVector3LinearSmooth_Driven_21 = true;
         property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23 = logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_21;
         property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_21.Finished;
         
         if ( test_0 == true )
         {
            Relay_False_18();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Interpolate Vector3 Linear (Smooth).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Resume_21()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5621d114-3076-41c4-9d13-8192510866e2", "Interpolate_Vector3_Linear__Smooth_", Relay_Resume_21)) return; 
         {
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_21 = property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_22_Get_Refresh( );
               
            }
            {
            }
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_time_21 = WheelStopTime;
               
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
         logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_21.Resume(logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_21, logic_uScriptAct_InterpolateVector3LinearSmooth_endValue_21, logic_uScriptAct_InterpolateVector3LinearSmooth_time_21, logic_uScriptAct_InterpolateVector3LinearSmooth_loopType_21, logic_uScriptAct_InterpolateVector3LinearSmooth_loopDelay_21, logic_uScriptAct_InterpolateVector3LinearSmooth_smooth_21, logic_uScriptAct_InterpolateVector3LinearSmooth_loopCount_21, out logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_21);
         logic_uScriptAct_InterpolateVector3LinearSmooth_Driven_21 = true;
         property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23 = logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_21;
         property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_21.Finished;
         
         if ( test_0 == true )
         {
            Relay_False_18();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Interpolate Vector3 Linear (Smooth).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Driven_21( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_21 = property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_22_Get_Refresh( );
               
            }
            {
            }
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_time_21 = WheelStopTime;
               
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
         logic_uScriptAct_InterpolateVector3LinearSmooth_Driven_21 = logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_21.Driven(out logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_21);
         if ( true == logic_uScriptAct_InterpolateVector3LinearSmooth_Driven_21 )
         {
            property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23 = logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_21;
            property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23_Set_Refresh( );
            if ( logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_21.Finished == true )
            {
               Relay_False_18();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Interpolate Vector3 Linear (Smooth).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_In_25()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8897f303-b839-4859-ab10-7dbf7a6ad243", "Set_GameObject", Relay_In_25)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_24_UnityEngine_GameObject_previous != local_24_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_24_UnityEngine_GameObject_previous = local_24_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_SetGameObject_Value_25 = local_24_UnityEngine_GameObject;
               
            }
            {
            }
         }
         logic_uScriptAct_SetGameObject_uScriptAct_SetGameObject_25.In(logic_uScriptAct_SetGameObject_Value_25, out logic_uScriptAct_SetGameObject_TargetGameObject_25);
         local_CurrentValue_UnityEngine_GameObject = logic_uScriptAct_SetGameObject_TargetGameObject_25;
         {
            //if our game object reference was changed then we need to reset event listeners
            if ( local_CurrentValue_UnityEngine_GameObject_previous != local_CurrentValue_UnityEngine_GameObject || false == m_RegisteredForEvents )
            {
               //tear down old listeners
               
               local_CurrentValue_UnityEngine_GameObject_previous = local_CurrentValue_UnityEngine_GameObject;
               
               //setup new listeners
            }
         }
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Set GameObject.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_27()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0de8f7e8-5fc2-4b13-9c48-f512d77d6e21", "Get_GameObject_Name", Relay_In_27)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_CurrentValue_UnityEngine_GameObject_previous != local_CurrentValue_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_CurrentValue_UnityEngine_GameObject_previous = local_CurrentValue_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_GetGameObjectName_gameObject_27 = local_CurrentValue_UnityEngine_GameObject;
               
            }
            {
            }
         }
         logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_27.In(logic_uScriptAct_GetGameObjectName_gameObject_27, out logic_uScriptAct_GetGameObjectName_name_27);
         local_GOName_System_String = logic_uScriptAct_GetGameObjectName_name_27;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_27.Out;
         
         if ( test_0 == true )
         {
            Relay_In_30();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Get GameObject Name.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_30()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2e217ec9-c325-4c04-aaf8-9012aa89a50d", "Compare_String", Relay_In_30)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_30 = local_GOName_System_String;
               
            }
            {
               logic_uScriptCon_CompareString_B_30 = local_31_System_String;
               
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_30.In(logic_uScriptCon_CompareString_A_30, logic_uScriptCon_CompareString_B_30);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_30.Same;
         bool test_1 = logic_uScriptCon_CompareString_uScriptCon_CompareString_30.Different;
         
         if ( test_0 == true )
         {
            Relay_In_32();
         }
         if ( test_1 == true )
         {
            Relay_In_37();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_32()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("58972c6a-0935-4eb0-ac27-25225a8389c9", "Add_Int", Relay_In_32)) return; 
         {
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_34_System_Int32);
               logic_uScriptAct_AddInt_A_32 = properties.ToArray();
            }
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_Score_System_Int32);
               logic_uScriptAct_AddInt_B_32 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddInt_uScriptAct_AddInt_32.In(logic_uScriptAct_AddInt_A_32, logic_uScriptAct_AddInt_B_32, out logic_uScriptAct_AddInt_IntResult_32, out logic_uScriptAct_AddInt_FloatResult_32);
         local_Score_System_Int32 = logic_uScriptAct_AddInt_IntResult_32;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Add Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_37()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b3bc9ebb-dc4c-4411-b2a8-1e7c6bd7c9da", "Compare_String", Relay_In_37)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_37 = local_GOName_System_String;
               
            }
            {
               logic_uScriptCon_CompareString_B_37 = local_36_System_String;
               
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_37.In(logic_uScriptCon_CompareString_A_37, logic_uScriptCon_CompareString_B_37);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_37.Same;
         bool test_1 = logic_uScriptCon_CompareString_uScriptCon_CompareString_37.Different;
         
         if ( test_0 == true )
         {
            Relay_In_38();
         }
         if ( test_1 == true )
         {
            Relay_In_42();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_38()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c704c62b-1ad4-4dba-8b5a-4ef4670add8d", "Add_Int", Relay_In_38)) return; 
         {
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_35_System_Int32);
               logic_uScriptAct_AddInt_A_38 = properties.ToArray();
            }
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_Score_System_Int32);
               logic_uScriptAct_AddInt_B_38 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddInt_uScriptAct_AddInt_38.In(logic_uScriptAct_AddInt_A_38, logic_uScriptAct_AddInt_B_38, out logic_uScriptAct_AddInt_IntResult_38, out logic_uScriptAct_AddInt_FloatResult_38);
         local_Score_System_Int32 = logic_uScriptAct_AddInt_IntResult_38;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Add Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_41()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("94c2a7b4-7bde-41d6-a09a-25afc4a4673f", "Add_Int", Relay_In_41)) return; 
         {
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_44_System_Int32);
               logic_uScriptAct_AddInt_A_41 = properties.ToArray();
            }
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_Score_System_Int32);
               logic_uScriptAct_AddInt_B_41 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddInt_uScriptAct_AddInt_41.In(logic_uScriptAct_AddInt_A_41, logic_uScriptAct_AddInt_B_41, out logic_uScriptAct_AddInt_IntResult_41, out logic_uScriptAct_AddInt_FloatResult_41);
         local_Score_System_Int32 = logic_uScriptAct_AddInt_IntResult_41;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Add Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_42()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3fd06310-bccd-46c1-88b9-58ffb94964bf", "Compare_String", Relay_In_42)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_42 = local_GOName_System_String;
               
            }
            {
               logic_uScriptCon_CompareString_B_42 = local_45_System_String;
               
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_42.In(logic_uScriptCon_CompareString_A_42, logic_uScriptCon_CompareString_B_42);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_42.Same;
         bool test_1 = logic_uScriptCon_CompareString_uScriptCon_CompareString_42.Different;
         
         if ( test_0 == true )
         {
            Relay_In_41();
         }
         if ( test_1 == true )
         {
            Relay_In_49();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_47()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a8757f5b-b3df-41a1-8982-b6c0d314d9ff", "Add_Int", Relay_In_47)) return; 
         {
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_48_System_Int32);
               logic_uScriptAct_AddInt_A_47 = properties.ToArray();
            }
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_Score_System_Int32);
               logic_uScriptAct_AddInt_B_47 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddInt_uScriptAct_AddInt_47.In(logic_uScriptAct_AddInt_A_47, logic_uScriptAct_AddInt_B_47, out logic_uScriptAct_AddInt_IntResult_47, out logic_uScriptAct_AddInt_FloatResult_47);
         local_Score_System_Int32 = logic_uScriptAct_AddInt_IntResult_47;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Add Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_49()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c069ca36-bfe9-4fb1-9b54-ef35023086fb", "Compare_String", Relay_In_49)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_49 = local_GOName_System_String;
               
            }
            {
               logic_uScriptCon_CompareString_B_49 = local_50_System_String;
               
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_49.In(logic_uScriptCon_CompareString_A_49, logic_uScriptCon_CompareString_B_49);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_49.Same;
         bool test_1 = logic_uScriptCon_CompareString_uScriptCon_CompareString_49.Different;
         
         if ( test_0 == true )
         {
            Relay_In_47();
         }
         if ( test_1 == true )
         {
            Relay_In_53();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_53()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("72cd5225-546b-4661-8c5f-4a0745ecc475", "Log", Relay_In_53)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_GOName_System_String);
               logic_uScriptAct_Log_Target_53 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_53.In(logic_uScriptAct_Log_Prefix_53, logic_uScriptAct_Log_Target_53, logic_uScriptAct_Log_Postfix_53);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_55()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("aba1fc5b-5479-409c-b9b7-912b9692fb52", "GUI_Label", Relay_In_55)) return; 
         {
            {
               logic_uScriptAct_GUILabel_Text_55 = local_59_System_String;
               
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
         logic_uScriptAct_GUILabel_uScriptAct_GUILabel_55.In(logic_uScriptAct_GUILabel_Text_55, logic_uScriptAct_GUILabel_Position_55, logic_uScriptAct_GUILabel_Texture_55, logic_uScriptAct_GUILabel_ToolTip_55, logic_uScriptAct_GUILabel_guiStyle_55);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at GUI Label.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_56()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("38bb4a7d-fcb5-4f15-9d79-5711414e7b2e", "Concatenate", Relay_In_56)) return; 
         {
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_58_System_String);
               logic_uScriptAct_Concatenate_A_56 = properties.ToArray();
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_Score_System_Int32);
               logic_uScriptAct_Concatenate_B_56 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_Concatenate_uScriptAct_Concatenate_56.In(logic_uScriptAct_Concatenate_A_56, logic_uScriptAct_Concatenate_B_56, logic_uScriptAct_Concatenate_Separator_56, out logic_uScriptAct_Concatenate_Result_56);
         local_59_System_String = logic_uScriptAct_Concatenate_Result_56;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Concatenate_uScriptAct_Concatenate_56.Out;
         
         if ( test_0 == true )
         {
            Relay_In_55();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Concatenate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_62()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("87cc237d-347b-4609-b1f6-2024d770a3b5", "Set_Random_Float", Relay_In_62)) return; 
         {
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_62.In(logic_uScriptAct_SetRandomFloat_Min_62, logic_uScriptAct_SetRandomFloat_Max_62, out logic_uScriptAct_SetRandomFloat_TargetFloat_62);
         local_63_System_Single = logic_uScriptAct_SetRandomFloat_TargetFloat_62;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_62.Out;
         
         if ( test_0 == true )
         {
            Relay_In_14();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Set Random Float.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnEnterTrigger_131()
   {
      if (true == CheckDebugBreak("6d46d0a9-a967-41bc-bb54-5642bd414dfe", "Trigger_Event", Relay_OnEnterTrigger_131)) return; 
      local_24_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_131;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_24_UnityEngine_GameObject_previous != local_24_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_24_UnityEngine_GameObject_previous = local_24_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
      Relay_In_25();
   }
   
   void Relay_OnExitTrigger_131()
   {
      if (true == CheckDebugBreak("6d46d0a9-a967-41bc-bb54-5642bd414dfe", "Trigger_Event", Relay_OnExitTrigger_131)) return; 
      local_24_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_131;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_24_UnityEngine_GameObject_previous != local_24_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_24_UnityEngine_GameObject_previous = local_24_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
   }
   
   void Relay_WhileInsideTrigger_131()
   {
      if (true == CheckDebugBreak("6d46d0a9-a967-41bc-bb54-5642bd414dfe", "Trigger_Event", Relay_WhileInsideTrigger_131)) return; 
      local_24_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_131;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_24_UnityEngine_GameObject_previous != local_24_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_24_UnityEngine_GameObject_previous = local_24_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:7", local_7_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "8b07f182-b07d-416f-a6a5-5325d86d418e", local_7_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:Spinning", local_Spinning_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "acef3158-76f3-4bd5-b4bf-9005a18a4c0d", local_Spinning_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:Slowing", local_Slowing_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "cb44b0a8-e56e-4c7f-96c6-500848938713", local_Slowing_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:24", local_24_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "436e5068-d843-4ae9-9d36-026b15bd5131", local_24_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:CurrentValue", local_CurrentValue_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "8b8771de-93e1-4bdf-a064-8d2f5a94229f", local_CurrentValue_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:31", local_31_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "9e28b93d-c717-4086-b369-dbb5f2cac6e5", local_31_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:34", local_34_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "accb283c-684c-455f-9a34-4617651abd35", local_34_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:35", local_35_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "09e60717-75e0-4b5d-a7aa-7d075d2b62b6", local_35_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:36", local_36_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "678ab3cb-756b-471f-b3fa-6285b780c3d9", local_36_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:44", local_44_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "3f68dd0a-4c93-470f-885a-ee28a66a0f68", local_44_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:45", local_45_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "38c63d5a-f75f-412e-9587-369f5703c2a8", local_45_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:48", local_48_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "4e911b8d-3747-4143-8536-51e752a0a569", local_48_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:50", local_50_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f6feb0e1-184f-4a85-b60c-cba8582152c5", local_50_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:GOName", local_GOName_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "244f9dcd-4e08-47ae-a9e0-2ba2ac858993", local_GOName_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:Score", local_Score_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "6e376bad-cb86-4e1f-91d3-0dc144a4dc07", local_Score_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:58", local_58_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d49906b5-32c5-4b48-a010-c9e7975082c1", local_58_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:59", local_59_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "65629ed2-1b69-4640-a24d-470a015fa3e4", local_59_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:WheelStopTime", WheelStopTime);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "05679969-9812-40a2-95b6-f4416e6fce84", WheelStopTime);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:63", local_63_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "9ed6af8f-97f6-49ff-b33b-a2704fb62a4e", local_63_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "42f73233-1248-40b6-952a-f4cd23b040ae", property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_22);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7f2e56a3-9d34-4f36-a533-7f7992bc8356", property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23);
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
