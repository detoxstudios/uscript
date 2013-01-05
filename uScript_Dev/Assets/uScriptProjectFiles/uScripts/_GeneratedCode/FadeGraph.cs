//uScript Generated Code - Build 0.9.2123
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("Untitled", "")]
public class FadeGraph : uScriptLogic
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
   public UnityEngine.Material FadeMaterial = null;
   System.Single local_11_System_Single = (float) 0;
   UnityEngine.Color local_12_UnityEngine_Color = new UnityEngine.Color( (float)0, (float)0, (float)0, (float)1 );
   System.String local_19_System_String = "Health:";
   System.String local_25_System_String = "";
   System.Single local_8_System_Single = (float) 0;
   UnityEngine.Color local_FadeColor_UnityEngine_Color = new UnityEngine.Color( (float)0, (float)0, (float)0, (float)1 );
   UnityEngine.GameObject local_FadeGO_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_FadeGO_UnityEngine_GameObject_previous = null;
   System.Single local_PlayerHealth_System_Single = (float) 100;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_1 = new uScriptAct_Delay( );
   System.Single logic_uScriptAct_Delay_Duration_1 = (float) 1;
   bool logic_uScriptAct_Delay_Immediate_1 = true;
   bool logic_uScriptAct_Delay_AfterDelay_1 = true;
   bool logic_uScriptAct_Delay_DrivenDelay_1 = false;
   //pointer to script instanced logic node
   uScriptAct_GetGameObjectMaterial logic_uScriptAct_GetGameObjectMaterial_uScriptAct_GetGameObjectMaterial_2 = new uScriptAct_GetGameObjectMaterial( );
   UnityEngine.GameObject logic_uScriptAct_GetGameObjectMaterial_Target_2 = null;
   System.Int32 logic_uScriptAct_GetGameObjectMaterial_MaterialIndex_2 = (int) 0;
   UnityEngine.Material logic_uScriptAct_GetGameObjectMaterial_targetMaterial_2;
   UnityEngine.Color logic_uScriptAct_GetGameObjectMaterial_materialColor_2;
   System.String logic_uScriptAct_GetGameObjectMaterial_materialName_2;
   bool logic_uScriptAct_GetGameObjectMaterial_Out_2 = true;
   //pointer to script instanced logic node
   uScriptAct_SetColorAlpha logic_uScriptAct_SetColorAlpha_uScriptAct_SetColorAlpha_4 = new uScriptAct_SetColorAlpha( );
   UnityEngine.Color logic_uScriptAct_SetColorAlpha_Value_4 = UnityEngine.Color.black;
   System.Single logic_uScriptAct_SetColorAlpha_Alpha_4 = (float) 0;
   System.Boolean logic_uScriptAct_SetColorAlpha_Use8bitRange_4 = (bool) false;
   UnityEngine.Color logic_uScriptAct_SetColorAlpha_TargetColor_4;
   bool logic_uScriptAct_SetColorAlpha_Out_4 = true;
   //pointer to script instanced logic node
   uScriptAct_AssignMaterialColor logic_uScriptAct_AssignMaterialColor_uScriptAct_AssignMaterialColor_5 = new uScriptAct_AssignMaterialColor( );
   UnityEngine.GameObject[] logic_uScriptAct_AssignMaterialColor_Target_5 = new UnityEngine.GameObject[] {};
   UnityEngine.Color logic_uScriptAct_AssignMaterialColor_MatColor_5 = UnityEngine.Color.black;
   System.Int32 logic_uScriptAct_AssignMaterialColor_MatChannel_5 = (int) 0;
   bool logic_uScriptAct_AssignMaterialColor_Out_5 = true;
   //pointer to script instanced logic node
   uScriptAct_GetComponentsColor logic_uScriptAct_GetComponentsColor_uScriptAct_GetComponentsColor_7 = new uScriptAct_GetComponentsColor( );
   UnityEngine.Color logic_uScriptAct_GetComponentsColor_InputColor_7 = UnityEngine.Color.black;
   System.Single logic_uScriptAct_GetComponentsColor_Red_7;
   System.Single logic_uScriptAct_GetComponentsColor_Green_7;
   System.Single logic_uScriptAct_GetComponentsColor_Blue_7;
   System.Single logic_uScriptAct_GetComponentsColor_Alpha_7;
   bool logic_uScriptAct_GetComponentsColor_Out_7 = true;
   //pointer to script instanced logic node
   uScriptAct_InterpolateFloatLinear logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_9 = new uScriptAct_InterpolateFloatLinear( );
   System.Single logic_uScriptAct_InterpolateFloatLinear_startValue_9 = (float) 0;
   System.Single logic_uScriptAct_InterpolateFloatLinear_endValue_9 = (float) 0;
   System.Single logic_uScriptAct_InterpolateFloatLinear_time_9 = (float) 2;
   uScript_Lerper.LoopType logic_uScriptAct_InterpolateFloatLinear_loopType_9 = uScript_Lerper.LoopType.None;
   System.Single logic_uScriptAct_InterpolateFloatLinear_loopDelay_9 = (float) 0;
   System.Int32 logic_uScriptAct_InterpolateFloatLinear_loopCount_9 = (int) -1;
   System.Single logic_uScriptAct_InterpolateFloatLinear_currentValue_9;
   bool logic_uScriptAct_InterpolateFloatLinear_Started_9 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Stopped_9 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Interpolating_9 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Finished_9 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Driven_9 = false;
   //pointer to script instanced logic node
   uScriptAct_CameraFade logic_uScriptAct_CameraFade_uScriptAct_CameraFade_14 = new uScriptAct_CameraFade( );
   UnityEngine.Camera logic_uScriptAct_CameraFade_TargetCamera_14 = null;
   uScriptAct_CameraFade.FadeDirection logic_uScriptAct_CameraFade_Direction_14 = uScriptAct_CameraFade.FadeDirection.To;
   UnityEngine.Material logic_uScriptAct_CameraFade_FadeMaterial_14 = null;
   System.Single logic_uScriptAct_CameraFade_FadeTime_14 = (float) 2;
   System.Single logic_uScriptAct_CameraFade_HoldTime_14 = (float) 0;
   System.Boolean logic_uScriptAct_CameraFade_ColorOverride_14 = (bool) true;
   UnityEngine.Color logic_uScriptAct_CameraFade_FadeColor_14 = new UnityEngine.Color( (float)1, (float)0, (float)0, (float)1 );
   bool logic_uScriptAct_CameraFade_Immediate_14 = true;
   bool logic_uScriptAct_CameraFade_FadeFinished_14 = true;
   bool logic_uScriptAct_CameraFade_DrivenFade_14 = false;
   //pointer to script instanced logic node
   uScriptAct_Concatenate logic_uScriptAct_Concatenate_uScriptAct_Concatenate_17 = new uScriptAct_Concatenate( );
   System.Object[] logic_uScriptAct_Concatenate_A_17 = new System.Object[] {};
   System.Object[] logic_uScriptAct_Concatenate_B_17 = new System.Object[] {};
   System.String logic_uScriptAct_Concatenate_Separator_17 = "";
   System.String logic_uScriptAct_Concatenate_Result_17;
   bool logic_uScriptAct_Concatenate_Out_17 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_18 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_18 = "";
   System.Int32 logic_uScriptAct_PrintText_FontSize_18 = (int) 16;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_18 = UnityEngine.FontStyle.Normal;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_18 = new UnityEngine.Color( (float)0, (float)0, (float)0, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_18 = UnityEngine.TextAnchor.UpperLeft;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_18 = (int) 8;
   System.Single logic_uScriptAct_PrintText_time_18 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_18 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareFloat logic_uScriptCon_CompareFloat_uScriptCon_CompareFloat_21 = new uScriptCon_CompareFloat( );
   System.Single logic_uScriptCon_CompareFloat_A_21 = (float) 0;
   System.Single logic_uScriptCon_CompareFloat_B_21 = (float) 0;
   bool logic_uScriptCon_CompareFloat_GreaterThan_21 = true;
   bool logic_uScriptCon_CompareFloat_GreaterThanOrEqualTo_21 = true;
   bool logic_uScriptCon_CompareFloat_EqualTo_21 = true;
   bool logic_uScriptCon_CompareFloat_NotEqualTo_21 = true;
   bool logic_uScriptCon_CompareFloat_LessThanOrEqualTo_21 = true;
   bool logic_uScriptCon_CompareFloat_LessThan_21 = true;
   //pointer to script instanced logic node
   uScriptAct_SetFloat logic_uScriptAct_SetFloat_uScriptAct_SetFloat_23 = new uScriptAct_SetFloat( );
   System.Single logic_uScriptAct_SetFloat_Value_23 = (float) 0;
   System.Single logic_uScriptAct_SetFloat_Target_23;
   bool logic_uScriptAct_SetFloat_Out_23 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_26 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_26 = "Camera Fade - Immediate Out";
   System.Object[] logic_uScriptAct_Log_Target_26 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_26 = "";
   bool logic_uScriptAct_Log_Out_26 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_27 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_27 = "Camera Fade - Finished Out";
   System.Object[] logic_uScriptAct_Log_Target_27 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_27 = "";
   bool logic_uScriptAct_Log_Out_27 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_28 = new uScriptAct_Delay( );
   System.Single logic_uScriptAct_Delay_Duration_28 = (float) 2;
   bool logic_uScriptAct_Delay_Immediate_28 = true;
   bool logic_uScriptAct_Delay_AfterDelay_28 = true;
   bool logic_uScriptAct_Delay_DrivenDelay_28 = false;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_29 = new uScriptAct_Delay( );
   System.Single logic_uScriptAct_Delay_Duration_29 = (float) 2;
   bool logic_uScriptAct_Delay_Immediate_29 = true;
   bool logic_uScriptAct_Delay_AfterDelay_29 = true;
   bool logic_uScriptAct_Delay_DrivenDelay_29 = false;
   //pointer to script instanced logic node
   uScriptAct_CameraFade logic_uScriptAct_CameraFade_uScriptAct_CameraFade_30 = new uScriptAct_CameraFade( );
   UnityEngine.Camera logic_uScriptAct_CameraFade_TargetCamera_30 = null;
   uScriptAct_CameraFade.FadeDirection logic_uScriptAct_CameraFade_Direction_30 = uScriptAct_CameraFade.FadeDirection.From;
   UnityEngine.Material logic_uScriptAct_CameraFade_FadeMaterial_30 = null;
   System.Single logic_uScriptAct_CameraFade_FadeTime_30 = (float) 2;
   System.Single logic_uScriptAct_CameraFade_HoldTime_30 = (float) 0;
   System.Boolean logic_uScriptAct_CameraFade_ColorOverride_30 = (bool) true;
   UnityEngine.Color logic_uScriptAct_CameraFade_FadeColor_30 = new UnityEngine.Color( (float)1, (float)0, (float)0, (float)1 );
   bool logic_uScriptAct_CameraFade_Immediate_30 = true;
   bool logic_uScriptAct_CameraFade_FadeFinished_30 = true;
   bool logic_uScriptAct_CameraFade_DrivenFade_30 = false;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_0 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_16 = null;
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      if ( null == logic_uScriptAct_CameraFade_TargetCamera_14 || false == m_RegisteredForEvents )
      {
         GameObject gameObject = GameObject.Find( "Main Camera" );
         if ( null != gameObject )
         {
            logic_uScriptAct_CameraFade_TargetCamera_14 = gameObject.GetComponent<UnityEngine.Camera>();
         }
      }
      if ( null == logic_uScriptAct_CameraFade_TargetCamera_30 || false == m_RegisteredForEvents )
      {
         GameObject gameObject = GameObject.Find( "Main Camera" );
         if ( null != gameObject )
         {
            logic_uScriptAct_CameraFade_TargetCamera_30 = gameObject.GetComponent<UnityEngine.Camera>();
         }
      }
      if ( null == local_FadeGO_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_FadeGO_UnityEngine_GameObject = GameObject.Find( "FadePlane" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_FadeGO_UnityEngine_GameObject_previous != local_FadeGO_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_FadeGO_UnityEngine_GameObject_previous = local_FadeGO_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_FadeGO_UnityEngine_GameObject_previous != local_FadeGO_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_FadeGO_UnityEngine_GameObject_previous = local_FadeGO_UnityEngine_GameObject;
         
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
               uScript_Global component = event_UnityEngine_GameObject_Instance_0.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_0.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_0;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_16 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_16 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_16 )
         {
            {
               uScript_Update component = event_UnityEngine_GameObject_Instance_16.GetComponent<uScript_Update>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_16.AddComponent<uScript_Update>();
               }
               if ( null != component )
               {
                  component.OnUpdate += Instance_OnUpdate_16;
                  component.OnLateUpdate += Instance_OnLateUpdate_16;
                  component.OnFixedUpdate += Instance_OnFixedUpdate_16;
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
            uScript_Global component = event_UnityEngine_GameObject_Instance_0.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_0;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_16 )
      {
         {
            uScript_Update component = event_UnityEngine_GameObject_Instance_16.GetComponent<uScript_Update>();
            if ( null != component )
            {
               component.OnUpdate -= Instance_OnUpdate_16;
               component.OnLateUpdate -= Instance_OnLateUpdate_16;
               component.OnFixedUpdate -= Instance_OnFixedUpdate_16;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_Delay_uScriptAct_Delay_1.SetParent(g);
      logic_uScriptAct_GetGameObjectMaterial_uScriptAct_GetGameObjectMaterial_2.SetParent(g);
      logic_uScriptAct_SetColorAlpha_uScriptAct_SetColorAlpha_4.SetParent(g);
      logic_uScriptAct_AssignMaterialColor_uScriptAct_AssignMaterialColor_5.SetParent(g);
      logic_uScriptAct_GetComponentsColor_uScriptAct_GetComponentsColor_7.SetParent(g);
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_9.SetParent(g);
      logic_uScriptAct_CameraFade_uScriptAct_CameraFade_14.SetParent(g);
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_17.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_18.SetParent(g);
      logic_uScriptCon_CompareFloat_uScriptCon_CompareFloat_21.SetParent(g);
      logic_uScriptAct_SetFloat_uScriptAct_SetFloat_23.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_26.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_27.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_28.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_29.SetParent(g);
      logic_uScriptAct_CameraFade_uScriptAct_CameraFade_30.SetParent(g);
   }
   public void Awake()
   {
      
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
      
      if (true == logic_uScriptAct_Delay_DrivenDelay_1)
      {
         Relay_DrivenDelay_1();
      }
      if (true == logic_uScriptAct_InterpolateFloatLinear_Driven_9)
      {
         Relay_Driven_9();
      }
      if (true == logic_uScriptAct_CameraFade_DrivenFade_14)
      {
         Relay_DrivenFade_14();
      }
      if (true == logic_uScriptAct_Delay_DrivenDelay_28)
      {
         Relay_DrivenDelay_28();
      }
      if (true == logic_uScriptAct_Delay_DrivenDelay_29)
      {
         Relay_DrivenDelay_29();
      }
      if (true == logic_uScriptAct_CameraFade_DrivenFade_30)
      {
         Relay_DrivenFade_30();
      }
   }
   
   public void OnDestroy()
   {
   }
   
   public void OnGUI()
   {
      logic_uScriptAct_PrintText_uScriptAct_PrintText_18.OnGUI( );
   }
   
   void Instance_uScriptStart_0(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_0( );
   }
   
   void Instance_OnUpdate_16(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUpdate_16( );
   }
   
   void Instance_OnLateUpdate_16(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnLateUpdate_16( );
   }
   
   void Instance_OnFixedUpdate_16(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnFixedUpdate_16( );
   }
   
   void Relay_uScriptStart_0()
   {
      if (true == CheckDebugBreak("40e7cd52-7626-48cc-baa0-1971dd6eb861", "uScript Events", Relay_uScriptStart_0)) return; 
      Relay_In_14();
   }
   
   void Relay_In_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("eb7ef601-e1b7-40d7-a4d0-ae30ced8afde", "Delay", Relay_In_1)) return; 
         {
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_1.In(logic_uScriptAct_Delay_Duration_1);
         logic_uScriptAct_Delay_DrivenDelay_1 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_1.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_In_2();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_DrivenDelay_1( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
         }
         logic_uScriptAct_Delay_DrivenDelay_1 = logic_uScriptAct_Delay_uScriptAct_Delay_1.DrivenDelay();
         if ( true == logic_uScriptAct_Delay_DrivenDelay_1 )
         {
            if ( logic_uScriptAct_Delay_uScriptAct_Delay_1.AfterDelay == true )
            {
               Relay_In_2();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_In_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6f2fb82a-2c88-420a-a5b2-8f3688ee83b2", "Get Material", Relay_In_2)) return; 
         {
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_FadeGO_UnityEngine_GameObject_previous != local_FadeGO_UnityEngine_GameObject || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  local_FadeGO_UnityEngine_GameObject_previous = local_FadeGO_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            logic_uScriptAct_GetGameObjectMaterial_Target_2 = local_FadeGO_UnityEngine_GameObject;
            
         }
         logic_uScriptAct_GetGameObjectMaterial_uScriptAct_GetGameObjectMaterial_2.In(logic_uScriptAct_GetGameObjectMaterial_Target_2, logic_uScriptAct_GetGameObjectMaterial_MaterialIndex_2, out logic_uScriptAct_GetGameObjectMaterial_targetMaterial_2, out logic_uScriptAct_GetGameObjectMaterial_materialColor_2, out logic_uScriptAct_GetGameObjectMaterial_materialName_2);
         local_FadeColor_UnityEngine_Color = logic_uScriptAct_GetGameObjectMaterial_materialColor_2;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetGameObjectMaterial_uScriptAct_GetGameObjectMaterial_2.Out;
         
         if ( test_0 == true )
         {
            Relay_In_7();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Get Material.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_4()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("86e8c8f8-f78e-4f22-8a0f-30b7c4bb6fb8", "Set Color Alpha", Relay_In_4)) return; 
         {
            logic_uScriptAct_SetColorAlpha_Value_4 = local_FadeColor_UnityEngine_Color;
            
            logic_uScriptAct_SetColorAlpha_Alpha_4 = local_11_System_Single;
            
         }
         logic_uScriptAct_SetColorAlpha_uScriptAct_SetColorAlpha_4.In(logic_uScriptAct_SetColorAlpha_Value_4, logic_uScriptAct_SetColorAlpha_Alpha_4, logic_uScriptAct_SetColorAlpha_Use8bitRange_4, out logic_uScriptAct_SetColorAlpha_TargetColor_4);
         local_12_UnityEngine_Color = logic_uScriptAct_SetColorAlpha_TargetColor_4;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetColorAlpha_uScriptAct_SetColorAlpha_4.Out;
         
         if ( test_0 == true )
         {
            Relay_In_5();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Set Color Alpha.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f9e8a542-8cb9-49c0-af02-6fedaa3a6ec8", "Assign Material Color", Relay_In_5)) return; 
         {
            int index;
            index = 0;
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( local_FadeGO_UnityEngine_GameObject_previous != local_FadeGO_UnityEngine_GameObject || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  local_FadeGO_UnityEngine_GameObject_previous = local_FadeGO_UnityEngine_GameObject;
                  
                  //setup new listeners
               }
            }
            if ( logic_uScriptAct_AssignMaterialColor_Target_5.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_AssignMaterialColor_Target_5, index + 1);
            }
            logic_uScriptAct_AssignMaterialColor_Target_5[ index++ ] = local_FadeGO_UnityEngine_GameObject;
            
            logic_uScriptAct_AssignMaterialColor_MatColor_5 = local_12_UnityEngine_Color;
            
         }
         logic_uScriptAct_AssignMaterialColor_uScriptAct_AssignMaterialColor_5.In(logic_uScriptAct_AssignMaterialColor_Target_5, logic_uScriptAct_AssignMaterialColor_MatColor_5, logic_uScriptAct_AssignMaterialColor_MatChannel_5);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Assign Material Color.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("144af89c-f91c-4294-a390-686c53872f60", "Get Components (Color)", Relay_In_7)) return; 
         {
            logic_uScriptAct_GetComponentsColor_InputColor_7 = local_FadeColor_UnityEngine_Color;
            
         }
         logic_uScriptAct_GetComponentsColor_uScriptAct_GetComponentsColor_7.In(logic_uScriptAct_GetComponentsColor_InputColor_7, out logic_uScriptAct_GetComponentsColor_Red_7, out logic_uScriptAct_GetComponentsColor_Green_7, out logic_uScriptAct_GetComponentsColor_Blue_7, out logic_uScriptAct_GetComponentsColor_Alpha_7);
         local_8_System_Single = logic_uScriptAct_GetComponentsColor_Alpha_7;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetComponentsColor_uScriptAct_GetComponentsColor_7.Out;
         
         if ( test_0 == true )
         {
            Relay_Begin_9();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Get Components (Color).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Begin_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5021645e-5e4d-45e0-9b94-ee091b4abaee", "Interpolate Float Linear", Relay_Begin_9)) return; 
         {
            logic_uScriptAct_InterpolateFloatLinear_startValue_9 = local_8_System_Single;
            
         }
         logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_9.Begin(logic_uScriptAct_InterpolateFloatLinear_startValue_9, logic_uScriptAct_InterpolateFloatLinear_endValue_9, logic_uScriptAct_InterpolateFloatLinear_time_9, logic_uScriptAct_InterpolateFloatLinear_loopType_9, logic_uScriptAct_InterpolateFloatLinear_loopDelay_9, logic_uScriptAct_InterpolateFloatLinear_loopCount_9, out logic_uScriptAct_InterpolateFloatLinear_currentValue_9);
         logic_uScriptAct_InterpolateFloatLinear_Driven_9 = true;
         local_11_System_Single = logic_uScriptAct_InterpolateFloatLinear_currentValue_9;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_9.Interpolating;
         
         if ( test_0 == true )
         {
            Relay_In_4();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Interpolate Float Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5021645e-5e4d-45e0-9b94-ee091b4abaee", "Interpolate Float Linear", Relay_Stop_9)) return; 
         {
            logic_uScriptAct_InterpolateFloatLinear_startValue_9 = local_8_System_Single;
            
         }
         logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_9.Stop(logic_uScriptAct_InterpolateFloatLinear_startValue_9, logic_uScriptAct_InterpolateFloatLinear_endValue_9, logic_uScriptAct_InterpolateFloatLinear_time_9, logic_uScriptAct_InterpolateFloatLinear_loopType_9, logic_uScriptAct_InterpolateFloatLinear_loopDelay_9, logic_uScriptAct_InterpolateFloatLinear_loopCount_9, out logic_uScriptAct_InterpolateFloatLinear_currentValue_9);
         logic_uScriptAct_InterpolateFloatLinear_Driven_9 = true;
         local_11_System_Single = logic_uScriptAct_InterpolateFloatLinear_currentValue_9;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_9.Interpolating;
         
         if ( test_0 == true )
         {
            Relay_In_4();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Interpolate Float Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Resume_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5021645e-5e4d-45e0-9b94-ee091b4abaee", "Interpolate Float Linear", Relay_Resume_9)) return; 
         {
            logic_uScriptAct_InterpolateFloatLinear_startValue_9 = local_8_System_Single;
            
         }
         logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_9.Resume(logic_uScriptAct_InterpolateFloatLinear_startValue_9, logic_uScriptAct_InterpolateFloatLinear_endValue_9, logic_uScriptAct_InterpolateFloatLinear_time_9, logic_uScriptAct_InterpolateFloatLinear_loopType_9, logic_uScriptAct_InterpolateFloatLinear_loopDelay_9, logic_uScriptAct_InterpolateFloatLinear_loopCount_9, out logic_uScriptAct_InterpolateFloatLinear_currentValue_9);
         logic_uScriptAct_InterpolateFloatLinear_Driven_9 = true;
         local_11_System_Single = logic_uScriptAct_InterpolateFloatLinear_currentValue_9;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_9.Interpolating;
         
         if ( test_0 == true )
         {
            Relay_In_4();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Interpolate Float Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Driven_9( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            logic_uScriptAct_InterpolateFloatLinear_startValue_9 = local_8_System_Single;
            
         }
         logic_uScriptAct_InterpolateFloatLinear_Driven_9 = logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_9.Driven(out logic_uScriptAct_InterpolateFloatLinear_currentValue_9);
         if ( true == logic_uScriptAct_InterpolateFloatLinear_Driven_9 )
         {
            local_11_System_Single = logic_uScriptAct_InterpolateFloatLinear_currentValue_9;
            if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_9.Interpolating == true )
            {
               Relay_In_4();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Interpolate Float Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_In_14()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d29ba26d-00a2-4feb-8344-4705b1fdef21", "Camera Fade", Relay_In_14)) return; 
         {
            logic_uScriptAct_CameraFade_FadeMaterial_14 = FadeMaterial;
            
         }
         logic_uScriptAct_CameraFade_uScriptAct_CameraFade_14.In(logic_uScriptAct_CameraFade_TargetCamera_14, logic_uScriptAct_CameraFade_Direction_14, logic_uScriptAct_CameraFade_FadeMaterial_14, logic_uScriptAct_CameraFade_FadeTime_14, logic_uScriptAct_CameraFade_HoldTime_14, logic_uScriptAct_CameraFade_ColorOverride_14, logic_uScriptAct_CameraFade_FadeColor_14);
         logic_uScriptAct_CameraFade_DrivenFade_14 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_CameraFade_uScriptAct_CameraFade_14.Immediate;
         bool test_1 = logic_uScriptAct_CameraFade_uScriptAct_CameraFade_14.FadeFinished;
         
         if ( test_0 == true )
         {
            Relay_In_26();
         }
         if ( test_1 == true )
         {
            Relay_In_27();
            Relay_In_29();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Camera Fade.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_DrivenFade_14( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            logic_uScriptAct_CameraFade_FadeMaterial_14 = FadeMaterial;
            
         }
         logic_uScriptAct_CameraFade_DrivenFade_14 = logic_uScriptAct_CameraFade_uScriptAct_CameraFade_14.DrivenFade();
         if ( true == logic_uScriptAct_CameraFade_DrivenFade_14 )
         {
            if ( logic_uScriptAct_CameraFade_uScriptAct_CameraFade_14.Immediate == true )
            {
               Relay_In_26();
            }
            if ( logic_uScriptAct_CameraFade_uScriptAct_CameraFade_14.FadeFinished == true )
            {
               Relay_In_27();
               Relay_In_29();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Camera Fade.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_OnUpdate_16()
   {
      if (true == CheckDebugBreak("9d8b6c65-289e-46c9-9956-e89b54eef397", "Global Update", Relay_OnUpdate_16)) return; 
   }
   
   void Relay_OnLateUpdate_16()
   {
      if (true == CheckDebugBreak("9d8b6c65-289e-46c9-9956-e89b54eef397", "Global Update", Relay_OnLateUpdate_16)) return; 
      Relay_In_21();
   }
   
   void Relay_OnFixedUpdate_16()
   {
      if (true == CheckDebugBreak("9d8b6c65-289e-46c9-9956-e89b54eef397", "Global Update", Relay_OnFixedUpdate_16)) return; 
   }
   
   void Relay_In_17()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7aef1b47-5fd6-4317-9811-7d9756744c9f", "Concatenate", Relay_In_17)) return; 
         {
            int index;
            index = 0;
            if ( logic_uScriptAct_Concatenate_A_17.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Concatenate_A_17, index + 1);
            }
            logic_uScriptAct_Concatenate_A_17[ index++ ] = local_19_System_String;
            
            index = 0;
            if ( logic_uScriptAct_Concatenate_B_17.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Concatenate_B_17, index + 1);
            }
            logic_uScriptAct_Concatenate_B_17[ index++ ] = local_PlayerHealth_System_Single;
            
         }
         logic_uScriptAct_Concatenate_uScriptAct_Concatenate_17.In(logic_uScriptAct_Concatenate_A_17, logic_uScriptAct_Concatenate_B_17, logic_uScriptAct_Concatenate_Separator_17, out logic_uScriptAct_Concatenate_Result_17);
         local_25_System_String = logic_uScriptAct_Concatenate_Result_17;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Concatenate_uScriptAct_Concatenate_17.Out;
         
         if ( test_0 == true )
         {
            Relay_ShowLabel_18();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Concatenate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_18()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7ad5f849-e329-4618-a824-d6878000c3c8", "Print Text", Relay_ShowLabel_18)) return; 
         {
            logic_uScriptAct_PrintText_Text_18 = local_25_System_String;
            
         }
         logic_uScriptAct_PrintText_uScriptAct_PrintText_18.ShowLabel(logic_uScriptAct_PrintText_Text_18, logic_uScriptAct_PrintText_FontSize_18, logic_uScriptAct_PrintText_FontStyle_18, logic_uScriptAct_PrintText_FontColor_18, logic_uScriptAct_PrintText_textAnchor_18, logic_uScriptAct_PrintText_EdgePadding_18, logic_uScriptAct_PrintText_time_18);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_18()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7ad5f849-e329-4618-a824-d6878000c3c8", "Print Text", Relay_HideLabel_18)) return; 
         {
            logic_uScriptAct_PrintText_Text_18 = local_25_System_String;
            
         }
         logic_uScriptAct_PrintText_uScriptAct_PrintText_18.HideLabel(logic_uScriptAct_PrintText_Text_18, logic_uScriptAct_PrintText_FontSize_18, logic_uScriptAct_PrintText_FontStyle_18, logic_uScriptAct_PrintText_FontColor_18, logic_uScriptAct_PrintText_textAnchor_18, logic_uScriptAct_PrintText_EdgePadding_18, logic_uScriptAct_PrintText_time_18);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_21()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("893b97c0-8bb5-4289-a2e2-4ec5590b17da", "Compare Float", Relay_In_21)) return; 
         {
            logic_uScriptCon_CompareFloat_A_21 = local_PlayerHealth_System_Single;
            
         }
         logic_uScriptCon_CompareFloat_uScriptCon_CompareFloat_21.In(logic_uScriptCon_CompareFloat_A_21, logic_uScriptCon_CompareFloat_B_21);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareFloat_uScriptCon_CompareFloat_21.GreaterThanOrEqualTo;
         bool test_1 = logic_uScriptCon_CompareFloat_uScriptCon_CompareFloat_21.LessThan;
         
         if ( test_0 == true )
         {
            Relay_In_17();
         }
         if ( test_1 == true )
         {
            Relay_In_23();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Compare Float.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_23()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("62b02c6d-cf0e-48e4-bf82-380e15ee82f3", "Set Float", Relay_In_23)) return; 
         {
         }
         logic_uScriptAct_SetFloat_uScriptAct_SetFloat_23.In(logic_uScriptAct_SetFloat_Value_23, out logic_uScriptAct_SetFloat_Target_23);
         local_PlayerHealth_System_Single = logic_uScriptAct_SetFloat_Target_23;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetFloat_uScriptAct_SetFloat_23.Out;
         
         if ( test_0 == true )
         {
            Relay_In_17();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Set Float.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_26()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5e5ac3a4-d16e-47c6-b090-13906a1a3adf", "Log", Relay_In_26)) return; 
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_26.In(logic_uScriptAct_Log_Prefix_26, logic_uScriptAct_Log_Target_26, logic_uScriptAct_Log_Postfix_26);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_27()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2ce20e8e-8c2b-4af9-883e-fbf525f34490", "Log", Relay_In_27)) return; 
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_27.In(logic_uScriptAct_Log_Prefix_27, logic_uScriptAct_Log_Target_27, logic_uScriptAct_Log_Postfix_27);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_28()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d30eb30b-81a6-47ee-b3e0-5b7ab3e934b9", "Delay", Relay_In_28)) return; 
         {
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_28.In(logic_uScriptAct_Delay_Duration_28);
         logic_uScriptAct_Delay_DrivenDelay_28 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_28.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_In_14();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_DrivenDelay_28( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
         }
         logic_uScriptAct_Delay_DrivenDelay_28 = logic_uScriptAct_Delay_uScriptAct_Delay_28.DrivenDelay();
         if ( true == logic_uScriptAct_Delay_DrivenDelay_28 )
         {
            if ( logic_uScriptAct_Delay_uScriptAct_Delay_28.AfterDelay == true )
            {
               Relay_In_14();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_In_29()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("bcae7323-6b05-489a-8718-7f77c9147ff2", "Delay", Relay_In_29)) return; 
         {
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_29.In(logic_uScriptAct_Delay_Duration_29);
         logic_uScriptAct_Delay_DrivenDelay_29 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_29.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_In_30();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_DrivenDelay_29( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
         }
         logic_uScriptAct_Delay_DrivenDelay_29 = logic_uScriptAct_Delay_uScriptAct_Delay_29.DrivenDelay();
         if ( true == logic_uScriptAct_Delay_DrivenDelay_29 )
         {
            if ( logic_uScriptAct_Delay_uScriptAct_Delay_29.AfterDelay == true )
            {
               Relay_In_30();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_In_30()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3b2dbc02-fd07-4c1e-908f-5ac3c0eab76d", "Camera Fade", Relay_In_30)) return; 
         {
            logic_uScriptAct_CameraFade_FadeMaterial_30 = FadeMaterial;
            
         }
         logic_uScriptAct_CameraFade_uScriptAct_CameraFade_30.In(logic_uScriptAct_CameraFade_TargetCamera_30, logic_uScriptAct_CameraFade_Direction_30, logic_uScriptAct_CameraFade_FadeMaterial_30, logic_uScriptAct_CameraFade_FadeTime_30, logic_uScriptAct_CameraFade_HoldTime_30, logic_uScriptAct_CameraFade_ColorOverride_30, logic_uScriptAct_CameraFade_FadeColor_30);
         logic_uScriptAct_CameraFade_DrivenFade_30 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_CameraFade_uScriptAct_CameraFade_30.FadeFinished;
         
         if ( test_0 == true )
         {
            Relay_In_28();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Camera Fade.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_DrivenFade_30( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            logic_uScriptAct_CameraFade_FadeMaterial_30 = FadeMaterial;
            
         }
         logic_uScriptAct_CameraFade_DrivenFade_30 = logic_uScriptAct_CameraFade_uScriptAct_CameraFade_30.DrivenFade();
         if ( true == logic_uScriptAct_CameraFade_DrivenFade_30 )
         {
            if ( logic_uScriptAct_CameraFade_uScriptAct_CameraFade_30.FadeFinished == true )
            {
               Relay_In_28();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FadeGraph.uscript at Camera Fade.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FadeGraph.uscript:8", local_8_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "78390c60-4cbd-45ae-80b8-e2b450cc661f", local_8_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FadeGraph.uscript:FadeColor", local_FadeColor_UnityEngine_Color);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b16cfc8b-88ba-4de2-b51b-9935dfa0634e", local_FadeColor_UnityEngine_Color);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FadeGraph.uscript:11", local_11_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "bc7508c1-a56d-404d-8435-3311e5eef63f", local_11_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FadeGraph.uscript:12", local_12_UnityEngine_Color);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f1b7ba42-7aba-40b4-9972-3e285c089dee", local_12_UnityEngine_Color);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FadeGraph.uscript:FadeGO", local_FadeGO_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "380d9369-8582-487b-bb70-8aba209075d8", local_FadeGO_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FadeGraph.uscript:19", local_19_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ebcc835f-7482-45e6-88fc-9c0b667d0f72", local_19_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FadeGraph.uscript:PlayerHealth", local_PlayerHealth_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "28955f4e-a656-4cc2-96c6-84a08fb094a4", local_PlayerHealth_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FadeGraph.uscript:25", local_25_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "92d481e7-a0fd-48ff-90d1-e59347f25999", local_25_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FadeGraph.uscript:FadeMaterial", FadeMaterial);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ff104f9c-15ea-40dc-8498-cd6be6036784", FadeMaterial);
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
