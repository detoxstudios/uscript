//uScript Generated Code - Build 1.0.3109
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class AdvancedUI_Credits : uScriptLogic
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
   System.String local_16_System_String = "";
   System.String local_17_System_String = "";
   System.Single local_22_System_Single = (float) 0;
   System.Single local_24_System_Single = (float) 0;
   System.Single local_26_System_Single = (float) 0;
   System.Single local_27_System_Single = (float) 0;
   System.Single local_30_System_Single = (float) 0;
   System.Single local_33_System_Single = (float) 0;
   UnityEngine.Rect local_7_UnityEngine_Rect = new Rect( (float)40, (float)280, (float)520, (float)80 );
   System.String local_9_System_String = "Back To Main Menu";
   UnityEngine.Rect local_Filtered_Rect_UnityEngine_Rect = new Rect( (float)0, (float)0, (float)0, (float)0 );
   UnityEngine.Rect local_Target_Rect_UnityEngine_Rect = new Rect( (float)0, (float)0, (float)0, (float)0 );
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_GUIBeginGroup logic_uScriptAct_GUIBeginGroup_uScriptAct_GUIBeginGroup_1 = new uScriptAct_GUIBeginGroup( );
   UnityEngine.Rect logic_uScriptAct_GUIBeginGroup_Position_1 = new Rect( );
   System.String logic_uScriptAct_GUIBeginGroup_Text_1 = "";
   UnityEngine.Texture2D logic_uScriptAct_GUIBeginGroup_Texture_1 = default(UnityEngine.Texture2D);
   System.String logic_uScriptAct_GUIBeginGroup_ToolTip_1 = "";
   System.String logic_uScriptAct_GUIBeginGroup_guiStyle_1 = "";
   bool logic_uScriptAct_GUIBeginGroup_Out_1 = true;
   //pointer to script instanced logic node
   uScriptAct_CreateRelativeRectScreen logic_uScriptAct_CreateRelativeRectScreen_uScriptAct_CreateRelativeRectScreen_3 = new uScriptAct_CreateRelativeRectScreen( );
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_RectWidth_3 = (int) 600;
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_RectHeight_3 = (int) 400;
   uScriptAct_CreateRelativeRectScreen.Position logic_uScriptAct_CreateRelativeRectScreen_RectPosition_3 = uScriptAct_CreateRelativeRectScreen.Position.MiddleCenter;
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_xOffset_3 = (int) 0;
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_yOffset_3 = (int) 0;
   UnityEngine.Rect logic_uScriptAct_CreateRelativeRectScreen_OutputRect_3;
   bool logic_uScriptAct_CreateRelativeRectScreen_Out_3 = true;
   //pointer to script instanced logic node
   uScriptAct_GUIBox logic_uScriptAct_GUIBox_uScriptAct_GUIBox_5 = new uScriptAct_GUIBox( );
   System.String logic_uScriptAct_GUIBox_Text_5 = "Credits";
   UnityEngine.Rect logic_uScriptAct_GUIBox_Position_5 = new Rect( (float)0, (float)0, (float)600, (float)400 );
   UnityEngine.Texture2D logic_uScriptAct_GUIBox_Texture_5 = default(UnityEngine.Texture2D);
   System.String logic_uScriptAct_GUIBox_ToolTip_5 = "";
   System.String logic_uScriptAct_GUIBox_guiStyle_5 = "";
   bool logic_uScriptAct_GUIBox_Out_5 = true;
   //pointer to script instanced logic node
   uScriptAct_GUIButton logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6 = new uScriptAct_GUIButton( );
   System.String logic_uScriptAct_GUIButton_Text_6 = "";
   System.Int32 logic_uScriptAct_GUIButton_identifier_6 = (int) 0;
   UnityEngine.Rect logic_uScriptAct_GUIButton_Position_6 = new Rect( );
   UnityEngine.Texture2D logic_uScriptAct_GUIButton_Texture_6 = default(UnityEngine.Texture2D);
   System.String logic_uScriptAct_GUIButton_ToolTip_6 = "";
   System.String logic_uScriptAct_GUIButton_guiStyle_6 = "";
   bool logic_uScriptAct_GUIButton_Out_6 = true;
   //pointer to script instanced logic node
   uScriptAct_GUIEndGroup logic_uScriptAct_GUIEndGroup_uScriptAct_GUIEndGroup_8 = new uScriptAct_GUIEndGroup( );
   bool logic_uScriptAct_GUIEndGroup_Out_8 = true;
   //pointer to script instanced logic node
   uScriptAct_FilterRect logic_uScriptAct_FilterRect_uScriptAct_FilterRect_12 = new uScriptAct_FilterRect( );
   UnityEngine.Rect logic_uScriptAct_FilterRect_Target_12 = new Rect( );
   System.Single logic_uScriptAct_FilterRect_FilterConstant_12 = (float) 0.05;
   UnityEngine.Rect logic_uScriptAct_FilterRect_Value_12;
   bool logic_uScriptAct_FilterRect_Out_12 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_18 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_18 = "";
   System.String logic_uScriptCon_CompareString_B_18 = "Credits";
   bool logic_uScriptCon_CompareString_Same_18 = true;
   bool logic_uScriptCon_CompareString_Different_18 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_19 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_19 = "";
   System.String logic_uScriptCon_CompareString_B_19 = "UI Button Clicked";
   bool logic_uScriptCon_CompareString_Same_19 = true;
   bool logic_uScriptCon_CompareString_Different_19 = true;
   //pointer to script instanced logic node
   uScriptAct_CreateRelativeRectScreen logic_uScriptAct_CreateRelativeRectScreen_uScriptAct_CreateRelativeRectScreen_20 = new uScriptAct_CreateRelativeRectScreen( );
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_RectWidth_20 = (int) 600;
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_RectHeight_20 = (int) 400;
   uScriptAct_CreateRelativeRectScreen.Position logic_uScriptAct_CreateRelativeRectScreen_RectPosition_20 = uScriptAct_CreateRelativeRectScreen.Position.MiddleCenter;
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_xOffset_20 = (int) 0;
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_yOffset_20 = (int) 0;
   UnityEngine.Rect logic_uScriptAct_CreateRelativeRectScreen_OutputRect_20;
   bool logic_uScriptAct_CreateRelativeRectScreen_Out_20 = true;
   //pointer to script instanced logic node
   uScriptAct_GetComponentsRect logic_uScriptAct_GetComponentsRect_uScriptAct_GetComponentsRect_23 = new uScriptAct_GetComponentsRect( );
   UnityEngine.Rect logic_uScriptAct_GetComponentsRect_InputRect_23 = new Rect( );
   System.Single logic_uScriptAct_GetComponentsRect_Left_23;
   System.Single logic_uScriptAct_GetComponentsRect_Top_23;
   System.Single logic_uScriptAct_GetComponentsRect_Width_23;
   System.Single logic_uScriptAct_GetComponentsRect_Height_23;
   bool logic_uScriptAct_GetComponentsRect_Out_23 = true;
   //pointer to script instanced logic node
   uScriptAct_SetComponentsRect logic_uScriptAct_SetComponentsRect_uScriptAct_SetComponentsRect_25 = new uScriptAct_SetComponentsRect( );
   System.Single logic_uScriptAct_SetComponentsRect_Left_25 = (float) 2000;
   System.Single logic_uScriptAct_SetComponentsRect_Top_25 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsRect_Width_25 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsRect_Height_25 = (float) 0;
   UnityEngine.Rect logic_uScriptAct_SetComponentsRect_OutputRect_25;
   bool logic_uScriptAct_SetComponentsRect_Out_25 = true;
   //pointer to script instanced logic node
   uScriptAct_GetComponentsRect logic_uScriptAct_GetComponentsRect_uScriptAct_GetComponentsRect_28 = new uScriptAct_GetComponentsRect( );
   UnityEngine.Rect logic_uScriptAct_GetComponentsRect_InputRect_28 = new Rect( );
   System.Single logic_uScriptAct_GetComponentsRect_Left_28;
   System.Single logic_uScriptAct_GetComponentsRect_Top_28;
   System.Single logic_uScriptAct_GetComponentsRect_Width_28;
   System.Single logic_uScriptAct_GetComponentsRect_Height_28;
   bool logic_uScriptAct_GetComponentsRect_Out_28 = true;
   //pointer to script instanced logic node
   uScriptAct_SendCustomEventString logic_uScriptAct_SendCustomEventString_uScriptAct_SendCustomEventString_31 = new uScriptAct_SendCustomEventString( );
   System.String logic_uScriptAct_SendCustomEventString_EventName_31 = "UI Button Clicked";
   System.String logic_uScriptAct_SendCustomEventString_EventValue_31 = "";
   uScriptCustomEvent.SendGroup logic_uScriptAct_SendCustomEventString_sendGroup_31 = uScriptCustomEvent.SendGroup.All;
   UnityEngine.GameObject logic_uScriptAct_SendCustomEventString_EventSender_31 = default(UnityEngine.GameObject);
   bool logic_uScriptAct_SendCustomEventString_Out_31 = true;
   //pointer to script instanced logic node
   uScriptAct_SetComponentsRect logic_uScriptAct_SetComponentsRect_uScriptAct_SetComponentsRect_32 = new uScriptAct_SetComponentsRect( );
   System.Single logic_uScriptAct_SetComponentsRect_Left_32 = (float) 2000;
   System.Single logic_uScriptAct_SetComponentsRect_Top_32 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsRect_Width_32 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsRect_Height_32 = (float) 0;
   UnityEngine.Rect logic_uScriptAct_SetComponentsRect_OutputRect_32;
   bool logic_uScriptAct_SetComponentsRect_Out_32 = true;
   //pointer to script instanced logic node
   uScriptAct_GUILabel logic_uScriptAct_GUILabel_uScriptAct_GUILabel_34 = new uScriptAct_GUILabel( );
   System.String logic_uScriptAct_GUILabel_Text_34 = "Special Thanks to Detox Studios for the uScript Visual Scripting Tool for Unity!";
   UnityEngine.Rect logic_uScriptAct_GUILabel_Position_34 = new Rect( (float)40, (float)40, (float)520, (float)80 );
   UnityEngine.Texture logic_uScriptAct_GUILabel_Texture_34 = default(UnityEngine.Texture);
   System.String logic_uScriptAct_GUILabel_ToolTip_34 = "";
   System.String logic_uScriptAct_GUILabel_guiStyle_34 = "";
   bool logic_uScriptAct_GUILabel_Out_34 = true;
   
   //event nodes
   System.Boolean event_UnityEngine_GameObject_GUIChanged_0 = (bool) false;
   System.String event_UnityEngine_GameObject_FocusedControl_0 = "";
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_0 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_2 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_11 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_15 = default(UnityEngine.GameObject);
   System.String event_UnityEngine_GameObject_EventName_15 = "";
   System.String event_UnityEngine_GameObject_EventData_15 = "";
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_15 = default(UnityEngine.GameObject);
   
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
      if ( null == event_UnityEngine_GameObject_Instance_11 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_11 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_11 )
         {
            {
               uScript_Update component = event_UnityEngine_GameObject_Instance_11.GetComponent<uScript_Update>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_11.AddComponent<uScript_Update>();
               }
               if ( null != component )
               {
                  component.OnUpdate += Instance_OnUpdate_11;
                  component.OnLateUpdate += Instance_OnLateUpdate_11;
                  component.OnFixedUpdate += Instance_OnFixedUpdate_11;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_15 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_15 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_15 )
         {
            {
               uScript_CustomEventString component = event_UnityEngine_GameObject_Instance_15.GetComponent<uScript_CustomEventString>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_15.AddComponent<uScript_CustomEventString>();
               }
               if ( null != component )
               {
                  component.OnCustomEventString += Instance_OnCustomEventString_15;
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
      if ( null != event_UnityEngine_GameObject_Instance_11 )
      {
         {
            uScript_Update component = event_UnityEngine_GameObject_Instance_11.GetComponent<uScript_Update>();
            if ( null != component )
            {
               component.OnUpdate -= Instance_OnUpdate_11;
               component.OnLateUpdate -= Instance_OnLateUpdate_11;
               component.OnFixedUpdate -= Instance_OnFixedUpdate_11;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_15 )
      {
         {
            uScript_CustomEventString component = event_UnityEngine_GameObject_Instance_15.GetComponent<uScript_CustomEventString>();
            if ( null != component )
            {
               component.OnCustomEventString -= Instance_OnCustomEventString_15;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_GUIBeginGroup_uScriptAct_GUIBeginGroup_1.SetParent(g);
      logic_uScriptAct_CreateRelativeRectScreen_uScriptAct_CreateRelativeRectScreen_3.SetParent(g);
      logic_uScriptAct_GUIBox_uScriptAct_GUIBox_5.SetParent(g);
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6.SetParent(g);
      logic_uScriptAct_GUIEndGroup_uScriptAct_GUIEndGroup_8.SetParent(g);
      logic_uScriptAct_FilterRect_uScriptAct_FilterRect_12.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_18.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_19.SetParent(g);
      logic_uScriptAct_CreateRelativeRectScreen_uScriptAct_CreateRelativeRectScreen_20.SetParent(g);
      logic_uScriptAct_GetComponentsRect_uScriptAct_GetComponentsRect_23.SetParent(g);
      logic_uScriptAct_SetComponentsRect_uScriptAct_SetComponentsRect_25.SetParent(g);
      logic_uScriptAct_GetComponentsRect_uScriptAct_GetComponentsRect_28.SetParent(g);
      logic_uScriptAct_SendCustomEventString_uScriptAct_SendCustomEventString_31.SetParent(g);
      logic_uScriptAct_SetComponentsRect_uScriptAct_SetComponentsRect_32.SetParent(g);
      logic_uScriptAct_GUILabel_uScriptAct_GUILabel_34.SetParent(g);
   }
   public void Awake()
   {
      
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6.OnButtonDown += uScriptAct_GUIButton_OnButtonDown_6;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6.OnButtonHeld += uScriptAct_GUIButton_OnButtonHeld_6;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6.OnButtonUp += uScriptAct_GUIButton_OnButtonUp_6;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6.OnButtonClicked += uScriptAct_GUIButton_OnButtonClicked_6;
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
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6.OnButtonDown -= uScriptAct_GUIButton_OnButtonDown_6;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6.OnButtonHeld -= uScriptAct_GUIButton_OnButtonHeld_6;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6.OnButtonUp -= uScriptAct_GUIButton_OnButtonUp_6;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6.OnButtonClicked -= uScriptAct_GUIButton_OnButtonClicked_6;
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
   
   void Instance_OnUpdate_11(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUpdate_11( );
   }
   
   void Instance_OnLateUpdate_11(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnLateUpdate_11( );
   }
   
   void Instance_OnFixedUpdate_11(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnFixedUpdate_11( );
   }
   
   void Instance_OnCustomEventString_15(object o, uScript_CustomEventString.CustomEventStringArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_15 = e.Sender;
      event_UnityEngine_GameObject_EventName_15 = e.EventName;
      event_UnityEngine_GameObject_EventData_15 = e.EventData;
      //relay event to nodes
      Relay_OnCustomEventString_15( );
   }
   
   void uScriptAct_GUIButton_OnButtonDown_6(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonDown_6( );
   }
   
   void uScriptAct_GUIButton_OnButtonHeld_6(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonHeld_6( );
   }
   
   void uScriptAct_GUIButton_OnButtonUp_6(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonUp_6( );
   }
   
   void uScriptAct_GUIButton_OnButtonClicked_6(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonClicked_6( );
   }
   
   void Relay_OnGui_0()
   {
      if (true == CheckDebugBreak("147aaa7d-d122-40e8-abe2-80f201356edf", "GUI_Events", Relay_OnGui_0)) return; 
      Relay_In_1();
   }
   
   void Relay_In_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5264832f-c586-486a-96c3-3a4bbd9bfc20", "GUI_Begin_Group", Relay_In_1)) return; 
         {
            {
               logic_uScriptAct_GUIBeginGroup_Position_1 = local_Filtered_Rect_UnityEngine_Rect;
               
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
         logic_uScriptAct_GUIBeginGroup_uScriptAct_GUIBeginGroup_1.In(logic_uScriptAct_GUIBeginGroup_Position_1, logic_uScriptAct_GUIBeginGroup_Text_1, logic_uScriptAct_GUIBeginGroup_Texture_1, logic_uScriptAct_GUIBeginGroup_ToolTip_1, logic_uScriptAct_GUIBeginGroup_guiStyle_1);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUIBeginGroup_uScriptAct_GUIBeginGroup_1.Out;
         
         if ( test_0 == true )
         {
            Relay_In_5();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_Credits.uscript at GUI Begin Group.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_uScriptStart_2()
   {
      if (true == CheckDebugBreak("142bb7d2-9a66-46e4-b88b-305ea355566c", "uScript_Events", Relay_uScriptStart_2)) return; 
      Relay_In_3();
   }
   
   void Relay_uScriptLateStart_2()
   {
      if (true == CheckDebugBreak("142bb7d2-9a66-46e4-b88b-305ea355566c", "uScript_Events", Relay_uScriptLateStart_2)) return; 
   }
   
   void Relay_In_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("34c65f62-1988-4081-b2b4-86bf2f901d6d", "Create_Relative_Rect__Screen_", Relay_In_3)) return; 
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
         logic_uScriptAct_CreateRelativeRectScreen_uScriptAct_CreateRelativeRectScreen_3.In(logic_uScriptAct_CreateRelativeRectScreen_RectWidth_3, logic_uScriptAct_CreateRelativeRectScreen_RectHeight_3, logic_uScriptAct_CreateRelativeRectScreen_RectPosition_3, logic_uScriptAct_CreateRelativeRectScreen_xOffset_3, logic_uScriptAct_CreateRelativeRectScreen_yOffset_3, out logic_uScriptAct_CreateRelativeRectScreen_OutputRect_3);
         local_Target_Rect_UnityEngine_Rect = logic_uScriptAct_CreateRelativeRectScreen_OutputRect_3;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_CreateRelativeRectScreen_uScriptAct_CreateRelativeRectScreen_3.Out;
         
         if ( test_0 == true )
         {
            Relay_In_23();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_Credits.uscript at Create Relative Rect (Screen).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e75e3898-72da-4170-8679-480a80a5c381", "GUI_Box", Relay_In_5)) return; 
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
         logic_uScriptAct_GUIBox_uScriptAct_GUIBox_5.In(logic_uScriptAct_GUIBox_Text_5, logic_uScriptAct_GUIBox_Position_5, logic_uScriptAct_GUIBox_Texture_5, logic_uScriptAct_GUIBox_ToolTip_5, logic_uScriptAct_GUIBox_guiStyle_5);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUIBox_uScriptAct_GUIBox_5.Out;
         
         if ( test_0 == true )
         {
            Relay_In_34();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_Credits.uscript at GUI Box.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonDown_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3b561381-83f6-4e7e-af43-79a13065e583", "GUI_Button", Relay_OnButtonDown_6)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_Credits.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonHeld_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3b561381-83f6-4e7e-af43-79a13065e583", "GUI_Button", Relay_OnButtonHeld_6)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_Credits.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonUp_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3b561381-83f6-4e7e-af43-79a13065e583", "GUI_Button", Relay_OnButtonUp_6)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_Credits.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonClicked_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3b561381-83f6-4e7e-af43-79a13065e583", "GUI_Button", Relay_OnButtonClicked_6)) return; 
         Relay_SendCustomEvent_31();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_Credits.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3b561381-83f6-4e7e-af43-79a13065e583", "GUI_Button", Relay_In_6)) return; 
         {
            {
               logic_uScriptAct_GUIButton_Text_6 = local_9_System_String;
               
            }
            {
            }
            {
               logic_uScriptAct_GUIButton_Position_6 = local_7_UnityEngine_Rect;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6.In(logic_uScriptAct_GUIButton_Text_6, logic_uScriptAct_GUIButton_identifier_6, logic_uScriptAct_GUIButton_Position_6, logic_uScriptAct_GUIButton_Texture_6, logic_uScriptAct_GUIButton_ToolTip_6, logic_uScriptAct_GUIButton_guiStyle_6);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUIButton_uScriptAct_GUIButton_6.Out;
         
         if ( test_0 == true )
         {
            Relay_In_8();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_Credits.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_8()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("52d5cf8c-1389-4ebf-b017-600a8334d984", "GUI_End_Group", Relay_In_8)) return; 
         {
         }
         logic_uScriptAct_GUIEndGroup_uScriptAct_GUIEndGroup_8.In();
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_Credits.uscript at GUI End Group.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnUpdate_11()
   {
      if (true == CheckDebugBreak("6f411169-b787-4ba5-8dff-9c129355d01b", "Global_Update", Relay_OnUpdate_11)) return; 
      Relay_Filter_12();
   }
   
   void Relay_OnLateUpdate_11()
   {
      if (true == CheckDebugBreak("6f411169-b787-4ba5-8dff-9c129355d01b", "Global_Update", Relay_OnLateUpdate_11)) return; 
   }
   
   void Relay_OnFixedUpdate_11()
   {
      if (true == CheckDebugBreak("6f411169-b787-4ba5-8dff-9c129355d01b", "Global_Update", Relay_OnFixedUpdate_11)) return; 
   }
   
   void Relay_Reset_12()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("07cb7dc7-127e-429c-8b73-a68849028c77", "Filter_Rect", Relay_Reset_12)) return; 
         {
            {
               logic_uScriptAct_FilterRect_Target_12 = local_Target_Rect_UnityEngine_Rect;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_FilterRect_uScriptAct_FilterRect_12.Reset(logic_uScriptAct_FilterRect_Target_12, logic_uScriptAct_FilterRect_FilterConstant_12, out logic_uScriptAct_FilterRect_Value_12);
         local_Filtered_Rect_UnityEngine_Rect = logic_uScriptAct_FilterRect_Value_12;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_Credits.uscript at Filter Rect.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Filter_12()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("07cb7dc7-127e-429c-8b73-a68849028c77", "Filter_Rect", Relay_Filter_12)) return; 
         {
            {
               logic_uScriptAct_FilterRect_Target_12 = local_Target_Rect_UnityEngine_Rect;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_FilterRect_uScriptAct_FilterRect_12.Filter(logic_uScriptAct_FilterRect_Target_12, logic_uScriptAct_FilterRect_FilterConstant_12, out logic_uScriptAct_FilterRect_Value_12);
         local_Filtered_Rect_UnityEngine_Rect = logic_uScriptAct_FilterRect_Value_12;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_Credits.uscript at Filter Rect.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnCustomEventString_15()
   {
      if (true == CheckDebugBreak("1d6d4a07-bce2-4eea-a953-a8478cc30661", "Custom_Event__String_", Relay_OnCustomEventString_15)) return; 
      local_16_System_String = event_UnityEngine_GameObject_EventName_15;
      local_17_System_String = event_UnityEngine_GameObject_EventData_15;
      Relay_In_19();
   }
   
   void Relay_In_18()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("759827d3-d770-4b3d-bc8c-57687f83fafc", "Compare_String", Relay_In_18)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_18 = local_17_System_String;
               
            }
            {
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_18.In(logic_uScriptCon_CompareString_A_18, logic_uScriptCon_CompareString_B_18);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_18.Same;
         
         if ( test_0 == true )
         {
            Relay_In_20();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_Credits.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_19()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("aac8d650-712b-4248-b513-14bcd5c7ce29", "Compare_String", Relay_In_19)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_19 = local_16_System_String;
               
            }
            {
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_19.In(logic_uScriptCon_CompareString_A_19, logic_uScriptCon_CompareString_B_19);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_19.Same;
         
         if ( test_0 == true )
         {
            Relay_In_18();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_Credits.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_20()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c8f331db-f880-48f3-92d0-08aced7c34c8", "Create_Relative_Rect__Screen_", Relay_In_20)) return; 
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
         logic_uScriptAct_CreateRelativeRectScreen_uScriptAct_CreateRelativeRectScreen_20.In(logic_uScriptAct_CreateRelativeRectScreen_RectWidth_20, logic_uScriptAct_CreateRelativeRectScreen_RectHeight_20, logic_uScriptAct_CreateRelativeRectScreen_RectPosition_20, logic_uScriptAct_CreateRelativeRectScreen_xOffset_20, logic_uScriptAct_CreateRelativeRectScreen_yOffset_20, out logic_uScriptAct_CreateRelativeRectScreen_OutputRect_20);
         local_Target_Rect_UnityEngine_Rect = logic_uScriptAct_CreateRelativeRectScreen_OutputRect_20;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_Credits.uscript at Create Relative Rect (Screen).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_23()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ab90415b-4dc2-4605-8dc7-a127b9a43e71", "Get_Components__Rect_", Relay_In_23)) return; 
         {
            {
               logic_uScriptAct_GetComponentsRect_InputRect_23 = local_Target_Rect_UnityEngine_Rect;
               
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
         logic_uScriptAct_GetComponentsRect_uScriptAct_GetComponentsRect_23.In(logic_uScriptAct_GetComponentsRect_InputRect_23, out logic_uScriptAct_GetComponentsRect_Left_23, out logic_uScriptAct_GetComponentsRect_Top_23, out logic_uScriptAct_GetComponentsRect_Width_23, out logic_uScriptAct_GetComponentsRect_Height_23);
         local_22_System_Single = logic_uScriptAct_GetComponentsRect_Top_23;
         local_26_System_Single = logic_uScriptAct_GetComponentsRect_Width_23;
         local_24_System_Single = logic_uScriptAct_GetComponentsRect_Height_23;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetComponentsRect_uScriptAct_GetComponentsRect_23.Out;
         
         if ( test_0 == true )
         {
            Relay_In_25();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_Credits.uscript at Get Components (Rect).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_25()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d460684c-6acd-4352-aafd-b66804f7d228", "Set_Components__Rect_", Relay_In_25)) return; 
         {
            {
            }
            {
               logic_uScriptAct_SetComponentsRect_Top_25 = local_22_System_Single;
               
            }
            {
               logic_uScriptAct_SetComponentsRect_Width_25 = local_26_System_Single;
               
            }
            {
               logic_uScriptAct_SetComponentsRect_Height_25 = local_24_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_SetComponentsRect_uScriptAct_SetComponentsRect_25.In(logic_uScriptAct_SetComponentsRect_Left_25, logic_uScriptAct_SetComponentsRect_Top_25, logic_uScriptAct_SetComponentsRect_Width_25, logic_uScriptAct_SetComponentsRect_Height_25, out logic_uScriptAct_SetComponentsRect_OutputRect_25);
         local_Target_Rect_UnityEngine_Rect = logic_uScriptAct_SetComponentsRect_OutputRect_25;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetComponentsRect_uScriptAct_SetComponentsRect_25.Out;
         
         if ( test_0 == true )
         {
            Relay_Reset_12();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_Credits.uscript at Set Components (Rect).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_28()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b2adeacb-fa4c-40f3-a809-a77876ea0087", "Get_Components__Rect_", Relay_In_28)) return; 
         {
            {
               logic_uScriptAct_GetComponentsRect_InputRect_28 = local_Target_Rect_UnityEngine_Rect;
               
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
         logic_uScriptAct_GetComponentsRect_uScriptAct_GetComponentsRect_28.In(logic_uScriptAct_GetComponentsRect_InputRect_28, out logic_uScriptAct_GetComponentsRect_Left_28, out logic_uScriptAct_GetComponentsRect_Top_28, out logic_uScriptAct_GetComponentsRect_Width_28, out logic_uScriptAct_GetComponentsRect_Height_28);
         local_27_System_Single = logic_uScriptAct_GetComponentsRect_Top_28;
         local_33_System_Single = logic_uScriptAct_GetComponentsRect_Width_28;
         local_30_System_Single = logic_uScriptAct_GetComponentsRect_Height_28;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetComponentsRect_uScriptAct_GetComponentsRect_28.Out;
         
         if ( test_0 == true )
         {
            Relay_In_32();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_Credits.uscript at Get Components (Rect).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_SendCustomEvent_31()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4c0c2678-3ddb-435c-9fcf-f987c98bc601", "Send_Custom_Event__String_", Relay_SendCustomEvent_31)) return; 
         {
            {
            }
            {
               logic_uScriptAct_SendCustomEventString_EventValue_31 = local_9_System_String;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SendCustomEventString_uScriptAct_SendCustomEventString_31.SendCustomEvent(logic_uScriptAct_SendCustomEventString_EventName_31, logic_uScriptAct_SendCustomEventString_EventValue_31, logic_uScriptAct_SendCustomEventString_sendGroup_31, logic_uScriptAct_SendCustomEventString_EventSender_31);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SendCustomEventString_uScriptAct_SendCustomEventString_31.Out;
         
         if ( test_0 == true )
         {
            Relay_In_28();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_Credits.uscript at Send Custom Event (String).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_32()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("93a7cb18-5a50-4ce9-b5a4-fce1e9c966f8", "Set_Components__Rect_", Relay_In_32)) return; 
         {
            {
            }
            {
               logic_uScriptAct_SetComponentsRect_Top_32 = local_27_System_Single;
               
            }
            {
               logic_uScriptAct_SetComponentsRect_Width_32 = local_33_System_Single;
               
            }
            {
               logic_uScriptAct_SetComponentsRect_Height_32 = local_30_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_SetComponentsRect_uScriptAct_SetComponentsRect_32.In(logic_uScriptAct_SetComponentsRect_Left_32, logic_uScriptAct_SetComponentsRect_Top_32, logic_uScriptAct_SetComponentsRect_Width_32, logic_uScriptAct_SetComponentsRect_Height_32, out logic_uScriptAct_SetComponentsRect_OutputRect_32);
         local_Target_Rect_UnityEngine_Rect = logic_uScriptAct_SetComponentsRect_OutputRect_32;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_Credits.uscript at Set Components (Rect).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_34()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("65037f3f-9c9f-4401-bb63-895893008ad6", "GUI_Label", Relay_In_34)) return; 
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
         logic_uScriptAct_GUILabel_uScriptAct_GUILabel_34.In(logic_uScriptAct_GUILabel_Text_34, logic_uScriptAct_GUILabel_Position_34, logic_uScriptAct_GUILabel_Texture_34, logic_uScriptAct_GUILabel_ToolTip_34, logic_uScriptAct_GUILabel_guiStyle_34);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUILabel_uScriptAct_GUILabel_34.Out;
         
         if ( test_0 == true )
         {
            Relay_In_6();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_Credits.uscript at GUI Label.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_Credits.uscript:7", local_7_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b6b56357-42a2-4daa-affd-f8db9ed8e883", local_7_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_Credits.uscript:9", local_9_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ff4ec241-4417-4230-b8ae-68c41d09311f", local_9_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_Credits.uscript:Filtered Rect", local_Filtered_Rect_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c98ee999-5487-4103-a887-6231475c32c1", local_Filtered_Rect_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_Credits.uscript:16", local_16_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d5a5c1b8-856d-402c-8e9f-5a6d7cbce250", local_16_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_Credits.uscript:17", local_17_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "eb1ca6d6-9f7a-428c-a03a-76b29f4a7aa8", local_17_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_Credits.uscript:22", local_22_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a0b2612d-df13-4337-b420-ef4c336aff23", local_22_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_Credits.uscript:24", local_24_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d71e4ff7-9da3-4021-aa91-b76a19473289", local_24_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_Credits.uscript:26", local_26_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "02c0c05d-fb9c-4b72-b3fc-2e2e5c08a719", local_26_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_Credits.uscript:27", local_27_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f50d6c49-86f2-4859-bf8b-284065e70c44", local_27_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_Credits.uscript:Target Rect", local_Target_Rect_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "cc32696d-b027-486f-bddc-13d9e63feb3b", local_Target_Rect_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_Credits.uscript:30", local_30_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "2dbd8ad0-69b2-40bc-8a12-6baa0b82da4d", local_30_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_Credits.uscript:33", local_33_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "6af4d8f2-9469-424f-b583-cc1005207d09", local_33_System_Single);
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
