//uScript Generated Code - Build 0.9.1661
//Generated with Debug Info
using UnityEngine;
using System.Collections;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("Untitled", "")]
public class FadeGraph : uScriptLogic
{

   #pragma warning disable 414
   GameObject parentGameObject = null;
   uScript_GUI thisScriptsOnGuiListener = null; 
   delegate void ContinueExecution();
   ContinueExecution m_ContinueExecution;
   bool m_Breakpoint = false;
   const int MaxRelayCallCount = 1000;
   int relayCallCount = 0;
   //external output properties
   
   //externally exposed events
   
   //external parameters
   
   //local nodes
   System.Single local_8_System_Single = (float) 0;
   UnityEngine.Color local_FadeColor_UnityEngine_Color = new UnityEngine.Color( (float)0, (float)0, (float)0, (float)1 );
   System.Single local_11_System_Single = (float) 0;
   UnityEngine.Color local_12_UnityEngine_Color = new UnityEngine.Color( (float)0, (float)0, (float)0, (float)1 );
   UnityEngine.GameObject local_FadeGO_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_FadeGO_UnityEngine_GameObject_previous = null;
   System.String local_19_System_String = "Health:";
   System.Single local_PlayerHealth_System_Single = (float) 100;
   System.String local_25_System_String = "";
   public UnityEngine.Material FadeMaterial = null;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_1 = new uScriptAct_Delay( );
   System.Single logic_uScriptAct_Delay_Duration_1 = (float) 1;
   bool logic_uScriptAct_Delay_Immediate_1 = true;
   bool logic_uScriptAct_Delay_AfterDelay_1 = true;
   bool logic_uScriptAct_Delay_DrivenDelay_1 = false;
   //pointer to script instanced logic node
   uScriptAct_GetGameObjectMaterial logic_uScriptAct_GetGameObjectMaterial_uScriptAct_GetGameObjectMaterial_2 = new uScriptAct_GetGameObjectMaterial( );
   UnityEngine.GameObject logic_uScriptAct_GetGameObjectMaterial_Target_2 = null;
   System.Int32 logic_uScriptAct_GetGameObjectMaterial_MaterialIndex_2 = (int) 0;
   UnityEngine.Material logic_uScriptAct_GetGameObjectMaterial_targetMaterial_2;
   UnityEngine.Color logic_uScriptAct_GetGameObjectMaterial_materialColor_2;
   System.String logic_uScriptAct_GetGameObjectMaterial_materialName_2;
   bool logic_uScriptAct_GetGameObjectMaterial_Out_2 = true;
   //pointer to script instanced logic node
   uScriptAct_SetColorAlpha logic_uScriptAct_SetColorAlpha_uScriptAct_SetColorAlpha_4 = new uScriptAct_SetColorAlpha( );
   UnityEngine.Color logic_uScriptAct_SetColorAlpha_Value_4 = UnityEngine.Color.black;
   System.Single logic_uScriptAct_SetColorAlpha_Alpha_4 = (float) 0;
   System.Boolean logic_uScriptAct_SetColorAlpha_Use8bitRange_4 = (bool) false;
   UnityEngine.Color logic_uScriptAct_SetColorAlpha_TargetColor_4;
   bool logic_uScriptAct_SetColorAlpha_Out_4 = true;
   //pointer to script instanced logic node
   uScriptAct_AssignMaterialColor logic_uScriptAct_AssignMaterialColor_uScriptAct_AssignMaterialColor_5 = new uScriptAct_AssignMaterialColor( );
   UnityEngine.GameObject[] logic_uScriptAct_AssignMaterialColor_Target_5 = new UnityEngine.GameObject[] {};
   UnityEngine.Color logic_uScriptAct_AssignMaterialColor_MatColor_5 = UnityEngine.Color.black;
   System.Int32 logic_uScriptAct_AssignMaterialColor_MatChannel_5 = (int) 0;
   bool logic_uScriptAct_AssignMaterialColor_Out_5 = true;
   //pointer to script instanced logic node
   uScriptAct_GetComponentsColor logic_uScriptAct_GetComponentsColor_uScriptAct_GetComponentsColor_7 = new uScriptAct_GetComponentsColor( );
   UnityEngine.Color logic_uScriptAct_GetComponentsColor_InputColor_7 = UnityEngine.Color.black;
   System.Single logic_uScriptAct_GetComponentsColor_Red_7;
   System.Single logic_uScriptAct_GetComponentsColor_Green_7;
   System.Single logic_uScriptAct_GetComponentsColor_Blue_7;
   System.Single logic_uScriptAct_GetComponentsColor_Alpha_7;
   bool logic_uScriptAct_GetComponentsColor_Out_7 = true;
   //pointer to script instanced logic node
   uScriptAct_InterpolateFloatLinear logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_9 = new uScriptAct_InterpolateFloatLinear( );
   System.Single logic_uScriptAct_InterpolateFloatLinear_startValue_9 = (float) 0;
   System.Single logic_uScriptAct_InterpolateFloatLinear_endValue_9 = (float) 0;
   System.Single logic_uScriptAct_InterpolateFloatLinear_time_9 = (float) 2;
   uScript_Lerper.LoopType logic_uScriptAct_InterpolateFloatLinear_loopType_9 = uScript_Lerper.LoopType.None;
   System.Single logic_uScriptAct_InterpolateFloatLinear_loopDelay_9 = (float) 0;
   System.Int32 logic_uScriptAct_InterpolateFloatLinear_loopCount_9 = (int) -1;
   System.Single logic_uScriptAct_InterpolateFloatLinear_currentValue_9;
   bool logic_uScriptAct_InterpolateFloatLinear_Started_9 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Stopped_9 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Interpolating_9 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Finished_9 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Driven_9 = false;
   //pointer to script instanced logic node
   uScriptAct_CameraFade logic_uScriptAct_CameraFade_uScriptAct_CameraFade_14 = new uScriptAct_CameraFade( );
   UnityEngine.Camera logic_uScriptAct_CameraFade_TargetCamera_14 = null;
   uScriptAct_CameraFade.FadeDirection logic_uScriptAct_CameraFade_Direction_14 = uScriptAct_CameraFade.FadeDirection.To;
   UnityEngine.Material logic_uScriptAct_CameraFade_FadeMaterial_14 = null;
   System.Single logic_uScriptAct_CameraFade_FadeTime_14 = (float) 2;
   System.Single logic_uScriptAct_CameraFade_HoldTime_14 = (float) 0;
   System.Boolean logic_uScriptAct_CameraFade_ColorOverride_14 = (bool) true;
   UnityEngine.Color logic_uScriptAct_CameraFade_FadeColor_14 = new UnityEngine.Color( (float)1, (float)0, (float)0, (float)1 );
   bool logic_uScriptAct_CameraFade_Immediate_14 = true;
   bool logic_uScriptAct_CameraFade_FadeFinished_14 = true;
   bool logic_uScriptAct_CameraFade_DrivenFade_14 = false;
   //pointer to script instanced logic node
   uScriptAct_Concatenate logic_uScriptAct_Concatenate_uScriptAct_Concatenate_17 = new uScriptAct_Concatenate( );
   System.Object[] logic_uScriptAct_Concatenate_A_17 = new System.Object[] {};
   System.Object[] logic_uScriptAct_Concatenate_B_17 = new System.Object[] {};
   System.String logic_uScriptAct_Concatenate_Separator_17 = "";
   System.String logic_uScriptAct_Concatenate_Result_17;
   bool logic_uScriptAct_Concatenate_Out_17 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_18 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_18 = "";
   System.Int32 logic_uScriptAct_PrintText_FontSize_18 = (int) 16;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_18 = UnityEngine.FontStyle.Normal;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_18 = new UnityEngine.Color( (float)0, (float)0, (float)0, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_18 = UnityEngine.TextAnchor.UpperLeft;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_18 = (int) 8;
   System.Single logic_uScriptAct_PrintText_time_18 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_18 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareFloat logic_uScriptCon_CompareFloat_uScriptCon_CompareFloat_21 = new uScriptCon_CompareFloat( );
   System.Single logic_uScriptCon_CompareFloat_A_21 = (float) 0;
   System.Single logic_uScriptCon_CompareFloat_B_21 = (float) 0;
   bool logic_uScriptCon_CompareFloat_GreaterThan_21 = true;
   bool logic_uScriptCon_CompareFloat_GreaterThanOrEqualTo_21 = true;
   bool logic_uScriptCon_CompareFloat_EqualTo_21 = true;
   bool logic_uScriptCon_CompareFloat_NotEqualTo_21 = true;
   bool logic_uScriptCon_CompareFloat_LessThanOrEqualTo_21 = true;
   bool logic_uScriptCon_CompareFloat_LessThan_21 = true;
   //pointer to script instanced logic node
   uScriptAct_SetFloat logic_uScriptAct_SetFloat_uScriptAct_SetFloat_23 = new uScriptAct_SetFloat( );
   System.Single logic_uScriptAct_SetFloat_Value_23 = (float) 0;
   System.Single logic_uScriptAct_SetFloat_Target_23;
   bool logic_uScriptAct_SetFloat_Out_23 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_26 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_26 = "Camera Fade - Immediate Out";
   System.Object[] logic_uScriptAct_Log_Target_26 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_26 = "";
   bool logic_uScriptAct_Log_Out_26 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_27 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_27 = "Camera Fade - Finished Out";
   System.Object[] logic_uScriptAct_Log_Target_27 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_27 = "";
   bool logic_uScriptAct_Log_Out_27 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_28 = new uScriptAct_Delay( );
   System.Single logic_uScriptAct_Delay_Duration_28 = (float) 2;
   bool logic_uScriptAct_Delay_Immediate_28 = true;
   bool logic_uScriptAct_Delay_AfterDelay_28 = true;
   bool logic_uScriptAct_Delay_DrivenDelay_28 = false;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_29 = new uScriptAct_Delay( );
   System.Single logic_uScriptAct_Delay_Duration_29 = (float) 2;
   bool logic_uScriptAct_Delay_Immediate_29 = true;
   bool logic_uScriptAct_Delay_AfterDelay_29 = true;
   bool logic_uScriptAct_Delay_DrivenDelay_29 = false;
   //pointer to script instanced logic node
   uScriptAct_CameraFade logic_uScriptAct_CameraFade_uScriptAct_CameraFade_30 = new uScriptAct_CameraFade( );
   UnityEngine.Camera logic_uScriptAct_CameraFade_TargetCamera_30 = null;
   uScriptAct_CameraFade.FadeDirection logic_uScriptAct_CameraFade_Direction_30 = uScriptAct_CameraFade.FadeDirection.From;
   UnityEngine.Material logic_uScriptAct_CameraFade_FadeMaterial_30 = null;
   System.Single logic_uScriptAct_CameraFade_FadeTime_30 = (float) 2;
   System.Single logic_uScriptAct_CameraFade_HoldTime_30 = (float) 0;
   System.Boolean logic_uScriptAct_CameraFade_ColorOverride_30 = (bool) true;
   UnityEngine.Color logic_uScriptAct_CameraFade_FadeColor_30 = new UnityEngine.Color( (float)1, (float)0, (float)0, (float)1 );
   bool logic_uScriptAct_CameraFade_Immediate_30 = true;
   bool logic_uScriptAct_CameraFade_FadeFinished_30 = true;
   bool logic_uScriptAct_CameraFade_DrivenFade_30 = false;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_0 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_16 = null;
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   public void Awake()
   {
   }
   
   public void Start()
   {
   }
   
   public void Update()
   {
   }
   
   public void OnDestroy()
   {
   }
   
   public void OnGUI()
   {
   }
   
}
