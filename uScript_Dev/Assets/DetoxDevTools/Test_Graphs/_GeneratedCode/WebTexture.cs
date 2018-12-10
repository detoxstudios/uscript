//uScript Generated Code - Build 1.0.3109
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class WebTexture : uScriptLogic
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
   System.String local_21_System_String = "http://www.uscript.net/files/test/texture.png";
   System.String local_22_System_String = "Download";
   System.String local_URL_System_String = "";
   System.String local_WWW_Error_System_String = "";
   UnityEngine.Texture2D local_WWW_Texture_UnityEngine_Texture2D = default(UnityEngine.Texture2D);
   System.String local_wwwStatus_System_String = "";
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_GUILabel logic_uScriptAct_GUILabel_uScriptAct_GUILabel_1 = new uScriptAct_GUILabel( );
   System.String logic_uScriptAct_GUILabel_Text_1 = "";
   UnityEngine.Rect logic_uScriptAct_GUILabel_Position_1 = new Rect( (float)15, (float)70, (float)700, (float)25 );
   UnityEngine.Texture logic_uScriptAct_GUILabel_Texture_1 = default(UnityEngine.Texture);
   System.String logic_uScriptAct_GUILabel_ToolTip_1 = "";
   System.String logic_uScriptAct_GUILabel_guiStyle_1 = "";
   bool logic_uScriptAct_GUILabel_Out_1 = true;
   //pointer to script instanced logic node
   uScriptAct_GUIButton logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2 = new uScriptAct_GUIButton( );
   System.String logic_uScriptAct_GUIButton_Text_2 = "";
   System.Int32 logic_uScriptAct_GUIButton_identifier_2 = (int) 0;
   UnityEngine.Rect logic_uScriptAct_GUIButton_Position_2 = new Rect( (float)10, (float)40, (float)80, (float)20 );
   UnityEngine.Texture2D logic_uScriptAct_GUIButton_Texture_2 = default(UnityEngine.Texture2D);
   System.String logic_uScriptAct_GUIButton_ToolTip_2 = "";
   System.String logic_uScriptAct_GUIButton_guiStyle_2 = "";
   bool logic_uScriptAct_GUIButton_Out_2 = true;
   //pointer to script instanced logic node
   uScriptAct_SetString logic_uScriptAct_SetString_uScriptAct_SetString_3 = new uScriptAct_SetString( );
   System.String logic_uScriptAct_SetString_Value_3 = "Requesting data ...";
   System.Boolean logic_uScriptAct_SetString_ToUpperCase_3 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_ToLowerCase_3 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_TrimWhitespace_3 = (bool) false;
   System.String logic_uScriptAct_SetString_Target_3;
   bool logic_uScriptAct_SetString_Out_3 = true;
   //pointer to script instanced logic node
   uScriptAct_GUITextField logic_uScriptAct_GUITextField_uScriptAct_GUITextField_4 = new uScriptAct_GUITextField( );
   System.String logic_uScriptAct_GUITextField_Value_4 = "";
   UnityEngine.Rect logic_uScriptAct_GUITextField_Position_4 = new Rect( (float)100, (float)40, (float)610, (float)20 );
   System.Int32 logic_uScriptAct_GUITextField_maxLength_4 = (int) -1;
   System.String logic_uScriptAct_GUITextField_ControlName_4 = "";
   System.String logic_uScriptAct_GUITextField_guiStyle_4 = "";
   bool logic_uScriptAct_GUITextField_Out_4 = true;
   bool logic_uScriptAct_GUITextField_Changed_4 = true;
   //pointer to script instanced logic node
   uScriptAct_SetString logic_uScriptAct_SetString_uScriptAct_SetString_5 = new uScriptAct_SetString( );
   System.String logic_uScriptAct_SetString_Value_5 = "";
   System.Boolean logic_uScriptAct_SetString_ToUpperCase_5 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_ToLowerCase_5 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_TrimWhitespace_5 = (bool) false;
   System.String logic_uScriptAct_SetString_Target_5;
   bool logic_uScriptAct_SetString_Out_5 = true;
   //pointer to script instanced logic node
   uScriptAct_SetString logic_uScriptAct_SetString_uScriptAct_SetString_6 = new uScriptAct_SetString( );
   System.String logic_uScriptAct_SetString_Value_6 = "Finished downloading data.";
   System.Boolean logic_uScriptAct_SetString_ToUpperCase_6 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_ToLowerCase_6 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_TrimWhitespace_6 = (bool) false;
   System.String logic_uScriptAct_SetString_Target_6;
   bool logic_uScriptAct_SetString_Out_6 = true;
   //pointer to script instanced logic node
   uScriptAct_SetString logic_uScriptAct_SetString_uScriptAct_SetString_7 = new uScriptAct_SetString( );
   System.String logic_uScriptAct_SetString_Value_7 = "";
   System.Boolean logic_uScriptAct_SetString_ToUpperCase_7 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_ToLowerCase_7 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_TrimWhitespace_7 = (bool) false;
   System.String logic_uScriptAct_SetString_Target_7;
   bool logic_uScriptAct_SetString_Out_7 = true;
   //pointer to script instanced logic node
   uScriptAct_WebTexture logic_uScriptAct_WebTexture_uScriptAct_WebTexture_8 = new uScriptAct_WebTexture( );
   System.String logic_uScriptAct_WebTexture_URL_8 = "";
   UnityEngine.WWWForm logic_uScriptAct_WebTexture_Form_8 = default(UnityEngine.WWWForm);
   UnityEngine.Texture2D logic_uScriptAct_WebTexture_Result_8;
   System.String logic_uScriptAct_WebTexture_Error_8;
   bool logic_uScriptAct_WebTexture_Out_8 = true;
   bool logic_uScriptAct_WebTexture_OutFinished_8 = true;
   bool logic_uScriptAct_WebTexture_OutError_8 = true;
   bool logic_uScriptAct_WebTexture_Driven_8 = false;
   //pointer to script instanced logic node
   uScriptAct_GUILabel logic_uScriptAct_GUILabel_uScriptAct_GUILabel_11 = new uScriptAct_GUILabel( );
   System.String logic_uScriptAct_GUILabel_Text_11 = "";
   UnityEngine.Rect logic_uScriptAct_GUILabel_Position_11 = new Rect( (float)10, (float)100, (float)700, (float)400 );
   UnityEngine.Texture logic_uScriptAct_GUILabel_Texture_11 = default(UnityEngine.Texture);
   System.String logic_uScriptAct_GUILabel_ToolTip_11 = "";
   System.String logic_uScriptAct_GUILabel_guiStyle_11 = "";
   bool logic_uScriptAct_GUILabel_Out_11 = true;
   
   //event nodes
   System.Boolean event_UnityEngine_GameObject_GUIChanged_0 = (bool) false;
   System.String event_UnityEngine_GameObject_FocusedControl_0 = "";
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_0 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_14 = default(UnityEngine.GameObject);
   
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
      if ( null == event_UnityEngine_GameObject_Instance_14 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_14 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_14 )
         {
            {
               uScript_Global component = event_UnityEngine_GameObject_Instance_14.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_14.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_14;
                  component.uScriptLateStart += Instance_uScriptLateStart_14;
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
      if ( null != event_UnityEngine_GameObject_Instance_14 )
      {
         {
            uScript_Global component = event_UnityEngine_GameObject_Instance_14.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_14;
               component.uScriptLateStart -= Instance_uScriptLateStart_14;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_GUILabel_uScriptAct_GUILabel_1.SetParent(g);
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2.SetParent(g);
      logic_uScriptAct_SetString_uScriptAct_SetString_3.SetParent(g);
      logic_uScriptAct_GUITextField_uScriptAct_GUITextField_4.SetParent(g);
      logic_uScriptAct_SetString_uScriptAct_SetString_5.SetParent(g);
      logic_uScriptAct_SetString_uScriptAct_SetString_6.SetParent(g);
      logic_uScriptAct_SetString_uScriptAct_SetString_7.SetParent(g);
      logic_uScriptAct_WebTexture_uScriptAct_WebTexture_8.SetParent(g);
      logic_uScriptAct_GUILabel_uScriptAct_GUILabel_11.SetParent(g);
   }
   public void Awake()
   {
      
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2.OnButtonDown += uScriptAct_GUIButton_OnButtonDown_2;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2.OnButtonHeld += uScriptAct_GUIButton_OnButtonHeld_2;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2.OnButtonUp += uScriptAct_GUIButton_OnButtonUp_2;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2.OnButtonClicked += uScriptAct_GUIButton_OnButtonClicked_2;
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
      
      if (true == logic_uScriptAct_WebTexture_Driven_8)
      {
         Relay_Driven_8();
      }
   }
   
   public void OnDestroy()
   {
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2.OnButtonDown -= uScriptAct_GUIButton_OnButtonDown_2;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2.OnButtonHeld -= uScriptAct_GUIButton_OnButtonHeld_2;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2.OnButtonUp -= uScriptAct_GUIButton_OnButtonUp_2;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_2.OnButtonClicked -= uScriptAct_GUIButton_OnButtonClicked_2;
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
   
   void Instance_uScriptStart_14(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_14( );
   }
   
   void Instance_uScriptLateStart_14(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptLateStart_14( );
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
   
   void Relay_OnGui_0()
   {
      if (true == CheckDebugBreak("41f92a5b-34c7-4b9d-bd60-46382eb9dd97", "GUI_Events", Relay_OnGui_0)) return; 
      Relay_In_2();
   }
   
   void Relay_In_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("10249a6d-2195-4def-8862-67a9bd4564bb", "GUI_Label", Relay_In_1)) return; 
         {
            {
               logic_uScriptAct_GUILabel_Text_1 = local_wwwStatus_System_String;
               
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
         logic_uScriptAct_GUILabel_uScriptAct_GUILabel_1.In(logic_uScriptAct_GUILabel_Text_1, logic_uScriptAct_GUILabel_Position_1, logic_uScriptAct_GUILabel_Texture_1, logic_uScriptAct_GUILabel_ToolTip_1, logic_uScriptAct_GUILabel_guiStyle_1);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUILabel_uScriptAct_GUILabel_1.Out;
         
         if ( test_0 == true )
         {
            Relay_In_11();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTexture.uscript at GUI Label.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonDown_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4acb7d8e-f127-48de-b062-b6e4bb35715d", "GUI_Button", Relay_OnButtonDown_2)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTexture.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonHeld_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4acb7d8e-f127-48de-b062-b6e4bb35715d", "GUI_Button", Relay_OnButtonHeld_2)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTexture.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonUp_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4acb7d8e-f127-48de-b062-b6e4bb35715d", "GUI_Button", Relay_OnButtonUp_2)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTexture.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonClicked_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4acb7d8e-f127-48de-b062-b6e4bb35715d", "GUI_Button", Relay_OnButtonClicked_2)) return; 
         Relay_In_8();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTexture.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4acb7d8e-f127-48de-b062-b6e4bb35715d", "GUI_Button", Relay_In_2)) return; 
         {
            {
               logic_uScriptAct_GUIButton_Text_2 = local_22_System_String;
               
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
            Relay_In_4();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTexture.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0848e806-0fd8-4212-8cec-9af2ef9b75c3", "Set_String", Relay_In_3)) return; 
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
         logic_uScriptAct_SetString_uScriptAct_SetString_3.In(logic_uScriptAct_SetString_Value_3, logic_uScriptAct_SetString_ToUpperCase_3, logic_uScriptAct_SetString_ToLowerCase_3, logic_uScriptAct_SetString_TrimWhitespace_3, out logic_uScriptAct_SetString_Target_3);
         local_wwwStatus_System_String = logic_uScriptAct_SetString_Target_3;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTexture.uscript at Set String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_4()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8e6e13a7-9a23-4bde-9699-778b4dc054a3", "GUI_Text_Field", Relay_In_4)) return; 
         {
            {
               logic_uScriptAct_GUITextField_Value_4 = local_URL_System_String;
               
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
         logic_uScriptAct_GUITextField_uScriptAct_GUITextField_4.In(ref logic_uScriptAct_GUITextField_Value_4, logic_uScriptAct_GUITextField_Position_4, logic_uScriptAct_GUITextField_maxLength_4, logic_uScriptAct_GUITextField_ControlName_4, logic_uScriptAct_GUITextField_guiStyle_4);
         local_URL_System_String = logic_uScriptAct_GUITextField_Value_4;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUITextField_uScriptAct_GUITextField_4.Out;
         
         if ( test_0 == true )
         {
            Relay_In_1();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTexture.uscript at GUI Text Field.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a879c713-af48-4cfc-b6b4-d3f6444412ee", "Set_String", Relay_In_5)) return; 
         {
            {
               logic_uScriptAct_SetString_Value_5 = local_21_System_String;
               
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
         logic_uScriptAct_SetString_uScriptAct_SetString_5.In(logic_uScriptAct_SetString_Value_5, logic_uScriptAct_SetString_ToUpperCase_5, logic_uScriptAct_SetString_ToLowerCase_5, logic_uScriptAct_SetString_TrimWhitespace_5, out logic_uScriptAct_SetString_Target_5);
         local_URL_System_String = logic_uScriptAct_SetString_Target_5;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTexture.uscript at Set String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3578c7cb-ec1a-4d3f-aa14-4b4c56805b60", "Set_String", Relay_In_6)) return; 
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
         logic_uScriptAct_SetString_uScriptAct_SetString_6.In(logic_uScriptAct_SetString_Value_6, logic_uScriptAct_SetString_ToUpperCase_6, logic_uScriptAct_SetString_ToLowerCase_6, logic_uScriptAct_SetString_TrimWhitespace_6, out logic_uScriptAct_SetString_Target_6);
         local_wwwStatus_System_String = logic_uScriptAct_SetString_Target_6;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTexture.uscript at Set String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d4942041-725f-48b6-91cc-a4061343f559", "Set_String", Relay_In_7)) return; 
         {
            {
               logic_uScriptAct_SetString_Value_7 = local_WWW_Error_System_String;
               
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
         logic_uScriptAct_SetString_uScriptAct_SetString_7.In(logic_uScriptAct_SetString_Value_7, logic_uScriptAct_SetString_ToUpperCase_7, logic_uScriptAct_SetString_ToLowerCase_7, logic_uScriptAct_SetString_TrimWhitespace_7, out logic_uScriptAct_SetString_Target_7);
         local_wwwStatus_System_String = logic_uScriptAct_SetString_Target_7;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTexture.uscript at Set String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_8()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ba49a3b6-ed74-4e0e-a1a3-ae5e960fcfec", "Web_Texture", Relay_In_8)) return; 
         {
            {
               logic_uScriptAct_WebTexture_URL_8 = local_URL_System_String;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_WebTexture_uScriptAct_WebTexture_8.In(logic_uScriptAct_WebTexture_URL_8, logic_uScriptAct_WebTexture_Form_8, out logic_uScriptAct_WebTexture_Result_8, out logic_uScriptAct_WebTexture_Error_8);
         logic_uScriptAct_WebTexture_Driven_8 = true;
         local_WWW_Texture_UnityEngine_Texture2D = logic_uScriptAct_WebTexture_Result_8;
         local_WWW_Error_System_String = logic_uScriptAct_WebTexture_Error_8;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_WebTexture_uScriptAct_WebTexture_8.Out;
         bool test_1 = logic_uScriptAct_WebTexture_uScriptAct_WebTexture_8.OutFinished;
         bool test_2 = logic_uScriptAct_WebTexture_uScriptAct_WebTexture_8.OutError;
         
         if ( test_0 == true )
         {
            Relay_In_3();
         }
         if ( test_1 == true )
         {
            Relay_In_6();
         }
         if ( test_2 == true )
         {
            Relay_In_7();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTexture.uscript at Web Texture.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Driven_8( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               logic_uScriptAct_WebTexture_URL_8 = local_URL_System_String;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_WebTexture_Driven_8 = logic_uScriptAct_WebTexture_uScriptAct_WebTexture_8.Driven(out logic_uScriptAct_WebTexture_Result_8, out logic_uScriptAct_WebTexture_Error_8);
         if ( true == logic_uScriptAct_WebTexture_Driven_8 )
         {
            local_WWW_Texture_UnityEngine_Texture2D = logic_uScriptAct_WebTexture_Result_8;
            local_WWW_Error_System_String = logic_uScriptAct_WebTexture_Error_8;
            if ( logic_uScriptAct_WebTexture_uScriptAct_WebTexture_8.Out == true )
            {
               Relay_In_3();
            }
            if ( logic_uScriptAct_WebTexture_uScriptAct_WebTexture_8.OutFinished == true )
            {
               Relay_In_6();
            }
            if ( logic_uScriptAct_WebTexture_uScriptAct_WebTexture_8.OutError == true )
            {
               Relay_In_7();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTexture.uscript at Web Texture.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_In_11()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("cc884cf9-419a-47ee-b9a1-75b02df1b5f7", "GUI_Label", Relay_In_11)) return; 
         {
            {
            }
            {
            }
            {
               logic_uScriptAct_GUILabel_Texture_11 = local_WWW_Texture_UnityEngine_Texture2D;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_GUILabel_uScriptAct_GUILabel_11.In(logic_uScriptAct_GUILabel_Text_11, logic_uScriptAct_GUILabel_Position_11, logic_uScriptAct_GUILabel_Texture_11, logic_uScriptAct_GUILabel_ToolTip_11, logic_uScriptAct_GUILabel_guiStyle_11);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTexture.uscript at GUI Label.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_uScriptStart_14()
   {
      if (true == CheckDebugBreak("2e250385-7c29-421f-8b98-5e26b9da1276", "uScript_Events", Relay_uScriptStart_14)) return; 
      Relay_In_5();
   }
   
   void Relay_uScriptLateStart_14()
   {
      if (true == CheckDebugBreak("2e250385-7c29-421f-8b98-5e26b9da1276", "uScript_Events", Relay_uScriptLateStart_14)) return; 
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "WebTexture.uscript:WWW Texture", local_WWW_Texture_UnityEngine_Texture2D);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "e7829ab1-95a0-43e3-ab6c-996741b2bbd3", local_WWW_Texture_UnityEngine_Texture2D);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "WebTexture.uscript:WWW Error", local_WWW_Error_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "097a95fc-f064-4271-9b3e-a5dd86960366", local_WWW_Error_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "WebTexture.uscript:URL", local_URL_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "542bf422-64cf-431f-a34b-23bca96c6e94", local_URL_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "WebTexture.uscript:wwwStatus", local_wwwStatus_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "582cd476-7588-41b4-892b-1ba64661dede", local_wwwStatus_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "WebTexture.uscript:21", local_21_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "6cacabd0-3ef0-451a-980c-5d84825a9537", local_21_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "WebTexture.uscript:22", local_22_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d8966bac-6d4b-412d-9576-c9973edfce61", local_22_System_String);
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
