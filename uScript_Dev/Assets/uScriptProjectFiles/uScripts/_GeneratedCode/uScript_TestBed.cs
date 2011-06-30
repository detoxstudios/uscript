//uScript Generated Code - Build 0.6.0905
using UnityEngine;
using System.Collections;

public class uScript_TestBed : uScriptLogic
{

   #pragma warning disable 414
   GameObject parentGameObject = null;
   const int MaxRelayCallCount = 1000;
   int relayCallCount = 0;
   //external output properties
   
   //externally exposed events
   
   //external parameters
   
   //local nodes
   System.Single local_1_System_Single = (float) 2;
   System.Single local_0_System_Single = (float) 90;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_2 = null;
   System.String logic_uScriptAct_Log_Prefix_2 = "";
   System.Object[] logic_uScriptAct_Log_Target_2 = new System.Object[] {"Up"};
   System.String logic_uScriptAct_Log_Postfix_2 = "";
   bool logic_uScriptAct_Log_Out_2 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_3 = null;
   System.String logic_uScriptAct_Log_Prefix_3 = "";
   System.Object[] logic_uScriptAct_Log_Target_3 = new System.Object[] {"Down"};
   System.String logic_uScriptAct_Log_Postfix_3 = "";
   bool logic_uScriptAct_Log_Out_3 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_4 = null;
   System.String logic_uScriptAct_Log_Prefix_4 = "";
   System.Object[] logic_uScriptAct_Log_Target_4 = new System.Object[] {"End FOV"};
   System.String logic_uScriptAct_Log_Postfix_4 = "";
   bool logic_uScriptAct_Log_Out_4 = true;
   //pointer to script instanced logic node
   uScriptAct_InterpolateFloatLinear logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5 = null;
   System.Single logic_uScriptAct_InterpolateFloatLinear_startValue_5 = (float) 0;
   System.Single logic_uScriptAct_InterpolateFloatLinear_endValue_5 = (float) 0;
   System.Single logic_uScriptAct_InterpolateFloatLinear_time_5 = (float) 0;
   uScript_Lerper.LoopType logic_uScriptAct_InterpolateFloatLinear_loopType_5 = uScript_Lerper.LoopType.None;
   System.Single logic_uScriptAct_InterpolateFloatLinear_loopDelay_5 = (float) 0;
   System.Int32 logic_uScriptAct_InterpolateFloatLinear_loopCount_5 = (int) 0;
   System.Single logic_uScriptAct_InterpolateFloatLinear_currentValue_5;
   bool logic_uScriptAct_InterpolateFloatLinear_Started_5 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Stopped_5 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Interpolating_5 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Finished_5 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Driven_5 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_6 = null;
   System.Single logic_uScriptAct_Delay_Duration_6 = (float) 1;
   bool logic_uScriptAct_Delay_Immediate_6 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_7 = null;
   System.String logic_uScriptAct_Log_Prefix_7 = "FOV: ";
   System.Object[] logic_uScriptAct_Log_Target_7 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_7 = "";
   bool logic_uScriptAct_Log_Out_7 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8 = null;
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_8 = UnityEngine.KeyCode.A;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_8 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_8 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_8 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_9 = null;
   System.String logic_uScriptAct_Log_Prefix_9 = "";
   System.Object[] logic_uScriptAct_Log_Target_9 = new System.Object[] {"Start FOV"};
   System.String logic_uScriptAct_Log_Postfix_9 = "";
   bool logic_uScriptAct_Log_Out_9 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_10 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_11 = null;
   
   //property nodes
   System.Single property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12 = (float) 0;
   UnityEngine.Camera property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_12 = null;
   System.Single property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_13 = (float) 0;
   UnityEngine.Camera property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_13 = null;
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   System.Single property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12_Get_Refresh( )
   {
      return property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_12.fieldOfView;
   }
   
   void property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12_Set_Refresh( )
   {
      property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_12.fieldOfView = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12;
   }
   
   System.Single property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_13_Get_Refresh( )
   {
      return property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_13.fieldOfView;
   }
   
   void property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_13_Set_Refresh( )
   {
      property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_13.fieldOfView = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_13;
   }
   
   
   void SyncUnityHooks( )
   {
      if ( null == event_UnityEngine_GameObject_Instance_10 )
      {
         event_UnityEngine_GameObject_Instance_10 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_10 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_10.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_10.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_10;
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
      if ( null == property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_12 )
      {
         GameObject gameObject = GameObject.Find( "Main Camera" );
         if ( null != gameObject )
         {
            property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_12 = gameObject.GetComponent<UnityEngine.Camera>();
            if ( null != property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_12 )
            {
            }
         }
      }
      if ( null == property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_13 )
      {
         GameObject gameObject = GameObject.Find( "Main Camera" );
         if ( null != gameObject )
         {
            property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_13 = gameObject.GetComponent<UnityEngine.Camera>();
            if ( null != property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_13 )
            {
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_Log_uScriptAct_Log_2.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_3.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_4.SetParent(g);
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_6.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_7.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_9.SetParent(g);
   }
   public void Awake()
   {
      logic_uScriptAct_Log_uScriptAct_Log_2 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_3 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_4 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5 = ScriptableObject.CreateInstance(typeof(uScriptAct_InterpolateFloatLinear)) as uScriptAct_InterpolateFloatLinear;
      logic_uScriptAct_Delay_uScriptAct_Delay_6 = ScriptableObject.CreateInstance(typeof(uScriptAct_Delay)) as uScriptAct_Delay;
      logic_uScriptAct_Log_uScriptAct_Log_7 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8 = ScriptableObject.CreateInstance(typeof(uScriptAct_OnInputEventFilter)) as uScriptAct_OnInputEventFilter;
      logic_uScriptAct_Log_uScriptAct_Log_9 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      
      logic_uScriptAct_Delay_uScriptAct_Delay_6.AfterDelay += uScriptAct_Delay_AfterDelay_6;
   }
   
   public override void Start()
   {
      
      SyncUnityHooks( );
      
      logic_uScriptAct_Log_uScriptAct_Log_2.Start( );
      logic_uScriptAct_Log_uScriptAct_Log_3.Start( );
      logic_uScriptAct_Log_uScriptAct_Log_4.Start( );
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Start( );
      logic_uScriptAct_Delay_uScriptAct_Delay_6.Start( );
      logic_uScriptAct_Log_uScriptAct_Log_7.Start( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.Start( );
      logic_uScriptAct_Log_uScriptAct_Log_9.Start( );
   }
   
   public override void Update()
   {
      //reset each Update, and increments each method call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      logic_uScriptAct_Log_uScriptAct_Log_2.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_3.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_4.Update( );
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Update( );
      logic_uScriptAct_Delay_uScriptAct_Delay_6.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_7.Update( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_9.Update( );
      Relay_Driven_5();
   }
   
   public override void LateUpdate()
   {
      logic_uScriptAct_Log_uScriptAct_Log_2.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_3.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_4.LateUpdate( );
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.LateUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_6.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_7.LateUpdate( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_9.LateUpdate( );
   }
   
   public override void FixedUpdate()
   {
      logic_uScriptAct_Log_uScriptAct_Log_2.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_3.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_4.FixedUpdate( );
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.FixedUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_6.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_7.FixedUpdate( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_9.FixedUpdate( );
   }
   
   public override void OnGUI()
   {
      logic_uScriptAct_Log_uScriptAct_Log_2.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_3.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_4.OnGUI( );
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.OnGUI( );
      logic_uScriptAct_Delay_uScriptAct_Delay_6.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_7.OnGUI( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_9.OnGUI( );
   }
   
   void Instance_KeyEvent_10(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_10( );
   }
   
   void Instance_uScriptStart_11(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_11( );
   }
   
   void uScriptAct_Delay_AfterDelay_6(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_AfterDelay_6( );
   }
   
   void Relay_In_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_Log_uScriptAct_Log_2.In(logic_uScriptAct_Log_Prefix_2, logic_uScriptAct_Log_Target_2, logic_uScriptAct_Log_Postfix_2);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Log_uScriptAct_Log_2.Out == true )
         {
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_Log_uScriptAct_Log_3.In(logic_uScriptAct_Log_Prefix_3, logic_uScriptAct_Log_Target_3, logic_uScriptAct_Log_Postfix_3);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Log_uScriptAct_Log_3.Out == true )
         {
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         Relay_In_8();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Input Events.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_4()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_Log_uScriptAct_Log_4.In(logic_uScriptAct_Log_Prefix_4, logic_uScriptAct_Log_Target_4, logic_uScriptAct_Log_Postfix_4);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Log_uScriptAct_Log_4.Out == true )
         {
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Begin_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            logic_uScriptAct_InterpolateFloatLinear_startValue_5 = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_13_Get_Refresh( );
            index = 0;
            properties = null;
            logic_uScriptAct_InterpolateFloatLinear_endValue_5 = local_0_System_Single;
            index = 0;
            properties = null;
            logic_uScriptAct_InterpolateFloatLinear_time_5 = local_1_System_Single;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Begin(logic_uScriptAct_InterpolateFloatLinear_startValue_5, logic_uScriptAct_InterpolateFloatLinear_endValue_5, logic_uScriptAct_InterpolateFloatLinear_time_5, logic_uScriptAct_InterpolateFloatLinear_loopType_5, logic_uScriptAct_InterpolateFloatLinear_loopDelay_5, logic_uScriptAct_InterpolateFloatLinear_loopCount_5, out logic_uScriptAct_InterpolateFloatLinear_currentValue_5);
         property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12 = logic_uScriptAct_InterpolateFloatLinear_currentValue_5;
         SyncUnityHooks( );
         property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12_Set_Refresh( );
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Started == true )
         {
         }
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Stopped == true )
         {
         }
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Interpolating == true )
         {
            Relay_In_7();
         }
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Finished == true )
         {
            Relay_In_4();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Interpolate Float Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            logic_uScriptAct_InterpolateFloatLinear_startValue_5 = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_13_Get_Refresh( );
            index = 0;
            properties = null;
            logic_uScriptAct_InterpolateFloatLinear_endValue_5 = local_0_System_Single;
            index = 0;
            properties = null;
            logic_uScriptAct_InterpolateFloatLinear_time_5 = local_1_System_Single;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Stop(logic_uScriptAct_InterpolateFloatLinear_startValue_5, logic_uScriptAct_InterpolateFloatLinear_endValue_5, logic_uScriptAct_InterpolateFloatLinear_time_5, logic_uScriptAct_InterpolateFloatLinear_loopType_5, logic_uScriptAct_InterpolateFloatLinear_loopDelay_5, logic_uScriptAct_InterpolateFloatLinear_loopCount_5, out logic_uScriptAct_InterpolateFloatLinear_currentValue_5);
         property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12 = logic_uScriptAct_InterpolateFloatLinear_currentValue_5;
         SyncUnityHooks( );
         property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12_Set_Refresh( );
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Started == true )
         {
         }
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Stopped == true )
         {
         }
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Interpolating == true )
         {
            Relay_In_7();
         }
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Finished == true )
         {
            Relay_In_4();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Interpolate Float Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Resume_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            logic_uScriptAct_InterpolateFloatLinear_startValue_5 = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_13_Get_Refresh( );
            index = 0;
            properties = null;
            logic_uScriptAct_InterpolateFloatLinear_endValue_5 = local_0_System_Single;
            index = 0;
            properties = null;
            logic_uScriptAct_InterpolateFloatLinear_time_5 = local_1_System_Single;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Resume(logic_uScriptAct_InterpolateFloatLinear_startValue_5, logic_uScriptAct_InterpolateFloatLinear_endValue_5, logic_uScriptAct_InterpolateFloatLinear_time_5, logic_uScriptAct_InterpolateFloatLinear_loopType_5, logic_uScriptAct_InterpolateFloatLinear_loopDelay_5, logic_uScriptAct_InterpolateFloatLinear_loopCount_5, out logic_uScriptAct_InterpolateFloatLinear_currentValue_5);
         property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12 = logic_uScriptAct_InterpolateFloatLinear_currentValue_5;
         SyncUnityHooks( );
         property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12_Set_Refresh( );
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Started == true )
         {
         }
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Stopped == true )
         {
         }
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Interpolating == true )
         {
            Relay_In_7();
         }
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Finished == true )
         {
            Relay_In_4();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Interpolate Float Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Driven_5( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            logic_uScriptAct_InterpolateFloatLinear_startValue_5 = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_13_Get_Refresh( );
            index = 0;
            properties = null;
            logic_uScriptAct_InterpolateFloatLinear_endValue_5 = local_0_System_Single;
            index = 0;
            properties = null;
            logic_uScriptAct_InterpolateFloatLinear_time_5 = local_1_System_Single;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_InterpolateFloatLinear_Driven_5 = logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Driven(out logic_uScriptAct_InterpolateFloatLinear_currentValue_5);
         if ( true == logic_uScriptAct_InterpolateFloatLinear_Driven_5 )
         {
            property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12 = logic_uScriptAct_InterpolateFloatLinear_currentValue_5;
            SyncUnityHooks( );
            property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12_Set_Refresh( );
            if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Started == true )
            {
            }
            if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Stopped == true )
            {
            }
            if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Interpolating == true )
            {
               Relay_In_7();
            }
            if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_5.Finished == true )
            {
               Relay_In_4();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Interpolate Float Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_AfterDelay_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         Relay_In_9();
         Relay_Begin_5();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_6.In(logic_uScriptAct_Delay_Duration_6);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Delay_uScriptAct_Delay_6.Immediate == true )
         {
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            if ( logic_uScriptAct_Log_Target_7.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Log_Target_7, index + 1);
            }
            logic_uScriptAct_Log_Target_7[ index++ ] = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12_Get_Refresh( );
            
            index = 0;
            properties = null;
         }
         logic_uScriptAct_Log_uScriptAct_Log_7.In(logic_uScriptAct_Log_Prefix_7, logic_uScriptAct_Log_Target_7, logic_uScriptAct_Log_Postfix_7);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Log_uScriptAct_Log_7.Out == true )
         {
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_8()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.In(logic_uScriptAct_OnInputEventFilter_KeyCode_8);
         SyncUnityHooks( );
         if ( logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.KeyHeld == true )
         {
         }
         if ( logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.KeyDown == true )
         {
            Relay_In_3();
         }
         if ( logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.KeyUp == true )
         {
            Relay_In_2();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            #pragma warning disable 219
            #pragma warning disable 168
            int index = 0;
            System.Array properties;
            #pragma warning restore 219
            #pragma warning restore 168
            index = 0;
            properties = null;
            index = 0;
            properties = null;
            index = 0;
            properties = null;
         }
         logic_uScriptAct_Log_uScriptAct_Log_9.In(logic_uScriptAct_Log_Prefix_9, logic_uScriptAct_Log_Target_9, logic_uScriptAct_Log_Postfix_9);
         SyncUnityHooks( );
         if ( logic_uScriptAct_Log_uScriptAct_Log_9.Out == true )
         {
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_uScriptStart_11()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         Relay_In_6();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at uScript Events.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   [Driven]
   public bool Driven_5(  )
   {
      return logic_uScriptAct_InterpolateFloatLinear_Driven_5;
   }
   
}
