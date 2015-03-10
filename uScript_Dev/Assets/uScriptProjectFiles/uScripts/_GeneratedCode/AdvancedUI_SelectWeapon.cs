//uScript Generated Code - Build 1.0.2830
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class AdvancedUI_SelectWeapon : uScriptLogic
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
   UnityEngine.Rect local_0_UnityEngine_Rect = new Rect( (float)40, (float)40, (float)250, (float)100 );
   UnityEngine.Rect local_11_UnityEngine_Rect = new Rect( (float)40, (float)430, (float)520, (float)80 );
   System.String local_13_System_String = "Weapon 1";
   System.String local_14_System_String = "Weapon 2";
   System.String local_15_System_String = "Back To Play Game";
   System.String local_22_System_String = "";
   System.String local_23_System_String = "";
   System.Single local_28_System_Single = (float) 0;
   System.Single local_30_System_Single = (float) 0;
   System.Single local_32_System_Single = (float) 0;
   System.Single local_33_System_Single = (float) 0;
   System.Single local_36_System_Single = (float) 0;
   System.Single local_39_System_Single = (float) 0;
   System.String local_40_System_String = "Weapon 4";
   System.String local_41_System_String = "Weapon 3";
   UnityEngine.Rect local_44_UnityEngine_Rect = new Rect( (float)40, (float)160, (float)250, (float)100 );
   UnityEngine.Rect local_45_UnityEngine_Rect = new Rect( (float)310, (float)160, (float)250, (float)100 );
   UnityEngine.Rect local_8_UnityEngine_Rect = new Rect( (float)310, (float)40, (float)250, (float)100 );
   UnityEngine.Rect local_Filtered_Rect_UnityEngine_Rect = new Rect( (float)0, (float)0, (float)0, (float)0 );
   UnityEngine.Texture2D local_Sword1_UnityEngine_Texture2D = default(UnityEngine.Texture2D);
   UnityEngine.Texture2D local_Sword2_UnityEngine_Texture2D = default(UnityEngine.Texture2D);
   UnityEngine.Texture2D local_Sword3_UnityEngine_Texture2D = default(UnityEngine.Texture2D);
   UnityEngine.Texture2D local_Sword4_UnityEngine_Texture2D = default(UnityEngine.Texture2D);
   UnityEngine.Rect local_Target_Rect_UnityEngine_Rect = new Rect( (float)0, (float)0, (float)0, (float)0 );
   System.String local_Weapon_Name_System_String = "";
   UnityEngine.Texture2D local_Weapon_Texture_UnityEngine_Texture2D = default(UnityEngine.Texture2D);
   
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
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_RectHeight_4 = (int) 550;
   uScriptAct_CreateRelativeRectScreen.Position logic_uScriptAct_CreateRelativeRectScreen_RectPosition_4 = uScriptAct_CreateRelativeRectScreen.Position.MiddleCenter;
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_xOffset_4 = (int) 0;
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_yOffset_4 = (int) 0;
   UnityEngine.Rect logic_uScriptAct_CreateRelativeRectScreen_OutputRect_4;
   bool logic_uScriptAct_CreateRelativeRectScreen_Out_4 = true;
   //pointer to script instanced logic node
   uScriptAct_GUIBox logic_uScriptAct_GUIBox_uScriptAct_GUIBox_6 = new uScriptAct_GUIBox( );
   System.String logic_uScriptAct_GUIBox_Text_6 = "Select Weapon";
   UnityEngine.Rect logic_uScriptAct_GUIBox_Position_6 = new Rect( (float)0, (float)0, (float)600, (float)550 );
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
   uScriptAct_FilterRect logic_uScriptAct_FilterRect_uScriptAct_FilterRect_18 = new uScriptAct_FilterRect( );
   UnityEngine.Rect logic_uScriptAct_FilterRect_Target_18 = new Rect( );
   System.Single logic_uScriptAct_FilterRect_FilterConstant_18 = (float) 0.05;
   UnityEngine.Rect logic_uScriptAct_FilterRect_Value_18;
   bool logic_uScriptAct_FilterRect_Out_18 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_24 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_24 = "";
   System.String logic_uScriptCon_CompareString_B_24 = "Select Weapon";
   bool logic_uScriptCon_CompareString_Same_24 = true;
   bool logic_uScriptCon_CompareString_Different_24 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_25 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_25 = "";
   System.String logic_uScriptCon_CompareString_B_25 = "UI Button Clicked";
   bool logic_uScriptCon_CompareString_Same_25 = true;
   bool logic_uScriptCon_CompareString_Different_25 = true;
   //pointer to script instanced logic node
   uScriptAct_CreateRelativeRectScreen logic_uScriptAct_CreateRelativeRectScreen_uScriptAct_CreateRelativeRectScreen_26 = new uScriptAct_CreateRelativeRectScreen( );
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_RectWidth_26 = (int) 600;
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_RectHeight_26 = (int) 550;
   uScriptAct_CreateRelativeRectScreen.Position logic_uScriptAct_CreateRelativeRectScreen_RectPosition_26 = uScriptAct_CreateRelativeRectScreen.Position.MiddleCenter;
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_xOffset_26 = (int) 0;
   System.Int32 logic_uScriptAct_CreateRelativeRectScreen_yOffset_26 = (int) 0;
   UnityEngine.Rect logic_uScriptAct_CreateRelativeRectScreen_OutputRect_26;
   bool logic_uScriptAct_CreateRelativeRectScreen_Out_26 = true;
   //pointer to script instanced logic node
   uScriptAct_GetComponentsRect logic_uScriptAct_GetComponentsRect_uScriptAct_GetComponentsRect_29 = new uScriptAct_GetComponentsRect( );
   UnityEngine.Rect logic_uScriptAct_GetComponentsRect_InputRect_29 = new Rect( );
   System.Single logic_uScriptAct_GetComponentsRect_Left_29;
   System.Single logic_uScriptAct_GetComponentsRect_Top_29;
   System.Single logic_uScriptAct_GetComponentsRect_Width_29;
   System.Single logic_uScriptAct_GetComponentsRect_Height_29;
   bool logic_uScriptAct_GetComponentsRect_Out_29 = true;
   //pointer to script instanced logic node
   uScriptAct_SetComponentsRect logic_uScriptAct_SetComponentsRect_uScriptAct_SetComponentsRect_31 = new uScriptAct_SetComponentsRect( );
   System.Single logic_uScriptAct_SetComponentsRect_Left_31 = (float) 2000;
   System.Single logic_uScriptAct_SetComponentsRect_Top_31 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsRect_Width_31 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsRect_Height_31 = (float) 0;
   UnityEngine.Rect logic_uScriptAct_SetComponentsRect_OutputRect_31;
   bool logic_uScriptAct_SetComponentsRect_Out_31 = true;
   //pointer to script instanced logic node
   uScriptAct_GetComponentsRect logic_uScriptAct_GetComponentsRect_uScriptAct_GetComponentsRect_34 = new uScriptAct_GetComponentsRect( );
   UnityEngine.Rect logic_uScriptAct_GetComponentsRect_InputRect_34 = new Rect( );
   System.Single logic_uScriptAct_GetComponentsRect_Left_34;
   System.Single logic_uScriptAct_GetComponentsRect_Top_34;
   System.Single logic_uScriptAct_GetComponentsRect_Width_34;
   System.Single logic_uScriptAct_GetComponentsRect_Height_34;
   bool logic_uScriptAct_GetComponentsRect_Out_34 = true;
   //pointer to script instanced logic node
   uScriptAct_SendCustomEventString logic_uScriptAct_SendCustomEventString_uScriptAct_SendCustomEventString_37 = new uScriptAct_SendCustomEventString( );
   System.String logic_uScriptAct_SendCustomEventString_EventName_37 = "UI Button Clicked";
   System.String logic_uScriptAct_SendCustomEventString_EventValue_37 = "";
   uScriptCustomEvent.SendGroup logic_uScriptAct_SendCustomEventString_sendGroup_37 = uScriptCustomEvent.SendGroup.All;
   UnityEngine.GameObject logic_uScriptAct_SendCustomEventString_EventSender_37 = default(UnityEngine.GameObject);
   bool logic_uScriptAct_SendCustomEventString_Out_37 = true;
   //pointer to script instanced logic node
   uScriptAct_SetComponentsRect logic_uScriptAct_SetComponentsRect_uScriptAct_SetComponentsRect_38 = new uScriptAct_SetComponentsRect( );
   System.Single logic_uScriptAct_SetComponentsRect_Left_38 = (float) 2000;
   System.Single logic_uScriptAct_SetComponentsRect_Top_38 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsRect_Width_38 = (float) 0;
   System.Single logic_uScriptAct_SetComponentsRect_Height_38 = (float) 0;
   UnityEngine.Rect logic_uScriptAct_SetComponentsRect_OutputRect_38;
   bool logic_uScriptAct_SetComponentsRect_Out_38 = true;
   //pointer to script instanced logic node
   uScriptAct_GUIButton logic_uScriptAct_GUIButton_uScriptAct_GUIButton_42 = new uScriptAct_GUIButton( );
   System.String logic_uScriptAct_GUIButton_Text_42 = "";
   System.Int32 logic_uScriptAct_GUIButton_identifier_42 = (int) 0;
   UnityEngine.Rect logic_uScriptAct_GUIButton_Position_42 = new Rect( );
   UnityEngine.Texture2D logic_uScriptAct_GUIButton_Texture_42 = default(UnityEngine.Texture2D);
   System.String logic_uScriptAct_GUIButton_ToolTip_42 = "";
   System.String logic_uScriptAct_GUIButton_guiStyle_42 = "";
   bool logic_uScriptAct_GUIButton_Out_42 = true;
   //pointer to script instanced logic node
   uScriptAct_GUIButton logic_uScriptAct_GUIButton_uScriptAct_GUIButton_43 = new uScriptAct_GUIButton( );
   System.String logic_uScriptAct_GUIButton_Text_43 = "";
   System.Int32 logic_uScriptAct_GUIButton_identifier_43 = (int) 0;
   UnityEngine.Rect logic_uScriptAct_GUIButton_Position_43 = new Rect( );
   UnityEngine.Texture2D logic_uScriptAct_GUIButton_Texture_43 = default(UnityEngine.Texture2D);
   System.String logic_uScriptAct_GUIButton_ToolTip_43 = "";
   System.String logic_uScriptAct_GUIButton_guiStyle_43 = "";
   bool logic_uScriptAct_GUIButton_Out_43 = true;
   //pointer to script instanced logic node
   uScriptAct_SetString logic_uScriptAct_SetString_uScriptAct_SetString_46 = new uScriptAct_SetString( );
   System.String logic_uScriptAct_SetString_Value_46 = "";
   System.Boolean logic_uScriptAct_SetString_ToUpperCase_46 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_ToLowerCase_46 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_TrimWhitespace_46 = (bool) false;
   System.String logic_uScriptAct_SetString_Target_46;
   bool logic_uScriptAct_SetString_Out_46 = true;
   //pointer to script instanced logic node
   uScriptAct_SetString logic_uScriptAct_SetString_uScriptAct_SetString_47 = new uScriptAct_SetString( );
   System.String logic_uScriptAct_SetString_Value_47 = "";
   System.Boolean logic_uScriptAct_SetString_ToUpperCase_47 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_ToLowerCase_47 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_TrimWhitespace_47 = (bool) false;
   System.String logic_uScriptAct_SetString_Target_47;
   bool logic_uScriptAct_SetString_Out_47 = true;
   //pointer to script instanced logic node
   uScriptAct_SetString logic_uScriptAct_SetString_uScriptAct_SetString_48 = new uScriptAct_SetString( );
   System.String logic_uScriptAct_SetString_Value_48 = "";
   System.Boolean logic_uScriptAct_SetString_ToUpperCase_48 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_ToLowerCase_48 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_TrimWhitespace_48 = (bool) false;
   System.String logic_uScriptAct_SetString_Target_48;
   bool logic_uScriptAct_SetString_Out_48 = true;
   //pointer to script instanced logic node
   uScriptAct_SetString logic_uScriptAct_SetString_uScriptAct_SetString_50 = new uScriptAct_SetString( );
   System.String logic_uScriptAct_SetString_Value_50 = "";
   System.Boolean logic_uScriptAct_SetString_ToUpperCase_50 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_ToLowerCase_50 = (bool) false;
   System.Boolean logic_uScriptAct_SetString_TrimWhitespace_50 = (bool) false;
   System.String logic_uScriptAct_SetString_Target_50;
   bool logic_uScriptAct_SetString_Out_50 = true;
   //pointer to script instanced logic node
   uScriptAct_GUILabel logic_uScriptAct_GUILabel_uScriptAct_GUILabel_51 = new uScriptAct_GUILabel( );
   System.String logic_uScriptAct_GUILabel_Text_51 = "";
   UnityEngine.Rect logic_uScriptAct_GUILabel_Position_51 = new Rect( (float)40, (float)280, (float)520, (float)48 );
   UnityEngine.Texture logic_uScriptAct_GUILabel_Texture_51 = default(UnityEngine.Texture);
   System.String logic_uScriptAct_GUILabel_ToolTip_51 = "";
   System.String logic_uScriptAct_GUILabel_guiStyle_51 = "";
   bool logic_uScriptAct_GUILabel_Out_51 = true;
   //pointer to script instanced logic node
   uScriptAct_LoadTexture2D logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_53 = new uScriptAct_LoadTexture2D( );
   System.String logic_uScriptAct_LoadTexture2D_name_53 = "ItemImages/sword1";
   UnityEngine.Texture2D logic_uScriptAct_LoadTexture2D_textureFile_53;
   bool logic_uScriptAct_LoadTexture2D_Out_53 = true;
   //pointer to script instanced logic node
   uScriptAct_LoadTexture2D logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_55 = new uScriptAct_LoadTexture2D( );
   System.String logic_uScriptAct_LoadTexture2D_name_55 = "ItemImages/sword2";
   UnityEngine.Texture2D logic_uScriptAct_LoadTexture2D_textureFile_55;
   bool logic_uScriptAct_LoadTexture2D_Out_55 = true;
   //pointer to script instanced logic node
   uScriptAct_LoadTexture2D logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_58 = new uScriptAct_LoadTexture2D( );
   System.String logic_uScriptAct_LoadTexture2D_name_58 = "ItemImages/sword3";
   UnityEngine.Texture2D logic_uScriptAct_LoadTexture2D_textureFile_58;
   bool logic_uScriptAct_LoadTexture2D_Out_58 = true;
   //pointer to script instanced logic node
   uScriptAct_LoadTexture2D logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_59 = new uScriptAct_LoadTexture2D( );
   System.String logic_uScriptAct_LoadTexture2D_name_59 = "ItemImages/sword4";
   UnityEngine.Texture2D logic_uScriptAct_LoadTexture2D_textureFile_59;
   bool logic_uScriptAct_LoadTexture2D_Out_59 = true;
   //pointer to script instanced logic node
   uScriptAct_SetTexture2D logic_uScriptAct_SetTexture2D_uScriptAct_SetTexture2D_61 = new uScriptAct_SetTexture2D( );
   UnityEngine.Texture2D logic_uScriptAct_SetTexture2D_Value_61 = default(UnityEngine.Texture2D);
   UnityEngine.Texture2D logic_uScriptAct_SetTexture2D_Target_61;
   bool logic_uScriptAct_SetTexture2D_Out_61 = true;
   //pointer to script instanced logic node
   uScriptAct_SetTexture2D logic_uScriptAct_SetTexture2D_uScriptAct_SetTexture2D_63 = new uScriptAct_SetTexture2D( );
   UnityEngine.Texture2D logic_uScriptAct_SetTexture2D_Value_63 = default(UnityEngine.Texture2D);
   UnityEngine.Texture2D logic_uScriptAct_SetTexture2D_Target_63;
   bool logic_uScriptAct_SetTexture2D_Out_63 = true;
   //pointer to script instanced logic node
   uScriptAct_SetTexture2D logic_uScriptAct_SetTexture2D_uScriptAct_SetTexture2D_64 = new uScriptAct_SetTexture2D( );
   UnityEngine.Texture2D logic_uScriptAct_SetTexture2D_Value_64 = default(UnityEngine.Texture2D);
   UnityEngine.Texture2D logic_uScriptAct_SetTexture2D_Target_64;
   bool logic_uScriptAct_SetTexture2D_Out_64 = true;
   //pointer to script instanced logic node
   uScriptAct_SetTexture2D logic_uScriptAct_SetTexture2D_uScriptAct_SetTexture2D_65 = new uScriptAct_SetTexture2D( );
   UnityEngine.Texture2D logic_uScriptAct_SetTexture2D_Value_65 = default(UnityEngine.Texture2D);
   UnityEngine.Texture2D logic_uScriptAct_SetTexture2D_Target_65;
   bool logic_uScriptAct_SetTexture2D_Out_65 = true;
   
   //event nodes
   System.Boolean event_UnityEngine_GameObject_GUIChanged_1 = (bool) false;
   System.String event_UnityEngine_GameObject_FocusedControl_1 = "";
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_1 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_3 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_17 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_21 = default(UnityEngine.GameObject);
   System.String event_UnityEngine_GameObject_EventName_21 = "";
   System.String event_UnityEngine_GameObject_EventData_21 = "";
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_21 = default(UnityEngine.GameObject);
   
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
      if ( null == event_UnityEngine_GameObject_Instance_17 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_17 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_17 )
         {
            {
               uScript_Update component = event_UnityEngine_GameObject_Instance_17.GetComponent<uScript_Update>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_17.AddComponent<uScript_Update>();
               }
               if ( null != component )
               {
                  component.OnUpdate += Instance_OnUpdate_17;
                  component.OnLateUpdate += Instance_OnLateUpdate_17;
                  component.OnFixedUpdate += Instance_OnFixedUpdate_17;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_21 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_21 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_21 )
         {
            {
               uScript_CustomEventString component = event_UnityEngine_GameObject_Instance_21.GetComponent<uScript_CustomEventString>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_21.AddComponent<uScript_CustomEventString>();
               }
               if ( null != component )
               {
                  component.OnCustomEventString += Instance_OnCustomEventString_21;
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
      if ( null != event_UnityEngine_GameObject_Instance_17 )
      {
         {
            uScript_Update component = event_UnityEngine_GameObject_Instance_17.GetComponent<uScript_Update>();
            if ( null != component )
            {
               component.OnUpdate -= Instance_OnUpdate_17;
               component.OnLateUpdate -= Instance_OnLateUpdate_17;
               component.OnFixedUpdate -= Instance_OnFixedUpdate_17;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_21 )
      {
         {
            uScript_CustomEventString component = event_UnityEngine_GameObject_Instance_21.GetComponent<uScript_CustomEventString>();
            if ( null != component )
            {
               component.OnCustomEventString -= Instance_OnCustomEventString_21;
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
      logic_uScriptAct_FilterRect_uScriptAct_FilterRect_18.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_24.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_25.SetParent(g);
      logic_uScriptAct_CreateRelativeRectScreen_uScriptAct_CreateRelativeRectScreen_26.SetParent(g);
      logic_uScriptAct_GetComponentsRect_uScriptAct_GetComponentsRect_29.SetParent(g);
      logic_uScriptAct_SetComponentsRect_uScriptAct_SetComponentsRect_31.SetParent(g);
      logic_uScriptAct_GetComponentsRect_uScriptAct_GetComponentsRect_34.SetParent(g);
      logic_uScriptAct_SendCustomEventString_uScriptAct_SendCustomEventString_37.SetParent(g);
      logic_uScriptAct_SetComponentsRect_uScriptAct_SetComponentsRect_38.SetParent(g);
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_42.SetParent(g);
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_43.SetParent(g);
      logic_uScriptAct_SetString_uScriptAct_SetString_46.SetParent(g);
      logic_uScriptAct_SetString_uScriptAct_SetString_47.SetParent(g);
      logic_uScriptAct_SetString_uScriptAct_SetString_48.SetParent(g);
      logic_uScriptAct_SetString_uScriptAct_SetString_50.SetParent(g);
      logic_uScriptAct_GUILabel_uScriptAct_GUILabel_51.SetParent(g);
      logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_53.SetParent(g);
      logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_55.SetParent(g);
      logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_58.SetParent(g);
      logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_59.SetParent(g);
      logic_uScriptAct_SetTexture2D_uScriptAct_SetTexture2D_61.SetParent(g);
      logic_uScriptAct_SetTexture2D_uScriptAct_SetTexture2D_63.SetParent(g);
      logic_uScriptAct_SetTexture2D_uScriptAct_SetTexture2D_64.SetParent(g);
      logic_uScriptAct_SetTexture2D_uScriptAct_SetTexture2D_65.SetParent(g);
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
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_42.OnButtonDown += uScriptAct_GUIButton_OnButtonDown_42;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_42.OnButtonHeld += uScriptAct_GUIButton_OnButtonHeld_42;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_42.OnButtonUp += uScriptAct_GUIButton_OnButtonUp_42;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_42.OnButtonClicked += uScriptAct_GUIButton_OnButtonClicked_42;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_43.OnButtonDown += uScriptAct_GUIButton_OnButtonDown_43;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_43.OnButtonHeld += uScriptAct_GUIButton_OnButtonHeld_43;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_43.OnButtonUp += uScriptAct_GUIButton_OnButtonUp_43;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_43.OnButtonClicked += uScriptAct_GUIButton_OnButtonClicked_43;
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
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_42.OnButtonDown -= uScriptAct_GUIButton_OnButtonDown_42;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_42.OnButtonHeld -= uScriptAct_GUIButton_OnButtonHeld_42;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_42.OnButtonUp -= uScriptAct_GUIButton_OnButtonUp_42;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_42.OnButtonClicked -= uScriptAct_GUIButton_OnButtonClicked_42;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_43.OnButtonDown -= uScriptAct_GUIButton_OnButtonDown_43;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_43.OnButtonHeld -= uScriptAct_GUIButton_OnButtonHeld_43;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_43.OnButtonUp -= uScriptAct_GUIButton_OnButtonUp_43;
      logic_uScriptAct_GUIButton_uScriptAct_GUIButton_43.OnButtonClicked -= uScriptAct_GUIButton_OnButtonClicked_43;
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
   
   void Instance_OnUpdate_17(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUpdate_17( );
   }
   
   void Instance_OnLateUpdate_17(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnLateUpdate_17( );
   }
   
   void Instance_OnFixedUpdate_17(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnFixedUpdate_17( );
   }
   
   void Instance_OnCustomEventString_21(object o, uScript_CustomEventString.CustomEventStringArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_21 = e.Sender;
      event_UnityEngine_GameObject_EventName_21 = e.EventName;
      event_UnityEngine_GameObject_EventData_21 = e.EventData;
      //relay event to nodes
      Relay_OnCustomEventString_21( );
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
   
   void uScriptAct_GUIButton_OnButtonDown_42(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonDown_42( );
   }
   
   void uScriptAct_GUIButton_OnButtonHeld_42(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonHeld_42( );
   }
   
   void uScriptAct_GUIButton_OnButtonUp_42(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonUp_42( );
   }
   
   void uScriptAct_GUIButton_OnButtonClicked_42(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonClicked_42( );
   }
   
   void uScriptAct_GUIButton_OnButtonDown_43(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonDown_43( );
   }
   
   void uScriptAct_GUIButton_OnButtonHeld_43(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonHeld_43( );
   }
   
   void uScriptAct_GUIButton_OnButtonUp_43(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonUp_43( );
   }
   
   void uScriptAct_GUIButton_OnButtonClicked_43(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnButtonClicked_43( );
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Begin Group.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
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
            Relay_In_29();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Create Relative Rect (Screen).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Box.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonClicked_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5fef6547-87c4-47b4-8280-a6793aa7e709", "GUI_Button", Relay_OnButtonClicked_7)) return; 
         Relay_In_46();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5fef6547-87c4-47b4-8280-a6793aa7e709", "GUI_Button", Relay_In_7)) return; 
         {
            {
               logic_uScriptAct_GUIButton_Text_7 = local_13_System_String;
               
            }
            {
            }
            {
               logic_uScriptAct_GUIButton_Position_7 = local_0_UnityEngine_Rect;
               
            }
            {
               logic_uScriptAct_GUIButton_Texture_7 = local_Sword1_UnityEngine_Texture2D;
               
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonClicked_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("42f651df-8829-43e7-8d11-333e64c7f17e", "GUI_Button", Relay_OnButtonClicked_9)) return; 
         Relay_In_47();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("42f651df-8829-43e7-8d11-333e64c7f17e", "GUI_Button", Relay_In_9)) return; 
         {
            {
               logic_uScriptAct_GUIButton_Text_9 = local_14_System_String;
               
            }
            {
            }
            {
               logic_uScriptAct_GUIButton_Position_9 = local_8_UnityEngine_Rect;
               
            }
            {
               logic_uScriptAct_GUIButton_Texture_9 = local_Sword2_UnityEngine_Texture2D;
               
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
            Relay_In_43();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3b561381-83f6-4e7e-af43-79a13065e583", "GUI_Button", Relay_In_10)) return; 
         {
            {
               logic_uScriptAct_GUIButton_Text_10 = local_15_System_String;
               
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI End Group.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnUpdate_17()
   {
      if (true == CheckDebugBreak("6f411169-b787-4ba5-8dff-9c129355d01b", "Global_Update", Relay_OnUpdate_17)) return; 
      Relay_Filter_18();
   }
   
   void Relay_OnLateUpdate_17()
   {
      if (true == CheckDebugBreak("6f411169-b787-4ba5-8dff-9c129355d01b", "Global_Update", Relay_OnLateUpdate_17)) return; 
   }
   
   void Relay_OnFixedUpdate_17()
   {
      if (true == CheckDebugBreak("6f411169-b787-4ba5-8dff-9c129355d01b", "Global_Update", Relay_OnFixedUpdate_17)) return; 
   }
   
   void Relay_Reset_18()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("07cb7dc7-127e-429c-8b73-a68849028c77", "Filter_Rect", Relay_Reset_18)) return; 
         {
            {
               logic_uScriptAct_FilterRect_Target_18 = local_Target_Rect_UnityEngine_Rect;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_FilterRect_uScriptAct_FilterRect_18.Reset(logic_uScriptAct_FilterRect_Target_18, logic_uScriptAct_FilterRect_FilterConstant_18, out logic_uScriptAct_FilterRect_Value_18);
         local_Filtered_Rect_UnityEngine_Rect = logic_uScriptAct_FilterRect_Value_18;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Filter Rect.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Filter_18()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("07cb7dc7-127e-429c-8b73-a68849028c77", "Filter_Rect", Relay_Filter_18)) return; 
         {
            {
               logic_uScriptAct_FilterRect_Target_18 = local_Target_Rect_UnityEngine_Rect;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_FilterRect_uScriptAct_FilterRect_18.Filter(logic_uScriptAct_FilterRect_Target_18, logic_uScriptAct_FilterRect_FilterConstant_18, out logic_uScriptAct_FilterRect_Value_18);
         local_Filtered_Rect_UnityEngine_Rect = logic_uScriptAct_FilterRect_Value_18;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Filter Rect.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnCustomEventString_21()
   {
      if (true == CheckDebugBreak("1d6d4a07-bce2-4eea-a953-a8478cc30661", "Custom_Event__String_", Relay_OnCustomEventString_21)) return; 
      local_22_System_String = event_UnityEngine_GameObject_EventName_21;
      local_23_System_String = event_UnityEngine_GameObject_EventData_21;
      Relay_In_25();
   }
   
   void Relay_In_24()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("759827d3-d770-4b3d-bc8c-57687f83fafc", "Compare_String", Relay_In_24)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_24 = local_23_System_String;
               
            }
            {
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_24.In(logic_uScriptCon_CompareString_A_24, logic_uScriptCon_CompareString_B_24);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_24.Same;
         
         if ( test_0 == true )
         {
            Relay_In_26();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_25()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("aac8d650-712b-4248-b513-14bcd5c7ce29", "Compare_String", Relay_In_25)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_25 = local_22_System_String;
               
            }
            {
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_25.In(logic_uScriptCon_CompareString_A_25, logic_uScriptCon_CompareString_B_25);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_25.Same;
         
         if ( test_0 == true )
         {
            Relay_In_24();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_26()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c8f331db-f880-48f3-92d0-08aced7c34c8", "Create_Relative_Rect__Screen_", Relay_In_26)) return; 
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
         logic_uScriptAct_CreateRelativeRectScreen_uScriptAct_CreateRelativeRectScreen_26.In(logic_uScriptAct_CreateRelativeRectScreen_RectWidth_26, logic_uScriptAct_CreateRelativeRectScreen_RectHeight_26, logic_uScriptAct_CreateRelativeRectScreen_RectPosition_26, logic_uScriptAct_CreateRelativeRectScreen_xOffset_26, logic_uScriptAct_CreateRelativeRectScreen_yOffset_26, out logic_uScriptAct_CreateRelativeRectScreen_OutputRect_26);
         local_Target_Rect_UnityEngine_Rect = logic_uScriptAct_CreateRelativeRectScreen_OutputRect_26;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Create Relative Rect (Screen).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_29()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ab90415b-4dc2-4605-8dc7-a127b9a43e71", "Get_Components__Rect_", Relay_In_29)) return; 
         {
            {
               logic_uScriptAct_GetComponentsRect_InputRect_29 = local_Target_Rect_UnityEngine_Rect;
               
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
         logic_uScriptAct_GetComponentsRect_uScriptAct_GetComponentsRect_29.In(logic_uScriptAct_GetComponentsRect_InputRect_29, out logic_uScriptAct_GetComponentsRect_Left_29, out logic_uScriptAct_GetComponentsRect_Top_29, out logic_uScriptAct_GetComponentsRect_Width_29, out logic_uScriptAct_GetComponentsRect_Height_29);
         local_28_System_Single = logic_uScriptAct_GetComponentsRect_Top_29;
         local_32_System_Single = logic_uScriptAct_GetComponentsRect_Width_29;
         local_30_System_Single = logic_uScriptAct_GetComponentsRect_Height_29;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetComponentsRect_uScriptAct_GetComponentsRect_29.Out;
         
         if ( test_0 == true )
         {
            Relay_In_31();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Get Components (Rect).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_31()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d460684c-6acd-4352-aafd-b66804f7d228", "Set_Components__Rect_", Relay_In_31)) return; 
         {
            {
            }
            {
               logic_uScriptAct_SetComponentsRect_Top_31 = local_28_System_Single;
               
            }
            {
               logic_uScriptAct_SetComponentsRect_Width_31 = local_32_System_Single;
               
            }
            {
               logic_uScriptAct_SetComponentsRect_Height_31 = local_30_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_SetComponentsRect_uScriptAct_SetComponentsRect_31.In(logic_uScriptAct_SetComponentsRect_Left_31, logic_uScriptAct_SetComponentsRect_Top_31, logic_uScriptAct_SetComponentsRect_Width_31, logic_uScriptAct_SetComponentsRect_Height_31, out logic_uScriptAct_SetComponentsRect_OutputRect_31);
         local_Target_Rect_UnityEngine_Rect = logic_uScriptAct_SetComponentsRect_OutputRect_31;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetComponentsRect_uScriptAct_SetComponentsRect_31.Out;
         
         if ( test_0 == true )
         {
            Relay_Reset_18();
            Relay_In_53();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Set Components (Rect).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_34()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b2adeacb-fa4c-40f3-a809-a77876ea0087", "Get_Components__Rect_", Relay_In_34)) return; 
         {
            {
               logic_uScriptAct_GetComponentsRect_InputRect_34 = local_Target_Rect_UnityEngine_Rect;
               
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
         logic_uScriptAct_GetComponentsRect_uScriptAct_GetComponentsRect_34.In(logic_uScriptAct_GetComponentsRect_InputRect_34, out logic_uScriptAct_GetComponentsRect_Left_34, out logic_uScriptAct_GetComponentsRect_Top_34, out logic_uScriptAct_GetComponentsRect_Width_34, out logic_uScriptAct_GetComponentsRect_Height_34);
         local_33_System_Single = logic_uScriptAct_GetComponentsRect_Top_34;
         local_39_System_Single = logic_uScriptAct_GetComponentsRect_Width_34;
         local_36_System_Single = logic_uScriptAct_GetComponentsRect_Height_34;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetComponentsRect_uScriptAct_GetComponentsRect_34.Out;
         
         if ( test_0 == true )
         {
            Relay_In_38();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Get Components (Rect).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_SendCustomEvent_37()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4c0c2678-3ddb-435c-9fcf-f987c98bc601", "Send_Custom_Event__String_", Relay_SendCustomEvent_37)) return; 
         {
            {
            }
            {
               logic_uScriptAct_SendCustomEventString_EventValue_37 = local_15_System_String;
               
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
            Relay_In_34();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Send Custom Event (String).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_38()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("93a7cb18-5a50-4ce9-b5a4-fce1e9c966f8", "Set_Components__Rect_", Relay_In_38)) return; 
         {
            {
            }
            {
               logic_uScriptAct_SetComponentsRect_Top_38 = local_33_System_Single;
               
            }
            {
               logic_uScriptAct_SetComponentsRect_Width_38 = local_39_System_Single;
               
            }
            {
               logic_uScriptAct_SetComponentsRect_Height_38 = local_36_System_Single;
               
            }
            {
            }
         }
         logic_uScriptAct_SetComponentsRect_uScriptAct_SetComponentsRect_38.In(logic_uScriptAct_SetComponentsRect_Left_38, logic_uScriptAct_SetComponentsRect_Top_38, logic_uScriptAct_SetComponentsRect_Width_38, logic_uScriptAct_SetComponentsRect_Height_38, out logic_uScriptAct_SetComponentsRect_OutputRect_38);
         local_Target_Rect_UnityEngine_Rect = logic_uScriptAct_SetComponentsRect_OutputRect_38;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Set Components (Rect).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonDown_42()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c2b8aee4-12d3-42cf-a2f5-682cf38df548", "GUI_Button", Relay_OnButtonDown_42)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonHeld_42()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c2b8aee4-12d3-42cf-a2f5-682cf38df548", "GUI_Button", Relay_OnButtonHeld_42)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonUp_42()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c2b8aee4-12d3-42cf-a2f5-682cf38df548", "GUI_Button", Relay_OnButtonUp_42)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonClicked_42()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c2b8aee4-12d3-42cf-a2f5-682cf38df548", "GUI_Button", Relay_OnButtonClicked_42)) return; 
         Relay_In_50();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_42()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c2b8aee4-12d3-42cf-a2f5-682cf38df548", "GUI_Button", Relay_In_42)) return; 
         {
            {
               logic_uScriptAct_GUIButton_Text_42 = local_40_System_String;
               
            }
            {
            }
            {
               logic_uScriptAct_GUIButton_Position_42 = local_45_UnityEngine_Rect;
               
            }
            {
               logic_uScriptAct_GUIButton_Texture_42 = local_Sword4_UnityEngine_Texture2D;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_GUIButton_uScriptAct_GUIButton_42.In(logic_uScriptAct_GUIButton_Text_42, logic_uScriptAct_GUIButton_identifier_42, logic_uScriptAct_GUIButton_Position_42, logic_uScriptAct_GUIButton_Texture_42, logic_uScriptAct_GUIButton_ToolTip_42, logic_uScriptAct_GUIButton_guiStyle_42);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUIButton_uScriptAct_GUIButton_42.Out;
         
         if ( test_0 == true )
         {
            Relay_In_51();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonDown_43()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3f64a886-8d5b-4fae-8374-188ba408cfe1", "GUI_Button", Relay_OnButtonDown_43)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonHeld_43()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3f64a886-8d5b-4fae-8374-188ba408cfe1", "GUI_Button", Relay_OnButtonHeld_43)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonUp_43()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3f64a886-8d5b-4fae-8374-188ba408cfe1", "GUI_Button", Relay_OnButtonUp_43)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnButtonClicked_43()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3f64a886-8d5b-4fae-8374-188ba408cfe1", "GUI_Button", Relay_OnButtonClicked_43)) return; 
         Relay_In_48();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_43()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3f64a886-8d5b-4fae-8374-188ba408cfe1", "GUI_Button", Relay_In_43)) return; 
         {
            {
               logic_uScriptAct_GUIButton_Text_43 = local_41_System_String;
               
            }
            {
            }
            {
               logic_uScriptAct_GUIButton_Position_43 = local_44_UnityEngine_Rect;
               
            }
            {
               logic_uScriptAct_GUIButton_Texture_43 = local_Sword3_UnityEngine_Texture2D;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_GUIButton_uScriptAct_GUIButton_43.In(logic_uScriptAct_GUIButton_Text_43, logic_uScriptAct_GUIButton_identifier_43, logic_uScriptAct_GUIButton_Position_43, logic_uScriptAct_GUIButton_Texture_43, logic_uScriptAct_GUIButton_ToolTip_43, logic_uScriptAct_GUIButton_guiStyle_43);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUIButton_uScriptAct_GUIButton_43.Out;
         
         if ( test_0 == true )
         {
            Relay_In_42();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Button.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_46()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("92f4ca19-fdd3-4bc4-910d-64a47cf93b7f", "Set_String", Relay_In_46)) return; 
         {
            {
               logic_uScriptAct_SetString_Value_46 = local_13_System_String;
               
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
         logic_uScriptAct_SetString_uScriptAct_SetString_46.In(logic_uScriptAct_SetString_Value_46, logic_uScriptAct_SetString_ToUpperCase_46, logic_uScriptAct_SetString_ToLowerCase_46, logic_uScriptAct_SetString_TrimWhitespace_46, out logic_uScriptAct_SetString_Target_46);
         local_Weapon_Name_System_String = logic_uScriptAct_SetString_Target_46;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetString_uScriptAct_SetString_46.Out;
         
         if ( test_0 == true )
         {
            Relay_In_65();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Set String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_47()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b1a844f3-f541-4add-a9f0-d167a1eb18d9", "Set_String", Relay_In_47)) return; 
         {
            {
               logic_uScriptAct_SetString_Value_47 = local_14_System_String;
               
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
         logic_uScriptAct_SetString_uScriptAct_SetString_47.In(logic_uScriptAct_SetString_Value_47, logic_uScriptAct_SetString_ToUpperCase_47, logic_uScriptAct_SetString_ToLowerCase_47, logic_uScriptAct_SetString_TrimWhitespace_47, out logic_uScriptAct_SetString_Target_47);
         local_Weapon_Name_System_String = logic_uScriptAct_SetString_Target_47;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetString_uScriptAct_SetString_47.Out;
         
         if ( test_0 == true )
         {
            Relay_In_64();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Set String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_48()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("105a6f51-0871-4212-a6d7-4509d26cc319", "Set_String", Relay_In_48)) return; 
         {
            {
               logic_uScriptAct_SetString_Value_48 = local_41_System_String;
               
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
         logic_uScriptAct_SetString_uScriptAct_SetString_48.In(logic_uScriptAct_SetString_Value_48, logic_uScriptAct_SetString_ToUpperCase_48, logic_uScriptAct_SetString_ToLowerCase_48, logic_uScriptAct_SetString_TrimWhitespace_48, out logic_uScriptAct_SetString_Target_48);
         local_Weapon_Name_System_String = logic_uScriptAct_SetString_Target_48;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetString_uScriptAct_SetString_48.Out;
         
         if ( test_0 == true )
         {
            Relay_In_63();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Set String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_50()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ecf9cd53-7dd7-4180-b06c-fed17905a765", "Set_String", Relay_In_50)) return; 
         {
            {
               logic_uScriptAct_SetString_Value_50 = local_40_System_String;
               
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
         logic_uScriptAct_SetString_uScriptAct_SetString_50.In(logic_uScriptAct_SetString_Value_50, logic_uScriptAct_SetString_ToUpperCase_50, logic_uScriptAct_SetString_ToLowerCase_50, logic_uScriptAct_SetString_TrimWhitespace_50, out logic_uScriptAct_SetString_Target_50);
         local_Weapon_Name_System_String = logic_uScriptAct_SetString_Target_50;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetString_uScriptAct_SetString_50.Out;
         
         if ( test_0 == true )
         {
            Relay_In_61();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Set String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_51()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8b01cde3-9ab2-4919-9376-921090e12e52", "GUI_Label", Relay_In_51)) return; 
         {
            {
               logic_uScriptAct_GUILabel_Text_51 = local_Weapon_Name_System_String;
               
            }
            {
            }
            {
               logic_uScriptAct_GUILabel_Texture_51 = local_Weapon_Texture_UnityEngine_Texture2D;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_GUILabel_uScriptAct_GUILabel_51.In(logic_uScriptAct_GUILabel_Text_51, logic_uScriptAct_GUILabel_Position_51, logic_uScriptAct_GUILabel_Texture_51, logic_uScriptAct_GUILabel_ToolTip_51, logic_uScriptAct_GUILabel_guiStyle_51);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GUILabel_uScriptAct_GUILabel_51.Out;
         
         if ( test_0 == true )
         {
            Relay_In_10();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at GUI Label.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_53()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("584235cf-486b-4f51-aa54-8d9887e28335", "Load_Texture2D", Relay_In_53)) return; 
         {
            {
            }
            {
            }
         }
         logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_53.In(logic_uScriptAct_LoadTexture2D_name_53, out logic_uScriptAct_LoadTexture2D_textureFile_53);
         local_Sword1_UnityEngine_Texture2D = logic_uScriptAct_LoadTexture2D_textureFile_53;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_53.Out;
         
         if ( test_0 == true )
         {
            Relay_In_55();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Load Texture2D.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_55()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0d1ef9b7-7dec-4287-8978-987503c1d0c3", "Load_Texture2D", Relay_In_55)) return; 
         {
            {
            }
            {
            }
         }
         logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_55.In(logic_uScriptAct_LoadTexture2D_name_55, out logic_uScriptAct_LoadTexture2D_textureFile_55);
         local_Sword2_UnityEngine_Texture2D = logic_uScriptAct_LoadTexture2D_textureFile_55;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_55.Out;
         
         if ( test_0 == true )
         {
            Relay_In_58();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Load Texture2D.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_58()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d532c102-9be6-4b42-836f-4314d2d6d803", "Load_Texture2D", Relay_In_58)) return; 
         {
            {
            }
            {
            }
         }
         logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_58.In(logic_uScriptAct_LoadTexture2D_name_58, out logic_uScriptAct_LoadTexture2D_textureFile_58);
         local_Sword3_UnityEngine_Texture2D = logic_uScriptAct_LoadTexture2D_textureFile_58;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_58.Out;
         
         if ( test_0 == true )
         {
            Relay_In_59();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Load Texture2D.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_59()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a77d255d-fcd0-44fe-945f-953ab30c3bf2", "Load_Texture2D", Relay_In_59)) return; 
         {
            {
            }
            {
            }
         }
         logic_uScriptAct_LoadTexture2D_uScriptAct_LoadTexture2D_59.In(logic_uScriptAct_LoadTexture2D_name_59, out logic_uScriptAct_LoadTexture2D_textureFile_59);
         local_Sword4_UnityEngine_Texture2D = logic_uScriptAct_LoadTexture2D_textureFile_59;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Load Texture2D.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_61()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8f745760-5de3-4737-aa59-0e1b105d9fab", "Set_Texture2D", Relay_In_61)) return; 
         {
            {
               logic_uScriptAct_SetTexture2D_Value_61 = local_Sword4_UnityEngine_Texture2D;
               
            }
            {
            }
         }
         logic_uScriptAct_SetTexture2D_uScriptAct_SetTexture2D_61.In(logic_uScriptAct_SetTexture2D_Value_61, out logic_uScriptAct_SetTexture2D_Target_61);
         local_Weapon_Texture_UnityEngine_Texture2D = logic_uScriptAct_SetTexture2D_Target_61;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Set Texture2D.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_63()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0797f498-c820-44d4-884b-8aadbb110b94", "Set_Texture2D", Relay_In_63)) return; 
         {
            {
               logic_uScriptAct_SetTexture2D_Value_63 = local_Sword3_UnityEngine_Texture2D;
               
            }
            {
            }
         }
         logic_uScriptAct_SetTexture2D_uScriptAct_SetTexture2D_63.In(logic_uScriptAct_SetTexture2D_Value_63, out logic_uScriptAct_SetTexture2D_Target_63);
         local_Weapon_Texture_UnityEngine_Texture2D = logic_uScriptAct_SetTexture2D_Target_63;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Set Texture2D.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_64()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("04eac4c9-2710-48d3-b95a-5cb7c03e1d9c", "Set_Texture2D", Relay_In_64)) return; 
         {
            {
               logic_uScriptAct_SetTexture2D_Value_64 = local_Sword2_UnityEngine_Texture2D;
               
            }
            {
            }
         }
         logic_uScriptAct_SetTexture2D_uScriptAct_SetTexture2D_64.In(logic_uScriptAct_SetTexture2D_Value_64, out logic_uScriptAct_SetTexture2D_Target_64);
         local_Weapon_Texture_UnityEngine_Texture2D = logic_uScriptAct_SetTexture2D_Target_64;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Set Texture2D.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_65()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9986cd46-6a67-4c15-bde6-b4bb159b5230", "Set_Texture2D", Relay_In_65)) return; 
         {
            {
               logic_uScriptAct_SetTexture2D_Value_65 = local_Sword1_UnityEngine_Texture2D;
               
            }
            {
            }
         }
         logic_uScriptAct_SetTexture2D_uScriptAct_SetTexture2D_65.In(logic_uScriptAct_SetTexture2D_Value_65, out logic_uScriptAct_SetTexture2D_Target_65);
         local_Weapon_Texture_UnityEngine_Texture2D = logic_uScriptAct_SetTexture2D_Target_65;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AdvancedUI_SelectWeapon.uscript at Set Texture2D.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:0", local_0_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "907cf769-7d4f-41cb-b344-41fb5b36d17d", local_0_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:8", local_8_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "972e8b1d-c359-4ce4-b539-5cdd38647cd2", local_8_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:11", local_11_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b6b56357-42a2-4daa-affd-f8db9ed8e883", local_11_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:13", local_13_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "283d9abb-fe24-4a35-81ba-b5126070baac", local_13_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:14", local_14_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ad92e525-6e47-40c8-a433-faec354a299d", local_14_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:15", local_15_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ff4ec241-4417-4230-b8ae-68c41d09311f", local_15_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:Filtered Rect", local_Filtered_Rect_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c98ee999-5487-4103-a887-6231475c32c1", local_Filtered_Rect_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:22", local_22_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d5a5c1b8-856d-402c-8e9f-5a6d7cbce250", local_22_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:23", local_23_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "eb1ca6d6-9f7a-428c-a03a-76b29f4a7aa8", local_23_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:28", local_28_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "a0b2612d-df13-4337-b420-ef4c336aff23", local_28_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:30", local_30_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d71e4ff7-9da3-4021-aa91-b76a19473289", local_30_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:32", local_32_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "02c0c05d-fb9c-4b72-b3fc-2e2e5c08a719", local_32_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:33", local_33_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f50d6c49-86f2-4859-bf8b-284065e70c44", local_33_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:Target Rect", local_Target_Rect_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "cc32696d-b027-486f-bddc-13d9e63feb3b", local_Target_Rect_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:36", local_36_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "2dbd8ad0-69b2-40bc-8a12-6baa0b82da4d", local_36_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:39", local_39_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "6af4d8f2-9469-424f-b583-cc1005207d09", local_39_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:40", local_40_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7f86af58-f0b6-45ff-bc79-3e3243de8c17", local_40_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:41", local_41_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c5b1b0d8-0fee-4ab3-bbe8-6cc9485f2a70", local_41_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:44", local_44_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d7f5184d-d504-4e63-83f0-c1da39c12869", local_44_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:45", local_45_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "96009155-63e3-4250-91c7-f39dac66017e", local_45_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:Weapon Name", local_Weapon_Name_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "79635fcc-9df0-49fa-aa9c-0677814cdedb", local_Weapon_Name_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:Weapon Texture", local_Weapon_Texture_UnityEngine_Texture2D);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "2c2f9684-c310-45e1-a181-6c6814922892", local_Weapon_Texture_UnityEngine_Texture2D);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:Sword1", local_Sword1_UnityEngine_Texture2D);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c9513062-0d40-4e5d-8d87-ee2998b2251e", local_Sword1_UnityEngine_Texture2D);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:Sword2", local_Sword2_UnityEngine_Texture2D);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "50dad80d-0b19-4488-8a79-321c6802f1ae", local_Sword2_UnityEngine_Texture2D);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:Sword3", local_Sword3_UnityEngine_Texture2D);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "4bfb2640-3afe-4e6c-ad72-93463ea2fc5e", local_Sword3_UnityEngine_Texture2D);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AdvancedUI_SelectWeapon.uscript:Sword4", local_Sword4_UnityEngine_Texture2D);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "57eaaec6-f973-40f0-a892-522a257599af", local_Sword4_UnityEngine_Texture2D);
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
