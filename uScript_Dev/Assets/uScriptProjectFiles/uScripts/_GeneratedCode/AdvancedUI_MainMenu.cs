//uScript Generated Code - Build 1.0.3109
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class AdvancedUI_MainMenu : uScriptLogic
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
   UnityEngine.Rect local_0_UnityEngine_Rect = new Rect( (float)40, (float)40, (float)520, (float)80 );
   UnityEngine.Rect local_11_UnityEngine_Rect = new Rect( (float)40, (float)240, (float)520, (float)80 );
   System.String local_14_System_String = "Play Game";
   System.String local_15_System_String = "Options";
   System.String local_16_System_String = "Credits";
   System.String local_23_System_String = "";
   System.String local_24_System_String = "";
   System.Single local_33_System_Single = (float) 0;
   System.Single local_34_System_Single = (float) 0;
   System.Single local_35_System_Single = (float) 0;
   UnityEngine.Rect local_8_UnityEngine_Rect = new Rect( (float)40, (float)140, (float)520, (float)80 );
   UnityEngine.Rect local_Filtered_Rect_UnityEngine_Rect = new Rect( (float)0, (float)0, (float)0, (float)0 );
   UnityEngine.Rect local_Target_Rect_UnityEngine_Rect = new Rect( (float)0, (float)0, (float)0, (float)0 );
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_GUIBeginGroup logic_uScriptAct_GUIBeginGroup_uScriptAct_GUIBeginGroup_2 = new uScriptAct_GUIBeginGroup( );
   UnityEngine.Rect logic_uScriptAct_GUIBeginGroup_Position_2 = new Rect( );
   System.String logic_uScriptAct_GUIBeginGroup_Text_2 = "";
   UnityEngine.Texture2D logic_uScriptAct_GUIBeginGroup_Texture_2 = default(UnityEngine.Texture2D);
   System.String logic_uScriptAct_GUIBeginGroup_ToolTip_2 = "";
   System.String logic_uScriptAct_GUIBeginGroup_guiStyle_2 = "";
   bool logic_uScriptAct_GUIBeginGroup_Out_2 = true;
   //pointer to script instanced logic node
   uScriptAct_CreateRelativeRectScreen logic_uScriptAct_CreateRelativeRectScreen_uScriptAct_CreateRelativeRectScreen_4 = new uScriptAct_CreateRelativeRectScreen( );
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_RectWidth_4 = (int) 600;
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_RectHeight_4 = (int) 400;
   uScriptAct_CreateRelativeRectScreen.Position logic_uScriptAct_CreateRelativeRectScreen_RectPosition_4 = uScriptAct_CreateRelativeRectScreen.Position.MiddleCenter;
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_xOffset_4 = (int) 0;
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_yOffset_4 = (int) 0;
   UnityEngine.Rect logic_uScriptAct_CreateRelativeRectScreen_OutputRect_4;
   bool logic_uScriptAct_CreateRelativeRectScreen_Out_4 = true;
   //pointer to script instanced logic node
   uScriptAct_GUIBox logic_uScriptAct_GUIBox_uScriptAct_GUIBox_6 = new uScriptAct_GUIBox( );
   System.String logic_uScriptAct_GUIBox_Text_6 = "Main Menu";
   UnityEngine.Rect logic_uScriptAct_GUIBox_Position_6 = new Rect( (float)0, (float)0, (float)600, (float)400 );
   UnityEngine.Texture2D logic_uScriptAct_GUIBox_Texture_6 = default(UnityEngine.Texture2D);
   System.String logic_uScriptAct_GUIBox_ToolTip_6 = "";
   System.String logic_uScriptAct_GUIBox_guiStyle_6 = "";
   bool logic_uScriptAct_GUIBox_Out_6 = true;
   //pointer to script instanced logic node
   uScriptAct_GUIButton logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7 = new uScriptAct_GUIButton( );
   System.String logic_uScriptAct_GUIButton_Text_7 = "";
   System.Int32 logic_uScriptAct_GUIButton_identifier_7 = (int) 0;
   UnityEngine.Rect logic_uScriptAct_GUIButton_Position_7 = new Rect( );
   UnityEngine.Texture2D logic_uScriptAct_GUIButton_Texture_7 = default(UnityEngine.Texture2D);
   System.String logic_uScriptAct_GUIButton_ToolTip_7 = "";
   System.String logic_uScriptAct_GUIButton_guiStyle_7 = "";
   bool logic_uScriptAct_GUIButton_Out_7 = true;
   //pointer to script instanced logic node
   uScriptAct_GUIButton logic_uScriptAct_GUIButton_uScriptAct_GUIButton_9 = new uScriptAct_GUIButton( );
   System.String logic_uScriptAct_GUIButton_Text_9 = "";
   System.Int32 logic_uScriptAct_GUIButton_identifier_9 = (int) 0;
   UnityEngine.Rect logic_uScriptAct_GUIButton_Position_9 = new Rect( );
   UnityEngine.Texture2D logic_uScriptAct_GUIButton_Texture_9 = default(UnityEngine.Texture2D);
   System.String logic_uScriptAct_GUIButton_ToolTip_9 = "";
   System.String logic_uScriptAct_GUIButton_guiStyle_9 = "";
   bool logic_uScriptAct_GUIButton_Out_9 = true;
   //pointer to script instanced logic node
   uScriptAct_GUIButton logic_uScriptAct_GUIButton_uScriptAct_GUIButton_10 = new uScriptAct_GUIButton( );
   System.String logic_uScriptAct_GUIButton_Text_10 = "";
   System.Int32 logic_uScriptAct_GUIButton_identifier_10 = (int) 0;
   UnityEngine.Rect logic_uScriptAct_GUIButton_Position_10 = new Rect( );
   UnityEngine.Texture2D logic_uScriptAct_GUIButton_Texture_10 = default(UnityEngine.Texture2D);
   System.String logic_uScriptAct_GUIButton_ToolTip_10 = "";
   System.String logic_uScriptAct_GUIButton_guiStyle_10 = "";
   bool logic_uScriptAct_GUIButton_Out_10 = true;
   //pointer to script instanced logic node
   uScriptAct_GUIEndGroup logic_uScriptAct_GUIEndGroup_uScriptAct_GUIEndGroup_12 = new uScriptAct_GUIEndGroup( );
   bool logic_uScriptAct_GUIEndGroup_Out_12 = true;
   //pointer to script instanced logic node
   uScriptAct_SendCustomEventString logic_uScriptAct_SendCustomEventString_uScriptAct_SendCustomEventString_13 = new uScriptAct_SendCustomEventString( );
   System.String logic_uScriptAct_SendCustomEventString_EventName_13 = "UI Button Clicked";
   System.String logic_uScriptAct_SendCustomEventString_EventValue_13 = "";
   uScriptCustomEvent.SendGroup logic_uScriptAct_SendCustomEventString_sendGroup_13 = uScriptCustomEvent.SendGroup.All;
   UnityEngine.GameObject logic_uScriptAct_SendCustomEventString_EventSender_13 = default(UnityEngine.GameObject);
   bool logic_uScriptAct_SendCustomEventString_Out_13 = true;
   //pointer to script instanced logic node
   uScriptAct_FilterRect logic_uScriptAct_FilterRect_uScriptAct_FilterRect_19 = new uScriptAct_FilterRect( );
   UnityEngine.Rect logic_uScriptAct_FilterRect_Target_19 = new Rect( );
   System.Single logic_uScriptAct_FilterRect_FilterConstant_19 = (float) 0.05;
   UnityEngine.Rect logic_uScriptAct_FilterRect_Value_19;
   bool logic_uScriptAct_FilterRect_Out_19 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_25 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_25 = "";
   System.String logic_uScriptCon_CompareString_B_25 = "Back To Main Menu";
   bool logic_uScriptCon_CompareString_Same_25 = true;
   bool logic_uScriptCon_CompareString_Different_25 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_26 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_26 = "";
   System.String logic_uScriptCon_CompareString_B_26 = "UI Button Clicked";
   bool logic_uScriptCon_CompareString_Same_26 = true;
   bool logic_uScriptCon_CompareString_Different_26 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_27 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_27 = "";
   System.String logic_uScriptCon_CompareString_B_27 = "Main Menu";
   bool logic_uScriptCon_CompareString_Same_27 = true;
   bool logic_uScriptCon_CompareString_Different_27 = true;
   //pointer to script instanced logic node
   uScriptAct_CreateRelativeRectScreen logic_uScriptAct_CreateRelativeRectScreen_uScriptAct_CreateRelativeRectScreen_28 = new uScriptAct_CreateRelativeRectScreen( );
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_RectWidth_28 = (int) 600;
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_RectHeight_28 = (int) 400;
   uScriptAct_CreateRelativeRectScreen.Position logic_uScriptAct_CreateRelativeRectScreen_RectPosition_28 = uScriptAct_CreateRelativeRectScreen.Position.MiddleCenter;
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_xOffset_28 = (int) 0;
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_yOffset_28 = (int) 0;
   UnityEngine.Rect logic_uScriptAct_CreateRelativeRectScreen_OutputRect_28;
   bool logic_uScriptAct_CreateRelativeRectScreen_Out_28 = true;
   //pointer to script instanced logic node
   uScriptAct_SetComponentsRect logic_uScriptAct_SetComponentsRect_uScriptAct_SetComponentsRect_31 = new uScriptAct_SetComponentsRect( );
   System.Single logic_uScriptAct_SetComponentsRect_Left_31 = (float) -800;
   System.Single logic_uScriptAct_SetComponentsRect_Top_31 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsRect_Width_31 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsRect_Height_31 = (float) 0;
   UnityEngine.Rect logic_uScriptAct_SetComponentsRect_OutputRect_31;
   bool logic_uScriptAct_SetComponentsRect_Out_31 = true;
   //pointer to script instanced logic node
   uScriptAct_GetComponentsRect logic_uScriptAct_GetComponentsRect_uScriptAct_GetComponentsRect_32 = new uScriptAct_GetComponentsRect( );
   UnityEngine.Rect logic_uScriptAct_GetComponentsRect_InputRect_32 = new Rect( );
   System.Single logic_uScriptAct_GetComponentsRect_Left_32;
   System.Single logic_uScriptAct_GetComponentsRect_Top_32;
   System.Single logic_uScriptAct_GetComponentsRect_Width_32;
   System.Single logic_uScriptAct_GetComponentsRect_Height_32;
   bool logic_uScriptAct_GetComponentsRect_Out_32 = true;
   //pointer to script instanced logic node
   uScriptAct_SendCustomEventString logic_uScriptAct_SendCustomEventString_uScriptAct_SendCustomEventString_36 = new uScriptAct_SendCustomEventString( );
   System.String logic_uScriptAct_SendCustomEventString_EventName_36 = "UI Button Clicked";
   System.String logic_uScriptAct_SendCustomEventString_EventValue_36 = "";
   uScriptCustomEvent.SendGroup logic_uScriptAct_SendCustomEventString_sendGroup_36 = uScriptCustomEvent.SendGroup.All;
   UnityEngine.GameObject logic_uScriptAct_SendCustomEventString_EventSender_36 = default(UnityEngine.GameObject);
   bool logic_uScriptAct_SendCustomEventString_Out_36 = true;
   //pointer to script instanced logic node
   uScriptAct_SendCustomEventString logic_uScriptAct_SendCustomEventString_uScriptAct_SendCustomEventString_37 = new uScriptAct_SendCustomEventString( );
   System.String logic_uScriptAct_SendCustomEventString_EventName_37 = "UI Button Clicked";
   System.String logic_uScriptAct_SendCustomEventString_EventValue_37 = "";
   uScriptCustomEvent.SendGroup logic_uScriptAct_SendCustomEventString_sendGroup_37 = uScriptCustomEvent.SendGroup.All;
   UnityEngine.GameObject logic_uScriptAct_SendCustomEventString_EventSender_37 = default(UnityEngine.GameObject);
   bool logic_uScriptAct_SendCustomEventString_Out_37 = true;
   
   //event nodes
   System.Boolean event_UnityEngine_GameObject_GUIChanged_1 = (bool) false;
   System.String event_UnityEngine_GameObject_FocusedControl_1 = "";
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_1 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_3 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_18 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_22 = default(UnityEngine.GameObject);
   System.String event_UnityEngine_GameObject_EventName_22 = "";
   System.String event_UnityEngine_GameObject_EventData_22 = "";
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_22 = default(UnityEngine.GameObject);
   
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
      if ( null == event_UnityEngine_GameObject_Instance_1 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_1 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_1 )
         {
            {
               if ( null == thisScriptsOnGuiListener )
               {
                  //OnGUI need unique listeners so calls like GUI.depth will work across uScripts
                  thisScriptsOnGuiListener = event_UnityEngine_GameObject_Instance_1.AddComponent<uScript_GUI>();
               }
               uScript_GUI component = thisScriptsOnGuiListener;
               if ( null != component )
               {
                  component.OnGui += Instance_OnGui_1;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_3 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_3 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_3 )
         {
            {
               uScript_Global component = event_UnityEngine_GameObject_Instance_3.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_3.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_3;
                  component.uScriptLateStart += Instance_uScriptLateStart_3;
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
               uScript_Update component = event_UnityEngine_GameObject_Instance_18.GetComponent<uScript_Update>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_18.AddComponent<uScript_Update>();
               }
               if ( null != component )
               {
                  component.OnUpdate += Instance_OnUpdate_18;
                  component.OnLateUpdate += Instance_OnLateUpdate_18;
                  component.OnFixedUpdate += Instance_OnFixedUpdate_18;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_22 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_22 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_22 )
         {
            {
               uScript_CustomEventString component = event_UnityEngine_GameObject_Instance_22.GetComponent<uScript_CustomEventString>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_22.AddComponent<uScript_CustomEventString>();
               }
               if ( null != component )
               {
                  component.OnCustomEventString += Instance_OnCustomEventString_22;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != event_UnityEngine_GameObject_Instance_1 )
      {
         {
            if ( null == thisScriptsOnGuiListener )
            {
               //OnGUI need unique listeners so calls like GUI.depth will work across uScripts
               thisScriptsOnGuiListener = event_UnityEngine_GameObject_Instance_1.AddComponent<uScript_GUI>();
            }
            uScript_GUI component = thisScriptsOnGuiListener;
            if ( null != component )
            {
               component.OnGui -= Instance_OnGui_1;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_3 )
      {
         {
            uScript_Global component = event_UnityEngine_GameObject_Instance_3.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_3;
               component.uScriptLateStart -= Instance_uScriptLateStart_3;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_18 )
      {
         {
            uScript_Update component = event_UnityEngine_GameObject_Instance_18.GetComponent<uScript_Update>();
            if ( null != component )
            {
               component.OnUpdate -= Instance_OnUpdate_18;
               component.OnLateUpdate -= Instance_OnLateUpdate_18;
               component.OnFixedUpdate -= Instance_OnFixedUpdate_18;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_22 )
      {
         {
            uScript_CustomEventString component = event_UnityEngine_GameObject_Instance_22.GetComponent<uScript_CustomEventString>();
            if ( null != component )
            {
               component.OnCustomEventString -= Instance_OnCustomEventString_22;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_GUIBeginGroup_uScriptAct_GUIBeginGroup_2.SetParent(g);
      logic_uScriptAct_CreateRelativeRectScreen_uScriptAct_CreateRelativeRectScreen_4.SetParent(g);
      logic_uScriptAct_GUIBox_uScriptAct_GUIBox_6.SetParent(g);
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7.SetParent(g);
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_9.SetParent(g);
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_10.SetParent(g);
      logic_uScriptAct_GUIEndGroup_uScriptAct_GUIEndGroup_12.SetParent(g);
      logic_uScriptAct_SendCustomEventString_uScriptAct_SendCustomEventString_13.SetParent(g);
      logic_uScriptAct_FilterRect_uScriptAct_FilterRect_19.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_25.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_26.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_27.SetParent(g);
      logic_uScriptAct_CreateRelativeRectScreen_uScriptAct_CreateRelativeRectScreen_28.SetParent(g);
      logic_uScriptAct_SetComponentsRect_uScriptAct_SetComponentsRect_31.SetParent(g);
      logic_uScriptAct_GetComponentsRect_uScriptAct_GetComponentsRect_32.SetParent(g);
      logic_uScriptAct_SendCustomEventString_uScriptAct_SendCustomEventString_36.SetParent(g);
      logic_uScriptAct_SendCustomEventString_uScriptAct_SendCustomEventString_37.SetParent(g);
   }
   public void Awake()
   {
      
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7.OnButtonDown += uScriptAct_GUIButton_OnButtonDown_7;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7.OnButtonHeld += uScriptAct_GUIButton_OnButtonHeld_7;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7.OnButtonUp += uScriptAct_GUIButton_OnButtonUp_7;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7.OnButtonClicked += uScriptAct_GUIButton_OnButtonClicked_7;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_9.OnButtonDown += uScriptAct_GUIButton_OnButtonDown_9;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_9.OnButtonHeld += uScriptAct_GUIButton_OnButtonHeld_9;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_9.OnButtonUp += uScriptAct_GUIButton_OnButtonUp_9;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_9.OnButtonClicked += uScriptAct_GUIButton_OnButtonClicked_9;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_10.OnButtonDown += uScriptAct_GUIButton_OnButtonDown_10;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_10.OnButtonHeld += uScriptAct_GUIButton_OnButtonHeld_10;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_10.OnButtonUp += uScriptAct_GUIButton_OnButtonUp_10;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_10.OnButtonClicked += uScriptAct_GUIButton_OnButtonClicked_10;
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
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7.OnButtonDown -= uScriptAct_GUIButton_OnButtonDown_7;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7.OnButtonHeld -= uScriptAct_GUIButton_OnButtonHeld_7;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7.OnButtonUp -= uScriptAct_GUIButton_OnButtonUp_7;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7.OnButtonClicked -= uScriptAct_GUIButton_OnButtonClicked_7;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_9.OnButtonDown -= uScriptAct_GUIButton_OnButtonDown_9;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_9.OnButtonHeld -= uScriptAct_GUIButton_OnButtonHeld_9;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_9.OnButtonUp -= uScriptAct_GUIButton_OnButtonUp_9;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_9.OnButtonClicked -= uScriptAct_GUIButton_OnButtonClicked_9;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_10.OnButtonDown -= uScriptAct_GUIButton_OnButtonDown_10;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_10.OnButtonHeld -= uScriptAct_GUIButton_OnButtonHeld_10;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_10.OnButtonUp -= uScriptAct_GUIButton_OnButtonUp_10;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_10.OnButtonClicked -= uScriptAct_GUIButton_OnButtonClicked_10;
   }
   
   void Instance_OnGui_1(object o, uScript_GUI.GUIEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GUIChanged_1 = e.GUIChanged;
      event_UnityEngine_GameObject_FocusedControl_1 = e.FocusedControl;
      //relay event to nodes
      Relay_OnGui_1( );
   }
   
   void Instance_uScriptStart_3(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_3( );
   }
   
   void Instance_uScriptLateStart_3(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptLateStart_3( );
   }
   
   void Instance_OnUpdate_18(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUpdate_18( );
   }
   
   void Instance_OnLateUpdate_18(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnLateUpdate_18( );
   }
   
   void Instance_OnFixedUpdate_18(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnFixedUpdate_18( );
   }
   
   void Instance_OnCustomEventString_22(object o, uScript_CustomEventString.CustomEventStringArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_22 = e.Sender;
      event_UnityEngine_GameObject_EventName_22 = e.EventName;
      event_UnityEngine_GameObject_EventData_22 = e.EventData;
      //relay event to nodes
      Relay_OnCustomEventString_22( );
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
   
   void uScriptAct_GUIButton_OnButtonDown_9(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonDown_9( );
   }
   
   void uScriptAct_GUIButton_OnButtonHeld_9(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonHeld_9( );
   }
   
   void uScriptAct_GUIButton_OnButtonUp_9(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonUp_9( );
   }
   
   void uScriptAct_GUIButton_OnButtonClicked_9(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonClicked_9( );
   }
   
   void uScriptAct_GUIButton_OnButtonDown_10(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonDown_10( );
   }
   
   void uScriptAct_GUIButton_OnButtonHeld_10(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonHeld_10( );
   }
   
   void uScriptAct_GUIButton_OnButtonUp_10(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonUp_10( );
   }
   
   void uScriptAct_GUIButton_OnButtonClicked_10(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonClicked_10( );
   }
   
   void Relay_OnGui_1()
   {
      if (true == CheckDebugBreak("147aaa7d-d122-40e8-abe2-80f201356edf", "GUI_Events", Relay_OnGui_1)) return; 
      Relay_In_2();
   }
   
   void Relay_In_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5264832f-c586-486a-96c3-3a4bbd9bfc20", "GUI_Begin_Group", Relay_In_2)) return; 
         {
            {
               logic_uScriptAct_GUIBeginGroup_Position_2 = local_Filtered_Rect_UnityEngine_Rect;
               
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
         logic_uScriptAct_GUIBeginGroup_uScriptAct_GUIBeginGroup_2.In(logic_uScriptAct_GUIBeginGroup_Position_2, logic_uScriptAct_GUIBeginGroup_Text_2, logic_uScriptAct_GUIBeginGroup_Texture_2, logic_uScriptAct_GUIBeginGroup_ToolTip_2, logic_uScriptAct_GUIBeginGroup_guiStyle_2);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUIBeginGroup_uScriptAct_GUIBeginGroup_2.Out;
         
         if ( test_0 == true )
         {
            Relay_In_6();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at GUI Begin Group.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_uScriptStart_3()
   {
      if (true == CheckDebugBreak("142bb7d2-9a66-46e4-b88b-305ea355566c", "uScript_Events", Relay_uScriptStart_3)) return; 
      Relay_In_4();
   }
   
   void Relay_uScriptLateStart_3()
   {
      if (true == CheckDebugBreak("142bb7d2-9a66-46e4-b88b-305ea355566c", "uScript_Events", Relay_uScriptLateStart_3)) return; 
   }
   
   void Relay_In_4()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("34c65f62-1988-4081-b2b4-86bf2f901d6d", "Create_Relative_Rect__Screen_", Relay_In_4)) return; 
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
         logic_uScriptAct_CreateRelativeRectScreen_uScriptAct_CreateRelativeRectScreen_4.In(logic_uScriptAct_CreateRelativeRectScreen_RectWidth_4, logic_uScriptAct_CreateRelativeRectScreen_RectHeight_4, logic_uScriptAct_CreateRelativeRectScreen_RectPosition_4, logic_uScriptAct_CreateRelativeRectScreen_xOffset_4, logic_uScriptAct_CreateRelativeRectScreen_yOffset_4, out logic_uScriptAct_CreateRelativeRectScreen_OutputRect_4);
         local_Target_Rect_UnityEngine_Rect = logic_uScriptAct_CreateRelativeRectScreen_OutputRect_4;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_CreateRelativeRectScreen_uScriptAct_CreateRelativeRectScreen_4.Out;
         
         if ( test_0 == true )
         {
            Relay_Reset_19();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at Create Relative Rect (Screen).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e75e3898-72da-4170-8679-480a80a5c381", "GUI_Box", Relay_In_6)) return; 
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
         logic_uScriptAct_GUIBox_uScriptAct_GUIBox_6.In(logic_uScriptAct_GUIBox_Text_6, logic_uScriptAct_GUIBox_Position_6, logic_uScriptAct_GUIBox_Texture_6, logic_uScriptAct_GUIBox_ToolTip_6, logic_uScriptAct_GUIBox_guiStyle_6);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUIBox_uScriptAct_GUIBox_6.Out;
         
         if ( test_0 == true )
         {
            Relay_In_7();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at GUI Box.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonDown_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5fef6547-87c4-47b4-8280-a6793aa7e709", "GUI_Button", Relay_OnButtonDown_7)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonHeld_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5fef6547-87c4-47b4-8280-a6793aa7e709", "GUI_Button", Relay_OnButtonHeld_7)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonUp_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5fef6547-87c4-47b4-8280-a6793aa7e709", "GUI_Button", Relay_OnButtonUp_7)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonClicked_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5fef6547-87c4-47b4-8280-a6793aa7e709", "GUI_Button", Relay_OnButtonClicked_7)) return; 
         Relay_SendCustomEvent_13();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5fef6547-87c4-47b4-8280-a6793aa7e709", "GUI_Button", Relay_In_7)) return; 
         {
            {
               logic_uScriptAct_GUIButton_Text_7 = local_14_System_String;
               
            }
            {
            }
            {
               logic_uScriptAct_GUIButton_Position_7 = local_0_UnityEngine_Rect;
               
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
         bool test_0 = logic_uScriptAct_GUIButton_uScriptAct_GUIButton_7.Out;
         
         if ( test_0 == true )
         {
            Relay_In_9();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonDown_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("42f651df-8829-43e7-8d11-333e64c7f17e", "GUI_Button", Relay_OnButtonDown_9)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonHeld_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("42f651df-8829-43e7-8d11-333e64c7f17e", "GUI_Button", Relay_OnButtonHeld_9)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonUp_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("42f651df-8829-43e7-8d11-333e64c7f17e", "GUI_Button", Relay_OnButtonUp_9)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonClicked_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("42f651df-8829-43e7-8d11-333e64c7f17e", "GUI_Button", Relay_OnButtonClicked_9)) return; 
         Relay_SendCustomEvent_36();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("42f651df-8829-43e7-8d11-333e64c7f17e", "GUI_Button", Relay_In_9)) return; 
         {
            {
               logic_uScriptAct_GUIButton_Text_9 = local_15_System_String;
               
            }
            {
            }
            {
               logic_uScriptAct_GUIButton_Position_9 = local_8_UnityEngine_Rect;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_GUIButton_uScriptAct_GUIButton_9.In(logic_uScriptAct_GUIButton_Text_9, logic_uScriptAct_GUIButton_identifier_9, logic_uScriptAct_GUIButton_Position_9, logic_uScriptAct_GUIButton_Texture_9, logic_uScriptAct_GUIButton_ToolTip_9, logic_uScriptAct_GUIButton_guiStyle_9);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUIButton_uScriptAct_GUIButton_9.Out;
         
         if ( test_0 == true )
         {
            Relay_In_10();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonDown_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3b561381-83f6-4e7e-af43-79a13065e583", "GUI_Button", Relay_OnButtonDown_10)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonHeld_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3b561381-83f6-4e7e-af43-79a13065e583", "GUI_Button", Relay_OnButtonHeld_10)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonUp_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3b561381-83f6-4e7e-af43-79a13065e583", "GUI_Button", Relay_OnButtonUp_10)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonClicked_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3b561381-83f6-4e7e-af43-79a13065e583", "GUI_Button", Relay_OnButtonClicked_10)) return; 
         Relay_SendCustomEvent_37();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3b561381-83f6-4e7e-af43-79a13065e583", "GUI_Button", Relay_In_10)) return; 
         {
            {
               logic_uScriptAct_GUIButton_Text_10 = local_16_System_String;
               
            }
            {
            }
            {
               logic_uScriptAct_GUIButton_Position_10 = local_11_UnityEngine_Rect;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_GUIButton_uScriptAct_GUIButton_10.In(logic_uScriptAct_GUIButton_Text_10, logic_uScriptAct_GUIButton_identifier_10, logic_uScriptAct_GUIButton_Position_10, logic_uScriptAct_GUIButton_Texture_10, logic_uScriptAct_GUIButton_ToolTip_10, logic_uScriptAct_GUIButton_guiStyle_10);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUIButton_uScriptAct_GUIButton_10.Out;
         
         if ( test_0 == true )
         {
            Relay_In_12();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_12()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("52d5cf8c-1389-4ebf-b017-600a8334d984", "GUI_End_Group", Relay_In_12)) return; 
         {
         }
         logic_uScriptAct_GUIEndGroup_uScriptAct_GUIEndGroup_12.In();
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at GUI End Group.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_SendCustomEvent_13()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("15a32514-b759-415f-a661-c3f6f7f99225", "Send_Custom_Event__String_", Relay_SendCustomEvent_13)) return; 
         {
            {
            }
            {
               logic_uScriptAct_SendCustomEventString_EventValue_13 = local_14_System_String;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SendCustomEventString_uScriptAct_SendCustomEventString_13.SendCustomEvent(logic_uScriptAct_SendCustomEventString_EventName_13, logic_uScriptAct_SendCustomEventString_EventValue_13, logic_uScriptAct_SendCustomEventString_sendGroup_13, logic_uScriptAct_SendCustomEventString_EventSender_13);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SendCustomEventString_uScriptAct_SendCustomEventString_13.Out;
         
         if ( test_0 == true )
         {
            Relay_In_32();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at Send Custom Event (String).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnUpdate_18()
   {
      if (true == CheckDebugBreak("6f411169-b787-4ba5-8dff-9c129355d01b", "Global_Update", Relay_OnUpdate_18)) return; 
      Relay_Filter_19();
   }
   
   void Relay_OnLateUpdate_18()
   {
      if (true == CheckDebugBreak("6f411169-b787-4ba5-8dff-9c129355d01b", "Global_Update", Relay_OnLateUpdate_18)) return; 
   }
   
   void Relay_OnFixedUpdate_18()
   {
      if (true == CheckDebugBreak("6f411169-b787-4ba5-8dff-9c129355d01b", "Global_Update", Relay_OnFixedUpdate_18)) return; 
   }
   
   void Relay_Reset_19()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("07cb7dc7-127e-429c-8b73-a68849028c77", "Filter_Rect", Relay_Reset_19)) return; 
         {
            {
               logic_uScriptAct_FilterRect_Target_19 = local_Target_Rect_UnityEngine_Rect;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_FilterRect_uScriptAct_FilterRect_19.Reset(logic_uScriptAct_FilterRect_Target_19, logic_uScriptAct_FilterRect_FilterConstant_19, out logic_uScriptAct_FilterRect_Value_19);
         local_Filtered_Rect_UnityEngine_Rect = logic_uScriptAct_FilterRect_Value_19;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at Filter Rect.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Filter_19()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("07cb7dc7-127e-429c-8b73-a68849028c77", "Filter_Rect", Relay_Filter_19)) return; 
         {
            {
               logic_uScriptAct_FilterRect_Target_19 = local_Target_Rect_UnityEngine_Rect;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_FilterRect_uScriptAct_FilterRect_19.Filter(logic_uScriptAct_FilterRect_Target_19, logic_uScriptAct_FilterRect_FilterConstant_19, out logic_uScriptAct_FilterRect_Value_19);
         local_Filtered_Rect_UnityEngine_Rect = logic_uScriptAct_FilterRect_Value_19;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at Filter Rect.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnCustomEventString_22()
   {
      if (true == CheckDebugBreak("1d6d4a07-bce2-4eea-a953-a8478cc30661", "Custom_Event__String_", Relay_OnCustomEventString_22)) return; 
      local_23_System_String = event_UnityEngine_GameObject_EventName_22;
      local_24_System_String = event_UnityEngine_GameObject_EventData_22;
      Relay_In_26();
   }
   
   void Relay_In_25()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("759827d3-d770-4b3d-bc8c-57687f83fafc", "Compare_String", Relay_In_25)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_25 = local_24_System_String;
               
            }
            {
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_25.In(logic_uScriptCon_CompareString_A_25, logic_uScriptCon_CompareString_B_25);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_25.Same;
         bool test_1 = logic_uScriptCon_CompareString_uScriptCon_CompareString_25.Different;
         
         if ( test_0 == true )
         {
            Relay_In_28();
         }
         if ( test_1 == true )
         {
            Relay_In_27();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_26()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("aac8d650-712b-4248-b513-14bcd5c7ce29", "Compare_String", Relay_In_26)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_26 = local_23_System_String;
               
            }
            {
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_26.In(logic_uScriptCon_CompareString_A_26, logic_uScriptCon_CompareString_B_26);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_26.Same;
         
         if ( test_0 == true )
         {
            Relay_In_25();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_27()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3c580e06-e6f8-410b-8b86-cf9065c2256c", "Compare_String", Relay_In_27)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_27 = local_24_System_String;
               
            }
            {
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_27.In(logic_uScriptCon_CompareString_A_27, logic_uScriptCon_CompareString_B_27);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_27.Same;
         
         if ( test_0 == true )
         {
            Relay_In_28();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_28()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c8f331db-f880-48f3-92d0-08aced7c34c8", "Create_Relative_Rect__Screen_", Relay_In_28)) return; 
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
         logic_uScriptAct_CreateRelativeRectScreen_uScriptAct_CreateRelativeRectScreen_28.In(logic_uScriptAct_CreateRelativeRectScreen_RectWidth_28, logic_uScriptAct_CreateRelativeRectScreen_RectHeight_28, logic_uScriptAct_CreateRelativeRectScreen_RectPosition_28, logic_uScriptAct_CreateRelativeRectScreen_xOffset_28, logic_uScriptAct_CreateRelativeRectScreen_yOffset_28, out logic_uScriptAct_CreateRelativeRectScreen_OutputRect_28);
         local_Target_Rect_UnityEngine_Rect = logic_uScriptAct_CreateRelativeRectScreen_OutputRect_28;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at Create Relative Rect (Screen).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_31()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5fb6cde5-73e0-43eb-8316-554b7ce4ae39", "Set_Components__Rect_", Relay_In_31)) return; 
         {
            {
            }
            {
               logic_uScriptAct_SetComponentsRect_Top_31 = local_33_System_Single;
               
            }
            {
               logic_uScriptAct_SetComponentsRect_Width_31 = local_34_System_Single;
               
            }
            {
               logic_uScriptAct_SetComponentsRect_Height_31 = local_35_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_SetComponentsRect_uScriptAct_SetComponentsRect_31.In(logic_uScriptAct_SetComponentsRect_Left_31, logic_uScriptAct_SetComponentsRect_Top_31, logic_uScriptAct_SetComponentsRect_Width_31, logic_uScriptAct_SetComponentsRect_Height_31, out logic_uScriptAct_SetComponentsRect_OutputRect_31);
         local_Target_Rect_UnityEngine_Rect = logic_uScriptAct_SetComponentsRect_OutputRect_31;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at Set Components (Rect).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_32()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a5aa1bd2-e5ef-4bf7-9d6c-2fb54cb12851", "Get_Components__Rect_", Relay_In_32)) return; 
         {
            {
               logic_uScriptAct_GetComponentsRect_InputRect_32 = local_Target_Rect_UnityEngine_Rect;
               
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
         logic_uScriptAct_GetComponentsRect_uScriptAct_GetComponentsRect_32.In(logic_uScriptAct_GetComponentsRect_InputRect_32, out logic_uScriptAct_GetComponentsRect_Left_32, out logic_uScriptAct_GetComponentsRect_Top_32, out logic_uScriptAct_GetComponentsRect_Width_32, out logic_uScriptAct_GetComponentsRect_Height_32);
         local_33_System_Single = logic_uScriptAct_GetComponentsRect_Top_32;
         local_34_System_Single = logic_uScriptAct_GetComponentsRect_Width_32;
         local_35_System_Single = logic_uScriptAct_GetComponentsRect_Height_32;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetComponentsRect_uScriptAct_GetComponentsRect_32.Out;
         
         if ( test_0 == true )
         {
            Relay_In_31();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at Get Components (Rect).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_SendCustomEvent_36()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2cf2b616-3c4e-454f-baf1-420cf4870422", "Send_Custom_Event__String_", Relay_SendCustomEvent_36)) return; 
         {
            {
            }
            {
               logic_uScriptAct_SendCustomEventString_EventValue_36 = local_15_System_String;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SendCustomEventString_uScriptAct_SendCustomEventString_36.SendCustomEvent(logic_uScriptAct_SendCustomEventString_EventName_36, logic_uScriptAct_SendCustomEventString_EventValue_36, logic_uScriptAct_SendCustomEventString_sendGroup_36, logic_uScriptAct_SendCustomEventString_EventSender_36);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SendCustomEventString_uScriptAct_SendCustomEventString_36.Out;
         
         if ( test_0 == true )
         {
            Relay_In_32();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at Send Custom Event (String).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_SendCustomEvent_37()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5b11dbbf-f265-4317-b3ea-c36357feee52", "Send_Custom_Event__String_", Relay_SendCustomEvent_37)) return; 
         {
            {
            }
            {
               logic_uScriptAct_SendCustomEventString_EventValue_37 = local_16_System_String;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SendCustomEventString_uScriptAct_SendCustomEventString_37.SendCustomEvent(logic_uScriptAct_SendCustomEventString_EventName_37, logic_uScriptAct_SendCustomEventString_EventValue_37, logic_uScriptAct_SendCustomEventString_sendGroup_37, logic_uScriptAct_SendCustomEventString_EventSender_37);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SendCustomEventString_uScriptAct_SendCustomEventString_37.Out;
         
         if ( test_0 == true )
         {
            Relay_In_32();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_MainMenu.uscript at Send Custom Event (String).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_MainMenu.uscript:0", local_0_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "907cf769-7d4f-41cb-b344-41fb5b36d17d", local_0_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_MainMenu.uscript:8", local_8_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "972e8b1d-c359-4ce4-b539-5cdd38647cd2", local_8_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_MainMenu.uscript:11", local_11_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b6b56357-42a2-4daa-affd-f8db9ed8e883", local_11_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_MainMenu.uscript:14", local_14_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "283d9abb-fe24-4a35-81ba-b5126070baac", local_14_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_MainMenu.uscript:15", local_15_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ad92e525-6e47-40c8-a433-faec354a299d", local_15_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_MainMenu.uscript:16", local_16_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ff4ec241-4417-4230-b8ae-68c41d09311f", local_16_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_MainMenu.uscript:Filtered Rect", local_Filtered_Rect_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c98ee999-5487-4103-a887-6231475c32c1", local_Filtered_Rect_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_MainMenu.uscript:23", local_23_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d5a5c1b8-856d-402c-8e9f-5a6d7cbce250", local_23_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_MainMenu.uscript:24", local_24_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "eb1ca6d6-9f7a-428c-a03a-76b29f4a7aa8", local_24_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_MainMenu.uscript:Target Rect", local_Target_Rect_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "3c7508d3-7e64-4a96-9db7-11b6752b469a", local_Target_Rect_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_MainMenu.uscript:33", local_33_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "438422a4-edae-45fd-be66-29c83ad10b5a", local_33_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_MainMenu.uscript:34", local_34_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "6f706e05-64c3-4dfa-b35d-ad035d7b3ce7", local_34_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_MainMenu.uscript:35", local_35_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "e6cb565f-fdc0-4f37-b86c-e7f907396952", local_35_System_Single);
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
