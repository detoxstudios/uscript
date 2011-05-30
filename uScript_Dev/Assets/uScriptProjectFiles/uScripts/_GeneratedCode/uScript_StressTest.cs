//uScript Generated Code - Build 0.4.110530a
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
   System.Int32 local_1_System_Int32 = (int) 0;
   System.Int32 local_3_System_Int32 = (int) 0;
   System.Boolean local_8_System_Boolean = (bool) false;
   UnityEngine.GameObject local_9_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_9_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Cover3_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Cover3_UnityEngine_GameObject_previous = null;
   System.Boolean local_13_System_Boolean = (bool) false;
   UnityEngine.GameObject local_15_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_15_UnityEngine_GameObject_previous = null;
   System.String local_20_System_String = "Area Damage";
   UnityEngine.GameObject local_27_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_27_UnityEngine_GameObject_previous = null;
   System.Int32 local_31_System_Int32 = (int) 0;
   System.Int32 local_34_System_Int32 = (int) 0;
   System.Int32 local_35_System_Int32 = (int) 0;
   UnityEngine.GameObject local_Cover1_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Cover1_UnityEngine_GameObject_previous = null;
   System.String local_39_System_String = "Ogre";
   UnityEngine.GameObject local_41_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_41_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_43_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_43_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_44_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_44_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_45_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_45_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Cover2_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Cover2_UnityEngine_GameObject_previous = null;
   System.String local_52_System_String = "";
   UnityEngine.GameObject local_54_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_54_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Monster_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Monster_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_56_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_56_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_62_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_62_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_63_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_63_UnityEngine_GameObject_previous = null;
   System.Single local_66_System_Single = (float) 3;
   
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
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_78 = null;
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_78 = null;
   UnityEngine.GameObject logic_uScriptAct_PlaySound_target_78 = null;
   System.Single logic_uScriptAct_PlaySound_volume_78 = (float) 0;
   System.Boolean logic_uScriptAct_PlaySound_loop_78 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_78 = true;
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
   uScriptAct_DestroyComponent logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_81 = null;
   UnityEngine.GameObject[] logic_uScriptAct_DestroyComponent_Target_81 = new UnityEngine.GameObject[] {};
   System.String[] logic_uScriptAct_DestroyComponent_ComponentName_81 = new System.String[] {""};
   System.Single logic_uScriptAct_DestroyComponent_DelayTime_81 = (float) 0;
   bool logic_uScriptAct_DestroyComponent_Out_81 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_82 = null;
   System.String logic_uScriptAct_Log_Prefix_82 = "";
   System.Object[] logic_uScriptAct_Log_Target_82 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_82 = "";
   bool logic_uScriptAct_Log_Out_82 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_83 = null;
   System.String logic_uScriptAct_Log_Prefix_83 = "Trigger Fired!";
   System.Object[] logic_uScriptAct_Log_Target_83 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_83 = "";
   bool logic_uScriptAct_Log_Out_83 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_84 = null;
   System.Int32 logic_uScriptCon_IntCounter_A_84 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_B_84 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_84;
   bool logic_uScriptCon_IntCounter_GreaterThan_84 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_84 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_84 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_84 = true;
   bool logic_uScriptCon_IntCounter_LessThan_84 = true;
   //pointer to script instanced logic node
   uScriptAct_Teleport logic_uScriptAct_Teleport_uScriptAct_Teleport_85 = null;
   UnityEngine.GameObject[] logic_uScriptAct_Teleport_Target_85 = new UnityEngine.GameObject[] {};
   UnityEngine.GameObject logic_uScriptAct_Teleport_Destination_85 = null;
   System.Boolean logic_uScriptAct_Teleport_UpdateRotation_85 = (bool) false;
   bool logic_uScriptAct_Teleport_Out_85 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_86 = null;
   System.Single logic_uScriptAct_Delay_Duration_86 = (float) 0;
   bool logic_uScriptAct_Delay_Immediate_86 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_87 = null;
   System.Single logic_uScriptAct_Delay_Duration_87 = (float) 0;
   bool logic_uScriptAct_Delay_Immediate_87 = true;
   //pointer to script instanced logic node
   uScriptAct_DestroyComponent logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_88 = null;
   UnityEngine.GameObject[] logic_uScriptAct_DestroyComponent_Target_88 = new UnityEngine.GameObject[] {};
   System.String[] logic_uScriptAct_DestroyComponent_ComponentName_88 = new System.String[] {""};
   System.Single logic_uScriptAct_DestroyComponent_DelayTime_88 = (float) 0;
   bool logic_uScriptAct_DestroyComponent_Out_88 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_89 = null;
   System.String logic_uScriptAct_Log_Prefix_89 = "";
   System.Object[] logic_uScriptAct_Log_Target_89 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_89 = "";
   bool logic_uScriptAct_Log_Out_89 = true;
   //pointer to script instanced logic node
   uScriptAct_Toggle logic_uScriptAct_Toggle_uScriptAct_Toggle_90 = null;
   UnityEngine.GameObject[] logic_uScriptAct_Toggle_Target_90 = new UnityEngine.GameObject[] {};
   System.Boolean logic_uScriptAct_Toggle_IgnoreChildren_90 = (bool) false;
   bool logic_uScriptAct_Toggle_Out_90 = true;
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
   uScriptAct_Concatenate logic_uScriptAct_Concatenate_uScriptAct_Concatenate_94 = null;
   System.Object[] logic_uScriptAct_Concatenate_A_94 = new System.Object[] {""};
   System.Object[] logic_uScriptAct_Concatenate_B_94 = new System.Object[] {""};
   System.String logic_uScriptAct_Concatenate_Separator_94 = "";
   System.String logic_uScriptAct_Concatenate_Result_94;
   bool logic_uScriptAct_Concatenate_Out_94 = true;
   //pointer to script instanced logic node
   uScriptAct_LookAt logic_uScriptAct_LookAt_uScriptAct_LookAt_95 = null;
   UnityEngine.GameObject[] logic_uScriptAct_LookAt_Target_95 = new UnityEngine.GameObject[] {};
   System.Object logic_uScriptAct_LookAt_Focus_95 = "";
   bool logic_uScriptAct_LookAt_Out_95 = true;
   //pointer to script instanced logic node
   uScriptAct_LookAt logic_uScriptAct_LookAt_uScriptAct_LookAt_96 = null;
   UnityEngine.GameObject[] logic_uScriptAct_LookAt_Target_96 = new UnityEngine.GameObject[] {};
   System.Object logic_uScriptAct_LookAt_Focus_96 = "";
   bool logic_uScriptAct_LookAt_Out_96 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_97 = null;
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_97 = UnityEngine.KeyCode.None;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_97 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_97 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_97 = true;
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
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_100 = null;
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_100 = UnityEngine.KeyCode.None;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_100 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_100 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_100 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_101 = null;
   System.Int32 logic_uScriptCon_IntCounter_A_101 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_B_101 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_101;
   bool logic_uScriptCon_IntCounter_GreaterThan_101 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_101 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_101 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_101 = true;
   bool logic_uScriptCon_IntCounter_LessThan_101 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_102 = null;
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_102 = null;
   UnityEngine.GameObject logic_uScriptAct_PlaySound_target_102 = null;
   System.Single logic_uScriptAct_PlaySound_volume_102 = (float) 0;
   System.Boolean logic_uScriptAct_PlaySound_loop_102 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_102 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_103 = null;
   System.Boolean logic_uScriptCon_CompareBool_Bool_103 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_103 = true;
   bool logic_uScriptCon_CompareBool_False_103 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_104 = null;
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_104 = null;
   UnityEngine.GameObject logic_uScriptAct_PlaySound_target_104 = null;
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
      if ( local_9_UnityEngine_GameObject_previous != local_9_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_9_UnityEngine_GameObject_previous )
         {
         }
         
         local_9_UnityEngine_GameObject_previous = local_9_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_9_UnityEngine_GameObject )
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
      if ( local_15_UnityEngine_GameObject_previous != local_15_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_15_UnityEngine_GameObject_previous )
         {
         }
         
         local_15_UnityEngine_GameObject_previous = local_15_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_15_UnityEngine_GameObject )
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
      if ( local_41_UnityEngine_GameObject_previous != local_41_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_41_UnityEngine_GameObject_previous )
         {
         }
         
         local_41_UnityEngine_GameObject_previous = local_41_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_41_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_43_UnityEngine_GameObject_previous != local_43_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_43_UnityEngine_GameObject_previous )
         {
         }
         
         local_43_UnityEngine_GameObject_previous = local_43_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_43_UnityEngine_GameObject )
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
      if ( local_62_UnityEngine_GameObject_previous != local_62_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_62_UnityEngine_GameObject_previous )
         {
         }
         
         local_62_UnityEngine_GameObject_previous = local_62_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_62_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_63_UnityEngine_GameObject_previous != local_63_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_63_UnityEngine_GameObject_previous )
         {
         }
         
         local_63_UnityEngine_GameObject_previous = local_63_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_63_UnityEngine_GameObject )
         {
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      SyncUnityHooks( );
      
      logic_uScriptAct_Log_uScriptAct_Log_76.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_78.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_79.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_80.SetParent(g);
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_81.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_82.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_83.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_84.SetParent(g);
      logic_uScriptAct_Teleport_uScriptAct_Teleport_85.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_86.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_87.SetParent(g);
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_88.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_89.SetParent(g);
      logic_uScriptAct_Toggle_uScriptAct_Toggle_90.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_91.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_92.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_93.SetParent(g);
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_94.SetParent(g);
      logic_uScriptAct_LookAt_uScriptAct_LookAt_95.SetParent(g);
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_97.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_98.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_99.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_100.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_101.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_102.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_103.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_104.SetParent(g);
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
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77 = ScriptableObject.CreateInstance(typeof(uScriptCon_IntCounter)) as uScriptCon_IntCounter;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_78 = ScriptableObject.CreateInstance(typeof(uScriptAct_PlaySound)) as uScriptAct_PlaySound;
      logic_uScriptAct_Log_uScriptAct_Log_79 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_80 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_81 = ScriptableObject.CreateInstance(typeof(uScriptAct_DestroyComponent)) as uScriptAct_DestroyComponent;
      logic_uScriptAct_Log_uScriptAct_Log_82 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_83 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_84 = ScriptableObject.CreateInstance(typeof(uScriptCon_IntCounter)) as uScriptCon_IntCounter;
      logic_uScriptAct_Teleport_uScriptAct_Teleport_85 = ScriptableObject.CreateInstance(typeof(uScriptAct_Teleport)) as uScriptAct_Teleport;
      logic_uScriptAct_Delay_uScriptAct_Delay_86 = ScriptableObject.CreateInstance(typeof(uScriptAct_Delay)) as uScriptAct_Delay;
      logic_uScriptAct_Delay_uScriptAct_Delay_87 = ScriptableObject.CreateInstance(typeof(uScriptAct_Delay)) as uScriptAct_Delay;
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_88 = ScriptableObject.CreateInstance(typeof(uScriptAct_DestroyComponent)) as uScriptAct_DestroyComponent;
      logic_uScriptAct_Log_uScriptAct_Log_89 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_90 = ScriptableObject.CreateInstance(typeof(uScriptAct_Toggle)) as uScriptAct_Toggle;
      logic_uScriptAct_Log_uScriptAct_Log_91 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_92 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_93 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_94 = ScriptableObject.CreateInstance(typeof(uScriptAct_Concatenate)) as uScriptAct_Concatenate;
      logic_uScriptAct_LookAt_uScriptAct_LookAt_95 = ScriptableObject.CreateInstance(typeof(uScriptAct_LookAt)) as uScriptAct_LookAt;
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96 = ScriptableObject.CreateInstance(typeof(uScriptAct_LookAt)) as uScriptAct_LookAt;
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_97 = ScriptableObject.CreateInstance(typeof(uScriptAct_OnInputEventFilter)) as uScriptAct_OnInputEventFilter;
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_98 = ScriptableObject.CreateInstance(typeof(uScriptCon_CompareBool)) as uScriptCon_CompareBool;
      logic_uScriptAct_Log_uScriptAct_Log_99 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_100 = ScriptableObject.CreateInstance(typeof(uScriptAct_OnInputEventFilter)) as uScriptAct_OnInputEventFilter;
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_101 = ScriptableObject.CreateInstance(typeof(uScriptCon_IntCounter)) as uScriptCon_IntCounter;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_102 = ScriptableObject.CreateInstance(typeof(uScriptAct_PlaySound)) as uScriptAct_PlaySound;
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_103 = ScriptableObject.CreateInstance(typeof(uScriptCon_CompareBool)) as uScriptCon_CompareBool;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_104 = ScriptableObject.CreateInstance(typeof(uScriptAct_PlaySound)) as uScriptAct_PlaySound;
      
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_78.Finished += uScriptAct_PlaySound_Finished_78;
      logic_uScriptAct_Delay_uScriptAct_Delay_86.AfterDelay += uScriptAct_Delay_AfterDelay_86;
      logic_uScriptAct_Delay_uScriptAct_Delay_87.AfterDelay += uScriptAct_Delay_AfterDelay_87;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_90.OnOut += uScriptAct_Toggle_OnOut_90;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_90.OffOut += uScriptAct_Toggle_OffOut_90;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_90.ToggleOut += uScriptAct_Toggle_ToggleOut_90;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_102.Finished += uScriptAct_PlaySound_Finished_102;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_104.Finished += uScriptAct_PlaySound_Finished_104;
   }
   
   public override void Update()
   {
      logic_uScriptAct_Log_uScriptAct_Log_76.Update( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_78.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_79.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_80.Update( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_81.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_82.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_83.Update( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_84.Update( );
      logic_uScriptAct_Teleport_uScriptAct_Teleport_85.Update( );
      logic_uScriptAct_Delay_uScriptAct_Delay_86.Update( );
      logic_uScriptAct_Delay_uScriptAct_Delay_87.Update( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_88.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_89.Update( );
      logic_uScriptAct_Toggle_uScriptAct_Toggle_90.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_91.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_92.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_93.Update( );
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_94.Update( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_95.Update( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.Update( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_97.Update( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_98.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_99.Update( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_100.Update( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_101.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_102.Update( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_103.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_104.Update( );
   }
   
   public override void LateUpdate()
   {
      logic_uScriptAct_Log_uScriptAct_Log_76.LateUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.LateUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_78.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_79.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_80.LateUpdate( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_81.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_82.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_83.LateUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_84.LateUpdate( );
      logic_uScriptAct_Teleport_uScriptAct_Teleport_85.LateUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_86.LateUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_87.LateUpdate( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_88.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_89.LateUpdate( );
      logic_uScriptAct_Toggle_uScriptAct_Toggle_90.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_91.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_92.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_93.LateUpdate( );
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_94.LateUpdate( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_95.LateUpdate( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.LateUpdate( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_97.LateUpdate( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_98.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_99.LateUpdate( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_100.LateUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_101.LateUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_102.LateUpdate( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_103.LateUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_104.LateUpdate( );
   }
   
   public override void FixedUpdate()
   {
      logic_uScriptAct_Log_uScriptAct_Log_76.FixedUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.FixedUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_78.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_79.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_80.FixedUpdate( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_81.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_82.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_83.FixedUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_84.FixedUpdate( );
      logic_uScriptAct_Teleport_uScriptAct_Teleport_85.FixedUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_86.FixedUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_87.FixedUpdate( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_88.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_89.FixedUpdate( );
      logic_uScriptAct_Toggle_uScriptAct_Toggle_90.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_91.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_92.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_93.FixedUpdate( );
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_94.FixedUpdate( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_95.FixedUpdate( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.FixedUpdate( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_97.FixedUpdate( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_98.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_99.FixedUpdate( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_100.FixedUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_101.FixedUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_102.FixedUpdate( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_103.FixedUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_104.FixedUpdate( );
   }
   
   public override void OnGUI()
   {
      logic_uScriptAct_Log_uScriptAct_Log_76.OnGUI( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.OnGUI( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_78.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_79.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_80.OnGUI( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_81.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_82.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_83.OnGUI( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_84.OnGUI( );
      logic_uScriptAct_Teleport_uScriptAct_Teleport_85.OnGUI( );
      logic_uScriptAct_Delay_uScriptAct_Delay_86.OnGUI( );
      logic_uScriptAct_Delay_uScriptAct_Delay_87.OnGUI( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_88.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_89.OnGUI( );
      logic_uScriptAct_Toggle_uScriptAct_Toggle_90.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_91.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_92.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_93.OnGUI( );
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_94.OnGUI( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_95.OnGUI( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.OnGUI( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_97.OnGUI( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_98.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_99.OnGUI( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_100.OnGUI( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_101.OnGUI( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_102.OnGUI( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_103.OnGUI( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_104.OnGUI( );
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
   
   void uScriptAct_PlaySound_Finished_78(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_Finished_78( );
   }
   
   void uScriptAct_Delay_AfterDelay_86(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_AfterDelay_86( );
   }
   
   void uScriptAct_Delay_AfterDelay_87(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_AfterDelay_87( );
   }
   
   void uScriptAct_Toggle_OnOut_90(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_OnOut_90( );
   }
   
   void uScriptAct_Toggle_OffOut_90(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_OffOut_90( );
   }
   
   void uScriptAct_Toggle_ToggleOut_90(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_ToggleOut_90( );
   }
   
   void uScriptAct_PlaySound_Finished_102(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_Finished_102( );
   }
   
   void uScriptAct_PlaySound_Finished_104(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_Finished_104( );
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
         index = 0;
         properties = null;
         logic_uScriptCon_IntCounter_B_77 = local_1_System_Int32;
         index = 0;
         properties = null;
      }
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.In(logic_uScriptCon_IntCounter_A_77, logic_uScriptCon_IntCounter_B_77, out logic_uScriptCon_IntCounter_currentValue_77);
      SyncUnityHooks( );
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.GreaterThan == true )
      {
         Relay_In_82();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.GreaterThanOrEqualTo == true )
      {
         Relay_In_93();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_77.EqualTo == true )
      {
         Relay_In_79();
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
   
   void Relay_Finished_78()
   {
   }
   
   void Relay_Play_78()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_78.Play(logic_uScriptAct_PlaySound_audioClip_78, logic_uScriptAct_PlaySound_target_78, logic_uScriptAct_PlaySound_volume_78, logic_uScriptAct_PlaySound_loop_78);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_78.Out == true )
      {
         Relay_In_103();
      }
   }
   
   void Relay_Stop_78()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_78.Stop(logic_uScriptAct_PlaySound_audioClip_78, logic_uScriptAct_PlaySound_target_78, logic_uScriptAct_PlaySound_volume_78, logic_uScriptAct_PlaySound_loop_78);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_78.Out == true )
      {
         Relay_In_103();
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
         if ( logic_uScriptAct_DestroyComponent_Target_81.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_DestroyComponent_Target_81, index + 1);
         }
         logic_uScriptAct_DestroyComponent_Target_81[ index++ ] = local_Monster_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         if ( logic_uScriptAct_DestroyComponent_ComponentName_81.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_DestroyComponent_ComponentName_81, index + 1);
         }
         logic_uScriptAct_DestroyComponent_ComponentName_81[ index++ ] = local_20_System_String;
         
         index = 0;
         properties = null;
      }
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_81.In(logic_uScriptAct_DestroyComponent_Target_81, logic_uScriptAct_DestroyComponent_ComponentName_81, logic_uScriptAct_DestroyComponent_DelayTime_81);
      SyncUnityHooks( );
      if ( logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_81.Out == true )
      {
         Relay_In_77();
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
         index = 0;
         properties = null;
      }
      logic_uScriptAct_Log_uScriptAct_Log_82.In(logic_uScriptAct_Log_Prefix_82, logic_uScriptAct_Log_Target_82, logic_uScriptAct_Log_Postfix_82);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_82.Out == true )
      {
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
         index = 0;
         properties = null;
         if ( logic_uScriptAct_Log_Target_83.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Log_Target_83, index + 1);
         }
         logic_uScriptAct_Log_Target_83[ index++ ] = local_Cover3_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
      }
      logic_uScriptAct_Log_uScriptAct_Log_83.In(logic_uScriptAct_Log_Prefix_83, logic_uScriptAct_Log_Target_83, logic_uScriptAct_Log_Postfix_83);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_83.Out == true )
      {
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
         logic_uScriptCon_IntCounter_B_84 = local_31_System_Int32;
         index = 0;
         properties = null;
      }
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_84.In(logic_uScriptCon_IntCounter_A_84, logic_uScriptCon_IntCounter_B_84, out logic_uScriptCon_IntCounter_currentValue_84);
      SyncUnityHooks( );
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_84.GreaterThan == true )
      {
         Relay_In_91();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_84.GreaterThanOrEqualTo == true )
      {
         Relay_In_92();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_84.EqualTo == true )
      {
         Relay_In_76();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_84.LessThanOrEqualTo == true )
      {
         Relay_In_89();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_84.LessThan == true )
      {
         Relay_In_89();
      }
   }
   
   void Relay_In_85()
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
         if ( logic_uScriptAct_Teleport_Target_85.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Teleport_Target_85, index + 1);
         }
         logic_uScriptAct_Teleport_Target_85[ index++ ] = local_63_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         index = 0;
         properties = null;
      }
      logic_uScriptAct_Teleport_uScriptAct_Teleport_85.In(logic_uScriptAct_Teleport_Target_85, logic_uScriptAct_Teleport_Destination_85, logic_uScriptAct_Teleport_UpdateRotation_85);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Teleport_uScriptAct_Teleport_85.Out == true )
      {
         Relay_In_80();
      }
   }
   
   void Relay_AfterDelay_86()
   {
      Relay_In_83();
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
         logic_uScriptAct_Delay_Duration_86 = local_66_System_Single;
      }
      logic_uScriptAct_Delay_uScriptAct_Delay_86.In(logic_uScriptAct_Delay_Duration_86);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Delay_uScriptAct_Delay_86.Immediate == true )
      {
         Relay_In_80();
      }
   }
   
   void Relay_AfterDelay_87()
   {
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
         Relay_In_101();
      }
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
         logic_uScriptAct_DestroyComponent_ComponentName_88[ index++ ] = local_0_System_String;
         
         index = 0;
         properties = null;
      }
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_88.In(logic_uScriptAct_DestroyComponent_Target_88, logic_uScriptAct_DestroyComponent_ComponentName_88, logic_uScriptAct_DestroyComponent_DelayTime_88);
      SyncUnityHooks( );
      if ( logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_88.Out == true )
      {
         Relay_In_84();
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
         index = 0;
         properties = null;
         index = 0;
         properties = null;
      }
      logic_uScriptAct_Log_uScriptAct_Log_89.In(logic_uScriptAct_Log_Prefix_89, logic_uScriptAct_Log_Target_89, logic_uScriptAct_Log_Postfix_89);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_89.Out == true )
      {
      }
   }
   
   void Relay_OnOut_90()
   {
   }
   
   void Relay_OffOut_90()
   {
   }
   
   void Relay_ToggleOut_90()
   {
   }
   
   void Relay_TurnOn_90()
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
         if ( logic_uScriptAct_Toggle_Target_90.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_90, index + 1);
         }
         logic_uScriptAct_Toggle_Target_90[ index++ ] = local_Cover2_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_Toggle_Target_90.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_90, index + 1);
         }
         logic_uScriptAct_Toggle_Target_90[ index++ ] = local_Cover1_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
      }
      logic_uScriptAct_Toggle_uScriptAct_Toggle_90.TurnOn(logic_uScriptAct_Toggle_Target_90, logic_uScriptAct_Toggle_IgnoreChildren_90);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Toggle_uScriptAct_Toggle_90.Out == true )
      {
         Relay_In_86();
      }
   }
   
   void Relay_TurnOff_90()
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
         if ( logic_uScriptAct_Toggle_Target_90.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_90, index + 1);
         }
         logic_uScriptAct_Toggle_Target_90[ index++ ] = local_Cover2_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_Toggle_Target_90.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_90, index + 1);
         }
         logic_uScriptAct_Toggle_Target_90[ index++ ] = local_Cover1_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
      }
      logic_uScriptAct_Toggle_uScriptAct_Toggle_90.TurnOff(logic_uScriptAct_Toggle_Target_90, logic_uScriptAct_Toggle_IgnoreChildren_90);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Toggle_uScriptAct_Toggle_90.Out == true )
      {
         Relay_In_86();
      }
   }
   
   void Relay_Toggle_90()
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
         if ( logic_uScriptAct_Toggle_Target_90.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_90, index + 1);
         }
         logic_uScriptAct_Toggle_Target_90[ index++ ] = local_Cover2_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_Toggle_Target_90.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_90, index + 1);
         }
         logic_uScriptAct_Toggle_Target_90[ index++ ] = local_Cover1_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
      }
      logic_uScriptAct_Toggle_uScriptAct_Toggle_90.Toggle(logic_uScriptAct_Toggle_Target_90, logic_uScriptAct_Toggle_IgnoreChildren_90);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Toggle_uScriptAct_Toggle_90.Out == true )
      {
         Relay_In_86();
      }
   }
   
   void Relay_In_91()
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
         if ( logic_uScriptAct_Concatenate_A_94.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Concatenate_A_94, index + 1);
         }
         logic_uScriptAct_Concatenate_A_94[ index++ ] = local_39_System_String;
         
         index = 0;
         properties = null;
         if ( logic_uScriptAct_Concatenate_B_94.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Concatenate_B_94, index + 1);
         }
         logic_uScriptAct_Concatenate_B_94[ index++ ] = local_3_System_Int32;
         
         index = 0;
         properties = null;
         index = 0;
         properties = null;
      }
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_94.In(logic_uScriptAct_Concatenate_A_94, logic_uScriptAct_Concatenate_B_94, logic_uScriptAct_Concatenate_Separator_94, out logic_uScriptAct_Concatenate_Result_94);
      local_52_System_String = logic_uScriptAct_Concatenate_Result_94;
      SyncUnityHooks( );
      if ( logic_uScriptAct_Concatenate_uScriptAct_Concatenate_94.Out == true )
      {
         Relay_Play_104();
         Relay_In_85();
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
         if ( logic_uScriptAct_LookAt_Target_95.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_95, index + 1);
         }
         logic_uScriptAct_LookAt_Target_95[ index++ ] = local_56_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_95.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_95, index + 1);
         }
         logic_uScriptAct_LookAt_Target_95[ index++ ] = local_54_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_95.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_95, index + 1);
         }
         logic_uScriptAct_LookAt_Target_95[ index++ ] = local_45_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_95.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_95, index + 1);
         }
         logic_uScriptAct_LookAt_Target_95[ index++ ] = local_27_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_95.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_95, index + 1);
         }
         logic_uScriptAct_LookAt_Target_95[ index++ ] = local_15_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
      }
      logic_uScriptAct_LookAt_uScriptAct_LookAt_95.In(logic_uScriptAct_LookAt_Target_95, logic_uScriptAct_LookAt_Focus_95);
      SyncUnityHooks( );
      if ( logic_uScriptAct_LookAt_uScriptAct_LookAt_95.Out == true )
      {
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
         logic_uScriptAct_LookAt_Target_96[ index++ ] = local_41_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_96.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_96, index + 1);
         }
         logic_uScriptAct_LookAt_Target_96[ index++ ] = local_62_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_96.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_96, index + 1);
         }
         logic_uScriptAct_LookAt_Target_96[ index++ ] = local_43_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_96.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_96, index + 1);
         }
         logic_uScriptAct_LookAt_Target_96[ index++ ] = local_9_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_96.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_96, index + 1);
         }
         logic_uScriptAct_LookAt_Target_96[ index++ ] = local_44_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
      }
      logic_uScriptAct_LookAt_uScriptAct_LookAt_96.In(logic_uScriptAct_LookAt_Target_96, logic_uScriptAct_LookAt_Focus_96);
      SyncUnityHooks( );
      if ( logic_uScriptAct_LookAt_uScriptAct_LookAt_96.Out == true )
      {
      }
   }
   
   void Relay_KeyEvent_105()
   {
      SyncUnityHooks( );
      Relay_In_97();
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
      }
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_97.In(logic_uScriptAct_OnInputEventFilter_KeyCode_97);
      SyncUnityHooks( );
      if ( logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_97.KeyHeld == true )
      {
      }
      if ( logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_97.KeyDown == true )
      {
         Relay_Play_78();
      }
      if ( logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_97.KeyUp == true )
      {
         Relay_In_81();
      }
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
         logic_uScriptCon_CompareBool_Bool_98 = local_13_System_Boolean;
      }
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_98.In(logic_uScriptCon_CompareBool_Bool_98);
      SyncUnityHooks( );
      if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_98.True == true )
      {
      }
      if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_98.False == true )
      {
         Relay_In_96();
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
      Relay_In_100();
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
      }
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_100.In(logic_uScriptAct_OnInputEventFilter_KeyCode_100);
      SyncUnityHooks( );
      if ( logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_100.KeyHeld == true )
      {
      }
      if ( logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_100.KeyDown == true )
      {
         Relay_In_88();
      }
      if ( logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_100.KeyUp == true )
      {
         Relay_Play_102();
      }
   }
   
   void Relay_In_101()
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
         logic_uScriptCon_IntCounter_A_101 = local_35_System_Int32;
         index = 0;
         properties = null;
         logic_uScriptCon_IntCounter_B_101 = local_34_System_Int32;
         index = 0;
         properties = null;
      }
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_101.In(logic_uScriptCon_IntCounter_A_101, logic_uScriptCon_IntCounter_B_101, out logic_uScriptCon_IntCounter_currentValue_101);
      local_3_System_Int32 = logic_uScriptCon_IntCounter_currentValue_101;
      SyncUnityHooks( );
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_101.GreaterThan == true )
      {
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_101.GreaterThanOrEqualTo == true )
      {
         Relay_In_94();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_101.EqualTo == true )
      {
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_101.LessThanOrEqualTo == true )
      {
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_101.LessThan == true )
      {
      }
   }
   
   void Relay_Finished_102()
   {
   }
   
   void Relay_Play_102()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_102.Play(logic_uScriptAct_PlaySound_audioClip_102, logic_uScriptAct_PlaySound_target_102, logic_uScriptAct_PlaySound_volume_102, logic_uScriptAct_PlaySound_loop_102);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_102.Out == true )
      {
         Relay_In_98();
      }
   }
   
   void Relay_Stop_102()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_102.Stop(logic_uScriptAct_PlaySound_audioClip_102, logic_uScriptAct_PlaySound_target_102, logic_uScriptAct_PlaySound_volume_102, logic_uScriptAct_PlaySound_loop_102);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_102.Out == true )
      {
         Relay_In_98();
      }
   }
   
   void Relay_In_103()
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
         logic_uScriptCon_CompareBool_Bool_103 = local_8_System_Boolean;
      }
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_103.In(logic_uScriptCon_CompareBool_Bool_103);
      SyncUnityHooks( );
      if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_103.True == true )
      {
      }
      if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_103.False == true )
      {
         Relay_In_95();
      }
   }
   
   void Relay_Finished_104()
   {
   }
   
   void Relay_Play_104()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_104.Play(logic_uScriptAct_PlaySound_audioClip_104, logic_uScriptAct_PlaySound_target_104, logic_uScriptAct_PlaySound_volume_104, logic_uScriptAct_PlaySound_loop_104);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_104.Out == true )
      {
      }
   }
   
   void Relay_Stop_104()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_104.Stop(logic_uScriptAct_PlaySound_audioClip_104, logic_uScriptAct_PlaySound_target_104, logic_uScriptAct_PlaySound_volume_104, logic_uScriptAct_PlaySound_loop_104);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_104.Out == true )
      {
      }
   }
   
}
