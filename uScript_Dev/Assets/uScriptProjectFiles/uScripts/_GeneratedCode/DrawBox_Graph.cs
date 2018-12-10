//uScript Generated Code - Build 1.0.3109
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class DrawBox_Graph : uScriptLogic
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
   UnityEngine.Texture2D local_BoxTexture_UnityEngine_Texture2D = default(UnityEngine.Texture2D);
   System.Single local_CurrentX_System_Single = (float) 0;
   System.Single local_CurrentY_System_Single = (float) 0;
   System.Single local_FinalHeight_System_Single = (float) 0;
   System.Single local_FinalWidth_System_Single = (float) 0;
   System.Boolean local_MouseDown_System_Boolean = (bool) false;
   UnityEngine.Rect local_SelectionRect_UnityEngine_Rect = new Rect( (float)0, (float)0, (float)0, (float)0 );
   System.Single local_StartX_System_Single = (float) 0;
   System.Single local_StartY_System_Single = (float) 0;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_0 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_0;
   bool logic_uScriptAct_SetBool_Out_0 = true;
   bool logic_uScriptAct_SetBool_SetTrue_0 = true;
   bool logic_uScriptAct_SetBool_SetFalse_0 = true;
   //pointer to script instanced logic node
   uScriptAct_LoadTexture2D logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_3 = new uScriptAct_LoadTexture2D( );
   System.String logic_uScriptAct_LoadTexture2D_name_3 = "selection_box";
   UnityEngine.Texture2D logic_uScriptAct_LoadTexture2D_textureFile_3;
   bool logic_uScriptAct_LoadTexture2D_Out_3 = true;
   //pointer to script instanced logic node
   uScriptAct_GetMousePosition logic_uScriptAct_GetMousePosition_uScriptAct_GetMousePosition_5 = new uScriptAct_GetMousePosition( );
   System.Boolean logic_uScriptAct_GetMousePosition_InvertY_5 = (bool) true;
   UnityEngine.Vector2 logic_uScriptAct_GetMousePosition_positionV2_5;
   System.Single logic_uScriptAct_GetMousePosition_XPosition_5;
   System.Single logic_uScriptAct_GetMousePosition_YPosition_5;
   UnityEngine.Vector3 logic_uScriptAct_GetMousePosition_position_5;
   bool logic_uScriptAct_GetMousePosition_Out_5 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_9 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_9 = "Press left mouse button and drag to draw a box.";
   System.Int32 logic_uScriptAct_PrintText_FontSize_9 = (int) 20;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_9 = UnityEngine.FontStyle.Normal;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_9 = new UnityEngine.Color( (float)1, (float)1, (float)1, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_9 = UnityEngine.TextAnchor.UpperCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_9 = (int) 8;
   System.Single logic_uScriptAct_PrintText_time_9 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_9 = true;
   //pointer to script instanced logic node
   uScriptAct_SubtractFloat logic_uScriptAct_SubtractFloat_uScriptAct_SubtractFloat_11 = new uScriptAct_SubtractFloat( );
   System.Single logic_uScriptAct_SubtractFloat_A_11 = (float) 0;
   System.Single logic_uScriptAct_SubtractFloat_B_11 = (float) 0;
   System.Single logic_uScriptAct_SubtractFloat_FloatResult_11;
   System.Int32 logic_uScriptAct_SubtractFloat_IntResult_11;
   bool logic_uScriptAct_SubtractFloat_Out_11 = true;
   //pointer to script instanced logic node
   uScriptAct_GetMousePosition logic_uScriptAct_GetMousePosition_uScriptAct_GetMousePosition_12 = new uScriptAct_GetMousePosition( );
   System.Boolean logic_uScriptAct_GetMousePosition_InvertY_12 = (bool) true;
   UnityEngine.Vector2 logic_uScriptAct_GetMousePosition_positionV2_12;
   System.Single logic_uScriptAct_GetMousePosition_XPosition_12;
   System.Single logic_uScriptAct_GetMousePosition_YPosition_12;
   UnityEngine.Vector3 logic_uScriptAct_GetMousePosition_position_12;
   bool logic_uScriptAct_GetMousePosition_Out_12 = true;
   //pointer to script instanced logic node
   uScriptAct_SubtractFloat logic_uScriptAct_SubtractFloat_uScriptAct_SubtractFloat_17 = new uScriptAct_SubtractFloat( );
   System.Single logic_uScriptAct_SubtractFloat_A_17 = (float) 0;
   System.Single logic_uScriptAct_SubtractFloat_B_17 = (float) 0;
   System.Single logic_uScriptAct_SubtractFloat_FloatResult_17;
   System.Int32 logic_uScriptAct_SubtractFloat_IntResult_17;
   bool logic_uScriptAct_SubtractFloat_Out_17 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_20 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_20 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_20 = true;
   bool logic_uScriptCon_CompareBool_False_20 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_21 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_21 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_21 = true;
   bool logic_uScriptCon_CompareBool_False_21 = true;
   //pointer to script instanced logic node
   uScriptAct_GetMousePosition logic_uScriptAct_GetMousePosition_uScriptAct_GetMousePosition_23 = new uScriptAct_GetMousePosition( );
   System.Boolean logic_uScriptAct_GetMousePosition_InvertY_23 = (bool) true;
   UnityEngine.Vector2 logic_uScriptAct_GetMousePosition_positionV2_23;
   System.Single logic_uScriptAct_GetMousePosition_XPosition_23;
   System.Single logic_uScriptAct_GetMousePosition_YPosition_23;
   UnityEngine.Vector3 logic_uScriptAct_GetMousePosition_position_23;
   bool logic_uScriptAct_GetMousePosition_Out_23 = true;
   //pointer to script instanced logic node
   uScriptAct_GUITexture logic_uScriptAct_GUITexture_uScriptAct_GUITexture_27 = new uScriptAct_GUITexture( );
   UnityEngine.Rect logic_uScriptAct_GUITexture_Position_27 = new Rect( );
   UnityEngine.Texture2D logic_uScriptAct_GUITexture_Texture_27 = default(UnityEngine.Texture2D);
   UnityEngine.ScaleMode logic_uScriptAct_GUITexture_scaleMode_27 = UnityEngine.ScaleMode.StretchToFill;
   System.Boolean logic_uScriptAct_GUITexture_alphaBlend_27 = (bool) true;
   System.Single logic_uScriptAct_GUITexture_aspect_27 = (float) 1;
   bool logic_uScriptAct_GUITexture_Out_27 = true;
   //pointer to script instanced logic node
   uScriptAct_SetComponentsRect logic_uScriptAct_SetComponentsRect_uScriptAct_SetComponentsRect_32 = new uScriptAct_SetComponentsRect( );
   System.Single logic_uScriptAct_SetComponentsRect_Left_32 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsRect_Top_32 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsRect_Width_32 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsRect_Height_32 = (float) 0;
   UnityEngine.Rect logic_uScriptAct_SetComponentsRect_OutputRect_32;
   bool logic_uScriptAct_SetComponentsRect_Out_32 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_36 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_36 = UnityEngine.KeyCode.Mouse0;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_36 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_36 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_36 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_2 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_6 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_8 = default(UnityEngine.GameObject);
   System.Boolean event_UnityEngine_GameObject_GUIChanged_19 = (bool) false;
   System.String event_UnityEngine_GameObject_FocusedControl_19 = "";
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_19 = default(UnityEngine.GameObject);
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
   }
   
   void SyncEventListeners( )
   {
      if ( null == event_UnityEngine_GameObject_Instance_2 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_2 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_2 )
         {
            {
               uScript_Global component = event_UnityEngine_GameObject_Instance_2.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_2.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_2;
                  component.uScriptLateStart += Instance_uScriptLateStart_2;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_6 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_6 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_6 )
         {
            {
               uScript_Update component = event_UnityEngine_GameObject_Instance_6.GetComponent<uScript_Update>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_6.AddComponent<uScript_Update>();
               }
               if ( null != component )
               {
                  component.OnUpdate += Instance_OnUpdate_6;
                  component.OnLateUpdate += Instance_OnLateUpdate_6;
                  component.OnFixedUpdate += Instance_OnFixedUpdate_6;
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
      if ( null == event_UnityEngine_GameObject_Instance_19 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_19 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_19 )
         {
            {
               if ( null == thisScriptsOnGuiListener )
               {
                  //OnGUI need unique listeners so calls like GUI.depth will work across uScripts
                  thisScriptsOnGuiListener = event_UnityEngine_GameObject_Instance_19.AddComponent<uScript_GUI>();
               }
               uScript_GUI component = thisScriptsOnGuiListener;
               if ( null != component )
               {
                  component.OnGui += Instance_OnGui_19;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != event_UnityEngine_GameObject_Instance_2 )
      {
         {
            uScript_Global component = event_UnityEngine_GameObject_Instance_2.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_2;
               component.uScriptLateStart -= Instance_uScriptLateStart_2;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_6 )
      {
         {
            uScript_Update component = event_UnityEngine_GameObject_Instance_6.GetComponent<uScript_Update>();
            if ( null != component )
            {
               component.OnUpdate -= Instance_OnUpdate_6;
               component.OnLateUpdate -= Instance_OnLateUpdate_6;
               component.OnFixedUpdate -= Instance_OnFixedUpdate_6;
            }
         }
      }
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
      if ( null != event_UnityEngine_GameObject_Instance_19 )
      {
         {
            if ( null == thisScriptsOnGuiListener )
            {
               //OnGUI need unique listeners so calls like GUI.depth will work across uScripts
               thisScriptsOnGuiListener = event_UnityEngine_GameObject_Instance_19.AddComponent<uScript_GUI>();
            }
            uScript_GUI component = thisScriptsOnGuiListener;
            if ( null != component )
            {
               component.OnGui -= Instance_OnGui_19;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_SetBool_uScriptAct_SetBool_0.SetParent(g);
      logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_3.SetParent(g);
      logic_uScriptAct_GetMousePosition_uScriptAct_GetMousePosition_5.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_9.SetParent(g);
      logic_uScriptAct_SubtractFloat_uScriptAct_SubtractFloat_11.SetParent(g);
      logic_uScriptAct_GetMousePosition_uScriptAct_GetMousePosition_12.SetParent(g);
      logic_uScriptAct_SubtractFloat_uScriptAct_SubtractFloat_17.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_20.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_21.SetParent(g);
      logic_uScriptAct_GetMousePosition_uScriptAct_GetMousePosition_23.SetParent(g);
      logic_uScriptAct_GUITexture_uScriptAct_GUITexture_27.SetParent(g);
      logic_uScriptAct_SetComponentsRect_uScriptAct_SetComponentsRect_32.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_36.SetParent(g);
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
      
   }
   
   public void OnDestroy()
   {
   }
   
   public void OnGUI()
   {
      logic_uScriptAct_PrintText_uScriptAct_PrintText_9.OnGUI( );
   }
   
   void Instance_uScriptStart_2(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_2( );
   }
   
   void Instance_uScriptLateStart_2(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptLateStart_2( );
   }
   
   void Instance_OnUpdate_6(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUpdate_6( );
   }
   
   void Instance_OnLateUpdate_6(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnLateUpdate_6( );
   }
   
   void Instance_OnFixedUpdate_6(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnFixedUpdate_6( );
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
   
   void Instance_OnGui_19(object o, uScript_GUI.GUIEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GUIChanged_19 = e.GUIChanged;
      event_UnityEngine_GameObject_FocusedControl_19 = e.FocusedControl;
      //relay event to nodes
      Relay_OnGui_19( );
   }
   
   void Relay_True_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("019bca16-43e5-41df-8e8f-b2371848896a", "Set_Bool", Relay_True_0)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_0.True(out logic_uScriptAct_SetBool_Target_0);
         local_MouseDown_System_Boolean = logic_uScriptAct_SetBool_Target_0;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DrawBox_Graph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("019bca16-43e5-41df-8e8f-b2371848896a", "Set_Bool", Relay_False_0)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_0.False(out logic_uScriptAct_SetBool_Target_0);
         local_MouseDown_System_Boolean = logic_uScriptAct_SetBool_Target_0;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DrawBox_Graph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_uScriptStart_2()
   {
      if (true == CheckDebugBreak("90e44dca-6335-4d15-8a3e-2047110e18ec", "uScript_Events", Relay_uScriptStart_2)) return; 
      Relay_In_3();
      Relay_ShowLabel_9();
   }
   
   void Relay_uScriptLateStart_2()
   {
      if (true == CheckDebugBreak("90e44dca-6335-4d15-8a3e-2047110e18ec", "uScript_Events", Relay_uScriptLateStart_2)) return; 
   }
   
   void Relay_In_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1e6c07c1-6b22-4a1a-9dd4-0c88dc522401", "Load_Texture2D", Relay_In_3)) return; 
         {
            {
            }
            {
            }
         }
         logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_3.In(logic_uScriptAct_LoadTexture2D_name_3, out logic_uScriptAct_LoadTexture2D_textureFile_3);
         local_BoxTexture_UnityEngine_Texture2D = logic_uScriptAct_LoadTexture2D_textureFile_3;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DrawBox_Graph.uscript at Load Texture2D.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d3219c62-f838-4995-bd0e-5801905dab14", "Get_Mouse_Position", Relay_In_5)) return; 
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
         logic_uScriptAct_GetMousePosition_uScriptAct_GetMousePosition_5.In(logic_uScriptAct_GetMousePosition_InvertY_5, out logic_uScriptAct_GetMousePosition_positionV2_5, out logic_uScriptAct_GetMousePosition_XPosition_5, out logic_uScriptAct_GetMousePosition_YPosition_5, out logic_uScriptAct_GetMousePosition_position_5);
         local_StartX_System_Single = logic_uScriptAct_GetMousePosition_XPosition_5;
         local_StartY_System_Single = logic_uScriptAct_GetMousePosition_YPosition_5;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DrawBox_Graph.uscript at Get Mouse Position.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnUpdate_6()
   {
      if (true == CheckDebugBreak("018ba388-0302-4557-996c-c51274262db1", "Global_Update", Relay_OnUpdate_6)) return; 
      Relay_In_21();
      Relay_In_23();
   }
   
   void Relay_OnLateUpdate_6()
   {
      if (true == CheckDebugBreak("018ba388-0302-4557-996c-c51274262db1", "Global_Update", Relay_OnLateUpdate_6)) return; 
   }
   
   void Relay_OnFixedUpdate_6()
   {
      if (true == CheckDebugBreak("018ba388-0302-4557-996c-c51274262db1", "Global_Update", Relay_OnFixedUpdate_6)) return; 
   }
   
   void Relay_KeyEvent_8()
   {
      if (true == CheckDebugBreak("c83ba475-16dd-4fde-a54d-a8d47eda80f6", "Input_Events", Relay_KeyEvent_8)) return; 
      Relay_In_36();
   }
   
   void Relay_ShowLabel_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f9c85cd5-914e-4e05-bcbf-713fdb1ed948", "Print_Text", Relay_ShowLabel_9)) return; 
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
            {
            }
         }
         logic_uScriptAct_PrintText_uScriptAct_PrintText_9.ShowLabel(logic_uScriptAct_PrintText_Text_9, logic_uScriptAct_PrintText_FontSize_9, logic_uScriptAct_PrintText_FontStyle_9, logic_uScriptAct_PrintText_FontColor_9, logic_uScriptAct_PrintText_textAnchor_9, logic_uScriptAct_PrintText_EdgePadding_9, logic_uScriptAct_PrintText_time_9);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DrawBox_Graph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f9c85cd5-914e-4e05-bcbf-713fdb1ed948", "Print_Text", Relay_HideLabel_9)) return; 
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
            {
            }
         }
         logic_uScriptAct_PrintText_uScriptAct_PrintText_9.HideLabel(logic_uScriptAct_PrintText_Text_9, logic_uScriptAct_PrintText_FontSize_9, logic_uScriptAct_PrintText_FontStyle_9, logic_uScriptAct_PrintText_FontColor_9, logic_uScriptAct_PrintText_textAnchor_9, logic_uScriptAct_PrintText_EdgePadding_9, logic_uScriptAct_PrintText_time_9);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DrawBox_Graph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_11()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a03c4459-5485-492a-a44a-12534486d7de", "Subtract_Float", Relay_In_11)) return; 
         {
            {
               logic_uScriptAct_SubtractFloat_A_11 = local_CurrentY_System_Single;
               
            }
            {
               logic_uScriptAct_SubtractFloat_B_11 = local_StartY_System_Single;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SubtractFloat_uScriptAct_SubtractFloat_11.In(logic_uScriptAct_SubtractFloat_A_11, logic_uScriptAct_SubtractFloat_B_11, out logic_uScriptAct_SubtractFloat_FloatResult_11, out logic_uScriptAct_SubtractFloat_IntResult_11);
         local_FinalHeight_System_Single = logic_uScriptAct_SubtractFloat_FloatResult_11;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SubtractFloat_uScriptAct_SubtractFloat_11.Out;
         
         if ( test_0 == true )
         {
            Relay_In_32();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DrawBox_Graph.uscript at Subtract Float.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_12()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ba116538-9c52-4b1f-9150-24ee03ef56a8", "Get_Mouse_Position", Relay_In_12)) return; 
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
         logic_uScriptAct_GetMousePosition_uScriptAct_GetMousePosition_12.In(logic_uScriptAct_GetMousePosition_InvertY_12, out logic_uScriptAct_GetMousePosition_positionV2_12, out logic_uScriptAct_GetMousePosition_XPosition_12, out logic_uScriptAct_GetMousePosition_YPosition_12, out logic_uScriptAct_GetMousePosition_position_12);
         local_StartX_System_Single = logic_uScriptAct_GetMousePosition_XPosition_12;
         local_StartY_System_Single = logic_uScriptAct_GetMousePosition_YPosition_12;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DrawBox_Graph.uscript at Get Mouse Position.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_17()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3f20bda3-60f6-4e9b-b9bb-45a7039942c2", "Subtract_Float", Relay_In_17)) return; 
         {
            {
               logic_uScriptAct_SubtractFloat_A_17 = local_CurrentX_System_Single;
               
            }
            {
               logic_uScriptAct_SubtractFloat_B_17 = local_StartX_System_Single;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SubtractFloat_uScriptAct_SubtractFloat_17.In(logic_uScriptAct_SubtractFloat_A_17, logic_uScriptAct_SubtractFloat_B_17, out logic_uScriptAct_SubtractFloat_FloatResult_17, out logic_uScriptAct_SubtractFloat_IntResult_17);
         local_FinalWidth_System_Single = logic_uScriptAct_SubtractFloat_FloatResult_17;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SubtractFloat_uScriptAct_SubtractFloat_17.Out;
         
         if ( test_0 == true )
         {
            Relay_In_11();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DrawBox_Graph.uscript at Subtract Float.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnGui_19()
   {
      if (true == CheckDebugBreak("3577864b-ccfb-45dd-8e69-b630fe939ee0", "GUI_Events", Relay_OnGui_19)) return; 
      Relay_In_20();
   }
   
   void Relay_In_20()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c7d602b7-c07a-4e26-8dea-41de082f59ea", "Compare_Bool", Relay_In_20)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_20 = local_MouseDown_System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_20.In(logic_uScriptCon_CompareBool_Bool_20);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_20.True;
         
         if ( test_0 == true )
         {
            Relay_In_27();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DrawBox_Graph.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_21()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("48c25290-78fa-44d3-9a00-fdc27a0da8fe", "Compare_Bool", Relay_In_21)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_21 = local_MouseDown_System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_21.In(logic_uScriptCon_CompareBool_Bool_21);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_21.False;
         
         if ( test_0 == true )
         {
            Relay_In_12();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DrawBox_Graph.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_23()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f48d3a87-8cee-4240-b7be-7822c251b23d", "Get_Mouse_Position", Relay_In_23)) return; 
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
         logic_uScriptAct_GetMousePosition_uScriptAct_GetMousePosition_23.In(logic_uScriptAct_GetMousePosition_InvertY_23, out logic_uScriptAct_GetMousePosition_positionV2_23, out logic_uScriptAct_GetMousePosition_XPosition_23, out logic_uScriptAct_GetMousePosition_YPosition_23, out logic_uScriptAct_GetMousePosition_position_23);
         local_CurrentX_System_Single = logic_uScriptAct_GetMousePosition_XPosition_23;
         local_CurrentY_System_Single = logic_uScriptAct_GetMousePosition_YPosition_23;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetMousePosition_uScriptAct_GetMousePosition_23.Out;
         
         if ( test_0 == true )
         {
            Relay_In_17();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DrawBox_Graph.uscript at Get Mouse Position.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_27()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b8275064-60e2-49f0-8a3d-0b2bc8c60464", "GUI_Texture", Relay_In_27)) return; 
         {
            {
               logic_uScriptAct_GUITexture_Position_27 = local_SelectionRect_UnityEngine_Rect;
               
            }
            {
               logic_uScriptAct_GUITexture_Texture_27 = local_BoxTexture_UnityEngine_Texture2D;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_GUITexture_uScriptAct_GUITexture_27.In(logic_uScriptAct_GUITexture_Position_27, logic_uScriptAct_GUITexture_Texture_27, logic_uScriptAct_GUITexture_scaleMode_27, logic_uScriptAct_GUITexture_alphaBlend_27, logic_uScriptAct_GUITexture_aspect_27);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DrawBox_Graph.uscript at GUI Texture.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_32()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6d3e5178-07ca-48e2-930f-418a91f6176e", "Set_Components__Rect_", Relay_In_32)) return; 
         {
            {
               logic_uScriptAct_SetComponentsRect_Left_32 = local_StartX_System_Single;
               
            }
            {
               logic_uScriptAct_SetComponentsRect_Top_32 = local_StartY_System_Single;
               
            }
            {
               logic_uScriptAct_SetComponentsRect_Width_32 = local_FinalWidth_System_Single;
               
            }
            {
               logic_uScriptAct_SetComponentsRect_Height_32 = local_FinalHeight_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_SetComponentsRect_uScriptAct_SetComponentsRect_32.In(logic_uScriptAct_SetComponentsRect_Left_32, logic_uScriptAct_SetComponentsRect_Top_32, logic_uScriptAct_SetComponentsRect_Width_32, logic_uScriptAct_SetComponentsRect_Height_32, out logic_uScriptAct_SetComponentsRect_OutputRect_32);
         local_SelectionRect_UnityEngine_Rect = logic_uScriptAct_SetComponentsRect_OutputRect_32;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DrawBox_Graph.uscript at Set Components (Rect).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_36()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("aeb0bb5e-9694-47d5-9a4a-67e891700786", "Input_Events_Filter", Relay_In_36)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_36.In(logic_uScriptAct_OnInputEventFilter_KeyCode_36);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_36.KeyDown;
         bool test_1 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_36.KeyUp;
         
         if ( test_0 == true )
         {
            Relay_True_0();
            Relay_In_5();
         }
         if ( test_1 == true )
         {
            Relay_False_0();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DrawBox_Graph.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "DrawBox_Graph.uscript:CurrentY", local_CurrentY_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d4dc4daf-5925-4fb4-ac98-9c62c05b46c0", local_CurrentY_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "DrawBox_Graph.uscript:FinalHeight", local_FinalHeight_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c9d3328a-6222-4a19-af5f-655cb92e1b33", local_FinalHeight_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "DrawBox_Graph.uscript:BoxTexture", local_BoxTexture_UnityEngine_Texture2D);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "870e3f93-22eb-4814-b5ff-74f40d1887ed", local_BoxTexture_UnityEngine_Texture2D);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "DrawBox_Graph.uscript:StartY", local_StartY_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "e8b7c4c0-6401-464d-a6b5-90f2e7f91db4", local_StartY_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "DrawBox_Graph.uscript:StartX", local_StartX_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "4c5522e3-1e66-43ae-89d3-44c448855c3b", local_StartX_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "DrawBox_Graph.uscript:MouseDown", local_MouseDown_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "4dfd1cb7-c23a-41cf-b084-10b9283296b1", local_MouseDown_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "DrawBox_Graph.uscript:CurrentX", local_CurrentX_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "bc0a8cbc-d3cf-4e12-b273-62c394810975", local_CurrentX_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "DrawBox_Graph.uscript:FinalWidth", local_FinalWidth_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "52fd11b5-74b7-4586-abf0-723fec504f09", local_FinalWidth_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "DrawBox_Graph.uscript:SelectionRect", local_SelectionRect_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c8ca0047-0c66-47e5-bcf7-b824f14dbdde", local_SelectionRect_UnityEngine_Rect);
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
