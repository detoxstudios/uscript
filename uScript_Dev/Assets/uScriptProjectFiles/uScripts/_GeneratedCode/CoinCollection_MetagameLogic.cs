//uScript Generated Code - Build 1.0.2830
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class CoinCollection_MetagameLogic : uScriptLogic
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
   UnityEngine.GameObject local_11_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_11_UnityEngine_GameObject_previous = null;
   UnityEngine.Vector3 local_12_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.GameObject local_3_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_3_UnityEngine_GameObject_previous = null;
   System.String local_31_System_String = "Coins:";
   System.String local_32_System_String = "";
   System.String local_33_System_String = "GiveCoins";
   System.String local_35_System_String = "";
   UnityEngine.GameObject local_44_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_44_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_45_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_45_UnityEngine_GameObject_previous = null;
   UnityEngine.Vector3 local_9_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   System.Boolean local_Attach_Camera_System_Boolean = (bool) false;
   UnityEngine.Vector3 local_Camera_Offset_UnityEngine_Vector3 = new Vector3( (float)-5, (float)10, (float)0 );
   System.Int32 local_CoinTotal_System_Int32 = (int) 0;
   System.Int32 local_CoinValue_System_Int32 = (int) 0;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_SetVector3 logic_uScriptAct_SetVector3_uScriptAct_SetVector3_2 = new uScriptAct_SetVector3( );
   UnityEngine.Vector3 logic_uScriptAct_SetVector3_Value_2 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_SetVector3_TargetVector3_2;
   bool logic_uScriptAct_SetVector3_Out_2 = true;
   //pointer to script instanced logic node
   uScriptAct_SetGameObjectEulerAngles logic_uScriptAct_SetGameObjectEulerAngles_uScriptAct_SetGameObjectEulerAngles_4 = new uScriptAct_SetGameObjectEulerAngles( );
   UnityEngine.GameObject[] logic_uScriptAct_SetGameObjectEulerAngles_Target_4 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_SetGameObjectEulerAngles_X_Axis_4 = (float) 57;
   System.Boolean logic_uScriptAct_SetGameObjectEulerAngles_PreserveX_Axis_4 = (bool) false;
   System.Single logic_uScriptAct_SetGameObjectEulerAngles_Y_Axis_4 = (float) 99;
   System.Boolean logic_uScriptAct_SetGameObjectEulerAngles_PreserveY_Axis_4 = (bool) false;
   System.Single logic_uScriptAct_SetGameObjectEulerAngles_Z_Axis_4 = (float) 0;
   System.Boolean logic_uScriptAct_SetGameObjectEulerAngles_PreserveZ_Axis_4 = (bool) false;
   System.Boolean logic_uScriptAct_SetGameObjectEulerAngles_AsLocal_4 = (bool) false;
   bool logic_uScriptAct_SetGameObjectEulerAngles_Out_4 = true;
   //pointer to script instanced logic node
   uScriptAct_LookAt logic_uScriptAct_LookAt_uScriptAct_LookAt_5 = new uScriptAct_LookAt( );
   UnityEngine.GameObject[] logic_uScriptAct_LookAt_Target_5 = new UnityEngine.GameObject[] {};
   System.Object logic_uScriptAct_LookAt_Focus_5 = "";
   System.Single logic_uScriptAct_LookAt_time_5 = (float) 0;
   uScriptAct_LookAt.LockAxis logic_uScriptAct_LookAt_lockAxis_5 = uScriptAct_LookAt.LockAxis.None;
   bool logic_uScriptAct_LookAt_Out_5 = true;
   //pointer to script instanced logic node
   uScriptCon_Switch logic_uScriptCon_Switch_uScriptCon_Switch_6 = new uScriptCon_Switch( );
   System.Boolean logic_uScriptCon_Switch_Loop_6 = (bool) true;
   System.Int32 logic_uScriptCon_Switch_MaxOutputUsed_6 = (int) 2;
   System.Int32 logic_uScriptCon_Switch_CurrentOutput_6;
   bool logic_uScriptCon_Switch_Output1_6 = true;
   bool logic_uScriptCon_Switch_Output2_6 = true;
   bool logic_uScriptCon_Switch_Output3_6 = true;
   bool logic_uScriptCon_Switch_Output4_6 = true;
   bool logic_uScriptCon_Switch_Output5_6 = true;
   bool logic_uScriptCon_Switch_Output6_6 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector3 logic_uScriptAct_AddVector3_uScriptAct_AddVector3_7 = new uScriptAct_AddVector3( );
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_A_7 = new Vector3[] {};
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_B_7 = new Vector3[] {};
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_Result_7;
   bool logic_uScriptAct_AddVector3_Out_7 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_10 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_10 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_10 = true;
   bool logic_uScriptCon_CompareBool_False_10 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_15 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_15 = UnityEngine.KeyCode.C;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_15 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_15 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_15 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_16 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_16;
   bool logic_uScriptAct_SetBool_Out_16 = true;
   bool logic_uScriptAct_SetBool_SetTrue_16 = true;
   bool logic_uScriptAct_SetBool_SetFalse_16 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_19 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_19 = "Camera attached: ";
   System.Object[] logic_uScriptAct_Log_Target_19 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_19 = "";
   bool logic_uScriptAct_Log_Out_19 = true;
   //pointer to script instanced logic node
   uScriptAct_SetGameObjectPosition logic_uScriptAct_SetGameObjectPosition_uScriptAct_SetGameObjectPosition_20 = new uScriptAct_SetGameObjectPosition( );
   UnityEngine.GameObject[] logic_uScriptAct_SetGameObjectPosition_Target_20 = new UnityEngine.GameObject[] {};
   UnityEngine.Vector3 logic_uScriptAct_SetGameObjectPosition_Position_20 = new Vector3( (float)-14, (float)19, (float)1 );
   System.Boolean logic_uScriptAct_SetGameObjectPosition_AsOffset_20 = (bool) false;
   System.Boolean logic_uScriptAct_SetGameObjectPosition_AsLocal_20 = (bool) false;
   bool logic_uScriptAct_SetGameObjectPosition_Out_20 = true;
   //pointer to script instanced logic node
   uScriptAct_GetPositionAndRotation logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_21 = new uScriptAct_GetPositionAndRotation( );
   UnityEngine.GameObject logic_uScriptAct_GetPositionAndRotation_Target_21 = default(UnityEngine.GameObject);
   System.Boolean logic_uScriptAct_GetPositionAndRotation_GetLocal_21 = (bool) false;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Position_21;
   UnityEngine.Quaternion logic_uScriptAct_GetPositionAndRotation_Rotation_21;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_EulerAngles_21;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Forward_21;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Up_21;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Right_21;
   bool logic_uScriptAct_GetPositionAndRotation_Out_21 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_24 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_24 = "Press W, A, S, D to move. Spacebar for Jump.";
   System.Int32 logic_uScriptAct_PrintText_FontSize_24 = (int) 16;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_24 = UnityEngine.FontStyle.Normal;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_24 = new UnityEngine.Color( (float)1, (float)1, (float)1, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_24 = UnityEngine.TextAnchor.UpperCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_24 = (int) 16;
   System.Single logic_uScriptAct_PrintText_time_24 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_24 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_25 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_25 = "Press C to toggle cameras.";
   System.Int32 logic_uScriptAct_PrintText_FontSize_25 = (int) 16;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_25 = UnityEngine.FontStyle.Normal;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_25 = new UnityEngine.Color( (float)1, (float)1, (float)1, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_25 = UnityEngine.TextAnchor.UpperCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_25 = (int) 64;
   System.Single logic_uScriptAct_PrintText_time_25 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_25 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_27 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_27 = "";
   System.String logic_uScriptCon_CompareString_B_27 = "";
   bool logic_uScriptCon_CompareString_Same_27 = true;
   bool logic_uScriptCon_CompareString_Different_27 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_28 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_28 = "";
   System.Int32 logic_uScriptAct_PrintText_FontSize_28 = (int) 20;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_28 = UnityEngine.FontStyle.Bold;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_28 = new UnityEngine.Color( (float)0.977612, (float)0.9735306, (float)0.6857875, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_28 = UnityEngine.TextAnchor.UpperRight;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_28 = (int) 16;
   System.Single logic_uScriptAct_PrintText_time_28 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_28 = true;
   //pointer to script instanced logic node
   uScriptAct_Concatenate logic_uScriptAct_Concatenate_uScriptAct_Concatenate_29 = new uScriptAct_Concatenate( );
   System.Object[] logic_uScriptAct_Concatenate_A_29 = new System.Object[] {};
   System.Object[] logic_uScriptAct_Concatenate_B_29 = new System.Object[] {};
   System.String logic_uScriptAct_Concatenate_Separator_29 = " ";
   System.String logic_uScriptAct_Concatenate_Result_29;
   bool logic_uScriptAct_Concatenate_Out_29 = true;
   //pointer to script instanced logic node
   uScriptAct_AddInt logic_uScriptAct_AddInt_uScriptAct_AddInt_37 = new uScriptAct_AddInt( );
   System.Int32[] logic_uScriptAct_AddInt_A_37 = new System.Int32[] {};
   System.Int32[] logic_uScriptAct_AddInt_B_37 = new System.Int32[] {};
   System.Int32 logic_uScriptAct_AddInt_IntResult_37;
   System.Single logic_uScriptAct_AddInt_FloatResult_37;
   bool logic_uScriptAct_AddInt_Out_37 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareInt logic_uScriptCon_CompareInt_uScriptCon_CompareInt_39 = new uScriptCon_CompareInt( );
   System.Int32 logic_uScriptCon_CompareInt_A_39 = (int) 0;
   System.Int32 logic_uScriptCon_CompareInt_B_39 = (int) 10;
   bool logic_uScriptCon_CompareInt_GreaterThan_39 = true;
   bool logic_uScriptCon_CompareInt_GreaterThanOrEqualTo_39 = true;
   bool logic_uScriptCon_CompareInt_EqualTo_39 = true;
   bool logic_uScriptCon_CompareInt_NotEqualTo_39 = true;
   bool logic_uScriptCon_CompareInt_LessThanOrEqualTo_39 = true;
   bool logic_uScriptCon_CompareInt_LessThan_39 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_42 = new uScriptAct_PlaySound( );
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_42 = default(UnityEngine.AudioClip);
   UnityEngine.GameObject[] logic_uScriptAct_PlaySound_target_42 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_PlaySound_volume_42 = (float) 1;
   System.Boolean logic_uScriptAct_PlaySound_loop_42 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_42 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_43 = new uScriptAct_PlaySound( );
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_43 = default(UnityEngine.AudioClip);
   UnityEngine.GameObject[] logic_uScriptAct_PlaySound_target_43 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_PlaySound_volume_43 = (float) 1;
   System.Boolean logic_uScriptAct_PlaySound_loop_43 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_43 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_0 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_14 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_23 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_26 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_34 = default(UnityEngine.GameObject);
   System.String event_UnityEngine_GameObject_EventName_34 = "";
   System.Int32 event_UnityEngine_GameObject_EventData_34 = (int) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_34 = default(UnityEngine.GameObject);
   
   //property nodes
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_13 = new Vector3( );
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_13 = default(UnityEngine.GameObject);
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_13_previous = null;
   UnityEngine.AudioClip property_CoinAudioGold_Detox_ScriptEditor_Parameter_CoinAudioGold_46 = default(UnityEngine.AudioClip);
   UnityEngine.GameObject property_CoinAudioGold_Detox_ScriptEditor_Parameter_Instance_46 = default(UnityEngine.GameObject);
   UnityEngine.GameObject property_CoinAudioGold_Detox_ScriptEditor_Parameter_Instance_46_previous = null;
   UnityEngine.AudioClip property_CoinAudioSilver_Detox_ScriptEditor_Parameter_CoinAudioSilver_47 = default(UnityEngine.AudioClip);
   UnityEngine.GameObject property_CoinAudioSilver_Detox_ScriptEditor_Parameter_Instance_47 = default(UnityEngine.GameObject);
   UnityEngine.GameObject property_CoinAudioSilver_Detox_ScriptEditor_Parameter_Instance_47_previous = null;
   UnityEngine.GameObject property_Player_Detox_ScriptEditor_Parameter_Player_48 = default(UnityEngine.GameObject);
   UnityEngine.GameObject property_Player_Detox_ScriptEditor_Parameter_Player_48_previous = null;
   UnityEngine.GameObject property_Player_Detox_ScriptEditor_Parameter_Instance_48 = default(UnityEngine.GameObject);
   UnityEngine.GameObject property_Player_Detox_ScriptEditor_Parameter_Instance_48_previous = null;
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_13_Get_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_13.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         return component.position;
      }
      else
      {
         return new Vector3( );
      }
   }
   
   void property_position_Detox_ScriptEditor_Parameter_position_13_Set_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_13.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         component.position = property_position_Detox_ScriptEditor_Parameter_position_13;
      }
   }
   
   UnityEngine.AudioClip property_CoinAudioGold_Detox_ScriptEditor_Parameter_CoinAudioGold_46_Get_Refresh( )
   {
      CoinCollection_GameplayGlobals_Component component = property_CoinAudioGold_Detox_ScriptEditor_Parameter_Instance_46.GetComponent<CoinCollection_GameplayGlobals_Component>();
      if ( null != component )
      {
         return component.CoinAudioGold;
      }
      else
      {
         return default(UnityEngine.AudioClip);
      }
   }
   
   void property_CoinAudioGold_Detox_ScriptEditor_Parameter_CoinAudioGold_46_Set_Refresh( )
   {
      CoinCollection_GameplayGlobals_Component component = property_CoinAudioGold_Detox_ScriptEditor_Parameter_Instance_46.GetComponent<CoinCollection_GameplayGlobals_Component>();
      if ( null != component )
      {
         component.CoinAudioGold = property_CoinAudioGold_Detox_ScriptEditor_Parameter_CoinAudioGold_46;
      }
   }
   
   UnityEngine.AudioClip property_CoinAudioSilver_Detox_ScriptEditor_Parameter_CoinAudioSilver_47_Get_Refresh( )
   {
      CoinCollection_GameplayGlobals_Component component = property_CoinAudioSilver_Detox_ScriptEditor_Parameter_Instance_47.GetComponent<CoinCollection_GameplayGlobals_Component>();
      if ( null != component )
      {
         return component.CoinAudioSilver;
      }
      else
      {
         return default(UnityEngine.AudioClip);
      }
   }
   
   void property_CoinAudioSilver_Detox_ScriptEditor_Parameter_CoinAudioSilver_47_Set_Refresh( )
   {
      CoinCollection_GameplayGlobals_Component component = property_CoinAudioSilver_Detox_ScriptEditor_Parameter_Instance_47.GetComponent<CoinCollection_GameplayGlobals_Component>();
      if ( null != component )
      {
         component.CoinAudioSilver = property_CoinAudioSilver_Detox_ScriptEditor_Parameter_CoinAudioSilver_47;
      }
   }
   
   UnityEngine.GameObject property_Player_Detox_ScriptEditor_Parameter_Player_48_Get_Refresh( )
   {
      CoinCollection_GameplayGlobals_Component component = property_Player_Detox_ScriptEditor_Parameter_Instance_48.GetComponent<CoinCollection_GameplayGlobals_Component>();
      if ( null != component )
      {
         return component.Player;
      }
      else
      {
         return default(UnityEngine.GameObject);
      }
   }
   
   void property_Player_Detox_ScriptEditor_Parameter_Player_48_Set_Refresh( )
   {
      CoinCollection_GameplayGlobals_Component component = property_Player_Detox_ScriptEditor_Parameter_Instance_48.GetComponent<CoinCollection_GameplayGlobals_Component>();
      if ( null != component )
      {
         component.Player = property_Player_Detox_ScriptEditor_Parameter_Player_48;
      }
   }
   
   
   void SyncUnityHooks( )
   {
      if ( null == property_position_Detox_ScriptEditor_Parameter_Instance_13 || false == m_RegisteredForEvents )
      {
         property_position_Detox_ScriptEditor_Parameter_Instance_13 = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_13_previous != property_position_Detox_ScriptEditor_Parameter_Instance_13 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_13_previous = property_position_Detox_ScriptEditor_Parameter_Instance_13;
         
         //setup new listeners
      }
      if ( null == property_CoinAudioGold_Detox_ScriptEditor_Parameter_Instance_46 || false == m_RegisteredForEvents )
      {
         property_CoinAudioGold_Detox_ScriptEditor_Parameter_Instance_46 = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_CoinAudioGold_Detox_ScriptEditor_Parameter_Instance_46_previous != property_CoinAudioGold_Detox_ScriptEditor_Parameter_Instance_46 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_CoinAudioGold_Detox_ScriptEditor_Parameter_Instance_46_previous = property_CoinAudioGold_Detox_ScriptEditor_Parameter_Instance_46;
         
         //setup new listeners
      }
      if ( null == property_CoinAudioSilver_Detox_ScriptEditor_Parameter_Instance_47 || false == m_RegisteredForEvents )
      {
         property_CoinAudioSilver_Detox_ScriptEditor_Parameter_Instance_47 = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_CoinAudioSilver_Detox_ScriptEditor_Parameter_Instance_47_previous != property_CoinAudioSilver_Detox_ScriptEditor_Parameter_Instance_47 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_CoinAudioSilver_Detox_ScriptEditor_Parameter_Instance_47_previous = property_CoinAudioSilver_Detox_ScriptEditor_Parameter_Instance_47;
         
         //setup new listeners
      }
      if ( null == property_Player_Detox_ScriptEditor_Parameter_Instance_48 || false == m_RegisteredForEvents )
      {
         property_Player_Detox_ScriptEditor_Parameter_Instance_48 = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_Player_Detox_ScriptEditor_Parameter_Instance_48_previous != property_Player_Detox_ScriptEditor_Parameter_Instance_48 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_Player_Detox_ScriptEditor_Parameter_Instance_48_previous = property_Player_Detox_ScriptEditor_Parameter_Instance_48;
         
         //setup new listeners
      }
      SyncEventListeners( );
      if ( null == local_3_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_3_UnityEngine_GameObject = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_3_UnityEngine_GameObject_previous != local_3_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_3_UnityEngine_GameObject_previous = local_3_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_11_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_11_UnityEngine_GameObject = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_11_UnityEngine_GameObject_previous != local_11_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_11_UnityEngine_GameObject_previous = local_11_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_44_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_44_UnityEngine_GameObject = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_44_UnityEngine_GameObject_previous != local_44_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_44_UnityEngine_GameObject_previous = local_44_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_45_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_45_UnityEngine_GameObject = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_45_UnityEngine_GameObject_previous != local_45_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_45_UnityEngine_GameObject_previous = local_45_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void RegisterForUnityHooks( )
   {
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_13_previous != property_position_Detox_ScriptEditor_Parameter_Instance_13 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_13_previous = property_position_Detox_ScriptEditor_Parameter_Instance_13;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_CoinAudioGold_Detox_ScriptEditor_Parameter_Instance_46_previous != property_CoinAudioGold_Detox_ScriptEditor_Parameter_Instance_46 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_CoinAudioGold_Detox_ScriptEditor_Parameter_Instance_46_previous = property_CoinAudioGold_Detox_ScriptEditor_Parameter_Instance_46;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_CoinAudioSilver_Detox_ScriptEditor_Parameter_Instance_47_previous != property_CoinAudioSilver_Detox_ScriptEditor_Parameter_Instance_47 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_CoinAudioSilver_Detox_ScriptEditor_Parameter_Instance_47_previous = property_CoinAudioSilver_Detox_ScriptEditor_Parameter_Instance_47;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_Player_Detox_ScriptEditor_Parameter_Instance_48_previous != property_Player_Detox_ScriptEditor_Parameter_Instance_48 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_Player_Detox_ScriptEditor_Parameter_Instance_48_previous = property_Player_Detox_ScriptEditor_Parameter_Instance_48;
         
         //setup new listeners
      }
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_3_UnityEngine_GameObject_previous != local_3_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_3_UnityEngine_GameObject_previous = local_3_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_11_UnityEngine_GameObject_previous != local_11_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_11_UnityEngine_GameObject_previous = local_11_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_44_UnityEngine_GameObject_previous != local_44_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_44_UnityEngine_GameObject_previous = local_44_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_45_UnityEngine_GameObject_previous != local_45_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_45_UnityEngine_GameObject_previous = local_45_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void SyncEventListeners( )
   {
      {
         {
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( property_position_Detox_ScriptEditor_Parameter_Instance_13_previous != property_position_Detox_ScriptEditor_Parameter_Instance_13 || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  property_position_Detox_ScriptEditor_Parameter_Instance_13_previous = property_position_Detox_ScriptEditor_Parameter_Instance_13;
                  
                  //setup new listeners
               }
            }
         }
      }
      {
         {
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( property_CoinAudioGold_Detox_ScriptEditor_Parameter_Instance_46_previous != property_CoinAudioGold_Detox_ScriptEditor_Parameter_Instance_46 || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  property_CoinAudioGold_Detox_ScriptEditor_Parameter_Instance_46_previous = property_CoinAudioGold_Detox_ScriptEditor_Parameter_Instance_46;
                  
                  //setup new listeners
               }
            }
         }
      }
      {
         {
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( property_CoinAudioSilver_Detox_ScriptEditor_Parameter_Instance_47_previous != property_CoinAudioSilver_Detox_ScriptEditor_Parameter_Instance_47 || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  property_CoinAudioSilver_Detox_ScriptEditor_Parameter_Instance_47_previous = property_CoinAudioSilver_Detox_ScriptEditor_Parameter_Instance_47;
                  
                  //setup new listeners
               }
            }
         }
      }
      {
         {
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( property_Player_Detox_ScriptEditor_Parameter_Instance_48_previous != property_Player_Detox_ScriptEditor_Parameter_Instance_48 || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  property_Player_Detox_ScriptEditor_Parameter_Instance_48_previous = property_Player_Detox_ScriptEditor_Parameter_Instance_48;
                  
                  //setup new listeners
               }
            }
         }
      }
      property_Player_Detox_ScriptEditor_Parameter_Player_48 = property_Player_Detox_ScriptEditor_Parameter_Player_48_Get_Refresh();
      //if our game object reference was changed then we need to reset event listeners
      if ( property_Player_Detox_ScriptEditor_Parameter_Player_48_previous != property_Player_Detox_ScriptEditor_Parameter_Player_48 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_Player_Detox_ScriptEditor_Parameter_Player_48_previous = property_Player_Detox_ScriptEditor_Parameter_Player_48;
         
         //setup new listeners
      }
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
      if ( null == event_UnityEngine_GameObject_Instance_14 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_14 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_14 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_14.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_14.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_14;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_23 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_23 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_23 )
         {
            {
               uScript_Global component = event_UnityEngine_GameObject_Instance_23.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_23.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_23;
                  component.uScriptLateStart += Instance_uScriptLateStart_23;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_26 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_26 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_26 )
         {
            {
               uScript_Update component = event_UnityEngine_GameObject_Instance_26.GetComponent<uScript_Update>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_26.AddComponent<uScript_Update>();
               }
               if ( null != component )
               {
                  component.OnUpdate += Instance_OnUpdate_26;
                  component.OnLateUpdate += Instance_OnLateUpdate_26;
                  component.OnFixedUpdate += Instance_OnFixedUpdate_26;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_34 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_34 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_34 )
         {
            {
               uScript_CustomEventInt component = event_UnityEngine_GameObject_Instance_34.GetComponent<uScript_CustomEventInt>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_34.AddComponent<uScript_CustomEventInt>();
               }
               if ( null != component )
               {
                  component.OnCustomEventInt += Instance_OnCustomEventInt_34;
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
      if ( null != event_UnityEngine_GameObject_Instance_14 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_14.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_14;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_23 )
      {
         {
            uScript_Global component = event_UnityEngine_GameObject_Instance_23.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_23;
               component.uScriptLateStart -= Instance_uScriptLateStart_23;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_26 )
      {
         {
            uScript_Update component = event_UnityEngine_GameObject_Instance_26.GetComponent<uScript_Update>();
            if ( null != component )
            {
               component.OnUpdate -= Instance_OnUpdate_26;
               component.OnLateUpdate -= Instance_OnLateUpdate_26;
               component.OnFixedUpdate -= Instance_OnFixedUpdate_26;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_34 )
      {
         {
            uScript_CustomEventInt component = event_UnityEngine_GameObject_Instance_34.GetComponent<uScript_CustomEventInt>();
            if ( null != component )
            {
               component.OnCustomEventInt -= Instance_OnCustomEventInt_34;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_SetVector3_uScriptAct_SetVector3_2.SetParent(g);
      logic_uScriptAct_SetGameObjectEulerAngles_uScriptAct_SetGameObjectEulerAngles_4.SetParent(g);
      logic_uScriptAct_LookAt_uScriptAct_LookAt_5.SetParent(g);
      logic_uScriptCon_Switch_uScriptCon_Switch_6.SetParent(g);
      logic_uScriptAct_AddVector3_uScriptAct_AddVector3_7.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_10.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_15.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_16.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_19.SetParent(g);
      logic_uScriptAct_SetGameObjectPosition_uScriptAct_SetGameObjectPosition_20.SetParent(g);
      logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_21.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_24.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_25.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_27.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_28.SetParent(g);
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_29.SetParent(g);
      logic_uScriptAct_AddInt_uScriptAct_AddInt_37.SetParent(g);
      logic_uScriptCon_CompareInt_uScriptCon_CompareInt_39.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_42.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_43.SetParent(g);
   }
   public void Awake()
   {
      
      logic_uScriptAct_LookAt_uScriptAct_LookAt_5.Finished += uScriptAct_LookAt_Finished_5;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_42.Finished += uScriptAct_PlaySound_Finished_42;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_43.Finished += uScriptAct_PlaySound_Finished_43;
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
      
      logic_uScriptAct_LookAt_uScriptAct_LookAt_5.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_42.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_43.Update( );
   }
   
   public void OnDestroy()
   {
      logic_uScriptAct_LookAt_uScriptAct_LookAt_5.Finished -= uScriptAct_LookAt_Finished_5;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_42.Finished -= uScriptAct_PlaySound_Finished_42;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_43.Finished -= uScriptAct_PlaySound_Finished_43;
   }
   
   public void OnGUI()
   {
      logic_uScriptAct_PrintText_uScriptAct_PrintText_24.OnGUI( );
      logic_uScriptAct_PrintText_uScriptAct_PrintText_25.OnGUI( );
      logic_uScriptAct_PrintText_uScriptAct_PrintText_28.OnGUI( );
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
   
   void Instance_KeyEvent_14(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_14( );
   }
   
   void Instance_uScriptStart_23(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_23( );
   }
   
   void Instance_uScriptLateStart_23(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptLateStart_23( );
   }
   
   void Instance_OnUpdate_26(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUpdate_26( );
   }
   
   void Instance_OnLateUpdate_26(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnLateUpdate_26( );
   }
   
   void Instance_OnFixedUpdate_26(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnFixedUpdate_26( );
   }
   
   void Instance_OnCustomEventInt_34(object o, uScript_CustomEventInt.CustomEventIntArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_34 = e.Sender;
      event_UnityEngine_GameObject_EventName_34 = e.EventName;
      event_UnityEngine_GameObject_EventData_34 = e.EventData;
      //relay event to nodes
      Relay_OnCustomEventInt_34( );
   }
   
   void uScriptAct_LookAt_Finished_5(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_5( );
   }
   
   void uScriptAct_PlaySound_Finished_42(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_42( );
   }
   
   void uScriptAct_PlaySound_Finished_43(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_43( );
   }
   
   void Relay_OnUpdate_0()
   {
      if (true == CheckDebugBreak("a262559c-931a-4569-abe8-1540b9082471", "Global_Update", Relay_OnUpdate_0)) return; 
   }
   
   void Relay_OnLateUpdate_0()
   {
      if (true == CheckDebugBreak("a262559c-931a-4569-abe8-1540b9082471", "Global_Update", Relay_OnLateUpdate_0)) return; 
   }
   
   void Relay_OnFixedUpdate_0()
   {
      if (true == CheckDebugBreak("a262559c-931a-4569-abe8-1540b9082471", "Global_Update", Relay_OnFixedUpdate_0)) return; 
      Relay_In_10();
   }
   
   void Relay_In_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0c3f67ea-e9cf-471e-8e4e-884156667bb2", "Set_Vector3", Relay_In_2)) return; 
         {
            {
               logic_uScriptAct_SetVector3_Value_2 = local_9_UnityEngine_Vector3;
               
            }
            {
            }
         }
         logic_uScriptAct_SetVector3_uScriptAct_SetVector3_2.In(logic_uScriptAct_SetVector3_Value_2, out logic_uScriptAct_SetVector3_TargetVector3_2);
         property_position_Detox_ScriptEditor_Parameter_position_13 = logic_uScriptAct_SetVector3_TargetVector3_2;
         property_position_Detox_ScriptEditor_Parameter_position_13_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetVector3_uScriptAct_SetVector3_2.Out;
         
         if ( test_0 == true )
         {
            Relay_In_5();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Set Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_4()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("025b3342-e5c9-4f11-adcf-afbc228558ae", "Set_Euler_Angles", Relay_In_4)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_11_UnityEngine_GameObject_previous != local_11_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_11_UnityEngine_GameObject_previous = local_11_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_11_UnityEngine_GameObject);
               logic_uScriptAct_SetGameObjectEulerAngles_Target_4 = properties.ToArray();
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
         logic_uScriptAct_SetGameObjectEulerAngles_uScriptAct_SetGameObjectEulerAngles_4.In(logic_uScriptAct_SetGameObjectEulerAngles_Target_4, logic_uScriptAct_SetGameObjectEulerAngles_X_Axis_4, logic_uScriptAct_SetGameObjectEulerAngles_PreserveX_Axis_4, logic_uScriptAct_SetGameObjectEulerAngles_Y_Axis_4, logic_uScriptAct_SetGameObjectEulerAngles_PreserveY_Axis_4, logic_uScriptAct_SetGameObjectEulerAngles_Z_Axis_4, logic_uScriptAct_SetGameObjectEulerAngles_PreserveZ_Axis_4, logic_uScriptAct_SetGameObjectEulerAngles_AsLocal_4);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetGameObjectEulerAngles_uScriptAct_SetGameObjectEulerAngles_4.Out;
         
         if ( test_0 == true )
         {
            Relay_In_20();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Set Euler Angles.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("cf7c11d6-27b6-447b-a135-c1d531d7f4d4", "Look_At", Relay_Finished_5)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Look At.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("cf7c11d6-27b6-447b-a135-c1d531d7f4d4", "Look_At", Relay_In_5)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_3_UnityEngine_GameObject_previous != local_3_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_3_UnityEngine_GameObject_previous = local_3_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_3_UnityEngine_GameObject);
               logic_uScriptAct_LookAt_Target_5 = properties.ToArray();
            }
            {
               {
                  property_Player_Detox_ScriptEditor_Parameter_Player_48 = property_Player_Detox_ScriptEditor_Parameter_Player_48_Get_Refresh();
                  //if our game object reference was changed then we need to reset event listeners
                  if ( property_Player_Detox_ScriptEditor_Parameter_Player_48_previous != property_Player_Detox_ScriptEditor_Parameter_Player_48 || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     property_Player_Detox_ScriptEditor_Parameter_Player_48_previous = property_Player_Detox_ScriptEditor_Parameter_Player_48;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_LookAt_Focus_5 = property_Player_Detox_ScriptEditor_Parameter_Player_48_Get_Refresh( );
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_LookAt_uScriptAct_LookAt_5.In(logic_uScriptAct_LookAt_Target_5, logic_uScriptAct_LookAt_Focus_5, logic_uScriptAct_LookAt_time_5, logic_uScriptAct_LookAt_lockAxis_5);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Look At.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0d80325c-505b-4452-aa64-f44f72f78f3d", "Switch", Relay_In_6)) return; 
         {
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptCon_Switch_uScriptCon_Switch_6.In(logic_uScriptCon_Switch_Loop_6, logic_uScriptCon_Switch_MaxOutputUsed_6, out logic_uScriptCon_Switch_CurrentOutput_6);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_Switch_uScriptCon_Switch_6.Output1;
         bool test_1 = logic_uScriptCon_Switch_uScriptCon_Switch_6.Output2;
         
         if ( test_0 == true )
         {
            Relay_True_16();
         }
         if ( test_1 == true )
         {
            Relay_False_16();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Switch.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Reset_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0d80325c-505b-4452-aa64-f44f72f78f3d", "Switch", Relay_Reset_6)) return; 
         {
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptCon_Switch_uScriptCon_Switch_6.Reset(logic_uScriptCon_Switch_Loop_6, logic_uScriptCon_Switch_MaxOutputUsed_6, out logic_uScriptCon_Switch_CurrentOutput_6);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_Switch_uScriptCon_Switch_6.Output1;
         bool test_1 = logic_uScriptCon_Switch_uScriptCon_Switch_6.Output2;
         
         if ( test_0 == true )
         {
            Relay_True_16();
         }
         if ( test_1 == true )
         {
            Relay_False_16();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Switch.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("03443454-af1c-4f5a-9c1a-fda9e5da17bc", "Add_Vector3", Relay_In_7)) return; 
         {
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_12_UnityEngine_Vector3);
               logic_uScriptAct_AddVector3_A_7 = properties.ToArray();
            }
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_Camera_Offset_UnityEngine_Vector3);
               logic_uScriptAct_AddVector3_B_7 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_uScriptAct_AddVector3_7.In(logic_uScriptAct_AddVector3_A_7, logic_uScriptAct_AddVector3_B_7, out logic_uScriptAct_AddVector3_Result_7);
         local_9_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_Result_7;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_uScriptAct_AddVector3_7.Out;
         
         if ( test_0 == true )
         {
            Relay_In_2();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3b93b7ff-8019-44be-a5d8-11f6d83c43c2", "Compare_Bool", Relay_In_10)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_10 = local_Attach_Camera_System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_10.In(logic_uScriptCon_CompareBool_Bool_10);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_10.True;
         bool test_1 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_10.False;
         
         if ( test_0 == true )
         {
            Relay_In_21();
         }
         if ( test_1 == true )
         {
            Relay_In_4();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_14()
   {
      if (true == CheckDebugBreak("afe8ed96-1880-4955-962b-faea2a0516e9", "Input_Events", Relay_KeyEvent_14)) return; 
      Relay_In_15();
   }
   
   void Relay_In_15()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2d3d4205-9b58-4943-b9db-c384eaeb83a6", "Input_Events_Filter", Relay_In_15)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_15.In(logic_uScriptAct_OnInputEventFilter_KeyCode_15);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_15.KeyUp;
         
         if ( test_0 == true )
         {
            Relay_In_6();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_16()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("004ac46c-75f5-411d-a4f1-01482da65786", "Set_Bool", Relay_True_16)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_16.True(out logic_uScriptAct_SetBool_Target_16);
         local_Attach_Camera_System_Boolean = logic_uScriptAct_SetBool_Target_16;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_16.Out;
         
         if ( test_0 == true )
         {
            Relay_In_19();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_16()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("004ac46c-75f5-411d-a4f1-01482da65786", "Set_Bool", Relay_False_16)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_16.False(out logic_uScriptAct_SetBool_Target_16);
         local_Attach_Camera_System_Boolean = logic_uScriptAct_SetBool_Target_16;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_16.Out;
         
         if ( test_0 == true )
         {
            Relay_In_19();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_19()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9f3c3909-cda6-4bd5-bf61-1e6d404ab42f", "Log", Relay_In_19)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_Attach_Camera_System_Boolean);
               logic_uScriptAct_Log_Target_19 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_19.In(logic_uScriptAct_Log_Prefix_19, logic_uScriptAct_Log_Target_19, logic_uScriptAct_Log_Postfix_19);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_20()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d9cbe2c7-b65f-4d59-b76c-1c564e60549f", "Set_Position", Relay_In_20)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_11_UnityEngine_GameObject_previous != local_11_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_11_UnityEngine_GameObject_previous = local_11_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_11_UnityEngine_GameObject);
               logic_uScriptAct_SetGameObjectPosition_Target_20 = properties.ToArray();
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SetGameObjectPosition_uScriptAct_SetGameObjectPosition_20.In(logic_uScriptAct_SetGameObjectPosition_Target_20, logic_uScriptAct_SetGameObjectPosition_Position_20, logic_uScriptAct_SetGameObjectPosition_AsOffset_20, logic_uScriptAct_SetGameObjectPosition_AsLocal_20);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Set Position.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_21()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ab00a0d0-69d5-4a13-843d-6d78db00c4a0", "Get_Position_and_Rotation", Relay_In_21)) return; 
         {
            {
               {
                  property_Player_Detox_ScriptEditor_Parameter_Player_48 = property_Player_Detox_ScriptEditor_Parameter_Player_48_Get_Refresh();
                  //if our game object reference was changed then we need to reset event listeners
                  if ( property_Player_Detox_ScriptEditor_Parameter_Player_48_previous != property_Player_Detox_ScriptEditor_Parameter_Player_48 || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     property_Player_Detox_ScriptEditor_Parameter_Player_48_previous = property_Player_Detox_ScriptEditor_Parameter_Player_48;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_GetPositionAndRotation_Target_21 = property_Player_Detox_ScriptEditor_Parameter_Player_48_Get_Refresh( );
               
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
         logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_21.In(logic_uScriptAct_GetPositionAndRotation_Target_21, logic_uScriptAct_GetPositionAndRotation_GetLocal_21, out logic_uScriptAct_GetPositionAndRotation_Position_21, out logic_uScriptAct_GetPositionAndRotation_Rotation_21, out logic_uScriptAct_GetPositionAndRotation_EulerAngles_21, out logic_uScriptAct_GetPositionAndRotation_Forward_21, out logic_uScriptAct_GetPositionAndRotation_Up_21, out logic_uScriptAct_GetPositionAndRotation_Right_21);
         local_12_UnityEngine_Vector3 = logic_uScriptAct_GetPositionAndRotation_Position_21;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_21.Out;
         
         if ( test_0 == true )
         {
            Relay_In_7();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Get Position and Rotation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_uScriptStart_23()
   {
      if (true == CheckDebugBreak("eacf9f4b-f4ac-4c1e-b44e-dd9b1e007459", "uScript_Events", Relay_uScriptStart_23)) return; 
      Relay_ShowLabel_24();
   }
   
   void Relay_uScriptLateStart_23()
   {
      if (true == CheckDebugBreak("eacf9f4b-f4ac-4c1e-b44e-dd9b1e007459", "uScript_Events", Relay_uScriptLateStart_23)) return; 
   }
   
   void Relay_ShowLabel_24()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7e01458b-c989-4aa8-b9a1-d0bd16c5c326", "Print_Text", Relay_ShowLabel_24)) return; 
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
            {
            }
         }
         logic_uScriptAct_PrintText_uScriptAct_PrintText_24.ShowLabel(logic_uScriptAct_PrintText_Text_24, logic_uScriptAct_PrintText_FontSize_24, logic_uScriptAct_PrintText_FontStyle_24, logic_uScriptAct_PrintText_FontColor_24, logic_uScriptAct_PrintText_textAnchor_24, logic_uScriptAct_PrintText_EdgePadding_24, logic_uScriptAct_PrintText_time_24);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_PrintText_uScriptAct_PrintText_24.Out;
         
         if ( test_0 == true )
         {
            Relay_ShowLabel_25();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_24()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7e01458b-c989-4aa8-b9a1-d0bd16c5c326", "Print_Text", Relay_HideLabel_24)) return; 
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
            {
            }
         }
         logic_uScriptAct_PrintText_uScriptAct_PrintText_24.HideLabel(logic_uScriptAct_PrintText_Text_24, logic_uScriptAct_PrintText_FontSize_24, logic_uScriptAct_PrintText_FontStyle_24, logic_uScriptAct_PrintText_FontColor_24, logic_uScriptAct_PrintText_textAnchor_24, logic_uScriptAct_PrintText_EdgePadding_24, logic_uScriptAct_PrintText_time_24);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_PrintText_uScriptAct_PrintText_24.Out;
         
         if ( test_0 == true )
         {
            Relay_ShowLabel_25();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_25()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e5e173b7-bb6e-4111-bc81-3a1696a7fc3c", "Print_Text", Relay_ShowLabel_25)) return; 
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
            {
            }
         }
         logic_uScriptAct_PrintText_uScriptAct_PrintText_25.ShowLabel(logic_uScriptAct_PrintText_Text_25, logic_uScriptAct_PrintText_FontSize_25, logic_uScriptAct_PrintText_FontStyle_25, logic_uScriptAct_PrintText_FontColor_25, logic_uScriptAct_PrintText_textAnchor_25, logic_uScriptAct_PrintText_EdgePadding_25, logic_uScriptAct_PrintText_time_25);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_25()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e5e173b7-bb6e-4111-bc81-3a1696a7fc3c", "Print_Text", Relay_HideLabel_25)) return; 
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
            {
            }
         }
         logic_uScriptAct_PrintText_uScriptAct_PrintText_25.HideLabel(logic_uScriptAct_PrintText_Text_25, logic_uScriptAct_PrintText_FontSize_25, logic_uScriptAct_PrintText_FontStyle_25, logic_uScriptAct_PrintText_FontColor_25, logic_uScriptAct_PrintText_textAnchor_25, logic_uScriptAct_PrintText_EdgePadding_25, logic_uScriptAct_PrintText_time_25);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnUpdate_26()
   {
      if (true == CheckDebugBreak("4f2e473b-d5d1-4738-8a5f-97a891bac302", "Global_Update", Relay_OnUpdate_26)) return; 
   }
   
   void Relay_OnLateUpdate_26()
   {
      if (true == CheckDebugBreak("4f2e473b-d5d1-4738-8a5f-97a891bac302", "Global_Update", Relay_OnLateUpdate_26)) return; 
      Relay_In_29();
   }
   
   void Relay_OnFixedUpdate_26()
   {
      if (true == CheckDebugBreak("4f2e473b-d5d1-4738-8a5f-97a891bac302", "Global_Update", Relay_OnFixedUpdate_26)) return; 
   }
   
   void Relay_In_27()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b40a5afc-c7eb-42e7-abf3-ffd805b04a1e", "Compare_String", Relay_In_27)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_27 = local_35_System_String;
               
            }
            {
               logic_uScriptCon_CompareString_B_27 = local_33_System_String;
               
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_27.In(logic_uScriptCon_CompareString_A_27, logic_uScriptCon_CompareString_B_27);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_27.Same;
         
         if ( test_0 == true )
         {
            Relay_In_37();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_28()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6c87add6-9bfd-44e1-b4c9-1062aaa80e93", "Print_Text", Relay_ShowLabel_28)) return; 
         {
            {
               logic_uScriptAct_PrintText_Text_28 = local_32_System_String;
               
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_28.ShowLabel(logic_uScriptAct_PrintText_Text_28, logic_uScriptAct_PrintText_FontSize_28, logic_uScriptAct_PrintText_FontStyle_28, logic_uScriptAct_PrintText_FontColor_28, logic_uScriptAct_PrintText_textAnchor_28, logic_uScriptAct_PrintText_EdgePadding_28, logic_uScriptAct_PrintText_time_28);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_28()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6c87add6-9bfd-44e1-b4c9-1062aaa80e93", "Print_Text", Relay_HideLabel_28)) return; 
         {
            {
               logic_uScriptAct_PrintText_Text_28 = local_32_System_String;
               
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_28.HideLabel(logic_uScriptAct_PrintText_Text_28, logic_uScriptAct_PrintText_FontSize_28, logic_uScriptAct_PrintText_FontStyle_28, logic_uScriptAct_PrintText_FontColor_28, logic_uScriptAct_PrintText_textAnchor_28, logic_uScriptAct_PrintText_EdgePadding_28, logic_uScriptAct_PrintText_time_28);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_29()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b0937780-42b9-40d2-8edf-8a09ca78aa2b", "Concatenate", Relay_In_29)) return; 
         {
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_31_System_String);
               logic_uScriptAct_Concatenate_A_29 = properties.ToArray();
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_CoinTotal_System_Int32);
               logic_uScriptAct_Concatenate_B_29 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_Concatenate_uScriptAct_Concatenate_29.In(logic_uScriptAct_Concatenate_A_29, logic_uScriptAct_Concatenate_B_29, logic_uScriptAct_Concatenate_Separator_29, out logic_uScriptAct_Concatenate_Result_29);
         local_32_System_String = logic_uScriptAct_Concatenate_Result_29;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Concatenate_uScriptAct_Concatenate_29.Out;
         
         if ( test_0 == true )
         {
            Relay_ShowLabel_28();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Concatenate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnCustomEventInt_34()
   {
      if (true == CheckDebugBreak("0ffdc7ae-be7e-473f-9432-53a93062b0e3", "Custom_Event__Int_", Relay_OnCustomEventInt_34)) return; 
      local_35_System_String = event_UnityEngine_GameObject_EventName_34;
      local_CoinValue_System_Int32 = event_UnityEngine_GameObject_EventData_34;
      Relay_In_27();
   }
   
   void Relay_In_37()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5889dc85-d6d7-4003-9136-877c419bd7c2", "Add_Int", Relay_In_37)) return; 
         {
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_CoinValue_System_Int32);
               logic_uScriptAct_AddInt_A_37 = properties.ToArray();
            }
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_CoinTotal_System_Int32);
               logic_uScriptAct_AddInt_B_37 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddInt_uScriptAct_AddInt_37.In(logic_uScriptAct_AddInt_A_37, logic_uScriptAct_AddInt_B_37, out logic_uScriptAct_AddInt_IntResult_37, out logic_uScriptAct_AddInt_FloatResult_37);
         local_CoinTotal_System_Int32 = logic_uScriptAct_AddInt_IntResult_37;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddInt_uScriptAct_AddInt_37.Out;
         
         if ( test_0 == true )
         {
            Relay_In_39();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Add Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_39()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e769f90b-db3a-4db3-8ccb-5f062a7ebf7f", "Compare_Int", Relay_In_39)) return; 
         {
            {
               logic_uScriptCon_CompareInt_A_39 = local_CoinValue_System_Int32;
               
            }
            {
            }
         }
         logic_uScriptCon_CompareInt_uScriptCon_CompareInt_39.In(logic_uScriptCon_CompareInt_A_39, logic_uScriptCon_CompareInt_B_39);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareInt_uScriptCon_CompareInt_39.GreaterThanOrEqualTo;
         bool test_1 = logic_uScriptCon_CompareInt_uScriptCon_CompareInt_39.LessThan;
         
         if ( test_0 == true )
         {
            Relay_Play_42();
         }
         if ( test_1 == true )
         {
            Relay_Play_43();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Compare Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_42()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e98b51aa-20d4-4a9d-999f-09fb2af4453a", "Play_Sound", Relay_Finished_42)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Play_42()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e98b51aa-20d4-4a9d-999f-09fb2af4453a", "Play_Sound", Relay_Play_42)) return; 
         {
            {
               logic_uScriptAct_PlaySound_audioClip_42 = property_CoinAudioGold_Detox_ScriptEditor_Parameter_CoinAudioGold_46_Get_Refresh( );
               
            }
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_44_UnityEngine_GameObject_previous != local_44_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_44_UnityEngine_GameObject_previous = local_44_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_44_UnityEngine_GameObject);
               logic_uScriptAct_PlaySound_target_42 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_42.Play(logic_uScriptAct_PlaySound_audioClip_42, logic_uScriptAct_PlaySound_target_42, logic_uScriptAct_PlaySound_volume_42, logic_uScriptAct_PlaySound_loop_42);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_UpdateVolume_42()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e98b51aa-20d4-4a9d-999f-09fb2af4453a", "Play_Sound", Relay_UpdateVolume_42)) return; 
         {
            {
               logic_uScriptAct_PlaySound_audioClip_42 = property_CoinAudioGold_Detox_ScriptEditor_Parameter_CoinAudioGold_46_Get_Refresh( );
               
            }
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_44_UnityEngine_GameObject_previous != local_44_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_44_UnityEngine_GameObject_previous = local_44_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_44_UnityEngine_GameObject);
               logic_uScriptAct_PlaySound_target_42 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_42.UpdateVolume(logic_uScriptAct_PlaySound_audioClip_42, logic_uScriptAct_PlaySound_target_42, logic_uScriptAct_PlaySound_volume_42, logic_uScriptAct_PlaySound_loop_42);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_42()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e98b51aa-20d4-4a9d-999f-09fb2af4453a", "Play_Sound", Relay_Stop_42)) return; 
         {
            {
               logic_uScriptAct_PlaySound_audioClip_42 = property_CoinAudioGold_Detox_ScriptEditor_Parameter_CoinAudioGold_46_Get_Refresh( );
               
            }
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_44_UnityEngine_GameObject_previous != local_44_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_44_UnityEngine_GameObject_previous = local_44_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_44_UnityEngine_GameObject);
               logic_uScriptAct_PlaySound_target_42 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_42.Stop(logic_uScriptAct_PlaySound_audioClip_42, logic_uScriptAct_PlaySound_target_42, logic_uScriptAct_PlaySound_volume_42, logic_uScriptAct_PlaySound_loop_42);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_43()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("66fdce2e-6102-47d0-bce9-36747450e706", "Play_Sound", Relay_Finished_43)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Play_43()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("66fdce2e-6102-47d0-bce9-36747450e706", "Play_Sound", Relay_Play_43)) return; 
         {
            {
               logic_uScriptAct_PlaySound_audioClip_43 = property_CoinAudioSilver_Detox_ScriptEditor_Parameter_CoinAudioSilver_47_Get_Refresh( );
               
            }
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_45_UnityEngine_GameObject_previous != local_45_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_45_UnityEngine_GameObject_previous = local_45_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_45_UnityEngine_GameObject);
               logic_uScriptAct_PlaySound_target_43 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_43.Play(logic_uScriptAct_PlaySound_audioClip_43, logic_uScriptAct_PlaySound_target_43, logic_uScriptAct_PlaySound_volume_43, logic_uScriptAct_PlaySound_loop_43);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_UpdateVolume_43()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("66fdce2e-6102-47d0-bce9-36747450e706", "Play_Sound", Relay_UpdateVolume_43)) return; 
         {
            {
               logic_uScriptAct_PlaySound_audioClip_43 = property_CoinAudioSilver_Detox_ScriptEditor_Parameter_CoinAudioSilver_47_Get_Refresh( );
               
            }
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_45_UnityEngine_GameObject_previous != local_45_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_45_UnityEngine_GameObject_previous = local_45_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_45_UnityEngine_GameObject);
               logic_uScriptAct_PlaySound_target_43 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_43.UpdateVolume(logic_uScriptAct_PlaySound_audioClip_43, logic_uScriptAct_PlaySound_target_43, logic_uScriptAct_PlaySound_volume_43, logic_uScriptAct_PlaySound_loop_43);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_43()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("66fdce2e-6102-47d0-bce9-36747450e706", "Play_Sound", Relay_Stop_43)) return; 
         {
            {
               logic_uScriptAct_PlaySound_audioClip_43 = property_CoinAudioSilver_Detox_ScriptEditor_Parameter_CoinAudioSilver_47_Get_Refresh( );
               
            }
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_45_UnityEngine_GameObject_previous != local_45_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_45_UnityEngine_GameObject_previous = local_45_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_45_UnityEngine_GameObject);
               logic_uScriptAct_PlaySound_target_43 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_43.Stop(logic_uScriptAct_PlaySound_audioClip_43, logic_uScriptAct_PlaySound_target_43, logic_uScriptAct_PlaySound_volume_43, logic_uScriptAct_PlaySound_loop_43);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_MetagameLogic.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_MetagameLogic.uscript:3", local_3_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "6aa61e0a-fe9c-48bf-b04f-1c6c452109ef", local_3_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_MetagameLogic.uscript:9", local_9_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "6e12bfa7-076c-45db-8522-73a439f8e641", local_9_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_MetagameLogic.uscript:11", local_11_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "1fda025b-0319-4456-9337-320adcf5cb4b", local_11_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_MetagameLogic.uscript:12", local_12_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "707c123c-66bb-4a5a-a277-3c8b05a568bb", local_12_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_MetagameLogic.uscript:Attach Camera", local_Attach_Camera_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "e7f11812-5a6d-41a2-8224-d299f711bd78", local_Attach_Camera_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_MetagameLogic.uscript:Camera Offset", local_Camera_Offset_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "0a38cf5e-6fbc-423c-806b-8eaee238418f", local_Camera_Offset_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_MetagameLogic.uscript:31", local_31_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "77bbc348-13dc-47da-9af8-adf5eed76cdb", local_31_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_MetagameLogic.uscript:32", local_32_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "fcaac8cb-ecea-456d-b846-190812e29c2e", local_32_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_MetagameLogic.uscript:33", local_33_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "596f2a63-a50e-495f-ac10-2b956f0a620a", local_33_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_MetagameLogic.uscript:35", local_35_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ed655493-5939-4aa5-9a9d-db6826fc2b52", local_35_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_MetagameLogic.uscript:CoinTotal", local_CoinTotal_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "56eeaeee-a735-44d0-b52c-876f66d7550f", local_CoinTotal_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_MetagameLogic.uscript:CoinValue", local_CoinValue_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "12d70690-16a5-4f62-9fd5-b4624220deb2", local_CoinValue_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_MetagameLogic.uscript:44", local_44_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "23bbac4d-35c9-4b8b-bfa6-6ebf53a8e84f", local_44_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_MetagameLogic.uscript:45", local_45_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "460e94e8-1754-4d93-97c5-5c2ce528fab6", local_45_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "fe0476bf-cd81-419c-a23a-58f4c4d16dfb", property_position_Detox_ScriptEditor_Parameter_position_13);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ae6558f2-7341-4252-a023-4a5a5d27581e", property_CoinAudioGold_Detox_ScriptEditor_Parameter_CoinAudioGold_46);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "999658d0-9e72-4671-ad37-bd86d46f3a3b", property_CoinAudioSilver_Detox_ScriptEditor_Parameter_CoinAudioSilver_47);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "033ee040-8f40-47ea-913a-8c32d0088eda", property_Player_Detox_ScriptEditor_Parameter_Player_48);
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
