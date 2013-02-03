//uScript Generated Code - Build 0.9.2215
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class Doors_DoorLockablePrefabGraph : uScriptLogic
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
   System.String local_12_System_String = "Door_Light_Mesh";
   System.String local_17_System_String = "Door_R";
   System.String local_18_System_String = "Door_L";
   System.String local_25_System_String = "";
   System.String local_27_System_String = "HasKeyQuery";
   System.String local_30_System_String = "HasKeyValue";
   System.Boolean local_45_System_Boolean = (bool) false;
   UnityEngine.GameObject local_46_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_46_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_Door_L_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Door_L_UnityEngine_GameObject_previous = null;
   System.Boolean local_Door_Open__System_Boolean = (bool) false;
   UnityEngine.GameObject local_Door_R_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Door_R_UnityEngine_GameObject_previous = null;
   System.Boolean local_Has_Key_System_Boolean = (bool) false;
   
   //owner nodes
   UnityEngine.GameObject owner_Connection_4 = null;
   UnityEngine.GameObject owner_Connection_10 = null;
   UnityEngine.GameObject owner_Connection_15 = null;
   UnityEngine.GameObject owner_Connection_28 = null;
   UnityEngine.GameObject owner_Connection_43 = null;
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_1 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_1 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_1 = true;
   bool logic_uScriptCon_CompareBool_False_1 = true;
   //pointer to script instanced logic node
   uScriptAct_AssignMaterialColor logic_uScriptAct_AssignMaterialColor_uScriptAct_AssignMaterialColor_2 = new uScriptAct_AssignMaterialColor( );
   UnityEngine.GameObject[] logic_uScriptAct_AssignMaterialColor_Target_2 = new UnityEngine.GameObject[] {};
   UnityEngine.Color logic_uScriptAct_AssignMaterialColor_MatColor_2 = new UnityEngine.Color( (float)0, (float)1, (float)0.03529412, (float)1 );
   System.Int32 logic_uScriptAct_AssignMaterialColor_MatChannel_2 = (int) 0;
   bool logic_uScriptAct_AssignMaterialColor_Out_2 = true;
   //pointer to script instanced logic node
   uScriptAct_PlayAnimation logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_5 = new uScriptAct_PlayAnimation( );
   UnityEngine.GameObject[] logic_uScriptAct_PlayAnimation_Target_5 = new UnityEngine.GameObject[] {};
   System.String logic_uScriptAct_PlayAnimation_Animation_5 = "PrefabDoorLOpenAnim";
   System.Single logic_uScriptAct_PlayAnimation_SpeedFactor_5 = (float) 1;
   UnityEngine.WrapMode logic_uScriptAct_PlayAnimation_AnimWrapMode_5 = UnityEngine.WrapMode.Once;
   System.Boolean logic_uScriptAct_PlayAnimation_StopOtherAnimations_5 = (bool) true;
   bool logic_uScriptAct_PlayAnimation_Out_5 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareString logic_uScriptCon_CompareString_uScriptCon_CompareString_6 = new uScriptCon_CompareString( );
   System.String logic_uScriptCon_CompareString_A_6 = "";
   System.String logic_uScriptCon_CompareString_B_6 = "";
   bool logic_uScriptCon_CompareString_Same_6 = true;
   bool logic_uScriptCon_CompareString_Different_6 = true;
   //pointer to script instanced logic node
   uScriptAct_SendCustomEvent logic_uScriptAct_SendCustomEvent_uScriptAct_SendCustomEvent_8 = new uScriptAct_SendCustomEvent( );
   System.String logic_uScriptAct_SendCustomEvent_EventName_8 = "";
   uScriptCustomEvent.SendGroup logic_uScriptAct_SendCustomEvent_sendGroup_8 = uScriptCustomEvent.SendGroup.All;
   UnityEngine.GameObject logic_uScriptAct_SendCustomEvent_EventSender_8 = null;
   bool logic_uScriptAct_SendCustomEvent_Out_8 = true;
   //pointer to script instanced logic node
   uScriptAct_PlayAnimation logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_9 = new uScriptAct_PlayAnimation( );
   UnityEngine.GameObject[] logic_uScriptAct_PlayAnimation_Target_9 = new UnityEngine.GameObject[] {};
   System.String logic_uScriptAct_PlayAnimation_Animation_9 = "PrefabDoorROpenAnim";
   System.Single logic_uScriptAct_PlayAnimation_SpeedFactor_9 = (float) -1;
   UnityEngine.WrapMode logic_uScriptAct_PlayAnimation_AnimWrapMode_9 = UnityEngine.WrapMode.Once;
   System.Boolean logic_uScriptAct_PlayAnimation_StopOtherAnimations_9 = (bool) true;
   bool logic_uScriptAct_PlayAnimation_Out_9 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_11 = new uScriptAct_Delay( );
   System.Single logic_uScriptAct_Delay_Duration_11 = (float) 3;
   bool logic_uScriptAct_Delay_Immediate_11 = true;
   bool logic_uScriptAct_Delay_AfterDelay_11 = true;
   bool logic_uScriptAct_Delay_DrivenDelay_11 = false;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_13 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_13;
   bool logic_uScriptAct_SetBool_Out_13 = true;
   bool logic_uScriptAct_SetBool_SetTrue_13 = true;
   bool logic_uScriptAct_SetBool_SetFalse_13 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_20 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_20;
   bool logic_uScriptAct_SetBool_Out_20 = true;
   bool logic_uScriptAct_SetBool_SetTrue_20 = true;
   bool logic_uScriptAct_SetBool_SetFalse_20 = true;
   //pointer to script instanced logic node
   uScriptAct_GetChildrenByName logic_uScriptAct_GetChildrenByName_uScriptAct_GetChildrenByName_21 = new uScriptAct_GetChildrenByName( );
   UnityEngine.GameObject logic_uScriptAct_GetChildrenByName_Target_21 = null;
   System.String logic_uScriptAct_GetChildrenByName_Name_21 = "";
   uScriptAct_GetChildrenByName.SearchType logic_uScriptAct_GetChildrenByName_SearchMethod_21 = uScriptAct_GetChildrenByName.SearchType.Matches;
   System.Boolean logic_uScriptAct_GetChildrenByName_recursive_21 = (bool) false;
   UnityEngine.GameObject logic_uScriptAct_GetChildrenByName_FirstChild_21;
   UnityEngine.GameObject[] logic_uScriptAct_GetChildrenByName_Children_21;
   System.Int32 logic_uScriptAct_GetChildrenByName_ChildrenCount_21;
   bool logic_uScriptAct_GetChildrenByName_Out_21 = true;
   bool logic_uScriptAct_GetChildrenByName_ChildrenFound_21 = true;
   bool logic_uScriptAct_GetChildrenByName_ChildrenNotFound_21 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_22 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_22;
   bool logic_uScriptAct_SetBool_Out_22 = true;
   bool logic_uScriptAct_SetBool_SetTrue_22 = true;
   bool logic_uScriptAct_SetBool_SetFalse_22 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_23 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_23 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_23 = true;
   bool logic_uScriptCon_CompareBool_False_23 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_33 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_33 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_33 = true;
   bool logic_uScriptCon_CompareBool_False_33 = true;
   //pointer to script instanced logic node
   uScriptAct_GetChildrenByName logic_uScriptAct_GetChildrenByName_uScriptAct_GetChildrenByName_34 = new uScriptAct_GetChildrenByName( );
   UnityEngine.GameObject logic_uScriptAct_GetChildrenByName_Target_34 = null;
   System.String logic_uScriptAct_GetChildrenByName_Name_34 = "";
   uScriptAct_GetChildrenByName.SearchType logic_uScriptAct_GetChildrenByName_SearchMethod_34 = uScriptAct_GetChildrenByName.SearchType.Matches;
   System.Boolean logic_uScriptAct_GetChildrenByName_recursive_34 = (bool) false;
   UnityEngine.GameObject logic_uScriptAct_GetChildrenByName_FirstChild_34;
   UnityEngine.GameObject[] logic_uScriptAct_GetChildrenByName_Children_34;
   System.Int32 logic_uScriptAct_GetChildrenByName_ChildrenCount_34;
   bool logic_uScriptAct_GetChildrenByName_Out_34 = true;
   bool logic_uScriptAct_GetChildrenByName_ChildrenFound_34 = true;
   bool logic_uScriptAct_GetChildrenByName_ChildrenNotFound_34 = true;
   //pointer to script instanced logic node
   uScriptAct_GetChildrenByName logic_uScriptAct_GetChildrenByName_uScriptAct_GetChildrenByName_35 = new uScriptAct_GetChildrenByName( );
   UnityEngine.GameObject logic_uScriptAct_GetChildrenByName_Target_35 = null;
   System.String logic_uScriptAct_GetChildrenByName_Name_35 = "";
   uScriptAct_GetChildrenByName.SearchType logic_uScriptAct_GetChildrenByName_SearchMethod_35 = uScriptAct_GetChildrenByName.SearchType.Matches;
   System.Boolean logic_uScriptAct_GetChildrenByName_recursive_35 = (bool) false;
   UnityEngine.GameObject logic_uScriptAct_GetChildrenByName_FirstChild_35;
   UnityEngine.GameObject[] logic_uScriptAct_GetChildrenByName_Children_35;
   System.Int32 logic_uScriptAct_GetChildrenByName_ChildrenCount_35;
   bool logic_uScriptAct_GetChildrenByName_Out_35 = true;
   bool logic_uScriptAct_GetChildrenByName_ChildrenFound_35 = true;
   bool logic_uScriptAct_GetChildrenByName_ChildrenNotFound_35 = true;
   //pointer to script instanced logic node
   uScriptAct_PlayAnimation logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_38 = new uScriptAct_PlayAnimation( );
   UnityEngine.GameObject[] logic_uScriptAct_PlayAnimation_Target_38 = new UnityEngine.GameObject[] {};
   System.String logic_uScriptAct_PlayAnimation_Animation_38 = "PrefabDoorLOpenAnim";
   System.Single logic_uScriptAct_PlayAnimation_SpeedFactor_38 = (float) -1;
   UnityEngine.WrapMode logic_uScriptAct_PlayAnimation_AnimWrapMode_38 = UnityEngine.WrapMode.Once;
   System.Boolean logic_uScriptAct_PlayAnimation_StopOtherAnimations_38 = (bool) true;
   bool logic_uScriptAct_PlayAnimation_Out_38 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_39 = new uScriptAct_Delay( );
   System.Single logic_uScriptAct_Delay_Duration_39 = (float) 3;
   bool logic_uScriptAct_Delay_Immediate_39 = true;
   bool logic_uScriptAct_Delay_AfterDelay_39 = true;
   bool logic_uScriptAct_Delay_DrivenDelay_39 = false;
   //pointer to script instanced logic node
   uScriptAct_PlayAnimation logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_44 = new uScriptAct_PlayAnimation( );
   UnityEngine.GameObject[] logic_uScriptAct_PlayAnimation_Target_44 = new UnityEngine.GameObject[] {};
   System.String logic_uScriptAct_PlayAnimation_Animation_44 = "PrefabDoorROpenAnim";
   System.Single logic_uScriptAct_PlayAnimation_SpeedFactor_44 = (float) 1;
   UnityEngine.WrapMode logic_uScriptAct_PlayAnimation_AnimWrapMode_44 = UnityEngine.WrapMode.Once;
   System.Boolean logic_uScriptAct_PlayAnimation_StopOtherAnimations_44 = (bool) true;
   bool logic_uScriptAct_PlayAnimation_Out_44 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Sender_0 = null;
   System.String event_UnityEngine_GameObject_EventName_0 = "";
   System.Boolean event_UnityEngine_GameObject_EventData_0 = (bool) false;
   System.Int32 event_UnityEngine_GameObject_TimesToTrigger_32 = (int) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_32 = null;
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_Door_L_UnityEngine_GameObject_previous != local_Door_L_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_Door_L_UnityEngine_GameObject_previous = local_Door_L_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_Door_R_UnityEngine_GameObject_previous != local_Door_R_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_Door_R_UnityEngine_GameObject_previous = local_Door_R_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_46_UnityEngine_GameObject_previous != local_46_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_46_UnityEngine_GameObject_previous = local_46_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == owner_Connection_4 || false == m_RegisteredForEvents )
      {
         owner_Connection_4 = parentGameObject;
         if ( null != owner_Connection_4 )
         {
            {
               uScript_CustomEventBool component = owner_Connection_4.GetComponent<uScript_CustomEventBool>();
               if ( null == component )
               {
                  component = owner_Connection_4.AddComponent<uScript_CustomEventBool>();
               }
               if ( null != component )
               {
                  component.OnCustomEventBool += Instance_OnCustomEventBool_0;
               }
            }
         }
      }
      if ( null == owner_Connection_10 || false == m_RegisteredForEvents )
      {
         owner_Connection_10 = parentGameObject;
      }
      if ( null == owner_Connection_15 || false == m_RegisteredForEvents )
      {
         owner_Connection_15 = parentGameObject;
      }
      if ( null == owner_Connection_28 || false == m_RegisteredForEvents )
      {
         owner_Connection_28 = parentGameObject;
      }
      if ( null == owner_Connection_43 || false == m_RegisteredForEvents )
      {
         owner_Connection_43 = parentGameObject;
         if ( null != owner_Connection_43 )
         {
            {
               uScript_Triggers component = owner_Connection_43.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = owner_Connection_43.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_32;
               }
            }
            {
               uScript_Triggers component = owner_Connection_43.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = owner_Connection_43.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_32;
                  component.OnExitTrigger += Instance_OnExitTrigger_32;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_32;
               }
            }
         }
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_Door_L_UnityEngine_GameObject_previous != local_Door_L_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_Door_L_UnityEngine_GameObject_previous = local_Door_L_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_Door_R_UnityEngine_GameObject_previous != local_Door_R_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_Door_R_UnityEngine_GameObject_previous = local_Door_R_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_46_UnityEngine_GameObject_previous != local_46_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_46_UnityEngine_GameObject_previous = local_46_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //reset event listeners if needed
      //this isn't a variable node so it should only be called once per enabling of the script
      //if it's called twice there would be a double event registration (which is an error)
      if ( false == m_RegisteredForEvents )
      {
         if ( null != owner_Connection_4 )
         {
            {
               uScript_CustomEventBool component = owner_Connection_4.GetComponent<uScript_CustomEventBool>();
               if ( null == component )
               {
                  component = owner_Connection_4.AddComponent<uScript_CustomEventBool>();
               }
               if ( null != component )
               {
                  component.OnCustomEventBool += Instance_OnCustomEventBool_0;
               }
            }
         }
      }
      //reset event listeners if needed
      //this isn't a variable node so it should only be called once per enabling of the script
      //if it's called twice there would be a double event registration (which is an error)
      if ( false == m_RegisteredForEvents )
      {
         if ( null != owner_Connection_43 )
         {
            {
               uScript_Triggers component = owner_Connection_43.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = owner_Connection_43.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_32;
               }
            }
            {
               uScript_Triggers component = owner_Connection_43.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = owner_Connection_43.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_32;
                  component.OnExitTrigger += Instance_OnExitTrigger_32;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_32;
               }
            }
         }
      }
   }
   
   void SyncEventListeners( )
   {
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != owner_Connection_4 )
      {
         {
            uScript_CustomEventBool component = owner_Connection_4.GetComponent<uScript_CustomEventBool>();
            if ( null != component )
            {
               component.OnCustomEventBool -= Instance_OnCustomEventBool_0;
            }
         }
      }
      if ( null != owner_Connection_43 )
      {
         {
            uScript_Triggers component = owner_Connection_43.GetComponent<uScript_Triggers>();
            if ( null != component )
            {
               component.OnEnterTrigger -= Instance_OnEnterTrigger_32;
               component.OnExitTrigger -= Instance_OnExitTrigger_32;
               component.WhileInsideTrigger -= Instance_WhileInsideTrigger_32;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_1.SetParent(g);
      logic_uScriptAct_AssignMaterialColor_uScriptAct_AssignMaterialColor_2.SetParent(g);
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_5.SetParent(g);
      logic_uScriptCon_CompareString_uScriptCon_CompareString_6.SetParent(g);
      logic_uScriptAct_SendCustomEvent_uScriptAct_SendCustomEvent_8.SetParent(g);
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_9.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_11.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_13.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_20.SetParent(g);
      logic_uScriptAct_GetChildrenByName_uScriptAct_GetChildrenByName_21.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_22.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_23.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_33.SetParent(g);
      logic_uScriptAct_GetChildrenByName_uScriptAct_GetChildrenByName_34.SetParent(g);
      logic_uScriptAct_GetChildrenByName_uScriptAct_GetChildrenByName_35.SetParent(g);
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_38.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_39.SetParent(g);
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_44.SetParent(g);
   }
   public void Awake()
   {
      
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_5.Finished += uScriptAct_PlayAnimation_Finished_5;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_9.Finished += uScriptAct_PlayAnimation_Finished_9;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_38.Finished += uScriptAct_PlayAnimation_Finished_38;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_44.Finished += uScriptAct_PlayAnimation_Finished_44;
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
      
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_5.Update( );
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_9.Update( );
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_38.Update( );
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_44.Update( );
      if (true == logic_uScriptAct_Delay_DrivenDelay_11)
      {
         Relay_DrivenDelay_11();
      }
      if (true == logic_uScriptAct_Delay_DrivenDelay_39)
      {
         Relay_DrivenDelay_39();
      }
   }
   
   public void OnDestroy()
   {
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_5.Finished -= uScriptAct_PlayAnimation_Finished_5;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_9.Finished -= uScriptAct_PlayAnimation_Finished_9;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_38.Finished -= uScriptAct_PlayAnimation_Finished_38;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_44.Finished -= uScriptAct_PlayAnimation_Finished_44;
   }
   
   void Instance_OnCustomEventBool_0(object o, uScript_CustomEventBool.CustomEventBoolArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_Sender_0 = e.Sender;
      event_UnityEngine_GameObject_EventName_0 = e.EventName;
      event_UnityEngine_GameObject_EventData_0 = e.EventData;
      //relay event to nodes
      Relay_OnCustomEventBool_0( );
   }
   
   void Instance_OnEnterTrigger_32(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_32 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_32( );
   }
   
   void Instance_OnExitTrigger_32(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_32 = e.GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_32( );
   }
   
   void Instance_WhileInsideTrigger_32(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_32 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_32( );
   }
   
   void uScriptAct_PlayAnimation_Finished_5(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_5( );
   }
   
   void uScriptAct_PlayAnimation_Finished_9(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_9( );
   }
   
   void uScriptAct_PlayAnimation_Finished_38(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_38( );
   }
   
   void uScriptAct_PlayAnimation_Finished_44(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_44( );
   }
   
   void Relay_OnCustomEventBool_0()
   {
      if (true == CheckDebugBreak("5332b4a1-0264-43f4-bb4f-154c75dc25e5", "Custom Event (Bool)", Relay_OnCustomEventBool_0)) return; 
      local_25_System_String = event_UnityEngine_GameObject_EventName_0;
      local_45_System_Boolean = event_UnityEngine_GameObject_EventData_0;
      Relay_In_6();
   }
   
   void Relay_In_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("51f6fb02-d238-46f1-8740-b8f27c36f52b", "Compare Bool", Relay_In_1)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_1 = local_Has_Key_System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_1.In(logic_uScriptCon_CompareBool_Bool_1);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_1.True;
         
         if ( test_0 == true )
         {
            Relay_In_34();
            Relay_In_23();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9c1c658d-aef9-4b23-8964-bce155c45810", "Assign Material Color", Relay_In_2)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_46_UnityEngine_GameObject_previous != local_46_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_46_UnityEngine_GameObject_previous = local_46_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add(local_46_UnityEngine_GameObject);
               logic_uScriptAct_AssignMaterialColor_Target_2 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AssignMaterialColor_uScriptAct_AssignMaterialColor_2.In(logic_uScriptAct_AssignMaterialColor_Target_2, logic_uScriptAct_AssignMaterialColor_MatColor_2, logic_uScriptAct_AssignMaterialColor_MatChannel_2);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Assign Material Color.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("02c0120c-567a-4437-b5ab-2b496bce8f51", "Play Animation", Relay_Finished_5)) return; 
         Relay_In_11();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("02c0120c-567a-4437-b5ab-2b496bce8f51", "Play Animation", Relay_In_5)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_Door_L_UnityEngine_GameObject_previous != local_Door_L_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_Door_L_UnityEngine_GameObject_previous = local_Door_L_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add(local_Door_L_UnityEngine_GameObject);
               logic_uScriptAct_PlayAnimation_Target_5 = properties.ToArray();
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
         logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_5.In(logic_uScriptAct_PlayAnimation_Target_5, logic_uScriptAct_PlayAnimation_Animation_5, logic_uScriptAct_PlayAnimation_SpeedFactor_5, logic_uScriptAct_PlayAnimation_AnimWrapMode_5, logic_uScriptAct_PlayAnimation_StopOtherAnimations_5);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("33bc6b4a-9db0-4cd5-8b53-f1b91f2fb33c", "Compare String", Relay_In_6)) return; 
         {
            {
               logic_uScriptCon_CompareString_A_6 = local_25_System_String;
               
            }
            {
               logic_uScriptCon_CompareString_B_6 = local_30_System_String;
               
            }
         }
         logic_uScriptCon_CompareString_uScriptCon_CompareString_6.In(logic_uScriptCon_CompareString_A_6, logic_uScriptCon_CompareString_B_6);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareString_uScriptCon_CompareString_6.Same;
         
         if ( test_0 == true )
         {
            Relay_In_33();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Compare String.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_SendCustomEvent_8()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("36828b41-f800-421b-a498-93b2a64aa6bf", "Send Custom Event", Relay_SendCustomEvent_8)) return; 
         {
            {
               logic_uScriptAct_SendCustomEvent_EventName_8 = local_27_System_String;
               
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SendCustomEvent_uScriptAct_SendCustomEvent_8.SendCustomEvent(logic_uScriptAct_SendCustomEvent_EventName_8, logic_uScriptAct_SendCustomEvent_sendGroup_8, logic_uScriptAct_SendCustomEvent_EventSender_8);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SendCustomEvent_uScriptAct_SendCustomEvent_8.Out;
         
         if ( test_0 == true )
         {
            Relay_In_1();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Send Custom Event.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0003d525-2aaf-4de1-9d26-e53f02b5ac5b", "Play Animation", Relay_Finished_9)) return; 
         Relay_False_20();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0003d525-2aaf-4de1-9d26-e53f02b5ac5b", "Play Animation", Relay_In_9)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_Door_R_UnityEngine_GameObject_previous != local_Door_R_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_Door_R_UnityEngine_GameObject_previous = local_Door_R_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add(local_Door_R_UnityEngine_GameObject);
               logic_uScriptAct_PlayAnimation_Target_9 = properties.ToArray();
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
         logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_9.In(logic_uScriptAct_PlayAnimation_Target_9, logic_uScriptAct_PlayAnimation_Animation_9, logic_uScriptAct_PlayAnimation_SpeedFactor_9, logic_uScriptAct_PlayAnimation_AnimWrapMode_9, logic_uScriptAct_PlayAnimation_StopOtherAnimations_9);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_11()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d0e66241-b788-4e7e-ade6-7396c8f104c3", "Delay", Relay_In_11)) return; 
         {
            {
            }
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_11.In(logic_uScriptAct_Delay_Duration_11);
         logic_uScriptAct_Delay_DrivenDelay_11 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_11.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_In_38();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_DrivenDelay_11( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
            }
         }
         logic_uScriptAct_Delay_DrivenDelay_11 = logic_uScriptAct_Delay_uScriptAct_Delay_11.DrivenDelay();
         if ( true == logic_uScriptAct_Delay_DrivenDelay_11 )
         {
            if ( logic_uScriptAct_Delay_uScriptAct_Delay_11.AfterDelay == true )
            {
               Relay_In_38();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_True_13()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("01c319bc-1475-4292-8793-50f148b79519", "Set Bool", Relay_True_13)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_13.True(out logic_uScriptAct_SetBool_Target_13);
         local_Door_Open__System_Boolean = logic_uScriptAct_SetBool_Target_13;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_13.Out;
         
         if ( test_0 == true )
         {
            Relay_In_21();
            Relay_In_35();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_13()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("01c319bc-1475-4292-8793-50f148b79519", "Set Bool", Relay_False_13)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_13.False(out logic_uScriptAct_SetBool_Target_13);
         local_Door_Open__System_Boolean = logic_uScriptAct_SetBool_Target_13;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_13.Out;
         
         if ( test_0 == true )
         {
            Relay_In_21();
            Relay_In_35();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_20()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("47854d78-4fcc-4b8c-9896-a0ee58adbed9", "Set Bool", Relay_True_20)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_20.True(out logic_uScriptAct_SetBool_Target_20);
         local_Door_Open__System_Boolean = logic_uScriptAct_SetBool_Target_20;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_20()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("47854d78-4fcc-4b8c-9896-a0ee58adbed9", "Set Bool", Relay_False_20)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_20.False(out logic_uScriptAct_SetBool_Target_20);
         local_Door_Open__System_Boolean = logic_uScriptAct_SetBool_Target_20;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_21()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e80689cc-0d7f-4436-bed7-80513018971f", "Get Children By Name", Relay_In_21)) return; 
         {
            {
               logic_uScriptAct_GetChildrenByName_Target_21 = owner_Connection_10;
               
            }
            {
               logic_uScriptAct_GetChildrenByName_Name_21 = local_18_System_String;
               
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
         logic_uScriptAct_GetChildrenByName_uScriptAct_GetChildrenByName_21.In(logic_uScriptAct_GetChildrenByName_Target_21, logic_uScriptAct_GetChildrenByName_Name_21, logic_uScriptAct_GetChildrenByName_SearchMethod_21, logic_uScriptAct_GetChildrenByName_recursive_21, out logic_uScriptAct_GetChildrenByName_FirstChild_21, out logic_uScriptAct_GetChildrenByName_Children_21, out logic_uScriptAct_GetChildrenByName_ChildrenCount_21);
         local_Door_L_UnityEngine_GameObject = logic_uScriptAct_GetChildrenByName_FirstChild_21;
         {
            //if our game object reference was changed then we need to reset event listeners
            if ( local_Door_L_UnityEngine_GameObject_previous != local_Door_L_UnityEngine_GameObject || false == m_RegisteredForEvents )
            {
               //tear down old listeners
               
               local_Door_L_UnityEngine_GameObject_previous = local_Door_L_UnityEngine_GameObject;
               
               //setup new listeners
            }
         }
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetChildrenByName_uScriptAct_GetChildrenByName_21.ChildrenFound;
         
         if ( test_0 == true )
         {
            Relay_In_5();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Get Children By Name.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_22()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7b6da1f7-606e-4842-816d-e3066d81b002", "Set Bool", Relay_True_22)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_22.True(out logic_uScriptAct_SetBool_Target_22);
         local_Has_Key_System_Boolean = logic_uScriptAct_SetBool_Target_22;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_22()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7b6da1f7-606e-4842-816d-e3066d81b002", "Set Bool", Relay_False_22)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_22.False(out logic_uScriptAct_SetBool_Target_22);
         local_Has_Key_System_Boolean = logic_uScriptAct_SetBool_Target_22;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_23()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8d301f1c-5933-4f31-91ec-e94500f4a872", "Compare Bool", Relay_In_23)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_23 = local_Door_Open__System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_23.In(logic_uScriptCon_CompareBool_Bool_23);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_23.False;
         
         if ( test_0 == true )
         {
            Relay_True_13();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnEnterTrigger_32()
   {
      if (true == CheckDebugBreak("dcc11741-b3a3-44cf-a133-06af6e9fb851", "Trigger Events", Relay_OnEnterTrigger_32)) return; 
      Relay_SendCustomEvent_8();
   }
   
   void Relay_OnExitTrigger_32()
   {
      if (true == CheckDebugBreak("dcc11741-b3a3-44cf-a133-06af6e9fb851", "Trigger Events", Relay_OnExitTrigger_32)) return; 
   }
   
   void Relay_WhileInsideTrigger_32()
   {
      if (true == CheckDebugBreak("dcc11741-b3a3-44cf-a133-06af6e9fb851", "Trigger Events", Relay_WhileInsideTrigger_32)) return; 
   }
   
   void Relay_In_33()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("162635dc-bf88-49a4-908e-6464a1e59d75", "Compare Bool", Relay_In_33)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_33 = local_45_System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_33.In(logic_uScriptCon_CompareBool_Bool_33);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_33.True;
         bool test_1 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_33.False;
         
         if ( test_0 == true )
         {
            Relay_True_22();
         }
         if ( test_1 == true )
         {
            Relay_False_22();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_34()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2426c8cb-0b11-47bb-9b3b-f87c8d3f4eb7", "Get Children By Name", Relay_In_34)) return; 
         {
            {
               logic_uScriptAct_GetChildrenByName_Target_34 = owner_Connection_15;
               
            }
            {
               logic_uScriptAct_GetChildrenByName_Name_34 = local_12_System_String;
               
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
         logic_uScriptAct_GetChildrenByName_uScriptAct_GetChildrenByName_34.In(logic_uScriptAct_GetChildrenByName_Target_34, logic_uScriptAct_GetChildrenByName_Name_34, logic_uScriptAct_GetChildrenByName_SearchMethod_34, logic_uScriptAct_GetChildrenByName_recursive_34, out logic_uScriptAct_GetChildrenByName_FirstChild_34, out logic_uScriptAct_GetChildrenByName_Children_34, out logic_uScriptAct_GetChildrenByName_ChildrenCount_34);
         local_46_UnityEngine_GameObject = logic_uScriptAct_GetChildrenByName_FirstChild_34;
         {
            //if our game object reference was changed then we need to reset event listeners
            if ( local_46_UnityEngine_GameObject_previous != local_46_UnityEngine_GameObject || false == m_RegisteredForEvents )
            {
               //tear down old listeners
               
               local_46_UnityEngine_GameObject_previous = local_46_UnityEngine_GameObject;
               
               //setup new listeners
            }
         }
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetChildrenByName_uScriptAct_GetChildrenByName_34.ChildrenFound;
         
         if ( test_0 == true )
         {
            Relay_In_2();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Get Children By Name.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_35()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e436eefa-95f7-4577-98e7-da05ee315692", "Get Children By Name", Relay_In_35)) return; 
         {
            {
               logic_uScriptAct_GetChildrenByName_Target_35 = owner_Connection_28;
               
            }
            {
               logic_uScriptAct_GetChildrenByName_Name_35 = local_17_System_String;
               
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
         logic_uScriptAct_GetChildrenByName_uScriptAct_GetChildrenByName_35.In(logic_uScriptAct_GetChildrenByName_Target_35, logic_uScriptAct_GetChildrenByName_Name_35, logic_uScriptAct_GetChildrenByName_SearchMethod_35, logic_uScriptAct_GetChildrenByName_recursive_35, out logic_uScriptAct_GetChildrenByName_FirstChild_35, out logic_uScriptAct_GetChildrenByName_Children_35, out logic_uScriptAct_GetChildrenByName_ChildrenCount_35);
         local_Door_R_UnityEngine_GameObject = logic_uScriptAct_GetChildrenByName_FirstChild_35;
         {
            //if our game object reference was changed then we need to reset event listeners
            if ( local_Door_R_UnityEngine_GameObject_previous != local_Door_R_UnityEngine_GameObject || false == m_RegisteredForEvents )
            {
               //tear down old listeners
               
               local_Door_R_UnityEngine_GameObject_previous = local_Door_R_UnityEngine_GameObject;
               
               //setup new listeners
            }
         }
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_GetChildrenByName_uScriptAct_GetChildrenByName_35.ChildrenFound;
         
         if ( test_0 == true )
         {
            Relay_In_44();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Get Children By Name.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_38()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("931aa7ee-5f34-41a6-8b49-67961dc96934", "Play Animation", Relay_Finished_38)) return; 
         Relay_False_20();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_38()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("931aa7ee-5f34-41a6-8b49-67961dc96934", "Play Animation", Relay_In_38)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_Door_L_UnityEngine_GameObject_previous != local_Door_L_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_Door_L_UnityEngine_GameObject_previous = local_Door_L_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add(local_Door_L_UnityEngine_GameObject);
               logic_uScriptAct_PlayAnimation_Target_38 = properties.ToArray();
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
         logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_38.In(logic_uScriptAct_PlayAnimation_Target_38, logic_uScriptAct_PlayAnimation_Animation_38, logic_uScriptAct_PlayAnimation_SpeedFactor_38, logic_uScriptAct_PlayAnimation_AnimWrapMode_38, logic_uScriptAct_PlayAnimation_StopOtherAnimations_38);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_39()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9a88b379-7143-42c4-9996-fe51d191e3af", "Delay", Relay_In_39)) return; 
         {
            {
            }
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_39.In(logic_uScriptAct_Delay_Duration_39);
         logic_uScriptAct_Delay_DrivenDelay_39 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_39.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_In_9();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_DrivenDelay_39( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
            }
         }
         logic_uScriptAct_Delay_DrivenDelay_39 = logic_uScriptAct_Delay_uScriptAct_Delay_39.DrivenDelay();
         if ( true == logic_uScriptAct_Delay_DrivenDelay_39 )
         {
            if ( logic_uScriptAct_Delay_uScriptAct_Delay_39.AfterDelay == true )
            {
               Relay_In_9();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_Finished_44()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("60d982a5-e90f-412f-9aa1-db3dcc46305f", "Play Animation", Relay_Finished_44)) return; 
         Relay_In_39();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_44()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("60d982a5-e90f-412f-9aa1-db3dcc46305f", "Play Animation", Relay_In_44)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_Door_R_UnityEngine_GameObject_previous != local_Door_R_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_Door_R_UnityEngine_GameObject_previous = local_Door_R_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add(local_Door_R_UnityEngine_GameObject);
               logic_uScriptAct_PlayAnimation_Target_44 = properties.ToArray();
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
         logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_44.In(logic_uScriptAct_PlayAnimation_Target_44, logic_uScriptAct_PlayAnimation_Animation_44, logic_uScriptAct_PlayAnimation_SpeedFactor_44, logic_uScriptAct_PlayAnimation_AnimWrapMode_44, logic_uScriptAct_PlayAnimation_StopOtherAnimations_44);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorLockablePrefabGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_DoorLockablePrefabGraph.uscript:12", local_12_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "587afb4e-b4f0-4894-99af-bbcd3f86a7a2", local_12_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_DoorLockablePrefabGraph.uscript:Door_L", local_Door_L_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "25b0ae1d-5a59-43c1-b2d9-ed449eab43c8", local_Door_L_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_DoorLockablePrefabGraph.uscript:17", local_17_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "58b246cf-6845-483e-a2f9-eeccd4a5e962", local_17_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_DoorLockablePrefabGraph.uscript:18", local_18_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ffc089fa-090e-46db-a04c-d46ce8d63f31", local_18_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_DoorLockablePrefabGraph.uscript:Door Open?", local_Door_Open__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b48fe905-5f27-49a4-8987-fc366e740e52", local_Door_Open__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_DoorLockablePrefabGraph.uscript:25", local_25_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "2bf476f6-4b67-4d6f-baaa-bed502ddfa08", local_25_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_DoorLockablePrefabGraph.uscript:27", local_27_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "5fac7c1c-a323-4fbb-b95e-d5056f2a3dec", local_27_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_DoorLockablePrefabGraph.uscript:30", local_30_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "2a50c5c6-3d6d-4934-a159-d02e1f8ea823", local_30_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_DoorLockablePrefabGraph.uscript:Door_R", local_Door_R_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d8f1a279-9c0c-4c28-9572-52cb50da0cbe", local_Door_R_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_DoorLockablePrefabGraph.uscript:Has Key", local_Has_Key_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "0b20c162-c106-4513-8601-e7fb01cd1801", local_Has_Key_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_DoorLockablePrefabGraph.uscript:45", local_45_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "e86673f5-74d8-470e-8c77-716e16b4d3ee", local_45_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_DoorLockablePrefabGraph.uscript:46", local_46_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "46bc07fd-7961-478b-9299-2c4f02aecce2", local_46_UnityEngine_GameObject);
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
