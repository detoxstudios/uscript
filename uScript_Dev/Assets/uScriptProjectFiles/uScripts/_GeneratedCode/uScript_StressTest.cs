//uScript Generated Code - Build 0.9.0997
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
   System.Int32 local_2_System_Int32 = (int) 0;
   UnityEngine.GameObject local_3_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_3_UnityEngine_GameObject_previous = null;
   System.Int32 local_5_System_Int32 = (int) 0;
   System.Boolean local_10_System_Boolean = (bool) false;
   UnityEngine.GameObject local_11_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_11_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Cover3_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Cover3_UnityEngine_GameObject_previous = null;
   System.Boolean local_14_System_Boolean = (bool) false;
   System.Single local_17_System_Single = (float) 3;
   UnityEngine.GameObject local_18_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_18_UnityEngine_GameObject_previous = null;
   System.String local_23_System_String = "Area Damage";
   UnityEngine.GameObject local_31_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_31_UnityEngine_GameObject_previous = null;
   System.Int32 local_35_System_Int32 = (int) 0;
   System.Int32 local_37_System_Int32 = (int) 0;
   UnityEngine.GameObject local_38_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_38_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Cover1_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Cover1_UnityEngine_GameObject_previous = null;
   System.String local_40_System_String = "Ogre";
   UnityEngine.GameObject local_45_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_45_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Cover2_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Cover2_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_48_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_48_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Monster_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Monster_UnityEngine_GameObject_previous = null;
   System.String local_53_System_String = "";
   UnityEngine.GameObject local_55_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_55_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_57_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_57_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_65_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_65_UnityEngine_GameObject_previous = null;
   System.Int32 local_70_System_Int32 = (int) 0;
   
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
   System.String logic_uScriptAct_Log_Prefix_80 = "";
   System.Object[] logic_uScriptAct_Log_Target_80 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_80 = "";
   bool logic_uScriptAct_Log_Out_80 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_81 = null;
   System.String logic_uScriptAct_Log_Prefix_81 = "Trigger Fired!";
   System.Object[] logic_uScriptAct_Log_Target_81 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_81 = "";
   bool logic_uScriptAct_Log_Out_81 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82 = null;
   System.Int32 logic_uScriptCon_IntCounter_A_82 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_B_82 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_82;
   bool logic_uScriptCon_IntCounter_GreaterThan_82 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_82 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_82 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_82 = true;
   bool logic_uScriptCon_IntCounter_LessThan_82 = true;
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
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_90 = null;
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_90 = null;
   UnityEngine.GameObject[] logic_uScriptAct_PlaySound_target_90 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_PlaySound_volume_90 = (float) 0;
   System.Boolean logic_uScriptAct_PlaySound_loop_90 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_90 = true;
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
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_93 = null;
   System.String logic_uScriptAct_Log_Prefix_93 = "";
   System.Object[] logic_uScriptAct_Log_Target_93 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_93 = "";
   bool logic_uScriptAct_Log_Out_93 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_94 = null;
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_94 = null;
   UnityEngine.GameObject[] logic_uScriptAct_PlaySound_target_94 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_PlaySound_volume_94 = (float) 0;
   System.Boolean logic_uScriptAct_PlaySound_loop_94 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_94 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_95 = null;
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_95 = UnityEngine.KeyCode.None;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_95 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_95 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_95 = true;
   //pointer to script instanced logic node
   uScriptAct_LookAt logic_uScriptAct_LookAt_uScriptAct_LookAt_96 = null;
   UnityEngine.GameObject[] logic_uScriptAct_LookAt_Target_96 = new UnityEngine.GameObject[] {};
   System.Object logic_uScriptAct_LookAt_Focus_96 = "";
   System.Single logic_uScriptAct_LookAt_time_96 = (float) 0;
   bool logic_uScriptAct_LookAt_Out_96 = true;
   //pointer to script instanced logic node
   uScriptAct_LookAt logic_uScriptAct_LookAt_uScriptAct_LookAt_97 = null;
   UnityEngine.GameObject[] logic_uScriptAct_LookAt_Target_97 = new UnityEngine.GameObject[] {};
   System.Object logic_uScriptAct_LookAt_Focus_97 = "";
   System.Single logic_uScriptAct_LookAt_time_97 = (float) 0;
   bool logic_uScriptAct_LookAt_Out_97 = true;
   //pointer to script instanced logic node
   uScriptAct_Teleport logic_uScriptAct_Teleport_uScriptAct_Teleport_98 = null;
   UnityEngine.GameObject[] logic_uScriptAct_Teleport_Target_98 = new UnityEngine.GameObject[] {};
   UnityEngine.GameObject logic_uScriptAct_Teleport_Destination_98 = null;
   System.Boolean logic_uScriptAct_Teleport_UpdateRotation_98 = (bool) false;
   bool logic_uScriptAct_Teleport_Out_98 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_99 = null;
   System.Boolean logic_uScriptCon_CompareBool_Bool_99 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_99 = true;
   bool logic_uScriptCon_CompareBool_False_99 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_100 = null;
   System.String logic_uScriptAct_Log_Prefix_100 = "";
   System.Object[] logic_uScriptAct_Log_Target_100 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_100 = "";
   bool logic_uScriptAct_Log_Out_100 = true;
   //pointer to script instanced logic node
   uScriptAct_Concatenate logic_uScriptAct_Concatenate_uScriptAct_Concatenate_101 = null;
   System.Object[] logic_uScriptAct_Concatenate_A_101 = new System.Object[] {""};
   System.Object[] logic_uScriptAct_Concatenate_B_101 = new System.Object[] {""};
   System.String logic_uScriptAct_Concatenate_Separator_101 = "";
   System.String logic_uScriptAct_Concatenate_Result_101;
   bool logic_uScriptAct_Concatenate_Out_101 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_102 = null;
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_102 = UnityEngine.KeyCode.None;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_102 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_102 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_102 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_103 = null;
   System.Int32 logic_uScriptCon_IntCounter_A_103 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_B_103 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_103;
   bool logic_uScriptCon_IntCounter_GreaterThan_103 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_103 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_103 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_103 = true;
   bool logic_uScriptCon_IntCounter_LessThan_103 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_104 = null;
   System.Boolean logic_uScriptCon_CompareBool_Bool_104 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_104 = true;
   bool logic_uScriptCon_CompareBool_False_104 = true;
   
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
         if ( null != local_0_UnityEngine_GameObject_previous )
         {
         }
         
         local_0_UnityEngine_GameObject_previous = local_0_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_0_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_3_UnityEngine_GameObject_previous != local_3_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_3_UnityEngine_GameObject_previous )
         {
         }
         
         local_3_UnityEngine_GameObject_previous = local_3_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_3_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_11_UnityEngine_GameObject_previous != local_11_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_11_UnityEngine_GameObject_previous )
         {
         }
         
         local_11_UnityEngine_GameObject_previous = local_11_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_11_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_Cover3_UnityEngine_GameObject_previous != local_Cover3_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_Cover3_UnityEngine_GameObject_previous )
         {
         }
         
         local_Cover3_UnityEngine_GameObject_previous = local_Cover3_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_Cover3_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_18_UnityEngine_GameObject_previous != local_18_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_18_UnityEngine_GameObject_previous )
         {
         }
         
         local_18_UnityEngine_GameObject_previous = local_18_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_18_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_31_UnityEngine_GameObject_previous != local_31_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_31_UnityEngine_GameObject_previous )
         {
         }
         
         local_31_UnityEngine_GameObject_previous = local_31_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_31_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_38_UnityEngine_GameObject_previous != local_38_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_38_UnityEngine_GameObject_previous )
         {
         }
         
         local_38_UnityEngine_GameObject_previous = local_38_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_38_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_Cover1_UnityEngine_GameObject_previous != local_Cover1_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_Cover1_UnityEngine_GameObject_previous )
         {
         }
         
         local_Cover1_UnityEngine_GameObject_previous = local_Cover1_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_Cover1_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_45_UnityEngine_GameObject_previous != local_45_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_45_UnityEngine_GameObject_previous )
         {
         }
         
         local_45_UnityEngine_GameObject_previous = local_45_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_45_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_Cover2_UnityEngine_GameObject_previous != local_Cover2_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_Cover2_UnityEngine_GameObject_previous )
         {
         }
         
         local_Cover2_UnityEngine_GameObject_previous = local_Cover2_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_Cover2_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_48_UnityEngine_GameObject_previous != local_48_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_48_UnityEngine_GameObject_previous )
         {
         }
         
         local_48_UnityEngine_GameObject_previous = local_48_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_48_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_Monster_UnityEngine_GameObject_previous != local_Monster_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_Monster_UnityEngine_GameObject_previous )
         {
         }
         
         local_Monster_UnityEngine_GameObject_previous = local_Monster_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_Monster_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_55_UnityEngine_GameObject_previous != local_55_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_55_UnityEngine_GameObject_previous )
         {
         }
         
         local_55_UnityEngine_GameObject_previous = local_55_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_55_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_57_UnityEngine_GameObject_previous != local_57_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_57_UnityEngine_GameObject_previous )
         {
         }
         
         local_57_UnityEngine_GameObject_previous = local_57_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_57_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_65_UnityEngine_GameObject_previous != local_65_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_65_UnityEngine_GameObject_previous )
         {
         }
         
         local_65_UnityEngine_GameObject_previous = local_65_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_65_UnityEngine_GameObject )
         {
         }
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
      logic_uScriptAct_Log_uScriptAct_Log_81.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_83.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_84.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_85.SetParent(g);
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_86.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_87.SetParent(g);
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_88.SetParent(g);
      logic_uScriptAct_Toggle_uScriptAct_Toggle_89.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_90.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_91.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_92.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_93.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_94.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_95.SetParent(g);
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.SetParent(g);
      logic_uScriptAct_LookAt_uScriptAct_LookAt_97.SetParent(g);
      logic_uScriptAct_Teleport_uScriptAct_Teleport_98.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_99.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_100.SetParent(g);
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_101.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_102.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_103.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_104.SetParent(g);
   }
   public void Awake()
   {
      logic_uScriptAct_Log_uScriptAct_Log_76 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77 = ScriptableObject.CreateInstance(typeof(uScriptCon_IntCounter)) as uScriptCon_IntCounter;
      logic_uScriptAct_Log_uScriptAct_Log_78 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_79 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_80 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_81 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82 = ScriptableObject.CreateInstance(typeof(uScriptCon_IntCounter)) as uScriptCon_IntCounter;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_83 = ScriptableObject.CreateInstance(typeof(uScriptAct_PlaySound)) as uScriptAct_PlaySound;
      logic_uScriptAct_Delay_uScriptAct_Delay_84 = ScriptableObject.CreateInstance(typeof(uScriptAct_Delay)) as uScriptAct_Delay;
      logic_uScriptAct_Delay_uScriptAct_Delay_85 = ScriptableObject.CreateInstance(typeof(uScriptAct_Delay)) as uScriptAct_Delay;
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_86 = ScriptableObject.CreateInstance(typeof(uScriptAct_DestroyComponent)) as uScriptAct_DestroyComponent;
      logic_uScriptAct_Log_uScriptAct_Log_87 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_88 = ScriptableObject.CreateInstance(typeof(uScriptAct_DestroyComponent)) as uScriptAct_DestroyComponent;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_89 = ScriptableObject.CreateInstance(typeof(uScriptAct_Toggle)) as uScriptAct_Toggle;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_90 = ScriptableObject.CreateInstance(typeof(uScriptAct_PlaySound)) as uScriptAct_PlaySound;
      logic_uScriptAct_Log_uScriptAct_Log_91 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_92 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_93 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_94 = ScriptableObject.CreateInstance(typeof(uScriptAct_PlaySound)) as uScriptAct_PlaySound;
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_95 = ScriptableObject.CreateInstance(typeof(uScriptAct_OnInputEventFilter)) as uScriptAct_OnInputEventFilter;
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96 = ScriptableObject.CreateInstance(typeof(uScriptAct_LookAt)) as uScriptAct_LookAt;
      logic_uScriptAct_LookAt_uScriptAct_LookAt_97 = ScriptableObject.CreateInstance(typeof(uScriptAct_LookAt)) as uScriptAct_LookAt;
      logic_uScriptAct_Teleport_uScriptAct_Teleport_98 = ScriptableObject.CreateInstance(typeof(uScriptAct_Teleport)) as uScriptAct_Teleport;
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_99 = ScriptableObject.CreateInstance(typeof(uScriptCon_CompareBool)) as uScriptCon_CompareBool;
      logic_uScriptAct_Log_uScriptAct_Log_100 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_101 = ScriptableObject.CreateInstance(typeof(uScriptAct_Concatenate)) as uScriptAct_Concatenate;
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_102 = ScriptableObject.CreateInstance(typeof(uScriptAct_OnInputEventFilter)) as uScriptAct_OnInputEventFilter;
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_103 = ScriptableObject.CreateInstance(typeof(uScriptCon_IntCounter)) as uScriptCon_IntCounter;
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_104 = ScriptableObject.CreateInstance(typeof(uScriptCon_CompareBool)) as uScriptCon_CompareBool;
      
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_83.Finished += uScriptAct_PlaySound_Finished_83;
      logic_uScriptAct_Delay_uScriptAct_Delay_84.AfterDelay += uScriptAct_Delay_AfterDelay_84;
      logic_uScriptAct_Delay_uScriptAct_Delay_85.AfterDelay += uScriptAct_Delay_AfterDelay_85;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_89.OnOut += uScriptAct_Toggle_OnOut_89;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_89.OffOut += uScriptAct_Toggle_OffOut_89;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_89.ToggleOut += uScriptAct_Toggle_ToggleOut_89;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_90.Finished += uScriptAct_PlaySound_Finished_90;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_94.Finished += uScriptAct_PlaySound_Finished_94;
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.Finished += uScriptAct_LookAt_Finished_96;
      logic_uScriptAct_LookAt_uScriptAct_LookAt_97.Finished += uScriptAct_LookAt_Finished_97;
   }
   
   public override void Start()
   {
      
      SyncUnityHooks( );
      
      logic_uScriptAct_Log_uScriptAct_Log_76.Start( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.Start( );
      logic_uScriptAct_Log_uScriptAct_Log_78.Start( );
      logic_uScriptAct_Log_uScriptAct_Log_79.Start( );
      logic_uScriptAct_Log_uScriptAct_Log_80.Start( );
      logic_uScriptAct_Log_uScriptAct_Log_81.Start( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.Start( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_83.Start( );
      logic_uScriptAct_Delay_uScriptAct_Delay_84.Start( );
      logic_uScriptAct_Delay_uScriptAct_Delay_85.Start( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_86.Start( );
      logic_uScriptAct_Log_uScriptAct_Log_87.Start( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_88.Start( );
      logic_uScriptAct_Toggle_uScriptAct_Toggle_89.Start( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_90.Start( );
      logic_uScriptAct_Log_uScriptAct_Log_91.Start( );
      logic_uScriptAct_Log_uScriptAct_Log_92.Start( );
      logic_uScriptAct_Log_uScriptAct_Log_93.Start( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_94.Start( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_95.Start( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.Start( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_97.Start( );
      logic_uScriptAct_Teleport_uScriptAct_Teleport_98.Start( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_99.Start( );
      logic_uScriptAct_Log_uScriptAct_Log_100.Start( );
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_101.Start( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_102.Start( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_103.Start( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_104.Start( );
   }
   
   public override void Update()
   {
      //reset each Update, and increments each method call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      logic_uScriptAct_Log_uScriptAct_Log_76.Update( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_78.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_79.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_80.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_81.Update( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_83.Update( );
      logic_uScriptAct_Delay_uScriptAct_Delay_84.Update( );
      logic_uScriptAct_Delay_uScriptAct_Delay_85.Update( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_86.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_87.Update( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_88.Update( );
      logic_uScriptAct_Toggle_uScriptAct_Toggle_89.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_90.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_91.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_92.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_93.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_94.Update( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_95.Update( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.Update( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_97.Update( );
      logic_uScriptAct_Teleport_uScriptAct_Teleport_98.Update( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_99.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_100.Update( );
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_101.Update( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_102.Update( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_103.Update( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_104.Update( );
   }
   
   public override void LateUpdate()
   {
      logic_uScriptAct_Log_uScriptAct_Log_76.LateUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_78.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_79.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_80.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_81.LateUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.LateUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_83.LateUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_84.LateUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_85.LateUpdate( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_86.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_87.LateUpdate( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_88.LateUpdate( );
      logic_uScriptAct_Toggle_uScriptAct_Toggle_89.LateUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_90.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_91.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_92.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_93.LateUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_94.LateUpdate( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_95.LateUpdate( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.LateUpdate( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_97.LateUpdate( );
      logic_uScriptAct_Teleport_uScriptAct_Teleport_98.LateUpdate( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_99.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_100.LateUpdate( );
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_101.LateUpdate( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_102.LateUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_103.LateUpdate( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_104.LateUpdate( );
   }
   
   public override void FixedUpdate()
   {
      logic_uScriptAct_Log_uScriptAct_Log_76.FixedUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_78.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_79.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_80.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_81.FixedUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.FixedUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_83.FixedUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_84.FixedUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_85.FixedUpdate( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_86.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_87.FixedUpdate( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_88.FixedUpdate( );
      logic_uScriptAct_Toggle_uScriptAct_Toggle_89.FixedUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_90.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_91.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_92.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_93.FixedUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_94.FixedUpdate( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_95.FixedUpdate( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.FixedUpdate( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_97.FixedUpdate( );
      logic_uScriptAct_Teleport_uScriptAct_Teleport_98.FixedUpdate( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_99.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_100.FixedUpdate( );
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_101.FixedUpdate( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_102.FixedUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_103.FixedUpdate( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_104.FixedUpdate( );
   }
   
   public override void OnGUI()
   {
      logic_uScriptAct_Log_uScriptAct_Log_76.OnGUI( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_78.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_79.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_80.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_81.OnGUI( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.OnGUI( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_83.OnGUI( );
      logic_uScriptAct_Delay_uScriptAct_Delay_84.OnGUI( );
      logic_uScriptAct_Delay_uScriptAct_Delay_85.OnGUI( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_86.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_87.OnGUI( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_88.OnGUI( );
      logic_uScriptAct_Toggle_uScriptAct_Toggle_89.OnGUI( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_90.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_91.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_92.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_93.OnGUI( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_94.OnGUI( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_95.OnGUI( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.OnGUI( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_97.OnGUI( );
      logic_uScriptAct_Teleport_uScriptAct_Teleport_98.OnGUI( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_99.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_100.OnGUI( );
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_101.OnGUI( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_102.OnGUI( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_103.OnGUI( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_104.OnGUI( );
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
   
   void uScriptAct_PlaySound_Finished_90(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_Finished_90( );
   }
   
   void uScriptAct_PlaySound_Finished_94(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_Finished_94( );
   }
   
   void uScriptAct_LookAt_Finished_96(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_Finished_96( );
   }
   
   void uScriptAct_LookAt_Finished_97(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_Finished_97( );
   }
   
   void Relay_In_76()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_Log_uScriptAct_Log_76.In(logic_uScriptAct_Log_Prefix_76, logic_uScriptAct_Log_Target_76, logic_uScriptAct_Log_Postfix_76);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Log_uScriptAct_Log_76.Out == true )
         {
         }
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
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            logic_uScriptCon_IntCounter_B_77 = local_2_System_Int32;
            index = 0;
            properties = null;
         }
         logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.In(logic_uScriptCon_IntCounter_A_77, logic_uScriptCon_IntCounter_B_77, out logic_uScriptCon_IntCounter_currentValue_77);
         SyncUnityHooks( );
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.GreaterThan == true )
         {
            Relay_In_80();
         }
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.GreaterThanOrEqualTo == true )
         {
            Relay_In_93();
         }
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.EqualTo == true )
         {
            Relay_In_78();
         }
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.LessThanOrEqualTo == true )
         {
            Relay_In_100();
         }
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.LessThan == true )
         {
            Relay_In_100();
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
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_Log_uScriptAct_Log_78.In(logic_uScriptAct_Log_Prefix_78, logic_uScriptAct_Log_Target_78, logic_uScriptAct_Log_Postfix_78);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Log_uScriptAct_Log_78.Out == true )
         {
         }
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
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_Log_uScriptAct_Log_79.In(logic_uScriptAct_Log_Prefix_79, logic_uScriptAct_Log_Target_79, logic_uScriptAct_Log_Postfix_79);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Log_uScriptAct_Log_79.Out == true )
         {
         }
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
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_Log_uScriptAct_Log_80.In(logic_uScriptAct_Log_Prefix_80, logic_uScriptAct_Log_Target_80, logic_uScriptAct_Log_Postfix_80);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Log_uScriptAct_Log_80.Out == true )
         {
         }
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
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            if ( logic_uScriptAct_Log_Target_81.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Log_Target_81, index + 1);
            }
            logic_uScriptAct_Log_Target_81[ index++ ] = local_Cover3_UnityEngine_GameObject;
            
            index = 0;
            properties = null;
         }
         logic_uScriptAct_Log_uScriptAct_Log_81.In(logic_uScriptAct_Log_Prefix_81, logic_uScriptAct_Log_Target_81, logic_uScriptAct_Log_Postfix_81);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Log_uScriptAct_Log_81.Out == true )
         {
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_82()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            logic_uScriptCon_IntCounter_B_82 = local_35_System_Int32;
            index = 0;
            properties = null;
         }
         logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.In(logic_uScriptCon_IntCounter_A_82, logic_uScriptCon_IntCounter_B_82, out logic_uScriptCon_IntCounter_currentValue_82);
         SyncUnityHooks( );
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.GreaterThan == true )
         {
            Relay_In_91();
         }
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.GreaterThanOrEqualTo == true )
         {
            Relay_In_92();
         }
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.EqualTo == true )
         {
            Relay_In_76();
         }
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.LessThanOrEqualTo == true )
         {
            Relay_In_87();
         }
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.LessThan == true )
         {
            Relay_In_87();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Int Counter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
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
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_83.Play(logic_uScriptAct_PlaySound_audioClip_83, logic_uScriptAct_PlaySound_target_83, logic_uScriptAct_PlaySound_volume_83, logic_uScriptAct_PlaySound_loop_83);
         SyncUnityHooks( );
         if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_83.Out == true )
         {
            Relay_In_104();
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
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_83.Stop(logic_uScriptAct_PlaySound_audioClip_83, logic_uScriptAct_PlaySound_target_83, logic_uScriptAct_PlaySound_volume_83, logic_uScriptAct_PlaySound_loop_83);
         SyncUnityHooks( );
         if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_83.Out == true )
         {
            Relay_In_104();
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
         Relay_In_81();
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
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            logic_uScriptAct_Delay_Duration_84 = local_17_System_Single;
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
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_85.In(logic_uScriptAct_Delay_Duration_85);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Delay_uScriptAct_Delay_85.Immediate == true )
         {
            Relay_In_103();
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
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            if ( logic_uScriptAct_DestroyComponent_Target_86.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_DestroyComponent_Target_86, index + 1);
            }
            logic_uScriptAct_DestroyComponent_Target_86[ index++ ] = local_Monster_UnityEngine_GameObject;
            
            index = 0;
            properties = null;
            if ( logic_uScriptAct_DestroyComponent_ComponentName_86.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_DestroyComponent_ComponentName_86, index + 1);
            }
            logic_uScriptAct_DestroyComponent_ComponentName_86[ index++ ] = local_1_System_String;
            
            index = 0;
            properties = null;
         }
         logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_86.In(logic_uScriptAct_DestroyComponent_Target_86, logic_uScriptAct_DestroyComponent_ComponentName_86, logic_uScriptAct_DestroyComponent_DelayTime_86);
         SyncUnityHooks( );
         if ( logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_86.Out == true )
         {
            Relay_In_82();
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
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_Log_uScriptAct_Log_87.In(logic_uScriptAct_Log_Prefix_87, logic_uScriptAct_Log_Target_87, logic_uScriptAct_Log_Postfix_87);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Log_uScriptAct_Log_87.Out == true )
         {
         }
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
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            if ( logic_uScriptAct_DestroyComponent_Target_88.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_DestroyComponent_Target_88, index + 1);
            }
            logic_uScriptAct_DestroyComponent_Target_88[ index++ ] = local_Monster_UnityEngine_GameObject;
            
            index = 0;
            properties = null;
            if ( logic_uScriptAct_DestroyComponent_ComponentName_88.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_DestroyComponent_ComponentName_88, index + 1);
            }
            logic_uScriptAct_DestroyComponent_ComponentName_88[ index++ ] = local_23_System_String;
            
            index = 0;
            properties = null;
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
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
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
            
            index = 0;
            properties = null;
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
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
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
            
            index = 0;
            properties = null;
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
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
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
            
            index = 0;
            properties = null;
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
   
   void Relay_Finished_90()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Play_90()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_90.Play(logic_uScriptAct_PlaySound_audioClip_90, logic_uScriptAct_PlaySound_target_90, logic_uScriptAct_PlaySound_volume_90, logic_uScriptAct_PlaySound_loop_90);
         SyncUnityHooks( );
         if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_90.Out == true )
         {
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_90()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_90.Stop(logic_uScriptAct_PlaySound_audioClip_90, logic_uScriptAct_PlaySound_target_90, logic_uScriptAct_PlaySound_volume_90, logic_uScriptAct_PlaySound_loop_90);
         SyncUnityHooks( );
         if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_90.Out == true )
         {
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_91()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_Log_uScriptAct_Log_91.In(logic_uScriptAct_Log_Prefix_91, logic_uScriptAct_Log_Target_91, logic_uScriptAct_Log_Postfix_91);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Log_uScriptAct_Log_91.Out == true )
         {
         }
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
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_Log_uScriptAct_Log_92.In(logic_uScriptAct_Log_Prefix_92, logic_uScriptAct_Log_Target_92, logic_uScriptAct_Log_Postfix_92);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Log_uScriptAct_Log_92.Out == true )
         {
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_93()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_Log_uScriptAct_Log_93.In(logic_uScriptAct_Log_Prefix_93, logic_uScriptAct_Log_Target_93, logic_uScriptAct_Log_Postfix_93);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Log_uScriptAct_Log_93.Out == true )
         {
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_94()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Play_94()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_94.Play(logic_uScriptAct_PlaySound_audioClip_94, logic_uScriptAct_PlaySound_target_94, logic_uScriptAct_PlaySound_volume_94, logic_uScriptAct_PlaySound_loop_94);
         SyncUnityHooks( );
         if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_94.Out == true )
         {
            Relay_In_99();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_94()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_94.Stop(logic_uScriptAct_PlaySound_audioClip_94, logic_uScriptAct_PlaySound_target_94, logic_uScriptAct_PlaySound_volume_94, logic_uScriptAct_PlaySound_loop_94);
         SyncUnityHooks( );
         if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_94.Out == true )
         {
            Relay_In_99();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_95()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_95.In(logic_uScriptAct_OnInputEventFilter_KeyCode_95);
         SyncUnityHooks( );
         if ( logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_95.KeyHeld == true )
         {
         }
         if ( logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_95.KeyDown == true )
         {
            Relay_Play_83();
         }
         if ( logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_95.KeyUp == true )
         {
            Relay_In_88();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
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
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            if ( logic_uScriptAct_LookAt_Target_96.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_96, index + 1);
            }
            logic_uScriptAct_LookAt_Target_96[ index++ ] = local_48_UnityEngine_GameObject;
            
            if ( logic_uScriptAct_LookAt_Target_96.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_96, index + 1);
            }
            logic_uScriptAct_LookAt_Target_96[ index++ ] = local_55_UnityEngine_GameObject;
            
            if ( logic_uScriptAct_LookAt_Target_96.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_96, index + 1);
            }
            logic_uScriptAct_LookAt_Target_96[ index++ ] = local_65_UnityEngine_GameObject;
            
            if ( logic_uScriptAct_LookAt_Target_96.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_96, index + 1);
            }
            logic_uScriptAct_LookAt_Target_96[ index++ ] = local_31_UnityEngine_GameObject;
            
            if ( logic_uScriptAct_LookAt_Target_96.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_96, index + 1);
            }
            logic_uScriptAct_LookAt_Target_96[ index++ ] = local_18_UnityEngine_GameObject;
            
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_LookAt_uScriptAct_LookAt_96.In(logic_uScriptAct_LookAt_Target_96, logic_uScriptAct_LookAt_Focus_96, logic_uScriptAct_LookAt_time_96);
         SyncUnityHooks( );
         if ( logic_uScriptAct_LookAt_uScriptAct_LookAt_96.Out == true )
         {
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Look At.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_97()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Look At.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_97()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            if ( logic_uScriptAct_LookAt_Target_97.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_97, index + 1);
            }
            logic_uScriptAct_LookAt_Target_97[ index++ ] = local_45_UnityEngine_GameObject;
            
            if ( logic_uScriptAct_LookAt_Target_97.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_97, index + 1);
            }
            logic_uScriptAct_LookAt_Target_97[ index++ ] = local_57_UnityEngine_GameObject;
            
            if ( logic_uScriptAct_LookAt_Target_97.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_97, index + 1);
            }
            logic_uScriptAct_LookAt_Target_97[ index++ ] = local_0_UnityEngine_GameObject;
            
            if ( logic_uScriptAct_LookAt_Target_97.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_97, index + 1);
            }
            logic_uScriptAct_LookAt_Target_97[ index++ ] = local_11_UnityEngine_GameObject;
            
            if ( logic_uScriptAct_LookAt_Target_97.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_LookAt_Target_97, index + 1);
            }
            logic_uScriptAct_LookAt_Target_97[ index++ ] = local_3_UnityEngine_GameObject;
            
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_LookAt_uScriptAct_LookAt_97.In(logic_uScriptAct_LookAt_Target_97, logic_uScriptAct_LookAt_Focus_97, logic_uScriptAct_LookAt_time_97);
         SyncUnityHooks( );
         if ( logic_uScriptAct_LookAt_uScriptAct_LookAt_97.Out == true )
         {
         }
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
         Relay_In_95();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Input Events.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_98()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            if ( logic_uScriptAct_Teleport_Target_98.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Teleport_Target_98, index + 1);
            }
            logic_uScriptAct_Teleport_Target_98[ index++ ] = local_38_UnityEngine_GameObject;
            
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_Teleport_uScriptAct_Teleport_98.In(logic_uScriptAct_Teleport_Target_98, logic_uScriptAct_Teleport_Destination_98, logic_uScriptAct_Teleport_UpdateRotation_98);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Teleport_uScriptAct_Teleport_98.Out == true )
         {
            Relay_In_79();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Teleport.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_99()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            logic_uScriptCon_CompareBool_Bool_99 = local_14_System_Boolean;
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_99.In(logic_uScriptCon_CompareBool_Bool_99);
         SyncUnityHooks( );
         if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_99.True == true )
         {
         }
         if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_99.False == true )
         {
            Relay_In_97();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_100()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_Log_uScriptAct_Log_100.In(logic_uScriptAct_Log_Prefix_100, logic_uScriptAct_Log_Target_100, logic_uScriptAct_Log_Postfix_100);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Log_uScriptAct_Log_100.Out == true )
         {
         }
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
         Relay_In_102();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Input Events.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_101()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            if ( logic_uScriptAct_Concatenate_A_101.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Concatenate_A_101, index + 1);
            }
            logic_uScriptAct_Concatenate_A_101[ index++ ] = local_40_System_String;
            
            index = 0;
            properties = null;
            if ( logic_uScriptAct_Concatenate_B_101.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Concatenate_B_101, index + 1);
            }
            logic_uScriptAct_Concatenate_B_101[ index++ ] = local_5_System_Int32;
            
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_Concatenate_uScriptAct_Concatenate_101.In(logic_uScriptAct_Concatenate_A_101, logic_uScriptAct_Concatenate_B_101, logic_uScriptAct_Concatenate_Separator_101, out logic_uScriptAct_Concatenate_Result_101);
         local_53_System_String = logic_uScriptAct_Concatenate_Result_101;
         SyncUnityHooks( );
         if ( logic_uScriptAct_Concatenate_uScriptAct_Concatenate_101.Out == true )
         {
            Relay_Play_90();
            Relay_In_98();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Concatenate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_102()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_102.In(logic_uScriptAct_OnInputEventFilter_KeyCode_102);
         SyncUnityHooks( );
         if ( logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_102.KeyHeld == true )
         {
         }
         if ( logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_102.KeyDown == true )
         {
            Relay_In_86();
         }
         if ( logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_102.KeyUp == true )
         {
            Relay_Play_94();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_103()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            logic_uScriptCon_IntCounter_A_103 = local_70_System_Int32;
            index = 0;
            properties = null;
            logic_uScriptCon_IntCounter_B_103 = local_37_System_Int32;
            index = 0;
            properties = null;
         }
         logic_uScriptCon_IntCounter_uScriptCon_IntCounter_103.In(logic_uScriptCon_IntCounter_A_103, logic_uScriptCon_IntCounter_B_103, out logic_uScriptCon_IntCounter_currentValue_103);
         local_5_System_Int32 = logic_uScriptCon_IntCounter_currentValue_103;
         SyncUnityHooks( );
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_103.GreaterThan == true )
         {
         }
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_103.GreaterThanOrEqualTo == true )
         {
            Relay_In_101();
         }
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_103.EqualTo == true )
         {
         }
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_103.LessThanOrEqualTo == true )
         {
         }
         if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_103.LessThan == true )
         {
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Int Counter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_104()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            logic_uScriptCon_CompareBool_Bool_104 = local_10_System_Boolean;
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_104.In(logic_uScriptCon_CompareBool_Bool_104);
         SyncUnityHooks( );
         if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_104.True == true )
         {
         }
         if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_104.False == true )
         {
            Relay_In_96();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_StressTest at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
}
