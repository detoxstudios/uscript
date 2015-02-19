//uScript Generated Code - Build 1.0.2740
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class FireBot_Gameplay : uScriptLogic
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
   public System.Single BotSpeedPerSecond = (float) 10;
   public System.Single BotTurnPerSecond = (float) 10;
   System.String local_1_System_String = "Start Game";
   System.String local_101_System_String = "";
   System.String local_103_System_String = "Game Over";
   System.Boolean local_11_System_Boolean = (bool) false;
   System.Single local_111_System_Single = (float) -600;
   System.String local_112_System_String = "";
   System.Single local_115_System_Single = (float) 0;
   UnityEngine.GameObject local_117_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_117_UnityEngine_GameObject_previous = null;
   System.String local_119_System_String = "Game Over";
   UnityEngine.GameObject local_120_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_120_UnityEngine_GameObject_previous = null;
   System.Int32 local_123_System_Int32 = (int) 18;
   UnityEngine.Vector3 local_131_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   System.Single local_139_System_Single = (float) 0;
   UnityEngine.Vector3 local_141_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 local_144_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   System.String local_148_System_String = "";
   System.Int32 local_150_System_Int32 = (int) 0;
   UnityEngine.GameObject local_151_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_151_UnityEngine_GameObject_previous = null;
   System.Int32 local_152_System_Int32 = (int) 0;
   System.Single local_3_System_Single = (float) 1;
   UnityEngine.Vector3 local_30_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   System.String local_33_System_String = "";
   System.Single local_34_System_Single = (float) -1200;
   System.Single local_35_System_Single = (float) 3;
   System.Single local_37_System_Single = (float) 10;
   System.String local_40_System_String = "Fire";
   System.Single local_44_System_Single = (float) 0;
   System.Single local_45_System_Single = (float) -10;
   System.Int32 local_59_System_Int32 = (int) 0;
   System.Single local_61_System_Single = (float) 0;
   UnityEngine.GameObject local_66_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_66_UnityEngine_GameObject_previous = null;
   System.String local_68_System_String = "Start Game";
   System.Single local_75_System_Single = (float) 0;
   System.Single local_80_System_Single = (float) 20;
   System.Single local_9_System_Single = (float) 0;
   System.String local_92_System_String = "Award Points";
   System.Single local_93_System_Single = (float) 2;
   System.Single local_94_System_Single = (float) 0.2;
   System.Int32 local_95_System_Int32 = (int) 0;
   System.String local_98_System_String = "";
   System.Single local_Bot_Speed_System_Single = (float) 10;
   System.Single local_Camera_Distance_System_Single = (float) 30;
   System.Boolean local_ForwardMotion_System_Boolean = (bool) false;
   System.Boolean local_Game_In_Progress__System_Boolean = (bool) false;
   UnityEngine.GameObject local_Player_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_Player_UnityEngine_GameObject_previous = null;
   System.String local_Points_String_System_String = "";
   System.Int32 local_Points_System_Int32 = (int) 0;
   System.Int32 local_Seconds_Left_System_Int32 = (int) 60;
   System.Boolean local_Turbo_Mode__System_Boolean = (bool) false;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_SetRandomFloat logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_2 = new uScriptAct_SetRandomFloat( );
   System.Single logic_uScriptAct_SetRandomFloat_Min_2 = (float) -40;
   System.Single logic_uScriptAct_SetRandomFloat_Max_2 = (float) 40;
   System.Single logic_uScriptAct_SetRandomFloat_TargetFloat_2;
   bool logic_uScriptAct_SetRandomFloat_Out_2 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_4 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_4 = "";
   System.String logic_uScriptCon_CompareString_B_4 = "";
   bool logic_uScriptCon_CompareString_Same_4 = true;
   bool logic_uScriptCon_CompareString_Different_4 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_5 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_5 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_5 = true;
   bool logic_uScriptCon_CompareBool_False_5 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_8 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_8 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_8 = true;
   bool logic_uScriptCon_CompareBool_False_8 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_10 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_10 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_10 = true;
   bool logic_uScriptCon_CompareBool_False_10 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_12 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_12 = "";
   System.String logic_uScriptCon_CompareString_B_12 = "";
   bool logic_uScriptCon_CompareString_Same_12 = true;
   bool logic_uScriptCon_CompareString_Different_12 = true;
   //pointer to script instanced logic node
   uScriptAct_AddForce logic_uScriptAct_AddForce_uScriptAct_AddForce_13 = new uScriptAct_AddForce( );
   UnityEngine.GameObject logic_uScriptAct_AddForce_Target_13 = default(UnityEngine.GameObject);
   UnityEngine.Vector3 logic_uScriptAct_AddForce_Force_13 = new Vector3( );
   System.Single logic_uScriptAct_AddForce_Scale_13 = (float) 0;
   System.Boolean logic_uScriptAct_AddForce_UseForceMode_13 = (bool) false;
   UnityEngine.ForceMode logic_uScriptAct_AddForce_ForceModeType_13 = UnityEngine.ForceMode.Force;
   bool logic_uScriptAct_AddForce_Out_13 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_14 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_14 = UnityEngine.KeyCode.UpArrow;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_14 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_14 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_14 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_17 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_17 = "";
   System.Int32 logic_uScriptAct_PrintText_FontSize_17 = (int) 48;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_17 = UnityEngine.FontStyle.Normal;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_17 = new UnityEngine.Color( (float)0, (float)1, (float)0, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_17 = UnityEngine.TextAnchor.UpperLeft;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_17 = (int) 64;
   System.Single logic_uScriptAct_PrintText_time_17 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_17 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_18 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_18 = "Game Over!";
   System.Int32 logic_uScriptAct_PrintText_FontSize_18 = (int) 48;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_18 = UnityEngine.FontStyle.Bold;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_18 = new UnityEngine.Color( (float)1, (float)0, (float)0, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_18 = UnityEngine.TextAnchor.UpperCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_18 = (int) 128;
   System.Single logic_uScriptAct_PrintText_time_18 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_18 = true;
   //pointer to script instanced logic node
   uScriptAct_SendCustomEventBool logic_uScriptAct_SendCustomEventBool_uScriptAct_SendCustomEventBool_19 = new uScriptAct_SendCustomEventBool( );
   System.String logic_uScriptAct_SendCustomEventBool_EventName_19 = "";
   System.Boolean logic_uScriptAct_SendCustomEventBool_EventValue_19 = (bool) false;
   uScriptCustomEvent.SendGroup logic_uScriptAct_SendCustomEventBool_sendGroup_19 = uScriptCustomEvent.SendGroup.Parents;
   UnityEngine.GameObject logic_uScriptAct_SendCustomEventBool_EventSender_19 = default(UnityEngine.GameObject);
   bool logic_uScriptAct_SendCustomEventBool_Out_19 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_20 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_20 = "";
   System.Int32 logic_uScriptAct_PrintText_FontSize_20 = (int) 48;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_20 = UnityEngine.FontStyle.Bold;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_20 = new UnityEngine.Color( (float)1, (float)1, (float)0, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_20 = UnityEngine.TextAnchor.UpperRight;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_20 = (int) 64;
   System.Single logic_uScriptAct_PrintText_time_20 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_20 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_21 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_21;
   bool logic_uScriptAct_SetBool_Out_21 = true;
   bool logic_uScriptAct_SetBool_SetTrue_21 = true;
   bool logic_uScriptAct_SetBool_SetFalse_21 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_22 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_22 = "Shoot with SPACE BAR";
   System.Int32 logic_uScriptAct_PrintText_FontSize_22 = (int) 18;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_22 = UnityEngine.FontStyle.Normal;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_22 = new UnityEngine.Color( (float)1, (float)1, (float)1, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_22 = UnityEngine.TextAnchor.LowerCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_22 = (int) 80;
   System.Single logic_uScriptAct_PrintText_time_22 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_22 = true;
   //pointer to script instanced logic node
   uScriptAct_SetFloat logic_uScriptAct_SetFloat_uScriptAct_SetFloat_24 = new uScriptAct_SetFloat( );
   System.Single logic_uScriptAct_SetFloat_Value_24 = (float) 0;
   System.Single logic_uScriptAct_SetFloat_Target_24;
   bool logic_uScriptAct_SetFloat_Out_24 = true;
   //pointer to script instanced logic node
   uScriptAct_SetRandomFloat logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_26 = new uScriptAct_SetRandomFloat( );
   System.Single logic_uScriptAct_SetRandomFloat_Min_26 = (float) -40;
   System.Single logic_uScriptAct_SetRandomFloat_Max_26 = (float) 40;
   System.Single logic_uScriptAct_SetRandomFloat_TargetFloat_26;
   bool logic_uScriptAct_SetRandomFloat_Out_26 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_28 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_28 = UnityEngine.KeyCode.LeftArrow;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_28 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_28 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_28 = true;
   //pointer to script instanced logic node
   uScriptAct_Destroy logic_uScriptAct_Destroy_uScriptAct_Destroy_31 = new uScriptAct_Destroy( );
   UnityEngine.GameObject[] logic_uScriptAct_Destroy_Target_31 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_Destroy_DelayTime_31 = (float) 0;
   bool logic_uScriptAct_Destroy_Out_31 = true;
   bool logic_uScriptAct_Destroy_ObjectsDestroyed_31 = true;
   bool logic_uScriptAct_Destroy_WaitOneTick_31 = false;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_39 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_39 = UnityEngine.KeyCode.W;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_39 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_39 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_39 = true;
   //pointer to script instanced logic node
   uScriptAct_IsometricCharacterController logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_41 = new uScriptAct_IsometricCharacterController( );
   UnityEngine.GameObject logic_uScriptAct_IsometricCharacterController_target_41 = default(UnityEngine.GameObject);
   System.Single logic_uScriptAct_IsometricCharacterController_translation_41 = (float) 0;
   System.Single logic_uScriptAct_IsometricCharacterController_rotation_41 = (float) 0;
   System.Boolean logic_uScriptAct_IsometricCharacterController_filterTranslation_41 = (bool) false;
   System.Single logic_uScriptAct_IsometricCharacterController_translationFilterConstant_41 = (float) 0.7;
   System.Boolean logic_uScriptAct_IsometricCharacterController_filterRotation_41 = (bool) false;
   System.Single logic_uScriptAct_IsometricCharacterController_rotationFilterConstant_41 = (float) 0.1;
   bool logic_uScriptAct_IsometricCharacterController_Out_41 = true;
   //pointer to script instanced logic node
   uScriptAct_SetComponentsVector3 logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_47 = new uScriptAct_SetComponentsVector3( );
   System.Single logic_uScriptAct_SetComponentsVector3_X_47 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsVector3_Y_47 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsVector3_Z_47 = (float) 0;
   UnityEngine.Vector3 logic_uScriptAct_SetComponentsVector3_OutputVector3_47;
   bool logic_uScriptAct_SetComponentsVector3_Out_47 = true;
   //pointer to script instanced logic node
   uScriptCon_TimedGate logic_uScriptCon_TimedGate_uScriptCon_TimedGate_49 = new uScriptCon_TimedGate( );
   System.Single logic_uScriptCon_TimedGate_Duration_49 = (float) 0;
   System.Boolean logic_uScriptCon_TimedGate_StartOpen_49 = (bool) true;
   bool logic_uScriptCon_TimedGate_TooSoon_49 = true;
   //pointer to script instanced logic node
   uScriptAct_SubtractInt logic_uScriptAct_SubtractInt_uScriptAct_SubtractInt_50 = new uScriptAct_SubtractInt( );
   System.Int32 logic_uScriptAct_SubtractInt_A_50 = (int) 0;
   System.Int32 logic_uScriptAct_SubtractInt_B_50 = (int) 1;
   System.Int32 logic_uScriptAct_SubtractInt_IntResult_50;
   System.Single logic_uScriptAct_SubtractInt_FloatResult_50;
   bool logic_uScriptAct_SubtractInt_Out_50 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_51 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_51 = UnityEngine.KeyCode.DownArrow;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_51 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_51 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_51 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareInt logic_uScriptCon_CompareInt_uScriptCon_CompareInt_53 = new uScriptCon_CompareInt( );
   System.Int32 logic_uScriptCon_CompareInt_A_53 = (int) 0;
   System.Int32 logic_uScriptCon_CompareInt_B_53 = (int) 0;
   bool logic_uScriptCon_CompareInt_GreaterThan_53 = true;
   bool logic_uScriptCon_CompareInt_GreaterThanOrEqualTo_53 = true;
   bool logic_uScriptCon_CompareInt_EqualTo_53 = true;
   bool logic_uScriptCon_CompareInt_NotEqualTo_53 = true;
   bool logic_uScriptCon_CompareInt_LessThanOrEqualTo_53 = true;
   bool logic_uScriptCon_CompareInt_LessThan_53 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_55 = new uScriptAct_Delay( );
   System.Single logic_uScriptAct_Delay_Duration_55 = (float) 0;
   System.Boolean logic_uScriptAct_Delay_SingleFrame_55 = (bool) false;
   bool logic_uScriptAct_Delay_Immediate_55 = true;
   bool logic_uScriptAct_Delay_AfterDelay_55 = true;
   bool logic_uScriptAct_Delay_Stopped_55 = true;
   bool logic_uScriptAct_Delay_DrivenDelay_55 = false;
   //pointer to script instanced logic node
   uScriptAct_SendCustomEventBool logic_uScriptAct_SendCustomEventBool_uScriptAct_SendCustomEventBool_56 = new uScriptAct_SendCustomEventBool( );
   System.String logic_uScriptAct_SendCustomEventBool_EventName_56 = "";
   System.Boolean logic_uScriptAct_SendCustomEventBool_EventValue_56 = (bool) false;
   uScriptCustomEvent.SendGroup logic_uScriptAct_SendCustomEventBool_sendGroup_56 = uScriptCustomEvent.SendGroup.Parents;
   UnityEngine.GameObject logic_uScriptAct_SendCustomEventBool_EventSender_56 = default(UnityEngine.GameObject);
   bool logic_uScriptAct_SendCustomEventBool_Out_56 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_57 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_57 = UnityEngine.KeyCode.S;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_57 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_57 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_57 = true;
   //pointer to script instanced logic node
   uScriptAct_Concatenate logic_uScriptAct_Concatenate_uScriptAct_Concatenate_58 = new uScriptAct_Concatenate( );
   System.Object[] logic_uScriptAct_Concatenate_A_58 = new System.Object[] {"Final "};
   System.Object[] logic_uScriptAct_Concatenate_B_58 = new System.Object[] {};
   System.String logic_uScriptAct_Concatenate_Separator_58 = " ";
   System.String logic_uScriptAct_Concatenate_Result_58;
   bool logic_uScriptAct_Concatenate_Out_58 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_60 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_60 = "";
   System.String logic_uScriptCon_CompareString_B_60 = "";
   bool logic_uScriptCon_CompareString_Same_60 = true;
   bool logic_uScriptCon_CompareString_Different_60 = true;
   //pointer to script instanced logic node
   uScriptAct_GetPositionAndRotation logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_62 = new uScriptAct_GetPositionAndRotation( );
   UnityEngine.GameObject logic_uScriptAct_GetPositionAndRotation_Target_62 = default(UnityEngine.GameObject);
   System.Boolean logic_uScriptAct_GetPositionAndRotation_GetLocal_62 = (bool) false;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Position_62;
   UnityEngine.Quaternion logic_uScriptAct_GetPositionAndRotation_Rotation_62;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_EulerAngles_62;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Forward_62;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Up_62;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Right_62;
   bool logic_uScriptAct_GetPositionAndRotation_Out_62 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_64 = new uScriptAct_Delay( );
   System.Single logic_uScriptAct_Delay_Duration_64 = (float) 0;
   System.Boolean logic_uScriptAct_Delay_SingleFrame_64 = (bool) false;
   bool logic_uScriptAct_Delay_Immediate_64 = true;
   bool logic_uScriptAct_Delay_AfterDelay_64 = true;
   bool logic_uScriptAct_Delay_Stopped_64 = true;
   bool logic_uScriptAct_Delay_DrivenDelay_64 = false;
   //pointer to script instanced logic node
   uScriptAct_AddFloat logic_uScriptAct_AddFloat_uScriptAct_AddFloat_65 = new uScriptAct_AddFloat( );
   System.Single[] logic_uScriptAct_AddFloat_A_65 = new System.Single[] {};
   System.Single[] logic_uScriptAct_AddFloat_B_65 = new System.Single[] {};
   System.Single logic_uScriptAct_AddFloat_FloatResult_65;
   System.Int32 logic_uScriptAct_AddFloat_IntResult_65;
   bool logic_uScriptAct_AddFloat_Out_65 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_69 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_69 = UnityEngine.KeyCode.Space;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_69 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_69 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_69 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_73 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_73;
   bool logic_uScriptAct_SetBool_Out_73 = true;
   bool logic_uScriptAct_SetBool_SetTrue_73 = true;
   bool logic_uScriptAct_SetBool_SetFalse_73 = true;
   //pointer to script instanced logic node
   uScriptAct_SetGameObjectPosition logic_uScriptAct_SetGameObjectPosition_uScriptAct_SetGameObjectPosition_74 = new uScriptAct_SetGameObjectPosition( );
   UnityEngine.GameObject[] logic_uScriptAct_SetGameObjectPosition_Target_74 = new UnityEngine.GameObject[] {};
   UnityEngine.Vector3 logic_uScriptAct_SetGameObjectPosition_Position_74 = new Vector3( );
   System.Boolean logic_uScriptAct_SetGameObjectPosition_AsOffset_74 = (bool) false;
   System.Boolean logic_uScriptAct_SetGameObjectPosition_AsLocal_74 = (bool) false;
   bool logic_uScriptAct_SetGameObjectPosition_Out_74 = true;
   //pointer to script instanced logic node
   uScriptAct_AddForce logic_uScriptAct_AddForce_uScriptAct_AddForce_76 = new uScriptAct_AddForce( );
   UnityEngine.GameObject logic_uScriptAct_AddForce_Target_76 = default(UnityEngine.GameObject);
   UnityEngine.Vector3 logic_uScriptAct_AddForce_Force_76 = new Vector3( );
   System.Single logic_uScriptAct_AddForce_Scale_76 = (float) 0;
   System.Boolean logic_uScriptAct_AddForce_UseForceMode_76 = (bool) false;
   UnityEngine.ForceMode logic_uScriptAct_AddForce_ForceModeType_76 = UnityEngine.ForceMode.Force;
   bool logic_uScriptAct_AddForce_Out_76 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_79 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_79;
   bool logic_uScriptAct_SetBool_Out_79 = true;
   bool logic_uScriptAct_SetBool_SetTrue_79 = true;
   bool logic_uScriptAct_SetBool_SetFalse_79 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_82 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_82 = UnityEngine.KeyCode.LeftShift;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_82 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_82 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_82 = true;
   //pointer to script instanced logic node
   uScriptAct_SetFloat logic_uScriptAct_SetFloat_uScriptAct_SetFloat_83 = new uScriptAct_SetFloat( );
   System.Single logic_uScriptAct_SetFloat_Value_83 = (float) 0;
   System.Single logic_uScriptAct_SetFloat_Target_83;
   bool logic_uScriptAct_SetFloat_Out_83 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_84 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_84 = UnityEngine.KeyCode.Space;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_84 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_84 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_84 = true;
   //pointer to script instanced logic node
   uScriptAct_SetComponentsVector3 logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_87 = new uScriptAct_SetComponentsVector3( );
   System.Single logic_uScriptAct_SetComponentsVector3_X_87 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsVector3_Y_87 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsVector3_Z_87 = (float) 0;
   UnityEngine.Vector3 logic_uScriptAct_SetComponentsVector3_OutputVector3_87;
   bool logic_uScriptAct_SetComponentsVector3_Out_87 = true;
   //pointer to script instanced logic node
   uScriptAct_AddInt logic_uScriptAct_AddInt_uScriptAct_AddInt_88 = new uScriptAct_AddInt( );
   System.Int32[] logic_uScriptAct_AddInt_A_88 = new System.Int32[] {};
   System.Int32[] logic_uScriptAct_AddInt_B_88 = new System.Int32[] {};
   System.Int32 logic_uScriptAct_AddInt_IntResult_88;
   System.Single logic_uScriptAct_AddInt_FloatResult_88;
   bool logic_uScriptAct_AddInt_Out_88 = true;
   //pointer to script instanced logic node
   uScriptAct_SpawnPrefab logic_uScriptAct_SpawnPrefab_uScriptAct_SpawnPrefab_91 = new uScriptAct_SpawnPrefab( );
   System.String logic_uScriptAct_SpawnPrefab_PrefabName_91 = "WaterBall";
   System.String logic_uScriptAct_SpawnPrefab_ResourcePath_91 = "";
   UnityEngine.GameObject logic_uScriptAct_SpawnPrefab_SpawnPoint_91 = default(UnityEngine.GameObject);
   System.String logic_uScriptAct_SpawnPrefab_SpawnedName_91 = "";
   UnityEngine.Vector3 logic_uScriptAct_SpawnPrefab_LocationOffset_91 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.GameObject logic_uScriptAct_SpawnPrefab_SpawnedGameObject_91;
   System.Int32 logic_uScriptAct_SpawnPrefab_SpawnedInstancedID_91;
   bool logic_uScriptAct_SpawnPrefab_Immediate_91 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareInt logic_uScriptCon_CompareInt_uScriptCon_CompareInt_99 = new uScriptCon_CompareInt( );
   System.Int32 logic_uScriptCon_CompareInt_A_99 = (int) 0;
   System.Int32 logic_uScriptCon_CompareInt_B_99 = (int) 0;
   bool logic_uScriptCon_CompareInt_GreaterThan_99 = true;
   bool logic_uScriptCon_CompareInt_GreaterThanOrEqualTo_99 = true;
   bool logic_uScriptCon_CompareInt_EqualTo_99 = true;
   bool logic_uScriptCon_CompareInt_NotEqualTo_99 = true;
   bool logic_uScriptCon_CompareInt_LessThanOrEqualTo_99 = true;
   bool logic_uScriptCon_CompareInt_LessThan_99 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_106 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_106 = UnityEngine.KeyCode.RightShift;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_106 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_106 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_106 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_107 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_107 = "Hold down SHIFT to Turbo Boost";
   System.Int32 logic_uScriptAct_PrintText_FontSize_107 = (int) 18;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_107 = UnityEngine.FontStyle.Normal;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_107 = new UnityEngine.Color( (float)1, (float)1, (float)1, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_107 = UnityEngine.TextAnchor.LowerCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_107 = (int) 32;
   System.Single logic_uScriptAct_PrintText_time_107 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_107 = true;
   //pointer to script instanced logic node
   uScriptAct_Concatenate logic_uScriptAct_Concatenate_uScriptAct_Concatenate_108 = new uScriptAct_Concatenate( );
   System.Object[] logic_uScriptAct_Concatenate_A_108 = new System.Object[] {"Score: "};
   System.Object[] logic_uScriptAct_Concatenate_B_108 = new System.Object[] {};
   System.String logic_uScriptAct_Concatenate_Separator_108 = " ";
   System.String logic_uScriptAct_Concatenate_Result_108;
   bool logic_uScriptAct_Concatenate_Out_108 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_113 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_113 = "Press 'SPACE' To Start";
   System.Int32 logic_uScriptAct_PrintText_FontSize_113 = (int) 32;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_113 = UnityEngine.FontStyle.Bold;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_113 = new UnityEngine.Color( (float)1, (float)1, (float)0, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_113 = UnityEngine.TextAnchor.MiddleCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_113 = (int) 32;
   System.Single logic_uScriptAct_PrintText_time_113 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_113 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareInt logic_uScriptCon_CompareInt_uScriptCon_CompareInt_114 = new uScriptCon_CompareInt( );
   System.Int32 logic_uScriptCon_CompareInt_A_114 = (int) 0;
   System.Int32 logic_uScriptCon_CompareInt_B_114 = (int) 0;
   bool logic_uScriptCon_CompareInt_GreaterThan_114 = true;
   bool logic_uScriptCon_CompareInt_GreaterThanOrEqualTo_114 = true;
   bool logic_uScriptCon_CompareInt_EqualTo_114 = true;
   bool logic_uScriptCon_CompareInt_NotEqualTo_114 = true;
   bool logic_uScriptCon_CompareInt_LessThanOrEqualTo_114 = true;
   bool logic_uScriptCon_CompareInt_LessThan_114 = true;
   //pointer to script instanced logic node
   uScriptAct_SetFloat logic_uScriptAct_SetFloat_uScriptAct_SetFloat_116 = new uScriptAct_SetFloat( );
   System.Single logic_uScriptAct_SetFloat_Value_116 = (float) 0;
   System.Single logic_uScriptAct_SetFloat_Target_116;
   bool logic_uScriptAct_SetFloat_Out_116 = true;
   //pointer to script instanced logic node
   uScriptAct_ConvertVariable logic_uScriptAct_ConvertVariable_uScriptAct_ConvertVariable_118 = new uScriptAct_ConvertVariable( );
   System.Object logic_uScriptAct_ConvertVariable_Target_118 = "";
   System.Int32 logic_uScriptAct_ConvertVariable_IntValue_118;
   System.Int64 logic_uScriptAct_ConvertVariable_Int64Value_118;
   System.Single logic_uScriptAct_ConvertVariable_FloatValue_118;
   System.String logic_uScriptAct_ConvertVariable_StringValue_118;
   System.Boolean logic_uScriptAct_ConvertVariable_BooleanValue_118;
   UnityEngine.Vector3 logic_uScriptAct_ConvertVariable_Vector3Value_118;
   System.String logic_uScriptAct_ConvertVariable_FloatGroupSeparator_118 = ",";
   bool logic_uScriptAct_ConvertVariable_Out_118 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_121 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_121;
   bool logic_uScriptAct_SetBool_Out_121 = true;
   bool logic_uScriptAct_SetBool_SetTrue_121 = true;
   bool logic_uScriptAct_SetBool_SetFalse_121 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_122 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_122 = UnityEngine.KeyCode.RightArrow;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_122 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_122 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_122 = true;
   //pointer to script instanced logic node
   uScriptAct_ScaleVector3 logic_uScriptAct_ScaleVector3_uScriptAct_ScaleVector3_125 = new uScriptAct_ScaleVector3( );
   UnityEngine.Vector3 logic_uScriptAct_ScaleVector3_v_125 = new Vector3( );
   System.Single logic_uScriptAct_ScaleVector3_s_125 = (float) 0;
   UnityEngine.Vector3 logic_uScriptAct_ScaleVector3_result_125;
   bool logic_uScriptAct_ScaleVector3_Out_125 = true;
   //pointer to script instanced logic node
   uScriptAct_SetFloat logic_uScriptAct_SetFloat_uScriptAct_SetFloat_127 = new uScriptAct_SetFloat( );
   System.Single logic_uScriptAct_SetFloat_Value_127 = (float) 0;
   System.Single logic_uScriptAct_SetFloat_Target_127;
   bool logic_uScriptAct_SetFloat_Out_127 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_128 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_128 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_128 = true;
   bool logic_uScriptCon_CompareBool_False_128 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_130 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_130 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_130 = true;
   bool logic_uScriptCon_CompareBool_False_130 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_132 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_132 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_132 = true;
   bool logic_uScriptCon_CompareBool_False_132 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_133 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_133 = "Move with W, A, S, D or Arrow Keys";
   System.Int32 logic_uScriptAct_PrintText_FontSize_133 = (int) 18;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_133 = UnityEngine.FontStyle.Normal;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_133 = new UnityEngine.Color( (float)1, (float)1, (float)1, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_133 = UnityEngine.TextAnchor.LowerCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_133 = (int) 128;
   System.Single logic_uScriptAct_PrintText_time_133 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_133 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_135 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_135 = UnityEngine.KeyCode.D;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_135 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_135 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_135 = true;
   //pointer to script instanced logic node
   uScriptAct_GetComponentsVector3 logic_uScriptAct_GetComponentsVector3_uScriptAct_GetComponentsVector3_136 = new uScriptAct_GetComponentsVector3( );
   UnityEngine.Vector3 logic_uScriptAct_GetComponentsVector3_InputVector3_136 = new Vector3( );
   System.Single logic_uScriptAct_GetComponentsVector3_X_136;
   System.Single logic_uScriptAct_GetComponentsVector3_Y_136;
   System.Single logic_uScriptAct_GetComponentsVector3_Z_136;
   bool logic_uScriptAct_GetComponentsVector3_Out_136 = true;
   //pointer to script instanced logic node
   uScriptAct_AddInt logic_uScriptAct_AddInt_uScriptAct_AddInt_137 = new uScriptAct_AddInt( );
   System.Int32[] logic_uScriptAct_AddInt_A_137 = new System.Int32[] {1};
   System.Int32[] logic_uScriptAct_AddInt_B_137 = new System.Int32[] {};
   System.Int32 logic_uScriptAct_AddInt_IntResult_137;
   System.Single logic_uScriptAct_AddInt_FloatResult_137;
   bool logic_uScriptAct_AddInt_Out_137 = true;
   //pointer to script instanced logic node
   uScriptAct_SpawnPrefabAtLocation logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_140 = new uScriptAct_SpawnPrefabAtLocation( );
   System.String logic_uScriptAct_SpawnPrefabAtLocation_PrefabName_140 = "";
   System.String logic_uScriptAct_SpawnPrefabAtLocation_ResourcePath_140 = "";
   UnityEngine.Vector3 logic_uScriptAct_SpawnPrefabAtLocation_SpawnPosition_140 = new Vector3( );
   UnityEngine.Quaternion logic_uScriptAct_SpawnPrefabAtLocation_SpawnRotation_140 = new Quaternion( (float)0, (float)0, (float)0, (float)0 );
   System.String logic_uScriptAct_SpawnPrefabAtLocation_SpawnedName_140 = "";
   UnityEngine.GameObject logic_uScriptAct_SpawnPrefabAtLocation_SpawnedGameObject_140;
   System.Int32 logic_uScriptAct_SpawnPrefabAtLocation_SpawnedInstancedID_140;
   bool logic_uScriptAct_SpawnPrefabAtLocation_Immediate_140 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_142 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_142 = "";
   System.Int32 logic_uScriptAct_PrintText_FontSize_142 = (int) 32;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_142 = UnityEngine.FontStyle.Bold;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_142 = new UnityEngine.Color( (float)1, (float)1, (float)1, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_142 = UnityEngine.TextAnchor.MiddleCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_142 = (int) 128;
   System.Single logic_uScriptAct_PrintText_time_142 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_142 = true;
   //pointer to script instanced logic node
   uScriptAct_ScaleVector3 logic_uScriptAct_ScaleVector3_uScriptAct_ScaleVector3_146 = new uScriptAct_ScaleVector3( );
   UnityEngine.Vector3 logic_uScriptAct_ScaleVector3_v_146 = new Vector3( );
   System.Single logic_uScriptAct_ScaleVector3_s_146 = (float) 0;
   UnityEngine.Vector3 logic_uScriptAct_ScaleVector3_result_146;
   bool logic_uScriptAct_ScaleVector3_Out_146 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_153 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_153 = UnityEngine.KeyCode.A;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_153 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_153 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_153 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_16 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_29 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_81 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_102 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_129 = default(UnityEngine.GameObject);
   System.String event_UnityEngine_GameObject_EventName_129 = "";
   System.Boolean event_UnityEngine_GameObject_EventData_129 = (bool) false;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_129 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_134 = default(UnityEngine.GameObject);
   System.String event_UnityEngine_GameObject_EventName_134 = "";
   System.Boolean event_UnityEngine_GameObject_EventData_134 = (bool) false;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_134 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_138 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_149 = default(UnityEngine.GameObject);
   System.String event_UnityEngine_GameObject_EventName_149 = "";
   System.Int32 event_UnityEngine_GameObject_EventData_149 = (int) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_149 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_155 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_155 = default(UnityEngine.GameObject);
   
   //property nodes
   UnityEngine.Vector3 property_forward_Detox_ScriptEditor_Parameter_forward_77 = new Vector3( );
   UnityEngine.GameObject property_forward_Detox_ScriptEditor_Parameter_Instance_77 = default(UnityEngine.GameObject);
   UnityEngine.GameObject property_forward_Detox_ScriptEditor_Parameter_Instance_77_previous = null;
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   UnityEngine.Vector3 property_forward_Detox_ScriptEditor_Parameter_forward_77_Get_Refresh( )
   {
      UnityEngine.Transform component = property_forward_Detox_ScriptEditor_Parameter_Instance_77.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         return component.forward;
      }
      else
      {
         return new Vector3( );
      }
   }
   
   void property_forward_Detox_ScriptEditor_Parameter_forward_77_Set_Refresh( )
   {
      UnityEngine.Transform component = property_forward_Detox_ScriptEditor_Parameter_Instance_77.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         component.forward = property_forward_Detox_ScriptEditor_Parameter_forward_77;
      }
   }
   
   
   void SyncUnityHooks( )
   {
      if ( null == property_forward_Detox_ScriptEditor_Parameter_Instance_77 || false == m_RegisteredForEvents )
      {
         property_forward_Detox_ScriptEditor_Parameter_Instance_77 = GameObject.Find( "FireBot" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_forward_Detox_ScriptEditor_Parameter_Instance_77_previous != property_forward_Detox_ScriptEditor_Parameter_Instance_77 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_forward_Detox_ScriptEditor_Parameter_Instance_77_previous = property_forward_Detox_ScriptEditor_Parameter_Instance_77;
         
         //setup new listeners
      }
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_66_UnityEngine_GameObject_previous != local_66_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_66_UnityEngine_GameObject_previous = local_66_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_Player_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_Player_UnityEngine_GameObject = GameObject.Find( "FireBot" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_Player_UnityEngine_GameObject_previous != local_Player_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_Player_UnityEngine_GameObject_previous = local_Player_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_117_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_117_UnityEngine_GameObject = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_117_UnityEngine_GameObject_previous != local_117_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_117_UnityEngine_GameObject_previous = local_117_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_120_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_120_UnityEngine_GameObject = GameObject.Find( "MuzzleEnd" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_120_UnityEngine_GameObject_previous != local_120_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_120_UnityEngine_GameObject_previous = local_120_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_151_UnityEngine_GameObject_previous != local_151_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_151_UnityEngine_GameObject_previous = local_151_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void RegisterForUnityHooks( )
   {
      //if our game object reference was changed then we need to reset event listeners
      if ( property_forward_Detox_ScriptEditor_Parameter_Instance_77_previous != property_forward_Detox_ScriptEditor_Parameter_Instance_77 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_forward_Detox_ScriptEditor_Parameter_Instance_77_previous = property_forward_Detox_ScriptEditor_Parameter_Instance_77;
         
         //setup new listeners
      }
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_66_UnityEngine_GameObject_previous != local_66_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_66_UnityEngine_GameObject_previous = local_66_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_Player_UnityEngine_GameObject_previous != local_Player_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_Player_UnityEngine_GameObject_previous = local_Player_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_117_UnityEngine_GameObject_previous != local_117_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_117_UnityEngine_GameObject_previous = local_117_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_120_UnityEngine_GameObject_previous != local_120_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_120_UnityEngine_GameObject_previous = local_120_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_151_UnityEngine_GameObject_previous != local_151_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_151_UnityEngine_GameObject_previous = local_151_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void SyncEventListeners( )
   {
      {
         {
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( property_forward_Detox_ScriptEditor_Parameter_Instance_77_previous != property_forward_Detox_ScriptEditor_Parameter_Instance_77 || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  property_forward_Detox_ScriptEditor_Parameter_Instance_77_previous = property_forward_Detox_ScriptEditor_Parameter_Instance_77;
                  
                  //setup new listeners
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_16 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_16 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_16 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_16.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_16.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_16;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_29 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_29 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_29 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_29.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_29.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_29;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_81 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_81 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_81 )
         {
            {
               uScript_Global component = event_UnityEngine_GameObject_Instance_81.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_81.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_81;
                  component.uScriptLateStart += Instance_uScriptLateStart_81;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_102 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_102 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_102 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_102.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_102.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_102;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_129 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_129 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_129 )
         {
            {
               uScript_CustomEventBool component = event_UnityEngine_GameObject_Instance_129.GetComponent<uScript_CustomEventBool>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_129.AddComponent<uScript_CustomEventBool>();
               }
               if ( null != component )
               {
                  component.OnCustomEventBool += Instance_OnCustomEventBool_129;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_134 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_134 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_134 )
         {
            {
               uScript_CustomEventBool component = event_UnityEngine_GameObject_Instance_134.GetComponent<uScript_CustomEventBool>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_134.AddComponent<uScript_CustomEventBool>();
               }
               if ( null != component )
               {
                  component.OnCustomEventBool += Instance_OnCustomEventBool_134;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_138 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_138 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_138 )
         {
            {
               uScript_Update component = event_UnityEngine_GameObject_Instance_138.GetComponent<uScript_Update>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_138.AddComponent<uScript_Update>();
               }
               if ( null != component )
               {
                  component.OnUpdate += Instance_OnUpdate_138;
                  component.OnLateUpdate += Instance_OnLateUpdate_138;
                  component.OnFixedUpdate += Instance_OnFixedUpdate_138;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_149 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_149 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_149 )
         {
            {
               uScript_CustomEventInt component = event_UnityEngine_GameObject_Instance_149.GetComponent<uScript_CustomEventInt>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_149.AddComponent<uScript_CustomEventInt>();
               }
               if ( null != component )
               {
                  component.OnCustomEventInt += Instance_OnCustomEventInt_149;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_155 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_155 = GameObject.Find( "KillTrigger" ) as UnityEngine.GameObject;
         if ( null != event_UnityEngine_GameObject_Instance_155 )
         {
            {
               uScript_Trigger component = event_UnityEngine_GameObject_Instance_155.GetComponent<uScript_Trigger>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_155.AddComponent<uScript_Trigger>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_155;
                  component.OnExitTrigger += Instance_OnExitTrigger_155;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_155;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != event_UnityEngine_GameObject_Instance_16 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_16.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_16;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_29 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_29.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_29;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_81 )
      {
         {
            uScript_Global component = event_UnityEngine_GameObject_Instance_81.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_81;
               component.uScriptLateStart -= Instance_uScriptLateStart_81;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_102 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_102.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_102;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_129 )
      {
         {
            uScript_CustomEventBool component = event_UnityEngine_GameObject_Instance_129.GetComponent<uScript_CustomEventBool>();
            if ( null != component )
            {
               component.OnCustomEventBool -= Instance_OnCustomEventBool_129;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_134 )
      {
         {
            uScript_CustomEventBool component = event_UnityEngine_GameObject_Instance_134.GetComponent<uScript_CustomEventBool>();
            if ( null != component )
            {
               component.OnCustomEventBool -= Instance_OnCustomEventBool_134;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_138 )
      {
         {
            uScript_Update component = event_UnityEngine_GameObject_Instance_138.GetComponent<uScript_Update>();
            if ( null != component )
            {
               component.OnUpdate -= Instance_OnUpdate_138;
               component.OnLateUpdate -= Instance_OnLateUpdate_138;
               component.OnFixedUpdate -= Instance_OnFixedUpdate_138;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_149 )
      {
         {
            uScript_CustomEventInt component = event_UnityEngine_GameObject_Instance_149.GetComponent<uScript_CustomEventInt>();
            if ( null != component )
            {
               component.OnCustomEventInt -= Instance_OnCustomEventInt_149;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_155 )
      {
         {
            uScript_Trigger component = event_UnityEngine_GameObject_Instance_155.GetComponent<uScript_Trigger>();
            if ( null != component )
            {
               component.OnEnterTrigger -= Instance_OnEnterTrigger_155;
               component.OnExitTrigger -= Instance_OnExitTrigger_155;
               component.WhileInsideTrigger -= Instance_WhileInsideTrigger_155;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_2.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_4.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_5.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_8.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_10.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_12.SetParent(g);
      logic_uScriptAct_AddForce_uScriptAct_AddForce_13.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_14.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_17.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_18.SetParent(g);
      logic_uScriptAct_SendCustomEventBool_uScriptAct_SendCustomEventBool_19.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_20.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_21.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_22.SetParent(g);
      logic_uScriptAct_SetFloat_uScriptAct_SetFloat_24.SetParent(g);
      logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_26.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_28.SetParent(g);
      logic_uScriptAct_Destroy_uScriptAct_Destroy_31.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_39.SetParent(g);
      logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_41.SetParent(g);
      logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_47.SetParent(g);
      logic_uScriptCon_TimedGate_uScriptCon_TimedGate_49.SetParent(g);
      logic_uScriptAct_SubtractInt_uScriptAct_SubtractInt_50.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_51.SetParent(g);
      logic_uScriptCon_CompareInt_uScriptCon_CompareInt_53.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_55.SetParent(g);
      logic_uScriptAct_SendCustomEventBool_uScriptAct_SendCustomEventBool_56.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_57.SetParent(g);
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_58.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_60.SetParent(g);
      logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_62.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_64.SetParent(g);
      logic_uScriptAct_AddFloat_uScriptAct_AddFloat_65.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_69.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_73.SetParent(g);
      logic_uScriptAct_SetGameObjectPosition_uScriptAct_SetGameObjectPosition_74.SetParent(g);
      logic_uScriptAct_AddForce_uScriptAct_AddForce_76.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_79.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_82.SetParent(g);
      logic_uScriptAct_SetFloat_uScriptAct_SetFloat_83.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_84.SetParent(g);
      logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_87.SetParent(g);
      logic_uScriptAct_AddInt_uScriptAct_AddInt_88.SetParent(g);
      logic_uScriptAct_SpawnPrefab_uScriptAct_SpawnPrefab_91.SetParent(g);
      logic_uScriptCon_CompareInt_uScriptCon_CompareInt_99.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_106.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_107.SetParent(g);
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_108.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_113.SetParent(g);
      logic_uScriptCon_CompareInt_uScriptCon_CompareInt_114.SetParent(g);
      logic_uScriptAct_SetFloat_uScriptAct_SetFloat_116.SetParent(g);
      logic_uScriptAct_ConvertVariable_uScriptAct_ConvertVariable_118.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_121.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_122.SetParent(g);
      logic_uScriptAct_ScaleVector3_uScriptAct_ScaleVector3_125.SetParent(g);
      logic_uScriptAct_SetFloat_uScriptAct_SetFloat_127.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_128.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_130.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_132.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_133.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_135.SetParent(g);
      logic_uScriptAct_GetComponentsVector3_uScriptAct_GetComponentsVector3_136.SetParent(g);
      logic_uScriptAct_AddInt_uScriptAct_AddInt_137.SetParent(g);
      logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_140.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_142.SetParent(g);
      logic_uScriptAct_ScaleVector3_uScriptAct_ScaleVector3_146.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_153.SetParent(g);
   }
   public void Awake()
   {
      
      logic_uScriptCon_TimedGate_uScriptCon_TimedGate_49.Out += uScriptCon_TimedGate_Out_49;
      logic_uScriptAct_SpawnPrefab_uScriptAct_SpawnPrefab_91.FinishedSpawning += uScriptAct_SpawnPrefab_FinishedSpawning_91;
      logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_140.FinishedSpawning += uScriptAct_SpawnPrefabAtLocation_FinishedSpawning_140;
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
      
      logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_41.Update( );
      logic_uScriptCon_TimedGate_uScriptCon_TimedGate_49.Update( );
      logic_uScriptAct_SpawnPrefab_uScriptAct_SpawnPrefab_91.Update( );
      logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_140.Update( );
      if (true == logic_uScriptAct_Destroy_WaitOneTick_31)
      {
         Relay_WaitOneTick_31();
      }
      if (true == logic_uScriptAct_Delay_DrivenDelay_55)
      {
         Relay_DrivenDelay_55();
      }
      if (true == logic_uScriptAct_Delay_DrivenDelay_64)
      {
         Relay_DrivenDelay_64();
      }
   }
   
   public void OnDestroy()
   {
      logic_uScriptCon_TimedGate_uScriptCon_TimedGate_49.Out -= uScriptCon_TimedGate_Out_49;
      logic_uScriptAct_SpawnPrefab_uScriptAct_SpawnPrefab_91.FinishedSpawning -= uScriptAct_SpawnPrefab_FinishedSpawning_91;
      logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_140.FinishedSpawning -= uScriptAct_SpawnPrefabAtLocation_FinishedSpawning_140;
   }
   
   public void OnGUI()
   {
      logic_uScriptAct_PrintText_uScriptAct_PrintText_17.OnGUI( );
      logic_uScriptAct_PrintText_uScriptAct_PrintText_18.OnGUI( );
      logic_uScriptAct_PrintText_uScriptAct_PrintText_20.OnGUI( );
      logic_uScriptAct_PrintText_uScriptAct_PrintText_22.OnGUI( );
      logic_uScriptAct_PrintText_uScriptAct_PrintText_107.OnGUI( );
      logic_uScriptAct_PrintText_uScriptAct_PrintText_113.OnGUI( );
      logic_uScriptAct_PrintText_uScriptAct_PrintText_133.OnGUI( );
      logic_uScriptAct_PrintText_uScriptAct_PrintText_142.OnGUI( );
   }
   
   void Instance_KeyEvent_16(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_16( );
   }
   
   void Instance_KeyEvent_29(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_29( );
   }
   
   void Instance_uScriptStart_81(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_81( );
   }
   
   void Instance_uScriptLateStart_81(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptLateStart_81( );
   }
   
   void Instance_KeyEvent_102(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_102( );
   }
   
   void Instance_OnCustomEventBool_129(object o, uScript_CustomEventBool.CustomEventBoolArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_129 = e.Sender;
      event_UnityEngine_GameObject_EventName_129 = e.EventName;
      event_UnityEngine_GameObject_EventData_129 = e.EventData;
      //relay event to nodes
      Relay_OnCustomEventBool_129( );
   }
   
   void Instance_OnCustomEventBool_134(object o, uScript_CustomEventBool.CustomEventBoolArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_134 = e.Sender;
      event_UnityEngine_GameObject_EventName_134 = e.EventName;
      event_UnityEngine_GameObject_EventData_134 = e.EventData;
      //relay event to nodes
      Relay_OnCustomEventBool_134( );
   }
   
   void Instance_OnUpdate_138(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUpdate_138( );
   }
   
   void Instance_OnLateUpdate_138(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnLateUpdate_138( );
   }
   
   void Instance_OnFixedUpdate_138(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnFixedUpdate_138( );
   }
   
   void Instance_OnCustomEventInt_149(object o, uScript_CustomEventInt.CustomEventIntArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_149 = e.Sender;
      event_UnityEngine_GameObject_EventName_149 = e.EventName;
      event_UnityEngine_GameObject_EventData_149 = e.EventData;
      //relay event to nodes
      Relay_OnCustomEventInt_149( );
   }
   
   void Instance_OnEnterTrigger_155(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_155 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_155( );
   }
   
   void Instance_OnExitTrigger_155(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_155 = e.GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_155( );
   }
   
   void Instance_WhileInsideTrigger_155(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_155 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_155( );
   }
   
   void uScriptCon_TimedGate_Out_49(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Out_49( );
   }
   
   void uScriptAct_SpawnPrefab_FinishedSpawning_91(object o, System.EventArgs e)
   {
      //fill globals
      //links to SpawnedGameObject = 1
      local_151_UnityEngine_GameObject = logic_uScriptAct_SpawnPrefab_SpawnedGameObject_91;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_151_UnityEngine_GameObject_previous != local_151_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_151_UnityEngine_GameObject_previous = local_151_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
      //links to SpawnedInstancedID = 0
      //relay event to nodes
      Relay_FinishedSpawning_91( );
   }
   
   void uScriptAct_SpawnPrefabAtLocation_FinishedSpawning_140(object o, System.EventArgs e)
   {
      //fill globals
      //links to SpawnedGameObject = 0
      //links to SpawnedInstancedID = 0
      //relay event to nodes
      Relay_FinishedSpawning_140( );
   }
   
   void Relay_In_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("cef60b67-9ce4-41ea-a21e-3f09e461ebae", "Set_Random_Float", Relay_In_2)) return; 
         {
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_2.In(logic_uScriptAct_SetRandomFloat_Min_2, logic_uScriptAct_SetRandomFloat_Max_2, out logic_uScriptAct_SetRandomFloat_TargetFloat_2);
         local_9_System_Single = logic_uScriptAct_SetRandomFloat_TargetFloat_2;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_2.Out;
         
         if ( test_0 == true )
         {
            Relay_In_47();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Set Random Float.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_4()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d1af21da-0b68-462b-a45f-0006202bd66e", "Compare_String", Relay_In_4)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_4 = local_101_System_String;
               
            }
            {
               logic_uScriptCon_CompareString_B_4 = local_1_System_String;
               
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_4.In(logic_uScriptCon_CompareString_A_4, logic_uScriptCon_CompareString_B_4);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_4.Same;
         
         if ( test_0 == true )
         {
            Relay_In_137();
            Relay_In_64();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("845c1acc-2195-4b9b-bbcf-4e9354e3beae", "Compare_Bool", Relay_In_5)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_5 = local_Turbo_Mode__System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_5.In(logic_uScriptCon_CompareBool_Bool_5);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_5.True;
         bool test_1 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_5.False;
         
         if ( test_0 == true )
         {
            Relay_In_116();
         }
         if ( test_1 == true )
         {
            Relay_In_83();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_8()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("bf53f205-9e42-479c-bcc7-cbb8e6141c71", "Compare_Bool", Relay_In_8)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_8 = local_Game_In_Progress__System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_8.In(logic_uScriptCon_CompareBool_Bool_8);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_8.True;
         
         if ( test_0 == true )
         {
            Relay_SendCustomEvent_19();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("778c6f62-92f1-4f8b-a6c4-bd4c4c75df32", "Compare_Bool", Relay_In_10)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_10 = local_Game_In_Progress__System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_10.In(logic_uScriptCon_CompareBool_Bool_10);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_10.True;
         
         if ( test_0 == true )
         {
            Relay_In_39();
            Relay_In_69();
            Relay_In_122();
            Relay_In_14();
            Relay_In_57();
            Relay_In_51();
            Relay_In_28();
            Relay_In_153();
            Relay_In_135();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_12()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("657e8a86-9f3b-4cd5-b9c4-b4ace7c4e9cf", "Compare_String", Relay_In_12)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_12 = local_33_System_String;
               
            }
            {
               logic_uScriptCon_CompareString_B_12 = local_92_System_String;
               
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_12.In(logic_uScriptCon_CompareString_A_12, logic_uScriptCon_CompareString_B_12);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_12.Same;
         
         if ( test_0 == true )
         {
            Relay_In_88();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_13()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5c7ec8e3-4df6-4ecd-97cf-294b863c9452", "Add_Force", Relay_In_13)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_151_UnityEngine_GameObject_previous != local_151_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_151_UnityEngine_GameObject_previous = local_151_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_AddForce_Target_13 = local_151_UnityEngine_GameObject;
               
            }
            {
               logic_uScriptAct_AddForce_Force_13 = local_131_UnityEngine_Vector3;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddForce_uScriptAct_AddForce_13.In(logic_uScriptAct_AddForce_Target_13, logic_uScriptAct_AddForce_Force_13, logic_uScriptAct_AddForce_Scale_13, logic_uScriptAct_AddForce_UseForceMode_13, logic_uScriptAct_AddForce_ForceModeType_13);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Add Force.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_14()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d225646c-c257-4511-8776-7b052d03c71d", "Input_Events_Filter", Relay_In_14)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_14.In(logic_uScriptAct_OnInputEventFilter_KeyCode_14);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_14.KeyHeld;
         bool test_1 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_14.KeyUp;
         
         if ( test_0 == true )
         {
            Relay_True_121();
            Relay_MoveBackward_41();
         }
         if ( test_1 == true )
         {
            Relay_False_121();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_16()
   {
      if (true == CheckDebugBreak("e798688b-b945-4889-a51f-cfa78b061f81", "Input_Events", Relay_KeyEvent_16)) return; 
      Relay_In_10();
   }
   
   void Relay_ShowLabel_17()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("629f9d31-6fa0-4ccd-b09a-06b9ee70b928", "Print_Text", Relay_ShowLabel_17)) return; 
         {
            {
               logic_uScriptAct_PrintText_Text_17 = local_Points_String_System_String;
               
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_17.ShowLabel(logic_uScriptAct_PrintText_Text_17, logic_uScriptAct_PrintText_FontSize_17, logic_uScriptAct_PrintText_FontStyle_17, logic_uScriptAct_PrintText_FontColor_17, logic_uScriptAct_PrintText_textAnchor_17, logic_uScriptAct_PrintText_EdgePadding_17, logic_uScriptAct_PrintText_time_17);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_17()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("629f9d31-6fa0-4ccd-b09a-06b9ee70b928", "Print_Text", Relay_HideLabel_17)) return; 
         {
            {
               logic_uScriptAct_PrintText_Text_17 = local_Points_String_System_String;
               
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_17.HideLabel(logic_uScriptAct_PrintText_Text_17, logic_uScriptAct_PrintText_FontSize_17, logic_uScriptAct_PrintText_FontStyle_17, logic_uScriptAct_PrintText_FontColor_17, logic_uScriptAct_PrintText_textAnchor_17, logic_uScriptAct_PrintText_EdgePadding_17, logic_uScriptAct_PrintText_time_17);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_18()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8cfc5aca-fa1d-41f6-ae67-8d6b350a9354", "Print_Text", Relay_ShowLabel_18)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_18.ShowLabel(logic_uScriptAct_PrintText_Text_18, logic_uScriptAct_PrintText_FontSize_18, logic_uScriptAct_PrintText_FontStyle_18, logic_uScriptAct_PrintText_FontColor_18, logic_uScriptAct_PrintText_textAnchor_18, logic_uScriptAct_PrintText_EdgePadding_18, logic_uScriptAct_PrintText_time_18);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_18()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8cfc5aca-fa1d-41f6-ae67-8d6b350a9354", "Print_Text", Relay_HideLabel_18)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_18.HideLabel(logic_uScriptAct_PrintText_Text_18, logic_uScriptAct_PrintText_FontSize_18, logic_uScriptAct_PrintText_FontStyle_18, logic_uScriptAct_PrintText_FontColor_18, logic_uScriptAct_PrintText_textAnchor_18, logic_uScriptAct_PrintText_EdgePadding_18, logic_uScriptAct_PrintText_time_18);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_SendCustomEvent_19()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("14b2e874-4b2b-416a-9b96-6ca0cfffdee0", "Send_Custom_Event__Bool_", Relay_SendCustomEvent_19)) return; 
         {
            {
               logic_uScriptAct_SendCustomEventBool_EventName_19 = local_103_System_String;
               
            }
            {
               logic_uScriptAct_SendCustomEventBool_EventValue_19 = local_11_System_Boolean;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SendCustomEventBool_uScriptAct_SendCustomEventBool_19.SendCustomEvent(logic_uScriptAct_SendCustomEventBool_EventName_19, logic_uScriptAct_SendCustomEventBool_EventValue_19, logic_uScriptAct_SendCustomEventBool_sendGroup_19, logic_uScriptAct_SendCustomEventBool_EventSender_19);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Send Custom Event (Bool).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_20()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7b6e1b64-e1ac-473a-9a34-e0925fe93501", "Print_Text", Relay_ShowLabel_20)) return; 
         {
            {
               logic_uScriptAct_PrintText_Text_20 = local_148_System_String;
               
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_20.ShowLabel(logic_uScriptAct_PrintText_Text_20, logic_uScriptAct_PrintText_FontSize_20, logic_uScriptAct_PrintText_FontStyle_20, logic_uScriptAct_PrintText_FontColor_20, logic_uScriptAct_PrintText_textAnchor_20, logic_uScriptAct_PrintText_EdgePadding_20, logic_uScriptAct_PrintText_time_20);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_20()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7b6e1b64-e1ac-473a-9a34-e0925fe93501", "Print_Text", Relay_HideLabel_20)) return; 
         {
            {
               logic_uScriptAct_PrintText_Text_20 = local_148_System_String;
               
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_20.HideLabel(logic_uScriptAct_PrintText_Text_20, logic_uScriptAct_PrintText_FontSize_20, logic_uScriptAct_PrintText_FontStyle_20, logic_uScriptAct_PrintText_FontColor_20, logic_uScriptAct_PrintText_textAnchor_20, logic_uScriptAct_PrintText_EdgePadding_20, logic_uScriptAct_PrintText_time_20);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_21()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b5fc28d0-37ac-4aa1-a1af-1e5a6587d572", "Set_Bool", Relay_True_21)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_21.True(out logic_uScriptAct_SetBool_Target_21);
         local_Game_In_Progress__System_Boolean = logic_uScriptAct_SetBool_Target_21;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_21.Out;
         
         if ( test_0 == true )
         {
            Relay_In_58();
            Relay_ShowLabel_18();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_21()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b5fc28d0-37ac-4aa1-a1af-1e5a6587d572", "Set_Bool", Relay_False_21)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_21.False(out logic_uScriptAct_SetBool_Target_21);
         local_Game_In_Progress__System_Boolean = logic_uScriptAct_SetBool_Target_21;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_21.Out;
         
         if ( test_0 == true )
         {
            Relay_In_58();
            Relay_ShowLabel_18();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_22()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d9345b16-7824-4c70-89a1-8d25ae3c60e4", "Print_Text", Relay_ShowLabel_22)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_22.ShowLabel(logic_uScriptAct_PrintText_Text_22, logic_uScriptAct_PrintText_FontSize_22, logic_uScriptAct_PrintText_FontStyle_22, logic_uScriptAct_PrintText_FontColor_22, logic_uScriptAct_PrintText_textAnchor_22, logic_uScriptAct_PrintText_EdgePadding_22, logic_uScriptAct_PrintText_time_22);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_22()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d9345b16-7824-4c70-89a1-8d25ae3c60e4", "Print_Text", Relay_HideLabel_22)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_22.HideLabel(logic_uScriptAct_PrintText_Text_22, logic_uScriptAct_PrintText_FontSize_22, logic_uScriptAct_PrintText_FontStyle_22, logic_uScriptAct_PrintText_FontColor_22, logic_uScriptAct_PrintText_textAnchor_22, logic_uScriptAct_PrintText_EdgePadding_22, logic_uScriptAct_PrintText_time_22);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_24()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("368f95bb-25ae-4840-a483-bf858fbc27a8", "Set_Float", Relay_In_24)) return; 
         {
            {
               logic_uScriptAct_SetFloat_Value_24 = local_80_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_SetFloat_uScriptAct_SetFloat_24.In(logic_uScriptAct_SetFloat_Value_24, out logic_uScriptAct_SetFloat_Target_24);
         BotSpeedPerSecond = logic_uScriptAct_SetFloat_Target_24;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Set Float.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_26()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("74195ff4-4421-4e8f-828f-d7e678690ca0", "Set_Random_Float", Relay_In_26)) return; 
         {
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_26.In(logic_uScriptAct_SetRandomFloat_Min_26, logic_uScriptAct_SetRandomFloat_Max_26, out logic_uScriptAct_SetRandomFloat_TargetFloat_26);
         local_75_System_Single = logic_uScriptAct_SetRandomFloat_TargetFloat_26;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_26.Out;
         
         if ( test_0 == true )
         {
            Relay_In_2();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Set Random Float.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_28()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("105847ef-0a41-4f88-a623-9e5644e331ca", "Input_Events_Filter", Relay_In_28)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_28.In(logic_uScriptAct_OnInputEventFilter_KeyCode_28);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_28.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_RotateLeft_41();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_29()
   {
      if (true == CheckDebugBreak("ea6be845-bc86-455e-9890-291d4b441f09", "Input_Events", Relay_KeyEvent_29)) return; 
      Relay_In_53();
   }
   
   void Relay_In_31()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0e882847-e42e-4799-b21f-ab15202ff3fa", "Destroy", Relay_In_31)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_66_UnityEngine_GameObject_previous != local_66_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_66_UnityEngine_GameObject_previous = local_66_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_66_UnityEngine_GameObject);
               logic_uScriptAct_Destroy_Target_31 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Destroy_uScriptAct_Destroy_31.In(logic_uScriptAct_Destroy_Target_31, logic_uScriptAct_Destroy_DelayTime_31);
         logic_uScriptAct_Destroy_WaitOneTick_31 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Destroy.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_WaitOneTick_31( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_66_UnityEngine_GameObject_previous != local_66_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_66_UnityEngine_GameObject_previous = local_66_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_66_UnityEngine_GameObject);
               logic_uScriptAct_Destroy_Target_31 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Destroy_WaitOneTick_31 = logic_uScriptAct_Destroy_uScriptAct_Destroy_31.WaitOneTick();
         if ( true == logic_uScriptAct_Destroy_WaitOneTick_31 )
         {
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Destroy.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_In_39()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("cfc3ac3f-c149-4429-810d-4a04fa9536c9", "Input_Events_Filter", Relay_In_39)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_39.In(logic_uScriptAct_OnInputEventFilter_KeyCode_39);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_39.KeyHeld;
         bool test_1 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_39.KeyUp;
         
         if ( test_0 == true )
         {
            Relay_MoveBackward_41();
            Relay_True_121();
         }
         if ( test_1 == true )
         {
            Relay_False_121();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_MoveForward_41()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1b035f38-bc3e-4c5f-82ec-3450abe215b5", "Isometric_Character_Controller", Relay_MoveForward_41)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_Player_UnityEngine_GameObject_previous != local_Player_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_Player_UnityEngine_GameObject_previous = local_Player_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_IsometricCharacterController_target_41 = local_Player_UnityEngine_GameObject;
               
            }
            {
               logic_uScriptAct_IsometricCharacterController_translation_41 = BotSpeedPerSecond;
               
            }
            {
               logic_uScriptAct_IsometricCharacterController_rotation_41 = BotTurnPerSecond;
               
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
         logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_41.MoveForward(logic_uScriptAct_IsometricCharacterController_target_41, logic_uScriptAct_IsometricCharacterController_translation_41, logic_uScriptAct_IsometricCharacterController_rotation_41, logic_uScriptAct_IsometricCharacterController_filterTranslation_41, logic_uScriptAct_IsometricCharacterController_translationFilterConstant_41, logic_uScriptAct_IsometricCharacterController_filterRotation_41, logic_uScriptAct_IsometricCharacterController_rotationFilterConstant_41);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_41.Out;
         
         if ( test_0 == true )
         {
            Relay_In_62();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Isometric Character Controller.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_MoveBackward_41()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1b035f38-bc3e-4c5f-82ec-3450abe215b5", "Isometric_Character_Controller", Relay_MoveBackward_41)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_Player_UnityEngine_GameObject_previous != local_Player_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_Player_UnityEngine_GameObject_previous = local_Player_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_IsometricCharacterController_target_41 = local_Player_UnityEngine_GameObject;
               
            }
            {
               logic_uScriptAct_IsometricCharacterController_translation_41 = BotSpeedPerSecond;
               
            }
            {
               logic_uScriptAct_IsometricCharacterController_rotation_41 = BotTurnPerSecond;
               
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
         logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_41.MoveBackward(logic_uScriptAct_IsometricCharacterController_target_41, logic_uScriptAct_IsometricCharacterController_translation_41, logic_uScriptAct_IsometricCharacterController_rotation_41, logic_uScriptAct_IsometricCharacterController_filterTranslation_41, logic_uScriptAct_IsometricCharacterController_translationFilterConstant_41, logic_uScriptAct_IsometricCharacterController_filterRotation_41, logic_uScriptAct_IsometricCharacterController_rotationFilterConstant_41);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_41.Out;
         
         if ( test_0 == true )
         {
            Relay_In_62();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Isometric Character Controller.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_StrafeRight_41()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1b035f38-bc3e-4c5f-82ec-3450abe215b5", "Isometric_Character_Controller", Relay_StrafeRight_41)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_Player_UnityEngine_GameObject_previous != local_Player_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_Player_UnityEngine_GameObject_previous = local_Player_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_IsometricCharacterController_target_41 = local_Player_UnityEngine_GameObject;
               
            }
            {
               logic_uScriptAct_IsometricCharacterController_translation_41 = BotSpeedPerSecond;
               
            }
            {
               logic_uScriptAct_IsometricCharacterController_rotation_41 = BotTurnPerSecond;
               
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
         logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_41.StrafeRight(logic_uScriptAct_IsometricCharacterController_target_41, logic_uScriptAct_IsometricCharacterController_translation_41, logic_uScriptAct_IsometricCharacterController_rotation_41, logic_uScriptAct_IsometricCharacterController_filterTranslation_41, logic_uScriptAct_IsometricCharacterController_translationFilterConstant_41, logic_uScriptAct_IsometricCharacterController_filterRotation_41, logic_uScriptAct_IsometricCharacterController_rotationFilterConstant_41);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_41.Out;
         
         if ( test_0 == true )
         {
            Relay_In_62();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Isometric Character Controller.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_StrafeLeft_41()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1b035f38-bc3e-4c5f-82ec-3450abe215b5", "Isometric_Character_Controller", Relay_StrafeLeft_41)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_Player_UnityEngine_GameObject_previous != local_Player_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_Player_UnityEngine_GameObject_previous = local_Player_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_IsometricCharacterController_target_41 = local_Player_UnityEngine_GameObject;
               
            }
            {
               logic_uScriptAct_IsometricCharacterController_translation_41 = BotSpeedPerSecond;
               
            }
            {
               logic_uScriptAct_IsometricCharacterController_rotation_41 = BotTurnPerSecond;
               
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
         logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_41.StrafeLeft(logic_uScriptAct_IsometricCharacterController_target_41, logic_uScriptAct_IsometricCharacterController_translation_41, logic_uScriptAct_IsometricCharacterController_rotation_41, logic_uScriptAct_IsometricCharacterController_filterTranslation_41, logic_uScriptAct_IsometricCharacterController_translationFilterConstant_41, logic_uScriptAct_IsometricCharacterController_filterRotation_41, logic_uScriptAct_IsometricCharacterController_rotationFilterConstant_41);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_41.Out;
         
         if ( test_0 == true )
         {
            Relay_In_62();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Isometric Character Controller.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_RotateRight_41()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1b035f38-bc3e-4c5f-82ec-3450abe215b5", "Isometric_Character_Controller", Relay_RotateRight_41)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_Player_UnityEngine_GameObject_previous != local_Player_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_Player_UnityEngine_GameObject_previous = local_Player_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_IsometricCharacterController_target_41 = local_Player_UnityEngine_GameObject;
               
            }
            {
               logic_uScriptAct_IsometricCharacterController_translation_41 = BotSpeedPerSecond;
               
            }
            {
               logic_uScriptAct_IsometricCharacterController_rotation_41 = BotTurnPerSecond;
               
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
         logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_41.RotateRight(logic_uScriptAct_IsometricCharacterController_target_41, logic_uScriptAct_IsometricCharacterController_translation_41, logic_uScriptAct_IsometricCharacterController_rotation_41, logic_uScriptAct_IsometricCharacterController_filterTranslation_41, logic_uScriptAct_IsometricCharacterController_translationFilterConstant_41, logic_uScriptAct_IsometricCharacterController_filterRotation_41, logic_uScriptAct_IsometricCharacterController_rotationFilterConstant_41);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_41.Out;
         
         if ( test_0 == true )
         {
            Relay_In_62();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Isometric Character Controller.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_RotateLeft_41()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1b035f38-bc3e-4c5f-82ec-3450abe215b5", "Isometric_Character_Controller", Relay_RotateLeft_41)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_Player_UnityEngine_GameObject_previous != local_Player_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_Player_UnityEngine_GameObject_previous = local_Player_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_IsometricCharacterController_target_41 = local_Player_UnityEngine_GameObject;
               
            }
            {
               logic_uScriptAct_IsometricCharacterController_translation_41 = BotSpeedPerSecond;
               
            }
            {
               logic_uScriptAct_IsometricCharacterController_rotation_41 = BotTurnPerSecond;
               
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
         logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_41.RotateLeft(logic_uScriptAct_IsometricCharacterController_target_41, logic_uScriptAct_IsometricCharacterController_translation_41, logic_uScriptAct_IsometricCharacterController_rotation_41, logic_uScriptAct_IsometricCharacterController_filterTranslation_41, logic_uScriptAct_IsometricCharacterController_translationFilterConstant_41, logic_uScriptAct_IsometricCharacterController_filterRotation_41, logic_uScriptAct_IsometricCharacterController_rotationFilterConstant_41);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_41.Out;
         
         if ( test_0 == true )
         {
            Relay_In_62();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Isometric Character Controller.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_47()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("967dd60e-7d02-49e5-81bc-44e40d9c69d8", "Set_Components__Vector3_", Relay_In_47)) return; 
         {
            {
               logic_uScriptAct_SetComponentsVector3_X_47 = local_75_System_Single;
               
            }
            {
            }
            {
               logic_uScriptAct_SetComponentsVector3_Z_47 = local_9_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_47.In(logic_uScriptAct_SetComponentsVector3_X_47, logic_uScriptAct_SetComponentsVector3_Y_47, logic_uScriptAct_SetComponentsVector3_Z_47, out logic_uScriptAct_SetComponentsVector3_OutputVector3_47);
         local_141_UnityEngine_Vector3 = logic_uScriptAct_SetComponentsVector3_OutputVector3_47;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_47.Out;
         
         if ( test_0 == true )
         {
            Relay_In_140();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Set Components (Vector3).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Out_49()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ca4bd269-adde-4fdc-8c32-90fd0e51bba0", "Timed_Gate", Relay_Out_49)) return; 
         Relay_In_91();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Timed Gate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_49()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ca4bd269-adde-4fdc-8c32-90fd0e51bba0", "Timed_Gate", Relay_In_49)) return; 
         {
            {
               logic_uScriptCon_TimedGate_Duration_49 = local_94_System_Single;
               
            }
            {
            }
         }
         logic_uScriptCon_TimedGate_uScriptCon_TimedGate_49.In(logic_uScriptCon_TimedGate_Duration_49, logic_uScriptCon_TimedGate_StartOpen_49);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Timed Gate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_50()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3ef217c8-801f-44ce-8b73-9f1165746417", "Subtract_Int", Relay_In_50)) return; 
         {
            {
               logic_uScriptAct_SubtractInt_A_50 = local_Seconds_Left_System_Int32;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SubtractInt_uScriptAct_SubtractInt_50.In(logic_uScriptAct_SubtractInt_A_50, logic_uScriptAct_SubtractInt_B_50, out logic_uScriptAct_SubtractInt_IntResult_50, out logic_uScriptAct_SubtractInt_FloatResult_50);
         local_Seconds_Left_System_Int32 = logic_uScriptAct_SubtractInt_IntResult_50;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SubtractInt_uScriptAct_SubtractInt_50.Out;
         
         if ( test_0 == true )
         {
            Relay_In_114();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Subtract Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_51()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6d32a3e4-4f0d-4991-b5b0-710c873b3696", "Input_Events_Filter", Relay_In_51)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_51.In(logic_uScriptAct_OnInputEventFilter_KeyCode_51);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_51.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_MoveForward_41();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_53()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ef5a55bf-b35e-42c9-a05c-c76e5419108f", "Compare_Int", Relay_In_53)) return; 
         {
            {
               logic_uScriptCon_CompareInt_A_53 = local_Points_System_Int32;
               
            }
            {
               logic_uScriptCon_CompareInt_B_53 = local_152_System_Int32;
               
            }
         }
         logic_uScriptCon_CompareInt_uScriptCon_CompareInt_53.In(logic_uScriptCon_CompareInt_A_53, logic_uScriptCon_CompareInt_B_53);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareInt_uScriptCon_CompareInt_53.EqualTo;
         
         if ( test_0 == true )
         {
            Relay_In_84();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Compare Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_55()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b96ee52e-5d88-4341-8b5e-672efa92928f", "Delay", Relay_In_55)) return; 
         {
            {
               logic_uScriptAct_Delay_Duration_55 = local_35_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_55.In(logic_uScriptAct_Delay_Duration_55, logic_uScriptAct_Delay_SingleFrame_55);
         logic_uScriptAct_Delay_DrivenDelay_55 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_55.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_In_137();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_55()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b96ee52e-5d88-4341-8b5e-672efa92928f", "Delay", Relay_Stop_55)) return; 
         {
            {
               logic_uScriptAct_Delay_Duration_55 = local_35_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_55.Stop(logic_uScriptAct_Delay_Duration_55, logic_uScriptAct_Delay_SingleFrame_55);
         logic_uScriptAct_Delay_DrivenDelay_55 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_55.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_In_137();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_DrivenDelay_55( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               logic_uScriptAct_Delay_Duration_55 = local_35_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_Delay_DrivenDelay_55 = logic_uScriptAct_Delay_uScriptAct_Delay_55.DrivenDelay();
         if ( true == logic_uScriptAct_Delay_DrivenDelay_55 )
         {
            if ( logic_uScriptAct_Delay_uScriptAct_Delay_55.AfterDelay == true )
            {
               Relay_In_137();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_SendCustomEvent_56()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("bfadb89a-975a-46a0-a85f-7bda696aa394", "Send_Custom_Event__Bool_", Relay_SendCustomEvent_56)) return; 
         {
            {
               logic_uScriptAct_SendCustomEventBool_EventName_56 = local_68_System_String;
               
            }
            {
               logic_uScriptAct_SendCustomEventBool_EventValue_56 = local_Game_In_Progress__System_Boolean;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SendCustomEventBool_uScriptAct_SendCustomEventBool_56.SendCustomEvent(logic_uScriptAct_SendCustomEventBool_EventName_56, logic_uScriptAct_SendCustomEventBool_EventValue_56, logic_uScriptAct_SendCustomEventBool_sendGroup_56, logic_uScriptAct_SendCustomEventBool_EventSender_56);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Send Custom Event (Bool).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_57()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("06ba7eec-bb51-42c3-8657-887db5439f04", "Input_Events_Filter", Relay_In_57)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_57.In(logic_uScriptAct_OnInputEventFilter_KeyCode_57);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_57.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_MoveForward_41();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_58()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f8b17509-1adc-47b4-8810-001ce26d3855", "Concatenate", Relay_In_58)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_Points_String_System_String);
               logic_uScriptAct_Concatenate_B_58 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_Concatenate_uScriptAct_Concatenate_58.In(logic_uScriptAct_Concatenate_A_58, logic_uScriptAct_Concatenate_B_58, logic_uScriptAct_Concatenate_Separator_58, out logic_uScriptAct_Concatenate_Result_58);
         local_98_System_String = logic_uScriptAct_Concatenate_Result_58;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Concatenate_uScriptAct_Concatenate_58.Out;
         
         if ( test_0 == true )
         {
            Relay_ShowLabel_142();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Concatenate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_60()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("076f4ce8-2b8a-4764-a9c6-1648864646c1", "Compare_String", Relay_In_60)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_60 = local_112_System_String;
               
            }
            {
               logic_uScriptCon_CompareString_B_60 = local_119_System_String;
               
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_60.In(logic_uScriptCon_CompareString_A_60, logic_uScriptCon_CompareString_B_60);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_60.Same;
         
         if ( test_0 == true )
         {
            Relay_False_21();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_62()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ec1e798a-5d3c-4697-8ce7-a2f74e464c06", "Get_Position_and_Rotation", Relay_In_62)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_Player_UnityEngine_GameObject_previous != local_Player_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_Player_UnityEngine_GameObject_previous = local_Player_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_GetPositionAndRotation_Target_62 = local_Player_UnityEngine_GameObject;
               
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
         logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_62.In(logic_uScriptAct_GetPositionAndRotation_Target_62, logic_uScriptAct_GetPositionAndRotation_GetLocal_62, out logic_uScriptAct_GetPositionAndRotation_Position_62, out logic_uScriptAct_GetPositionAndRotation_Rotation_62, out logic_uScriptAct_GetPositionAndRotation_EulerAngles_62, out logic_uScriptAct_GetPositionAndRotation_Forward_62, out logic_uScriptAct_GetPositionAndRotation_Up_62, out logic_uScriptAct_GetPositionAndRotation_Right_62);
         local_30_UnityEngine_Vector3 = logic_uScriptAct_GetPositionAndRotation_Position_62;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_62.Out;
         
         if ( test_0 == true )
         {
            Relay_In_136();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Get Position and Rotation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_64()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a569f5a7-6143-488b-86eb-cafe8c5cd918", "Delay", Relay_In_64)) return; 
         {
            {
               logic_uScriptAct_Delay_Duration_64 = local_3_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_64.In(logic_uScriptAct_Delay_Duration_64, logic_uScriptAct_Delay_SingleFrame_64);
         logic_uScriptAct_Delay_DrivenDelay_64 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_64.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_In_50();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_64()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a569f5a7-6143-488b-86eb-cafe8c5cd918", "Delay", Relay_Stop_64)) return; 
         {
            {
               logic_uScriptAct_Delay_Duration_64 = local_3_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_64.Stop(logic_uScriptAct_Delay_Duration_64, logic_uScriptAct_Delay_SingleFrame_64);
         logic_uScriptAct_Delay_DrivenDelay_64 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_64.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_In_50();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_DrivenDelay_64( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               logic_uScriptAct_Delay_Duration_64 = local_3_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_Delay_DrivenDelay_64 = logic_uScriptAct_Delay_uScriptAct_Delay_64.DrivenDelay();
         if ( true == logic_uScriptAct_Delay_DrivenDelay_64 )
         {
            if ( logic_uScriptAct_Delay_uScriptAct_Delay_64.AfterDelay == true )
            {
               Relay_In_50();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_In_65()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("96806546-d135-4046-9de8-a046ad698142", "Add_Float", Relay_In_65)) return; 
         {
            {
               List<System.Single> properties = new List<System.Single>();
               properties.Add((System.Single)local_115_System_Single);
               logic_uScriptAct_AddFloat_A_65 = properties.ToArray();
            }
            {
               List<System.Single> properties = new List<System.Single>();
               properties.Add((System.Single)local_45_System_Single);
               logic_uScriptAct_AddFloat_B_65 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddFloat_uScriptAct_AddFloat_65.In(logic_uScriptAct_AddFloat_A_65, logic_uScriptAct_AddFloat_B_65, out logic_uScriptAct_AddFloat_FloatResult_65, out logic_uScriptAct_AddFloat_IntResult_65);
         local_44_System_Single = logic_uScriptAct_AddFloat_FloatResult_65;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddFloat_uScriptAct_AddFloat_65.Out;
         
         if ( test_0 == true )
         {
            Relay_In_87();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Add Float.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_69()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2d01b891-492b-4a48-a56e-d9b985e7ea9d", "Input_Events_Filter", Relay_In_69)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_69.In(logic_uScriptAct_OnInputEventFilter_KeyCode_69);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_69.KeyDown;
         bool test_1 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_69.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_In_5();
         }
         if ( test_1 == true )
         {
            Relay_In_49();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_73()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("78b05f59-4d8a-421e-af85-e074b9fc5298", "Set_Bool", Relay_True_73)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_73.True(out logic_uScriptAct_SetBool_Target_73);
         local_Game_In_Progress__System_Boolean = logic_uScriptAct_SetBool_Target_73;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_73.Out;
         
         if ( test_0 == true )
         {
            Relay_SendCustomEvent_56();
            Relay_HideLabel_22();
            Relay_HideLabel_133();
            Relay_HideLabel_107();
            Relay_HideLabel_113();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_73()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("78b05f59-4d8a-421e-af85-e074b9fc5298", "Set_Bool", Relay_False_73)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_73.False(out logic_uScriptAct_SetBool_Target_73);
         local_Game_In_Progress__System_Boolean = logic_uScriptAct_SetBool_Target_73;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_73.Out;
         
         if ( test_0 == true )
         {
            Relay_SendCustomEvent_56();
            Relay_HideLabel_22();
            Relay_HideLabel_133();
            Relay_HideLabel_107();
            Relay_HideLabel_113();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_74()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6fb23ca1-29ad-47cd-83ab-24e5057115bb", "Set_Position", Relay_In_74)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_117_UnityEngine_GameObject_previous != local_117_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_117_UnityEngine_GameObject_previous = local_117_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_117_UnityEngine_GameObject);
               logic_uScriptAct_SetGameObjectPosition_Target_74 = properties.ToArray();
            }
            {
               logic_uScriptAct_SetGameObjectPosition_Position_74 = local_144_UnityEngine_Vector3;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SetGameObjectPosition_uScriptAct_SetGameObjectPosition_74.In(logic_uScriptAct_SetGameObjectPosition_Target_74, logic_uScriptAct_SetGameObjectPosition_Position_74, logic_uScriptAct_SetGameObjectPosition_AsOffset_74, logic_uScriptAct_SetGameObjectPosition_AsLocal_74);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Set Position.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_76()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f358da71-3366-489c-932c-4747d4508c4d", "Add_Force", Relay_In_76)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_151_UnityEngine_GameObject_previous != local_151_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_151_UnityEngine_GameObject_previous = local_151_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_AddForce_Target_76 = local_151_UnityEngine_GameObject;
               
            }
            {
               logic_uScriptAct_AddForce_Force_76 = local_131_UnityEngine_Vector3;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddForce_uScriptAct_AddForce_76.In(logic_uScriptAct_AddForce_Target_76, logic_uScriptAct_AddForce_Force_76, logic_uScriptAct_AddForce_Scale_76, logic_uScriptAct_AddForce_UseForceMode_76, logic_uScriptAct_AddForce_ForceModeType_76);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Add Force.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_79()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("24834be8-20d2-4241-81ce-77ca027c086f", "Set_Bool", Relay_True_79)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_79.True(out logic_uScriptAct_SetBool_Target_79);
         local_Turbo_Mode__System_Boolean = logic_uScriptAct_SetBool_Target_79;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_79()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("24834be8-20d2-4241-81ce-77ca027c086f", "Set_Bool", Relay_False_79)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_79.False(out logic_uScriptAct_SetBool_Target_79);
         local_Turbo_Mode__System_Boolean = logic_uScriptAct_SetBool_Target_79;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_uScriptStart_81()
   {
      if (true == CheckDebugBreak("1e742aa9-a4ae-4034-ae11-68175fc3d425", "uScript_Events", Relay_uScriptStart_81)) return; 
      Relay_ShowLabel_107();
      Relay_ShowLabel_113();
      Relay_ShowLabel_133();
      Relay_ShowLabel_22();
   }
   
   void Relay_uScriptLateStart_81()
   {
      if (true == CheckDebugBreak("1e742aa9-a4ae-4034-ae11-68175fc3d425", "uScript_Events", Relay_uScriptLateStart_81)) return; 
   }
   
   void Relay_In_82()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("795bb3cf-9a61-43b9-999c-cffbf0e11e0e", "Input_Events_Filter", Relay_In_82)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_82.In(logic_uScriptAct_OnInputEventFilter_KeyCode_82);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_82.KeyDown;
         bool test_1 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_82.KeyHeld;
         bool test_2 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_82.KeyUp;
         
         if ( test_0 == true )
         {
            Relay_True_79();
         }
         if ( test_1 == true )
         {
            Relay_In_116();
         }
         if ( test_2 == true )
         {
            Relay_In_83();
            Relay_False_79();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_83()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("39a75de6-97f2-4165-b4a4-d8451cde541f", "Set_Float", Relay_In_83)) return; 
         {
            {
               logic_uScriptAct_SetFloat_Value_83 = local_111_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_SetFloat_uScriptAct_SetFloat_83.In(logic_uScriptAct_SetFloat_Value_83, out logic_uScriptAct_SetFloat_Target_83);
         local_Bot_Speed_System_Single = logic_uScriptAct_SetFloat_Target_83;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetFloat_uScriptAct_SetFloat_83.Out;
         
         if ( test_0 == true )
         {
            Relay_In_127();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Set Float.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_84()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("567dc6ee-c131-4727-86d8-718c7fdcd483", "Input_Events_Filter", Relay_In_84)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_84.In(logic_uScriptAct_OnInputEventFilter_KeyCode_84);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_84.KeyUp;
         
         if ( test_0 == true )
         {
            Relay_In_130();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_87()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6e67463a-2cb0-4dc9-8f55-316b045886e3", "Set_Components__Vector3_", Relay_In_87)) return; 
         {
            {
               logic_uScriptAct_SetComponentsVector3_X_87 = local_139_System_Single;
               
            }
            {
               logic_uScriptAct_SetComponentsVector3_Y_87 = local_Camera_Distance_System_Single;
               
            }
            {
               logic_uScriptAct_SetComponentsVector3_Z_87 = local_44_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_87.In(logic_uScriptAct_SetComponentsVector3_X_87, logic_uScriptAct_SetComponentsVector3_Y_87, logic_uScriptAct_SetComponentsVector3_Z_87, out logic_uScriptAct_SetComponentsVector3_OutputVector3_87);
         local_144_UnityEngine_Vector3 = logic_uScriptAct_SetComponentsVector3_OutputVector3_87;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetComponentsVector3_uScriptAct_SetComponentsVector3_87.Out;
         
         if ( test_0 == true )
         {
            Relay_In_74();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Set Components (Vector3).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_88()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7004c7c3-4361-47ff-8d06-20f232f5e207", "Add_Int", Relay_In_88)) return; 
         {
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_95_System_Int32);
               logic_uScriptAct_AddInt_A_88 = properties.ToArray();
            }
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_Points_System_Int32);
               logic_uScriptAct_AddInt_B_88 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddInt_uScriptAct_AddInt_88.In(logic_uScriptAct_AddInt_A_88, logic_uScriptAct_AddInt_B_88, out logic_uScriptAct_AddInt_IntResult_88, out logic_uScriptAct_AddInt_FloatResult_88);
         local_Points_System_Int32 = logic_uScriptAct_AddInt_IntResult_88;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Add Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_FinishedSpawning_91()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("40613a47-4145-4372-a7d0-e9ce246c8140", "Spawn_Prefab", Relay_FinishedSpawning_91)) return; 
         Relay_In_146();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Spawn Prefab.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_91()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("40613a47-4145-4372-a7d0-e9ce246c8140", "Spawn_Prefab", Relay_In_91)) return; 
         {
            {
            }
            {
            }
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_120_UnityEngine_GameObject_previous != local_120_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_120_UnityEngine_GameObject_previous = local_120_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_SpawnPrefab_SpawnPoint_91 = local_120_UnityEngine_GameObject;
               
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
         logic_uScriptAct_SpawnPrefab_uScriptAct_SpawnPrefab_91.In(logic_uScriptAct_SpawnPrefab_PrefabName_91, logic_uScriptAct_SpawnPrefab_ResourcePath_91, logic_uScriptAct_SpawnPrefab_SpawnPoint_91, logic_uScriptAct_SpawnPrefab_SpawnedName_91, logic_uScriptAct_SpawnPrefab_LocationOffset_91, out logic_uScriptAct_SpawnPrefab_SpawnedGameObject_91, out logic_uScriptAct_SpawnPrefab_SpawnedInstancedID_91);
         local_151_UnityEngine_GameObject = logic_uScriptAct_SpawnPrefab_SpawnedGameObject_91;
         {
            //if our game object reference was changed then we need to reset event listeners
            if ( local_151_UnityEngine_GameObject_previous != local_151_UnityEngine_GameObject || false == m_RegisteredForEvents )
            {
               //tear down old listeners
               
               local_151_UnityEngine_GameObject_previous = local_151_UnityEngine_GameObject;
               
               //setup new listeners
            }
         }
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Spawn Prefab.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_99()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2bacbc57-cf89-447b-8df7-870ad8d46a21", "Compare_Int", Relay_In_99)) return; 
         {
            {
               logic_uScriptCon_CompareInt_A_99 = local_150_System_Int32;
               
            }
            {
               logic_uScriptCon_CompareInt_B_99 = local_123_System_Int32;
               
            }
         }
         logic_uScriptCon_CompareInt_uScriptCon_CompareInt_99.In(logic_uScriptCon_CompareInt_A_99, logic_uScriptCon_CompareInt_B_99);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareInt_uScriptCon_CompareInt_99.LessThanOrEqualTo;
         
         if ( test_0 == true )
         {
            Relay_In_26();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Compare Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_102()
   {
      if (true == CheckDebugBreak("cf41d302-6b82-4348-8b1d-40ebe8589a6f", "Input_Events", Relay_KeyEvent_102)) return; 
      Relay_In_82();
      Relay_In_106();
   }
   
   void Relay_In_106()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8dd9663d-af4a-4077-920a-c2d66f94ae8b", "Input_Events_Filter", Relay_In_106)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_106.In(logic_uScriptAct_OnInputEventFilter_KeyCode_106);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_106.KeyDown;
         bool test_1 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_106.KeyHeld;
         bool test_2 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_106.KeyUp;
         
         if ( test_0 == true )
         {
            Relay_True_79();
         }
         if ( test_1 == true )
         {
            Relay_In_116();
         }
         if ( test_2 == true )
         {
            Relay_In_83();
            Relay_False_79();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_107()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("cf756f52-a2fd-4e3e-9419-a0649c26a85d", "Print_Text", Relay_ShowLabel_107)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_107.ShowLabel(logic_uScriptAct_PrintText_Text_107, logic_uScriptAct_PrintText_FontSize_107, logic_uScriptAct_PrintText_FontStyle_107, logic_uScriptAct_PrintText_FontColor_107, logic_uScriptAct_PrintText_textAnchor_107, logic_uScriptAct_PrintText_EdgePadding_107, logic_uScriptAct_PrintText_time_107);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_107()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("cf756f52-a2fd-4e3e-9419-a0649c26a85d", "Print_Text", Relay_HideLabel_107)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_107.HideLabel(logic_uScriptAct_PrintText_Text_107, logic_uScriptAct_PrintText_FontSize_107, logic_uScriptAct_PrintText_FontStyle_107, logic_uScriptAct_PrintText_FontColor_107, logic_uScriptAct_PrintText_textAnchor_107, logic_uScriptAct_PrintText_EdgePadding_107, logic_uScriptAct_PrintText_time_107);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_108()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ee99ef2d-e369-412f-a576-c33a472b7aac", "Concatenate", Relay_In_108)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_Points_System_Int32);
               logic_uScriptAct_Concatenate_B_108 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_Concatenate_uScriptAct_Concatenate_108.In(logic_uScriptAct_Concatenate_A_108, logic_uScriptAct_Concatenate_B_108, logic_uScriptAct_Concatenate_Separator_108, out logic_uScriptAct_Concatenate_Result_108);
         local_Points_String_System_String = logic_uScriptAct_Concatenate_Result_108;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Concatenate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_113()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9c5dd928-7e08-46f5-96bd-a8187df5e142", "Print_Text", Relay_ShowLabel_113)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_113.ShowLabel(logic_uScriptAct_PrintText_Text_113, logic_uScriptAct_PrintText_FontSize_113, logic_uScriptAct_PrintText_FontStyle_113, logic_uScriptAct_PrintText_FontColor_113, logic_uScriptAct_PrintText_textAnchor_113, logic_uScriptAct_PrintText_EdgePadding_113, logic_uScriptAct_PrintText_time_113);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_113()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9c5dd928-7e08-46f5-96bd-a8187df5e142", "Print_Text", Relay_HideLabel_113)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_113.HideLabel(logic_uScriptAct_PrintText_Text_113, logic_uScriptAct_PrintText_FontSize_113, logic_uScriptAct_PrintText_FontStyle_113, logic_uScriptAct_PrintText_FontColor_113, logic_uScriptAct_PrintText_textAnchor_113, logic_uScriptAct_PrintText_EdgePadding_113, logic_uScriptAct_PrintText_time_113);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_114()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("84e22d37-5d41-429d-99db-8e5379c8ea5a", "Compare_Int", Relay_In_114)) return; 
         {
            {
               logic_uScriptCon_CompareInt_A_114 = local_Seconds_Left_System_Int32;
               
            }
            {
               logic_uScriptCon_CompareInt_B_114 = local_59_System_Int32;
               
            }
         }
         logic_uScriptCon_CompareInt_uScriptCon_CompareInt_114.In(logic_uScriptCon_CompareInt_A_114, logic_uScriptCon_CompareInt_B_114);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareInt_uScriptCon_CompareInt_114.GreaterThan;
         bool test_1 = logic_uScriptCon_CompareInt_uScriptCon_CompareInt_114.EqualTo;
         
         if ( test_0 == true )
         {
            Relay_In_64();
         }
         if ( test_1 == true )
         {
            Relay_In_8();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Compare Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_116()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e3c9b6e5-fd9d-4775-a82f-4485e75b0e21", "Set_Float", Relay_In_116)) return; 
         {
            {
               logic_uScriptAct_SetFloat_Value_116 = local_34_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_SetFloat_uScriptAct_SetFloat_116.In(logic_uScriptAct_SetFloat_Value_116, out logic_uScriptAct_SetFloat_Target_116);
         local_Bot_Speed_System_Single = logic_uScriptAct_SetFloat_Target_116;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetFloat_uScriptAct_SetFloat_116.Out;
         
         if ( test_0 == true )
         {
            Relay_In_24();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Set Float.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_118()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d8030323-a5ec-463a-a631-511c79a6512f", "Convert_Variable", Relay_In_118)) return; 
         {
            {
               logic_uScriptAct_ConvertVariable_Target_118 = local_Seconds_Left_System_Int32;
               
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
         logic_uScriptAct_ConvertVariable_uScriptAct_ConvertVariable_118.In(logic_uScriptAct_ConvertVariable_Target_118, out logic_uScriptAct_ConvertVariable_IntValue_118, out logic_uScriptAct_ConvertVariable_Int64Value_118, out logic_uScriptAct_ConvertVariable_FloatValue_118, out logic_uScriptAct_ConvertVariable_StringValue_118, out logic_uScriptAct_ConvertVariable_BooleanValue_118, out logic_uScriptAct_ConvertVariable_Vector3Value_118, logic_uScriptAct_ConvertVariable_FloatGroupSeparator_118);
         local_148_System_String = logic_uScriptAct_ConvertVariable_StringValue_118;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Convert Variable.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_121()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("89dfcd1b-5707-471e-868e-82c8c7872372", "Set_Bool", Relay_True_121)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_121.True(out logic_uScriptAct_SetBool_Target_121);
         local_ForwardMotion_System_Boolean = logic_uScriptAct_SetBool_Target_121;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_121()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("89dfcd1b-5707-471e-868e-82c8c7872372", "Set_Bool", Relay_False_121)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_121.False(out logic_uScriptAct_SetBool_Target_121);
         local_ForwardMotion_System_Boolean = logic_uScriptAct_SetBool_Target_121;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_122()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("71274d0c-b615-4d81-8f11-ec908704df99", "Input_Events_Filter", Relay_In_122)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_122.In(logic_uScriptAct_OnInputEventFilter_KeyCode_122);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_122.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_RotateRight_41();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_125()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("810f9d8b-a466-4fff-959c-88f1d93816b3", "Scale_Vector3", Relay_In_125)) return; 
         {
            {
               logic_uScriptAct_ScaleVector3_v_125 = local_131_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_ScaleVector3_s_125 = local_93_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_ScaleVector3_uScriptAct_ScaleVector3_125.In(logic_uScriptAct_ScaleVector3_v_125, logic_uScriptAct_ScaleVector3_s_125, out logic_uScriptAct_ScaleVector3_result_125);
         local_131_UnityEngine_Vector3 = logic_uScriptAct_ScaleVector3_result_125;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_ScaleVector3_uScriptAct_ScaleVector3_125.Out;
         
         if ( test_0 == true )
         {
            Relay_In_76();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Scale Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_127()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0bf30e6c-95b5-4d8f-a2e2-14f1abcf77ae", "Set_Float", Relay_In_127)) return; 
         {
            {
               logic_uScriptAct_SetFloat_Value_127 = local_37_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_SetFloat_uScriptAct_SetFloat_127.In(logic_uScriptAct_SetFloat_Value_127, out logic_uScriptAct_SetFloat_Target_127);
         BotSpeedPerSecond = logic_uScriptAct_SetFloat_Target_127;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Set Float.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_128()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("691f598d-60a8-4c82-8df5-d4a85ee8f734", "Compare_Bool", Relay_In_128)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_128 = local_Game_In_Progress__System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_128.In(logic_uScriptCon_CompareBool_Bool_128);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_128.True;
         bool test_1 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_128.False;
         
         if ( test_0 == true )
         {
            Relay_ShowLabel_17();
            Relay_ShowLabel_20();
         }
         if ( test_1 == true )
         {
            Relay_HideLabel_20();
            Relay_HideLabel_17();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnCustomEventBool_129()
   {
      if (true == CheckDebugBreak("8d0f5e44-c7dc-4d1e-b366-0118a9287d9a", "Custom_Event__Bool_", Relay_OnCustomEventBool_129)) return; 
      local_101_System_String = event_UnityEngine_GameObject_EventName_129;
      Relay_In_4();
   }
   
   void Relay_In_130()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9bfe47cb-9358-4da3-ba09-cdcbb571cb67", "Compare_Bool", Relay_In_130)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_130 = local_Game_In_Progress__System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_130.In(logic_uScriptCon_CompareBool_Bool_130);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_130.False;
         
         if ( test_0 == true )
         {
            Relay_True_73();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_132()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4cda301b-5a19-4578-baa4-7ba58fd004e9", "Compare_Bool", Relay_In_132)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_132 = local_ForwardMotion_System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_132.In(logic_uScriptCon_CompareBool_Bool_132);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_132.True;
         bool test_1 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_132.False;
         
         if ( test_0 == true )
         {
            Relay_In_125();
         }
         if ( test_1 == true )
         {
            Relay_In_13();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_133()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6eb04751-39d9-49f2-88e1-e0e2e1554a59", "Print_Text", Relay_ShowLabel_133)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_133.ShowLabel(logic_uScriptAct_PrintText_Text_133, logic_uScriptAct_PrintText_FontSize_133, logic_uScriptAct_PrintText_FontStyle_133, logic_uScriptAct_PrintText_FontColor_133, logic_uScriptAct_PrintText_textAnchor_133, logic_uScriptAct_PrintText_EdgePadding_133, logic_uScriptAct_PrintText_time_133);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_133()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6eb04751-39d9-49f2-88e1-e0e2e1554a59", "Print_Text", Relay_HideLabel_133)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_133.HideLabel(logic_uScriptAct_PrintText_Text_133, logic_uScriptAct_PrintText_FontSize_133, logic_uScriptAct_PrintText_FontStyle_133, logic_uScriptAct_PrintText_FontColor_133, logic_uScriptAct_PrintText_textAnchor_133, logic_uScriptAct_PrintText_EdgePadding_133, logic_uScriptAct_PrintText_time_133);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnCustomEventBool_134()
   {
      if (true == CheckDebugBreak("6a2b70b1-5139-4d65-a431-2b949337660a", "Custom_Event__Bool_", Relay_OnCustomEventBool_134)) return; 
      local_112_System_String = event_UnityEngine_GameObject_EventName_134;
      Relay_In_60();
   }
   
   void Relay_In_135()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("bea06374-0bb6-4339-a4c7-194ce1d1fe4e", "Input_Events_Filter", Relay_In_135)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_135.In(logic_uScriptAct_OnInputEventFilter_KeyCode_135);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_135.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_RotateRight_41();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_136()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5ecd2e77-83f3-4ea8-8ac7-7501749f2a9c", "Get_Components__Vector3_", Relay_In_136)) return; 
         {
            {
               logic_uScriptAct_GetComponentsVector3_InputVector3_136 = local_30_UnityEngine_Vector3;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_GetComponentsVector3_uScriptAct_GetComponentsVector3_136.In(logic_uScriptAct_GetComponentsVector3_InputVector3_136, out logic_uScriptAct_GetComponentsVector3_X_136, out logic_uScriptAct_GetComponentsVector3_Y_136, out logic_uScriptAct_GetComponentsVector3_Z_136);
         local_139_System_Single = logic_uScriptAct_GetComponentsVector3_X_136;
         local_61_System_Single = logic_uScriptAct_GetComponentsVector3_Y_136;
         local_115_System_Single = logic_uScriptAct_GetComponentsVector3_Z_136;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetComponentsVector3_uScriptAct_GetComponentsVector3_136.Out;
         
         if ( test_0 == true )
         {
            Relay_In_65();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Get Components (Vector3).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_137()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("15606cb3-61b4-4937-8ea5-475fb49e03aa", "Add_Int", Relay_In_137)) return; 
         {
            {
            }
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_150_System_Int32);
               logic_uScriptAct_AddInt_B_137 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddInt_uScriptAct_AddInt_137.In(logic_uScriptAct_AddInt_A_137, logic_uScriptAct_AddInt_B_137, out logic_uScriptAct_AddInt_IntResult_137, out logic_uScriptAct_AddInt_FloatResult_137);
         local_150_System_Int32 = logic_uScriptAct_AddInt_IntResult_137;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddInt_uScriptAct_AddInt_137.Out;
         
         if ( test_0 == true )
         {
            Relay_In_99();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Add Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnUpdate_138()
   {
      if (true == CheckDebugBreak("eac2b572-0f24-4191-b891-9e5ab9fbd71e", "Global_Update", Relay_OnUpdate_138)) return; 
      Relay_In_118();
      Relay_In_108();
   }
   
   void Relay_OnLateUpdate_138()
   {
      if (true == CheckDebugBreak("eac2b572-0f24-4191-b891-9e5ab9fbd71e", "Global_Update", Relay_OnLateUpdate_138)) return; 
      Relay_In_128();
   }
   
   void Relay_OnFixedUpdate_138()
   {
      if (true == CheckDebugBreak("eac2b572-0f24-4191-b891-9e5ab9fbd71e", "Global_Update", Relay_OnFixedUpdate_138)) return; 
   }
   
   void Relay_FinishedSpawning_140()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("dc3c0cc4-8779-4c54-9cd5-73df50ed1cbc", "Spawn_Prefab_At_Location", Relay_FinishedSpawning_140)) return; 
         Relay_In_55();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Spawn Prefab At Location.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_140()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("dc3c0cc4-8779-4c54-9cd5-73df50ed1cbc", "Spawn_Prefab_At_Location", Relay_In_140)) return; 
         {
            {
               logic_uScriptAct_SpawnPrefabAtLocation_PrefabName_140 = local_40_System_String;
               
            }
            {
            }
            {
               logic_uScriptAct_SpawnPrefabAtLocation_SpawnPosition_140 = local_141_UnityEngine_Vector3;
               
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
         logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_140.In(logic_uScriptAct_SpawnPrefabAtLocation_PrefabName_140, logic_uScriptAct_SpawnPrefabAtLocation_ResourcePath_140, logic_uScriptAct_SpawnPrefabAtLocation_SpawnPosition_140, logic_uScriptAct_SpawnPrefabAtLocation_SpawnRotation_140, logic_uScriptAct_SpawnPrefabAtLocation_SpawnedName_140, out logic_uScriptAct_SpawnPrefabAtLocation_SpawnedGameObject_140, out logic_uScriptAct_SpawnPrefabAtLocation_SpawnedInstancedID_140);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Spawn Prefab At Location.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_142()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("198aee7a-ab19-4ae1-a287-48b5470dd2ac", "Print_Text", Relay_ShowLabel_142)) return; 
         {
            {
               logic_uScriptAct_PrintText_Text_142 = local_98_System_String;
               
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_142.ShowLabel(logic_uScriptAct_PrintText_Text_142, logic_uScriptAct_PrintText_FontSize_142, logic_uScriptAct_PrintText_FontStyle_142, logic_uScriptAct_PrintText_FontColor_142, logic_uScriptAct_PrintText_textAnchor_142, logic_uScriptAct_PrintText_EdgePadding_142, logic_uScriptAct_PrintText_time_142);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_142()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("198aee7a-ab19-4ae1-a287-48b5470dd2ac", "Print_Text", Relay_HideLabel_142)) return; 
         {
            {
               logic_uScriptAct_PrintText_Text_142 = local_98_System_String;
               
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_142.HideLabel(logic_uScriptAct_PrintText_Text_142, logic_uScriptAct_PrintText_FontSize_142, logic_uScriptAct_PrintText_FontStyle_142, logic_uScriptAct_PrintText_FontColor_142, logic_uScriptAct_PrintText_textAnchor_142, logic_uScriptAct_PrintText_EdgePadding_142, logic_uScriptAct_PrintText_time_142);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_146()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f1fffcf2-d57b-4cd8-ada0-d6628c5a3199", "Scale_Vector3", Relay_In_146)) return; 
         {
            {
               logic_uScriptAct_ScaleVector3_v_146 = property_forward_Detox_ScriptEditor_Parameter_forward_77_Get_Refresh( );
               
            }
            {
               logic_uScriptAct_ScaleVector3_s_146 = local_Bot_Speed_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_ScaleVector3_uScriptAct_ScaleVector3_146.In(logic_uScriptAct_ScaleVector3_v_146, logic_uScriptAct_ScaleVector3_s_146, out logic_uScriptAct_ScaleVector3_result_146);
         local_131_UnityEngine_Vector3 = logic_uScriptAct_ScaleVector3_result_146;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_ScaleVector3_uScriptAct_ScaleVector3_146.Out;
         
         if ( test_0 == true )
         {
            Relay_In_132();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Scale Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnCustomEventInt_149()
   {
      if (true == CheckDebugBreak("65fdfda6-efd0-4524-9301-3cf9838f950a", "Custom_Event__Int_", Relay_OnCustomEventInt_149)) return; 
      local_33_System_String = event_UnityEngine_GameObject_EventName_149;
      local_95_System_Int32 = event_UnityEngine_GameObject_EventData_149;
      Relay_In_12();
   }
   
   void Relay_In_153()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("26bf3970-a10b-44d6-a4b5-145cdfccadbd", "Input_Events_Filter", Relay_In_153)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_153.In(logic_uScriptAct_OnInputEventFilter_KeyCode_153);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_153.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_RotateLeft_41();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FireBot_Gameplay.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnEnterTrigger_155()
   {
      if (true == CheckDebugBreak("64a9305f-8396-4f19-bc60-bce48c5f8208", "Trigger_Event", Relay_OnEnterTrigger_155)) return; 
      local_66_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_155;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_66_UnityEngine_GameObject_previous != local_66_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_66_UnityEngine_GameObject_previous = local_66_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
      Relay_In_31();
   }
   
   void Relay_OnExitTrigger_155()
   {
      if (true == CheckDebugBreak("64a9305f-8396-4f19-bc60-bce48c5f8208", "Trigger_Event", Relay_OnExitTrigger_155)) return; 
      local_66_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_155;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_66_UnityEngine_GameObject_previous != local_66_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_66_UnityEngine_GameObject_previous = local_66_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
   }
   
   void Relay_WhileInsideTrigger_155()
   {
      if (true == CheckDebugBreak("64a9305f-8396-4f19-bc60-bce48c5f8208", "Trigger_Event", Relay_WhileInsideTrigger_155)) return; 
      local_66_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_155;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_66_UnityEngine_GameObject_previous != local_66_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_66_UnityEngine_GameObject_previous = local_66_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:1", local_1_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "cc5eddfd-0dbb-4f02-8761-5506603dac66", local_1_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:3", local_3_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "fc29408b-2f87-472c-a400-99f1dddbaadd", local_3_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:9", local_9_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a2e2f283-4e5e-4654-a87e-240f063a3cce", local_9_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:11", local_11_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "81a0dcc5-cd8f-4797-93e6-6d0da1a43eb3", local_11_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:Turbo Mode?", local_Turbo_Mode__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "e196d91a-1824-4945-abe6-89a59e2eed3b", local_Turbo_Mode__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:30", local_30_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "3ed86f2d-9458-41a3-86a9-eab255c7e4d3", local_30_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:33", local_33_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "63333cd5-7b82-4dad-b935-e7d5c470ecc4", local_33_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:34", local_34_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "cf6b96d2-1b92-448f-bcac-891c0c403ae0", local_34_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:35", local_35_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "27cd82bf-e82f-41c6-a67c-1d1a091dde5f", local_35_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:37", local_37_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "77913ebf-f4f0-4fa1-bb55-dbabbaefe821", local_37_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:40", local_40_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "bdd59dd4-188b-4659-b58a-d5f0dcc7fc0b", local_40_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:Seconds Left", local_Seconds_Left_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "1fb4bf2e-480e-4371-96cf-1d3b4c5ff342", local_Seconds_Left_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:44", local_44_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "8faa16ed-b5ec-4fcf-a0d2-0c1157f31810", local_44_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:45", local_45_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b05e7858-4a53-47e3-bee7-325f46832b4e", local_45_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:ForwardMotion", local_ForwardMotion_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "fd35c2fd-544c-4286-908a-7363d4ae8822", local_ForwardMotion_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:Bot Speed", local_Bot_Speed_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "8218274a-b92b-4035-bc1f-770ef2a71ce3", local_Bot_Speed_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:59", local_59_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "8bb6b9cc-f873-410c-b49d-616b4d6b8a06", local_59_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:61", local_61_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "20a627f0-266b-4e26-91c8-56b3a8a1074a", local_61_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:66", local_66_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "177f8c8b-dabc-4e8d-93bc-a1aac6cf675f", local_66_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:68", local_68_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ca023ac0-91b4-4852-81cb-cf937a20317f", local_68_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:BotTurnPerSecond", BotTurnPerSecond);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "fe219691-dd97-4cd6-83f2-7222f22f06f7", BotTurnPerSecond);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:75", local_75_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7bb2d924-a997-40e2-a09f-2dc0104ff74b", local_75_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:80", local_80_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "00492ee7-41fd-4184-97c5-b983c0acb209", local_80_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:Camera Distance", local_Camera_Distance_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "37afeb78-5da4-4925-b36c-0d501b923116", local_Camera_Distance_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:92", local_92_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b90dbfb7-7f1b-4243-a912-69a4f5dc1f3e", local_92_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:93", local_93_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7fda24ec-ec3e-45cb-9fd9-1cdec5836f10", local_93_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:94", local_94_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "3d9ea08a-fab9-426f-9920-1c69c2319b51", local_94_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:95", local_95_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "edf6d3f6-c8ff-4852-aff6-024e111c7162", local_95_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:98", local_98_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "587c23d5-7ce6-43b5-95d6-8a2a5d6c434d", local_98_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:BotSpeedPerSecond", BotSpeedPerSecond);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f56bdd3e-f11f-4da4-88e1-317f95bf474b", BotSpeedPerSecond);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:101", local_101_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "5f73e6fe-b421-486c-bade-b099ee37285a", local_101_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:103", local_103_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "8ccc1756-d034-44cc-ae2f-5e1dfcaf759d", local_103_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:Player", local_Player_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "2122a10e-245c-4402-9993-66061defc3b8", local_Player_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:Points String", local_Points_String_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "df0aa8f5-aebe-48b9-ba9a-a9bcf98b4444", local_Points_String_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:111", local_111_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c11fc376-a51a-4282-a04c-513977382189", local_111_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:112", local_112_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "2f793e9f-2ce0-4316-9cb2-fa1230778718", local_112_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:115", local_115_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "334f28d3-29b9-4313-b4a2-21fae54c9063", local_115_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:117", local_117_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a2c65a2e-79bf-4197-a2ed-f36aea0e4062", local_117_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:119", local_119_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "cf4d6f91-73b2-4e6c-8472-380e3d950d1d", local_119_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:120", local_120_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a8d64a84-9aac-4305-9f53-31a2780db6da", local_120_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:123", local_123_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7079522f-03ae-47d4-b630-d5382fb2b177", local_123_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:131", local_131_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "8d807e7f-08dc-4438-96c1-223248d8d4a0", local_131_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:139", local_139_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a203bb9e-2bb7-455b-aa80-5ae413337315", local_139_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:141", local_141_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b9918ae2-ac79-4734-9a77-037ef24ea42f", local_141_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:Points", local_Points_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "82b17d26-f5d9-4bbe-a326-b388bd5f7428", local_Points_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:144", local_144_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "80c45852-914d-4c01-a090-3e8cf19e2692", local_144_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:Game In Progress?", local_Game_In_Progress__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c9ddb864-6e71-422e-b8be-2e84cf9fd139", local_Game_In_Progress__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:148", local_148_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "8a86dc34-b989-4b42-a9a1-6687a12f69eb", local_148_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:150", local_150_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c90214c5-fdfb-4e0e-ae9f-2272906ec48c", local_150_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:151", local_151_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "903830b5-437c-4cca-97d1-a683e91b3552", local_151_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FireBot_Gameplay.uscript:152", local_152_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "e32ec0d7-3705-4f02-b338-d8e2dcd2e51b", local_152_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "27741908-f05c-48d8-8bb1-66759fff7627", property_forward_Detox_ScriptEditor_Parameter_forward_77);
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
