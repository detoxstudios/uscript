//uScript Generated Code - Build 0.3.110522b
using UnityEngine;
using System.Collections;

public class uScript_StressTest : uScriptLogic
{

   #pragma warning disable 414
   GameObject parentGameObject = null;
   //external output properties
   
   //externally exposed events
   
   //external parameters
   
   //local nodes
   System.String local_0_System_String = "Area Damage";
   System.Int32 local_2_System_Int32 = (int) 0;
   System.Int32 local_4_System_Int32 = (int) 0;
   System.Boolean local_9_System_Boolean = (bool) false;
   UnityEngine.GameObject local_10_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_10_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Cover3_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Cover3_UnityEngine_GameObject_previous = null;
   System.Boolean local_14_System_Boolean = (bool) false;
   UnityEngine.GameObject local_16_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_16_UnityEngine_GameObject_previous = null;
   System.String local_21_System_String = "Area Damage";
   UnityEngine.GameObject local_27_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_27_UnityEngine_GameObject_previous = null;
   System.Int32 local_30_System_Int32 = (int) 0;
   System.Int32 local_32_System_Int32 = (int) 0;
   UnityEngine.GameObject local_Monster_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Monster_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Cover1_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Cover1_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_35_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_35_UnityEngine_GameObject_previous = null;
   System.String local_36_System_String = "Ogre";
   UnityEngine.GameObject local_39_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_39_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_44_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_44_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Cover2_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Cover2_UnityEngine_GameObject_previous = null;
   System.String local_52_System_String = "";
   UnityEngine.GameObject local_54_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_54_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_56_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_56_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_57_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_57_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_64_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_64_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_65_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_65_UnityEngine_GameObject_previous = null;
   System.Int32 local_68_System_Int32 = (int) 0;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_76 = null;
   System.String logic_uScriptAct_Log_Prefix_76 = "";
   System.Object[] logic_uScriptAct_Log_Target_76 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_76 = "";
   bool logic_uScriptAct_Log_Out_76 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_77 = null;
   System.Boolean logic_uScriptCon_CompareBool_Bool_77 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_77 = true;
   bool logic_uScriptCon_CompareBool_False_77 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_78 = null;
   System.Int32 logic_uScriptCon_IntCounter_A_78 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_B_78 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_78;
   bool logic_uScriptCon_IntCounter_GreaterThan_78 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_78 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_78 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_78 = true;
   bool logic_uScriptCon_IntCounter_LessThan_78 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_79 = null;
   System.String logic_uScriptAct_Log_Prefix_79 = "";
   System.Object[] logic_uScriptAct_Log_Target_79 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_79 = "";
   bool logic_uScriptAct_Log_Out_79 = true;
   //pointer to script instanced logic node
   uScriptAct_DestroyComponent logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_80 = null;
   UnityEngine.GameObject[] logic_uScriptAct_DestroyComponent_Target_80 = new UnityEngine.GameObject[] {};
   System.String[] logic_uScriptAct_DestroyComponent_ComponentName_80 = new System.String[] {""};
   System.Single logic_uScriptAct_DestroyComponent_DelayTime_80 = (float) 0;
   bool logic_uScriptAct_DestroyComponent_Out_80 = true;
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
   uScriptAct_Teleport logic_uScriptAct_Teleport_uScriptAct_Teleport_83 = null;
   UnityEngine.GameObject[] logic_uScriptAct_Teleport_Target_83 = new UnityEngine.GameObject[] {};
   UnityEngine.GameObject logic_uScriptAct_Teleport_Destination_83 = null;
   System.Boolean logic_uScriptAct_Teleport_UpdateRotation_83 = (bool) false;
   bool logic_uScriptAct_Teleport_Out_83 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_84 = null;
   System.String logic_uScriptAct_Log_Prefix_84 = "";
   System.Object[] logic_uScriptAct_Log_Target_84 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_84 = "";
   bool logic_uScriptAct_Log_Out_84 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_85 = null;
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_85 = null;
   UnityEngine.GameObject logic_uScriptAct_PlaySound_target_85 = null;
   System.Single logic_uScriptAct_PlaySound_volume_85 = (float) 0;
   System.Boolean logic_uScriptAct_PlaySound_loop_85 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_85 = true;
   //pointer to script instanced logic node
   uScriptAct_OnKeyPressFilter logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_86 = null;
   UnityEngine.KeyCode logic_uScriptAct_OnKeyPressFilter_KeyCode_86 = UnityEngine.KeyCode.None;
   bool logic_uScriptAct_OnKeyPressFilter_KeyHeld_86 = true;
   bool logic_uScriptAct_OnKeyPressFilter_KeyDown_86 = true;
   bool logic_uScriptAct_OnKeyPressFilter_KeyUp_86 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_87 = null;
   System.Single logic_uScriptAct_Delay_Duration_87 = (float) 0;
   bool logic_uScriptAct_Delay_Immediate_87 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_88 = null;
   System.Single logic_uScriptAct_Delay_Duration_88 = (float) 0;
   bool logic_uScriptAct_Delay_Immediate_88 = true;
   //pointer to script instanced logic node
   uScriptAct_DestroyComponent logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_89 = null;
   UnityEngine.GameObject[] logic_uScriptAct_DestroyComponent_Target_89 = new UnityEngine.GameObject[] {};
   System.String[] logic_uScriptAct_DestroyComponent_ComponentName_89 = new System.String[] {""};
   System.Single logic_uScriptAct_DestroyComponent_DelayTime_89 = (float) 0;
   bool logic_uScriptAct_DestroyComponent_Out_89 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_90 = null;
   System.String logic_uScriptAct_Log_Prefix_90 = "";
   System.Object[] logic_uScriptAct_Log_Target_90 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_90 = "";
   bool logic_uScriptAct_Log_Out_90 = true;
   //pointer to script instanced logic node
   uScriptAct_Toggle logic_uScriptAct_Toggle_uScriptAct_Toggle_91 = null;
   UnityEngine.GameObject[] logic_uScriptAct_Toggle_Target_91 = new UnityEngine.GameObject[] {};
   System.Boolean logic_uScriptAct_Toggle_IgnoreChildren_91 = (bool) false;
   bool logic_uScriptAct_Toggle_Out_91 = true;
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
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_94 = null;
   System.String logic_uScriptAct_Log_Prefix_94 = "";
   System.Object[] logic_uScriptAct_Log_Target_94 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_94 = "";
   bool logic_uScriptAct_Log_Out_94 = true;
   //pointer to script instanced logic node
   uScriptAct_Concatenate logic_uScriptAct_Concatenate_uScriptAct_Concatenate_95 = null;
   System.Object[] logic_uScriptAct_Concatenate_A_95 = new System.Object[] {""};
   System.Object[] logic_uScriptAct_Concatenate_B_95 = new System.Object[] {""};
   System.String logic_uScriptAct_Concatenate_Separator_95 = "";
   System.String logic_uScriptAct_Concatenate_Result_95;
   bool logic_uScriptAct_Concatenate_Out_95 = true;
   //pointer to script instanced logic node
   uScriptAct_LookAt logic_uScriptAct_LookAt_uScriptAct_LookAt_96 = null;
   UnityEngine.GameObject[] logic_uScriptAct_LookAt_Target_96 = new UnityEngine.GameObject[] {};
   System.Object logic_uScriptAct_LookAt_Focus_96 = "";
   bool logic_uScriptAct_LookAt_Out_96 = true;
   //pointer to script instanced logic node
   uScriptAct_LookAt logic_uScriptAct_LookAt_uScriptAct_LookAt_97 = null;
   UnityEngine.GameObject[] logic_uScriptAct_LookAt_Target_97 = new UnityEngine.GameObject[] {};
   System.Object logic_uScriptAct_LookAt_Focus_97 = "";
   bool logic_uScriptAct_LookAt_Out_97 = true;
   //pointer to script instanced logic node
   uScriptAct_OnKeyPressFilter logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_98 = null;
   UnityEngine.KeyCode logic_uScriptAct_OnKeyPressFilter_KeyCode_98 = UnityEngine.KeyCode.None;
   bool logic_uScriptAct_OnKeyPressFilter_KeyHeld_98 = true;
   bool logic_uScriptAct_OnKeyPressFilter_KeyDown_98 = true;
   bool logic_uScriptAct_OnKeyPressFilter_KeyUp_98 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_99 = null;
   System.String logic_uScriptAct_Log_Prefix_99 = "";
   System.Object[] logic_uScriptAct_Log_Target_99 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_99 = "";
   bool logic_uScriptAct_Log_Out_99 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_100 = null;
   System.Int32 logic_uScriptCon_IntCounter_A_100 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_B_100 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_100;
   bool logic_uScriptCon_IntCounter_GreaterThan_100 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_100 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_100 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_100 = true;
   bool logic_uScriptCon_IntCounter_LessThan_100 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_101 = null;
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_101 = null;
   UnityEngine.GameObject logic_uScriptAct_PlaySound_target_101 = null;
   System.Single logic_uScriptAct_PlaySound_volume_101 = (float) 0;
   System.Boolean logic_uScriptAct_PlaySound_loop_101 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_101 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_102 = null;
   System.Boolean logic_uScriptCon_CompareBool_Bool_102 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_102 = true;
   bool logic_uScriptCon_CompareBool_False_102 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_103 = null;
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_103 = null;
   UnityEngine.GameObject logic_uScriptAct_PlaySound_target_103 = null;
   System.Single logic_uScriptAct_PlaySound_volume_103 = (float) 0;
   System.Boolean logic_uScriptAct_PlaySound_loop_103 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_103 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_104 = null;
   System.String logic_uScriptAct_Log_Prefix_104 = "";
   System.Object[] logic_uScriptAct_Log_Target_104 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_104 = "";
   bool logic_uScriptAct_Log_Out_104 = true;
   
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
         event_UnityEngine_GameObject_Instance_105 = GameObject.Find( "_uScript" ) as UnityEngine.GameObject;
         if ( null != event_UnityEngine_GameObject_Instance_105 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_105.GetComponent<uScript_Input>();
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_105;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_106 )
      {
         event_UnityEngine_GameObject_Instance_106 = GameObject.Find( "_uScript" ) as UnityEngine.GameObject;
         if ( null != event_UnityEngine_GameObject_Instance_106 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_106.GetComponent<uScript_Input>();
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_106;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_10_UnityEngine_GameObject_previous != local_10_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_10_UnityEngine_GameObject_previous )
         {
         }
         
         local_10_UnityEngine_GameObject_previous = local_10_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_10_UnityEngine_GameObject )
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
      if ( local_16_UnityEngine_GameObject_previous != local_16_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_16_UnityEngine_GameObject_previous )
         {
         }
         
         local_16_UnityEngine_GameObject_previous = local_16_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_16_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_27_UnityEngine_GameObject_previous != local_27_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_27_UnityEngine_GameObject_previous )
         {
         }
         
         local_27_UnityEngine_GameObject_previous = local_27_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_27_UnityEngine_GameObject )
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
      if ( local_35_UnityEngine_GameObject_previous != local_35_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_35_UnityEngine_GameObject_previous )
         {
         }
         
         local_35_UnityEngine_GameObject_previous = local_35_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_35_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_39_UnityEngine_GameObject_previous != local_39_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_39_UnityEngine_GameObject_previous )
         {
         }
         
         local_39_UnityEngine_GameObject_previous = local_39_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_39_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_44_UnityEngine_GameObject_previous != local_44_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_44_UnityEngine_GameObject_previous )
         {
         }
         
         local_44_UnityEngine_GameObject_previous = local_44_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_44_UnityEngine_GameObject )
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
      if ( local_54_UnityEngine_GameObject_previous != local_54_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_54_UnityEngine_GameObject_previous )
         {
         }
         
         local_54_UnityEngine_GameObject_previous = local_54_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_54_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_56_UnityEngine_GameObject_previous != local_56_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_56_UnityEngine_GameObject_previous )
         {
         }
         
         local_56_UnityEngine_GameObject_previous = local_56_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_56_UnityEngine_GameObject )
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
      if ( local_64_UnityEngine_GameObject_previous != local_64_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_64_UnityEngine_GameObject_previous )
         {
         }
         
         local_64_UnityEngine_GameObject_previous = local_64_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_64_UnityEngine_GameObject )
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
      SyncUnityHooks( );
      
      logic_uScriptAct_Log_uScriptAct_Log_76.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_77.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_78.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_79.SetParent(g);
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_80.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_81.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.SetParent(g);
      logic_uScriptAct_Teleport_uScriptAct_Teleport_83.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_84.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_85.SetParent(g);
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_86.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_87.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_88.SetParent(g);
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_89.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_90.SetParent(g);
      logic_uScriptAct_Toggle_uScriptAct_Toggle_91.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_92.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_93.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_94.SetParent(g);
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_95.SetParent(g);
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.SetParent(g);
      logic_uScriptAct_LookAt_uScriptAct_LookAt_97.SetParent(g);
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_98.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_99.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_100.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_101.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_102.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_103.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_104.SetParent(g);
   }
   public void Awake()
   {
      #pragma warning disable 414
      GameObject masterObject = GameObject.Find("_uScript");
      uScript_Assets assetComponent = null;
      if ( null != masterObject ) assetComponent = masterObject.GetComponent<uScript_Assets>( );
      if ( null != assetComponent )
      {
      }
      else
      {
         uScriptDebug.Log( "uScript_Assets component cannot be found on GameObject _uScript", uScriptDebug.Type.Error);
      }
      #pragma warning restore 414
      
      SyncUnityHooks( );
      
      logic_uScriptAct_Log_uScriptAct_Log_76 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_77 = ScriptableObject.CreateInstance(typeof(uScriptCon_CompareBool)) as uScriptCon_CompareBool;
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_78 = ScriptableObject.CreateInstance(typeof(uScriptCon_IntCounter)) as uScriptCon_IntCounter;
      logic_uScriptAct_Log_uScriptAct_Log_79 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_80 = ScriptableObject.CreateInstance(typeof(uScriptAct_DestroyComponent)) as uScriptAct_DestroyComponent;
      logic_uScriptAct_Log_uScriptAct_Log_81 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82 = ScriptableObject.CreateInstance(typeof(uScriptCon_IntCounter)) as uScriptCon_IntCounter;
      logic_uScriptAct_Teleport_uScriptAct_Teleport_83 = ScriptableObject.CreateInstance(typeof(uScriptAct_Teleport)) as uScriptAct_Teleport;
      logic_uScriptAct_Log_uScriptAct_Log_84 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_85 = ScriptableObject.CreateInstance(typeof(uScriptAct_PlaySound)) as uScriptAct_PlaySound;
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_86 = ScriptableObject.CreateInstance(typeof(uScriptAct_OnKeyPressFilter)) as uScriptAct_OnKeyPressFilter;
      logic_uScriptAct_Delay_uScriptAct_Delay_87 = ScriptableObject.CreateInstance(typeof(uScriptAct_Delay)) as uScriptAct_Delay;
      logic_uScriptAct_Delay_uScriptAct_Delay_88 = ScriptableObject.CreateInstance(typeof(uScriptAct_Delay)) as uScriptAct_Delay;
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_89 = ScriptableObject.CreateInstance(typeof(uScriptAct_DestroyComponent)) as uScriptAct_DestroyComponent;
      logic_uScriptAct_Log_uScriptAct_Log_90 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_91 = ScriptableObject.CreateInstance(typeof(uScriptAct_Toggle)) as uScriptAct_Toggle;
      logic_uScriptAct_Log_uScriptAct_Log_92 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_93 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_94 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_95 = ScriptableObject.CreateInstance(typeof(uScriptAct_Concatenate)) as uScriptAct_Concatenate;
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96 = ScriptableObject.CreateInstance(typeof(uScriptAct_LookAt)) as uScriptAct_LookAt;
      logic_uScriptAct_LookAt_uScriptAct_LookAt_97 = ScriptableObject.CreateInstance(typeof(uScriptAct_LookAt)) as uScriptAct_LookAt;
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_98 = ScriptableObject.CreateInstance(typeof(uScriptAct_OnKeyPressFilter)) as uScriptAct_OnKeyPressFilter;
      logic_uScriptAct_Log_uScriptAct_Log_99 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_100 = ScriptableObject.CreateInstance(typeof(uScriptCon_IntCounter)) as uScriptCon_IntCounter;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_101 = ScriptableObject.CreateInstance(typeof(uScriptAct_PlaySound)) as uScriptAct_PlaySound;
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_102 = ScriptableObject.CreateInstance(typeof(uScriptCon_CompareBool)) as uScriptCon_CompareBool;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_103 = ScriptableObject.CreateInstance(typeof(uScriptAct_PlaySound)) as uScriptAct_PlaySound;
      logic_uScriptAct_Log_uScriptAct_Log_104 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_85.Finished += uScriptAct_PlaySound_Finished_85;
      logic_uScriptAct_Delay_uScriptAct_Delay_87.AfterDelay += uScriptAct_Delay_AfterDelay_87;
      logic_uScriptAct_Delay_uScriptAct_Delay_88.AfterDelay += uScriptAct_Delay_AfterDelay_88;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_91.OnOut += uScriptAct_Toggle_OnOut_91;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_91.OffOut += uScriptAct_Toggle_OffOut_91;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_91.ToggleOut += uScriptAct_Toggle_ToggleOut_91;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_101.Finished += uScriptAct_PlaySound_Finished_101;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_103.Finished += uScriptAct_PlaySound_Finished_103;
   }
   
   public override void Update()
   {
      logic_uScriptAct_Log_uScriptAct_Log_76.Update( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_77.Update( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_78.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_79.Update( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_80.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_81.Update( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.Update( );
      logic_uScriptAct_Teleport_uScriptAct_Teleport_83.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_84.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_85.Update( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_86.Update( );
      logic_uScriptAct_Delay_uScriptAct_Delay_87.Update( );
      logic_uScriptAct_Delay_uScriptAct_Delay_88.Update( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_89.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_90.Update( );
      logic_uScriptAct_Toggle_uScriptAct_Toggle_91.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_92.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_93.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_94.Update( );
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_95.Update( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.Update( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_97.Update( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_98.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_99.Update( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_100.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_101.Update( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_102.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_103.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_104.Update( );
   }
   
   public override void LateUpdate()
   {
      logic_uScriptAct_Log_uScriptAct_Log_76.LateUpdate( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_77.LateUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_78.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_79.LateUpdate( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_80.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_81.LateUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.LateUpdate( );
      logic_uScriptAct_Teleport_uScriptAct_Teleport_83.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_84.LateUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_85.LateUpdate( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_86.LateUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_87.LateUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_88.LateUpdate( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_89.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_90.LateUpdate( );
      logic_uScriptAct_Toggle_uScriptAct_Toggle_91.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_92.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_93.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_94.LateUpdate( );
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_95.LateUpdate( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.LateUpdate( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_97.LateUpdate( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_98.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_99.LateUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_100.LateUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_101.LateUpdate( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_102.LateUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_103.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_104.LateUpdate( );
   }
   
   public override void FixedUpdate()
   {
      logic_uScriptAct_Log_uScriptAct_Log_76.FixedUpdate( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_77.FixedUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_78.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_79.FixedUpdate( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_80.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_81.FixedUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.FixedUpdate( );
      logic_uScriptAct_Teleport_uScriptAct_Teleport_83.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_84.FixedUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_85.FixedUpdate( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_86.FixedUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_87.FixedUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_88.FixedUpdate( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_89.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_90.FixedUpdate( );
      logic_uScriptAct_Toggle_uScriptAct_Toggle_91.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_92.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_93.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_94.FixedUpdate( );
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_95.FixedUpdate( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.FixedUpdate( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_97.FixedUpdate( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_98.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_99.FixedUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_100.FixedUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_101.FixedUpdate( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_102.FixedUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_103.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_104.FixedUpdate( );
   }
   
   public override void OnGUI()
   {
      logic_uScriptAct_Log_uScriptAct_Log_76.OnGUI( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_77.OnGUI( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_78.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_79.OnGUI( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_80.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_81.OnGUI( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.OnGUI( );
      logic_uScriptAct_Teleport_uScriptAct_Teleport_83.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_84.OnGUI( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_85.OnGUI( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_86.OnGUI( );
      logic_uScriptAct_Delay_uScriptAct_Delay_87.OnGUI( );
      logic_uScriptAct_Delay_uScriptAct_Delay_88.OnGUI( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_89.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_90.OnGUI( );
      logic_uScriptAct_Toggle_uScriptAct_Toggle_91.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_92.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_93.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_94.OnGUI( );
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_95.OnGUI( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.OnGUI( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_97.OnGUI( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_98.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_99.OnGUI( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_100.OnGUI( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_101.OnGUI( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_102.OnGUI( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_103.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_104.OnGUI( );
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
   
   void uScriptAct_PlaySound_Finished_85(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_Finished_85( );
   }
   
   void uScriptAct_Delay_AfterDelay_87(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_AfterDelay_87( );
   }
   
   void uScriptAct_Delay_AfterDelay_88(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_AfterDelay_88( );
   }
   
   void uScriptAct_Toggle_OnOut_91(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_OnOut_91( );
   }
   
   void uScriptAct_Toggle_OffOut_91(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_OffOut_91( );
   }
   
   void uScriptAct_Toggle_ToggleOut_91(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_ToggleOut_91( );
   }
   
   void uScriptAct_PlaySound_Finished_101(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_Finished_101( );
   }
   
   void uScriptAct_PlaySound_Finished_103(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_Finished_103( );
   }
   
   void Relay_In_76()
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
   
   void Relay_In_77()
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
         logic_uScriptCon_CompareBool_Bool_77 = local_14_System_Boolean;
      }
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_77.In(logic_uScriptCon_CompareBool_Bool_77);
      SyncUnityHooks( );
      if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_77.True == true )
      {
      }
      if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_77.False == true )
      {
         Relay_In_97();
      }
   }
   
   void Relay_In_78()
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
         logic_uScriptCon_IntCounter_B_78 = local_2_System_Int32;
         index = 0;
         properties = null;
      }
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_78.In(logic_uScriptCon_IntCounter_A_78, logic_uScriptCon_IntCounter_B_78, out logic_uScriptCon_IntCounter_currentValue_78);
      SyncUnityHooks( );
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_78.GreaterThan == true )
      {
         Relay_In_84();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_78.GreaterThanOrEqualTo == true )
      {
         Relay_In_94();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_78.EqualTo == true )
      {
         Relay_In_104();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_78.LessThanOrEqualTo == true )
      {
         Relay_In_99();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_78.LessThan == true )
      {
         Relay_In_99();
      }
   }
   
   void Relay_In_79()
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
   
   void Relay_In_80()
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
         if ( logic_uScriptAct_DestroyComponent_Target_80.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_DestroyComponent_Target_80, index + 1);
         }
         logic_uScriptAct_DestroyComponent_Target_80[ index++ ] = local_Monster_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         if ( logic_uScriptAct_DestroyComponent_ComponentName_80.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_DestroyComponent_ComponentName_80, index + 1);
         }
         logic_uScriptAct_DestroyComponent_ComponentName_80[ index++ ] = local_21_System_String;
         
         index = 0;
         properties = null;
      }
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_80.In(logic_uScriptAct_DestroyComponent_Target_80, logic_uScriptAct_DestroyComponent_ComponentName_80, logic_uScriptAct_DestroyComponent_DelayTime_80);
      SyncUnityHooks( );
      if ( logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_80.Out == true )
      {
         Relay_In_78();
      }
   }
   
   void Relay_In_81()
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
   
   void Relay_In_82()
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
         logic_uScriptCon_IntCounter_B_82 = local_30_System_Int32;
         index = 0;
         properties = null;
      }
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.In(logic_uScriptCon_IntCounter_A_82, logic_uScriptCon_IntCounter_B_82, out logic_uScriptCon_IntCounter_currentValue_82);
      SyncUnityHooks( );
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.GreaterThan == true )
      {
         Relay_In_92();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.GreaterThanOrEqualTo == true )
      {
         Relay_In_93();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.EqualTo == true )
      {
         Relay_In_76();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.LessThanOrEqualTo == true )
      {
         Relay_In_90();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_82.LessThan == true )
      {
         Relay_In_90();
      }
   }
   
   void Relay_In_83()
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
         if ( logic_uScriptAct_Teleport_Target_83.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Teleport_Target_83, index + 1);
         }
         logic_uScriptAct_Teleport_Target_83[ index++ ] = local_65_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         index = 0;
         properties = null;
      }
      logic_uScriptAct_Teleport_uScriptAct_Teleport_83.In(logic_uScriptAct_Teleport_Target_83, logic_uScriptAct_Teleport_Destination_83, logic_uScriptAct_Teleport_UpdateRotation_83);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Teleport_uScriptAct_Teleport_83.Out == true )
      {
         Relay_In_79();
      }
   }
   
   void Relay_In_84()
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
      logic_uScriptAct_Log_uScriptAct_Log_84.In(logic_uScriptAct_Log_Prefix_84, logic_uScriptAct_Log_Target_84, logic_uScriptAct_Log_Postfix_84);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_84.Out == true )
      {
      }
   }
   
   void Relay_Finished_85()
   {
   }
   
   void Relay_Play_85()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_85.Play(logic_uScriptAct_PlaySound_audioClip_85, logic_uScriptAct_PlaySound_target_85, logic_uScriptAct_PlaySound_volume_85, logic_uScriptAct_PlaySound_loop_85);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_85.Out == true )
      {
         Relay_In_102();
      }
   }
   
   void Relay_Stop_85()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_85.Stop(logic_uScriptAct_PlaySound_audioClip_85, logic_uScriptAct_PlaySound_target_85, logic_uScriptAct_PlaySound_volume_85, logic_uScriptAct_PlaySound_loop_85);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_85.Out == true )
      {
         Relay_In_102();
      }
   }
   
   void Relay_In_86()
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
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_86.In(logic_uScriptAct_OnKeyPressFilter_KeyCode_86);
      SyncUnityHooks( );
      if ( logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_86.KeyHeld == true )
      {
      }
      if ( logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_86.KeyDown == true )
      {
         Relay_Stop_101();
         Relay_In_89();
      }
      if ( logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_86.KeyUp == true )
      {
      }
   }
   
   void Relay_AfterDelay_87()
   {
      Relay_In_81();
   }
   
   void Relay_In_87()
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
      logic_uScriptAct_Delay_uScriptAct_Delay_87.In(logic_uScriptAct_Delay_Duration_87);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Delay_uScriptAct_Delay_87.Immediate == true )
      {
         Relay_In_79();
      }
   }
   
   void Relay_AfterDelay_88()
   {
   }
   
   void Relay_In_88()
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
      logic_uScriptAct_Delay_uScriptAct_Delay_88.In(logic_uScriptAct_Delay_Duration_88);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Delay_uScriptAct_Delay_88.Immediate == true )
      {
         Relay_In_100();
      }
   }
   
   void Relay_In_89()
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
         if ( logic_uScriptAct_DestroyComponent_Target_89.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_DestroyComponent_Target_89, index + 1);
         }
         logic_uScriptAct_DestroyComponent_Target_89[ index++ ] = local_Monster_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         if ( logic_uScriptAct_DestroyComponent_ComponentName_89.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_DestroyComponent_ComponentName_89, index + 1);
         }
         logic_uScriptAct_DestroyComponent_ComponentName_89[ index++ ] = local_0_System_String;
         
         index = 0;
         properties = null;
      }
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_89.In(logic_uScriptAct_DestroyComponent_Target_89, logic_uScriptAct_DestroyComponent_ComponentName_89, logic_uScriptAct_DestroyComponent_DelayTime_89);
      SyncUnityHooks( );
      if ( logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_89.Out == true )
      {
         Relay_In_82();
      }
   }
   
   void Relay_In_90()
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
      logic_uScriptAct_Log_uScriptAct_Log_90.In(logic_uScriptAct_Log_Prefix_90, logic_uScriptAct_Log_Target_90, logic_uScriptAct_Log_Postfix_90);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_90.Out == true )
      {
      }
   }
   
   void Relay_OnOut_91()
   {
   }
   
   void Relay_OffOut_91()
   {
   }
   
   void Relay_ToggleOut_91()
   {
   }
   
   void Relay_TurnOn_91()
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
         if ( logic_uScriptAct_Toggle_Target_91.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_91, index + 1);
         }
         logic_uScriptAct_Toggle_Target_91[ index++ ] = local_Cover2_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_Toggle_Target_91.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_91, index + 1);
         }
         logic_uScriptAct_Toggle_Target_91[ index++ ] = local_Cover1_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
      }
      logic_uScriptAct_Toggle_uScriptAct_Toggle_91.TurnOn(logic_uScriptAct_Toggle_Target_91, logic_uScriptAct_Toggle_IgnoreChildren_91);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Toggle_uScriptAct_Toggle_91.Out == true )
      {
         Relay_In_87();
      }
   }
   
   void Relay_TurnOff_91()
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
         if ( logic_uScriptAct_Toggle_Target_91.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_91, index + 1);
         }
         logic_uScriptAct_Toggle_Target_91[ index++ ] = local_Cover2_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_Toggle_Target_91.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_91, index + 1);
         }
         logic_uScriptAct_Toggle_Target_91[ index++ ] = local_Cover1_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
      }
      logic_uScriptAct_Toggle_uScriptAct_Toggle_91.TurnOff(logic_uScriptAct_Toggle_Target_91, logic_uScriptAct_Toggle_IgnoreChildren_91);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Toggle_uScriptAct_Toggle_91.Out == true )
      {
         Relay_In_87();
      }
   }
   
   void Relay_Toggle_91()
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
         if ( logic_uScriptAct_Toggle_Target_91.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_91, index + 1);
         }
         logic_uScriptAct_Toggle_Target_91[ index++ ] = local_Cover2_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_Toggle_Target_91.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_91, index + 1);
         }
         logic_uScriptAct_Toggle_Target_91[ index++ ] = local_Cover1_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
      }
      logic_uScriptAct_Toggle_uScriptAct_Toggle_91.Toggle(logic_uScriptAct_Toggle_Target_91, logic_uScriptAct_Toggle_IgnoreChildren_91);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Toggle_uScriptAct_Toggle_91.Out == true )
      {
         Relay_In_87();
      }
   }
   
   void Relay_In_92()
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
   
   void Relay_In_93()
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
   
   void Relay_In_94()
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
      logic_uScriptAct_Log_uScriptAct_Log_94.In(logic_uScriptAct_Log_Prefix_94, logic_uScriptAct_Log_Target_94, logic_uScriptAct_Log_Postfix_94);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_94.Out == true )
      {
      }
   }
   
   void Relay_In_95()
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
         if ( logic_uScriptAct_Concatenate_A_95.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Concatenate_A_95, index + 1);
         }
         logic_uScriptAct_Concatenate_A_95[ index++ ] = local_36_System_String;
         
         index = 0;
         properties = null;
         if ( logic_uScriptAct_Concatenate_B_95.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Concatenate_B_95, index + 1);
         }
         logic_uScriptAct_Concatenate_B_95[ index++ ] = local_4_System_Int32;
         
         index = 0;
         properties = null;
         index = 0;
         properties = null;
      }
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_95.In(logic_uScriptAct_Concatenate_A_95, logic_uScriptAct_Concatenate_B_95, logic_uScriptAct_Concatenate_Separator_95, out logic_uScriptAct_Concatenate_Result_95);
      local_52_System_String = logic_uScriptAct_Concatenate_Result_95;
      SyncUnityHooks( );
      if ( logic_uScriptAct_Concatenate_uScriptAct_Concatenate_95.Out == true )
      {
         Relay_In_83();
         Relay_Play_103();
      }
   }
   
   void Relay_In_96()
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
         logic_uScriptAct_LookAt_Target_96[ index++ ] = local_56_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_96.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_96, index + 1);
         }
         logic_uScriptAct_LookAt_Target_96[ index++ ] = local_54_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_96.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_96, index + 1);
         }
         logic_uScriptAct_LookAt_Target_96[ index++ ] = local_64_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_96.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_96, index + 1);
         }
         logic_uScriptAct_LookAt_Target_96[ index++ ] = local_27_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_96.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_96, index + 1);
         }
         logic_uScriptAct_LookAt_Target_96[ index++ ] = local_16_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
      }
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.In(logic_uScriptAct_LookAt_Target_96, logic_uScriptAct_LookAt_Focus_96);
      SyncUnityHooks( );
      if ( logic_uScriptAct_LookAt_uScriptAct_LookAt_96.Out == true )
      {
      }
   }
   
   void Relay_In_97()
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
         logic_uScriptAct_LookAt_Target_97[ index++ ] = local_39_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_97.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_97, index + 1);
         }
         logic_uScriptAct_LookAt_Target_97[ index++ ] = local_57_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_97.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_97, index + 1);
         }
         logic_uScriptAct_LookAt_Target_97[ index++ ] = local_35_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_97.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_97, index + 1);
         }
         logic_uScriptAct_LookAt_Target_97[ index++ ] = local_10_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_97.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_97, index + 1);
         }
         logic_uScriptAct_LookAt_Target_97[ index++ ] = local_44_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
      }
      logic_uScriptAct_LookAt_uScriptAct_LookAt_97.In(logic_uScriptAct_LookAt_Target_97, logic_uScriptAct_LookAt_Focus_97);
      SyncUnityHooks( );
      if ( logic_uScriptAct_LookAt_uScriptAct_LookAt_97.Out == true )
      {
      }
   }
   
   void Relay_KeyEvent_105()
   {
      SyncUnityHooks( );
      Relay_In_98();
   }
   
   void Relay_In_98()
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
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_98.In(logic_uScriptAct_OnKeyPressFilter_KeyCode_98);
      SyncUnityHooks( );
      if ( logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_98.KeyHeld == true )
      {
      }
      if ( logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_98.KeyDown == true )
      {
         Relay_Stop_85();
         Relay_In_80();
      }
      if ( logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_98.KeyUp == true )
      {
      }
   }
   
   void Relay_In_99()
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
      logic_uScriptAct_Log_uScriptAct_Log_99.In(logic_uScriptAct_Log_Prefix_99, logic_uScriptAct_Log_Target_99, logic_uScriptAct_Log_Postfix_99);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_99.Out == true )
      {
      }
   }
   
   void Relay_KeyEvent_106()
   {
      SyncUnityHooks( );
      Relay_In_86();
   }
   
   void Relay_In_100()
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
         logic_uScriptCon_IntCounter_A_100 = local_68_System_Int32;
         index = 0;
         properties = null;
         logic_uScriptCon_IntCounter_B_100 = local_32_System_Int32;
         index = 0;
         properties = null;
      }
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_100.In(logic_uScriptCon_IntCounter_A_100, logic_uScriptCon_IntCounter_B_100, out logic_uScriptCon_IntCounter_currentValue_100);
      local_4_System_Int32 = logic_uScriptCon_IntCounter_currentValue_100;
      SyncUnityHooks( );
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_100.GreaterThan == true )
      {
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_100.GreaterThanOrEqualTo == true )
      {
         Relay_In_95();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_100.EqualTo == true )
      {
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_100.LessThanOrEqualTo == true )
      {
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_100.LessThan == true )
      {
      }
   }
   
   void Relay_Finished_101()
   {
   }
   
   void Relay_Play_101()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_101.Play(logic_uScriptAct_PlaySound_audioClip_101, logic_uScriptAct_PlaySound_target_101, logic_uScriptAct_PlaySound_volume_101, logic_uScriptAct_PlaySound_loop_101);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_101.Out == true )
      {
         Relay_In_77();
      }
   }
   
   void Relay_Stop_101()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_101.Stop(logic_uScriptAct_PlaySound_audioClip_101, logic_uScriptAct_PlaySound_target_101, logic_uScriptAct_PlaySound_volume_101, logic_uScriptAct_PlaySound_loop_101);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_101.Out == true )
      {
         Relay_In_77();
      }
   }
   
   void Relay_In_102()
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
         logic_uScriptCon_CompareBool_Bool_102 = local_9_System_Boolean;
      }
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_102.In(logic_uScriptCon_CompareBool_Bool_102);
      SyncUnityHooks( );
      if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_102.True == true )
      {
      }
      if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_102.False == true )
      {
         Relay_In_96();
      }
   }
   
   void Relay_Finished_103()
   {
   }
   
   void Relay_Play_103()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_103.Play(logic_uScriptAct_PlaySound_audioClip_103, logic_uScriptAct_PlaySound_target_103, logic_uScriptAct_PlaySound_volume_103, logic_uScriptAct_PlaySound_loop_103);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_103.Out == true )
      {
      }
   }
   
   void Relay_Stop_103()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_103.Stop(logic_uScriptAct_PlaySound_audioClip_103, logic_uScriptAct_PlaySound_target_103, logic_uScriptAct_PlaySound_volume_103, logic_uScriptAct_PlaySound_loop_103);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_103.Out == true )
      {
      }
   }
   
   void Relay_In_104()
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
      logic_uScriptAct_Log_uScriptAct_Log_104.In(logic_uScriptAct_Log_Prefix_104, logic_uScriptAct_Log_Target_104, logic_uScriptAct_Log_Postfix_104);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_104.Out == true )
      {
      }
   }
   
}
