//uScript Generated Code - Build 0.9.1848
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
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_0_UnityEngine_GameObject_previous != local_0_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_0_UnityEngine_GameObject_previous = local_0_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_6_UnityEngine_GameObject_previous != local_6_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_17_UnityEngine_GameObject_previous != local_17_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_17_UnityEngine_GameObject_previous = local_17_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_Cover3_UnityEngine_GameObject_previous != local_Cover3_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_Cover3_UnityEngine_GameObject_previous = local_Cover3_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_26_UnityEngine_GameObject_previous != local_26_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_26_UnityEngine_GameObject_previous = local_26_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_35_UnityEngine_GameObject_previous != local_35_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_35_UnityEngine_GameObject_previous = local_35_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_45_UnityEngine_GameObject_previous != local_45_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_45_UnityEngine_GameObject_previous = local_45_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_54_UnityEngine_GameObject_previous != local_54_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_54_UnityEngine_GameObject_previous = local_54_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_Cover1_UnityEngine_GameObject_previous != local_Cover1_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_Cover1_UnityEngine_GameObject_previous = local_Cover1_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_69_UnityEngine_GameObject_previous != local_69_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_69_UnityEngine_GameObject_previous = local_69_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_Cover2_UnityEngine_GameObject_previous != local_Cover2_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_Cover2_UnityEngine_GameObject_previous = local_Cover2_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_88_UnityEngine_GameObject_previous != local_88_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_88_UnityEngine_GameObject_previous = local_88_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_Monster_UnityEngine_GameObject_previous != local_Monster_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_Monster_UnityEngine_GameObject_previous = local_Monster_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_94_UnityEngine_GameObject_previous != local_94_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_94_UnityEngine_GameObject_previous = local_94_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_105_UnityEngine_GameObject_previous != local_105_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_105_UnityEngine_GameObject_previous = local_105_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void SyncEventListeners( )
   {
      if ( null == event_UnityEngine_GameObject_Instance_92 )
      {
         event_UnityEngine_GameObject_Instance_92 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_92 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_92.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_92.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_92;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_106 )
      {
         event_UnityEngine_GameObject_Instance_106 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_106 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_106.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_106.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_106;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != event_UnityEngine_GameObject_Instance_92 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_92.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_92;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_106 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_106.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_106;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_Log_uScriptAct_Log_1.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_14.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_16.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_19.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_28.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_36.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_43.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_55.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_63.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_64.SetParent(g);
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_65.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_67.SetParent(g);
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_68.SetParent(g);
      logic_uScriptAct_Toggle_uScriptAct_Toggle_70.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_72.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_74.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_75.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_76.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_80.SetParent(g);
      logic_uScriptAct_LookAt_uScriptAct_LookAt_83.SetParent(g);
      logic_uScriptAct_LookAt_uScriptAct_LookAt_89.SetParent(g);
      logic_uScriptAct_Teleport_uScriptAct_Teleport_96.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_98.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_103.SetParent(g);
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_107.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_109.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_110.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_115.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_116.SetParent(g);
   }
   public void Awake()
   {
      
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_55.Finished += uScriptAct_PlaySound_Finished_55;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_70.OnOut += uScriptAct_Toggle_OnOut_70;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_70.OffOut += uScriptAct_Toggle_OffOut_70;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_70.ToggleOut += uScriptAct_Toggle_ToggleOut_70;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_76.Finished += uScriptAct_PlaySound_Finished_76;
      logic_uScriptAct_LookAt_uScriptAct_LookAt_83.Finished += uScriptAct_LookAt_Finished_83;
      logic_uScriptAct_LookAt_uScriptAct_LookAt_89.Finished += uScriptAct_LookAt_Finished_89;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_116.Finished += uScriptAct_PlaySound_Finished_116;
   }
   
   public void Start()
   {
      SyncUnityHooks( );
      
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
      
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_55.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_76.Update( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_83.Update( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_89.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_116.Update( );
      if (true == logic_uScriptAct_Delay_DrivenDelay_63)
      {
         Relay_DrivenDelay_63();
      }
      if (true == logic_uScriptAct_Delay_DrivenDelay_64)
      {
         Relay_DrivenDelay_64();
      }
   }
   
   public void OnDestroy()
   {
      UnregisterEventListeners( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_55.Finished -= uScriptAct_PlaySound_Finished_55;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_70.OnOut -= uScriptAct_Toggle_OnOut_70;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_70.OffOut -= uScriptAct_Toggle_OffOut_70;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_70.ToggleOut -= uScriptAct_Toggle_ToggleOut_70;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_76.Finished -= uScriptAct_PlaySound_Finished_76;
      logic_uScriptAct_LookAt_uScriptAct_LookAt_83.Finished -= uScriptAct_LookAt_Finished_83;
      logic_uScriptAct_LookAt_uScriptAct_LookAt_89.Finished -= uScriptAct_LookAt_Finished_89;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_116.Finished -= uScriptAct_PlaySound_Finished_116;
   }
   
   void Instance_KeyEvent_92(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_92( );
   }
   
   void Instance_KeyEvent_106(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_106( );
   }
   
   void uScriptAct_PlaySound_Finished_55(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_55( );
   }
   
   void uScriptAct_Toggle_OnOut_70(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnOut_70( );
   }
   
   void uScriptAct_Toggle_OffOut_70(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OffOut_70( );
   }
   
   void uScriptAct_Toggle_ToggleOut_70(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_ToggleOut_70( );
   }
   
   void uScriptAct_PlaySound_Finished_76(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_76( );
   }
   
   void uScriptAct_LookAt_Finished_83(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_83( );
   }
   
   void uScriptAct_LookAt_Finished_89(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_89( );
   }
   
   void uScriptAct_PlaySound_Finished_116(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_116( );
   }
   
   void Relay_In_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4be3275c-fcbe-4e3e-af23-f775bd1dafad", "Log", Relay_In_1)) return; 
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_1.In(logic_uScriptAct_Log_Prefix_1, logic_uScriptAct_Log_Target_1, logic_uScriptAct_Log_Postfix_1);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_14()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a440fa9f-6a17-4c28-92dc-edacb1ace12b", "Int Counter", Relay_In_14)) return; 
         {
            logic_uScriptCon_IntCounter_B_14 = local_5_System_Int32;
            
         }
         logic_uScriptCon_IntCounter_uScriptCon_IntCounter_14.In(logic_uScriptCon_IntCounter_A_14, logic_uScriptCon_IntCounter_B_14, out logic_uScriptCon_IntCounter_currentValue_14);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_14.GreaterThan;
         bool test_1 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_14.GreaterThanOrEqualTo;
         bool test_2 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_14.EqualTo;
         bool test_3 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_14.LessThanOrEqualTo;
         bool test_4 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_14.LessThan;
         
         if ( test_0 == true )
         {
            Relay_In_43();
         }
         if ( test_1 == true )
         {
            Relay_In_75();
         }
         if ( test_2 == true )
         {
            Relay_In_16();
         }
         if ( test_3 == true )
         {
            Relay_In_103();
         }
         if ( test_4 == true )
         {
            Relay_In_103();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Int Counter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Reset_14()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a440fa9f-6a17-4c28-92dc-edacb1ace12b", "Int Counter", Relay_Reset_14)) return; 
         {
            logic_uScriptCon_IntCounter_B_14 = local_5_System_Int32;
            
         }
         logic_uScriptCon_IntCounter_uScriptCon_IntCounter_14.Reset(logic_uScriptCon_IntCounter_A_14, logic_uScriptCon_IntCounter_B_14, out logic_uScriptCon_IntCounter_currentValue_14);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_14.GreaterThan;
         bool test_1 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_14.GreaterThanOrEqualTo;
         bool test_2 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_14.EqualTo;
         bool test_3 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_14.LessThanOrEqualTo;
         bool test_4 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_14.LessThan;
         
         if ( test_0 == true )
         {
            Relay_In_43();
         }
         if ( test_1 == true )
         {
            Relay_In_75();
         }
         if ( test_2 == true )
         {
            Relay_In_16();
         }
         if ( test_3 == true )
         {
            Relay_In_103();
         }
         if ( test_4 == true )
         {
            Relay_In_103();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Int Counter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_16()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("462ee351-38f8-4820-a0a5-cad8546d65b0", "Log", Relay_In_16)) return; 
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_16.In(logic_uScriptAct_Log_Prefix_16, logic_uScriptAct_Log_Target_16, logic_uScriptAct_Log_Postfix_16);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_19()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a305a8be-0f86-4472-923b-4e433dbd7e48", "Log", Relay_In_19)) return; 
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_19.In(logic_uScriptAct_Log_Prefix_19, logic_uScriptAct_Log_Target_19, logic_uScriptAct_Log_Postfix_19);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_28()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("22291619-d991-46a5-877b-64b11963cd01", "Log", Relay_In_28)) return; 
         {
            int index;
            index = 0;
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_Cover3_UnityEngine_GameObject_previous != local_Cover3_UnityEngine_GameObject )
               {
                  //tear down old listeners
                  
                  local_Cover3_UnityEngine_GameObject_previous = local_Cover3_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            if ( logic_uScriptAct_Log_Target_28.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Log_Target_28, index + 1);
            }
            logic_uScriptAct_Log_Target_28[ index++ ] = local_Cover3_UnityEngine_GameObject;
            
         }
         logic_uScriptAct_Log_uScriptAct_Log_28.In(logic_uScriptAct_Log_Prefix_28, logic_uScriptAct_Log_Target_28, logic_uScriptAct_Log_Postfix_28);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_36()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4bd0cd79-1da7-4551-8c56-4f6e3a048b00", "Int Counter", Relay_In_36)) return; 
         {
            logic_uScriptCon_IntCounter_B_36 = local_49_System_Int32;
            
         }
         logic_uScriptCon_IntCounter_uScriptCon_IntCounter_36.In(logic_uScriptCon_IntCounter_A_36, logic_uScriptCon_IntCounter_B_36, out logic_uScriptCon_IntCounter_currentValue_36);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_36.GreaterThan;
         bool test_1 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_36.GreaterThanOrEqualTo;
         bool test_2 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_36.EqualTo;
         bool test_3 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_36.LessThanOrEqualTo;
         bool test_4 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_36.LessThan;
         
         if ( test_0 == true )
         {
            Relay_In_72();
         }
         if ( test_1 == true )
         {
            Relay_In_74();
         }
         if ( test_2 == true )
         {
            Relay_In_1();
         }
         if ( test_3 == true )
         {
            Relay_In_67();
         }
         if ( test_4 == true )
         {
            Relay_In_67();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Int Counter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Reset_36()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4bd0cd79-1da7-4551-8c56-4f6e3a048b00", "Int Counter", Relay_Reset_36)) return; 
         {
            logic_uScriptCon_IntCounter_B_36 = local_49_System_Int32;
            
         }
         logic_uScriptCon_IntCounter_uScriptCon_IntCounter_36.Reset(logic_uScriptCon_IntCounter_A_36, logic_uScriptCon_IntCounter_B_36, out logic_uScriptCon_IntCounter_currentValue_36);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_36.GreaterThan;
         bool test_1 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_36.GreaterThanOrEqualTo;
         bool test_2 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_36.EqualTo;
         bool test_3 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_36.LessThanOrEqualTo;
         bool test_4 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_36.LessThan;
         
         if ( test_0 == true )
         {
            Relay_In_72();
         }
         if ( test_1 == true )
         {
            Relay_In_74();
         }
         if ( test_2 == true )
         {
            Relay_In_1();
         }
         if ( test_3 == true )
         {
            Relay_In_67();
         }
         if ( test_4 == true )
         {
            Relay_In_67();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Int Counter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_43()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f44d061e-de56-47d9-b229-868135231342", "Log", Relay_In_43)) return; 
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_43.In(logic_uScriptAct_Log_Prefix_43, logic_uScriptAct_Log_Target_43, logic_uScriptAct_Log_Postfix_43);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_55()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("cc3cbc31-f842-4dad-bc9e-4c1e88cb52e7", "Play Sound", Relay_Finished_55)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Play_55()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("cc3cbc31-f842-4dad-bc9e-4c1e88cb52e7", "Play Sound", Relay_Play_55)) return; 
         {
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_55.Play(logic_uScriptAct_PlaySound_audioClip_55, logic_uScriptAct_PlaySound_target_55, logic_uScriptAct_PlaySound_volume_55, logic_uScriptAct_PlaySound_loop_55);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_PlaySound_uScriptAct_PlaySound_55.Out;
         
         if ( test_0 == true )
         {
            Relay_In_115();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_UpdateVolume_55()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("cc3cbc31-f842-4dad-bc9e-4c1e88cb52e7", "Play Sound", Relay_UpdateVolume_55)) return; 
         {
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_55.UpdateVolume(logic_uScriptAct_PlaySound_audioClip_55, logic_uScriptAct_PlaySound_target_55, logic_uScriptAct_PlaySound_volume_55, logic_uScriptAct_PlaySound_loop_55);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_PlaySound_uScriptAct_PlaySound_55.Out;
         
         if ( test_0 == true )
         {
            Relay_In_115();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_55()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("cc3cbc31-f842-4dad-bc9e-4c1e88cb52e7", "Play Sound", Relay_Stop_55)) return; 
         {
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_55.Stop(logic_uScriptAct_PlaySound_audioClip_55, logic_uScriptAct_PlaySound_target_55, logic_uScriptAct_PlaySound_volume_55, logic_uScriptAct_PlaySound_loop_55);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_PlaySound_uScriptAct_PlaySound_55.Out;
         
         if ( test_0 == true )
         {
            Relay_In_115();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_63()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e9561390-31c1-4ebb-b6d6-efac67318268", "Delay", Relay_In_63)) return; 
         {
            logic_uScriptAct_Delay_Duration_63 = local_25_System_Single;
            
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_63.In(logic_uScriptAct_Delay_Duration_63);
         logic_uScriptAct_Delay_DrivenDelay_63 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_63.Immediate;
         bool test_1 = logic_uScriptAct_Delay_uScriptAct_Delay_63.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_In_19();
         }
         if ( test_1 == true )
         {
            Relay_In_28();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_DrivenDelay_63( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            logic_uScriptAct_Delay_Duration_63 = local_25_System_Single;
            
         }
         logic_uScriptAct_Delay_DrivenDelay_63 = logic_uScriptAct_Delay_uScriptAct_Delay_63.DrivenDelay();
         if ( true == logic_uScriptAct_Delay_DrivenDelay_63 )
         {
            if ( logic_uScriptAct_Delay_uScriptAct_Delay_63.Immediate == true )
            {
               Relay_In_19();
            }
            if ( logic_uScriptAct_Delay_uScriptAct_Delay_63.AfterDelay == true )
            {
               Relay_In_28();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_In_64()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("02ff9116-0c4f-4aaf-ba41-f312cb1252ef", "Delay", Relay_In_64)) return; 
         {
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_64.In(logic_uScriptAct_Delay_Duration_64);
         logic_uScriptAct_Delay_DrivenDelay_64 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_64.Immediate;
         
         if ( test_0 == true )
         {
            Relay_In_110();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_DrivenDelay_64( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
         }
         logic_uScriptAct_Delay_DrivenDelay_64 = logic_uScriptAct_Delay_uScriptAct_Delay_64.DrivenDelay();
         if ( true == logic_uScriptAct_Delay_DrivenDelay_64 )
         {
            if ( logic_uScriptAct_Delay_uScriptAct_Delay_64.Immediate == true )
            {
               Relay_In_110();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_In_65()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2a8539ca-7852-4f46-a04b-a68d36b8c0c6", "Destroy Component", Relay_In_65)) return; 
         {
            int index;
            index = 0;
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_Monster_UnityEngine_GameObject_previous != local_Monster_UnityEngine_GameObject )
               {
                  //tear down old listeners
                  
                  local_Monster_UnityEngine_GameObject_previous = local_Monster_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            if ( logic_uScriptAct_DestroyComponent_Target_65.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_DestroyComponent_Target_65, index + 1);
            }
            logic_uScriptAct_DestroyComponent_Target_65[ index++ ] = local_Monster_UnityEngine_GameObject;
            
            index = 0;
            if ( logic_uScriptAct_DestroyComponent_ComponentName_65.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_DestroyComponent_ComponentName_65, index + 1);
            }
            logic_uScriptAct_DestroyComponent_ComponentName_65[ index++ ] = local_2_System_String;
            
         }
         logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_65.In(logic_uScriptAct_DestroyComponent_Target_65, logic_uScriptAct_DestroyComponent_ComponentName_65, logic_uScriptAct_DestroyComponent_DelayTime_65);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_65.Out;
         
         if ( test_0 == true )
         {
            Relay_In_36();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Destroy Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_67()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("05fa14f8-dbab-4bfc-91e6-8d6ea9ff3982", "Log", Relay_In_67)) return; 
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_67.In(logic_uScriptAct_Log_Prefix_67, logic_uScriptAct_Log_Target_67, logic_uScriptAct_Log_Postfix_67);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_68()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("946abbb0-d896-4a44-b703-8efc3745545f", "Destroy Component", Relay_In_68)) return; 
         {
            int index;
            index = 0;
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_Monster_UnityEngine_GameObject_previous != local_Monster_UnityEngine_GameObject )
               {
                  //tear down old listeners
                  
                  local_Monster_UnityEngine_GameObject_previous = local_Monster_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            if ( logic_uScriptAct_DestroyComponent_Target_68.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_DestroyComponent_Target_68, index + 1);
            }
            logic_uScriptAct_DestroyComponent_Target_68[ index++ ] = local_Monster_UnityEngine_GameObject;
            
            index = 0;
            if ( logic_uScriptAct_DestroyComponent_ComponentName_68.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_DestroyComponent_ComponentName_68, index + 1);
            }
            logic_uScriptAct_DestroyComponent_ComponentName_68[ index++ ] = local_34_System_String;
            
         }
         logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_68.In(logic_uScriptAct_DestroyComponent_Target_68, logic_uScriptAct_DestroyComponent_ComponentName_68, logic_uScriptAct_DestroyComponent_DelayTime_68);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_68.Out;
         
         if ( test_0 == true )
         {
            Relay_In_14();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Destroy Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnOut_70()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f1a5ab09-6a40-4d6d-8074-0c475f1d84b0", "Toggle", Relay_OnOut_70)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Toggle.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OffOut_70()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f1a5ab09-6a40-4d6d-8074-0c475f1d84b0", "Toggle", Relay_OffOut_70)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Toggle.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ToggleOut_70()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f1a5ab09-6a40-4d6d-8074-0c475f1d84b0", "Toggle", Relay_ToggleOut_70)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Toggle.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_TurnOn_70()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f1a5ab09-6a40-4d6d-8074-0c475f1d84b0", "Toggle", Relay_TurnOn_70)) return; 
         {
            int index;
            index = 0;
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_Cover1_UnityEngine_GameObject_previous != local_Cover1_UnityEngine_GameObject )
               {
                  //tear down old listeners
                  
                  local_Cover1_UnityEngine_GameObject_previous = local_Cover1_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            if ( logic_uScriptAct_Toggle_Target_70.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Toggle_Target_70, index + 1);
            }
            logic_uScriptAct_Toggle_Target_70[ index++ ] = local_Cover1_UnityEngine_GameObject;
            
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_Cover2_UnityEngine_GameObject_previous != local_Cover2_UnityEngine_GameObject )
               {
                  //tear down old listeners
                  
                  local_Cover2_UnityEngine_GameObject_previous = local_Cover2_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            if ( logic_uScriptAct_Toggle_Target_70.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Toggle_Target_70, index + 1);
            }
            logic_uScriptAct_Toggle_Target_70[ index++ ] = local_Cover2_UnityEngine_GameObject;
            
         }
         logic_uScriptAct_Toggle_uScriptAct_Toggle_70.TurnOn(logic_uScriptAct_Toggle_Target_70, logic_uScriptAct_Toggle_IgnoreChildren_70);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Toggle_uScriptAct_Toggle_70.Out;
         
         if ( test_0 == true )
         {
            Relay_In_63();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Toggle.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_TurnOff_70()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f1a5ab09-6a40-4d6d-8074-0c475f1d84b0", "Toggle", Relay_TurnOff_70)) return; 
         {
            int index;
            index = 0;
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_Cover1_UnityEngine_GameObject_previous != local_Cover1_UnityEngine_GameObject )
               {
                  //tear down old listeners
                  
                  local_Cover1_UnityEngine_GameObject_previous = local_Cover1_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            if ( logic_uScriptAct_Toggle_Target_70.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Toggle_Target_70, index + 1);
            }
            logic_uScriptAct_Toggle_Target_70[ index++ ] = local_Cover1_UnityEngine_GameObject;
            
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_Cover2_UnityEngine_GameObject_previous != local_Cover2_UnityEngine_GameObject )
               {
                  //tear down old listeners
                  
                  local_Cover2_UnityEngine_GameObject_previous = local_Cover2_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            if ( logic_uScriptAct_Toggle_Target_70.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Toggle_Target_70, index + 1);
            }
            logic_uScriptAct_Toggle_Target_70[ index++ ] = local_Cover2_UnityEngine_GameObject;
            
         }
         logic_uScriptAct_Toggle_uScriptAct_Toggle_70.TurnOff(logic_uScriptAct_Toggle_Target_70, logic_uScriptAct_Toggle_IgnoreChildren_70);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Toggle_uScriptAct_Toggle_70.Out;
         
         if ( test_0 == true )
         {
            Relay_In_63();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Toggle.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Toggle_70()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f1a5ab09-6a40-4d6d-8074-0c475f1d84b0", "Toggle", Relay_Toggle_70)) return; 
         {
            int index;
            index = 0;
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_Cover1_UnityEngine_GameObject_previous != local_Cover1_UnityEngine_GameObject )
               {
                  //tear down old listeners
                  
                  local_Cover1_UnityEngine_GameObject_previous = local_Cover1_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            if ( logic_uScriptAct_Toggle_Target_70.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Toggle_Target_70, index + 1);
            }
            logic_uScriptAct_Toggle_Target_70[ index++ ] = local_Cover1_UnityEngine_GameObject;
            
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_Cover2_UnityEngine_GameObject_previous != local_Cover2_UnityEngine_GameObject )
               {
                  //tear down old listeners
                  
                  local_Cover2_UnityEngine_GameObject_previous = local_Cover2_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            if ( logic_uScriptAct_Toggle_Target_70.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Toggle_Target_70, index + 1);
            }
            logic_uScriptAct_Toggle_Target_70[ index++ ] = local_Cover2_UnityEngine_GameObject;
            
         }
         logic_uScriptAct_Toggle_uScriptAct_Toggle_70.Toggle(logic_uScriptAct_Toggle_Target_70, logic_uScriptAct_Toggle_IgnoreChildren_70);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Toggle_uScriptAct_Toggle_70.Out;
         
         if ( test_0 == true )
         {
            Relay_In_63();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Toggle.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_72()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d63f6f11-f804-440a-b306-03193f2977ba", "Log", Relay_In_72)) return; 
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_72.In(logic_uScriptAct_Log_Prefix_72, logic_uScriptAct_Log_Target_72, logic_uScriptAct_Log_Postfix_72);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_74()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f82dab27-423b-410b-ac2e-241242674fa2", "Log", Relay_In_74)) return; 
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_74.In(logic_uScriptAct_Log_Prefix_74, logic_uScriptAct_Log_Target_74, logic_uScriptAct_Log_Postfix_74);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_75()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c2ad20b1-6afb-435e-86d5-d835bf9ce8b5", "Log", Relay_In_75)) return; 
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_75.In(logic_uScriptAct_Log_Prefix_75, logic_uScriptAct_Log_Target_75, logic_uScriptAct_Log_Postfix_75);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_76()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("df91d8ba-6284-4150-8d70-56c445509598", "Play Sound", Relay_Finished_76)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Play_76()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("df91d8ba-6284-4150-8d70-56c445509598", "Play Sound", Relay_Play_76)) return; 
         {
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_76.Play(logic_uScriptAct_PlaySound_audioClip_76, logic_uScriptAct_PlaySound_target_76, logic_uScriptAct_PlaySound_volume_76, logic_uScriptAct_PlaySound_loop_76);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_PlaySound_uScriptAct_PlaySound_76.Out;
         
         if ( test_0 == true )
         {
            Relay_In_98();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_UpdateVolume_76()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("df91d8ba-6284-4150-8d70-56c445509598", "Play Sound", Relay_UpdateVolume_76)) return; 
         {
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_76.UpdateVolume(logic_uScriptAct_PlaySound_audioClip_76, logic_uScriptAct_PlaySound_target_76, logic_uScriptAct_PlaySound_volume_76, logic_uScriptAct_PlaySound_loop_76);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_PlaySound_uScriptAct_PlaySound_76.Out;
         
         if ( test_0 == true )
         {
            Relay_In_98();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_76()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("df91d8ba-6284-4150-8d70-56c445509598", "Play Sound", Relay_Stop_76)) return; 
         {
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_76.Stop(logic_uScriptAct_PlaySound_audioClip_76, logic_uScriptAct_PlaySound_target_76, logic_uScriptAct_PlaySound_volume_76, logic_uScriptAct_PlaySound_loop_76);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_PlaySound_uScriptAct_PlaySound_76.Out;
         
         if ( test_0 == true )
         {
            Relay_In_98();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_80()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e304c37f-ccc5-4a1e-ac1a-1370efa9ccc4", "Input Events Filter", Relay_In_80)) return; 
         {
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_80.In(logic_uScriptAct_OnInputEventFilter_KeyCode_80);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_80.KeyDown;
         bool test_1 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_80.KeyUp;
         
         if ( test_0 == true )
         {
            Relay_Play_55();
         }
         if ( test_1 == true )
         {
            Relay_In_68();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_83()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("eba3b3e6-e10f-42f8-bbab-6e6066e48a25", "Look At", Relay_Finished_83)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Look At.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_83()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("eba3b3e6-e10f-42f8-bbab-6e6066e48a25", "Look At", Relay_In_83)) return; 
         {
            int index;
            index = 0;
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_94_UnityEngine_GameObject_previous != local_94_UnityEngine_GameObject )
               {
                  //tear down old listeners
                  
                  local_94_UnityEngine_GameObject_previous = local_94_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            if ( logic_uScriptAct_LookAt_Target_83.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_83, index + 1);
            }
            logic_uScriptAct_LookAt_Target_83[ index++ ] = local_94_UnityEngine_GameObject;
            
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_88_UnityEngine_GameObject_previous != local_88_UnityEngine_GameObject )
               {
                  //tear down old listeners
                  
                  local_88_UnityEngine_GameObject_previous = local_88_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            if ( logic_uScriptAct_LookAt_Target_83.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_83, index + 1);
            }
            logic_uScriptAct_LookAt_Target_83[ index++ ] = local_88_UnityEngine_GameObject;
            
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_45_UnityEngine_GameObject_previous != local_45_UnityEngine_GameObject )
               {
                  //tear down old listeners
                  
                  local_45_UnityEngine_GameObject_previous = local_45_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            if ( logic_uScriptAct_LookAt_Target_83.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_83, index + 1);
            }
            logic_uScriptAct_LookAt_Target_83[ index++ ] = local_45_UnityEngine_GameObject;
            
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_105_UnityEngine_GameObject_previous != local_105_UnityEngine_GameObject )
               {
                  //tear down old listeners
                  
                  local_105_UnityEngine_GameObject_previous = local_105_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            if ( logic_uScriptAct_LookAt_Target_83.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_83, index + 1);
            }
            logic_uScriptAct_LookAt_Target_83[ index++ ] = local_105_UnityEngine_GameObject;
            
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_26_UnityEngine_GameObject_previous != local_26_UnityEngine_GameObject )
               {
                  //tear down old listeners
                  
                  local_26_UnityEngine_GameObject_previous = local_26_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            if ( logic_uScriptAct_LookAt_Target_83.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_83, index + 1);
            }
            logic_uScriptAct_LookAt_Target_83[ index++ ] = local_26_UnityEngine_GameObject;
            
         }
         logic_uScriptAct_LookAt_uScriptAct_LookAt_83.In(logic_uScriptAct_LookAt_Target_83, logic_uScriptAct_LookAt_Focus_83, logic_uScriptAct_LookAt_time_83, logic_uScriptAct_LookAt_lockAxis_83);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Look At.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_89()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("568ade37-79eb-46c7-ba19-259de6b0cf25", "Look At", Relay_Finished_89)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Look At.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_89()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("568ade37-79eb-46c7-ba19-259de6b0cf25", "Look At", Relay_In_89)) return; 
         {
            int index;
            index = 0;
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_35_UnityEngine_GameObject_previous != local_35_UnityEngine_GameObject )
               {
                  //tear down old listeners
                  
                  local_35_UnityEngine_GameObject_previous = local_35_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            if ( logic_uScriptAct_LookAt_Target_89.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_89, index + 1);
            }
            logic_uScriptAct_LookAt_Target_89[ index++ ] = local_35_UnityEngine_GameObject;
            
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_69_UnityEngine_GameObject_previous != local_69_UnityEngine_GameObject )
               {
                  //tear down old listeners
                  
                  local_69_UnityEngine_GameObject_previous = local_69_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            if ( logic_uScriptAct_LookAt_Target_89.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_89, index + 1);
            }
            logic_uScriptAct_LookAt_Target_89[ index++ ] = local_69_UnityEngine_GameObject;
            
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_0_UnityEngine_GameObject_previous != local_0_UnityEngine_GameObject )
               {
                  //tear down old listeners
                  
                  local_0_UnityEngine_GameObject_previous = local_0_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            if ( logic_uScriptAct_LookAt_Target_89.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_89, index + 1);
            }
            logic_uScriptAct_LookAt_Target_89[ index++ ] = local_0_UnityEngine_GameObject;
            
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_17_UnityEngine_GameObject_previous != local_17_UnityEngine_GameObject )
               {
                  //tear down old listeners
                  
                  local_17_UnityEngine_GameObject_previous = local_17_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            if ( logic_uScriptAct_LookAt_Target_89.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_89, index + 1);
            }
            logic_uScriptAct_LookAt_Target_89[ index++ ] = local_17_UnityEngine_GameObject;
            
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_6_UnityEngine_GameObject_previous != local_6_UnityEngine_GameObject )
               {
                  //tear down old listeners
                  
                  local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            if ( logic_uScriptAct_LookAt_Target_89.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_89, index + 1);
            }
            logic_uScriptAct_LookAt_Target_89[ index++ ] = local_6_UnityEngine_GameObject;
            
         }
         logic_uScriptAct_LookAt_uScriptAct_LookAt_89.In(logic_uScriptAct_LookAt_Target_89, logic_uScriptAct_LookAt_Focus_89, logic_uScriptAct_LookAt_time_89, logic_uScriptAct_LookAt_lockAxis_89);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Look At.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_92()
   {
      if (true == CheckDebugBreak("a856229d-2f54-4fdd-995a-1b95a676022c", "Input Events", Relay_KeyEvent_92)) return; 
      Relay_In_80();
   }
   
   void Relay_In_96()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ce1fa72c-9798-4a0c-bd8b-b595cfd6613e", "Teleport", Relay_In_96)) return; 
         {
            int index;
            index = 0;
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_54_UnityEngine_GameObject_previous != local_54_UnityEngine_GameObject )
               {
                  //tear down old listeners
                  
                  local_54_UnityEngine_GameObject_previous = local_54_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            if ( logic_uScriptAct_Teleport_Target_96.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Teleport_Target_96, index + 1);
            }
            logic_uScriptAct_Teleport_Target_96[ index++ ] = local_54_UnityEngine_GameObject;
            
         }
         logic_uScriptAct_Teleport_uScriptAct_Teleport_96.In(logic_uScriptAct_Teleport_Target_96, logic_uScriptAct_Teleport_Destination_96, logic_uScriptAct_Teleport_UpdateRotation_96);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Teleport_uScriptAct_Teleport_96.Out;
         
         if ( test_0 == true )
         {
            Relay_In_19();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Teleport.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_98()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("15fa09ba-de02-40f9-ad6f-088b7e027c06", "Compare Bool", Relay_In_98)) return; 
         {
            logic_uScriptCon_CompareBool_Bool_98 = local_22_System_Boolean;
            
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_98.In(logic_uScriptCon_CompareBool_Bool_98);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_98.False;
         
         if ( test_0 == true )
         {
            Relay_In_89();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_103()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("fff4dec1-3751-422d-ba6f-9f7808cf0a7a", "Log", Relay_In_103)) return; 
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_103.In(logic_uScriptAct_Log_Prefix_103, logic_uScriptAct_Log_Target_103, logic_uScriptAct_Log_Postfix_103);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_106()
   {
      if (true == CheckDebugBreak("69e6e3a5-c588-4584-8451-0dd7e41814a5", "Input Events", Relay_KeyEvent_106)) return; 
      Relay_In_109();
   }
   
   void Relay_In_107()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("17c59a20-6765-4be5-a093-491c67a03a43", "Concatenate", Relay_In_107)) return; 
         {
            int index;
            index = 0;
            if ( logic_uScriptAct_Concatenate_A_107.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Concatenate_A_107, index + 1);
            }
            logic_uScriptAct_Concatenate_A_107[ index++ ] = local_119_System_String;
            
            index = 0;
            if ( logic_uScriptAct_Concatenate_B_107.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Concatenate_B_107, index + 1);
            }
            logic_uScriptAct_Concatenate_B_107[ index++ ] = local_9_System_Int32;
            
         }
         logic_uScriptAct_Concatenate_uScriptAct_Concatenate_107.In(logic_uScriptAct_Concatenate_A_107, logic_uScriptAct_Concatenate_B_107, logic_uScriptAct_Concatenate_Separator_107, out logic_uScriptAct_Concatenate_Result_107);
         local_86_System_String = logic_uScriptAct_Concatenate_Result_107;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Concatenate_uScriptAct_Concatenate_107.Out;
         
         if ( test_0 == true )
         {
            Relay_In_96();
            Relay_Play_116();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Concatenate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_109()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("892454ea-a6b0-413e-b725-8acac29dde32", "Input Events Filter", Relay_In_109)) return; 
         {
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_109.In(logic_uScriptAct_OnInputEventFilter_KeyCode_109);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_109.KeyDown;
         bool test_1 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_109.KeyUp;
         
         if ( test_0 == true )
         {
            Relay_In_65();
         }
         if ( test_1 == true )
         {
            Relay_Play_76();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_110()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b003ab9f-f3bb-472a-bef5-23e4e22e35ca", "Int Counter", Relay_In_110)) return; 
         {
            logic_uScriptCon_IntCounter_A_110 = local_113_System_Int32;
            
            logic_uScriptCon_IntCounter_B_110 = local_53_System_Int32;
            
         }
         logic_uScriptCon_IntCounter_uScriptCon_IntCounter_110.In(logic_uScriptCon_IntCounter_A_110, logic_uScriptCon_IntCounter_B_110, out logic_uScriptCon_IntCounter_currentValue_110);
         local_9_System_Int32 = logic_uScriptCon_IntCounter_currentValue_110;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_110.GreaterThanOrEqualTo;
         
         if ( test_0 == true )
         {
            Relay_In_107();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Int Counter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Reset_110()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b003ab9f-f3bb-472a-bef5-23e4e22e35ca", "Int Counter", Relay_Reset_110)) return; 
         {
            logic_uScriptCon_IntCounter_A_110 = local_113_System_Int32;
            
            logic_uScriptCon_IntCounter_B_110 = local_53_System_Int32;
            
         }
         logic_uScriptCon_IntCounter_uScriptCon_IntCounter_110.Reset(logic_uScriptCon_IntCounter_A_110, logic_uScriptCon_IntCounter_B_110, out logic_uScriptCon_IntCounter_currentValue_110);
         local_9_System_Int32 = logic_uScriptCon_IntCounter_currentValue_110;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_IntCounter_uScriptCon_IntCounter_110.GreaterThanOrEqualTo;
         
         if ( test_0 == true )
         {
            Relay_In_107();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Int Counter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_115()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("68a827d6-5a77-4f56-b1c6-8194b5be3d26", "Compare Bool", Relay_In_115)) return; 
         {
            logic_uScriptCon_CompareBool_Bool_115 = local_15_System_Boolean;
            
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_115.In(logic_uScriptCon_CompareBool_Bool_115);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_115.False;
         
         if ( test_0 == true )
         {
            Relay_In_83();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_116()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4e3ce073-1c25-4fb6-9d0b-620a1e94ed6f", "Play Sound", Relay_Finished_116)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Play_116()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4e3ce073-1c25-4fb6-9d0b-620a1e94ed6f", "Play Sound", Relay_Play_116)) return; 
         {
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_116.Play(logic_uScriptAct_PlaySound_audioClip_116, logic_uScriptAct_PlaySound_target_116, logic_uScriptAct_PlaySound_volume_116, logic_uScriptAct_PlaySound_loop_116);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_UpdateVolume_116()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4e3ce073-1c25-4fb6-9d0b-620a1e94ed6f", "Play Sound", Relay_UpdateVolume_116)) return; 
         {
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_116.UpdateVolume(logic_uScriptAct_PlaySound_audioClip_116, logic_uScriptAct_PlaySound_target_116, logic_uScriptAct_PlaySound_volume_116, logic_uScriptAct_PlaySound_loop_116);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_116()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4e3ce073-1c25-4fb6-9d0b-620a1e94ed6f", "Play Sound", Relay_Stop_116)) return; 
         {
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_116.Stop(logic_uScriptAct_PlaySound_audioClip_116, logic_uScriptAct_PlaySound_target_116, logic_uScriptAct_PlaySound_volume_116, logic_uScriptAct_PlaySound_loop_116);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   [Driven]
   public bool DrivenDelay_63(  )
   {
      return logic_uScriptAct_Delay_DrivenDelay_63;
   }
   
   [Driven]
   public bool DrivenDelay_64(  )
   {
      return logic_uScriptAct_Delay_DrivenDelay_64;
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:0", local_0_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "700b31ce-d39a-45c1-bfbb-5167a1af043c", local_0_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:2", local_2_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "5e839179-239a-4e6e-891f-d0fc7bbd9c1c", local_2_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:5", local_5_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "08f7b1fd-8b84-4b18-a12f-1fc888ad0d53", local_5_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:6", local_6_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a6079937-01cd-48a0-a903-6945a0b0db7d", local_6_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:9", local_9_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "9bb83543-47d9-4b62-9e83-ce5d867a4e78", local_9_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:15", local_15_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b3047e11-45ae-42bc-8c0f-4624efe6da46", local_15_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:17", local_17_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b07cf586-c7e7-4c63-9f1c-0ea8526f6f9a", local_17_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:Cover3", local_Cover3_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "aa6e67b3-19c5-458f-9f9f-37d3344c3aa0", local_Cover3_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:22", local_22_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f80fd207-d1d6-4b5d-9464-0463cf224b69", local_22_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:25", local_25_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c8c67866-c569-457a-bca2-c8ef0b0e41d7", local_25_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:26", local_26_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "72a65482-8a7c-4bbe-a94a-95b147403253", local_26_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:34", local_34_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d0c2963c-86c7-4415-b19e-a52dab226e7a", local_34_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:35", local_35_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f3736609-4ced-4c45-80cb-f78cce95be2b", local_35_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:45", local_45_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "852db6a5-fea0-4696-880e-bce8de18a21b", local_45_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:49", local_49_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c42796c0-51c3-492e-a2a8-bf522f9fb389", local_49_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:53", local_53_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "de4060f3-5865-40fd-af2b-cc45f83629da", local_53_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:54", local_54_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "929f66b4-e326-4e49-94e5-f01c802af703", local_54_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:Cover1", local_Cover1_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "9b3d30ea-3d13-4e10-b26b-9c1f5dbf24a4", local_Cover1_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:69", local_69_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "732193c0-6948-4a35-a989-505082537dde", local_69_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:Cover2", local_Cover2_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ac1771f6-bde4-46d4-b495-59c375d71d04", local_Cover2_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:86", local_86_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "87a059be-60b4-4ba6-8cde-49fe89fd53ae", local_86_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:88", local_88_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "4ac5a598-0f14-4462-b07d-6633d9b4715b", local_88_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:Monster", local_Monster_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7ecb2ff8-5bc1-4277-8d06-a6fb21995c04", local_Monster_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:94", local_94_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "85cdd1d4-67f7-4532-9004-82a220246b27", local_94_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:105", local_105_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a99ec6a4-4db2-4bfd-be70-95e07dda0a00", local_105_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:113", local_113_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7e20e9e4-7ab6-409f-9aec-206dcb4aa315", local_113_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "uScript_StressTest.uscript:119", local_119_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "5c960525-e3fa-44f7-ba77-bc5f9f2ed7e0", local_119_System_String);
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
            m_ContinueExecution = new ContinueExecution(method);
            m_Breakpoint = true;
            return true;
         }
      }
      return false;
   }
}
