//uScript Generated Code - Build 1.0.2830
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class Doors_MainGraph : uScriptLogic
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
   UnityEngine.Vector3 local_10_UnityEngine_Vector3 = new Vector3( (float)-1.25, (float)0, (float)0 );
   System.Single local_11_System_Single = (float) 2;
   System.Single local_13_System_Single = (float) 3;
   UnityEngine.GameObject local_16_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_16_UnityEngine_GameObject_previous = null;
   System.String local_28_System_String = "";
   UnityEngine.Vector3 local_3_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 local_31_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.GameObject local_33_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_33_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_37_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_37_UnityEngine_GameObject_previous = null;
   UnityEngine.Vector3 local_4_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.GameObject local_41_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_41_UnityEngine_GameObject_previous = null;
   System.Single local_47_System_Single = (float) 3;
   UnityEngine.Vector3 local_48_UnityEngine_Vector3 = new Vector3( (float)-2.75, (float)0, (float)0 );
   UnityEngine.GameObject local_56_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_56_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_59_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_59_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_6_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_6_UnityEngine_GameObject_previous = null;
   System.String local_60_System_String = "HasKeyValue";
   UnityEngine.Vector3 local_63_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 local_65_UnityEngine_Vector3 = new Vector3( (float)2.75, (float)0, (float)0 );
   UnityEngine.GameObject local_66_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_66_UnityEngine_GameObject_previous = null;
   System.Single local_70_System_Single = (float) 1;
   System.Single local_72_System_Single = (float) 2;
   System.Single local_73_System_Single = (float) 1;
   UnityEngine.Vector3 local_77_UnityEngine_Vector3 = new Vector3( (float)1.25, (float)0, (float)0 );
   System.String local_9_System_String = "HasKeyQuery";
   System.Boolean local_Door1_Open__System_Boolean = (bool) false;
   System.Boolean local_Door2_Open__System_Boolean = (bool) false;
   System.Boolean local_Door3_Open__System_Boolean = (bool) false;
   System.Boolean local_Has_Key_System_Boolean = (bool) false;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_MoveToLocation logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_1 = new uScriptAct_MoveToLocation( );
   UnityEngine.GameObject[] logic_uScriptAct_MoveToLocation_targetArray_1 = new UnityEngine.GameObject[] {};
   UnityEngine.Vector3 logic_uScriptAct_MoveToLocation_location_1 = new Vector3( );
   System.Boolean logic_uScriptAct_MoveToLocation_asOffset_1 = (bool) false;
   System.Single logic_uScriptAct_MoveToLocation_totalTime_1 = (float) 0;
   bool logic_uScriptAct_MoveToLocation_Out_1 = true;
   bool logic_uScriptAct_MoveToLocation_Cancelled_1 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_2 = new uScriptAct_Delay( );
   System.Single logic_uScriptAct_Delay_Duration_2 = (float) 0;
   System.Boolean logic_uScriptAct_Delay_SingleFrame_2 = (bool) false;
   bool logic_uScriptAct_Delay_Immediate_2 = true;
   bool logic_uScriptAct_Delay_AfterDelay_2 = true;
   bool logic_uScriptAct_Delay_Stopped_2 = true;
   bool logic_uScriptAct_Delay_DrivenDelay_2 = false;
   //pointer to script instanced logic node
   uScriptAct_AddVector3 logic_uScriptAct_AddVector3_uScriptAct_AddVector3_5 = new uScriptAct_AddVector3( );
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_A_5 = new Vector3[] {};
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_B_5 = new Vector3[] {};
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_Result_5;
   bool logic_uScriptAct_AddVector3_Out_5 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_7 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_7 = "Key: 1";
   System.Int32 logic_uScriptAct_PrintText_FontSize_7 = (int) 32;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_7 = UnityEngine.FontStyle.Bold;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_7 = new UnityEngine.Color( (float)1, (float)0.5803922, (float)0, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_7 = UnityEngine.TextAnchor.UpperRight;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_7 = (int) 32;
   System.Single logic_uScriptAct_PrintText_time_7 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_7 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_8 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_8;
   bool logic_uScriptAct_SetBool_Out_8 = true;
   bool logic_uScriptAct_SetBool_SetTrue_8 = true;
   bool logic_uScriptAct_SetBool_SetFalse_8 = true;
   //pointer to script instanced logic node
   uScriptAct_InterpolateVector3LinearSmooth logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_12 = new uScriptAct_InterpolateVector3LinearSmooth( );
   UnityEngine.Vector3 logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_12 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_InterpolateVector3LinearSmooth_endValue_12 = new Vector3( );
   System.Single logic_uScriptAct_InterpolateVector3LinearSmooth_time_12 = (float) 0;
   uScript_Lerper.LoopType logic_uScriptAct_InterpolateVector3LinearSmooth_loopType_12 = uScript_Lerper.LoopType.None;
   System.Single logic_uScriptAct_InterpolateVector3LinearSmooth_loopDelay_12 = (float) 0;
   System.Boolean logic_uScriptAct_InterpolateVector3LinearSmooth_smooth_12 = (bool) false;
   System.Int32 logic_uScriptAct_InterpolateVector3LinearSmooth_loopCount_12 = (int) 0;
   UnityEngine.Vector3 logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_12;
   bool logic_uScriptAct_InterpolateVector3LinearSmooth_Started_12 = true;
   bool logic_uScriptAct_InterpolateVector3LinearSmooth_Stopped_12 = true;
   bool logic_uScriptAct_InterpolateVector3LinearSmooth_Interpolating_12 = true;
   bool logic_uScriptAct_InterpolateVector3LinearSmooth_Finished_12 = true;
   bool logic_uScriptAct_InterpolateVector3LinearSmooth_Driven_12 = false;
   //pointer to script instanced logic node
   uScriptAct_PlayAnimation logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_14 = new uScriptAct_PlayAnimation( );
   UnityEngine.GameObject[] logic_uScriptAct_PlayAnimation_Target_14 = new UnityEngine.GameObject[] {};
   System.String logic_uScriptAct_PlayAnimation_Animation_14 = "Door2OpenAnim";
   System.Single logic_uScriptAct_PlayAnimation_SpeedFactor_14 = (float) -1;
   UnityEngine.WrapMode logic_uScriptAct_PlayAnimation_AnimWrapMode_14 = UnityEngine.WrapMode.Once;
   System.Boolean logic_uScriptAct_PlayAnimation_StopOtherAnimations_14 = (bool) true;
   bool logic_uScriptAct_PlayAnimation_Out_14 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_18 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_18;
   bool logic_uScriptAct_SetBool_Out_18 = true;
   bool logic_uScriptAct_SetBool_SetTrue_18 = true;
   bool logic_uScriptAct_SetBool_SetFalse_18 = true;
   //pointer to script instanced logic node
   uScriptAct_Destroy logic_uScriptAct_Destroy_uScriptAct_Destroy_23 = new uScriptAct_Destroy( );
   UnityEngine.GameObject[] logic_uScriptAct_Destroy_Target_23 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_Destroy_DelayTime_23 = (float) 0;
   bool logic_uScriptAct_Destroy_Out_23 = true;
   bool logic_uScriptAct_Destroy_ObjectsDestroyed_23 = true;
   bool logic_uScriptAct_Destroy_WaitOneTick_23 = false;
   //pointer to script instanced logic node
   uScriptAct_InterpolateVector3LinearSmooth logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_24 = new uScriptAct_InterpolateVector3LinearSmooth( );
   UnityEngine.Vector3 logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_24 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_InterpolateVector3LinearSmooth_endValue_24 = new Vector3( );
   System.Single logic_uScriptAct_InterpolateVector3LinearSmooth_time_24 = (float) 0;
   uScript_Lerper.LoopType logic_uScriptAct_InterpolateVector3LinearSmooth_loopType_24 = uScript_Lerper.LoopType.None;
   System.Single logic_uScriptAct_InterpolateVector3LinearSmooth_loopDelay_24 = (float) 0;
   System.Boolean logic_uScriptAct_InterpolateVector3LinearSmooth_smooth_24 = (bool) false;
   System.Int32 logic_uScriptAct_InterpolateVector3LinearSmooth_loopCount_24 = (int) 0;
   UnityEngine.Vector3 logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_24;
   bool logic_uScriptAct_InterpolateVector3LinearSmooth_Started_24 = true;
   bool logic_uScriptAct_InterpolateVector3LinearSmooth_Stopped_24 = true;
   bool logic_uScriptAct_InterpolateVector3LinearSmooth_Interpolating_24 = true;
   bool logic_uScriptAct_InterpolateVector3LinearSmooth_Finished_24 = true;
   bool logic_uScriptAct_InterpolateVector3LinearSmooth_Driven_24 = false;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_25 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_25 = "Key: 0";
   System.Int32 logic_uScriptAct_PrintText_FontSize_25 = (int) 32;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_25 = UnityEngine.FontStyle.Bold;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_25 = new UnityEngine.Color( (float)1, (float)0.5803922, (float)0, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_25 = UnityEngine.TextAnchor.UpperRight;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_25 = (int) 32;
   System.Single logic_uScriptAct_PrintText_time_25 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_25 = true;
   //pointer to script instanced logic node
   uScriptAct_SendCustomEventBool logic_uScriptAct_SendCustomEventBool_uScriptAct_SendCustomEventBool_27 = new uScriptAct_SendCustomEventBool( );
   System.String logic_uScriptAct_SendCustomEventBool_EventName_27 = "";
   System.Boolean logic_uScriptAct_SendCustomEventBool_EventValue_27 = (bool) false;
   uScriptCustomEvent.SendGroup logic_uScriptAct_SendCustomEventBool_sendGroup_27 = uScriptCustomEvent.SendGroup.All;
   UnityEngine.GameObject logic_uScriptAct_SendCustomEventBool_EventSender_27 = default(UnityEngine.GameObject);
   bool logic_uScriptAct_SendCustomEventBool_Out_27 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_30 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_30;
   bool logic_uScriptAct_SetBool_Out_30 = true;
   bool logic_uScriptAct_SetBool_SetTrue_30 = true;
   bool logic_uScriptAct_SetBool_SetFalse_30 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector3 logic_uScriptAct_AddVector3_uScriptAct_AddVector3_34 = new uScriptAct_AddVector3( );
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_A_34 = new Vector3[] {};
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_B_34 = new Vector3[] {};
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_Result_34;
   bool logic_uScriptAct_AddVector3_Out_34 = true;
   //pointer to script instanced logic node
   uScriptAct_PlayAnimation logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_35 = new uScriptAct_PlayAnimation( );
   UnityEngine.GameObject[] logic_uScriptAct_PlayAnimation_Target_35 = new UnityEngine.GameObject[] {};
   System.String logic_uScriptAct_PlayAnimation_Animation_35 = "Door2OpenAnim";
   System.Single logic_uScriptAct_PlayAnimation_SpeedFactor_35 = (float) 1;
   UnityEngine.WrapMode logic_uScriptAct_PlayAnimation_AnimWrapMode_35 = UnityEngine.WrapMode.Once;
   System.Boolean logic_uScriptAct_PlayAnimation_StopOtherAnimations_35 = (bool) true;
   bool logic_uScriptAct_PlayAnimation_Out_35 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector3 logic_uScriptAct_AddVector3_uScriptAct_AddVector3_38 = new uScriptAct_AddVector3( );
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_A_38 = new Vector3[] {};
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_B_38 = new Vector3[] {};
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_Result_38;
   bool logic_uScriptAct_AddVector3_Out_38 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_39 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_39 = "";
   System.String logic_uScriptCon_CompareString_B_39 = "";
   bool logic_uScriptCon_CompareString_Same_39 = true;
   bool logic_uScriptCon_CompareString_Different_39 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_40 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_40;
   bool logic_uScriptAct_SetBool_Out_40 = true;
   bool logic_uScriptAct_SetBool_SetTrue_40 = true;
   bool logic_uScriptAct_SetBool_SetFalse_40 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_43 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_43 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_43 = true;
   bool logic_uScriptCon_CompareBool_False_43 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_49 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_49;
   bool logic_uScriptAct_SetBool_Out_49 = true;
   bool logic_uScriptAct_SetBool_SetTrue_49 = true;
   bool logic_uScriptAct_SetBool_SetFalse_49 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_50 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_50 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_50 = true;
   bool logic_uScriptCon_CompareBool_False_50 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector3 logic_uScriptAct_AddVector3_uScriptAct_AddVector3_52 = new uScriptAct_AddVector3( );
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_A_52 = new Vector3[] {};
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_B_52 = new Vector3[] {};
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_Result_52;
   bool logic_uScriptAct_AddVector3_Out_52 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_57 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_57 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_57 = true;
   bool logic_uScriptCon_CompareBool_False_57 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_61 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_61 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_61 = true;
   bool logic_uScriptCon_CompareBool_False_61 = true;
   //pointer to script instanced logic node
   uScriptAct_SetColor logic_uScriptAct_SetColor_uScriptAct_SetColor_67 = new uScriptAct_SetColor( );
   UnityEngine.Color logic_uScriptAct_SetColor_Value_67 = new UnityEngine.Color( (float)0, (float)1, (float)0.03137255, (float)1 );
   UnityEngine.Color logic_uScriptAct_SetColor_TargetColor_67;
   bool logic_uScriptAct_SetColor_Out_67 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_68 = new uScriptAct_Delay( );
   System.Single logic_uScriptAct_Delay_Duration_68 = (float) 0;
   System.Boolean logic_uScriptAct_Delay_SingleFrame_68 = (bool) false;
   bool logic_uScriptAct_Delay_Immediate_68 = true;
   bool logic_uScriptAct_Delay_AfterDelay_68 = true;
   bool logic_uScriptAct_Delay_Stopped_68 = true;
   bool logic_uScriptAct_Delay_DrivenDelay_68 = false;
   //pointer to script instanced logic node
   uScriptAct_MoveToLocation logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_69 = new uScriptAct_MoveToLocation( );
   UnityEngine.GameObject[] logic_uScriptAct_MoveToLocation_targetArray_69 = new UnityEngine.GameObject[] {};
   UnityEngine.Vector3 logic_uScriptAct_MoveToLocation_location_69 = new Vector3( );
   System.Boolean logic_uScriptAct_MoveToLocation_asOffset_69 = (bool) false;
   System.Single logic_uScriptAct_MoveToLocation_totalTime_69 = (float) 0;
   bool logic_uScriptAct_MoveToLocation_Out_69 = true;
   bool logic_uScriptAct_MoveToLocation_Cancelled_69 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_74 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_74 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_74 = true;
   bool logic_uScriptCon_CompareBool_False_74 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_79 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_79;
   bool logic_uScriptAct_SetBool_Out_79 = true;
   bool logic_uScriptAct_SetBool_SetTrue_79 = true;
   bool logic_uScriptAct_SetBool_SetFalse_79 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_29 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_80 = default(UnityEngine.GameObject);
   System.String event_UnityEngine_GameObject_EventName_80 = "";
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_80 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_158 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_161 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_164 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_167 = default(UnityEngine.GameObject);
   
   //property nodes
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_22 = new Vector3( );
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_22 = default(UnityEngine.GameObject);
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_22_previous = null;
   UnityEngine.Color property_color_Detox_ScriptEditor_Parameter_color_26 = UnityEngine.Color.black;
   UnityEngine.GameObject property_color_Detox_ScriptEditor_Parameter_Instance_26 = default(UnityEngine.GameObject);
   UnityEngine.GameObject property_color_Detox_ScriptEditor_Parameter_Instance_26_previous = null;
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_32 = new Vector3( );
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_32 = default(UnityEngine.GameObject);
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_32_previous = null;
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_45 = new Vector3( );
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_45 = default(UnityEngine.GameObject);
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_45_previous = null;
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_53 = new Vector3( );
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_53 = default(UnityEngine.GameObject);
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_53_previous = null;
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_58 = new Vector3( );
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_58 = default(UnityEngine.GameObject);
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_58_previous = null;
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_71 = new Vector3( );
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_71 = default(UnityEngine.GameObject);
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_71_previous = null;
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_75 = new Vector3( );
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_75 = default(UnityEngine.GameObject);
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_75_previous = null;
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_81 = new Vector3( );
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_81 = default(UnityEngine.GameObject);
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_81_previous = null;
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_22_Get_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_22.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         return component.position;
      }
      else
      {
         return new Vector3( );
      }
   }
   
   void property_position_Detox_ScriptEditor_Parameter_position_22_Set_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_22.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         component.position = property_position_Detox_ScriptEditor_Parameter_position_22;
      }
   }
   
   UnityEngine.Color property_color_Detox_ScriptEditor_Parameter_color_26_Get_Refresh( )
   {
      UnityEngine.Light component = property_color_Detox_ScriptEditor_Parameter_Instance_26.GetComponent<UnityEngine.Light>();
      if ( null != component )
      {
         return component.color;
      }
      else
      {
         return UnityEngine.Color.black;
      }
   }
   
   void property_color_Detox_ScriptEditor_Parameter_color_26_Set_Refresh( )
   {
      UnityEngine.Light component = property_color_Detox_ScriptEditor_Parameter_Instance_26.GetComponent<UnityEngine.Light>();
      if ( null != component )
      {
         component.color = property_color_Detox_ScriptEditor_Parameter_color_26;
      }
   }
   
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_32_Get_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_32.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         return component.position;
      }
      else
      {
         return new Vector3( );
      }
   }
   
   void property_position_Detox_ScriptEditor_Parameter_position_32_Set_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_32.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         component.position = property_position_Detox_ScriptEditor_Parameter_position_32;
      }
   }
   
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_45_Get_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_45.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         return component.position;
      }
      else
      {
         return new Vector3( );
      }
   }
   
   void property_position_Detox_ScriptEditor_Parameter_position_45_Set_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_45.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         component.position = property_position_Detox_ScriptEditor_Parameter_position_45;
      }
   }
   
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_53_Get_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_53.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         return component.position;
      }
      else
      {
         return new Vector3( );
      }
   }
   
   void property_position_Detox_ScriptEditor_Parameter_position_53_Set_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_53.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         component.position = property_position_Detox_ScriptEditor_Parameter_position_53;
      }
   }
   
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_58_Get_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_58.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         return component.position;
      }
      else
      {
         return new Vector3( );
      }
   }
   
   void property_position_Detox_ScriptEditor_Parameter_position_58_Set_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_58.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         component.position = property_position_Detox_ScriptEditor_Parameter_position_58;
      }
   }
   
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_71_Get_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_71.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         return component.position;
      }
      else
      {
         return new Vector3( );
      }
   }
   
   void property_position_Detox_ScriptEditor_Parameter_position_71_Set_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_71.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         component.position = property_position_Detox_ScriptEditor_Parameter_position_71;
      }
   }
   
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_75_Get_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_75.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         return component.position;
      }
      else
      {
         return new Vector3( );
      }
   }
   
   void property_position_Detox_ScriptEditor_Parameter_position_75_Set_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_75.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         component.position = property_position_Detox_ScriptEditor_Parameter_position_75;
      }
   }
   
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_81_Get_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_81.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         return component.position;
      }
      else
      {
         return new Vector3( );
      }
   }
   
   void property_position_Detox_ScriptEditor_Parameter_position_81_Set_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_81.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         component.position = property_position_Detox_ScriptEditor_Parameter_position_81;
      }
   }
   
   
   void SyncUnityHooks( )
   {
      if ( null == property_position_Detox_ScriptEditor_Parameter_Instance_22 || false == m_RegisteredForEvents )
      {
         property_position_Detox_ScriptEditor_Parameter_Instance_22 = GameObject.Find( "Door1" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_22_previous != property_position_Detox_ScriptEditor_Parameter_Instance_22 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_22_previous = property_position_Detox_ScriptEditor_Parameter_Instance_22;
         
         //setup new listeners
      }
      if ( null == property_color_Detox_ScriptEditor_Parameter_Instance_26 || false == m_RegisteredForEvents )
      {
         property_color_Detox_ScriptEditor_Parameter_Instance_26 = GameObject.Find( "Door3_Spotlight" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_color_Detox_ScriptEditor_Parameter_Instance_26_previous != property_color_Detox_ScriptEditor_Parameter_Instance_26 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_color_Detox_ScriptEditor_Parameter_Instance_26_previous = property_color_Detox_ScriptEditor_Parameter_Instance_26;
         
         //setup new listeners
      }
      if ( null == property_position_Detox_ScriptEditor_Parameter_Instance_32 || false == m_RegisteredForEvents )
      {
         property_position_Detox_ScriptEditor_Parameter_Instance_32 = GameObject.Find( "Door3_R" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_32_previous != property_position_Detox_ScriptEditor_Parameter_Instance_32 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_32_previous = property_position_Detox_ScriptEditor_Parameter_Instance_32;
         
         //setup new listeners
      }
      if ( null == property_position_Detox_ScriptEditor_Parameter_Instance_45 || false == m_RegisteredForEvents )
      {
         property_position_Detox_ScriptEditor_Parameter_Instance_45 = GameObject.Find( "Door1" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_45_previous != property_position_Detox_ScriptEditor_Parameter_Instance_45 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_45_previous = property_position_Detox_ScriptEditor_Parameter_Instance_45;
         
         //setup new listeners
      }
      if ( null == property_position_Detox_ScriptEditor_Parameter_Instance_53 || false == m_RegisteredForEvents )
      {
         property_position_Detox_ScriptEditor_Parameter_Instance_53 = GameObject.Find( "Door3_L" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_53_previous != property_position_Detox_ScriptEditor_Parameter_Instance_53 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_53_previous = property_position_Detox_ScriptEditor_Parameter_Instance_53;
         
         //setup new listeners
      }
      if ( null == property_position_Detox_ScriptEditor_Parameter_Instance_58 || false == m_RegisteredForEvents )
      {
         property_position_Detox_ScriptEditor_Parameter_Instance_58 = GameObject.Find( "Door3_L" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_58_previous != property_position_Detox_ScriptEditor_Parameter_Instance_58 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_58_previous = property_position_Detox_ScriptEditor_Parameter_Instance_58;
         
         //setup new listeners
      }
      if ( null == property_position_Detox_ScriptEditor_Parameter_Instance_71 || false == m_RegisteredForEvents )
      {
         property_position_Detox_ScriptEditor_Parameter_Instance_71 = GameObject.Find( "Door3_R" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_71_previous != property_position_Detox_ScriptEditor_Parameter_Instance_71 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_71_previous = property_position_Detox_ScriptEditor_Parameter_Instance_71;
         
         //setup new listeners
      }
      if ( null == property_position_Detox_ScriptEditor_Parameter_Instance_75 || false == m_RegisteredForEvents )
      {
         property_position_Detox_ScriptEditor_Parameter_Instance_75 = GameObject.Find( "Door3_R" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_75_previous != property_position_Detox_ScriptEditor_Parameter_Instance_75 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_75_previous = property_position_Detox_ScriptEditor_Parameter_Instance_75;
         
         //setup new listeners
      }
      if ( null == property_position_Detox_ScriptEditor_Parameter_Instance_81 || false == m_RegisteredForEvents )
      {
         property_position_Detox_ScriptEditor_Parameter_Instance_81 = GameObject.Find( "Door3_L" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_81_previous != property_position_Detox_ScriptEditor_Parameter_Instance_81 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_81_previous = property_position_Detox_ScriptEditor_Parameter_Instance_81;
         
         //setup new listeners
      }
      SyncEventListeners( );
      if ( null == local_6_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_6_UnityEngine_GameObject = GameObject.Find( "Key" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_6_UnityEngine_GameObject_previous != local_6_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_6_UnityEngine_GameObject_previous )
         {
            {
               uScript_Trigger component = local_6_UnityEngine_GameObject_previous.GetComponent<uScript_Trigger>();
               if ( null != component )
               {
                  component.OnEnterTrigger -= Instance_OnEnterTrigger_158;
                  component.OnExitTrigger -= Instance_OnExitTrigger_158;
                  component.WhileInsideTrigger -= Instance_WhileInsideTrigger_158;
               }
            }
         }
         
         local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_6_UnityEngine_GameObject )
         {
            {
               uScript_Trigger component = local_6_UnityEngine_GameObject.GetComponent<uScript_Trigger>();
               if ( null == component )
               {
                  component = local_6_UnityEngine_GameObject.AddComponent<uScript_Trigger>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_158;
                  component.OnExitTrigger += Instance_OnExitTrigger_158;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_158;
               }
            }
         }
      }
      if ( null == local_16_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_16_UnityEngine_GameObject = GameObject.Find( "Door1_Trigger" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_16_UnityEngine_GameObject_previous != local_16_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_16_UnityEngine_GameObject_previous )
         {
            {
               uScript_Trigger component = local_16_UnityEngine_GameObject_previous.GetComponent<uScript_Trigger>();
               if ( null != component )
               {
                  component.OnEnterTrigger -= Instance_OnEnterTrigger_164;
                  component.OnExitTrigger -= Instance_OnExitTrigger_164;
                  component.WhileInsideTrigger -= Instance_WhileInsideTrigger_164;
               }
            }
         }
         
         local_16_UnityEngine_GameObject_previous = local_16_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_16_UnityEngine_GameObject )
         {
            {
               uScript_Trigger component = local_16_UnityEngine_GameObject.GetComponent<uScript_Trigger>();
               if ( null == component )
               {
                  component = local_16_UnityEngine_GameObject.AddComponent<uScript_Trigger>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_164;
                  component.OnExitTrigger += Instance_OnExitTrigger_164;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_164;
               }
            }
         }
      }
      if ( null == local_33_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_33_UnityEngine_GameObject = GameObject.Find( "Door1" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_33_UnityEngine_GameObject_previous != local_33_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_33_UnityEngine_GameObject_previous = local_33_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_37_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_37_UnityEngine_GameObject = GameObject.Find( "Door2_Trigger" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_37_UnityEngine_GameObject_previous != local_37_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_37_UnityEngine_GameObject_previous )
         {
            {
               uScript_Trigger component = local_37_UnityEngine_GameObject_previous.GetComponent<uScript_Trigger>();
               if ( null != component )
               {
                  component.OnEnterTrigger -= Instance_OnEnterTrigger_161;
                  component.OnExitTrigger -= Instance_OnExitTrigger_161;
                  component.WhileInsideTrigger -= Instance_WhileInsideTrigger_161;
               }
            }
         }
         
         local_37_UnityEngine_GameObject_previous = local_37_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_37_UnityEngine_GameObject )
         {
            {
               uScript_Trigger component = local_37_UnityEngine_GameObject.GetComponent<uScript_Trigger>();
               if ( null == component )
               {
                  component = local_37_UnityEngine_GameObject.AddComponent<uScript_Trigger>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_161;
                  component.OnExitTrigger += Instance_OnExitTrigger_161;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_161;
               }
            }
         }
      }
      if ( null == local_41_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_41_UnityEngine_GameObject = GameObject.Find( "Door2" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_41_UnityEngine_GameObject_previous != local_41_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_41_UnityEngine_GameObject_previous = local_41_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_56_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_56_UnityEngine_GameObject = GameObject.Find( "Door3_Trigger" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_56_UnityEngine_GameObject_previous != local_56_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_56_UnityEngine_GameObject_previous )
         {
            {
               uScript_Trigger component = local_56_UnityEngine_GameObject_previous.GetComponent<uScript_Trigger>();
               if ( null != component )
               {
                  component.OnEnterTrigger -= Instance_OnEnterTrigger_167;
                  component.OnExitTrigger -= Instance_OnExitTrigger_167;
                  component.WhileInsideTrigger -= Instance_WhileInsideTrigger_167;
               }
            }
         }
         
         local_56_UnityEngine_GameObject_previous = local_56_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_56_UnityEngine_GameObject )
         {
            {
               uScript_Trigger component = local_56_UnityEngine_GameObject.GetComponent<uScript_Trigger>();
               if ( null == component )
               {
                  component = local_56_UnityEngine_GameObject.AddComponent<uScript_Trigger>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_167;
                  component.OnExitTrigger += Instance_OnExitTrigger_167;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_167;
               }
            }
         }
      }
      if ( null == local_59_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_59_UnityEngine_GameObject = GameObject.Find( "Door1" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_59_UnityEngine_GameObject_previous != local_59_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_59_UnityEngine_GameObject_previous = local_59_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_66_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_66_UnityEngine_GameObject = GameObject.Find( "Door2" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_66_UnityEngine_GameObject_previous != local_66_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_66_UnityEngine_GameObject_previous = local_66_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void RegisterForUnityHooks( )
   {
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_22_previous != property_position_Detox_ScriptEditor_Parameter_Instance_22 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_22_previous = property_position_Detox_ScriptEditor_Parameter_Instance_22;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_color_Detox_ScriptEditor_Parameter_Instance_26_previous != property_color_Detox_ScriptEditor_Parameter_Instance_26 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_color_Detox_ScriptEditor_Parameter_Instance_26_previous = property_color_Detox_ScriptEditor_Parameter_Instance_26;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_32_previous != property_position_Detox_ScriptEditor_Parameter_Instance_32 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_32_previous = property_position_Detox_ScriptEditor_Parameter_Instance_32;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_45_previous != property_position_Detox_ScriptEditor_Parameter_Instance_45 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_45_previous = property_position_Detox_ScriptEditor_Parameter_Instance_45;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_53_previous != property_position_Detox_ScriptEditor_Parameter_Instance_53 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_53_previous = property_position_Detox_ScriptEditor_Parameter_Instance_53;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_58_previous != property_position_Detox_ScriptEditor_Parameter_Instance_58 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_58_previous = property_position_Detox_ScriptEditor_Parameter_Instance_58;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_71_previous != property_position_Detox_ScriptEditor_Parameter_Instance_71 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_71_previous = property_position_Detox_ScriptEditor_Parameter_Instance_71;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_75_previous != property_position_Detox_ScriptEditor_Parameter_Instance_75 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_75_previous = property_position_Detox_ScriptEditor_Parameter_Instance_75;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_81_previous != property_position_Detox_ScriptEditor_Parameter_Instance_81 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_81_previous = property_position_Detox_ScriptEditor_Parameter_Instance_81;
         
         //setup new listeners
      }
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_6_UnityEngine_GameObject_previous != local_6_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_6_UnityEngine_GameObject_previous )
         {
            {
               uScript_Trigger component = local_6_UnityEngine_GameObject_previous.GetComponent<uScript_Trigger>();
               if ( null != component )
               {
                  component.OnEnterTrigger -= Instance_OnEnterTrigger_158;
                  component.OnExitTrigger -= Instance_OnExitTrigger_158;
                  component.WhileInsideTrigger -= Instance_WhileInsideTrigger_158;
               }
            }
         }
         
         local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_6_UnityEngine_GameObject )
         {
            {
               uScript_Trigger component = local_6_UnityEngine_GameObject.GetComponent<uScript_Trigger>();
               if ( null == component )
               {
                  component = local_6_UnityEngine_GameObject.AddComponent<uScript_Trigger>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_158;
                  component.OnExitTrigger += Instance_OnExitTrigger_158;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_158;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_16_UnityEngine_GameObject_previous != local_16_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_16_UnityEngine_GameObject_previous )
         {
            {
               uScript_Trigger component = local_16_UnityEngine_GameObject_previous.GetComponent<uScript_Trigger>();
               if ( null != component )
               {
                  component.OnEnterTrigger -= Instance_OnEnterTrigger_164;
                  component.OnExitTrigger -= Instance_OnExitTrigger_164;
                  component.WhileInsideTrigger -= Instance_WhileInsideTrigger_164;
               }
            }
         }
         
         local_16_UnityEngine_GameObject_previous = local_16_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_16_UnityEngine_GameObject )
         {
            {
               uScript_Trigger component = local_16_UnityEngine_GameObject.GetComponent<uScript_Trigger>();
               if ( null == component )
               {
                  component = local_16_UnityEngine_GameObject.AddComponent<uScript_Trigger>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_164;
                  component.OnExitTrigger += Instance_OnExitTrigger_164;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_164;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_33_UnityEngine_GameObject_previous != local_33_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_33_UnityEngine_GameObject_previous = local_33_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_37_UnityEngine_GameObject_previous != local_37_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_37_UnityEngine_GameObject_previous )
         {
            {
               uScript_Trigger component = local_37_UnityEngine_GameObject_previous.GetComponent<uScript_Trigger>();
               if ( null != component )
               {
                  component.OnEnterTrigger -= Instance_OnEnterTrigger_161;
                  component.OnExitTrigger -= Instance_OnExitTrigger_161;
                  component.WhileInsideTrigger -= Instance_WhileInsideTrigger_161;
               }
            }
         }
         
         local_37_UnityEngine_GameObject_previous = local_37_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_37_UnityEngine_GameObject )
         {
            {
               uScript_Trigger component = local_37_UnityEngine_GameObject.GetComponent<uScript_Trigger>();
               if ( null == component )
               {
                  component = local_37_UnityEngine_GameObject.AddComponent<uScript_Trigger>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_161;
                  component.OnExitTrigger += Instance_OnExitTrigger_161;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_161;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_41_UnityEngine_GameObject_previous != local_41_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_41_UnityEngine_GameObject_previous = local_41_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_56_UnityEngine_GameObject_previous != local_56_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_56_UnityEngine_GameObject_previous )
         {
            {
               uScript_Trigger component = local_56_UnityEngine_GameObject_previous.GetComponent<uScript_Trigger>();
               if ( null != component )
               {
                  component.OnEnterTrigger -= Instance_OnEnterTrigger_167;
                  component.OnExitTrigger -= Instance_OnExitTrigger_167;
                  component.WhileInsideTrigger -= Instance_WhileInsideTrigger_167;
               }
            }
         }
         
         local_56_UnityEngine_GameObject_previous = local_56_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_56_UnityEngine_GameObject )
         {
            {
               uScript_Trigger component = local_56_UnityEngine_GameObject.GetComponent<uScript_Trigger>();
               if ( null == component )
               {
                  component = local_56_UnityEngine_GameObject.AddComponent<uScript_Trigger>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_167;
                  component.OnExitTrigger += Instance_OnExitTrigger_167;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_167;
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
      if ( local_66_UnityEngine_GameObject_previous != local_66_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_66_UnityEngine_GameObject_previous = local_66_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void SyncEventListeners( )
   {
      {
         {
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( property_position_Detox_ScriptEditor_Parameter_Instance_22_previous != property_position_Detox_ScriptEditor_Parameter_Instance_22 || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  property_position_Detox_ScriptEditor_Parameter_Instance_22_previous = property_position_Detox_ScriptEditor_Parameter_Instance_22;
                  
                  //setup new listeners
               }
            }
         }
      }
      {
         {
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( property_color_Detox_ScriptEditor_Parameter_Instance_26_previous != property_color_Detox_ScriptEditor_Parameter_Instance_26 || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  property_color_Detox_ScriptEditor_Parameter_Instance_26_previous = property_color_Detox_ScriptEditor_Parameter_Instance_26;
                  
                  //setup new listeners
               }
            }
         }
      }
      {
         {
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( property_position_Detox_ScriptEditor_Parameter_Instance_32_previous != property_position_Detox_ScriptEditor_Parameter_Instance_32 || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  property_position_Detox_ScriptEditor_Parameter_Instance_32_previous = property_position_Detox_ScriptEditor_Parameter_Instance_32;
                  
                  //setup new listeners
               }
            }
         }
      }
      {
         {
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( property_position_Detox_ScriptEditor_Parameter_Instance_45_previous != property_position_Detox_ScriptEditor_Parameter_Instance_45 || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  property_position_Detox_ScriptEditor_Parameter_Instance_45_previous = property_position_Detox_ScriptEditor_Parameter_Instance_45;
                  
                  //setup new listeners
               }
            }
         }
      }
      {
         {
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( property_position_Detox_ScriptEditor_Parameter_Instance_53_previous != property_position_Detox_ScriptEditor_Parameter_Instance_53 || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  property_position_Detox_ScriptEditor_Parameter_Instance_53_previous = property_position_Detox_ScriptEditor_Parameter_Instance_53;
                  
                  //setup new listeners
               }
            }
         }
      }
      {
         {
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( property_position_Detox_ScriptEditor_Parameter_Instance_58_previous != property_position_Detox_ScriptEditor_Parameter_Instance_58 || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  property_position_Detox_ScriptEditor_Parameter_Instance_58_previous = property_position_Detox_ScriptEditor_Parameter_Instance_58;
                  
                  //setup new listeners
               }
            }
         }
      }
      {
         {
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( property_position_Detox_ScriptEditor_Parameter_Instance_71_previous != property_position_Detox_ScriptEditor_Parameter_Instance_71 || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  property_position_Detox_ScriptEditor_Parameter_Instance_71_previous = property_position_Detox_ScriptEditor_Parameter_Instance_71;
                  
                  //setup new listeners
               }
            }
         }
      }
      {
         {
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( property_position_Detox_ScriptEditor_Parameter_Instance_75_previous != property_position_Detox_ScriptEditor_Parameter_Instance_75 || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  property_position_Detox_ScriptEditor_Parameter_Instance_75_previous = property_position_Detox_ScriptEditor_Parameter_Instance_75;
                  
                  //setup new listeners
               }
            }
         }
      }
      {
         {
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( property_position_Detox_ScriptEditor_Parameter_Instance_81_previous != property_position_Detox_ScriptEditor_Parameter_Instance_81 || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  property_position_Detox_ScriptEditor_Parameter_Instance_81_previous = property_position_Detox_ScriptEditor_Parameter_Instance_81;
                  
                  //setup new listeners
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
               uScript_Update component = event_UnityEngine_GameObject_Instance_29.GetComponent<uScript_Update>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_29.AddComponent<uScript_Update>();
               }
               if ( null != component )
               {
                  component.OnUpdate += Instance_OnUpdate_29;
                  component.OnLateUpdate += Instance_OnLateUpdate_29;
                  component.OnFixedUpdate += Instance_OnFixedUpdate_29;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_80 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_80 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_80 )
         {
            {
               uScript_CustomEvent component = event_UnityEngine_GameObject_Instance_80.GetComponent<uScript_CustomEvent>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_80.AddComponent<uScript_CustomEvent>();
               }
               if ( null != component )
               {
                  component.OnCustomEvent += Instance_OnCustomEvent_80;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != local_6_UnityEngine_GameObject )
      {
         {
            uScript_Trigger component = local_6_UnityEngine_GameObject.GetComponent<uScript_Trigger>();
            if ( null != component )
            {
               component.OnEnterTrigger -= Instance_OnEnterTrigger_158;
               component.OnExitTrigger -= Instance_OnExitTrigger_158;
               component.WhileInsideTrigger -= Instance_WhileInsideTrigger_158;
            }
         }
      }
      if ( null != local_16_UnityEngine_GameObject )
      {
         {
            uScript_Trigger component = local_16_UnityEngine_GameObject.GetComponent<uScript_Trigger>();
            if ( null != component )
            {
               component.OnEnterTrigger -= Instance_OnEnterTrigger_164;
               component.OnExitTrigger -= Instance_OnExitTrigger_164;
               component.WhileInsideTrigger -= Instance_WhileInsideTrigger_164;
            }
         }
      }
      if ( null != local_37_UnityEngine_GameObject )
      {
         {
            uScript_Trigger component = local_37_UnityEngine_GameObject.GetComponent<uScript_Trigger>();
            if ( null != component )
            {
               component.OnEnterTrigger -= Instance_OnEnterTrigger_161;
               component.OnExitTrigger -= Instance_OnExitTrigger_161;
               component.WhileInsideTrigger -= Instance_WhileInsideTrigger_161;
            }
         }
      }
      if ( null != local_56_UnityEngine_GameObject )
      {
         {
            uScript_Trigger component = local_56_UnityEngine_GameObject.GetComponent<uScript_Trigger>();
            if ( null != component )
            {
               component.OnEnterTrigger -= Instance_OnEnterTrigger_167;
               component.OnExitTrigger -= Instance_OnExitTrigger_167;
               component.WhileInsideTrigger -= Instance_WhileInsideTrigger_167;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_29 )
      {
         {
            uScript_Update component = event_UnityEngine_GameObject_Instance_29.GetComponent<uScript_Update>();
            if ( null != component )
            {
               component.OnUpdate -= Instance_OnUpdate_29;
               component.OnLateUpdate -= Instance_OnLateUpdate_29;
               component.OnFixedUpdate -= Instance_OnFixedUpdate_29;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_80 )
      {
         {
            uScript_CustomEvent component = event_UnityEngine_GameObject_Instance_80.GetComponent<uScript_CustomEvent>();
            if ( null != component )
            {
               component.OnCustomEvent -= Instance_OnCustomEvent_80;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_1.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_2.SetParent(g);
      logic_uScriptAct_AddVector3_uScriptAct_AddVector3_5.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_7.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_8.SetParent(g);
      logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_12.SetParent(g);
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_14.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_18.SetParent(g);
      logic_uScriptAct_Destroy_uScriptAct_Destroy_23.SetParent(g);
      logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_24.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_25.SetParent(g);
      logic_uScriptAct_SendCustomEventBool_uScriptAct_SendCustomEventBool_27.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_30.SetParent(g);
      logic_uScriptAct_AddVector3_uScriptAct_AddVector3_34.SetParent(g);
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_35.SetParent(g);
      logic_uScriptAct_AddVector3_uScriptAct_AddVector3_38.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_39.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_40.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_43.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_49.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_50.SetParent(g);
      logic_uScriptAct_AddVector3_uScriptAct_AddVector3_52.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_57.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_61.SetParent(g);
      logic_uScriptAct_SetColor_uScriptAct_SetColor_67.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_68.SetParent(g);
      logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_69.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_74.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_79.SetParent(g);
   }
   public void Awake()
   {
      
      logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_1.Finished += uScriptAct_MoveToLocation_Finished_1;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_14.Finished += uScriptAct_PlayAnimation_Finished_14;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_35.Finished += uScriptAct_PlayAnimation_Finished_35;
      logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_69.Finished += uScriptAct_MoveToLocation_Finished_69;
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
      
      logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_1.Update( );
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_14.Update( );
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_35.Update( );
      logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_69.Update( );
      if (true == logic_uScriptAct_Delay_DrivenDelay_2)
      {
         Relay_DrivenDelay_2();
      }
      if (true == logic_uScriptAct_InterpolateVector3LinearSmooth_Driven_12)
      {
         Relay_Driven_12();
      }
      if (true == logic_uScriptAct_Destroy_WaitOneTick_23)
      {
         Relay_WaitOneTick_23();
      }
      if (true == logic_uScriptAct_InterpolateVector3LinearSmooth_Driven_24)
      {
         Relay_Driven_24();
      }
      if (true == logic_uScriptAct_Delay_DrivenDelay_68)
      {
         Relay_DrivenDelay_68();
      }
   }
   
   public void OnDestroy()
   {
      logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_1.Finished -= uScriptAct_MoveToLocation_Finished_1;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_14.Finished -= uScriptAct_PlayAnimation_Finished_14;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_35.Finished -= uScriptAct_PlayAnimation_Finished_35;
      logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_69.Finished -= uScriptAct_MoveToLocation_Finished_69;
   }
   
   public void OnGUI()
   {
      logic_uScriptAct_PrintText_uScriptAct_PrintText_7.OnGUI( );
      logic_uScriptAct_PrintText_uScriptAct_PrintText_25.OnGUI( );
   }
   
   void Instance_OnUpdate_29(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUpdate_29( );
   }
   
   void Instance_OnLateUpdate_29(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnLateUpdate_29( );
   }
   
   void Instance_OnFixedUpdate_29(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnFixedUpdate_29( );
   }
   
   void Instance_OnCustomEvent_80(object o, uScript_CustomEvent.CustomEventBoolArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_80 = e.Sender;
      event_UnityEngine_GameObject_EventName_80 = e.EventName;
      //relay event to nodes
      Relay_OnCustomEvent_80( );
   }
   
   void Instance_OnEnterTrigger_158(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_158 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_158( );
   }
   
   void Instance_OnExitTrigger_158(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_158 = e.GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_158( );
   }
   
   void Instance_WhileInsideTrigger_158(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_158 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_158( );
   }
   
   void Instance_OnEnterTrigger_161(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_161 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_161( );
   }
   
   void Instance_OnExitTrigger_161(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_161 = e.GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_161( );
   }
   
   void Instance_WhileInsideTrigger_161(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_161 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_161( );
   }
   
   void Instance_OnEnterTrigger_164(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_164 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_164( );
   }
   
   void Instance_OnExitTrigger_164(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_164 = e.GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_164( );
   }
   
   void Instance_WhileInsideTrigger_164(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_164 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_164( );
   }
   
   void Instance_OnEnterTrigger_167(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_167 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_167( );
   }
   
   void Instance_OnExitTrigger_167(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_167 = e.GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_167( );
   }
   
   void Instance_WhileInsideTrigger_167(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_167 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_167( );
   }
   
   void uScriptAct_MoveToLocation_Finished_1(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_1( );
   }
   
   void uScriptAct_PlayAnimation_Finished_14(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_14( );
   }
   
   void uScriptAct_PlayAnimation_Finished_35(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_35( );
   }
   
   void uScriptAct_MoveToLocation_Finished_69(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_69( );
   }
   
   void Relay_Finished_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("384da341-4a91-4527-b106-5845e694aea2", "Move_To_Location", Relay_Finished_1)) return; 
         Relay_False_79();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Move To Location.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("384da341-4a91-4527-b106-5845e694aea2", "Move_To_Location", Relay_In_1)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_59_UnityEngine_GameObject_previous != local_59_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_59_UnityEngine_GameObject_previous = local_59_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_59_UnityEngine_GameObject);
               logic_uScriptAct_MoveToLocation_targetArray_1 = properties.ToArray();
            }
            {
               logic_uScriptAct_MoveToLocation_location_1 = local_3_UnityEngine_Vector3;
               
            }
            {
            }
            {
               logic_uScriptAct_MoveToLocation_totalTime_1 = local_73_System_Single;
               
            }
         }
         logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_1.In(logic_uScriptAct_MoveToLocation_targetArray_1, logic_uScriptAct_MoveToLocation_location_1, logic_uScriptAct_MoveToLocation_asOffset_1, logic_uScriptAct_MoveToLocation_totalTime_1);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Move To Location.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Cancel_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("384da341-4a91-4527-b106-5845e694aea2", "Move_To_Location", Relay_Cancel_1)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_59_UnityEngine_GameObject_previous != local_59_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_59_UnityEngine_GameObject_previous = local_59_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_59_UnityEngine_GameObject);
               logic_uScriptAct_MoveToLocation_targetArray_1 = properties.ToArray();
            }
            {
               logic_uScriptAct_MoveToLocation_location_1 = local_3_UnityEngine_Vector3;
               
            }
            {
            }
            {
               logic_uScriptAct_MoveToLocation_totalTime_1 = local_73_System_Single;
               
            }
         }
         logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_1.Cancel(logic_uScriptAct_MoveToLocation_targetArray_1, logic_uScriptAct_MoveToLocation_location_1, logic_uScriptAct_MoveToLocation_asOffset_1, logic_uScriptAct_MoveToLocation_totalTime_1);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Move To Location.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("237f0adb-7207-48cd-b7e4-9f32025ce6d5", "Delay", Relay_In_2)) return; 
         {
            {
               logic_uScriptAct_Delay_Duration_2 = local_47_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_2.In(logic_uScriptAct_Delay_Duration_2, logic_uScriptAct_Delay_SingleFrame_2);
         logic_uScriptAct_Delay_DrivenDelay_2 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_2.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_In_14();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("237f0adb-7207-48cd-b7e4-9f32025ce6d5", "Delay", Relay_Stop_2)) return; 
         {
            {
               logic_uScriptAct_Delay_Duration_2 = local_47_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_2.Stop(logic_uScriptAct_Delay_Duration_2, logic_uScriptAct_Delay_SingleFrame_2);
         logic_uScriptAct_Delay_DrivenDelay_2 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_2.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_In_14();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_DrivenDelay_2( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               logic_uScriptAct_Delay_Duration_2 = local_47_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_Delay_DrivenDelay_2 = logic_uScriptAct_Delay_uScriptAct_Delay_2.DrivenDelay();
         if ( true == logic_uScriptAct_Delay_DrivenDelay_2 )
         {
            if ( logic_uScriptAct_Delay_uScriptAct_Delay_2.AfterDelay == true )
            {
               Relay_In_14();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_In_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ce6ddcbd-a3fb-4e42-ba75-a85abb92e00f", "Add_Vector3", Relay_In_5)) return; 
         {
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)property_position_Detox_ScriptEditor_Parameter_position_45_Get_Refresh());
               logic_uScriptAct_AddVector3_A_5 = properties.ToArray();
            }
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_48_UnityEngine_Vector3);
               logic_uScriptAct_AddVector3_B_5 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_uScriptAct_AddVector3_5.In(logic_uScriptAct_AddVector3_A_5, logic_uScriptAct_AddVector3_B_5, out logic_uScriptAct_AddVector3_Result_5);
         local_4_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_Result_5;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_uScriptAct_AddVector3_5.Out;
         
         if ( test_0 == true )
         {
            Relay_In_69();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9286744b-f05c-4c08-adf6-609df3af749d", "Print_Text", Relay_ShowLabel_7)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_7.ShowLabel(logic_uScriptAct_PrintText_Text_7, logic_uScriptAct_PrintText_FontSize_7, logic_uScriptAct_PrintText_FontStyle_7, logic_uScriptAct_PrintText_FontColor_7, logic_uScriptAct_PrintText_textAnchor_7, logic_uScriptAct_PrintText_EdgePadding_7, logic_uScriptAct_PrintText_time_7);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9286744b-f05c-4c08-adf6-609df3af749d", "Print_Text", Relay_HideLabel_7)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_7.HideLabel(logic_uScriptAct_PrintText_Text_7, logic_uScriptAct_PrintText_FontSize_7, logic_uScriptAct_PrintText_FontStyle_7, logic_uScriptAct_PrintText_FontColor_7, logic_uScriptAct_PrintText_textAnchor_7, logic_uScriptAct_PrintText_EdgePadding_7, logic_uScriptAct_PrintText_time_7);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_8()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9936fe7f-c5b3-42b8-bd45-3f106b5da017", "Set_Bool", Relay_True_8)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_8.True(out logic_uScriptAct_SetBool_Target_8);
         local_Door2_Open__System_Boolean = logic_uScriptAct_SetBool_Target_8;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_8.Out;
         
         if ( test_0 == true )
         {
            Relay_In_35();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_8()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9936fe7f-c5b3-42b8-bd45-3f106b5da017", "Set_Bool", Relay_False_8)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_8.False(out logic_uScriptAct_SetBool_Target_8);
         local_Door2_Open__System_Boolean = logic_uScriptAct_SetBool_Target_8;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_8.Out;
         
         if ( test_0 == true )
         {
            Relay_In_35();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Begin_12()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("69d1d5d5-fff8-4d67-b32a-5d00a4a993db", "Interpolate_Vector3_Linear__Smooth_", Relay_Begin_12)) return; 
         {
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_12 = property_position_Detox_ScriptEditor_Parameter_position_71_Get_Refresh( );
               
            }
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_endValue_12 = local_31_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_time_12 = local_72_System_Single;
               
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
         logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_12.Begin(logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_12, logic_uScriptAct_InterpolateVector3LinearSmooth_endValue_12, logic_uScriptAct_InterpolateVector3LinearSmooth_time_12, logic_uScriptAct_InterpolateVector3LinearSmooth_loopType_12, logic_uScriptAct_InterpolateVector3LinearSmooth_loopDelay_12, logic_uScriptAct_InterpolateVector3LinearSmooth_smooth_12, logic_uScriptAct_InterpolateVector3LinearSmooth_loopCount_12, out logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_12);
         logic_uScriptAct_InterpolateVector3LinearSmooth_Driven_12 = true;
         property_position_Detox_ScriptEditor_Parameter_position_32 = logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_12;
         property_position_Detox_ScriptEditor_Parameter_position_32_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Interpolate Vector3 Linear (Smooth).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_12()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("69d1d5d5-fff8-4d67-b32a-5d00a4a993db", "Interpolate_Vector3_Linear__Smooth_", Relay_Stop_12)) return; 
         {
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_12 = property_position_Detox_ScriptEditor_Parameter_position_71_Get_Refresh( );
               
            }
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_endValue_12 = local_31_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_time_12 = local_72_System_Single;
               
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
         logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_12.Stop(logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_12, logic_uScriptAct_InterpolateVector3LinearSmooth_endValue_12, logic_uScriptAct_InterpolateVector3LinearSmooth_time_12, logic_uScriptAct_InterpolateVector3LinearSmooth_loopType_12, logic_uScriptAct_InterpolateVector3LinearSmooth_loopDelay_12, logic_uScriptAct_InterpolateVector3LinearSmooth_smooth_12, logic_uScriptAct_InterpolateVector3LinearSmooth_loopCount_12, out logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_12);
         logic_uScriptAct_InterpolateVector3LinearSmooth_Driven_12 = true;
         property_position_Detox_ScriptEditor_Parameter_position_32 = logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_12;
         property_position_Detox_ScriptEditor_Parameter_position_32_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Interpolate Vector3 Linear (Smooth).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Resume_12()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("69d1d5d5-fff8-4d67-b32a-5d00a4a993db", "Interpolate_Vector3_Linear__Smooth_", Relay_Resume_12)) return; 
         {
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_12 = property_position_Detox_ScriptEditor_Parameter_position_71_Get_Refresh( );
               
            }
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_endValue_12 = local_31_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_time_12 = local_72_System_Single;
               
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
         logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_12.Resume(logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_12, logic_uScriptAct_InterpolateVector3LinearSmooth_endValue_12, logic_uScriptAct_InterpolateVector3LinearSmooth_time_12, logic_uScriptAct_InterpolateVector3LinearSmooth_loopType_12, logic_uScriptAct_InterpolateVector3LinearSmooth_loopDelay_12, logic_uScriptAct_InterpolateVector3LinearSmooth_smooth_12, logic_uScriptAct_InterpolateVector3LinearSmooth_loopCount_12, out logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_12);
         logic_uScriptAct_InterpolateVector3LinearSmooth_Driven_12 = true;
         property_position_Detox_ScriptEditor_Parameter_position_32 = logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_12;
         property_position_Detox_ScriptEditor_Parameter_position_32_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Interpolate Vector3 Linear (Smooth).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Driven_12( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_12 = property_position_Detox_ScriptEditor_Parameter_position_71_Get_Refresh( );
               
            }
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_endValue_12 = local_31_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_time_12 = local_72_System_Single;
               
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
         logic_uScriptAct_InterpolateVector3LinearSmooth_Driven_12 = logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_12.Driven(out logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_12);
         if ( true == logic_uScriptAct_InterpolateVector3LinearSmooth_Driven_12 )
         {
            property_position_Detox_ScriptEditor_Parameter_position_32 = logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_12;
            property_position_Detox_ScriptEditor_Parameter_position_32_Set_Refresh( );
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Interpolate Vector3 Linear (Smooth).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_Finished_14()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2c58a3da-20be-4c4c-aa5e-4d73de68f83d", "Play_Animation", Relay_Finished_14)) return; 
         Relay_False_49();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_14()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2c58a3da-20be-4c4c-aa5e-4d73de68f83d", "Play_Animation", Relay_In_14)) return; 
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
               logic_uScriptAct_PlayAnimation_Target_14 = properties.ToArray();
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
         logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_14.In(logic_uScriptAct_PlayAnimation_Target_14, logic_uScriptAct_PlayAnimation_Animation_14, logic_uScriptAct_PlayAnimation_SpeedFactor_14, logic_uScriptAct_PlayAnimation_AnimWrapMode_14, logic_uScriptAct_PlayAnimation_StopOtherAnimations_14);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_18()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("92221b11-5f5d-4c65-a5c1-2fe2565f5593", "Set_Bool", Relay_True_18)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_18.True(out logic_uScriptAct_SetBool_Target_18);
         local_Door3_Open__System_Boolean = logic_uScriptAct_SetBool_Target_18;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_18.Out;
         
         if ( test_0 == true )
         {
            Relay_In_67();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_18()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("92221b11-5f5d-4c65-a5c1-2fe2565f5593", "Set_Bool", Relay_False_18)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_18.False(out logic_uScriptAct_SetBool_Target_18);
         local_Door3_Open__System_Boolean = logic_uScriptAct_SetBool_Target_18;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_18.Out;
         
         if ( test_0 == true )
         {
            Relay_In_67();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_23()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a37920ac-a636-4c20-a607-f048478063b0", "Destroy", Relay_In_23)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_6_UnityEngine_GameObject_previous != local_6_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     if ( null != local_6_UnityEngine_GameObject_previous )
                     {
                        {
                           uScript_Trigger component = local_6_UnityEngine_GameObject_previous.GetComponent<uScript_Trigger>();
                           if ( null != component )
                           {
                              component.OnEnterTrigger -= Instance_OnEnterTrigger_158;
                              component.OnExitTrigger -= Instance_OnExitTrigger_158;
                              component.WhileInsideTrigger -= Instance_WhileInsideTrigger_158;
                           }
                        }
                     }
                     
                     local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
                     
                     //setup new listeners
                     if ( null != local_6_UnityEngine_GameObject )
                     {
                        {
                           uScript_Trigger component = local_6_UnityEngine_GameObject.GetComponent<uScript_Trigger>();
                           if ( null == component )
                           {
                              component = local_6_UnityEngine_GameObject.AddComponent<uScript_Trigger>();
                           }
                           if ( null != component )
                           {
                              component.OnEnterTrigger += Instance_OnEnterTrigger_158;
                              component.OnExitTrigger += Instance_OnExitTrigger_158;
                              component.WhileInsideTrigger += Instance_WhileInsideTrigger_158;
                           }
                        }
                     }
                  }
               }
               properties.Add((UnityEngine.GameObject)local_6_UnityEngine_GameObject);
               logic_uScriptAct_Destroy_Target_23 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Destroy_uScriptAct_Destroy_23.In(logic_uScriptAct_Destroy_Target_23, logic_uScriptAct_Destroy_DelayTime_23);
         logic_uScriptAct_Destroy_WaitOneTick_23 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Destroy.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_WaitOneTick_23( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_6_UnityEngine_GameObject_previous != local_6_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     if ( null != local_6_UnityEngine_GameObject_previous )
                     {
                        {
                           uScript_Trigger component = local_6_UnityEngine_GameObject_previous.GetComponent<uScript_Trigger>();
                           if ( null != component )
                           {
                              component.OnEnterTrigger -= Instance_OnEnterTrigger_158;
                              component.OnExitTrigger -= Instance_OnExitTrigger_158;
                              component.WhileInsideTrigger -= Instance_WhileInsideTrigger_158;
                           }
                        }
                     }
                     
                     local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
                     
                     //setup new listeners
                     if ( null != local_6_UnityEngine_GameObject )
                     {
                        {
                           uScript_Trigger component = local_6_UnityEngine_GameObject.GetComponent<uScript_Trigger>();
                           if ( null == component )
                           {
                              component = local_6_UnityEngine_GameObject.AddComponent<uScript_Trigger>();
                           }
                           if ( null != component )
                           {
                              component.OnEnterTrigger += Instance_OnEnterTrigger_158;
                              component.OnExitTrigger += Instance_OnExitTrigger_158;
                              component.WhileInsideTrigger += Instance_WhileInsideTrigger_158;
                           }
                        }
                     }
                  }
               }
               properties.Add((UnityEngine.GameObject)local_6_UnityEngine_GameObject);
               logic_uScriptAct_Destroy_Target_23 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Destroy_WaitOneTick_23 = logic_uScriptAct_Destroy_uScriptAct_Destroy_23.WaitOneTick();
         if ( true == logic_uScriptAct_Destroy_WaitOneTick_23 )
         {
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Destroy.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_Begin_24()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("af14b845-79f6-476a-b811-19247ec5ddb0", "Interpolate_Vector3_Linear__Smooth_", Relay_Begin_24)) return; 
         {
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_24 = property_position_Detox_ScriptEditor_Parameter_position_81_Get_Refresh( );
               
            }
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_endValue_24 = local_63_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_time_24 = local_11_System_Single;
               
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
         logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_24.Begin(logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_24, logic_uScriptAct_InterpolateVector3LinearSmooth_endValue_24, logic_uScriptAct_InterpolateVector3LinearSmooth_time_24, logic_uScriptAct_InterpolateVector3LinearSmooth_loopType_24, logic_uScriptAct_InterpolateVector3LinearSmooth_loopDelay_24, logic_uScriptAct_InterpolateVector3LinearSmooth_smooth_24, logic_uScriptAct_InterpolateVector3LinearSmooth_loopCount_24, out logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_24);
         logic_uScriptAct_InterpolateVector3LinearSmooth_Driven_24 = true;
         property_position_Detox_ScriptEditor_Parameter_position_53 = logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_24;
         property_position_Detox_ScriptEditor_Parameter_position_53_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Interpolate Vector3 Linear (Smooth).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_24()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("af14b845-79f6-476a-b811-19247ec5ddb0", "Interpolate_Vector3_Linear__Smooth_", Relay_Stop_24)) return; 
         {
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_24 = property_position_Detox_ScriptEditor_Parameter_position_81_Get_Refresh( );
               
            }
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_endValue_24 = local_63_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_time_24 = local_11_System_Single;
               
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
         logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_24.Stop(logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_24, logic_uScriptAct_InterpolateVector3LinearSmooth_endValue_24, logic_uScriptAct_InterpolateVector3LinearSmooth_time_24, logic_uScriptAct_InterpolateVector3LinearSmooth_loopType_24, logic_uScriptAct_InterpolateVector3LinearSmooth_loopDelay_24, logic_uScriptAct_InterpolateVector3LinearSmooth_smooth_24, logic_uScriptAct_InterpolateVector3LinearSmooth_loopCount_24, out logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_24);
         logic_uScriptAct_InterpolateVector3LinearSmooth_Driven_24 = true;
         property_position_Detox_ScriptEditor_Parameter_position_53 = logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_24;
         property_position_Detox_ScriptEditor_Parameter_position_53_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Interpolate Vector3 Linear (Smooth).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Resume_24()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("af14b845-79f6-476a-b811-19247ec5ddb0", "Interpolate_Vector3_Linear__Smooth_", Relay_Resume_24)) return; 
         {
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_24 = property_position_Detox_ScriptEditor_Parameter_position_81_Get_Refresh( );
               
            }
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_endValue_24 = local_63_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_time_24 = local_11_System_Single;
               
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
         logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_24.Resume(logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_24, logic_uScriptAct_InterpolateVector3LinearSmooth_endValue_24, logic_uScriptAct_InterpolateVector3LinearSmooth_time_24, logic_uScriptAct_InterpolateVector3LinearSmooth_loopType_24, logic_uScriptAct_InterpolateVector3LinearSmooth_loopDelay_24, logic_uScriptAct_InterpolateVector3LinearSmooth_smooth_24, logic_uScriptAct_InterpolateVector3LinearSmooth_loopCount_24, out logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_24);
         logic_uScriptAct_InterpolateVector3LinearSmooth_Driven_24 = true;
         property_position_Detox_ScriptEditor_Parameter_position_53 = logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_24;
         property_position_Detox_ScriptEditor_Parameter_position_53_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Interpolate Vector3 Linear (Smooth).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Driven_24( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_startValue_24 = property_position_Detox_ScriptEditor_Parameter_position_81_Get_Refresh( );
               
            }
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_endValue_24 = local_63_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_InterpolateVector3LinearSmooth_time_24 = local_11_System_Single;
               
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
         logic_uScriptAct_InterpolateVector3LinearSmooth_Driven_24 = logic_uScriptAct_InterpolateVector3LinearSmooth_uScriptAct_InterpolateVector3LinearSmooth_24.Driven(out logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_24);
         if ( true == logic_uScriptAct_InterpolateVector3LinearSmooth_Driven_24 )
         {
            property_position_Detox_ScriptEditor_Parameter_position_53 = logic_uScriptAct_InterpolateVector3LinearSmooth_currentValue_24;
            property_position_Detox_ScriptEditor_Parameter_position_53_Set_Refresh( );
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Interpolate Vector3 Linear (Smooth).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_ShowLabel_25()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6e384f1b-4ac6-406c-bc7d-7e1bfbc0aa9e", "Print_Text", Relay_ShowLabel_25)) return; 
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_25()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6e384f1b-4ac6-406c-bc7d-7e1bfbc0aa9e", "Print_Text", Relay_HideLabel_25)) return; 
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_SendCustomEvent_27()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7e4777bd-8453-49fa-89e9-27ea635bcdd0", "Send_Custom_Event__Bool_", Relay_SendCustomEvent_27)) return; 
         {
            {
               logic_uScriptAct_SendCustomEventBool_EventName_27 = local_60_System_String;
               
            }
            {
               logic_uScriptAct_SendCustomEventBool_EventValue_27 = local_Has_Key_System_Boolean;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SendCustomEventBool_uScriptAct_SendCustomEventBool_27.SendCustomEvent(logic_uScriptAct_SendCustomEventBool_EventName_27, logic_uScriptAct_SendCustomEventBool_EventValue_27, logic_uScriptAct_SendCustomEventBool_sendGroup_27, logic_uScriptAct_SendCustomEventBool_EventSender_27);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Send Custom Event (Bool).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnUpdate_29()
   {
      if (true == CheckDebugBreak("3ccf063a-b800-4289-8b39-e071fb297ecf", "Global_Update", Relay_OnUpdate_29)) return; 
   }
   
   void Relay_OnLateUpdate_29()
   {
      if (true == CheckDebugBreak("3ccf063a-b800-4289-8b39-e071fb297ecf", "Global_Update", Relay_OnLateUpdate_29)) return; 
   }
   
   void Relay_OnFixedUpdate_29()
   {
      if (true == CheckDebugBreak("3ccf063a-b800-4289-8b39-e071fb297ecf", "Global_Update", Relay_OnFixedUpdate_29)) return; 
      Relay_In_43();
   }
   
   void Relay_True_30()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("dd3f8fb0-624f-46c5-8089-6f3cef2c7b8b", "Set_Bool", Relay_True_30)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_30.True(out logic_uScriptAct_SetBool_Target_30);
         local_Has_Key_System_Boolean = logic_uScriptAct_SetBool_Target_30;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_30.Out;
         
         if ( test_0 == true )
         {
            Relay_In_23();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_30()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("dd3f8fb0-624f-46c5-8089-6f3cef2c7b8b", "Set_Bool", Relay_False_30)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_30.False(out logic_uScriptAct_SetBool_Target_30);
         local_Has_Key_System_Boolean = logic_uScriptAct_SetBool_Target_30;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_30.Out;
         
         if ( test_0 == true )
         {
            Relay_In_23();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_34()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ae512a97-6917-4ab9-87ad-bb5727a6f774", "Add_Vector3", Relay_In_34)) return; 
         {
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)property_position_Detox_ScriptEditor_Parameter_position_58_Get_Refresh());
               logic_uScriptAct_AddVector3_A_34 = properties.ToArray();
            }
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_10_UnityEngine_Vector3);
               logic_uScriptAct_AddVector3_B_34 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_uScriptAct_AddVector3_34.In(logic_uScriptAct_AddVector3_A_34, logic_uScriptAct_AddVector3_B_34, out logic_uScriptAct_AddVector3_Result_34);
         local_63_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_Result_34;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_uScriptAct_AddVector3_34.Out;
         
         if ( test_0 == true )
         {
            Relay_Begin_24();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_35()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("da40dc5d-9415-43bc-9b03-ecc3cca739a7", "Play_Animation", Relay_Finished_35)) return; 
         Relay_In_2();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_35()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("da40dc5d-9415-43bc-9b03-ecc3cca739a7", "Play_Animation", Relay_In_35)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_41_UnityEngine_GameObject_previous != local_41_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_41_UnityEngine_GameObject_previous = local_41_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_41_UnityEngine_GameObject);
               logic_uScriptAct_PlayAnimation_Target_35 = properties.ToArray();
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
         logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_35.In(logic_uScriptAct_PlayAnimation_Target_35, logic_uScriptAct_PlayAnimation_Animation_35, logic_uScriptAct_PlayAnimation_SpeedFactor_35, logic_uScriptAct_PlayAnimation_AnimWrapMode_35, logic_uScriptAct_PlayAnimation_StopOtherAnimations_35);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_38()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8cc0a5ea-0dba-4f69-8c3d-e10b9a141ede", "Add_Vector3", Relay_In_38)) return; 
         {
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)property_position_Detox_ScriptEditor_Parameter_position_22_Get_Refresh());
               logic_uScriptAct_AddVector3_A_38 = properties.ToArray();
            }
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_65_UnityEngine_Vector3);
               logic_uScriptAct_AddVector3_B_38 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_uScriptAct_AddVector3_38.In(logic_uScriptAct_AddVector3_A_38, logic_uScriptAct_AddVector3_B_38, out logic_uScriptAct_AddVector3_Result_38);
         local_3_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_Result_38;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_uScriptAct_AddVector3_38.Out;
         
         if ( test_0 == true )
         {
            Relay_In_1();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_39()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("64ffff61-5294-4a16-adf7-16138a39f264", "Compare_String", Relay_In_39)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_39 = local_28_System_String;
               
            }
            {
               logic_uScriptCon_CompareString_B_39 = local_9_System_String;
               
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_39.In(logic_uScriptCon_CompareString_A_39, logic_uScriptCon_CompareString_B_39);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_39.Same;
         
         if ( test_0 == true )
         {
            Relay_SendCustomEvent_27();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_40()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("68d8153a-787d-4adf-9893-32f629ba6aef", "Set_Bool", Relay_True_40)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_40.True(out logic_uScriptAct_SetBool_Target_40);
         local_Door1_Open__System_Boolean = logic_uScriptAct_SetBool_Target_40;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_40.Out;
         
         if ( test_0 == true )
         {
            Relay_In_5();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_40()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("68d8153a-787d-4adf-9893-32f629ba6aef", "Set_Bool", Relay_False_40)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_40.False(out logic_uScriptAct_SetBool_Target_40);
         local_Door1_Open__System_Boolean = logic_uScriptAct_SetBool_Target_40;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_40.Out;
         
         if ( test_0 == true )
         {
            Relay_In_5();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_43()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("af90b800-73ec-4229-955f-4f81833a4602", "Compare_Bool", Relay_In_43)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_43 = local_Has_Key_System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_43.In(logic_uScriptCon_CompareBool_Bool_43);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_43.True;
         bool test_1 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_43.False;
         
         if ( test_0 == true )
         {
            Relay_HideLabel_25();
            Relay_ShowLabel_7();
         }
         if ( test_1 == true )
         {
            Relay_HideLabel_7();
            Relay_ShowLabel_25();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_49()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("28a9f34b-26f0-45c4-9bd9-2a14ee537202", "Set_Bool", Relay_True_49)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_49.True(out logic_uScriptAct_SetBool_Target_49);
         local_Door2_Open__System_Boolean = logic_uScriptAct_SetBool_Target_49;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_49()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("28a9f34b-26f0-45c4-9bd9-2a14ee537202", "Set_Bool", Relay_False_49)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_49.False(out logic_uScriptAct_SetBool_Target_49);
         local_Door2_Open__System_Boolean = logic_uScriptAct_SetBool_Target_49;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_50()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("267c6992-8358-4302-9be3-501293f06295", "Compare_Bool", Relay_In_50)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_50 = local_Door2_Open__System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_50.In(logic_uScriptCon_CompareBool_Bool_50);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_50.False;
         
         if ( test_0 == true )
         {
            Relay_True_8();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_52()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("986204f6-2143-41b9-83e1-c0f292a8934b", "Add_Vector3", Relay_In_52)) return; 
         {
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)property_position_Detox_ScriptEditor_Parameter_position_75_Get_Refresh());
               logic_uScriptAct_AddVector3_A_52 = properties.ToArray();
            }
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_77_UnityEngine_Vector3);
               logic_uScriptAct_AddVector3_B_52 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_uScriptAct_AddVector3_52.In(logic_uScriptAct_AddVector3_A_52, logic_uScriptAct_AddVector3_B_52, out logic_uScriptAct_AddVector3_Result_52);
         local_31_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_Result_52;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_uScriptAct_AddVector3_52.Out;
         
         if ( test_0 == true )
         {
            Relay_Begin_12();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_57()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e7887f30-b0c2-44df-a613-e5a6765bfb40", "Compare_Bool", Relay_In_57)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_57 = local_Door1_Open__System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_57.In(logic_uScriptCon_CompareBool_Bool_57);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_57.False;
         
         if ( test_0 == true )
         {
            Relay_True_40();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_61()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("05a0be28-3ce9-4ab5-828c-54d6a216e1b3", "Compare_Bool", Relay_In_61)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_61 = local_Has_Key_System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_61.In(logic_uScriptCon_CompareBool_Bool_61);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_61.True;
         
         if ( test_0 == true )
         {
            Relay_In_74();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_67()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6dd82d6c-c2dd-4b6d-8be1-781c4360bf30", "Set_Color", Relay_In_67)) return; 
         {
            {
            }
            {
            }
         }
         logic_uScriptAct_SetColor_uScriptAct_SetColor_67.In(logic_uScriptAct_SetColor_Value_67, out logic_uScriptAct_SetColor_TargetColor_67);
         property_color_Detox_ScriptEditor_Parameter_color_26 = logic_uScriptAct_SetColor_TargetColor_67;
         property_color_Detox_ScriptEditor_Parameter_color_26_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetColor_uScriptAct_SetColor_67.Out;
         
         if ( test_0 == true )
         {
            Relay_In_34();
            Relay_In_52();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Color.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_68()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c5f04559-5697-4bdb-b519-fb2556359cdb", "Delay", Relay_In_68)) return; 
         {
            {
               logic_uScriptAct_Delay_Duration_68 = local_13_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_68.In(logic_uScriptAct_Delay_Duration_68, logic_uScriptAct_Delay_SingleFrame_68);
         logic_uScriptAct_Delay_DrivenDelay_68 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_68.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_In_38();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_68()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c5f04559-5697-4bdb-b519-fb2556359cdb", "Delay", Relay_Stop_68)) return; 
         {
            {
               logic_uScriptAct_Delay_Duration_68 = local_13_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_68.Stop(logic_uScriptAct_Delay_Duration_68, logic_uScriptAct_Delay_SingleFrame_68);
         logic_uScriptAct_Delay_DrivenDelay_68 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_68.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_In_38();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_DrivenDelay_68( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               logic_uScriptAct_Delay_Duration_68 = local_13_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_Delay_DrivenDelay_68 = logic_uScriptAct_Delay_uScriptAct_Delay_68.DrivenDelay();
         if ( true == logic_uScriptAct_Delay_DrivenDelay_68 )
         {
            if ( logic_uScriptAct_Delay_uScriptAct_Delay_68.AfterDelay == true )
            {
               Relay_In_38();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_Finished_69()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b64730f3-9ee9-4d97-a644-ad01f0e801dc", "Move_To_Location", Relay_Finished_69)) return; 
         Relay_In_68();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Move To Location.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_69()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b64730f3-9ee9-4d97-a644-ad01f0e801dc", "Move_To_Location", Relay_In_69)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_33_UnityEngine_GameObject_previous != local_33_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_33_UnityEngine_GameObject_previous = local_33_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_33_UnityEngine_GameObject);
               logic_uScriptAct_MoveToLocation_targetArray_69 = properties.ToArray();
            }
            {
               logic_uScriptAct_MoveToLocation_location_69 = local_4_UnityEngine_Vector3;
               
            }
            {
            }
            {
               logic_uScriptAct_MoveToLocation_totalTime_69 = local_70_System_Single;
               
            }
         }
         logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_69.In(logic_uScriptAct_MoveToLocation_targetArray_69, logic_uScriptAct_MoveToLocation_location_69, logic_uScriptAct_MoveToLocation_asOffset_69, logic_uScriptAct_MoveToLocation_totalTime_69);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Move To Location.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Cancel_69()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b64730f3-9ee9-4d97-a644-ad01f0e801dc", "Move_To_Location", Relay_Cancel_69)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_33_UnityEngine_GameObject_previous != local_33_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_33_UnityEngine_GameObject_previous = local_33_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_33_UnityEngine_GameObject);
               logic_uScriptAct_MoveToLocation_targetArray_69 = properties.ToArray();
            }
            {
               logic_uScriptAct_MoveToLocation_location_69 = local_4_UnityEngine_Vector3;
               
            }
            {
            }
            {
               logic_uScriptAct_MoveToLocation_totalTime_69 = local_70_System_Single;
               
            }
         }
         logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_69.Cancel(logic_uScriptAct_MoveToLocation_targetArray_69, logic_uScriptAct_MoveToLocation_location_69, logic_uScriptAct_MoveToLocation_asOffset_69, logic_uScriptAct_MoveToLocation_totalTime_69);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Move To Location.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_74()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("70c79920-e6f9-4497-b101-bee29c15e5e6", "Compare_Bool", Relay_In_74)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_74 = local_Door3_Open__System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_74.In(logic_uScriptCon_CompareBool_Bool_74);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_74.False;
         
         if ( test_0 == true )
         {
            Relay_True_18();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_79()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e4d27f13-84e7-4482-a6e7-4219cadd2135", "Set_Bool", Relay_True_79)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_79.True(out logic_uScriptAct_SetBool_Target_79);
         local_Door1_Open__System_Boolean = logic_uScriptAct_SetBool_Target_79;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_79()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e4d27f13-84e7-4482-a6e7-4219cadd2135", "Set_Bool", Relay_False_79)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_79.False(out logic_uScriptAct_SetBool_Target_79);
         local_Door1_Open__System_Boolean = logic_uScriptAct_SetBool_Target_79;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnCustomEvent_80()
   {
      if (true == CheckDebugBreak("7c353773-7eea-4de6-b7f2-d4acff6754fa", "Custom_Event", Relay_OnCustomEvent_80)) return; 
      local_28_System_String = event_UnityEngine_GameObject_EventName_80;
      Relay_In_39();
   }
   
   void Relay_OnEnterTrigger_158()
   {
      if (true == CheckDebugBreak("d274d28e-e91b-47ed-a007-d05d864fdd57", "Trigger_Event", Relay_OnEnterTrigger_158)) return; 
      Relay_True_30();
   }
   
   void Relay_OnExitTrigger_158()
   {
      if (true == CheckDebugBreak("d274d28e-e91b-47ed-a007-d05d864fdd57", "Trigger_Event", Relay_OnExitTrigger_158)) return; 
   }
   
   void Relay_WhileInsideTrigger_158()
   {
      if (true == CheckDebugBreak("d274d28e-e91b-47ed-a007-d05d864fdd57", "Trigger_Event", Relay_WhileInsideTrigger_158)) return; 
   }
   
   void Relay_OnEnterTrigger_161()
   {
      if (true == CheckDebugBreak("2736c5e4-e0cd-454b-bde6-8a02babc902c", "Trigger_Event", Relay_OnEnterTrigger_161)) return; 
      Relay_In_50();
   }
   
   void Relay_OnExitTrigger_161()
   {
      if (true == CheckDebugBreak("2736c5e4-e0cd-454b-bde6-8a02babc902c", "Trigger_Event", Relay_OnExitTrigger_161)) return; 
   }
   
   void Relay_WhileInsideTrigger_161()
   {
      if (true == CheckDebugBreak("2736c5e4-e0cd-454b-bde6-8a02babc902c", "Trigger_Event", Relay_WhileInsideTrigger_161)) return; 
   }
   
   void Relay_OnEnterTrigger_164()
   {
      if (true == CheckDebugBreak("27e3328c-ef35-4237-b99a-6e9980c32e2f", "Trigger_Event", Relay_OnEnterTrigger_164)) return; 
      Relay_In_57();
   }
   
   void Relay_OnExitTrigger_164()
   {
      if (true == CheckDebugBreak("27e3328c-ef35-4237-b99a-6e9980c32e2f", "Trigger_Event", Relay_OnExitTrigger_164)) return; 
   }
   
   void Relay_WhileInsideTrigger_164()
   {
      if (true == CheckDebugBreak("27e3328c-ef35-4237-b99a-6e9980c32e2f", "Trigger_Event", Relay_WhileInsideTrigger_164)) return; 
   }
   
   void Relay_OnEnterTrigger_167()
   {
      if (true == CheckDebugBreak("ff7230e2-d1ba-4ba7-aad8-b410074ae6de", "Trigger_Event", Relay_OnEnterTrigger_167)) return; 
      Relay_In_61();
   }
   
   void Relay_OnExitTrigger_167()
   {
      if (true == CheckDebugBreak("ff7230e2-d1ba-4ba7-aad8-b410074ae6de", "Trigger_Event", Relay_OnExitTrigger_167)) return; 
   }
   
   void Relay_WhileInsideTrigger_167()
   {
      if (true == CheckDebugBreak("ff7230e2-d1ba-4ba7-aad8-b410074ae6de", "Trigger_Event", Relay_WhileInsideTrigger_167)) return; 
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:3", local_3_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "52990a72-2e5a-4b42-b85e-000a15601a8a", local_3_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:4", local_4_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "e55d89a6-83b9-435c-a58a-c62617ac5321", local_4_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:6", local_6_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "63318a8c-184d-481a-a6b0-a07d27861043", local_6_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:9", local_9_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "68e4bfe2-08cb-44dc-870e-e84bc1a47184", local_9_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:10", local_10_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "976ad023-bacd-418f-86a8-a107515d89d4", local_10_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:11", local_11_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f3d11ba1-bda3-47f3-86a5-70d7cc71bd09", local_11_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:13", local_13_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "365cf50f-3961-4532-a476-58ad302756c6", local_13_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:16", local_16_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "203fda8c-1fc2-4f71-b733-7fb527538e6f", local_16_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:28", local_28_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "fe5acf83-7161-49c4-8077-f48289c24d35", local_28_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:31", local_31_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "aca18670-c8aa-47ad-8929-2f96733498ac", local_31_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:33", local_33_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a091fb03-4149-4899-aad0-7c4d720de37d", local_33_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:37", local_37_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "2c3a04b0-d989-4fa1-a1b0-d3a1e6c547d8", local_37_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:41", local_41_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7f3d5c57-1c28-4ba0-8e0e-8f63c786a246", local_41_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:Door3 Open?", local_Door3_Open__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "5273341d-fac2-464d-a6f4-e7516763909c", local_Door3_Open__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:47", local_47_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "2ce35273-e2c8-4d67-89a1-e4b13a6a2c64", local_47_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:48", local_48_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "eda6602c-b027-41c2-8378-1b469ff098b7", local_48_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:Has Key", local_Has_Key_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a7776564-bc58-4587-b1de-77f563e09eb0", local_Has_Key_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:56", local_56_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b419549b-2d0f-4e57-834e-593936f338a7", local_56_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:59", local_59_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "21cbeb00-b0da-4a75-bd86-6c7032622bc8", local_59_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:60", local_60_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "32135b0b-80fc-43df-a626-60cd0d767314", local_60_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:63", local_63_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d076fe87-3088-4576-9f08-eb2d49f080f5", local_63_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:Door2 Open?", local_Door2_Open__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ec996f89-f41b-4cfb-a0e0-62dd759a821e", local_Door2_Open__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:65", local_65_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ca1353d3-2ed8-4ee1-a1f7-bfd56c71300c", local_65_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:66", local_66_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "af5630c1-c765-4e87-8445-94f98dc2f3a9", local_66_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:70", local_70_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b1073fd0-b85b-4041-b56a-0349eac44672", local_70_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:72", local_72_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "5621150a-66e9-40bb-8c78-14ee44815ffb", local_72_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:73", local_73_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "19ce721b-1c55-4c92-a175-846d1c54bb21", local_73_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:77", local_77_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "4983f4bf-f59e-4350-be28-3cf448dd9f31", local_77_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:Door1 Open?", local_Door1_Open__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7f44a938-631c-467a-9311-171718fe55fc", local_Door1_Open__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "097baa99-2bc2-478b-915b-f7a886da26af", property_position_Detox_ScriptEditor_Parameter_position_22);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a6825d91-b7df-4139-aa7e-2aae9c3b51be", property_color_Detox_ScriptEditor_Parameter_color_26);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b3acae1f-4743-4cf1-940d-40127aeeb29e", property_position_Detox_ScriptEditor_Parameter_position_32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "aacfd7d2-9e52-4823-90da-5bd12c55fbae", property_position_Detox_ScriptEditor_Parameter_position_45);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "1fb07904-084d-4449-8353-4f42a45bd51e", property_position_Detox_ScriptEditor_Parameter_position_53);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "8369cb9b-d275-4c6e-a7cd-c8bfbbcfe3be", property_position_Detox_ScriptEditor_Parameter_position_58);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a4ca1f9d-3f20-44c1-ba9b-2e26d2ab0f48", property_position_Detox_ScriptEditor_Parameter_position_71);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "bb075d3f-a251-4e0d-bfcc-ae5675ec026b", property_position_Detox_ScriptEditor_Parameter_position_75);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ab45b753-0843-4c49-a65b-07c61cad8091", property_position_Detox_ScriptEditor_Parameter_position_81);
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
