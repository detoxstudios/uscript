//uScript Generated Code - Build 0.9.2275
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class SquibEffect_Gameplay : uScriptLogic
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
   System.String local_0_System_String = "Grenade";
   System.Single local_13_System_Single = (float) 0.7;
   System.Int32 local_18_System_Int32 = (int) 0;
   UnityEngine.Vector3 local_2_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 local_20_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   System.Single local_22_System_Single = (float) 200;
   System.Single local_3_System_Single = (float) 0.5;
   UnityEngine.Camera local_32_UnityEngine_Camera = null;
   System.String local_33_System_String = "Grenades: ";
   UnityEngine.GameObject local_34_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_34_UnityEngine_GameObject_previous = null;
   System.String local_35_System_String = "";
   UnityEngine.Vector3 local_4_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   System.String local_40_System_String = "Squib";
   System.Int32 local_41_System_Int32 = (int) 1;
   UnityEngine.GameObject local_50_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_50_UnityEngine_GameObject_previous = null;
   System.String local_60_System_String = "";
   UnityEngine.GameObject local_62_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_62_UnityEngine_GameObject_previous = null;
   UnityEngine.Vector3 local_74_UnityEngine_Vector3 = new Vector3( (float)0, (float)0.75, (float)0 );
   System.Int32 local_76_System_Int32 = (int) 64;
   UnityEngine.KeyCode local_79_UnityEngine_KeyCode = UnityEngine.KeyCode.Mouse0;
   UnityEngine.Quaternion local_8_UnityEngine_Quaternion = new Quaternion( (float)0, (float)0, (float)0, (float)0 );
   System.Single local_80_System_Single = (float) 10;
   System.String local_83_System_String = "BulletDecal";
   UnityEngine.GameObject local_85_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_85_UnityEngine_GameObject_previous = null;
   UnityEngine.Vector3 local_93_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Rect local_Crosshair_Rect_UnityEngine_Rect = new Rect( (float)0, (float)0, (float)0, (float)0 );
   UnityEngine.Texture2D local_Crosshair_Texture2D_UnityEngine_Texture2D = null;
   System.Boolean local_Enable_Crosshair__System_Boolean = (bool) false;
   System.String local_EVENT_Grenade_UI_System_String = "Grenade_UI";
   System.Int32 local_Grenades_On_Hand_System_Int32 = (int) 10;
   UnityEngine.Vector3 local_PrefabLocation_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Quaternion local_PrefabRotation_UnityEngine_Quaternion = new Quaternion( (float)0, (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 local_RayHitLocation_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 local_RayHitNormal_UnityEngine_Vector3 = new Vector3( (float)0, (float)0, (float)0 );
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_RaycastFromCamera logic_uScriptAct_RaycastFromCamera_uScriptAct_RaycastFromCamera_5 = new uScriptAct_RaycastFromCamera( );
   UnityEngine.Camera logic_uScriptAct_RaycastFromCamera_Camera_5 = null;
   System.Int32 logic_uScriptAct_RaycastFromCamera_Offset_X_5 = (int) 0;
   System.Int32 logic_uScriptAct_RaycastFromCamera_Offset_Y_5 = (int) 0;
   System.Single logic_uScriptAct_RaycastFromCamera_Distance_5 = (float) 1000;
   UnityEngine.LayerMask logic_uScriptAct_RaycastFromCamera_layerMask_5 = 1;
   System.Boolean logic_uScriptAct_RaycastFromCamera_include_5 = (bool) true;
   System.Boolean logic_uScriptAct_RaycastFromCamera_showRay_5 = (bool) false;
   UnityEngine.GameObject logic_uScriptAct_RaycastFromCamera_HitObject_5;
   System.Single logic_uScriptAct_RaycastFromCamera_HitDistance_5;
   UnityEngine.Vector3 logic_uScriptAct_RaycastFromCamera_HitLocation_5;
   UnityEngine.Vector3 logic_uScriptAct_RaycastFromCamera_HitNormal_5;
   bool logic_uScriptAct_RaycastFromCamera_NotObstructed_5 = true;
   bool logic_uScriptAct_RaycastFromCamera_Obstructed_5 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_10 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_10 = "";
   System.String logic_uScriptCon_CompareString_B_10 = "";
   bool logic_uScriptCon_CompareString_Same_10 = true;
   bool logic_uScriptCon_CompareString_Different_10 = true;
   //pointer to script instanced logic node
   uScriptAct_LoadTexture2D logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_11 = new uScriptAct_LoadTexture2D( );
   System.String logic_uScriptAct_LoadTexture2D_name_11 = "crosshair";
   UnityEngine.Texture2D logic_uScriptAct_LoadTexture2D_textureFile_11;
   bool logic_uScriptAct_LoadTexture2D_Out_11 = true;
   //pointer to script instanced logic node
   uScriptAct_CreateRelativeRectScreen logic_uScriptAct_CreateRelativeRectScreen_uScriptAct_CreateRelativeRectScreen_17 = new uScriptAct_CreateRelativeRectScreen( );
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_RectWidth_17 = (int) 0;
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_RectHeight_17 = (int) 0;
   uScriptAct_CreateRelativeRectScreen.Position logic_uScriptAct_CreateRelativeRectScreen_RectPosition_17 = uScriptAct_CreateRelativeRectScreen.Position.MiddleCenter;
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_xOffset_17 = (int) 0;
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_yOffset_17 = (int) 0;
   UnityEngine.Rect logic_uScriptAct_CreateRelativeRectScreen_OutputRect_17;
   bool logic_uScriptAct_CreateRelativeRectScreen_Out_17 = true;
   //pointer to script instanced logic node
   uScriptAct_SpawnPrefabAtLocation logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_19 = new uScriptAct_SpawnPrefabAtLocation( );
   System.String logic_uScriptAct_SpawnPrefabAtLocation_PrefabName_19 = "";
   System.String logic_uScriptAct_SpawnPrefabAtLocation_ResourcePath_19 = "";
   UnityEngine.Vector3 logic_uScriptAct_SpawnPrefabAtLocation_SpawnPosition_19 = new Vector3( );
   UnityEngine.Quaternion logic_uScriptAct_SpawnPrefabAtLocation_SpawnRotation_19 = new Quaternion( );
   System.String logic_uScriptAct_SpawnPrefabAtLocation_SpawnedName_19 = "";
   UnityEngine.GameObject logic_uScriptAct_SpawnPrefabAtLocation_SpawnedGameObject_19;
   System.Int32 logic_uScriptAct_SpawnPrefabAtLocation_SpawnedInstancedID_19;
   bool logic_uScriptAct_SpawnPrefabAtLocation_Immediate_19 = true;
   //pointer to script instanced logic node
   uScriptAct_GUITexture logic_uScriptAct_GUITexture_uScriptAct_GUITexture_23 = new uScriptAct_GUITexture( );
   UnityEngine.Rect logic_uScriptAct_GUITexture_Position_23 = new Rect( );
   UnityEngine.Texture2D logic_uScriptAct_GUITexture_Texture_23 = null;
   UnityEngine.ScaleMode logic_uScriptAct_GUITexture_scaleMode_23 = UnityEngine.ScaleMode.StretchToFill;
   System.Boolean logic_uScriptAct_GUITexture_alphaBlend_23 = (bool) true;
   System.Single logic_uScriptAct_GUITexture_aspect_23 = (float) 1;
   bool logic_uScriptAct_GUITexture_Out_23 = true;
   //pointer to script instanced logic node
   uScriptAct_Concatenate logic_uScriptAct_Concatenate_uScriptAct_Concatenate_27 = new uScriptAct_Concatenate( );
   System.Object[] logic_uScriptAct_Concatenate_A_27 = new System.Object[] {};
   System.Object[] logic_uScriptAct_Concatenate_B_27 = new System.Object[] {};
   System.String logic_uScriptAct_Concatenate_Separator_27 = " ";
   System.String logic_uScriptAct_Concatenate_Result_27;
   bool logic_uScriptAct_Concatenate_Out_27 = true;
   //pointer to script instanced logic node
   uScriptAct_SendCustomEventInt logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_31 = new uScriptAct_SendCustomEventInt( );
   System.String logic_uScriptAct_SendCustomEventInt_EventName_31 = "";
   System.Int32 logic_uScriptAct_SendCustomEventInt_EventValue_31 = (int) 0;
   uScriptCustomEvent.SendGroup logic_uScriptAct_SendCustomEventInt_sendGroup_31 = uScriptCustomEvent.SendGroup.Parents;
   UnityEngine.GameObject logic_uScriptAct_SendCustomEventInt_EventSender_31 = null;
   bool logic_uScriptAct_SendCustomEventInt_Out_31 = true;
   //pointer to script instanced logic node
   uScriptCon_TimedGate logic_uScriptCon_TimedGate_uScriptCon_TimedGate_37 = new uScriptCon_TimedGate( );
   System.Single logic_uScriptCon_TimedGate_Duration_37 = (float) 0;
   System.Boolean logic_uScriptCon_TimedGate_StartOpen_37 = (bool) true;
   bool logic_uScriptCon_TimedGate_TooSoon_37 = true;
   //pointer to script instanced logic node
   uScriptAct_SendCustomEventInt logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_38 = new uScriptAct_SendCustomEventInt( );
   System.String logic_uScriptAct_SendCustomEventInt_EventName_38 = "";
   System.Int32 logic_uScriptAct_SendCustomEventInt_EventValue_38 = (int) 0;
   uScriptCustomEvent.SendGroup logic_uScriptAct_SendCustomEventInt_sendGroup_38 = uScriptCustomEvent.SendGroup.Parents;
   UnityEngine.GameObject logic_uScriptAct_SendCustomEventInt_EventSender_38 = null;
   bool logic_uScriptAct_SendCustomEventInt_Out_38 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_39 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_39 = UnityEngine.KeyCode.None;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_39 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_39 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_39 = true;
   //pointer to script instanced logic node
   uScriptAct_SpawnPrefabAtLocation logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_42 = new uScriptAct_SpawnPrefabAtLocation( );
   System.String logic_uScriptAct_SpawnPrefabAtLocation_PrefabName_42 = "";
   System.String logic_uScriptAct_SpawnPrefabAtLocation_ResourcePath_42 = "";
   UnityEngine.Vector3 logic_uScriptAct_SpawnPrefabAtLocation_SpawnPosition_42 = new Vector3( );
   UnityEngine.Quaternion logic_uScriptAct_SpawnPrefabAtLocation_SpawnRotation_42 = new Quaternion( );
   System.String logic_uScriptAct_SpawnPrefabAtLocation_SpawnedName_42 = "";
   UnityEngine.GameObject logic_uScriptAct_SpawnPrefabAtLocation_SpawnedGameObject_42;
   System.Int32 logic_uScriptAct_SpawnPrefabAtLocation_SpawnedInstancedID_42;
   bool logic_uScriptAct_SpawnPrefabAtLocation_Immediate_42 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_43 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_43 = "";
   System.Int32 logic_uScriptAct_PrintText_FontSize_43 = (int) 32;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_43 = UnityEngine.FontStyle.Normal;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_43 = new UnityEngine.Color( (float)0.8470588, (float)1, (float)0.6705883, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_43 = UnityEngine.TextAnchor.UpperLeft;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_43 = (int) 64;
   System.Single logic_uScriptAct_PrintText_time_43 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_43 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_47 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_47;
   bool logic_uScriptAct_SetBool_Out_47 = true;
   bool logic_uScriptAct_SetBool_SetTrue_47 = true;
   bool logic_uScriptAct_SetBool_SetFalse_47 = true;
   //pointer to script instanced logic node
   uScriptAct_AddForce logic_uScriptAct_AddForce_uScriptAct_AddForce_49 = new uScriptAct_AddForce( );
   UnityEngine.GameObject logic_uScriptAct_AddForce_Target_49 = null;
   UnityEngine.Vector3 logic_uScriptAct_AddForce_Force_49 = new Vector3( );
   System.Single logic_uScriptAct_AddForce_Scale_49 = (float) 0;
   System.Boolean logic_uScriptAct_AddForce_UseForceMode_49 = (bool) false;
   UnityEngine.ForceMode logic_uScriptAct_AddForce_ForceModeType_49 = UnityEngine.ForceMode.Force;
   bool logic_uScriptAct_AddForce_Out_49 = true;
   //pointer to script instanced logic node
   uScriptAct_SubtractInt logic_uScriptAct_SubtractInt_uScriptAct_SubtractInt_51 = new uScriptAct_SubtractInt( );
   System.Int32 logic_uScriptAct_SubtractInt_A_51 = (int) 0;
   System.Int32 logic_uScriptAct_SubtractInt_B_51 = (int) 0;
   System.Int32 logic_uScriptAct_SubtractInt_IntResult_51;
   System.Single logic_uScriptAct_SubtractInt_FloatResult_51;
   bool logic_uScriptAct_SubtractInt_Out_51 = true;
   //pointer to script instanced logic node
   uScriptAct_VectorsFromQuaternion logic_uScriptAct_VectorsFromQuaternion_uScriptAct_VectorsFromQuaternion_52 = new uScriptAct_VectorsFromQuaternion( );
   UnityEngine.Quaternion logic_uScriptAct_VectorsFromQuaternion_quaternion_52 = new Quaternion( );
   UnityEngine.Vector3 logic_uScriptAct_VectorsFromQuaternion_forward_52;
   UnityEngine.Vector3 logic_uScriptAct_VectorsFromQuaternion_up_52;
   bool logic_uScriptAct_VectorsFromQuaternion_Out_52 = true;
   //pointer to script instanced logic node
   uScriptAct_GetPositionAndRotation logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_56 = new uScriptAct_GetPositionAndRotation( );
   UnityEngine.GameObject logic_uScriptAct_GetPositionAndRotation_Target_56 = null;
   System.Boolean logic_uScriptAct_GetPositionAndRotation_GetLocal_56 = (bool) false;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Position_56;
   UnityEngine.Quaternion logic_uScriptAct_GetPositionAndRotation_Rotation_56;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_EulerAngles_56;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Forward_56;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Up_56;
   UnityEngine.Vector3 logic_uScriptAct_GetPositionAndRotation_Right_56;
   bool logic_uScriptAct_GetPositionAndRotation_Out_56 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector3 logic_uScriptAct_AddVector3_uScriptAct_AddVector3_63 = new uScriptAct_AddVector3( );
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_A_63 = new Vector3[] {};
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_B_63 = new Vector3[] {};
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_Result_63;
   bool logic_uScriptAct_AddVector3_Out_63 = true;
   //pointer to script instanced logic node
   uScriptAct_Destroy logic_uScriptAct_Destroy_uScriptAct_Destroy_68 = new uScriptAct_Destroy( );
   UnityEngine.GameObject[] logic_uScriptAct_Destroy_Target_68 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_Destroy_DelayTime_68 = (float) 0;
   bool logic_uScriptAct_Destroy_Out_68 = true;
   bool logic_uScriptAct_Destroy_ObjectsDestroyed_68 = true;
   bool logic_uScriptAct_Destroy_WaitOneTick_68 = false;
   //pointer to script instanced logic node
   uScriptCon_CompareInt logic_uScriptCon_CompareInt_uScriptCon_CompareInt_69 = new uScriptCon_CompareInt( );
   System.Int32 logic_uScriptCon_CompareInt_A_69 = (int) 0;
   System.Int32 logic_uScriptCon_CompareInt_B_69 = (int) 0;
   bool logic_uScriptCon_CompareInt_GreaterThan_69 = true;
   bool logic_uScriptCon_CompareInt_GreaterThanOrEqualTo_69 = true;
   bool logic_uScriptCon_CompareInt_EqualTo_69 = true;
   bool logic_uScriptCon_CompareInt_NotEqualTo_69 = true;
   bool logic_uScriptCon_CompareInt_LessThanOrEqualTo_69 = true;
   bool logic_uScriptCon_CompareInt_LessThan_69 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_70 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_70 = UnityEngine.KeyCode.Mouse1;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_70 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_70 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_70 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_75 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_75 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_75 = true;
   bool logic_uScriptCon_CompareBool_False_75 = true;
   //pointer to script instanced logic node
   uScriptAct_QuaternionFromVectors logic_uScriptAct_QuaternionFromVectors_uScriptAct_QuaternionFromVectors_78 = new uScriptAct_QuaternionFromVectors( );
   UnityEngine.Vector3 logic_uScriptAct_QuaternionFromVectors_forward_78 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Vector3 logic_uScriptAct_QuaternionFromVectors_up_78 = new Vector3( );
   UnityEngine.Quaternion logic_uScriptAct_QuaternionFromVectors_result_78;
   bool logic_uScriptAct_QuaternionFromVectors_Out_78 = true;
   //pointer to script instanced logic node
   uScriptAct_SpawnPrefabAtLocation logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_82 = new uScriptAct_SpawnPrefabAtLocation( );
   System.String logic_uScriptAct_SpawnPrefabAtLocation_PrefabName_82 = "";
   System.String logic_uScriptAct_SpawnPrefabAtLocation_ResourcePath_82 = "";
   UnityEngine.Vector3 logic_uScriptAct_SpawnPrefabAtLocation_SpawnPosition_82 = new Vector3( );
   UnityEngine.Quaternion logic_uScriptAct_SpawnPrefabAtLocation_SpawnRotation_82 = new Quaternion( );
   System.String logic_uScriptAct_SpawnPrefabAtLocation_SpawnedName_82 = "";
   UnityEngine.GameObject logic_uScriptAct_SpawnPrefabAtLocation_SpawnedGameObject_82;
   System.Int32 logic_uScriptAct_SpawnPrefabAtLocation_SpawnedInstancedID_82;
   bool logic_uScriptAct_SpawnPrefabAtLocation_Immediate_82 = true;
   //pointer to script instanced logic node
   uScriptAct_Destroy logic_uScriptAct_Destroy_uScriptAct_Destroy_84 = new uScriptAct_Destroy( );
   UnityEngine.GameObject[] logic_uScriptAct_Destroy_Target_84 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_Destroy_DelayTime_84 = (float) 0;
   bool logic_uScriptAct_Destroy_Out_84 = true;
   bool logic_uScriptAct_Destroy_ObjectsDestroyed_84 = true;
   bool logic_uScriptAct_Destroy_WaitOneTick_84 = false;
   //pointer to script instanced logic node
   uScriptAct_AddVector3 logic_uScriptAct_AddVector3_uScriptAct_AddVector3_88 = new uScriptAct_AddVector3( );
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_A_88 = new Vector3[] {};
   UnityEngine.Vector3[] logic_uScriptAct_AddVector3_B_88 = new Vector3[] {};
   UnityEngine.Vector3 logic_uScriptAct_AddVector3_Result_88;
   bool logic_uScriptAct_AddVector3_Out_88 = true;
   //pointer to script instanced logic node
   uScriptAct_DivideVector3WithFloat logic_uScriptAct_DivideVector3WithFloat_uScriptAct_DivideVector3WithFloat_92 = new uScriptAct_DivideVector3WithFloat( );
   UnityEngine.Vector3 logic_uScriptAct_DivideVector3WithFloat_targetVector3_92 = new Vector3( );
   System.Single logic_uScriptAct_DivideVector3WithFloat_targetFloat_92 = (float) 100;
   UnityEngine.Vector3 logic_uScriptAct_DivideVector3WithFloat_Result_92;
   bool logic_uScriptAct_DivideVector3WithFloat_Out_92 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_21 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_44 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_54 = null;
   System.String event_UnityEngine_GameObject_EventName_54 = "";
   System.Int32 event_UnityEngine_GameObject_EventData_54 = (int) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_54 = null;
   System.Boolean event_UnityEngine_GameObject_GUIChanged_65 = (bool) false;
   System.String event_UnityEngine_GameObject_FocusedControl_65 = "";
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_65 = null;
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      if ( null == local_32_UnityEngine_Camera || false == m_RegisteredForEvents )
      {
         GameObject gameObject = GameObject.Find( "Main Camera" );
         if ( null != gameObject )
         {
            local_32_UnityEngine_Camera = gameObject.GetComponent<UnityEngine.Camera>();
         }
      }
      if ( null == local_34_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_34_UnityEngine_GameObject = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_34_UnityEngine_GameObject_previous != local_34_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_34_UnityEngine_GameObject_previous = local_34_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_50_UnityEngine_GameObject_previous != local_50_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_50_UnityEngine_GameObject_previous = local_50_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_62_UnityEngine_GameObject_previous != local_62_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_62_UnityEngine_GameObject_previous = local_62_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_85_UnityEngine_GameObject_previous != local_85_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_85_UnityEngine_GameObject_previous = local_85_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_34_UnityEngine_GameObject_previous != local_34_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_34_UnityEngine_GameObject_previous = local_34_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_50_UnityEngine_GameObject_previous != local_50_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_50_UnityEngine_GameObject_previous = local_50_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_62_UnityEngine_GameObject_previous != local_62_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_62_UnityEngine_GameObject_previous = local_62_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_85_UnityEngine_GameObject_previous != local_85_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_85_UnityEngine_GameObject_previous = local_85_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void SyncEventListeners( )
   {
      if ( null == event_UnityEngine_GameObject_Instance_21 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_21 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_21 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_21.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_21.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_21;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_44 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_44 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_44 )
         {
            {
               uScript_Global component = event_UnityEngine_GameObject_Instance_44.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_44.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_44;
                  component.uScriptLateStart += Instance_uScriptLateStart_44;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_54 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_54 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_54 )
         {
            {
               uScript_CustomEventInt component = event_UnityEngine_GameObject_Instance_54.GetComponent<uScript_CustomEventInt>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_54.AddComponent<uScript_CustomEventInt>();
               }
               if ( null != component )
               {
                  component.OnCustomEventInt += Instance_OnCustomEventInt_54;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_65 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_65 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_65 )
         {
            {
               if ( null == thisScriptsOnGuiListener )
               {
                  //OnGUI need unique listeners so calls like GUI.depth will work across uScripts
                  thisScriptsOnGuiListener = event_UnityEngine_GameObject_Instance_65.AddComponent<uScript_GUI>();
               }
               uScript_GUI component = thisScriptsOnGuiListener;
               if ( null != component )
               {
                  component.OnGui += Instance_OnGui_65;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != event_UnityEngine_GameObject_Instance_21 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_21.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_21;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_44 )
      {
         {
            uScript_Global component = event_UnityEngine_GameObject_Instance_44.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_44;
               component.uScriptLateStart -= Instance_uScriptLateStart_44;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_54 )
      {
         {
            uScript_CustomEventInt component = event_UnityEngine_GameObject_Instance_54.GetComponent<uScript_CustomEventInt>();
            if ( null != component )
            {
               component.OnCustomEventInt -= Instance_OnCustomEventInt_54;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_65 )
      {
         {
            if ( null == thisScriptsOnGuiListener )
            {
               //OnGUI need unique listeners so calls like GUI.depth will work across uScripts
               thisScriptsOnGuiListener = event_UnityEngine_GameObject_Instance_65.AddComponent<uScript_GUI>();
            }
            uScript_GUI component = thisScriptsOnGuiListener;
            if ( null != component )
            {
               component.OnGui -= Instance_OnGui_65;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_RaycastFromCamera_uScriptAct_RaycastFromCamera_5.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_10.SetParent(g);
      logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_11.SetParent(g);
      logic_uScriptAct_CreateRelativeRectScreen_uScriptAct_CreateRelativeRectScreen_17.SetParent(g);
      logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_19.SetParent(g);
      logic_uScriptAct_GUITexture_uScriptAct_GUITexture_23.SetParent(g);
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_27.SetParent(g);
      logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_31.SetParent(g);
      logic_uScriptCon_TimedGate_uScriptCon_TimedGate_37.SetParent(g);
      logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_38.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_39.SetParent(g);
      logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_42.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_43.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_47.SetParent(g);
      logic_uScriptAct_AddForce_uScriptAct_AddForce_49.SetParent(g);
      logic_uScriptAct_SubtractInt_uScriptAct_SubtractInt_51.SetParent(g);
      logic_uScriptAct_VectorsFromQuaternion_uScriptAct_VectorsFromQuaternion_52.SetParent(g);
      logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_56.SetParent(g);
      logic_uScriptAct_AddVector3_uScriptAct_AddVector3_63.SetParent(g);
      logic_uScriptAct_Destroy_uScriptAct_Destroy_68.SetParent(g);
      logic_uScriptCon_CompareInt_uScriptCon_CompareInt_69.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_70.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_75.SetParent(g);
      logic_uScriptAct_QuaternionFromVectors_uScriptAct_QuaternionFromVectors_78.SetParent(g);
      logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_82.SetParent(g);
      logic_uScriptAct_Destroy_uScriptAct_Destroy_84.SetParent(g);
      logic_uScriptAct_AddVector3_uScriptAct_AddVector3_88.SetParent(g);
      logic_uScriptAct_DivideVector3WithFloat_uScriptAct_DivideVector3WithFloat_92.SetParent(g);
   }
   public void Awake()
   {
      
      logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_19.FinishedSpawning += uScriptAct_SpawnPrefabAtLocation_FinishedSpawning_19;
      logic_uScriptCon_TimedGate_uScriptCon_TimedGate_37.Out += uScriptCon_TimedGate_Out_37;
      logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_42.FinishedSpawning += uScriptAct_SpawnPrefabAtLocation_FinishedSpawning_42;
      logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_82.FinishedSpawning += uScriptAct_SpawnPrefabAtLocation_FinishedSpawning_82;
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
      
      logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_19.Update( );
      logic_uScriptCon_TimedGate_uScriptCon_TimedGate_37.Update( );
      logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_42.Update( );
      logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_82.Update( );
      if (true == logic_uScriptAct_Destroy_WaitOneTick_68)
      {
         Relay_WaitOneTick_68();
      }
      if (true == logic_uScriptAct_Destroy_WaitOneTick_84)
      {
         Relay_WaitOneTick_84();
      }
   }
   
   public void OnDestroy()
   {
      logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_19.FinishedSpawning -= uScriptAct_SpawnPrefabAtLocation_FinishedSpawning_19;
      logic_uScriptCon_TimedGate_uScriptCon_TimedGate_37.Out -= uScriptCon_TimedGate_Out_37;
      logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_42.FinishedSpawning -= uScriptAct_SpawnPrefabAtLocation_FinishedSpawning_42;
      logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_82.FinishedSpawning -= uScriptAct_SpawnPrefabAtLocation_FinishedSpawning_82;
   }
   
   public void OnGUI()
   {
      logic_uScriptAct_PrintText_uScriptAct_PrintText_43.OnGUI( );
   }
   
   void Instance_KeyEvent_21(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_21( );
   }
   
   void Instance_uScriptStart_44(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_44( );
   }
   
   void Instance_uScriptLateStart_44(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptLateStart_44( );
   }
   
   void Instance_OnCustomEventInt_54(object o, uScript_CustomEventInt.CustomEventIntArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_54 = e.Sender;
      event_UnityEngine_GameObject_EventName_54 = e.EventName;
      event_UnityEngine_GameObject_EventData_54 = e.EventData;
      //relay event to nodes
      Relay_OnCustomEventInt_54( );
   }
   
   void Instance_OnGui_65(object o, uScript_GUI.GUIEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GUIChanged_65 = e.GUIChanged;
      event_UnityEngine_GameObject_FocusedControl_65 = e.FocusedControl;
      //relay event to nodes
      Relay_OnGui_65( );
   }
   
   void uScriptAct_SpawnPrefabAtLocation_FinishedSpawning_19(object o, System.EventArgs e)
   {
      //fill globals
      //links to SpawnedGameObject = 1
      local_62_UnityEngine_GameObject = logic_uScriptAct_SpawnPrefabAtLocation_SpawnedGameObject_19;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_62_UnityEngine_GameObject_previous != local_62_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_62_UnityEngine_GameObject_previous = local_62_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
      //links to SpawnedInstancedID = 0
      //relay event to nodes
      Relay_FinishedSpawning_19( );
   }
   
   void uScriptCon_TimedGate_Out_37(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Out_37( );
   }
   
   void uScriptAct_SpawnPrefabAtLocation_FinishedSpawning_42(object o, System.EventArgs e)
   {
      //fill globals
      //links to SpawnedGameObject = 1
      local_50_UnityEngine_GameObject = logic_uScriptAct_SpawnPrefabAtLocation_SpawnedGameObject_42;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_50_UnityEngine_GameObject_previous != local_50_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_50_UnityEngine_GameObject_previous = local_50_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
      //links to SpawnedInstancedID = 0
      //relay event to nodes
      Relay_FinishedSpawning_42( );
   }
   
   void uScriptAct_SpawnPrefabAtLocation_FinishedSpawning_82(object o, System.EventArgs e)
   {
      //fill globals
      //links to SpawnedGameObject = 1
      local_85_UnityEngine_GameObject = logic_uScriptAct_SpawnPrefabAtLocation_SpawnedGameObject_82;
      {
         //if our game object reference was changed then we need to reset event listeners
         if ( local_85_UnityEngine_GameObject_previous != local_85_UnityEngine_GameObject || false == m_RegisteredForEvents )
         {
            //tear down old listeners
            
            local_85_UnityEngine_GameObject_previous = local_85_UnityEngine_GameObject;
            
            //setup new listeners
         }
      }
      //links to SpawnedInstancedID = 0
      //relay event to nodes
      Relay_FinishedSpawning_82( );
   }
   
   void Relay_In_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("fd77c1d3-fd73-47be-a4d5-5281a034ad87", "Raycast From Camera", Relay_In_5)) return; 
         {
            {
               logic_uScriptAct_RaycastFromCamera_Camera_5 = local_32_UnityEngine_Camera;
               
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
         logic_uScriptAct_RaycastFromCamera_uScriptAct_RaycastFromCamera_5.In(logic_uScriptAct_RaycastFromCamera_Camera_5, logic_uScriptAct_RaycastFromCamera_Offset_X_5, logic_uScriptAct_RaycastFromCamera_Offset_Y_5, logic_uScriptAct_RaycastFromCamera_Distance_5, logic_uScriptAct_RaycastFromCamera_layerMask_5, logic_uScriptAct_RaycastFromCamera_include_5, logic_uScriptAct_RaycastFromCamera_showRay_5, out logic_uScriptAct_RaycastFromCamera_HitObject_5, out logic_uScriptAct_RaycastFromCamera_HitDistance_5, out logic_uScriptAct_RaycastFromCamera_HitLocation_5, out logic_uScriptAct_RaycastFromCamera_HitNormal_5);
         local_RayHitLocation_UnityEngine_Vector3 = logic_uScriptAct_RaycastFromCamera_HitLocation_5;
         local_RayHitNormal_UnityEngine_Vector3 = logic_uScriptAct_RaycastFromCamera_HitNormal_5;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_RaycastFromCamera_uScriptAct_RaycastFromCamera_5.Obstructed;
         
         if ( test_0 == true )
         {
            Relay_In_78();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Raycast From Camera.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4a519ab5-0f88-48fd-99e9-7757bd132764", "Compare String", Relay_In_10)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_10 = local_60_System_String;
               
            }
            {
               logic_uScriptCon_CompareString_B_10 = local_EVENT_Grenade_UI_System_String;
               
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_10.In(logic_uScriptCon_CompareString_A_10, logic_uScriptCon_CompareString_B_10);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_10.Same;
         
         if ( test_0 == true )
         {
            Relay_In_27();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_11()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("fbf5f0cb-069d-4b6a-a89d-b4f01c2a2a89", "Load Texture2D", Relay_In_11)) return; 
         {
            {
            }
            {
            }
         }
         logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_11.In(logic_uScriptAct_LoadTexture2D_name_11, out logic_uScriptAct_LoadTexture2D_textureFile_11);
         local_Crosshair_Texture2D_UnityEngine_Texture2D = logic_uScriptAct_LoadTexture2D_textureFile_11;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_11.Out;
         
         if ( test_0 == true )
         {
            Relay_True_47();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Load Texture2D.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_17()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2a5d3293-369f-4dd7-a361-80f859f2cfd1", "Create Relative Rect (Screen)", Relay_In_17)) return; 
         {
            {
               logic_uScriptAct_CreateRelativeRectScreen_RectWidth_17 = local_76_System_Int32;
               
            }
            {
               logic_uScriptAct_CreateRelativeRectScreen_RectHeight_17 = local_76_System_Int32;
               
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
         logic_uScriptAct_CreateRelativeRectScreen_uScriptAct_CreateRelativeRectScreen_17.In(logic_uScriptAct_CreateRelativeRectScreen_RectWidth_17, logic_uScriptAct_CreateRelativeRectScreen_RectHeight_17, logic_uScriptAct_CreateRelativeRectScreen_RectPosition_17, logic_uScriptAct_CreateRelativeRectScreen_xOffset_17, logic_uScriptAct_CreateRelativeRectScreen_yOffset_17, out logic_uScriptAct_CreateRelativeRectScreen_OutputRect_17);
         local_Crosshair_Rect_UnityEngine_Rect = logic_uScriptAct_CreateRelativeRectScreen_OutputRect_17;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_CreateRelativeRectScreen_uScriptAct_CreateRelativeRectScreen_17.Out;
         
         if ( test_0 == true )
         {
            Relay_In_11();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Create Relative Rect (Screen).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_FinishedSpawning_19()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("dbfcadde-8ed5-479c-8299-664738209217", "Spawn Prefab At Location", Relay_FinishedSpawning_19)) return; 
         Relay_In_68();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Spawn Prefab At Location.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_19()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("dbfcadde-8ed5-479c-8299-664738209217", "Spawn Prefab At Location", Relay_In_19)) return; 
         {
            {
               logic_uScriptAct_SpawnPrefabAtLocation_PrefabName_19 = local_40_System_String;
               
            }
            {
            }
            {
               logic_uScriptAct_SpawnPrefabAtLocation_SpawnPosition_19 = local_PrefabLocation_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_SpawnPrefabAtLocation_SpawnRotation_19 = local_PrefabRotation_UnityEngine_Quaternion;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_19.In(logic_uScriptAct_SpawnPrefabAtLocation_PrefabName_19, logic_uScriptAct_SpawnPrefabAtLocation_ResourcePath_19, logic_uScriptAct_SpawnPrefabAtLocation_SpawnPosition_19, logic_uScriptAct_SpawnPrefabAtLocation_SpawnRotation_19, logic_uScriptAct_SpawnPrefabAtLocation_SpawnedName_19, out logic_uScriptAct_SpawnPrefabAtLocation_SpawnedGameObject_19, out logic_uScriptAct_SpawnPrefabAtLocation_SpawnedInstancedID_19);
         local_62_UnityEngine_GameObject = logic_uScriptAct_SpawnPrefabAtLocation_SpawnedGameObject_19;
         {
            //if our game object reference was changed then we need to reset event listeners
            if ( local_62_UnityEngine_GameObject_previous != local_62_UnityEngine_GameObject || false == m_RegisteredForEvents )
            {
               //tear down old listeners
               
               local_62_UnityEngine_GameObject_previous = local_62_UnityEngine_GameObject;
               
               //setup new listeners
            }
         }
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Spawn Prefab At Location.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_21()
   {
      if (true == CheckDebugBreak("8db4b60c-9bf6-4a2a-8ccf-ad82dbc8ddee", "Input Events", Relay_KeyEvent_21)) return; 
      Relay_In_70();
      Relay_In_39();
   }
   
   void Relay_In_23()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d2686224-5beb-444b-93dc-40f15a0a7ce7", "GUI Texture", Relay_In_23)) return; 
         {
            {
               logic_uScriptAct_GUITexture_Position_23 = local_Crosshair_Rect_UnityEngine_Rect;
               
            }
            {
               logic_uScriptAct_GUITexture_Texture_23 = local_Crosshair_Texture2D_UnityEngine_Texture2D;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_GUITexture_uScriptAct_GUITexture_23.In(logic_uScriptAct_GUITexture_Position_23, logic_uScriptAct_GUITexture_Texture_23, logic_uScriptAct_GUITexture_scaleMode_23, logic_uScriptAct_GUITexture_alphaBlend_23, logic_uScriptAct_GUITexture_aspect_23);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at GUI Texture.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_27()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ebe0881f-4ab9-45f3-b19a-9af4e7034095", "Concatenate", Relay_In_27)) return; 
         {
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_33_System_String);
               logic_uScriptAct_Concatenate_A_27 = properties.ToArray();
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_Grenades_On_Hand_System_Int32);
               logic_uScriptAct_Concatenate_B_27 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_Concatenate_uScriptAct_Concatenate_27.In(logic_uScriptAct_Concatenate_A_27, logic_uScriptAct_Concatenate_B_27, logic_uScriptAct_Concatenate_Separator_27, out logic_uScriptAct_Concatenate_Result_27);
         local_35_System_String = logic_uScriptAct_Concatenate_Result_27;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Concatenate_uScriptAct_Concatenate_27.Out;
         
         if ( test_0 == true )
         {
            Relay_ShowLabel_43();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Concatenate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_SendCustomEvent_31()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("aaa2007a-0809-4572-a4d5-4fd15eb86a2d", "Send Custom Event (Int)", Relay_SendCustomEvent_31)) return; 
         {
            {
               logic_uScriptAct_SendCustomEventInt_EventName_31 = local_EVENT_Grenade_UI_System_String;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_31.SendCustomEvent(logic_uScriptAct_SendCustomEventInt_EventName_31, logic_uScriptAct_SendCustomEventInt_EventValue_31, logic_uScriptAct_SendCustomEventInt_sendGroup_31, logic_uScriptAct_SendCustomEventInt_EventSender_31);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Send Custom Event (Int).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Out_37()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("424d9d71-3a5b-47d1-8ea1-ef81e7b9d402", "Timed Gate", Relay_Out_37)) return; 
         Relay_In_51();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Timed Gate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_37()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("424d9d71-3a5b-47d1-8ea1-ef81e7b9d402", "Timed Gate", Relay_In_37)) return; 
         {
            {
               logic_uScriptCon_TimedGate_Duration_37 = local_3_System_Single;
               
            }
            {
            }
         }
         logic_uScriptCon_TimedGate_uScriptCon_TimedGate_37.In(logic_uScriptCon_TimedGate_Duration_37, logic_uScriptCon_TimedGate_StartOpen_37);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Timed Gate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_SendCustomEvent_38()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c0c2cfc7-2d1c-4dc2-9e59-6911302e3d97", "Send Custom Event (Int)", Relay_SendCustomEvent_38)) return; 
         {
            {
               logic_uScriptAct_SendCustomEventInt_EventName_38 = local_EVENT_Grenade_UI_System_String;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SendCustomEventInt_uScriptAct_SendCustomEventInt_38.SendCustomEvent(logic_uScriptAct_SendCustomEventInt_EventName_38, logic_uScriptAct_SendCustomEventInt_EventValue_38, logic_uScriptAct_SendCustomEventInt_sendGroup_38, logic_uScriptAct_SendCustomEventInt_EventSender_38);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Send Custom Event (Int).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_39()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1600261b-67d6-43b7-b8f9-9ccfab248312", "Input Events Filter", Relay_In_39)) return; 
         {
            {
               logic_uScriptAct_OnInputEventFilter_KeyCode_39 = local_79_UnityEngine_KeyCode;
               
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_39.In(logic_uScriptAct_OnInputEventFilter_KeyCode_39);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_39.KeyDown;
         
         if ( test_0 == true )
         {
            Relay_In_5();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_FinishedSpawning_42()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ab877325-874e-4be3-a741-ca868c6f336f", "Spawn Prefab At Location", Relay_FinishedSpawning_42)) return; 
         Relay_In_52();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Spawn Prefab At Location.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_42()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ab877325-874e-4be3-a741-ca868c6f336f", "Spawn Prefab At Location", Relay_In_42)) return; 
         {
            {
               logic_uScriptAct_SpawnPrefabAtLocation_PrefabName_42 = local_0_System_String;
               
            }
            {
            }
            {
               logic_uScriptAct_SpawnPrefabAtLocation_SpawnPosition_42 = local_20_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_SpawnPrefabAtLocation_SpawnRotation_42 = local_8_UnityEngine_Quaternion;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_42.In(logic_uScriptAct_SpawnPrefabAtLocation_PrefabName_42, logic_uScriptAct_SpawnPrefabAtLocation_ResourcePath_42, logic_uScriptAct_SpawnPrefabAtLocation_SpawnPosition_42, logic_uScriptAct_SpawnPrefabAtLocation_SpawnRotation_42, logic_uScriptAct_SpawnPrefabAtLocation_SpawnedName_42, out logic_uScriptAct_SpawnPrefabAtLocation_SpawnedGameObject_42, out logic_uScriptAct_SpawnPrefabAtLocation_SpawnedInstancedID_42);
         local_50_UnityEngine_GameObject = logic_uScriptAct_SpawnPrefabAtLocation_SpawnedGameObject_42;
         {
            //if our game object reference was changed then we need to reset event listeners
            if ( local_50_UnityEngine_GameObject_previous != local_50_UnityEngine_GameObject || false == m_RegisteredForEvents )
            {
               //tear down old listeners
               
               local_50_UnityEngine_GameObject_previous = local_50_UnityEngine_GameObject;
               
               //setup new listeners
            }
         }
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Spawn Prefab At Location.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_43()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1c266721-6382-4f8a-9b1e-70e9538b8fbb", "Print Text", Relay_ShowLabel_43)) return; 
         {
            {
               logic_uScriptAct_PrintText_Text_43 = local_35_System_String;
               
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
            {
            }
         }
         logic_uScriptAct_PrintText_uScriptAct_PrintText_43.ShowLabel(logic_uScriptAct_PrintText_Text_43, logic_uScriptAct_PrintText_FontSize_43, logic_uScriptAct_PrintText_FontStyle_43, logic_uScriptAct_PrintText_FontColor_43, logic_uScriptAct_PrintText_textAnchor_43, logic_uScriptAct_PrintText_EdgePadding_43, logic_uScriptAct_PrintText_time_43);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_43()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1c266721-6382-4f8a-9b1e-70e9538b8fbb", "Print Text", Relay_HideLabel_43)) return; 
         {
            {
               logic_uScriptAct_PrintText_Text_43 = local_35_System_String;
               
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
            {
            }
         }
         logic_uScriptAct_PrintText_uScriptAct_PrintText_43.HideLabel(logic_uScriptAct_PrintText_Text_43, logic_uScriptAct_PrintText_FontSize_43, logic_uScriptAct_PrintText_FontStyle_43, logic_uScriptAct_PrintText_FontColor_43, logic_uScriptAct_PrintText_textAnchor_43, logic_uScriptAct_PrintText_EdgePadding_43, logic_uScriptAct_PrintText_time_43);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_uScriptStart_44()
   {
      if (true == CheckDebugBreak("3de06897-62ee-4ce8-bde1-30f3ae0b181d", "uScript Events", Relay_uScriptStart_44)) return; 
      Relay_SendCustomEvent_38();
      Relay_In_17();
   }
   
   void Relay_uScriptLateStart_44()
   {
      if (true == CheckDebugBreak("3de06897-62ee-4ce8-bde1-30f3ae0b181d", "uScript Events", Relay_uScriptLateStart_44)) return; 
   }
   
   void Relay_True_47()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("20aeb726-7583-4a30-87b1-91dce75a38c7", "Set Bool", Relay_True_47)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_47.True(out logic_uScriptAct_SetBool_Target_47);
         local_Enable_Crosshair__System_Boolean = logic_uScriptAct_SetBool_Target_47;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_47()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("20aeb726-7583-4a30-87b1-91dce75a38c7", "Set Bool", Relay_False_47)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_47.False(out logic_uScriptAct_SetBool_Target_47);
         local_Enable_Crosshair__System_Boolean = logic_uScriptAct_SetBool_Target_47;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_49()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5f9190b5-3f68-4567-a9aa-e9bb234d3adc", "Add Force", Relay_In_49)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_50_UnityEngine_GameObject_previous != local_50_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_50_UnityEngine_GameObject_previous = local_50_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_AddForce_Target_49 = local_50_UnityEngine_GameObject;
               
            }
            {
               logic_uScriptAct_AddForce_Force_49 = local_4_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_AddForce_Scale_49 = local_22_System_Single;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddForce_uScriptAct_AddForce_49.In(logic_uScriptAct_AddForce_Target_49, logic_uScriptAct_AddForce_Force_49, logic_uScriptAct_AddForce_Scale_49, logic_uScriptAct_AddForce_UseForceMode_49, logic_uScriptAct_AddForce_ForceModeType_49);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddForce_uScriptAct_AddForce_49.Out;
         
         if ( test_0 == true )
         {
            Relay_SendCustomEvent_31();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Add Force.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_51()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5086132d-71ea-4a5b-9769-17262be471d9", "Subtract Int", Relay_In_51)) return; 
         {
            {
               logic_uScriptAct_SubtractInt_A_51 = local_Grenades_On_Hand_System_Int32;
               
            }
            {
               logic_uScriptAct_SubtractInt_B_51 = local_41_System_Int32;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SubtractInt_uScriptAct_SubtractInt_51.In(logic_uScriptAct_SubtractInt_A_51, logic_uScriptAct_SubtractInt_B_51, out logic_uScriptAct_SubtractInt_IntResult_51, out logic_uScriptAct_SubtractInt_FloatResult_51);
         local_Grenades_On_Hand_System_Int32 = logic_uScriptAct_SubtractInt_IntResult_51;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SubtractInt_uScriptAct_SubtractInt_51.Out;
         
         if ( test_0 == true )
         {
            Relay_In_56();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Subtract Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_52()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ed65820e-a1ce-4078-af56-2d6a5a3c7c03", "Vectors From Quaternion", Relay_In_52)) return; 
         {
            {
               logic_uScriptAct_VectorsFromQuaternion_quaternion_52 = local_8_UnityEngine_Quaternion;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_VectorsFromQuaternion_uScriptAct_VectorsFromQuaternion_52.In(logic_uScriptAct_VectorsFromQuaternion_quaternion_52, out logic_uScriptAct_VectorsFromQuaternion_forward_52, out logic_uScriptAct_VectorsFromQuaternion_up_52);
         local_4_UnityEngine_Vector3 = logic_uScriptAct_VectorsFromQuaternion_forward_52;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_VectorsFromQuaternion_uScriptAct_VectorsFromQuaternion_52.Out;
         
         if ( test_0 == true )
         {
            Relay_In_49();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Vectors From Quaternion.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnCustomEventInt_54()
   {
      if (true == CheckDebugBreak("3192307f-d9f2-43ad-baa1-94c79931d838", "Custom Event (Int)", Relay_OnCustomEventInt_54)) return; 
      local_60_System_String = event_UnityEngine_GameObject_EventName_54;
      Relay_In_10();
   }
   
   void Relay_In_56()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4b355309-b859-4eef-921f-c453cfa07b38", "Get Position and Rotation", Relay_In_56)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_34_UnityEngine_GameObject_previous != local_34_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_34_UnityEngine_GameObject_previous = local_34_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_GetPositionAndRotation_Target_56 = local_34_UnityEngine_GameObject;
               
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
            {
            }
            {
            }
         }
         logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_56.In(logic_uScriptAct_GetPositionAndRotation_Target_56, logic_uScriptAct_GetPositionAndRotation_GetLocal_56, out logic_uScriptAct_GetPositionAndRotation_Position_56, out logic_uScriptAct_GetPositionAndRotation_Rotation_56, out logic_uScriptAct_GetPositionAndRotation_EulerAngles_56, out logic_uScriptAct_GetPositionAndRotation_Forward_56, out logic_uScriptAct_GetPositionAndRotation_Up_56, out logic_uScriptAct_GetPositionAndRotation_Right_56);
         local_2_UnityEngine_Vector3 = logic_uScriptAct_GetPositionAndRotation_Position_56;
         local_8_UnityEngine_Quaternion = logic_uScriptAct_GetPositionAndRotation_Rotation_56;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetPositionAndRotation_uScriptAct_GetPositionAndRotation_56.Out;
         
         if ( test_0 == true )
         {
            Relay_In_63();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Get Position and Rotation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_63()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d778b925-f5b1-4898-bd70-6d4178f8d456", "Add Vector3", Relay_In_63)) return; 
         {
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_2_UnityEngine_Vector3);
               logic_uScriptAct_AddVector3_A_63 = properties.ToArray();
            }
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_74_UnityEngine_Vector3);
               logic_uScriptAct_AddVector3_B_63 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_uScriptAct_AddVector3_63.In(logic_uScriptAct_AddVector3_A_63, logic_uScriptAct_AddVector3_B_63, out logic_uScriptAct_AddVector3_Result_63);
         local_20_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_Result_63;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_uScriptAct_AddVector3_63.Out;
         
         if ( test_0 == true )
         {
            Relay_In_42();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnGui_65()
   {
      if (true == CheckDebugBreak("b391115c-5f58-49d0-895e-5195e1a0f9ab", "GUI Events", Relay_OnGui_65)) return; 
      Relay_In_75();
   }
   
   void Relay_In_68()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f51e7402-d63e-490b-b146-2c054d8356ed", "Destroy", Relay_In_68)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_62_UnityEngine_GameObject_previous != local_62_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_62_UnityEngine_GameObject_previous = local_62_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_62_UnityEngine_GameObject);
               logic_uScriptAct_Destroy_Target_68 = properties.ToArray();
            }
            {
               logic_uScriptAct_Destroy_DelayTime_68 = local_13_System_Single;
               
            }
         }
         logic_uScriptAct_Destroy_uScriptAct_Destroy_68.In(logic_uScriptAct_Destroy_Target_68, logic_uScriptAct_Destroy_DelayTime_68);
         logic_uScriptAct_Destroy_WaitOneTick_68 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Destroy.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_WaitOneTick_68( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_62_UnityEngine_GameObject_previous != local_62_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_62_UnityEngine_GameObject_previous = local_62_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_62_UnityEngine_GameObject);
               logic_uScriptAct_Destroy_Target_68 = properties.ToArray();
            }
            {
               logic_uScriptAct_Destroy_DelayTime_68 = local_13_System_Single;
               
            }
         }
         logic_uScriptAct_Destroy_WaitOneTick_68 = logic_uScriptAct_Destroy_uScriptAct_Destroy_68.WaitOneTick();
         if ( true == logic_uScriptAct_Destroy_WaitOneTick_68 )
         {
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Destroy.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_In_69()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c08443ea-180b-44c8-b1d7-209ca5c5046f", "Compare Int", Relay_In_69)) return; 
         {
            {
               logic_uScriptCon_CompareInt_A_69 = local_Grenades_On_Hand_System_Int32;
               
            }
            {
               logic_uScriptCon_CompareInt_B_69 = local_18_System_Int32;
               
            }
         }
         logic_uScriptCon_CompareInt_uScriptCon_CompareInt_69.In(logic_uScriptCon_CompareInt_A_69, logic_uScriptCon_CompareInt_B_69);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareInt_uScriptCon_CompareInt_69.GreaterThan;
         
         if ( test_0 == true )
         {
            Relay_In_37();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Compare Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_70()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d2843711-bd8a-403e-b86c-dbad2dbee12b", "Input Events Filter", Relay_In_70)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_70.In(logic_uScriptAct_OnInputEventFilter_KeyCode_70);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_70.KeyDown;
         
         if ( test_0 == true )
         {
            Relay_In_69();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_75()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("254b3a9c-cd60-4c95-b51b-cb71376ceb35", "Compare Bool", Relay_In_75)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_75 = local_Enable_Crosshair__System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_75.In(logic_uScriptCon_CompareBool_Bool_75);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_75.True;
         
         if ( test_0 == true )
         {
            Relay_In_23();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_78()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("81fea639-74c6-4b5f-95aa-0fc72d467a99", "Quaternion From Vectors", Relay_In_78)) return; 
         {
            {
            }
            {
               logic_uScriptAct_QuaternionFromVectors_up_78 = local_RayHitNormal_UnityEngine_Vector3;
               
            }
            {
            }
         }
         logic_uScriptAct_QuaternionFromVectors_uScriptAct_QuaternionFromVectors_78.In(logic_uScriptAct_QuaternionFromVectors_forward_78, logic_uScriptAct_QuaternionFromVectors_up_78, out logic_uScriptAct_QuaternionFromVectors_result_78);
         local_PrefabRotation_UnityEngine_Quaternion = logic_uScriptAct_QuaternionFromVectors_result_78;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_QuaternionFromVectors_uScriptAct_QuaternionFromVectors_78.Out;
         
         if ( test_0 == true )
         {
            Relay_In_92();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Quaternion From Vectors.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_FinishedSpawning_82()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d9b09e47-af14-45c1-a3ee-ecf64d927270", "Spawn Prefab At Location", Relay_FinishedSpawning_82)) return; 
         Relay_In_84();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Spawn Prefab At Location.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_82()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d9b09e47-af14-45c1-a3ee-ecf64d927270", "Spawn Prefab At Location", Relay_In_82)) return; 
         {
            {
               logic_uScriptAct_SpawnPrefabAtLocation_PrefabName_82 = local_83_System_String;
               
            }
            {
            }
            {
               logic_uScriptAct_SpawnPrefabAtLocation_SpawnPosition_82 = local_PrefabLocation_UnityEngine_Vector3;
               
            }
            {
               logic_uScriptAct_SpawnPrefabAtLocation_SpawnRotation_82 = local_PrefabRotation_UnityEngine_Quaternion;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SpawnPrefabAtLocation_uScriptAct_SpawnPrefabAtLocation_82.In(logic_uScriptAct_SpawnPrefabAtLocation_PrefabName_82, logic_uScriptAct_SpawnPrefabAtLocation_ResourcePath_82, logic_uScriptAct_SpawnPrefabAtLocation_SpawnPosition_82, logic_uScriptAct_SpawnPrefabAtLocation_SpawnRotation_82, logic_uScriptAct_SpawnPrefabAtLocation_SpawnedName_82, out logic_uScriptAct_SpawnPrefabAtLocation_SpawnedGameObject_82, out logic_uScriptAct_SpawnPrefabAtLocation_SpawnedInstancedID_82);
         local_85_UnityEngine_GameObject = logic_uScriptAct_SpawnPrefabAtLocation_SpawnedGameObject_82;
         {
            //if our game object reference was changed then we need to reset event listeners
            if ( local_85_UnityEngine_GameObject_previous != local_85_UnityEngine_GameObject || false == m_RegisteredForEvents )
            {
               //tear down old listeners
               
               local_85_UnityEngine_GameObject_previous = local_85_UnityEngine_GameObject;
               
               //setup new listeners
            }
         }
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Spawn Prefab At Location.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_84()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("26f65288-e764-454f-b351-2f357bffed91", "Destroy", Relay_In_84)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_85_UnityEngine_GameObject_previous != local_85_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_85_UnityEngine_GameObject_previous = local_85_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_85_UnityEngine_GameObject);
               logic_uScriptAct_Destroy_Target_84 = properties.ToArray();
            }
            {
               logic_uScriptAct_Destroy_DelayTime_84 = local_80_System_Single;
               
            }
         }
         logic_uScriptAct_Destroy_uScriptAct_Destroy_84.In(logic_uScriptAct_Destroy_Target_84, logic_uScriptAct_Destroy_DelayTime_84);
         logic_uScriptAct_Destroy_WaitOneTick_84 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Destroy_uScriptAct_Destroy_84.Out;
         
         if ( test_0 == true )
         {
            Relay_In_19();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Destroy.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_WaitOneTick_84( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_85_UnityEngine_GameObject_previous != local_85_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_85_UnityEngine_GameObject_previous = local_85_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_85_UnityEngine_GameObject);
               logic_uScriptAct_Destroy_Target_84 = properties.ToArray();
            }
            {
               logic_uScriptAct_Destroy_DelayTime_84 = local_80_System_Single;
               
            }
         }
         logic_uScriptAct_Destroy_WaitOneTick_84 = logic_uScriptAct_Destroy_uScriptAct_Destroy_84.WaitOneTick();
         if ( true == logic_uScriptAct_Destroy_WaitOneTick_84 )
         {
            if ( logic_uScriptAct_Destroy_uScriptAct_Destroy_84.Out == true )
            {
               Relay_In_19();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Destroy.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_In_88()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("237639bd-a378-4c40-8f07-db9dce0403ca", "Add Vector3", Relay_In_88)) return; 
         {
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_93_UnityEngine_Vector3);
               logic_uScriptAct_AddVector3_A_88 = properties.ToArray();
            }
            {
               List<UnityEngine.Vector3> properties = new List<UnityEngine.Vector3>();
               properties.Add((UnityEngine.Vector3)local_RayHitLocation_UnityEngine_Vector3);
               logic_uScriptAct_AddVector3_B_88 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_AddVector3_uScriptAct_AddVector3_88.In(logic_uScriptAct_AddVector3_A_88, logic_uScriptAct_AddVector3_B_88, out logic_uScriptAct_AddVector3_Result_88);
         local_PrefabLocation_UnityEngine_Vector3 = logic_uScriptAct_AddVector3_Result_88;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector3_uScriptAct_AddVector3_88.Out;
         
         if ( test_0 == true )
         {
            Relay_In_82();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Add Vector3.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_92()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3a360303-0b0d-43dd-9744-65d282978faf", "Divide Vector3 With Float", Relay_In_92)) return; 
         {
            {
               logic_uScriptAct_DivideVector3WithFloat_targetVector3_92 = local_RayHitNormal_UnityEngine_Vector3;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_DivideVector3WithFloat_uScriptAct_DivideVector3WithFloat_92.In(logic_uScriptAct_DivideVector3WithFloat_targetVector3_92, logic_uScriptAct_DivideVector3WithFloat_targetFloat_92, out logic_uScriptAct_DivideVector3WithFloat_Result_92);
         local_93_UnityEngine_Vector3 = logic_uScriptAct_DivideVector3WithFloat_Result_92;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_DivideVector3WithFloat_uScriptAct_DivideVector3WithFloat_92.Out;
         
         if ( test_0 == true )
         {
            Relay_In_88();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SquibEffect_Gameplay.uscript at Divide Vector3 With Float.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:0", local_0_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "566e8562-930d-4fcf-a68d-63e5ec80fbb8", local_0_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:2", local_2_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "0367fb16-879d-45e9-a852-3d5ddc1cff79", local_2_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:3", local_3_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "678114a7-ecd6-4b59-9d04-f661dd256202", local_3_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:4", local_4_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "61f31a24-0543-45c0-aec7-24493235f252", local_4_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:8", local_8_UnityEngine_Quaternion);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c65906a7-4f31-4fd4-b3ae-e1923cd65a56", local_8_UnityEngine_Quaternion);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:13", local_13_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d88199c3-ca97-40bd-a429-52998a48f43a", local_13_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:18", local_18_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "52cc8695-e560-41f6-9992-2c0653553f45", local_18_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:20", local_20_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d64572ca-7849-4f4c-a3a8-1c29beb5544e", local_20_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:22", local_22_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7b2752b7-b34d-46a1-9133-bb47eb12dacf", local_22_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:Crosshair Texture2D", local_Crosshair_Texture2D_UnityEngine_Texture2D);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "80adb11b-e1bc-4286-bf39-633662f46c31", local_Crosshair_Texture2D_UnityEngine_Texture2D);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:32", local_32_UnityEngine_Camera);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f88b98bc-70e6-4c3b-be80-04362db50547", local_32_UnityEngine_Camera);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:33", local_33_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "46b5a651-deae-4395-a6ba-6475a80435c4", local_33_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:34", local_34_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "95060344-5088-44a4-8926-382d3bd72e24", local_34_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:35", local_35_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "faec1a4b-9297-4c2e-a5df-9172880dd3ce", local_35_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:40", local_40_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "beccee9a-9434-403f-84a9-3eb9f1130b94", local_40_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:41", local_41_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "88249c6e-10d7-4648-88c0-bddd27ef1857", local_41_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:50", local_50_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "fca913a2-1f26-4bcb-ad3a-dec5ebc7c0d9", local_50_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:EVENT Grenade_UI", local_EVENT_Grenade_UI_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "e1b299b8-ab23-436f-89db-02129f1118a0", local_EVENT_Grenade_UI_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:Crosshair Rect", local_Crosshair_Rect_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "92f52b1a-be01-4a90-89e4-b399cb26be78", local_Crosshair_Rect_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:60", local_60_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "2207b042-d4f1-4bba-aca4-654a44fbf638", local_60_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:62", local_62_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "449593ee-2142-40dd-9d01-829304df4a69", local_62_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:Grenades On Hand", local_Grenades_On_Hand_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "5a91d1d2-30c9-4ab6-8d43-6009a9b17727", local_Grenades_On_Hand_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:Enable Crosshair?", local_Enable_Crosshair__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "1e1fe5ad-b32d-4961-9d59-b2797bc0c00a", local_Enable_Crosshair__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:74", local_74_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a2fbdfc2-1431-48f4-a6d9-6e64e65375c6", local_74_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:76", local_76_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d0050cdb-9892-4d03-a847-5745b8356d08", local_76_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:79", local_79_UnityEngine_KeyCode);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "bdb2291e-f7d0-4ae6-b0fb-4fbc95b93ae2", local_79_UnityEngine_KeyCode);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:80", local_80_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ac14773e-d059-4610-b6c1-5e36fc3b7be7", local_80_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:83", local_83_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "0b161f4e-8446-45f3-b95c-2e2e44b94149", local_83_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:85", local_85_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ecf79bd6-7737-43ba-be19-3f540105f98e", local_85_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:PrefabRotation", local_PrefabRotation_UnityEngine_Quaternion);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "2609390d-cfa8-4b6b-9006-4dcea2f88881", local_PrefabRotation_UnityEngine_Quaternion);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:PrefabLocation", local_PrefabLocation_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "bb212312-0a46-4013-aafd-abeb8ed155d3", local_PrefabLocation_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:93", local_93_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "9f84e9ba-f3ad-45d4-b269-afee532014a4", local_93_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:RayHitLocation", local_RayHitLocation_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d2a2d9b4-6d49-4205-8166-e6ff784c553d", local_RayHitLocation_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SquibEffect_Gameplay.uscript:RayHitNormal", local_RayHitNormal_UnityEngine_Vector3);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "59cf007d-1757-40ed-9b3e-26b6c47c2d33", local_RayHitNormal_UnityEngine_Vector3);
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
