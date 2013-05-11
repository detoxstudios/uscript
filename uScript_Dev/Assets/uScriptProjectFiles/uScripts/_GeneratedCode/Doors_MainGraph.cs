//uScript Generated Code - Build 0.9.2275
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
   UnityEngine.Vector3 local_11_UnityEngine_Vector3 = new Vector3( (float)-1.25, (float)0, (float)0 );
   System.Single local_12_System_Single = (float) 2;
   System.Single local_14_System_Single = (float) 3;
   UnityEngine.GameObject local_17_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_17_UnityEngine_GameObject_previous = null;
   System.String local_29_System_String = "";
   UnityEngine.Vector3 local_3_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 local_33_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.GameObject local_36_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_36_UnityEngine_GameObject_previous = null;
   UnityEngine.Vector3 local_4_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.GameObject local_40_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_40_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_44_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_44_UnityEngine_GameObject_previous = null;
   System.Single local_50_System_Single = (float) 3;
   UnityEngine.Vector3 local_51_UnityEngine_Vector3 = new Vector3( (float)-2.75, (float)0, (float)0 );
   UnityEngine.GameObject local_59_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_59_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_6_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_6_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_62_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_62_UnityEngine_GameObject_previous = null;
   System.String local_63_System_String = "HasKeyValue";
   UnityEngine.Vector3 local_67_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 local_69_UnityEngine_Vector3 = new Vector3( (float)2.75, (float)0, (float)0 );
   UnityEngine.GameObject local_70_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_70_UnityEngine_GameObject_previous = null;
   System.Single local_74_System_Single = (float) 1;
   System.Single local_76_System_Single = (float) 2;
   System.Single local_77_System_Single = (float) 1;
   UnityEngine.Vector3 local_81_UnityEngine_Vector3 = new Vector3( (float)1.25, (float)0, (float)0 );
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
   uScriptAct_InterpolateVector3Linear logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_13 = new uScriptAct_InterpolateVector3Linear( );
   UnityEngine.Vector3 logic_uScriptAct_InterpolateVector3Linear_startValue_13 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_InterpolateVector3Linear_endValue_13 = new Vector3( );
   System.Single logic_uScriptAct_InterpolateVector3Linear_time_13 = (float) 0;
   uScript_Lerper.LoopType logic_uScriptAct_InterpolateVector3Linear_loopType_13 = uScript_Lerper.LoopType.None;
   System.Single logic_uScriptAct_InterpolateVector3Linear_loopDelay_13 = (float) 0;
   System.Int32 logic_uScriptAct_InterpolateVector3Linear_loopCount_13 = (int) 0;
   UnityEngine.Vector3 logic_uScriptAct_InterpolateVector3Linear_currentValue_13;
   bool logic_uScriptAct_InterpolateVector3Linear_Started_13 = true;
   bool logic_uScriptAct_InterpolateVector3Linear_Stopped_13 = true;
   bool logic_uScriptAct_InterpolateVector3Linear_Interpolating_13 = true;
   bool logic_uScriptAct_InterpolateVector3Linear_Finished_13 = true;
   bool logic_uScriptAct_InterpolateVector3Linear_Driven_13 = false;
   //pointer to script instanced logic node
   uScriptAct_PlayAnimation logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_15 = new uScriptAct_PlayAnimation( );
   UnityEngine.GameObject[] logic_uScriptAct_PlayAnimation_Target_15 = new UnityEngine.GameObject[] {};
   System.String logic_uScriptAct_PlayAnimation_Animation_15 = "Door2OpenAnim";
   System.Single logic_uScriptAct_PlayAnimation_SpeedFactor_15 = (float) -1;
   UnityEngine.WrapMode logic_uScriptAct_PlayAnimation_AnimWrapMode_15 = UnityEngine.WrapMode.Once;
   System.Boolean logic_uScriptAct_PlayAnimation_StopOtherAnimations_15 = (bool) true;
   bool logic_uScriptAct_PlayAnimation_Out_15 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_19 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_19;
   bool logic_uScriptAct_SetBool_Out_19 = true;
   bool logic_uScriptAct_SetBool_SetTrue_19 = true;
   bool logic_uScriptAct_SetBool_SetFalse_19 = true;
   //pointer to script instanced logic node
   uScriptAct_Destroy logic_uScriptAct_Destroy_uScriptAct_Destroy_24 = new uScriptAct_Destroy( );
   UnityEngine.GameObject[] logic_uScriptAct_Destroy_Target_24 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_Destroy_DelayTime_24 = (float) 0;
   bool logic_uScriptAct_Destroy_Out_24 = true;
   bool logic_uScriptAct_Destroy_ObjectsDestroyed_24 = true;
   bool logic_uScriptAct_Destroy_WaitOneTick_24 = false;
   //pointer to script instanced logic node
   uScriptAct_InterpolateVector3Linear logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_25 = new uScriptAct_InterpolateVector3Linear( );
   UnityEngine.Vector3 logic_uScriptAct_InterpolateVector3Linear_startValue_25 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_InterpolateVector3Linear_endValue_25 = new Vector3( );
   System.Single logic_uScriptAct_InterpolateVector3Linear_time_25 = (float) 0;
   uScript_Lerper.LoopType logic_uScriptAct_InterpolateVector3Linear_loopType_25 = uScript_Lerper.LoopType.None;
   System.Single logic_uScriptAct_InterpolateVector3Linear_loopDelay_25 = (float) 0;
   System.Int32 logic_uScriptAct_InterpolateVector3Linear_loopCount_25 = (int) 0;
   UnityEngine.Vector3 logic_uScriptAct_InterpolateVector3Linear_currentValue_25;
   bool logic_uScriptAct_InterpolateVector3Linear_Started_25 = true;
   bool logic_uScriptAct_InterpolateVector3Linear_Stopped_25 = true;
   bool logic_uScriptAct_InterpolateVector3Linear_Interpolating_25 = true;
   bool logic_uScriptAct_InterpolateVector3Linear_Finished_25 = true;
   bool logic_uScriptAct_InterpolateVector3Linear_Driven_25 = false;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_26 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_26 = "Key: 0";
   System.Int32 logic_uScriptAct_PrintText_FontSize_26 = (int) 32;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_26 = UnityEngine.FontStyle.Bold;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_26 = new UnityEngine.Color( (float)1, (float)0.5803922, (float)0, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_26 = UnityEngine.TextAnchor.UpperRight;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_26 = (int) 32;
   System.Single logic_uScriptAct_PrintText_time_26 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_26 = true;
   //pointer to script instanced logic node
   uScriptAct_SendCustomEventBool logic_uScriptAct_SendCustomEventBool_uScriptAct_SendCustomEventBool_28 = new uScriptAct_SendCustomEventBool( );
   System.String logic_uScriptAct_SendCustomEventBool_EventName_28 = "";
   System.Boolean logic_uScriptAct_SendCustomEventBool_EventValue_28 = (bool) false;
   uScriptCustomEvent.SendGroup logic_uScriptAct_SendCustomEventBool_sendGroup_28 = uScriptCustomEvent.SendGroup.All;
   UnityEngine.GameObject logic_uScriptAct_SendCustomEventBool_EventSender_28 = null;
   bool logic_uScriptAct_SendCustomEventBool_Out_28 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_32 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_32;
   bool logic_uScriptAct_SetBool_Out_32 = true;
   bool logic_uScriptAct_SetBool_SetTrue_32 = true;
   bool logic_uScriptAct_SetBool_SetFalse_32 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector3 logic_uScriptAct_AddVector3_uScriptAct_AddVector3_37 = new uScriptAct_AddVector3( );
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_A_37 = new Vector3[] {};
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_B_37 = new Vector3[] {};
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_Result_37;
   bool logic_uScriptAct_AddVector3_Out_37 = true;
   //pointer to script instanced logic node
   uScriptAct_PlayAnimation logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_38 = new uScriptAct_PlayAnimation( );
   UnityEngine.GameObject[] logic_uScriptAct_PlayAnimation_Target_38 = new UnityEngine.GameObject[] {};
   System.String logic_uScriptAct_PlayAnimation_Animation_38 = "Door2OpenAnim";
   System.Single logic_uScriptAct_PlayAnimation_SpeedFactor_38 = (float) 1;
   UnityEngine.WrapMode logic_uScriptAct_PlayAnimation_AnimWrapMode_38 = UnityEngine.WrapMode.Once;
   System.Boolean logic_uScriptAct_PlayAnimation_StopOtherAnimations_38 = (bool) true;
   bool logic_uScriptAct_PlayAnimation_Out_38 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector3 logic_uScriptAct_AddVector3_uScriptAct_AddVector3_41 = new uScriptAct_AddVector3( );
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_A_41 = new Vector3[] {};
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_B_41 = new Vector3[] {};
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_Result_41;
   bool logic_uScriptAct_AddVector3_Out_41 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_42 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_42 = "";
   System.String logic_uScriptCon_CompareString_B_42 = "";
   bool logic_uScriptCon_CompareString_Same_42 = true;
   bool logic_uScriptCon_CompareString_Different_42 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_43 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_43;
   bool logic_uScriptAct_SetBool_Out_43 = true;
   bool logic_uScriptAct_SetBool_SetTrue_43 = true;
   bool logic_uScriptAct_SetBool_SetFalse_43 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_46 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_46 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_46 = true;
   bool logic_uScriptCon_CompareBool_False_46 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_52 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_52;
   bool logic_uScriptAct_SetBool_Out_52 = true;
   bool logic_uScriptAct_SetBool_SetTrue_52 = true;
   bool logic_uScriptAct_SetBool_SetFalse_52 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_53 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_53 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_53 = true;
   bool logic_uScriptCon_CompareBool_False_53 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector3 logic_uScriptAct_AddVector3_uScriptAct_AddVector3_55 = new uScriptAct_AddVector3( );
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_A_55 = new Vector3[] {};
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_B_55 = new Vector3[] {};
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_Result_55;
   bool logic_uScriptAct_AddVector3_Out_55 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_60 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_60 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_60 = true;
   bool logic_uScriptCon_CompareBool_False_60 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_64 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_64 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_64 = true;
   bool logic_uScriptCon_CompareBool_False_64 = true;
   //pointer to script instanced logic node
   uScriptAct_SetColor logic_uScriptAct_SetColor_uScriptAct_SetColor_71 = new uScriptAct_SetColor( );
   UnityEngine.Color logic_uScriptAct_SetColor_Value_71 = new UnityEngine.Color( (float)0, (float)1, (float)0.03137255, (float)1 );
   UnityEngine.Color logic_uScriptAct_SetColor_TargetColor_71;
   bool logic_uScriptAct_SetColor_Out_71 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_72 = new uScriptAct_Delay( );
   System.Single logic_uScriptAct_Delay_Duration_72 = (float) 0;
   System.Boolean logic_uScriptAct_Delay_SingleFrame_72 = (bool) false;
   bool logic_uScriptAct_Delay_Immediate_72 = true;
   bool logic_uScriptAct_Delay_AfterDelay_72 = true;
   bool logic_uScriptAct_Delay_DrivenDelay_72 = false;
   //pointer to script instanced logic node
   uScriptAct_MoveToLocation logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_73 = new uScriptAct_MoveToLocation( );
   UnityEngine.GameObject[] logic_uScriptAct_MoveToLocation_targetArray_73 = new UnityEngine.GameObject[] {};
   UnityEngine.Vector3 logic_uScriptAct_MoveToLocation_location_73 = new Vector3( );
   System.Boolean logic_uScriptAct_MoveToLocation_asOffset_73 = (bool) false;
   System.Single logic_uScriptAct_MoveToLocation_totalTime_73 = (float) 0;
   bool logic_uScriptAct_MoveToLocation_Out_73 = true;
   bool logic_uScriptAct_MoveToLocation_Cancelled_73 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_78 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_78 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_78 = true;
   bool logic_uScriptCon_CompareBool_False_78 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_83 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_83;
   bool logic_uScriptAct_SetBool_Out_83 = true;
   bool logic_uScriptAct_SetBool_SetTrue_83 = true;
   bool logic_uScriptAct_SetBool_SetFalse_83 = true;
   
   //event nodes
   System.Int32 event_UnityEngine_GameObject_TimesToTrigger_10 = (int) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_10 = null;
   System.Int32 event_UnityEngine_GameObject_TimesToTrigger_30 = (int) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_30 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_31 = null;
   System.Int32 event_UnityEngine_GameObject_TimesToTrigger_35 = (int) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_35 = null;
   System.Int32 event_UnityEngine_GameObject_TimesToTrigger_65 = (int) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_65 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_84 = null;
   System.String event_UnityEngine_GameObject_EventName_84 = "";
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_84 = null;
   
   //property nodes
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_23 = new Vector3( );
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_23 = null;
   UnityEngine.Color property_color_Detox_ScriptEditor_Parameter_color_27 = UnityEngine.Color.black;
   UnityEngine.GameObject property_color_Detox_ScriptEditor_Parameter_Instance_27 = null;
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_34 = new Vector3( );
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_34 = null;
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_48 = new Vector3( );
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_48 = null;
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_56 = new Vector3( );
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_56 = null;
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_61 = new Vector3( );
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_61 = null;
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_75 = new Vector3( );
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_75 = null;
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_79 = new Vector3( );
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_79 = null;
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_85 = new Vector3( );
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_85 = null;
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_23_Get_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_23.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         return component.position;
      }
      else
      {
         return new Vector3( );
      }
   }
   
   void property_position_Detox_ScriptEditor_Parameter_position_23_Set_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_23.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         component.position = property_position_Detox_ScriptEditor_Parameter_position_23;
      }
   }
   
   UnityEngine.Color property_color_Detox_ScriptEditor_Parameter_color_27_Get_Refresh( )
   {
      UnityEngine.Light component = property_color_Detox_ScriptEditor_Parameter_Instance_27.GetComponent<UnityEngine.Light>();
      if ( null != component )
      {
         return component.color;
      }
      else
      {
         return UnityEngine.Color.black;
      }
   }
   
   void property_color_Detox_ScriptEditor_Parameter_color_27_Set_Refresh( )
   {
      UnityEngine.Light component = property_color_Detox_ScriptEditor_Parameter_Instance_27.GetComponent<UnityEngine.Light>();
      if ( null != component )
      {
         component.color = property_color_Detox_ScriptEditor_Parameter_color_27;
      }
   }
   
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_34_Get_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_34.GetComponent<UnityEngine.Transform>();
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
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_34.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         component.position = property_position_Detox_ScriptEditor_Parameter_position_34;
      }
   }
   
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_48_Get_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_48.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         return component.position;
      }
      else
      {
         return new Vector3( );
      }
   }
   
   void property_position_Detox_ScriptEditor_Parameter_position_48_Set_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_48.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         component.position = property_position_Detox_ScriptEditor_Parameter_position_48;
      }
   }
   
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_56_Get_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_56.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         return component.position;
      }
      else
      {
         return new Vector3( );
      }
   }
   
   void property_position_Detox_ScriptEditor_Parameter_position_56_Set_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_56.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         component.position = property_position_Detox_ScriptEditor_Parameter_position_56;
      }
   }
   
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_61_Get_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_61.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         return component.position;
      }
      else
      {
         return new Vector3( );
      }
   }
   
   void property_position_Detox_ScriptEditor_Parameter_position_61_Set_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_61.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         component.position = property_position_Detox_ScriptEditor_Parameter_position_61;
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
   
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_79_Get_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_79.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         return component.position;
      }
      else
      {
         return new Vector3( );
      }
   }
   
   void property_position_Detox_ScriptEditor_Parameter_position_79_Set_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_79.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         component.position = property_position_Detox_ScriptEditor_Parameter_position_79;
      }
   }
   
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_85_Get_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_85.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         return component.position;
      }
      else
      {
         return new Vector3( );
      }
   }
   
   void property_position_Detox_ScriptEditor_Parameter_position_85_Set_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_85.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         component.position = property_position_Detox_ScriptEditor_Parameter_position_85;
      }
   }
   
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      if ( null == property_position_Detox_ScriptEditor_Parameter_Instance_23 || false == m_RegisteredForEvents )
      {
         property_position_Detox_ScriptEditor_Parameter_Instance_23 = GameObject.Find( "Door1" ) as UnityEngine.GameObject;
      }
      if ( null == property_color_Detox_ScriptEditor_Parameter_Instance_27 || false == m_RegisteredForEvents )
      {
         property_color_Detox_ScriptEditor_Parameter_Instance_27 = GameObject.Find( "Door3_Spotlight" ) as UnityEngine.GameObject;
      }
      if ( null == property_position_Detox_ScriptEditor_Parameter_Instance_34 || false == m_RegisteredForEvents )
      {
         property_position_Detox_ScriptEditor_Parameter_Instance_34 = GameObject.Find( "Door3_R" ) as UnityEngine.GameObject;
      }
      if ( null == property_position_Detox_ScriptEditor_Parameter_Instance_48 || false == m_RegisteredForEvents )
      {
         property_position_Detox_ScriptEditor_Parameter_Instance_48 = GameObject.Find( "Door1" ) as UnityEngine.GameObject;
      }
      if ( null == property_position_Detox_ScriptEditor_Parameter_Instance_56 || false == m_RegisteredForEvents )
      {
         property_position_Detox_ScriptEditor_Parameter_Instance_56 = GameObject.Find( "Door3_L" ) as UnityEngine.GameObject;
      }
      if ( null == property_position_Detox_ScriptEditor_Parameter_Instance_61 || false == m_RegisteredForEvents )
      {
         property_position_Detox_ScriptEditor_Parameter_Instance_61 = GameObject.Find( "Door3_L" ) as UnityEngine.GameObject;
      }
      if ( null == property_position_Detox_ScriptEditor_Parameter_Instance_75 || false == m_RegisteredForEvents )
      {
         property_position_Detox_ScriptEditor_Parameter_Instance_75 = GameObject.Find( "Door3_R" ) as UnityEngine.GameObject;
      }
      if ( null == property_position_Detox_ScriptEditor_Parameter_Instance_79 || false == m_RegisteredForEvents )
      {
         property_position_Detox_ScriptEditor_Parameter_Instance_79 = GameObject.Find( "Door3_R" ) as UnityEngine.GameObject;
      }
      if ( null == property_position_Detox_ScriptEditor_Parameter_Instance_85 || false == m_RegisteredForEvents )
      {
         property_position_Detox_ScriptEditor_Parameter_Instance_85 = GameObject.Find( "Door3_L" ) as UnityEngine.GameObject;
      }
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
               uScript_Triggers component = local_6_UnityEngine_GameObject_previous.GetComponent<uScript_Triggers>();
               if ( null != component )
               {
                  component.OnEnterTrigger -= Instance_OnEnterTrigger_30;
                  component.OnExitTrigger -= Instance_OnExitTrigger_30;
                  component.WhileInsideTrigger -= Instance_WhileInsideTrigger_30;
               }
            }
         }
         
         local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_6_UnityEngine_GameObject )
         {
            {
               uScript_Triggers component = local_6_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = local_6_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_30;
               }
            }
            {
               uScript_Triggers component = local_6_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = local_6_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_30;
                  component.OnExitTrigger += Instance_OnExitTrigger_30;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_30;
               }
            }
         }
      }
      if ( null == local_17_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_17_UnityEngine_GameObject = GameObject.Find( "Door1_Trigger" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_17_UnityEngine_GameObject_previous != local_17_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_17_UnityEngine_GameObject_previous )
         {
            {
               uScript_Triggers component = local_17_UnityEngine_GameObject_previous.GetComponent<uScript_Triggers>();
               if ( null != component )
               {
                  component.OnEnterTrigger -= Instance_OnEnterTrigger_10;
                  component.OnExitTrigger -= Instance_OnExitTrigger_10;
                  component.WhileInsideTrigger -= Instance_WhileInsideTrigger_10;
               }
            }
         }
         
         local_17_UnityEngine_GameObject_previous = local_17_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_17_UnityEngine_GameObject )
         {
            {
               uScript_Triggers component = local_17_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = local_17_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_10;
               }
            }
            {
               uScript_Triggers component = local_17_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = local_17_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_10;
                  component.OnExitTrigger += Instance_OnExitTrigger_10;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_10;
               }
            }
         }
      }
      if ( null == local_36_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_36_UnityEngine_GameObject = GameObject.Find( "Door1" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_36_UnityEngine_GameObject_previous != local_36_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_36_UnityEngine_GameObject_previous = local_36_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_40_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_40_UnityEngine_GameObject = GameObject.Find( "Door2_Trigger" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_40_UnityEngine_GameObject_previous != local_40_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_40_UnityEngine_GameObject_previous )
         {
            {
               uScript_Triggers component = local_40_UnityEngine_GameObject_previous.GetComponent<uScript_Triggers>();
               if ( null != component )
               {
                  component.OnEnterTrigger -= Instance_OnEnterTrigger_65;
                  component.OnExitTrigger -= Instance_OnExitTrigger_65;
                  component.WhileInsideTrigger -= Instance_WhileInsideTrigger_65;
               }
            }
         }
         
         local_40_UnityEngine_GameObject_previous = local_40_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_40_UnityEngine_GameObject )
         {
            {
               uScript_Triggers component = local_40_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = local_40_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_65;
               }
            }
            {
               uScript_Triggers component = local_40_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = local_40_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_65;
                  component.OnExitTrigger += Instance_OnExitTrigger_65;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_65;
               }
            }
         }
      }
      if ( null == local_44_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_44_UnityEngine_GameObject = GameObject.Find( "Door2" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_44_UnityEngine_GameObject_previous != local_44_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_44_UnityEngine_GameObject_previous = local_44_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_59_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_59_UnityEngine_GameObject = GameObject.Find( "Door3_Trigger" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_59_UnityEngine_GameObject_previous != local_59_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_59_UnityEngine_GameObject_previous )
         {
            {
               uScript_Triggers component = local_59_UnityEngine_GameObject_previous.GetComponent<uScript_Triggers>();
               if ( null != component )
               {
                  component.OnEnterTrigger -= Instance_OnEnterTrigger_35;
                  component.OnExitTrigger -= Instance_OnExitTrigger_35;
                  component.WhileInsideTrigger -= Instance_WhileInsideTrigger_35;
               }
            }
         }
         
         local_59_UnityEngine_GameObject_previous = local_59_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_59_UnityEngine_GameObject )
         {
            {
               uScript_Triggers component = local_59_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = local_59_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_35;
               }
            }
            {
               uScript_Triggers component = local_59_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = local_59_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_35;
                  component.OnExitTrigger += Instance_OnExitTrigger_35;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_35;
               }
            }
         }
      }
      if ( null == local_62_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_62_UnityEngine_GameObject = GameObject.Find( "Door1" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_62_UnityEngine_GameObject_previous != local_62_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_62_UnityEngine_GameObject_previous = local_62_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_70_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_70_UnityEngine_GameObject = GameObject.Find( "Door2" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_70_UnityEngine_GameObject_previous != local_70_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_70_UnityEngine_GameObject_previous = local_70_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_6_UnityEngine_GameObject_previous != local_6_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_6_UnityEngine_GameObject_previous )
         {
            {
               uScript_Triggers component = local_6_UnityEngine_GameObject_previous.GetComponent<uScript_Triggers>();
               if ( null != component )
               {
                  component.OnEnterTrigger -= Instance_OnEnterTrigger_30;
                  component.OnExitTrigger -= Instance_OnExitTrigger_30;
                  component.WhileInsideTrigger -= Instance_WhileInsideTrigger_30;
               }
            }
         }
         
         local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_6_UnityEngine_GameObject )
         {
            {
               uScript_Triggers component = local_6_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = local_6_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_30;
               }
            }
            {
               uScript_Triggers component = local_6_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = local_6_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_30;
                  component.OnExitTrigger += Instance_OnExitTrigger_30;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_30;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_17_UnityEngine_GameObject_previous != local_17_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_17_UnityEngine_GameObject_previous )
         {
            {
               uScript_Triggers component = local_17_UnityEngine_GameObject_previous.GetComponent<uScript_Triggers>();
               if ( null != component )
               {
                  component.OnEnterTrigger -= Instance_OnEnterTrigger_10;
                  component.OnExitTrigger -= Instance_OnExitTrigger_10;
                  component.WhileInsideTrigger -= Instance_WhileInsideTrigger_10;
               }
            }
         }
         
         local_17_UnityEngine_GameObject_previous = local_17_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_17_UnityEngine_GameObject )
         {
            {
               uScript_Triggers component = local_17_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = local_17_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_10;
               }
            }
            {
               uScript_Triggers component = local_17_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = local_17_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_10;
                  component.OnExitTrigger += Instance_OnExitTrigger_10;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_10;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_36_UnityEngine_GameObject_previous != local_36_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_36_UnityEngine_GameObject_previous = local_36_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_40_UnityEngine_GameObject_previous != local_40_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_40_UnityEngine_GameObject_previous )
         {
            {
               uScript_Triggers component = local_40_UnityEngine_GameObject_previous.GetComponent<uScript_Triggers>();
               if ( null != component )
               {
                  component.OnEnterTrigger -= Instance_OnEnterTrigger_65;
                  component.OnExitTrigger -= Instance_OnExitTrigger_65;
                  component.WhileInsideTrigger -= Instance_WhileInsideTrigger_65;
               }
            }
         }
         
         local_40_UnityEngine_GameObject_previous = local_40_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_40_UnityEngine_GameObject )
         {
            {
               uScript_Triggers component = local_40_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = local_40_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_65;
               }
            }
            {
               uScript_Triggers component = local_40_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = local_40_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_65;
                  component.OnExitTrigger += Instance_OnExitTrigger_65;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_65;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_44_UnityEngine_GameObject_previous != local_44_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_44_UnityEngine_GameObject_previous = local_44_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_59_UnityEngine_GameObject_previous != local_59_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_59_UnityEngine_GameObject_previous )
         {
            {
               uScript_Triggers component = local_59_UnityEngine_GameObject_previous.GetComponent<uScript_Triggers>();
               if ( null != component )
               {
                  component.OnEnterTrigger -= Instance_OnEnterTrigger_35;
                  component.OnExitTrigger -= Instance_OnExitTrigger_35;
                  component.WhileInsideTrigger -= Instance_WhileInsideTrigger_35;
               }
            }
         }
         
         local_59_UnityEngine_GameObject_previous = local_59_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_59_UnityEngine_GameObject )
         {
            {
               uScript_Triggers component = local_59_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = local_59_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_35;
               }
            }
            {
               uScript_Triggers component = local_59_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = local_59_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_35;
                  component.OnExitTrigger += Instance_OnExitTrigger_35;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_35;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_62_UnityEngine_GameObject_previous != local_62_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_62_UnityEngine_GameObject_previous = local_62_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_70_UnityEngine_GameObject_previous != local_70_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_70_UnityEngine_GameObject_previous = local_70_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void SyncEventListeners( )
   {
      if ( null == event_UnityEngine_GameObject_Instance_31 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_31 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_31 )
         {
            {
               uScript_Update component = event_UnityEngine_GameObject_Instance_31.GetComponent<uScript_Update>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_31.AddComponent<uScript_Update>();
               }
               if ( null != component )
               {
                  component.OnUpdate += Instance_OnUpdate_31;
                  component.OnLateUpdate += Instance_OnLateUpdate_31;
                  component.OnFixedUpdate += Instance_OnFixedUpdate_31;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_84 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_84 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_84 )
         {
            {
               uScript_CustomEvent component = event_UnityEngine_GameObject_Instance_84.GetComponent<uScript_CustomEvent>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_84.AddComponent<uScript_CustomEvent>();
               }
               if ( null != component )
               {
                  component.OnCustomEvent += Instance_OnCustomEvent_84;
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
            uScript_Triggers component = local_6_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
            if ( null != component )
            {
               component.OnEnterTrigger -= Instance_OnEnterTrigger_30;
               component.OnExitTrigger -= Instance_OnExitTrigger_30;
               component.WhileInsideTrigger -= Instance_WhileInsideTrigger_30;
            }
         }
      }
      if ( null != local_17_UnityEngine_GameObject )
      {
         {
            uScript_Triggers component = local_17_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
            if ( null != component )
            {
               component.OnEnterTrigger -= Instance_OnEnterTrigger_10;
               component.OnExitTrigger -= Instance_OnExitTrigger_10;
               component.WhileInsideTrigger -= Instance_WhileInsideTrigger_10;
            }
         }
      }
      if ( null != local_40_UnityEngine_GameObject )
      {
         {
            uScript_Triggers component = local_40_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
            if ( null != component )
            {
               component.OnEnterTrigger -= Instance_OnEnterTrigger_65;
               component.OnExitTrigger -= Instance_OnExitTrigger_65;
               component.WhileInsideTrigger -= Instance_WhileInsideTrigger_65;
            }
         }
      }
      if ( null != local_59_UnityEngine_GameObject )
      {
         {
            uScript_Triggers component = local_59_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
            if ( null != component )
            {
               component.OnEnterTrigger -= Instance_OnEnterTrigger_35;
               component.OnExitTrigger -= Instance_OnExitTrigger_35;
               component.WhileInsideTrigger -= Instance_WhileInsideTrigger_35;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_31 )
      {
         {
            uScript_Update component = event_UnityEngine_GameObject_Instance_31.GetComponent<uScript_Update>();
            if ( null != component )
            {
               component.OnUpdate -= Instance_OnUpdate_31;
               component.OnLateUpdate -= Instance_OnLateUpdate_31;
               component.OnFixedUpdate -= Instance_OnFixedUpdate_31;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_84 )
      {
         {
            uScript_CustomEvent component = event_UnityEngine_GameObject_Instance_84.GetComponent<uScript_CustomEvent>();
            if ( null != component )
            {
               component.OnCustomEvent -= Instance_OnCustomEvent_84;
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
      logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_13.SetParent(g);
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_15.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_19.SetParent(g);
      logic_uScriptAct_Destroy_uScriptAct_Destroy_24.SetParent(g);
      logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_25.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_26.SetParent(g);
      logic_uScriptAct_SendCustomEventBool_uScriptAct_SendCustomEventBool_28.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_32.SetParent(g);
      logic_uScriptAct_AddVector3_uScriptAct_AddVector3_37.SetParent(g);
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_38.SetParent(g);
      logic_uScriptAct_AddVector3_uScriptAct_AddVector3_41.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_42.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_43.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_46.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_52.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_53.SetParent(g);
      logic_uScriptAct_AddVector3_uScriptAct_AddVector3_55.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_60.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_64.SetParent(g);
      logic_uScriptAct_SetColor_uScriptAct_SetColor_71.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_72.SetParent(g);
      logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_73.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_78.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_83.SetParent(g);
   }
   public void Awake()
   {
      
      logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_1.Finished += uScriptAct_MoveToLocation_Finished_1;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_15.Finished += uScriptAct_PlayAnimation_Finished_15;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_38.Finished += uScriptAct_PlayAnimation_Finished_38;
      logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_73.Finished += uScriptAct_MoveToLocation_Finished_73;
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
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_15.Update( );
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_38.Update( );
      logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_73.Update( );
      if (true == logic_uScriptAct_Delay_DrivenDelay_2)
      {
         Relay_DrivenDelay_2();
      }
      if (true == logic_uScriptAct_InterpolateVector3Linear_Driven_13)
      {
         Relay_Driven_13();
      }
      if (true == logic_uScriptAct_Destroy_WaitOneTick_24)
      {
         Relay_WaitOneTick_24();
      }
      if (true == logic_uScriptAct_InterpolateVector3Linear_Driven_25)
      {
         Relay_Driven_25();
      }
      if (true == logic_uScriptAct_Delay_DrivenDelay_72)
      {
         Relay_DrivenDelay_72();
      }
   }
   
   public void OnDestroy()
   {
      logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_1.Finished -= uScriptAct_MoveToLocation_Finished_1;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_15.Finished -= uScriptAct_PlayAnimation_Finished_15;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_38.Finished -= uScriptAct_PlayAnimation_Finished_38;
      logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_73.Finished -= uScriptAct_MoveToLocation_Finished_73;
   }
   
   public void OnGUI()
   {
      logic_uScriptAct_PrintText_uScriptAct_PrintText_7.OnGUI( );
      logic_uScriptAct_PrintText_uScriptAct_PrintText_26.OnGUI( );
   }
   
   void Instance_OnEnterTrigger_10(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_10 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_10( );
   }
   
   void Instance_OnExitTrigger_10(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_10 = e.GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_10( );
   }
   
   void Instance_WhileInsideTrigger_10(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_10 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_10( );
   }
   
   void Instance_OnEnterTrigger_30(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_30 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_30( );
   }
   
   void Instance_OnExitTrigger_30(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_30 = e.GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_30( );
   }
   
   void Instance_WhileInsideTrigger_30(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_30 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_30( );
   }
   
   void Instance_OnUpdate_31(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUpdate_31( );
   }
   
   void Instance_OnLateUpdate_31(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnLateUpdate_31( );
   }
   
   void Instance_OnFixedUpdate_31(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnFixedUpdate_31( );
   }
   
   void Instance_OnEnterTrigger_35(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_35 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_35( );
   }
   
   void Instance_OnExitTrigger_35(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_35 = e.GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_35( );
   }
   
   void Instance_WhileInsideTrigger_35(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_35 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_35( );
   }
   
   void Instance_OnEnterTrigger_65(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_65 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_65( );
   }
   
   void Instance_OnExitTrigger_65(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_65 = e.GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_65( );
   }
   
   void Instance_WhileInsideTrigger_65(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_65 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_65( );
   }
   
   void Instance_OnCustomEvent_84(object o, uScript_CustomEvent.CustomEventBoolArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_84 = e.Sender;
      event_UnityEngine_GameObject_EventName_84 = e.EventName;
      //relay event to nodes
      Relay_OnCustomEvent_84( );
   }
   
   void uScriptAct_MoveToLocation_Finished_1(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_1( );
   }
   
   void uScriptAct_PlayAnimation_Finished_15(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_15( );
   }
   
   void uScriptAct_PlayAnimation_Finished_38(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_38( );
   }
   
   void uScriptAct_MoveToLocation_Finished_73(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_73( );
   }
   
   void Relay_Finished_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("384da341-4a91-4527-b106-5845e694aea2", "Move To Location", Relay_Finished_1)) return; 
         Relay_False_83();
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
         if (true == CheckDebugBreak("384da341-4a91-4527-b106-5845e694aea2", "Move To Location", Relay_In_1)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_62_UnityEngine_GameObject_previous != local_62_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_62_UnityEngine_GameObject_previous = local_62_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_62_UnityEngine_GameObject);
               logic_uScriptAct_MoveToLocation_targetArray_1 = properties.ToArray();
            }
            {
               logic_uScriptAct_MoveToLocation_location_1 = local_3_UnityEngine_Vector3;
               
            }
            {
            }
            {
               logic_uScriptAct_MoveToLocation_totalTime_1 = local_77_System_Single;
               
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
         if (true == CheckDebugBreak("384da341-4a91-4527-b106-5845e694aea2", "Move To Location", Relay_Cancel_1)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_62_UnityEngine_GameObject_previous != local_62_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_62_UnityEngine_GameObject_previous = local_62_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_62_UnityEngine_GameObject);
               logic_uScriptAct_MoveToLocation_targetArray_1 = properties.ToArray();
            }
            {
               logic_uScriptAct_MoveToLocation_location_1 = local_3_UnityEngine_Vector3;
               
            }
            {
            }
            {
               logic_uScriptAct_MoveToLocation_totalTime_1 = local_77_System_Single;
               
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
               logic_uScriptAct_Delay_Duration_2 = local_50_System_Single;
               
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
            Relay_In_15();
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
               logic_uScriptAct_Delay_Duration_2 = local_50_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_Delay_DrivenDelay_2 = logic_uScriptAct_Delay_uScriptAct_Delay_2.DrivenDelay();
         if ( true == logic_uScriptAct_Delay_DrivenDelay_2 )
         {
            if ( logic_uScriptAct_Delay_uScriptAct_Delay_2.AfterDelay == true )
            {
               Relay_In_15();
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
         if (true == CheckDebugBreak("ce6ddcbd-a3fb-4e42-ba75-a85abb92e00f", "Add Vector3", Relay_In_5)) return; 
         {
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)property_position_Detox_ScriptEditor_Parameter_position_48_Get_Refresh());
               logic_uScriptAct_AddVector3_A_5 = properties.ToArray();
            }
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_51_UnityEngine_Vector3);
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
            Relay_In_73();
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
         if (true == CheckDebugBreak("9286744b-f05c-4c08-adf6-609df3af749d", "Print Text", Relay_ShowLabel_7)) return; 
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
         if (true == CheckDebugBreak("9286744b-f05c-4c08-adf6-609df3af749d", "Print Text", Relay_HideLabel_7)) return; 
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
         if (true == CheckDebugBreak("9936fe7f-c5b3-42b8-bd45-3f106b5da017", "Set Bool", Relay_True_8)) return; 
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
            Relay_In_38();
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
         if (true == CheckDebugBreak("9936fe7f-c5b3-42b8-bd45-3f106b5da017", "Set Bool", Relay_False_8)) return; 
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
            Relay_In_38();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnEnterTrigger_10()
   {
      if (true == CheckDebugBreak("cbcf4ab6-7d40-463b-b498-c404cd7a24bc", "Trigger Events", Relay_OnEnterTrigger_10)) return; 
      Relay_In_60();
   }
   
   void Relay_OnExitTrigger_10()
   {
      if (true == CheckDebugBreak("cbcf4ab6-7d40-463b-b498-c404cd7a24bc", "Trigger Events", Relay_OnExitTrigger_10)) return; 
   }
   
   void Relay_WhileInsideTrigger_10()
   {
      if (true == CheckDebugBreak("cbcf4ab6-7d40-463b-b498-c404cd7a24bc", "Trigger Events", Relay_WhileInsideTrigger_10)) return; 
   }
   
   void Relay_Begin_13()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("69d1d5d5-fff8-4d67-b32a-5d00a4a993db", "Interpolate Vector3 Linear", Relay_Begin_13)) return; 
         {
            {
               logic_uScriptAct_InterpolateVector3Linear_startValue_13 = property_position_Detox_ScriptEditor_Parameter_position_75_Get_Refresh( );
               
            }
            {
               logic_uScriptAct_InterpolateVector3Linear_endValue_13 = local_33_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_InterpolateVector3Linear_time_13 = local_76_System_Single;
               
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
         logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_13.Begin(logic_uScriptAct_InterpolateVector3Linear_startValue_13, logic_uScriptAct_InterpolateVector3Linear_endValue_13, logic_uScriptAct_InterpolateVector3Linear_time_13, logic_uScriptAct_InterpolateVector3Linear_loopType_13, logic_uScriptAct_InterpolateVector3Linear_loopDelay_13, logic_uScriptAct_InterpolateVector3Linear_loopCount_13, out logic_uScriptAct_InterpolateVector3Linear_currentValue_13);
         logic_uScriptAct_InterpolateVector3Linear_Driven_13 = true;
         property_position_Detox_ScriptEditor_Parameter_position_34 = logic_uScriptAct_InterpolateVector3Linear_currentValue_13;
         property_position_Detox_ScriptEditor_Parameter_position_34_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Interpolate Vector3 Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_13()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("69d1d5d5-fff8-4d67-b32a-5d00a4a993db", "Interpolate Vector3 Linear", Relay_Stop_13)) return; 
         {
            {
               logic_uScriptAct_InterpolateVector3Linear_startValue_13 = property_position_Detox_ScriptEditor_Parameter_position_75_Get_Refresh( );
               
            }
            {
               logic_uScriptAct_InterpolateVector3Linear_endValue_13 = local_33_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_InterpolateVector3Linear_time_13 = local_76_System_Single;
               
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
         logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_13.Stop(logic_uScriptAct_InterpolateVector3Linear_startValue_13, logic_uScriptAct_InterpolateVector3Linear_endValue_13, logic_uScriptAct_InterpolateVector3Linear_time_13, logic_uScriptAct_InterpolateVector3Linear_loopType_13, logic_uScriptAct_InterpolateVector3Linear_loopDelay_13, logic_uScriptAct_InterpolateVector3Linear_loopCount_13, out logic_uScriptAct_InterpolateVector3Linear_currentValue_13);
         logic_uScriptAct_InterpolateVector3Linear_Driven_13 = true;
         property_position_Detox_ScriptEditor_Parameter_position_34 = logic_uScriptAct_InterpolateVector3Linear_currentValue_13;
         property_position_Detox_ScriptEditor_Parameter_position_34_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Interpolate Vector3 Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Resume_13()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("69d1d5d5-fff8-4d67-b32a-5d00a4a993db", "Interpolate Vector3 Linear", Relay_Resume_13)) return; 
         {
            {
               logic_uScriptAct_InterpolateVector3Linear_startValue_13 = property_position_Detox_ScriptEditor_Parameter_position_75_Get_Refresh( );
               
            }
            {
               logic_uScriptAct_InterpolateVector3Linear_endValue_13 = local_33_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_InterpolateVector3Linear_time_13 = local_76_System_Single;
               
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
         logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_13.Resume(logic_uScriptAct_InterpolateVector3Linear_startValue_13, logic_uScriptAct_InterpolateVector3Linear_endValue_13, logic_uScriptAct_InterpolateVector3Linear_time_13, logic_uScriptAct_InterpolateVector3Linear_loopType_13, logic_uScriptAct_InterpolateVector3Linear_loopDelay_13, logic_uScriptAct_InterpolateVector3Linear_loopCount_13, out logic_uScriptAct_InterpolateVector3Linear_currentValue_13);
         logic_uScriptAct_InterpolateVector3Linear_Driven_13 = true;
         property_position_Detox_ScriptEditor_Parameter_position_34 = logic_uScriptAct_InterpolateVector3Linear_currentValue_13;
         property_position_Detox_ScriptEditor_Parameter_position_34_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Interpolate Vector3 Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Driven_13( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               logic_uScriptAct_InterpolateVector3Linear_startValue_13 = property_position_Detox_ScriptEditor_Parameter_position_75_Get_Refresh( );
               
            }
            {
               logic_uScriptAct_InterpolateVector3Linear_endValue_13 = local_33_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_InterpolateVector3Linear_time_13 = local_76_System_Single;
               
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
         logic_uScriptAct_InterpolateVector3Linear_Driven_13 = logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_13.Driven(out logic_uScriptAct_InterpolateVector3Linear_currentValue_13);
         if ( true == logic_uScriptAct_InterpolateVector3Linear_Driven_13 )
         {
            property_position_Detox_ScriptEditor_Parameter_position_34 = logic_uScriptAct_InterpolateVector3Linear_currentValue_13;
            property_position_Detox_ScriptEditor_Parameter_position_34_Set_Refresh( );
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Interpolate Vector3 Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_Finished_15()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2c58a3da-20be-4c4c-aa5e-4d73de68f83d", "Play Animation", Relay_Finished_15)) return; 
         Relay_False_52();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_15()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2c58a3da-20be-4c4c-aa5e-4d73de68f83d", "Play Animation", Relay_In_15)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_70_UnityEngine_GameObject_previous != local_70_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_70_UnityEngine_GameObject_previous = local_70_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_70_UnityEngine_GameObject);
               logic_uScriptAct_PlayAnimation_Target_15 = properties.ToArray();
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
         logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_15.In(logic_uScriptAct_PlayAnimation_Target_15, logic_uScriptAct_PlayAnimation_Animation_15, logic_uScriptAct_PlayAnimation_SpeedFactor_15, logic_uScriptAct_PlayAnimation_AnimWrapMode_15, logic_uScriptAct_PlayAnimation_StopOtherAnimations_15);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_19()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("92221b11-5f5d-4c65-a5c1-2fe2565f5593", "Set Bool", Relay_True_19)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_19.True(out logic_uScriptAct_SetBool_Target_19);
         local_Door3_Open__System_Boolean = logic_uScriptAct_SetBool_Target_19;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_19.Out;
         
         if ( test_0 == true )
         {
            Relay_In_71();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_19()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("92221b11-5f5d-4c65-a5c1-2fe2565f5593", "Set Bool", Relay_False_19)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_19.False(out logic_uScriptAct_SetBool_Target_19);
         local_Door3_Open__System_Boolean = logic_uScriptAct_SetBool_Target_19;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_19.Out;
         
         if ( test_0 == true )
         {
            Relay_In_71();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_24()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a37920ac-a636-4c20-a607-f048478063b0", "Destroy", Relay_In_24)) return; 
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
                           uScript_Triggers component = local_6_UnityEngine_GameObject_previous.GetComponent<uScript_Triggers>();
                           if ( null != component )
                           {
                              component.OnEnterTrigger -= Instance_OnEnterTrigger_30;
                              component.OnExitTrigger -= Instance_OnExitTrigger_30;
                              component.WhileInsideTrigger -= Instance_WhileInsideTrigger_30;
                           }
                        }
                     }
                     
                     local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
                     
                     //setup new listeners
                     if ( null != local_6_UnityEngine_GameObject )
                     {
                        {
                           uScript_Triggers component = local_6_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
                           if ( null == component )
                           {
                              component = local_6_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
                           }
                           if ( null != component )
                           {
                              component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_30;
                           }
                        }
                        {
                           uScript_Triggers component = local_6_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
                           if ( null == component )
                           {
                              component = local_6_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
                           }
                           if ( null != component )
                           {
                              component.OnEnterTrigger += Instance_OnEnterTrigger_30;
                              component.OnExitTrigger += Instance_OnExitTrigger_30;
                              component.WhileInsideTrigger += Instance_WhileInsideTrigger_30;
                           }
                        }
                     }
                  }
               }
               properties.Add((UnityEngine.GameObject)local_6_UnityEngine_GameObject);
               logic_uScriptAct_Destroy_Target_24 = properties.ToArray();
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Destroy.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_WaitOneTick_24( )
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
                           uScript_Triggers component = local_6_UnityEngine_GameObject_previous.GetComponent<uScript_Triggers>();
                           if ( null != component )
                           {
                              component.OnEnterTrigger -= Instance_OnEnterTrigger_30;
                              component.OnExitTrigger -= Instance_OnExitTrigger_30;
                              component.WhileInsideTrigger -= Instance_WhileInsideTrigger_30;
                           }
                        }
                     }
                     
                     local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
                     
                     //setup new listeners
                     if ( null != local_6_UnityEngine_GameObject )
                     {
                        {
                           uScript_Triggers component = local_6_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
                           if ( null == component )
                           {
                              component = local_6_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
                           }
                           if ( null != component )
                           {
                              component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_30;
                           }
                        }
                        {
                           uScript_Triggers component = local_6_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
                           if ( null == component )
                           {
                              component = local_6_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
                           }
                           if ( null != component )
                           {
                              component.OnEnterTrigger += Instance_OnEnterTrigger_30;
                              component.OnExitTrigger += Instance_OnExitTrigger_30;
                              component.WhileInsideTrigger += Instance_WhileInsideTrigger_30;
                           }
                        }
                     }
                  }
               }
               properties.Add((UnityEngine.GameObject)local_6_UnityEngine_GameObject);
               logic_uScriptAct_Destroy_Target_24 = properties.ToArray();
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Destroy.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_Begin_25()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("af14b845-79f6-476a-b811-19247ec5ddb0", "Interpolate Vector3 Linear", Relay_Begin_25)) return; 
         {
            {
               logic_uScriptAct_InterpolateVector3Linear_startValue_25 = property_position_Detox_ScriptEditor_Parameter_position_85_Get_Refresh( );
               
            }
            {
               logic_uScriptAct_InterpolateVector3Linear_endValue_25 = local_67_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_InterpolateVector3Linear_time_25 = local_12_System_Single;
               
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
         logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_25.Begin(logic_uScriptAct_InterpolateVector3Linear_startValue_25, logic_uScriptAct_InterpolateVector3Linear_endValue_25, logic_uScriptAct_InterpolateVector3Linear_time_25, logic_uScriptAct_InterpolateVector3Linear_loopType_25, logic_uScriptAct_InterpolateVector3Linear_loopDelay_25, logic_uScriptAct_InterpolateVector3Linear_loopCount_25, out logic_uScriptAct_InterpolateVector3Linear_currentValue_25);
         logic_uScriptAct_InterpolateVector3Linear_Driven_25 = true;
         property_position_Detox_ScriptEditor_Parameter_position_56 = logic_uScriptAct_InterpolateVector3Linear_currentValue_25;
         property_position_Detox_ScriptEditor_Parameter_position_56_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Interpolate Vector3 Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_25()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("af14b845-79f6-476a-b811-19247ec5ddb0", "Interpolate Vector3 Linear", Relay_Stop_25)) return; 
         {
            {
               logic_uScriptAct_InterpolateVector3Linear_startValue_25 = property_position_Detox_ScriptEditor_Parameter_position_85_Get_Refresh( );
               
            }
            {
               logic_uScriptAct_InterpolateVector3Linear_endValue_25 = local_67_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_InterpolateVector3Linear_time_25 = local_12_System_Single;
               
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
         logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_25.Stop(logic_uScriptAct_InterpolateVector3Linear_startValue_25, logic_uScriptAct_InterpolateVector3Linear_endValue_25, logic_uScriptAct_InterpolateVector3Linear_time_25, logic_uScriptAct_InterpolateVector3Linear_loopType_25, logic_uScriptAct_InterpolateVector3Linear_loopDelay_25, logic_uScriptAct_InterpolateVector3Linear_loopCount_25, out logic_uScriptAct_InterpolateVector3Linear_currentValue_25);
         logic_uScriptAct_InterpolateVector3Linear_Driven_25 = true;
         property_position_Detox_ScriptEditor_Parameter_position_56 = logic_uScriptAct_InterpolateVector3Linear_currentValue_25;
         property_position_Detox_ScriptEditor_Parameter_position_56_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Interpolate Vector3 Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Resume_25()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("af14b845-79f6-476a-b811-19247ec5ddb0", "Interpolate Vector3 Linear", Relay_Resume_25)) return; 
         {
            {
               logic_uScriptAct_InterpolateVector3Linear_startValue_25 = property_position_Detox_ScriptEditor_Parameter_position_85_Get_Refresh( );
               
            }
            {
               logic_uScriptAct_InterpolateVector3Linear_endValue_25 = local_67_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_InterpolateVector3Linear_time_25 = local_12_System_Single;
               
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
         logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_25.Resume(logic_uScriptAct_InterpolateVector3Linear_startValue_25, logic_uScriptAct_InterpolateVector3Linear_endValue_25, logic_uScriptAct_InterpolateVector3Linear_time_25, logic_uScriptAct_InterpolateVector3Linear_loopType_25, logic_uScriptAct_InterpolateVector3Linear_loopDelay_25, logic_uScriptAct_InterpolateVector3Linear_loopCount_25, out logic_uScriptAct_InterpolateVector3Linear_currentValue_25);
         logic_uScriptAct_InterpolateVector3Linear_Driven_25 = true;
         property_position_Detox_ScriptEditor_Parameter_position_56 = logic_uScriptAct_InterpolateVector3Linear_currentValue_25;
         property_position_Detox_ScriptEditor_Parameter_position_56_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Interpolate Vector3 Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Driven_25( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               logic_uScriptAct_InterpolateVector3Linear_startValue_25 = property_position_Detox_ScriptEditor_Parameter_position_85_Get_Refresh( );
               
            }
            {
               logic_uScriptAct_InterpolateVector3Linear_endValue_25 = local_67_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_InterpolateVector3Linear_time_25 = local_12_System_Single;
               
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
         logic_uScriptAct_InterpolateVector3Linear_Driven_25 = logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_25.Driven(out logic_uScriptAct_InterpolateVector3Linear_currentValue_25);
         if ( true == logic_uScriptAct_InterpolateVector3Linear_Driven_25 )
         {
            property_position_Detox_ScriptEditor_Parameter_position_56 = logic_uScriptAct_InterpolateVector3Linear_currentValue_25;
            property_position_Detox_ScriptEditor_Parameter_position_56_Set_Refresh( );
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Interpolate Vector3 Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_ShowLabel_26()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6e384f1b-4ac6-406c-bc7d-7e1bfbc0aa9e", "Print Text", Relay_ShowLabel_26)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_26.ShowLabel(logic_uScriptAct_PrintText_Text_26, logic_uScriptAct_PrintText_FontSize_26, logic_uScriptAct_PrintText_FontStyle_26, logic_uScriptAct_PrintText_FontColor_26, logic_uScriptAct_PrintText_textAnchor_26, logic_uScriptAct_PrintText_EdgePadding_26, logic_uScriptAct_PrintText_time_26);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_26()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6e384f1b-4ac6-406c-bc7d-7e1bfbc0aa9e", "Print Text", Relay_HideLabel_26)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_26.HideLabel(logic_uScriptAct_PrintText_Text_26, logic_uScriptAct_PrintText_FontSize_26, logic_uScriptAct_PrintText_FontStyle_26, logic_uScriptAct_PrintText_FontColor_26, logic_uScriptAct_PrintText_textAnchor_26, logic_uScriptAct_PrintText_EdgePadding_26, logic_uScriptAct_PrintText_time_26);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_SendCustomEvent_28()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7e4777bd-8453-49fa-89e9-27ea635bcdd0", "Send Custom Event (Bool)", Relay_SendCustomEvent_28)) return; 
         {
            {
               logic_uScriptAct_SendCustomEventBool_EventName_28 = local_63_System_String;
               
            }
            {
               logic_uScriptAct_SendCustomEventBool_EventValue_28 = local_Has_Key_System_Boolean;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SendCustomEventBool_uScriptAct_SendCustomEventBool_28.SendCustomEvent(logic_uScriptAct_SendCustomEventBool_EventName_28, logic_uScriptAct_SendCustomEventBool_EventValue_28, logic_uScriptAct_SendCustomEventBool_sendGroup_28, logic_uScriptAct_SendCustomEventBool_EventSender_28);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Send Custom Event (Bool).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnEnterTrigger_30()
   {
      if (true == CheckDebugBreak("12c02af9-a956-4cc0-9e4f-7b32a146d893", "Trigger Events", Relay_OnEnterTrigger_30)) return; 
      Relay_True_32();
   }
   
   void Relay_OnExitTrigger_30()
   {
      if (true == CheckDebugBreak("12c02af9-a956-4cc0-9e4f-7b32a146d893", "Trigger Events", Relay_OnExitTrigger_30)) return; 
   }
   
   void Relay_WhileInsideTrigger_30()
   {
      if (true == CheckDebugBreak("12c02af9-a956-4cc0-9e4f-7b32a146d893", "Trigger Events", Relay_WhileInsideTrigger_30)) return; 
   }
   
   void Relay_OnUpdate_31()
   {
      if (true == CheckDebugBreak("3ccf063a-b800-4289-8b39-e071fb297ecf", "Global Update", Relay_OnUpdate_31)) return; 
   }
   
   void Relay_OnLateUpdate_31()
   {
      if (true == CheckDebugBreak("3ccf063a-b800-4289-8b39-e071fb297ecf", "Global Update", Relay_OnLateUpdate_31)) return; 
   }
   
   void Relay_OnFixedUpdate_31()
   {
      if (true == CheckDebugBreak("3ccf063a-b800-4289-8b39-e071fb297ecf", "Global Update", Relay_OnFixedUpdate_31)) return; 
      Relay_In_46();
   }
   
   void Relay_True_32()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("dd3f8fb0-624f-46c5-8089-6f3cef2c7b8b", "Set Bool", Relay_True_32)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_32.True(out logic_uScriptAct_SetBool_Target_32);
         local_Has_Key_System_Boolean = logic_uScriptAct_SetBool_Target_32;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_32.Out;
         
         if ( test_0 == true )
         {
            Relay_In_24();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_32()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("dd3f8fb0-624f-46c5-8089-6f3cef2c7b8b", "Set Bool", Relay_False_32)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_32.False(out logic_uScriptAct_SetBool_Target_32);
         local_Has_Key_System_Boolean = logic_uScriptAct_SetBool_Target_32;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_32.Out;
         
         if ( test_0 == true )
         {
            Relay_In_24();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnEnterTrigger_35()
   {
      if (true == CheckDebugBreak("8c0ecc61-df54-48aa-a894-2af5a3af0f84", "Trigger Events", Relay_OnEnterTrigger_35)) return; 
      Relay_In_64();
   }
   
   void Relay_OnExitTrigger_35()
   {
      if (true == CheckDebugBreak("8c0ecc61-df54-48aa-a894-2af5a3af0f84", "Trigger Events", Relay_OnExitTrigger_35)) return; 
   }
   
   void Relay_WhileInsideTrigger_35()
   {
      if (true == CheckDebugBreak("8c0ecc61-df54-48aa-a894-2af5a3af0f84", "Trigger Events", Relay_WhileInsideTrigger_35)) return; 
   }
   
   void Relay_In_37()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ae512a97-6917-4ab9-87ad-bb5727a6f774", "Add Vector3", Relay_In_37)) return; 
         {
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)property_position_Detox_ScriptEditor_Parameter_position_61_Get_Refresh());
               logic_uScriptAct_AddVector3_A_37 = properties.ToArray();
            }
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_11_UnityEngine_Vector3);
               logic_uScriptAct_AddVector3_B_37 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_uScriptAct_AddVector3_37.In(logic_uScriptAct_AddVector3_A_37, logic_uScriptAct_AddVector3_B_37, out logic_uScriptAct_AddVector3_Result_37);
         local_67_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_Result_37;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_uScriptAct_AddVector3_37.Out;
         
         if ( test_0 == true )
         {
            Relay_Begin_25();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_38()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("da40dc5d-9415-43bc-9b03-ecc3cca739a7", "Play Animation", Relay_Finished_38)) return; 
         Relay_In_2();
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
         if (true == CheckDebugBreak("da40dc5d-9415-43bc-9b03-ecc3cca739a7", "Play Animation", Relay_In_38)) return; 
         {
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
               logic_uScriptAct_PlayAnimation_Target_38 = properties.ToArray();
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
         logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_38.In(logic_uScriptAct_PlayAnimation_Target_38, logic_uScriptAct_PlayAnimation_Animation_38, logic_uScriptAct_PlayAnimation_SpeedFactor_38, logic_uScriptAct_PlayAnimation_AnimWrapMode_38, logic_uScriptAct_PlayAnimation_StopOtherAnimations_38);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_41()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8cc0a5ea-0dba-4f69-8c3d-e10b9a141ede", "Add Vector3", Relay_In_41)) return; 
         {
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)property_position_Detox_ScriptEditor_Parameter_position_23_Get_Refresh());
               logic_uScriptAct_AddVector3_A_41 = properties.ToArray();
            }
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_69_UnityEngine_Vector3);
               logic_uScriptAct_AddVector3_B_41 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_uScriptAct_AddVector3_41.In(logic_uScriptAct_AddVector3_A_41, logic_uScriptAct_AddVector3_B_41, out logic_uScriptAct_AddVector3_Result_41);
         local_3_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_Result_41;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_uScriptAct_AddVector3_41.Out;
         
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
   
   void Relay_In_42()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("64ffff61-5294-4a16-adf7-16138a39f264", "Compare String", Relay_In_42)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_42 = local_29_System_String;
               
            }
            {
               logic_uScriptCon_CompareString_B_42 = local_9_System_String;
               
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_42.In(logic_uScriptCon_CompareString_A_42, logic_uScriptCon_CompareString_B_42);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_42.Same;
         
         if ( test_0 == true )
         {
            Relay_SendCustomEvent_28();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_43()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("68d8153a-787d-4adf-9893-32f629ba6aef", "Set Bool", Relay_True_43)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_43.True(out logic_uScriptAct_SetBool_Target_43);
         local_Door1_Open__System_Boolean = logic_uScriptAct_SetBool_Target_43;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_43.Out;
         
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
   
   void Relay_False_43()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("68d8153a-787d-4adf-9893-32f629ba6aef", "Set Bool", Relay_False_43)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_43.False(out logic_uScriptAct_SetBool_Target_43);
         local_Door1_Open__System_Boolean = logic_uScriptAct_SetBool_Target_43;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_43.Out;
         
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
   
   void Relay_In_46()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("af90b800-73ec-4229-955f-4f81833a4602", "Compare Bool", Relay_In_46)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_46 = local_Has_Key_System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_46.In(logic_uScriptCon_CompareBool_Bool_46);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_46.True;
         bool test_1 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_46.False;
         
         if ( test_0 == true )
         {
            Relay_HideLabel_26();
            Relay_ShowLabel_7();
         }
         if ( test_1 == true )
         {
            Relay_HideLabel_7();
            Relay_ShowLabel_26();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_52()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("28a9f34b-26f0-45c4-9bd9-2a14ee537202", "Set Bool", Relay_True_52)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_52.True(out logic_uScriptAct_SetBool_Target_52);
         local_Door2_Open__System_Boolean = logic_uScriptAct_SetBool_Target_52;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_52()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("28a9f34b-26f0-45c4-9bd9-2a14ee537202", "Set Bool", Relay_False_52)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_52.False(out logic_uScriptAct_SetBool_Target_52);
         local_Door2_Open__System_Boolean = logic_uScriptAct_SetBool_Target_52;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_53()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("267c6992-8358-4302-9be3-501293f06295", "Compare Bool", Relay_In_53)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_53 = local_Door2_Open__System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_53.In(logic_uScriptCon_CompareBool_Bool_53);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_53.False;
         
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
   
   void Relay_In_55()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("986204f6-2143-41b9-83e1-c0f292a8934b", "Add Vector3", Relay_In_55)) return; 
         {
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)property_position_Detox_ScriptEditor_Parameter_position_79_Get_Refresh());
               logic_uScriptAct_AddVector3_A_55 = properties.ToArray();
            }
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_81_UnityEngine_Vector3);
               logic_uScriptAct_AddVector3_B_55 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_uScriptAct_AddVector3_55.In(logic_uScriptAct_AddVector3_A_55, logic_uScriptAct_AddVector3_B_55, out logic_uScriptAct_AddVector3_Result_55);
         local_33_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_Result_55;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_uScriptAct_AddVector3_55.Out;
         
         if ( test_0 == true )
         {
            Relay_Begin_13();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_60()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e7887f30-b0c2-44df-a613-e5a6765bfb40", "Compare Bool", Relay_In_60)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_60 = local_Door1_Open__System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_60.In(logic_uScriptCon_CompareBool_Bool_60);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_60.False;
         
         if ( test_0 == true )
         {
            Relay_True_43();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_64()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("05a0be28-3ce9-4ab5-828c-54d6a216e1b3", "Compare Bool", Relay_In_64)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_64 = local_Has_Key_System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_64.In(logic_uScriptCon_CompareBool_Bool_64);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_64.True;
         
         if ( test_0 == true )
         {
            Relay_In_78();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnEnterTrigger_65()
   {
      if (true == CheckDebugBreak("d2b4691c-bb9f-4f9d-b8e6-bbe11debd9d4", "Trigger Events", Relay_OnEnterTrigger_65)) return; 
      Relay_In_53();
   }
   
   void Relay_OnExitTrigger_65()
   {
      if (true == CheckDebugBreak("d2b4691c-bb9f-4f9d-b8e6-bbe11debd9d4", "Trigger Events", Relay_OnExitTrigger_65)) return; 
   }
   
   void Relay_WhileInsideTrigger_65()
   {
      if (true == CheckDebugBreak("d2b4691c-bb9f-4f9d-b8e6-bbe11debd9d4", "Trigger Events", Relay_WhileInsideTrigger_65)) return; 
   }
   
   void Relay_In_71()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6dd82d6c-c2dd-4b6d-8be1-781c4360bf30", "Set Color", Relay_In_71)) return; 
         {
            {
            }
            {
            }
         }
         logic_uScriptAct_SetColor_uScriptAct_SetColor_71.In(logic_uScriptAct_SetColor_Value_71, out logic_uScriptAct_SetColor_TargetColor_71);
         property_color_Detox_ScriptEditor_Parameter_color_27 = logic_uScriptAct_SetColor_TargetColor_71;
         property_color_Detox_ScriptEditor_Parameter_color_27_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetColor_uScriptAct_SetColor_71.Out;
         
         if ( test_0 == true )
         {
            Relay_In_37();
            Relay_In_55();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Color.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_72()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c5f04559-5697-4bdb-b519-fb2556359cdb", "Delay", Relay_In_72)) return; 
         {
            {
               logic_uScriptAct_Delay_Duration_72 = local_14_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_72.In(logic_uScriptAct_Delay_Duration_72, logic_uScriptAct_Delay_SingleFrame_72);
         logic_uScriptAct_Delay_DrivenDelay_72 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_72.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_In_41();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_DrivenDelay_72( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               logic_uScriptAct_Delay_Duration_72 = local_14_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_Delay_DrivenDelay_72 = logic_uScriptAct_Delay_uScriptAct_Delay_72.DrivenDelay();
         if ( true == logic_uScriptAct_Delay_DrivenDelay_72 )
         {
            if ( logic_uScriptAct_Delay_uScriptAct_Delay_72.AfterDelay == true )
            {
               Relay_In_41();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_Finished_73()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b64730f3-9ee9-4d97-a644-ad01f0e801dc", "Move To Location", Relay_Finished_73)) return; 
         Relay_In_72();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Move To Location.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_73()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b64730f3-9ee9-4d97-a644-ad01f0e801dc", "Move To Location", Relay_In_73)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_36_UnityEngine_GameObject_previous != local_36_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_36_UnityEngine_GameObject_previous = local_36_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_36_UnityEngine_GameObject);
               logic_uScriptAct_MoveToLocation_targetArray_73 = properties.ToArray();
            }
            {
               logic_uScriptAct_MoveToLocation_location_73 = local_4_UnityEngine_Vector3;
               
            }
            {
            }
            {
               logic_uScriptAct_MoveToLocation_totalTime_73 = local_74_System_Single;
               
            }
         }
         logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_73.In(logic_uScriptAct_MoveToLocation_targetArray_73, logic_uScriptAct_MoveToLocation_location_73, logic_uScriptAct_MoveToLocation_asOffset_73, logic_uScriptAct_MoveToLocation_totalTime_73);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Move To Location.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Cancel_73()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b64730f3-9ee9-4d97-a644-ad01f0e801dc", "Move To Location", Relay_Cancel_73)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_36_UnityEngine_GameObject_previous != local_36_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_36_UnityEngine_GameObject_previous = local_36_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_36_UnityEngine_GameObject);
               logic_uScriptAct_MoveToLocation_targetArray_73 = properties.ToArray();
            }
            {
               logic_uScriptAct_MoveToLocation_location_73 = local_4_UnityEngine_Vector3;
               
            }
            {
            }
            {
               logic_uScriptAct_MoveToLocation_totalTime_73 = local_74_System_Single;
               
            }
         }
         logic_uScriptAct_MoveToLocation_uScriptAct_MoveToLocation_73.Cancel(logic_uScriptAct_MoveToLocation_targetArray_73, logic_uScriptAct_MoveToLocation_location_73, logic_uScriptAct_MoveToLocation_asOffset_73, logic_uScriptAct_MoveToLocation_totalTime_73);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Move To Location.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_78()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("70c79920-e6f9-4497-b101-bee29c15e5e6", "Compare Bool", Relay_In_78)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_78 = local_Door3_Open__System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_78.In(logic_uScriptCon_CompareBool_Bool_78);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_78.False;
         
         if ( test_0 == true )
         {
            Relay_True_19();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_83()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e4d27f13-84e7-4482-a6e7-4219cadd2135", "Set Bool", Relay_True_83)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_83.True(out logic_uScriptAct_SetBool_Target_83);
         local_Door1_Open__System_Boolean = logic_uScriptAct_SetBool_Target_83;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_83()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e4d27f13-84e7-4482-a6e7-4219cadd2135", "Set Bool", Relay_False_83)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_83.False(out logic_uScriptAct_SetBool_Target_83);
         local_Door1_Open__System_Boolean = logic_uScriptAct_SetBool_Target_83;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_MainGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnCustomEvent_84()
   {
      if (true == CheckDebugBreak("7c353773-7eea-4de6-b7f2-d4acff6754fa", "Custom Event", Relay_OnCustomEvent_84)) return; 
      local_29_System_String = event_UnityEngine_GameObject_EventName_84;
      Relay_In_42();
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
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:11", local_11_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "976ad023-bacd-418f-86a8-a107515d89d4", local_11_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:12", local_12_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f3d11ba1-bda3-47f3-86a5-70d7cc71bd09", local_12_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:14", local_14_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "365cf50f-3961-4532-a476-58ad302756c6", local_14_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:17", local_17_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "203fda8c-1fc2-4f71-b733-7fb527538e6f", local_17_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:29", local_29_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "fe5acf83-7161-49c4-8077-f48289c24d35", local_29_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:33", local_33_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "aca18670-c8aa-47ad-8929-2f96733498ac", local_33_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:36", local_36_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a091fb03-4149-4899-aad0-7c4d720de37d", local_36_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:40", local_40_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "2c3a04b0-d989-4fa1-a1b0-d3a1e6c547d8", local_40_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:44", local_44_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7f3d5c57-1c28-4ba0-8e0e-8f63c786a246", local_44_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:Door3 Open?", local_Door3_Open__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "5273341d-fac2-464d-a6f4-e7516763909c", local_Door3_Open__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:50", local_50_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "2ce35273-e2c8-4d67-89a1-e4b13a6a2c64", local_50_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:51", local_51_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "eda6602c-b027-41c2-8378-1b469ff098b7", local_51_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:Has Key", local_Has_Key_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a7776564-bc58-4587-b1de-77f563e09eb0", local_Has_Key_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:59", local_59_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b419549b-2d0f-4e57-834e-593936f338a7", local_59_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:62", local_62_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "21cbeb00-b0da-4a75-bd86-6c7032622bc8", local_62_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:63", local_63_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "32135b0b-80fc-43df-a626-60cd0d767314", local_63_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:67", local_67_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d076fe87-3088-4576-9f08-eb2d49f080f5", local_67_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:Door2 Open?", local_Door2_Open__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ec996f89-f41b-4cfb-a0e0-62dd759a821e", local_Door2_Open__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:69", local_69_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ca1353d3-2ed8-4ee1-a1f7-bfd56c71300c", local_69_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:70", local_70_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "af5630c1-c765-4e87-8445-94f98dc2f3a9", local_70_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:74", local_74_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b1073fd0-b85b-4041-b56a-0349eac44672", local_74_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:76", local_76_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "5621150a-66e9-40bb-8c78-14ee44815ffb", local_76_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:77", local_77_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "19ce721b-1c55-4c92-a175-846d1c54bb21", local_77_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:81", local_81_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "4983f4bf-f59e-4350-be28-3cf448dd9f31", local_81_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_MainGraph.uscript:Door1 Open?", local_Door1_Open__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7f44a938-631c-467a-9311-171718fe55fc", local_Door1_Open__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "097baa99-2bc2-478b-915b-f7a886da26af", property_position_Detox_ScriptEditor_Parameter_position_23);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a6825d91-b7df-4139-aa7e-2aae9c3b51be", property_color_Detox_ScriptEditor_Parameter_color_27);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b3acae1f-4743-4cf1-940d-40127aeeb29e", property_position_Detox_ScriptEditor_Parameter_position_34);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "aacfd7d2-9e52-4823-90da-5bd12c55fbae", property_position_Detox_ScriptEditor_Parameter_position_48);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "1fb07904-084d-4449-8353-4f42a45bd51e", property_position_Detox_ScriptEditor_Parameter_position_56);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "8369cb9b-d275-4c6e-a7cd-c8bfbbcfe3be", property_position_Detox_ScriptEditor_Parameter_position_61);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a4ca1f9d-3f20-44c1-ba9b-2e26d2ab0f48", property_position_Detox_ScriptEditor_Parameter_position_75);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "bb075d3f-a251-4e0d-bfcc-ae5675ec026b", property_position_Detox_ScriptEditor_Parameter_position_79);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ab45b753-0843-4c49-a65b-07c61cad8091", property_position_Detox_ScriptEditor_Parameter_position_85);
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
