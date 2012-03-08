//uScript Generated Code - Build 0.9.1661
//Generated with Debug Info
using UnityEngine;
using System.Collections;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class uScript_StressTest : uScriptLogic
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
   UnityEngine.GameObject local_0_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_0_UnityEngine_GameObject_previous = null;
   System.String local_2_System_String = "Area Damage";
   System.Int32 local_5_System_Int32 = (int) 0;
   UnityEngine.GameObject local_6_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_6_UnityEngine_GameObject_previous = null;
   System.Int32 local_9_System_Int32 = (int) 0;
   System.Boolean local_15_System_Boolean = (bool) false;
   UnityEngine.GameObject local_17_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_17_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Cover3_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Cover3_UnityEngine_GameObject_previous = null;
   System.Boolean local_22_System_Boolean = (bool) false;
   System.Single local_25_System_Single = (float) 3;
   UnityEngine.GameObject local_26_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_26_UnityEngine_GameObject_previous = null;
   System.String local_34_System_String = "Area Damage";
   UnityEngine.GameObject local_35_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_35_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_45_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_45_UnityEngine_GameObject_previous = null;
   System.Int32 local_49_System_Int32 = (int) 0;
   System.Int32 local_53_System_Int32 = (int) 0;
   UnityEngine.GameObject local_54_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_54_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Cover1_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Cover1_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_69_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_69_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Cover2_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Cover2_UnityEngine_GameObject_previous = null;
   System.String local_86_System_String = "";
   UnityEngine.GameObject local_88_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_88_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Monster_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Monster_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_94_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_94_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_105_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_105_UnityEngine_GameObject_previous = null;
   System.Int32 local_113_System_Int32 = (int) 0;
   System.String local_119_System_String = "Ogre";
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_1 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_1 = "";
   System.Object[] logic_uScriptAct_Log_Target_1 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_1 = "";
   bool logic_uScriptAct_Log_Out_1 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_14 = new uScriptCon_IntCounter( );
   System.Int32 logic_uScriptCon_IntCounter_A_14 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_B_14 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_14;
   bool logic_uScriptCon_IntCounter_GreaterThan_14 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_14 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_14 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_14 = true;
   bool logic_uScriptCon_IntCounter_LessThan_14 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_16 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_16 = "";
   System.Object[] logic_uScriptAct_Log_Target_16 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_16 = "";
   bool logic_uScriptAct_Log_Out_16 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_19 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_19 = "";
   System.Object[] logic_uScriptAct_Log_Target_19 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_19 = "";
   bool logic_uScriptAct_Log_Out_19 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_28 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_28 = "";
   System.Object[] logic_uScriptAct_Log_Target_28 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_28 = "";
   bool logic_uScriptAct_Log_Out_28 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_36 = new uScriptCon_IntCounter( );
   System.Int32 logic_uScriptCon_IntCounter_A_36 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_B_36 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_36;
   bool logic_uScriptCon_IntCounter_GreaterThan_36 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_36 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_36 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_36 = true;
   bool logic_uScriptCon_IntCounter_LessThan_36 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_43 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_43 = "";
   System.Object[] logic_uScriptAct_Log_Target_43 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_43 = "";
   bool logic_uScriptAct_Log_Out_43 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_55 = new uScriptAct_PlaySound( );
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_55 = null;
   UnityEngine.GameObject[] logic_uScriptAct_PlaySound_target_55 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_PlaySound_volume_55 = (float) 0;
   System.Boolean logic_uScriptAct_PlaySound_loop_55 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_55 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_63 = new uScriptAct_Delay( );
   System.Single logic_uScriptAct_Delay_Duration_63 = (float) 0;
   bool logic_uScriptAct_Delay_Immediate_63 = true;
   bool logic_uScriptAct_Delay_AfterDelay_63 = true;
   bool logic_uScriptAct_Delay_DrivenDelay_63 = false;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_64 = new uScriptAct_Delay( );
   System.Single logic_uScriptAct_Delay_Duration_64 = (float) 0;
   bool logic_uScriptAct_Delay_Immediate_64 = true;
   bool logic_uScriptAct_Delay_AfterDelay_64 = true;
   bool logic_uScriptAct_Delay_DrivenDelay_64 = false;
   //pointer to script instanced logic node
   uScriptAct_DestroyComponent logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_65 = new uScriptAct_DestroyComponent( );
   UnityEngine.GameObject[] logic_uScriptAct_DestroyComponent_Target_65 = new UnityEngine.GameObject[] {};
   System.String[] logic_uScriptAct_DestroyComponent_ComponentName_65 = new System.String[] {};
   System.Single logic_uScriptAct_DestroyComponent_DelayTime_65 = (float) 0;
   bool logic_uScriptAct_DestroyComponent_Out_65 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_67 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_67 = "";
   System.Object[] logic_uScriptAct_Log_Target_67 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_67 = "";
   bool logic_uScriptAct_Log_Out_67 = true;
   //pointer to script instanced logic node
   uScriptAct_DestroyComponent logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_68 = new uScriptAct_DestroyComponent( );
   UnityEngine.GameObject[] logic_uScriptAct_DestroyComponent_Target_68 = new UnityEngine.GameObject[] {};
   System.String[] logic_uScriptAct_DestroyComponent_ComponentName_68 = new System.String[] {};
   System.Single logic_uScriptAct_DestroyComponent_DelayTime_68 = (float) 0;
   bool logic_uScriptAct_DestroyComponent_Out_68 = true;
   //pointer to script instanced logic node
   uScriptAct_Toggle logic_uScriptAct_Toggle_uScriptAct_Toggle_70 = new uScriptAct_Toggle( );
   UnityEngine.GameObject[] logic_uScriptAct_Toggle_Target_70 = new UnityEngine.GameObject[] {};
   System.Boolean logic_uScriptAct_Toggle_IgnoreChildren_70 = (bool) false;
   bool logic_uScriptAct_Toggle_Out_70 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_72 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_72 = "";
   System.Object[] logic_uScriptAct_Log_Target_72 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_72 = "";
   bool logic_uScriptAct_Log_Out_72 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_74 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_74 = "";
   System.Object[] logic_uScriptAct_Log_Target_74 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_74 = "";
   bool logic_uScriptAct_Log_Out_74 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_75 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_75 = "";
   System.Object[] logic_uScriptAct_Log_Target_75 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_75 = "";
   bool logic_uScriptAct_Log_Out_75 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_76 = new uScriptAct_PlaySound( );
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_76 = null;
   UnityEngine.GameObject[] logic_uScriptAct_PlaySound_target_76 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_PlaySound_volume_76 = (float) 0;
   System.Boolean logic_uScriptAct_PlaySound_loop_76 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_76 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_80 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_80 = UnityEngine.KeyCode.None;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_80 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_80 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_80 = true;
   //pointer to script instanced logic node
   uScriptAct_LookAt logic_uScriptAct_LookAt_uScriptAct_LookAt_83 = new uScriptAct_LookAt( );
   UnityEngine.GameObject[] logic_uScriptAct_LookAt_Target_83 = new UnityEngine.GameObject[] {};
   System.Object logic_uScriptAct_LookAt_Focus_83 = "";
   System.Single logic_uScriptAct_LookAt_time_83 = (float) 0;
   uScriptAct_LookAt.LockAxis logic_uScriptAct_LookAt_lockAxis_83 = uScriptAct_LookAt.LockAxis.None;
   bool logic_uScriptAct_LookAt_Out_83 = true;
   //pointer to script instanced logic node
   uScriptAct_LookAt logic_uScriptAct_LookAt_uScriptAct_LookAt_89 = new uScriptAct_LookAt( );
   UnityEngine.GameObject[] logic_uScriptAct_LookAt_Target_89 = new UnityEngine.GameObject[] {};
   System.Object logic_uScriptAct_LookAt_Focus_89 = "";
   System.Single logic_uScriptAct_LookAt_time_89 = (float) 0;
   uScriptAct_LookAt.LockAxis logic_uScriptAct_LookAt_lockAxis_89 = uScriptAct_LookAt.LockAxis.None;
   bool logic_uScriptAct_LookAt_Out_89 = true;
   //pointer to script instanced logic node
   uScriptAct_Teleport logic_uScriptAct_Teleport_uScriptAct_Teleport_96 = new uScriptAct_Teleport( );
   UnityEngine.GameObject[] logic_uScriptAct_Teleport_Target_96 = new UnityEngine.GameObject[] {};
   UnityEngine.GameObject logic_uScriptAct_Teleport_Destination_96 = null;
   System.Boolean logic_uScriptAct_Teleport_UpdateRotation_96 = (bool) false;
   bool logic_uScriptAct_Teleport_Out_96 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_98 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_98 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_98 = true;
   bool logic_uScriptCon_CompareBool_False_98 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_103 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_103 = "";
   System.Object[] logic_uScriptAct_Log_Target_103 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_103 = "";
   bool logic_uScriptAct_Log_Out_103 = true;
   //pointer to script instanced logic node
   uScriptAct_Concatenate logic_uScriptAct_Concatenate_uScriptAct_Concatenate_107 = new uScriptAct_Concatenate( );
   System.Object[] logic_uScriptAct_Concatenate_A_107 = new System.Object[] {};
   System.Object[] logic_uScriptAct_Concatenate_B_107 = new System.Object[] {};
   System.String logic_uScriptAct_Concatenate_Separator_107 = "";
   System.String logic_uScriptAct_Concatenate_Result_107;
   bool logic_uScriptAct_Concatenate_Out_107 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_109 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_109 = UnityEngine.KeyCode.None;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_109 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_109 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_109 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_110 = new uScriptCon_IntCounter( );
   System.Int32 logic_uScriptCon_IntCounter_A_110 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_B_110 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_110;
   bool logic_uScriptCon_IntCounter_GreaterThan_110 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_110 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_110 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_110 = true;
   bool logic_uScriptCon_IntCounter_LessThan_110 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_115 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_115 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_115 = true;
   bool logic_uScriptCon_CompareBool_False_115 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_116 = new uScriptAct_PlaySound( );
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_116 = null;
   UnityEngine.GameObject[] logic_uScriptAct_PlaySound_target_116 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_PlaySound_volume_116 = (float) 0;
   System.Boolean logic_uScriptAct_PlaySound_loop_116 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_116 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_92 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_106 = null;
   
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
   
}
