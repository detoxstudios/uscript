//uScript Generated Code - Build 0.9.1104
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
   System.Single local_0_System_Single = (float) 90;
   System.Single local_1_System_Single = (float) 2;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_2 = null;
   System.String logic_uScriptAct_Log_Prefix_2 = "";
   System.Object[] logic_uScriptAct_Log_Target_2 = new System.Object[] {"Up"};
   System.String logic_uScriptAct_Log_Postfix_2 = "";
   bool logic_uScriptAct_Log_Out_2 = true;
   //pointer to script instanced logic node
   uScriptAct_InterpolateFloatLinear logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_3 = null;
   System.Single logic_uScriptAct_InterpolateFloatLinear_startValue_3 = (float) 0;
   System.Single logic_uScriptAct_InterpolateFloatLinear_endValue_3 = (float) 0;
   System.Single logic_uScriptAct_InterpolateFloatLinear_time_3 = (float) 0;
   uScript_Lerper.LoopType logic_uScriptAct_InterpolateFloatLinear_loopType_3 = uScript_Lerper.LoopType.None;
   System.Single logic_uScriptAct_InterpolateFloatLinear_loopDelay_3 = (float) 0;
   System.Int32 logic_uScriptAct_InterpolateFloatLinear_loopCount_3 = (int) 0;
   System.Single logic_uScriptAct_InterpolateFloatLinear_currentValue_3;
   bool logic_uScriptAct_InterpolateFloatLinear_Started_3 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Stopped_3 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Interpolating_3 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Finished_3 = true;
   bool logic_uScriptAct_InterpolateFloatLinear_Driven_3 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_4 = null;
   System.String logic_uScriptAct_Log_Prefix_4 = "";
   System.Object[] logic_uScriptAct_Log_Target_4 = new System.Object[] {"Down"};
   System.String logic_uScriptAct_Log_Postfix_4 = "";
   bool logic_uScriptAct_Log_Out_4 = true;
   //pointer to script instanced logic node
   uScriptAct_Delay logic_uScriptAct_Delay_uScriptAct_Delay_5 = null;
   System.Single logic_uScriptAct_Delay_Duration_5 = (float) 1;
   bool logic_uScriptAct_Delay_Immediate_5 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_6 = null;
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_6 = UnityEngine.KeyCode.A;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_6 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_6 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_6 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_7 = null;
   System.String logic_uScriptAct_Log_Prefix_7 = "FOV: ";
   System.Object[] logic_uScriptAct_Log_Target_7 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_7 = "";
   bool logic_uScriptAct_Log_Out_7 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_8 = null;
   System.String logic_uScriptAct_Log_Prefix_8 = "";
   System.Object[] logic_uScriptAct_Log_Target_8 = new System.Object[] {"Start FOV"};
   System.String logic_uScriptAct_Log_Postfix_8 = "";
   bool logic_uScriptAct_Log_Out_8 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_9 = null;
   System.String logic_uScriptAct_Log_Prefix_9 = "";
   System.Object[] logic_uScriptAct_Log_Target_9 = new System.Object[] {"End FOV"};
   System.String logic_uScriptAct_Log_Postfix_9 = "";
   bool logic_uScriptAct_Log_Out_9 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_10 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_11 = null;
   
   //property nodes
   System.Single property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12 = (float) 0;
   UnityEngine.GameObject property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_12 = null;
   System.Single property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_13 = (float) 0;
   UnityEngine.GameObject property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_13 = null;
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   System.Single property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12_Get_Refresh( )
   {
      UnityEngine.Camera component = property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_12.GetComponent<UnityEngine.Camera>();
      if ( null != component )
      {
         return component.fieldOfView;
      }
      else
      {
         return (float) 0;
      }
   }
   
   void property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12_Set_Refresh( )
   {
      UnityEngine.Camera component = property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_12.GetComponent<UnityEngine.Camera>();
      if ( null != component )
      {
         component.fieldOfView = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12;
      }
   }
   
   System.Single property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_13_Get_Refresh( )
   {
      UnityEngine.Camera component = property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_13.GetComponent<UnityEngine.Camera>();
      if ( null != component )
      {
         return component.fieldOfView;
      }
      else
      {
         return (float) 0;
      }
   }
   
   void property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_13_Set_Refresh( )
   {
      UnityEngine.Camera component = property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_13.GetComponent<UnityEngine.Camera>();
      if ( null != component )
      {
         component.fieldOfView = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_13;
      }
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
         property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_12 = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
      if ( null == property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_13 )
      {
         property_fieldOfView_Detox_ScriptEditor_Parameter_Instance_13 = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_Log_uScriptAct_Log_2.SetParent(g);
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_3.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_4.SetParent(g);
      logic_uScriptAct_Delay_uScriptAct_Delay_5.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_6.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_7.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_8.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_9.SetParent(g);
   }
   public void Awake()
   {
      logic_uScriptAct_Log_uScriptAct_Log_2 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_3 = ScriptableObject.CreateInstance(typeof(uScriptAct_InterpolateFloatLinear)) as uScriptAct_InterpolateFloatLinear;
      logic_uScriptAct_Log_uScriptAct_Log_4 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Delay_uScriptAct_Delay_5 = ScriptableObject.CreateInstance(typeof(uScriptAct_Delay)) as uScriptAct_Delay;
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_6 = ScriptableObject.CreateInstance(typeof(uScriptAct_OnInputEventFilter)) as uScriptAct_OnInputEventFilter;
      logic_uScriptAct_Log_uScriptAct_Log_7 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_8 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_9 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      
      logic_uScriptAct_Delay_uScriptAct_Delay_5.AfterDelay += uScriptAct_Delay_AfterDelay_5;
   }
   
   public void Update()
   {
      //reset each Update, and increments each method call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      logic_uScriptAct_Delay_uScriptAct_Delay_5.Update( );
      Relay_Driven_3();
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
   
   void uScriptAct_Delay_AfterDelay_5(object o, System.EventArgs e)
   {
      //relay event to nodes
      Relay_AfterDelay_5( );
   }
   
   void Relay_In_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         //param = Prefix
         //param = Target
         //param = Postfix
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_2.In(logic_uScriptAct_Log_Prefix_2, logic_uScriptAct_Log_Target_2, logic_uScriptAct_Log_Postfix_2);
         SyncUnityHooks( );
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
         Relay_In_6();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Input Events.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Begin_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         //param = startValue
         //param = endValue
         //param = time
         //param = loopType
         //param = loopDelay
         //param = loopCount
         //param = currentValue
         SyncUnityHooks( );
         {
            logic_uScriptAct_InterpolateFloatLinear_startValue_3 = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_13_Get_Refresh( );
            
            logic_uScriptAct_InterpolateFloatLinear_endValue_3 = local_0_System_Single;
            
            logic_uScriptAct_InterpolateFloatLinear_time_3 = local_1_System_Single;
            
         }
         logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_3.Begin(logic_uScriptAct_InterpolateFloatLinear_startValue_3, logic_uScriptAct_InterpolateFloatLinear_endValue_3, logic_uScriptAct_InterpolateFloatLinear_time_3, logic_uScriptAct_InterpolateFloatLinear_loopType_3, logic_uScriptAct_InterpolateFloatLinear_loopDelay_3, logic_uScriptAct_InterpolateFloatLinear_loopCount_3, out logic_uScriptAct_InterpolateFloatLinear_currentValue_3);
         property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12 = logic_uScriptAct_InterpolateFloatLinear_currentValue_3;
         SyncUnityHooks( );
         property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12_Set_Refresh( );
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_3.Interpolating == true )
         {
            Relay_In_7();
         }
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_3.Finished == true )
         {
            Relay_In_9();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Interpolate Float Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         //param = startValue
         //param = endValue
         //param = time
         //param = loopType
         //param = loopDelay
         //param = loopCount
         //param = currentValue
         SyncUnityHooks( );
         {
            logic_uScriptAct_InterpolateFloatLinear_startValue_3 = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_13_Get_Refresh( );
            
            logic_uScriptAct_InterpolateFloatLinear_endValue_3 = local_0_System_Single;
            
            logic_uScriptAct_InterpolateFloatLinear_time_3 = local_1_System_Single;
            
         }
         logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_3.Stop(logic_uScriptAct_InterpolateFloatLinear_startValue_3, logic_uScriptAct_InterpolateFloatLinear_endValue_3, logic_uScriptAct_InterpolateFloatLinear_time_3, logic_uScriptAct_InterpolateFloatLinear_loopType_3, logic_uScriptAct_InterpolateFloatLinear_loopDelay_3, logic_uScriptAct_InterpolateFloatLinear_loopCount_3, out logic_uScriptAct_InterpolateFloatLinear_currentValue_3);
         property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12 = logic_uScriptAct_InterpolateFloatLinear_currentValue_3;
         SyncUnityHooks( );
         property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12_Set_Refresh( );
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_3.Interpolating == true )
         {
            Relay_In_7();
         }
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_3.Finished == true )
         {
            Relay_In_9();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Interpolate Float Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Resume_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         //param = startValue
         //param = endValue
         //param = time
         //param = loopType
         //param = loopDelay
         //param = loopCount
         //param = currentValue
         SyncUnityHooks( );
         {
            logic_uScriptAct_InterpolateFloatLinear_startValue_3 = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_13_Get_Refresh( );
            
            logic_uScriptAct_InterpolateFloatLinear_endValue_3 = local_0_System_Single;
            
            logic_uScriptAct_InterpolateFloatLinear_time_3 = local_1_System_Single;
            
         }
         logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_3.Resume(logic_uScriptAct_InterpolateFloatLinear_startValue_3, logic_uScriptAct_InterpolateFloatLinear_endValue_3, logic_uScriptAct_InterpolateFloatLinear_time_3, logic_uScriptAct_InterpolateFloatLinear_loopType_3, logic_uScriptAct_InterpolateFloatLinear_loopDelay_3, logic_uScriptAct_InterpolateFloatLinear_loopCount_3, out logic_uScriptAct_InterpolateFloatLinear_currentValue_3);
         property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12 = logic_uScriptAct_InterpolateFloatLinear_currentValue_3;
         SyncUnityHooks( );
         property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12_Set_Refresh( );
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_3.Interpolating == true )
         {
            Relay_In_7();
         }
         if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_3.Finished == true )
         {
            Relay_In_9();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Interpolate Float Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Driven_3( )
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         SyncUnityHooks( );
         {
            logic_uScriptAct_InterpolateFloatLinear_startValue_3 = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_13_Get_Refresh( );
            
            logic_uScriptAct_InterpolateFloatLinear_endValue_3 = local_0_System_Single;
            
            logic_uScriptAct_InterpolateFloatLinear_time_3 = local_1_System_Single;
            
         }
         logic_uScriptAct_InterpolateFloatLinear_Driven_3 = logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_3.Driven(out logic_uScriptAct_InterpolateFloatLinear_currentValue_3);
         if ( true == logic_uScriptAct_InterpolateFloatLinear_Driven_3 )
         {
            property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12 = logic_uScriptAct_InterpolateFloatLinear_currentValue_3;
            SyncUnityHooks( );
            property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12_Set_Refresh( );
            if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_3.Interpolating == true )
            {
               Relay_In_7();
            }
            if ( logic_uScriptAct_InterpolateFloatLinear_uScriptAct_InterpolateFloatLinear_3.Finished == true )
            {
               Relay_In_9();
            }
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Interpolate Float Linear.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   void Relay_In_4()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         //param = Prefix
         //param = Target
         //param = Postfix
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_4.In(logic_uScriptAct_Log_Prefix_4, logic_uScriptAct_Log_Target_4, logic_uScriptAct_Log_Postfix_4);
         SyncUnityHooks( );
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_AfterDelay_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         Relay_In_8();
         Relay_Begin_3();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Delay.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         //param = Duration
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_Delay_uScriptAct_Delay_5.In(logic_uScriptAct_Delay_Duration_5);
         SyncUnityHooks( );
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
         //param = KeyCode
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_6.In(logic_uScriptAct_OnInputEventFilter_KeyCode_6);
         SyncUnityHooks( );
         if ( logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_6.KeyDown == true )
         {
            Relay_In_4();
         }
         if ( logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_6.KeyUp == true )
         {
            Relay_In_2();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         //param = Prefix
         //param = Target
         //param = Postfix
         SyncUnityHooks( );
         {
            int index;
            index = 0;
            if ( logic_uScriptAct_Log_Target_7.Length <= index)
            {
               System.Array.Resize(ref logic_uScriptAct_Log_Target_7, index + 1);
            }
            logic_uScriptAct_Log_Target_7[ index++ ] = property_fieldOfView_Detox_ScriptEditor_Parameter_fieldOfView_12_Get_Refresh( );
            
         }
         logic_uScriptAct_Log_uScriptAct_Log_7.In(logic_uScriptAct_Log_Prefix_7, logic_uScriptAct_Log_Target_7, logic_uScriptAct_Log_Postfix_7);
         SyncUnityHooks( );
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
         //param = Prefix
         //param = Target
         //param = Postfix
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_8.In(logic_uScriptAct_Log_Prefix_8, logic_uScriptAct_Log_Target_8, logic_uScriptAct_Log_Postfix_8);
         SyncUnityHooks( );
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
         Relay_In_5();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at uScript Events.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         //param = Prefix
         //param = Target
         //param = Postfix
         SyncUnityHooks( );
         {
         }
         logic_uScriptAct_Log_uScriptAct_Log_9.In(logic_uScriptAct_Log_Prefix_9, logic_uScriptAct_Log_Target_9, logic_uScriptAct_Log_Postfix_9);
         SyncUnityHooks( );
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript uScript_TestBed at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   [Driven]
   public bool Driven_3(  )
   {
      return logic_uScriptAct_InterpolateFloatLinear_Driven_3;
   }
   
}
