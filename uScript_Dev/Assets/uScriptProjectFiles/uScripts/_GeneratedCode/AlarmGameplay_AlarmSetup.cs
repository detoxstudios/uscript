//uScript Generated Code - Build 1.0.3008
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("Alarm Setup", "This is the nested node description.")]
public class AlarmGameplay_AlarmSetup : uScriptLogic
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
   [FriendlyName("Out - Alarm Start")]
   public event uScriptEventHandler Out___Alarm_Start;
   [FriendlyName("Out - Alarm Stop")]
   public event uScriptEventHandler Out___Alarm_Stop;
   
   //external parameters
   UnityEngine.AudioClip external_25 = default(UnityEngine.AudioClip);
   System.Boolean external_3 = (bool) false;
   
   //local nodes
   System.Single local_13_System_Single = (float) -360;
   UnityEngine.GameObject local_14_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_14_UnityEngine_GameObject_previous = null;
   System.String local_15_System_String = "Y";
   UnityEngine.GameObject local_16_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_16_UnityEngine_GameObject_previous = null;
   System.String local_18_System_String = "Y";
   System.Boolean local_20_System_Boolean = (bool) true;
   System.Single local_21_System_Single = (float) 360;
   UnityEngine.GameObject local_7_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_7_UnityEngine_GameObject_previous = null;
   System.Boolean local_8_System_Boolean = (bool) true;
   System.String local_9_System_String = "Light";
   System.Single local_Rotate_Speed_System_Single = (float) 1;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_0 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_0 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_0 = true;
   bool logic_uScriptCon_CompareBool_False_0 = true;
   //pointer to script instanced logic node
   uScriptAct_PlayAnimation logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_1 = new uScriptAct_PlayAnimation( );
   UnityEngine.GameObject[] logic_uScriptAct_PlayAnimation_Target_1 = new UnityEngine.GameObject[] {};
   System.String logic_uScriptAct_PlayAnimation_Animation_1 = "ModoAnim";
   System.Single logic_uScriptAct_PlayAnimation_SpeedFactor_1 = (float) 3;
   UnityEngine.WrapMode logic_uScriptAct_PlayAnimation_AnimWrapMode_1 = UnityEngine.WrapMode.Once;
   System.Boolean logic_uScriptAct_PlayAnimation_StopOtherAnimations_1 = (bool) true;
   bool logic_uScriptAct_PlayAnimation_Out_1 = true;
   //pointer to script instanced logic node
   uScriptAct_Rotate logic_uScriptAct_Rotate_uScriptAct_Rotate_2 = new uScriptAct_Rotate( );
   UnityEngine.GameObject[] logic_uScriptAct_Rotate_Target_2 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_Rotate_Degrees_2 = (float) 0;
   System.String logic_uScriptAct_Rotate_Axis_2 = "";
   System.Single logic_uScriptAct_Rotate_Seconds_2 = (float) 0;
   System.Boolean logic_uScriptAct_Rotate_Loop_2 = (bool) false;
   bool logic_uScriptAct_Rotate_Out_2 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareBool logic_uScriptCon_CompareBool_uScriptCon_CompareBool_4 = new uScriptCon_CompareBool( );
   System.Boolean logic_uScriptCon_CompareBool_Bool_4 = (bool) false;
   bool logic_uScriptCon_CompareBool_True_4 = true;
   bool logic_uScriptCon_CompareBool_False_4 = true;
   //pointer to script instanced logic node
   uScriptAct_PlayAnimation logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_5 = new uScriptAct_PlayAnimation( );
   UnityEngine.GameObject[] logic_uScriptAct_PlayAnimation_Target_5 = new UnityEngine.GameObject[] {};
   System.String logic_uScriptAct_PlayAnimation_Animation_5 = "ModoAnim";
   System.Single logic_uScriptAct_PlayAnimation_SpeedFactor_5 = (float) -3;
   UnityEngine.WrapMode logic_uScriptAct_PlayAnimation_AnimWrapMode_5 = UnityEngine.WrapMode.Once;
   System.Boolean logic_uScriptAct_PlayAnimation_StopOtherAnimations_5 = (bool) true;
   bool logic_uScriptAct_PlayAnimation_Out_5 = true;
   //pointer to script instanced logic node
   uScriptAct_ToggleComponent logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_6 = new uScriptAct_ToggleComponent( );
   UnityEngine.GameObject[] logic_uScriptAct_ToggleComponent_Target_6 = new UnityEngine.GameObject[] {};
   System.String[] logic_uScriptAct_ToggleComponent_ComponentName_6 = new System.String[] {};
   bool logic_uScriptAct_ToggleComponent_Out_6 = true;
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_19 = new uScriptAct_PlaySound( );
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_19 = default(UnityEngine.AudioClip);
   UnityEngine.GameObject[] logic_uScriptAct_PlaySound_target_19 = new UnityEngine.GameObject[] {null};
   System.Single logic_uScriptAct_PlaySound_volume_19 = (float) 1;
   System.Boolean logic_uScriptAct_PlaySound_loop_19 = (bool) true;
   bool logic_uScriptAct_PlaySound_Out_19 = true;
   //pointer to script instanced logic node
   uScriptAct_Rotate logic_uScriptAct_Rotate_uScriptAct_Rotate_22 = new uScriptAct_Rotate( );
   UnityEngine.GameObject[] logic_uScriptAct_Rotate_Target_22 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_Rotate_Degrees_22 = (float) 0;
   System.String logic_uScriptAct_Rotate_Axis_22 = "";
   System.Single logic_uScriptAct_Rotate_Seconds_22 = (float) 0;
   System.Boolean logic_uScriptAct_Rotate_Loop_22 = (bool) false;
   bool logic_uScriptAct_Rotate_Out_22 = true;
   
   //event nodes
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   public delegate void uScriptEventHandler(object sender, LogicEventArgs args);
   
   public class LogicEventArgs : System.EventArgs
   {
   }
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      if ( null == logic_uScriptAct_PlaySound_target_19[0] || false == m_RegisteredForEvents )
      {
         logic_uScriptAct_PlaySound_target_19[0] = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
      if ( null == local_7_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_7_UnityEngine_GameObject = GameObject.Find( "Door_Panels" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_7_UnityEngine_GameObject_previous != local_7_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_7_UnityEngine_GameObject_previous = local_7_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_14_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_14_UnityEngine_GameObject = GameObject.Find( "Alarm_Light_Right" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_14_UnityEngine_GameObject_previous != local_14_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_14_UnityEngine_GameObject_previous = local_14_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_16_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_16_UnityEngine_GameObject = GameObject.Find( "Alarm_Light_Left" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_16_UnityEngine_GameObject_previous != local_16_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_16_UnityEngine_GameObject_previous = local_16_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_7_UnityEngine_GameObject_previous != local_7_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_7_UnityEngine_GameObject_previous = local_7_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_14_UnityEngine_GameObject_previous != local_14_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_14_UnityEngine_GameObject_previous = local_14_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_16_UnityEngine_GameObject_previous != local_16_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_16_UnityEngine_GameObject_previous = local_16_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void SyncEventListeners( )
   {
   }
   
   void UnregisterEventListeners( )
   {
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_0.SetParent(g);
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_1.SetParent(g);
      logic_uScriptAct_Rotate_uScriptAct_Rotate_2.SetParent(g);
      logic_uScriptCon_CompareBool_uScriptCon_CompareBool_4.SetParent(g);
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_5.SetParent(g);
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_6.SetParent(g);
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_19.SetParent(g);
      logic_uScriptAct_Rotate_uScriptAct_Rotate_22.SetParent(g);
   }
   public void Awake()
   {
      
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_1.Finished += uScriptAct_PlayAnimation_Finished_1;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_5.Finished += uScriptAct_PlayAnimation_Finished_5;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_6.OnOut += uScriptAct_ToggleComponent_OnOut_6;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_6.OffOut += uScriptAct_ToggleComponent_OffOut_6;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_6.ToggleOut += uScriptAct_ToggleComponent_ToggleOut_6;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_19.Finished += uScriptAct_PlaySound_Finished_19;
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
      
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_1.Update( );
      logic_uScriptAct_Rotate_uScriptAct_Rotate_2.Update( );
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_5.Update( );
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_19.Update( );
      logic_uScriptAct_Rotate_uScriptAct_Rotate_22.Update( );
   }
   
   public void OnDestroy()
   {
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_1.Finished -= uScriptAct_PlayAnimation_Finished_1;
      logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_5.Finished -= uScriptAct_PlayAnimation_Finished_5;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_6.OnOut -= uScriptAct_ToggleComponent_OnOut_6;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_6.OffOut -= uScriptAct_ToggleComponent_OffOut_6;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_6.ToggleOut -= uScriptAct_ToggleComponent_ToggleOut_6;
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_19.Finished -= uScriptAct_PlaySound_Finished_19;
   }
   
   void uScriptAct_PlayAnimation_Finished_1(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_1( );
   }
   
   void uScriptAct_PlayAnimation_Finished_5(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_5( );
   }
   
   void uScriptAct_ToggleComponent_OnOut_6(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnOut_6( );
   }
   
   void uScriptAct_ToggleComponent_OffOut_6(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OffOut_6( );
   }
   
   void uScriptAct_ToggleComponent_ToggleOut_6(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_ToggleOut_6( );
   }
   
   void uScriptAct_PlaySound_Finished_19(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_19( );
   }
   
   [FriendlyName("Alarm Start", "")]
   public void Alarm_Start( [FriendlyName("Alarm Sound", "The sound that will play when the alarm is triggered.")] UnityEngine.AudioClip Alarm_Sound, [FriendlyName("Alarm Hacked?", "Has the alarm been hacked yet?")] System.Boolean Alarm_Hacked_ )
   {
      
      external_25 = Alarm_Sound;
      external_3 = Alarm_Hacked_;
      Relay_In_0( );
   }
   
   [FriendlyName("Alarm Stop", "")]
   public void Alarm_Stop( [FriendlyName("Alarm Sound", "The sound that will play when the alarm is triggered.")] UnityEngine.AudioClip Alarm_Sound, [FriendlyName("Alarm Hacked?", "Has the alarm been hacked yet?")] System.Boolean Alarm_Hacked_ )
   {
      
      external_25 = Alarm_Sound;
      external_3 = Alarm_Hacked_;
      Relay_In_4( );
   }
   
   void Relay_In_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c5b5993f-61dc-4a4e-8685-964aff85ede4", "Compare_Bool", Relay_In_0)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_0 = external_3;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_0.In(logic_uScriptCon_CompareBool_Bool_0);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_0.False;
         
         if ( test_0 == true )
         {
            Relay_TurnOn_6();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a5ca0fd2-64f4-42b7-b54d-061fd8491670", "Play_Animation", Relay_Finished_1)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a5ca0fd2-64f4-42b7-b54d-061fd8491670", "Play_Animation", Relay_In_1)) return; 
         {
            {
               int index = 0;
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_7_UnityEngine_GameObject_previous != local_7_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_7_UnityEngine_GameObject_previous = local_7_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               if ( logic_uScriptAct_PlayAnimation_Target_1.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_PlayAnimation_Target_1, index + 1);
               }
               logic_uScriptAct_PlayAnimation_Target_1[ index++ ] = local_7_UnityEngine_GameObject;
               
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
         logic_uScriptAct_PlayAnimation_uScriptAct_PlayAnimation_1.In(logic_uScriptAct_PlayAnimation_Target_1, logic_uScriptAct_PlayAnimation_Animation_1, logic_uScriptAct_PlayAnimation_SpeedFactor_1, logic_uScriptAct_PlayAnimation_AnimWrapMode_1, logic_uScriptAct_PlayAnimation_StopOtherAnimations_1);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("e633a215-4669-4fa2-a627-80cde87800e6", "Rotate", Relay_In_2)) return; 
         {
            {
               int index = 0;
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_16_UnityEngine_GameObject_previous != local_16_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_16_UnityEngine_GameObject_previous = local_16_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               if ( logic_uScriptAct_Rotate_Target_2.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_Rotate_Target_2, index + 1);
               }
               logic_uScriptAct_Rotate_Target_2[ index++ ] = local_16_UnityEngine_GameObject;
               
            }
            {
               logic_uScriptAct_Rotate_Degrees_2 = local_13_System_Single;
               
            }
            {
               logic_uScriptAct_Rotate_Axis_2 = local_18_System_String;
               
            }
            {
               logic_uScriptAct_Rotate_Seconds_2 = local_Rotate_Speed_System_Single;
               
            }
            {
               logic_uScriptAct_Rotate_Loop_2 = local_8_System_Boolean;
               
            }
         }
         logic_uScriptAct_Rotate_uScriptAct_Rotate_2.In(logic_uScriptAct_Rotate_Target_2, logic_uScriptAct_Rotate_Degrees_2, logic_uScriptAct_Rotate_Axis_2, logic_uScriptAct_Rotate_Seconds_2, logic_uScriptAct_Rotate_Loop_2);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Rotate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Connection_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8538041e-a376-4c26-981a-02ffe7aaa5b9", "", Relay_Connection_3)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Alarm Hacked?.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_4()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("517ad356-bae2-4c37-b274-58e57922d785", "Compare_Bool", Relay_In_4)) return; 
         {
            {
               logic_uScriptCon_CompareBool_Bool_4 = external_3;
               
            }
         }
         logic_uScriptCon_CompareBool_uScriptCon_CompareBool_4.In(logic_uScriptCon_CompareBool_Bool_4);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareBool_uScriptCon_CompareBool_4.False;
         
         if ( test_0 == true )
         {
            Relay_TurnOff_6();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Compare Bool.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1384e518-81de-4435-aca2-127aad5be020", "Play_Animation", Relay_Finished_5)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1384e518-81de-4435-aca2-127aad5be020", "Play_Animation", Relay_In_5)) return; 
         {
            {
               int index = 0;
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_7_UnityEngine_GameObject_previous != local_7_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_7_UnityEngine_GameObject_previous = local_7_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               if ( logic_uScriptAct_PlayAnimation_Target_5.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_PlayAnimation_Target_5, index + 1);
               }
               logic_uScriptAct_PlayAnimation_Target_5[ index++ ] = local_7_UnityEngine_GameObject;
               
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
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Play Animation.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnOut_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3702455b-ec4e-484d-8ad5-44fc608eb815", "Toggle_Component", Relay_OnOut_6)) return; 
         Relay_In_2();
         Relay_Play_19();
         Relay_In_22();
         Relay_Connection_23();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OffOut_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3702455b-ec4e-484d-8ad5-44fc608eb815", "Toggle_Component", Relay_OffOut_6)) return; 
         Relay_In_5();
         Relay_Stop_19();
         Relay_Connection_24();
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ToggleOut_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3702455b-ec4e-484d-8ad5-44fc608eb815", "Toggle_Component", Relay_ToggleOut_6)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_TurnOn_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3702455b-ec4e-484d-8ad5-44fc608eb815", "Toggle_Component", Relay_TurnOn_6)) return; 
         {
            {
               int index = 0;
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_14_UnityEngine_GameObject_previous != local_14_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_14_UnityEngine_GameObject_previous = local_14_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               if ( logic_uScriptAct_ToggleComponent_Target_6.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_ToggleComponent_Target_6, index + 1);
               }
               logic_uScriptAct_ToggleComponent_Target_6[ index++ ] = local_14_UnityEngine_GameObject;
               
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_16_UnityEngine_GameObject_previous != local_16_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_16_UnityEngine_GameObject_previous = local_16_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               if ( logic_uScriptAct_ToggleComponent_Target_6.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_ToggleComponent_Target_6, index + 1);
               }
               logic_uScriptAct_ToggleComponent_Target_6[ index++ ] = local_16_UnityEngine_GameObject;
               
            }
            {
               int index = 0;
               if ( logic_uScriptAct_ToggleComponent_ComponentName_6.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_ToggleComponent_ComponentName_6, index + 1);
               }
               logic_uScriptAct_ToggleComponent_ComponentName_6[ index++ ] = local_9_System_String;
               
            }
         }
         logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_6.TurnOn(logic_uScriptAct_ToggleComponent_Target_6, logic_uScriptAct_ToggleComponent_ComponentName_6);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_TurnOff_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3702455b-ec4e-484d-8ad5-44fc608eb815", "Toggle_Component", Relay_TurnOff_6)) return; 
         {
            {
               int index = 0;
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_14_UnityEngine_GameObject_previous != local_14_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_14_UnityEngine_GameObject_previous = local_14_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               if ( logic_uScriptAct_ToggleComponent_Target_6.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_ToggleComponent_Target_6, index + 1);
               }
               logic_uScriptAct_ToggleComponent_Target_6[ index++ ] = local_14_UnityEngine_GameObject;
               
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_16_UnityEngine_GameObject_previous != local_16_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_16_UnityEngine_GameObject_previous = local_16_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               if ( logic_uScriptAct_ToggleComponent_Target_6.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_ToggleComponent_Target_6, index + 1);
               }
               logic_uScriptAct_ToggleComponent_Target_6[ index++ ] = local_16_UnityEngine_GameObject;
               
            }
            {
               int index = 0;
               if ( logic_uScriptAct_ToggleComponent_ComponentName_6.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_ToggleComponent_ComponentName_6, index + 1);
               }
               logic_uScriptAct_ToggleComponent_ComponentName_6[ index++ ] = local_9_System_String;
               
            }
         }
         logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_6.TurnOff(logic_uScriptAct_ToggleComponent_Target_6, logic_uScriptAct_ToggleComponent_ComponentName_6);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Toggle_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3702455b-ec4e-484d-8ad5-44fc608eb815", "Toggle_Component", Relay_Toggle_6)) return; 
         {
            {
               int index = 0;
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_14_UnityEngine_GameObject_previous != local_14_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_14_UnityEngine_GameObject_previous = local_14_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               if ( logic_uScriptAct_ToggleComponent_Target_6.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_ToggleComponent_Target_6, index + 1);
               }
               logic_uScriptAct_ToggleComponent_Target_6[ index++ ] = local_14_UnityEngine_GameObject;
               
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_16_UnityEngine_GameObject_previous != local_16_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_16_UnityEngine_GameObject_previous = local_16_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               if ( logic_uScriptAct_ToggleComponent_Target_6.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_ToggleComponent_Target_6, index + 1);
               }
               logic_uScriptAct_ToggleComponent_Target_6[ index++ ] = local_16_UnityEngine_GameObject;
               
            }
            {
               int index = 0;
               if ( logic_uScriptAct_ToggleComponent_ComponentName_6.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_ToggleComponent_ComponentName_6, index + 1);
               }
               logic_uScriptAct_ToggleComponent_ComponentName_6[ index++ ] = local_9_System_String;
               
            }
         }
         logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_6.Toggle(logic_uScriptAct_ToggleComponent_Target_6, logic_uScriptAct_ToggleComponent_ComponentName_6);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Connection_11()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c7cdff05-518d-46ad-a4b2-24244157223d", "", Relay_Connection_11)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Alarm Start.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Connection_12()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1e1e3b7d-af56-4fb7-a049-ca317d4f3c69", "", Relay_Connection_12)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Alarm Stop.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Finished_19()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("690b1f93-7ae9-433e-b5b1-437102dc2926", "Play_Sound", Relay_Finished_19)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Play_19()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("690b1f93-7ae9-433e-b5b1-437102dc2926", "Play_Sound", Relay_Play_19)) return; 
         {
            {
               logic_uScriptAct_PlaySound_audioClip_19 = external_25;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_19.Play(logic_uScriptAct_PlaySound_audioClip_19, logic_uScriptAct_PlaySound_target_19, logic_uScriptAct_PlaySound_volume_19, logic_uScriptAct_PlaySound_loop_19);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_UpdateVolume_19()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("690b1f93-7ae9-433e-b5b1-437102dc2926", "Play_Sound", Relay_UpdateVolume_19)) return; 
         {
            {
               logic_uScriptAct_PlaySound_audioClip_19 = external_25;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_19.UpdateVolume(logic_uScriptAct_PlaySound_audioClip_19, logic_uScriptAct_PlaySound_target_19, logic_uScriptAct_PlaySound_volume_19, logic_uScriptAct_PlaySound_loop_19);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_19()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("690b1f93-7ae9-433e-b5b1-437102dc2926", "Play_Sound", Relay_Stop_19)) return; 
         {
            {
               logic_uScriptAct_PlaySound_audioClip_19 = external_25;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_19.Stop(logic_uScriptAct_PlaySound_audioClip_19, logic_uScriptAct_PlaySound_target_19, logic_uScriptAct_PlaySound_volume_19, logic_uScriptAct_PlaySound_loop_19);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_22()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("a663162e-a064-4845-a3ca-e4cad485f234", "Rotate", Relay_In_22)) return; 
         {
            {
               int index = 0;
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_14_UnityEngine_GameObject_previous != local_14_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_14_UnityEngine_GameObject_previous = local_14_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               if ( logic_uScriptAct_Rotate_Target_22.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_Rotate_Target_22, index + 1);
               }
               logic_uScriptAct_Rotate_Target_22[ index++ ] = local_14_UnityEngine_GameObject;
               
            }
            {
               logic_uScriptAct_Rotate_Degrees_22 = local_21_System_Single;
               
            }
            {
               logic_uScriptAct_Rotate_Axis_22 = local_15_System_String;
               
            }
            {
               logic_uScriptAct_Rotate_Seconds_22 = local_Rotate_Speed_System_Single;
               
            }
            {
               logic_uScriptAct_Rotate_Loop_22 = local_20_System_Boolean;
               
            }
         }
         logic_uScriptAct_Rotate_uScriptAct_Rotate_22.In(logic_uScriptAct_Rotate_Target_22, logic_uScriptAct_Rotate_Degrees_22, logic_uScriptAct_Rotate_Axis_22, logic_uScriptAct_Rotate_Seconds_22, logic_uScriptAct_Rotate_Loop_22);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_Rotate_uScriptAct_Rotate_22.Out;
         
         if ( test_0 == true )
         {
            Relay_In_1();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Rotate.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Connection_23()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("532d3a7a-6836-4a06-bd69-26a2e540c780", "", Relay_Connection_23)) return; 
         if ( Out___Alarm_Start != null )
         {
            LogicEventArgs eventArgs = new LogicEventArgs( );
            Out___Alarm_Start( this, eventArgs );
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Out - Alarm Start.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Connection_24()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("216f3670-bc95-4561-8132-9f84f03f3d22", "", Relay_Connection_24)) return; 
         if ( Out___Alarm_Stop != null )
         {
            LogicEventArgs eventArgs = new LogicEventArgs( );
            Out___Alarm_Stop( this, eventArgs );
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Out - Alarm Stop.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Connection_25()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("25e5e426-d83d-4b7a-af51-bfbc33df3ba0", "", Relay_Connection_25)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript AlarmGameplay_AlarmSetup.uscript at Alarm Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AlarmGameplay_AlarmSetup.uscript:7", local_7_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "3d204643-d446-4013-99f7-0b1e05f73773", local_7_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AlarmGameplay_AlarmSetup.uscript:8", local_8_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "38fceca0-0189-4bcb-9071-8dc2ced46de0", local_8_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AlarmGameplay_AlarmSetup.uscript:9", local_9_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "91f22e84-d148-430b-8442-8b0dafcaf67c", local_9_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AlarmGameplay_AlarmSetup.uscript:13", local_13_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "0d8b9f52-6b82-4d42-a056-591b7420822d", local_13_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AlarmGameplay_AlarmSetup.uscript:14", local_14_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d292b09e-cea1-4c43-a168-d7b236052f45", local_14_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AlarmGameplay_AlarmSetup.uscript:15", local_15_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "1c8a7fa7-2fe5-49a6-b53b-bc6fb471c9c8", local_15_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AlarmGameplay_AlarmSetup.uscript:16", local_16_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "8b8ffec6-ec56-48ff-b60c-56959a357718", local_16_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AlarmGameplay_AlarmSetup.uscript:Rotate Speed", local_Rotate_Speed_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "aa4de26f-cf2b-46c7-b877-2a72fc9881db", local_Rotate_Speed_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AlarmGameplay_AlarmSetup.uscript:18", local_18_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "e2d96e2d-6ddf-482d-960f-41c22bcc5ef8", local_18_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AlarmGameplay_AlarmSetup.uscript:20", local_20_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "0ce8d7df-5e3c-4dc0-bff1-fa078805373a", local_20_System_Boolean);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "AlarmGameplay_AlarmSetup.uscript:21", local_21_System_Single);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7858c5ff-6553-4bbf-86be-851878a29f02", local_21_System_Single);
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
