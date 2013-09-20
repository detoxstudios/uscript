//uScript Generated Code - Build 0.9.2428
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("Web Text", "")]
public class WebText : uScriptLogic
{

   #pragma warning disable 414
   GameObject parentGameObject = null;
   uScript_GUI thisScriptsOnGuiListener = null; 
   bool m_RegisteredForEvents = false;
   
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
   System.String logic_uScriptAct_ConvertVariable_FloatGroupSeparator_31 = ",";
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
      //fill globals
      event_UnityEngine_GameObject_GUIChanged_1 = e.GUIChanged;
      event_UnityEngine_GameObject_FocusedControl_1 = e.FocusedControl;
      //relay event to nodes
      Relay_OnGui_1( );
   }
   
   void Instance_uScriptStart_13(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_13( );
   }
   
   void Instance_uScriptLateStart_13(object o, System.EventArgs e)
   {
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
   
   void Relay_OnGui_1()
   {
      Relay_In_3();
   }
   
   void Relay_In_2()
   {
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
   
   void Relay_OnButtonDown_3()
   {
   }
   
   void Relay_OnButtonHeld_3()
   {
   }
   
   void Relay_OnButtonUp_3()
   {
   }
   
   void Relay_OnButtonClicked_3()
   {
      Relay_In_47();
   }
   
   void Relay_In_3()
   {
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
   
   void Relay_In_4()
   {
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
   
   void Relay_In_5()
   {
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
   
   void Relay_In_6()
   {
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
   
   void Relay_In_8()
   {
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
   
   void Relay_In_9()
   {
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
   
   void Relay_In_10()
   {
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
   
   void Relay_In_12()
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
   
   void Relay_Driven_12( )
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
   void Relay_uScriptStart_13()
   {
      Relay_In_6();
   }
   
   void Relay_uScriptLateStart_13()
   {
   }
   
   void Relay_In_17()
   {
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
   
   void Relay_In_18()
   {
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
   
   void Relay_In_19()
   {
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
   
   void Relay_In_21()
   {
      {
         {
            List<System.Object> properties = new List<System.Object>();
            properties.Add((System.Object)local_URL_System_String);
            logic_uScriptAct_Concatenate_A_21 = properties.ToArray();
         }
         {
            List<System.Object> properties = new List<System.Object>();
            properties.Add((System.Object)local_29_System_String);
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
   
   void Relay_In_22()
   {
      {
         {
            List<System.Object> properties = new List<System.Object>();
            properties.Add((System.Object)local_URL_System_String);
            logic_uScriptAct_Concatenate_A_22 = properties.ToArray();
         }
         {
            List<System.Object> properties = new List<System.Object>();
            properties.Add((System.Object)local_33_System_String);
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
   
   void Relay_In_23()
   {
      {
         {
            List<System.Object> properties = new List<System.Object>();
            properties.Add((System.Object)local_URL_System_String);
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
   
   void Relay_In_27()
   {
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
   
   void Relay_In_28()
   {
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
   
   void Relay_In_30()
   {
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
   
   void Relay_In_31()
   {
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
         {
         }
      }
      logic_uScriptAct_ConvertVariable_uScriptAct_ConvertVariable_31.In(logic_uScriptAct_ConvertVariable_Target_31, out logic_uScriptAct_ConvertVariable_IntValue_31, out logic_uScriptAct_ConvertVariable_Int64Value_31, out logic_uScriptAct_ConvertVariable_FloatValue_31, out logic_uScriptAct_ConvertVariable_StringValue_31, out logic_uScriptAct_ConvertVariable_BooleanValue_31, out logic_uScriptAct_ConvertVariable_Vector3Value_31, logic_uScriptAct_ConvertVariable_FloatGroupSeparator_31);
      local_32_System_String = logic_uScriptAct_ConvertVariable_StringValue_31;
      
      //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
      bool test_0 = logic_uScriptAct_ConvertVariable_uScriptAct_ConvertVariable_31.Out;
      
      if ( test_0 == true )
      {
         Relay_In_30();
      }
   }
   
   void Relay_In_34()
   {
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
   
   void Relay_In_35()
   {
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
   
   void Relay_In_38()
   {
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
   
   void Relay_In_40()
   {
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
   
   void Relay_In_43()
   {
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
   
   void Relay_In_47()
   {
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
   
   void Relay_In_48()
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
   
   void Relay_Driven_48( )
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
   void Relay_In_64()
   {
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
   
   void Relay_In_70()
   {
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
   
   void Relay_In_71()
   {
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
   
}
