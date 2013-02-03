//uScript Generated Code - Build 0.9.2215
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class WebTextExample : uScriptLogic
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
   System.String local_29_System_String = "";
   System.String local_32_System_String = "";
   System.String local_33_System_String = "";
   System.String local_72_System_String = "http://www.uscript.net/files/test/request.php";
   System.String local_74_System_String = "Submit";
   System.Boolean local_toggleValue_System_Boolean = (bool) false;
   System.String local_URL_System_String = "";
   System.String local_usernameValue_System_String = "";
   System.String local_WWW_Error_System_String = "";
   UnityEngine.WWWForm local_WWW_Form_UnityEngine_WWWForm = null;
   System.Int32 local_WWW_Method_System_Int32 = (int) 0;
   System.String local_WWW_Text_System_String = "";
   System.String local_wwwStatus_System_String = "";
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_GUITextArea logic_uScriptAct_GUITextArea_uScriptAct_GUITextArea_0 = new uScriptAct_GUITextArea( );
   System.String logic_uScriptAct_GUITextArea_Value_0 = "";
   UnityEngine.Rect logic_uScriptAct_GUITextArea_Position_0 = new Rect( (float)10, (float)100, (float)700, (float)400 );
   System.Int32 logic_uScriptAct_GUITextArea_maxLength_0 = (int) -1;
   System.String logic_uScriptAct_GUITextArea_ControlName_0 = "";
   System.String logic_uScriptAct_GUITextArea_guiStyle_0 = "";
   bool logic_uScriptAct_GUITextArea_Out_0 = true;
   bool logic_uScriptAct_GUITextArea_Changed_0 = true;
   //pointer to script instanced logic node
   uScriptAct_GUILabel logic_uScriptAct_GUILabel_uScriptAct_GUILabel_2 = new uScriptAct_GUILabel( );
   System.String logic_uScriptAct_GUILabel_Text_2 = "";
   UnityEngine.Rect logic_uScriptAct_GUILabel_Position_2 = new Rect( (float)15, (float)70, (float)700, (float)25 );
   UnityEngine.Texture logic_uScriptAct_GUILabel_Texture_2 = null;
   System.String logic_uScriptAct_GUILabel_ToolTip_2 = "";
   System.String logic_uScriptAct_GUILabel_guiStyle_2 = "";
   bool logic_uScriptAct_GUILabel_Out_2 = true;
   //pointer to script instanced logic node
   uScriptAct_GUIButton logic_uScriptAct_GUIButton_uScriptAct_GUIButton_3 = new uScriptAct_GUIButton( );
   System.String logic_uScriptAct_GUIButton_Text_3 = "";
   System.Int32 logic_uScriptAct_GUIButton_identifier_3 = (int) 0;
   UnityEngine.Rect logic_uScriptAct_GUIButton_Position_3 = new Rect( (float)10, (float)40, (float)80, (float)20 );
   UnityEngine.Texture2D logic_uScriptAct_GUIButton_Texture_3 = null;
   System.String logic_uScriptAct_GUIButton_ToolTip_3 = "";
   System.String logic_uScriptAct_GUIButton_guiStyle_3 = "";
   bool logic_uScriptAct_GUIButton_Out_3 = true;
   //pointer to script instanced logic node
   uScriptAct_SetString logic_uScriptAct_SetString_uScriptAct_SetString_4 = new uScriptAct_SetString( );
   System.String logic_uScriptAct_SetString_Value_4 = "Requesting data ...";
   System.Boolean logic_uScriptAct_SetString_ToUpperCase_4 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_ToLowerCase_4 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_TrimWhitespace_4 = (bool) false;
   System.String logic_uScriptAct_SetString_Target_4;
   bool logic_uScriptAct_SetString_Out_4 = true;
   //pointer to script instanced logic node
   uScriptAct_GUITextField logic_uScriptAct_GUITextField_uScriptAct_GUITextField_5 = new uScriptAct_GUITextField( );
   System.String logic_uScriptAct_GUITextField_Value_5 = "";
   UnityEngine.Rect logic_uScriptAct_GUITextField_Position_5 = new Rect( (float)100, (float)40, (float)610, (float)20 );
   System.Int32 logic_uScriptAct_GUITextField_maxLength_5 = (int) -1;
   System.String logic_uScriptAct_GUITextField_ControlName_5 = "";
   System.String logic_uScriptAct_GUITextField_guiStyle_5 = "";
   bool logic_uScriptAct_GUITextField_Out_5 = true;
   bool logic_uScriptAct_GUITextField_Changed_5 = true;
   //pointer to script instanced logic node
   uScriptAct_SetString logic_uScriptAct_SetString_uScriptAct_SetString_6 = new uScriptAct_SetString( );
   System.String logic_uScriptAct_SetString_Value_6 = "";
   System.Boolean logic_uScriptAct_SetString_ToUpperCase_6 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_ToLowerCase_6 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_TrimWhitespace_6 = (bool) false;
   System.String logic_uScriptAct_SetString_Target_6;
   bool logic_uScriptAct_SetString_Out_6 = true;
   //pointer to script instanced logic node
   uScriptAct_SetString logic_uScriptAct_SetString_uScriptAct_SetString_8 = new uScriptAct_SetString( );
   System.String logic_uScriptAct_SetString_Value_8 = "Finished downloading data.";
   System.Boolean logic_uScriptAct_SetString_ToUpperCase_8 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_ToLowerCase_8 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_TrimWhitespace_8 = (bool) false;
   System.String logic_uScriptAct_SetString_Target_8;
   bool logic_uScriptAct_SetString_Out_8 = true;
   //pointer to script instanced logic node
   uScriptAct_SetString logic_uScriptAct_SetString_uScriptAct_SetString_9 = new uScriptAct_SetString( );
   System.String logic_uScriptAct_SetString_Value_9 = "";
   System.Boolean logic_uScriptAct_SetString_ToUpperCase_9 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_ToLowerCase_9 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_TrimWhitespace_9 = (bool) false;
   System.String logic_uScriptAct_SetString_Target_9;
   bool logic_uScriptAct_SetString_Out_9 = true;
   //pointer to script instanced logic node
   uScriptAct_SetString logic_uScriptAct_SetString_uScriptAct_SetString_10 = new uScriptAct_SetString( );
   System.String logic_uScriptAct_SetString_Value_10 = "";
   System.Boolean logic_uScriptAct_SetString_ToUpperCase_10 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_ToLowerCase_10 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_TrimWhitespace_10 = (bool) false;
   System.String logic_uScriptAct_SetString_Target_10;
   bool logic_uScriptAct_SetString_Out_10 = true;
   //pointer to script instanced logic node
   uScriptAct_WebText logic_uScriptAct_WebText_uScriptAct_WebText_12 = new uScriptAct_WebText( );
   System.String logic_uScriptAct_WebText_URL_12 = "";
   UnityEngine.WWWForm logic_uScriptAct_WebText_Form_12 = null;
   System.String logic_uScriptAct_WebText_Result_12;
   System.String logic_uScriptAct_WebText_Error_12;
   bool logic_uScriptAct_WebText_Out_12 = true;
   bool logic_uScriptAct_WebText_OutFinished_12 = true;
   bool logic_uScriptAct_WebText_OutError_12 = true;
   bool logic_uScriptAct_WebText_Driven_12 = false;
   //pointer to script instanced logic node
   uScriptAct_GUIToggle logic_uScriptAct_GUIToggle_uScriptAct_GUIToggle_17 = new uScriptAct_GUIToggle( );
   System.Boolean logic_uScriptAct_GUIToggle_Value_17 = (bool) false;
   System.String logic_uScriptAct_GUIToggle_Text_17 = "  toggle";
   UnityEngine.Rect logic_uScriptAct_GUIToggle_Position_17 = new Rect( (float)650, (float)70, (float)60, (float)20 );
   UnityEngine.Texture2D logic_uScriptAct_GUIToggle_Texture_17 = null;
   System.String logic_uScriptAct_GUIToggle_ToolTip_17 = "";
   System.String logic_uScriptAct_GUIToggle_guiStyle_17 = "";
   bool logic_uScriptAct_GUIToggle_Out_17 = true;
   bool logic_uScriptAct_GUIToggle_Changed_17 = true;
   //pointer to script instanced logic node
   uScriptAct_GUITextField logic_uScriptAct_GUITextField_uScriptAct_GUITextField_18 = new uScriptAct_GUITextField( );
   System.String logic_uScriptAct_GUITextField_Value_18 = "";
   UnityEngine.Rect logic_uScriptAct_GUITextField_Position_18 = new Rect( (float)430, (float)70, (float)200, (float)20 );
   System.Int32 logic_uScriptAct_GUITextField_maxLength_18 = (int) 20;
   System.String logic_uScriptAct_GUITextField_ControlName_18 = "";
   System.String logic_uScriptAct_GUITextField_guiStyle_18 = "";
   bool logic_uScriptAct_GUITextField_Out_18 = true;
   bool logic_uScriptAct_GUITextField_Changed_18 = true;
   //pointer to script instanced logic node
   uScriptAct_GUILabel logic_uScriptAct_GUILabel_uScriptAct_GUILabel_19 = new uScriptAct_GUILabel( );
   System.String logic_uScriptAct_GUILabel_Text_19 = "username";
   UnityEngine.Rect logic_uScriptAct_GUILabel_Position_19 = new Rect( (float)365, (float)70, (float)65, (float)20 );
   UnityEngine.Texture logic_uScriptAct_GUILabel_Texture_19 = null;
   System.String logic_uScriptAct_GUILabel_ToolTip_19 = "";
   System.String logic_uScriptAct_GUILabel_guiStyle_19 = "";
   bool logic_uScriptAct_GUILabel_Out_19 = true;
   //pointer to script instanced logic node
   uScriptAct_Concatenate logic_uScriptAct_Concatenate_uScriptAct_Concatenate_21 = new uScriptAct_Concatenate( );
   System.Object[] logic_uScriptAct_Concatenate_A_21 = new System.Object[] {};
   System.Object[] logic_uScriptAct_Concatenate_B_21 = new System.Object[] {};
   System.String logic_uScriptAct_Concatenate_Separator_21 = "username=";
   System.String logic_uScriptAct_Concatenate_Result_21;
   bool logic_uScriptAct_Concatenate_Out_21 = true;
   //pointer to script instanced logic node
   uScriptAct_Concatenate logic_uScriptAct_Concatenate_uScriptAct_Concatenate_22 = new uScriptAct_Concatenate( );
   System.Object[] logic_uScriptAct_Concatenate_A_22 = new System.Object[] {};
   System.Object[] logic_uScriptAct_Concatenate_B_22 = new System.Object[] {};
   System.String logic_uScriptAct_Concatenate_Separator_22 = "toggle=";
   System.String logic_uScriptAct_Concatenate_Result_22;
   bool logic_uScriptAct_Concatenate_Out_22 = true;
   //pointer to script instanced logic node
   uScriptAct_Concatenate logic_uScriptAct_Concatenate_uScriptAct_Concatenate_23 = new uScriptAct_Concatenate( );
   System.Object[] logic_uScriptAct_Concatenate_A_23 = new System.Object[] {};
   System.Object[] logic_uScriptAct_Concatenate_B_23 = new System.Object[] {"&"};
   System.String logic_uScriptAct_Concatenate_Separator_23 = "";
   System.String logic_uScriptAct_Concatenate_Result_23;
   bool logic_uScriptAct_Concatenate_Out_23 = true;
   //pointer to script instanced logic node
   uScriptAct_SetString logic_uScriptAct_SetString_uScriptAct_SetString_27 = new uScriptAct_SetString( );
   System.String logic_uScriptAct_SetString_Value_27 = "http://www.uscript.net/files/test/request.php?";
   System.Boolean logic_uScriptAct_SetString_ToUpperCase_27 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_ToLowerCase_27 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_TrimWhitespace_27 = (bool) false;
   System.String logic_uScriptAct_SetString_Target_27;
   bool logic_uScriptAct_SetString_Out_27 = true;
   //pointer to script instanced logic node
   uScriptAct_EscapeURL logic_uScriptAct_EscapeURL_uScriptAct_EscapeURL_28 = new uScriptAct_EscapeURL( );
   System.String logic_uScriptAct_EscapeURL_Target_28 = "";
   System.String logic_uScriptAct_EscapeURL_Result_28;
   bool logic_uScriptAct_EscapeURL_Out_28 = true;
   //pointer to script instanced logic node
   uScriptAct_EscapeURL logic_uScriptAct_EscapeURL_uScriptAct_EscapeURL_30 = new uScriptAct_EscapeURL( );
   System.String logic_uScriptAct_EscapeURL_Target_30 = "";
   System.String logic_uScriptAct_EscapeURL_Result_30;
   bool logic_uScriptAct_EscapeURL_Out_30 = true;
   //pointer to script instanced logic node
   uScriptAct_ConvertVariable logic_uScriptAct_ConvertVariable_uScriptAct_ConvertVariable_31 = new uScriptAct_ConvertVariable( );
   System.Object logic_uScriptAct_ConvertVariable_Target_31 = "";
   System.Int32 logic_uScriptAct_ConvertVariable_IntValue_31;
   System.Int64 logic_uScriptAct_ConvertVariable_Int64Value_31;
   System.Single logic_uScriptAct_ConvertVariable_FloatValue_31;
   System.String logic_uScriptAct_ConvertVariable_StringValue_31;
   System.Boolean logic_uScriptAct_ConvertVariable_BooleanValue_31;
   UnityEngine.Vector3 logic_uScriptAct_ConvertVariable_Vector3Value_31;
   bool logic_uScriptAct_ConvertVariable_Out_31 = true;
   //pointer to script instanced logic node
   uScriptAct_GUISelectionGrid logic_uScriptAct_GUISelectionGrid_uScriptAct_GUISelectionGrid_34 = new uScriptAct_GUISelectionGrid( );
   System.Int32 logic_uScriptAct_GUISelectionGrid_Value_34 = (int) 0;
   UnityEngine.Rect logic_uScriptAct_GUISelectionGrid_Position_34 = new Rect( (float)230, (float)70, (float)110, (float)20 );
   System.String[] logic_uScriptAct_GUISelectionGrid_Content_34 = new System.String[] {"GET","POST"};
   System.Int32 logic_uScriptAct_GUISelectionGrid_xCount_34 = (int) 2;
   System.String logic_uScriptAct_GUISelectionGrid_guiStyle_34 = "";
   bool logic_uScriptAct_GUISelectionGrid_Out_34 = true;
   bool logic_uScriptAct_GUISelectionGrid_Changed_34 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareInt logic_uScriptCon_CompareInt_uScriptCon_CompareInt_35 = new uScriptCon_CompareInt( );
   System.Int32 logic_uScriptCon_CompareInt_A_35 = (int) 0;
   System.Int32 logic_uScriptCon_CompareInt_B_35 = (int) 0;
   bool logic_uScriptCon_CompareInt_GreaterThan_35 = true;
   bool logic_uScriptCon_CompareInt_GreaterThanOrEqualTo_35 = true;
   bool logic_uScriptCon_CompareInt_EqualTo_35 = true;
   bool logic_uScriptCon_CompareInt_NotEqualTo_35 = true;
   bool logic_uScriptCon_CompareInt_LessThanOrEqualTo_35 = true;
   bool logic_uScriptCon_CompareInt_LessThan_35 = true;
   //pointer to script instanced logic node
   uScriptAct_SetString logic_uScriptAct_SetString_uScriptAct_SetString_38 = new uScriptAct_SetString( );
   System.String logic_uScriptAct_SetString_Value_38 = "http://www.uscript.net/files/test/request.php";
   System.Boolean logic_uScriptAct_SetString_ToUpperCase_38 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_ToLowerCase_38 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_TrimWhitespace_38 = (bool) false;
   System.String logic_uScriptAct_SetString_Target_38;
   bool logic_uScriptAct_SetString_Out_38 = true;
   //pointer to script instanced logic node
   uScriptAct_FormUpdateField logic_uScriptAct_FormUpdateField_uScriptAct_FormUpdateField_40 = new uScriptAct_FormUpdateField( );
   UnityEngine.WWWForm logic_uScriptAct_FormUpdateField_Form_40 = null;
   System.String logic_uScriptAct_FormUpdateField_Field_40 = "username";
   System.Object logic_uScriptAct_FormUpdateField_Value_40 = "";
   bool logic_uScriptAct_FormUpdateField_Out_40 = true;
   //pointer to script instanced logic node
   uScriptAct_FormUpdateField logic_uScriptAct_FormUpdateField_uScriptAct_FormUpdateField_43 = new uScriptAct_FormUpdateField( );
   UnityEngine.WWWForm logic_uScriptAct_FormUpdateField_Form_43 = null;
   System.String logic_uScriptAct_FormUpdateField_Field_43 = "toggle";
   System.Object logic_uScriptAct_FormUpdateField_Value_43 = "";
   bool logic_uScriptAct_FormUpdateField_Out_43 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareInt logic_uScriptCon_CompareInt_uScriptCon_CompareInt_47 = new uScriptCon_CompareInt( );
   System.Int32 logic_uScriptCon_CompareInt_A_47 = (int) 0;
   System.Int32 logic_uScriptCon_CompareInt_B_47 = (int) 0;
   bool logic_uScriptCon_CompareInt_GreaterThan_47 = true;
   bool logic_uScriptCon_CompareInt_GreaterThanOrEqualTo_47 = true;
   bool logic_uScriptCon_CompareInt_EqualTo_47 = true;
   bool logic_uScriptCon_CompareInt_NotEqualTo_47 = true;
   bool logic_uScriptCon_CompareInt_LessThanOrEqualTo_47 = true;
   bool logic_uScriptCon_CompareInt_LessThan_47 = true;
   //pointer to script instanced logic node
   uScriptAct_WebText logic_uScriptAct_WebText_uScriptAct_WebText_48 = new uScriptAct_WebText( );
   System.String logic_uScriptAct_WebText_URL_48 = "";
   UnityEngine.WWWForm logic_uScriptAct_WebText_Form_48 = null;
   System.String logic_uScriptAct_WebText_Result_48;
   System.String logic_uScriptAct_WebText_Error_48;
   bool logic_uScriptAct_WebText_Out_48 = true;
   bool logic_uScriptAct_WebText_OutFinished_48 = true;
   bool logic_uScriptAct_WebText_OutError_48 = true;
   bool logic_uScriptAct_WebText_Driven_48 = false;
   //pointer to script instanced logic node
   uScriptAct_SetString logic_uScriptAct_SetString_uScriptAct_SetString_64 = new uScriptAct_SetString( );
   System.String logic_uScriptAct_SetString_Value_64 = "http://www.uscript.net/files/test/request.php?";
   System.Boolean logic_uScriptAct_SetString_ToUpperCase_64 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_ToLowerCase_64 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_TrimWhitespace_64 = (bool) false;
   System.String logic_uScriptAct_SetString_Target_64;
   bool logic_uScriptAct_SetString_Out_64 = true;
   //pointer to script instanced logic node
   uScriptAct_AppendURLQuery logic_uScriptAct_AppendURLQuery_uScriptAct_AppendURLQuery_70 = new uScriptAct_AppendURLQuery( );
   System.String logic_uScriptAct_AppendURLQuery_URL_70 = "";
   System.String logic_uScriptAct_AppendURLQuery_Field_70 = "username";
   System.Object logic_uScriptAct_AppendURLQuery_Value_70 = "";
   System.Boolean logic_uScriptAct_AppendURLQuery_EscapeValue_70 = (bool) true;
   System.Boolean logic_uScriptAct_AppendURLQuery_UseSemicolon_70 = (bool) false;
   System.String logic_uScriptAct_AppendURLQuery_Result_70;
   bool logic_uScriptAct_AppendURLQuery_Out_70 = true;
   //pointer to script instanced logic node
   uScriptAct_AppendURLQuery logic_uScriptAct_AppendURLQuery_uScriptAct_AppendURLQuery_71 = new uScriptAct_AppendURLQuery( );
   System.String logic_uScriptAct_AppendURLQuery_URL_71 = "";
   System.String logic_uScriptAct_AppendURLQuery_Field_71 = "toggle";
   System.Object logic_uScriptAct_AppendURLQuery_Value_71 = "";
   System.Boolean logic_uScriptAct_AppendURLQuery_EscapeValue_71 = (bool) true;
   System.Boolean logic_uScriptAct_AppendURLQuery_UseSemicolon_71 = (bool) false;
   System.String logic_uScriptAct_AppendURLQuery_Result_71;
   bool logic_uScriptAct_AppendURLQuery_Out_71 = true;
   
   //event nodes
   System.Boolean event_UnityEngine_GameObject_GUIChanged_1 = (bool) false;
   System.String event_UnityEngine_GameObject_FocusedControl_1 = "";
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_1 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_13 = null;
   
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
      if ( null == event_UnityEngine_GameObject_Instance_13 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_13 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_13 )
         {
            {
               uScript_Global component = event_UnityEngine_GameObject_Instance_13.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_13.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_13;
                  component.uScriptLateStart += Instance_uScriptLateStart_13;
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
      if ( null != event_UnityEngine_GameObject_Instance_13 )
      {
         {
            uScript_Global component = event_UnityEngine_GameObject_Instance_13.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_13;
               component.uScriptLateStart -= Instance_uScriptLateStart_13;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_GUITextArea_uScriptAct_GUITextArea_0.SetParent(g);
      logic_uScriptAct_GUILabel_uScriptAct_GUILabel_2.SetParent(g);
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_3.SetParent(g);
      logic_uScriptAct_SetString_uScriptAct_SetString_4.SetParent(g);
      logic_uScriptAct_GUITextField_uScriptAct_GUITextField_5.SetParent(g);
      logic_uScriptAct_SetString_uScriptAct_SetString_6.SetParent(g);
      logic_uScriptAct_SetString_uScriptAct_SetString_8.SetParent(g);
      logic_uScriptAct_SetString_uScriptAct_SetString_9.SetParent(g);
      logic_uScriptAct_SetString_uScriptAct_SetString_10.SetParent(g);
      logic_uScriptAct_WebText_uScriptAct_WebText_12.SetParent(g);
      logic_uScriptAct_GUIToggle_uScriptAct_GUIToggle_17.SetParent(g);
      logic_uScriptAct_GUITextField_uScriptAct_GUITextField_18.SetParent(g);
      logic_uScriptAct_GUILabel_uScriptAct_GUILabel_19.SetParent(g);
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_21.SetParent(g);
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_22.SetParent(g);
      logic_uScriptAct_Concatenate_uScriptAct_Concatenate_23.SetParent(g);
      logic_uScriptAct_SetString_uScriptAct_SetString_27.SetParent(g);
      logic_uScriptAct_EscapeURL_uScriptAct_EscapeURL_28.SetParent(g);
      logic_uScriptAct_EscapeURL_uScriptAct_EscapeURL_30.SetParent(g);
      logic_uScriptAct_ConvertVariable_uScriptAct_ConvertVariable_31.SetParent(g);
      logic_uScriptAct_GUISelectionGrid_uScriptAct_GUISelectionGrid_34.SetParent(g);
      logic_uScriptCon_CompareInt_uScriptCon_CompareInt_35.SetParent(g);
      logic_uScriptAct_SetString_uScriptAct_SetString_38.SetParent(g);
      logic_uScriptAct_FormUpdateField_uScriptAct_FormUpdateField_40.SetParent(g);
      logic_uScriptAct_FormUpdateField_uScriptAct_FormUpdateField_43.SetParent(g);
      logic_uScriptCon_CompareInt_uScriptCon_CompareInt_47.SetParent(g);
      logic_uScriptAct_WebText_uScriptAct_WebText_48.SetParent(g);
      logic_uScriptAct_SetString_uScriptAct_SetString_64.SetParent(g);
      logic_uScriptAct_AppendURLQuery_uScriptAct_AppendURLQuery_70.SetParent(g);
      logic_uScriptAct_AppendURLQuery_uScriptAct_AppendURLQuery_71.SetParent(g);
   }
   public void Awake()
   {
      
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_3.OnButtonDown += uScriptAct_GUIButton_OnButtonDown_3;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_3.OnButtonHeld += uScriptAct_GUIButton_OnButtonHeld_3;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_3.OnButtonUp += uScriptAct_GUIButton_OnButtonUp_3;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_3.OnButtonClicked += uScriptAct_GUIButton_OnButtonClicked_3;
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
      
      if (true == logic_uScriptAct_WebText_Driven_12)
      {
         Relay_Driven_12();
      }
      if (true == logic_uScriptAct_WebText_Driven_48)
      {
         Relay_Driven_48();
      }
   }
   
   public void OnDestroy()
   {
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_3.OnButtonDown -= uScriptAct_GUIButton_OnButtonDown_3;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_3.OnButtonHeld -= uScriptAct_GUIButton_OnButtonHeld_3;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_3.OnButtonUp -= uScriptAct_GUIButton_OnButtonUp_3;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_3.OnButtonClicked -= uScriptAct_GUIButton_OnButtonClicked_3;
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
   
   void Instance_uScriptStart_13(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_13( );
   }
   
   void Instance_uScriptLateStart_13(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptLateStart_13( );
   }
   
   void uScriptAct_GUIButton_OnButtonDown_3(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonDown_3( );
   }
   
   void uScriptAct_GUIButton_OnButtonHeld_3(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonHeld_3( );
   }
   
   void uScriptAct_GUIButton_OnButtonUp_3(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonUp_3( );
   }
   
   void uScriptAct_GUIButton_OnButtonClicked_3(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonClicked_3( );
   }
   
   void Relay_In_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8ec1d1ea-72db-4b70-a7a9-35757e9f9e6a", "GUI Text Area", Relay_In_0)) return; 
         {
            {
               logic_uScriptAct_GUITextArea_Value_0 = local_WWW_Text_System_String;
               
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
         logic_uScriptAct_GUITextArea_uScriptAct_GUITextArea_0.In(ref logic_uScriptAct_GUITextArea_Value_0, logic_uScriptAct_GUITextArea_Position_0, logic_uScriptAct_GUITextArea_maxLength_0, logic_uScriptAct_GUITextArea_ControlName_0, logic_uScriptAct_GUITextArea_guiStyle_0);
         local_WWW_Text_System_String = logic_uScriptAct_GUITextArea_Value_0;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at GUI Text Area.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnGui_1()
   {
      if (true == CheckDebugBreak("41f92a5b-34c7-4b9d-bd60-46382eb9dd97", "GUI Events", Relay_OnGui_1)) return; 
      Relay_In_3();
   }
   
   void Relay_In_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("10249a6d-2195-4def-8862-67a9bd4564bb", "GUI Label", Relay_In_2)) return; 
         {
            {
               logic_uScriptAct_GUILabel_Text_2 = local_wwwStatus_System_String;
               
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
         logic_uScriptAct_GUILabel_uScriptAct_GUILabel_2.In(logic_uScriptAct_GUILabel_Text_2, logic_uScriptAct_GUILabel_Position_2, logic_uScriptAct_GUILabel_Texture_2, logic_uScriptAct_GUILabel_ToolTip_2, logic_uScriptAct_GUILabel_guiStyle_2);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUILabel_uScriptAct_GUILabel_2.Out;
         
         if ( test_0 == true )
         {
            Relay_In_34();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at GUI Label.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonDown_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4acb7d8e-f127-48de-b062-b6e4bb35715d", "GUI Button", Relay_OnButtonDown_3)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonHeld_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4acb7d8e-f127-48de-b062-b6e4bb35715d", "GUI Button", Relay_OnButtonHeld_3)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonUp_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4acb7d8e-f127-48de-b062-b6e4bb35715d", "GUI Button", Relay_OnButtonUp_3)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonClicked_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4acb7d8e-f127-48de-b062-b6e4bb35715d", "GUI Button", Relay_OnButtonClicked_3)) return; 
         Relay_In_47();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4acb7d8e-f127-48de-b062-b6e4bb35715d", "GUI Button", Relay_In_3)) return; 
         {
            {
               logic_uScriptAct_GUIButton_Text_3 = local_74_System_String;
               
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
         logic_uScriptAct_GUIButton_uScriptAct_GUIButton_3.In(logic_uScriptAct_GUIButton_Text_3, logic_uScriptAct_GUIButton_identifier_3, logic_uScriptAct_GUIButton_Position_3, logic_uScriptAct_GUIButton_Texture_3, logic_uScriptAct_GUIButton_ToolTip_3, logic_uScriptAct_GUIButton_guiStyle_3);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUIButton_uScriptAct_GUIButton_3.Out;
         
         if ( test_0 == true )
         {
            Relay_In_5();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_4()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0848e806-0fd8-4212-8cec-9af2ef9b75c3", "Set String", Relay_In_4)) return; 
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
         logic_uScriptAct_SetString_uScriptAct_SetString_4.In(logic_uScriptAct_SetString_Value_4, logic_uScriptAct_SetString_ToUpperCase_4, logic_uScriptAct_SetString_ToLowerCase_4, logic_uScriptAct_SetString_TrimWhitespace_4, out logic_uScriptAct_SetString_Target_4);
         local_wwwStatus_System_String = logic_uScriptAct_SetString_Target_4;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Set String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8e6e13a7-9a23-4bde-9699-778b4dc054a3", "GUI Text Field", Relay_In_5)) return; 
         {
            {
               logic_uScriptAct_GUITextField_Value_5 = local_URL_System_String;
               
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
         logic_uScriptAct_GUITextField_uScriptAct_GUITextField_5.In(ref logic_uScriptAct_GUITextField_Value_5, logic_uScriptAct_GUITextField_Position_5, logic_uScriptAct_GUITextField_maxLength_5, logic_uScriptAct_GUITextField_ControlName_5, logic_uScriptAct_GUITextField_guiStyle_5);
         local_URL_System_String = logic_uScriptAct_GUITextField_Value_5;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUITextField_uScriptAct_GUITextField_5.Out;
         
         if ( test_0 == true )
         {
            Relay_In_2();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at GUI Text Field.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("97faba6a-b9ea-4d5f-98b3-9e2d31dc1e32", "Set String", Relay_In_6)) return; 
         {
            {
               logic_uScriptAct_SetString_Value_6 = local_72_System_String;
               
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
         local_URL_System_String = logic_uScriptAct_SetString_Target_6;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetString_uScriptAct_SetString_6.Out;
         
         if ( test_0 == true )
         {
            Relay_In_10();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Set String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_8()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3578c7cb-ec1a-4d3f-aa14-4b4c56805b60", "Set String", Relay_In_8)) return; 
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
         logic_uScriptAct_SetString_uScriptAct_SetString_8.In(logic_uScriptAct_SetString_Value_8, logic_uScriptAct_SetString_ToUpperCase_8, logic_uScriptAct_SetString_ToLowerCase_8, logic_uScriptAct_SetString_TrimWhitespace_8, out logic_uScriptAct_SetString_Target_8);
         local_wwwStatus_System_String = logic_uScriptAct_SetString_Target_8;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Set String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d4942041-725f-48b6-91cc-a4061343f559", "Set String", Relay_In_9)) return; 
         {
            {
               logic_uScriptAct_SetString_Value_9 = local_WWW_Error_System_String;
               
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
         logic_uScriptAct_SetString_uScriptAct_SetString_9.In(logic_uScriptAct_SetString_Value_9, logic_uScriptAct_SetString_ToUpperCase_9, logic_uScriptAct_SetString_ToLowerCase_9, logic_uScriptAct_SetString_TrimWhitespace_9, out logic_uScriptAct_SetString_Target_9);
         local_wwwStatus_System_String = logic_uScriptAct_SetString_Target_9;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Set String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f6b2fb87-ee8c-451d-8068-7917d72af032", "Set String", Relay_In_10)) return; 
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
         logic_uScriptAct_SetString_uScriptAct_SetString_10.In(logic_uScriptAct_SetString_Value_10, logic_uScriptAct_SetString_ToUpperCase_10, logic_uScriptAct_SetString_ToLowerCase_10, logic_uScriptAct_SetString_TrimWhitespace_10, out logic_uScriptAct_SetString_Target_10);
         local_WWW_Text_System_String = logic_uScriptAct_SetString_Target_10;
         local_wwwStatus_System_String = logic_uScriptAct_SetString_Target_10;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Set String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_12()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("764a964b-b50c-41cc-aec4-c75387bc87ae", "Web Text", Relay_In_12)) return; 
         {
            {
               logic_uScriptAct_WebText_URL_12 = local_URL_System_String;
               
            }
            {
               logic_uScriptAct_WebText_Form_12 = local_WWW_Form_UnityEngine_WWWForm;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_WebText_uScriptAct_WebText_12.In(logic_uScriptAct_WebText_URL_12, logic_uScriptAct_WebText_Form_12, out logic_uScriptAct_WebText_Result_12, out logic_uScriptAct_WebText_Error_12);
         logic_uScriptAct_WebText_Driven_12 = true;
         local_WWW_Text_System_String = logic_uScriptAct_WebText_Result_12;
         local_WWW_Error_System_String = logic_uScriptAct_WebText_Error_12;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_WebText_uScriptAct_WebText_12.Out;
         bool test_1 = logic_uScriptAct_WebText_uScriptAct_WebText_12.OutFinished;
         bool test_2 = logic_uScriptAct_WebText_uScriptAct_WebText_12.OutError;
         
         if ( test_0 == true )
         {
            Relay_In_4();
         }
         if ( test_1 == true )
         {
            Relay_In_8();
         }
         if ( test_2 == true )
         {
            Relay_In_9();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Web Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Driven_12( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               logic_uScriptAct_WebText_URL_12 = local_URL_System_String;
               
            }
            {
               logic_uScriptAct_WebText_Form_12 = local_WWW_Form_UnityEngine_WWWForm;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_WebText_Driven_12 = logic_uScriptAct_WebText_uScriptAct_WebText_12.Driven(out logic_uScriptAct_WebText_Result_12, out logic_uScriptAct_WebText_Error_12);
         if ( true == logic_uScriptAct_WebText_Driven_12 )
         {
            local_WWW_Text_System_String = logic_uScriptAct_WebText_Result_12;
            local_WWW_Error_System_String = logic_uScriptAct_WebText_Error_12;
            if ( logic_uScriptAct_WebText_uScriptAct_WebText_12.Out == true )
            {
               Relay_In_4();
            }
            if ( logic_uScriptAct_WebText_uScriptAct_WebText_12.OutFinished == true )
            {
               Relay_In_8();
            }
            if ( logic_uScriptAct_WebText_uScriptAct_WebText_12.OutError == true )
            {
               Relay_In_9();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Web Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_uScriptStart_13()
   {
      if (true == CheckDebugBreak("2e250385-7c29-421f-8b98-5e26b9da1276", "uScript Events", Relay_uScriptStart_13)) return; 
      Relay_In_6();
   }
   
   void Relay_uScriptLateStart_13()
   {
      if (true == CheckDebugBreak("2e250385-7c29-421f-8b98-5e26b9da1276", "uScript Events", Relay_uScriptLateStart_13)) return; 
   }
   
   void Relay_In_17()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2d8fda6d-080b-4c6a-a84c-7225b5e5969e", "GUI Toggle", Relay_In_17)) return; 
         {
            {
               logic_uScriptAct_GUIToggle_Value_17 = local_toggleValue_System_Boolean;
               
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
         logic_uScriptAct_GUIToggle_uScriptAct_GUIToggle_17.In(ref logic_uScriptAct_GUIToggle_Value_17, logic_uScriptAct_GUIToggle_Text_17, logic_uScriptAct_GUIToggle_Position_17, logic_uScriptAct_GUIToggle_Texture_17, logic_uScriptAct_GUIToggle_ToolTip_17, logic_uScriptAct_GUIToggle_guiStyle_17);
         local_toggleValue_System_Boolean = logic_uScriptAct_GUIToggle_Value_17;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUIToggle_uScriptAct_GUIToggle_17.Out;
         bool test_1 = logic_uScriptAct_GUIToggle_uScriptAct_GUIToggle_17.Changed;
         
         if ( test_0 == true )
         {
            Relay_In_0();
         }
         if ( test_1 == true )
         {
            Relay_In_35();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at GUI Toggle.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_18()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a3e1542e-3543-41f6-9cb6-67914852f92c", "GUI Text Field", Relay_In_18)) return; 
         {
            {
               logic_uScriptAct_GUITextField_Value_18 = local_usernameValue_System_String;
               
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
         logic_uScriptAct_GUITextField_uScriptAct_GUITextField_18.In(ref logic_uScriptAct_GUITextField_Value_18, logic_uScriptAct_GUITextField_Position_18, logic_uScriptAct_GUITextField_maxLength_18, logic_uScriptAct_GUITextField_ControlName_18, logic_uScriptAct_GUITextField_guiStyle_18);
         local_usernameValue_System_String = logic_uScriptAct_GUITextField_Value_18;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUITextField_uScriptAct_GUITextField_18.Out;
         bool test_1 = logic_uScriptAct_GUITextField_uScriptAct_GUITextField_18.Changed;
         
         if ( test_0 == true )
         {
            Relay_In_17();
         }
         if ( test_1 == true )
         {
            Relay_In_35();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at GUI Text Field.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_19()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2420c4ba-b8f2-4e39-b822-8974b86744ba", "GUI Label", Relay_In_19)) return; 
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
         logic_uScriptAct_GUILabel_uScriptAct_GUILabel_19.In(logic_uScriptAct_GUILabel_Text_19, logic_uScriptAct_GUILabel_Position_19, logic_uScriptAct_GUILabel_Texture_19, logic_uScriptAct_GUILabel_ToolTip_19, logic_uScriptAct_GUILabel_guiStyle_19);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUILabel_uScriptAct_GUILabel_19.Out;
         
         if ( test_0 == true )
         {
            Relay_In_18();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at GUI Label.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_21()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("bf7120e2-dd60-4fb0-9d05-6e98327476b6", "Concatenate", Relay_In_21)) return; 
         {
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add(local_URL_System_String);
               logic_uScriptAct_Concatenate_A_21 = properties.ToArray();
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add(local_29_System_String);
               logic_uScriptAct_Concatenate_B_21 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_Concatenate_uScriptAct_Concatenate_21.In(logic_uScriptAct_Concatenate_A_21, logic_uScriptAct_Concatenate_B_21, logic_uScriptAct_Concatenate_Separator_21, out logic_uScriptAct_Concatenate_Result_21);
         local_URL_System_String = logic_uScriptAct_Concatenate_Result_21;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Concatenate_uScriptAct_Concatenate_21.Out;
         
         if ( test_0 == true )
         {
            Relay_In_23();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Concatenate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_22()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f0beb8dc-9cfe-4d75-bbf3-e79d2afcc801", "Concatenate", Relay_In_22)) return; 
         {
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add(local_URL_System_String);
               logic_uScriptAct_Concatenate_A_22 = properties.ToArray();
            }
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add(local_33_System_String);
               logic_uScriptAct_Concatenate_B_22 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_Concatenate_uScriptAct_Concatenate_22.In(logic_uScriptAct_Concatenate_A_22, logic_uScriptAct_Concatenate_B_22, logic_uScriptAct_Concatenate_Separator_22, out logic_uScriptAct_Concatenate_Result_22);
         local_URL_System_String = logic_uScriptAct_Concatenate_Result_22;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Concatenate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_23()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("271c68a2-a069-4904-8d6d-57c19718a056", "Concatenate", Relay_In_23)) return; 
         {
            {
               List<System.Object> properties = new List<System.Object>();
               properties.Add(local_URL_System_String);
               logic_uScriptAct_Concatenate_A_23 = properties.ToArray();
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_Concatenate_uScriptAct_Concatenate_23.In(logic_uScriptAct_Concatenate_A_23, logic_uScriptAct_Concatenate_B_23, logic_uScriptAct_Concatenate_Separator_23, out logic_uScriptAct_Concatenate_Result_23);
         local_URL_System_String = logic_uScriptAct_Concatenate_Result_23;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Concatenate_uScriptAct_Concatenate_23.Out;
         
         if ( test_0 == true )
         {
            Relay_In_31();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Concatenate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_27()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9bc32f89-6fc2-45f7-b1d2-810086f50109", "Set String", Relay_In_27)) return; 
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
         logic_uScriptAct_SetString_uScriptAct_SetString_27.In(logic_uScriptAct_SetString_Value_27, logic_uScriptAct_SetString_ToUpperCase_27, logic_uScriptAct_SetString_ToLowerCase_27, logic_uScriptAct_SetString_TrimWhitespace_27, out logic_uScriptAct_SetString_Target_27);
         local_URL_System_String = logic_uScriptAct_SetString_Target_27;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetString_uScriptAct_SetString_27.Out;
         
         if ( test_0 == true )
         {
            Relay_In_28();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Set String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_28()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3e9227ac-ca42-46db-856a-6e0ee505b723", "Escape String", Relay_In_28)) return; 
         {
            {
               logic_uScriptAct_EscapeURL_Target_28 = local_usernameValue_System_String;
               
            }
            {
            }
         }
         logic_uScriptAct_EscapeURL_uScriptAct_EscapeURL_28.In(logic_uScriptAct_EscapeURL_Target_28, out logic_uScriptAct_EscapeURL_Result_28);
         local_29_System_String = logic_uScriptAct_EscapeURL_Result_28;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_EscapeURL_uScriptAct_EscapeURL_28.Out;
         
         if ( test_0 == true )
         {
            Relay_In_21();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Escape String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_30()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8f69f7bd-4bb7-4743-9d69-81aa0290f68d", "Escape String", Relay_In_30)) return; 
         {
            {
               logic_uScriptAct_EscapeURL_Target_30 = local_32_System_String;
               
            }
            {
            }
         }
         logic_uScriptAct_EscapeURL_uScriptAct_EscapeURL_30.In(logic_uScriptAct_EscapeURL_Target_30, out logic_uScriptAct_EscapeURL_Result_30);
         local_33_System_String = logic_uScriptAct_EscapeURL_Result_30;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_EscapeURL_uScriptAct_EscapeURL_30.Out;
         
         if ( test_0 == true )
         {
            Relay_In_22();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Escape String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_31()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3b71e175-ff8e-4a86-b994-42ea6245b85f", "Convert Variable", Relay_In_31)) return; 
         {
            {
               logic_uScriptAct_ConvertVariable_Target_31 = local_toggleValue_System_Boolean;
               
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
         logic_uScriptAct_ConvertVariable_uScriptAct_ConvertVariable_31.In(logic_uScriptAct_ConvertVariable_Target_31, out logic_uScriptAct_ConvertVariable_IntValue_31, out logic_uScriptAct_ConvertVariable_Int64Value_31, out logic_uScriptAct_ConvertVariable_FloatValue_31, out logic_uScriptAct_ConvertVariable_StringValue_31, out logic_uScriptAct_ConvertVariable_BooleanValue_31, out logic_uScriptAct_ConvertVariable_Vector3Value_31);
         local_32_System_String = logic_uScriptAct_ConvertVariable_StringValue_31;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_ConvertVariable_uScriptAct_ConvertVariable_31.Out;
         
         if ( test_0 == true )
         {
            Relay_In_30();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Convert Variable.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_34()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("970212cc-1c42-4727-b4ba-de712d2c5bf8", "GUI Selection Grid", Relay_In_34)) return; 
         {
            {
               logic_uScriptAct_GUISelectionGrid_Value_34 = local_WWW_Method_System_Int32;
               
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
         logic_uScriptAct_GUISelectionGrid_uScriptAct_GUISelectionGrid_34.In(ref logic_uScriptAct_GUISelectionGrid_Value_34, logic_uScriptAct_GUISelectionGrid_Position_34, logic_uScriptAct_GUISelectionGrid_Content_34, logic_uScriptAct_GUISelectionGrid_xCount_34, logic_uScriptAct_GUISelectionGrid_guiStyle_34);
         local_WWW_Method_System_Int32 = logic_uScriptAct_GUISelectionGrid_Value_34;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUISelectionGrid_uScriptAct_GUISelectionGrid_34.Out;
         bool test_1 = logic_uScriptAct_GUISelectionGrid_uScriptAct_GUISelectionGrid_34.Changed;
         
         if ( test_0 == true )
         {
            Relay_In_19();
         }
         if ( test_1 == true )
         {
            Relay_In_35();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at GUI Selection Grid.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_35()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("12774b80-b43d-4dcc-a8bb-e1495cc3f3be", "Compare Int", Relay_In_35)) return; 
         {
            {
               logic_uScriptCon_CompareInt_A_35 = local_WWW_Method_System_Int32;
               
            }
            {
            }
         }
         logic_uScriptCon_CompareInt_uScriptCon_CompareInt_35.In(logic_uScriptCon_CompareInt_A_35, logic_uScriptCon_CompareInt_B_35);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareInt_uScriptCon_CompareInt_35.EqualTo;
         bool test_1 = logic_uScriptCon_CompareInt_uScriptCon_CompareInt_35.NotEqualTo;
         
         if ( test_0 == true )
         {
            Relay_In_64();
         }
         if ( test_1 == true )
         {
            Relay_In_38();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Compare Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_38()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("cb7201d5-9038-496b-9821-88de26664aa8", "Set String", Relay_In_38)) return; 
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
         logic_uScriptAct_SetString_uScriptAct_SetString_38.In(logic_uScriptAct_SetString_Value_38, logic_uScriptAct_SetString_ToUpperCase_38, logic_uScriptAct_SetString_ToLowerCase_38, logic_uScriptAct_SetString_TrimWhitespace_38, out logic_uScriptAct_SetString_Target_38);
         local_URL_System_String = logic_uScriptAct_SetString_Target_38;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetString_uScriptAct_SetString_38.Out;
         
         if ( test_0 == true )
         {
            Relay_In_40();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Set String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_40()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("64a6cb88-9e61-4ad6-8314-2c81b4b27650", "Form Update Field", Relay_In_40)) return; 
         {
            {
               logic_uScriptAct_FormUpdateField_Form_40 = local_WWW_Form_UnityEngine_WWWForm;
               
            }
            {
            }
            {
               logic_uScriptAct_FormUpdateField_Value_40 = local_usernameValue_System_String;
               
            }
         }
         logic_uScriptAct_FormUpdateField_uScriptAct_FormUpdateField_40.In(ref logic_uScriptAct_FormUpdateField_Form_40, logic_uScriptAct_FormUpdateField_Field_40, logic_uScriptAct_FormUpdateField_Value_40);
         local_WWW_Form_UnityEngine_WWWForm = logic_uScriptAct_FormUpdateField_Form_40;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_FormUpdateField_uScriptAct_FormUpdateField_40.Out;
         
         if ( test_0 == true )
         {
            Relay_In_43();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Form Update Field.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_43()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("889b50f5-7b1d-4499-af14-0c4974f5d38e", "Form Update Field", Relay_In_43)) return; 
         {
            {
               logic_uScriptAct_FormUpdateField_Form_43 = local_WWW_Form_UnityEngine_WWWForm;
               
            }
            {
            }
            {
               logic_uScriptAct_FormUpdateField_Value_43 = local_toggleValue_System_Boolean;
               
            }
         }
         logic_uScriptAct_FormUpdateField_uScriptAct_FormUpdateField_43.In(ref logic_uScriptAct_FormUpdateField_Form_43, logic_uScriptAct_FormUpdateField_Field_43, logic_uScriptAct_FormUpdateField_Value_43);
         local_WWW_Form_UnityEngine_WWWForm = logic_uScriptAct_FormUpdateField_Form_43;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Form Update Field.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_47()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ebb9015b-5975-4092-82b7-a97f9676eb15", "Compare Int", Relay_In_47)) return; 
         {
            {
               logic_uScriptCon_CompareInt_A_47 = local_WWW_Method_System_Int32;
               
            }
            {
            }
         }
         logic_uScriptCon_CompareInt_uScriptCon_CompareInt_47.In(logic_uScriptCon_CompareInt_A_47, logic_uScriptCon_CompareInt_B_47);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareInt_uScriptCon_CompareInt_47.EqualTo;
         bool test_1 = logic_uScriptCon_CompareInt_uScriptCon_CompareInt_47.NotEqualTo;
         
         if ( test_0 == true )
         {
            Relay_In_48();
         }
         if ( test_1 == true )
         {
            Relay_In_12();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Compare Int.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_48()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1353bf0a-cf25-4b1b-a6ef-a3ab18410d8e", "Web Text", Relay_In_48)) return; 
         {
            {
               logic_uScriptAct_WebText_URL_48 = local_URL_System_String;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_WebText_uScriptAct_WebText_48.In(logic_uScriptAct_WebText_URL_48, logic_uScriptAct_WebText_Form_48, out logic_uScriptAct_WebText_Result_48, out logic_uScriptAct_WebText_Error_48);
         logic_uScriptAct_WebText_Driven_48 = true;
         local_WWW_Text_System_String = logic_uScriptAct_WebText_Result_48;
         local_WWW_Error_System_String = logic_uScriptAct_WebText_Error_48;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_WebText_uScriptAct_WebText_48.Out;
         bool test_1 = logic_uScriptAct_WebText_uScriptAct_WebText_48.OutFinished;
         bool test_2 = logic_uScriptAct_WebText_uScriptAct_WebText_48.OutError;
         
         if ( test_0 == true )
         {
            Relay_In_4();
         }
         if ( test_1 == true )
         {
            Relay_In_8();
         }
         if ( test_2 == true )
         {
            Relay_In_9();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Web Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Driven_48( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
               logic_uScriptAct_WebText_URL_48 = local_URL_System_String;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_WebText_Driven_48 = logic_uScriptAct_WebText_uScriptAct_WebText_48.Driven(out logic_uScriptAct_WebText_Result_48, out logic_uScriptAct_WebText_Error_48);
         if ( true == logic_uScriptAct_WebText_Driven_48 )
         {
            local_WWW_Text_System_String = logic_uScriptAct_WebText_Result_48;
            local_WWW_Error_System_String = logic_uScriptAct_WebText_Error_48;
            if ( logic_uScriptAct_WebText_uScriptAct_WebText_48.Out == true )
            {
               Relay_In_4();
            }
            if ( logic_uScriptAct_WebText_uScriptAct_WebText_48.OutFinished == true )
            {
               Relay_In_8();
            }
            if ( logic_uScriptAct_WebText_uScriptAct_WebText_48.OutError == true )
            {
               Relay_In_9();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Web Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_In_64()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e48477ee-ed64-44b4-821c-41b374446a44", "Set String", Relay_In_64)) return; 
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
         logic_uScriptAct_SetString_uScriptAct_SetString_64.In(logic_uScriptAct_SetString_Value_64, logic_uScriptAct_SetString_ToUpperCase_64, logic_uScriptAct_SetString_ToLowerCase_64, logic_uScriptAct_SetString_TrimWhitespace_64, out logic_uScriptAct_SetString_Target_64);
         local_URL_System_String = logic_uScriptAct_SetString_Target_64;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetString_uScriptAct_SetString_64.Out;
         
         if ( test_0 == true )
         {
            Relay_In_70();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Set String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_70()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9b6629cb-9394-46f8-9483-6583ac36e0d6", "Append URL Query", Relay_In_70)) return; 
         {
            {
               logic_uScriptAct_AppendURLQuery_URL_70 = local_URL_System_String;
               
            }
            {
            }
            {
               logic_uScriptAct_AppendURLQuery_Value_70 = local_usernameValue_System_String;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AppendURLQuery_uScriptAct_AppendURLQuery_70.In(logic_uScriptAct_AppendURLQuery_URL_70, logic_uScriptAct_AppendURLQuery_Field_70, logic_uScriptAct_AppendURLQuery_Value_70, logic_uScriptAct_AppendURLQuery_EscapeValue_70, logic_uScriptAct_AppendURLQuery_UseSemicolon_70, out logic_uScriptAct_AppendURLQuery_Result_70);
         local_URL_System_String = logic_uScriptAct_AppendURLQuery_Result_70;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AppendURLQuery_uScriptAct_AppendURLQuery_70.Out;
         
         if ( test_0 == true )
         {
            Relay_In_71();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Append URL Query.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_71()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("cfe5e1d1-d645-47d3-abe3-0eb5e52646b9", "Append URL Query", Relay_In_71)) return; 
         {
            {
               logic_uScriptAct_AppendURLQuery_URL_71 = local_URL_System_String;
               
            }
            {
            }
            {
               logic_uScriptAct_AppendURLQuery_Value_71 = local_toggleValue_System_Boolean;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AppendURLQuery_uScriptAct_AppendURLQuery_71.In(logic_uScriptAct_AppendURLQuery_URL_71, logic_uScriptAct_AppendURLQuery_Field_71, logic_uScriptAct_AppendURLQuery_Value_71, logic_uScriptAct_AppendURLQuery_EscapeValue_71, logic_uScriptAct_AppendURLQuery_UseSemicolon_71, out logic_uScriptAct_AppendURLQuery_Result_71);
         local_URL_System_String = logic_uScriptAct_AppendURLQuery_Result_71;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript WebTextExample.uscript at Append URL Query.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "WebTextExample.uscript:29", local_29_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "abbdc1c7-0e9e-45c4-8f82-85d5ecd862d3", local_29_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "WebTextExample.uscript:32", local_32_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "fac39bd9-cb0d-4ca6-af83-d1ba4c37d662", local_32_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "WebTextExample.uscript:33", local_33_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f6f39d15-4fba-4527-a82e-9ff5596c9ec3", local_33_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "WebTextExample.uscript:WWW Form", local_WWW_Form_UnityEngine_WWWForm);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "dcc5c468-988b-4495-9db0-5d98f80037aa", local_WWW_Form_UnityEngine_WWWForm);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "WebTextExample.uscript:WWW Method", local_WWW_Method_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "294d7a15-0cb2-4eb3-bd2e-02e2e2ae7bf0", local_WWW_Method_System_Int32);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "WebTextExample.uscript:WWW Error", local_WWW_Error_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "fb268741-7f63-45a9-8449-e28abef25355", local_WWW_Error_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "WebTextExample.uscript:WWW Text", local_WWW_Text_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "6aedde37-1e01-4e5f-957a-0e59b276b4d9", local_WWW_Text_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "WebTextExample.uscript:wwwStatus", local_wwwStatus_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "582cd476-7588-41b4-892b-1ba64661dede", local_wwwStatus_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "WebTextExample.uscript:toggleValue", local_toggleValue_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a4b70357-0484-4f9f-a8fd-8dcdbda78c44", local_toggleValue_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "WebTextExample.uscript:usernameValue", local_usernameValue_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "befaa697-701d-40f8-b598-eff3ab716a64", local_usernameValue_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "WebTextExample.uscript:URL", local_URL_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "05a5c52e-9a37-4c0a-b17e-c82dd3c09c4d", local_URL_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "WebTextExample.uscript:72", local_72_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "fd933828-89fd-4305-b1a5-7fb8087c54dc", local_72_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "WebTextExample.uscript:74", local_74_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "aaeb1c61-0e84-4515-94cd-1a42c20ab85c", local_74_System_String);
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
