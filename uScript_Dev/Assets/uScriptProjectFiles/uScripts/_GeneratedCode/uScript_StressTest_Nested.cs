//uScript Generated Code - Build 0.3.110514a
using UnityEngine;
using System.Collections;

public class uScript_StressTest_Nested : uScriptLogic
{

   #pragma warning disable 414
   GameObject parentGameObject = null;
   //external output properties
   
   //externally exposed events
   
   //external parameters
   
   //local nodes
   System.String local_0_System_String = "Area Damage";
   System.Int32 local_1_System_Int32 = (int) 0;
   UnityEngine.GameObject local_2_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_2_UnityEngine_GameObject_previous = null;
   System.Int32 local_3_System_Int32 = (int) 0;
   UnityEngine.GameObject local_4_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_4_UnityEngine_GameObject_previous = null;
   System.Boolean local_5_System_Boolean = (bool) false;
   UnityEngine.GameObject local_6_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_6_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Cover3_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Cover3_UnityEngine_GameObject_previous = null;
   System.Boolean local_7_System_Boolean = (bool) false;
   UnityEngine.GameObject local_8_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_8_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_9_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_9_UnityEngine_GameObject_previous = null;
   System.String local_10_System_String = "Area Damage";
   UnityEngine.GameObject local_11_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_11_UnityEngine_GameObject_previous = null;
   System.Int32 local_12_System_Int32 = (int) 0;
   System.Int32 local_13_System_Int32 = (int) 0;
   UnityEngine.GameObject local_14_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_14_UnityEngine_GameObject_previous = null;
   System.Int32 local_15_System_Int32 = (int) 0;
   UnityEngine.GameObject local_Cover1_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Cover1_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_16_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_16_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_17_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_17_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_18_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_18_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Cover2_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Cover2_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Monster_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Monster_UnityEngine_GameObject_previous = null;
   System.String local_19_System_String = "";
   UnityEngine.GameObject local_20_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_20_UnityEngine_GameObject_previous = null;
   System.String local_21_System_String = "Ogre";
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_26 = null;
   System.String logic_uScriptAct_Log_Prefix_26 = "";
   System.Object[] logic_uScriptAct_Log_Target_26 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_26 = "";
   bool logic_uScriptAct_Log_Out_26 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_27 = null;
   System.Int32 logic_uScriptCon_IntCounter_A_27 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_B_27 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_27;
   bool logic_uScriptCon_IntCounter_GreaterThan_27 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_27 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_27 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_27 = true;
   bool logic_uScriptCon_IntCounter_LessThan_27 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_28 = null;
   System.String logic_uScriptAct_Log_Prefix_28 = "";
   System.Object[] logic_uScriptAct_Log_Target_28 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_28 = "";
   bool logic_uScriptAct_Log_Out_28 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_29 = null;
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_29 = null;
   UnityEngine.GameObject logic_uScriptAct_PlaySound_target_29 = null;
   System.Single logic_uScriptAct_PlaySound_volume_29 = (float) 0;
   System.Boolean logic_uScriptAct_PlaySound_loop_29 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_29 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_30 = null;
   System.String logic_uScriptAct_Log_Prefix_30 = "Trigger Fired!";
   System.Object[] logic_uScriptAct_Log_Target_30 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_30 = "";
   bool logic_uScriptAct_Log_Out_30 = true;
   //pointer to script instanced logic node
   uScriptAct_OnKeyPressFilter logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_31 = null;
   UnityEngine.KeyCode logic_uScriptAct_OnKeyPressFilter_KeyCode_31 = UnityEngine.KeyCode.None;
   bool logic_uScriptAct_OnKeyPressFilter_KeyHeld_31 = true;
   bool logic_uScriptAct_OnKeyPressFilter_KeyDown_31 = true;
   bool logic_uScriptAct_OnKeyPressFilter_KeyUp_31 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_32 = null;
   System.Int32 logic_uScriptCon_IntCounter_A_32 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_B_32 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_32;
   bool logic_uScriptCon_IntCounter_GreaterThan_32 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_32 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_32 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_32 = true;
   bool logic_uScriptCon_IntCounter_LessThan_32 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_33 = null;
   System.String logic_uScriptAct_Log_Prefix_33 = "";
   System.Object[] logic_uScriptAct_Log_Target_33 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_33 = "";
   bool logic_uScriptAct_Log_Out_33 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_34 = null;
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_34 = null;
   UnityEngine.GameObject logic_uScriptAct_PlaySound_target_34 = null;
   System.Single logic_uScriptAct_PlaySound_volume_34 = (float) 0;
   System.Boolean logic_uScriptAct_PlaySound_loop_34 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_34 = true;
   //pointer to script instanced logic node
   uScriptAct_OnKeyPressFilter logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_35 = null;
   UnityEngine.KeyCode logic_uScriptAct_OnKeyPressFilter_KeyCode_35 = UnityEngine.KeyCode.None;
   bool logic_uScriptAct_OnKeyPressFilter_KeyHeld_35 = true;
   bool logic_uScriptAct_OnKeyPressFilter_KeyDown_35 = true;
   bool logic_uScriptAct_OnKeyPressFilter_KeyUp_35 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_36 = null;
   System.String logic_uScriptAct_Log_Prefix_36 = "";
   System.Object[] logic_uScriptAct_Log_Target_36 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_36 = "";
   bool logic_uScriptAct_Log_Out_36 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_37 = null;
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_37 = null;
   UnityEngine.GameObject logic_uScriptAct_PlaySound_target_37 = null;
   System.Single logic_uScriptAct_PlaySound_volume_37 = (float) 0;
   System.Boolean logic_uScriptAct_PlaySound_loop_37 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_37 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_38 = null;
   System.Single logic_uScriptAct_Delay_Duration_38 = (float) 0;
   bool logic_uScriptAct_Delay_Immediate_38 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_39 = null;
   System.Single logic_uScriptAct_Delay_Duration_39 = (float) 0;
   bool logic_uScriptAct_Delay_Immediate_39 = true;
   //pointer to script instanced logic node
   uScriptAct_DestroyComponent logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_40 = null;
   UnityEngine.GameObject[] logic_uScriptAct_DestroyComponent_Target_40 = new UnityEngine.GameObject[] {null};
   System.String[] logic_uScriptAct_DestroyComponent_ComponentName_40 = new System.String[] {""};
   System.Single logic_uScriptAct_DestroyComponent_DelayTime_40 = (float) 0;
   bool logic_uScriptAct_DestroyComponent_Out_40 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_41 = null;
   System.String logic_uScriptAct_Log_Prefix_41 = "";
   System.Object[] logic_uScriptAct_Log_Target_41 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_41 = "";
   bool logic_uScriptAct_Log_Out_41 = true;
   //pointer to script instanced logic node
   uScriptAct_DestroyComponent logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_42 = null;
   UnityEngine.GameObject[] logic_uScriptAct_DestroyComponent_Target_42 = new UnityEngine.GameObject[] {null};
   System.String[] logic_uScriptAct_DestroyComponent_ComponentName_42 = new System.String[] {""};
   System.Single logic_uScriptAct_DestroyComponent_DelayTime_42 = (float) 0;
   bool logic_uScriptAct_DestroyComponent_Out_42 = true;
   //pointer to script instanced logic node
   uScriptAct_Toggle logic_uScriptAct_Toggle_uScriptAct_Toggle_43 = null;
   UnityEngine.GameObject[] logic_uScriptAct_Toggle_Target_43 = new UnityEngine.GameObject[] {null};
   System.Boolean logic_uScriptAct_Toggle_IgnoreChildren_43 = (bool) false;
   bool logic_uScriptAct_Toggle_Out_43 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_44 = null;
   System.String logic_uScriptAct_Log_Prefix_44 = "";
   System.Object[] logic_uScriptAct_Log_Target_44 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_44 = "";
   bool logic_uScriptAct_Log_Out_44 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_45 = null;
   System.String logic_uScriptAct_Log_Prefix_45 = "";
   System.Object[] logic_uScriptAct_Log_Target_45 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_45 = "";
   bool logic_uScriptAct_Log_Out_45 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_46 = null;
   System.String logic_uScriptAct_Log_Prefix_46 = "";
   System.Object[] logic_uScriptAct_Log_Target_46 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_46 = "";
   bool logic_uScriptAct_Log_Out_46 = true;
   //pointer to script instanced logic node
   uScriptAct_LookAt logic_uScriptAct_LookAt_uScriptAct_LookAt_47 = null;
   UnityEngine.GameObject[] logic_uScriptAct_LookAt_Target_47 = new UnityEngine.GameObject[] {null};
   System.Object logic_uScriptAct_LookAt_Focus_47 = "";
   bool logic_uScriptAct_LookAt_Out_47 = true;
   //pointer to script instanced logic node
   uScriptAct_LookAt logic_uScriptAct_LookAt_uScriptAct_LookAt_48 = null;
   UnityEngine.GameObject[] logic_uScriptAct_LookAt_Target_48 = new UnityEngine.GameObject[] {null};
   System.Object logic_uScriptAct_LookAt_Focus_48 = "";
   bool logic_uScriptAct_LookAt_Out_48 = true;
   //pointer to script instanced logic node
   uScriptAct_Teleport logic_uScriptAct_Teleport_uScriptAct_Teleport_49 = null;
   UnityEngine.GameObject[] logic_uScriptAct_Teleport_Target_49 = new UnityEngine.GameObject[] {null};
   UnityEngine.GameObject logic_uScriptAct_Teleport_Destination_49 = null;
   System.Boolean logic_uScriptAct_Teleport_UpdateRotation_49 = (bool) false;
   bool logic_uScriptAct_Teleport_Out_49 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_50 = null;
   System.Boolean logic_uScriptCon_CompareBool_Bool_50 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_50 = true;
   bool logic_uScriptCon_CompareBool_False_50 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_51 = null;
   System.String logic_uScriptAct_Log_Prefix_51 = "";
   System.Object[] logic_uScriptAct_Log_Target_51 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_51 = "";
   bool logic_uScriptAct_Log_Out_51 = true;
   //pointer to script instanced logic node
   uScriptAct_Concatenate logic_uScriptAct_Concatenate_uScriptAct_Concatenate_52 = null;
   System.Object[] logic_uScriptAct_Concatenate_A_52 = new System.Object[] {""};
   System.Object[] logic_uScriptAct_Concatenate_B_52 = new System.Object[] {""};
   System.String logic_uScriptAct_Concatenate_Separator_52 = "";
   System.String logic_uScriptAct_Concatenate_Result_52;
   bool logic_uScriptAct_Concatenate_Out_52 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_53 = null;
   System.Int32 logic_uScriptCon_IntCounter_A_53 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_B_53 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_53;
   bool logic_uScriptCon_IntCounter_GreaterThan_53 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_53 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_53 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_53 = true;
   bool logic_uScriptCon_IntCounter_LessThan_53 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_54 = null;
   System.Boolean logic_uScriptCon_CompareBool_Bool_54 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_54 = true;
   bool logic_uScriptCon_CompareBool_False_54 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_55 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_56 = null;
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      if ( null == event_UnityEngine_GameObject_Instance_55 )
      {
         event_UnityEngine_GameObject_Instance_55 = GameObject.Find( "_uScript" ) as UnityEngine.GameObject;
         if ( null != event_UnityEngine_GameObject_Instance_55 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_55.GetComponent<uScript_Input>();
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_55;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_56 )
      {
         event_UnityEngine_GameObject_Instance_56 = GameObject.Find( "_uScript" ) as UnityEngine.GameObject;
         if ( null != event_UnityEngine_GameObject_Instance_56 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_56.GetComponent<uScript_Input>();
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_56;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_2_UnityEngine_GameObject_previous != local_2_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_2_UnityEngine_GameObject_previous )
         {
         }
         
         local_2_UnityEngine_GameObject_previous = local_2_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_2_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_4_UnityEngine_GameObject_previous != local_4_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_4_UnityEngine_GameObject_previous )
         {
         }
         
         local_4_UnityEngine_GameObject_previous = local_4_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_4_UnityEngine_GameObject )
         {
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_6_UnityEngine_GameObject_previous != local_6_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_6_UnityEngine_GameObject_previous )
         {
         }
         
         local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_6_UnityEngine_GameObject )
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
      if ( local_8_UnityEngine_GameObject_previous != local_8_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_8_UnityEngine_GameObject_previous )
         {
         }
         
         local_8_UnityEngine_GameObject_previous = local_8_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_8_UnityEngine_GameObject )
         {
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
      if ( local_14_UnityEngine_GameObject_previous != local_14_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_14_UnityEngine_GameObject_previous )
         {
         }
         
         local_14_UnityEngine_GameObject_previous = local_14_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_14_UnityEngine_GameObject )
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
      if ( local_17_UnityEngine_GameObject_previous != local_17_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_17_UnityEngine_GameObject_previous )
         {
         }
         
         local_17_UnityEngine_GameObject_previous = local_17_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_17_UnityEngine_GameObject )
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
      if ( local_20_UnityEngine_GameObject_previous != local_20_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_20_UnityEngine_GameObject_previous )
         {
         }
         
         local_20_UnityEngine_GameObject_previous = local_20_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_20_UnityEngine_GameObject )
         {
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      SyncUnityHooks( );
      
      logic_uScriptAct_Log_uScriptAct_Log_26.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_27.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_28.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_29.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_30.SetParent(g);
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_31.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_32.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_33.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_34.SetParent(g);
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_35.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_36.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_37.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_38.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_39.SetParent(g);
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_40.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_41.SetParent(g);
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_42.SetParent(g);
      logic_uScriptAct_Toggle_uScriptAct_Toggle_43.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_44.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_45.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_46.SetParent(g);
      logic_uScriptAct_LookAt_uScriptAct_LookAt_47.SetParent(g);
      logic_uScriptAct_LookAt_uScriptAct_LookAt_48.SetParent(g);
      logic_uScriptAct_Teleport_uScriptAct_Teleport_49.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_50.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_51.SetParent(g);
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_52.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_53.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_54.SetParent(g);
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
      
      logic_uScriptAct_Log_uScriptAct_Log_26 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_27 = ScriptableObject.CreateInstance(typeof(uScriptCon_IntCounter)) as uScriptCon_IntCounter;
      logic_uScriptAct_Log_uScriptAct_Log_28 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_29 = ScriptableObject.CreateInstance(typeof(uScriptAct_PlaySound)) as uScriptAct_PlaySound;
      logic_uScriptAct_Log_uScriptAct_Log_30 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_31 = ScriptableObject.CreateInstance(typeof(uScriptAct_OnKeyPressFilter)) as uScriptAct_OnKeyPressFilter;
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_32 = ScriptableObject.CreateInstance(typeof(uScriptCon_IntCounter)) as uScriptCon_IntCounter;
      logic_uScriptAct_Log_uScriptAct_Log_33 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_34 = ScriptableObject.CreateInstance(typeof(uScriptAct_PlaySound)) as uScriptAct_PlaySound;
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_35 = ScriptableObject.CreateInstance(typeof(uScriptAct_OnKeyPressFilter)) as uScriptAct_OnKeyPressFilter;
      logic_uScriptAct_Log_uScriptAct_Log_36 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_37 = ScriptableObject.CreateInstance(typeof(uScriptAct_PlaySound)) as uScriptAct_PlaySound;
      logic_uScriptAct_Delay_uScriptAct_Delay_38 = ScriptableObject.CreateInstance(typeof(uScriptAct_Delay)) as uScriptAct_Delay;
      logic_uScriptAct_Delay_uScriptAct_Delay_39 = ScriptableObject.CreateInstance(typeof(uScriptAct_Delay)) as uScriptAct_Delay;
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_40 = ScriptableObject.CreateInstance(typeof(uScriptAct_DestroyComponent)) as uScriptAct_DestroyComponent;
      logic_uScriptAct_Log_uScriptAct_Log_41 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_42 = ScriptableObject.CreateInstance(typeof(uScriptAct_DestroyComponent)) as uScriptAct_DestroyComponent;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_43 = ScriptableObject.CreateInstance(typeof(uScriptAct_Toggle)) as uScriptAct_Toggle;
      logic_uScriptAct_Log_uScriptAct_Log_44 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_45 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_46 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_LookAt_uScriptAct_LookAt_47 = ScriptableObject.CreateInstance(typeof(uScriptAct_LookAt)) as uScriptAct_LookAt;
      logic_uScriptAct_LookAt_uScriptAct_LookAt_48 = ScriptableObject.CreateInstance(typeof(uScriptAct_LookAt)) as uScriptAct_LookAt;
      logic_uScriptAct_Teleport_uScriptAct_Teleport_49 = ScriptableObject.CreateInstance(typeof(uScriptAct_Teleport)) as uScriptAct_Teleport;
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_50 = ScriptableObject.CreateInstance(typeof(uScriptCon_CompareBool)) as uScriptCon_CompareBool;
      logic_uScriptAct_Log_uScriptAct_Log_51 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_52 = ScriptableObject.CreateInstance(typeof(uScriptAct_Concatenate)) as uScriptAct_Concatenate;
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_53 = ScriptableObject.CreateInstance(typeof(uScriptCon_IntCounter)) as uScriptCon_IntCounter;
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_54 = ScriptableObject.CreateInstance(typeof(uScriptCon_CompareBool)) as uScriptCon_CompareBool;
      
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_29.Finished += uScriptAct_PlaySound_Finished_29;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_34.Finished += uScriptAct_PlaySound_Finished_34;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_37.Finished += uScriptAct_PlaySound_Finished_37;
      logic_uScriptAct_Delay_uScriptAct_Delay_38.AfterDelay += uScriptAct_Delay_AfterDelay_38;
      logic_uScriptAct_Delay_uScriptAct_Delay_39.AfterDelay += uScriptAct_Delay_AfterDelay_39;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_43.OnOut += uScriptAct_Toggle_OnOut_43;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_43.OffOut += uScriptAct_Toggle_OffOut_43;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_43.ToggleOut += uScriptAct_Toggle_ToggleOut_43;
   }
   
   public override void Update()
   {
      logic_uScriptAct_Log_uScriptAct_Log_26.Update( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_27.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_28.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_29.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_30.Update( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_31.Update( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_32.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_33.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_34.Update( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_35.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_36.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_37.Update( );
      logic_uScriptAct_Delay_uScriptAct_Delay_38.Update( );
      logic_uScriptAct_Delay_uScriptAct_Delay_39.Update( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_40.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_41.Update( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_42.Update( );
      logic_uScriptAct_Toggle_uScriptAct_Toggle_43.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_44.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_45.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_46.Update( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_47.Update( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_48.Update( );
      logic_uScriptAct_Teleport_uScriptAct_Teleport_49.Update( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_50.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_51.Update( );
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_52.Update( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_53.Update( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_54.Update( );
   }
   
   public override void LateUpdate()
   {
      logic_uScriptAct_Log_uScriptAct_Log_26.LateUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_27.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_28.LateUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_29.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_30.LateUpdate( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_31.LateUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_32.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_33.LateUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_34.LateUpdate( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_35.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_36.LateUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_37.LateUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_38.LateUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_39.LateUpdate( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_40.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_41.LateUpdate( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_42.LateUpdate( );
      logic_uScriptAct_Toggle_uScriptAct_Toggle_43.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_44.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_45.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_46.LateUpdate( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_47.LateUpdate( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_48.LateUpdate( );
      logic_uScriptAct_Teleport_uScriptAct_Teleport_49.LateUpdate( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_50.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_51.LateUpdate( );
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_52.LateUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_53.LateUpdate( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_54.LateUpdate( );
   }
   
   public override void FixedUpdate()
   {
      logic_uScriptAct_Log_uScriptAct_Log_26.FixedUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_27.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_28.FixedUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_29.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_30.FixedUpdate( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_31.FixedUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_32.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_33.FixedUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_34.FixedUpdate( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_35.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_36.FixedUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_37.FixedUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_38.FixedUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_39.FixedUpdate( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_40.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_41.FixedUpdate( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_42.FixedUpdate( );
      logic_uScriptAct_Toggle_uScriptAct_Toggle_43.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_44.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_45.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_46.FixedUpdate( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_47.FixedUpdate( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_48.FixedUpdate( );
      logic_uScriptAct_Teleport_uScriptAct_Teleport_49.FixedUpdate( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_50.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_51.FixedUpdate( );
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_52.FixedUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_53.FixedUpdate( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_54.FixedUpdate( );
   }
   
   public override void OnGUI()
   {
      logic_uScriptAct_Log_uScriptAct_Log_26.OnGUI( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_27.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_28.OnGUI( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_29.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_30.OnGUI( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_31.OnGUI( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_32.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_33.OnGUI( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_34.OnGUI( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_35.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_36.OnGUI( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_37.OnGUI( );
      logic_uScriptAct_Delay_uScriptAct_Delay_38.OnGUI( );
      logic_uScriptAct_Delay_uScriptAct_Delay_39.OnGUI( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_40.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_41.OnGUI( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_42.OnGUI( );
      logic_uScriptAct_Toggle_uScriptAct_Toggle_43.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_44.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_45.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_46.OnGUI( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_47.OnGUI( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_48.OnGUI( );
      logic_uScriptAct_Teleport_uScriptAct_Teleport_49.OnGUI( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_50.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_51.OnGUI( );
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_52.OnGUI( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_53.OnGUI( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_54.OnGUI( );
   }
   
   void Instance_KeyEvent_55(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_55( );
   }
   
   void Instance_KeyEvent_56(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_56( );
   }
   
   void uScriptAct_PlaySound_Finished_29(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_Finished_29( );
   }
   
   void uScriptAct_PlaySound_Finished_34(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_Finished_34( );
   }
   
   void uScriptAct_PlaySound_Finished_37(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_Finished_37( );
   }
   
   void uScriptAct_Delay_AfterDelay_38(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_AfterDelay_38( );
   }
   
   void uScriptAct_Delay_AfterDelay_39(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_AfterDelay_39( );
   }
   
   void uScriptAct_Toggle_OnOut_43(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_OnOut_43( );
   }
   
   void uScriptAct_Toggle_OffOut_43(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_OffOut_43( );
   }
   
   void uScriptAct_Toggle_ToggleOut_43(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_ToggleOut_43( );
   }
   
   void Relay_In_26()
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
      logic_uScriptAct_Log_uScriptAct_Log_26.In(logic_uScriptAct_Log_Prefix_26, logic_uScriptAct_Log_Target_26, logic_uScriptAct_Log_Postfix_26);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_26.Out == true )
      {
      }
   }
   
   void Relay_In_27()
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
         logic_uScriptCon_IntCounter_B_27 = local_1_System_Int32;
         index = 0;
         properties = null;
         }
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_27.In(logic_uScriptCon_IntCounter_A_27, logic_uScriptCon_IntCounter_B_27, out logic_uScriptCon_IntCounter_currentValue_27);
      SyncUnityHooks( );
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_27.GreaterThan == true )
      {
         Relay_In_33();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_27.GreaterThanOrEqualTo == true )
      {
         Relay_In_46();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_27.EqualTo == true )
      {
         Relay_In_36();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_27.LessThanOrEqualTo == true )
      {
         Relay_In_51();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_27.LessThan == true )
      {
         Relay_In_51();
      }
   }
   
   void Relay_In_28()
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
      logic_uScriptAct_Log_uScriptAct_Log_28.In(logic_uScriptAct_Log_Prefix_28, logic_uScriptAct_Log_Target_28, logic_uScriptAct_Log_Postfix_28);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_28.Out == true )
      {
      }
   }
   
   void Relay_Finished_29()
   {
   }
   
   void Relay_Play_29()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_29.Play(logic_uScriptAct_PlaySound_audioClip_29, logic_uScriptAct_PlaySound_target_29, logic_uScriptAct_PlaySound_volume_29, logic_uScriptAct_PlaySound_loop_29);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_29.Out == true )
      {
      }
   }
   
   void Relay_Stop_29()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_29.Stop(logic_uScriptAct_PlaySound_audioClip_29, logic_uScriptAct_PlaySound_target_29, logic_uScriptAct_PlaySound_volume_29, logic_uScriptAct_PlaySound_loop_29);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_29.Out == true )
      {
      }
   }
   
   void Relay_In_30()
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
         if ( logic_uScriptAct_Log_Target_30.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Log_Target_30, index + 1);
         }
         logic_uScriptAct_Log_Target_30[ index++ ] = local_Cover3_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         }
      logic_uScriptAct_Log_uScriptAct_Log_30.In(logic_uScriptAct_Log_Prefix_30, logic_uScriptAct_Log_Target_30, logic_uScriptAct_Log_Postfix_30);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_30.Out == true )
      {
      }
   }
   
   void Relay_In_31()
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
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_31.In(logic_uScriptAct_OnKeyPressFilter_KeyCode_31);
      SyncUnityHooks( );
      if ( logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_31.KeyHeld == true )
      {
      }
      if ( logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_31.KeyDown == true )
      {
         Relay_Stop_34();
         Relay_In_42();
      }
      if ( logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_31.KeyUp == true )
      {
      }
   }
   
   void Relay_In_32()
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
         logic_uScriptCon_IntCounter_B_32 = local_12_System_Int32;
         index = 0;
         properties = null;
         }
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_32.In(logic_uScriptCon_IntCounter_A_32, logic_uScriptCon_IntCounter_B_32, out logic_uScriptCon_IntCounter_currentValue_32);
      SyncUnityHooks( );
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_32.GreaterThan == true )
      {
         Relay_In_44();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_32.GreaterThanOrEqualTo == true )
      {
         Relay_In_45();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_32.EqualTo == true )
      {
         Relay_In_26();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_32.LessThanOrEqualTo == true )
      {
         Relay_In_41();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_32.LessThan == true )
      {
         Relay_In_41();
      }
   }
   
   void Relay_In_33()
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
      logic_uScriptAct_Log_uScriptAct_Log_33.In(logic_uScriptAct_Log_Prefix_33, logic_uScriptAct_Log_Target_33, logic_uScriptAct_Log_Postfix_33);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_33.Out == true )
      {
      }
   }
   
   void Relay_Finished_34()
   {
   }
   
   void Relay_Play_34()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_34.Play(logic_uScriptAct_PlaySound_audioClip_34, logic_uScriptAct_PlaySound_target_34, logic_uScriptAct_PlaySound_volume_34, logic_uScriptAct_PlaySound_loop_34);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_34.Out == true )
      {
         Relay_In_54();
      }
   }
   
   void Relay_Stop_34()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_34.Stop(logic_uScriptAct_PlaySound_audioClip_34, logic_uScriptAct_PlaySound_target_34, logic_uScriptAct_PlaySound_volume_34, logic_uScriptAct_PlaySound_loop_34);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_34.Out == true )
      {
         Relay_In_54();
      }
   }
   
   void Relay_In_35()
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
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_35.In(logic_uScriptAct_OnKeyPressFilter_KeyCode_35);
      SyncUnityHooks( );
      if ( logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_35.KeyHeld == true )
      {
      }
      if ( logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_35.KeyDown == true )
      {
         Relay_Stop_37();
         Relay_In_40();
      }
      if ( logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_35.KeyUp == true )
      {
      }
   }
   
   void Relay_In_36()
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
      logic_uScriptAct_Log_uScriptAct_Log_36.In(logic_uScriptAct_Log_Prefix_36, logic_uScriptAct_Log_Target_36, logic_uScriptAct_Log_Postfix_36);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_36.Out == true )
      {
      }
   }
   
   void Relay_Finished_37()
   {
   }
   
   void Relay_Play_37()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_37.Play(logic_uScriptAct_PlaySound_audioClip_37, logic_uScriptAct_PlaySound_target_37, logic_uScriptAct_PlaySound_volume_37, logic_uScriptAct_PlaySound_loop_37);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_37.Out == true )
      {
         Relay_In_50();
      }
   }
   
   void Relay_Stop_37()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_37.Stop(logic_uScriptAct_PlaySound_audioClip_37, logic_uScriptAct_PlaySound_target_37, logic_uScriptAct_PlaySound_volume_37, logic_uScriptAct_PlaySound_loop_37);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_37.Out == true )
      {
         Relay_In_50();
      }
   }
   
   void Relay_AfterDelay_38()
   {
      Relay_In_30();
   }
   
   void Relay_In_38()
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
      logic_uScriptAct_Delay_uScriptAct_Delay_38.In(logic_uScriptAct_Delay_Duration_38);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Delay_uScriptAct_Delay_38.Immediate == true )
      {
         Relay_In_28();
      }
   }
   
   void Relay_AfterDelay_39()
   {
   }
   
   void Relay_In_39()
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
      logic_uScriptAct_Delay_uScriptAct_Delay_39.In(logic_uScriptAct_Delay_Duration_39);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Delay_uScriptAct_Delay_39.Immediate == true )
      {
         Relay_In_53();
      }
   }
   
   void Relay_In_40()
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
         if ( logic_uScriptAct_DestroyComponent_Target_40.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_DestroyComponent_Target_40, index + 1);
         }
         logic_uScriptAct_DestroyComponent_Target_40[ index++ ] = local_Monster_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         if ( logic_uScriptAct_DestroyComponent_ComponentName_40.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_DestroyComponent_ComponentName_40, index + 1);
         }
         logic_uScriptAct_DestroyComponent_ComponentName_40[ index++ ] = local_0_System_String;
         
         index = 0;
         properties = null;
         }
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_40.In(logic_uScriptAct_DestroyComponent_Target_40, logic_uScriptAct_DestroyComponent_ComponentName_40, logic_uScriptAct_DestroyComponent_DelayTime_40);
      SyncUnityHooks( );
      if ( logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_40.Out == true )
      {
         Relay_In_32();
      }
   }
   
   void Relay_In_41()
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
      logic_uScriptAct_Log_uScriptAct_Log_41.In(logic_uScriptAct_Log_Prefix_41, logic_uScriptAct_Log_Target_41, logic_uScriptAct_Log_Postfix_41);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_41.Out == true )
      {
      }
   }
   
   void Relay_In_42()
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
         if ( logic_uScriptAct_DestroyComponent_Target_42.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_DestroyComponent_Target_42, index + 1);
         }
         logic_uScriptAct_DestroyComponent_Target_42[ index++ ] = local_Monster_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         if ( logic_uScriptAct_DestroyComponent_ComponentName_42.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_DestroyComponent_ComponentName_42, index + 1);
         }
         logic_uScriptAct_DestroyComponent_ComponentName_42[ index++ ] = local_10_System_String;
         
         index = 0;
         properties = null;
         }
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_42.In(logic_uScriptAct_DestroyComponent_Target_42, logic_uScriptAct_DestroyComponent_ComponentName_42, logic_uScriptAct_DestroyComponent_DelayTime_42);
      SyncUnityHooks( );
      if ( logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_42.Out == true )
      {
         Relay_In_27();
      }
   }
   
   void Relay_OnOut_43()
   {
   }
   
   void Relay_OffOut_43()
   {
   }
   
   void Relay_ToggleOut_43()
   {
   }
   
   void Relay_TurnOn_43()
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
         if ( logic_uScriptAct_Toggle_Target_43.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_43, index + 1);
         }
         logic_uScriptAct_Toggle_Target_43[ index++ ] = local_Cover1_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_Toggle_Target_43.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_43, index + 1);
         }
         logic_uScriptAct_Toggle_Target_43[ index++ ] = local_Cover2_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         }
      logic_uScriptAct_Toggle_uScriptAct_Toggle_43.TurnOn(logic_uScriptAct_Toggle_Target_43, logic_uScriptAct_Toggle_IgnoreChildren_43);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Toggle_uScriptAct_Toggle_43.Out == true )
      {
         Relay_In_38();
      }
   }
   
   void Relay_TurnOff_43()
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
         if ( logic_uScriptAct_Toggle_Target_43.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_43, index + 1);
         }
         logic_uScriptAct_Toggle_Target_43[ index++ ] = local_Cover1_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_Toggle_Target_43.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_43, index + 1);
         }
         logic_uScriptAct_Toggle_Target_43[ index++ ] = local_Cover2_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         }
      logic_uScriptAct_Toggle_uScriptAct_Toggle_43.TurnOff(logic_uScriptAct_Toggle_Target_43, logic_uScriptAct_Toggle_IgnoreChildren_43);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Toggle_uScriptAct_Toggle_43.Out == true )
      {
         Relay_In_38();
      }
   }
   
   void Relay_Toggle_43()
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
         if ( logic_uScriptAct_Toggle_Target_43.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_43, index + 1);
         }
         logic_uScriptAct_Toggle_Target_43[ index++ ] = local_Cover1_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_Toggle_Target_43.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_43, index + 1);
         }
         logic_uScriptAct_Toggle_Target_43[ index++ ] = local_Cover2_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         }
      logic_uScriptAct_Toggle_uScriptAct_Toggle_43.Toggle(logic_uScriptAct_Toggle_Target_43, logic_uScriptAct_Toggle_IgnoreChildren_43);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Toggle_uScriptAct_Toggle_43.Out == true )
      {
         Relay_In_38();
      }
   }
   
   void Relay_In_44()
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
      logic_uScriptAct_Log_uScriptAct_Log_44.In(logic_uScriptAct_Log_Prefix_44, logic_uScriptAct_Log_Target_44, logic_uScriptAct_Log_Postfix_44);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_44.Out == true )
      {
      }
   }
   
   void Relay_In_45()
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
      logic_uScriptAct_Log_uScriptAct_Log_45.In(logic_uScriptAct_Log_Prefix_45, logic_uScriptAct_Log_Target_45, logic_uScriptAct_Log_Postfix_45);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_45.Out == true )
      {
      }
   }
   
   void Relay_In_46()
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
      logic_uScriptAct_Log_uScriptAct_Log_46.In(logic_uScriptAct_Log_Prefix_46, logic_uScriptAct_Log_Target_46, logic_uScriptAct_Log_Postfix_46);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_46.Out == true )
      {
      }
   }
   
   void Relay_In_47()
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
         if ( logic_uScriptAct_LookAt_Target_47.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_47, index + 1);
         }
         logic_uScriptAct_LookAt_Target_47[ index++ ] = local_4_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_47.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_47, index + 1);
         }
         logic_uScriptAct_LookAt_Target_47[ index++ ] = local_20_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_47.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_47, index + 1);
         }
         logic_uScriptAct_LookAt_Target_47[ index++ ] = local_9_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_47.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_47, index + 1);
         }
         logic_uScriptAct_LookAt_Target_47[ index++ ] = local_11_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_47.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_47, index + 1);
         }
         logic_uScriptAct_LookAt_Target_47[ index++ ] = local_8_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         }
      logic_uScriptAct_LookAt_uScriptAct_LookAt_47.In(logic_uScriptAct_LookAt_Target_47, logic_uScriptAct_LookAt_Focus_47);
      SyncUnityHooks( );
      if ( logic_uScriptAct_LookAt_uScriptAct_LookAt_47.Out == true )
      {
      }
   }
   
   void Relay_In_48()
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
         if ( logic_uScriptAct_LookAt_Target_48.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_48, index + 1);
         }
         logic_uScriptAct_LookAt_Target_48[ index++ ] = local_16_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_48.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_48, index + 1);
         }
         logic_uScriptAct_LookAt_Target_48[ index++ ] = local_17_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_48.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_48, index + 1);
         }
         logic_uScriptAct_LookAt_Target_48[ index++ ] = local_18_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_48.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_48, index + 1);
         }
         logic_uScriptAct_LookAt_Target_48[ index++ ] = local_6_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_48.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_48, index + 1);
         }
         logic_uScriptAct_LookAt_Target_48[ index++ ] = local_2_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         }
      logic_uScriptAct_LookAt_uScriptAct_LookAt_48.In(logic_uScriptAct_LookAt_Target_48, logic_uScriptAct_LookAt_Focus_48);
      SyncUnityHooks( );
      if ( logic_uScriptAct_LookAt_uScriptAct_LookAt_48.Out == true )
      {
      }
   }
   
   void Relay_In_49()
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
         if ( logic_uScriptAct_Teleport_Target_49.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Teleport_Target_49, index + 1);
         }
         logic_uScriptAct_Teleport_Target_49[ index++ ] = local_14_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         index = 0;
         properties = null;
         }
      logic_uScriptAct_Teleport_uScriptAct_Teleport_49.In(logic_uScriptAct_Teleport_Target_49, logic_uScriptAct_Teleport_Destination_49, logic_uScriptAct_Teleport_UpdateRotation_49);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Teleport_uScriptAct_Teleport_49.Out == true )
      {
         Relay_In_28();
      }
   }
   
   void Relay_In_50()
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
         logic_uScriptCon_CompareBool_Bool_50 = local_7_System_Boolean;
         }
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_50.In(logic_uScriptCon_CompareBool_Bool_50);
      SyncUnityHooks( );
      if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_50.True == true )
      {
      }
      if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_50.False == true )
      {
         Relay_In_48();
      }
   }
   
   void Relay_In_51()
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
      logic_uScriptAct_Log_uScriptAct_Log_51.In(logic_uScriptAct_Log_Prefix_51, logic_uScriptAct_Log_Target_51, logic_uScriptAct_Log_Postfix_51);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_51.Out == true )
      {
      }
   }
   
   void Relay_In_52()
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
         if ( logic_uScriptAct_Concatenate_A_52.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Concatenate_A_52, index + 1);
         }
         logic_uScriptAct_Concatenate_A_52[ index++ ] = local_21_System_String;
         
         index = 0;
         properties = null;
         if ( logic_uScriptAct_Concatenate_B_52.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Concatenate_B_52, index + 1);
         }
         logic_uScriptAct_Concatenate_B_52[ index++ ] = local_3_System_Int32;
         
         index = 0;
         properties = null;
         index = 0;
         properties = null;
         }
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_52.In(logic_uScriptAct_Concatenate_A_52, logic_uScriptAct_Concatenate_B_52, logic_uScriptAct_Concatenate_Separator_52, out logic_uScriptAct_Concatenate_Result_52);
      local_19_System_String = logic_uScriptAct_Concatenate_Result_52;
      SyncUnityHooks( );
      if ( logic_uScriptAct_Concatenate_uScriptAct_Concatenate_52.Out == true )
      {
         Relay_In_49();
         Relay_Play_29();
      }
   }
   
   void Relay_In_53()
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
         logic_uScriptCon_IntCounter_A_53 = local_15_System_Int32;
         index = 0;
         properties = null;
         logic_uScriptCon_IntCounter_B_53 = local_13_System_Int32;
         index = 0;
         properties = null;
         }
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_53.In(logic_uScriptCon_IntCounter_A_53, logic_uScriptCon_IntCounter_B_53, out logic_uScriptCon_IntCounter_currentValue_53);
      local_3_System_Int32 = logic_uScriptCon_IntCounter_currentValue_53;
      SyncUnityHooks( );
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_53.GreaterThan == true )
      {
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_53.GreaterThanOrEqualTo == true )
      {
         Relay_In_52();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_53.EqualTo == true )
      {
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_53.LessThanOrEqualTo == true )
      {
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_53.LessThan == true )
      {
      }
   }
   
   void Relay_KeyEvent_55()
   {
      SyncUnityHooks( );
      Relay_In_35();
   }
   
   void Relay_In_54()
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
         logic_uScriptCon_CompareBool_Bool_54 = local_5_System_Boolean;
         }
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_54.In(logic_uScriptCon_CompareBool_Bool_54);
      SyncUnityHooks( );
      if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_54.True == true )
      {
      }
      if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_54.False == true )
      {
         Relay_In_47();
      }
   }
   
   void Relay_KeyEvent_56()
   {
      SyncUnityHooks( );
      Relay_In_31();
   }
   
}
