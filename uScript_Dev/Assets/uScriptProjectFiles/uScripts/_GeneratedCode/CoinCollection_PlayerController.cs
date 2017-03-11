//uScript Generated Code - Build 1.0.3055
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class CoinCollection_PlayerController : uScriptLogic
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
   UnityEngine.Vector3 local_1_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)-7 );
   UnityEngine.Vector3 local_14_UnityEngine_Vector3 = new Vector3( (float)7, (float)0, (float)0 );
   UnityEngine.GameObject local_17_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_17_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_21_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_21_UnityEngine_GameObject_previous = null;
   UnityEngine.Vector3 local_22_UnityEngine_Vector3 = new Vector3( (float)-7, (float)0, (float)0 );
   UnityEngine.Vector3 local_24_UnityEngine_Vector3 = new Vector3( (float)7, (float)0, (float)0 );
   UnityEngine.Vector3 local_33_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)7 );
   UnityEngine.Vector3 local_38_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)-7 );
   UnityEngine.Vector3 local_39_UnityEngine_Vector3 = new Vector3( (float)0, (float)3, (float)0 );
   UnityEngine.GameObject local_6_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_6_UnityEngine_GameObject_previous = null;
   UnityEngine.Vector3 local_8_UnityEngine_Vector3 = new Vector3( (float)-7, (float)0, (float)0 );
   UnityEngine.Vector3 local_9_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)7 );
   System.Boolean local_Can_Jump__System_Boolean = (bool) true;
   
   //owner nodes
   UnityEngine.GameObject owner_Connection_41 = null;
   UnityEngine.GameObject owner_Connection_42 = null;
   UnityEngine.GameObject owner_Connection_43 = null;
   UnityEngine.GameObject owner_Connection_44 = null;
   UnityEngine.GameObject owner_Connection_45 = null;
   UnityEngine.GameObject owner_Connection_46 = null;
   UnityEngine.GameObject owner_Connection_47 = null;
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_0 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_0 = UnityEngine.KeyCode.A;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_0 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_0 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_0 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector3_v2 logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_2 = new uScriptAct_AddVector3_v2( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_A_2 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_B_2 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_Result_2;
   bool logic_uScriptAct_AddVector3_v2_Out_2 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_3 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_3 = UnityEngine.KeyCode.Space;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_3 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_3 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_3 = true;
   //pointer to script instanced logic node
   uScriptAct_AddForce logic_uScriptAct_AddForce_uScriptAct_AddForce_7 = new uScriptAct_AddForce( );
   UnityEngine.GameObject logic_uScriptAct_AddForce_Target_7 = default(UnityEngine.GameObject);
   UnityEngine.Vector3 logic_uScriptAct_AddForce_Force_7 = new Vector3( );
   System.Single logic_uScriptAct_AddForce_Scale_7 = (float) 0;
   System.Boolean logic_uScriptAct_AddForce_UseForceMode_7 = (bool) false;
   UnityEngine.ForceMode logic_uScriptAct_AddForce_ForceModeType_7 = UnityEngine.ForceMode.Force;
   bool logic_uScriptAct_AddForce_Out_7 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector3_v2 logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_12 = new uScriptAct_AddVector3_v2( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_A_12 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_B_12 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_Result_12;
   bool logic_uScriptAct_AddVector3_v2_Out_12 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_13 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_13 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_13 = true;
   bool logic_uScriptCon_CompareBool_False_13 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_15 = new uScriptAct_PlaySound( );
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_15 = default(UnityEngine.AudioClip);
   UnityEngine.GameObject[] logic_uScriptAct_PlaySound_target_15 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_PlaySound_volume_15 = (float) 1;
   System.Boolean logic_uScriptAct_PlaySound_loop_15 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_15 = true;
   //pointer to script instanced logic node
   uScriptAct_AddForce logic_uScriptAct_AddForce_uScriptAct_AddForce_16 = new uScriptAct_AddForce( );
   UnityEngine.GameObject logic_uScriptAct_AddForce_Target_16 = default(UnityEngine.GameObject);
   UnityEngine.Vector3 logic_uScriptAct_AddForce_Force_16 = new Vector3( );
   System.Single logic_uScriptAct_AddForce_Scale_16 = (float) 0;
   System.Boolean logic_uScriptAct_AddForce_UseForceMode_16 = (bool) true;
   UnityEngine.ForceMode logic_uScriptAct_AddForce_ForceModeType_16 = UnityEngine.ForceMode.Impulse;
   bool logic_uScriptAct_AddForce_Out_16 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector3_v2 logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_20 = new uScriptAct_AddVector3_v2( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_A_20 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_B_20 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_Result_20;
   bool logic_uScriptAct_AddVector3_v2_Out_20 = true;
   //pointer to script instanced logic node
   uScriptAct_AddForce logic_uScriptAct_AddForce_uScriptAct_AddForce_23 = new uScriptAct_AddForce( );
   UnityEngine.GameObject logic_uScriptAct_AddForce_Target_23 = default(UnityEngine.GameObject);
   UnityEngine.Vector3 logic_uScriptAct_AddForce_Force_23 = new Vector3( );
   System.Single logic_uScriptAct_AddForce_Scale_23 = (float) 0;
   System.Boolean logic_uScriptAct_AddForce_UseForceMode_23 = (bool) false;
   UnityEngine.ForceMode logic_uScriptAct_AddForce_ForceModeType_23 = UnityEngine.ForceMode.Force;
   bool logic_uScriptAct_AddForce_Out_23 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_25 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_25 = UnityEngine.KeyCode.W;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_25 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_25 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_25 = true;
   //pointer to script instanced logic node
   uScriptAct_AddForce logic_uScriptAct_AddForce_uScriptAct_AddForce_27 = new uScriptAct_AddForce( );
   UnityEngine.GameObject logic_uScriptAct_AddForce_Target_27 = default(UnityEngine.GameObject);
   UnityEngine.Vector3 logic_uScriptAct_AddForce_Force_27 = new Vector3( );
   System.Single logic_uScriptAct_AddForce_Scale_27 = (float) 0;
   System.Boolean logic_uScriptAct_AddForce_UseForceMode_27 = (bool) false;
   UnityEngine.ForceMode logic_uScriptAct_AddForce_ForceModeType_27 = UnityEngine.ForceMode.Force;
   bool logic_uScriptAct_AddForce_Out_27 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_28 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_28 = UnityEngine.KeyCode.D;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_28 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_28 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_28 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareGameObjects logic_uScriptCon_CompareGameObjects_uScriptCon_CompareGameObjects_30 = new uScriptCon_CompareGameObjects( );
   UnityEngine.GameObject logic_uScriptCon_CompareGameObjects_A_30 = default(UnityEngine.GameObject);
   UnityEngine.GameObject logic_uScriptCon_CompareGameObjects_B_30 = default(UnityEngine.GameObject);
   System.Boolean logic_uScriptCon_CompareGameObjects_CompareByTag_30 = (bool) false;
   System.Boolean logic_uScriptCon_CompareGameObjects_CompareByName_30 = (bool) false;
   System.Boolean logic_uScriptCon_CompareGameObjects_ReportNull_30 = (bool) true;
   bool logic_uScriptCon_CompareGameObjects_Same_30 = true;
   bool logic_uScriptCon_CompareGameObjects_Different_30 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_31 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_31;
   bool logic_uScriptAct_SetBool_Out_31 = true;
   bool logic_uScriptAct_SetBool_SetTrue_31 = true;
   bool logic_uScriptAct_SetBool_SetFalse_31 = true;
   //pointer to script instanced logic node
   uScriptAct_AddForce logic_uScriptAct_AddForce_uScriptAct_AddForce_34 = new uScriptAct_AddForce( );
   UnityEngine.GameObject logic_uScriptAct_AddForce_Target_34 = default(UnityEngine.GameObject);
   UnityEngine.Vector3 logic_uScriptAct_AddForce_Force_34 = new Vector3( );
   System.Single logic_uScriptAct_AddForce_Scale_34 = (float) 0;
   System.Boolean logic_uScriptAct_AddForce_UseForceMode_34 = (bool) false;
   UnityEngine.ForceMode logic_uScriptAct_AddForce_ForceModeType_34 = UnityEngine.ForceMode.Force;
   bool logic_uScriptAct_AddForce_Out_34 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_35 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_35;
   bool logic_uScriptAct_SetBool_Out_35 = true;
   bool logic_uScriptAct_SetBool_SetTrue_35 = true;
   bool logic_uScriptAct_SetBool_SetFalse_35 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_37 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_37 = UnityEngine.KeyCode.S;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_37 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_37 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_37 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector3_v2 logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_40 = new uScriptAct_AddVector3_v2( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_A_40 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_B_40 = new Vector3( );
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_v2_Result_40;
   bool logic_uScriptAct_AddVector3_v2_Out_40 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_4 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_5 = default(UnityEngine.GameObject);
   UnityEngine.Vector3 event_UnityEngine_GameObject_RelativeVelocity_10 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Rigidbody event_UnityEngine_GameObject_RigidBody_10 = default(UnityEngine.Rigidbody);
   UnityEngine.Collider event_UnityEngine_GameObject_Collider_10 = default(UnityEngine.Collider);
   UnityEngine.Transform event_UnityEngine_GameObject_Transform_10 = default(UnityEngine.Transform);
   UnityEngine.ContactPoint[] event_UnityEngine_GameObject_Contacts_10 = new UnityEngine.ContactPoint[ 0 ];
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_10 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_18 = default(UnityEngine.GameObject);
   UnityEngine.Vector3 event_UnityEngine_GameObject_RelativeVelocity_19 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Rigidbody event_UnityEngine_GameObject_RigidBody_19 = default(UnityEngine.Rigidbody);
   UnityEngine.Collider event_UnityEngine_GameObject_Collider_19 = default(UnityEngine.Collider);
   UnityEngine.Transform event_UnityEngine_GameObject_Transform_19 = default(UnityEngine.Transform);
   UnityEngine.ContactPoint[] event_UnityEngine_GameObject_Contacts_19 = new UnityEngine.ContactPoint[ 0 ];
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_19 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_26 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_29 = default(UnityEngine.GameObject);
   
   //property nodes
   UnityEngine.AudioClip property_JumpAudio_Detox_ScriptEditor_Parameter_JumpAudio_48 = default(UnityEngine.AudioClip);
   UnityEngine.GameObject property_JumpAudio_Detox_ScriptEditor_Parameter_Instance_48 = default(UnityEngine.GameObject);
   UnityEngine.GameObject property_JumpAudio_Detox_ScriptEditor_Parameter_Instance_48_previous = null;
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   UnityEngine.AudioClip property_JumpAudio_Detox_ScriptEditor_Parameter_JumpAudio_48_Get_Refresh( )
   {
      CoinCollection_GameplayGlobals_Component component = null;
      if (property_JumpAudio_Detox_ScriptEditor_Parameter_Instance_48 != null)
      {
         component = property_JumpAudio_Detox_ScriptEditor_Parameter_Instance_48.GetComponent<CoinCollection_GameplayGlobals_Component>();
      }
      if ( null != component )
      {
         return component.JumpAudio;
      }
      else
      {
         return default(UnityEngine.AudioClip);
      }
   }
   
   void property_JumpAudio_Detox_ScriptEditor_Parameter_JumpAudio_48_Set_Refresh( )
   {
      CoinCollection_GameplayGlobals_Component component = null;
      if (property_JumpAudio_Detox_ScriptEditor_Parameter_Instance_48 != null)
      {
         component = property_JumpAudio_Detox_ScriptEditor_Parameter_Instance_48.GetComponent<CoinCollection_GameplayGlobals_Component>();
      }
      if ( null != component )
      {
         component.JumpAudio = property_JumpAudio_Detox_ScriptEditor_Parameter_JumpAudio_48;
      }
   }
   
   
   void SyncUnityHooks( )
   {
      if ( null == property_JumpAudio_Detox_ScriptEditor_Parameter_Instance_48 || false == m_RegisteredForEvents )
      {
         property_JumpAudio_Detox_ScriptEditor_Parameter_Instance_48 = uScript_MasterComponent.LatestMaster;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_JumpAudio_Detox_ScriptEditor_Parameter_Instance_48_previous != property_JumpAudio_Detox_ScriptEditor_Parameter_Instance_48 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_JumpAudio_Detox_ScriptEditor_Parameter_Instance_48_previous = property_JumpAudio_Detox_ScriptEditor_Parameter_Instance_48;
         
         //setup new listeners
      }
      SyncEventListeners( );
      if ( null == local_6_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_6_UnityEngine_GameObject = GameObject.Find( "Ground" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_6_UnityEngine_GameObject_previous != local_6_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_17_UnityEngine_GameObject_previous != local_17_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_17_UnityEngine_GameObject_previous = local_17_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_21_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_21_UnityEngine_GameObject = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_21_UnityEngine_GameObject_previous != local_21_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_21_UnityEngine_GameObject_previous = local_21_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == owner_Connection_41 || false == m_RegisteredForEvents )
      {
         owner_Connection_41 = parentGameObject;
      }
      if ( null == owner_Connection_42 || false == m_RegisteredForEvents )
      {
         owner_Connection_42 = parentGameObject;
      }
      if ( null == owner_Connection_43 || false == m_RegisteredForEvents )
      {
         owner_Connection_43 = parentGameObject;
      }
      if ( null == owner_Connection_44 || false == m_RegisteredForEvents )
      {
         owner_Connection_44 = parentGameObject;
         if ( null != owner_Connection_44 )
         {
            {
               uScript_Collision component = owner_Connection_44.GetComponent<uScript_Collision>();
               if ( null == component )
               {
                  component = owner_Connection_44.AddComponent<uScript_Collision>();
               }
               if ( null != component )
               {
                  component.OnEnterCollision += Instance_OnEnterCollision_10;
                  component.OnExitCollision += Instance_OnExitCollision_10;
                  component.WhileInsideCollision += Instance_WhileInsideCollision_10;
               }
            }
         }
      }
      if ( null == owner_Connection_45 || false == m_RegisteredForEvents )
      {
         owner_Connection_45 = parentGameObject;
      }
      if ( null == owner_Connection_46 || false == m_RegisteredForEvents )
      {
         owner_Connection_46 = parentGameObject;
      }
      if ( null == owner_Connection_47 || false == m_RegisteredForEvents )
      {
         owner_Connection_47 = parentGameObject;
         if ( null != owner_Connection_47 )
         {
            {
               uScript_Collision component = owner_Connection_47.GetComponent<uScript_Collision>();
               if ( null == component )
               {
                  component = owner_Connection_47.AddComponent<uScript_Collision>();
               }
               if ( null != component )
               {
                  component.OnEnterCollision += Instance_OnEnterCollision_19;
                  component.OnExitCollision += Instance_OnExitCollision_19;
                  component.WhileInsideCollision += Instance_WhileInsideCollision_19;
               }
            }
         }
      }
   }
   
   void RegisterForUnityHooks( )
   {
      //if our game object reference was changed then we need to reset event listeners
      if ( property_JumpAudio_Detox_ScriptEditor_Parameter_Instance_48_previous != property_JumpAudio_Detox_ScriptEditor_Parameter_Instance_48 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_JumpAudio_Detox_ScriptEditor_Parameter_Instance_48_previous = property_JumpAudio_Detox_ScriptEditor_Parameter_Instance_48;
         
         //setup new listeners
      }
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_6_UnityEngine_GameObject_previous != local_6_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_17_UnityEngine_GameObject_previous != local_17_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_17_UnityEngine_GameObject_previous = local_17_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_21_UnityEngine_GameObject_previous != local_21_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_21_UnityEngine_GameObject_previous = local_21_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //reset event listeners if needed
      //this isn't a variable node so it should only be called once per enabling of the script
      //if it's called twice there would be a double event registration (which is an error)
      if ( false == m_RegisteredForEvents )
      {
         if ( null != owner_Connection_44 )
         {
            {
               uScript_Collision component = owner_Connection_44.GetComponent<uScript_Collision>();
               if ( null == component )
               {
                  component = owner_Connection_44.AddComponent<uScript_Collision>();
               }
               if ( null != component )
               {
                  component.OnEnterCollision += Instance_OnEnterCollision_10;
                  component.OnExitCollision += Instance_OnExitCollision_10;
                  component.WhileInsideCollision += Instance_WhileInsideCollision_10;
               }
            }
         }
      }
      //reset event listeners if needed
      //this isn't a variable node so it should only be called once per enabling of the script
      //if it's called twice there would be a double event registration (which is an error)
      if ( false == m_RegisteredForEvents )
      {
         if ( null != owner_Connection_47 )
         {
            {
               uScript_Collision component = owner_Connection_47.GetComponent<uScript_Collision>();
               if ( null == component )
               {
                  component = owner_Connection_47.AddComponent<uScript_Collision>();
               }
               if ( null != component )
               {
                  component.OnEnterCollision += Instance_OnEnterCollision_19;
                  component.OnExitCollision += Instance_OnExitCollision_19;
                  component.WhileInsideCollision += Instance_WhileInsideCollision_19;
               }
            }
         }
      }
   }
   
   void SyncEventListeners( )
   {
      {
         {
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( property_JumpAudio_Detox_ScriptEditor_Parameter_Instance_48_previous != property_JumpAudio_Detox_ScriptEditor_Parameter_Instance_48 || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  property_JumpAudio_Detox_ScriptEditor_Parameter_Instance_48_previous = property_JumpAudio_Detox_ScriptEditor_Parameter_Instance_48;
                  
                  //setup new listeners
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_4 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_4 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_4 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_4.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_4.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_4;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_5 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_5 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_5 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_5.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_5.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_5;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_18 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_18 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_18 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_18.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_18.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_18;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_26 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_26 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_26 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_26.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_26.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_26;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_29 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_29 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_29 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_29.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_29.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_29;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != owner_Connection_44 )
      {
         {
            uScript_Collision component = owner_Connection_44.GetComponent<uScript_Collision>();
            if ( null != component )
            {
               component.OnEnterCollision -= Instance_OnEnterCollision_10;
               component.OnExitCollision -= Instance_OnExitCollision_10;
               component.WhileInsideCollision -= Instance_WhileInsideCollision_10;
            }
         }
      }
      if ( null != owner_Connection_47 )
      {
         {
            uScript_Collision component = owner_Connection_47.GetComponent<uScript_Collision>();
            if ( null != component )
            {
               component.OnEnterCollision -= Instance_OnEnterCollision_19;
               component.OnExitCollision -= Instance_OnExitCollision_19;
               component.WhileInsideCollision -= Instance_WhileInsideCollision_19;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_4 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_4.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_4;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_5 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_5.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_5;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_18 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_18.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_18;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_26 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_26.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_26;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_29 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_29.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_29;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_0.SetParent(g);
      logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_2.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_3.SetParent(g);
      logic_uScriptAct_AddForce_uScriptAct_AddForce_7.SetParent(g);
      logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_12.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_13.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_15.SetParent(g);
      logic_uScriptAct_AddForce_uScriptAct_AddForce_16.SetParent(g);
      logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_20.SetParent(g);
      logic_uScriptAct_AddForce_uScriptAct_AddForce_23.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_25.SetParent(g);
      logic_uScriptAct_AddForce_uScriptAct_AddForce_27.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_28.SetParent(g);
      logic_uScriptCon_CompareGameObjects_uScriptCon_CompareGameObjects_30.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_31.SetParent(g);
      logic_uScriptAct_AddForce_uScriptAct_AddForce_34.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_35.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_37.SetParent(g);
      logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_40.SetParent(g);
      owner_Connection_41 = parentGameObject;
      owner_Connection_42 = parentGameObject;
      owner_Connection_43 = parentGameObject;
      owner_Connection_44 = parentGameObject;
      owner_Connection_45 = parentGameObject;
      owner_Connection_46 = parentGameObject;
      owner_Connection_47 = parentGameObject;
   }
   public void Awake()
   {
      
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_15.Finished += uScriptAct_PlaySound_Finished_15;
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
      
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_15.Update( );
   }
   
   public void OnDestroy()
   {
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_15.Finished -= uScriptAct_PlaySound_Finished_15;
   }
   
   void Instance_KeyEvent_4(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_4( );
   }
   
   void Instance_KeyEvent_5(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_5( );
   }
   
   void Instance_OnEnterCollision_10(object o, uScript_Collision.CollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_RelativeVelocity_10 = e.RelativeVelocity;
      event_UnityEngine_GameObject_RigidBody_10 = e.RigidBody;
      event_UnityEngine_GameObject_Collider_10 = e.Collider;
      event_UnityEngine_GameObject_Transform_10 = e.Transform;
      event_UnityEngine_GameObject_Contacts_10 = e.Contacts;
      event_UnityEngine_GameObject_GameObject_10 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterCollision_10( );
   }
   
   void Instance_OnExitCollision_10(object o, uScript_Collision.CollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_RelativeVelocity_10 = e.RelativeVelocity;
      event_UnityEngine_GameObject_RigidBody_10 = e.RigidBody;
      event_UnityEngine_GameObject_Collider_10 = e.Collider;
      event_UnityEngine_GameObject_Transform_10 = e.Transform;
      event_UnityEngine_GameObject_Contacts_10 = e.Contacts;
      event_UnityEngine_GameObject_GameObject_10 = e.GameObject;
      //relay event to nodes
      Relay_OnExitCollision_10( );
   }
   
   void Instance_WhileInsideCollision_10(object o, uScript_Collision.CollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_RelativeVelocity_10 = e.RelativeVelocity;
      event_UnityEngine_GameObject_RigidBody_10 = e.RigidBody;
      event_UnityEngine_GameObject_Collider_10 = e.Collider;
      event_UnityEngine_GameObject_Transform_10 = e.Transform;
      event_UnityEngine_GameObject_Contacts_10 = e.Contacts;
      event_UnityEngine_GameObject_GameObject_10 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideCollision_10( );
   }
   
   void Instance_KeyEvent_18(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_18( );
   }
   
   void Instance_OnEnterCollision_19(object o, uScript_Collision.CollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_RelativeVelocity_19 = e.RelativeVelocity;
      event_UnityEngine_GameObject_RigidBody_19 = e.RigidBody;
      event_UnityEngine_GameObject_Collider_19 = e.Collider;
      event_UnityEngine_GameObject_Transform_19 = e.Transform;
      event_UnityEngine_GameObject_Contacts_19 = e.Contacts;
      event_UnityEngine_GameObject_GameObject_19 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterCollision_19( );
   }
   
   void Instance_OnExitCollision_19(object o, uScript_Collision.CollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_RelativeVelocity_19 = e.RelativeVelocity;
      event_UnityEngine_GameObject_RigidBody_19 = e.RigidBody;
      event_UnityEngine_GameObject_Collider_19 = e.Collider;
      event_UnityEngine_GameObject_Transform_19 = e.Transform;
      event_UnityEngine_GameObject_Contacts_19 = e.Contacts;
      event_UnityEngine_GameObject_GameObject_19 = e.GameObject;
      //relay event to nodes
      Relay_OnExitCollision_19( );
   }
   
   void Instance_WhileInsideCollision_19(object o, uScript_Collision.CollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_RelativeVelocity_19 = e.RelativeVelocity;
      event_UnityEngine_GameObject_RigidBody_19 = e.RigidBody;
      event_UnityEngine_GameObject_Collider_19 = e.Collider;
      event_UnityEngine_GameObject_Transform_19 = e.Transform;
      event_UnityEngine_GameObject_Contacts_19 = e.Contacts;
      event_UnityEngine_GameObject_GameObject_19 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideCollision_19( );
   }
   
   void Instance_KeyEvent_26(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_26( );
   }
   
   void Instance_KeyEvent_29(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_29( );
   }
   
   void uScriptAct_PlaySound_Finished_15(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_15( );
   }
   
   void Relay_In_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6d541d17-dfd9-43ba-bf9a-cd16fccf1831", "Input_Events_Filter", Relay_In_0)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_0.In(logic_uScriptAct_OnInputEventFilter_KeyCode_0);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_0.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_In_20();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("967db53c-3733-4c11-93ce-a73b83a96add", "Add_Vector3", Relay_In_2)) return; 
         {
            {
               logic_uScriptAct_AddVector3_v2_A_2 = local_14_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_AddVector3_v2_B_2 = local_24_UnityEngine_Vector3;
               
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_2.In(logic_uScriptAct_AddVector3_v2_A_2, logic_uScriptAct_AddVector3_v2_B_2, out logic_uScriptAct_AddVector3_v2_Result_2);
         local_14_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_v2_Result_2;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_2.Out;
         
         if ( test_0 == true )
         {
            Relay_In_23();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d94065ed-32f2-4bbe-97e0-8d83ff9e1e53", "Input_Events_Filter", Relay_In_3)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_3.In(logic_uScriptAct_OnInputEventFilter_KeyCode_3);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_3.KeyDown;
         
         if ( test_0 == true )
         {
            Relay_In_13();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_4()
   {
      if (true == CheckDebugBreak("6e12710f-dc84-47e1-b7e4-cc7c0f3b5de1", "Input_Events", Relay_KeyEvent_4)) return; 
      Relay_In_28();
   }
   
   void Relay_KeyEvent_5()
   {
      if (true == CheckDebugBreak("a097f6b8-ad4b-41a6-b493-dcaec63e9ee1", "Input_Events", Relay_KeyEvent_5)) return; 
      Relay_In_37();
   }
   
   void Relay_In_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("fa66c631-cc88-4620-8976-f1d948c1c3e8", "Add_Force", Relay_In_7)) return; 
         {
            {
               logic_uScriptAct_AddForce_Target_7 = owner_Connection_45;
               
            }
            {
               logic_uScriptAct_AddForce_Force_7 = local_9_UnityEngine_Vector3;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddForce_uScriptAct_AddForce_7.In(logic_uScriptAct_AddForce_Target_7, logic_uScriptAct_AddForce_Force_7, logic_uScriptAct_AddForce_Scale_7, logic_uScriptAct_AddForce_UseForceMode_7, logic_uScriptAct_AddForce_ForceModeType_7);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Add Force.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnEnterCollision_10()
   {
      if (true == CheckDebugBreak("88e8fae4-a5ca-43c6-a25f-3e44f7b7d835", "On_Collision", Relay_OnEnterCollision_10)) return; 
      Relay_Play_15();
   }
   
   void Relay_OnExitCollision_10()
   {
      if (true == CheckDebugBreak("88e8fae4-a5ca-43c6-a25f-3e44f7b7d835", "On_Collision", Relay_OnExitCollision_10)) return; 
   }
   
   void Relay_WhileInsideCollision_10()
   {
      if (true == CheckDebugBreak("88e8fae4-a5ca-43c6-a25f-3e44f7b7d835", "On_Collision", Relay_WhileInsideCollision_10)) return; 
   }
   
   void Relay_In_12()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e976feed-4333-4068-90c0-9a79a374d832", "Add_Vector3", Relay_In_12)) return; 
         {
            {
               logic_uScriptAct_AddVector3_v2_A_12 = local_38_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_AddVector3_v2_B_12 = local_1_UnityEngine_Vector3;
               
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_12.In(logic_uScriptAct_AddVector3_v2_A_12, logic_uScriptAct_AddVector3_v2_B_12, out logic_uScriptAct_AddVector3_v2_Result_12);
         local_38_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_v2_Result_12;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_12.Out;
         
         if ( test_0 == true )
         {
            Relay_In_34();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_13()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("17757096-883e-4c88-81fc-b175a560f4e6", "Compare_Bool", Relay_In_13)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_13 = local_Can_Jump__System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_13.In(logic_uScriptCon_CompareBool_Bool_13);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_13.True;
         
         if ( test_0 == true )
         {
            Relay_In_16();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_15()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("09d6155e-915a-4f90-984e-d28558029463", "Play_Sound", Relay_Finished_15)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Play_15()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("09d6155e-915a-4f90-984e-d28558029463", "Play_Sound", Relay_Play_15)) return; 
         {
            {
               logic_uScriptAct_PlaySound_audioClip_15 = property_JumpAudio_Detox_ScriptEditor_Parameter_JumpAudio_48_Get_Refresh( );
            }
            {
               int index = 0;
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_21_UnityEngine_GameObject_previous != local_21_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_21_UnityEngine_GameObject_previous = local_21_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               if ( logic_uScriptAct_PlaySound_target_15.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_PlaySound_target_15, index + 1);
               }
               logic_uScriptAct_PlaySound_target_15[ index++ ] = local_21_UnityEngine_GameObject;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_15.Play(logic_uScriptAct_PlaySound_audioClip_15, logic_uScriptAct_PlaySound_target_15, logic_uScriptAct_PlaySound_volume_15, logic_uScriptAct_PlaySound_loop_15);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_UpdateVolume_15()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("09d6155e-915a-4f90-984e-d28558029463", "Play_Sound", Relay_UpdateVolume_15)) return; 
         {
            {
               logic_uScriptAct_PlaySound_audioClip_15 = property_JumpAudio_Detox_ScriptEditor_Parameter_JumpAudio_48_Get_Refresh( );
            }
            {
               int index = 0;
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_21_UnityEngine_GameObject_previous != local_21_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_21_UnityEngine_GameObject_previous = local_21_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               if ( logic_uScriptAct_PlaySound_target_15.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_PlaySound_target_15, index + 1);
               }
               logic_uScriptAct_PlaySound_target_15[ index++ ] = local_21_UnityEngine_GameObject;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_15.UpdateVolume(logic_uScriptAct_PlaySound_audioClip_15, logic_uScriptAct_PlaySound_target_15, logic_uScriptAct_PlaySound_volume_15, logic_uScriptAct_PlaySound_loop_15);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_15()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("09d6155e-915a-4f90-984e-d28558029463", "Play_Sound", Relay_Stop_15)) return; 
         {
            {
               logic_uScriptAct_PlaySound_audioClip_15 = property_JumpAudio_Detox_ScriptEditor_Parameter_JumpAudio_48_Get_Refresh( );
            }
            {
               int index = 0;
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_21_UnityEngine_GameObject_previous != local_21_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_21_UnityEngine_GameObject_previous = local_21_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               if ( logic_uScriptAct_PlaySound_target_15.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_PlaySound_target_15, index + 1);
               }
               logic_uScriptAct_PlaySound_target_15[ index++ ] = local_21_UnityEngine_GameObject;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_15.Stop(logic_uScriptAct_PlaySound_audioClip_15, logic_uScriptAct_PlaySound_target_15, logic_uScriptAct_PlaySound_volume_15, logic_uScriptAct_PlaySound_loop_15);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_16()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("73c9f55c-cb67-472d-bb50-ad3314bbf493", "Add_Force", Relay_In_16)) return; 
         {
            {
               logic_uScriptAct_AddForce_Target_16 = owner_Connection_43;
               
            }
            {
               logic_uScriptAct_AddForce_Force_16 = local_39_UnityEngine_Vector3;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddForce_uScriptAct_AddForce_16.In(logic_uScriptAct_AddForce_Target_16, logic_uScriptAct_AddForce_Force_16, logic_uScriptAct_AddForce_Scale_16, logic_uScriptAct_AddForce_UseForceMode_16, logic_uScriptAct_AddForce_ForceModeType_16);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddForce_uScriptAct_AddForce_16.Out;
         
         if ( test_0 == true )
         {
            Relay_False_31();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Add Force.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_18()
   {
      if (true == CheckDebugBreak("99d8571c-6f3f-459f-a7ed-1be10386aba6", "Input_Events", Relay_KeyEvent_18)) return; 
      Relay_In_0();
   }
   
   void Relay_OnEnterCollision_19()
   {
      if (true == CheckDebugBreak("d2d7725b-f762-4b75-abc8-2a53bb13f47f", "On_Collision", Relay_OnEnterCollision_19)) return; 
      local_17_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_19;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_17_UnityEngine_GameObject_previous != local_17_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_17_UnityEngine_GameObject_previous = local_17_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
      Relay_In_30();
   }
   
   void Relay_OnExitCollision_19()
   {
      if (true == CheckDebugBreak("d2d7725b-f762-4b75-abc8-2a53bb13f47f", "On_Collision", Relay_OnExitCollision_19)) return; 
      local_17_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_19;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_17_UnityEngine_GameObject_previous != local_17_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_17_UnityEngine_GameObject_previous = local_17_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
   }
   
   void Relay_WhileInsideCollision_19()
   {
      if (true == CheckDebugBreak("d2d7725b-f762-4b75-abc8-2a53bb13f47f", "On_Collision", Relay_WhileInsideCollision_19)) return; 
      local_17_UnityEngine_GameObject = event_UnityEngine_GameObject_GameObject_19;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_17_UnityEngine_GameObject_previous != local_17_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_17_UnityEngine_GameObject_previous = local_17_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
   }
   
   void Relay_In_20()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("64321cec-2fd0-4ddb-b83e-ba1970d0e890", "Add_Vector3", Relay_In_20)) return; 
         {
            {
               logic_uScriptAct_AddVector3_v2_A_20 = local_33_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_AddVector3_v2_B_20 = local_9_UnityEngine_Vector3;
               
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_20.In(logic_uScriptAct_AddVector3_v2_A_20, logic_uScriptAct_AddVector3_v2_B_20, out logic_uScriptAct_AddVector3_v2_Result_20);
         local_33_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_v2_Result_20;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_20.Out;
         
         if ( test_0 == true )
         {
            Relay_In_7();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_23()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("38dc87b5-b8c8-438f-8eaf-c2b9df5bc4bb", "Add_Force", Relay_In_23)) return; 
         {
            {
               logic_uScriptAct_AddForce_Target_23 = owner_Connection_42;
               
            }
            {
               logic_uScriptAct_AddForce_Force_23 = local_24_UnityEngine_Vector3;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddForce_uScriptAct_AddForce_23.In(logic_uScriptAct_AddForce_Target_23, logic_uScriptAct_AddForce_Force_23, logic_uScriptAct_AddForce_Scale_23, logic_uScriptAct_AddForce_UseForceMode_23, logic_uScriptAct_AddForce_ForceModeType_23);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Add Force.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_25()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7b111d72-2696-45a4-b17f-35e87a2044aa", "Input_Events_Filter", Relay_In_25)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_25.In(logic_uScriptAct_OnInputEventFilter_KeyCode_25);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_25.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_In_2();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_26()
   {
      if (true == CheckDebugBreak("a3997f75-e0ec-403c-94f8-440bac6a01eb", "Input_Events", Relay_KeyEvent_26)) return; 
      Relay_In_3();
   }
   
   void Relay_In_27()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("10527add-8b96-43b9-81fa-57049b3409ea", "Add_Force", Relay_In_27)) return; 
         {
            {
               logic_uScriptAct_AddForce_Target_27 = owner_Connection_41;
               
            }
            {
               logic_uScriptAct_AddForce_Force_27 = local_8_UnityEngine_Vector3;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddForce_uScriptAct_AddForce_27.In(logic_uScriptAct_AddForce_Target_27, logic_uScriptAct_AddForce_Force_27, logic_uScriptAct_AddForce_Scale_27, logic_uScriptAct_AddForce_UseForceMode_27, logic_uScriptAct_AddForce_ForceModeType_27);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Add Force.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_28()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("fb8daa3f-64f6-44dd-9772-1aae171eb6b3", "Input_Events_Filter", Relay_In_28)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_28.In(logic_uScriptAct_OnInputEventFilter_KeyCode_28);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_28.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_In_12();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_29()
   {
      if (true == CheckDebugBreak("c8ecf3e7-46ba-4406-91d9-75b318299af5", "Input_Events", Relay_KeyEvent_29)) return; 
      Relay_In_25();
   }
   
   void Relay_In_30()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("be849bbd-181b-4341-939f-afc6aa55a4d5", "Compare_GameObjects", Relay_In_30)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_17_UnityEngine_GameObject_previous != local_17_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_17_UnityEngine_GameObject_previous = local_17_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptCon_CompareGameObjects_A_30 = local_17_UnityEngine_GameObject;
               
            }
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_6_UnityEngine_GameObject_previous != local_6_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptCon_CompareGameObjects_B_30 = local_6_UnityEngine_GameObject;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptCon_CompareGameObjects_uScriptCon_CompareGameObjects_30.In(logic_uScriptCon_CompareGameObjects_A_30, logic_uScriptCon_CompareGameObjects_B_30, logic_uScriptCon_CompareGameObjects_CompareByTag_30, logic_uScriptCon_CompareGameObjects_CompareByName_30, logic_uScriptCon_CompareGameObjects_ReportNull_30);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareGameObjects_uScriptCon_CompareGameObjects_30.Same;
         
         if ( test_0 == true )
         {
            Relay_True_35();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Compare GameObjects.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_31()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c2df141d-5539-4d18-8a95-3cb3e47633cd", "Set_Bool", Relay_True_31)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_31.True(out logic_uScriptAct_SetBool_Target_31);
         local_Can_Jump__System_Boolean = logic_uScriptAct_SetBool_Target_31;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_31()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c2df141d-5539-4d18-8a95-3cb3e47633cd", "Set_Bool", Relay_False_31)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_31.False(out logic_uScriptAct_SetBool_Target_31);
         local_Can_Jump__System_Boolean = logic_uScriptAct_SetBool_Target_31;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_34()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("68b1fb1b-4af9-43e0-9985-55746982c61f", "Add_Force", Relay_In_34)) return; 
         {
            {
               logic_uScriptAct_AddForce_Target_34 = owner_Connection_46;
               
            }
            {
               logic_uScriptAct_AddForce_Force_34 = local_1_UnityEngine_Vector3;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddForce_uScriptAct_AddForce_34.In(logic_uScriptAct_AddForce_Target_34, logic_uScriptAct_AddForce_Force_34, logic_uScriptAct_AddForce_Scale_34, logic_uScriptAct_AddForce_UseForceMode_34, logic_uScriptAct_AddForce_ForceModeType_34);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Add Force.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_35()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b950f7c4-f871-48ca-bb24-5266f2620f5a", "Set_Bool", Relay_True_35)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_35.True(out logic_uScriptAct_SetBool_Target_35);
         local_Can_Jump__System_Boolean = logic_uScriptAct_SetBool_Target_35;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_35()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b950f7c4-f871-48ca-bb24-5266f2620f5a", "Set_Bool", Relay_False_35)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_35.False(out logic_uScriptAct_SetBool_Target_35);
         local_Can_Jump__System_Boolean = logic_uScriptAct_SetBool_Target_35;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_37()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0ae44ffc-1368-40f0-a9f2-c66a4fa1238a", "Input_Events_Filter", Relay_In_37)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_37.In(logic_uScriptAct_OnInputEventFilter_KeyCode_37);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_37.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_In_40();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_40()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("06d1b029-d25f-4ced-a3ac-431bb671c3d2", "Add_Vector3", Relay_In_40)) return; 
         {
            {
               logic_uScriptAct_AddVector3_v2_A_40 = local_22_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_AddVector3_v2_B_40 = local_8_UnityEngine_Vector3;
               
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_40.In(logic_uScriptAct_AddVector3_v2_A_40, logic_uScriptAct_AddVector3_v2_B_40, out logic_uScriptAct_AddVector3_v2_Result_40);
         local_22_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_v2_Result_40;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_v2_uScriptAct_AddVector3_v2_40.Out;
         
         if ( test_0 == true )
         {
            Relay_In_27();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript CoinCollection_PlayerController.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_PlayerController.uscript:1", local_1_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "5ab0e284-b5b1-46b0-84b7-15c307a71be6", local_1_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_PlayerController.uscript:6", local_6_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "04180cec-6c4e-4524-a58e-8c81c7c5dcce", local_6_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_PlayerController.uscript:8", local_8_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "e63d5a97-9f70-404d-9fce-70c5c05d217d", local_8_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_PlayerController.uscript:9", local_9_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c21a392e-4c1c-4919-9227-cee4e123038c", local_9_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_PlayerController.uscript:Can Jump?", local_Can_Jump__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f07fae5a-b982-4528-aeeb-677711a76279", local_Can_Jump__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_PlayerController.uscript:14", local_14_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b6d9fdfd-51bc-4374-89ee-514b5a47a743", local_14_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_PlayerController.uscript:17", local_17_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "06ff6b85-f8ff-4edb-9cb5-cd8a4ae76362", local_17_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_PlayerController.uscript:21", local_21_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "0f8ec8ac-06d0-4e73-8296-7db253c1663c", local_21_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_PlayerController.uscript:22", local_22_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ce9b4c5b-4edf-4832-8392-54f85f54df6d", local_22_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_PlayerController.uscript:24", local_24_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "dd95d32d-db8f-46ca-9e3c-6544ffc50b34", local_24_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_PlayerController.uscript:33", local_33_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "285f9784-5600-406e-9e3f-2408d3af52ea", local_33_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_PlayerController.uscript:38", local_38_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a3f22101-d852-432f-a3dc-3efdfdc40f1b", local_38_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_PlayerController.uscript:39", local_39_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "2bddf279-21a3-47c4-a248-8c3dd385d6a9", local_39_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "793689b5-bb68-47c3-81a6-2ccdf40bd1c3", property_JumpAudio_Detox_ScriptEditor_Parameter_JumpAudio_48_Get_Refresh());
   }
   bool CheckDebugBreak(string guid, string name, ContinueExecution method)
   {
      if (true == m_Breakpoint) return true;
      
      if (true == uScript_MasterComponent.FindBreakpoint(guid))
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
