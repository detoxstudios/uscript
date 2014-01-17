//uScript Generated Code - Build 1.0.2505
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("Untitled", "")]
public class DialogTest : uScriptLogic
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
   System.String local_34_System_String = "";
   System.String[] local_4_System_StringArray = new System.String[] {"Hello!","Line 1","Line 2","Line 3"};
   System.Boolean local_ShowText_System_Boolean = (bool) false;
   
   //owner nodes
   UnityEngine.GameObject owner_Connection_6 = null;
   UnityEngine.GameObject owner_Connection_12 = null;
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_ForEachListString logic_uScriptAct_ForEachListString_uScriptAct_ForEachListString_0 = new uScriptAct_ForEachListString( );
   System.String[] logic_uScriptAct_ForEachListString_List_0 = new System.String[] {};
   System.String logic_uScriptAct_ForEachListString_Value_0;
   System.Int32 logic_uScriptAct_ForEachListString_currentIndex_0;
   bool logic_uScriptAct_ForEachListString_Immediate_0 = true;
   bool logic_uScriptAct_ForEachListString_Done_0 = true;
   bool logic_uScriptAct_ForEachListString_Iteration_0 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_2 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_2 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_2 = true;
   bool logic_uScriptCon_CompareBool_False_2 = true;
   //pointer to script instanced logic node
   uScriptAct_SetBool logic_uScriptAct_SetBool_uScriptAct_SetBool_7 = new uScriptAct_SetBool( );
   System.Boolean logic_uScriptAct_SetBool_Target_7;
   bool logic_uScriptAct_SetBool_Out_7 = true;
   bool logic_uScriptAct_SetBool_SetTrue_7 = true;
   bool logic_uScriptAct_SetBool_SetFalse_7 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_9 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_9 = "";
   System.Int32 logic_uScriptAct_PrintText_FontSize_9 = (int) 24;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_9 = UnityEngine.FontStyle.Bold;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_9 = new UnityEngine.Color( (float)1, (float)1, (float)0.6538461, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_9 = UnityEngine.TextAnchor.MiddleCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_9 = (int) 8;
   System.Single logic_uScriptAct_PrintText_time_9 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_9 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_10 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_10 = UnityEngine.KeyCode.O;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_10 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_10 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_10 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_13 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_13 = UnityEngine.KeyCode.T;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_13 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_13 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_13 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_14 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_14 = UnityEngine.KeyCode.F;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_14 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_14 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_14 = true;
   
   //event nodes
   System.Int32 event_UnityEngine_GameObject_TimesToTrigger_5 = (int) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_5 = null;
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      if ( null == owner_Connection_6 || false == m_RegisteredForEvents )
      {
         owner_Connection_6 = parentGameObject;
         if ( null != owner_Connection_6 )
         {
            {
               uScript_Triggers component = owner_Connection_6.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = owner_Connection_6.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_5;
               }
            }
            {
               uScript_Triggers component = owner_Connection_6.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = owner_Connection_6.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_5;
                  component.OnExitTrigger += Instance_OnExitTrigger_5;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_5;
               }
            }
            {
               uScript_Input component = owner_Connection_6.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = owner_Connection_6.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_3;
               }
            }
         }
      }
      if ( null == owner_Connection_12 || false == m_RegisteredForEvents )
      {
         owner_Connection_12 = parentGameObject;
         if ( null != owner_Connection_12 )
         {
            {
               uScript_Input component = owner_Connection_12.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = owner_Connection_12.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_11;
               }
            }
         }
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
      //reset event listeners if needed
      //this isn't a variable node so it should only be called once per enabling of the script
      //if it's called twice there would be a double event registration (which is an error)
      if ( false == m_RegisteredForEvents )
      {
         if ( null != owner_Connection_6 )
         {
            {
               uScript_Triggers component = owner_Connection_6.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = owner_Connection_6.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.TimesToTrigger = event_UnityEngine_GameObject_TimesToTrigger_5;
               }
            }
            {
               uScript_Triggers component = owner_Connection_6.GetComponent<uScript_Triggers>();
               if ( null == component )
               {
                  component = owner_Connection_6.AddComponent<uScript_Triggers>();
               }
               if ( null != component )
               {
                  component.OnEnterTrigger += Instance_OnEnterTrigger_5;
                  component.OnExitTrigger += Instance_OnExitTrigger_5;
                  component.WhileInsideTrigger += Instance_WhileInsideTrigger_5;
               }
            }
            {
               uScript_Input component = owner_Connection_6.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = owner_Connection_6.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_3;
               }
            }
         }
      }
      //reset event listeners if needed
      //this isn't a variable node so it should only be called once per enabling of the script
      //if it's called twice there would be a double event registration (which is an error)
      if ( false == m_RegisteredForEvents )
      {
         if ( null != owner_Connection_12 )
         {
            {
               uScript_Input component = owner_Connection_12.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = owner_Connection_12.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_11;
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
      if ( null != owner_Connection_6 )
      {
         {
            uScript_Triggers component = owner_Connection_6.GetComponent<uScript_Triggers>();
            if ( null != component )
            {
               component.OnEnterTrigger -= Instance_OnEnterTrigger_5;
               component.OnExitTrigger -= Instance_OnExitTrigger_5;
               component.WhileInsideTrigger -= Instance_WhileInsideTrigger_5;
            }
         }
         {
            uScript_Input component = owner_Connection_6.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_3;
            }
         }
      }
      if ( null != owner_Connection_12 )
      {
         {
            uScript_Input component = owner_Connection_12.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_11;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_ForEachListString_uScriptAct_ForEachListString_0.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_2.SetParent(g);
      logic_uScriptAct_SetBool_uScriptAct_SetBool_7.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_9.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_10.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_13.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_14.SetParent(g);
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
   
   void Instance_KeyEvent_3(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_3( );
   }
   
   void Instance_OnEnterTrigger_5(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_5 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_5( );
   }
   
   void Instance_OnExitTrigger_5(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_5 = e.GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_5( );
   }
   
   void Instance_WhileInsideTrigger_5(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_GameObject_5 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_5( );
   }
   
   void Instance_KeyEvent_11(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_11( );
   }
   
   void Relay_Reset_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("fdc3e518-9994-4327-b833-01eabe7c0409", "For Each In List (String)", Relay_Reset_0)) return; 
         {
            {
               List<System.String> properties = new List<System.String>();
               properties.AddRange(local_4_System_StringArray);
               logic_uScriptAct_ForEachListString_List_0 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_ForEachListString_uScriptAct_ForEachListString_0.Reset(logic_uScriptAct_ForEachListString_List_0, out logic_uScriptAct_ForEachListString_Value_0, out logic_uScriptAct_ForEachListString_currentIndex_0);
         local_34_System_String = logic_uScriptAct_ForEachListString_Value_0;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_ForEachListString_uScriptAct_ForEachListString_0.Iteration;
         
         if ( test_0 == true )
         {
            Relay_ShowLabel_9();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DialogTest.uscript at For Each In List (String).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("fdc3e518-9994-4327-b833-01eabe7c0409", "For Each In List (String)", Relay_In_0)) return; 
         {
            {
               List<System.String> properties = new List<System.String>();
               properties.AddRange(local_4_System_StringArray);
               logic_uScriptAct_ForEachListString_List_0 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_ForEachListString_uScriptAct_ForEachListString_0.In(logic_uScriptAct_ForEachListString_List_0, out logic_uScriptAct_ForEachListString_Value_0, out logic_uScriptAct_ForEachListString_currentIndex_0);
         local_34_System_String = logic_uScriptAct_ForEachListString_Value_0;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_ForEachListString_uScriptAct_ForEachListString_0.Iteration;
         
         if ( test_0 == true )
         {
            Relay_ShowLabel_9();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DialogTest.uscript at For Each In List (String).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("f97958b4-89fb-4ffc-bbbb-2caba40059e0", "Compare Bool", Relay_In_2)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_2 = local_ShowText_System_Boolean;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_2.In(logic_uScriptCon_CompareBool_Bool_2);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_2.True;
         
         if ( test_0 == true )
         {
            Relay_In_0();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DialogTest.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_3()
   {
      if (true == CheckDebugBreak("37e911ef-369b-4ead-b881-8c2b01befe92", "Input Events", Relay_KeyEvent_3)) return; 
      Relay_In_10();
   }
   
   void Relay_OnEnterTrigger_5()
   {
      if (true == CheckDebugBreak("e9db2eed-70bd-4606-9e4a-67abc12c45a7", "Trigger Events", Relay_OnEnterTrigger_5)) return; 
      Relay_True_7();
   }
   
   void Relay_OnExitTrigger_5()
   {
      if (true == CheckDebugBreak("e9db2eed-70bd-4606-9e4a-67abc12c45a7", "Trigger Events", Relay_OnExitTrigger_5)) return; 
      Relay_False_7();
   }
   
   void Relay_WhileInsideTrigger_5()
   {
      if (true == CheckDebugBreak("e9db2eed-70bd-4606-9e4a-67abc12c45a7", "Trigger Events", Relay_WhileInsideTrigger_5)) return; 
   }
   
   void Relay_True_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("297b91b5-0b64-4129-b7ba-b914c3f4214f", "Set Bool", Relay_True_7)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_7.True(out logic_uScriptAct_SetBool_Target_7);
         local_ShowText_System_Boolean = logic_uScriptAct_SetBool_Target_7;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_7.SetTrue;
         bool test_1 = logic_uScriptAct_SetBool_uScriptAct_SetBool_7.SetFalse;
         
         if ( test_0 == true )
         {
            Relay_In_0();
         }
         if ( test_1 == true )
         {
            Relay_Reset_0();
            Relay_HideLabel_9();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DialogTest.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_False_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("297b91b5-0b64-4129-b7ba-b914c3f4214f", "Set Bool", Relay_False_7)) return; 
         {
            {
            }
         }
         logic_uScriptAct_SetBool_uScriptAct_SetBool_7.False(out logic_uScriptAct_SetBool_Target_7);
         local_ShowText_System_Boolean = logic_uScriptAct_SetBool_Target_7;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SetBool_uScriptAct_SetBool_7.SetTrue;
         bool test_1 = logic_uScriptAct_SetBool_uScriptAct_SetBool_7.SetFalse;
         
         if ( test_0 == true )
         {
            Relay_In_0();
         }
         if ( test_1 == true )
         {
            Relay_Reset_0();
            Relay_HideLabel_9();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DialogTest.uscript at Set Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e892a8bc-ad95-4b3b-beb2-a03b977d62d5", "Print Text", Relay_ShowLabel_9)) return; 
         {
            {
               logic_uScriptAct_PrintText_Text_9 = local_34_System_String;
               
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript DialogTest.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e892a8bc-ad95-4b3b-beb2-a03b977d62d5", "Print Text", Relay_HideLabel_9)) return; 
         {
            {
               logic_uScriptAct_PrintText_Text_9 = local_34_System_String;
               
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript DialogTest.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2f7bcfe6-4205-4da6-af4f-137c1f00510b", "Input Events Filter", Relay_In_10)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_10.In(logic_uScriptAct_OnInputEventFilter_KeyCode_10);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_10.KeyDown;
         
         if ( test_0 == true )
         {
            Relay_In_2();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DialogTest.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_11()
   {
      if (true == CheckDebugBreak("950a5ea5-a75b-483a-8509-961857f5c2a0", "Input Events", Relay_KeyEvent_11)) return; 
      Relay_In_13();
      Relay_In_14();
   }
   
   void Relay_In_13()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("849abcaf-bcdb-46dc-9482-795ca003ed8d", "Input Events Filter", Relay_In_13)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_13.In(logic_uScriptAct_OnInputEventFilter_KeyCode_13);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_13.KeyDown;
         
         if ( test_0 == true )
         {
            Relay_True_7();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DialogTest.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_14()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7c9a8d12-fca2-4e59-9805-c2af07a45f72", "Input Events Filter", Relay_In_14)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_14.In(logic_uScriptAct_OnInputEventFilter_KeyCode_14);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_14.KeyDown;
         
         if ( test_0 == true )
         {
            Relay_False_7();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript DialogTest.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "DialogTest.uscript:4", local_4_System_StringArray);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "df5e0cd5-629a-43db-a9a1-df49e4ca4e84", local_4_System_StringArray);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "DialogTest.uscript:ShowText", local_ShowText_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d64e3e11-fa3b-4907-aa79-673d30f9b3e8", local_ShowText_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "DialogTest.uscript:34", local_34_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b4a62367-592e-42b9-9346-7969b60ed6e6", local_34_System_String);
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
