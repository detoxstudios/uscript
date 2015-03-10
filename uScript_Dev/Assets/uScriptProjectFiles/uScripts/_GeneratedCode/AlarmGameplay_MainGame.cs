//uScript Generated Code - Build 1.0.2830
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class AlarmGameplay_MainGame : uScriptLogic
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
   System.String local_26_System_String = "Console hacked.";
   UnityEngine.AudioClip local_Alarm_Audio_UnityEngine_AudioClip = default(UnityEngine.AudioClip);
   System.Boolean local_Alarm_Hacked__System_Boolean = (bool) false;
   System.Boolean local_Can_Hack__System_Boolean = (bool) true;
   UnityEngine.AudioClip local_Hack_Audio_UnityEngine_AudioClip = default(UnityEngine.AudioClip);
   System.String local_Hack_String_System_String = "Press 'H' to hack the console.";
   UnityEngine.Material local_Open_MAT_UnityEngine_Material = default(UnityEngine.Material);
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_0 = new uScriptAct_PlaySound( );
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_0 = default(UnityEngine.AudioClip);
   UnityEngine.GameObject[] logic_uScriptAct_PlaySound_target_0 = new UnityEngine.GameObject[] {null};
   System.Single logic_uScriptAct_PlaySound_volume_0 = (float) 1;
   System.Boolean logic_uScriptAct_PlaySound_loop_0 = (bool) false;
   bool logic_uScriptAct_PlaySound_Out_0 = true;
   //pointer to script instanced logic node
   uScriptAct_AssignMaterial logic_uScriptAct_AssignMaterial_uScriptAct_AssignMaterial_1 = new uScriptAct_AssignMaterial( );
   UnityEngine.GameObject[] logic_uScriptAct_AssignMaterial_Target_1 = new UnityEngine.GameObject[] {null};
   UnityEngine.Material logic_uScriptAct_AssignMaterial_materialName_1 = default(UnityEngine.Material);
   System.Int32 logic_uScriptAct_AssignMaterial_MatChannel_1 = (int) 0;
   bool logic_uScriptAct_AssignMaterial_Out_1 = true;
   //pointer to script instanced logic node
   uScriptAct_AssignMaterial logic_uScriptAct_AssignMaterial_uScriptAct_AssignMaterial_2 = new uScriptAct_AssignMaterial( );
   UnityEngine.GameObject[] logic_uScriptAct_AssignMaterial_Target_2 = new UnityEngine.GameObject[] {null};
   UnityEngine.Material logic_uScriptAct_AssignMaterial_materialName_2 = default(UnityEngine.Material);
   System.Int32 logic_uScriptAct_AssignMaterial_MatChannel_2 = (int) 1;
   bool logic_uScriptAct_AssignMaterial_Out_2 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_4 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_4;
   bool logic_uScriptAct_SetBool_Out_4 = true;
   bool logic_uScriptAct_SetBool_SetTrue_4 = true;
   bool logic_uScriptAct_SetBool_SetFalse_4 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_6 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_6 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_6 = true;
   bool logic_uScriptCon_CompareBool_False_6 = true;
   //pointer to script instanced logic node
   uScriptAct_SetColor logic_uScriptAct_SetColor_uScriptAct_SetColor_9 = new uScriptAct_SetColor( );
   UnityEngine.Color logic_uScriptAct_SetColor_Value_9 = new UnityEngine.Color( (float)0, (float)1, (float)0, (float)1 );
   UnityEngine.Color logic_uScriptAct_SetColor_TargetColor_9;
   bool logic_uScriptAct_SetColor_Out_9 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_11 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_11 = UnityEngine.KeyCode.H;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_11 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_11 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_11 = true;
   //pointer to script instanced logic node
   uScriptAct_LoadAudioClip logic_uScriptAct_LoadAudioClip_uScriptAct_LoadAudioClip_13 = new uScriptAct_LoadAudioClip( );
   System.String logic_uScriptAct_LoadAudioClip_name_13 = "Audio/alarm";
   UnityEngine.AudioClip logic_uScriptAct_LoadAudioClip_audioClip_13;
   bool logic_uScriptAct_LoadAudioClip_Out_13 = true;
   //pointer to script instanced logic node
   uScriptAct_LoadMaterial logic_uScriptAct_LoadMaterial_uScriptAct_LoadMaterial_14 = new uScriptAct_LoadMaterial( );
   System.String logic_uScriptAct_LoadMaterial_name_14 = "Materials/OpenMAT";
   UnityEngine.Material logic_uScriptAct_LoadMaterial_materialFile_14;
   bool logic_uScriptAct_LoadMaterial_Out_14 = true;
   //pointer to script instanced logic node
   uScriptAct_LoadAudioClip logic_uScriptAct_LoadAudioClip_uScriptAct_LoadAudioClip_15 = new uScriptAct_LoadAudioClip( );
   System.String logic_uScriptAct_LoadAudioClip_name_15 = "Audio/hack_shutdown";
   UnityEngine.AudioClip logic_uScriptAct_LoadAudioClip_audioClip_15;
   bool logic_uScriptAct_LoadAudioClip_Out_15 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_22 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_22 = "";
   System.Int32 logic_uScriptAct_PrintText_FontSize_22 = (int) 24;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_22 = UnityEngine.FontStyle.Bold;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_22 = new UnityEngine.Color( (float)1, (float)0.7762238, (float)0, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_22 = UnityEngine.TextAnchor.MiddleCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_22 = (int) 8;
   System.Single logic_uScriptAct_PrintText_time_22 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_22 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_23 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_23 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_23 = true;
   bool logic_uScriptCon_CompareBool_False_23 = true;
   //pointer to script instanced logic node
   uScriptAct_SetString logic_uScriptAct_SetString_uScriptAct_SetString_25 = new uScriptAct_SetString( );
   System.String logic_uScriptAct_SetString_Value_25 = "";
   System.Boolean logic_uScriptAct_SetString_ToUpperCase_25 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_ToLowerCase_25 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_TrimWhitespace_25 = (bool) false;
   System.String logic_uScriptAct_SetString_Target_25;
   bool logic_uScriptAct_SetString_Out_25 = true;
   //pointer to script instanced logic node
   AlarmGameplay_AlarmSetup logic_AlarmGameplay_AlarmSetup_AlarmGameplay_AlarmSetup_34 = new AlarmGameplay_AlarmSetup( );
   UnityEngine.AudioClip logic_AlarmGameplay_AlarmSetup_Alarm_Sound_34 = default(UnityEngine.AudioClip);
   System.Boolean logic_AlarmGameplay_AlarmSetup_Alarm_Hacked__34 = (bool) false;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_8 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_12 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_62 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_62 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_63 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_63 = default(UnityEngine.GameObject);
   
   //property nodes
   UnityEngine.Color property_color_Detox_ScriptEditor_Parameter_color_10 = UnityEngine.Color.black;
   UnityEngine.GameObject property_color_Detox_ScriptEditor_Parameter_Instance_10 = default(UnityEngine.GameObject);
   UnityEngine.GameObject property_color_Detox_ScriptEditor_Parameter_Instance_10_previous = null;
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   UnityEngine.Color property_color_Detox_ScriptEditor_Parameter_color_10_Get_Refresh( )
   {
      UnityEngine.Light component = property_color_Detox_ScriptEditor_Parameter_Instance_10.GetComponent<UnityEngine.Light>();
      if ( null != component )
      {
         return component.color;
      }
      else
      {
         return UnityEngine.Color.black;
      }
   }
   
   void property_color_Detox_ScriptEditor_Parameter_color_10_Set_Refresh( )
   {
      UnityEngine.Light component = property_color_Detox_ScriptEditor_Parameter_Instance_10.GetComponent<UnityEngine.Light>();
      if ( null != component )
      {
         component.color = property_color_Detox_ScriptEditor_Parameter_color_10;
      }
   }
   
   
   void SyncUnityHooks( )
   {
      if ( null == property_color_Detox_ScriptEditor_Parameter_Instance_10 || false == m_RegisteredForEvents )
      {
         property_color_Detox_ScriptEditor_Parameter_Instance_10 = GameObject.Find( "Door_PointLight" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_color_Detox_ScriptEditor_Parameter_Instance_10_previous != property_color_Detox_ScriptEditor_Parameter_Instance_10 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_color_Detox_ScriptEditor_Parameter_Instance_10_previous = property_color_Detox_ScriptEditor_Parameter_Instance_10;
         
         //setup new listeners
      }
      SyncEventListeners( );
      if ( null == logic_uScriptAct_PlaySound_target_0[0] || false == m_RegisteredForEvents )
      {
         logic_uScriptAct_PlaySound_target_0[0] = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
      if ( null == logic_uScriptAct_AssignMaterial_Target_1[0] || false == m_RegisteredForEvents )
      {
         logic_uScriptAct_AssignMaterial_Target_1[0] = GameObject.Find( "Security_Screen" ) as UnityEngine.GameObject;
      }
      if ( null == logic_uScriptAct_AssignMaterial_Target_2[0] || false == m_RegisteredForEvents )
      {
         logic_uScriptAct_AssignMaterial_Target_2[0] = GameObject.Find( "Door_Frame" ) as UnityEngine.GameObject;
      }
   }
   
   void RegisterForUnityHooks( )
   {
      //if our game object reference was changed then we need to reset event listeners
      if ( property_color_Detox_ScriptEditor_Parameter_Instance_10_previous != property_color_Detox_ScriptEditor_Parameter_Instance_10 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_color_Detox_ScriptEditor_Parameter_Instance_10_previous = property_color_Detox_ScriptEditor_Parameter_Instance_10;
         
         //setup new listeners
      }
      SyncEventListeners( );
   }
   
   void SyncEventListeners( )
   {
      {
         {
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( property_color_Detox_ScriptEditor_Parameter_Instance_10_previous != property_color_Detox_ScriptEditor_Parameter_Instance_10 || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  property_color_Detox_ScriptEditor_Parameter_Instance_10_previous = property_color_Detox_ScriptEditor_Parameter_Instance_10;
                  
                  //setup new listeners
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_8 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_8 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_8 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_8.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_8.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_8;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_12 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_12 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_12 )
         {
            {
               uScript_Global component = event_UnityEngine_GameObject_Instance_12.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_12.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_12;
                  component.uScriptLateStart += Instance_uScriptLateStart_12;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_62 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_62 = GameObject.Find( "Trigger_Alarm" ) as UnityEngine.GameObject;
         if ( null != event_UnityEngine_GameObject_Instance_62 )
         {
            {
               uScript_Trigger component = event_UnityEngine_GameObject_Instance_62.GetComponent<uScript_Trigger>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_62.AddComponent<uScript_Trigger>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_62;
                  component.OnExitTrigger += Instance_OnExitTrigger_62;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_62;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_63 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_63 = GameObject.Find( "Trigger_Console" ) as UnityEngine.GameObject;
         if ( null != event_UnityEngine_GameObject_Instance_63 )
         {
            {
               uScript_Trigger component = event_UnityEngine_GameObject_Instance_63.GetComponent<uScript_Trigger>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_63.AddComponent<uScript_Trigger>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_63;
                  component.OnExitTrigger += Instance_OnExitTrigger_63;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_63;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != event_UnityEngine_GameObject_Instance_8 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_8.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_8;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_12 )
      {
         {
            uScript_Global component = event_UnityEngine_GameObject_Instance_12.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_12;
               component.uScriptLateStart -= Instance_uScriptLateStart_12;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_62 )
      {
         {
            uScript_Trigger component = event_UnityEngine_GameObject_Instance_62.GetComponent<uScript_Trigger>();
            if ( null != component )
            {
               component.OnEnterTrigger -= Instance_OnEnterTrigger_62;
               component.OnExitTrigger -= Instance_OnExitTrigger_62;
               component.WhileInsideTrigger -= Instance_WhileInsideTrigger_62;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_63 )
      {
         {
            uScript_Trigger component = event_UnityEngine_GameObject_Instance_63.GetComponent<uScript_Trigger>();
            if ( null != component )
            {
               component.OnEnterTrigger -= Instance_OnEnterTrigger_63;
               component.OnExitTrigger -= Instance_OnExitTrigger_63;
               component.WhileInsideTrigger -= Instance_WhileInsideTrigger_63;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_0.SetParent(g);
      logic_uScriptAct_AssignMaterial_uScriptAct_AssignMaterial_1.SetParent(g);
      logic_uScriptAct_AssignMaterial_uScriptAct_AssignMaterial_2.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_4.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_6.SetParent(g);
      logic_uScriptAct_SetColor_uScriptAct_SetColor_9.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_11.SetParent(g);
      logic_uScriptAct_LoadAudioClip_uScriptAct_LoadAudioClip_13.SetParent(g);
      logic_uScriptAct_LoadMaterial_uScriptAct_LoadMaterial_14.SetParent(g);
      logic_uScriptAct_LoadAudioClip_uScriptAct_LoadAudioClip_15.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_22.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_23.SetParent(g);
      logic_uScriptAct_SetString_uScriptAct_SetString_25.SetParent(g);
      logic_AlarmGameplay_AlarmSetup_AlarmGameplay_AlarmSetup_34.SetParent(g);
   }
   public void Awake()
   {
      logic_AlarmGameplay_AlarmSetup_AlarmGameplay_AlarmSetup_34.Awake( );
      
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_0.Finished += uScriptAct_PlaySound_Finished_0;
      logic_AlarmGameplay_AlarmSetup_AlarmGameplay_AlarmSetup_34.Out___Alarm_Start += AlarmGameplay_AlarmSetup_Out___Alarm_Start_34;
      logic_AlarmGameplay_AlarmSetup_AlarmGameplay_AlarmSetup_34.Out___Alarm_Stop += AlarmGameplay_AlarmSetup_Out___Alarm_Stop_34;
   }
   
   public void Start()
   {
      SyncUnityHooks( );
      m_RegisteredForEvents = true;
      
      logic_AlarmGameplay_AlarmSetup_AlarmGameplay_AlarmSetup_34.Start( );
   }
   
   public void OnEnable()
   {
      RegisterForUnityHooks( );
      m_RegisteredForEvents = true;
      logic_AlarmGameplay_AlarmSetup_AlarmGameplay_AlarmSetup_34.OnEnable( );
   }
   
   public void OnDisable()
   {
      logic_AlarmGameplay_AlarmSetup_AlarmGameplay_AlarmSetup_34.OnDisable( );
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
      
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_0.Update( );
      logic_AlarmGameplay_AlarmSetup_AlarmGameplay_AlarmSetup_34.Update( );
   }
   
   public void OnDestroy()
   {
      logic_AlarmGameplay_AlarmSetup_AlarmGameplay_AlarmSetup_34.OnDestroy( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_0.Finished -= uScriptAct_PlaySound_Finished_0;
      logic_AlarmGameplay_AlarmSetup_AlarmGameplay_AlarmSetup_34.Out___Alarm_Start -= AlarmGameplay_AlarmSetup_Out___Alarm_Start_34;
      logic_AlarmGameplay_AlarmSetup_AlarmGameplay_AlarmSetup_34.Out___Alarm_Stop -= AlarmGameplay_AlarmSetup_Out___Alarm_Stop_34;
   }
   
   public void OnGUI()
   {
      logic_uScriptAct_PrintText_uScriptAct_PrintText_22.OnGUI( );
   }
   
   void Instance_KeyEvent_8(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_8( );
   }
   
   void Instance_uScriptStart_12(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_12( );
   }
   
   void Instance_uScriptLateStart_12(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptLateStart_12( );
   }
   
   void Instance_OnEnterTrigger_62(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_62 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_62( );
   }
   
   void Instance_OnExitTrigger_62(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_62 = e.GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_62( );
   }
   
   void Instance_WhileInsideTrigger_62(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_62 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_62( );
   }
   
   void Instance_OnEnterTrigger_63(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_63 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_63( );
   }
   
   void Instance_OnExitTrigger_63(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_63 = e.GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_63( );
   }
   
   void Instance_WhileInsideTrigger_63(object o, uScript_Trigger.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_63 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_63( );
   }
   
   void uScriptAct_PlaySound_Finished_0(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_0( );
   }
   
   void AlarmGameplay_AlarmSetup_Out___Alarm_Start_34(object o, AlarmGameplay_AlarmSetup.LogicEventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Out___Alarm_Start_34( );
   }
   
   void AlarmGameplay_AlarmSetup_Out___Alarm_Stop_34(object o, AlarmGameplay_AlarmSetup.LogicEventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Out___Alarm_Stop_34( );
   }
   
   void Relay_Finished_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("70c291c7-79e6-48cc-9084-eac106f8a1ab", "Play_Sound", Relay_Finished_0)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Play_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("70c291c7-79e6-48cc-9084-eac106f8a1ab", "Play_Sound", Relay_Play_0)) return; 
         {
            {
               logic_uScriptAct_PlaySound_audioClip_0 = local_Hack_Audio_UnityEngine_AudioClip;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_0.Play(logic_uScriptAct_PlaySound_audioClip_0, logic_uScriptAct_PlaySound_target_0, logic_uScriptAct_PlaySound_volume_0, logic_uScriptAct_PlaySound_loop_0);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_PlaySound_uScriptAct_PlaySound_0.Out;
         
         if ( test_0 == true )
         {
            Relay_In_9();
            Relay_In_25();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_UpdateVolume_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("70c291c7-79e6-48cc-9084-eac106f8a1ab", "Play_Sound", Relay_UpdateVolume_0)) return; 
         {
            {
               logic_uScriptAct_PlaySound_audioClip_0 = local_Hack_Audio_UnityEngine_AudioClip;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_0.UpdateVolume(logic_uScriptAct_PlaySound_audioClip_0, logic_uScriptAct_PlaySound_target_0, logic_uScriptAct_PlaySound_volume_0, logic_uScriptAct_PlaySound_loop_0);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_PlaySound_uScriptAct_PlaySound_0.Out;
         
         if ( test_0 == true )
         {
            Relay_In_9();
            Relay_In_25();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("70c291c7-79e6-48cc-9084-eac106f8a1ab", "Play_Sound", Relay_Stop_0)) return; 
         {
            {
               logic_uScriptAct_PlaySound_audioClip_0 = local_Hack_Audio_UnityEngine_AudioClip;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_0.Stop(logic_uScriptAct_PlaySound_audioClip_0, logic_uScriptAct_PlaySound_target_0, logic_uScriptAct_PlaySound_volume_0, logic_uScriptAct_PlaySound_loop_0);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_PlaySound_uScriptAct_PlaySound_0.Out;
         
         if ( test_0 == true )
         {
            Relay_In_9();
            Relay_In_25();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("95447226-5a63-49d4-a20a-9574816371ba", "Assign_Material", Relay_In_1)) return; 
         {
            {
            }
            {
               logic_uScriptAct_AssignMaterial_materialName_1 = local_Open_MAT_UnityEngine_Material;
               
            }
            {
            }
         }
         logic_uScriptAct_AssignMaterial_uScriptAct_AssignMaterial_1.In(logic_uScriptAct_AssignMaterial_Target_1, logic_uScriptAct_AssignMaterial_materialName_1, logic_uScriptAct_AssignMaterial_MatChannel_1);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Assign Material.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("722c036f-bfd3-47da-8ea4-1b4f2c62b02c", "Assign_Material", Relay_In_2)) return; 
         {
            {
            }
            {
               logic_uScriptAct_AssignMaterial_materialName_2 = local_Open_MAT_UnityEngine_Material;
               
            }
            {
            }
         }
         logic_uScriptAct_AssignMaterial_uScriptAct_AssignMaterial_2.In(logic_uScriptAct_AssignMaterial_Target_2, logic_uScriptAct_AssignMaterial_materialName_2, logic_uScriptAct_AssignMaterial_MatChannel_2);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Assign Material.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_4()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a72c7648-3ae3-4971-a097-272b3511d09b", "Set_Bool", Relay_True_4)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_4.True(out logic_uScriptAct_SetBool_Target_4);
         local_Alarm_Hacked__System_Boolean = logic_uScriptAct_SetBool_Target_4;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_4.Out;
         
         if ( test_0 == true )
         {
            Relay_Play_0();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_4()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a72c7648-3ae3-4971-a097-272b3511d09b", "Set_Bool", Relay_False_4)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_4.False(out logic_uScriptAct_SetBool_Target_4);
         local_Alarm_Hacked__System_Boolean = logic_uScriptAct_SetBool_Target_4;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_4.Out;
         
         if ( test_0 == true )
         {
            Relay_Play_0();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4499df27-2966-473e-865e-f6ed8840bedd", "Compare_Bool", Relay_In_6)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_6 = local_Can_Hack__System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_6.In(logic_uScriptCon_CompareBool_Bool_6);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_6.True;
         
         if ( test_0 == true )
         {
            Relay_In_23();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_8()
   {
      if (true == CheckDebugBreak("7624d46c-7a48-4c2b-b873-7e750c7a71fa", "Input_Events", Relay_KeyEvent_8)) return; 
      Relay_In_11();
   }
   
   void Relay_In_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ea2bed66-7a23-4f83-9413-f8580d9fba4d", "Set_Color", Relay_In_9)) return; 
         {
            {
            }
            {
            }
         }
         logic_uScriptAct_SetColor_uScriptAct_SetColor_9.In(logic_uScriptAct_SetColor_Value_9, out logic_uScriptAct_SetColor_TargetColor_9);
         property_color_Detox_ScriptEditor_Parameter_color_10 = logic_uScriptAct_SetColor_TargetColor_9;
         property_color_Detox_ScriptEditor_Parameter_color_10_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetColor_uScriptAct_SetColor_9.Out;
         
         if ( test_0 == true )
         {
            Relay_In_2();
            Relay_In_1();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Set Color.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_11()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("812b5fc5-f40f-4bff-9242-b0de30fd465c", "Input_Events_Filter", Relay_In_11)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_11.In(logic_uScriptAct_OnInputEventFilter_KeyCode_11);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_11.KeyUp;
         
         if ( test_0 == true )
         {
            Relay_In_6();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_uScriptStart_12()
   {
      if (true == CheckDebugBreak("88a985e9-4f2c-4a56-982b-5f2e5a409425", "uScript_Events", Relay_uScriptStart_12)) return; 
      Relay_In_13();
   }
   
   void Relay_uScriptLateStart_12()
   {
      if (true == CheckDebugBreak("88a985e9-4f2c-4a56-982b-5f2e5a409425", "uScript_Events", Relay_uScriptLateStart_12)) return; 
   }
   
   void Relay_In_13()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("889a18c0-0cfd-4611-8f36-b6eccaeb1fc8", "Load_AudioClip", Relay_In_13)) return; 
         {
            {
            }
            {
            }
         }
         logic_uScriptAct_LoadAudioClip_uScriptAct_LoadAudioClip_13.In(logic_uScriptAct_LoadAudioClip_name_13, out logic_uScriptAct_LoadAudioClip_audioClip_13);
         local_Alarm_Audio_UnityEngine_AudioClip = logic_uScriptAct_LoadAudioClip_audioClip_13;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_LoadAudioClip_uScriptAct_LoadAudioClip_13.Out;
         
         if ( test_0 == true )
         {
            Relay_In_15();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Load AudioClip.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_14()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("257957cc-4313-4f02-abfe-aa8fc0f2d3da", "Load_Material", Relay_In_14)) return; 
         {
            {
            }
            {
            }
         }
         logic_uScriptAct_LoadMaterial_uScriptAct_LoadMaterial_14.In(logic_uScriptAct_LoadMaterial_name_14, out logic_uScriptAct_LoadMaterial_materialFile_14);
         local_Open_MAT_UnityEngine_Material = logic_uScriptAct_LoadMaterial_materialFile_14;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Load Material.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_15()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e14b563b-f0fa-40d2-9bac-e2916214cc46", "Load_AudioClip", Relay_In_15)) return; 
         {
            {
            }
            {
            }
         }
         logic_uScriptAct_LoadAudioClip_uScriptAct_LoadAudioClip_15.In(logic_uScriptAct_LoadAudioClip_name_15, out logic_uScriptAct_LoadAudioClip_audioClip_15);
         local_Hack_Audio_UnityEngine_AudioClip = logic_uScriptAct_LoadAudioClip_audioClip_15;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_LoadAudioClip_uScriptAct_LoadAudioClip_15.Out;
         
         if ( test_0 == true )
         {
            Relay_In_14();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Load AudioClip.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_22()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b2bb5a05-e7c7-4dd6-9777-9371626bd5a2", "Print_Text", Relay_ShowLabel_22)) return; 
         {
            {
               logic_uScriptAct_PrintText_Text_22 = local_Hack_String_System_String;
               
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_22.ShowLabel(logic_uScriptAct_PrintText_Text_22, logic_uScriptAct_PrintText_FontSize_22, logic_uScriptAct_PrintText_FontStyle_22, logic_uScriptAct_PrintText_FontColor_22, logic_uScriptAct_PrintText_textAnchor_22, logic_uScriptAct_PrintText_EdgePadding_22, logic_uScriptAct_PrintText_time_22);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_22()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b2bb5a05-e7c7-4dd6-9777-9371626bd5a2", "Print_Text", Relay_HideLabel_22)) return; 
         {
            {
               logic_uScriptAct_PrintText_Text_22 = local_Hack_String_System_String;
               
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_22.HideLabel(logic_uScriptAct_PrintText_Text_22, logic_uScriptAct_PrintText_FontSize_22, logic_uScriptAct_PrintText_FontStyle_22, logic_uScriptAct_PrintText_FontColor_22, logic_uScriptAct_PrintText_textAnchor_22, logic_uScriptAct_PrintText_EdgePadding_22, logic_uScriptAct_PrintText_time_22);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_23()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d9a7b4fd-804d-465e-94af-6cb3b07b3643", "Compare_Bool", Relay_In_23)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_23 = local_Alarm_Hacked__System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_23.In(logic_uScriptCon_CompareBool_Bool_23);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_23.False;
         
         if ( test_0 == true )
         {
            Relay_True_4();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_25()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a3593eed-ad64-4f12-b30b-66b77dd5d636", "Set_String", Relay_In_25)) return; 
         {
            {
               logic_uScriptAct_SetString_Value_25 = local_26_System_String;
               
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
         logic_uScriptAct_SetString_uScriptAct_SetString_25.In(logic_uScriptAct_SetString_Value_25, logic_uScriptAct_SetString_ToUpperCase_25, logic_uScriptAct_SetString_ToLowerCase_25, logic_uScriptAct_SetString_TrimWhitespace_25, out logic_uScriptAct_SetString_Target_25);
         local_Hack_String_System_String = logic_uScriptAct_SetString_Target_25;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Set String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Out___Alarm_Start_34()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8fdf5393-0564-4d28-9e78-aa3a4f827e37", "Alarm_Setup", Relay_Out___Alarm_Start_34)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Alarm Setup.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Out___Alarm_Stop_34()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8fdf5393-0564-4d28-9e78-aa3a4f827e37", "Alarm_Setup", Relay_Out___Alarm_Stop_34)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Alarm Setup.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Alarm_Start_34()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8fdf5393-0564-4d28-9e78-aa3a4f827e37", "Alarm_Setup", Relay_Alarm_Start_34)) return; 
         {
            {
               logic_AlarmGameplay_AlarmSetup_Alarm_Sound_34 = local_Alarm_Audio_UnityEngine_AudioClip;
               
            }
            {
               logic_AlarmGameplay_AlarmSetup_Alarm_Hacked__34 = local_Alarm_Hacked__System_Boolean;
               
            }
         }
         logic_AlarmGameplay_AlarmSetup_AlarmGameplay_AlarmSetup_34.Alarm_Start(logic_AlarmGameplay_AlarmSetup_Alarm_Sound_34, logic_AlarmGameplay_AlarmSetup_Alarm_Hacked__34);
         
         //Don't copy 'out' values back to the global variables because this was an auto generated nested node
         //and those values get set through an event which is called before the above method exited
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Alarm Setup.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Alarm_Stop_34()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8fdf5393-0564-4d28-9e78-aa3a4f827e37", "Alarm_Setup", Relay_Alarm_Stop_34)) return; 
         {
            {
               logic_AlarmGameplay_AlarmSetup_Alarm_Sound_34 = local_Alarm_Audio_UnityEngine_AudioClip;
               
            }
            {
               logic_AlarmGameplay_AlarmSetup_Alarm_Hacked__34 = local_Alarm_Hacked__System_Boolean;
               
            }
         }
         logic_AlarmGameplay_AlarmSetup_AlarmGameplay_AlarmSetup_34.Alarm_Stop(logic_AlarmGameplay_AlarmSetup_Alarm_Sound_34, logic_AlarmGameplay_AlarmSetup_Alarm_Hacked__34);
         
         //Don't copy 'out' values back to the global variables because this was an auto generated nested node
         //and those values get set through an event which is called before the above method exited
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_MainGame.uscript at Alarm Setup.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnEnterTrigger_62()
   {
      if (true == CheckDebugBreak("25da3948-574b-4b7c-96d9-6c39c4967544", "Trigger_Event", Relay_OnEnterTrigger_62)) return; 
      Relay_Alarm_Start_34();
   }
   
   void Relay_OnExitTrigger_62()
   {
      if (true == CheckDebugBreak("25da3948-574b-4b7c-96d9-6c39c4967544", "Trigger_Event", Relay_OnExitTrigger_62)) return; 
      Relay_Alarm_Stop_34();
   }
   
   void Relay_WhileInsideTrigger_62()
   {
      if (true == CheckDebugBreak("25da3948-574b-4b7c-96d9-6c39c4967544", "Trigger_Event", Relay_WhileInsideTrigger_62)) return; 
   }
   
   void Relay_OnEnterTrigger_63()
   {
      if (true == CheckDebugBreak("2b1e95d4-d155-4bba-a366-16b622ee8d88", "Trigger_Event", Relay_OnEnterTrigger_63)) return; 
   }
   
   void Relay_OnExitTrigger_63()
   {
      if (true == CheckDebugBreak("2b1e95d4-d155-4bba-a366-16b622ee8d88", "Trigger_Event", Relay_OnExitTrigger_63)) return; 
      Relay_HideLabel_22();
   }
   
   void Relay_WhileInsideTrigger_63()
   {
      if (true == CheckDebugBreak("2b1e95d4-d155-4bba-a366-16b622ee8d88", "Trigger_Event", Relay_WhileInsideTrigger_63)) return; 
      Relay_ShowLabel_22();
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AlarmGameplay_MainGame.uscript:Can Hack?", local_Can_Hack__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "cdd47181-e031-46ce-9fc3-ee9681826bd8", local_Can_Hack__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AlarmGameplay_MainGame.uscript:Alarm Hacked?", local_Alarm_Hacked__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a5508d8a-6b21-49ee-84d5-9359e2bb9f7e", local_Alarm_Hacked__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AlarmGameplay_MainGame.uscript:Alarm Audio", local_Alarm_Audio_UnityEngine_AudioClip);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "dec6c17c-0f2c-40b4-94eb-11088b36a489", local_Alarm_Audio_UnityEngine_AudioClip);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AlarmGameplay_MainGame.uscript:Hack Audio", local_Hack_Audio_UnityEngine_AudioClip);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "1d35001e-02fa-4848-b146-941c18e2f55f", local_Hack_Audio_UnityEngine_AudioClip);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AlarmGameplay_MainGame.uscript:Open MAT", local_Open_MAT_UnityEngine_Material);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "fe205744-59ed-49c3-88d9-f961cca7d1a6", local_Open_MAT_UnityEngine_Material);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AlarmGameplay_MainGame.uscript:26", local_26_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "8240847b-bc3f-4eb1-a58c-94736df4bece", local_26_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AlarmGameplay_MainGame.uscript:Hack String", local_Hack_String_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c9a8c8d3-e5ec-443f-b520-a1464ba32339", local_Hack_String_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "13d5ac84-faf7-4ad3-9e0b-fdfdf1c7f201", property_color_Detox_ScriptEditor_Parameter_color_10);
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
