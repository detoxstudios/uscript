//uScript Generated Code - Build 0.9.1613
using UnityEngine;
using System.Collections;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class uScript_TestBed : uScriptLogic
{

   #pragma warning disable 414
   GameObject parentGameObject = null;
   uScript_GUI thisScriptsOnGuiListener = null; 
   //external output properties
   
   //externally exposed events
   
   //external parameters
   
   //local nodes
   System.Single local_2_System_Single = (float) 90;
   System.Single local_12_System_Single = (float) 2;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_1 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_1 = "";
   System.Object[] logic_uScriptAct_Log_Target_1 = new System.Object[] {"Up"};
   System.Object logic_uScriptAct_Log_Postfix_1 = "";
   bool logic_uScriptAct_Log_Out_1 = true;
   //pointer to script instanced logic node
   uScriptAct_InterpolateFloatLinear logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4 = new uScriptAct_InterpolateFloatLinear( );
   System.Single logic_uScriptAct_InterpolateFloatLinear_startValue_4 = (float) 0;
   System.Single logic_uScriptAct_InterpolateFloatLinear_endValue_4 = (float) 0;
   System.Single logic_uScriptAct_InterpolateFloatLinear_time_4 = (float) 0;
   uScript_Lerper.LoopType logic_uScriptAct_InterpolateFloatLinear_loopType_4 = uScript_Lerper.LoopType.None;
   System.Single logic_uScriptAct_InterpolateFloatLinear_loopDelay_4 = (float) 0;
   System.Int32 logic_uScriptAct_InterpolateFloatLinear_loopCount_4 = (int) 0;
   System.Single logic_uScriptAct_InterpolateFloatLinear_currentValue_4;
   bool logic_uScriptAct_InterpolateFloatLinear_Started_4 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Stopped_4 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Interpolating_4 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Finished_4 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Driven_4 = false;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_6 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_6 = "";
   System.Object[] logic_uScriptAct_Log_Target_6 = new System.Object[] {"Down"};
   System.Object logic_uScriptAct_Log_Postfix_6 = "";
   bool logic_uScriptAct_Log_Out_6 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_7 = new uScriptAct_Delay( );
   System.Single logic_uScriptAct_Delay_Duration_7 = (float) 1;
   bool logic_uScriptAct_Delay_Immediate_7 = true;
   bool logic_uScriptAct_Delay_AfterDelay_7 = true;
   bool logic_uScriptAct_Delay_DrivenDelay_7 = false;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_8 = UnityEngine.KeyCode.A;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_8 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_8 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_8 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_9 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_9 = "";
   System.Object[] logic_uScriptAct_Log_Target_9 = new System.Object[] {};
   System.Object logic_uScriptAct_Log_Postfix_9 = "";
   bool logic_uScriptAct_Log_Out_9 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_10 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_10 = "";
   System.Object[] logic_uScriptAct_Log_Target_10 = new System.Object[] {"Start FOV"};
   System.Object logic_uScriptAct_Log_Postfix_10 = "";
   bool logic_uScriptAct_Log_Out_10 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_13 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_13 = "";
   System.Object[] logic_uScriptAct_Log_Target_13 = new System.Object[] {"End FOV"};
   System.Object logic_uScriptAct_Log_Postfix_13 = "";
   bool logic_uScriptAct_Log_Out_13 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_3 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_11 = null;
   
   //property nodes
   System.Single property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_0 = (float) 0;
   UnityEngine.GameObject property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_0 = null;
   System.Single property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_5 = (float) 0;
   UnityEngine.GameObject property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_5 = null;
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   System.Single property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_0_Get_Refresh( )
   {
      UnityEngine.Camera component = property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_0.GetComponent<UnityEngine.Camera>();
      if ( null != component )
      {
         return component.fieldOfView;
      }
      else
      {
         return (float) 0;
      }
   }
   
   void property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_0_Set_Refresh( )
   {
      UnityEngine.Camera component = property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_0.GetComponent<UnityEngine.Camera>();
      if ( null != component )
      {
         component.fieldOfView = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_0;
      }
   }
   
   System.Single property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_5_Get_Refresh( )
   {
      UnityEngine.Camera component = property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_5.GetComponent<UnityEngine.Camera>();
      if ( null != component )
      {
         return component.fieldOfView;
      }
      else
      {
         return (float) 0;
      }
   }
   
   void property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_5_Set_Refresh( )
   {
      UnityEngine.Camera component = property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_5.GetComponent<UnityEngine.Camera>();
      if ( null != component )
      {
         component.fieldOfView = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_5;
      }
   }
   
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      if ( null == property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_0 )
      {
         property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_0 = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
      if ( null == property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_5 )
      {
         property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_5 = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
   }
   
   void SyncEventListeners( )
   {
      if ( null == event_UnityEngine_GameObject_Instance_3 )
      {
         event_UnityEngine_GameObject_Instance_3 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_3 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_3.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_3.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_3;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_11 )
      {
         event_UnityEngine_GameObject_Instance_11 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_11 )
         {
            {
               uScript_Global component = event_UnityEngine_GameObject_Instance_11.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_11.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_11;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != event_UnityEngine_GameObject_Instance_3 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_3.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_3;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_11 )
      {
         {
            uScript_Global component = event_UnityEngine_GameObject_Instance_11.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_11;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_Log_uScriptAct_Log_1.SetParent(g);
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_6.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_7.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_9.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_10.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_13.SetParent(g);
   }
   public void Awake()
   {
      
   }
   
   public void Start()
   {
      SyncUnityHooks( );
      
   }
   
   public void Update()
   {
      //other scripts might have added GameObjects with event scripts
      //so we need to verify all our event listeners are registered
      SyncEventListeners( );
      
      if (true == logic_uScriptAct_InterpolateFloatLinear_Driven_4)
      {
         Relay_Driven_4();
      }
      if (true == logic_uScriptAct_Delay_DrivenDelay_7)
      {
         Relay_DrivenDelay_7();
      }
   }
   
   public void OnDestroy()
   {
      UnregisterEventListeners( );
   }
   
   void Instance_KeyEvent_3(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_3( );
   }
   
   void Instance_uScriptStart_11(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_11( );
   }
   
   void Relay_In_1()
   {
      {
      }
      logic_uScriptAct_Log_uScriptAct_Log_1.In(logic_uScriptAct_Log_Prefix_1, logic_uScriptAct_Log_Target_1, logic_uScriptAct_Log_Postfix_1);
      
      //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
      
   }
   
   void Relay_KeyEvent_3()
   {
      Relay_In_8();
   }
   
   void Relay_Begin_4()
   {
      {
         logic_uScriptAct_InterpolateFloatLinear_startValue_4 = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_5_Get_Refresh( );
         
         logic_uScriptAct_InterpolateFloatLinear_endValue_4 = local_2_System_Single;
         
         logic_uScriptAct_InterpolateFloatLinear_time_4 = local_12_System_Single;
         
      }
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Begin(logic_uScriptAct_InterpolateFloatLinear_startValue_4, logic_uScriptAct_InterpolateFloatLinear_endValue_4, logic_uScriptAct_InterpolateFloatLinear_time_4, logic_uScriptAct_InterpolateFloatLinear_loopType_4, logic_uScriptAct_InterpolateFloatLinear_loopDelay_4, logic_uScriptAct_InterpolateFloatLinear_loopCount_4, out logic_uScriptAct_InterpolateFloatLinear_currentValue_4);
      logic_uScriptAct_InterpolateFloatLinear_Driven_4 = true;
      property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_0 = logic_uScriptAct_InterpolateFloatLinear_currentValue_4;
      property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_0_Set_Refresh( );
      
      //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
      bool test_0 = logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Interpolating;
      bool test_1 = logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Finished;
      
      if ( test_0 == true )
      {
         Relay_In_9();
      }
      if ( test_1 == true )
      {
         Relay_In_13();
      }
   }
   
   void Relay_Stop_4()
   {
      {
         logic_uScriptAct_InterpolateFloatLinear_startValue_4 = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_5_Get_Refresh( );
         
         logic_uScriptAct_InterpolateFloatLinear_endValue_4 = local_2_System_Single;
         
         logic_uScriptAct_InterpolateFloatLinear_time_4 = local_12_System_Single;
         
      }
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Stop(logic_uScriptAct_InterpolateFloatLinear_startValue_4, logic_uScriptAct_InterpolateFloatLinear_endValue_4, logic_uScriptAct_InterpolateFloatLinear_time_4, logic_uScriptAct_InterpolateFloatLinear_loopType_4, logic_uScriptAct_InterpolateFloatLinear_loopDelay_4, logic_uScriptAct_InterpolateFloatLinear_loopCount_4, out logic_uScriptAct_InterpolateFloatLinear_currentValue_4);
      logic_uScriptAct_InterpolateFloatLinear_Driven_4 = true;
      property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_0 = logic_uScriptAct_InterpolateFloatLinear_currentValue_4;
      property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_0_Set_Refresh( );
      
      //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
      bool test_0 = logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Interpolating;
      bool test_1 = logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Finished;
      
      if ( test_0 == true )
      {
         Relay_In_9();
      }
      if ( test_1 == true )
      {
         Relay_In_13();
      }
   }
   
   void Relay_Resume_4()
   {
      {
         logic_uScriptAct_InterpolateFloatLinear_startValue_4 = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_5_Get_Refresh( );
         
         logic_uScriptAct_InterpolateFloatLinear_endValue_4 = local_2_System_Single;
         
         logic_uScriptAct_InterpolateFloatLinear_time_4 = local_12_System_Single;
         
      }
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Resume(logic_uScriptAct_InterpolateFloatLinear_startValue_4, logic_uScriptAct_InterpolateFloatLinear_endValue_4, logic_uScriptAct_InterpolateFloatLinear_time_4, logic_uScriptAct_InterpolateFloatLinear_loopType_4, logic_uScriptAct_InterpolateFloatLinear_loopDelay_4, logic_uScriptAct_InterpolateFloatLinear_loopCount_4, out logic_uScriptAct_InterpolateFloatLinear_currentValue_4);
      logic_uScriptAct_InterpolateFloatLinear_Driven_4 = true;
      property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_0 = logic_uScriptAct_InterpolateFloatLinear_currentValue_4;
      property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_0_Set_Refresh( );
      
      //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
      bool test_0 = logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Interpolating;
      bool test_1 = logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Finished;
      
      if ( test_0 == true )
      {
         Relay_In_9();
      }
      if ( test_1 == true )
      {
         Relay_In_13();
      }
   }
   
   void Relay_Driven_4( )
   {
      {
         logic_uScriptAct_InterpolateFloatLinear_startValue_4 = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_5_Get_Refresh( );
         
         logic_uScriptAct_InterpolateFloatLinear_endValue_4 = local_2_System_Single;
         
         logic_uScriptAct_InterpolateFloatLinear_time_4 = local_12_System_Single;
         
      }
      logic_uScriptAct_InterpolateFloatLinear_Driven_4 = logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Driven(out logic_uScriptAct_InterpolateFloatLinear_currentValue_4);
      if ( true == logic_uScriptAct_InterpolateFloatLinear_Driven_4 )
      {
         property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_0 = logic_uScriptAct_InterpolateFloatLinear_currentValue_4;
         property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_0_Set_Refresh( );
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Interpolating == true )
         {
            Relay_In_9();
         }
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Finished == true )
         {
            Relay_In_13();
         }
      }
   }
   void Relay_In_6()
   {
      {
      }
      logic_uScriptAct_Log_uScriptAct_Log_6.In(logic_uScriptAct_Log_Prefix_6, logic_uScriptAct_Log_Target_6, logic_uScriptAct_Log_Postfix_6);
      
      //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
      
   }
   
   void Relay_In_7()
   {
      {
      }
      logic_uScriptAct_Delay_uScriptAct_Delay_7.In(logic_uScriptAct_Delay_Duration_7);
      logic_uScriptAct_Delay_DrivenDelay_7 = true;
      
      //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
      bool test_0 = logic_uScriptAct_Delay_uScriptAct_Delay_7.AfterDelay;
      
      if ( test_0 == true )
      {
         Relay_In_10();
         Relay_Begin_4();
      }
   }
   
   void Relay_DrivenDelay_7( )
   {
      {
      }
      logic_uScriptAct_Delay_DrivenDelay_7 = logic_uScriptAct_Delay_uScriptAct_Delay_7.DrivenDelay();
      if ( true == logic_uScriptAct_Delay_DrivenDelay_7 )
      {
         if ( logic_uScriptAct_Delay_uScriptAct_Delay_7.AfterDelay == true )
         {
            Relay_In_10();
            Relay_Begin_4();
         }
      }
   }
   void Relay_In_8()
   {
      {
      }
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.In(logic_uScriptAct_OnInputEventFilter_KeyCode_8);
      
      //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
      bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.KeyDown;
      bool test_1 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.KeyUp;
      
      if ( test_0 == true )
      {
         Relay_In_6();
      }
      if ( test_1 == true )
      {
         Relay_In_1();
      }
   }
   
   void Relay_In_9()
   {
      {
         int index;
         index = 0;
         if ( logic_uScriptAct_Log_Target_9.Length <= index)
         {
            System.Array.Resize(ref logic_uScriptAct_Log_Target_9, index + 1);
         }
         logic_uScriptAct_Log_Target_9[ index++ ] = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_0_Get_Refresh( );
         
      }
      logic_uScriptAct_Log_uScriptAct_Log_9.In(logic_uScriptAct_Log_Prefix_9, logic_uScriptAct_Log_Target_9, logic_uScriptAct_Log_Postfix_9);
      
      //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
      
   }
   
   void Relay_In_10()
   {
      {
      }
      logic_uScriptAct_Log_uScriptAct_Log_10.In(logic_uScriptAct_Log_Prefix_10, logic_uScriptAct_Log_Target_10, logic_uScriptAct_Log_Postfix_10);
      
      //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
      
   }
   
   void Relay_uScriptStart_11()
   {
      Relay_In_7();
   }
   
   void Relay_In_13()
   {
      {
      }
      logic_uScriptAct_Log_uScriptAct_Log_13.In(logic_uScriptAct_Log_Prefix_13, logic_uScriptAct_Log_Target_13, logic_uScriptAct_Log_Postfix_13);
      
      //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
      
   }
   
   [Driven]
   public bool Driven_4(  )
   {
      return logic_uScriptAct_InterpolateFloatLinear_Driven_4;
   }
   
   [Driven]
   public bool DrivenDelay_7(  )
   {
      return logic_uScriptAct_Delay_DrivenDelay_7;
   }
   
}
