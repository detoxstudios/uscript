//uScript Generated Code - Build 0.9.1661
//Generated with Debug Info
using UnityEngine;
using System.Collections;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class uScript_TestBed : uScriptLogic
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
   System.Single local_2_System_Single = (float) 90;
   System.Single local_12_System_Single = (float) 2;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_1 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_1 = "";
   System.Object[] logic_uScriptAct_Log_Target_1 = new System.Object[] {"Up"};
   System.Object logic_uScriptAct_Log_Postfix_1 = "";
   bool logic_uScriptAct_Log_Out_1 = true;
   //pointer to script instanced logic node
   uScriptAct_InterpolateFloatLinear logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4 = new uScriptAct_InterpolateFloatLinear( );
   System.Single logic_uScriptAct_InterpolateFloatLinear_startValue_4 = (float) 0;
   System.Single logic_uScriptAct_InterpolateFloatLinear_endValue_4 = (float) 0;
   System.Single logic_uScriptAct_InterpolateFloatLinear_time_4 = (float) 0;
   uScript_Lerper.LoopType logic_uScriptAct_InterpolateFloatLinear_loopType_4 = uScript_Lerper.LoopType.None;
   System.Single logic_uScriptAct_InterpolateFloatLinear_loopDelay_4 = (float) 0;
   System.Int32 logic_uScriptAct_InterpolateFloatLinear_loopCount_4 = (int) 0;
   System.Single logic_uScriptAct_InterpolateFloatLinear_currentValue_4;
   bool logic_uScriptAct_InterpolateFloatLinear_Started_4 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Stopped_4 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Interpolating_4 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Finished_4 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Driven_4 = false;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_6 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_6 = "";
   System.Object[] logic_uScriptAct_Log_Target_6 = new System.Object[] {"Down"};
   System.Object logic_uScriptAct_Log_Postfix_6 = "";
   bool logic_uScriptAct_Log_Out_6 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_7 = new uScriptAct_Delay( );
   System.Single logic_uScriptAct_Delay_Duration_7 = (float) 1;
   bool logic_uScriptAct_Delay_Immediate_7 = true;
   bool logic_uScriptAct_Delay_AfterDelay_7 = true;
   bool logic_uScriptAct_Delay_DrivenDelay_7 = false;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_8 = UnityEngine.KeyCode.A;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_8 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_8 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_8 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_9 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_9 = "";
   System.Object[] logic_uScriptAct_Log_Target_9 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_9 = "";
   bool logic_uScriptAct_Log_Out_9 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_10 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_10 = "";
   System.Object[] logic_uScriptAct_Log_Target_10 = new System.Object[] {"Start FOV"};
   System.Object logic_uScriptAct_Log_Postfix_10 = "";
   bool logic_uScriptAct_Log_Out_10 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_13 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_13 = "";
   System.Object[] logic_uScriptAct_Log_Target_13 = new System.Object[] {"End FOV"};
   System.Object logic_uScriptAct_Log_Postfix_13 = "";
   bool logic_uScriptAct_Log_Out_13 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_3 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_11 = null;
   
   //property nodes
   System.Single property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_0 = (float) 0;
   UnityEngine.GameObject property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_0 = null;
   System.Single property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_5 = (float) 0;
   UnityEngine.GameObject property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_5 = null;
   
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
   
}
