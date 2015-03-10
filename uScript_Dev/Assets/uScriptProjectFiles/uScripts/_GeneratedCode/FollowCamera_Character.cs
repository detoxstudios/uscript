//uScript Generated Code - Build 1.0.2830
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class FollowCamera_Character : uScriptLogic
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
   UnityEngine.GameObject local_16_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_16_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_3_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_3_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_4_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_4_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_5_UnityEngine_GameObject = default(UnityEngine.GameObject);
   UnityEngine.GameObject local_5_UnityEngine_GameObject_previous = null;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   FollowCamera logic_FollowCamera_FollowCamera_0 = new FollowCamera( );
   UnityEngine.GameObject logic_FollowCamera_Follow_Object_0 = default(UnityEngine.GameObject);
   System.Single logic_FollowCamera_Follow_Distance_0 = (float) -7.5;
   System.Single logic_FollowCamera_Follow_Height_0 = (float) 2;
   System.Object logic_FollowCamera_Look_At_Object_0 = "";
   System.Single logic_FollowCamera_Filter_Value_0 = (float) 0.1;
   UnityEngine.GameObject[] logic_FollowCamera_Camera_0 = new UnityEngine.GameObject[] {};
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_8 = UnityEngine.KeyCode.W;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_8 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_8 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_8 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_10 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_10 = UnityEngine.KeyCode.S;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_10 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_10 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_10 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_12 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_12 = UnityEngine.KeyCode.D;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_12 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_12 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_12 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_14 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_14 = UnityEngine.KeyCode.A;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_14 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_14 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_14 = true;
   //pointer to script instanced logic node
   uScriptAct_IsometricCharacterController logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_15 = new uScriptAct_IsometricCharacterController( );
   UnityEngine.GameObject logic_uScriptAct_IsometricCharacterController_target_15 = default(UnityEngine.GameObject);
   System.Single logic_uScriptAct_IsometricCharacterController_translation_15 = (float) 1;
   System.Single logic_uScriptAct_IsometricCharacterController_rotation_15 = (float) 85;
   System.Boolean logic_uScriptAct_IsometricCharacterController_filterTranslation_15 = (bool) false;
   System.Single logic_uScriptAct_IsometricCharacterController_translationFilterConstant_15 = (float) 0.7;
   System.Boolean logic_uScriptAct_IsometricCharacterController_filterRotation_15 = (bool) false;
   System.Single logic_uScriptAct_IsometricCharacterController_rotationFilterConstant_15 = (float) 0.1;
   bool logic_uScriptAct_IsometricCharacterController_Out_15 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_20 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_20 = "Use W, S, A, D to move the cube.";
   System.Int32 logic_uScriptAct_PrintText_FontSize_20 = (int) 16;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_20 = UnityEngine.FontStyle.Normal;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_20 = new UnityEngine.Color( (float)1, (float)1, (float)1, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_20 = UnityEngine.TextAnchor.UpperCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_20 = (int) 32;
   System.Single logic_uScriptAct_PrintText_time_20 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_20 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_1 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_2 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_7 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_9 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_11 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_13 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_19 = default(UnityEngine.GameObject);
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      if ( null == local_3_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_3_UnityEngine_GameObject = GameObject.Find( "Cube" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_3_UnityEngine_GameObject_previous != local_3_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_3_UnityEngine_GameObject_previous = local_3_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_4_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_4_UnityEngine_GameObject = GameObject.Find( "Cube" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_4_UnityEngine_GameObject_previous != local_4_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_4_UnityEngine_GameObject_previous = local_4_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_5_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_5_UnityEngine_GameObject = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_5_UnityEngine_GameObject_previous != local_5_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_5_UnityEngine_GameObject_previous = local_5_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_16_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_16_UnityEngine_GameObject = GameObject.Find( "Cube" ) as UnityEngine.GameObject;
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
      if ( local_3_UnityEngine_GameObject_previous != local_3_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_3_UnityEngine_GameObject_previous = local_3_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_4_UnityEngine_GameObject_previous != local_4_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_4_UnityEngine_GameObject_previous = local_4_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_5_UnityEngine_GameObject_previous != local_5_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_5_UnityEngine_GameObject_previous = local_5_UnityEngine_GameObject;
         
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
      if ( null == event_UnityEngine_GameObject_Instance_1 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_1 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_1 )
         {
            {
               uScript_Global component = event_UnityEngine_GameObject_Instance_1.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_1.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_1;
                  component.uScriptLateStart += Instance_uScriptLateStart_1;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_2 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_2 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_2 )
         {
            {
               uScript_Update component = event_UnityEngine_GameObject_Instance_2.GetComponent<uScript_Update>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_2.AddComponent<uScript_Update>();
               }
               if ( null != component )
               {
                  component.OnUpdate += Instance_OnUpdate_2;
                  component.OnLateUpdate += Instance_OnLateUpdate_2;
                  component.OnFixedUpdate += Instance_OnFixedUpdate_2;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_7 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_7 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_7 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_7.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_7.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_7;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_9 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_9 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_9 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_9.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_9.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_9;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_11 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_11 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_11 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_11.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_11.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_11;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_13 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_13 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_13 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_13.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_13.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_13;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_19 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_19 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_19 )
         {
            {
               uScript_Global component = event_UnityEngine_GameObject_Instance_19.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_19.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_19;
                  component.uScriptLateStart += Instance_uScriptLateStart_19;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != event_UnityEngine_GameObject_Instance_1 )
      {
         {
            uScript_Global component = event_UnityEngine_GameObject_Instance_1.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_1;
               component.uScriptLateStart -= Instance_uScriptLateStart_1;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_2 )
      {
         {
            uScript_Update component = event_UnityEngine_GameObject_Instance_2.GetComponent<uScript_Update>();
            if ( null != component )
            {
               component.OnUpdate -= Instance_OnUpdate_2;
               component.OnLateUpdate -= Instance_OnLateUpdate_2;
               component.OnFixedUpdate -= Instance_OnFixedUpdate_2;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_7 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_7.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_7;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_9 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_9.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_9;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_11 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_11.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_11;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_13 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_13.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_13;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_19 )
      {
         {
            uScript_Global component = event_UnityEngine_GameObject_Instance_19.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_19;
               component.uScriptLateStart -= Instance_uScriptLateStart_19;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_FollowCamera_FollowCamera_0.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_10.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_12.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_14.SetParent(g);
      logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_15.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_20.SetParent(g);
   }
   public void Awake()
   {
      logic_FollowCamera_FollowCamera_0.Awake( );
      
      logic_FollowCamera_FollowCamera_0.Out += FollowCamera_Out_0;
   }
   
   public void Start()
   {
      SyncUnityHooks( );
      m_RegisteredForEvents = true;
      
      logic_FollowCamera_FollowCamera_0.Start( );
   }
   
   public void OnEnable()
   {
      RegisterForUnityHooks( );
      m_RegisteredForEvents = true;
      logic_FollowCamera_FollowCamera_0.OnEnable( );
   }
   
   public void OnDisable()
   {
      logic_FollowCamera_FollowCamera_0.OnDisable( );
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
      
      logic_FollowCamera_FollowCamera_0.Update( );
      logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_15.Update( );
   }
   
   public void OnDestroy()
   {
      logic_FollowCamera_FollowCamera_0.OnDestroy( );
      logic_FollowCamera_FollowCamera_0.Out -= FollowCamera_Out_0;
   }
   
   public void OnGUI()
   {
      logic_uScriptAct_PrintText_uScriptAct_PrintText_20.OnGUI( );
   }
   
   void Instance_uScriptStart_1(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_1( );
   }
   
   void Instance_uScriptLateStart_1(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptLateStart_1( );
   }
   
   void Instance_OnUpdate_2(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUpdate_2( );
   }
   
   void Instance_OnLateUpdate_2(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnLateUpdate_2( );
   }
   
   void Instance_OnFixedUpdate_2(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnFixedUpdate_2( );
   }
   
   void Instance_KeyEvent_7(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_7( );
   }
   
   void Instance_KeyEvent_9(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_9( );
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
   
   void Instance_KeyEvent_13(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_13( );
   }
   
   void Instance_uScriptStart_19(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_19( );
   }
   
   void Instance_uScriptLateStart_19(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptLateStart_19( );
   }
   
   void FollowCamera_Out_0(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_Out_0( );
   }
   
   void Relay_Out_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3972b649-c92d-4401-9f7b-ca0a1ebf63be", "", Relay_Out_0)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera_Character.uscript at FollowCamera.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Reset_Position_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3972b649-c92d-4401-9f7b-ca0a1ebf63be", "", Relay_Reset_Position_0)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_4_UnityEngine_GameObject_previous != local_4_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_4_UnityEngine_GameObject_previous = local_4_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_FollowCamera_Follow_Object_0 = local_4_UnityEngine_GameObject;
               
            }
            {
            }
            {
            }
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_3_UnityEngine_GameObject_previous != local_3_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_3_UnityEngine_GameObject_previous = local_3_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_FollowCamera_Look_At_Object_0 = local_3_UnityEngine_GameObject;
               
            }
            {
            }
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_5_UnityEngine_GameObject_previous != local_5_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_5_UnityEngine_GameObject_previous = local_5_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_5_UnityEngine_GameObject);
               logic_FollowCamera_Camera_0 = properties.ToArray();
            }
         }
         logic_FollowCamera_FollowCamera_0.Reset_Position(logic_FollowCamera_Follow_Object_0, logic_FollowCamera_Follow_Distance_0, logic_FollowCamera_Follow_Height_0, logic_FollowCamera_Look_At_Object_0, logic_FollowCamera_Filter_Value_0, logic_FollowCamera_Camera_0);
         
         //Don't copy 'out' values back to the global variables because this was an auto generated nested node
         //and those values get set through an event which is called before the above method exited
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera_Character.uscript at FollowCamera.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Update_Position_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3972b649-c92d-4401-9f7b-ca0a1ebf63be", "", Relay_Update_Position_0)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_4_UnityEngine_GameObject_previous != local_4_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_4_UnityEngine_GameObject_previous = local_4_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_FollowCamera_Follow_Object_0 = local_4_UnityEngine_GameObject;
               
            }
            {
            }
            {
            }
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_3_UnityEngine_GameObject_previous != local_3_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_3_UnityEngine_GameObject_previous = local_3_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_FollowCamera_Look_At_Object_0 = local_3_UnityEngine_GameObject;
               
            }
            {
            }
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_5_UnityEngine_GameObject_previous != local_5_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_5_UnityEngine_GameObject_previous = local_5_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_5_UnityEngine_GameObject);
               logic_FollowCamera_Camera_0 = properties.ToArray();
            }
         }
         logic_FollowCamera_FollowCamera_0.Update_Position(logic_FollowCamera_Follow_Object_0, logic_FollowCamera_Follow_Distance_0, logic_FollowCamera_Follow_Height_0, logic_FollowCamera_Look_At_Object_0, logic_FollowCamera_Filter_Value_0, logic_FollowCamera_Camera_0);
         
         //Don't copy 'out' values back to the global variables because this was an auto generated nested node
         //and those values get set through an event which is called before the above method exited
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera_Character.uscript at FollowCamera.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_uScriptStart_1()
   {
      if (true == CheckDebugBreak("26ae5e93-5f33-4a74-bd45-1ab60725f4e8", "uScript_Events", Relay_uScriptStart_1)) return; 
      Relay_Reset_Position_0();
   }
   
   void Relay_uScriptLateStart_1()
   {
      if (true == CheckDebugBreak("26ae5e93-5f33-4a74-bd45-1ab60725f4e8", "uScript_Events", Relay_uScriptLateStart_1)) return; 
   }
   
   void Relay_OnUpdate_2()
   {
      if (true == CheckDebugBreak("f6a9f64b-71d9-40a0-9b84-63266c650faf", "Global_Update", Relay_OnUpdate_2)) return; 
      Relay_Update_Position_0();
   }
   
   void Relay_OnLateUpdate_2()
   {
      if (true == CheckDebugBreak("f6a9f64b-71d9-40a0-9b84-63266c650faf", "Global_Update", Relay_OnLateUpdate_2)) return; 
   }
   
   void Relay_OnFixedUpdate_2()
   {
      if (true == CheckDebugBreak("f6a9f64b-71d9-40a0-9b84-63266c650faf", "Global_Update", Relay_OnFixedUpdate_2)) return; 
   }
   
   void Relay_KeyEvent_7()
   {
      if (true == CheckDebugBreak("c468ee21-ba99-4e1d-87eb-88ecb33f633d", "Input_Events", Relay_KeyEvent_7)) return; 
      Relay_In_8();
   }
   
   void Relay_In_8()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("11b7e2f1-cde0-485d-9df8-40436e427287", "Input_Events_Filter", Relay_In_8)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.In(logic_uScriptAct_OnInputEventFilter_KeyCode_8);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_8.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_MoveForward_15();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera_Character.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_9()
   {
      if (true == CheckDebugBreak("47a35231-9605-4e6b-9193-a8eecee80a3e", "Input_Events", Relay_KeyEvent_9)) return; 
      Relay_In_10();
   }
   
   void Relay_In_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d051b1e7-8e98-4b69-b935-4df4680ffec4", "Input_Events_Filter", Relay_In_10)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_10.In(logic_uScriptAct_OnInputEventFilter_KeyCode_10);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_10.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_MoveBackward_15();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera_Character.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_11()
   {
      if (true == CheckDebugBreak("d8fcad54-9952-4abf-bae6-344f592d6dcf", "Input_Events", Relay_KeyEvent_11)) return; 
      Relay_In_12();
   }
   
   void Relay_In_12()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9bef96f6-0953-436f-9c22-4b2cdde7966a", "Input_Events_Filter", Relay_In_12)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_12.In(logic_uScriptAct_OnInputEventFilter_KeyCode_12);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_12.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_RotateRight_15();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera_Character.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_KeyEvent_13()
   {
      if (true == CheckDebugBreak("2ef503df-849b-42c2-bc77-f4f4999b74f9", "Input_Events", Relay_KeyEvent_13)) return; 
      Relay_In_14();
   }
   
   void Relay_In_14()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("52b4a3a5-9026-4821-a7a5-4c8178301e98", "Input_Events_Filter", Relay_In_14)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_14.In(logic_uScriptAct_OnInputEventFilter_KeyCode_14);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_14.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_RotateLeft_15();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera_Character.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_MoveForward_15()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d7cc2d24-c616-4058-9fd2-c053322a8a01", "Isometric_Character_Controller", Relay_MoveForward_15)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_16_UnityEngine_GameObject_previous != local_16_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_16_UnityEngine_GameObject_previous = local_16_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_IsometricCharacterController_target_15 = local_16_UnityEngine_GameObject;
               
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
         logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_15.MoveForward(logic_uScriptAct_IsometricCharacterController_target_15, logic_uScriptAct_IsometricCharacterController_translation_15, logic_uScriptAct_IsometricCharacterController_rotation_15, logic_uScriptAct_IsometricCharacterController_filterTranslation_15, logic_uScriptAct_IsometricCharacterController_translationFilterConstant_15, logic_uScriptAct_IsometricCharacterController_filterRotation_15, logic_uScriptAct_IsometricCharacterController_rotationFilterConstant_15);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera_Character.uscript at Isometric Character Controller.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_MoveBackward_15()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d7cc2d24-c616-4058-9fd2-c053322a8a01", "Isometric_Character_Controller", Relay_MoveBackward_15)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_16_UnityEngine_GameObject_previous != local_16_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_16_UnityEngine_GameObject_previous = local_16_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_IsometricCharacterController_target_15 = local_16_UnityEngine_GameObject;
               
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
         logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_15.MoveBackward(logic_uScriptAct_IsometricCharacterController_target_15, logic_uScriptAct_IsometricCharacterController_translation_15, logic_uScriptAct_IsometricCharacterController_rotation_15, logic_uScriptAct_IsometricCharacterController_filterTranslation_15, logic_uScriptAct_IsometricCharacterController_translationFilterConstant_15, logic_uScriptAct_IsometricCharacterController_filterRotation_15, logic_uScriptAct_IsometricCharacterController_rotationFilterConstant_15);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera_Character.uscript at Isometric Character Controller.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_StrafeRight_15()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d7cc2d24-c616-4058-9fd2-c053322a8a01", "Isometric_Character_Controller", Relay_StrafeRight_15)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_16_UnityEngine_GameObject_previous != local_16_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_16_UnityEngine_GameObject_previous = local_16_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_IsometricCharacterController_target_15 = local_16_UnityEngine_GameObject;
               
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
         logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_15.StrafeRight(logic_uScriptAct_IsometricCharacterController_target_15, logic_uScriptAct_IsometricCharacterController_translation_15, logic_uScriptAct_IsometricCharacterController_rotation_15, logic_uScriptAct_IsometricCharacterController_filterTranslation_15, logic_uScriptAct_IsometricCharacterController_translationFilterConstant_15, logic_uScriptAct_IsometricCharacterController_filterRotation_15, logic_uScriptAct_IsometricCharacterController_rotationFilterConstant_15);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera_Character.uscript at Isometric Character Controller.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_StrafeLeft_15()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d7cc2d24-c616-4058-9fd2-c053322a8a01", "Isometric_Character_Controller", Relay_StrafeLeft_15)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_16_UnityEngine_GameObject_previous != local_16_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_16_UnityEngine_GameObject_previous = local_16_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_IsometricCharacterController_target_15 = local_16_UnityEngine_GameObject;
               
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
         logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_15.StrafeLeft(logic_uScriptAct_IsometricCharacterController_target_15, logic_uScriptAct_IsometricCharacterController_translation_15, logic_uScriptAct_IsometricCharacterController_rotation_15, logic_uScriptAct_IsometricCharacterController_filterTranslation_15, logic_uScriptAct_IsometricCharacterController_translationFilterConstant_15, logic_uScriptAct_IsometricCharacterController_filterRotation_15, logic_uScriptAct_IsometricCharacterController_rotationFilterConstant_15);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera_Character.uscript at Isometric Character Controller.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_RotateRight_15()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d7cc2d24-c616-4058-9fd2-c053322a8a01", "Isometric_Character_Controller", Relay_RotateRight_15)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_16_UnityEngine_GameObject_previous != local_16_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_16_UnityEngine_GameObject_previous = local_16_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_IsometricCharacterController_target_15 = local_16_UnityEngine_GameObject;
               
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
         logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_15.RotateRight(logic_uScriptAct_IsometricCharacterController_target_15, logic_uScriptAct_IsometricCharacterController_translation_15, logic_uScriptAct_IsometricCharacterController_rotation_15, logic_uScriptAct_IsometricCharacterController_filterTranslation_15, logic_uScriptAct_IsometricCharacterController_translationFilterConstant_15, logic_uScriptAct_IsometricCharacterController_filterRotation_15, logic_uScriptAct_IsometricCharacterController_rotationFilterConstant_15);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera_Character.uscript at Isometric Character Controller.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_RotateLeft_15()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d7cc2d24-c616-4058-9fd2-c053322a8a01", "Isometric_Character_Controller", Relay_RotateLeft_15)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_16_UnityEngine_GameObject_previous != local_16_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_16_UnityEngine_GameObject_previous = local_16_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_IsometricCharacterController_target_15 = local_16_UnityEngine_GameObject;
               
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
         logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_15.RotateLeft(logic_uScriptAct_IsometricCharacterController_target_15, logic_uScriptAct_IsometricCharacterController_translation_15, logic_uScriptAct_IsometricCharacterController_rotation_15, logic_uScriptAct_IsometricCharacterController_filterTranslation_15, logic_uScriptAct_IsometricCharacterController_translationFilterConstant_15, logic_uScriptAct_IsometricCharacterController_filterRotation_15, logic_uScriptAct_IsometricCharacterController_rotationFilterConstant_15);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera_Character.uscript at Isometric Character Controller.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_uScriptStart_19()
   {
      if (true == CheckDebugBreak("5dbf8ac4-4186-4d3e-9a64-ad74788ff0eb", "uScript_Events", Relay_uScriptStart_19)) return; 
      Relay_ShowLabel_20();
   }
   
   void Relay_uScriptLateStart_19()
   {
      if (true == CheckDebugBreak("5dbf8ac4-4186-4d3e-9a64-ad74788ff0eb", "uScript_Events", Relay_uScriptLateStart_19)) return; 
   }
   
   void Relay_ShowLabel_20()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7ad19681-8968-40c1-936b-d2fc86832268", "Print_Text", Relay_ShowLabel_20)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_20.ShowLabel(logic_uScriptAct_PrintText_Text_20, logic_uScriptAct_PrintText_FontSize_20, logic_uScriptAct_PrintText_FontStyle_20, logic_uScriptAct_PrintText_FontColor_20, logic_uScriptAct_PrintText_textAnchor_20, logic_uScriptAct_PrintText_EdgePadding_20, logic_uScriptAct_PrintText_time_20);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera_Character.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_20()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("7ad19681-8968-40c1-936b-d2fc86832268", "Print_Text", Relay_HideLabel_20)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_20.HideLabel(logic_uScriptAct_PrintText_Text_20, logic_uScriptAct_PrintText_FontSize_20, logic_uScriptAct_PrintText_FontStyle_20, logic_uScriptAct_PrintText_FontColor_20, logic_uScriptAct_PrintText_textAnchor_20, logic_uScriptAct_PrintText_EdgePadding_20, logic_uScriptAct_PrintText_time_20);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript FollowCamera_Character.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FollowCamera_Character.uscript:3", local_3_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "11d40bf2-3159-43d3-9248-2c7a554c0d6e", local_3_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FollowCamera_Character.uscript:4", local_4_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d86a3316-0810-49d3-a3e1-da7678650167", local_4_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FollowCamera_Character.uscript:5", local_5_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c71c1a2a-f8cb-41d0-a83d-7b8a0a0b5c6d", local_5_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "FollowCamera_Character.uscript:16", local_16_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "354328f1-d2bb-48ac-9e70-30237721f910", local_16_UnityEngine_GameObject);
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
