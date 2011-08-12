//uScript Generated Code - Build 0.9.1104
using UnityEngine;
using System.Collections;

public class uScript_StressTest : uScriptLogic
{

   #pragma warning disable 414
   GameObject parentGameObject = null;
   const int MaxRelayCallCount = 1000;
   int relayCallCount = 0;
   //external output properties
   
   //externally exposed events
   
   //external parameters
   
   //local nodes
   UnityEngine.GameObject local_0_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_0_UnityEngine_GameObject_previous = null;
   System.String local_1_System_String = "Area Damage";
   System.Int32 local_4_System_Int32 = (int) 0;
   UnityEngine.GameObject local_5_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_5_UnityEngine_GameObject_previous = null;
   System.Int32 local_7_System_Int32 = (int) 0;
   System.Boolean local_12_System_Boolean = (bool) false;
   UnityEngine.GameObject local_13_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_13_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Cover3_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Cover3_UnityEngine_GameObject_previous = null;
   System.Boolean local_16_System_Boolean = (bool) false;
   System.Single local_19_System_Single = (float) 3;
   UnityEngine.GameObject local_20_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_20_UnityEngine_GameObject_previous = null;
   System.String local_25_System_String = "Area Damage";
   UnityEngine.GameObject local_26_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_26_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_33_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_33_UnityEngine_GameObject_previous = null;
   System.Int32 local_37_System_Int32 = (int) 0;
   System.Int32 local_39_System_Int32 = (int) 0;
   UnityEngine.GameObject local_40_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_40_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Cover1_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Cover1_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_47_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_47_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Cover2_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Cover2_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Monster_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Monster_UnityEngine_GameObject_previous = null;
   System.String local_54_System_String = "";
   UnityEngine.GameObject local_56_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_56_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_58_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_58_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_65_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_65_UnityEngine_GameObject_previous = null;
   System.Int32 local_68_System_Int32 = (int) 0;
   System.String local_71_System_String = "Ogre";
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_76 = null;
   System.String logic_uScriptAct_Log_Prefix_76 = "";
   System.Object[] logic_uScriptAct_Log_Target_76 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_76 = "";
   bool logic_uScriptAct_Log_Out_76 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77 = null;
   System.Int32 logic_uScriptCon_IntCounter_A_77 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_B_77 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_77;
   bool logic_uScriptCon_IntCounter_GreaterThan_77 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_77 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_77 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_77 = true;
   bool logic_uScriptCon_IntCounter_LessThan_77 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_78 = null;
   System.String logic_uScriptAct_Log_Prefix_78 = "";
   System.Object[] logic_uScriptAct_Log_Target_78 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_78 = "";
   bool logic_uScriptAct_Log_Out_78 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_79 = null;
   System.String logic_uScriptAct_Log_Prefix_79 = "";
   System.Object[] logic_uScriptAct_Log_Target_79 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_79 = "";
   bool logic_uScriptAct_Log_Out_79 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_80 = null;
   System.String logic_uScriptAct_Log_Prefix_80 = "Trigger Fired!";
   System.Object[] logic_uScriptAct_Log_Target_80 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_80 = "";
   bool logic_uScriptAct_Log_Out_80 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_81 = null;
   System.Int32 logic_uScriptCon_IntCounter_A_81 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_B_81 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_81;
   bool logic_uScriptCon_IntCounter_GreaterThan_81 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_81 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_81 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_81 = true;
   bool logic_uScriptCon_IntCounter_LessThan_81 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_82 = null;
   System.String logic_uScriptAct_Log_Prefix_82 = "";
   System.Object[] logic_uScriptAct_Log_Target_82 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_82 = "";
   bool logic_uScriptAct_Log_Out_82 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_83 = null;
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_83 = null;
   UnityEngine.GameObject[] logic_uScriptAct_PlaySound_target_83 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_PlaySound_volume_83 = (float) 0;
   System.Boolean logic_uScriptAct_PlaySound_loop_83 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_83 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_84 = null;
   System.Single logic_uScriptAct_Delay_Duration_84 = (float) 0;
   bool logic_uScriptAct_Delay_Immediate_84 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_85 = null;
   System.Single logic_uScriptAct_Delay_Duration_85 = (float) 0;
   bool logic_uScriptAct_Delay_Immediate_85 = true;
   //pointer to script instanced logic node
   uScriptAct_DestroyComponent logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_86 = null;
   UnityEngine.GameObject[] logic_uScriptAct_DestroyComponent_Target_86 = new UnityEngine.GameObject[] {};
   System.String[] logic_uScriptAct_DestroyComponent_ComponentName_86 = new System.String[] {""};
   System.Single logic_uScriptAct_DestroyComponent_DelayTime_86 = (float) 0;
   bool logic_uScriptAct_DestroyComponent_Out_86 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_87 = null;
   System.String logic_uScriptAct_Log_Prefix_87 = "";
   System.Object[] logic_uScriptAct_Log_Target_87 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_87 = "";
   bool logic_uScriptAct_Log_Out_87 = true;
   //pointer to script instanced logic node
   uScriptAct_DestroyComponent logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_88 = null;
   UnityEngine.GameObject[] logic_uScriptAct_DestroyComponent_Target_88 = new UnityEngine.GameObject[] {};
   System.String[] logic_uScriptAct_DestroyComponent_ComponentName_88 = new System.String[] {""};
   System.Single logic_uScriptAct_DestroyComponent_DelayTime_88 = (float) 0;
   bool logic_uScriptAct_DestroyComponent_Out_88 = true;
   //pointer to script instanced logic node
   uScriptAct_Toggle logic_uScriptAct_Toggle_uScriptAct_Toggle_89 = null;
   UnityEngine.GameObject[] logic_uScriptAct_Toggle_Target_89 = new UnityEngine.GameObject[] {};
   System.Boolean logic_uScriptAct_Toggle_IgnoreChildren_89 = (bool) false;
   bool logic_uScriptAct_Toggle_Out_89 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_90 = null;
   System.String logic_uScriptAct_Log_Prefix_90 = "";
   System.Object[] logic_uScriptAct_Log_Target_90 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_90 = "";
   bool logic_uScriptAct_Log_Out_90 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_91 = null;
   System.String logic_uScriptAct_Log_Prefix_91 = "";
   System.Object[] logic_uScriptAct_Log_Target_91 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_91 = "";
   bool logic_uScriptAct_Log_Out_91 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_92 = null;
   System.String logic_uScriptAct_Log_Prefix_92 = "";
   System.Object[] logic_uScriptAct_Log_Target_92 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_92 = "";
   bool logic_uScriptAct_Log_Out_92 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_93 = null;
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_93 = null;
   UnityEngine.GameObject[] logic_uScriptAct_PlaySound_target_93 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_PlaySound_volume_93 = (float) 0;
   System.Boolean logic_uScriptAct_PlaySound_loop_93 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_93 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_94 = null;
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_94 = UnityEngine.KeyCode.None;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_94 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_94 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_94 = true;
   //pointer to script instanced logic node
   uScriptAct_LookAt logic_uScriptAct_LookAt_uScriptAct_LookAt_95 = null;
   UnityEngine.GameObject[] logic_uScriptAct_LookAt_Target_95 = new UnityEngine.GameObject[] {};
   System.Object logic_uScriptAct_LookAt_Focus_95 = "";
   System.Single logic_uScriptAct_LookAt_time_95 = (float) 0;
   bool logic_uScriptAct_LookAt_Out_95 = true;
   //pointer to script instanced logic node
   uScriptAct_LookAt logic_uScriptAct_LookAt_uScriptAct_LookAt_96 = null;
   UnityEngine.GameObject[] logic_uScriptAct_LookAt_Target_96 = new UnityEngine.GameObject[] {};
   System.Object logic_uScriptAct_LookAt_Focus_96 = "";
   System.Single logic_uScriptAct_LookAt_time_96 = (float) 0;
   bool logic_uScriptAct_LookAt_Out_96 = true;
   //pointer to script instanced logic node
   uScriptAct_Teleport logic_uScriptAct_Teleport_uScriptAct_Teleport_97 = null;
   UnityEngine.GameObject[] logic_uScriptAct_Teleport_Target_97 = new UnityEngine.GameObject[] {};
   UnityEngine.GameObject logic_uScriptAct_Teleport_Destination_97 = null;
   System.Boolean logic_uScriptAct_Teleport_UpdateRotation_97 = (bool) false;
   bool logic_uScriptAct_Teleport_Out_97 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_98 = null;
   System.Boolean logic_uScriptCon_CompareBool_Bool_98 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_98 = true;
   bool logic_uScriptCon_CompareBool_False_98 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_99 = null;
   System.String logic_uScriptAct_Log_Prefix_99 = "";
   System.Object[] logic_uScriptAct_Log_Target_99 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_99 = "";
   bool logic_uScriptAct_Log_Out_99 = true;
   //pointer to script instanced logic node
   uScriptAct_Concatenate logic_uScriptAct_Concatenate_uScriptAct_Concatenate_100 = null;
   System.Object[] logic_uScriptAct_Concatenate_A_100 = new System.Object[] {""};
   System.Object[] logic_uScriptAct_Concatenate_B_100 = new System.Object[] {""};
   System.String logic_uScriptAct_Concatenate_Separator_100 = "";
   System.String logic_uScriptAct_Concatenate_Result_100;
   bool logic_uScriptAct_Concatenate_Out_100 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_101 = null;
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_101 = UnityEngine.KeyCode.None;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_101 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_101 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_101 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_102 = null;
   System.Int32 logic_uScriptCon_IntCounter_A_102 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_B_102 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_102;
   bool logic_uScriptCon_IntCounter_GreaterThan_102 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_102 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_102 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_102 = true;
   bool logic_uScriptCon_IntCounter_LessThan_102 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_103 = null;
   System.Boolean logic_uScriptCon_CompareBool_Bool_103 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_103 = true;
   bool logic_uScriptCon_CompareBool_False_103 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_104 = null;
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_104 = null;
   UnityEngine.GameObject[] logic_uScriptAct_PlaySound_target_104 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_PlaySound_volume_104 = (float) 0;
   System.Boolean logic_uScriptAct_PlaySound_loop_104 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_104 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_105 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_106 = null;
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      if ( null == event_UnityEngine_GameObject_Instance_105 )
      {
         event_UnityEngine_GameObject_Instance_105 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_105 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_105.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_105.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_105;
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
      //if our game object reference was changed then we need to reset event listeners
      if ( local_0_UnityEngine_GameObject_previous != local_0_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_0_UnityEngine_GameObject_previous = local_0_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_5_UnityEngine_GameObject_previous != local_5_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_5_UnityEngine_GameObject_previous = local_5_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_13_UnityEngine_GameObject_previous != local_13_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_13_UnityEngine_GameObject_previous = local_13_UnityEngine_GameObject;
         
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
      if ( local_20_UnityEngine_GameObject_previous != local_20_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_20_UnityEngine_GameObject_previous = local_20_UnityEngine_GameObject;
         
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
      if ( local_33_UnityEngine_GameObject_previous != local_33_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_33_UnityEngine_GameObject_previous = local_33_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_40_UnityEngine_GameObject_previous != local_40_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_40_UnityEngine_GameObject_previous = local_40_UnityEngine_GameObject;
         
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
      if ( local_47_UnityEngine_GameObject_previous != local_47_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_47_UnityEngine_GameObject_previous = local_47_UnityEngine_GameObject;
         
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
      if ( local_Monster_UnityEngine_GameObject_previous != local_Monster_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_Monster_UnityEngine_GameObject_previous = local_Monster_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_56_UnityEngine_GameObject_previous != local_56_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_56_UnityEngine_GameObject_previous = local_56_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_58_UnityEngine_GameObject_previous != local_58_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_58_UnityEngine_GameObject_previous = local_58_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_65_UnityEngine_GameObject_previous != local_65_UnityEngine_GameObject )
      {
         //tear down old listeners
         
         local_65_UnityEngine_GameObject_previous = local_65_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_Log_uScriptAct_Log_76.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_78.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_79.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_80.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_81.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_82.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_83.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_84.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_85.SetParent(g);
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_86.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_87.SetParent(g);
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_88.SetParent(g);
      logic_uScriptAct_Toggle_uScriptAct_Toggle_89.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_90.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_91.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_92.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_93.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_94.SetParent(g);
      logic_uScriptAct_LookAt_uScriptAct_LookAt_95.SetParent(g);
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.SetParent(g);
      logic_uScriptAct_Teleport_uScriptAct_Teleport_97.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_98.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_99.SetParent(g);
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_100.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_101.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_102.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_103.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_104.SetParent(g);
   }
   public void Awake()
   {
      logic_uScriptAct_Log_uScriptAct_Log_76 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77 = ScriptableObject.CreateInstance(typeof(uScriptCon_IntCounter)) as uScriptCon_IntCounter;
      logic_uScriptAct_Log_uScriptAct_Log_78 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_79 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_80 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_81 = ScriptableObject.CreateInstance(typeof(uScriptCon_IntCounter)) as uScriptCon_IntCounter;
      logic_uScriptAct_Log_uScriptAct_Log_82 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_83 = ScriptableObject.CreateInstance(typeof(uScriptAct_PlaySound)) as uScriptAct_PlaySound;
      logic_uScriptAct_Delay_uScriptAct_Delay_84 = ScriptableObject.CreateInstance(typeof(uScriptAct_Delay)) as uScriptAct_Delay;
      logic_uScriptAct_Delay_uScriptAct_Delay_85 = ScriptableObject.CreateInstance(typeof(uScriptAct_Delay)) as uScriptAct_Delay;
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_86 = ScriptableObject.CreateInstance(typeof(uScriptAct_DestroyComponent)) as uScriptAct_DestroyComponent;
      logic_uScriptAct_Log_uScriptAct_Log_87 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_88 = ScriptableObject.CreateInstance(typeof(uScriptAct_DestroyComponent)) as uScriptAct_DestroyComponent;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_89 = ScriptableObject.CreateInstance(typeof(uScriptAct_Toggle)) as uScriptAct_Toggle;
      logic_uScriptAct_Log_uScriptAct_Log_90 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_91 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_92 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_93 = ScriptableObject.CreateInstance(typeof(uScriptAct_PlaySound)) as uScriptAct_PlaySound;
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_94 = ScriptableObject.CreateInstance(typeof(uScriptAct_OnInputEventFilter)) as uScriptAct_OnInputEventFilter;
      logic_uScriptAct_LookAt_uScriptAct_LookAt_95 = ScriptableObject.CreateInstance(typeof(uScriptAct_LookAt)) as uScriptAct_LookAt;
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96 = ScriptableObject.CreateInstance(typeof(uScriptAct_LookAt)) as uScriptAct_LookAt;
      logic_uScriptAct_Teleport_uScriptAct_Teleport_97 = ScriptableObject.CreateInstance(typeof(uScriptAct_Teleport)) as uScriptAct_Teleport;
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_98 = ScriptableObject.CreateInstance(typeof(uScriptCon_CompareBool)) as uScriptCon_CompareBool;
      logic_uScriptAct_Log_uScriptAct_Log_99 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_100 = ScriptableObject.CreateInstance(typeof(uScriptAct_Concatenate)) as uScriptAct_Concatenate;
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_101 = ScriptableObject.CreateInstance(typeof(uScriptAct_OnInputEventFilter)) as uScriptAct_OnInputEventFilter;
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_102 = ScriptableObject.CreateInstance(typeof(uScriptCon_IntCounter)) as uScriptCon_IntCounter;
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_103 = ScriptableObject.CreateInstance(typeof(uScriptCon_CompareBool)) as uScriptCon_CompareBool;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_104 = ScriptableObject.CreateInstance(typeof(uScriptAct_PlaySound)) as uScriptAct_PlaySound;
      
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_83.Finished += uScriptAct_PlaySound_Finished_83;
      logic_uScriptAct_Delay_uScriptAct_Delay_84.AfterDelay += uScriptAct_Delay_AfterDelay_84;
      logic_uScriptAct_Delay_uScriptAct_Delay_85.AfterDelay += uScriptAct_Delay_AfterDelay_85;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_89.OnOut += uScriptAct_Toggle_OnOut_89;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_89.OffOut += uScriptAct_Toggle_OffOut_89;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_89.ToggleOut += uScriptAct_Toggle_ToggleOut_89;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_93.Finished += uScriptAct_PlaySound_Finished_93;
      logic_uScriptAct_LookAt_uScriptAct_LookAt_95.Finished += uScriptAct_LookAt_Finished_95;
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.Finished += uScriptAct_LookAt_Finished_96;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_104.Finished += uScriptAct_PlaySound_Finished_104;
   }
   
   public void Update()
   {
      //reset each Update, and increments each method call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_83.Update( );
      logic_uScriptAct_Delay_uScriptAct_Delay_84.Update( );
      logic_uScriptAct_Delay_uScriptAct_Delay_85.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_93.Update( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_95.Update( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_104.Update( );
   }
   
   void Instance_KeyEvent_105(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_105( );
   }
   
   void Instance_KeyEvent_106(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_106( );
   }
   
   void uScriptAct_PlaySound_Finished_83(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_Finished_83( );
   }
   
   void uScriptAct_Delay_AfterDelay_84(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_AfterDelay_84( );
   }
   
   void uScriptAct_Delay_AfterDelay_85(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_AfterDelay_85( );
   }
   
   void uScriptAct_Toggle_OnOut_89(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_OnOut_89( );
   }
   
   void uScriptAct_Toggle_OffOut_89(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_OffOut_89( );
   }
   
   void uScriptAct_Toggle_ToggleOut_89(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_ToggleOut_89( );
   }
   
   void uScriptAct_PlaySound_Finished_93(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_Finished_93( );
   }
   
   void uScriptAct_LookAt_Finished_95(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_Finished_95( );
   }
   
   void uScriptAct_LookAt_Finished_96(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_Finished_96( );
   }
   
   void uScriptAct_PlaySound_Finished_104(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_Finished_104( );
   }
   
   void Relay_In_76()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_76.In(logic_uScriptAct_Log_Prefix_76, logic_uScriptAct_Log_Target_76, logic_uScriptAct_Log_Postfix_76);
         SyncUnityHooks( );
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_77()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            logic_uScriptCon_IntCounter_B_77 = local_4_System_Int32;
            
         }
         logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.In(logic_uScriptCon_IntCounter_A_77, logic_uScriptCon_IntCounter_B_77, out logic_uScriptCon_IntCounter_currentValue_77);
         SyncUnityHooks( );
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.GreaterThan == true )
         {
            Relay_In_82();
         }
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.GreaterThanOrEqualTo == true )
         {
            Relay_In_92();
         }
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.EqualTo == true )
         {
            Relay_In_78();
         }
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.LessThanOrEqualTo == true )
         {
            Relay_In_99();
         }
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.LessThan == true )
         {
            Relay_In_99();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Int Counter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_78()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_78.In(logic_uScriptAct_Log_Prefix_78, logic_uScriptAct_Log_Target_78, logic_uScriptAct_Log_Postfix_78);
         SyncUnityHooks( );
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_79()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_79.In(logic_uScriptAct_Log_Prefix_79, logic_uScriptAct_Log_Target_79, logic_uScriptAct_Log_Postfix_79);
         SyncUnityHooks( );
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_80()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            int index;
            index = 0;
            if ( logic_uScriptAct_Log_Target_80.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Log_Target_80, index + 1);
            }
            logic_uScriptAct_Log_Target_80[ index++ ] = local_Cover3_UnityEngine_GameObject;
            
         }
         logic_uScriptAct_Log_uScriptAct_Log_80.In(logic_uScriptAct_Log_Prefix_80, logic_uScriptAct_Log_Target_80, logic_uScriptAct_Log_Postfix_80);
         SyncUnityHooks( );
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_81()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            logic_uScriptCon_IntCounter_B_81 = local_37_System_Int32;
            
         }
         logic_uScriptCon_IntCounter_uScriptCon_IntCounter_81.In(logic_uScriptCon_IntCounter_A_81, logic_uScriptCon_IntCounter_B_81, out logic_uScriptCon_IntCounter_currentValue_81);
         SyncUnityHooks( );
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_81.GreaterThan == true )
         {
            Relay_In_90();
         }
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_81.GreaterThanOrEqualTo == true )
         {
            Relay_In_91();
         }
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_81.EqualTo == true )
         {
            Relay_In_76();
         }
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_81.LessThanOrEqualTo == true )
         {
            Relay_In_87();
         }
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_81.LessThan == true )
         {
            Relay_In_87();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Int Counter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_82()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_82.In(logic_uScriptAct_Log_Prefix_82, logic_uScriptAct_Log_Target_82, logic_uScriptAct_Log_Postfix_82);
         SyncUnityHooks( );
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_83()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Play_83()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_83.Play(logic_uScriptAct_PlaySound_audioClip_83, logic_uScriptAct_PlaySound_target_83, logic_uScriptAct_PlaySound_volume_83, logic_uScriptAct_PlaySound_loop_83);
         SyncUnityHooks( );
         if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_83.Out == true )
         {
            Relay_In_103();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_83()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_83.Stop(logic_uScriptAct_PlaySound_audioClip_83, logic_uScriptAct_PlaySound_target_83, logic_uScriptAct_PlaySound_volume_83, logic_uScriptAct_PlaySound_loop_83);
         SyncUnityHooks( );
         if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_83.Out == true )
         {
            Relay_In_103();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_AfterDelay_84()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         Relay_In_80();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_84()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            logic_uScriptAct_Delay_Duration_84 = local_19_System_Single;
            
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_84.In(logic_uScriptAct_Delay_Duration_84);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Delay_uScriptAct_Delay_84.Immediate == true )
         {
            Relay_In_79();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_AfterDelay_85()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_85()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_85.In(logic_uScriptAct_Delay_Duration_85);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Delay_uScriptAct_Delay_85.Immediate == true )
         {
            Relay_In_102();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_86()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            int index;
            index = 0;
            if ( logic_uScriptAct_DestroyComponent_Target_86.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_DestroyComponent_Target_86, index + 1);
            }
            logic_uScriptAct_DestroyComponent_Target_86[ index++ ] = local_Monster_UnityEngine_GameObject;
            
            index = 0;
            if ( logic_uScriptAct_DestroyComponent_ComponentName_86.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_DestroyComponent_ComponentName_86, index + 1);
            }
            logic_uScriptAct_DestroyComponent_ComponentName_86[ index++ ] = local_1_System_String;
            
         }
         logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_86.In(logic_uScriptAct_DestroyComponent_Target_86, logic_uScriptAct_DestroyComponent_ComponentName_86, logic_uScriptAct_DestroyComponent_DelayTime_86);
         SyncUnityHooks( );
         if ( logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_86.Out == true )
         {
            Relay_In_81();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Destroy Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_87()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_87.In(logic_uScriptAct_Log_Prefix_87, logic_uScriptAct_Log_Target_87, logic_uScriptAct_Log_Postfix_87);
         SyncUnityHooks( );
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_88()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            int index;
            index = 0;
            if ( logic_uScriptAct_DestroyComponent_Target_88.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_DestroyComponent_Target_88, index + 1);
            }
            logic_uScriptAct_DestroyComponent_Target_88[ index++ ] = local_Monster_UnityEngine_GameObject;
            
            index = 0;
            if ( logic_uScriptAct_DestroyComponent_ComponentName_88.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_DestroyComponent_ComponentName_88, index + 1);
            }
            logic_uScriptAct_DestroyComponent_ComponentName_88[ index++ ] = local_25_System_String;
            
         }
         logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_88.In(logic_uScriptAct_DestroyComponent_Target_88, logic_uScriptAct_DestroyComponent_ComponentName_88, logic_uScriptAct_DestroyComponent_DelayTime_88);
         SyncUnityHooks( );
         if ( logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_88.Out == true )
         {
            Relay_In_77();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Destroy Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnOut_89()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Toggle.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OffOut_89()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Toggle.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ToggleOut_89()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Toggle.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_TurnOn_89()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            int index;
            index = 0;
            if ( logic_uScriptAct_Toggle_Target_89.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Toggle_Target_89, index + 1);
            }
            logic_uScriptAct_Toggle_Target_89[ index++ ] = local_Cover1_UnityEngine_GameObject;
            
            if ( logic_uScriptAct_Toggle_Target_89.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Toggle_Target_89, index + 1);
            }
            logic_uScriptAct_Toggle_Target_89[ index++ ] = local_Cover2_UnityEngine_GameObject;
            
         }
         logic_uScriptAct_Toggle_uScriptAct_Toggle_89.TurnOn(logic_uScriptAct_Toggle_Target_89, logic_uScriptAct_Toggle_IgnoreChildren_89);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Toggle_uScriptAct_Toggle_89.Out == true )
         {
            Relay_In_84();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Toggle.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_TurnOff_89()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            int index;
            index = 0;
            if ( logic_uScriptAct_Toggle_Target_89.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Toggle_Target_89, index + 1);
            }
            logic_uScriptAct_Toggle_Target_89[ index++ ] = local_Cover1_UnityEngine_GameObject;
            
            if ( logic_uScriptAct_Toggle_Target_89.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Toggle_Target_89, index + 1);
            }
            logic_uScriptAct_Toggle_Target_89[ index++ ] = local_Cover2_UnityEngine_GameObject;
            
         }
         logic_uScriptAct_Toggle_uScriptAct_Toggle_89.TurnOff(logic_uScriptAct_Toggle_Target_89, logic_uScriptAct_Toggle_IgnoreChildren_89);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Toggle_uScriptAct_Toggle_89.Out == true )
         {
            Relay_In_84();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Toggle.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Toggle_89()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            int index;
            index = 0;
            if ( logic_uScriptAct_Toggle_Target_89.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Toggle_Target_89, index + 1);
            }
            logic_uScriptAct_Toggle_Target_89[ index++ ] = local_Cover1_UnityEngine_GameObject;
            
            if ( logic_uScriptAct_Toggle_Target_89.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Toggle_Target_89, index + 1);
            }
            logic_uScriptAct_Toggle_Target_89[ index++ ] = local_Cover2_UnityEngine_GameObject;
            
         }
         logic_uScriptAct_Toggle_uScriptAct_Toggle_89.Toggle(logic_uScriptAct_Toggle_Target_89, logic_uScriptAct_Toggle_IgnoreChildren_89);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Toggle_uScriptAct_Toggle_89.Out == true )
         {
            Relay_In_84();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Toggle.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_90()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_90.In(logic_uScriptAct_Log_Prefix_90, logic_uScriptAct_Log_Target_90, logic_uScriptAct_Log_Postfix_90);
         SyncUnityHooks( );
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_91()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_91.In(logic_uScriptAct_Log_Prefix_91, logic_uScriptAct_Log_Target_91, logic_uScriptAct_Log_Postfix_91);
         SyncUnityHooks( );
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_92()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_92.In(logic_uScriptAct_Log_Prefix_92, logic_uScriptAct_Log_Target_92, logic_uScriptAct_Log_Postfix_92);
         SyncUnityHooks( );
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_93()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Play_93()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_93.Play(logic_uScriptAct_PlaySound_audioClip_93, logic_uScriptAct_PlaySound_target_93, logic_uScriptAct_PlaySound_volume_93, logic_uScriptAct_PlaySound_loop_93);
         SyncUnityHooks( );
         if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_93.Out == true )
         {
            Relay_In_98();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_93()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_93.Stop(logic_uScriptAct_PlaySound_audioClip_93, logic_uScriptAct_PlaySound_target_93, logic_uScriptAct_PlaySound_volume_93, logic_uScriptAct_PlaySound_loop_93);
         SyncUnityHooks( );
         if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_93.Out == true )
         {
            Relay_In_98();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_94()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_94.In(logic_uScriptAct_OnInputEventFilter_KeyCode_94);
         SyncUnityHooks( );
         if ( logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_94.KeyDown == true )
         {
            Relay_Play_83();
         }
         if ( logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_94.KeyUp == true )
         {
            Relay_In_88();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_95()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Look At.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_95()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            int index;
            index = 0;
            if ( logic_uScriptAct_LookAt_Target_95.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_95, index + 1);
            }
            logic_uScriptAct_LookAt_Target_95[ index++ ] = local_58_UnityEngine_GameObject;
            
            if ( logic_uScriptAct_LookAt_Target_95.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_95, index + 1);
            }
            logic_uScriptAct_LookAt_Target_95[ index++ ] = local_56_UnityEngine_GameObject;
            
            if ( logic_uScriptAct_LookAt_Target_95.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_95, index + 1);
            }
            logic_uScriptAct_LookAt_Target_95[ index++ ] = local_33_UnityEngine_GameObject;
            
            if ( logic_uScriptAct_LookAt_Target_95.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_95, index + 1);
            }
            logic_uScriptAct_LookAt_Target_95[ index++ ] = local_65_UnityEngine_GameObject;
            
            if ( logic_uScriptAct_LookAt_Target_95.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_95, index + 1);
            }
            logic_uScriptAct_LookAt_Target_95[ index++ ] = local_20_UnityEngine_GameObject;
            
         }
         logic_uScriptAct_LookAt_uScriptAct_LookAt_95.In(logic_uScriptAct_LookAt_Target_95, logic_uScriptAct_LookAt_Focus_95, logic_uScriptAct_LookAt_time_95);
         SyncUnityHooks( );
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Look At.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_96()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Look At.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_96()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            int index;
            index = 0;
            if ( logic_uScriptAct_LookAt_Target_96.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_96, index + 1);
            }
            logic_uScriptAct_LookAt_Target_96[ index++ ] = local_26_UnityEngine_GameObject;
            
            if ( logic_uScriptAct_LookAt_Target_96.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_96, index + 1);
            }
            logic_uScriptAct_LookAt_Target_96[ index++ ] = local_47_UnityEngine_GameObject;
            
            if ( logic_uScriptAct_LookAt_Target_96.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_96, index + 1);
            }
            logic_uScriptAct_LookAt_Target_96[ index++ ] = local_0_UnityEngine_GameObject;
            
            if ( logic_uScriptAct_LookAt_Target_96.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_96, index + 1);
            }
            logic_uScriptAct_LookAt_Target_96[ index++ ] = local_13_UnityEngine_GameObject;
            
            if ( logic_uScriptAct_LookAt_Target_96.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_96, index + 1);
            }
            logic_uScriptAct_LookAt_Target_96[ index++ ] = local_5_UnityEngine_GameObject;
            
         }
         logic_uScriptAct_LookAt_uScriptAct_LookAt_96.In(logic_uScriptAct_LookAt_Target_96, logic_uScriptAct_LookAt_Focus_96, logic_uScriptAct_LookAt_time_96);
         SyncUnityHooks( );
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Look At.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_105()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         Relay_In_94();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Input Events.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_97()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            int index;
            index = 0;
            if ( logic_uScriptAct_Teleport_Target_97.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Teleport_Target_97, index + 1);
            }
            logic_uScriptAct_Teleport_Target_97[ index++ ] = local_40_UnityEngine_GameObject;
            
         }
         logic_uScriptAct_Teleport_uScriptAct_Teleport_97.In(logic_uScriptAct_Teleport_Target_97, logic_uScriptAct_Teleport_Destination_97, logic_uScriptAct_Teleport_UpdateRotation_97);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Teleport_uScriptAct_Teleport_97.Out == true )
         {
            Relay_In_79();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Teleport.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_98()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            logic_uScriptCon_CompareBool_Bool_98 = local_16_System_Boolean;
            
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_98.In(logic_uScriptCon_CompareBool_Bool_98);
         SyncUnityHooks( );
         if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_98.False == true )
         {
            Relay_In_96();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_99()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_99.In(logic_uScriptAct_Log_Prefix_99, logic_uScriptAct_Log_Target_99, logic_uScriptAct_Log_Postfix_99);
         SyncUnityHooks( );
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_106()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         Relay_In_101();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Input Events.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_100()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            int index;
            index = 0;
            if ( logic_uScriptAct_Concatenate_A_100.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Concatenate_A_100, index + 1);
            }
            logic_uScriptAct_Concatenate_A_100[ index++ ] = local_71_System_String;
            
            index = 0;
            if ( logic_uScriptAct_Concatenate_B_100.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Concatenate_B_100, index + 1);
            }
            logic_uScriptAct_Concatenate_B_100[ index++ ] = local_7_System_Int32;
            
         }
         logic_uScriptAct_Concatenate_uScriptAct_Concatenate_100.In(logic_uScriptAct_Concatenate_A_100, logic_uScriptAct_Concatenate_B_100, logic_uScriptAct_Concatenate_Separator_100, out logic_uScriptAct_Concatenate_Result_100);
         local_54_System_String = logic_uScriptAct_Concatenate_Result_100;
         SyncUnityHooks( );
         if ( logic_uScriptAct_Concatenate_uScriptAct_Concatenate_100.Out == true )
         {
            Relay_In_97();
            Relay_Play_104();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Concatenate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_101()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_101.In(logic_uScriptAct_OnInputEventFilter_KeyCode_101);
         SyncUnityHooks( );
         if ( logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_101.KeyDown == true )
         {
            Relay_In_86();
         }
         if ( logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_101.KeyUp == true )
         {
            Relay_Play_93();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_102()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            logic_uScriptCon_IntCounter_A_102 = local_68_System_Int32;
            
            logic_uScriptCon_IntCounter_B_102 = local_39_System_Int32;
            
         }
         logic_uScriptCon_IntCounter_uScriptCon_IntCounter_102.In(logic_uScriptCon_IntCounter_A_102, logic_uScriptCon_IntCounter_B_102, out logic_uScriptCon_IntCounter_currentValue_102);
         local_7_System_Int32 = logic_uScriptCon_IntCounter_currentValue_102;
         SyncUnityHooks( );
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_102.GreaterThanOrEqualTo == true )
         {
            Relay_In_100();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Int Counter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_103()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            logic_uScriptCon_CompareBool_Bool_103 = local_12_System_Boolean;
            
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_103.In(logic_uScriptCon_CompareBool_Bool_103);
         SyncUnityHooks( );
         if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_103.False == true )
         {
            Relay_In_95();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_104()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Play_104()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_104.Play(logic_uScriptAct_PlaySound_audioClip_104, logic_uScriptAct_PlaySound_target_104, logic_uScriptAct_PlaySound_volume_104, logic_uScriptAct_PlaySound_loop_104);
         SyncUnityHooks( );
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_104()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_104.Stop(logic_uScriptAct_PlaySound_audioClip_104, logic_uScriptAct_PlaySound_target_104, logic_uScriptAct_PlaySound_volume_104, logic_uScriptAct_PlaySound_loop_104);
         SyncUnityHooks( );
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
}
