//uScript Generated Code - Build 0.9.2215
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class PlaySound_Graph : uScriptLogic
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
   UnityEngine.GameObject local_0_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_0_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_10_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_10_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_6_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_6_UnityEngine_GameObject_previous = null;
   UnityEngine.AudioClip local_Alarm_AudioClip_UnityEngine_AudioClip = null;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_PlaySound logic_uScriptAct_PlaySound_uScriptAct_PlaySound_1 = new uScriptAct_PlaySound( );
   UnityEngine.AudioClip logic_uScriptAct_PlaySound_audioClip_1 = null;
   UnityEngine.GameObject[] logic_uScriptAct_PlaySound_target_1 = new UnityEngine.GameObject[] {};
   System.Single logic_uScriptAct_PlaySound_volume_1 = (float) 1;
   System.Boolean logic_uScriptAct_PlaySound_loop_1 = (bool) true;
   bool logic_uScriptAct_PlaySound_Out_1 = true;
   //pointer to script instanced logic node
   uScriptAct_LoadAudioClip logic_uScriptAct_LoadAudioClip_uScriptAct_LoadAudioClip_2 = new uScriptAct_LoadAudioClip( );
   System.String logic_uScriptAct_LoadAudioClip_name_2 = "alarm";
   UnityEngine.AudioClip logic_uScriptAct_LoadAudioClip_audioClip_2;
   bool logic_uScriptAct_LoadAudioClip_Out_2 = true;
   //pointer to script instanced logic node
   uScriptAct_ToggleComponent logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_9 = new uScriptAct_ToggleComponent( );
   UnityEngine.GameObject[] logic_uScriptAct_ToggleComponent_Target_9 = new UnityEngine.GameObject[] {};
   System.String[] logic_uScriptAct_ToggleComponent_ComponentName_9 = new System.String[] {"Light"};
   bool logic_uScriptAct_ToggleComponent_Out_9 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_13 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_13 = "Mouse over the cube.";
   System.Int32 logic_uScriptAct_PrintText_FontSize_13 = (int) 24;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_13 = UnityEngine.FontStyle.Normal;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_13 = new UnityEngine.Color( (float)1, (float)1, (float)1, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_13 = UnityEngine.TextAnchor.UpperCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_13 = (int) 16;
   System.Single logic_uScriptAct_PrintText_time_13 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_13 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_3 = null;
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      if ( null == local_0_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_0_UnityEngine_GameObject = GameObject.Find( "Cube" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_0_UnityEngine_GameObject_previous != local_0_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_0_UnityEngine_GameObject_previous )
         {
            {
               uScript_Mouse component = local_0_UnityEngine_GameObject_previous.GetComponent<uScript_Mouse>();
               if ( null != component )
               {
                  component.OnEnter -= Instance_OnEnter_7;
                  component.OnOver -= Instance_OnOver_7;
                  component.OnExit -= Instance_OnExit_7;
                  component.OnDown -= Instance_OnDown_7;
                  component.OnUp -= Instance_OnUp_7;
                  component.OnDrag -= Instance_OnDrag_7;
               }
            }
         }
         
         local_0_UnityEngine_GameObject_previous = local_0_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_0_UnityEngine_GameObject )
         {
            {
               uScript_Mouse component = local_0_UnityEngine_GameObject.GetComponent<uScript_Mouse>();
               if ( null == component )
               {
                  component = local_0_UnityEngine_GameObject.AddComponent<uScript_Mouse>();
               }
               if ( null != component )
               {
                  component.OnEnter += Instance_OnEnter_7;
                  component.OnOver += Instance_OnOver_7;
                  component.OnExit += Instance_OnExit_7;
                  component.OnDown += Instance_OnDown_7;
                  component.OnUp += Instance_OnUp_7;
                  component.OnDrag += Instance_OnDrag_7;
               }
            }
         }
      }
      if ( null == local_6_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_6_UnityEngine_GameObject = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_6_UnityEngine_GameObject_previous != local_6_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_10_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_10_UnityEngine_GameObject = GameObject.Find( "Alarm_Light" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_10_UnityEngine_GameObject_previous != local_10_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_10_UnityEngine_GameObject_previous = local_10_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_0_UnityEngine_GameObject_previous != local_0_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != local_0_UnityEngine_GameObject_previous )
         {
            {
               uScript_Mouse component = local_0_UnityEngine_GameObject_previous.GetComponent<uScript_Mouse>();
               if ( null != component )
               {
                  component.OnEnter -= Instance_OnEnter_7;
                  component.OnOver -= Instance_OnOver_7;
                  component.OnExit -= Instance_OnExit_7;
                  component.OnDown -= Instance_OnDown_7;
                  component.OnUp -= Instance_OnUp_7;
                  component.OnDrag -= Instance_OnDrag_7;
               }
            }
         }
         
         local_0_UnityEngine_GameObject_previous = local_0_UnityEngine_GameObject;
         
         //setup new listeners
         if ( null != local_0_UnityEngine_GameObject )
         {
            {
               uScript_Mouse component = local_0_UnityEngine_GameObject.GetComponent<uScript_Mouse>();
               if ( null == component )
               {
                  component = local_0_UnityEngine_GameObject.AddComponent<uScript_Mouse>();
               }
               if ( null != component )
               {
                  component.OnEnter += Instance_OnEnter_7;
                  component.OnOver += Instance_OnOver_7;
                  component.OnExit += Instance_OnExit_7;
                  component.OnDown += Instance_OnDown_7;
                  component.OnUp += Instance_OnUp_7;
                  component.OnDrag += Instance_OnDrag_7;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_6_UnityEngine_GameObject_previous != local_6_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_10_UnityEngine_GameObject_previous != local_10_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_10_UnityEngine_GameObject_previous = local_10_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void SyncEventListeners( )
   {
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
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != local_0_UnityEngine_GameObject )
      {
         {
            uScript_Mouse component = local_0_UnityEngine_GameObject.GetComponent<uScript_Mouse>();
            if ( null != component )
            {
               component.OnEnter -= Instance_OnEnter_7;
               component.OnOver -= Instance_OnOver_7;
               component.OnExit -= Instance_OnExit_7;
               component.OnDown -= Instance_OnDown_7;
               component.OnUp -= Instance_OnUp_7;
               component.OnDrag -= Instance_OnDrag_7;
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
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_1.SetParent(g);
      logic_uScriptAct_LoadAudioClip_uScriptAct_LoadAudioClip_2.SetParent(g);
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_9.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_13.SetParent(g);
   }
   public void Awake()
   {
      
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_1.Finished += uScriptAct_PlaySound_Finished_1;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_9.OnOut += uScriptAct_ToggleComponent_OnOut_9;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_9.OffOut += uScriptAct_ToggleComponent_OffOut_9;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_9.ToggleOut += uScriptAct_ToggleComponent_ToggleOut_9;
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
      
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_1.Update( );
   }
   
   public void OnDestroy()
   {
      logic_uScriptAct_PlaySound_uScriptAct_PlaySound_1.Finished -= uScriptAct_PlaySound_Finished_1;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_9.OnOut -= uScriptAct_ToggleComponent_OnOut_9;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_9.OffOut -= uScriptAct_ToggleComponent_OffOut_9;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_9.ToggleOut -= uScriptAct_ToggleComponent_ToggleOut_9;
   }
   
   public void OnGUI()
   {
      logic_uScriptAct_PrintText_uScriptAct_PrintText_13.OnGUI( );
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
   
   void Instance_OnEnter_7(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnEnter_7( );
   }
   
   void Instance_OnOver_7(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnOver_7( );
   }
   
   void Instance_OnExit_7(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnExit_7( );
   }
   
   void Instance_OnDown_7(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnDown_7( );
   }
   
   void Instance_OnUp_7(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUp_7( );
   }
   
   void Instance_OnDrag_7(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnDrag_7( );
   }
   
   void uScriptAct_PlaySound_Finished_1(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Finished_1( );
   }
   
   void uScriptAct_ToggleComponent_OnOut_9(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnOut_9( );
   }
   
   void uScriptAct_ToggleComponent_OffOut_9(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OffOut_9( );
   }
   
   void uScriptAct_ToggleComponent_ToggleOut_9(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_ToggleOut_9( );
   }
   
   void Relay_Finished_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2b996ed3-8295-4e12-83ad-a6bbc2f0853f", "Play Sound", Relay_Finished_1)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript PlaySound_Graph.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Play_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2b996ed3-8295-4e12-83ad-a6bbc2f0853f", "Play Sound", Relay_Play_1)) return; 
         {
            {
               logic_uScriptAct_PlaySound_audioClip_1 = local_Alarm_AudioClip_UnityEngine_AudioClip;
               
            }
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_6_UnityEngine_GameObject_previous != local_6_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add(local_6_UnityEngine_GameObject);
               logic_uScriptAct_PlaySound_target_1 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_1.Play(logic_uScriptAct_PlaySound_audioClip_1, logic_uScriptAct_PlaySound_target_1, logic_uScriptAct_PlaySound_volume_1, logic_uScriptAct_PlaySound_loop_1);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript PlaySound_Graph.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_UpdateVolume_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2b996ed3-8295-4e12-83ad-a6bbc2f0853f", "Play Sound", Relay_UpdateVolume_1)) return; 
         {
            {
               logic_uScriptAct_PlaySound_audioClip_1 = local_Alarm_AudioClip_UnityEngine_AudioClip;
               
            }
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_6_UnityEngine_GameObject_previous != local_6_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add(local_6_UnityEngine_GameObject);
               logic_uScriptAct_PlaySound_target_1 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_1.UpdateVolume(logic_uScriptAct_PlaySound_audioClip_1, logic_uScriptAct_PlaySound_target_1, logic_uScriptAct_PlaySound_volume_1, logic_uScriptAct_PlaySound_loop_1);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript PlaySound_Graph.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Stop_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2b996ed3-8295-4e12-83ad-a6bbc2f0853f", "Play Sound", Relay_Stop_1)) return; 
         {
            {
               logic_uScriptAct_PlaySound_audioClip_1 = local_Alarm_AudioClip_UnityEngine_AudioClip;
               
            }
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_6_UnityEngine_GameObject_previous != local_6_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_6_UnityEngine_GameObject_previous = local_6_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add(local_6_UnityEngine_GameObject);
               logic_uScriptAct_PlaySound_target_1 = properties.ToArray();
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_PlaySound_uScriptAct_PlaySound_1.Stop(logic_uScriptAct_PlaySound_audioClip_1, logic_uScriptAct_PlaySound_target_1, logic_uScriptAct_PlaySound_volume_1, logic_uScriptAct_PlaySound_loop_1);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript PlaySound_Graph.uscript at Play Sound.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("373c63b4-b58a-41f0-aa1a-59a010257289", "Load AudioClip", Relay_In_2)) return; 
         {
            {
            }
            {
            }
         }
         logic_uScriptAct_LoadAudioClip_uScriptAct_LoadAudioClip_2.In(logic_uScriptAct_LoadAudioClip_name_2, out logic_uScriptAct_LoadAudioClip_audioClip_2);
         local_Alarm_AudioClip_UnityEngine_AudioClip = logic_uScriptAct_LoadAudioClip_audioClip_2;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_LoadAudioClip_uScriptAct_LoadAudioClip_2.Out;
         
         if ( test_0 == true )
         {
            Relay_ShowLabel_13();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript PlaySound_Graph.uscript at Load AudioClip.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_uScriptStart_3()
   {
      if (true == CheckDebugBreak("17728fb2-ec20-48ec-b387-e5482e5912e9", "uScript Events", Relay_uScriptStart_3)) return; 
      Relay_In_2();
   }
   
   void Relay_OnEnter_7()
   {
      if (true == CheckDebugBreak("47310a36-0a8a-4fea-a467-9d4c3959b6ac", "Mouse Cursor Events", Relay_OnEnter_7)) return; 
      Relay_Play_1();
      Relay_TurnOn_9();
   }
   
   void Relay_OnOver_7()
   {
      if (true == CheckDebugBreak("47310a36-0a8a-4fea-a467-9d4c3959b6ac", "Mouse Cursor Events", Relay_OnOver_7)) return; 
   }
   
   void Relay_OnExit_7()
   {
      if (true == CheckDebugBreak("47310a36-0a8a-4fea-a467-9d4c3959b6ac", "Mouse Cursor Events", Relay_OnExit_7)) return; 
      Relay_Stop_1();
      Relay_TurnOff_9();
   }
   
   void Relay_OnDown_7()
   {
      if (true == CheckDebugBreak("47310a36-0a8a-4fea-a467-9d4c3959b6ac", "Mouse Cursor Events", Relay_OnDown_7)) return; 
   }
   
   void Relay_OnUp_7()
   {
      if (true == CheckDebugBreak("47310a36-0a8a-4fea-a467-9d4c3959b6ac", "Mouse Cursor Events", Relay_OnUp_7)) return; 
   }
   
   void Relay_OnDrag_7()
   {
      if (true == CheckDebugBreak("47310a36-0a8a-4fea-a467-9d4c3959b6ac", "Mouse Cursor Events", Relay_OnDrag_7)) return; 
   }
   
   void Relay_OnOut_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1ec0bd06-2122-41c1-b942-0e766e144f6f", "Toggle Component", Relay_OnOut_9)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript PlaySound_Graph.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OffOut_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1ec0bd06-2122-41c1-b942-0e766e144f6f", "Toggle Component", Relay_OffOut_9)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript PlaySound_Graph.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ToggleOut_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1ec0bd06-2122-41c1-b942-0e766e144f6f", "Toggle Component", Relay_ToggleOut_9)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript PlaySound_Graph.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_TurnOn_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1ec0bd06-2122-41c1-b942-0e766e144f6f", "Toggle Component", Relay_TurnOn_9)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_10_UnityEngine_GameObject_previous != local_10_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_10_UnityEngine_GameObject_previous = local_10_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add(local_10_UnityEngine_GameObject);
               logic_uScriptAct_ToggleComponent_Target_9 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_9.TurnOn(logic_uScriptAct_ToggleComponent_Target_9, logic_uScriptAct_ToggleComponent_ComponentName_9);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript PlaySound_Graph.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_TurnOff_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1ec0bd06-2122-41c1-b942-0e766e144f6f", "Toggle Component", Relay_TurnOff_9)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_10_UnityEngine_GameObject_previous != local_10_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_10_UnityEngine_GameObject_previous = local_10_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add(local_10_UnityEngine_GameObject);
               logic_uScriptAct_ToggleComponent_Target_9 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_9.TurnOff(logic_uScriptAct_ToggleComponent_Target_9, logic_uScriptAct_ToggleComponent_ComponentName_9);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript PlaySound_Graph.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Toggle_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1ec0bd06-2122-41c1-b942-0e766e144f6f", "Toggle Component", Relay_Toggle_9)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_10_UnityEngine_GameObject_previous != local_10_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_10_UnityEngine_GameObject_previous = local_10_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add(local_10_UnityEngine_GameObject);
               logic_uScriptAct_ToggleComponent_Target_9 = properties.ToArray();
            }
            {
            }
         }
         logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_9.Toggle(logic_uScriptAct_ToggleComponent_Target_9, logic_uScriptAct_ToggleComponent_ComponentName_9);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript PlaySound_Graph.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_13()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1e9884f2-fc2e-4931-a618-950bc8672b0d", "Print Text", Relay_ShowLabel_13)) return; 
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
            {
            }
         }
         logic_uScriptAct_PrintText_uScriptAct_PrintText_13.ShowLabel(logic_uScriptAct_PrintText_Text_13, logic_uScriptAct_PrintText_FontSize_13, logic_uScriptAct_PrintText_FontStyle_13, logic_uScriptAct_PrintText_FontColor_13, logic_uScriptAct_PrintText_textAnchor_13, logic_uScriptAct_PrintText_EdgePadding_13, logic_uScriptAct_PrintText_time_13);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript PlaySound_Graph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_13()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("1e9884f2-fc2e-4931-a618-950bc8672b0d", "Print Text", Relay_HideLabel_13)) return; 
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
            {
            }
         }
         logic_uScriptAct_PrintText_uScriptAct_PrintText_13.HideLabel(logic_uScriptAct_PrintText_Text_13, logic_uScriptAct_PrintText_FontSize_13, logic_uScriptAct_PrintText_FontStyle_13, logic_uScriptAct_PrintText_FontColor_13, logic_uScriptAct_PrintText_textAnchor_13, logic_uScriptAct_PrintText_EdgePadding_13, logic_uScriptAct_PrintText_time_13);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript PlaySound_Graph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "PlaySound_Graph.uscript:0", local_0_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c088257d-4b68-4914-ad65-c8f2832e0e88", local_0_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "PlaySound_Graph.uscript:Alarm AudioClip", local_Alarm_AudioClip_UnityEngine_AudioClip);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "66b555e2-08a9-414a-a835-66f6107adbae", local_Alarm_AudioClip_UnityEngine_AudioClip);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "PlaySound_Graph.uscript:6", local_6_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "961d6de5-9c3a-4d70-812d-446f19a0a71c", local_6_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "PlaySound_Graph.uscript:10", local_10_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "3a14ab24-b067-41a0-80d2-4e6f7b5205c2", local_10_UnityEngine_GameObject);
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
