//uScript Generated Code - Build 0.9.2275
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class SimpleLogic_Graph : uScriptLogic
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
   UnityEngine.GameObject local_13_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_13_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_14_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_14_UnityEngine_GameObject_previous = null;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_SwitchCameras logic_uScriptAct_SwitchCameras_uScriptAct_SwitchCameras_0 = new uScriptAct_SwitchCameras( );
   UnityEngine.GameObject logic_uScriptAct_SwitchCameras_FromCamera_0 = null;
   UnityEngine.GameObject logic_uScriptAct_SwitchCameras_Target_0 = null;
   System.Boolean logic_uScriptAct_SwitchCameras_EnableAudioListener_0 = (bool) true;
   bool logic_uScriptAct_SwitchCameras_Out_0 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_3 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_3 = UnityEngine.KeyCode.Mouse1;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_3 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_3 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_3 = true;
   //pointer to script instanced logic node
   uScriptAct_SwitchCameras logic_uScriptAct_SwitchCameras_uScriptAct_SwitchCameras_5 = new uScriptAct_SwitchCameras( );
   UnityEngine.GameObject logic_uScriptAct_SwitchCameras_FromCamera_5 = null;
   UnityEngine.GameObject logic_uScriptAct_SwitchCameras_Target_5 = null;
   System.Boolean logic_uScriptAct_SwitchCameras_EnableAudioListener_5 = (bool) true;
   bool logic_uScriptAct_SwitchCameras_Out_5 = true;
   //pointer to script instanced logic node
   uScriptAct_SetColor logic_uScriptAct_SetColor_uScriptAct_SetColor_7 = new uScriptAct_SetColor( );
   UnityEngine.Color logic_uScriptAct_SetColor_Value_7 = new UnityEngine.Color( (float)0.01960784, (float)0.8509804, (float)0.1098039, (float)1 );
   UnityEngine.Color logic_uScriptAct_SetColor_TargetColor_7;
   bool logic_uScriptAct_SetColor_Out_7 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_8 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_8 = "Mouse is over Box1!";
   System.Int32 logic_uScriptAct_PrintText_FontSize_8 = (int) 32;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_8 = UnityEngine.FontStyle.Bold;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_8 = new UnityEngine.Color( (float)1, (float)1, (float)1, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_8 = UnityEngine.TextAnchor.MiddleCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_8 = (int) 32;
   System.Single logic_uScriptAct_PrintText_time_8 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_8 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_9 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_9 = "";
   System.Object[] logic_uScriptAct_Log_Target_9 = new System.Object[] {"uScript fired this log text."};
   System.Object logic_uScriptAct_Log_Postfix_9 = "";
   bool logic_uScriptAct_Log_Out_9 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_10 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_10 = "The boxes collided, so we turned the light green!";
   System.Int32 logic_uScriptAct_PrintText_FontSize_10 = (int) 16;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_10 = UnityEngine.FontStyle.Bold;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_10 = UnityEngine.Color.black;
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_10 = UnityEngine.TextAnchor.UpperCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_10 = (int) 32;
   System.Single logic_uScriptAct_PrintText_time_10 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_10 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_11 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_11 = "Hold Right Mouse Button to switch cameras";
   System.Int32 logic_uScriptAct_PrintText_FontSize_11 = (int) 16;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_11 = UnityEngine.FontStyle.Bold;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_11 = new UnityEngine.Color( (float)0, (float)0, (float)0, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_11 = UnityEngine.TextAnchor.LowerRight;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_11 = (int) 32;
   System.Single logic_uScriptAct_PrintText_time_11 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_11 = true;
   
   //event nodes
   UnityEngine.Vector3 event_UnityEngine_GameObject_RelativeVelocity_2 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Rigidbody event_UnityEngine_GameObject_RigidBody_2 = null;
   UnityEngine.Collider event_UnityEngine_GameObject_Collider_2 = null;
   UnityEngine.Transform event_UnityEngine_GameObject_Transform_2 = null;
   UnityEngine.ContactPoint[] event_UnityEngine_GameObject_Contacts_2 = new UnityEngine.ContactPoint[ 0 ];
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_2 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_2 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_4 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_6 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_15 = null;
   
   //property nodes
   UnityEngine.Color property_color_Detox_ScriptEditor_Parameter_color_1 = UnityEngine.Color.black;
   UnityEngine.GameObject property_color_Detox_ScriptEditor_Parameter_Instance_1 = null;
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   UnityEngine.Color property_color_Detox_ScriptEditor_Parameter_color_1_Get_Refresh( )
   {
      UnityEngine.Light component = property_color_Detox_ScriptEditor_Parameter_Instance_1.GetComponent<UnityEngine.Light>();
      if ( null != component )
      {
         return component.color;
      }
      else
      {
         return UnityEngine.Color.black;
      }
   }
   
   void property_color_Detox_ScriptEditor_Parameter_color_1_Set_Refresh( )
   {
      UnityEngine.Light component = property_color_Detox_ScriptEditor_Parameter_Instance_1.GetComponent<UnityEngine.Light>();
      if ( null != component )
      {
         component.color = property_color_Detox_ScriptEditor_Parameter_color_1;
      }
   }
   
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      if ( null == property_color_Detox_ScriptEditor_Parameter_Instance_1 || false == m_RegisteredForEvents )
      {
         property_color_Detox_ScriptEditor_Parameter_Instance_1 = GameObject.Find( "Directional light" ) as UnityEngine.GameObject;
      }
      if ( null == local_13_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_13_UnityEngine_GameObject = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_13_UnityEngine_GameObject_previous != local_13_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_13_UnityEngine_GameObject_previous = local_13_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_14_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_14_UnityEngine_GameObject = GameObject.Find( "Camera2" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_14_UnityEngine_GameObject_previous != local_14_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_14_UnityEngine_GameObject_previous = local_14_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_13_UnityEngine_GameObject_previous != local_13_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_13_UnityEngine_GameObject_previous = local_13_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_14_UnityEngine_GameObject_previous != local_14_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_14_UnityEngine_GameObject_previous = local_14_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void SyncEventListeners( )
   {
      if ( null == event_UnityEngine_GameObject_Instance_2 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_2 = GameObject.Find( "Box2" ) as UnityEngine.GameObject;
         if ( null != event_UnityEngine_GameObject_Instance_2 )
         {
            {
               uScript_Collision component = event_UnityEngine_GameObject_Instance_2.GetComponent<uScript_Collision>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_2.AddComponent<uScript_Collision>();
               }
               if ( null != component )
               {
                  component.OnEnterCollision += Instance_OnEnterCollision_2;
                  component.OnExitCollision += Instance_OnExitCollision_2;
                  component.WhileInsideCollision += Instance_WhileInsideCollision_2;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_4 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_4 = GameObject.Find( "Box1" ) as UnityEngine.GameObject;
         if ( null != event_UnityEngine_GameObject_Instance_4 )
         {
            {
               uScript_Mouse component = event_UnityEngine_GameObject_Instance_4.GetComponent<uScript_Mouse>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_4.AddComponent<uScript_Mouse>();
               }
               if ( null != component )
               {
                  component.OnEnter += Instance_OnEnter_4;
                  component.OnOver += Instance_OnOver_4;
                  component.OnExit += Instance_OnExit_4;
                  component.OnDown += Instance_OnDown_4;
                  component.OnUp += Instance_OnUp_4;
                  component.OnDrag += Instance_OnDrag_4;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_6 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_6 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_6 )
         {
            {
               uScript_Global component = event_UnityEngine_GameObject_Instance_6.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_6.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_6;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_15 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_15 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_15 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_15.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_15.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_15;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != event_UnityEngine_GameObject_Instance_2 )
      {
         {
            uScript_Collision component = event_UnityEngine_GameObject_Instance_2.GetComponent<uScript_Collision>();
            if ( null != component )
            {
               component.OnEnterCollision -= Instance_OnEnterCollision_2;
               component.OnExitCollision -= Instance_OnExitCollision_2;
               component.WhileInsideCollision -= Instance_WhileInsideCollision_2;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_4 )
      {
         {
            uScript_Mouse component = event_UnityEngine_GameObject_Instance_4.GetComponent<uScript_Mouse>();
            if ( null != component )
            {
               component.OnEnter -= Instance_OnEnter_4;
               component.OnOver -= Instance_OnOver_4;
               component.OnExit -= Instance_OnExit_4;
               component.OnDown -= Instance_OnDown_4;
               component.OnUp -= Instance_OnUp_4;
               component.OnDrag -= Instance_OnDrag_4;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_6 )
      {
         {
            uScript_Global component = event_UnityEngine_GameObject_Instance_6.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_6;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_15 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_15.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_15;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_SwitchCameras_uScriptAct_SwitchCameras_0.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_3.SetParent(g);
      logic_uScriptAct_SwitchCameras_uScriptAct_SwitchCameras_5.SetParent(g);
      logic_uScriptAct_SetColor_uScriptAct_SetColor_7.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_8.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_9.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_10.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_11.SetParent(g);
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
      logic_uScriptAct_PrintText_uScriptAct_PrintText_8.OnGUI( );
      logic_uScriptAct_PrintText_uScriptAct_PrintText_10.OnGUI( );
      logic_uScriptAct_PrintText_uScriptAct_PrintText_11.OnGUI( );
   }
   
   void Instance_OnEnterCollision_2(object o, uScript_Collision.CollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_RelativeVelocity_2 = e.RelativeVelocity;
      event_UnityEngine_GameObject_RigidBody_2 = e.RigidBody;
      event_UnityEngine_GameObject_Collider_2 = e.Collider;
      event_UnityEngine_GameObject_Transform_2 = e.Transform;
      event_UnityEngine_GameObject_Contacts_2 = e.Contacts;
      event_UnityEngine_GameObject_GameObject_2 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterCollision_2( );
   }
   
   void Instance_OnExitCollision_2(object o, uScript_Collision.CollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_RelativeVelocity_2 = e.RelativeVelocity;
      event_UnityEngine_GameObject_RigidBody_2 = e.RigidBody;
      event_UnityEngine_GameObject_Collider_2 = e.Collider;
      event_UnityEngine_GameObject_Transform_2 = e.Transform;
      event_UnityEngine_GameObject_Contacts_2 = e.Contacts;
      event_UnityEngine_GameObject_GameObject_2 = e.GameObject;
      //relay event to nodes
      Relay_OnExitCollision_2( );
   }
   
   void Instance_WhileInsideCollision_2(object o, uScript_Collision.CollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_RelativeVelocity_2 = e.RelativeVelocity;
      event_UnityEngine_GameObject_RigidBody_2 = e.RigidBody;
      event_UnityEngine_GameObject_Collider_2 = e.Collider;
      event_UnityEngine_GameObject_Transform_2 = e.Transform;
      event_UnityEngine_GameObject_Contacts_2 = e.Contacts;
      event_UnityEngine_GameObject_GameObject_2 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideCollision_2( );
   }
   
   void Instance_OnEnter_4(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnEnter_4( );
   }
   
   void Instance_OnOver_4(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnOver_4( );
   }
   
   void Instance_OnExit_4(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnExit_4( );
   }
   
   void Instance_OnDown_4(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnDown_4( );
   }
   
   void Instance_OnUp_4(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUp_4( );
   }
   
   void Instance_OnDrag_4(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnDrag_4( );
   }
   
   void Instance_uScriptStart_6(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_6( );
   }
   
   void Instance_KeyEvent_15(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_15( );
   }
   
   void Relay_In_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("072e5750-c5e9-4f3c-9855-d53d39344a86", "Switch Cameras", Relay_In_0)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_13_UnityEngine_GameObject_previous != local_13_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_13_UnityEngine_GameObject_previous = local_13_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_SwitchCameras_FromCamera_0 = local_13_UnityEngine_GameObject;
               
            }
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_14_UnityEngine_GameObject_previous != local_14_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_14_UnityEngine_GameObject_previous = local_14_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_SwitchCameras_Target_0 = local_14_UnityEngine_GameObject;
               
            }
            {
            }
         }
         logic_uScriptAct_SwitchCameras_uScriptAct_SwitchCameras_0.In(logic_uScriptAct_SwitchCameras_FromCamera_0, logic_uScriptAct_SwitchCameras_Target_0, logic_uScriptAct_SwitchCameras_EnableAudioListener_0);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleLogic_Graph.uscript at Switch Cameras.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnEnterCollision_2()
   {
      if (true == CheckDebugBreak("5362511a-20a4-4005-ad4b-0e7885ef4695", "On Collision", Relay_OnEnterCollision_2)) return; 
      Relay_ShowLabel_10();
      Relay_In_7();
   }
   
   void Relay_OnExitCollision_2()
   {
      if (true == CheckDebugBreak("5362511a-20a4-4005-ad4b-0e7885ef4695", "On Collision", Relay_OnExitCollision_2)) return; 
   }
   
   void Relay_WhileInsideCollision_2()
   {
      if (true == CheckDebugBreak("5362511a-20a4-4005-ad4b-0e7885ef4695", "On Collision", Relay_WhileInsideCollision_2)) return; 
   }
   
   void Relay_In_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c9a4c85f-478b-4474-94e8-76dabc44681f", "Input Events Filter", Relay_In_3)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_3.In(logic_uScriptAct_OnInputEventFilter_KeyCode_3);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_3.KeyDown;
         bool test_1 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_3.KeyUp;
         
         if ( test_0 == true )
         {
            Relay_In_0();
         }
         if ( test_1 == true )
         {
            Relay_In_5();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleLogic_Graph.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnEnter_4()
   {
      if (true == CheckDebugBreak("e81a5b7b-1435-4c4a-837a-4c5d0dee717a", "Mouse Cursor Events", Relay_OnEnter_4)) return; 
   }
   
   void Relay_OnOver_4()
   {
      if (true == CheckDebugBreak("e81a5b7b-1435-4c4a-837a-4c5d0dee717a", "Mouse Cursor Events", Relay_OnOver_4)) return; 
      Relay_ShowLabel_8();
   }
   
   void Relay_OnExit_4()
   {
      if (true == CheckDebugBreak("e81a5b7b-1435-4c4a-837a-4c5d0dee717a", "Mouse Cursor Events", Relay_OnExit_4)) return; 
      Relay_HideLabel_8();
   }
   
   void Relay_OnDown_4()
   {
      if (true == CheckDebugBreak("e81a5b7b-1435-4c4a-837a-4c5d0dee717a", "Mouse Cursor Events", Relay_OnDown_4)) return; 
   }
   
   void Relay_OnUp_4()
   {
      if (true == CheckDebugBreak("e81a5b7b-1435-4c4a-837a-4c5d0dee717a", "Mouse Cursor Events", Relay_OnUp_4)) return; 
   }
   
   void Relay_OnDrag_4()
   {
      if (true == CheckDebugBreak("e81a5b7b-1435-4c4a-837a-4c5d0dee717a", "Mouse Cursor Events", Relay_OnDrag_4)) return; 
   }
   
   void Relay_In_5()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("80fb89e5-e340-49c8-b1f9-33310c220370", "Switch Cameras", Relay_In_5)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_14_UnityEngine_GameObject_previous != local_14_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_14_UnityEngine_GameObject_previous = local_14_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_SwitchCameras_FromCamera_5 = local_14_UnityEngine_GameObject;
               
            }
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_13_UnityEngine_GameObject_previous != local_13_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_13_UnityEngine_GameObject_previous = local_13_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_SwitchCameras_Target_5 = local_13_UnityEngine_GameObject;
               
            }
            {
            }
         }
         logic_uScriptAct_SwitchCameras_uScriptAct_SwitchCameras_5.In(logic_uScriptAct_SwitchCameras_FromCamera_5, logic_uScriptAct_SwitchCameras_Target_5, logic_uScriptAct_SwitchCameras_EnableAudioListener_5);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleLogic_Graph.uscript at Switch Cameras.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_uScriptStart_6()
   {
      if (true == CheckDebugBreak("6a046e38-655f-49eb-9bc8-a69830feddd1", "uScript Events", Relay_uScriptStart_6)) return; 
      Relay_In_9();
      Relay_ShowLabel_11();
   }
   
   void Relay_In_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("54cac139-791c-4225-80b8-3e2c681993a5", "Set Color", Relay_In_7)) return; 
         {
            {
            }
            {
            }
         }
         logic_uScriptAct_SetColor_uScriptAct_SetColor_7.In(logic_uScriptAct_SetColor_Value_7, out logic_uScriptAct_SetColor_TargetColor_7);
         property_color_Detox_ScriptEditor_Parameter_color_1 = logic_uScriptAct_SetColor_TargetColor_7;
         property_color_Detox_ScriptEditor_Parameter_color_1_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleLogic_Graph.uscript at Set Color.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_8()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d38a7f9a-796d-41df-b676-c9605310ff28", "Print Text", Relay_ShowLabel_8)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_8.ShowLabel(logic_uScriptAct_PrintText_Text_8, logic_uScriptAct_PrintText_FontSize_8, logic_uScriptAct_PrintText_FontStyle_8, logic_uScriptAct_PrintText_FontColor_8, logic_uScriptAct_PrintText_textAnchor_8, logic_uScriptAct_PrintText_EdgePadding_8, logic_uScriptAct_PrintText_time_8);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleLogic_Graph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_8()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d38a7f9a-796d-41df-b676-c9605310ff28", "Print Text", Relay_HideLabel_8)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_8.HideLabel(logic_uScriptAct_PrintText_Text_8, logic_uScriptAct_PrintText_FontSize_8, logic_uScriptAct_PrintText_FontStyle_8, logic_uScriptAct_PrintText_FontColor_8, logic_uScriptAct_PrintText_textAnchor_8, logic_uScriptAct_PrintText_EdgePadding_8, logic_uScriptAct_PrintText_time_8);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleLogic_Graph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0165ef15-e126-4920-b64a-d505ddd3d460", "Log", Relay_In_9)) return; 
         {
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_9.In(logic_uScriptAct_Log_Prefix_9, logic_uScriptAct_Log_Target_9, logic_uScriptAct_Log_Postfix_9);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleLogic_Graph.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("41bd28dd-9789-4f5f-a29d-cb156e159362", "Print Text", Relay_ShowLabel_10)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_10.ShowLabel(logic_uScriptAct_PrintText_Text_10, logic_uScriptAct_PrintText_FontSize_10, logic_uScriptAct_PrintText_FontStyle_10, logic_uScriptAct_PrintText_FontColor_10, logic_uScriptAct_PrintText_textAnchor_10, logic_uScriptAct_PrintText_EdgePadding_10, logic_uScriptAct_PrintText_time_10);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleLogic_Graph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("41bd28dd-9789-4f5f-a29d-cb156e159362", "Print Text", Relay_HideLabel_10)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_10.HideLabel(logic_uScriptAct_PrintText_Text_10, logic_uScriptAct_PrintText_FontSize_10, logic_uScriptAct_PrintText_FontStyle_10, logic_uScriptAct_PrintText_FontColor_10, logic_uScriptAct_PrintText_textAnchor_10, logic_uScriptAct_PrintText_EdgePadding_10, logic_uScriptAct_PrintText_time_10);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleLogic_Graph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_11()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9020d966-4b89-4e47-b346-70862f90b4c1", "Print Text", Relay_ShowLabel_11)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_11.ShowLabel(logic_uScriptAct_PrintText_Text_11, logic_uScriptAct_PrintText_FontSize_11, logic_uScriptAct_PrintText_FontStyle_11, logic_uScriptAct_PrintText_FontColor_11, logic_uScriptAct_PrintText_textAnchor_11, logic_uScriptAct_PrintText_EdgePadding_11, logic_uScriptAct_PrintText_time_11);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleLogic_Graph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_11()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9020d966-4b89-4e47-b346-70862f90b4c1", "Print Text", Relay_HideLabel_11)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_11.HideLabel(logic_uScriptAct_PrintText_Text_11, logic_uScriptAct_PrintText_FontSize_11, logic_uScriptAct_PrintText_FontStyle_11, logic_uScriptAct_PrintText_FontColor_11, logic_uScriptAct_PrintText_textAnchor_11, logic_uScriptAct_PrintText_EdgePadding_11, logic_uScriptAct_PrintText_time_11);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleLogic_Graph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_15()
   {
      if (true == CheckDebugBreak("13138bbc-a045-47f3-a720-2ecdcd5fd26e", "Input Events", Relay_KeyEvent_15)) return; 
      Relay_In_3();
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SimpleLogic_Graph.uscript:13", local_13_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "eb19681a-a617-432a-8d2c-76b4d4d3d72a", local_13_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SimpleLogic_Graph.uscript:14", local_14_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "44fdaa97-18a9-4d23-9900-fb519089881d", local_14_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "82093ad5-6f8b-4261-85b5-8f9868bb335d", property_color_Detox_ScriptEditor_Parameter_color_1);
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
