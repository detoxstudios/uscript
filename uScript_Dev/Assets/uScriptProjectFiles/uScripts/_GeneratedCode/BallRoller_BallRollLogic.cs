//uScript Generated Code - Build 1.0.3109
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class BallRoller_BallRollLogic : uScriptLogic
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
   UnityEngine.Vector3 local_10_UnityEngine_Vector3 = new Vector3( (float)-7, (float)0, (float)0 );
   UnityEngine.Vector3 local_11_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)7 );
   UnityEngine.Vector3 local_16_UnityEngine_Vector3 = new Vector3( (float)7, (float)0, (float)0 );
   UnityEngine.Vector3 local_25_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.GameObject local_28_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_28_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_29_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_29_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_30_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_30_UnityEngine_GameObject_previous = null;
   UnityEngine.Vector3 local_31_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)7 );
   UnityEngine.Vector3 local_32_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 local_35_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)-7 );
   UnityEngine.GameObject local_39_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_39_UnityEngine_GameObject_previous = null;
   UnityEngine.Vector3 local_40_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)-7 );
   UnityEngine.Vector3 local_46_UnityEngine_Vector3 = new Vector3( (float)-7, (float)0, (float)0 );
   UnityEngine.GameObject local_51_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_51_UnityEngine_GameObject_previous = null;
   UnityEngine.Vector3 local_53_UnityEngine_Vector3 = new Vector3( (float)0, (float)3, (float)0 );
   UnityEngine.GameObject local_58_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_58_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_59_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_59_UnityEngine_GameObject_previous = null;
   UnityEngine.Vector3 local_6_UnityEngine_Vector3 = new Vector3( (float)7, (float)0, (float)0 );
   UnityEngine.GameObject local_61_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_61_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_9_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_9_UnityEngine_GameObject_previous = null;
   System.Boolean local_Attach_Camera_System_Boolean = (bool) false;
   UnityEngine.Vector3 local_Camera_Offset_UnityEngine_Vector3 = new Vector3( (float)-5, (float)10, (float)0 );
   System.Boolean local_Can_Jump__System_Boolean = (bool) true;
   UnityEngine.AudioClip local_Col_Sound_UnityEngine_AudioClip = default(UnityEngine.AudioClip);
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_AddForce logic_uScriptAct_AddForce_uScriptAct_AddForce_3 = new uScriptAct_AddForce( );
   UnityEngine.GameObject logic_uScriptAct_AddForce_Target_3 = default(UnityEngine.GameObject);
   UnityEngine.Vector3 logic_uScriptAct_AddForce_Force_3 = new Vector3( );
   System.Single logic_uScriptAct_AddForce_Scale_3 = (float) 0;
   System.Boolean logic_uScriptAct_AddForce_UseForceMode_3 = (bool) false;
   UnityEngine.ForceMode logic_uScriptAct_AddForce_ForceModeType_3 = UnityEngine.ForceMode.Force;
   bool logic_uScriptAct_AddForce_Out_3 = true;
   //pointer to script instanced logic node
   uScriptAct_AddForce logic_uScriptAct_AddForce_uScriptAct_AddForce_4 = new uScriptAct_AddForce( );
   UnityEngine.GameObject logic_uScriptAct_AddForce_Target_4 = default(UnityEngine.GameObject);
   UnityEngine.Vector3 logic_uScriptAct_AddForce_Force_4 = new Vector3( );
   System.Single logic_uScriptAct_AddForce_Scale_4 = (float) 0;
   System.Boolean logic_uScriptAct_AddForce_UseForceMode_4 = (bool) false;
   UnityEngine.ForceMode logic_uScriptAct_AddForce_ForceModeType_4 = UnityEngine.ForceMode.Force;
   bool logic_uScriptAct_AddForce_Out_4 = true;
   //pointer to script instanced logic node
   uScriptAct_SetVector3 logic_uScriptAct_SetVector3_uScriptAct_SetVector3_5 = new uScriptAct_SetVector3( );
   UnityEngine.Vector3 logic_uScriptAct_SetVector3_Value_5 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_SetVector3_TargetVector3_5;
   bool logic_uScriptAct_SetVector3_Out_5 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_8 = UnityEngine.KeyCode.S;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_8 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_8 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_8 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_12 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_12 = UnityEngine.KeyCode.W;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_12 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_12 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_12 = true;
   //pointer to script instanced logic node
   uScriptAct_SetGameObjectEulerAngles logic_uScriptAct_SetGameObjectEulerAngles_uScriptAct_SetGameObjectEulerAngles_13 = new uScriptAct_SetGameObjectEulerAngles( );
   UnityEngine.GameObject[] logic_uScriptAct_SetGameObjectEulerAngles_Target_13 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_SetGameObjectEulerAngles_X_Axis_13 = (float) 57;
   System.Boolean logic_uScriptAct_SetGameObjectEulerAngles_PreserveX_Axis_13 = (bool) false;
   System.Single logic_uScriptAct_SetGameObjectEulerAngles_Y_Axis_13 = (float) 99;
   System.Boolean logic_uScriptAct_SetGameObjectEulerAngles_PreserveY_Axis_13 = (bool) false;
   System.Single logic_uScriptAct_SetGameObjectEulerAngles_Z_Axis_13 = (float) 0;
   System.Boolean logic_uScriptAct_SetGameObjectEulerAngles_PreserveZ_Axis_13 = (bool) false;
   System.Boolean logic_uScriptAct_SetGameObjectEulerAngles_AsLocal_13 = (bool) false;
   bool logic_uScriptAct_SetGameObjectEulerAngles_Out_13 = true;
   //pointer to script instanced logic node
   uScriptAct_LookAt logic_uScriptAct_LookAt_uScriptAct_LookAt_14 = new uScriptAct_LookAt( );
   UnityEngine.GameObject[] logic_uScriptAct_LookAt_Target_14 = new UnityEngine.GameObject[] {};
   System.Object logic_uScriptAct_LookAt_Focus_14 = "";
   System.Single logic_uScriptAct_LookAt_time_14 = (float) 0;
   uScriptAct_LookAt.LockAxis logic_uScriptAct_LookAt_lockAxis_14 = uScriptAct_LookAt.LockAxis.None;
   System.Single logic_uScriptAct_LookAt_DegreesPerSecond_14 = (float) 0;
   System.Boolean logic_uScriptAct_LookAt_UseDegreesPerSecond_14 = (bool) false;
   bool logic_uScriptAct_LookAt_Out_14 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector3_v2 logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_15 = new uScriptAct_AddVector3_v2( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_A_15 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_B_15 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_Result_15;
   bool logic_uScriptAct_AddVector3_v2_Out_15 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_17 = new uScriptAct_PlaySound( );
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_17 = default(UnityEngine.AudioClip);
   UnityEngine.GameObject[] logic_uScriptAct_PlaySound_target_17 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_PlaySound_volume_17 = (float) 1;
   System.Boolean logic_uScriptAct_PlaySound_loop_17 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_17 = true;
   //pointer to script instanced logic node
   uScriptAct_AddForce logic_uScriptAct_AddForce_uScriptAct_AddForce_18 = new uScriptAct_AddForce( );
   UnityEngine.GameObject logic_uScriptAct_AddForce_Target_18 = default(UnityEngine.GameObject);
   UnityEngine.Vector3 logic_uScriptAct_AddForce_Force_18 = new Vector3( );
   System.Single logic_uScriptAct_AddForce_Scale_18 = (float) 0;
   System.Boolean logic_uScriptAct_AddForce_UseForceMode_18 = (bool) false;
   UnityEngine.ForceMode logic_uScriptAct_AddForce_ForceModeType_18 = UnityEngine.ForceMode.Force;
   bool logic_uScriptAct_AddForce_Out_18 = true;
   //pointer to script instanced logic node
   uScriptAct_AddForce logic_uScriptAct_AddForce_uScriptAct_AddForce_19 = new uScriptAct_AddForce( );
   UnityEngine.GameObject logic_uScriptAct_AddForce_Target_19 = default(UnityEngine.GameObject);
   UnityEngine.Vector3 logic_uScriptAct_AddForce_Force_19 = new Vector3( );
   System.Single logic_uScriptAct_AddForce_Scale_19 = (float) 0;
   System.Boolean logic_uScriptAct_AddForce_UseForceMode_19 = (bool) false;
   UnityEngine.ForceMode logic_uScriptAct_AddForce_ForceModeType_19 = UnityEngine.ForceMode.Force;
   bool logic_uScriptAct_AddForce_Out_19 = true;
   //pointer to script instanced logic node
   uScriptCon_Switch logic_uScriptCon_Switch_uScriptCon_Switch_20 = new uScriptCon_Switch( );
   System.Boolean logic_uScriptCon_Switch_Loop_20 = (bool) true;
   System.Int32 logic_uScriptCon_Switch_MaxOutputUsed_20 = (int) 2;
   System.Int32 logic_uScriptCon_Switch_CurrentOutput_20;
   bool logic_uScriptCon_Switch_Output1_20 = true;
   bool logic_uScriptCon_Switch_Output2_20 = true;
   bool logic_uScriptCon_Switch_Output3_20 = true;
   bool logic_uScriptCon_Switch_Output4_20 = true;
   bool logic_uScriptCon_Switch_Output5_20 = true;
   bool logic_uScriptCon_Switch_Output6_20 = true;
   bool logic_uScriptCon_Switch_Output7_20 = true;
   bool logic_uScriptCon_Switch_Output8_20 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector3_v2 logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_21 = new uScriptAct_AddVector3_v2( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_A_21 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_B_21 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_Result_21;
   bool logic_uScriptAct_AddVector3_v2_Out_21 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_22 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_22 = UnityEngine.KeyCode.D;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_22 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_22 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_22 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector3_v2 logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_23 = new uScriptAct_AddVector3_v2( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_A_23 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_B_23 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_Result_23;
   bool logic_uScriptAct_AddVector3_v2_Out_23 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_26 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_26 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_26 = true;
   bool logic_uScriptCon_CompareBool_False_26 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector3_v2 logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_27 = new uScriptAct_AddVector3_v2( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_A_27 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_B_27 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_Result_27;
   bool logic_uScriptAct_AddVector3_v2_Out_27 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_37 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_37 = UnityEngine.KeyCode.C;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_37 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_37 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_37 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_38 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_38 = UnityEngine.KeyCode.A;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_38 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_38 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_38 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_41 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_41;
   bool logic_uScriptAct_SetBool_Out_41 = true;
   bool logic_uScriptAct_SetBool_SetTrue_41 = true;
   bool logic_uScriptAct_SetBool_SetFalse_41 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector3_v2 logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_42 = new uScriptAct_AddVector3_v2( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_A_42 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_B_42 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_Result_42;
   bool logic_uScriptAct_AddVector3_v2_Out_42 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_48 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_48 = "Camera attached: ";
   System.Object[] logic_uScriptAct_Log_Target_48 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_48 = "";
   bool logic_uScriptAct_Log_Out_48 = true;
   //pointer to script instanced logic node
   uScriptAct_SetGameObjectPosition logic_uScriptAct_SetGameObjectPosition_uScriptAct_SetGameObjectPosition_49 = new uScriptAct_SetGameObjectPosition( );
   UnityEngine.GameObject[] logic_uScriptAct_SetGameObjectPosition_Target_49 = new UnityEngine.GameObject[] {};
   UnityEngine.Vector3 logic_uScriptAct_SetGameObjectPosition_Position_49 = new Vector3( (float)-14, (float)19, (float)1 );
   System.Boolean logic_uScriptAct_SetGameObjectPosition_AsOffset_49 = (bool) false;
   System.Boolean logic_uScriptAct_SetGameObjectPosition_AsLocal_49 = (bool) false;
   bool logic_uScriptAct_SetGameObjectPosition_Out_49 = true;
   //pointer to script instanced logic node
   uScriptAct_GetPositionAndRotation logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_50 = new uScriptAct_GetPositionAndRotation( );
   UnityEngine.GameObject logic_uScriptAct_GetPositionAndRotation_Target_50 = default(UnityEngine.GameObject);
   System.Boolean logic_uScriptAct_GetPositionAndRotation_GetLocal_50 = (bool) false;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Position_50;
   UnityEngine.Quaternion logic_uScriptAct_GetPositionAndRotation_Rotation_50;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_EulerAngles_50;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Forward_50;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Up_50;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Right_50;
   bool logic_uScriptAct_GetPositionAndRotation_Out_50 = true;
   //pointer to script instanced logic node
   uScriptAct_AddForce logic_uScriptAct_AddForce_uScriptAct_AddForce_52 = new uScriptAct_AddForce( );
   UnityEngine.GameObject logic_uScriptAct_AddForce_Target_52 = default(UnityEngine.GameObject);
   UnityEngine.Vector3 logic_uScriptAct_AddForce_Force_52 = new Vector3( );
   System.Single logic_uScriptAct_AddForce_Scale_52 = (float) 0;
   System.Boolean logic_uScriptAct_AddForce_UseForceMode_52 = (bool) true;
   UnityEngine.ForceMode logic_uScriptAct_AddForce_ForceModeType_52 = UnityEngine.ForceMode.Impulse;
   bool logic_uScriptAct_AddForce_Out_52 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_54 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_54 = UnityEngine.KeyCode.Space;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_54 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_54 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_54 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareGameObjects logic_uScriptCon_CompareGameObjects_uScriptCon_CompareGameObjects_60 = new uScriptCon_CompareGameObjects( );
   UnityEngine.GameObject logic_uScriptCon_CompareGameObjects_A_60 = default(UnityEngine.GameObject);
   UnityEngine.GameObject logic_uScriptCon_CompareGameObjects_B_60 = default(UnityEngine.GameObject);
   System.Boolean logic_uScriptCon_CompareGameObjects_CompareByTag_60 = (bool) false;
   System.Boolean logic_uScriptCon_CompareGameObjects_CompareByName_60 = (bool) false;
   System.Boolean logic_uScriptCon_CompareGameObjects_ReportNull_60 = (bool) true;
   bool logic_uScriptCon_CompareGameObjects_Same_60 = true;
   bool logic_uScriptCon_CompareGameObjects_Different_60 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_62 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_62 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_62 = true;
   bool logic_uScriptCon_CompareBool_False_62 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_63 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_63;
   bool logic_uScriptAct_SetBool_Out_63 = true;
   bool logic_uScriptAct_SetBool_SetTrue_63 = true;
   bool logic_uScriptAct_SetBool_SetFalse_63 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_65 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_65;
   bool logic_uScriptAct_SetBool_Out_65 = true;
   bool logic_uScriptAct_SetBool_SetTrue_65 = true;
   bool logic_uScriptAct_SetBool_SetFalse_65 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_68 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_68 = "Press W, A, S, D to move. Spacebar for Jump.";
   System.Int32 logic_uScriptAct_PrintText_FontSize_68 = (int) 16;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_68 = UnityEngine.FontStyle.Normal;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_68 = new UnityEngine.Color( (float)1, (float)1, (float)1, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_68 = UnityEngine.TextAnchor.UpperCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_68 = (int) 16;
   System.Single logic_uScriptAct_PrintText_time_68 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_68 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_69 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_69 = "Press C to toggle cameras.";
   System.Int32 logic_uScriptAct_PrintText_FontSize_69 = (int) 16;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_69 = UnityEngine.FontStyle.Normal;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_69 = new UnityEngine.Color( (float)1, (float)1, (float)1, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_69 = UnityEngine.TextAnchor.UpperCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_69 = (int) 64;
   System.Single logic_uScriptAct_PrintText_time_69 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_69 = true;
   //pointer to script instanced logic node
   uScriptAct_LoadAudioClip logic_uScriptAct_LoadAudioClip_uScriptAct_LoadAudioClip_70 = new uScriptAct_LoadAudioClip( );
   System.String logic_uScriptAct_LoadAudioClip_name_70 = "Audio/PlayerJump";
   UnityEngine.AudioClip logic_uScriptAct_LoadAudioClip_audioClip_70;
   bool logic_uScriptAct_LoadAudioClip_Out_70 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_0 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_1 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_7 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_33 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_36 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_43 = default(UnityEngine.GameObject);
   UnityEngine.Vector3 event_UnityEngine_GameObject_RelativeVelocity_44 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Rigidbody event_UnityEngine_GameObject_RigidBody_44 = default(UnityEngine.Rigidbody);
   UnityEngine.Collider event_UnityEngine_GameObject_Collider_44 = default(UnityEngine.Collider);
   UnityEngine.Transform event_UnityEngine_GameObject_Transform_44 = default(UnityEngine.Transform);
   UnityEngine.ContactPoint[] event_UnityEngine_GameObject_Contacts_44 = new UnityEngine.ContactPoint[ 0 ];
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_44 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_55 = default(UnityEngine.GameObject);
   UnityEngine.Vector3 event_UnityEngine_GameObject_RelativeVelocity_56 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Rigidbody event_UnityEngine_GameObject_RigidBody_56 = default(UnityEngine.Rigidbody);
   UnityEngine.Collider event_UnityEngine_GameObject_Collider_56 = default(UnityEngine.Collider);
   UnityEngine.Transform event_UnityEngine_GameObject_Transform_56 = default(UnityEngine.Transform);
   UnityEngine.ContactPoint[] event_UnityEngine_GameObject_Contacts_56 = new UnityEngine.ContactPoint[ 0 ];
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_56 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_67 = default(UnityEngine.GameObject);
   
   //property nodes
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_34 = new Vector3( );
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_34 = default(UnityEngine.GameObject);
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_34_previous = null;
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_34_Get_Refresh( )
   {
      UnityEngine.Transform component = null;
      if (property_position_Detox_ScriptEditor_Parameter_Instance_34 != null)
      {
         component = property_position_Detox_ScriptEditor_Parameter_Instance_34.GetComponent<UnityEngine.Transform>();
      }
      if ( null != component )
      {
         return component.position;
      }
      else
      {
         return new Vector3( );
      }
   }
   
   void property_position_Detox_ScriptEditor_Parameter_position_34_Set_Refresh( )
   {
      UnityEngine.Transform component = null;
      if (property_position_Detox_ScriptEditor_Parameter_Instance_34 != null)
      {
         component = property_position_Detox_ScriptEditor_Parameter_Instance_34.GetComponent<UnityEngine.Transform>();
      }
      if ( null != component )
      {
         component.position = property_position_Detox_ScriptEditor_Parameter_position_34;
      }
   }
   
   
   void SyncUnityHooks( )
   {
      if ( null == property_position_Detox_ScriptEditor_Parameter_Instance_34 || false == m_RegisteredForEvents )
      {
         property_position_Detox_ScriptEditor_Parameter_Instance_34 = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_34_previous != property_position_Detox_ScriptEditor_Parameter_Instance_34 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_34_previous = property_position_Detox_ScriptEditor_Parameter_Instance_34;
         
         //setup new listeners
      }
      SyncEventListeners( );
      if ( null == local_9_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_9_UnityEngine_GameObject = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_9_UnityEngine_GameObject_previous != local_9_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_9_UnityEngine_GameObject_previous = local_9_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_28_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_28_UnityEngine_GameObject = GameObject.Find( "Sphere" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_28_UnityEngine_GameObject_previous != local_28_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_28_UnityEngine_GameObject_previous = local_28_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_29_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_29_UnityEngine_GameObject = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_29_UnityEngine_GameObject_previous != local_29_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_29_UnityEngine_GameObject_previous = local_29_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_30_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_30_UnityEngine_GameObject = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_30_UnityEngine_GameObject_previous != local_30_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_30_UnityEngine_GameObject_previous = local_30_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_39_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_39_UnityEngine_GameObject = GameObject.Find( "Sphere" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_39_UnityEngine_GameObject_previous != local_39_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_39_UnityEngine_GameObject_previous )
         {
            {
               uScript_Collision component = local_39_UnityEngine_GameObject_previous.GetComponent<uScript_Collision>();
               if ( null != component )
               {
                  component.OnEnterCollision -= Instance_OnEnterCollision_44;
                  component.OnExitCollision -= Instance_OnExitCollision_44;
                  component.WhileInsideCollision -= Instance_WhileInsideCollision_44;
               }
            }
         }
         
         local_39_UnityEngine_GameObject_previous = local_39_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_39_UnityEngine_GameObject )
         {
            {
               uScript_Collision component = local_39_UnityEngine_GameObject.GetComponent<uScript_Collision>();
               if ( null == component )
               {
                  component = local_39_UnityEngine_GameObject.AddComponent<uScript_Collision>();
               }
               if ( null != component )
               {
                  component.OnEnterCollision += Instance_OnEnterCollision_44;
                  component.OnExitCollision += Instance_OnExitCollision_44;
                  component.WhileInsideCollision += Instance_WhileInsideCollision_44;
               }
            }
         }
      }
      if ( null == local_51_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_51_UnityEngine_GameObject = GameObject.Find( "Geometry" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_51_UnityEngine_GameObject_previous != local_51_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_51_UnityEngine_GameObject_previous = local_51_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_58_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_58_UnityEngine_GameObject = GameObject.Find( "Sphere" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_58_UnityEngine_GameObject_previous != local_58_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_58_UnityEngine_GameObject_previous )
         {
            {
               uScript_Collision component = local_58_UnityEngine_GameObject_previous.GetComponent<uScript_Collision>();
               if ( null != component )
               {
                  component.OnEnterCollision -= Instance_OnEnterCollision_56;
                  component.OnExitCollision -= Instance_OnExitCollision_56;
                  component.WhileInsideCollision -= Instance_WhileInsideCollision_56;
               }
            }
         }
         
         local_58_UnityEngine_GameObject_previous = local_58_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_58_UnityEngine_GameObject )
         {
            {
               uScript_Collision component = local_58_UnityEngine_GameObject.GetComponent<uScript_Collision>();
               if ( null == component )
               {
                  component = local_58_UnityEngine_GameObject.AddComponent<uScript_Collision>();
               }
               if ( null != component )
               {
                  component.OnEnterCollision += Instance_OnEnterCollision_56;
                  component.OnExitCollision += Instance_OnExitCollision_56;
                  component.WhileInsideCollision += Instance_WhileInsideCollision_56;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_59_UnityEngine_GameObject_previous != local_59_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_59_UnityEngine_GameObject_previous = local_59_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_61_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_61_UnityEngine_GameObject = GameObject.Find( "Ground" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_61_UnityEngine_GameObject_previous != local_61_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_61_UnityEngine_GameObject_previous = local_61_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void RegisterForUnityHooks( )
   {
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_34_previous != property_position_Detox_ScriptEditor_Parameter_Instance_34 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_34_previous = property_position_Detox_ScriptEditor_Parameter_Instance_34;
         
         //setup new listeners
      }
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_9_UnityEngine_GameObject_previous != local_9_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_9_UnityEngine_GameObject_previous = local_9_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_28_UnityEngine_GameObject_previous != local_28_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_28_UnityEngine_GameObject_previous = local_28_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_29_UnityEngine_GameObject_previous != local_29_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_29_UnityEngine_GameObject_previous = local_29_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_30_UnityEngine_GameObject_previous != local_30_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_30_UnityEngine_GameObject_previous = local_30_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_39_UnityEngine_GameObject_previous != local_39_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_39_UnityEngine_GameObject_previous )
         {
            {
               uScript_Collision component = local_39_UnityEngine_GameObject_previous.GetComponent<uScript_Collision>();
               if ( null != component )
               {
                  component.OnEnterCollision -= Instance_OnEnterCollision_44;
                  component.OnExitCollision -= Instance_OnExitCollision_44;
                  component.WhileInsideCollision -= Instance_WhileInsideCollision_44;
               }
            }
         }
         
         local_39_UnityEngine_GameObject_previous = local_39_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_39_UnityEngine_GameObject )
         {
            {
               uScript_Collision component = local_39_UnityEngine_GameObject.GetComponent<uScript_Collision>();
               if ( null == component )
               {
                  component = local_39_UnityEngine_GameObject.AddComponent<uScript_Collision>();
               }
               if ( null != component )
               {
                  component.OnEnterCollision += Instance_OnEnterCollision_44;
                  component.OnExitCollision += Instance_OnExitCollision_44;
                  component.WhileInsideCollision += Instance_WhileInsideCollision_44;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_51_UnityEngine_GameObject_previous != local_51_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_51_UnityEngine_GameObject_previous = local_51_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_58_UnityEngine_GameObject_previous != local_58_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_58_UnityEngine_GameObject_previous )
         {
            {
               uScript_Collision component = local_58_UnityEngine_GameObject_previous.GetComponent<uScript_Collision>();
               if ( null != component )
               {
                  component.OnEnterCollision -= Instance_OnEnterCollision_56;
                  component.OnExitCollision -= Instance_OnExitCollision_56;
                  component.WhileInsideCollision -= Instance_WhileInsideCollision_56;
               }
            }
         }
         
         local_58_UnityEngine_GameObject_previous = local_58_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_58_UnityEngine_GameObject )
         {
            {
               uScript_Collision component = local_58_UnityEngine_GameObject.GetComponent<uScript_Collision>();
               if ( null == component )
               {
                  component = local_58_UnityEngine_GameObject.AddComponent<uScript_Collision>();
               }
               if ( null != component )
               {
                  component.OnEnterCollision += Instance_OnEnterCollision_56;
                  component.OnExitCollision += Instance_OnExitCollision_56;
                  component.WhileInsideCollision += Instance_WhileInsideCollision_56;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_59_UnityEngine_GameObject_previous != local_59_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_59_UnityEngine_GameObject_previous = local_59_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_61_UnityEngine_GameObject_previous != local_61_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_61_UnityEngine_GameObject_previous = local_61_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void SyncEventListeners( )
   {
      {
         {
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( property_position_Detox_ScriptEditor_Parameter_Instance_34_previous != property_position_Detox_ScriptEditor_Parameter_Instance_34 || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  property_position_Detox_ScriptEditor_Parameter_Instance_34_previous = property_position_Detox_ScriptEditor_Parameter_Instance_34;
                  
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
      if ( null == event_UnityEngine_GameObject_Instance_1 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_1 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_1 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_1.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_1.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_1;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_7 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_7 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_7 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_7.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_7.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_7;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_33 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_33 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_33 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_33.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_33.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_33;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_36 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_36 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_36 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_36.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_36.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_36;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_43 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_43 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_43 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_43.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_43.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_43;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_55 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_55 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_55 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_55.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_55.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_55;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_67 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_67 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_67 )
         {
            {
               uScript_Global component = event_UnityEngine_GameObject_Instance_67.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_67.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_67;
                  component.uScriptLateStart += Instance_uScriptLateStart_67;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != local_39_UnityEngine_GameObject )
      {
         {
            uScript_Collision component = local_39_UnityEngine_GameObject.GetComponent<uScript_Collision>();
            if ( null != component )
            {
               component.OnEnterCollision -= Instance_OnEnterCollision_44;
               component.OnExitCollision -= Instance_OnExitCollision_44;
               component.WhileInsideCollision -= Instance_WhileInsideCollision_44;
            }
         }
      }
      if ( null != local_58_UnityEngine_GameObject )
      {
         {
            uScript_Collision component = local_58_UnityEngine_GameObject.GetComponent<uScript_Collision>();
            if ( null != component )
            {
               component.OnEnterCollision -= Instance_OnEnterCollision_56;
               component.OnExitCollision -= Instance_OnExitCollision_56;
               component.WhileInsideCollision -= Instance_WhileInsideCollision_56;
            }
         }
      }
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
      if ( null != event_UnityEngine_GameObject_Instance_1 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_1.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_1;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_7 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_7.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_7;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_33 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_33.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_33;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_36 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_36.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_36;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_43 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_43.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_43;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_55 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_55.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_55;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_67 )
      {
         {
            uScript_Global component = event_UnityEngine_GameObject_Instance_67.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_67;
               component.uScriptLateStart -= Instance_uScriptLateStart_67;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_AddForce_uScriptAct_AddForce_3.SetParent(g);
      logic_uScriptAct_AddForce_uScriptAct_AddForce_4.SetParent(g);
      logic_uScriptAct_SetVector3_uScriptAct_SetVector3_5.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_12.SetParent(g);
      logic_uScriptAct_SetGameObjectEulerAngles_uScriptAct_SetGameObjectEulerAngles_13.SetParent(g);
      logic_uScriptAct_LookAt_uScriptAct_LookAt_14.SetParent(g);
      logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_15.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_17.SetParent(g);
      logic_uScriptAct_AddForce_uScriptAct_AddForce_18.SetParent(g);
      logic_uScriptAct_AddForce_uScriptAct_AddForce_19.SetParent(g);
      logic_uScriptCon_Switch_uScriptCon_Switch_20.SetParent(g);
      logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_21.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_22.SetParent(g);
      logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_23.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_26.SetParent(g);
      logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_27.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_37.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_38.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_41.SetParent(g);
      logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_42.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_48.SetParent(g);
      logic_uScriptAct_SetGameObjectPosition_uScriptAct_SetGameObjectPosition_49.SetParent(g);
      logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_50.SetParent(g);
      logic_uScriptAct_AddForce_uScriptAct_AddForce_52.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_54.SetParent(g);
      logic_uScriptCon_CompareGameObjects_uScriptCon_CompareGameObjects_60.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_62.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_63.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_65.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_68.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_69.SetParent(g);
      logic_uScriptAct_LoadAudioClip_uScriptAct_LoadAudioClip_70.SetParent(g);
   }
   public void Awake()
   {
      
      logic_uScriptAct_LookAt_uScriptAct_LookAt_14.Finished += uScriptAct_LookAt_Finished_14;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_17.Finished += uScriptAct_PlaySound_Finished_17;
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
      
      logic_uScriptAct_LookAt_uScriptAct_LookAt_14.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_17.Update( );
   }
   
   public void OnDestroy()
   {
      logic_uScriptAct_LookAt_uScriptAct_LookAt_14.Finished -= uScriptAct_LookAt_Finished_14;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_17.Finished -= uScriptAct_PlaySound_Finished_17;
   }
   
   public void OnGUI()
   {
      logic_uScriptAct_PrintText_uScriptAct_PrintText_68.OnGUI( );
      logic_uScriptAct_PrintText_uScriptAct_PrintText_69.OnGUI( );
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
   
   void Instance_KeyEvent_1(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_1( );
   }
   
   void Instance_KeyEvent_7(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_7( );
   }
   
   void Instance_KeyEvent_33(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_33( );
   }
   
   void Instance_KeyEvent_36(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_36( );
   }
   
   void Instance_KeyEvent_43(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_43( );
   }
   
   void Instance_OnEnterCollision_44(object o, uScript_Collision.CollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_RelativeVelocity_44 = e.RelativeVelocity;
      event_UnityEngine_GameObject_RigidBody_44 = e.RigidBody;
      event_UnityEngine_GameObject_Collider_44 = e.Collider;
      event_UnityEngine_GameObject_Transform_44 = e.Transform;
      event_UnityEngine_GameObject_Contacts_44 = e.Contacts;
      event_UnityEngine_GameObject_GameObject_44 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterCollision_44( );
   }
   
   void Instance_OnExitCollision_44(object o, uScript_Collision.CollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_RelativeVelocity_44 = e.RelativeVelocity;
      event_UnityEngine_GameObject_RigidBody_44 = e.RigidBody;
      event_UnityEngine_GameObject_Collider_44 = e.Collider;
      event_UnityEngine_GameObject_Transform_44 = e.Transform;
      event_UnityEngine_GameObject_Contacts_44 = e.Contacts;
      event_UnityEngine_GameObject_GameObject_44 = e.GameObject;
      //relay event to nodes
      Relay_OnExitCollision_44( );
   }
   
   void Instance_WhileInsideCollision_44(object o, uScript_Collision.CollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_RelativeVelocity_44 = e.RelativeVelocity;
      event_UnityEngine_GameObject_RigidBody_44 = e.RigidBody;
      event_UnityEngine_GameObject_Collider_44 = e.Collider;
      event_UnityEngine_GameObject_Transform_44 = e.Transform;
      event_UnityEngine_GameObject_Contacts_44 = e.Contacts;
      event_UnityEngine_GameObject_GameObject_44 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideCollision_44( );
   }
   
   void Instance_KeyEvent_55(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_55( );
   }
   
   void Instance_OnEnterCollision_56(object o, uScript_Collision.CollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_RelativeVelocity_56 = e.RelativeVelocity;
      event_UnityEngine_GameObject_RigidBody_56 = e.RigidBody;
      event_UnityEngine_GameObject_Collider_56 = e.Collider;
      event_UnityEngine_GameObject_Transform_56 = e.Transform;
      event_UnityEngine_GameObject_Contacts_56 = e.Contacts;
      event_UnityEngine_GameObject_GameObject_56 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterCollision_56( );
   }
   
   void Instance_OnExitCollision_56(object o, uScript_Collision.CollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_RelativeVelocity_56 = e.RelativeVelocity;
      event_UnityEngine_GameObject_RigidBody_56 = e.RigidBody;
      event_UnityEngine_GameObject_Collider_56 = e.Collider;
      event_UnityEngine_GameObject_Transform_56 = e.Transform;
      event_UnityEngine_GameObject_Contacts_56 = e.Contacts;
      event_UnityEngine_GameObject_GameObject_56 = e.GameObject;
      //relay event to nodes
      Relay_OnExitCollision_56( );
   }
   
   void Instance_WhileInsideCollision_56(object o, uScript_Collision.CollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_RelativeVelocity_56 = e.RelativeVelocity;
      event_UnityEngine_GameObject_RigidBody_56 = e.RigidBody;
      event_UnityEngine_GameObject_Collider_56 = e.Collider;
      event_UnityEngine_GameObject_Transform_56 = e.Transform;
      event_UnityEngine_GameObject_Contacts_56 = e.Contacts;
      event_UnityEngine_GameObject_GameObject_56 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideCollision_56( );
   }
   
   void Instance_uScriptStart_67(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_67( );
   }
   
   void Instance_uScriptLateStart_67(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptLateStart_67( );
   }
   
   void uScriptAct_LookAt_Finished_14(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_14( );
   }
   
   void uScriptAct_PlaySound_Finished_17(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_17( );
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
      Relay_In_26();
   }
   
   void Relay_KeyEvent_1()
   {
      if (true == CheckDebugBreak("49d038d9-23ca-46fd-a197-3c6e3a04e69a", "Input_Events", Relay_KeyEvent_1)) return; 
      Relay_In_12();
   }
   
   void Relay_In_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2a9d0a59-2474-4371-9fed-a43812d3e5e8", "Add_Force", Relay_In_3)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_39_UnityEngine_GameObject_previous != local_39_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     if ( null != local_39_UnityEngine_GameObject_previous )
                     {
                        {
                           uScript_Collision component = local_39_UnityEngine_GameObject_previous.GetComponent<uScript_Collision>();
                           if ( null != component )
                           {
                              component.OnEnterCollision -= Instance_OnEnterCollision_44;
                              component.OnExitCollision -= Instance_OnExitCollision_44;
                              component.WhileInsideCollision -= Instance_WhileInsideCollision_44;
                           }
                        }
                     }
                     
                     local_39_UnityEngine_GameObject_previous = local_39_UnityEngine_GameObject;
                     
                     //setup new listeners
                     if ( null != local_39_UnityEngine_GameObject )
                     {
                        {
                           uScript_Collision component = local_39_UnityEngine_GameObject.GetComponent<uScript_Collision>();
                           if ( null == component )
                           {
                              component = local_39_UnityEngine_GameObject.AddComponent<uScript_Collision>();
                           }
                           if ( null != component )
                           {
                              component.OnEnterCollision += Instance_OnEnterCollision_44;
                              component.OnExitCollision += Instance_OnExitCollision_44;
                              component.WhileInsideCollision += Instance_WhileInsideCollision_44;
                           }
                        }
                     }
                  }
               }
               logic_uScriptAct_AddForce_Target_3 = local_39_UnityEngine_GameObject;
               
            }
            {
               logic_uScriptAct_AddForce_Force_3 = local_6_UnityEngine_Vector3;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddForce_uScriptAct_AddForce_3.In(logic_uScriptAct_AddForce_Target_3, logic_uScriptAct_AddForce_Force_3, logic_uScriptAct_AddForce_Scale_3, logic_uScriptAct_AddForce_UseForceMode_3, logic_uScriptAct_AddForce_ForceModeType_3);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Add Force.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_4()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a71ac3c4-a17c-47f3-ab39-87d02c43084b", "Add_Force", Relay_In_4)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_39_UnityEngine_GameObject_previous != local_39_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     if ( null != local_39_UnityEngine_GameObject_previous )
                     {
                        {
                           uScript_Collision component = local_39_UnityEngine_GameObject_previous.GetComponent<uScript_Collision>();
                           if ( null != component )
                           {
                              component.OnEnterCollision -= Instance_OnEnterCollision_44;
                              component.OnExitCollision -= Instance_OnExitCollision_44;
                              component.WhileInsideCollision -= Instance_WhileInsideCollision_44;
                           }
                        }
                     }
                     
                     local_39_UnityEngine_GameObject_previous = local_39_UnityEngine_GameObject;
                     
                     //setup new listeners
                     if ( null != local_39_UnityEngine_GameObject )
                     {
                        {
                           uScript_Collision component = local_39_UnityEngine_GameObject.GetComponent<uScript_Collision>();
                           if ( null == component )
                           {
                              component = local_39_UnityEngine_GameObject.AddComponent<uScript_Collision>();
                           }
                           if ( null != component )
                           {
                              component.OnEnterCollision += Instance_OnEnterCollision_44;
                              component.OnExitCollision += Instance_OnExitCollision_44;
                              component.WhileInsideCollision += Instance_WhileInsideCollision_44;
                           }
                        }
                     }
                  }
               }
               logic_uScriptAct_AddForce_Target_4 = local_39_UnityEngine_GameObject;
               
            }
            {
               logic_uScriptAct_AddForce_Force_4 = local_40_UnityEngine_Vector3;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddForce_uScriptAct_AddForce_4.In(logic_uScriptAct_AddForce_Target_4, logic_uScriptAct_AddForce_Force_4, logic_uScriptAct_AddForce_Scale_4, logic_uScriptAct_AddForce_UseForceMode_4, logic_uScriptAct_AddForce_ForceModeType_4);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Add Force.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0c3f67ea-e9cf-471e-8e4e-884156667bb2", "Set_Vector3", Relay_In_5)) return; 
         {
            {
               logic_uScriptAct_SetVector3_Value_5 = local_25_UnityEngine_Vector3;
               
            }
            {
            }
         }
         logic_uScriptAct_SetVector3_uScriptAct_SetVector3_5.In(logic_uScriptAct_SetVector3_Value_5, out logic_uScriptAct_SetVector3_TargetVector3_5);
         property_position_Detox_ScriptEditor_Parameter_position_34 = logic_uScriptAct_SetVector3_TargetVector3_5;
         property_position_Detox_ScriptEditor_Parameter_position_34_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetVector3_uScriptAct_SetVector3_5.Out;
         
         if ( test_0 == true )
         {
            Relay_In_14();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Set Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_7()
   {
      if (true == CheckDebugBreak("d6d74250-8094-462b-8b7a-fa6005d4dc0e", "Input_Events", Relay_KeyEvent_7)) return; 
      Relay_In_8();
   }
   
   void Relay_In_8()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2af320e9-a78d-4fad-8f17-862b1d0cf678", "Input_Events_Filter", Relay_In_8)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.In(logic_uScriptAct_OnInputEventFilter_KeyCode_8);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_In_27();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_12()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c1e6d87e-45c3-469a-8243-c072f7ed97a7", "Input_Events_Filter", Relay_In_12)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_12.In(logic_uScriptAct_OnInputEventFilter_KeyCode_12);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_12.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_In_15();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_13()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("025b3342-e5c9-4f11-adcf-afbc228558ae", "Set_Euler_Angles", Relay_In_13)) return; 
         {
            {
               int index = 0;
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_30_UnityEngine_GameObject_previous != local_30_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_30_UnityEngine_GameObject_previous = local_30_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               if ( logic_uScriptAct_SetGameObjectEulerAngles_Target_13.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_SetGameObjectEulerAngles_Target_13, index + 1);
               }
               logic_uScriptAct_SetGameObjectEulerAngles_Target_13[ index++ ] = local_30_UnityEngine_GameObject;
               
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
         logic_uScriptAct_SetGameObjectEulerAngles_uScriptAct_SetGameObjectEulerAngles_13.In(logic_uScriptAct_SetGameObjectEulerAngles_Target_13, logic_uScriptAct_SetGameObjectEulerAngles_X_Axis_13, logic_uScriptAct_SetGameObjectEulerAngles_PreserveX_Axis_13, logic_uScriptAct_SetGameObjectEulerAngles_Y_Axis_13, logic_uScriptAct_SetGameObjectEulerAngles_PreserveY_Axis_13, logic_uScriptAct_SetGameObjectEulerAngles_Z_Axis_13, logic_uScriptAct_SetGameObjectEulerAngles_PreserveZ_Axis_13, logic_uScriptAct_SetGameObjectEulerAngles_AsLocal_13);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetGameObjectEulerAngles_uScriptAct_SetGameObjectEulerAngles_13.Out;
         
         if ( test_0 == true )
         {
            Relay_In_49();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Set Euler Angles.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_14()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("cf7c11d6-27b6-447b-a135-c1d531d7f4d4", "Look_At", Relay_Finished_14)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Look At.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_14()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("cf7c11d6-27b6-447b-a135-c1d531d7f4d4", "Look_At", Relay_In_14)) return; 
         {
            {
               int index = 0;
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_9_UnityEngine_GameObject_previous != local_9_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_9_UnityEngine_GameObject_previous = local_9_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               if ( logic_uScriptAct_LookAt_Target_14.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_LookAt_Target_14, index + 1);
               }
               logic_uScriptAct_LookAt_Target_14[ index++ ] = local_9_UnityEngine_GameObject;
               
            }
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_28_UnityEngine_GameObject_previous != local_28_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_28_UnityEngine_GameObject_previous = local_28_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_LookAt_Focus_14 = local_28_UnityEngine_GameObject;
               
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
         logic_uScriptAct_LookAt_uScriptAct_LookAt_14.In(logic_uScriptAct_LookAt_Target_14, logic_uScriptAct_LookAt_Focus_14, logic_uScriptAct_LookAt_time_14, logic_uScriptAct_LookAt_lockAxis_14, logic_uScriptAct_LookAt_DegreesPerSecond_14, logic_uScriptAct_LookAt_UseDegreesPerSecond_14);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Look At.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_15()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a7784265-1624-4584-bc4e-0f9d2573f7d3", "Add_Vector3", Relay_In_15)) return; 
         {
            {
               logic_uScriptAct_AddVector3_v2_A_15 = local_16_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_AddVector3_v2_B_15 = local_6_UnityEngine_Vector3;
               
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_15.In(logic_uScriptAct_AddVector3_v2_A_15, logic_uScriptAct_AddVector3_v2_B_15, out logic_uScriptAct_AddVector3_v2_Result_15);
         local_16_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_v2_Result_15;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_15.Out;
         
         if ( test_0 == true )
         {
            Relay_In_3();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_17()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("90113637-b515-4642-93d4-0c48a9d55dfb", "Play_Sound", Relay_Finished_17)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Play_17()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("90113637-b515-4642-93d4-0c48a9d55dfb", "Play_Sound", Relay_Play_17)) return; 
         {
            {
               logic_uScriptAct_PlaySound_audioClip_17 = local_Col_Sound_UnityEngine_AudioClip;
               
            }
            {
               int index = 0;
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_29_UnityEngine_GameObject_previous != local_29_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_29_UnityEngine_GameObject_previous = local_29_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               if ( logic_uScriptAct_PlaySound_target_17.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_PlaySound_target_17, index + 1);
               }
               logic_uScriptAct_PlaySound_target_17[ index++ ] = local_29_UnityEngine_GameObject;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_17.Play(logic_uScriptAct_PlaySound_audioClip_17, logic_uScriptAct_PlaySound_target_17, logic_uScriptAct_PlaySound_volume_17, logic_uScriptAct_PlaySound_loop_17);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_UpdateVolume_17()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("90113637-b515-4642-93d4-0c48a9d55dfb", "Play_Sound", Relay_UpdateVolume_17)) return; 
         {
            {
               logic_uScriptAct_PlaySound_audioClip_17 = local_Col_Sound_UnityEngine_AudioClip;
               
            }
            {
               int index = 0;
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_29_UnityEngine_GameObject_previous != local_29_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_29_UnityEngine_GameObject_previous = local_29_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               if ( logic_uScriptAct_PlaySound_target_17.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_PlaySound_target_17, index + 1);
               }
               logic_uScriptAct_PlaySound_target_17[ index++ ] = local_29_UnityEngine_GameObject;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_17.UpdateVolume(logic_uScriptAct_PlaySound_audioClip_17, logic_uScriptAct_PlaySound_target_17, logic_uScriptAct_PlaySound_volume_17, logic_uScriptAct_PlaySound_loop_17);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_17()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("90113637-b515-4642-93d4-0c48a9d55dfb", "Play_Sound", Relay_Stop_17)) return; 
         {
            {
               logic_uScriptAct_PlaySound_audioClip_17 = local_Col_Sound_UnityEngine_AudioClip;
               
            }
            {
               int index = 0;
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_29_UnityEngine_GameObject_previous != local_29_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_29_UnityEngine_GameObject_previous = local_29_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               if ( logic_uScriptAct_PlaySound_target_17.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_PlaySound_target_17, index + 1);
               }
               logic_uScriptAct_PlaySound_target_17[ index++ ] = local_29_UnityEngine_GameObject;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_17.Stop(logic_uScriptAct_PlaySound_audioClip_17, logic_uScriptAct_PlaySound_target_17, logic_uScriptAct_PlaySound_volume_17, logic_uScriptAct_PlaySound_loop_17);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_18()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a9e6eda8-0032-46cc-9b72-efcb8ac848e2", "Add_Force", Relay_In_18)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_39_UnityEngine_GameObject_previous != local_39_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     if ( null != local_39_UnityEngine_GameObject_previous )
                     {
                        {
                           uScript_Collision component = local_39_UnityEngine_GameObject_previous.GetComponent<uScript_Collision>();
                           if ( null != component )
                           {
                              component.OnEnterCollision -= Instance_OnEnterCollision_44;
                              component.OnExitCollision -= Instance_OnExitCollision_44;
                              component.WhileInsideCollision -= Instance_WhileInsideCollision_44;
                           }
                        }
                     }
                     
                     local_39_UnityEngine_GameObject_previous = local_39_UnityEngine_GameObject;
                     
                     //setup new listeners
                     if ( null != local_39_UnityEngine_GameObject )
                     {
                        {
                           uScript_Collision component = local_39_UnityEngine_GameObject.GetComponent<uScript_Collision>();
                           if ( null == component )
                           {
                              component = local_39_UnityEngine_GameObject.AddComponent<uScript_Collision>();
                           }
                           if ( null != component )
                           {
                              component.OnEnterCollision += Instance_OnEnterCollision_44;
                              component.OnExitCollision += Instance_OnExitCollision_44;
                              component.WhileInsideCollision += Instance_WhileInsideCollision_44;
                           }
                        }
                     }
                  }
               }
               logic_uScriptAct_AddForce_Target_18 = local_39_UnityEngine_GameObject;
               
            }
            {
               logic_uScriptAct_AddForce_Force_18 = local_31_UnityEngine_Vector3;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddForce_uScriptAct_AddForce_18.In(logic_uScriptAct_AddForce_Target_18, logic_uScriptAct_AddForce_Force_18, logic_uScriptAct_AddForce_Scale_18, logic_uScriptAct_AddForce_UseForceMode_18, logic_uScriptAct_AddForce_ForceModeType_18);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Add Force.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_19()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("310b76aa-7f2a-41ab-b27f-99ca03e51a22", "Add_Force", Relay_In_19)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_39_UnityEngine_GameObject_previous != local_39_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     if ( null != local_39_UnityEngine_GameObject_previous )
                     {
                        {
                           uScript_Collision component = local_39_UnityEngine_GameObject_previous.GetComponent<uScript_Collision>();
                           if ( null != component )
                           {
                              component.OnEnterCollision -= Instance_OnEnterCollision_44;
                              component.OnExitCollision -= Instance_OnExitCollision_44;
                              component.WhileInsideCollision -= Instance_WhileInsideCollision_44;
                           }
                        }
                     }
                     
                     local_39_UnityEngine_GameObject_previous = local_39_UnityEngine_GameObject;
                     
                     //setup new listeners
                     if ( null != local_39_UnityEngine_GameObject )
                     {
                        {
                           uScript_Collision component = local_39_UnityEngine_GameObject.GetComponent<uScript_Collision>();
                           if ( null == component )
                           {
                              component = local_39_UnityEngine_GameObject.AddComponent<uScript_Collision>();
                           }
                           if ( null != component )
                           {
                              component.OnEnterCollision += Instance_OnEnterCollision_44;
                              component.OnExitCollision += Instance_OnExitCollision_44;
                              component.WhileInsideCollision += Instance_WhileInsideCollision_44;
                           }
                        }
                     }
                  }
               }
               logic_uScriptAct_AddForce_Target_19 = local_39_UnityEngine_GameObject;
               
            }
            {
               logic_uScriptAct_AddForce_Force_19 = local_46_UnityEngine_Vector3;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddForce_uScriptAct_AddForce_19.In(logic_uScriptAct_AddForce_Target_19, logic_uScriptAct_AddForce_Force_19, logic_uScriptAct_AddForce_Scale_19, logic_uScriptAct_AddForce_UseForceMode_19, logic_uScriptAct_AddForce_ForceModeType_19);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Add Force.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_20()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0d80325c-505b-4452-aa64-f44f72f78f3d", "Switch", Relay_In_20)) return; 
         {
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptCon_Switch_uScriptCon_Switch_20.In(logic_uScriptCon_Switch_Loop_20, logic_uScriptCon_Switch_MaxOutputUsed_20, out logic_uScriptCon_Switch_CurrentOutput_20);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_Switch_uScriptCon_Switch_20.Output1;
         bool test_1 = logic_uScriptCon_Switch_uScriptCon_Switch_20.Output2;
         
         if ( test_0 == true )
         {
            Relay_True_41();
         }
         if ( test_1 == true )
         {
            Relay_False_41();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Switch.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Reset_20()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0d80325c-505b-4452-aa64-f44f72f78f3d", "Switch", Relay_Reset_20)) return; 
         {
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptCon_Switch_uScriptCon_Switch_20.Reset(logic_uScriptCon_Switch_Loop_20, logic_uScriptCon_Switch_MaxOutputUsed_20, out logic_uScriptCon_Switch_CurrentOutput_20);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_Switch_uScriptCon_Switch_20.Output1;
         bool test_1 = logic_uScriptCon_Switch_uScriptCon_Switch_20.Output2;
         
         if ( test_0 == true )
         {
            Relay_True_41();
         }
         if ( test_1 == true )
         {
            Relay_False_41();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Switch.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_21()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1ffa62bc-db40-4dba-a030-a74d3fa2d11d", "Add_Vector3", Relay_In_21)) return; 
         {
            {
               logic_uScriptAct_AddVector3_v2_A_21 = local_35_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_AddVector3_v2_B_21 = local_40_UnityEngine_Vector3;
               
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_21.In(logic_uScriptAct_AddVector3_v2_A_21, logic_uScriptAct_AddVector3_v2_B_21, out logic_uScriptAct_AddVector3_v2_Result_21);
         local_35_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_v2_Result_21;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_21.Out;
         
         if ( test_0 == true )
         {
            Relay_In_4();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_22()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("aa457d97-73ea-4737-b7bd-f32cf8bec6dd", "Input_Events_Filter", Relay_In_22)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_22.In(logic_uScriptAct_OnInputEventFilter_KeyCode_22);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_22.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_In_21();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_23()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("03443454-af1c-4f5a-9c1a-fda9e5da17bc", "Add_Vector3", Relay_In_23)) return; 
         {
            {
               logic_uScriptAct_AddVector3_v2_A_23 = local_32_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_AddVector3_v2_B_23 = local_Camera_Offset_UnityEngine_Vector3;
               
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_23.In(logic_uScriptAct_AddVector3_v2_A_23, logic_uScriptAct_AddVector3_v2_B_23, out logic_uScriptAct_AddVector3_v2_Result_23);
         local_25_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_v2_Result_23;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_23.Out;
         
         if ( test_0 == true )
         {
            Relay_In_5();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_26()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3b93b7ff-8019-44be-a5d8-11f6d83c43c2", "Compare_Bool", Relay_In_26)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_26 = local_Attach_Camera_System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_26.In(logic_uScriptCon_CompareBool_Bool_26);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_26.True;
         bool test_1 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_26.False;
         
         if ( test_0 == true )
         {
            Relay_In_50();
         }
         if ( test_1 == true )
         {
            Relay_In_13();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_27()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("aed4cbb7-1a43-441d-9b8a-2d2aa6a54887", "Add_Vector3", Relay_In_27)) return; 
         {
            {
               logic_uScriptAct_AddVector3_v2_A_27 = local_10_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_AddVector3_v2_B_27 = local_46_UnityEngine_Vector3;
               
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_27.In(logic_uScriptAct_AddVector3_v2_A_27, logic_uScriptAct_AddVector3_v2_B_27, out logic_uScriptAct_AddVector3_v2_Result_27);
         local_10_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_v2_Result_27;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_27.Out;
         
         if ( test_0 == true )
         {
            Relay_In_19();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_33()
   {
      if (true == CheckDebugBreak("8a1b7b1f-eb39-45cf-a3ec-6a79b7dc459c", "Input_Events", Relay_KeyEvent_33)) return; 
      Relay_In_38();
   }
   
   void Relay_KeyEvent_36()
   {
      if (true == CheckDebugBreak("afe8ed96-1880-4955-962b-faea2a0516e9", "Input_Events", Relay_KeyEvent_36)) return; 
      Relay_In_37();
   }
   
   void Relay_In_37()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2d3d4205-9b58-4943-b9db-c384eaeb83a6", "Input_Events_Filter", Relay_In_37)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_37.In(logic_uScriptAct_OnInputEventFilter_KeyCode_37);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_37.KeyDown;
         
         if ( test_0 == true )
         {
            Relay_In_20();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_38()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a1e11af0-179b-41cf-a6fd-bcdfc810cb0f", "Input_Events_Filter", Relay_In_38)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_38.In(logic_uScriptAct_OnInputEventFilter_KeyCode_38);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_38.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_In_42();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_41()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("004ac46c-75f5-411d-a4f1-01482da65786", "Set_Bool", Relay_True_41)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_41.True(out logic_uScriptAct_SetBool_Target_41);
         local_Attach_Camera_System_Boolean = logic_uScriptAct_SetBool_Target_41;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_41.Out;
         
         if ( test_0 == true )
         {
            Relay_In_48();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_41()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("004ac46c-75f5-411d-a4f1-01482da65786", "Set_Bool", Relay_False_41)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_41.False(out logic_uScriptAct_SetBool_Target_41);
         local_Attach_Camera_System_Boolean = logic_uScriptAct_SetBool_Target_41;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_41.Out;
         
         if ( test_0 == true )
         {
            Relay_In_48();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_42()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0e39d844-aafe-4bd6-ae3d-93278c0c62d6", "Add_Vector3", Relay_In_42)) return; 
         {
            {
               logic_uScriptAct_AddVector3_v2_A_42 = local_11_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_AddVector3_v2_B_42 = local_31_UnityEngine_Vector3;
               
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_42.In(logic_uScriptAct_AddVector3_v2_A_42, logic_uScriptAct_AddVector3_v2_B_42, out logic_uScriptAct_AddVector3_v2_Result_42);
         local_11_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_v2_Result_42;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_42.Out;
         
         if ( test_0 == true )
         {
            Relay_In_18();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_43()
   {
      if (true == CheckDebugBreak("4d3617b3-e294-4771-98eb-69862b517fb3", "Input_Events", Relay_KeyEvent_43)) return; 
      Relay_In_22();
   }
   
   void Relay_OnEnterCollision_44()
   {
      if (true == CheckDebugBreak("c0febaf7-2218-48e3-b2c7-ef302a3a519e", "On_Collision", Relay_OnEnterCollision_44)) return; 
      local_51_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_44;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_51_UnityEngine_GameObject_previous != local_51_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_51_UnityEngine_GameObject_previous = local_51_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
      Relay_Play_17();
   }
   
   void Relay_OnExitCollision_44()
   {
      if (true == CheckDebugBreak("c0febaf7-2218-48e3-b2c7-ef302a3a519e", "On_Collision", Relay_OnExitCollision_44)) return; 
      local_51_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_44;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_51_UnityEngine_GameObject_previous != local_51_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_51_UnityEngine_GameObject_previous = local_51_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
   }
   
   void Relay_WhileInsideCollision_44()
   {
      if (true == CheckDebugBreak("c0febaf7-2218-48e3-b2c7-ef302a3a519e", "On_Collision", Relay_WhileInsideCollision_44)) return; 
      local_51_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_44;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_51_UnityEngine_GameObject_previous != local_51_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_51_UnityEngine_GameObject_previous = local_51_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
   }
   
   void Relay_In_48()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9f3c3909-cda6-4bd5-bf61-1e6d404ab42f", "Log", Relay_In_48)) return; 
         {
            {
            }
            {
               int index = 0;
               if ( logic_uScriptAct_Log_Target_48.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_Log_Target_48, index + 1);
               }
               logic_uScriptAct_Log_Target_48[ index++ ] = local_Attach_Camera_System_Boolean;
               
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_48.In(logic_uScriptAct_Log_Prefix_48, logic_uScriptAct_Log_Target_48, logic_uScriptAct_Log_Postfix_48);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_49()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d9cbe2c7-b65f-4d59-b76c-1c564e60549f", "Set_Position", Relay_In_49)) return; 
         {
            {
               int index = 0;
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_30_UnityEngine_GameObject_previous != local_30_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_30_UnityEngine_GameObject_previous = local_30_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               if ( logic_uScriptAct_SetGameObjectPosition_Target_49.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_SetGameObjectPosition_Target_49, index + 1);
               }
               logic_uScriptAct_SetGameObjectPosition_Target_49[ index++ ] = local_30_UnityEngine_GameObject;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SetGameObjectPosition_uScriptAct_SetGameObjectPosition_49.In(logic_uScriptAct_SetGameObjectPosition_Target_49, logic_uScriptAct_SetGameObjectPosition_Position_49, logic_uScriptAct_SetGameObjectPosition_AsOffset_49, logic_uScriptAct_SetGameObjectPosition_AsLocal_49);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Set Position.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_50()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ab00a0d0-69d5-4a13-843d-6d78db00c4a0", "Get_Position_and_Rotation", Relay_In_50)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_28_UnityEngine_GameObject_previous != local_28_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_28_UnityEngine_GameObject_previous = local_28_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_GetPositionAndRotation_Target_50 = local_28_UnityEngine_GameObject;
               
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
         logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_50.In(logic_uScriptAct_GetPositionAndRotation_Target_50, logic_uScriptAct_GetPositionAndRotation_GetLocal_50, out logic_uScriptAct_GetPositionAndRotation_Position_50, out logic_uScriptAct_GetPositionAndRotation_Rotation_50, out logic_uScriptAct_GetPositionAndRotation_EulerAngles_50, out logic_uScriptAct_GetPositionAndRotation_Forward_50, out logic_uScriptAct_GetPositionAndRotation_Up_50, out logic_uScriptAct_GetPositionAndRotation_Right_50);
         local_32_UnityEngine_Vector3 = logic_uScriptAct_GetPositionAndRotation_Position_50;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_50.Out;
         
         if ( test_0 == true )
         {
            Relay_In_23();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Get Position and Rotation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_52()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4bc2361e-d207-4ac1-ac72-1ddabd5f17a4", "Add_Force", Relay_In_52)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_39_UnityEngine_GameObject_previous != local_39_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     if ( null != local_39_UnityEngine_GameObject_previous )
                     {
                        {
                           uScript_Collision component = local_39_UnityEngine_GameObject_previous.GetComponent<uScript_Collision>();
                           if ( null != component )
                           {
                              component.OnEnterCollision -= Instance_OnEnterCollision_44;
                              component.OnExitCollision -= Instance_OnExitCollision_44;
                              component.WhileInsideCollision -= Instance_WhileInsideCollision_44;
                           }
                        }
                     }
                     
                     local_39_UnityEngine_GameObject_previous = local_39_UnityEngine_GameObject;
                     
                     //setup new listeners
                     if ( null != local_39_UnityEngine_GameObject )
                     {
                        {
                           uScript_Collision component = local_39_UnityEngine_GameObject.GetComponent<uScript_Collision>();
                           if ( null == component )
                           {
                              component = local_39_UnityEngine_GameObject.AddComponent<uScript_Collision>();
                           }
                           if ( null != component )
                           {
                              component.OnEnterCollision += Instance_OnEnterCollision_44;
                              component.OnExitCollision += Instance_OnExitCollision_44;
                              component.WhileInsideCollision += Instance_WhileInsideCollision_44;
                           }
                        }
                     }
                  }
               }
               logic_uScriptAct_AddForce_Target_52 = local_39_UnityEngine_GameObject;
               
            }
            {
               logic_uScriptAct_AddForce_Force_52 = local_53_UnityEngine_Vector3;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddForce_uScriptAct_AddForce_52.In(logic_uScriptAct_AddForce_Target_52, logic_uScriptAct_AddForce_Force_52, logic_uScriptAct_AddForce_Scale_52, logic_uScriptAct_AddForce_UseForceMode_52, logic_uScriptAct_AddForce_ForceModeType_52);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddForce_uScriptAct_AddForce_52.Out;
         
         if ( test_0 == true )
         {
            Relay_False_65();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Add Force.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_54()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c1818070-f299-4e3e-b806-3be9d216c3d5", "Input_Events_Filter", Relay_In_54)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_54.In(logic_uScriptAct_OnInputEventFilter_KeyCode_54);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_54.KeyDown;
         
         if ( test_0 == true )
         {
            Relay_In_62();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_55()
   {
      if (true == CheckDebugBreak("624e7061-6d31-4b96-987f-0aa1188598fc", "Input_Events", Relay_KeyEvent_55)) return; 
      Relay_In_54();
   }
   
   void Relay_OnEnterCollision_56()
   {
      if (true == CheckDebugBreak("8501013f-f2d3-44a0-883e-91fe44b92de9", "On_Collision", Relay_OnEnterCollision_56)) return; 
      local_59_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_56;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_59_UnityEngine_GameObject_previous != local_59_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_59_UnityEngine_GameObject_previous = local_59_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
      Relay_In_60();
   }
   
   void Relay_OnExitCollision_56()
   {
      if (true == CheckDebugBreak("8501013f-f2d3-44a0-883e-91fe44b92de9", "On_Collision", Relay_OnExitCollision_56)) return; 
      local_59_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_56;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_59_UnityEngine_GameObject_previous != local_59_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_59_UnityEngine_GameObject_previous = local_59_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
   }
   
   void Relay_WhileInsideCollision_56()
   {
      if (true == CheckDebugBreak("8501013f-f2d3-44a0-883e-91fe44b92de9", "On_Collision", Relay_WhileInsideCollision_56)) return; 
      local_59_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_56;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_59_UnityEngine_GameObject_previous != local_59_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_59_UnityEngine_GameObject_previous = local_59_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
   }
   
   void Relay_In_60()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9190ed7f-2348-4fc0-8ac6-983acd8798c8", "Compare_GameObjects", Relay_In_60)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_59_UnityEngine_GameObject_previous != local_59_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_59_UnityEngine_GameObject_previous = local_59_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptCon_CompareGameObjects_A_60 = local_59_UnityEngine_GameObject;
               
            }
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_61_UnityEngine_GameObject_previous != local_61_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_61_UnityEngine_GameObject_previous = local_61_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptCon_CompareGameObjects_B_60 = local_61_UnityEngine_GameObject;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptCon_CompareGameObjects_uScriptCon_CompareGameObjects_60.In(logic_uScriptCon_CompareGameObjects_A_60, logic_uScriptCon_CompareGameObjects_B_60, logic_uScriptCon_CompareGameObjects_CompareByTag_60, logic_uScriptCon_CompareGameObjects_CompareByName_60, logic_uScriptCon_CompareGameObjects_ReportNull_60);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareGameObjects_uScriptCon_CompareGameObjects_60.Same;
         
         if ( test_0 == true )
         {
            Relay_True_63();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Compare GameObjects.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_62()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2797d323-2f58-42a6-a67e-e09a8a84e4dd", "Compare_Bool", Relay_In_62)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_62 = local_Can_Jump__System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_62.In(logic_uScriptCon_CompareBool_Bool_62);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_62.True;
         
         if ( test_0 == true )
         {
            Relay_In_52();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_63()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6a2ce54e-52fc-418a-b78e-579c7ce17a7d", "Set_Bool", Relay_True_63)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_63.True(out logic_uScriptAct_SetBool_Target_63);
         local_Can_Jump__System_Boolean = logic_uScriptAct_SetBool_Target_63;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_63()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6a2ce54e-52fc-418a-b78e-579c7ce17a7d", "Set_Bool", Relay_False_63)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_63.False(out logic_uScriptAct_SetBool_Target_63);
         local_Can_Jump__System_Boolean = logic_uScriptAct_SetBool_Target_63;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_65()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("57467ece-e5af-41d5-94e7-9accc668f1c9", "Set_Bool", Relay_True_65)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_65.True(out logic_uScriptAct_SetBool_Target_65);
         local_Can_Jump__System_Boolean = logic_uScriptAct_SetBool_Target_65;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_65()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("57467ece-e5af-41d5-94e7-9accc668f1c9", "Set_Bool", Relay_False_65)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_65.False(out logic_uScriptAct_SetBool_Target_65);
         local_Can_Jump__System_Boolean = logic_uScriptAct_SetBool_Target_65;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_uScriptStart_67()
   {
      if (true == CheckDebugBreak("eacf9f4b-f4ac-4c1e-b44e-dd9b1e007459", "uScript_Events", Relay_uScriptStart_67)) return; 
      Relay_ShowLabel_68();
      Relay_In_70();
   }
   
   void Relay_uScriptLateStart_67()
   {
      if (true == CheckDebugBreak("eacf9f4b-f4ac-4c1e-b44e-dd9b1e007459", "uScript_Events", Relay_uScriptLateStart_67)) return; 
   }
   
   void Relay_ShowLabel_68()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7e01458b-c989-4aa8-b9a1-d0bd16c5c326", "Print_Text", Relay_ShowLabel_68)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_68.ShowLabel(logic_uScriptAct_PrintText_Text_68, logic_uScriptAct_PrintText_FontSize_68, logic_uScriptAct_PrintText_FontStyle_68, logic_uScriptAct_PrintText_FontColor_68, logic_uScriptAct_PrintText_textAnchor_68, logic_uScriptAct_PrintText_EdgePadding_68, logic_uScriptAct_PrintText_time_68);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_PrintText_uScriptAct_PrintText_68.Out;
         
         if ( test_0 == true )
         {
            Relay_ShowLabel_69();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_68()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7e01458b-c989-4aa8-b9a1-d0bd16c5c326", "Print_Text", Relay_HideLabel_68)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_68.HideLabel(logic_uScriptAct_PrintText_Text_68, logic_uScriptAct_PrintText_FontSize_68, logic_uScriptAct_PrintText_FontStyle_68, logic_uScriptAct_PrintText_FontColor_68, logic_uScriptAct_PrintText_textAnchor_68, logic_uScriptAct_PrintText_EdgePadding_68, logic_uScriptAct_PrintText_time_68);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_PrintText_uScriptAct_PrintText_68.Out;
         
         if ( test_0 == true )
         {
            Relay_ShowLabel_69();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_69()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e5e173b7-bb6e-4111-bc81-3a1696a7fc3c", "Print_Text", Relay_ShowLabel_69)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_69.ShowLabel(logic_uScriptAct_PrintText_Text_69, logic_uScriptAct_PrintText_FontSize_69, logic_uScriptAct_PrintText_FontStyle_69, logic_uScriptAct_PrintText_FontColor_69, logic_uScriptAct_PrintText_textAnchor_69, logic_uScriptAct_PrintText_EdgePadding_69, logic_uScriptAct_PrintText_time_69);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_69()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e5e173b7-bb6e-4111-bc81-3a1696a7fc3c", "Print_Text", Relay_HideLabel_69)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_69.HideLabel(logic_uScriptAct_PrintText_Text_69, logic_uScriptAct_PrintText_FontSize_69, logic_uScriptAct_PrintText_FontStyle_69, logic_uScriptAct_PrintText_FontColor_69, logic_uScriptAct_PrintText_textAnchor_69, logic_uScriptAct_PrintText_EdgePadding_69, logic_uScriptAct_PrintText_time_69);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_70()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d74c6b73-086b-407c-89bb-9574f2c6d3c5", "Load_AudioClip", Relay_In_70)) return; 
         {
            {
            }
            {
            }
         }
         logic_uScriptAct_LoadAudioClip_uScriptAct_LoadAudioClip_70.In(logic_uScriptAct_LoadAudioClip_name_70, out logic_uScriptAct_LoadAudioClip_audioClip_70);
         local_Col_Sound_UnityEngine_AudioClip = logic_uScriptAct_LoadAudioClip_audioClip_70;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript BallRoller_BallRollLogic.uscript at Load AudioClip.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:6", local_6_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f0b6f445-314b-4c8b-b759-624410097332", local_6_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:9", local_9_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "6aa61e0a-fe9c-48bf-b04f-1c6c452109ef", local_9_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:10", local_10_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "fa497d61-559e-4654-b87b-75c63ea01591", local_10_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:11", local_11_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f928f8d7-0b9a-474a-856b-5e1f39382a81", local_11_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:16", local_16_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "9d2dd55a-097e-42cf-abad-ffdaf0b6664d", local_16_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:25", local_25_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "6e12bfa7-076c-45db-8522-73a439f8e641", local_25_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:28", local_28_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "67ff177d-1b41-4746-865c-bd3127a0bf8d", local_28_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:29", local_29_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d6b553ca-4b09-4b74-8e58-c41c37cd1db5", local_29_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:30", local_30_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "1fda025b-0319-4456-9337-320adcf5cb4b", local_30_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:31", local_31_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "2ef29887-b87d-4f21-968d-b6800fdff30b", local_31_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:32", local_32_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "707c123c-66bb-4a5a-a277-3c8b05a568bb", local_32_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:35", local_35_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b47d2f2e-0a2a-4168-8949-e138f4e7f383", local_35_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:39", local_39_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "dc3b49b2-7ddc-4c7f-9dca-79df00473d03", local_39_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:40", local_40_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ebaa5c23-085d-459f-a9bb-ed0edf55265f", local_40_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:Attach Camera", local_Attach_Camera_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "e7f11812-5a6d-41a2-8224-d299f711bd78", local_Attach_Camera_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:46", local_46_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "1283ae13-d713-4740-8768-24d2166984b6", local_46_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:Camera Offset", local_Camera_Offset_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "0a38cf5e-6fbc-423c-806b-8eaee238418f", local_Camera_Offset_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:51", local_51_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d8f10d9b-d786-4720-aa43-8452eeae25c8", local_51_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:53", local_53_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a1cf6da1-b39c-42b0-9e00-721938afc8eb", local_53_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:58", local_58_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "e9f90c1c-c473-412c-ab88-bde6ca465fab", local_58_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:59", local_59_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "9d25ff31-3d62-456a-b0da-d92f106939a4", local_59_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:61", local_61_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "3682d3c6-7b22-4786-84ff-72bdbedd35b7", local_61_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:Can Jump?", local_Can_Jump__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ae4fb8a3-14bd-473c-ae86-a3deae44953a", local_Can_Jump__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "BallRoller_BallRollLogic.uscript:Col_Sound", local_Col_Sound_UnityEngine_AudioClip);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "44b3db84-6540-456e-9482-ce23723709ad", local_Col_Sound_UnityEngine_AudioClip);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "fe0476bf-cd81-419c-a23a-58f4c4d16dfb", property_position_Detox_ScriptEditor_Parameter_position_34_Get_Refresh());
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
