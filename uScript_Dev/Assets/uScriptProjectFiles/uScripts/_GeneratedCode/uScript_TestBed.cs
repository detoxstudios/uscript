//uScript Generated Code - Build 0.4.0767
using UnityEngine;
using System.Collections;

public class uScript_TestBed : uScriptLogic
{

   #pragma warning disable 414
   GameObject parentGameObject = null;
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
   uScriptAct_InterpolateFloatLinear logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4 = null;
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
   bool logic_uScriptAct_InterpolateFloatLinear_Driven_4 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_5 = null;
   System.String logic_uScriptAct_Log_Prefix_5 = "";
   System.Object[] logic_uScriptAct_Log_Target_5 = new System.Object[] {"End FOV"};
   System.String logic_uScriptAct_Log_Postfix_5 = "";
   bool logic_uScriptAct_Log_Out_5 = true;
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
         event_UnityEngine_GameObject_Instance_10 = GameObject.Find( "_uScript" ) as UnityEngine.GameObject;
         if ( null != event_UnityEngine_GameObject_Instance_10 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_10.GetComponent<uScript_Input>();
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_10;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_11 )
      {
         event_UnityEngine_GameObject_Instance_11 = GameObject.Find( "_uScript" ) as UnityEngine.GameObject;
         if ( null != event_UnityEngine_GameObject_Instance_11 )
         {
            {
               uScript_Global component = event_UnityEngine_GameObject_Instance_11.GetComponent<uScript_Global>();
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
      SyncUnityHooks( );
      
      logic_uScriptAct_Log_uScriptAct_Log_2.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_3.SetParent(g);
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_5.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_6.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_7.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_9.SetParent(g);
   }
   public void Awake()
   {
      #pragma warning disable 414
      GameObject masterObject = GameObject.Find("_uScript");
      uScript_Assets assetComponent = null;
      if ( null != masterObject ) assetComponent = masterObject.GetComponent<uScript_Assets>( );
      if ( null != assetComponent )
      {
      }
      else
      {
         uScriptDebug.Log( "uScript_Assets component cannot be found on GameObject _uScript", uScriptDebug.Type.Error);
      }
      #pragma warning restore 414
      
      SyncUnityHooks( );
      
      logic_uScriptAct_Log_uScriptAct_Log_2 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_3 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4 = ScriptableObject.CreateInstance(typeof(uScriptAct_InterpolateFloatLinear)) as uScriptAct_InterpolateFloatLinear;
      logic_uScriptAct_Log_uScriptAct_Log_5 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Delay_uScriptAct_Delay_6 = ScriptableObject.CreateInstance(typeof(uScriptAct_Delay)) as uScriptAct_Delay;
      logic_uScriptAct_Log_uScriptAct_Log_7 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8 = ScriptableObject.CreateInstance(typeof(uScriptAct_OnInputEventFilter)) as uScriptAct_OnInputEventFilter;
      logic_uScriptAct_Log_uScriptAct_Log_9 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      
      logic_uScriptAct_Delay_uScriptAct_Delay_6.AfterDelay += uScriptAct_Delay_AfterDelay_6;
   }
   
   public override void Update()
   {
      logic_uScriptAct_Log_uScriptAct_Log_2.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_3.Update( );
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_5.Update( );
      logic_uScriptAct_Delay_uScriptAct_Delay_6.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_7.Update( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_9.Update( );
      Relay_Driven_4();
   }
   
   public override void LateUpdate()
   {
      logic_uScriptAct_Log_uScriptAct_Log_2.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_3.LateUpdate( );
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_5.LateUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_6.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_7.LateUpdate( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_9.LateUpdate( );
   }
   
   public override void FixedUpdate()
   {
      logic_uScriptAct_Log_uScriptAct_Log_2.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_3.FixedUpdate( );
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_5.FixedUpdate( );
      logic_uScriptAct_Delay_uScriptAct_Delay_6.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_7.FixedUpdate( );
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_9.FixedUpdate( );
   }
   
   public override void OnGUI()
   {
      logic_uScriptAct_Log_uScriptAct_Log_2.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_3.OnGUI( );
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_5.OnGUI( );
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
   
   void Relay_In_3()
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
   
   void Relay_KeyEvent_10()
   {
      SyncUnityHooks( );
      Relay_In_8();
   }
   
   void Relay_Begin_4()
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
         logic_uScriptAct_InterpolateFloatLinear_startValue_4 = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_13_Get_Refresh( );
         index = 0;
         properties = null;
         logic_uScriptAct_InterpolateFloatLinear_endValue_4 = local_0_System_Single;
         index = 0;
         properties = null;
         logic_uScriptAct_InterpolateFloatLinear_time_4 = local_1_System_Single;
         index = 0;
         properties = null;
         index = 0;
         properties = null;
         index = 0;
         properties = null;
         index = 0;
         properties = null;
      }
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Begin(logic_uScriptAct_InterpolateFloatLinear_startValue_4, logic_uScriptAct_InterpolateFloatLinear_endValue_4, logic_uScriptAct_InterpolateFloatLinear_time_4, logic_uScriptAct_InterpolateFloatLinear_loopType_4, logic_uScriptAct_InterpolateFloatLinear_loopDelay_4, logic_uScriptAct_InterpolateFloatLinear_loopCount_4, out logic_uScriptAct_InterpolateFloatLinear_currentValue_4);
      property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12 = logic_uScriptAct_InterpolateFloatLinear_currentValue_4;
      SyncUnityHooks( );
      property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12_Set_Refresh( );
      if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Started == true )
      {
      }
      if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Stopped == true )
      {
      }
      if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Interpolating == true )
      {
         Relay_In_7();
      }
      if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Finished == true )
      {
         Relay_In_5();
      }
   }
   
   void Relay_Stop_4()
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
         logic_uScriptAct_InterpolateFloatLinear_startValue_4 = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_13_Get_Refresh( );
         index = 0;
         properties = null;
         logic_uScriptAct_InterpolateFloatLinear_endValue_4 = local_0_System_Single;
         index = 0;
         properties = null;
         logic_uScriptAct_InterpolateFloatLinear_time_4 = local_1_System_Single;
         index = 0;
         properties = null;
         index = 0;
         properties = null;
         index = 0;
         properties = null;
         index = 0;
         properties = null;
      }
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Stop(logic_uScriptAct_InterpolateFloatLinear_startValue_4, logic_uScriptAct_InterpolateFloatLinear_endValue_4, logic_uScriptAct_InterpolateFloatLinear_time_4, logic_uScriptAct_InterpolateFloatLinear_loopType_4, logic_uScriptAct_InterpolateFloatLinear_loopDelay_4, logic_uScriptAct_InterpolateFloatLinear_loopCount_4, out logic_uScriptAct_InterpolateFloatLinear_currentValue_4);
      property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12 = logic_uScriptAct_InterpolateFloatLinear_currentValue_4;
      SyncUnityHooks( );
      property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12_Set_Refresh( );
      if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Started == true )
      {
      }
      if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Stopped == true )
      {
      }
      if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Interpolating == true )
      {
         Relay_In_7();
      }
      if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Finished == true )
      {
         Relay_In_5();
      }
   }
   
   void Relay_Resume_4()
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
         logic_uScriptAct_InterpolateFloatLinear_startValue_4 = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_13_Get_Refresh( );
         index = 0;
         properties = null;
         logic_uScriptAct_InterpolateFloatLinear_endValue_4 = local_0_System_Single;
         index = 0;
         properties = null;
         logic_uScriptAct_InterpolateFloatLinear_time_4 = local_1_System_Single;
         index = 0;
         properties = null;
         index = 0;
         properties = null;
         index = 0;
         properties = null;
         index = 0;
         properties = null;
      }
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Resume(logic_uScriptAct_InterpolateFloatLinear_startValue_4, logic_uScriptAct_InterpolateFloatLinear_endValue_4, logic_uScriptAct_InterpolateFloatLinear_time_4, logic_uScriptAct_InterpolateFloatLinear_loopType_4, logic_uScriptAct_InterpolateFloatLinear_loopDelay_4, logic_uScriptAct_InterpolateFloatLinear_loopCount_4, out logic_uScriptAct_InterpolateFloatLinear_currentValue_4);
      property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12 = logic_uScriptAct_InterpolateFloatLinear_currentValue_4;
      SyncUnityHooks( );
      property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12_Set_Refresh( );
      if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Started == true )
      {
      }
      if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Stopped == true )
      {
      }
      if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Interpolating == true )
      {
         Relay_In_7();
      }
      if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Finished == true )
      {
         Relay_In_5();
      }
   }
   
   void Relay_Driven_4( )
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
         logic_uScriptAct_InterpolateFloatLinear_startValue_4 = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_13_Get_Refresh( );
         index = 0;
         properties = null;
         logic_uScriptAct_InterpolateFloatLinear_endValue_4 = local_0_System_Single;
         index = 0;
         properties = null;
         logic_uScriptAct_InterpolateFloatLinear_time_4 = local_1_System_Single;
         index = 0;
         properties = null;
         index = 0;
         properties = null;
         index = 0;
         properties = null;
         index = 0;
         properties = null;
      }
      logic_uScriptAct_InterpolateFloatLinear_Driven_4 = logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Driven(out logic_uScriptAct_InterpolateFloatLinear_currentValue_4);
      if ( true == logic_uScriptAct_InterpolateFloatLinear_Driven_4 )
      {
         property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12 = logic_uScriptAct_InterpolateFloatLinear_currentValue_4;
         SyncUnityHooks( );
         property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12_Set_Refresh( );
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Started == true )
         {
         }
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Stopped == true )
         {
         }
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Interpolating == true )
         {
            Relay_In_7();
         }
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_4.Finished == true )
         {
            Relay_In_5();
         }
      }
   }
   void Relay_In_5()
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
      logic_uScriptAct_Log_uScriptAct_Log_5.In(logic_uScriptAct_Log_Prefix_5, logic_uScriptAct_Log_Target_5, logic_uScriptAct_Log_Postfix_5);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_5.Out == true )
      {
      }
   }
   
   void Relay_AfterDelay_6()
   {
      Relay_In_9();
      Relay_Begin_4();
   }
   
   void Relay_In_6()
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
   
   void Relay_In_7()
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
   
   void Relay_In_8()
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
   
   void Relay_In_9()
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
   
   void Relay_uScriptStart_11()
   {
      SyncUnityHooks( );
      Relay_In_6();
   }
   
   [Driven]
   public bool Driven_4(  )
   {
      return logic_uScriptAct_InterpolateFloatLinear_Driven_4;
   }
   
}
