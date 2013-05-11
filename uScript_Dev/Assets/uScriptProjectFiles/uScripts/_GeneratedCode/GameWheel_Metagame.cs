//uScript Generated Code - Build 0.9.2275
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
   UnityEngine.GameObject local_25_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_25_UnityEngine_GameObject_previous = null;
   System.String local_32_System_String = "One";
   System.Int32 local_35_System_Int32 = (int) 1;
   System.Int32 local_36_System_Int32 = (int) 10;
   System.String local_37_System_String = "Ten";
   System.Int32 local_45_System_Int32 = (int) 25;
   System.String local_46_System_String = "TwentyFive";
   System.Int32 local_49_System_Int32 = (int) 100;
   System.String local_51_System_String = "OneHundred";
   System.String local_59_System_String = "Score:";
   System.String local_60_System_String = "";
   System.Single local_64_System_Single = (float) 0;
   UnityEngine.GameObject local_7_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_7_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_CurrentValue_UnityEngine_GameObject = null;
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
   UnityEngine.Texture2D logic_uScriptAct_GUIButton_Texture_1 = null;
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
   UnityEngine.Texture2D logic_uScriptAct_GUIButton_Texture_6 = null;
   System.String logic_uScriptAct_GUIButton_ToolTip_6 = "";
   System.String logic_uScriptAct_GUIButton_guiStyle_6 = "";
   bool logic_uScriptAct_GUIButton_Out_6 = true;
   //pointer to script instanced logic node
   uScriptAct_AddRelativeTorque logic_uScriptAct_AddRelativeTorque_uScriptAct_AddRelativeTorque_8 = new uScriptAct_AddRelativeTorque( );
   UnityEngine.GameObject logic_uScriptAct_AddRelativeTorque_Target_8 = null;
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
   uScriptAct_InterpolateVector3Linear logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_21 = new uScriptAct_InterpolateVector3Linear( );
   UnityEngine.Vector3 logic_uScriptAct_InterpolateVector3Linear_startValue_21 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_InterpolateVector3Linear_endValue_21 = new Vector3( (float)0, (float)0, (float)0 );
   System.Single logic_uScriptAct_InterpolateVector3Linear_time_21 = (float) 0;
   uScript_Lerper.LoopType logic_uScriptAct_InterpolateVector3Linear_loopType_21 = uScript_Lerper.LoopType.None;
   System.Single logic_uScriptAct_InterpolateVector3Linear_loopDelay_21 = (float) 0;
   System.Int32 logic_uScriptAct_InterpolateVector3Linear_loopCount_21 = (int) -1;
   UnityEngine.Vector3 logic_uScriptAct_InterpolateVector3Linear_currentValue_21;
   bool logic_uScriptAct_InterpolateVector3Linear_Started_21 = true;
   bool logic_uScriptAct_InterpolateVector3Linear_Stopped_21 = true;
   bool logic_uScriptAct_InterpolateVector3Linear_Interpolating_21 = true;
   bool logic_uScriptAct_InterpolateVector3Linear_Finished_21 = true;
   bool logic_uScriptAct_InterpolateVector3Linear_Driven_21 = false;
   //pointer to script instanced logic node
   uScriptAct_SetGameObject logic_uScriptAct_SetGameObject_uScriptAct_SetGameObject_26 = new uScriptAct_SetGameObject( );
   UnityEngine.GameObject logic_uScriptAct_SetGameObject_Value_26 = null;
   UnityEngine.GameObject logic_uScriptAct_SetGameObject_TargetGameObject_26;
   bool logic_uScriptAct_SetGameObject_Out_26 = true;
   //pointer to script instanced logic node
   uScriptAct_GetGameObjectName logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_28 = new uScriptAct_GetGameObjectName( );
   UnityEngine.GameObject logic_uScriptAct_GetGameObjectName_gameObject_28 = null;
   System.String logic_uScriptAct_GetGameObjectName_name_28;
   bool logic_uScriptAct_GetGameObjectName_Out_28 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_31 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_31 = "";
   System.String logic_uScriptCon_CompareString_B_31 = "";
   bool logic_uScriptCon_CompareString_Same_31 = true;
   bool logic_uScriptCon_CompareString_Different_31 = true;
   //pointer to script instanced logic node
   uScriptAct_AddInt logic_uScriptAct_AddInt_uScriptAct_AddInt_33 = new uScriptAct_AddInt( );
   System.Int32[] logic_uScriptAct_AddInt_A_33 = new System.Int32[] {};
   System.Int32[] logic_uScriptAct_AddInt_B_33 = new System.Int32[] {};
   System.Int32 logic_uScriptAct_AddInt_IntResult_33;
   System.Single logic_uScriptAct_AddInt_FloatResult_33;
   bool logic_uScriptAct_AddInt_Out_33 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_38 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_38 = "";
   System.String logic_uScriptCon_CompareString_B_38 = "";
   bool logic_uScriptCon_CompareString_Same_38 = true;
   bool logic_uScriptCon_CompareString_Different_38 = true;
   //pointer to script instanced logic node
   uScriptAct_AddInt logic_uScriptAct_AddInt_uScriptAct_AddInt_39 = new uScriptAct_AddInt( );
   System.Int32[] logic_uScriptAct_AddInt_A_39 = new System.Int32[] {};
   System.Int32[] logic_uScriptAct_AddInt_B_39 = new System.Int32[] {};
   System.Int32 logic_uScriptAct_AddInt_IntResult_39;
   System.Single logic_uScriptAct_AddInt_FloatResult_39;
   bool logic_uScriptAct_AddInt_Out_39 = true;
   //pointer to script instanced logic node
   uScriptAct_AddInt logic_uScriptAct_AddInt_uScriptAct_AddInt_42 = new uScriptAct_AddInt( );
   System.Int32[] logic_uScriptAct_AddInt_A_42 = new System.Int32[] {};
   System.Int32[] logic_uScriptAct_AddInt_B_42 = new System.Int32[] {};
   System.Int32 logic_uScriptAct_AddInt_IntResult_42;
   System.Single logic_uScriptAct_AddInt_FloatResult_42;
   bool logic_uScriptAct_AddInt_Out_42 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_43 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_43 = "";
   System.String logic_uScriptCon_CompareString_B_43 = "";
   bool logic_uScriptCon_CompareString_Same_43 = true;
   bool logic_uScriptCon_CompareString_Different_43 = true;
   //pointer to script instanced logic node
   uScriptAct_AddInt logic_uScriptAct_AddInt_uScriptAct_AddInt_48 = new uScriptAct_AddInt( );
   System.Int32[] logic_uScriptAct_AddInt_A_48 = new System.Int32[] {};
   System.Int32[] logic_uScriptAct_AddInt_B_48 = new System.Int32[] {};
   System.Int32 logic_uScriptAct_AddInt_IntResult_48;
   System.Single logic_uScriptAct_AddInt_FloatResult_48;
   bool logic_uScriptAct_AddInt_Out_48 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_50 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_50 = "";
   System.String logic_uScriptCon_CompareString_B_50 = "";
   bool logic_uScriptCon_CompareString_Same_50 = true;
   bool logic_uScriptCon_CompareString_Different_50 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_54 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_54 = "Unknown GameObject: ";
   System.Object[] logic_uScriptAct_Log_Target_54 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_54 = "";
   bool logic_uScriptAct_Log_Out_54 = true;
   //pointer to script instanced logic node
   uScriptAct_GUILabel logic_uScriptAct_GUILabel_uScriptAct_GUILabel_56 = new uScriptAct_GUILabel( );
   System.String logic_uScriptAct_GUILabel_Text_56 = "";
   UnityEngine.Rect logic_uScriptAct_GUILabel_Position_56 = new Rect( (float)16, (float)140, (float)128, (float)32 );
   UnityEngine.Texture logic_uScriptAct_GUILabel_Texture_56 = null;
   System.String logic_uScriptAct_GUILabel_ToolTip_56 = "";
   System.String logic_uScriptAct_GUILabel_guiStyle_56 = "";
   bool logic_uScriptAct_GUILabel_Out_56 = true;
   //pointer to script instanced logic node
   uScriptAct_Concatenate logic_uScriptAct_Concatenate_uScriptAct_Concatenate_57 = new uScriptAct_Concatenate( );
   System.Object[] logic_uScriptAct_Concatenate_A_57 = new System.Object[] {};
   System.Object[] logic_uScriptAct_Concatenate_B_57 = new System.Object[] {};
   System.String logic_uScriptAct_Concatenate_Separator_57 = " ";
   System.String logic_uScriptAct_Concatenate_Result_57;
   bool logic_uScriptAct_Concatenate_Out_57 = true;
   //pointer to script instanced logic node
   uScriptAct_SetRandomFloat logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_63 = new uScriptAct_SetRandomFloat( );
   System.Single logic_uScriptAct_SetRandomFloat_Min_63 = (float) 1.5;
   System.Single logic_uScriptAct_SetRandomFloat_Max_63 = (float) 3;
   System.Single logic_uScriptAct_SetRandomFloat_TargetFloat_63;
   bool logic_uScriptAct_SetRandomFloat_Out_63 = true;
   
   //event nodes
   System.Boolean event_UnityEngine_GameObject_GUIChanged_0 = (bool) false;
   System.String event_UnityEngine_GameObject_FocusedControl_0 = "";
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_0 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_9 = null;
   System.Int32 event_UnityEngine_GameObject_TimesToTrigger_24 = (int) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_24 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_24 = null;
   
   //property nodes
   UnityEngine.Vector3 property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_22 = new Vector3( );
   UnityEngine.GameObject property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_22 = null;
   UnityEngine.Vector3 property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23 = new Vector3( );
   UnityEngine.GameObject property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_23 = null;
   
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
      SyncEventListeners( );
      if ( null == property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_22 || false == m_RegisteredForEvents )
      {
         property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_22 = GameObject.Find( "Disc" ) as UnityEngine.GameObject;
      }
      if ( null == property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_23 || false == m_RegisteredForEvents )
      {
         property_angularVelocity_Detox_ScriptEditor_Parameter_Instance_23 = GameObject.Find( "Disc" ) as UnityEngine.GameObject;
      }
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
      if ( local_25_UnityEngine_GameObject_previous != local_25_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_25_UnityEngine_GameObject_previous = local_25_UnityEngine_GameObject;
         
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
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_7_UnityEngine_GameObject_previous != local_7_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_7_UnityEngine_GameObject_previous = local_7_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_25_UnityEngine_GameObject_previous != local_25_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_25_UnityEngine_GameObject_previous = local_25_UnityEngine_GameObject;
         
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
      if ( null == event_UnityEngine_GameObject_Instance_24 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_24 = GameObject.Find( "Needle" ) as UnityEngine.GameObject;
         if ( null != event_UnityEngine_GameObject_Instance_24 )
         {
            {
               uScript_Triggers component = event_UnityEngine_GameObject_Instance_24.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_24.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_24;
               }
            }
            {
               uScript_Triggers component = event_UnityEngine_GameObject_Instance_24.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_24.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_24;
                  component.OnExitTrigger += Instance_OnExitTrigger_24;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_24;
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
      if ( null != event_UnityEngine_GameObject_Instance_24 )
      {
         {
            uScript_Triggers component = event_UnityEngine_GameObject_Instance_24.GetComponent<uScript_Triggers>();
            if ( null != component )
            {
               component.OnEnterTrigger -= Instance_OnEnterTrigger_24;
               component.OnExitTrigger -= Instance_OnExitTrigger_24;
               component.WhileInsideTrigger -= Instance_WhileInsideTrigger_24;
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
      logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_21.SetParent(g);
      logic_uScriptAct_SetGameObject_uScriptAct_SetGameObject_26.SetParent(g);
      logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_28.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_31.SetParent(g);
      logic_uScriptAct_AddInt_uScriptAct_AddInt_33.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_38.SetParent(g);
      logic_uScriptAct_AddInt_uScriptAct_AddInt_39.SetParent(g);
      logic_uScriptAct_AddInt_uScriptAct_AddInt_42.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_43.SetParent(g);
      logic_uScriptAct_AddInt_uScriptAct_AddInt_48.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_50.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_54.SetParent(g);
      logic_uScriptAct_GUILabel_uScriptAct_GUILabel_56.SetParent(g);
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_57.SetParent(g);
      logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_63.SetParent(g);
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
      if (true == logic_uScriptAct_InterpolateVector3Linear_Driven_21)
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
   
   void Instance_OnEnterTrigger_24(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_24 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_24( );
   }
   
   void Instance_OnExitTrigger_24(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_24 = e.GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_24( );
   }
   
   void Instance_WhileInsideTrigger_24(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_24 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_24( );
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
      if (true == CheckDebugBreak("ee65abf7-7032-4aea-8c0d-3c9b55d6c385", "GUI Events", Relay_OnGui_0)) return; 
      Relay_In_3();
      Relay_In_57();
   }
   
   void Relay_OnButtonDown_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("45e4976e-4411-47f7-b50a-94f80bda031b", "GUI Button", Relay_OnButtonDown_1)) return; 
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
         if (true == CheckDebugBreak("45e4976e-4411-47f7-b50a-94f80bda031b", "GUI Button", Relay_OnButtonHeld_1)) return; 
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
         if (true == CheckDebugBreak("45e4976e-4411-47f7-b50a-94f80bda031b", "GUI Button", Relay_OnButtonUp_1)) return; 
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
         if (true == CheckDebugBreak("45e4976e-4411-47f7-b50a-94f80bda031b", "GUI Button", Relay_OnButtonClicked_1)) return; 
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
         if (true == CheckDebugBreak("45e4976e-4411-47f7-b50a-94f80bda031b", "GUI Button", Relay_In_1)) return; 
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
         if (true == CheckDebugBreak("9db2a079-9cca-472c-a62b-cf511b4d1b2b", "Set Bool", Relay_True_2)) return; 
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
            Relay_In_63();
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
         if (true == CheckDebugBreak("9db2a079-9cca-472c-a62b-cf511b4d1b2b", "Set Bool", Relay_False_2)) return; 
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
            Relay_In_63();
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
         if (true == CheckDebugBreak("096955b8-d11a-4b0d-ab62-bf02618af1c1", "Compare Bool", Relay_In_3)) return; 
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
         if (true == CheckDebugBreak("a6249012-af43-4990-83cc-b774ecfddff7", "GUI Button", Relay_OnButtonDown_6)) return; 
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
         if (true == CheckDebugBreak("a6249012-af43-4990-83cc-b774ecfddff7", "GUI Button", Relay_OnButtonHeld_6)) return; 
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
         if (true == CheckDebugBreak("a6249012-af43-4990-83cc-b774ecfddff7", "GUI Button", Relay_OnButtonUp_6)) return; 
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
         if (true == CheckDebugBreak("a6249012-af43-4990-83cc-b774ecfddff7", "GUI Button", Relay_OnButtonClicked_6)) return; 
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
         if (true == CheckDebugBreak("a6249012-af43-4990-83cc-b774ecfddff7", "GUI Button", Relay_In_6)) return; 
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
         if (true == CheckDebugBreak("7b34533a-b1e2-405c-97b7-c956f87626b5", "Add Relative Torque", Relay_In_8)) return; 
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
      if (true == CheckDebugBreak("0832e513-8d2b-4479-bccf-3f1cd0e4ff14", "Global Update", Relay_OnUpdate_9)) return; 
   }
   
   void Relay_OnLateUpdate_9()
   {
      if (true == CheckDebugBreak("0832e513-8d2b-4479-bccf-3f1cd0e4ff14", "Global Update", Relay_OnLateUpdate_9)) return; 
   }
   
   void Relay_OnFixedUpdate_9()
   {
      if (true == CheckDebugBreak("0832e513-8d2b-4479-bccf-3f1cd0e4ff14", "Global Update", Relay_OnFixedUpdate_9)) return; 
      Relay_In_10();
   }
   
   void Relay_In_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("dd84b8ff-33a8-46ea-8ffc-8dbf84315f45", "Compare Bool", Relay_In_10)) return; 
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
         if (true == CheckDebugBreak("89fde440-27d3-4dba-b703-b2fc4b206a42", "Compare Bool", Relay_In_13)) return; 
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
               logic_uScriptAct_Delay_Duration_14 = local_64_System_Single;
               
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
   
   void Relay_DrivenDelay_14( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               logic_uScriptAct_Delay_Duration_14 = local_64_System_Single;
               
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
         if (true == CheckDebugBreak("3e605a1e-573b-44f1-aa6d-b81402e33714", "Set Bool", Relay_True_15)) return; 
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
         if (true == CheckDebugBreak("3e605a1e-573b-44f1-aa6d-b81402e33714", "Set Bool", Relay_False_15)) return; 
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
         if (true == CheckDebugBreak("70755466-1749-492f-b813-6d84f8e2a186", "Set Bool", Relay_True_18)) return; 
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
         if (true == CheckDebugBreak("70755466-1749-492f-b813-6d84f8e2a186", "Set Bool", Relay_False_18)) return; 
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
         if (true == CheckDebugBreak("4f898b0f-bf01-4063-bcfe-64ccbae1640d", "Set Bool", Relay_True_19)) return; 
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
            Relay_In_28();
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
         if (true == CheckDebugBreak("4f898b0f-bf01-4063-bcfe-64ccbae1640d", "Set Bool", Relay_False_19)) return; 
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
            Relay_In_28();
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
         if (true == CheckDebugBreak("5621d114-3076-41c4-9d13-8192510866e2", "Interpolate Vector3 Linear", Relay_Begin_21)) return; 
         {
            {
               logic_uScriptAct_InterpolateVector3Linear_startValue_21 = property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_22_Get_Refresh( );
               
            }
            {
            }
            {
               logic_uScriptAct_InterpolateVector3Linear_time_21 = WheelStopTime;
               
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
         logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_21.Begin(logic_uScriptAct_InterpolateVector3Linear_startValue_21, logic_uScriptAct_InterpolateVector3Linear_endValue_21, logic_uScriptAct_InterpolateVector3Linear_time_21, logic_uScriptAct_InterpolateVector3Linear_loopType_21, logic_uScriptAct_InterpolateVector3Linear_loopDelay_21, logic_uScriptAct_InterpolateVector3Linear_loopCount_21, out logic_uScriptAct_InterpolateVector3Linear_currentValue_21);
         logic_uScriptAct_InterpolateVector3Linear_Driven_21 = true;
         property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23 = logic_uScriptAct_InterpolateVector3Linear_currentValue_21;
         property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_21.Finished;
         
         if ( test_0 == true )
         {
            Relay_False_18();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Interpolate Vector3 Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_21()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5621d114-3076-41c4-9d13-8192510866e2", "Interpolate Vector3 Linear", Relay_Stop_21)) return; 
         {
            {
               logic_uScriptAct_InterpolateVector3Linear_startValue_21 = property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_22_Get_Refresh( );
               
            }
            {
            }
            {
               logic_uScriptAct_InterpolateVector3Linear_time_21 = WheelStopTime;
               
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
         logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_21.Stop(logic_uScriptAct_InterpolateVector3Linear_startValue_21, logic_uScriptAct_InterpolateVector3Linear_endValue_21, logic_uScriptAct_InterpolateVector3Linear_time_21, logic_uScriptAct_InterpolateVector3Linear_loopType_21, logic_uScriptAct_InterpolateVector3Linear_loopDelay_21, logic_uScriptAct_InterpolateVector3Linear_loopCount_21, out logic_uScriptAct_InterpolateVector3Linear_currentValue_21);
         logic_uScriptAct_InterpolateVector3Linear_Driven_21 = true;
         property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23 = logic_uScriptAct_InterpolateVector3Linear_currentValue_21;
         property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_21.Finished;
         
         if ( test_0 == true )
         {
            Relay_False_18();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Interpolate Vector3 Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Resume_21()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5621d114-3076-41c4-9d13-8192510866e2", "Interpolate Vector3 Linear", Relay_Resume_21)) return; 
         {
            {
               logic_uScriptAct_InterpolateVector3Linear_startValue_21 = property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_22_Get_Refresh( );
               
            }
            {
            }
            {
               logic_uScriptAct_InterpolateVector3Linear_time_21 = WheelStopTime;
               
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
         logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_21.Resume(logic_uScriptAct_InterpolateVector3Linear_startValue_21, logic_uScriptAct_InterpolateVector3Linear_endValue_21, logic_uScriptAct_InterpolateVector3Linear_time_21, logic_uScriptAct_InterpolateVector3Linear_loopType_21, logic_uScriptAct_InterpolateVector3Linear_loopDelay_21, logic_uScriptAct_InterpolateVector3Linear_loopCount_21, out logic_uScriptAct_InterpolateVector3Linear_currentValue_21);
         logic_uScriptAct_InterpolateVector3Linear_Driven_21 = true;
         property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23 = logic_uScriptAct_InterpolateVector3Linear_currentValue_21;
         property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_21.Finished;
         
         if ( test_0 == true )
         {
            Relay_False_18();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Interpolate Vector3 Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Driven_21( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               logic_uScriptAct_InterpolateVector3Linear_startValue_21 = property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_22_Get_Refresh( );
               
            }
            {
            }
            {
               logic_uScriptAct_InterpolateVector3Linear_time_21 = WheelStopTime;
               
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
         logic_uScriptAct_InterpolateVector3Linear_Driven_21 = logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_21.Driven(out logic_uScriptAct_InterpolateVector3Linear_currentValue_21);
         if ( true == logic_uScriptAct_InterpolateVector3Linear_Driven_21 )
         {
            property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23 = logic_uScriptAct_InterpolateVector3Linear_currentValue_21;
            property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23_Set_Refresh( );
            if ( logic_uScriptAct_InterpolateVector3Linear_uScriptAct_InterpolateVector3Linear_21.Finished == true )
            {
               Relay_False_18();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Interpolate Vector3 Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_OnEnterTrigger_24()
   {
      if (true == CheckDebugBreak("15fabe0d-3ca9-49d1-9049-4dc6bde761a5", "Trigger Events", Relay_OnEnterTrigger_24)) return; 
      local_25_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_24;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_25_UnityEngine_GameObject_previous != local_25_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_25_UnityEngine_GameObject_previous = local_25_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
      Relay_In_26();
   }
   
   void Relay_OnExitTrigger_24()
   {
      if (true == CheckDebugBreak("15fabe0d-3ca9-49d1-9049-4dc6bde761a5", "Trigger Events", Relay_OnExitTrigger_24)) return; 
      local_25_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_24;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_25_UnityEngine_GameObject_previous != local_25_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_25_UnityEngine_GameObject_previous = local_25_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
   }
   
   void Relay_WhileInsideTrigger_24()
   {
      if (true == CheckDebugBreak("15fabe0d-3ca9-49d1-9049-4dc6bde761a5", "Trigger Events", Relay_WhileInsideTrigger_24)) return; 
      local_25_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_24;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_25_UnityEngine_GameObject_previous != local_25_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_25_UnityEngine_GameObject_previous = local_25_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
   }
   
   void Relay_In_26()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8897f303-b839-4859-ab10-7dbf7a6ad243", "Set GameObject", Relay_In_26)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_25_UnityEngine_GameObject_previous != local_25_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_25_UnityEngine_GameObject_previous = local_25_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_SetGameObject_Value_26 = local_25_UnityEngine_GameObject;
               
            }
            {
            }
         }
         logic_uScriptAct_SetGameObject_uScriptAct_SetGameObject_26.In(logic_uScriptAct_SetGameObject_Value_26, out logic_uScriptAct_SetGameObject_TargetGameObject_26);
         local_CurrentValue_UnityEngine_GameObject = logic_uScriptAct_SetGameObject_TargetGameObject_26;
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
   
   void Relay_In_28()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0de8f7e8-5fc2-4b13-9c48-f512d77d6e21", "Get GameObject Name", Relay_In_28)) return; 
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
               logic_uScriptAct_GetGameObjectName_gameObject_28 = local_CurrentValue_UnityEngine_GameObject;
               
            }
            {
            }
         }
         logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_28.In(logic_uScriptAct_GetGameObjectName_gameObject_28, out logic_uScriptAct_GetGameObjectName_name_28);
         local_GOName_System_String = logic_uScriptAct_GetGameObjectName_name_28;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetGameObjectName_uScriptAct_GetGameObjectName_28.Out;
         
         if ( test_0 == true )
         {
            Relay_In_31();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Get GameObject Name.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_31()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2e217ec9-c325-4c04-aaf8-9012aa89a50d", "Compare String", Relay_In_31)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_31 = local_GOName_System_String;
               
            }
            {
               logic_uScriptCon_CompareString_B_31 = local_32_System_String;
               
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_31.In(logic_uScriptCon_CompareString_A_31, logic_uScriptCon_CompareString_B_31);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_31.Same;
         bool test_1 = logic_uScriptCon_CompareString_uScriptCon_CompareString_31.Different;
         
         if ( test_0 == true )
         {
            Relay_In_33();
         }
         if ( test_1 == true )
         {
            Relay_In_38();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_33()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("58972c6a-0935-4eb0-ac27-25225a8389c9", "Add Int", Relay_In_33)) return; 
         {
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_35_System_Int32);
               logic_uScriptAct_AddInt_A_33 = properties.ToArray();
            }
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_Score_System_Int32);
               logic_uScriptAct_AddInt_B_33 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddInt_uScriptAct_AddInt_33.In(logic_uScriptAct_AddInt_A_33, logic_uScriptAct_AddInt_B_33, out logic_uScriptAct_AddInt_IntResult_33, out logic_uScriptAct_AddInt_FloatResult_33);
         local_Score_System_Int32 = logic_uScriptAct_AddInt_IntResult_33;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Add Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_38()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b3bc9ebb-dc4c-4411-b2a8-1e7c6bd7c9da", "Compare String", Relay_In_38)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_38 = local_GOName_System_String;
               
            }
            {
               logic_uScriptCon_CompareString_B_38 = local_37_System_String;
               
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_38.In(logic_uScriptCon_CompareString_A_38, logic_uScriptCon_CompareString_B_38);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_38.Same;
         bool test_1 = logic_uScriptCon_CompareString_uScriptCon_CompareString_38.Different;
         
         if ( test_0 == true )
         {
            Relay_In_39();
         }
         if ( test_1 == true )
         {
            Relay_In_43();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_39()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c704c62b-1ad4-4dba-8b5a-4ef4670add8d", "Add Int", Relay_In_39)) return; 
         {
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_36_System_Int32);
               logic_uScriptAct_AddInt_A_39 = properties.ToArray();
            }
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_Score_System_Int32);
               logic_uScriptAct_AddInt_B_39 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddInt_uScriptAct_AddInt_39.In(logic_uScriptAct_AddInt_A_39, logic_uScriptAct_AddInt_B_39, out logic_uScriptAct_AddInt_IntResult_39, out logic_uScriptAct_AddInt_FloatResult_39);
         local_Score_System_Int32 = logic_uScriptAct_AddInt_IntResult_39;
         
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
         if (true == CheckDebugBreak("94c2a7b4-7bde-41d6-a09a-25afc4a4673f", "Add Int", Relay_In_42)) return; 
         {
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_45_System_Int32);
               logic_uScriptAct_AddInt_A_42 = properties.ToArray();
            }
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_Score_System_Int32);
               logic_uScriptAct_AddInt_B_42 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddInt_uScriptAct_AddInt_42.In(logic_uScriptAct_AddInt_A_42, logic_uScriptAct_AddInt_B_42, out logic_uScriptAct_AddInt_IntResult_42, out logic_uScriptAct_AddInt_FloatResult_42);
         local_Score_System_Int32 = logic_uScriptAct_AddInt_IntResult_42;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Add Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_43()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3fd06310-bccd-46c1-88b9-58ffb94964bf", "Compare String", Relay_In_43)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_43 = local_GOName_System_String;
               
            }
            {
               logic_uScriptCon_CompareString_B_43 = local_46_System_String;
               
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_43.In(logic_uScriptCon_CompareString_A_43, logic_uScriptCon_CompareString_B_43);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_43.Same;
         bool test_1 = logic_uScriptCon_CompareString_uScriptCon_CompareString_43.Different;
         
         if ( test_0 == true )
         {
            Relay_In_42();
         }
         if ( test_1 == true )
         {
            Relay_In_50();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_48()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a8757f5b-b3df-41a1-8982-b6c0d314d9ff", "Add Int", Relay_In_48)) return; 
         {
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_49_System_Int32);
               logic_uScriptAct_AddInt_A_48 = properties.ToArray();
            }
            {
               List<System.Int32> properties = new List<System.Int32>();
               properties.Add((System.Int32)local_Score_System_Int32);
               logic_uScriptAct_AddInt_B_48 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddInt_uScriptAct_AddInt_48.In(logic_uScriptAct_AddInt_A_48, logic_uScriptAct_AddInt_B_48, out logic_uScriptAct_AddInt_IntResult_48, out logic_uScriptAct_AddInt_FloatResult_48);
         local_Score_System_Int32 = logic_uScriptAct_AddInt_IntResult_48;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Add Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_50()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c069ca36-bfe9-4fb1-9b54-ef35023086fb", "Compare String", Relay_In_50)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_50 = local_GOName_System_String;
               
            }
            {
               logic_uScriptCon_CompareString_B_50 = local_51_System_String;
               
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_50.In(logic_uScriptCon_CompareString_A_50, logic_uScriptCon_CompareString_B_50);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_50.Same;
         bool test_1 = logic_uScriptCon_CompareString_uScriptCon_CompareString_50.Different;
         
         if ( test_0 == true )
         {
            Relay_In_48();
         }
         if ( test_1 == true )
         {
            Relay_In_54();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_54()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("72cd5225-546b-4661-8c5f-4a0745ecc475", "Log", Relay_In_54)) return; 
         {
            {
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_GOName_System_String);
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_56()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("aba1fc5b-5479-409c-b9b7-912b9692fb52", "GUI Label", Relay_In_56)) return; 
         {
            {
               logic_uScriptAct_GUILabel_Text_56 = local_60_System_String;
               
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
         logic_uScriptAct_GUILabel_uScriptAct_GUILabel_56.In(logic_uScriptAct_GUILabel_Text_56, logic_uScriptAct_GUILabel_Position_56, logic_uScriptAct_GUILabel_Texture_56, logic_uScriptAct_GUILabel_ToolTip_56, logic_uScriptAct_GUILabel_guiStyle_56);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at GUI Label.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_57()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("38bb4a7d-fcb5-4f15-9d79-5711414e7b2e", "Concatenate", Relay_In_57)) return; 
         {
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_59_System_String);
               logic_uScriptAct_Concatenate_A_57 = properties.ToArray();
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_Score_System_Int32);
               logic_uScriptAct_Concatenate_B_57 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_Concatenate_uScriptAct_Concatenate_57.In(logic_uScriptAct_Concatenate_A_57, logic_uScriptAct_Concatenate_B_57, logic_uScriptAct_Concatenate_Separator_57, out logic_uScriptAct_Concatenate_Result_57);
         local_60_System_String = logic_uScriptAct_Concatenate_Result_57;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Concatenate_uScriptAct_Concatenate_57.Out;
         
         if ( test_0 == true )
         {
            Relay_In_56();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GameWheel_Metagame.uscript at Concatenate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_63()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("87cc237d-347b-4609-b1f6-2024d770a3b5", "Set Random Float", Relay_In_63)) return; 
         {
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_63.In(logic_uScriptAct_SetRandomFloat_Min_63, logic_uScriptAct_SetRandomFloat_Max_63, out logic_uScriptAct_SetRandomFloat_TargetFloat_63);
         local_64_System_Single = logic_uScriptAct_SetRandomFloat_TargetFloat_63;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetRandomFloat_uScriptAct_SetRandomFloat_63.Out;
         
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
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:7", local_7_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "8b07f182-b07d-416f-a6a5-5325d86d418e", local_7_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:Spinning", local_Spinning_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "acef3158-76f3-4bd5-b4bf-9005a18a4c0d", local_Spinning_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:Slowing", local_Slowing_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "cb44b0a8-e56e-4c7f-96c6-500848938713", local_Slowing_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:25", local_25_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "436e5068-d843-4ae9-9d36-026b15bd5131", local_25_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:CurrentValue", local_CurrentValue_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "8b8771de-93e1-4bdf-a064-8d2f5a94229f", local_CurrentValue_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:32", local_32_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "9e28b93d-c717-4086-b369-dbb5f2cac6e5", local_32_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:35", local_35_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "accb283c-684c-455f-9a34-4617651abd35", local_35_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:36", local_36_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "09e60717-75e0-4b5d-a7aa-7d075d2b62b6", local_36_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:37", local_37_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "678ab3cb-756b-471f-b3fa-6285b780c3d9", local_37_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:45", local_45_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "3f68dd0a-4c93-470f-885a-ee28a66a0f68", local_45_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:46", local_46_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "38c63d5a-f75f-412e-9587-369f5703c2a8", local_46_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:49", local_49_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "4e911b8d-3747-4143-8536-51e752a0a569", local_49_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:51", local_51_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f6feb0e1-184f-4a85-b60c-cba8582152c5", local_51_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:GOName", local_GOName_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "244f9dcd-4e08-47ae-a9e0-2ba2ac858993", local_GOName_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:Score", local_Score_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "6e376bad-cb86-4e1f-91d3-0dc144a4dc07", local_Score_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:59", local_59_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d49906b5-32c5-4b48-a010-c9e7975082c1", local_59_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:60", local_60_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "65629ed2-1b69-4640-a24d-470a015fa3e4", local_60_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:WheelStopTime", WheelStopTime);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "05679969-9812-40a2-95b6-f4416e6fce84", WheelStopTime);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GameWheel_Metagame.uscript:64", local_64_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "9ed6af8f-97f6-49ff-b33b-a2704fb62a4e", local_64_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "42f73233-1248-40b6-952a-f4cd23b040ae", property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_22);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7f2e56a3-9d34-4f36-a533-7f7992bc8356", property_angularVelocity_Detox_ScriptEditor_Parameter_angularVelocity_23);
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
