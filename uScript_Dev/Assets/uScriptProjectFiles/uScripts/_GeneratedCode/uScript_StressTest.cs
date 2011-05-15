//uScript Generated Code - Build 0.3.110514a
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
   UnityEngine.GameObject local_0_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_0_UnityEngine_GameObject_previous = null;
   System.String local_1_System_String = "Area Damage";
   System.Int32 local_2_System_Int32 = (int) 0;
   System.Int32 local_3_System_Int32 = (int) 0;
   System.Boolean local_4_System_Boolean = (bool) false;
   UnityEngine.GameObject local_5_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_5_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Cover3_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Cover3_UnityEngine_GameObject_previous = null;
   System.Boolean local_6_System_Boolean = (bool) false;
   UnityEngine.GameObject local_7_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_7_UnityEngine_GameObject_previous = null;
   System.String local_8_System_String = "Area Damage";
   UnityEngine.GameObject local_9_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_9_UnityEngine_GameObject_previous = null;
   System.Int32 local_10_System_Int32 = (int) 0;
   System.Int32 local_11_System_Int32 = (int) 0;
   System.Int32 local_12_System_Int32 = (int) 0;
   UnityEngine.GameObject local_Cover1_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Cover1_UnityEngine_GameObject_previous = null;
   System.String local_13_System_String = "";
   UnityEngine.GameObject local_14_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_14_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_15_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_15_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Cover2_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Cover2_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Monster_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Monster_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_16_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_16_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_17_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_17_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_18_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_18_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_19_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_19_UnityEngine_GameObject_previous = null;
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
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_27 = null;
   System.Boolean logic_uScriptCon_CompareBool_Bool_27 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_27 = true;
   bool logic_uScriptCon_CompareBool_False_27 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_28 = null;
   System.Int32 logic_uScriptCon_IntCounter_A_28 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_B_28 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_28;
   bool logic_uScriptCon_IntCounter_GreaterThan_28 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_28 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_28 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_28 = true;
   bool logic_uScriptCon_IntCounter_LessThan_28 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_29 = null;
   System.String logic_uScriptAct_Log_Prefix_29 = "";
   System.Object[] logic_uScriptAct_Log_Target_29 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_29 = "";
   bool logic_uScriptAct_Log_Out_29 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_30 = null;
   System.String logic_uScriptAct_Log_Prefix_30 = "";
   System.Object[] logic_uScriptAct_Log_Target_30 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_30 = "";
   bool logic_uScriptAct_Log_Out_30 = true;
   //pointer to script instanced logic node
   uScriptAct_DestroyComponent logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_31 = null;
   UnityEngine.GameObject[] logic_uScriptAct_DestroyComponent_Target_31 = new UnityEngine.GameObject[] {null};
   System.String[] logic_uScriptAct_DestroyComponent_ComponentName_31 = new System.String[] {""};
   System.Single logic_uScriptAct_DestroyComponent_DelayTime_31 = (float) 0;
   bool logic_uScriptAct_DestroyComponent_Out_31 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_32 = null;
   System.String logic_uScriptAct_Log_Prefix_32 = "Trigger Fired!";
   System.Object[] logic_uScriptAct_Log_Target_32 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_32 = "";
   bool logic_uScriptAct_Log_Out_32 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_33 = null;
   System.Int32 logic_uScriptCon_IntCounter_A_33 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_B_33 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_33;
   bool logic_uScriptCon_IntCounter_GreaterThan_33 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_33 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_33 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_33 = true;
   bool logic_uScriptCon_IntCounter_LessThan_33 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_34 = null;
   System.String logic_uScriptAct_Log_Prefix_34 = "";
   System.Object[] logic_uScriptAct_Log_Target_34 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_34 = "";
   bool logic_uScriptAct_Log_Out_34 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_35 = null;
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_35 = null;
   UnityEngine.GameObject logic_uScriptAct_PlaySound_target_35 = null;
   System.Single logic_uScriptAct_PlaySound_volume_35 = (float) 0;
   System.Boolean logic_uScriptAct_PlaySound_loop_35 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_35 = true;
   //pointer to script instanced logic node
   uScriptAct_OnKeyPressFilter logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_36 = null;
   UnityEngine.KeyCode logic_uScriptAct_OnKeyPressFilter_KeyCode_36 = UnityEngine.KeyCode.None;
   bool logic_uScriptAct_OnKeyPressFilter_KeyHeld_36 = true;
   bool logic_uScriptAct_OnKeyPressFilter_KeyDown_36 = true;
   bool logic_uScriptAct_OnKeyPressFilter_KeyUp_36 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_37 = null;
   System.Single logic_uScriptAct_Delay_Duration_37 = (float) 0;
   bool logic_uScriptAct_Delay_Immediate_37 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_38 = null;
   System.Single logic_uScriptAct_Delay_Duration_38 = (float) 0;
   bool logic_uScriptAct_Delay_Immediate_38 = true;
   //pointer to script instanced logic node
   uScriptAct_DestroyComponent logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_39 = null;
   UnityEngine.GameObject[] logic_uScriptAct_DestroyComponent_Target_39 = new UnityEngine.GameObject[] {null};
   System.String[] logic_uScriptAct_DestroyComponent_ComponentName_39 = new System.String[] {""};
   System.Single logic_uScriptAct_DestroyComponent_DelayTime_39 = (float) 0;
   bool logic_uScriptAct_DestroyComponent_Out_39 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_40 = null;
   System.String logic_uScriptAct_Log_Prefix_40 = "";
   System.Object[] logic_uScriptAct_Log_Target_40 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_40 = "";
   bool logic_uScriptAct_Log_Out_40 = true;
   //pointer to script instanced logic node
   uScriptAct_Toggle logic_uScriptAct_Toggle_uScriptAct_Toggle_41 = null;
   UnityEngine.GameObject[] logic_uScriptAct_Toggle_Target_41 = new UnityEngine.GameObject[] {null};
   System.Boolean logic_uScriptAct_Toggle_IgnoreChildren_41 = (bool) false;
   bool logic_uScriptAct_Toggle_Out_41 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_42 = null;
   System.String logic_uScriptAct_Log_Prefix_42 = "";
   System.Object[] logic_uScriptAct_Log_Target_42 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_42 = "";
   bool logic_uScriptAct_Log_Out_42 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_43 = null;
   System.String logic_uScriptAct_Log_Prefix_43 = "";
   System.Object[] logic_uScriptAct_Log_Target_43 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_43 = "";
   bool logic_uScriptAct_Log_Out_43 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_44 = null;
   System.String logic_uScriptAct_Log_Prefix_44 = "";
   System.Object[] logic_uScriptAct_Log_Target_44 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_44 = "";
   bool logic_uScriptAct_Log_Out_44 = true;
   //pointer to script instanced logic node
   uScriptAct_Concatenate logic_uScriptAct_Concatenate_uScriptAct_Concatenate_45 = null;
   System.Object[] logic_uScriptAct_Concatenate_A_45 = new System.Object[] {""};
   System.Object[] logic_uScriptAct_Concatenate_B_45 = new System.Object[] {""};
   System.String logic_uScriptAct_Concatenate_Separator_45 = "";
   System.String logic_uScriptAct_Concatenate_Result_45;
   bool logic_uScriptAct_Concatenate_Out_45 = true;
   //pointer to script instanced logic node
   uScriptAct_LookAt logic_uScriptAct_LookAt_uScriptAct_LookAt_46 = null;
   UnityEngine.GameObject[] logic_uScriptAct_LookAt_Target_46 = new UnityEngine.GameObject[] {null};
   System.Object logic_uScriptAct_LookAt_Focus_46 = "";
   bool logic_uScriptAct_LookAt_Out_46 = true;
   //pointer to script instanced logic node
   uScriptAct_LookAt logic_uScriptAct_LookAt_uScriptAct_LookAt_47 = null;
   UnityEngine.GameObject[] logic_uScriptAct_LookAt_Target_47 = new UnityEngine.GameObject[] {null};
   System.Object logic_uScriptAct_LookAt_Focus_47 = "";
   bool logic_uScriptAct_LookAt_Out_47 = true;
   //pointer to script instanced logic node
   uScriptAct_OnKeyPressFilter logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_48 = null;
   UnityEngine.KeyCode logic_uScriptAct_OnKeyPressFilter_KeyCode_48 = UnityEngine.KeyCode.None;
   bool logic_uScriptAct_OnKeyPressFilter_KeyHeld_48 = true;
   bool logic_uScriptAct_OnKeyPressFilter_KeyDown_48 = true;
   bool logic_uScriptAct_OnKeyPressFilter_KeyUp_48 = true;
   //pointer to script instanced logic node
   uScriptAct_Teleport logic_uScriptAct_Teleport_uScriptAct_Teleport_49 = null;
   UnityEngine.GameObject[] logic_uScriptAct_Teleport_Target_49 = new UnityEngine.GameObject[] {null};
   UnityEngine.GameObject logic_uScriptAct_Teleport_Destination_49 = null;
   System.Boolean logic_uScriptAct_Teleport_UpdateRotation_49 = (bool) false;
   bool logic_uScriptAct_Teleport_Out_49 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_50 = null;
   System.String logic_uScriptAct_Log_Prefix_50 = "";
   System.Object[] logic_uScriptAct_Log_Target_50 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_50 = "";
   bool logic_uScriptAct_Log_Out_50 = true;
   //pointer to script instanced logic node
   uScriptCon_IntCounter logic_uScriptCon_IntCounter_uScriptCon_IntCounter_51 = null;
   System.Int32 logic_uScriptCon_IntCounter_A_51 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_B_51 = (int) 0;
   System.Int32 logic_uScriptCon_IntCounter_currentValue_51;
   bool logic_uScriptCon_IntCounter_GreaterThan_51 = true;
   bool logic_uScriptCon_IntCounter_GreaterThanOrEqualTo_51 = true;
   bool logic_uScriptCon_IntCounter_EqualTo_51 = true;
   bool logic_uScriptCon_IntCounter_LessThanOrEqualTo_51 = true;
   bool logic_uScriptCon_IntCounter_LessThan_51 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_52 = null;
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_52 = null;
   UnityEngine.GameObject logic_uScriptAct_PlaySound_target_52 = null;
   System.Single logic_uScriptAct_PlaySound_volume_52 = (float) 0;
   System.Boolean logic_uScriptAct_PlaySound_loop_52 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_52 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_53 = null;
   System.Boolean logic_uScriptCon_CompareBool_Bool_53 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_53 = true;
   bool logic_uScriptCon_CompareBool_False_53 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_54 = null;
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_54 = null;
   UnityEngine.GameObject logic_uScriptAct_PlaySound_target_54 = null;
   System.Single logic_uScriptAct_PlaySound_volume_54 = (float) 0;
   System.Boolean logic_uScriptAct_PlaySound_loop_54 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_54 = true;
   
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
      if ( local_5_UnityEngine_GameObject_previous != local_5_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_5_UnityEngine_GameObject_previous )
         {
         }
         
         local_5_UnityEngine_GameObject_previous = local_5_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_5_UnityEngine_GameObject )
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
      if ( local_7_UnityEngine_GameObject_previous != local_7_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_7_UnityEngine_GameObject_previous )
         {
         }
         
         local_7_UnityEngine_GameObject_previous = local_7_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_7_UnityEngine_GameObject )
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
      if ( local_19_UnityEngine_GameObject_previous != local_19_UnityEngine_GameObject )
      {
         //tear down old listeners
         if ( null != local_19_UnityEngine_GameObject_previous )
         {
         }
         
         local_19_UnityEngine_GameObject_previous = local_19_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_19_UnityEngine_GameObject )
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
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_27.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_28.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_29.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_30.SetParent(g);
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_31.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_32.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_33.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_34.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_35.SetParent(g);
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_36.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_37.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_38.SetParent(g);
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_39.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_40.SetParent(g);
      logic_uScriptAct_Toggle_uScriptAct_Toggle_41.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_42.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_43.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_44.SetParent(g);
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_45.SetParent(g);
      logic_uScriptAct_LookAt_uScriptAct_LookAt_46.SetParent(g);
      logic_uScriptAct_LookAt_uScriptAct_LookAt_47.SetParent(g);
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_48.SetParent(g);
      logic_uScriptAct_Teleport_uScriptAct_Teleport_49.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_50.SetParent(g);
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_51.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_52.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_53.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_54.SetParent(g);
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
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_27 = ScriptableObject.CreateInstance(typeof(uScriptCon_CompareBool)) as uScriptCon_CompareBool;
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_28 = ScriptableObject.CreateInstance(typeof(uScriptCon_IntCounter)) as uScriptCon_IntCounter;
      logic_uScriptAct_Log_uScriptAct_Log_29 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_30 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_31 = ScriptableObject.CreateInstance(typeof(uScriptAct_DestroyComponent)) as uScriptAct_DestroyComponent;
      logic_uScriptAct_Log_uScriptAct_Log_32 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_33 = ScriptableObject.CreateInstance(typeof(uScriptCon_IntCounter)) as uScriptCon_IntCounter;
      logic_uScriptAct_Log_uScriptAct_Log_34 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_35 = ScriptableObject.CreateInstance(typeof(uScriptAct_PlaySound)) as uScriptAct_PlaySound;
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_36 = ScriptableObject.CreateInstance(typeof(uScriptAct_OnKeyPressFilter)) as uScriptAct_OnKeyPressFilter;
      logic_uScriptAct_Delay_uScriptAct_Delay_37 = ScriptableObject.CreateInstance(typeof(uScriptAct_Delay)) as uScriptAct_Delay;
      logic_uScriptAct_Delay_uScriptAct_Delay_38 = ScriptableObject.CreateInstance(typeof(uScriptAct_Delay)) as uScriptAct_Delay;
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_39 = ScriptableObject.CreateInstance(typeof(uScriptAct_DestroyComponent)) as uScriptAct_DestroyComponent;
      logic_uScriptAct_Log_uScriptAct_Log_40 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_41 = ScriptableObject.CreateInstance(typeof(uScriptAct_Toggle)) as uScriptAct_Toggle;
      logic_uScriptAct_Log_uScriptAct_Log_42 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_43 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_44 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_45 = ScriptableObject.CreateInstance(typeof(uScriptAct_Concatenate)) as uScriptAct_Concatenate;
      logic_uScriptAct_LookAt_uScriptAct_LookAt_46 = ScriptableObject.CreateInstance(typeof(uScriptAct_LookAt)) as uScriptAct_LookAt;
      logic_uScriptAct_LookAt_uScriptAct_LookAt_47 = ScriptableObject.CreateInstance(typeof(uScriptAct_LookAt)) as uScriptAct_LookAt;
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_48 = ScriptableObject.CreateInstance(typeof(uScriptAct_OnKeyPressFilter)) as uScriptAct_OnKeyPressFilter;
      logic_uScriptAct_Teleport_uScriptAct_Teleport_49 = ScriptableObject.CreateInstance(typeof(uScriptAct_Teleport)) as uScriptAct_Teleport;
      logic_uScriptAct_Log_uScriptAct_Log_50 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_51 = ScriptableObject.CreateInstance(typeof(uScriptCon_IntCounter)) as uScriptCon_IntCounter;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_52 = ScriptableObject.CreateInstance(typeof(uScriptAct_PlaySound)) as uScriptAct_PlaySound;
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_53 = ScriptableObject.CreateInstance(typeof(uScriptCon_CompareBool)) as uScriptCon_CompareBool;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_54 = ScriptableObject.CreateInstance(typeof(uScriptAct_PlaySound)) as uScriptAct_PlaySound;
      
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_35.Finished += uScriptAct_PlaySound_Finished_35;
      logic_uScriptAct_Delay_uScriptAct_Delay_37.AfterDelay += uScriptAct_Delay_AfterDelay_37;
      logic_uScriptAct_Delay_uScriptAct_Delay_38.AfterDelay += uScriptAct_Delay_AfterDelay_38;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_41.OnOut += uScriptAct_Toggle_OnOut_41;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_41.OffOut += uScriptAct_Toggle_OffOut_41;
      logic_uScriptAct_Toggle_uScriptAct_Toggle_41.ToggleOut += uScriptAct_Toggle_ToggleOut_41;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_52.Finished += uScriptAct_PlaySound_Finished_52;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_54.Finished += uScriptAct_PlaySound_Finished_54;
   }
   
   public override void Update()
   {
      logic_uScriptAct_Log_uScriptAct_Log_26.Update( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_27.Update( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_28.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_29.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_30.Update( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_31.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_32.Update( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_33.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_34.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_35.Update( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_36.Update( );
      logic_uScriptAct_Delay_uScriptAct_Delay_37.Update( );
      logic_uScriptAct_Delay_uScriptAct_Delay_38.Update( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_39.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_40.Update( );
      logic_uScriptAct_Toggle_uScriptAct_Toggle_41.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_42.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_43.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_44.Update( );
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_45.Update( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_46.Update( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_47.Update( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_48.Update( );
      logic_uScriptAct_Teleport_uScriptAct_Teleport_49.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_50.Update( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_51.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_52.Update( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_53.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_54.Update( );
   }
   
   public override void LateUpdate()
   {
      logic_uScriptAct_Log_uScriptAct_Log_26.LateUpdate( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_27.LateUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_28.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_29.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_30.LateUpdate( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_31.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_32.LateUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_33.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_34.LateUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_35.LateUpdate( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_36.LateUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_37.LateUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_38.LateUpdate( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_39.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_40.LateUpdate( );
      logic_uScriptAct_Toggle_uScriptAct_Toggle_41.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_42.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_43.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_44.LateUpdate( );
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_45.LateUpdate( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_46.LateUpdate( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_47.LateUpdate( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_48.LateUpdate( );
      logic_uScriptAct_Teleport_uScriptAct_Teleport_49.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_50.LateUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_51.LateUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_52.LateUpdate( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_53.LateUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_54.LateUpdate( );
   }
   
   public override void FixedUpdate()
   {
      logic_uScriptAct_Log_uScriptAct_Log_26.FixedUpdate( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_27.FixedUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_28.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_29.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_30.FixedUpdate( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_31.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_32.FixedUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_33.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_34.FixedUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_35.FixedUpdate( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_36.FixedUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_37.FixedUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_38.FixedUpdate( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_39.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_40.FixedUpdate( );
      logic_uScriptAct_Toggle_uScriptAct_Toggle_41.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_42.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_43.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_44.FixedUpdate( );
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_45.FixedUpdate( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_46.FixedUpdate( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_47.FixedUpdate( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_48.FixedUpdate( );
      logic_uScriptAct_Teleport_uScriptAct_Teleport_49.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_50.FixedUpdate( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_51.FixedUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_52.FixedUpdate( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_53.FixedUpdate( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_54.FixedUpdate( );
   }
   
   public override void OnGUI()
   {
      logic_uScriptAct_Log_uScriptAct_Log_26.OnGUI( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_27.OnGUI( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_28.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_29.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_30.OnGUI( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_31.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_32.OnGUI( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_33.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_34.OnGUI( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_35.OnGUI( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_36.OnGUI( );
      logic_uScriptAct_Delay_uScriptAct_Delay_37.OnGUI( );
      logic_uScriptAct_Delay_uScriptAct_Delay_38.OnGUI( );
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_39.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_40.OnGUI( );
      logic_uScriptAct_Toggle_uScriptAct_Toggle_41.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_42.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_43.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_44.OnGUI( );
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_45.OnGUI( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_46.OnGUI( );
      logic_uScriptAct_LookAt_uScriptAct_LookAt_47.OnGUI( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_48.OnGUI( );
      logic_uScriptAct_Teleport_uScriptAct_Teleport_49.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_50.OnGUI( );
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_51.OnGUI( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_52.OnGUI( );
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_53.OnGUI( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_54.OnGUI( );
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
   
   void uScriptAct_PlaySound_Finished_35(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_Finished_35( );
   }
   
   void uScriptAct_Delay_AfterDelay_37(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_AfterDelay_37( );
   }
   
   void uScriptAct_Delay_AfterDelay_38(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_AfterDelay_38( );
   }
   
   void uScriptAct_Toggle_OnOut_41(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_OnOut_41( );
   }
   
   void uScriptAct_Toggle_OffOut_41(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_OffOut_41( );
   }
   
   void uScriptAct_Toggle_ToggleOut_41(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_ToggleOut_41( );
   }
   
   void uScriptAct_PlaySound_Finished_52(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_Finished_52( );
   }
   
   void uScriptAct_PlaySound_Finished_54(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_Finished_54( );
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
         logic_uScriptCon_CompareBool_Bool_27 = local_6_System_Boolean;
         }
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_27.In(logic_uScriptCon_CompareBool_Bool_27);
      SyncUnityHooks( );
      if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_27.True == true )
      {
      }
      if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_27.False == true )
      {
         Relay_In_47();
      }
   }
   
   void Relay_KeyEvent_55()
   {
      SyncUnityHooks( );
      Relay_In_36();
   }
   
   void Relay_KeyEvent_56()
   {
      SyncUnityHooks( );
      Relay_In_48();
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
         logic_uScriptCon_IntCounter_B_28 = local_2_System_Int32;
         index = 0;
         properties = null;
         }
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_28.In(logic_uScriptCon_IntCounter_A_28, logic_uScriptCon_IntCounter_B_28, out logic_uScriptCon_IntCounter_currentValue_28);
      SyncUnityHooks( );
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_28.GreaterThan == true )
      {
         Relay_In_34();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_28.GreaterThanOrEqualTo == true )
      {
         Relay_In_44();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_28.EqualTo == true )
      {
         Relay_In_29();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_28.LessThanOrEqualTo == true )
      {
         Relay_In_50();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_28.LessThan == true )
      {
         Relay_In_50();
      }
   }
   
   void Relay_In_29()
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
      logic_uScriptAct_Log_uScriptAct_Log_29.In(logic_uScriptAct_Log_Prefix_29, logic_uScriptAct_Log_Target_29, logic_uScriptAct_Log_Postfix_29);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_29.Out == true )
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
         if ( logic_uScriptAct_DestroyComponent_Target_31.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_DestroyComponent_Target_31, index + 1);
         }
         logic_uScriptAct_DestroyComponent_Target_31[ index++ ] = local_Monster_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         if ( logic_uScriptAct_DestroyComponent_ComponentName_31.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_DestroyComponent_ComponentName_31, index + 1);
         }
         logic_uScriptAct_DestroyComponent_ComponentName_31[ index++ ] = local_8_System_String;
         
         index = 0;
         properties = null;
         }
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_31.In(logic_uScriptAct_DestroyComponent_Target_31, logic_uScriptAct_DestroyComponent_ComponentName_31, logic_uScriptAct_DestroyComponent_DelayTime_31);
      SyncUnityHooks( );
      if ( logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_31.Out == true )
      {
         Relay_In_28();
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
         if ( logic_uScriptAct_Log_Target_32.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Log_Target_32, index + 1);
         }
         logic_uScriptAct_Log_Target_32[ index++ ] = local_Cover3_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         }
      logic_uScriptAct_Log_uScriptAct_Log_32.In(logic_uScriptAct_Log_Prefix_32, logic_uScriptAct_Log_Target_32, logic_uScriptAct_Log_Postfix_32);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_32.Out == true )
      {
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
         logic_uScriptCon_IntCounter_B_33 = local_10_System_Int32;
         index = 0;
         properties = null;
         }
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_33.In(logic_uScriptCon_IntCounter_A_33, logic_uScriptCon_IntCounter_B_33, out logic_uScriptCon_IntCounter_currentValue_33);
      SyncUnityHooks( );
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_33.GreaterThan == true )
      {
         Relay_In_42();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_33.GreaterThanOrEqualTo == true )
      {
         Relay_In_43();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_33.EqualTo == true )
      {
         Relay_In_26();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_33.LessThanOrEqualTo == true )
      {
         Relay_In_40();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_33.LessThan == true )
      {
         Relay_In_40();
      }
   }
   
   void Relay_In_34()
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
      logic_uScriptAct_Log_uScriptAct_Log_34.In(logic_uScriptAct_Log_Prefix_34, logic_uScriptAct_Log_Target_34, logic_uScriptAct_Log_Postfix_34);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_34.Out == true )
      {
      }
   }
   
   void Relay_Finished_35()
   {
   }
   
   void Relay_Play_35()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_35.Play(logic_uScriptAct_PlaySound_audioClip_35, logic_uScriptAct_PlaySound_target_35, logic_uScriptAct_PlaySound_volume_35, logic_uScriptAct_PlaySound_loop_35);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_35.Out == true )
      {
         Relay_In_53();
      }
   }
   
   void Relay_Stop_35()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_35.Stop(logic_uScriptAct_PlaySound_audioClip_35, logic_uScriptAct_PlaySound_target_35, logic_uScriptAct_PlaySound_volume_35, logic_uScriptAct_PlaySound_loop_35);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_35.Out == true )
      {
         Relay_In_53();
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
         }
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_36.In(logic_uScriptAct_OnKeyPressFilter_KeyCode_36);
      SyncUnityHooks( );
      if ( logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_36.KeyHeld == true )
      {
      }
      if ( logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_36.KeyDown == true )
      {
         Relay_Stop_52();
         Relay_In_39();
      }
      if ( logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_36.KeyUp == true )
      {
      }
   }
   
   void Relay_AfterDelay_37()
   {
      Relay_In_32();
   }
   
   void Relay_In_37()
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
      logic_uScriptAct_Delay_uScriptAct_Delay_37.In(logic_uScriptAct_Delay_Duration_37);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Delay_uScriptAct_Delay_37.Immediate == true )
      {
         Relay_In_30();
      }
   }
   
   void Relay_AfterDelay_38()
   {
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
         Relay_In_51();
      }
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
         if ( logic_uScriptAct_DestroyComponent_Target_39.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_DestroyComponent_Target_39, index + 1);
         }
         logic_uScriptAct_DestroyComponent_Target_39[ index++ ] = local_Monster_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         if ( logic_uScriptAct_DestroyComponent_ComponentName_39.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_DestroyComponent_ComponentName_39, index + 1);
         }
         logic_uScriptAct_DestroyComponent_ComponentName_39[ index++ ] = local_1_System_String;
         
         index = 0;
         properties = null;
         }
      logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_39.In(logic_uScriptAct_DestroyComponent_Target_39, logic_uScriptAct_DestroyComponent_ComponentName_39, logic_uScriptAct_DestroyComponent_DelayTime_39);
      SyncUnityHooks( );
      if ( logic_uScriptAct_DestroyComponent_uScriptAct_DestroyComponent_39.Out == true )
      {
         Relay_In_33();
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
         index = 0;
         properties = null;
         index = 0;
         properties = null;
         }
      logic_uScriptAct_Log_uScriptAct_Log_40.In(logic_uScriptAct_Log_Prefix_40, logic_uScriptAct_Log_Target_40, logic_uScriptAct_Log_Postfix_40);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_40.Out == true )
      {
      }
   }
   
   void Relay_OnOut_41()
   {
   }
   
   void Relay_OffOut_41()
   {
   }
   
   void Relay_ToggleOut_41()
   {
   }
   
   void Relay_TurnOn_41()
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
         if ( logic_uScriptAct_Toggle_Target_41.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_41, index + 1);
         }
         logic_uScriptAct_Toggle_Target_41[ index++ ] = local_Cover1_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_Toggle_Target_41.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_41, index + 1);
         }
         logic_uScriptAct_Toggle_Target_41[ index++ ] = local_Cover2_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         }
      logic_uScriptAct_Toggle_uScriptAct_Toggle_41.TurnOn(logic_uScriptAct_Toggle_Target_41, logic_uScriptAct_Toggle_IgnoreChildren_41);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Toggle_uScriptAct_Toggle_41.Out == true )
      {
         Relay_In_37();
      }
   }
   
   void Relay_TurnOff_41()
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
         if ( logic_uScriptAct_Toggle_Target_41.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_41, index + 1);
         }
         logic_uScriptAct_Toggle_Target_41[ index++ ] = local_Cover1_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_Toggle_Target_41.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_41, index + 1);
         }
         logic_uScriptAct_Toggle_Target_41[ index++ ] = local_Cover2_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         }
      logic_uScriptAct_Toggle_uScriptAct_Toggle_41.TurnOff(logic_uScriptAct_Toggle_Target_41, logic_uScriptAct_Toggle_IgnoreChildren_41);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Toggle_uScriptAct_Toggle_41.Out == true )
      {
         Relay_In_37();
      }
   }
   
   void Relay_Toggle_41()
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
         if ( logic_uScriptAct_Toggle_Target_41.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_41, index + 1);
         }
         logic_uScriptAct_Toggle_Target_41[ index++ ] = local_Cover1_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_Toggle_Target_41.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Toggle_Target_41, index + 1);
         }
         logic_uScriptAct_Toggle_Target_41[ index++ ] = local_Cover2_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         }
      logic_uScriptAct_Toggle_uScriptAct_Toggle_41.Toggle(logic_uScriptAct_Toggle_Target_41, logic_uScriptAct_Toggle_IgnoreChildren_41);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Toggle_uScriptAct_Toggle_41.Out == true )
      {
         Relay_In_37();
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
         index = 0;
         properties = null;
         index = 0;
         properties = null;
         }
      logic_uScriptAct_Log_uScriptAct_Log_42.In(logic_uScriptAct_Log_Prefix_42, logic_uScriptAct_Log_Target_42, logic_uScriptAct_Log_Postfix_42);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_42.Out == true )
      {
      }
   }
   
   void Relay_In_43()
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
      logic_uScriptAct_Log_uScriptAct_Log_43.In(logic_uScriptAct_Log_Prefix_43, logic_uScriptAct_Log_Target_43, logic_uScriptAct_Log_Postfix_43);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_43.Out == true )
      {
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
         if ( logic_uScriptAct_Concatenate_A_45.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Concatenate_A_45, index + 1);
         }
         logic_uScriptAct_Concatenate_A_45[ index++ ] = local_21_System_String;
         
         index = 0;
         properties = null;
         if ( logic_uScriptAct_Concatenate_B_45.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Concatenate_B_45, index + 1);
         }
         logic_uScriptAct_Concatenate_B_45[ index++ ] = local_3_System_Int32;
         
         index = 0;
         properties = null;
         index = 0;
         properties = null;
         }
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_45.In(logic_uScriptAct_Concatenate_A_45, logic_uScriptAct_Concatenate_B_45, logic_uScriptAct_Concatenate_Separator_45, out logic_uScriptAct_Concatenate_Result_45);
      local_13_System_String = logic_uScriptAct_Concatenate_Result_45;
      SyncUnityHooks( );
      if ( logic_uScriptAct_Concatenate_uScriptAct_Concatenate_45.Out == true )
      {
         Relay_Play_54();
         Relay_In_49();
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
         if ( logic_uScriptAct_LookAt_Target_46.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_46, index + 1);
         }
         logic_uScriptAct_LookAt_Target_46[ index++ ] = local_16_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_46.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_46, index + 1);
         }
         logic_uScriptAct_LookAt_Target_46[ index++ ] = local_20_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_46.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_46, index + 1);
         }
         logic_uScriptAct_LookAt_Target_46[ index++ ] = local_18_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_46.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_46, index + 1);
         }
         logic_uScriptAct_LookAt_Target_46[ index++ ] = local_9_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_46.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_46, index + 1);
         }
         logic_uScriptAct_LookAt_Target_46[ index++ ] = local_7_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         }
      logic_uScriptAct_LookAt_uScriptAct_LookAt_46.In(logic_uScriptAct_LookAt_Target_46, logic_uScriptAct_LookAt_Focus_46);
      SyncUnityHooks( );
      if ( logic_uScriptAct_LookAt_uScriptAct_LookAt_46.Out == true )
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
         logic_uScriptAct_LookAt_Target_47[ index++ ] = local_14_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_47.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_47, index + 1);
         }
         logic_uScriptAct_LookAt_Target_47[ index++ ] = local_17_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_47.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_47, index + 1);
         }
         logic_uScriptAct_LookAt_Target_47[ index++ ] = local_0_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_47.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_47, index + 1);
         }
         logic_uScriptAct_LookAt_Target_47[ index++ ] = local_5_UnityEngine_GameObject;
         
         if ( logic_uScriptAct_LookAt_Target_47.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_LookAt_Target_47, index + 1);
         }
         logic_uScriptAct_LookAt_Target_47[ index++ ] = local_15_UnityEngine_GameObject;
         
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
         }
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_48.In(logic_uScriptAct_OnKeyPressFilter_KeyCode_48);
      SyncUnityHooks( );
      if ( logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_48.KeyHeld == true )
      {
      }
      if ( logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_48.KeyDown == true )
      {
         Relay_Stop_35();
         Relay_In_31();
      }
      if ( logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_48.KeyUp == true )
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
         logic_uScriptAct_Teleport_Target_49[ index++ ] = local_19_UnityEngine_GameObject;
         
         index = 0;
         properties = null;
         index = 0;
         properties = null;
         }
      logic_uScriptAct_Teleport_uScriptAct_Teleport_49.In(logic_uScriptAct_Teleport_Target_49, logic_uScriptAct_Teleport_Destination_49, logic_uScriptAct_Teleport_UpdateRotation_49);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Teleport_uScriptAct_Teleport_49.Out == true )
      {
         Relay_In_30();
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
         index = 0;
         properties = null;
         index = 0;
         properties = null;
         }
      logic_uScriptAct_Log_uScriptAct_Log_50.In(logic_uScriptAct_Log_Prefix_50, logic_uScriptAct_Log_Target_50, logic_uScriptAct_Log_Postfix_50);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_50.Out == true )
      {
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
         logic_uScriptCon_IntCounter_A_51 = local_12_System_Int32;
         index = 0;
         properties = null;
         logic_uScriptCon_IntCounter_B_51 = local_11_System_Int32;
         index = 0;
         properties = null;
         }
      logic_uScriptCon_IntCounter_uScriptCon_IntCounter_51.In(logic_uScriptCon_IntCounter_A_51, logic_uScriptCon_IntCounter_B_51, out logic_uScriptCon_IntCounter_currentValue_51);
      local_3_System_Int32 = logic_uScriptCon_IntCounter_currentValue_51;
      SyncUnityHooks( );
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_51.GreaterThan == true )
      {
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_51.GreaterThanOrEqualTo == true )
      {
         Relay_In_45();
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_51.EqualTo == true )
      {
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_51.LessThanOrEqualTo == true )
      {
      }
      if ( logic_uScriptCon_IntCounter_uScriptCon_IntCounter_51.LessThan == true )
      {
      }
   }
   
   void Relay_Finished_52()
   {
   }
   
   void Relay_Play_52()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_52.Play(logic_uScriptAct_PlaySound_audioClip_52, logic_uScriptAct_PlaySound_target_52, logic_uScriptAct_PlaySound_volume_52, logic_uScriptAct_PlaySound_loop_52);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_52.Out == true )
      {
         Relay_In_27();
      }
   }
   
   void Relay_Stop_52()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_52.Stop(logic_uScriptAct_PlaySound_audioClip_52, logic_uScriptAct_PlaySound_target_52, logic_uScriptAct_PlaySound_volume_52, logic_uScriptAct_PlaySound_loop_52);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_52.Out == true )
      {
         Relay_In_27();
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
         logic_uScriptCon_CompareBool_Bool_53 = local_4_System_Boolean;
         }
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_53.In(logic_uScriptCon_CompareBool_Bool_53);
      SyncUnityHooks( );
      if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_53.True == true )
      {
      }
      if ( logic_uScriptCon_CompareBool_uScriptCon_CompareBool_53.False == true )
      {
         Relay_In_46();
      }
   }
   
   void Relay_Finished_54()
   {
   }
   
   void Relay_Play_54()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_54.Play(logic_uScriptAct_PlaySound_audioClip_54, logic_uScriptAct_PlaySound_target_54, logic_uScriptAct_PlaySound_volume_54, logic_uScriptAct_PlaySound_loop_54);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_54.Out == true )
      {
      }
   }
   
   void Relay_Stop_54()
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
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_54.Stop(logic_uScriptAct_PlaySound_audioClip_54, logic_uScriptAct_PlaySound_target_54, logic_uScriptAct_PlaySound_volume_54, logic_uScriptAct_PlaySound_loop_54);
      SyncUnityHooks( );
      if ( logic_uScriptAct_PlaySound_uScriptAct_PlaySound_54.Out == true )
      {
      }
   }
   
}
