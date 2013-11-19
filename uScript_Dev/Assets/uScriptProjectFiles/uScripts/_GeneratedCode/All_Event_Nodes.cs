//uScript Generated Code - Build 0.9.2439
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("Untitled", "")]
public class All_Event_Nodes : uScriptLogic
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
   System.String local_100_System_String = "Event fired - Managed Input Events";
   System.String local_102_System_String = "Event fired - Mouse Axis";
   System.String local_105_System_String = "Event fired - Mouse Cursor Events";
   System.String local_106_System_String = "Event fired - On-Screen Keyboard Events";
   System.String local_108_System_String = "Event fired - Touch Events";
   System.String local_118_System_String = "Event fired - Network Client Connection";
   System.String local_119_System_String = "Event fired - Network Failed Connection";
   System.String local_121_System_String = "Event fired - Network Instantiate";
   System.String local_123_System_String = "Event fired - Network Serialization";
   System.String local_126_System_String = "Event fired - Network Server Initialized";
   System.String local_127_System_String = "Event fired - Network Server Player";
   System.String local_129_System_String = "Event fired - Network Master Server";
   System.String local_18_System_String = "Event fired - Application Quit";
   System.String local_20_System_String = "Event fired - Application Focus";
   System.String local_21_System_String = "Event fired - Custom Event";
   System.String local_24_System_String = "Event fired - Custom Event (Bool)";
   System.String local_26_System_String = "Event fired - Custom Event (Color)";
   System.String local_262_System_String = "Event fired - Particle Collision";
   System.String local_269_System_String = "Event fired - On Collision";
   System.String local_272_System_String = "Event fired - Joint Break";
   System.String local_275_System_String = "Event fired - Controller Collision";
   System.String local_28_System_String = "Event fired - Custom Event (Float)";
   System.String local_285_System_String = "Event fired - Render Events";
   System.String local_288_System_String = "Event fired - Post Effect Events";
   UnityEngine.GameObject local_297_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_297_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_299_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_299_UnityEngine_GameObject_previous = null;
   System.String local_30_System_String = "Event fired - Custom Event (GameObject)";
   UnityEngine.GameObject local_301_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_301_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_303_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_303_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_305_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_305_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_307_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_307_UnityEngine_GameObject_previous = null;
   System.String local_31_System_String = "Event fired - Custom Event (Int)";
   UnityEngine.GameObject local_310_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_310_UnityEngine_GameObject_previous = null;
   System.String local_312_System_String = "Event fired - Trigger Events";
   System.String local_34_System_String = "Event fired - Custom Event (Object)";
   UnityEngine.GameObject local_35_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_35_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_36_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_36_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_37_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_37_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_38_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_38_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_39_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_39_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_40_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_40_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_41_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_41_UnityEngine_GameObject_previous = null;
   System.String local_43_System_String = "Event fired - Custom Event (String)";
   UnityEngine.GameObject local_44_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_44_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_45_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_45_UnityEngine_GameObject_previous = null;
   System.String local_47_System_String = "Event fired - Custom Event (Vector2)";
   UnityEngine.GameObject local_48_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_48_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_49_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_49_UnityEngine_GameObject_previous = null;
   System.String local_51_System_String = "Event fired - Custom Event (Vector3)";
   System.String local_53_System_String = "Event fired - Custom Event (Vector4)";
   System.String local_55_System_String = "Event fired - Global Update (Update)";
   System.Int32 local_57_System_Int32 = (int) 0;
   System.String local_59_System_String = "Event fired - GUI Events";
   System.Int32 local_62_System_Int32 = (int) 0;
   System.String local_64_System_String = "Event fired - Level Load";
   System.String local_66_System_String = "Event fired - uScript Events";
   System.String local_70_System_String = "Event fired - GameObject Events";
   System.String local_73_System_String = "Event fired - Visibility Events";
   UnityEngine.GameObject local_74_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_74_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_75_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_75_UnityEngine_GameObject_previous = null;
   System.String local_85_System_String = "Event fired - Accelerometer Events";
   System.String local_87_System_String = "Event fired - Device Orientation Events";
   System.Int32 local_91_System_Int32 = (int) 0;
   System.String local_92_System_String = "Event fired - Global Update (LateUpdate)";
   System.Int32 local_96_System_Int32 = (int) 0;
   System.String local_97_System_String = "Event fired - Global Update (FixedUpdate)";
   System.String local_99_System_String = "Event fired - Input Events";
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_17 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_17 = "";
   System.Object[] logic_uScriptAct_Log_Target_17 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_17 = "";
   bool logic_uScriptAct_Log_Out_17 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_19 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_19 = "";
   System.Object[] logic_uScriptAct_Log_Target_19 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_19 = "";
   bool logic_uScriptAct_Log_Out_19 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_22 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_22 = "";
   System.Object[] logic_uScriptAct_Log_Target_22 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_22 = "";
   bool logic_uScriptAct_Log_Out_22 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_23 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_23 = "";
   System.Object[] logic_uScriptAct_Log_Target_23 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_23 = "";
   bool logic_uScriptAct_Log_Out_23 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_25 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_25 = "";
   System.Object[] logic_uScriptAct_Log_Target_25 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_25 = "";
   bool logic_uScriptAct_Log_Out_25 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_27 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_27 = "";
   System.Object[] logic_uScriptAct_Log_Target_27 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_27 = "";
   bool logic_uScriptAct_Log_Out_27 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_29 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_29 = "";
   System.Object[] logic_uScriptAct_Log_Target_29 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_29 = "";
   bool logic_uScriptAct_Log_Out_29 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_32 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_32 = "";
   System.Object[] logic_uScriptAct_Log_Target_32 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_32 = "";
   bool logic_uScriptAct_Log_Out_32 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_33 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_33 = "";
   System.Object[] logic_uScriptAct_Log_Target_33 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_33 = "";
   bool logic_uScriptAct_Log_Out_33 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_42 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_42 = "";
   System.Object[] logic_uScriptAct_Log_Target_42 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_42 = "";
   bool logic_uScriptAct_Log_Out_42 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_46 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_46 = "";
   System.Object[] logic_uScriptAct_Log_Target_46 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_46 = "";
   bool logic_uScriptAct_Log_Out_46 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_50 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_50 = "";
   System.Object[] logic_uScriptAct_Log_Target_50 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_50 = "";
   bool logic_uScriptAct_Log_Out_50 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_52 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_52 = "";
   System.Object[] logic_uScriptAct_Log_Target_52 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_52 = "";
   bool logic_uScriptAct_Log_Out_52 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_54 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_54 = "";
   System.Object[] logic_uScriptAct_Log_Target_54 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_54 = "";
   bool logic_uScriptAct_Log_Out_54 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_56 = new uScriptCon_IntCounter( );
   System.Int32 logic_uScriptCon_IntCounter_A_56 = (int) 1;
   System.Int32 logic_uScriptCon_IntCounter_B_56 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_56;
   bool logic_uScriptCon_IntCounter_GreaterThan_56 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_56 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_56 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_56 = true;
   bool logic_uScriptCon_IntCounter_LessThan_56 = true;
   //pointer to script instanced logic node
   uScriptAct_AddInt logic_uScriptAct_AddInt_uScriptAct_AddInt_58 = new uScriptAct_AddInt( );
   System.Int32[] logic_uScriptAct_AddInt_A_58 = new System.Int32[] {};
   System.Int32[] logic_uScriptAct_AddInt_B_58 = new System.Int32[] {1};
   System.Int32 logic_uScriptAct_AddInt_IntResult_58;
   System.Single logic_uScriptAct_AddInt_FloatResult_58;
   bool logic_uScriptAct_AddInt_Out_58 = true;
   //pointer to script instanced logic node
   uScriptAct_AddInt logic_uScriptAct_AddInt_uScriptAct_AddInt_60 = new uScriptAct_AddInt( );
   System.Int32[] logic_uScriptAct_AddInt_A_60 = new System.Int32[] {};
   System.Int32[] logic_uScriptAct_AddInt_B_60 = new System.Int32[] {1};
   System.Int32 logic_uScriptAct_AddInt_IntResult_60;
   System.Single logic_uScriptAct_AddInt_FloatResult_60;
   bool logic_uScriptAct_AddInt_Out_60 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_61 = new uScriptCon_IntCounter( );
   System.Int32 logic_uScriptCon_IntCounter_A_61 = (int) 1;
   System.Int32 logic_uScriptCon_IntCounter_B_61 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_61;
   bool logic_uScriptCon_IntCounter_GreaterThan_61 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_61 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_61 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_61 = true;
   bool logic_uScriptCon_IntCounter_LessThan_61 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_63 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_63 = "";
   System.Object[] logic_uScriptAct_Log_Target_63 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_63 = "";
   bool logic_uScriptAct_Log_Out_63 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_65 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_65 = "";
   System.Object[] logic_uScriptAct_Log_Target_65 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_65 = "";
   bool logic_uScriptAct_Log_Out_65 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_67 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_67 = "";
   System.Object[] logic_uScriptAct_Log_Target_67 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_67 = "";
   bool logic_uScriptAct_Log_Out_67 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_71 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_71 = "";
   System.Object[] logic_uScriptAct_Log_Target_71 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_71 = "";
   bool logic_uScriptAct_Log_Out_71 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_72 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_72 = "";
   System.Object[] logic_uScriptAct_Log_Target_72 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_72 = "";
   bool logic_uScriptAct_Log_Out_72 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_84 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_84 = "";
   System.Object[] logic_uScriptAct_Log_Target_84 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_84 = "";
   bool logic_uScriptAct_Log_Out_84 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_86 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_86 = "";
   System.Object[] logic_uScriptAct_Log_Target_86 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_86 = "";
   bool logic_uScriptAct_Log_Out_86 = true;
   //pointer to script instanced logic node
   uScriptAct_AddInt logic_uScriptAct_AddInt_uScriptAct_AddInt_88 = new uScriptAct_AddInt( );
   System.Int32[] logic_uScriptAct_AddInt_A_88 = new System.Int32[] {};
   System.Int32[] logic_uScriptAct_AddInt_B_88 = new System.Int32[] {1};
   System.Int32 logic_uScriptAct_AddInt_IntResult_88;
   System.Single logic_uScriptAct_AddInt_FloatResult_88;
   bool logic_uScriptAct_AddInt_Out_88 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_89 = new uScriptCon_IntCounter( );
   System.Int32 logic_uScriptCon_IntCounter_A_89 = (int) 1;
   System.Int32 logic_uScriptCon_IntCounter_B_89 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_89;
   bool logic_uScriptCon_IntCounter_GreaterThan_89 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_89 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_89 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_89 = true;
   bool logic_uScriptCon_IntCounter_LessThan_89 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_90 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_90 = "";
   System.Object[] logic_uScriptAct_Log_Target_90 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_90 = "";
   bool logic_uScriptAct_Log_Out_90 = true;
   //pointer to script instanced logic node
   uScriptAct_AddInt logic_uScriptAct_AddInt_uScriptAct_AddInt_93 = new uScriptAct_AddInt( );
   System.Int32[] logic_uScriptAct_AddInt_A_93 = new System.Int32[] {};
   System.Int32[] logic_uScriptAct_AddInt_B_93 = new System.Int32[] {1};
   System.Int32 logic_uScriptAct_AddInt_IntResult_93;
   System.Single logic_uScriptAct_AddInt_FloatResult_93;
   bool logic_uScriptAct_AddInt_Out_93 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_94 = new uScriptCon_IntCounter( );
   System.Int32 logic_uScriptCon_IntCounter_A_94 = (int) 1;
   System.Int32 logic_uScriptCon_IntCounter_B_94 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_94;
   bool logic_uScriptCon_IntCounter_GreaterThan_94 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_94 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_94 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_94 = true;
   bool logic_uScriptCon_IntCounter_LessThan_94 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_95 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_95 = "";
   System.Object[] logic_uScriptAct_Log_Target_95 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_95 = "";
   bool logic_uScriptAct_Log_Out_95 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_98 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_98 = "";
   System.Object[] logic_uScriptAct_Log_Target_98 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_98 = "";
   bool logic_uScriptAct_Log_Out_98 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_101 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_101 = "";
   System.Object[] logic_uScriptAct_Log_Target_101 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_101 = "";
   bool logic_uScriptAct_Log_Out_101 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_103 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_103 = "";
   System.Object[] logic_uScriptAct_Log_Target_103 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_103 = "";
   bool logic_uScriptAct_Log_Out_103 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_104 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_104 = "";
   System.Object[] logic_uScriptAct_Log_Target_104 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_104 = "";
   bool logic_uScriptAct_Log_Out_104 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_107 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_107 = "";
   System.Object[] logic_uScriptAct_Log_Target_107 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_107 = "";
   bool logic_uScriptAct_Log_Out_107 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_109 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_109 = "";
   System.Object[] logic_uScriptAct_Log_Target_109 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_109 = "";
   bool logic_uScriptAct_Log_Out_109 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_117 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_117 = "";
   System.Object[] logic_uScriptAct_Log_Target_117 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_117 = "";
   bool logic_uScriptAct_Log_Out_117 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_120 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_120 = "";
   System.Object[] logic_uScriptAct_Log_Target_120 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_120 = "";
   bool logic_uScriptAct_Log_Out_120 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_122 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_122 = "";
   System.Object[] logic_uScriptAct_Log_Target_122 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_122 = "";
   bool logic_uScriptAct_Log_Out_122 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_124 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_124 = "";
   System.Object[] logic_uScriptAct_Log_Target_124 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_124 = "";
   bool logic_uScriptAct_Log_Out_124 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_125 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_125 = "";
   System.Object[] logic_uScriptAct_Log_Target_125 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_125 = "";
   bool logic_uScriptAct_Log_Out_125 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_128 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_128 = "";
   System.Object[] logic_uScriptAct_Log_Target_128 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_128 = "";
   bool logic_uScriptAct_Log_Out_128 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_130 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_130 = "";
   System.Object[] logic_uScriptAct_Log_Target_130 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_130 = "";
   bool logic_uScriptAct_Log_Out_130 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_263 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_263 = "";
   System.Object[] logic_uScriptAct_Log_Target_263 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_263 = "";
   bool logic_uScriptAct_Log_Out_263 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_270 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_270 = "";
   System.Object[] logic_uScriptAct_Log_Target_270 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_270 = "";
   bool logic_uScriptAct_Log_Out_270 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_273 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_273 = "";
   System.Object[] logic_uScriptAct_Log_Target_273 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_273 = "";
   bool logic_uScriptAct_Log_Out_273 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_276 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_276 = "";
   System.Object[] logic_uScriptAct_Log_Target_276 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_276 = "";
   bool logic_uScriptAct_Log_Out_276 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_286 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_286 = "";
   System.Object[] logic_uScriptAct_Log_Target_286 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_286 = "";
   bool logic_uScriptAct_Log_Out_286 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_289 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_289 = "";
   System.Object[] logic_uScriptAct_Log_Target_289 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_289 = "";
   bool logic_uScriptAct_Log_Out_289 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_313 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_313 = "";
   System.Object[] logic_uScriptAct_Log_Target_313 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_313 = "";
   bool logic_uScriptAct_Log_Out_313 = true;
   
   //event nodes
   System.Boolean event_UnityEngine_GameObject_HasFocus_0 = (bool) false;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_0 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_1 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_2 = null;
   System.String event_UnityEngine_GameObject_EventName_2 = "";
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_3 = null;
   System.String event_UnityEngine_GameObject_EventName_3 = "";
   System.Boolean event_UnityEngine_GameObject_EventData_3 = (bool) false;
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_4 = null;
   System.String event_UnityEngine_GameObject_EventName_4 = "";
   UnityEngine.Color event_UnityEngine_GameObject_EventData_4 = new UnityEngine.Color( (float)0, (float)0, (float)0, (float)1 );
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_5 = null;
   System.String event_UnityEngine_GameObject_EventName_5 = "";
   System.Single event_UnityEngine_GameObject_EventData_5 = (float) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_6 = null;
   System.String event_UnityEngine_GameObject_EventName_6 = "";
   UnityEngine.GameObject event_UnityEngine_GameObject_EventData_6 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_7 = null;
   System.String event_UnityEngine_GameObject_EventName_7 = "";
   System.Int32 event_UnityEngine_GameObject_EventData_7 = (int) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_8 = null;
   System.String event_UnityEngine_GameObject_EventName_8 = "";
   UnityEngine.Object event_UnityEngine_GameObject_EventData_8 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_9 = null;
   System.String event_UnityEngine_GameObject_EventName_9 = "";
   System.String event_UnityEngine_GameObject_EventData_9 = "";
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_10 = null;
   System.String event_UnityEngine_GameObject_EventName_10 = "";
   UnityEngine.Vector2 event_UnityEngine_GameObject_EventData_10 = new Vector2( (float)0, (float)0 );
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_11 = null;
   System.String event_UnityEngine_GameObject_EventName_11 = "";
   UnityEngine.Vector3 event_UnityEngine_GameObject_EventData_11 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_12 = null;
   System.String event_UnityEngine_GameObject_EventName_12 = "";
   UnityEngine.Vector4 event_UnityEngine_GameObject_EventData_12 = new Vector4( (float)0, (float)0, (float)0, (float)0 );
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_13 = null;
   System.Boolean event_UnityEngine_GameObject_GUIChanged_14 = (bool) false;
   System.String event_UnityEngine_GameObject_FocusedControl_14 = "";
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_14 = null;
   System.Int32 event_UnityEngine_GameObject_Level_15 = (int) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_15 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_16 = null;
   UnityEngine.Vector3 event_UnityEngine_GameObject_Acceleration_76 = new Vector3( (float)0, (float)0, (float)0 );
   System.Single event_UnityEngine_GameObject_DeltaTime_76 = (float) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_76 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_77 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_78 = null;
   System.Single event_UnityEngine_GameObject_Horizontal_79 = (float) 0;
   System.Single event_UnityEngine_GameObject_Vertical_79 = (float) 0;
   System.Boolean event_UnityEngine_GameObject_Fire1_79 = (bool) false;
   System.Boolean event_UnityEngine_GameObject_Fire2_79 = (bool) false;
   System.Boolean event_UnityEngine_GameObject_Fire3_79 = (bool) false;
   System.Boolean event_UnityEngine_GameObject_Jump_79 = (bool) false;
   System.Single event_UnityEngine_GameObject_MouseX_79 = (float) 0;
   System.Single event_UnityEngine_GameObject_MouseY_79 = (float) 0;
   System.Single event_UnityEngine_GameObject_MouseScrollWheel_79 = (float) 0;
   System.Single event_UnityEngine_GameObject_WindowShakeX_79 = (float) 0;
   System.Single event_UnityEngine_GameObject_WindowShakeY_79 = (float) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_79 = null;
   System.Single event_UnityEngine_GameObject_MouseX_80 = (float) 0;
   System.Single event_UnityEngine_GameObject_MouseY_80 = (float) 0;
   System.Single event_UnityEngine_GameObject_Wheel_80 = (float) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_80 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_81 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_82 = null;
   System.Int32 event_UnityEngine_GameObject_FingerId_83 = (int) 0;
   UnityEngine.Vector2 event_UnityEngine_GameObject_Position_83 = new Vector2( (float)0, (float)0 );
   UnityEngine.Vector2 event_UnityEngine_GameObject_DeltaPosition_83 = new Vector2( (float)0, (float)0 );
   System.Single event_UnityEngine_GameObject_DeltaTime_83 = (float) 0;
   System.Int32 event_UnityEngine_GameObject_TapCount_83 = (int) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_83 = null;
   System.String event_UnityEngine_GameObject_Failure_110 = "";
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_110 = null;
   UnityEngine.NetworkConnectionError event_UnityEngine_GameObject_Error_111 = UnityEngine.NetworkConnectionError.NoError;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_111 = null;
   UnityEngine.NetworkMessageInfo event_UnityEngine_GameObject_MessageInfo_112 = new UnityEngine.NetworkMessageInfo( );
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_112 = null;
   UnityEngine.MasterServerEvent event_UnityEngine_GameObject_MasterServerEvent_113 = UnityEngine.MasterServerEvent.RegistrationFailedGameName;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_113 = null;
   UnityEngine.BitStream event_UnityEngine_GameObject_BitStream_114 = null;
   UnityEngine.NetworkMessageInfo event_UnityEngine_GameObject_MessageInfo_114 = new UnityEngine.NetworkMessageInfo( );
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_114 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_115 = null;
   UnityEngine.NetworkPlayer event_UnityEngine_GameObject_NetworkPlayer_116 = new UnityEngine.NetworkPlayer( );
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_116 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_261 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_266 = null;
   UnityEngine.CharacterController event_UnityEngine_GameObject_Controller_266 = null;
   UnityEngine.Collider event_UnityEngine_GameObject_Collider_266 = null;
   UnityEngine.Rigidbody event_UnityEngine_GameObject_RigidBody_266 = null;
   UnityEngine.Transform event_UnityEngine_GameObject_Transform_266 = null;
   UnityEngine.Vector3 event_UnityEngine_GameObject_Point_266 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 event_UnityEngine_GameObject_Normal_266 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 event_UnityEngine_GameObject_MoveDirection_266 = new Vector3( (float)0, (float)0, (float)0 );
   System.Single event_UnityEngine_GameObject_MoveLength_266 = (float) 0;
   System.Single event_UnityEngine_GameObject_BreakForce_267 = (float) 0;
   UnityEngine.Vector3 event_UnityEngine_GameObject_RelativeVelocity_268 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Rigidbody event_UnityEngine_GameObject_RigidBody_268 = null;
   UnityEngine.Collider event_UnityEngine_GameObject_Collider_268 = null;
   UnityEngine.Transform event_UnityEngine_GameObject_Transform_268 = null;
   UnityEngine.ContactPoint[] event_UnityEngine_GameObject_Contacts_268 = new UnityEngine.ContactPoint[ 0 ];
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_268 = null;
   UnityEngine.RenderTexture event_UnityEngine_GameObject_SourceTexture_283 = null;
   UnityEngine.RenderTexture event_UnityEngine_GameObject_DestinationTexture_283 = null;
   System.Int32 event_UnityEngine_GameObject_TimesToTrigger_309 = (int) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_309 = null;
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      if ( null == local_35_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_35_UnityEngine_GameObject = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_35_UnityEngine_GameObject_previous != local_35_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_35_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEvent component = local_35_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEvent>();
               if ( null != component )
               {
                  component.OnCustomEvent -= Instance_OnCustomEvent_2;
               }
            }
         }
         
         local_35_UnityEngine_GameObject_previous = local_35_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_35_UnityEngine_GameObject )
         {
            {
               uScript_CustomEvent component = local_35_UnityEngine_GameObject.GetComponent<uScript_CustomEvent>();
               if ( null == component )
               {
                  component = local_35_UnityEngine_GameObject.AddComponent<uScript_CustomEvent>();
               }
               if ( null != component )
               {
                  component.OnCustomEvent += Instance_OnCustomEvent_2;
               }
            }
         }
      }
      if ( null == local_36_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_36_UnityEngine_GameObject = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_36_UnityEngine_GameObject_previous != local_36_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_36_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEventBool component = local_36_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEventBool>();
               if ( null != component )
               {
                  component.OnCustomEventBool -= Instance_OnCustomEventBool_3;
               }
            }
         }
         
         local_36_UnityEngine_GameObject_previous = local_36_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_36_UnityEngine_GameObject )
         {
            {
               uScript_CustomEventBool component = local_36_UnityEngine_GameObject.GetComponent<uScript_CustomEventBool>();
               if ( null == component )
               {
                  component = local_36_UnityEngine_GameObject.AddComponent<uScript_CustomEventBool>();
               }
               if ( null != component )
               {
                  component.OnCustomEventBool += Instance_OnCustomEventBool_3;
               }
            }
         }
      }
      if ( null == local_37_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_37_UnityEngine_GameObject = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_37_UnityEngine_GameObject_previous != local_37_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_37_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEventColor component = local_37_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEventColor>();
               if ( null != component )
               {
                  component.OnCustomEventColor -= Instance_OnCustomEventColor_4;
               }
            }
         }
         
         local_37_UnityEngine_GameObject_previous = local_37_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_37_UnityEngine_GameObject )
         {
            {
               uScript_CustomEventColor component = local_37_UnityEngine_GameObject.GetComponent<uScript_CustomEventColor>();
               if ( null == component )
               {
                  component = local_37_UnityEngine_GameObject.AddComponent<uScript_CustomEventColor>();
               }
               if ( null != component )
               {
                  component.OnCustomEventColor += Instance_OnCustomEventColor_4;
               }
            }
         }
      }
      if ( null == local_38_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_38_UnityEngine_GameObject = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_38_UnityEngine_GameObject_previous != local_38_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_38_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEventFloat component = local_38_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEventFloat>();
               if ( null != component )
               {
                  component.OnCustomEventFloat -= Instance_OnCustomEventFloat_5;
               }
            }
         }
         
         local_38_UnityEngine_GameObject_previous = local_38_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_38_UnityEngine_GameObject )
         {
            {
               uScript_CustomEventFloat component = local_38_UnityEngine_GameObject.GetComponent<uScript_CustomEventFloat>();
               if ( null == component )
               {
                  component = local_38_UnityEngine_GameObject.AddComponent<uScript_CustomEventFloat>();
               }
               if ( null != component )
               {
                  component.OnCustomEventFloat += Instance_OnCustomEventFloat_5;
               }
            }
         }
      }
      if ( null == local_39_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_39_UnityEngine_GameObject = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_39_UnityEngine_GameObject_previous != local_39_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_39_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEventGameObject component = local_39_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEventGameObject>();
               if ( null != component )
               {
                  component.OnCustomEventGameObject -= Instance_OnCustomEventGameObject_6;
               }
            }
         }
         
         local_39_UnityEngine_GameObject_previous = local_39_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_39_UnityEngine_GameObject )
         {
            {
               uScript_CustomEventGameObject component = local_39_UnityEngine_GameObject.GetComponent<uScript_CustomEventGameObject>();
               if ( null == component )
               {
                  component = local_39_UnityEngine_GameObject.AddComponent<uScript_CustomEventGameObject>();
               }
               if ( null != component )
               {
                  component.OnCustomEventGameObject += Instance_OnCustomEventGameObject_6;
               }
            }
         }
      }
      if ( null == local_40_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_40_UnityEngine_GameObject = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_40_UnityEngine_GameObject_previous != local_40_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_40_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEventInt component = local_40_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEventInt>();
               if ( null != component )
               {
                  component.OnCustomEventInt -= Instance_OnCustomEventInt_7;
               }
            }
         }
         
         local_40_UnityEngine_GameObject_previous = local_40_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_40_UnityEngine_GameObject )
         {
            {
               uScript_CustomEventInt component = local_40_UnityEngine_GameObject.GetComponent<uScript_CustomEventInt>();
               if ( null == component )
               {
                  component = local_40_UnityEngine_GameObject.AddComponent<uScript_CustomEventInt>();
               }
               if ( null != component )
               {
                  component.OnCustomEventInt += Instance_OnCustomEventInt_7;
               }
            }
         }
      }
      if ( null == local_41_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_41_UnityEngine_GameObject = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_41_UnityEngine_GameObject_previous != local_41_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_41_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEventObject component = local_41_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEventObject>();
               if ( null != component )
               {
                  component.OnCustomEventObject -= Instance_OnCustomEventObject_8;
               }
            }
         }
         
         local_41_UnityEngine_GameObject_previous = local_41_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_41_UnityEngine_GameObject )
         {
            {
               uScript_CustomEventObject component = local_41_UnityEngine_GameObject.GetComponent<uScript_CustomEventObject>();
               if ( null == component )
               {
                  component = local_41_UnityEngine_GameObject.AddComponent<uScript_CustomEventObject>();
               }
               if ( null != component )
               {
                  component.OnCustomEventObject += Instance_OnCustomEventObject_8;
               }
            }
         }
      }
      if ( null == local_44_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_44_UnityEngine_GameObject = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_44_UnityEngine_GameObject_previous != local_44_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_44_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEventString component = local_44_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEventString>();
               if ( null != component )
               {
                  component.OnCustomEventString -= Instance_OnCustomEventString_9;
               }
            }
         }
         
         local_44_UnityEngine_GameObject_previous = local_44_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_44_UnityEngine_GameObject )
         {
            {
               uScript_CustomEventString component = local_44_UnityEngine_GameObject.GetComponent<uScript_CustomEventString>();
               if ( null == component )
               {
                  component = local_44_UnityEngine_GameObject.AddComponent<uScript_CustomEventString>();
               }
               if ( null != component )
               {
                  component.OnCustomEventString += Instance_OnCustomEventString_9;
               }
            }
         }
      }
      if ( null == local_45_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_45_UnityEngine_GameObject = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_45_UnityEngine_GameObject_previous != local_45_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_45_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEventVector2 component = local_45_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEventVector2>();
               if ( null != component )
               {
                  component.OnCustomEventVector2 -= Instance_OnCustomEventVector2_10;
               }
            }
         }
         
         local_45_UnityEngine_GameObject_previous = local_45_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_45_UnityEngine_GameObject )
         {
            {
               uScript_CustomEventVector2 component = local_45_UnityEngine_GameObject.GetComponent<uScript_CustomEventVector2>();
               if ( null == component )
               {
                  component = local_45_UnityEngine_GameObject.AddComponent<uScript_CustomEventVector2>();
               }
               if ( null != component )
               {
                  component.OnCustomEventVector2 += Instance_OnCustomEventVector2_10;
               }
            }
         }
      }
      if ( null == local_48_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_48_UnityEngine_GameObject = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_48_UnityEngine_GameObject_previous != local_48_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_48_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEventVector3 component = local_48_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEventVector3>();
               if ( null != component )
               {
                  component.OnCustomEventVector3 -= Instance_OnCustomEventVector3_11;
               }
            }
         }
         
         local_48_UnityEngine_GameObject_previous = local_48_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_48_UnityEngine_GameObject )
         {
            {
               uScript_CustomEventVector3 component = local_48_UnityEngine_GameObject.GetComponent<uScript_CustomEventVector3>();
               if ( null == component )
               {
                  component = local_48_UnityEngine_GameObject.AddComponent<uScript_CustomEventVector3>();
               }
               if ( null != component )
               {
                  component.OnCustomEventVector3 += Instance_OnCustomEventVector3_11;
               }
            }
         }
      }
      if ( null == local_49_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_49_UnityEngine_GameObject = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_49_UnityEngine_GameObject_previous != local_49_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_49_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEventVector4 component = local_49_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEventVector4>();
               if ( null != component )
               {
                  component.OnCustomEventVector4 -= Instance_OnCustomEventVector4_12;
               }
            }
         }
         
         local_49_UnityEngine_GameObject_previous = local_49_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_49_UnityEngine_GameObject )
         {
            {
               uScript_CustomEventVector4 component = local_49_UnityEngine_GameObject.GetComponent<uScript_CustomEventVector4>();
               if ( null == component )
               {
                  component = local_49_UnityEngine_GameObject.AddComponent<uScript_CustomEventVector4>();
               }
               if ( null != component )
               {
                  component.OnCustomEventVector4 += Instance_OnCustomEventVector4_12;
               }
            }
         }
      }
      if ( null == local_74_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_74_UnityEngine_GameObject = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_74_UnityEngine_GameObject_previous != local_74_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_74_UnityEngine_GameObject_previous )
         {
            {
               uScript_GameObject component = local_74_UnityEngine_GameObject_previous.GetComponent<uScript_GameObject>();
               if ( null != component )
               {
                  component.EnableEvent -= Instance_EnableEvent_68;
                  component.DisableEvent -= Instance_DisableEvent_68;
                  component.DestroyEvent -= Instance_DestroyEvent_68;
               }
            }
         }
         
         local_74_UnityEngine_GameObject_previous = local_74_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_74_UnityEngine_GameObject )
         {
            {
               uScript_GameObject component = local_74_UnityEngine_GameObject.GetComponent<uScript_GameObject>();
               if ( null == component )
               {
                  component = local_74_UnityEngine_GameObject.AddComponent<uScript_GameObject>();
               }
               if ( null != component )
               {
                  component.EnableEvent += Instance_EnableEvent_68;
                  component.DisableEvent += Instance_DisableEvent_68;
                  component.DestroyEvent += Instance_DestroyEvent_68;
               }
            }
         }
      }
      if ( null == local_75_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_75_UnityEngine_GameObject = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_75_UnityEngine_GameObject_previous != local_75_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_75_UnityEngine_GameObject_previous )
         {
            {
               uScript_Visibility component = local_75_UnityEngine_GameObject_previous.GetComponent<uScript_Visibility>();
               if ( null != component )
               {
                  component.BecameVisible -= Instance_BecameVisible_69;
                  component.BecameInvisible -= Instance_BecameInvisible_69;
               }
            }
         }
         
         local_75_UnityEngine_GameObject_previous = local_75_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_75_UnityEngine_GameObject )
         {
            {
               uScript_Visibility component = local_75_UnityEngine_GameObject.GetComponent<uScript_Visibility>();
               if ( null == component )
               {
                  component = local_75_UnityEngine_GameObject.AddComponent<uScript_Visibility>();
               }
               if ( null != component )
               {
                  component.BecameVisible += Instance_BecameVisible_69;
                  component.BecameInvisible += Instance_BecameInvisible_69;
               }
            }
         }
      }
      if ( null == local_297_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_297_UnityEngine_GameObject = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_297_UnityEngine_GameObject_previous != local_297_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_297_UnityEngine_GameObject_previous )
         {
            {
               uScript_Particle component = local_297_UnityEngine_GameObject_previous.GetComponent<uScript_Particle>();
               if ( null != component )
               {
                  component.Collision -= Instance_Collision_261;
               }
            }
         }
         
         local_297_UnityEngine_GameObject_previous = local_297_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_297_UnityEngine_GameObject )
         {
            {
               uScript_Particle component = local_297_UnityEngine_GameObject.GetComponent<uScript_Particle>();
               if ( null == component )
               {
                  component = local_297_UnityEngine_GameObject.AddComponent<uScript_Particle>();
               }
               if ( null != component )
               {
                  component.Collision += Instance_Collision_261;
               }
            }
         }
      }
      if ( null == local_299_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_299_UnityEngine_GameObject = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_299_UnityEngine_GameObject_previous != local_299_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_299_UnityEngine_GameObject_previous )
         {
            {
               uScript_Collision component = local_299_UnityEngine_GameObject_previous.GetComponent<uScript_Collision>();
               if ( null != component )
               {
                  component.OnEnterCollision -= Instance_OnEnterCollision_268;
                  component.OnExitCollision -= Instance_OnExitCollision_268;
                  component.WhileInsideCollision -= Instance_WhileInsideCollision_268;
               }
            }
         }
         
         local_299_UnityEngine_GameObject_previous = local_299_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_299_UnityEngine_GameObject )
         {
            {
               uScript_Collision component = local_299_UnityEngine_GameObject.GetComponent<uScript_Collision>();
               if ( null == component )
               {
                  component = local_299_UnityEngine_GameObject.AddComponent<uScript_Collision>();
               }
               if ( null != component )
               {
                  component.OnEnterCollision += Instance_OnEnterCollision_268;
                  component.OnExitCollision += Instance_OnExitCollision_268;
                  component.WhileInsideCollision += Instance_WhileInsideCollision_268;
               }
            }
         }
      }
      if ( null == local_301_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_301_UnityEngine_GameObject = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_301_UnityEngine_GameObject_previous != local_301_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_301_UnityEngine_GameObject_previous )
         {
            {
               uScript_Joint component = local_301_UnityEngine_GameObject_previous.GetComponent<uScript_Joint>();
               if ( null != component )
               {
                  component.JointBreak -= Instance_JointBreak_267;
               }
            }
         }
         
         local_301_UnityEngine_GameObject_previous = local_301_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_301_UnityEngine_GameObject )
         {
            {
               uScript_Joint component = local_301_UnityEngine_GameObject.GetComponent<uScript_Joint>();
               if ( null == component )
               {
                  component = local_301_UnityEngine_GameObject.AddComponent<uScript_Joint>();
               }
               if ( null != component )
               {
                  component.JointBreak += Instance_JointBreak_267;
               }
            }
         }
      }
      if ( null == local_303_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_303_UnityEngine_GameObject = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_303_UnityEngine_GameObject_previous != local_303_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_303_UnityEngine_GameObject_previous )
         {
            {
               uScript_ProxyController component = local_303_UnityEngine_GameObject_previous.GetComponent<uScript_ProxyController>();
               if ( null != component )
               {
                  component.OnHit -= Instance_OnHit_266;
               }
            }
         }
         
         local_303_UnityEngine_GameObject_previous = local_303_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_303_UnityEngine_GameObject )
         {
            {
               uScript_ProxyController component = local_303_UnityEngine_GameObject.GetComponent<uScript_ProxyController>();
               if ( null == component )
               {
                  component = local_303_UnityEngine_GameObject.AddComponent<uScript_ProxyController>();
               }
               if ( null != component )
               {
                  component.OnHit += Instance_OnHit_266;
               }
            }
         }
      }
      if ( null == local_305_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_305_UnityEngine_GameObject = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_305_UnityEngine_GameObject_previous != local_305_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_305_UnityEngine_GameObject_previous )
         {
            {
               uScript_Render component = local_305_UnityEngine_GameObject_previous.GetComponent<uScript_Render>();
               if ( null != component )
               {
                  component.PreCull -= Instance_PreCull_284;
                  component.PreRender -= Instance_PreRender_284;
                  component.PostRender -= Instance_PostRender_284;
                  component.RenderObject -= Instance_RenderObject_284;
                  component.WillRenderObject -= Instance_WillRenderObject_284;
               }
            }
         }
         
         local_305_UnityEngine_GameObject_previous = local_305_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_305_UnityEngine_GameObject )
         {
            {
               uScript_Render component = local_305_UnityEngine_GameObject.GetComponent<uScript_Render>();
               if ( null == component )
               {
                  component = local_305_UnityEngine_GameObject.AddComponent<uScript_Render>();
               }
               if ( null != component )
               {
                  component.PreCull += Instance_PreCull_284;
                  component.PreRender += Instance_PreRender_284;
                  component.PostRender += Instance_PostRender_284;
                  component.RenderObject += Instance_RenderObject_284;
                  component.WillRenderObject += Instance_WillRenderObject_284;
               }
            }
         }
      }
      if ( null == local_307_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_307_UnityEngine_GameObject = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_307_UnityEngine_GameObject_previous != local_307_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_307_UnityEngine_GameObject_previous )
         {
            {
               uScript_PostEffect component = local_307_UnityEngine_GameObject_previous.GetComponent<uScript_PostEffect>();
               if ( null != component )
               {
                  component.RenderImage -= Instance_RenderImage_283;
               }
            }
         }
         
         local_307_UnityEngine_GameObject_previous = local_307_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_307_UnityEngine_GameObject )
         {
            {
               uScript_PostEffect component = local_307_UnityEngine_GameObject.GetComponent<uScript_PostEffect>();
               if ( null == component )
               {
                  component = local_307_UnityEngine_GameObject.AddComponent<uScript_PostEffect>();
               }
               if ( null != component )
               {
                  component.RenderImage += Instance_RenderImage_283;
               }
            }
         }
      }
      if ( null == local_310_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_310_UnityEngine_GameObject = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_310_UnityEngine_GameObject_previous != local_310_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_310_UnityEngine_GameObject_previous )
         {
            {
               uScript_Triggers component = local_310_UnityEngine_GameObject_previous.GetComponent<uScript_Triggers>();
               if ( null != component )
               {
                  component.OnEnterTrigger -= Instance_OnEnterTrigger_309;
                  component.OnExitTrigger -= Instance_OnExitTrigger_309;
                  component.WhileInsideTrigger -= Instance_WhileInsideTrigger_309;
               }
            }
         }
         
         local_310_UnityEngine_GameObject_previous = local_310_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_310_UnityEngine_GameObject )
         {
            {
               uScript_Triggers component = local_310_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = local_310_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_309;
               }
            }
            {
               uScript_Triggers component = local_310_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = local_310_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_309;
                  component.OnExitTrigger += Instance_OnExitTrigger_309;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_309;
               }
            }
         }
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_35_UnityEngine_GameObject_previous != local_35_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_35_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEvent component = local_35_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEvent>();
               if ( null != component )
               {
                  component.OnCustomEvent -= Instance_OnCustomEvent_2;
               }
            }
         }
         
         local_35_UnityEngine_GameObject_previous = local_35_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_35_UnityEngine_GameObject )
         {
            {
               uScript_CustomEvent component = local_35_UnityEngine_GameObject.GetComponent<uScript_CustomEvent>();
               if ( null == component )
               {
                  component = local_35_UnityEngine_GameObject.AddComponent<uScript_CustomEvent>();
               }
               if ( null != component )
               {
                  component.OnCustomEvent += Instance_OnCustomEvent_2;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_36_UnityEngine_GameObject_previous != local_36_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_36_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEventBool component = local_36_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEventBool>();
               if ( null != component )
               {
                  component.OnCustomEventBool -= Instance_OnCustomEventBool_3;
               }
            }
         }
         
         local_36_UnityEngine_GameObject_previous = local_36_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_36_UnityEngine_GameObject )
         {
            {
               uScript_CustomEventBool component = local_36_UnityEngine_GameObject.GetComponent<uScript_CustomEventBool>();
               if ( null == component )
               {
                  component = local_36_UnityEngine_GameObject.AddComponent<uScript_CustomEventBool>();
               }
               if ( null != component )
               {
                  component.OnCustomEventBool += Instance_OnCustomEventBool_3;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_37_UnityEngine_GameObject_previous != local_37_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_37_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEventColor component = local_37_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEventColor>();
               if ( null != component )
               {
                  component.OnCustomEventColor -= Instance_OnCustomEventColor_4;
               }
            }
         }
         
         local_37_UnityEngine_GameObject_previous = local_37_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_37_UnityEngine_GameObject )
         {
            {
               uScript_CustomEventColor component = local_37_UnityEngine_GameObject.GetComponent<uScript_CustomEventColor>();
               if ( null == component )
               {
                  component = local_37_UnityEngine_GameObject.AddComponent<uScript_CustomEventColor>();
               }
               if ( null != component )
               {
                  component.OnCustomEventColor += Instance_OnCustomEventColor_4;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_38_UnityEngine_GameObject_previous != local_38_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_38_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEventFloat component = local_38_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEventFloat>();
               if ( null != component )
               {
                  component.OnCustomEventFloat -= Instance_OnCustomEventFloat_5;
               }
            }
         }
         
         local_38_UnityEngine_GameObject_previous = local_38_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_38_UnityEngine_GameObject )
         {
            {
               uScript_CustomEventFloat component = local_38_UnityEngine_GameObject.GetComponent<uScript_CustomEventFloat>();
               if ( null == component )
               {
                  component = local_38_UnityEngine_GameObject.AddComponent<uScript_CustomEventFloat>();
               }
               if ( null != component )
               {
                  component.OnCustomEventFloat += Instance_OnCustomEventFloat_5;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_39_UnityEngine_GameObject_previous != local_39_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_39_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEventGameObject component = local_39_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEventGameObject>();
               if ( null != component )
               {
                  component.OnCustomEventGameObject -= Instance_OnCustomEventGameObject_6;
               }
            }
         }
         
         local_39_UnityEngine_GameObject_previous = local_39_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_39_UnityEngine_GameObject )
         {
            {
               uScript_CustomEventGameObject component = local_39_UnityEngine_GameObject.GetComponent<uScript_CustomEventGameObject>();
               if ( null == component )
               {
                  component = local_39_UnityEngine_GameObject.AddComponent<uScript_CustomEventGameObject>();
               }
               if ( null != component )
               {
                  component.OnCustomEventGameObject += Instance_OnCustomEventGameObject_6;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_40_UnityEngine_GameObject_previous != local_40_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_40_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEventInt component = local_40_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEventInt>();
               if ( null != component )
               {
                  component.OnCustomEventInt -= Instance_OnCustomEventInt_7;
               }
            }
         }
         
         local_40_UnityEngine_GameObject_previous = local_40_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_40_UnityEngine_GameObject )
         {
            {
               uScript_CustomEventInt component = local_40_UnityEngine_GameObject.GetComponent<uScript_CustomEventInt>();
               if ( null == component )
               {
                  component = local_40_UnityEngine_GameObject.AddComponent<uScript_CustomEventInt>();
               }
               if ( null != component )
               {
                  component.OnCustomEventInt += Instance_OnCustomEventInt_7;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_41_UnityEngine_GameObject_previous != local_41_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_41_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEventObject component = local_41_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEventObject>();
               if ( null != component )
               {
                  component.OnCustomEventObject -= Instance_OnCustomEventObject_8;
               }
            }
         }
         
         local_41_UnityEngine_GameObject_previous = local_41_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_41_UnityEngine_GameObject )
         {
            {
               uScript_CustomEventObject component = local_41_UnityEngine_GameObject.GetComponent<uScript_CustomEventObject>();
               if ( null == component )
               {
                  component = local_41_UnityEngine_GameObject.AddComponent<uScript_CustomEventObject>();
               }
               if ( null != component )
               {
                  component.OnCustomEventObject += Instance_OnCustomEventObject_8;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_44_UnityEngine_GameObject_previous != local_44_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_44_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEventString component = local_44_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEventString>();
               if ( null != component )
               {
                  component.OnCustomEventString -= Instance_OnCustomEventString_9;
               }
            }
         }
         
         local_44_UnityEngine_GameObject_previous = local_44_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_44_UnityEngine_GameObject )
         {
            {
               uScript_CustomEventString component = local_44_UnityEngine_GameObject.GetComponent<uScript_CustomEventString>();
               if ( null == component )
               {
                  component = local_44_UnityEngine_GameObject.AddComponent<uScript_CustomEventString>();
               }
               if ( null != component )
               {
                  component.OnCustomEventString += Instance_OnCustomEventString_9;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_45_UnityEngine_GameObject_previous != local_45_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_45_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEventVector2 component = local_45_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEventVector2>();
               if ( null != component )
               {
                  component.OnCustomEventVector2 -= Instance_OnCustomEventVector2_10;
               }
            }
         }
         
         local_45_UnityEngine_GameObject_previous = local_45_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_45_UnityEngine_GameObject )
         {
            {
               uScript_CustomEventVector2 component = local_45_UnityEngine_GameObject.GetComponent<uScript_CustomEventVector2>();
               if ( null == component )
               {
                  component = local_45_UnityEngine_GameObject.AddComponent<uScript_CustomEventVector2>();
               }
               if ( null != component )
               {
                  component.OnCustomEventVector2 += Instance_OnCustomEventVector2_10;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_48_UnityEngine_GameObject_previous != local_48_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_48_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEventVector3 component = local_48_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEventVector3>();
               if ( null != component )
               {
                  component.OnCustomEventVector3 -= Instance_OnCustomEventVector3_11;
               }
            }
         }
         
         local_48_UnityEngine_GameObject_previous = local_48_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_48_UnityEngine_GameObject )
         {
            {
               uScript_CustomEventVector3 component = local_48_UnityEngine_GameObject.GetComponent<uScript_CustomEventVector3>();
               if ( null == component )
               {
                  component = local_48_UnityEngine_GameObject.AddComponent<uScript_CustomEventVector3>();
               }
               if ( null != component )
               {
                  component.OnCustomEventVector3 += Instance_OnCustomEventVector3_11;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_49_UnityEngine_GameObject_previous != local_49_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_49_UnityEngine_GameObject_previous )
         {
            {
               uScript_CustomEventVector4 component = local_49_UnityEngine_GameObject_previous.GetComponent<uScript_CustomEventVector4>();
               if ( null != component )
               {
                  component.OnCustomEventVector4 -= Instance_OnCustomEventVector4_12;
               }
            }
         }
         
         local_49_UnityEngine_GameObject_previous = local_49_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_49_UnityEngine_GameObject )
         {
            {
               uScript_CustomEventVector4 component = local_49_UnityEngine_GameObject.GetComponent<uScript_CustomEventVector4>();
               if ( null == component )
               {
                  component = local_49_UnityEngine_GameObject.AddComponent<uScript_CustomEventVector4>();
               }
               if ( null != component )
               {
                  component.OnCustomEventVector4 += Instance_OnCustomEventVector4_12;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_74_UnityEngine_GameObject_previous != local_74_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_74_UnityEngine_GameObject_previous )
         {
            {
               uScript_GameObject component = local_74_UnityEngine_GameObject_previous.GetComponent<uScript_GameObject>();
               if ( null != component )
               {
                  component.EnableEvent -= Instance_EnableEvent_68;
                  component.DisableEvent -= Instance_DisableEvent_68;
                  component.DestroyEvent -= Instance_DestroyEvent_68;
               }
            }
         }
         
         local_74_UnityEngine_GameObject_previous = local_74_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_74_UnityEngine_GameObject )
         {
            {
               uScript_GameObject component = local_74_UnityEngine_GameObject.GetComponent<uScript_GameObject>();
               if ( null == component )
               {
                  component = local_74_UnityEngine_GameObject.AddComponent<uScript_GameObject>();
               }
               if ( null != component )
               {
                  component.EnableEvent += Instance_EnableEvent_68;
                  component.DisableEvent += Instance_DisableEvent_68;
                  component.DestroyEvent += Instance_DestroyEvent_68;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_75_UnityEngine_GameObject_previous != local_75_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_75_UnityEngine_GameObject_previous )
         {
            {
               uScript_Visibility component = local_75_UnityEngine_GameObject_previous.GetComponent<uScript_Visibility>();
               if ( null != component )
               {
                  component.BecameVisible -= Instance_BecameVisible_69;
                  component.BecameInvisible -= Instance_BecameInvisible_69;
               }
            }
         }
         
         local_75_UnityEngine_GameObject_previous = local_75_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_75_UnityEngine_GameObject )
         {
            {
               uScript_Visibility component = local_75_UnityEngine_GameObject.GetComponent<uScript_Visibility>();
               if ( null == component )
               {
                  component = local_75_UnityEngine_GameObject.AddComponent<uScript_Visibility>();
               }
               if ( null != component )
               {
                  component.BecameVisible += Instance_BecameVisible_69;
                  component.BecameInvisible += Instance_BecameInvisible_69;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_297_UnityEngine_GameObject_previous != local_297_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_297_UnityEngine_GameObject_previous )
         {
            {
               uScript_Particle component = local_297_UnityEngine_GameObject_previous.GetComponent<uScript_Particle>();
               if ( null != component )
               {
                  component.Collision -= Instance_Collision_261;
               }
            }
         }
         
         local_297_UnityEngine_GameObject_previous = local_297_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_297_UnityEngine_GameObject )
         {
            {
               uScript_Particle component = local_297_UnityEngine_GameObject.GetComponent<uScript_Particle>();
               if ( null == component )
               {
                  component = local_297_UnityEngine_GameObject.AddComponent<uScript_Particle>();
               }
               if ( null != component )
               {
                  component.Collision += Instance_Collision_261;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_299_UnityEngine_GameObject_previous != local_299_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_299_UnityEngine_GameObject_previous )
         {
            {
               uScript_Collision component = local_299_UnityEngine_GameObject_previous.GetComponent<uScript_Collision>();
               if ( null != component )
               {
                  component.OnEnterCollision -= Instance_OnEnterCollision_268;
                  component.OnExitCollision -= Instance_OnExitCollision_268;
                  component.WhileInsideCollision -= Instance_WhileInsideCollision_268;
               }
            }
         }
         
         local_299_UnityEngine_GameObject_previous = local_299_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_299_UnityEngine_GameObject )
         {
            {
               uScript_Collision component = local_299_UnityEngine_GameObject.GetComponent<uScript_Collision>();
               if ( null == component )
               {
                  component = local_299_UnityEngine_GameObject.AddComponent<uScript_Collision>();
               }
               if ( null != component )
               {
                  component.OnEnterCollision += Instance_OnEnterCollision_268;
                  component.OnExitCollision += Instance_OnExitCollision_268;
                  component.WhileInsideCollision += Instance_WhileInsideCollision_268;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_301_UnityEngine_GameObject_previous != local_301_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_301_UnityEngine_GameObject_previous )
         {
            {
               uScript_Joint component = local_301_UnityEngine_GameObject_previous.GetComponent<uScript_Joint>();
               if ( null != component )
               {
                  component.JointBreak -= Instance_JointBreak_267;
               }
            }
         }
         
         local_301_UnityEngine_GameObject_previous = local_301_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_301_UnityEngine_GameObject )
         {
            {
               uScript_Joint component = local_301_UnityEngine_GameObject.GetComponent<uScript_Joint>();
               if ( null == component )
               {
                  component = local_301_UnityEngine_GameObject.AddComponent<uScript_Joint>();
               }
               if ( null != component )
               {
                  component.JointBreak += Instance_JointBreak_267;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_303_UnityEngine_GameObject_previous != local_303_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_303_UnityEngine_GameObject_previous )
         {
            {
               uScript_ProxyController component = local_303_UnityEngine_GameObject_previous.GetComponent<uScript_ProxyController>();
               if ( null != component )
               {
                  component.OnHit -= Instance_OnHit_266;
               }
            }
         }
         
         local_303_UnityEngine_GameObject_previous = local_303_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_303_UnityEngine_GameObject )
         {
            {
               uScript_ProxyController component = local_303_UnityEngine_GameObject.GetComponent<uScript_ProxyController>();
               if ( null == component )
               {
                  component = local_303_UnityEngine_GameObject.AddComponent<uScript_ProxyController>();
               }
               if ( null != component )
               {
                  component.OnHit += Instance_OnHit_266;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_305_UnityEngine_GameObject_previous != local_305_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_305_UnityEngine_GameObject_previous )
         {
            {
               uScript_Render component = local_305_UnityEngine_GameObject_previous.GetComponent<uScript_Render>();
               if ( null != component )
               {
                  component.PreCull -= Instance_PreCull_284;
                  component.PreRender -= Instance_PreRender_284;
                  component.PostRender -= Instance_PostRender_284;
                  component.RenderObject -= Instance_RenderObject_284;
                  component.WillRenderObject -= Instance_WillRenderObject_284;
               }
            }
         }
         
         local_305_UnityEngine_GameObject_previous = local_305_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_305_UnityEngine_GameObject )
         {
            {
               uScript_Render component = local_305_UnityEngine_GameObject.GetComponent<uScript_Render>();
               if ( null == component )
               {
                  component = local_305_UnityEngine_GameObject.AddComponent<uScript_Render>();
               }
               if ( null != component )
               {
                  component.PreCull += Instance_PreCull_284;
                  component.PreRender += Instance_PreRender_284;
                  component.PostRender += Instance_PostRender_284;
                  component.RenderObject += Instance_RenderObject_284;
                  component.WillRenderObject += Instance_WillRenderObject_284;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_307_UnityEngine_GameObject_previous != local_307_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_307_UnityEngine_GameObject_previous )
         {
            {
               uScript_PostEffect component = local_307_UnityEngine_GameObject_previous.GetComponent<uScript_PostEffect>();
               if ( null != component )
               {
                  component.RenderImage -= Instance_RenderImage_283;
               }
            }
         }
         
         local_307_UnityEngine_GameObject_previous = local_307_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_307_UnityEngine_GameObject )
         {
            {
               uScript_PostEffect component = local_307_UnityEngine_GameObject.GetComponent<uScript_PostEffect>();
               if ( null == component )
               {
                  component = local_307_UnityEngine_GameObject.AddComponent<uScript_PostEffect>();
               }
               if ( null != component )
               {
                  component.RenderImage += Instance_RenderImage_283;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_310_UnityEngine_GameObject_previous != local_310_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_310_UnityEngine_GameObject_previous )
         {
            {
               uScript_Triggers component = local_310_UnityEngine_GameObject_previous.GetComponent<uScript_Triggers>();
               if ( null != component )
               {
                  component.OnEnterTrigger -= Instance_OnEnterTrigger_309;
                  component.OnExitTrigger -= Instance_OnExitTrigger_309;
                  component.WhileInsideTrigger -= Instance_WhileInsideTrigger_309;
               }
            }
         }
         
         local_310_UnityEngine_GameObject_previous = local_310_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_310_UnityEngine_GameObject )
         {
            {
               uScript_Triggers component = local_310_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = local_310_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_309;
               }
            }
            {
               uScript_Triggers component = local_310_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = local_310_UnityEngine_GameObject.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_309;
                  component.OnExitTrigger += Instance_OnExitTrigger_309;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_309;
               }
            }
         }
      }
   }
   
   void SyncEventListeners( )
   {
      if ( null == event_UnityEngine_GameObject_Instance_0 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_0 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_0 )
         {
            {
               uScript_ApplicationFocus component = event_UnityEngine_GameObject_Instance_0.GetComponent<uScript_ApplicationFocus>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_0.AddComponent<uScript_ApplicationFocus>();
               }
               if ( null != component )
               {
                  component.FocusEvent += Instance_FocusEvent_0;
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
               uScript_ApplicationQuit component = event_UnityEngine_GameObject_Instance_1.GetComponent<uScript_ApplicationQuit>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_1.AddComponent<uScript_ApplicationQuit>();
               }
               if ( null != component )
               {
                  component.QuitEvent += Instance_QuitEvent_1;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_13 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_13 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_13 )
         {
            {
               uScript_Update component = event_UnityEngine_GameObject_Instance_13.GetComponent<uScript_Update>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_13.AddComponent<uScript_Update>();
               }
               if ( null != component )
               {
                  component.OnUpdate += Instance_OnUpdate_13;
                  component.OnLateUpdate += Instance_OnLateUpdate_13;
                  component.OnFixedUpdate += Instance_OnFixedUpdate_13;
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
               if ( null == thisScriptsOnGuiListener )
               {
                  //OnGUI need unique listeners so calls like GUI.depth will work across uScripts
                  thisScriptsOnGuiListener = event_UnityEngine_GameObject_Instance_14.AddComponent<uScript_GUI>();
               }
               uScript_GUI component = thisScriptsOnGuiListener;
               if ( null != component )
               {
                  component.OnGui += Instance_OnGui_14;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_15 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_15 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_15 )
         {
            {
               uScript_Level component = event_UnityEngine_GameObject_Instance_15.GetComponent<uScript_Level>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_15.AddComponent<uScript_Level>();
               }
               if ( null != component )
               {
                  component.LevelWasLoaded += Instance_LevelWasLoaded_15;
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
               uScript_Global component = event_UnityEngine_GameObject_Instance_16.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_16.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_16;
                  component.uScriptLateStart += Instance_uScriptLateStart_16;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_76 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_76 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_76 )
         {
            {
               uScript_Accelerometer component = event_UnityEngine_GameObject_Instance_76.GetComponent<uScript_Accelerometer>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_76.AddComponent<uScript_Accelerometer>();
               }
               if ( null != component )
               {
                  component.OnAccelerationEvent += Instance_OnAccelerationEvent_76;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_77 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_77 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_77 )
         {
            {
               uScript_DeviceOrientation component = event_UnityEngine_GameObject_Instance_77.GetComponent<uScript_DeviceOrientation>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_77.AddComponent<uScript_DeviceOrientation>();
               }
               if ( null != component )
               {
                  component.OnDevicePortrait += Instance_OnDevicePortrait_77;
                  component.OnDevicePortraitUpsideDown += Instance_OnDevicePortraitUpsideDown_77;
                  component.OnDeviceLandscapeLeft += Instance_OnDeviceLandscapeLeft_77;
                  component.OnDeviceLandscapeRight += Instance_OnDeviceLandscapeRight_77;
                  component.OnDeviceFaceUp += Instance_OnDeviceFaceUp_77;
                  component.OnDeviceFaceDown += Instance_OnDeviceFaceDown_77;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_78 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_78 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_78 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_78.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_78.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_78;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_79 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_79 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_79 )
         {
            {
               uScript_ManagedInput component = event_UnityEngine_GameObject_Instance_79.GetComponent<uScript_ManagedInput>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_79.AddComponent<uScript_ManagedInput>();
               }
               if ( null != component )
               {
                  component.OnInputEvent += Instance_OnInputEvent_79;
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
               uScript_MouseAxis component = event_UnityEngine_GameObject_Instance_80.GetComponent<uScript_MouseAxis>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_80.AddComponent<uScript_MouseAxis>();
               }
               if ( null != component )
               {
                  component.AxisEvent += Instance_AxisEvent_80;
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
               uScript_Mouse component = event_UnityEngine_GameObject_Instance_81.GetComponent<uScript_Mouse>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_81.AddComponent<uScript_Mouse>();
               }
               if ( null != component )
               {
                  component.OnEnter += Instance_OnEnter_81;
                  component.OnOver += Instance_OnOver_81;
                  component.OnExit += Instance_OnExit_81;
                  component.OnDown += Instance_OnDown_81;
                  component.OnUp += Instance_OnUp_81;
                  component.OnDrag += Instance_OnDrag_81;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_82 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_82 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_82 )
         {
            {
               uScript_OnScreenKeyboard component = event_UnityEngine_GameObject_Instance_82.GetComponent<uScript_OnScreenKeyboard>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_82.AddComponent<uScript_OnScreenKeyboard>();
               }
               if ( null != component )
               {
                  component.OnKeyboardSlidOut += Instance_OnKeyboardSlidOut_82;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_83 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_83 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_83 )
         {
            {
               uScript_Touch component = event_UnityEngine_GameObject_Instance_83.GetComponent<uScript_Touch>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_83.AddComponent<uScript_Touch>();
               }
               if ( null != component )
               {
                  component.OnTouchBegan += Instance_OnTouchBegan_83;
                  component.OnTouchMoved += Instance_OnTouchMoved_83;
                  component.OnTouchStationary += Instance_OnTouchStationary_83;
                  component.OnTouchEnded += Instance_OnTouchEnded_83;
                  component.OnTouchCanceled += Instance_OnTouchCanceled_83;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_110 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_110 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_110 )
         {
            {
               uScript_NetworkClientConnection component = event_UnityEngine_GameObject_Instance_110.GetComponent<uScript_NetworkClientConnection>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_110.AddComponent<uScript_NetworkClientConnection>();
               }
               if ( null != component )
               {
                  component.ConnectedToServer += Instance_ConnectedToServer_110;
                  component.DisconnectedFromServer += Instance_DisconnectedFromServer_110;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_111 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_111 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_111 )
         {
            {
               uScript_NetworkFailedConnection component = event_UnityEngine_GameObject_Instance_111.GetComponent<uScript_NetworkFailedConnection>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_111.AddComponent<uScript_NetworkFailedConnection>();
               }
               if ( null != component )
               {
                  component.FailedToConnect += Instance_FailedToConnect_111;
                  component.FailedToConnectToMaster += Instance_FailedToConnectToMaster_111;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_112 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_112 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_112 )
         {
            {
               uScript_NetworkInstantiate component = event_UnityEngine_GameObject_Instance_112.GetComponent<uScript_NetworkInstantiate>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_112.AddComponent<uScript_NetworkInstantiate>();
               }
               if ( null != component )
               {
                  component.OnInstantiate += Instance_OnInstantiate_112;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_113 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_113 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_113 )
         {
            {
               uScript_NetworkMasterServer component = event_UnityEngine_GameObject_Instance_113.GetComponent<uScript_NetworkMasterServer>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_113.AddComponent<uScript_NetworkMasterServer>();
               }
               if ( null != component )
               {
                  component.OnEvent += Instance_OnEvent_113;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_114 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_114 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_114 )
         {
            {
               uScript_NetworkSerialization component = event_UnityEngine_GameObject_Instance_114.GetComponent<uScript_NetworkSerialization>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_114.AddComponent<uScript_NetworkSerialization>();
               }
               if ( null != component )
               {
                  component.OnSerialize += Instance_OnSerialize_114;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_115 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_115 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_115 )
         {
            {
               uScript_NetworkServerInitialized component = event_UnityEngine_GameObject_Instance_115.GetComponent<uScript_NetworkServerInitialized>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_115.AddComponent<uScript_NetworkServerInitialized>();
               }
               if ( null != component )
               {
                  component.OnInitialized += Instance_OnInitialized_115;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_116 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_116 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_116 )
         {
            {
               uScript_NetworkServerPlayer component = event_UnityEngine_GameObject_Instance_116.GetComponent<uScript_NetworkServerPlayer>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_116.AddComponent<uScript_NetworkServerPlayer>();
               }
               if ( null != component )
               {
                  component.PlayerConnected += Instance_PlayerConnected_116;
                  component.PlayerDisconnected += Instance_PlayerDisconnected_116;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != local_35_UnityEngine_GameObject )
      {
         {
            uScript_CustomEvent component = local_35_UnityEngine_GameObject.GetComponent<uScript_CustomEvent>();
            if ( null != component )
            {
               component.OnCustomEvent -= Instance_OnCustomEvent_2;
            }
         }
      }
      if ( null != local_36_UnityEngine_GameObject )
      {
         {
            uScript_CustomEventBool component = local_36_UnityEngine_GameObject.GetComponent<uScript_CustomEventBool>();
            if ( null != component )
            {
               component.OnCustomEventBool -= Instance_OnCustomEventBool_3;
            }
         }
      }
      if ( null != local_37_UnityEngine_GameObject )
      {
         {
            uScript_CustomEventColor component = local_37_UnityEngine_GameObject.GetComponent<uScript_CustomEventColor>();
            if ( null != component )
            {
               component.OnCustomEventColor -= Instance_OnCustomEventColor_4;
            }
         }
      }
      if ( null != local_38_UnityEngine_GameObject )
      {
         {
            uScript_CustomEventFloat component = local_38_UnityEngine_GameObject.GetComponent<uScript_CustomEventFloat>();
            if ( null != component )
            {
               component.OnCustomEventFloat -= Instance_OnCustomEventFloat_5;
            }
         }
      }
      if ( null != local_39_UnityEngine_GameObject )
      {
         {
            uScript_CustomEventGameObject component = local_39_UnityEngine_GameObject.GetComponent<uScript_CustomEventGameObject>();
            if ( null != component )
            {
               component.OnCustomEventGameObject -= Instance_OnCustomEventGameObject_6;
            }
         }
      }
      if ( null != local_40_UnityEngine_GameObject )
      {
         {
            uScript_CustomEventInt component = local_40_UnityEngine_GameObject.GetComponent<uScript_CustomEventInt>();
            if ( null != component )
            {
               component.OnCustomEventInt -= Instance_OnCustomEventInt_7;
            }
         }
      }
      if ( null != local_41_UnityEngine_GameObject )
      {
         {
            uScript_CustomEventObject component = local_41_UnityEngine_GameObject.GetComponent<uScript_CustomEventObject>();
            if ( null != component )
            {
               component.OnCustomEventObject -= Instance_OnCustomEventObject_8;
            }
         }
      }
      if ( null != local_44_UnityEngine_GameObject )
      {
         {
            uScript_CustomEventString component = local_44_UnityEngine_GameObject.GetComponent<uScript_CustomEventString>();
            if ( null != component )
            {
               component.OnCustomEventString -= Instance_OnCustomEventString_9;
            }
         }
      }
      if ( null != local_45_UnityEngine_GameObject )
      {
         {
            uScript_CustomEventVector2 component = local_45_UnityEngine_GameObject.GetComponent<uScript_CustomEventVector2>();
            if ( null != component )
            {
               component.OnCustomEventVector2 -= Instance_OnCustomEventVector2_10;
            }
         }
      }
      if ( null != local_48_UnityEngine_GameObject )
      {
         {
            uScript_CustomEventVector3 component = local_48_UnityEngine_GameObject.GetComponent<uScript_CustomEventVector3>();
            if ( null != component )
            {
               component.OnCustomEventVector3 -= Instance_OnCustomEventVector3_11;
            }
         }
      }
      if ( null != local_49_UnityEngine_GameObject )
      {
         {
            uScript_CustomEventVector4 component = local_49_UnityEngine_GameObject.GetComponent<uScript_CustomEventVector4>();
            if ( null != component )
            {
               component.OnCustomEventVector4 -= Instance_OnCustomEventVector4_12;
            }
         }
      }
      if ( null != local_74_UnityEngine_GameObject )
      {
         {
            uScript_GameObject component = local_74_UnityEngine_GameObject.GetComponent<uScript_GameObject>();
            if ( null != component )
            {
               component.EnableEvent -= Instance_EnableEvent_68;
               component.DisableEvent -= Instance_DisableEvent_68;
               component.DestroyEvent -= Instance_DestroyEvent_68;
            }
         }
      }
      if ( null != local_75_UnityEngine_GameObject )
      {
         {
            uScript_Visibility component = local_75_UnityEngine_GameObject.GetComponent<uScript_Visibility>();
            if ( null != component )
            {
               component.BecameVisible -= Instance_BecameVisible_69;
               component.BecameInvisible -= Instance_BecameInvisible_69;
            }
         }
      }
      if ( null != local_297_UnityEngine_GameObject )
      {
         {
            uScript_Particle component = local_297_UnityEngine_GameObject.GetComponent<uScript_Particle>();
            if ( null != component )
            {
               component.Collision -= Instance_Collision_261;
            }
         }
      }
      if ( null != local_299_UnityEngine_GameObject )
      {
         {
            uScript_Collision component = local_299_UnityEngine_GameObject.GetComponent<uScript_Collision>();
            if ( null != component )
            {
               component.OnEnterCollision -= Instance_OnEnterCollision_268;
               component.OnExitCollision -= Instance_OnExitCollision_268;
               component.WhileInsideCollision -= Instance_WhileInsideCollision_268;
            }
         }
      }
      if ( null != local_301_UnityEngine_GameObject )
      {
         {
            uScript_Joint component = local_301_UnityEngine_GameObject.GetComponent<uScript_Joint>();
            if ( null != component )
            {
               component.JointBreak -= Instance_JointBreak_267;
            }
         }
      }
      if ( null != local_303_UnityEngine_GameObject )
      {
         {
            uScript_ProxyController component = local_303_UnityEngine_GameObject.GetComponent<uScript_ProxyController>();
            if ( null != component )
            {
               component.OnHit -= Instance_OnHit_266;
            }
         }
      }
      if ( null != local_305_UnityEngine_GameObject )
      {
         {
            uScript_Render component = local_305_UnityEngine_GameObject.GetComponent<uScript_Render>();
            if ( null != component )
            {
               component.PreCull -= Instance_PreCull_284;
               component.PreRender -= Instance_PreRender_284;
               component.PostRender -= Instance_PostRender_284;
               component.RenderObject -= Instance_RenderObject_284;
               component.WillRenderObject -= Instance_WillRenderObject_284;
            }
         }
      }
      if ( null != local_307_UnityEngine_GameObject )
      {
         {
            uScript_PostEffect component = local_307_UnityEngine_GameObject.GetComponent<uScript_PostEffect>();
            if ( null != component )
            {
               component.RenderImage -= Instance_RenderImage_283;
            }
         }
      }
      if ( null != local_310_UnityEngine_GameObject )
      {
         {
            uScript_Triggers component = local_310_UnityEngine_GameObject.GetComponent<uScript_Triggers>();
            if ( null != component )
            {
               component.OnEnterTrigger -= Instance_OnEnterTrigger_309;
               component.OnExitTrigger -= Instance_OnExitTrigger_309;
               component.WhileInsideTrigger -= Instance_WhileInsideTrigger_309;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_0 )
      {
         {
            uScript_ApplicationFocus component = event_UnityEngine_GameObject_Instance_0.GetComponent<uScript_ApplicationFocus>();
            if ( null != component )
            {
               component.FocusEvent -= Instance_FocusEvent_0;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_1 )
      {
         {
            uScript_ApplicationQuit component = event_UnityEngine_GameObject_Instance_1.GetComponent<uScript_ApplicationQuit>();
            if ( null != component )
            {
               component.QuitEvent -= Instance_QuitEvent_1;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_13 )
      {
         {
            uScript_Update component = event_UnityEngine_GameObject_Instance_13.GetComponent<uScript_Update>();
            if ( null != component )
            {
               component.OnUpdate -= Instance_OnUpdate_13;
               component.OnLateUpdate -= Instance_OnLateUpdate_13;
               component.OnFixedUpdate -= Instance_OnFixedUpdate_13;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_14 )
      {
         {
            if ( null == thisScriptsOnGuiListener )
            {
               //OnGUI need unique listeners so calls like GUI.depth will work across uScripts
               thisScriptsOnGuiListener = event_UnityEngine_GameObject_Instance_14.AddComponent<uScript_GUI>();
            }
            uScript_GUI component = thisScriptsOnGuiListener;
            if ( null != component )
            {
               component.OnGui -= Instance_OnGui_14;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_15 )
      {
         {
            uScript_Level component = event_UnityEngine_GameObject_Instance_15.GetComponent<uScript_Level>();
            if ( null != component )
            {
               component.LevelWasLoaded -= Instance_LevelWasLoaded_15;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_16 )
      {
         {
            uScript_Global component = event_UnityEngine_GameObject_Instance_16.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_16;
               component.uScriptLateStart -= Instance_uScriptLateStart_16;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_76 )
      {
         {
            uScript_Accelerometer component = event_UnityEngine_GameObject_Instance_76.GetComponent<uScript_Accelerometer>();
            if ( null != component )
            {
               component.OnAccelerationEvent -= Instance_OnAccelerationEvent_76;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_77 )
      {
         {
            uScript_DeviceOrientation component = event_UnityEngine_GameObject_Instance_77.GetComponent<uScript_DeviceOrientation>();
            if ( null != component )
            {
               component.OnDevicePortrait -= Instance_OnDevicePortrait_77;
               component.OnDevicePortraitUpsideDown -= Instance_OnDevicePortraitUpsideDown_77;
               component.OnDeviceLandscapeLeft -= Instance_OnDeviceLandscapeLeft_77;
               component.OnDeviceLandscapeRight -= Instance_OnDeviceLandscapeRight_77;
               component.OnDeviceFaceUp -= Instance_OnDeviceFaceUp_77;
               component.OnDeviceFaceDown -= Instance_OnDeviceFaceDown_77;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_78 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_78.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_78;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_79 )
      {
         {
            uScript_ManagedInput component = event_UnityEngine_GameObject_Instance_79.GetComponent<uScript_ManagedInput>();
            if ( null != component )
            {
               component.OnInputEvent -= Instance_OnInputEvent_79;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_80 )
      {
         {
            uScript_MouseAxis component = event_UnityEngine_GameObject_Instance_80.GetComponent<uScript_MouseAxis>();
            if ( null != component )
            {
               component.AxisEvent -= Instance_AxisEvent_80;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_81 )
      {
         {
            uScript_Mouse component = event_UnityEngine_GameObject_Instance_81.GetComponent<uScript_Mouse>();
            if ( null != component )
            {
               component.OnEnter -= Instance_OnEnter_81;
               component.OnOver -= Instance_OnOver_81;
               component.OnExit -= Instance_OnExit_81;
               component.OnDown -= Instance_OnDown_81;
               component.OnUp -= Instance_OnUp_81;
               component.OnDrag -= Instance_OnDrag_81;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_82 )
      {
         {
            uScript_OnScreenKeyboard component = event_UnityEngine_GameObject_Instance_82.GetComponent<uScript_OnScreenKeyboard>();
            if ( null != component )
            {
               component.OnKeyboardSlidOut -= Instance_OnKeyboardSlidOut_82;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_83 )
      {
         {
            uScript_Touch component = event_UnityEngine_GameObject_Instance_83.GetComponent<uScript_Touch>();
            if ( null != component )
            {
               component.OnTouchBegan -= Instance_OnTouchBegan_83;
               component.OnTouchMoved -= Instance_OnTouchMoved_83;
               component.OnTouchStationary -= Instance_OnTouchStationary_83;
               component.OnTouchEnded -= Instance_OnTouchEnded_83;
               component.OnTouchCanceled -= Instance_OnTouchCanceled_83;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_110 )
      {
         {
            uScript_NetworkClientConnection component = event_UnityEngine_GameObject_Instance_110.GetComponent<uScript_NetworkClientConnection>();
            if ( null != component )
            {
               component.ConnectedToServer -= Instance_ConnectedToServer_110;
               component.DisconnectedFromServer -= Instance_DisconnectedFromServer_110;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_111 )
      {
         {
            uScript_NetworkFailedConnection component = event_UnityEngine_GameObject_Instance_111.GetComponent<uScript_NetworkFailedConnection>();
            if ( null != component )
            {
               component.FailedToConnect -= Instance_FailedToConnect_111;
               component.FailedToConnectToMaster -= Instance_FailedToConnectToMaster_111;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_112 )
      {
         {
            uScript_NetworkInstantiate component = event_UnityEngine_GameObject_Instance_112.GetComponent<uScript_NetworkInstantiate>();
            if ( null != component )
            {
               component.OnInstantiate -= Instance_OnInstantiate_112;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_113 )
      {
         {
            uScript_NetworkMasterServer component = event_UnityEngine_GameObject_Instance_113.GetComponent<uScript_NetworkMasterServer>();
            if ( null != component )
            {
               component.OnEvent -= Instance_OnEvent_113;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_114 )
      {
         {
            uScript_NetworkSerialization component = event_UnityEngine_GameObject_Instance_114.GetComponent<uScript_NetworkSerialization>();
            if ( null != component )
            {
               component.OnSerialize -= Instance_OnSerialize_114;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_115 )
      {
         {
            uScript_NetworkServerInitialized component = event_UnityEngine_GameObject_Instance_115.GetComponent<uScript_NetworkServerInitialized>();
            if ( null != component )
            {
               component.OnInitialized -= Instance_OnInitialized_115;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_116 )
      {
         {
            uScript_NetworkServerPlayer component = event_UnityEngine_GameObject_Instance_116.GetComponent<uScript_NetworkServerPlayer>();
            if ( null != component )
            {
               component.PlayerConnected -= Instance_PlayerConnected_116;
               component.PlayerDisconnected -= Instance_PlayerDisconnected_116;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_Log_uScriptAct_Log_17.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_19.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_22.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_23.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_25.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_27.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_29.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_32.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_33.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_42.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_46.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_50.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_52.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_54.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_56.SetParent(g);
      logic_uScriptAct_AddInt_uScriptAct_AddInt_58.SetParent(g);
      logic_uScriptAct_AddInt_uScriptAct_AddInt_60.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_61.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_63.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_65.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_67.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_71.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_72.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_84.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_86.SetParent(g);
      logic_uScriptAct_AddInt_uScriptAct_AddInt_88.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_89.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_90.SetParent(g);
      logic_uScriptAct_AddInt_uScriptAct_AddInt_93.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_94.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_95.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_98.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_101.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_103.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_104.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_107.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_109.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_117.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_120.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_122.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_124.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_125.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_128.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_130.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_263.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_270.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_273.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_276.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_286.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_289.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_313.SetParent(g);
   }
   public void Awake()
   {
      
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
      
   }
   
   public void OnDestroy()
   {
   }
   
   void Instance_FocusEvent_0(object o, uScript_ApplicationFocus.ApplicationFocusEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_HasFocus_0 = e.HasFocus;
      //relay event to nodes
      Relay_FocusEvent_0( );
   }
   
   void Instance_QuitEvent_1(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_QuitEvent_1( );
   }
   
   void Instance_OnCustomEvent_2(object o, uScript_CustomEvent.CustomEventBoolArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_2 = e.Sender;
      event_UnityEngine_GameObject_EventName_2 = e.EventName;
      //relay event to nodes
      Relay_OnCustomEvent_2( );
   }
   
   void Instance_OnCustomEventBool_3(object o, uScript_CustomEventBool.CustomEventBoolArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_3 = e.Sender;
      event_UnityEngine_GameObject_EventName_3 = e.EventName;
      event_UnityEngine_GameObject_EventData_3 = e.EventData;
      //relay event to nodes
      Relay_OnCustomEventBool_3( );
   }
   
   void Instance_OnCustomEventColor_4(object o, uScript_CustomEventColor.CustomEventColorArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_4 = e.Sender;
      event_UnityEngine_GameObject_EventName_4 = e.EventName;
      event_UnityEngine_GameObject_EventData_4 = e.EventData;
      //relay event to nodes
      Relay_OnCustomEventColor_4( );
   }
   
   void Instance_OnCustomEventFloat_5(object o, uScript_CustomEventFloat.CustomEventFloatArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_5 = e.Sender;
      event_UnityEngine_GameObject_EventName_5 = e.EventName;
      event_UnityEngine_GameObject_EventData_5 = e.EventData;
      //relay event to nodes
      Relay_OnCustomEventFloat_5( );
   }
   
   void Instance_OnCustomEventGameObject_6(object o, uScript_CustomEventGameObject.CustomEventGameObjectArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_6 = e.Sender;
      event_UnityEngine_GameObject_EventName_6 = e.EventName;
      event_UnityEngine_GameObject_EventData_6 = e.EventData;
      //relay event to nodes
      Relay_OnCustomEventGameObject_6( );
   }
   
   void Instance_OnCustomEventInt_7(object o, uScript_CustomEventInt.CustomEventIntArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_7 = e.Sender;
      event_UnityEngine_GameObject_EventName_7 = e.EventName;
      event_UnityEngine_GameObject_EventData_7 = e.EventData;
      //relay event to nodes
      Relay_OnCustomEventInt_7( );
   }
   
   void Instance_OnCustomEventObject_8(object o, uScript_CustomEventObject.CustomEventObjectArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_8 = e.Sender;
      event_UnityEngine_GameObject_EventName_8 = e.EventName;
      event_UnityEngine_GameObject_EventData_8 = e.EventData;
      //relay event to nodes
      Relay_OnCustomEventObject_8( );
   }
   
   void Instance_OnCustomEventString_9(object o, uScript_CustomEventString.CustomEventStringArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_9 = e.Sender;
      event_UnityEngine_GameObject_EventName_9 = e.EventName;
      event_UnityEngine_GameObject_EventData_9 = e.EventData;
      //relay event to nodes
      Relay_OnCustomEventString_9( );
   }
   
   void Instance_OnCustomEventVector2_10(object o, uScript_CustomEventVector2.CustomEventVector2Args e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_10 = e.Sender;
      event_UnityEngine_GameObject_EventName_10 = e.EventName;
      event_UnityEngine_GameObject_EventData_10 = e.EventData;
      //relay event to nodes
      Relay_OnCustomEventVector2_10( );
   }
   
   void Instance_OnCustomEventVector3_11(object o, uScript_CustomEventVector3.CustomEventVector3Args e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_11 = e.Sender;
      event_UnityEngine_GameObject_EventName_11 = e.EventName;
      event_UnityEngine_GameObject_EventData_11 = e.EventData;
      //relay event to nodes
      Relay_OnCustomEventVector3_11( );
   }
   
   void Instance_OnCustomEventVector4_12(object o, uScript_CustomEventVector4.CustomEventVector4Args e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_12 = e.Sender;
      event_UnityEngine_GameObject_EventName_12 = e.EventName;
      event_UnityEngine_GameObject_EventData_12 = e.EventData;
      //relay event to nodes
      Relay_OnCustomEventVector4_12( );
   }
   
   void Instance_OnUpdate_13(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUpdate_13( );
   }
   
   void Instance_OnLateUpdate_13(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnLateUpdate_13( );
   }
   
   void Instance_OnFixedUpdate_13(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnFixedUpdate_13( );
   }
   
   void Instance_OnGui_14(object o, uScript_GUI.GUIEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GUIChanged_14 = e.GUIChanged;
      event_UnityEngine_GameObject_FocusedControl_14 = e.FocusedControl;
      //relay event to nodes
      Relay_OnGui_14( );
   }
   
   void Instance_LevelWasLoaded_15(object o, uScript_Level.LevelWasLoadedEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Level_15 = e.Level;
      //relay event to nodes
      Relay_LevelWasLoaded_15( );
   }
   
   void Instance_uScriptStart_16(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_16( );
   }
   
   void Instance_uScriptLateStart_16(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptLateStart_16( );
   }
   
   void Instance_EnableEvent_68(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_EnableEvent_68( );
   }
   
   void Instance_DisableEvent_68(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_DisableEvent_68( );
   }
   
   void Instance_DestroyEvent_68(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_DestroyEvent_68( );
   }
   
   void Instance_BecameVisible_69(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_BecameVisible_69( );
   }
   
   void Instance_BecameInvisible_69(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_BecameInvisible_69( );
   }
   
   void Instance_OnAccelerationEvent_76(object o, uScript_Accelerometer.AccelerometerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Acceleration_76 = e.Acceleration;
      event_UnityEngine_GameObject_DeltaTime_76 = e.DeltaTime;
      //relay event to nodes
      Relay_OnAccelerationEvent_76( );
   }
   
   void Instance_OnDevicePortrait_77(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnDevicePortrait_77( );
   }
   
   void Instance_OnDevicePortraitUpsideDown_77(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnDevicePortraitUpsideDown_77( );
   }
   
   void Instance_OnDeviceLandscapeLeft_77(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnDeviceLandscapeLeft_77( );
   }
   
   void Instance_OnDeviceLandscapeRight_77(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnDeviceLandscapeRight_77( );
   }
   
   void Instance_OnDeviceFaceUp_77(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnDeviceFaceUp_77( );
   }
   
   void Instance_OnDeviceFaceDown_77(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnDeviceFaceDown_77( );
   }
   
   void Instance_KeyEvent_78(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_78( );
   }
   
   void Instance_OnInputEvent_79(object o, uScript_ManagedInput.CustomEventBoolArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Horizontal_79 = e.Horizontal;
      event_UnityEngine_GameObject_Vertical_79 = e.Vertical;
      event_UnityEngine_GameObject_Fire1_79 = e.Fire1;
      event_UnityEngine_GameObject_Fire2_79 = e.Fire2;
      event_UnityEngine_GameObject_Fire3_79 = e.Fire3;
      event_UnityEngine_GameObject_Jump_79 = e.Jump;
      event_UnityEngine_GameObject_MouseX_79 = e.MouseX;
      event_UnityEngine_GameObject_MouseY_79 = e.MouseY;
      event_UnityEngine_GameObject_MouseScrollWheel_79 = e.MouseScrollWheel;
      event_UnityEngine_GameObject_WindowShakeX_79 = e.WindowShakeX;
      event_UnityEngine_GameObject_WindowShakeY_79 = e.WindowShakeY;
      //relay event to nodes
      Relay_OnInputEvent_79( );
   }
   
   void Instance_AxisEvent_80(object o, uScript_MouseAxis.CustomMouseAxisArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_MouseX_80 = e.MouseX;
      event_UnityEngine_GameObject_MouseY_80 = e.MouseY;
      event_UnityEngine_GameObject_Wheel_80 = e.Wheel;
      //relay event to nodes
      Relay_AxisEvent_80( );
   }
   
   void Instance_OnEnter_81(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnEnter_81( );
   }
   
   void Instance_OnOver_81(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnOver_81( );
   }
   
   void Instance_OnExit_81(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnExit_81( );
   }
   
   void Instance_OnDown_81(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnDown_81( );
   }
   
   void Instance_OnUp_81(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUp_81( );
   }
   
   void Instance_OnDrag_81(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnDrag_81( );
   }
   
   void Instance_OnKeyboardSlidOut_82(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnKeyboardSlidOut_82( );
   }
   
   void Instance_OnTouchBegan_83(object o, uScript_Touch.TouchEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_FingerId_83 = e.FingerId;
      event_UnityEngine_GameObject_Position_83 = e.Position;
      event_UnityEngine_GameObject_DeltaPosition_83 = e.DeltaPosition;
      event_UnityEngine_GameObject_DeltaTime_83 = e.DeltaTime;
      event_UnityEngine_GameObject_TapCount_83 = e.TapCount;
      //relay event to nodes
      Relay_OnTouchBegan_83( );
   }
   
   void Instance_OnTouchMoved_83(object o, uScript_Touch.TouchEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_FingerId_83 = e.FingerId;
      event_UnityEngine_GameObject_Position_83 = e.Position;
      event_UnityEngine_GameObject_DeltaPosition_83 = e.DeltaPosition;
      event_UnityEngine_GameObject_DeltaTime_83 = e.DeltaTime;
      event_UnityEngine_GameObject_TapCount_83 = e.TapCount;
      //relay event to nodes
      Relay_OnTouchMoved_83( );
   }
   
   void Instance_OnTouchStationary_83(object o, uScript_Touch.TouchEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_FingerId_83 = e.FingerId;
      event_UnityEngine_GameObject_Position_83 = e.Position;
      event_UnityEngine_GameObject_DeltaPosition_83 = e.DeltaPosition;
      event_UnityEngine_GameObject_DeltaTime_83 = e.DeltaTime;
      event_UnityEngine_GameObject_TapCount_83 = e.TapCount;
      //relay event to nodes
      Relay_OnTouchStationary_83( );
   }
   
   void Instance_OnTouchEnded_83(object o, uScript_Touch.TouchEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_FingerId_83 = e.FingerId;
      event_UnityEngine_GameObject_Position_83 = e.Position;
      event_UnityEngine_GameObject_DeltaPosition_83 = e.DeltaPosition;
      event_UnityEngine_GameObject_DeltaTime_83 = e.DeltaTime;
      event_UnityEngine_GameObject_TapCount_83 = e.TapCount;
      //relay event to nodes
      Relay_OnTouchEnded_83( );
   }
   
   void Instance_OnTouchCanceled_83(object o, uScript_Touch.TouchEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_FingerId_83 = e.FingerId;
      event_UnityEngine_GameObject_Position_83 = e.Position;
      event_UnityEngine_GameObject_DeltaPosition_83 = e.DeltaPosition;
      event_UnityEngine_GameObject_DeltaTime_83 = e.DeltaTime;
      event_UnityEngine_GameObject_TapCount_83 = e.TapCount;
      //relay event to nodes
      Relay_OnTouchCanceled_83( );
   }
   
   void Instance_ConnectedToServer_110(object o, uScript_NetworkClientConnection.NetworkClientConnectionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Failure_110 = e.Failure;
      //relay event to nodes
      Relay_ConnectedToServer_110( );
   }
   
   void Instance_DisconnectedFromServer_110(object o, uScript_NetworkClientConnection.NetworkClientConnectionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Failure_110 = e.Failure;
      //relay event to nodes
      Relay_DisconnectedFromServer_110( );
   }
   
   void Instance_FailedToConnect_111(object o, uScript_NetworkFailedConnection.NetworkFailedConnectionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Error_111 = e.Error;
      //relay event to nodes
      Relay_FailedToConnect_111( );
   }
   
   void Instance_FailedToConnectToMaster_111(object o, uScript_NetworkFailedConnection.NetworkFailedConnectionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Error_111 = e.Error;
      //relay event to nodes
      Relay_FailedToConnectToMaster_111( );
   }
   
   void Instance_OnInstantiate_112(object o, uScript_NetworkInstantiate.NetworkInstantiateEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_MessageInfo_112 = e.MessageInfo;
      //relay event to nodes
      Relay_OnInstantiate_112( );
   }
   
   void Instance_OnEvent_113(object o, uScript_NetworkMasterServer.NetworkMasterServerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_MasterServerEvent_113 = e.MasterServerEvent;
      //relay event to nodes
      Relay_OnEvent_113( );
   }
   
   void Instance_OnSerialize_114(object o, uScript_NetworkSerialization.NetworkSerializationEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_BitStream_114 = e.BitStream;
      event_UnityEngine_GameObject_MessageInfo_114 = e.MessageInfo;
      //relay event to nodes
      Relay_OnSerialize_114( );
   }
   
   void Instance_OnInitialized_115(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnInitialized_115( );
   }
   
   void Instance_PlayerConnected_116(object o, uScript_NetworkServerPlayer.NetworkServerPlayerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_NetworkPlayer_116 = e.NetworkPlayer;
      //relay event to nodes
      Relay_PlayerConnected_116( );
   }
   
   void Instance_PlayerDisconnected_116(object o, uScript_NetworkServerPlayer.NetworkServerPlayerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_NetworkPlayer_116 = e.NetworkPlayer;
      //relay event to nodes
      Relay_PlayerDisconnected_116( );
   }
   
   void Instance_Collision_261(object o, uScript_Particle.ParticleCollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_261 = e.GameObject;
      //relay event to nodes
      Relay_Collision_261( );
   }
   
   void Instance_OnHit_266(object o, uScript_ProxyController.ProxyControllerCollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_266 = e.GameObject;
      event_UnityEngine_GameObject_Controller_266 = e.Controller;
      event_UnityEngine_GameObject_Collider_266 = e.Collider;
      event_UnityEngine_GameObject_RigidBody_266 = e.RigidBody;
      event_UnityEngine_GameObject_Transform_266 = e.Transform;
      event_UnityEngine_GameObject_Point_266 = e.Point;
      event_UnityEngine_GameObject_Normal_266 = e.Normal;
      event_UnityEngine_GameObject_MoveDirection_266 = e.MoveDirection;
      event_UnityEngine_GameObject_MoveLength_266 = e.MoveLength;
      //relay event to nodes
      Relay_OnHit_266( );
   }
   
   void Instance_JointBreak_267(object o, uScript_Joint.JointBreakEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_BreakForce_267 = e.BreakForce;
      //relay event to nodes
      Relay_JointBreak_267( );
   }
   
   void Instance_OnEnterCollision_268(object o, uScript_Collision.CollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_RelativeVelocity_268 = e.RelativeVelocity;
      event_UnityEngine_GameObject_RigidBody_268 = e.RigidBody;
      event_UnityEngine_GameObject_Collider_268 = e.Collider;
      event_UnityEngine_GameObject_Transform_268 = e.Transform;
      event_UnityEngine_GameObject_Contacts_268 = e.Contacts;
      event_UnityEngine_GameObject_GameObject_268 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterCollision_268( );
   }
   
   void Instance_OnExitCollision_268(object o, uScript_Collision.CollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_RelativeVelocity_268 = e.RelativeVelocity;
      event_UnityEngine_GameObject_RigidBody_268 = e.RigidBody;
      event_UnityEngine_GameObject_Collider_268 = e.Collider;
      event_UnityEngine_GameObject_Transform_268 = e.Transform;
      event_UnityEngine_GameObject_Contacts_268 = e.Contacts;
      event_UnityEngine_GameObject_GameObject_268 = e.GameObject;
      //relay event to nodes
      Relay_OnExitCollision_268( );
   }
   
   void Instance_WhileInsideCollision_268(object o, uScript_Collision.CollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_RelativeVelocity_268 = e.RelativeVelocity;
      event_UnityEngine_GameObject_RigidBody_268 = e.RigidBody;
      event_UnityEngine_GameObject_Collider_268 = e.Collider;
      event_UnityEngine_GameObject_Transform_268 = e.Transform;
      event_UnityEngine_GameObject_Contacts_268 = e.Contacts;
      event_UnityEngine_GameObject_GameObject_268 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideCollision_268( );
   }
   
   void Instance_RenderImage_283(object o, uScript_PostEffect.PostEffectEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_SourceTexture_283 = e.SourceTexture;
      event_UnityEngine_GameObject_DestinationTexture_283 = e.DestinationTexture;
      //relay event to nodes
      Relay_RenderImage_283( );
   }
   
   void Instance_PreCull_284(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_PreCull_284( );
   }
   
   void Instance_PreRender_284(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_PreRender_284( );
   }
   
   void Instance_PostRender_284(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_PostRender_284( );
   }
   
   void Instance_RenderObject_284(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_RenderObject_284( );
   }
   
   void Instance_WillRenderObject_284(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_WillRenderObject_284( );
   }
   
   void Instance_OnEnterTrigger_309(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_309 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_309( );
   }
   
   void Instance_OnExitTrigger_309(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_309 = e.GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_309( );
   }
   
   void Instance_WhileInsideTrigger_309(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_309 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_309( );
   }
   
   void Relay_FocusEvent_0()
   {
      if (true == CheckDebugBreak("17b36543-4319-4571-9fea-20775272b21f", "Application Focus", Relay_FocusEvent_0)) return; 
      Relay_In_19();
   }
   
   void Relay_QuitEvent_1()
   {
      if (true == CheckDebugBreak("590aba8e-9959-4b4f-89e0-e00b6d99e314", "Application Quit", Relay_QuitEvent_1)) return; 
      Relay_In_17();
   }
   
   void Relay_OnCustomEvent_2()
   {
      if (true == CheckDebugBreak("049f55c3-bfe0-4b2d-8121-f234c3f59449", "Custom Event", Relay_OnCustomEvent_2)) return; 
      Relay_In_22();
   }
   
   void Relay_OnCustomEventBool_3()
   {
      if (true == CheckDebugBreak("b27d3864-ae6e-4405-80d0-47d0644fe6ec", "Custom Event (Bool)", Relay_OnCustomEventBool_3)) return; 
      Relay_In_23();
   }
   
   void Relay_OnCustomEventColor_4()
   {
      if (true == CheckDebugBreak("26c0b04d-7de1-4df8-a8e9-de3e348f7f32", "Custom Event (Color)", Relay_OnCustomEventColor_4)) return; 
      Relay_In_25();
   }
   
   void Relay_OnCustomEventFloat_5()
   {
      if (true == CheckDebugBreak("f376b8d6-3ca8-464f-80ce-e995b6acaa5a", "Custom Event (Float)", Relay_OnCustomEventFloat_5)) return; 
      Relay_In_27();
   }
   
   void Relay_OnCustomEventGameObject_6()
   {
      if (true == CheckDebugBreak("973a889f-991c-4b1d-9d1e-fb510b93cc6c", "Custom Event (GameObject)", Relay_OnCustomEventGameObject_6)) return; 
      Relay_In_29();
   }
   
   void Relay_OnCustomEventInt_7()
   {
      if (true == CheckDebugBreak("3a0a5a31-0477-483c-a04d-a70e2bd88761", "Custom Event (Int)", Relay_OnCustomEventInt_7)) return; 
      Relay_In_32();
   }
   
   void Relay_OnCustomEventObject_8()
   {
      if (true == CheckDebugBreak("4112da2a-f93f-4b9e-8a9e-2048ea294369", "Custom Event (Object)", Relay_OnCustomEventObject_8)) return; 
      Relay_In_33();
   }
   
   void Relay_OnCustomEventString_9()
   {
      if (true == CheckDebugBreak("6208efba-ac45-4084-af85-78b514b32772", "Custom Event (String)", Relay_OnCustomEventString_9)) return; 
      Relay_In_42();
   }
   
   void Relay_OnCustomEventVector2_10()
   {
      if (true == CheckDebugBreak("e8fe91a0-683f-4701-bd1d-a035ac2e0d5d", "Custom Event (Vector2)", Relay_OnCustomEventVector2_10)) return; 
      Relay_In_46();
   }
   
   void Relay_OnCustomEventVector3_11()
   {
      if (true == CheckDebugBreak("f3acce0e-1464-4e97-8012-b4da52ec2967", "Custom Event (Vector3)", Relay_OnCustomEventVector3_11)) return; 
      Relay_In_50();
   }
   
   void Relay_OnCustomEventVector4_12()
   {
      if (true == CheckDebugBreak("c863f386-5d5c-4b31-b076-81b08f22e0de", "Custom Event (Vector4)", Relay_OnCustomEventVector4_12)) return; 
      Relay_In_52();
   }
   
   void Relay_OnUpdate_13()
   {
      if (true == CheckDebugBreak("f899854a-8cb7-4586-8ad9-adf1d9397a85", "Global Update", Relay_OnUpdate_13)) return; 
      Relay_In_56();
   }
   
   void Relay_OnLateUpdate_13()
   {
      if (true == CheckDebugBreak("f899854a-8cb7-4586-8ad9-adf1d9397a85", "Global Update", Relay_OnLateUpdate_13)) return; 
      Relay_In_89();
   }
   
   void Relay_OnFixedUpdate_13()
   {
      if (true == CheckDebugBreak("f899854a-8cb7-4586-8ad9-adf1d9397a85", "Global Update", Relay_OnFixedUpdate_13)) return; 
      Relay_In_94();
   }
   
   void Relay_OnGui_14()
   {
      if (true == CheckDebugBreak("3b100514-2e87-435f-b7ed-09b5c037eedc", "GUI Events", Relay_OnGui_14)) return; 
      Relay_In_61();
   }
   
   void Relay_LevelWasLoaded_15()
   {
      if (true == CheckDebugBreak("63ecc4d6-d3b8-485e-bc88-a94bcf6dc0a1", "Level Load", Relay_LevelWasLoaded_15)) return; 
      Relay_In_65();
   }
   
   void Relay_uScriptStart_16()
   {
      if (true == CheckDebugBreak("873ec68b-4713-4af2-ad88-882235402ac6", "uScript Events", Relay_uScriptStart_16)) return; 
      Relay_In_67();
   }
   
   void Relay_uScriptLateStart_16()
   {
      if (true == CheckDebugBreak("873ec68b-4713-4af2-ad88-882235402ac6", "uScript Events", Relay_uScriptLateStart_16)) return; 
      Relay_In_67();
   }
   
   void Relay_In_17()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("89f116ae-e426-4035-8f94-e6bcea9dd682", "Log", Relay_In_17)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_18_System_String);
               logic_uScriptAct_Log_Target_17 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_17.In(logic_uScriptAct_Log_Prefix_17, logic_uScriptAct_Log_Target_17, logic_uScriptAct_Log_Postfix_17);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_19()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d7dc065a-987c-482b-b9ac-d6516234de5f", "Log", Relay_In_19)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_20_System_String);
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_22()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0e0a45d6-a6be-45e7-9c39-ba90786fa488", "Log", Relay_In_22)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_21_System_String);
               logic_uScriptAct_Log_Target_22 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_22.In(logic_uScriptAct_Log_Prefix_22, logic_uScriptAct_Log_Target_22, logic_uScriptAct_Log_Postfix_22);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_23()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("cf4edaf4-f2cd-4fe2-9788-ad9dcfe31dba", "Log", Relay_In_23)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_24_System_String);
               logic_uScriptAct_Log_Target_23 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_23.In(logic_uScriptAct_Log_Prefix_23, logic_uScriptAct_Log_Target_23, logic_uScriptAct_Log_Postfix_23);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_25()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0228cdd0-6a9c-437b-a2c7-822d7487e65f", "Log", Relay_In_25)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_26_System_String);
               logic_uScriptAct_Log_Target_25 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_25.In(logic_uScriptAct_Log_Prefix_25, logic_uScriptAct_Log_Target_25, logic_uScriptAct_Log_Postfix_25);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_27()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("07bd9405-b149-4270-9318-997be65d87e5", "Log", Relay_In_27)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_28_System_String);
               logic_uScriptAct_Log_Target_27 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_27.In(logic_uScriptAct_Log_Prefix_27, logic_uScriptAct_Log_Target_27, logic_uScriptAct_Log_Postfix_27);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_29()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("66579a9e-78d9-4f46-845a-2dd67b17a046", "Log", Relay_In_29)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_30_System_String);
               logic_uScriptAct_Log_Target_29 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_29.In(logic_uScriptAct_Log_Prefix_29, logic_uScriptAct_Log_Target_29, logic_uScriptAct_Log_Postfix_29);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_32()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a676bec8-0b35-4556-876c-32d91d5bbb95", "Log", Relay_In_32)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_31_System_String);
               logic_uScriptAct_Log_Target_32 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_32.In(logic_uScriptAct_Log_Prefix_32, logic_uScriptAct_Log_Target_32, logic_uScriptAct_Log_Postfix_32);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_33()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f9825b5d-7e47-44a0-b29d-61b9e218fb40", "Log", Relay_In_33)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_34_System_String);
               logic_uScriptAct_Log_Target_33 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_33.In(logic_uScriptAct_Log_Prefix_33, logic_uScriptAct_Log_Target_33, logic_uScriptAct_Log_Postfix_33);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_42()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2c792852-97d2-47c2-af47-bc875b2b3d29", "Log", Relay_In_42)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_43_System_String);
               logic_uScriptAct_Log_Target_42 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_42.In(logic_uScriptAct_Log_Prefix_42, logic_uScriptAct_Log_Target_42, logic_uScriptAct_Log_Postfix_42);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_46()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("99d0c216-dbb4-4134-b619-ba1c0995cc77", "Log", Relay_In_46)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_47_System_String);
               logic_uScriptAct_Log_Target_46 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_46.In(logic_uScriptAct_Log_Prefix_46, logic_uScriptAct_Log_Target_46, logic_uScriptAct_Log_Postfix_46);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_50()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1095298b-efc2-4ceb-86fe-b1d2cd69a6f1", "Log", Relay_In_50)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_51_System_String);
               logic_uScriptAct_Log_Target_50 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_50.In(logic_uScriptAct_Log_Prefix_50, logic_uScriptAct_Log_Target_50, logic_uScriptAct_Log_Postfix_50);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_52()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("047292d8-a028-4c06-bef8-68d395a7acd7", "Log", Relay_In_52)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_53_System_String);
               logic_uScriptAct_Log_Target_52 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_52.In(logic_uScriptAct_Log_Prefix_52, logic_uScriptAct_Log_Target_52, logic_uScriptAct_Log_Postfix_52);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_54()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ddf0c6ca-d32c-4f23-b15c-7f521dd38313", "Log", Relay_In_54)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_55_System_String);
               logic_uScriptAct_Log_Target_54 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_54.In(logic_uScriptAct_Log_Prefix_54, logic_uScriptAct_Log_Target_54, logic_uScriptAct_Log_Postfix_54);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_56()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d86caf4a-9c66-4dd6-a42c-dd2e8096c859", "Int Counter", Relay_In_56)) return; 
         {
            {
            }
            {
               logic_uScriptCon_IntCounter_B_56 = local_57_System_Int32;
               
            }
            {
            }
         }
         logic_uScriptCon_IntCounter_uScriptCon_IntCounter_56.In(logic_uScriptCon_IntCounter_A_56, logic_uScriptCon_IntCounter_B_56, out logic_uScriptCon_IntCounter_currentValue_56);
         local_57_System_Int32 = logic_uScriptCon_IntCounter_currentValue_56;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_56.GreaterThan;
         
         if ( test_0 == true )
         {
            Relay_In_58();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Int Counter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Reset_56()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d86caf4a-9c66-4dd6-a42c-dd2e8096c859", "Int Counter", Relay_Reset_56)) return; 
         {
            {
            }
            {
               logic_uScriptCon_IntCounter_B_56 = local_57_System_Int32;
               
            }
            {
            }
         }
         logic_uScriptCon_IntCounter_uScriptCon_IntCounter_56.Reset(logic_uScriptCon_IntCounter_A_56, logic_uScriptCon_IntCounter_B_56, out logic_uScriptCon_IntCounter_currentValue_56);
         local_57_System_Int32 = logic_uScriptCon_IntCounter_currentValue_56;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_56.GreaterThan;
         
         if ( test_0 == true )
         {
            Relay_In_58();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Int Counter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_58()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8c10099a-8a00-4f3e-a3fe-30ae2d3145d4", "Add Int", Relay_In_58)) return; 
         {
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_57_System_Int32);
               logic_uScriptAct_AddInt_A_58 = properties.ToArray();
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddInt_uScriptAct_AddInt_58.In(logic_uScriptAct_AddInt_A_58, logic_uScriptAct_AddInt_B_58, out logic_uScriptAct_AddInt_IntResult_58, out logic_uScriptAct_AddInt_FloatResult_58);
         local_57_System_Int32 = logic_uScriptAct_AddInt_IntResult_58;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddInt_uScriptAct_AddInt_58.Out;
         
         if ( test_0 == true )
         {
            Relay_In_54();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Add Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_60()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("64e92474-a133-437f-8fd2-5abd8a3787f6", "Add Int", Relay_In_60)) return; 
         {
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_62_System_Int32);
               logic_uScriptAct_AddInt_A_60 = properties.ToArray();
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddInt_uScriptAct_AddInt_60.In(logic_uScriptAct_AddInt_A_60, logic_uScriptAct_AddInt_B_60, out logic_uScriptAct_AddInt_IntResult_60, out logic_uScriptAct_AddInt_FloatResult_60);
         local_62_System_Int32 = logic_uScriptAct_AddInt_IntResult_60;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddInt_uScriptAct_AddInt_60.Out;
         
         if ( test_0 == true )
         {
            Relay_In_63();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Add Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_61()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2c9845b5-70d0-4bb5-bde5-bce425d07bbc", "Int Counter", Relay_In_61)) return; 
         {
            {
            }
            {
               logic_uScriptCon_IntCounter_B_61 = local_62_System_Int32;
               
            }
            {
            }
         }
         logic_uScriptCon_IntCounter_uScriptCon_IntCounter_61.In(logic_uScriptCon_IntCounter_A_61, logic_uScriptCon_IntCounter_B_61, out logic_uScriptCon_IntCounter_currentValue_61);
         local_62_System_Int32 = logic_uScriptCon_IntCounter_currentValue_61;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_61.GreaterThan;
         
         if ( test_0 == true )
         {
            Relay_In_60();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Int Counter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Reset_61()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2c9845b5-70d0-4bb5-bde5-bce425d07bbc", "Int Counter", Relay_Reset_61)) return; 
         {
            {
            }
            {
               logic_uScriptCon_IntCounter_B_61 = local_62_System_Int32;
               
            }
            {
            }
         }
         logic_uScriptCon_IntCounter_uScriptCon_IntCounter_61.Reset(logic_uScriptCon_IntCounter_A_61, logic_uScriptCon_IntCounter_B_61, out logic_uScriptCon_IntCounter_currentValue_61);
         local_62_System_Int32 = logic_uScriptCon_IntCounter_currentValue_61;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_61.GreaterThan;
         
         if ( test_0 == true )
         {
            Relay_In_60();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Int Counter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_63()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("eb4b7427-8ca2-427b-874b-478db031ee35", "Log", Relay_In_63)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_59_System_String);
               logic_uScriptAct_Log_Target_63 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_63.In(logic_uScriptAct_Log_Prefix_63, logic_uScriptAct_Log_Target_63, logic_uScriptAct_Log_Postfix_63);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_65()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6e6aaeb9-ab5a-45a2-90b5-6794de308222", "Log", Relay_In_65)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_64_System_String);
               logic_uScriptAct_Log_Target_65 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_65.In(logic_uScriptAct_Log_Prefix_65, logic_uScriptAct_Log_Target_65, logic_uScriptAct_Log_Postfix_65);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_67()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2c1ff6be-b303-4c24-a14b-002da78c7a43", "Log", Relay_In_67)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_66_System_String);
               logic_uScriptAct_Log_Target_67 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_67.In(logic_uScriptAct_Log_Prefix_67, logic_uScriptAct_Log_Target_67, logic_uScriptAct_Log_Postfix_67);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_EnableEvent_68()
   {
      if (true == CheckDebugBreak("64976a28-a5f5-4066-9d2f-f15b2fcc3907", "GameObject Events", Relay_EnableEvent_68)) return; 
      Relay_In_71();
   }
   
   void Relay_DisableEvent_68()
   {
      if (true == CheckDebugBreak("64976a28-a5f5-4066-9d2f-f15b2fcc3907", "GameObject Events", Relay_DisableEvent_68)) return; 
      Relay_In_71();
   }
   
   void Relay_DestroyEvent_68()
   {
      if (true == CheckDebugBreak("64976a28-a5f5-4066-9d2f-f15b2fcc3907", "GameObject Events", Relay_DestroyEvent_68)) return; 
      Relay_In_71();
   }
   
   void Relay_BecameVisible_69()
   {
      if (true == CheckDebugBreak("e8def8d0-6b74-4dbf-9269-c5f58300b091", "Visibility Events", Relay_BecameVisible_69)) return; 
      Relay_In_72();
   }
   
   void Relay_BecameInvisible_69()
   {
      if (true == CheckDebugBreak("e8def8d0-6b74-4dbf-9269-c5f58300b091", "Visibility Events", Relay_BecameInvisible_69)) return; 
      Relay_In_72();
   }
   
   void Relay_In_71()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f24d422f-a58b-4808-908e-54b21fc9292b", "Log", Relay_In_71)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_70_System_String);
               logic_uScriptAct_Log_Target_71 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_71.In(logic_uScriptAct_Log_Prefix_71, logic_uScriptAct_Log_Target_71, logic_uScriptAct_Log_Postfix_71);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_72()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f98b3ebc-2950-45bc-90ce-9b0335c3952e", "Log", Relay_In_72)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_73_System_String);
               logic_uScriptAct_Log_Target_72 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_72.In(logic_uScriptAct_Log_Prefix_72, logic_uScriptAct_Log_Target_72, logic_uScriptAct_Log_Postfix_72);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnAccelerationEvent_76()
   {
      if (true == CheckDebugBreak("1b3813c1-efde-4c26-aa6f-0e4e5bc2ac82", "Accelerometer Events", Relay_OnAccelerationEvent_76)) return; 
      Relay_In_84();
   }
   
   void Relay_OnDevicePortrait_77()
   {
      if (true == CheckDebugBreak("b9ab46d6-efb1-49ab-b17d-92643d9b0ed8", "Device Orientation Events", Relay_OnDevicePortrait_77)) return; 
      Relay_In_86();
   }
   
   void Relay_OnDevicePortraitUpsideDown_77()
   {
      if (true == CheckDebugBreak("b9ab46d6-efb1-49ab-b17d-92643d9b0ed8", "Device Orientation Events", Relay_OnDevicePortraitUpsideDown_77)) return; 
      Relay_In_86();
   }
   
   void Relay_OnDeviceLandscapeLeft_77()
   {
      if (true == CheckDebugBreak("b9ab46d6-efb1-49ab-b17d-92643d9b0ed8", "Device Orientation Events", Relay_OnDeviceLandscapeLeft_77)) return; 
      Relay_In_86();
   }
   
   void Relay_OnDeviceLandscapeRight_77()
   {
      if (true == CheckDebugBreak("b9ab46d6-efb1-49ab-b17d-92643d9b0ed8", "Device Orientation Events", Relay_OnDeviceLandscapeRight_77)) return; 
      Relay_In_86();
   }
   
   void Relay_OnDeviceFaceUp_77()
   {
      if (true == CheckDebugBreak("b9ab46d6-efb1-49ab-b17d-92643d9b0ed8", "Device Orientation Events", Relay_OnDeviceFaceUp_77)) return; 
      Relay_In_86();
   }
   
   void Relay_OnDeviceFaceDown_77()
   {
      if (true == CheckDebugBreak("b9ab46d6-efb1-49ab-b17d-92643d9b0ed8", "Device Orientation Events", Relay_OnDeviceFaceDown_77)) return; 
      Relay_In_86();
   }
   
   void Relay_KeyEvent_78()
   {
      if (true == CheckDebugBreak("5c2a22bf-b59b-4eec-a2ad-f457c0d0de4d", "Input Events", Relay_KeyEvent_78)) return; 
      Relay_In_98();
   }
   
   void Relay_OnInputEvent_79()
   {
      if (true == CheckDebugBreak("2ada240a-7309-4f3e-9904-62ef5d8cd256", "Managed Input Events", Relay_OnInputEvent_79)) return; 
      Relay_In_101();
   }
   
   void Relay_AxisEvent_80()
   {
      if (true == CheckDebugBreak("13489f7e-25c6-49d0-a8fa-27745b5299d9", "Mouse Axis", Relay_AxisEvent_80)) return; 
      Relay_In_103();
   }
   
   void Relay_OnEnter_81()
   {
      if (true == CheckDebugBreak("50bba20f-349a-4e5a-8445-83129d9a3405", "Mouse Cursor Events", Relay_OnEnter_81)) return; 
      Relay_In_104();
   }
   
   void Relay_OnOver_81()
   {
      if (true == CheckDebugBreak("50bba20f-349a-4e5a-8445-83129d9a3405", "Mouse Cursor Events", Relay_OnOver_81)) return; 
      Relay_In_104();
   }
   
   void Relay_OnExit_81()
   {
      if (true == CheckDebugBreak("50bba20f-349a-4e5a-8445-83129d9a3405", "Mouse Cursor Events", Relay_OnExit_81)) return; 
      Relay_In_104();
   }
   
   void Relay_OnDown_81()
   {
      if (true == CheckDebugBreak("50bba20f-349a-4e5a-8445-83129d9a3405", "Mouse Cursor Events", Relay_OnDown_81)) return; 
      Relay_In_104();
   }
   
   void Relay_OnUp_81()
   {
      if (true == CheckDebugBreak("50bba20f-349a-4e5a-8445-83129d9a3405", "Mouse Cursor Events", Relay_OnUp_81)) return; 
      Relay_In_104();
   }
   
   void Relay_OnDrag_81()
   {
      if (true == CheckDebugBreak("50bba20f-349a-4e5a-8445-83129d9a3405", "Mouse Cursor Events", Relay_OnDrag_81)) return; 
      Relay_In_104();
   }
   
   void Relay_OnKeyboardSlidOut_82()
   {
      if (true == CheckDebugBreak("21acdb57-678c-4b06-b10f-0243b875d558", "On-Screen Keyboard Events", Relay_OnKeyboardSlidOut_82)) return; 
      Relay_In_107();
   }
   
   void Relay_OnTouchBegan_83()
   {
      if (true == CheckDebugBreak("4020f18a-f2e1-4317-8e4b-fb99a46ea9f7", "Touch Events", Relay_OnTouchBegan_83)) return; 
      Relay_In_109();
   }
   
   void Relay_OnTouchMoved_83()
   {
      if (true == CheckDebugBreak("4020f18a-f2e1-4317-8e4b-fb99a46ea9f7", "Touch Events", Relay_OnTouchMoved_83)) return; 
      Relay_In_109();
   }
   
   void Relay_OnTouchStationary_83()
   {
      if (true == CheckDebugBreak("4020f18a-f2e1-4317-8e4b-fb99a46ea9f7", "Touch Events", Relay_OnTouchStationary_83)) return; 
      Relay_In_109();
   }
   
   void Relay_OnTouchEnded_83()
   {
      if (true == CheckDebugBreak("4020f18a-f2e1-4317-8e4b-fb99a46ea9f7", "Touch Events", Relay_OnTouchEnded_83)) return; 
      Relay_In_109();
   }
   
   void Relay_OnTouchCanceled_83()
   {
      if (true == CheckDebugBreak("4020f18a-f2e1-4317-8e4b-fb99a46ea9f7", "Touch Events", Relay_OnTouchCanceled_83)) return; 
      Relay_In_109();
   }
   
   void Relay_In_84()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0942dfa4-57f0-437b-b19f-213e2fc7f537", "Log", Relay_In_84)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_85_System_String);
               logic_uScriptAct_Log_Target_84 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_84.In(logic_uScriptAct_Log_Prefix_84, logic_uScriptAct_Log_Target_84, logic_uScriptAct_Log_Postfix_84);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_86()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1a2bb6d7-4ed3-4dae-9a7c-04b1778ad82b", "Log", Relay_In_86)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_87_System_String);
               logic_uScriptAct_Log_Target_86 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_86.In(logic_uScriptAct_Log_Prefix_86, logic_uScriptAct_Log_Target_86, logic_uScriptAct_Log_Postfix_86);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_88()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d00b6de7-6aa3-4773-861f-73f3f77054cb", "Add Int", Relay_In_88)) return; 
         {
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_91_System_Int32);
               logic_uScriptAct_AddInt_A_88 = properties.ToArray();
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddInt_uScriptAct_AddInt_88.In(logic_uScriptAct_AddInt_A_88, logic_uScriptAct_AddInt_B_88, out logic_uScriptAct_AddInt_IntResult_88, out logic_uScriptAct_AddInt_FloatResult_88);
         local_91_System_Int32 = logic_uScriptAct_AddInt_IntResult_88;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddInt_uScriptAct_AddInt_88.Out;
         
         if ( test_0 == true )
         {
            Relay_In_90();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Add Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_89()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("407304e3-1d92-4258-a811-6ffdd0123fa9", "Int Counter", Relay_In_89)) return; 
         {
            {
            }
            {
               logic_uScriptCon_IntCounter_B_89 = local_91_System_Int32;
               
            }
            {
            }
         }
         logic_uScriptCon_IntCounter_uScriptCon_IntCounter_89.In(logic_uScriptCon_IntCounter_A_89, logic_uScriptCon_IntCounter_B_89, out logic_uScriptCon_IntCounter_currentValue_89);
         local_91_System_Int32 = logic_uScriptCon_IntCounter_currentValue_89;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_89.GreaterThan;
         
         if ( test_0 == true )
         {
            Relay_In_88();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Int Counter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Reset_89()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("407304e3-1d92-4258-a811-6ffdd0123fa9", "Int Counter", Relay_Reset_89)) return; 
         {
            {
            }
            {
               logic_uScriptCon_IntCounter_B_89 = local_91_System_Int32;
               
            }
            {
            }
         }
         logic_uScriptCon_IntCounter_uScriptCon_IntCounter_89.Reset(logic_uScriptCon_IntCounter_A_89, logic_uScriptCon_IntCounter_B_89, out logic_uScriptCon_IntCounter_currentValue_89);
         local_91_System_Int32 = logic_uScriptCon_IntCounter_currentValue_89;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_89.GreaterThan;
         
         if ( test_0 == true )
         {
            Relay_In_88();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Int Counter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_90()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ac1f628d-b44b-49a2-b175-f3718cd699f1", "Log", Relay_In_90)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_92_System_String);
               logic_uScriptAct_Log_Target_90 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_90.In(logic_uScriptAct_Log_Prefix_90, logic_uScriptAct_Log_Target_90, logic_uScriptAct_Log_Postfix_90);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_93()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("94f9f654-093a-4ec4-8e56-aeb3e2e0de07", "Add Int", Relay_In_93)) return; 
         {
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_96_System_Int32);
               logic_uScriptAct_AddInt_A_93 = properties.ToArray();
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddInt_uScriptAct_AddInt_93.In(logic_uScriptAct_AddInt_A_93, logic_uScriptAct_AddInt_B_93, out logic_uScriptAct_AddInt_IntResult_93, out logic_uScriptAct_AddInt_FloatResult_93);
         local_96_System_Int32 = logic_uScriptAct_AddInt_IntResult_93;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddInt_uScriptAct_AddInt_93.Out;
         
         if ( test_0 == true )
         {
            Relay_In_95();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Add Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_94()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("75bb8334-1dc3-41e5-8423-8a5ce0083894", "Int Counter", Relay_In_94)) return; 
         {
            {
            }
            {
               logic_uScriptCon_IntCounter_B_94 = local_96_System_Int32;
               
            }
            {
            }
         }
         logic_uScriptCon_IntCounter_uScriptCon_IntCounter_94.In(logic_uScriptCon_IntCounter_A_94, logic_uScriptCon_IntCounter_B_94, out logic_uScriptCon_IntCounter_currentValue_94);
         local_96_System_Int32 = logic_uScriptCon_IntCounter_currentValue_94;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_94.GreaterThan;
         
         if ( test_0 == true )
         {
            Relay_In_93();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Int Counter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Reset_94()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("75bb8334-1dc3-41e5-8423-8a5ce0083894", "Int Counter", Relay_Reset_94)) return; 
         {
            {
            }
            {
               logic_uScriptCon_IntCounter_B_94 = local_96_System_Int32;
               
            }
            {
            }
         }
         logic_uScriptCon_IntCounter_uScriptCon_IntCounter_94.Reset(logic_uScriptCon_IntCounter_A_94, logic_uScriptCon_IntCounter_B_94, out logic_uScriptCon_IntCounter_currentValue_94);
         local_96_System_Int32 = logic_uScriptCon_IntCounter_currentValue_94;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_94.GreaterThan;
         
         if ( test_0 == true )
         {
            Relay_In_93();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Int Counter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_95()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("14924f97-8c0a-4e08-91b9-8e9b986ecada", "Log", Relay_In_95)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_97_System_String);
               logic_uScriptAct_Log_Target_95 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_95.In(logic_uScriptAct_Log_Prefix_95, logic_uScriptAct_Log_Target_95, logic_uScriptAct_Log_Postfix_95);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_98()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("24e19fc1-a072-4ce5-9cd1-bd55eb6dcdcf", "Log", Relay_In_98)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_99_System_String);
               logic_uScriptAct_Log_Target_98 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_98.In(logic_uScriptAct_Log_Prefix_98, logic_uScriptAct_Log_Target_98, logic_uScriptAct_Log_Postfix_98);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_101()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("30a9d1f1-9d7c-4882-9d87-9819aac9c5c5", "Log", Relay_In_101)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_100_System_String);
               logic_uScriptAct_Log_Target_101 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_101.In(logic_uScriptAct_Log_Prefix_101, logic_uScriptAct_Log_Target_101, logic_uScriptAct_Log_Postfix_101);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_103()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("663fc962-9948-46ff-985d-800c8da47ed9", "Log", Relay_In_103)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_102_System_String);
               logic_uScriptAct_Log_Target_103 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_103.In(logic_uScriptAct_Log_Prefix_103, logic_uScriptAct_Log_Target_103, logic_uScriptAct_Log_Postfix_103);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_104()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3b0fbb0a-cd79-4d61-92d3-e4aadf048ca0", "Log", Relay_In_104)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_105_System_String);
               logic_uScriptAct_Log_Target_104 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_104.In(logic_uScriptAct_Log_Prefix_104, logic_uScriptAct_Log_Target_104, logic_uScriptAct_Log_Postfix_104);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_107()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9885cafe-cb34-4d7b-90fa-385b1c70b28c", "Log", Relay_In_107)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_106_System_String);
               logic_uScriptAct_Log_Target_107 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_107.In(logic_uScriptAct_Log_Prefix_107, logic_uScriptAct_Log_Target_107, logic_uScriptAct_Log_Postfix_107);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_109()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e708487c-be87-4faf-9d92-e5b5429a8a76", "Log", Relay_In_109)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_108_System_String);
               logic_uScriptAct_Log_Target_109 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_109.In(logic_uScriptAct_Log_Prefix_109, logic_uScriptAct_Log_Target_109, logic_uScriptAct_Log_Postfix_109);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ConnectedToServer_110()
   {
      if (true == CheckDebugBreak("6c201bf4-92e3-4182-afe0-896d5587248c", "Network Client Connection", Relay_ConnectedToServer_110)) return; 
      Relay_In_117();
   }
   
   void Relay_DisconnectedFromServer_110()
   {
      if (true == CheckDebugBreak("6c201bf4-92e3-4182-afe0-896d5587248c", "Network Client Connection", Relay_DisconnectedFromServer_110)) return; 
      Relay_In_117();
   }
   
   void Relay_FailedToConnect_111()
   {
      if (true == CheckDebugBreak("62d19113-5170-4455-b488-80e7bb58552e", "Network Failed Connection", Relay_FailedToConnect_111)) return; 
      Relay_In_120();
   }
   
   void Relay_FailedToConnectToMaster_111()
   {
      if (true == CheckDebugBreak("62d19113-5170-4455-b488-80e7bb58552e", "Network Failed Connection", Relay_FailedToConnectToMaster_111)) return; 
      Relay_In_120();
   }
   
   void Relay_OnInstantiate_112()
   {
      if (true == CheckDebugBreak("2088f375-a24a-4cde-b2fd-72f52296d4b3", "Network Instantiate", Relay_OnInstantiate_112)) return; 
      Relay_In_122();
   }
   
   void Relay_OnEvent_113()
   {
      if (true == CheckDebugBreak("c7e16c8b-49ba-405d-bc4e-ded09b56bbe9", "Network Master Server", Relay_OnEvent_113)) return; 
      Relay_In_130();
   }
   
   void Relay_OnSerialize_114()
   {
      if (true == CheckDebugBreak("ad780df2-991c-4971-a5ae-32ea27d0cc4d", "Network Serialization", Relay_OnSerialize_114)) return; 
      Relay_In_124();
   }
   
   void Relay_OnInitialized_115()
   {
      if (true == CheckDebugBreak("50e6a64f-105e-4734-a819-9faa3ab507ae", "Network Server Initialized", Relay_OnInitialized_115)) return; 
      Relay_In_125();
   }
   
   void Relay_PlayerConnected_116()
   {
      if (true == CheckDebugBreak("326996a4-97af-46cf-a04b-0809d0bee471", "Network Server Player", Relay_PlayerConnected_116)) return; 
      Relay_In_128();
   }
   
   void Relay_PlayerDisconnected_116()
   {
      if (true == CheckDebugBreak("326996a4-97af-46cf-a04b-0809d0bee471", "Network Server Player", Relay_PlayerDisconnected_116)) return; 
      Relay_In_128();
   }
   
   void Relay_In_117()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("bec982d4-8fad-4e43-84ba-64958aa685fd", "Log", Relay_In_117)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_118_System_String);
               logic_uScriptAct_Log_Target_117 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_117.In(logic_uScriptAct_Log_Prefix_117, logic_uScriptAct_Log_Target_117, logic_uScriptAct_Log_Postfix_117);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_120()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("28a75744-4cec-4edd-994f-168583e511c0", "Log", Relay_In_120)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_119_System_String);
               logic_uScriptAct_Log_Target_120 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_120.In(logic_uScriptAct_Log_Prefix_120, logic_uScriptAct_Log_Target_120, logic_uScriptAct_Log_Postfix_120);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_122()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b7492f57-6a55-46b2-aae2-192dceb5bce8", "Log", Relay_In_122)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_121_System_String);
               logic_uScriptAct_Log_Target_122 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_122.In(logic_uScriptAct_Log_Prefix_122, logic_uScriptAct_Log_Target_122, logic_uScriptAct_Log_Postfix_122);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_124()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f71d2cdd-3901-4cde-9b80-e5b2aec42dac", "Log", Relay_In_124)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_123_System_String);
               logic_uScriptAct_Log_Target_124 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_124.In(logic_uScriptAct_Log_Prefix_124, logic_uScriptAct_Log_Target_124, logic_uScriptAct_Log_Postfix_124);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_125()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ec04526c-d3ba-438f-afa6-4598cf6c2e40", "Log", Relay_In_125)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_126_System_String);
               logic_uScriptAct_Log_Target_125 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_125.In(logic_uScriptAct_Log_Prefix_125, logic_uScriptAct_Log_Target_125, logic_uScriptAct_Log_Postfix_125);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_128()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1ebee1d4-b417-49d0-8bdd-de244faf23a3", "Log", Relay_In_128)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_127_System_String);
               logic_uScriptAct_Log_Target_128 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_128.In(logic_uScriptAct_Log_Prefix_128, logic_uScriptAct_Log_Target_128, logic_uScriptAct_Log_Postfix_128);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_130()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a9f8d061-9543-4d7d-935e-772864b5ec10", "Log", Relay_In_130)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_129_System_String);
               logic_uScriptAct_Log_Target_130 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_130.In(logic_uScriptAct_Log_Prefix_130, logic_uScriptAct_Log_Target_130, logic_uScriptAct_Log_Postfix_130);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Collision_261()
   {
      if (true == CheckDebugBreak("3ba5da65-a130-4503-9a3c-d55a66184f90", "Particle Collision", Relay_Collision_261)) return; 
      Relay_In_263();
   }
   
   void Relay_In_263()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6543aefd-5e12-41d6-8bb3-4a75cf1a83d9", "Log", Relay_In_263)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_262_System_String);
               logic_uScriptAct_Log_Target_263 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_263.In(logic_uScriptAct_Log_Prefix_263, logic_uScriptAct_Log_Target_263, logic_uScriptAct_Log_Postfix_263);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnHit_266()
   {
      if (true == CheckDebugBreak("fde66a2c-c803-4004-8fec-b0f3eb92683d", "Controller Collision", Relay_OnHit_266)) return; 
      Relay_In_276();
   }
   
   void Relay_JointBreak_267()
   {
      if (true == CheckDebugBreak("b26dfa1f-9735-4295-b21b-92870cfae38b", "Joint Break", Relay_JointBreak_267)) return; 
      Relay_In_273();
   }
   
   void Relay_OnEnterCollision_268()
   {
      if (true == CheckDebugBreak("da725f57-319b-4889-bbf9-89ad78ca0674", "On Collision", Relay_OnEnterCollision_268)) return; 
      Relay_In_270();
   }
   
   void Relay_OnExitCollision_268()
   {
      if (true == CheckDebugBreak("da725f57-319b-4889-bbf9-89ad78ca0674", "On Collision", Relay_OnExitCollision_268)) return; 
      Relay_In_270();
   }
   
   void Relay_WhileInsideCollision_268()
   {
      if (true == CheckDebugBreak("da725f57-319b-4889-bbf9-89ad78ca0674", "On Collision", Relay_WhileInsideCollision_268)) return; 
      Relay_In_270();
   }
   
   void Relay_In_270()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("43159f45-3b50-4a8d-b45d-c1b67637bedb", "Log", Relay_In_270)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_269_System_String);
               logic_uScriptAct_Log_Target_270 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_270.In(logic_uScriptAct_Log_Prefix_270, logic_uScriptAct_Log_Target_270, logic_uScriptAct_Log_Postfix_270);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_273()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("bc30ea07-1a2c-4417-a252-9786b4d503b3", "Log", Relay_In_273)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_272_System_String);
               logic_uScriptAct_Log_Target_273 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_273.In(logic_uScriptAct_Log_Prefix_273, logic_uScriptAct_Log_Target_273, logic_uScriptAct_Log_Postfix_273);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_276()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("748487b4-e680-40a3-96a0-55599029104b", "Log", Relay_In_276)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_275_System_String);
               logic_uScriptAct_Log_Target_276 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_276.In(logic_uScriptAct_Log_Prefix_276, logic_uScriptAct_Log_Target_276, logic_uScriptAct_Log_Postfix_276);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_RenderImage_283()
   {
      if (true == CheckDebugBreak("153e2c88-2df2-443d-80b8-5530df5f25b1", "Post Effect Events", Relay_RenderImage_283)) return; 
      Relay_In_289();
   }
   
   void Relay_PreCull_284()
   {
      if (true == CheckDebugBreak("1ae5dc01-f455-4b34-9494-4b864a4deea5", "Render Events", Relay_PreCull_284)) return; 
      Relay_In_286();
   }
   
   void Relay_PreRender_284()
   {
      if (true == CheckDebugBreak("1ae5dc01-f455-4b34-9494-4b864a4deea5", "Render Events", Relay_PreRender_284)) return; 
      Relay_In_286();
   }
   
   void Relay_PostRender_284()
   {
      if (true == CheckDebugBreak("1ae5dc01-f455-4b34-9494-4b864a4deea5", "Render Events", Relay_PostRender_284)) return; 
      Relay_In_286();
   }
   
   void Relay_RenderObject_284()
   {
      if (true == CheckDebugBreak("1ae5dc01-f455-4b34-9494-4b864a4deea5", "Render Events", Relay_RenderObject_284)) return; 
      Relay_In_286();
   }
   
   void Relay_WillRenderObject_284()
   {
      if (true == CheckDebugBreak("1ae5dc01-f455-4b34-9494-4b864a4deea5", "Render Events", Relay_WillRenderObject_284)) return; 
      Relay_In_286();
   }
   
   void Relay_In_286()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9ef40ee2-33bb-4d1a-a7c9-eee89d953b28", "Log", Relay_In_286)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_285_System_String);
               logic_uScriptAct_Log_Target_286 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_286.In(logic_uScriptAct_Log_Prefix_286, logic_uScriptAct_Log_Target_286, logic_uScriptAct_Log_Postfix_286);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_289()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c4e129c3-9a3b-4fbf-bbfa-defabfe48344", "Log", Relay_In_289)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_288_System_String);
               logic_uScriptAct_Log_Target_289 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_289.In(logic_uScriptAct_Log_Prefix_289, logic_uScriptAct_Log_Target_289, logic_uScriptAct_Log_Postfix_289);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnEnterTrigger_309()
   {
      if (true == CheckDebugBreak("4d6e30d5-6123-46c8-8638-2fd9b7b12206", "Trigger Events", Relay_OnEnterTrigger_309)) return; 
      Relay_In_313();
   }
   
   void Relay_OnExitTrigger_309()
   {
      if (true == CheckDebugBreak("4d6e30d5-6123-46c8-8638-2fd9b7b12206", "Trigger Events", Relay_OnExitTrigger_309)) return; 
      Relay_In_313();
   }
   
   void Relay_WhileInsideTrigger_309()
   {
      if (true == CheckDebugBreak("4d6e30d5-6123-46c8-8638-2fd9b7b12206", "Trigger Events", Relay_WhileInsideTrigger_309)) return; 
      Relay_In_313();
   }
   
   void Relay_In_313()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("18e193dc-b0d1-447f-8225-81a71924e69c", "Log", Relay_In_313)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_312_System_String);
               logic_uScriptAct_Log_Target_313 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_313.In(logic_uScriptAct_Log_Prefix_313, logic_uScriptAct_Log_Target_313, logic_uScriptAct_Log_Postfix_313);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript All_Event_Nodes.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:18", local_18_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "935f4a23-36b8-4c40-adb7-c4c34409d052", local_18_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:20", local_20_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "5ec44c77-7c46-4488-b39b-7408956622fc", local_20_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:21", local_21_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ec73ce91-087c-451b-9d6c-2ac890262f6a", local_21_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:24", local_24_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a78977c8-d36c-4245-8609-855db29e49fc", local_24_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:26", local_26_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "70d750cd-980b-41c9-be52-5131e2140a04", local_26_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:28", local_28_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "cc7f8468-84c4-46c1-a576-0342e32d4933", local_28_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:30", local_30_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7612ff9b-54e4-46cd-a5f6-45de34c66ccb", local_30_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:31", local_31_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "77e863af-8058-47db-b322-ce25cf78a367", local_31_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:34", local_34_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "1c7aac5a-fd11-4073-a257-f448ea41b977", local_34_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:35", local_35_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "539412dc-2ca2-42be-a8db-8db726bc614b", local_35_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:36", local_36_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "320fe143-4bad-4b10-a414-ae56f322e783", local_36_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:37", local_37_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "8487bd2d-fd62-44e5-be4b-f2e42d88e43f", local_37_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:38", local_38_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "5e0af659-0102-4e40-8230-8565533da47f", local_38_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:39", local_39_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "0344d4a4-a857-453e-a474-158d9bb00529", local_39_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:40", local_40_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "4f7f8ae1-31ed-4dad-967c-00be2ca8ac6a", local_40_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:41", local_41_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "4b6b5faf-137b-4b4b-8110-06ce52e08bd4", local_41_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:43", local_43_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "61f64851-89b6-44ff-bd64-b880ad0c3536", local_43_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:44", local_44_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "74e2029f-2c7d-4aef-b1e8-d4670b41d374", local_44_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:45", local_45_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "10b38573-0010-4efe-a42f-7b6976e19c0c", local_45_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:47", local_47_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ec3314a5-9e88-48ae-99bd-8502a490af53", local_47_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:48", local_48_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "dd027f60-ea75-49d5-8b95-0f62ce54c8c2", local_48_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:49", local_49_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f262a9ae-8ab9-43c1-95d2-3176e178c887", local_49_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:51", local_51_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "668cab1d-f301-4805-9f2d-82b94d7b40fa", local_51_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:53", local_53_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "36b16f12-8ea4-47ed-93ae-358e7f7af32b", local_53_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:55", local_55_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "3ba7e959-9b6f-444f-9af1-97f1ca21d42a", local_55_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:57", local_57_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d7690fff-272d-4380-aa89-fa7b1ed82835", local_57_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:59", local_59_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ed9b5163-6047-45c5-9b47-7f2f00657239", local_59_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:62", local_62_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "33a841fb-851c-481f-9b0f-ee738ca5e8bc", local_62_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:64", local_64_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "8a6430db-3541-45a8-bac4-c9801e6ab643", local_64_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:66", local_66_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c8ce2c52-23f4-44a8-b611-c728d8b0e45d", local_66_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:70", local_70_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "9080585a-6e43-4209-8385-c483a1689b14", local_70_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:73", local_73_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7e90ed7a-d680-4491-b4ff-a6fb36afbd9e", local_73_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:74", local_74_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "dd1f5590-f10a-4347-80a5-d381dd354773", local_74_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:75", local_75_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "4367b206-f9f4-47e3-8063-ddf94a39c7e8", local_75_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:85", local_85_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f779ce4a-f61e-4d32-a243-8311a2fe4454", local_85_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:87", local_87_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "cab76a57-77a6-45a7-8e42-372e26c490fe", local_87_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:91", local_91_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "fcc8d0c4-7e39-4511-be1e-d8ff680feabc", local_91_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:92", local_92_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "1ca6511a-014c-4606-8073-8181872acba1", local_92_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:96", local_96_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "373ba695-b672-4426-8a88-74a835ede566", local_96_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:97", local_97_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b030f8fd-bb4b-42ac-91dd-5ea230bda5bf", local_97_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:99", local_99_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "74523856-5e73-4673-bcd6-4adfffd8b104", local_99_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:100", local_100_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "37380c06-7ed0-41e3-b263-cce158fb8a21", local_100_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:102", local_102_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "33720d0d-2c7c-4861-94b6-384e082c4224", local_102_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:105", local_105_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d9f8441e-2f2c-477e-8137-9acf53e27d18", local_105_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:106", local_106_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "66a0b2e7-643d-475e-aff1-6cc91100e47a", local_106_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:108", local_108_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "df09649b-3b66-4800-a22d-ae748cafaa63", local_108_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:118", local_118_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "2acac668-1ebd-4cdd-9e43-c97220b13dd9", local_118_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:119", local_119_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "11f32da4-1461-4da4-84b9-8c307bc5dec6", local_119_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:121", local_121_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "6eeb688d-2f5a-4651-8958-6b790c09b2a5", local_121_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:123", local_123_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "569ec40d-a093-4bd7-b94f-65b794bd67a2", local_123_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:126", local_126_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "6cd3055a-73cd-4b08-891b-23388e3a22ee", local_126_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:127", local_127_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ddd39768-e999-4a8b-b734-f1c04a537d90", local_127_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:129", local_129_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "029c44eb-8e18-423c-a8fa-9c2bedfc2f59", local_129_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:262", local_262_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ad80b1dc-7ab7-416b-b787-709d94e57bd8", local_262_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:269", local_269_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "0013c3fd-3fdd-492a-a4d5-b42f67d19d5f", local_269_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:272", local_272_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7eaf4cfd-fb88-4007-b716-150a9ecfe2e6", local_272_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:275", local_275_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c30d4a04-bef6-44c6-aa10-0a5f19ee7fe6", local_275_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:285", local_285_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "12aa2675-b63d-40cc-bb8b-abf23b70deed", local_285_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:288", local_288_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "2793e51d-cf76-4bfa-b81d-a2ebcd7fc625", local_288_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:297", local_297_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c679e835-d091-4f57-ab41-e9ccd55cc3b9", local_297_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:299", local_299_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "cd140708-0929-4a38-958e-cc5f033145ec", local_299_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:301", local_301_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "abf67e23-6496-4989-9bf0-f226d7784e0f", local_301_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:303", local_303_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7c063130-96ca-4b48-8f96-9c1120f8912d", local_303_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:305", local_305_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "63dda243-49eb-490c-b584-b5843a205c26", local_305_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:307", local_307_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "bd023f78-355b-4d4e-add0-93712ee8877a", local_307_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:310", local_310_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "fd21d60c-9889-46a3-ba18-6a51747ac60b", local_310_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "All_Event_Nodes.uscript:312", local_312_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "673d92ae-b657-4fcc-b4f2-b60db240ec42", local_312_System_String);
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
