//uScript Generated Code - Build 0.9.2215
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class Doors_DoorPrefabGraph : uScriptLogic
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
   System.String local_1_System_String = "Door_L";
   System.String local_5_System_String = "Door_R";
   UnityEngine.GameObject local_Door_L_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Door_L_UnityEngine_GameObject_previous = null;
   System.Boolean local_Door_Open__System_Boolean = (bool) false;
   UnityEngine.GameObject local_Door_R_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_Door_R_UnityEngine_GameObject_previous = null;
   
   //owner nodes
   UnityEngine.GameObject owner_Connection_10 = null;
   UnityEngine.GameObject owner_Connection_14 = null;
   UnityEngine.GameObject owner_Connection_22 = null;
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_PlayAnimation logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_0 = new uScriptAct_PlayAnimation( );
   UnityEngine.GameObject[] logic_uScriptAct_PlayAnimation_Target_0 = new UnityEngine.GameObject[] {};
   System.String logic_uScriptAct_PlayAnimation_Animation_0 = "PrefabDoorLOpenAnim";
   System.Single logic_uScriptAct_PlayAnimation_SpeedFactor_0 = (float) 1;
   UnityEngine.WrapMode logic_uScriptAct_PlayAnimation_AnimWrapMode_0 = UnityEngine.WrapMode.Once;
   System.Boolean logic_uScriptAct_PlayAnimation_StopOtherAnimations_0 = (bool) true;
   bool logic_uScriptAct_PlayAnimation_Out_0 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_2 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_2;
   bool logic_uScriptAct_SetBool_Out_2 = true;
   bool logic_uScriptAct_SetBool_SetTrue_2 = true;
   bool logic_uScriptAct_SetBool_SetFalse_2 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_4 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_4;
   bool logic_uScriptAct_SetBool_Out_4 = true;
   bool logic_uScriptAct_SetBool_SetTrue_4 = true;
   bool logic_uScriptAct_SetBool_SetFalse_4 = true;
   //pointer to script instanced logic node
   uScriptAct_PlayAnimation logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_6 = new uScriptAct_PlayAnimation( );
   UnityEngine.GameObject[] logic_uScriptAct_PlayAnimation_Target_6 = new UnityEngine.GameObject[] {};
   System.String logic_uScriptAct_PlayAnimation_Animation_6 = "PrefabDoorLOpenAnim";
   System.Single logic_uScriptAct_PlayAnimation_SpeedFactor_6 = (float) -1;
   UnityEngine.WrapMode logic_uScriptAct_PlayAnimation_AnimWrapMode_6 = UnityEngine.WrapMode.Once;
   System.Boolean logic_uScriptAct_PlayAnimation_StopOtherAnimations_6 = (bool) true;
   bool logic_uScriptAct_PlayAnimation_Out_6 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_7 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_7 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_7 = true;
   bool logic_uScriptCon_CompareBool_False_7 = true;
   //pointer to script instanced logic node
   uScriptAct_GetChildrenByName logic_uScriptAct_GetChildrenByName_uScriptAct_GetChildrenByName_8 = new uScriptAct_GetChildrenByName( );
   UnityEngine.GameObject logic_uScriptAct_GetChildrenByName_Target_8 = null;
   System.String logic_uScriptAct_GetChildrenByName_Name_8 = "";
   uScriptAct_GetChildrenByName.SearchType logic_uScriptAct_GetChildrenByName_SearchMethod_8 = uScriptAct_GetChildrenByName.SearchType.Matches;
   System.Boolean logic_uScriptAct_GetChildrenByName_recursive_8 = (bool) false;
   UnityEngine.GameObject logic_uScriptAct_GetChildrenByName_FirstChild_8;
   UnityEngine.GameObject[] logic_uScriptAct_GetChildrenByName_Children_8;
   System.Int32 logic_uScriptAct_GetChildrenByName_ChildrenCount_8;
   bool logic_uScriptAct_GetChildrenByName_Out_8 = true;
   bool logic_uScriptAct_GetChildrenByName_ChildrenFound_8 = true;
   bool logic_uScriptAct_GetChildrenByName_ChildrenNotFound_8 = true;
   //pointer to script instanced logic node
   uScriptAct_PlayAnimation logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_9 = new uScriptAct_PlayAnimation( );
   UnityEngine.GameObject[] logic_uScriptAct_PlayAnimation_Target_9 = new UnityEngine.GameObject[] {};
   System.String logic_uScriptAct_PlayAnimation_Animation_9 = "PrefabDoorROpenAnim";
   System.Single logic_uScriptAct_PlayAnimation_SpeedFactor_9 = (float) 1;
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
   uScriptAct_PlayAnimation logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_12 = new uScriptAct_PlayAnimation( );
   UnityEngine.GameObject[] logic_uScriptAct_PlayAnimation_Target_12 = new UnityEngine.GameObject[] {};
   System.String logic_uScriptAct_PlayAnimation_Animation_12 = "PrefabDoorROpenAnim";
   System.Single logic_uScriptAct_PlayAnimation_SpeedFactor_12 = (float) -1;
   UnityEngine.WrapMode logic_uScriptAct_PlayAnimation_AnimWrapMode_12 = UnityEngine.WrapMode.Once;
   System.Boolean logic_uScriptAct_PlayAnimation_StopOtherAnimations_12 = (bool) true;
   bool logic_uScriptAct_PlayAnimation_Out_12 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_17 = new uScriptAct_Delay( );
   System.Single logic_uScriptAct_Delay_Duration_17 = (float) 3;
   bool logic_uScriptAct_Delay_Immediate_17 = true;
   bool logic_uScriptAct_Delay_AfterDelay_17 = true;
   bool logic_uScriptAct_Delay_DrivenDelay_17 = false;
   //pointer to script instanced logic node
   uScriptAct_GetChildrenByName logic_uScriptAct_GetChildrenByName_uScriptAct_GetChildrenByName_20 = new uScriptAct_GetChildrenByName( );
   UnityEngine.GameObject logic_uScriptAct_GetChildrenByName_Target_20 = null;
   System.String logic_uScriptAct_GetChildrenByName_Name_20 = "";
   uScriptAct_GetChildrenByName.SearchType logic_uScriptAct_GetChildrenByName_SearchMethod_20 = uScriptAct_GetChildrenByName.SearchType.Matches;
   System.Boolean logic_uScriptAct_GetChildrenByName_recursive_20 = (bool) false;
   UnityEngine.GameObject logic_uScriptAct_GetChildrenByName_FirstChild_20;
   UnityEngine.GameObject[] logic_uScriptAct_GetChildrenByName_Children_20;
   System.Int32 logic_uScriptAct_GetChildrenByName_ChildrenCount_20;
   bool logic_uScriptAct_GetChildrenByName_Out_20 = true;
   bool logic_uScriptAct_GetChildrenByName_ChildrenFound_20 = true;
   bool logic_uScriptAct_GetChildrenByName_ChildrenNotFound_20 = true;
   
   //event nodes
   System.Int32 event_UnityEngine_GameObject_TimesToTrigger_19 = (int) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_19 = null;
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_Door_R_UnityEngine_GameObject_previous != local_Door_R_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_Door_R_UnityEngine_GameObject_previous = local_Door_R_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_Door_L_UnityEngine_GameObject_previous != local_Door_L_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_Door_L_UnityEngine_GameObject_previous = local_Door_L_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == owner_Connection_10 || false == m_RegisteredForEvents )
      {
         owner_Connection_10 = parentGameObject;
      }
      if ( null == owner_Connection_14 || false == m_RegisteredForEvents )
      {
         owner_Connection_14 = parentGameObject;
      }
      if ( null == owner_Connection_22 || false == m_RegisteredForEvents )
      {
         owner_Connection_22 = parentGameObject;
         if ( null != owner_Connection_22 )
         {
            {
               uScript_Triggers component = owner_Connection_22.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = owner_Connection_22.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_19;
               }
            }
            {
               uScript_Triggers component = owner_Connection_22.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = owner_Connection_22.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_19;
                  component.OnExitTrigger += Instance_OnExitTrigger_19;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_19;
               }
            }
         }
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_Door_R_UnityEngine_GameObject_previous != local_Door_R_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_Door_R_UnityEngine_GameObject_previous = local_Door_R_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_Door_L_UnityEngine_GameObject_previous != local_Door_L_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_Door_L_UnityEngine_GameObject_previous = local_Door_L_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //reset event listeners if needed
      //this isn't a variable node so it should only be called once per enabling of the script
      //if it's called twice there would be a double event registration (which is an error)
      if ( false == m_RegisteredForEvents )
      {
         if ( null != owner_Connection_22 )
         {
            {
               uScript_Triggers component = owner_Connection_22.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = owner_Connection_22.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_19;
               }
            }
            {
               uScript_Triggers component = owner_Connection_22.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = owner_Connection_22.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_19;
                  component.OnExitTrigger += Instance_OnExitTrigger_19;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_19;
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
      if ( null != owner_Connection_22 )
      {
         {
            uScript_Triggers component = owner_Connection_22.GetComponent<uScript_Triggers>();
            if ( null != component )
            {
               component.OnEnterTrigger -= Instance_OnEnterTrigger_19;
               component.OnExitTrigger -= Instance_OnExitTrigger_19;
               component.WhileInsideTrigger -= Instance_WhileInsideTrigger_19;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_0.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_2.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_4.SetParent(g);
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_6.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_7.SetParent(g);
      logic_uScriptAct_GetChildrenByName_uScriptAct_GetChildrenByName_8.SetParent(g);
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_9.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_11.SetParent(g);
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_12.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_17.SetParent(g);
      logic_uScriptAct_GetChildrenByName_uScriptAct_GetChildrenByName_20.SetParent(g);
   }
   public void Awake()
   {
      
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_0.Finished += uScriptAct_PlayAnimation_Finished_0;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_6.Finished += uScriptAct_PlayAnimation_Finished_6;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_9.Finished += uScriptAct_PlayAnimation_Finished_9;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_12.Finished += uScriptAct_PlayAnimation_Finished_12;
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
      
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_0.Update( );
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_6.Update( );
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_9.Update( );
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_12.Update( );
      if (true == logic_uScriptAct_Delay_DrivenDelay_11)
      {
         Relay_DrivenDelay_11();
      }
      if (true == logic_uScriptAct_Delay_DrivenDelay_17)
      {
         Relay_DrivenDelay_17();
      }
   }
   
   public void OnDestroy()
   {
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_0.Finished -= uScriptAct_PlayAnimation_Finished_0;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_6.Finished -= uScriptAct_PlayAnimation_Finished_6;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_9.Finished -= uScriptAct_PlayAnimation_Finished_9;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_12.Finished -= uScriptAct_PlayAnimation_Finished_12;
   }
   
   void Instance_OnEnterTrigger_19(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_19 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_19( );
   }
   
   void Instance_OnExitTrigger_19(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_19 = e.GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_19( );
   }
   
   void Instance_WhileInsideTrigger_19(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_19 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_19( );
   }
   
   void uScriptAct_PlayAnimation_Finished_0(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_0( );
   }
   
   void uScriptAct_PlayAnimation_Finished_6(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_6( );
   }
   
   void uScriptAct_PlayAnimation_Finished_9(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_9( );
   }
   
   void uScriptAct_PlayAnimation_Finished_12(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_12( );
   }
   
   void Relay_Finished_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("02c0120c-567a-4437-b5ab-2b496bce8f51", "Play Animation", Relay_Finished_0)) return; 
         Relay_In_11();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorPrefabGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("02c0120c-567a-4437-b5ab-2b496bce8f51", "Play Animation", Relay_In_0)) return; 
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
               logic_uScriptAct_PlayAnimation_Target_0 = properties.ToArray();
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
         logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_0.In(logic_uScriptAct_PlayAnimation_Target_0, logic_uScriptAct_PlayAnimation_Animation_0, logic_uScriptAct_PlayAnimation_SpeedFactor_0, logic_uScriptAct_PlayAnimation_AnimWrapMode_0, logic_uScriptAct_PlayAnimation_StopOtherAnimations_0);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorPrefabGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("47854d78-4fcc-4b8c-9896-a0ee58adbed9", "Set Bool", Relay_True_2)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_2.True(out logic_uScriptAct_SetBool_Target_2);
         local_Door_Open__System_Boolean = logic_uScriptAct_SetBool_Target_2;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorPrefabGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("47854d78-4fcc-4b8c-9896-a0ee58adbed9", "Set Bool", Relay_False_2)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_2.False(out logic_uScriptAct_SetBool_Target_2);
         local_Door_Open__System_Boolean = logic_uScriptAct_SetBool_Target_2;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorPrefabGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_True_4()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("01c319bc-1475-4292-8793-50f148b79519", "Set Bool", Relay_True_4)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_4.True(out logic_uScriptAct_SetBool_Target_4);
         local_Door_Open__System_Boolean = logic_uScriptAct_SetBool_Target_4;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_4.Out;
         
         if ( test_0 == true )
         {
            Relay_In_20();
            Relay_In_8();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorPrefabGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_4()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("01c319bc-1475-4292-8793-50f148b79519", "Set Bool", Relay_False_4)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_4.False(out logic_uScriptAct_SetBool_Target_4);
         local_Door_Open__System_Boolean = logic_uScriptAct_SetBool_Target_4;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_4.Out;
         
         if ( test_0 == true )
         {
            Relay_In_20();
            Relay_In_8();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorPrefabGraph.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("931aa7ee-5f34-41a6-8b49-67961dc96934", "Play Animation", Relay_Finished_6)) return; 
         Relay_False_2();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorPrefabGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("931aa7ee-5f34-41a6-8b49-67961dc96934", "Play Animation", Relay_In_6)) return; 
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
               logic_uScriptAct_PlayAnimation_Target_6 = properties.ToArray();
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
         logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_6.In(logic_uScriptAct_PlayAnimation_Target_6, logic_uScriptAct_PlayAnimation_Animation_6, logic_uScriptAct_PlayAnimation_SpeedFactor_6, logic_uScriptAct_PlayAnimation_AnimWrapMode_6, logic_uScriptAct_PlayAnimation_StopOtherAnimations_6);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorPrefabGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8d301f1c-5933-4f31-91ec-e94500f4a872", "Compare Bool", Relay_In_7)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_7 = local_Door_Open__System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_7.In(logic_uScriptCon_CompareBool_Bool_7);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_7.False;
         
         if ( test_0 == true )
         {
            Relay_True_4();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorPrefabGraph.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_8()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e436eefa-95f7-4577-98e7-da05ee315692", "Get Children By Name", Relay_In_8)) return; 
         {
            {
               logic_uScriptAct_GetChildrenByName_Target_8 = owner_Connection_10;
               
            }
            {
               logic_uScriptAct_GetChildrenByName_Name_8 = local_5_System_String;
               
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
         logic_uScriptAct_GetChildrenByName_uScriptAct_GetChildrenByName_8.In(logic_uScriptAct_GetChildrenByName_Target_8, logic_uScriptAct_GetChildrenByName_Name_8, logic_uScriptAct_GetChildrenByName_SearchMethod_8, logic_uScriptAct_GetChildrenByName_recursive_8, out logic_uScriptAct_GetChildrenByName_FirstChild_8, out logic_uScriptAct_GetChildrenByName_Children_8, out logic_uScriptAct_GetChildrenByName_ChildrenCount_8);
         local_Door_R_UnityEngine_GameObject = logic_uScriptAct_GetChildrenByName_FirstChild_8;
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
         bool test_0 = logic_uScriptAct_GetChildrenByName_uScriptAct_GetChildrenByName_8.ChildrenFound;
         
         if ( test_0 == true )
         {
            Relay_In_9();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorPrefabGraph.uscript at Get Children By Name.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("60d982a5-e90f-412f-9aa1-db3dcc46305f", "Play Animation", Relay_Finished_9)) return; 
         Relay_In_17();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorPrefabGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("60d982a5-e90f-412f-9aa1-db3dcc46305f", "Play Animation", Relay_In_9)) return; 
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorPrefabGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
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
            Relay_In_6();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorPrefabGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
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
               Relay_In_6();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorPrefabGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_Finished_12()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0003d525-2aaf-4de1-9d26-e53f02b5ac5b", "Play Animation", Relay_Finished_12)) return; 
         Relay_False_2();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorPrefabGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_12()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0003d525-2aaf-4de1-9d26-e53f02b5ac5b", "Play Animation", Relay_In_12)) return; 
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
               logic_uScriptAct_PlayAnimation_Target_12 = properties.ToArray();
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
         logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_12.In(logic_uScriptAct_PlayAnimation_Target_12, logic_uScriptAct_PlayAnimation_Animation_12, logic_uScriptAct_PlayAnimation_SpeedFactor_12, logic_uScriptAct_PlayAnimation_AnimWrapMode_12, logic_uScriptAct_PlayAnimation_StopOtherAnimations_12);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorPrefabGraph.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_17()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9a88b379-7143-42c4-9996-fe51d191e3af", "Delay", Relay_In_17)) return; 
         {
            {
            }
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_17.In(logic_uScriptAct_Delay_Duration_17);
         logic_uScriptAct_Delay_DrivenDelay_17 = true;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_17.AfterDelay;
         
         if ( test_0 == true )
         {
            Relay_In_12();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorPrefabGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_DrivenDelay_17( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         {
            {
            }
         }
         logic_uScriptAct_Delay_DrivenDelay_17 = logic_uScriptAct_Delay_uScriptAct_Delay_17.DrivenDelay();
         if ( true == logic_uScriptAct_Delay_DrivenDelay_17 )
         {
            if ( logic_uScriptAct_Delay_uScriptAct_Delay_17.AfterDelay == true )
            {
               Relay_In_12();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorPrefabGraph.uscript at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_OnEnterTrigger_19()
   {
      if (true == CheckDebugBreak("dcc11741-b3a3-44cf-a133-06af6e9fb851", "Trigger Events", Relay_OnEnterTrigger_19)) return; 
      Relay_In_7();
   }
   
   void Relay_OnExitTrigger_19()
   {
      if (true == CheckDebugBreak("dcc11741-b3a3-44cf-a133-06af6e9fb851", "Trigger Events", Relay_OnExitTrigger_19)) return; 
   }
   
   void Relay_WhileInsideTrigger_19()
   {
      if (true == CheckDebugBreak("dcc11741-b3a3-44cf-a133-06af6e9fb851", "Trigger Events", Relay_WhileInsideTrigger_19)) return; 
   }
   
   void Relay_In_20()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e80689cc-0d7f-4436-bed7-80513018971f", "Get Children By Name", Relay_In_20)) return; 
         {
            {
               logic_uScriptAct_GetChildrenByName_Target_20 = owner_Connection_14;
               
            }
            {
               logic_uScriptAct_GetChildrenByName_Name_20 = local_1_System_String;
               
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
         logic_uScriptAct_GetChildrenByName_uScriptAct_GetChildrenByName_20.In(logic_uScriptAct_GetChildrenByName_Target_20, logic_uScriptAct_GetChildrenByName_Name_20, logic_uScriptAct_GetChildrenByName_SearchMethod_20, logic_uScriptAct_GetChildrenByName_recursive_20, out logic_uScriptAct_GetChildrenByName_FirstChild_20, out logic_uScriptAct_GetChildrenByName_Children_20, out logic_uScriptAct_GetChildrenByName_ChildrenCount_20);
         local_Door_L_UnityEngine_GameObject = logic_uScriptAct_GetChildrenByName_FirstChild_20;
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
         bool test_0 = logic_uScriptAct_GetChildrenByName_uScriptAct_GetChildrenByName_20.ChildrenFound;
         
         if ( test_0 == true )
         {
            Relay_In_0();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript Doors_DoorPrefabGraph.uscript at Get Children By Name.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_DoorPrefabGraph.uscript:1", local_1_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ffc089fa-090e-46db-a04c-d46ce8d63f31", local_1_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_DoorPrefabGraph.uscript:Door_R", local_Door_R_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d8f1a279-9c0c-4c28-9572-52cb50da0cbe", local_Door_R_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_DoorPrefabGraph.uscript:5", local_5_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "58b246cf-6845-483e-a2f9-eeccd4a5e962", local_5_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_DoorPrefabGraph.uscript:Door_L", local_Door_L_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "25b0ae1d-5a59-43c1-b2d9-ed449eab43c8", local_Door_L_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "Doors_DoorPrefabGraph.uscript:Door Open?", local_Door_Open__System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b48fe905-5f27-49a4-8987-fc366e740e52", local_Door_Open__System_Boolean);
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
