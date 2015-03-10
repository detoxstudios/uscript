//uScript Generated Code - Build 1.0.2830
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class SimpleUI_Logic : uScriptLogic
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
   UnityEngine.GameObject local_15_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_15_UnityEngine_GameObject_previous = null;
   System.String local_22_System_String = "";
   System.String local_24_System_String = "Cube position:";
   System.String local_Enabled_Text_System_String = "Enable";
   System.Boolean local_Jump_Enabled_System_Boolean = (bool) false;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_GUISetBackgroundColor logic_uScriptAct_GUISetBackgroundColor_uScriptAct_GUISetBackgroundColor_1 = new uScriptAct_GUISetBackgroundColor( );
   UnityEngine.Color logic_uScriptAct_GUISetBackgroundColor_color_1 = new UnityEngine.Color( (float)1, (float)0, (float)0, (float)1 );
   bool logic_uScriptAct_GUISetBackgroundColor_Out_1 = true;
   //pointer to script instanced logic node
   uScriptAct_GUIButton logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2 = new uScriptAct_GUIButton( );
   System.String logic_uScriptAct_GUIButton_Text_2 = "Jump";
   System.Int32 logic_uScriptAct_GUIButton_identifier_2 = (int) 0;
   UnityEngine.Rect logic_uScriptAct_GUIButton_Position_2 = new Rect( (float)10, (float)10, (float)100, (float)25 );
   UnityEngine.Texture2D logic_uScriptAct_GUIButton_Texture_2 = default(UnityEngine.Texture2D);
   System.String logic_uScriptAct_GUIButton_ToolTip_2 = "";
   System.String logic_uScriptAct_GUIButton_guiStyle_2 = "";
   bool logic_uScriptAct_GUIButton_Out_2 = true;
   //pointer to script instanced logic node
   uScriptAct_GUISetEnabledState logic_uScriptAct_GUISetEnabledState_uScriptAct_GUISetEnabledState_3 = new uScriptAct_GUISetEnabledState( );
   System.Boolean logic_uScriptAct_GUISetEnabledState_Enabled_3 = (bool) false;
   bool logic_uScriptAct_GUISetEnabledState_Out_3 = true;
   //pointer to script instanced logic node
   uScriptAct_GUISetEnabledState logic_uScriptAct_GUISetEnabledState_uScriptAct_GUISetEnabledState_5 = new uScriptAct_GUISetEnabledState( );
   System.Boolean logic_uScriptAct_GUISetEnabledState_Enabled_5 = (bool) true;
   bool logic_uScriptAct_GUISetEnabledState_Out_5 = true;
   //pointer to script instanced logic node
   uScriptAct_GUISetBackgroundColor logic_uScriptAct_GUISetBackgroundColor_uScriptAct_GUISetBackgroundColor_6 = new uScriptAct_GUISetBackgroundColor( );
   UnityEngine.Color logic_uScriptAct_GUISetBackgroundColor_color_6 = new UnityEngine.Color( (float)0, (float)1, (float)0, (float)1 );
   bool logic_uScriptAct_GUISetBackgroundColor_Out_6 = true;
   //pointer to script instanced logic node
   uScriptAct_GUIButton logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7 = new uScriptAct_GUIButton( );
   System.String logic_uScriptAct_GUIButton_Text_7 = "";
   System.Int32 logic_uScriptAct_GUIButton_identifier_7 = (int) 0;
   UnityEngine.Rect logic_uScriptAct_GUIButton_Position_7 = new Rect( (float)120, (float)10, (float)100, (float)25 );
   UnityEngine.Texture2D logic_uScriptAct_GUIButton_Texture_7 = default(UnityEngine.Texture2D);
   System.String logic_uScriptAct_GUIButton_ToolTip_7 = "";
   System.String logic_uScriptAct_GUIButton_guiStyle_7 = "";
   bool logic_uScriptAct_GUIButton_Out_7 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_9 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_9;
   bool logic_uScriptAct_SetBool_Out_9 = true;
   bool logic_uScriptAct_SetBool_SetTrue_9 = true;
   bool logic_uScriptAct_SetBool_SetFalse_9 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_10 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_10 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_10 = true;
   bool logic_uScriptCon_CompareBool_False_10 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_11 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_11;
   bool logic_uScriptAct_SetBool_Out_11 = true;
   bool logic_uScriptAct_SetBool_SetTrue_11 = true;
   bool logic_uScriptAct_SetBool_SetFalse_11 = true;
   //pointer to script instanced logic node
   uScriptAct_SetString logic_uScriptAct_SetString_uScriptAct_SetString_13 = new uScriptAct_SetString( );
   System.String logic_uScriptAct_SetString_Value_13 = "Enable";
   System.Boolean logic_uScriptAct_SetString_ToUpperCase_13 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_ToLowerCase_13 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_TrimWhitespace_13 = (bool) false;
   System.String logic_uScriptAct_SetString_Target_13;
   bool logic_uScriptAct_SetString_Out_13 = true;
   //pointer to script instanced logic node
   uScriptAct_SetString logic_uScriptAct_SetString_uScriptAct_SetString_14 = new uScriptAct_SetString( );
   System.String logic_uScriptAct_SetString_Value_14 = "Disable";
   System.Boolean logic_uScriptAct_SetString_ToUpperCase_14 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_ToLowerCase_14 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_TrimWhitespace_14 = (bool) false;
   System.String logic_uScriptAct_SetString_Target_14;
   bool logic_uScriptAct_SetString_Out_14 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_20 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_20 = "";
   System.Int32 logic_uScriptAct_PrintText_FontSize_20 = (int) 16;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_20 = UnityEngine.FontStyle.Bold;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_20 = new UnityEngine.Color( (float)1, (float)1, (float)1, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_20 = UnityEngine.TextAnchor.LowerCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_20 = (int) 8;
   System.Single logic_uScriptAct_PrintText_time_20 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_20 = true;
   //pointer to script instanced logic node
   uScriptAct_Concatenate logic_uScriptAct_Concatenate_uScriptAct_Concatenate_21 = new uScriptAct_Concatenate( );
   System.Object[] logic_uScriptAct_Concatenate_A_21 = new System.Object[] {};
   System.Object[] logic_uScriptAct_Concatenate_B_21 = new System.Object[] {};
   System.String logic_uScriptAct_Concatenate_Separator_21 = " ";
   System.String logic_uScriptAct_Concatenate_Result_21;
   bool logic_uScriptAct_Concatenate_Out_21 = true;
   
   //event nodes
   System.Boolean event_UnityEngine_GameObject_GUIChanged_0 = (bool) false;
   System.String event_UnityEngine_GameObject_FocusedControl_0 = "";
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_0 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_23 = default(UnityEngine.GameObject);
   
   //property nodes
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_25 = new Vector3( );
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_25 = default(UnityEngine.GameObject);
   UnityEngine.GameObject property_position_Detox_ScriptEditor_Parameter_Instance_25_previous = null;
   
   //method nodes
   UnityEngine.Vector3 method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_force_16 = new Vector3( (float)0, (float)300, (float)0 );
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   UnityEngine.Vector3 property_position_Detox_ScriptEditor_Parameter_position_25_Get_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_25.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         return component.position;
      }
      else
      {
         return new Vector3( );
      }
   }
   
   void property_position_Detox_ScriptEditor_Parameter_position_25_Set_Refresh( )
   {
      UnityEngine.Transform component = property_position_Detox_ScriptEditor_Parameter_Instance_25.GetComponent<UnityEngine.Transform>();
      if ( null != component )
      {
         component.position = property_position_Detox_ScriptEditor_Parameter_position_25;
      }
   }
   
   
   void SyncUnityHooks( )
   {
      if ( null == property_position_Detox_ScriptEditor_Parameter_Instance_25 || false == m_RegisteredForEvents )
      {
         property_position_Detox_ScriptEditor_Parameter_Instance_25 = GameObject.Find( "Cube" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_25_previous != property_position_Detox_ScriptEditor_Parameter_Instance_25 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_25_previous = property_position_Detox_ScriptEditor_Parameter_Instance_25;
         
         //setup new listeners
      }
      SyncEventListeners( );
      if ( null == local_15_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_15_UnityEngine_GameObject = GameObject.Find( "Cube" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_15_UnityEngine_GameObject_previous != local_15_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_15_UnityEngine_GameObject_previous = local_15_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void RegisterForUnityHooks( )
   {
      //if our game object reference was changed then we need to reset event listeners
      if ( property_position_Detox_ScriptEditor_Parameter_Instance_25_previous != property_position_Detox_ScriptEditor_Parameter_Instance_25 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         property_position_Detox_ScriptEditor_Parameter_Instance_25_previous = property_position_Detox_ScriptEditor_Parameter_Instance_25;
         
         //setup new listeners
      }
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_15_UnityEngine_GameObject_previous != local_15_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_15_UnityEngine_GameObject_previous = local_15_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void SyncEventListeners( )
   {
      {
         {
            {
               //if our game object reference was changed then we need to reset event listeners
               if ( property_position_Detox_ScriptEditor_Parameter_Instance_25_previous != property_position_Detox_ScriptEditor_Parameter_Instance_25 || false == m_RegisteredForEvents )
               {
                  //tear down old listeners
                  
                  property_position_Detox_ScriptEditor_Parameter_Instance_25_previous = property_position_Detox_ScriptEditor_Parameter_Instance_25;
                  
                  //setup new listeners
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_0 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_0 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_0 )
         {
            {
               if ( null == thisScriptsOnGuiListener )
               {
                  //OnGUI need unique listeners so calls like GUI.depth will work across uScripts
                  thisScriptsOnGuiListener = event_UnityEngine_GameObject_Instance_0.AddComponent<uScript_GUI>();
               }
               uScript_GUI component = thisScriptsOnGuiListener;
               if ( null != component )
               {
                  component.OnGui += Instance_OnGui_0;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_23 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_23 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_23 )
         {
            {
               uScript_Update component = event_UnityEngine_GameObject_Instance_23.GetComponent<uScript_Update>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_23.AddComponent<uScript_Update>();
               }
               if ( null != component )
               {
                  component.OnUpdate += Instance_OnUpdate_23;
                  component.OnLateUpdate += Instance_OnLateUpdate_23;
                  component.OnFixedUpdate += Instance_OnFixedUpdate_23;
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
            if ( null == thisScriptsOnGuiListener )
            {
               //OnGUI need unique listeners so calls like GUI.depth will work across uScripts
               thisScriptsOnGuiListener = event_UnityEngine_GameObject_Instance_0.AddComponent<uScript_GUI>();
            }
            uScript_GUI component = thisScriptsOnGuiListener;
            if ( null != component )
            {
               component.OnGui -= Instance_OnGui_0;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_23 )
      {
         {
            uScript_Update component = event_UnityEngine_GameObject_Instance_23.GetComponent<uScript_Update>();
            if ( null != component )
            {
               component.OnUpdate -= Instance_OnUpdate_23;
               component.OnLateUpdate -= Instance_OnLateUpdate_23;
               component.OnFixedUpdate -= Instance_OnFixedUpdate_23;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_GUISetBackgroundColor_uScriptAct_GUISetBackgroundColor_1.SetParent(g);
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2.SetParent(g);
      logic_uScriptAct_GUISetEnabledState_uScriptAct_GUISetEnabledState_3.SetParent(g);
      logic_uScriptAct_GUISetEnabledState_uScriptAct_GUISetEnabledState_5.SetParent(g);
      logic_uScriptAct_GUISetBackgroundColor_uScriptAct_GUISetBackgroundColor_6.SetParent(g);
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_9.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_10.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_11.SetParent(g);
      logic_uScriptAct_SetString_uScriptAct_SetString_13.SetParent(g);
      logic_uScriptAct_SetString_uScriptAct_SetString_14.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_20.SetParent(g);
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_21.SetParent(g);
   }
   public void Awake()
   {
      
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2.OnButtonDown += uScriptAct_GUIButton_OnButtonDown_2;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2.OnButtonHeld += uScriptAct_GUIButton_OnButtonHeld_2;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2.OnButtonUp += uScriptAct_GUIButton_OnButtonUp_2;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2.OnButtonClicked += uScriptAct_GUIButton_OnButtonClicked_2;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7.OnButtonDown += uScriptAct_GUIButton_OnButtonDown_7;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7.OnButtonHeld += uScriptAct_GUIButton_OnButtonHeld_7;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7.OnButtonUp += uScriptAct_GUIButton_OnButtonUp_7;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7.OnButtonClicked += uScriptAct_GUIButton_OnButtonClicked_7;
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
      
   }
   
   public void OnDestroy()
   {
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2.OnButtonDown -= uScriptAct_GUIButton_OnButtonDown_2;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2.OnButtonHeld -= uScriptAct_GUIButton_OnButtonHeld_2;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2.OnButtonUp -= uScriptAct_GUIButton_OnButtonUp_2;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2.OnButtonClicked -= uScriptAct_GUIButton_OnButtonClicked_2;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7.OnButtonDown -= uScriptAct_GUIButton_OnButtonDown_7;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7.OnButtonHeld -= uScriptAct_GUIButton_OnButtonHeld_7;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7.OnButtonUp -= uScriptAct_GUIButton_OnButtonUp_7;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7.OnButtonClicked -= uScriptAct_GUIButton_OnButtonClicked_7;
   }
   
   public void OnGUI()
   {
      logic_uScriptAct_PrintText_uScriptAct_PrintText_20.OnGUI( );
   }
   
   void Instance_OnGui_0(object o, uScript_GUI.GUIEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GUIChanged_0 = e.GUIChanged;
      event_UnityEngine_GameObject_FocusedControl_0 = e.FocusedControl;
      //relay event to nodes
      Relay_OnGui_0( );
   }
   
   void Instance_OnUpdate_23(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUpdate_23( );
   }
   
   void Instance_OnLateUpdate_23(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnLateUpdate_23( );
   }
   
   void Instance_OnFixedUpdate_23(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnFixedUpdate_23( );
   }
   
   void uScriptAct_GUIButton_OnButtonDown_2(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonDown_2( );
   }
   
   void uScriptAct_GUIButton_OnButtonHeld_2(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonHeld_2( );
   }
   
   void uScriptAct_GUIButton_OnButtonUp_2(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonUp_2( );
   }
   
   void uScriptAct_GUIButton_OnButtonClicked_2(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonClicked_2( );
   }
   
   void uScriptAct_GUIButton_OnButtonDown_7(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonDown_7( );
   }
   
   void uScriptAct_GUIButton_OnButtonHeld_7(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonHeld_7( );
   }
   
   void uScriptAct_GUIButton_OnButtonUp_7(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonUp_7( );
   }
   
   void uScriptAct_GUIButton_OnButtonClicked_7(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonClicked_7( );
   }
   
   void Relay_OnGui_0()
   {
      if (true == CheckDebugBreak("b51b9490-29c2-4ce8-8b73-59f914eaec5e", "GUI_Events", Relay_OnGui_0)) return; 
      Relay_In_1();
   }
   
   void Relay_In_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a730152c-c939-4f79-a63c-0e7254d46f6c", "GUI_Set_Background_Color", Relay_In_1)) return; 
         {
            {
            }
         }
         logic_uScriptAct_GUISetBackgroundColor_uScriptAct_GUISetBackgroundColor_1.In(logic_uScriptAct_GUISetBackgroundColor_color_1);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUISetBackgroundColor_uScriptAct_GUISetBackgroundColor_1.Out;
         
         if ( test_0 == true )
         {
            Relay_In_3();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at GUI Set Background Color.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonDown_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4e442452-5c25-4eac-984e-9b3987f951d7", "GUI_Button", Relay_OnButtonDown_2)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonHeld_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4e442452-5c25-4eac-984e-9b3987f951d7", "GUI_Button", Relay_OnButtonHeld_2)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonUp_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4e442452-5c25-4eac-984e-9b3987f951d7", "GUI_Button", Relay_OnButtonUp_2)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonClicked_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4e442452-5c25-4eac-984e-9b3987f951d7", "GUI_Button", Relay_OnButtonClicked_2)) return; 
         Relay_AddRelativeForce_16();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4e442452-5c25-4eac-984e-9b3987f951d7", "GUI_Button", Relay_In_2)) return; 
         {
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
         logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2.In(logic_uScriptAct_GUIButton_Text_2, logic_uScriptAct_GUIButton_identifier_2, logic_uScriptAct_GUIButton_Position_2, logic_uScriptAct_GUIButton_Texture_2, logic_uScriptAct_GUIButton_ToolTip_2, logic_uScriptAct_GUIButton_guiStyle_2);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2.Out;
         
         if ( test_0 == true )
         {
            Relay_In_5();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0d74540d-189b-47db-b10f-7aabb787ca26", "GUI_Set_Enabled_State", Relay_In_3)) return; 
         {
            {
               logic_uScriptAct_GUISetEnabledState_Enabled_3 = local_Jump_Enabled_System_Boolean;
               
            }
         }
         logic_uScriptAct_GUISetEnabledState_uScriptAct_GUISetEnabledState_3.In(logic_uScriptAct_GUISetEnabledState_Enabled_3);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUISetEnabledState_uScriptAct_GUISetEnabledState_3.Out;
         
         if ( test_0 == true )
         {
            Relay_In_2();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at GUI Set Enabled State.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("724c40a7-e27c-4d9b-b72d-91e674bfa54a", "GUI_Set_Enabled_State", Relay_In_5)) return; 
         {
            {
            }
         }
         logic_uScriptAct_GUISetEnabledState_uScriptAct_GUISetEnabledState_5.In(logic_uScriptAct_GUISetEnabledState_Enabled_5);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUISetEnabledState_uScriptAct_GUISetEnabledState_5.Out;
         
         if ( test_0 == true )
         {
            Relay_In_6();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at GUI Set Enabled State.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("959a7a71-b2fc-46b8-a376-e971c58b399a", "GUI_Set_Background_Color", Relay_In_6)) return; 
         {
            {
            }
         }
         logic_uScriptAct_GUISetBackgroundColor_uScriptAct_GUISetBackgroundColor_6.In(logic_uScriptAct_GUISetBackgroundColor_color_6);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUISetBackgroundColor_uScriptAct_GUISetBackgroundColor_6.Out;
         
         if ( test_0 == true )
         {
            Relay_In_7();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at GUI Set Background Color.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonDown_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("554c0e61-5a15-4c92-8764-bd3ae6c0720b", "GUI_Button", Relay_OnButtonDown_7)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonHeld_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("554c0e61-5a15-4c92-8764-bd3ae6c0720b", "GUI_Button", Relay_OnButtonHeld_7)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonUp_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("554c0e61-5a15-4c92-8764-bd3ae6c0720b", "GUI_Button", Relay_OnButtonUp_7)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonClicked_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("554c0e61-5a15-4c92-8764-bd3ae6c0720b", "GUI_Button", Relay_OnButtonClicked_7)) return; 
         Relay_In_10();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("554c0e61-5a15-4c92-8764-bd3ae6c0720b", "GUI_Button", Relay_In_7)) return; 
         {
            {
               logic_uScriptAct_GUIButton_Text_7 = local_Enabled_Text_System_String;
               
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
         logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7.In(logic_uScriptAct_GUIButton_Text_7, logic_uScriptAct_GUIButton_identifier_7, logic_uScriptAct_GUIButton_Position_7, logic_uScriptAct_GUIButton_Texture_7, logic_uScriptAct_GUIButton_ToolTip_7, logic_uScriptAct_GUIButton_guiStyle_7);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b7fc7931-e830-46d7-920f-8512afffe428", "Set_Bool", Relay_True_9)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_9.True(out logic_uScriptAct_SetBool_Target_9);
         local_Jump_Enabled_System_Boolean = logic_uScriptAct_SetBool_Target_9;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_9.Out;
         
         if ( test_0 == true )
         {
            Relay_In_13();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b7fc7931-e830-46d7-920f-8512afffe428", "Set_Bool", Relay_False_9)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_9.False(out logic_uScriptAct_SetBool_Target_9);
         local_Jump_Enabled_System_Boolean = logic_uScriptAct_SetBool_Target_9;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_9.Out;
         
         if ( test_0 == true )
         {
            Relay_In_13();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("79b90be1-20ff-4ea2-a1a5-a33de01446e1", "Compare_Bool", Relay_In_10)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_10 = local_Jump_Enabled_System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_10.In(logic_uScriptCon_CompareBool_Bool_10);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_10.True;
         bool test_1 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_10.False;
         
         if ( test_0 == true )
         {
            Relay_False_9();
         }
         if ( test_1 == true )
         {
            Relay_True_11();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_11()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0b889e77-7458-44ed-a9a5-74d7dbc5e1fc", "Set_Bool", Relay_True_11)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_11.True(out logic_uScriptAct_SetBool_Target_11);
         local_Jump_Enabled_System_Boolean = logic_uScriptAct_SetBool_Target_11;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_11.Out;
         
         if ( test_0 == true )
         {
            Relay_In_14();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_11()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0b889e77-7458-44ed-a9a5-74d7dbc5e1fc", "Set_Bool", Relay_False_11)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_11.False(out logic_uScriptAct_SetBool_Target_11);
         local_Jump_Enabled_System_Boolean = logic_uScriptAct_SetBool_Target_11;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_11.Out;
         
         if ( test_0 == true )
         {
            Relay_In_14();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_13()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4c70fc70-fb45-4cd7-a9dc-3ff4ee06ea8f", "Set_String", Relay_In_13)) return; 
         {
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
         logic_uScriptAct_SetString_uScriptAct_SetString_13.In(logic_uScriptAct_SetString_Value_13, logic_uScriptAct_SetString_ToUpperCase_13, logic_uScriptAct_SetString_ToLowerCase_13, logic_uScriptAct_SetString_TrimWhitespace_13, out logic_uScriptAct_SetString_Target_13);
         local_Enabled_Text_System_String = logic_uScriptAct_SetString_Target_13;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at Set String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_14()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5c1dc7ed-38e8-4bf1-957f-a1cc606571b8", "Set_String", Relay_In_14)) return; 
         {
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
         logic_uScriptAct_SetString_uScriptAct_SetString_14.In(logic_uScriptAct_SetString_Value_14, logic_uScriptAct_SetString_ToUpperCase_14, logic_uScriptAct_SetString_ToLowerCase_14, logic_uScriptAct_SetString_TrimWhitespace_14, out logic_uScriptAct_SetString_Target_14);
         local_Enabled_Text_System_String = logic_uScriptAct_SetString_Target_14;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at Set String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_AddRelativeForce_16()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d7b0c72e-8998-4eed-bf50-7562bd8ba925", "UnityEngine_Rigidbody", Relay_AddRelativeForce_16)) return; 
         {
            {
            }
         }
         {
            UnityEngine.Rigidbody component;
            component = local_15_UnityEngine_GameObject.GetComponent<UnityEngine.Rigidbody>();
            if ( null != component )
            {
               component.AddRelativeForce(method_Detox_ScriptEditor_Plug_UnityEngine_GameObject_force_16);
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at UnityEngine.Rigidbody.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_20()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("fc9832ad-ed38-4fe6-ac66-90dc2a988fa1", "Print_Text", Relay_ShowLabel_20)) return; 
         {
            {
               logic_uScriptAct_PrintText_Text_20 = local_22_System_String;
               
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_20.ShowLabel(logic_uScriptAct_PrintText_Text_20, logic_uScriptAct_PrintText_FontSize_20, logic_uScriptAct_PrintText_FontStyle_20, logic_uScriptAct_PrintText_FontColor_20, logic_uScriptAct_PrintText_textAnchor_20, logic_uScriptAct_PrintText_EdgePadding_20, logic_uScriptAct_PrintText_time_20);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_20()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("fc9832ad-ed38-4fe6-ac66-90dc2a988fa1", "Print_Text", Relay_HideLabel_20)) return; 
         {
            {
               logic_uScriptAct_PrintText_Text_20 = local_22_System_String;
               
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_20.HideLabel(logic_uScriptAct_PrintText_Text_20, logic_uScriptAct_PrintText_FontSize_20, logic_uScriptAct_PrintText_FontStyle_20, logic_uScriptAct_PrintText_FontColor_20, logic_uScriptAct_PrintText_textAnchor_20, logic_uScriptAct_PrintText_EdgePadding_20, logic_uScriptAct_PrintText_time_20);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_21()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e569fd81-1a7c-4db2-a3ef-fb383d01c00c", "Concatenate", Relay_In_21)) return; 
         {
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)local_24_System_String);
               logic_uScriptAct_Concatenate_A_21 = properties.ToArray();
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add((System.Object)property_position_Detox_ScriptEditor_Parameter_position_25_Get_Refresh());
               logic_uScriptAct_Concatenate_B_21 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_Concatenate_uScriptAct_Concatenate_21.In(logic_uScriptAct_Concatenate_A_21, logic_uScriptAct_Concatenate_B_21, logic_uScriptAct_Concatenate_Separator_21, out logic_uScriptAct_Concatenate_Result_21);
         local_22_System_String = logic_uScriptAct_Concatenate_Result_21;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Concatenate_uScriptAct_Concatenate_21.Out;
         
         if ( test_0 == true )
         {
            Relay_ShowLabel_20();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleUI_Logic.uscript at Concatenate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnUpdate_23()
   {
      if (true == CheckDebugBreak("6aab1e6a-1c27-434a-948a-aca785161dc6", "Global_Update", Relay_OnUpdate_23)) return; 
   }
   
   void Relay_OnLateUpdate_23()
   {
      if (true == CheckDebugBreak("6aab1e6a-1c27-434a-948a-aca785161dc6", "Global_Update", Relay_OnLateUpdate_23)) return; 
      Relay_In_21();
   }
   
   void Relay_OnFixedUpdate_23()
   {
      if (true == CheckDebugBreak("6aab1e6a-1c27-434a-948a-aca785161dc6", "Global_Update", Relay_OnFixedUpdate_23)) return; 
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SimpleUI_Logic.uscript:Enabled Text", local_Enabled_Text_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "05680e4b-8d7a-401c-b1e4-724c13e4386d", local_Enabled_Text_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SimpleUI_Logic.uscript:Jump Enabled", local_Jump_Enabled_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "51c70987-ee23-4e0f-99a2-418be9f9e50b", local_Jump_Enabled_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SimpleUI_Logic.uscript:15", local_15_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "520402e8-fb12-4ff5-a6bf-c762ffed7c8b", local_15_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SimpleUI_Logic.uscript:22", local_22_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "00cc2bd5-6d15-4639-8f4a-86129e7881fe", local_22_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SimpleUI_Logic.uscript:24", local_24_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "9eb2e6cc-d2d0-4960-ae2f-5aab68796ea9", local_24_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "91948ae5-5928-4534-b8e0-887ba3e7d9a6", property_position_Detox_ScriptEditor_Parameter_position_25);
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
