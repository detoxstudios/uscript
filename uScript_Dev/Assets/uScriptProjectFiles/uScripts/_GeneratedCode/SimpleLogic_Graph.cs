//uScript Generated Code - Build 1.0.2740
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
   public UnityEngine.GameObject Box1 = default(UnityEngine.GameObject);
   UnityEngine.GameObject Box1_previous = null;
   public UnityEngine.GameObject Box2 = default(UnityEngine.GameObject);
   UnityEngine.GameObject Box2_previous = null;
   public UnityEngine.GameObject Camera2 = default(UnityEngine.GameObject);
   UnityEngine.GameObject Camera2_previous = null;
   public UnityEngine.GameObject Light = default(UnityEngine.GameObject);
   UnityEngine.GameObject Light_previous = null;
   public UnityEngine.GameObject MainCamera = default(UnityEngine.GameObject);
   UnityEngine.GameObject MainCamera_previous = null;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_SwitchCameras logic_uScriptAct_SwitchCameras_uScriptAct_SwitchCameras_0 = new uScriptAct_SwitchCameras( );
   UnityEngine.GameObject logic_uScriptAct_SwitchCameras_FromCamera_0 = default(UnityEngine.GameObject);
   UnityEngine.GameObject logic_uScriptAct_SwitchCameras_Target_0 = default(UnityEngine.GameObject);
   System.Boolean logic_uScriptAct_SwitchCameras_EnableAudioListener_0 = (bool) true;
   bool logic_uScriptAct_SwitchCameras_Out_0 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_2 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_2 = UnityEngine.KeyCode.Mouse1;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_2 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_2 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_2 = true;
   //pointer to script instanced logic node
   uScriptAct_SwitchCameras logic_uScriptAct_SwitchCameras_uScriptAct_SwitchCameras_4 = new uScriptAct_SwitchCameras( );
   UnityEngine.GameObject logic_uScriptAct_SwitchCameras_FromCamera_4 = default(UnityEngine.GameObject);
   UnityEngine.GameObject logic_uScriptAct_SwitchCameras_Target_4 = default(UnityEngine.GameObject);
   System.Boolean logic_uScriptAct_SwitchCameras_EnableAudioListener_4 = (bool) true;
   bool logic_uScriptAct_SwitchCameras_Out_4 = true;
   //pointer to script instanced logic node
   uScriptAct_SetColor logic_uScriptAct_SetColor_uScriptAct_SetColor_6 = new uScriptAct_SetColor( );
   UnityEngine.Color logic_uScriptAct_SetColor_Value_6 = new UnityEngine.Color( (float)0.01960784, (float)0.8509804, (float)0.1098039, (float)1 );
   UnityEngine.Color logic_uScriptAct_SetColor_TargetColor_6;
   bool logic_uScriptAct_SetColor_Out_6 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_7 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_7 = "Mouse is over Box1!";
   System.Int32 logic_uScriptAct_PrintText_FontSize_7 = (int) 32;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_7 = UnityEngine.FontStyle.Bold;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_7 = new UnityEngine.Color( (float)1, (float)1, (float)1, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_7 = UnityEngine.TextAnchor.MiddleCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_7 = (int) 32;
   System.Single logic_uScriptAct_PrintText_time_7 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_7 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_8 = new uScriptAct_Log( );
   System.Object logic_uScriptAct_Log_Prefix_8 = "";
   System.Object[] logic_uScriptAct_Log_Target_8 = new System.Object[] {"uScript fired this log text."};
   System.Object logic_uScriptAct_Log_Postfix_8 = "";
   bool logic_uScriptAct_Log_Out_8 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_9 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_9 = "The boxes collided, so we turned the light green!";
   System.Int32 logic_uScriptAct_PrintText_FontSize_9 = (int) 16;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_9 = UnityEngine.FontStyle.Bold;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_9 = UnityEngine.Color.black;
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_9 = UnityEngine.TextAnchor.UpperCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_9 = (int) 32;
   System.Single logic_uScriptAct_PrintText_time_9 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_9 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_10 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_10 = "Hold Right Mouse Button to switch cameras";
   System.Int32 logic_uScriptAct_PrintText_FontSize_10 = (int) 16;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_10 = UnityEngine.FontStyle.Bold;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_10 = new UnityEngine.Color( (float)0, (float)0, (float)0, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_10 = UnityEngine.TextAnchor.LowerRight;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_10 = (int) 32;
   System.Single logic_uScriptAct_PrintText_time_10 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_10 = true;
   
   //event nodes
   UnityEngine.Vector3 event_UnityEngine_GameObject_RelativeVelocity_1 = new Vector3( (float)0, (float)0, (float)0 );
   UnityEngine.Rigidbody event_UnityEngine_GameObject_RigidBody_1 = default(UnityEngine.Rigidbody);
   UnityEngine.Collider event_UnityEngine_GameObject_Collider_1 = default(UnityEngine.Collider);
   UnityEngine.Transform event_UnityEngine_GameObject_Transform_1 = default(UnityEngine.Transform);
   UnityEngine.ContactPoint[] event_UnityEngine_GameObject_Contacts_1 = new UnityEngine.ContactPoint[ 0 ];
   UnityEngine.GameObject event_UnityEngine_GameObject_GameObject_1 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_5 = default(UnityEngine.GameObject);
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_14 = default(UnityEngine.GameObject);
   
   //property nodes
   UnityEngine.Color property_color_Detox_ScriptEditor_Parameter_color_33 = UnityEngine.Color.black;
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   UnityEngine.Color property_color_Detox_ScriptEditor_Parameter_color_33_Get_Refresh( )
   {
      UnityEngine.Light component = Light.GetComponent<UnityEngine.Light>();
      if ( null != component )
      {
         return component.color;
      }
      else
      {
         return UnityEngine.Color.black;
      }
   }
   
   void property_color_Detox_ScriptEditor_Parameter_color_33_Set_Refresh( )
   {
      UnityEngine.Light component = Light.GetComponent<UnityEngine.Light>();
      if ( null != component )
      {
         component.color = property_color_Detox_ScriptEditor_Parameter_color_33;
      }
   }
   
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      if ( null == MainCamera || false == m_RegisteredForEvents )
      {
         MainCamera = GameObject.Find( "Main Camera" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( MainCamera_previous != MainCamera || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         MainCamera_previous = MainCamera;
         
         //setup new listeners
      }
      if ( null == Camera2 || false == m_RegisteredForEvents )
      {
         Camera2 = GameObject.Find( "Camera2" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( Camera2_previous != Camera2 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         Camera2_previous = Camera2;
         
         //setup new listeners
      }
      if ( null == Box1 || false == m_RegisteredForEvents )
      {
         Box1 = GameObject.Find( "Box1" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( Box1_previous != Box1 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != Box1_previous )
         {
            {
               uScript_Mouse component = Box1_previous.GetComponent<uScript_Mouse>();
               if ( null != component )
               {
                  component.OnEnter -= Instance_OnEnter_3;
                  component.OnOver -= Instance_OnOver_3;
                  component.OnExit -= Instance_OnExit_3;
                  component.OnDown -= Instance_OnDown_3;
                  component.OnUp -= Instance_OnUp_3;
                  component.OnDrag -= Instance_OnDrag_3;
               }
            }
         }
         
         Box1_previous = Box1;
         
         //setup new listeners
         if ( null != Box1 )
         {
            {
               uScript_Mouse component = Box1.GetComponent<uScript_Mouse>();
               if ( null == component )
               {
                  component = Box1.AddComponent<uScript_Mouse>();
               }
               if ( null != component )
               {
                  component.OnEnter += Instance_OnEnter_3;
                  component.OnOver += Instance_OnOver_3;
                  component.OnExit += Instance_OnExit_3;
                  component.OnDown += Instance_OnDown_3;
                  component.OnUp += Instance_OnUp_3;
                  component.OnDrag += Instance_OnDrag_3;
               }
            }
         }
      }
      if ( null == Box2 || false == m_RegisteredForEvents )
      {
         Box2 = GameObject.Find( "Box2" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( Box2_previous != Box2 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != Box2_previous )
         {
            {
               uScript_Collision component = Box2_previous.GetComponent<uScript_Collision>();
               if ( null != component )
               {
                  component.OnEnterCollision -= Instance_OnEnterCollision_1;
                  component.OnExitCollision -= Instance_OnExitCollision_1;
                  component.WhileInsideCollision -= Instance_WhileInsideCollision_1;
               }
            }
         }
         
         Box2_previous = Box2;
         
         //setup new listeners
         if ( null != Box2 )
         {
            {
               uScript_Collision component = Box2.GetComponent<uScript_Collision>();
               if ( null == component )
               {
                  component = Box2.AddComponent<uScript_Collision>();
               }
               if ( null != component )
               {
                  component.OnEnterCollision += Instance_OnEnterCollision_1;
                  component.OnExitCollision += Instance_OnExitCollision_1;
                  component.WhileInsideCollision += Instance_WhileInsideCollision_1;
               }
            }
         }
      }
      if ( null == Light || false == m_RegisteredForEvents )
      {
         Light = GameObject.Find( "Directional light" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( Light_previous != Light || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         Light_previous = Light;
         
         //setup new listeners
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( MainCamera_previous != MainCamera || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         MainCamera_previous = MainCamera;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( Camera2_previous != Camera2 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         Camera2_previous = Camera2;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( Box1_previous != Box1 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != Box1_previous )
         {
            {
               uScript_Mouse component = Box1_previous.GetComponent<uScript_Mouse>();
               if ( null != component )
               {
                  component.OnEnter -= Instance_OnEnter_3;
                  component.OnOver -= Instance_OnOver_3;
                  component.OnExit -= Instance_OnExit_3;
                  component.OnDown -= Instance_OnDown_3;
                  component.OnUp -= Instance_OnUp_3;
                  component.OnDrag -= Instance_OnDrag_3;
               }
            }
         }
         
         Box1_previous = Box1;
         
         //setup new listeners
         if ( null != Box1 )
         {
            {
               uScript_Mouse component = Box1.GetComponent<uScript_Mouse>();
               if ( null == component )
               {
                  component = Box1.AddComponent<uScript_Mouse>();
               }
               if ( null != component )
               {
                  component.OnEnter += Instance_OnEnter_3;
                  component.OnOver += Instance_OnOver_3;
                  component.OnExit += Instance_OnExit_3;
                  component.OnDown += Instance_OnDown_3;
                  component.OnUp += Instance_OnUp_3;
                  component.OnDrag += Instance_OnDrag_3;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( Box2_previous != Box2 || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         if ( null != Box2_previous )
         {
            {
               uScript_Collision component = Box2_previous.GetComponent<uScript_Collision>();
               if ( null != component )
               {
                  component.OnEnterCollision -= Instance_OnEnterCollision_1;
                  component.OnExitCollision -= Instance_OnExitCollision_1;
                  component.WhileInsideCollision -= Instance_WhileInsideCollision_1;
               }
            }
         }
         
         Box2_previous = Box2;
         
         //setup new listeners
         if ( null != Box2 )
         {
            {
               uScript_Collision component = Box2.GetComponent<uScript_Collision>();
               if ( null == component )
               {
                  component = Box2.AddComponent<uScript_Collision>();
               }
               if ( null != component )
               {
                  component.OnEnterCollision += Instance_OnEnterCollision_1;
                  component.OnExitCollision += Instance_OnExitCollision_1;
                  component.WhileInsideCollision += Instance_WhileInsideCollision_1;
               }
            }
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( Light_previous != Light || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         Light_previous = Light;
         
         //setup new listeners
      }
   }
   
   void SyncEventListeners( )
   {
      if ( null == event_UnityEngine_GameObject_Instance_5 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_5 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_5 )
         {
            {
               uScript_Global component = event_UnityEngine_GameObject_Instance_5.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_5.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_5;
                  component.uScriptLateStart += Instance_uScriptLateStart_5;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_14 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_14 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_14 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_14.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_14.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_14;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != Box1 )
      {
         {
            uScript_Mouse component = Box1.GetComponent<uScript_Mouse>();
            if ( null != component )
            {
               component.OnEnter -= Instance_OnEnter_3;
               component.OnOver -= Instance_OnOver_3;
               component.OnExit -= Instance_OnExit_3;
               component.OnDown -= Instance_OnDown_3;
               component.OnUp -= Instance_OnUp_3;
               component.OnDrag -= Instance_OnDrag_3;
            }
         }
      }
      if ( null != Box2 )
      {
         {
            uScript_Collision component = Box2.GetComponent<uScript_Collision>();
            if ( null != component )
            {
               component.OnEnterCollision -= Instance_OnEnterCollision_1;
               component.OnExitCollision -= Instance_OnExitCollision_1;
               component.WhileInsideCollision -= Instance_WhileInsideCollision_1;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_5 )
      {
         {
            uScript_Global component = event_UnityEngine_GameObject_Instance_5.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_5;
               component.uScriptLateStart -= Instance_uScriptLateStart_5;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_14 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_14.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_14;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_SwitchCameras_uScriptAct_SwitchCameras_0.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_2.SetParent(g);
      logic_uScriptAct_SwitchCameras_uScriptAct_SwitchCameras_4.SetParent(g);
      logic_uScriptAct_SetColor_uScriptAct_SetColor_6.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_7.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_8.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_9.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_10.SetParent(g);
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
      logic_uScriptAct_PrintText_uScriptAct_PrintText_7.OnGUI( );
      logic_uScriptAct_PrintText_uScriptAct_PrintText_9.OnGUI( );
      logic_uScriptAct_PrintText_uScriptAct_PrintText_10.OnGUI( );
   }
   
   void Instance_OnEnterCollision_1(object o, uScript_Collision.CollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_RelativeVelocity_1 = e.RelativeVelocity;
      event_UnityEngine_GameObject_RigidBody_1 = e.RigidBody;
      event_UnityEngine_GameObject_Collider_1 = e.Collider;
      event_UnityEngine_GameObject_Transform_1 = e.Transform;
      event_UnityEngine_GameObject_Contacts_1 = e.Contacts;
      event_UnityEngine_GameObject_GameObject_1 = e.GameObject;
      //relay event to nodes
      Relay_OnEnterCollision_1( );
   }
   
   void Instance_OnExitCollision_1(object o, uScript_Collision.CollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_RelativeVelocity_1 = e.RelativeVelocity;
      event_UnityEngine_GameObject_RigidBody_1 = e.RigidBody;
      event_UnityEngine_GameObject_Collider_1 = e.Collider;
      event_UnityEngine_GameObject_Transform_1 = e.Transform;
      event_UnityEngine_GameObject_Contacts_1 = e.Contacts;
      event_UnityEngine_GameObject_GameObject_1 = e.GameObject;
      //relay event to nodes
      Relay_OnExitCollision_1( );
   }
   
   void Instance_WhileInsideCollision_1(object o, uScript_Collision.CollisionEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_RelativeVelocity_1 = e.RelativeVelocity;
      event_UnityEngine_GameObject_RigidBody_1 = e.RigidBody;
      event_UnityEngine_GameObject_Collider_1 = e.Collider;
      event_UnityEngine_GameObject_Transform_1 = e.Transform;
      event_UnityEngine_GameObject_Contacts_1 = e.Contacts;
      event_UnityEngine_GameObject_GameObject_1 = e.GameObject;
      //relay event to nodes
      Relay_WhileInsideCollision_1( );
   }
   
   void Instance_OnEnter_3(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnEnter_3( );
   }
   
   void Instance_OnOver_3(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnOver_3( );
   }
   
   void Instance_OnExit_3(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnExit_3( );
   }
   
   void Instance_OnDown_3(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnDown_3( );
   }
   
   void Instance_OnUp_3(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUp_3( );
   }
   
   void Instance_OnDrag_3(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnDrag_3( );
   }
   
   void Instance_uScriptStart_5(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_5( );
   }
   
   void Instance_uScriptLateStart_5(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptLateStart_5( );
   }
   
   void Instance_KeyEvent_14(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_14( );
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
                  if ( MainCamera_previous != MainCamera || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     MainCamera_previous = MainCamera;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_SwitchCameras_FromCamera_0 = MainCamera;
               
            }
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( Camera2_previous != Camera2 || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     Camera2_previous = Camera2;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_SwitchCameras_Target_0 = Camera2;
               
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
   
   void Relay_OnEnterCollision_1()
   {
      if (true == CheckDebugBreak("5362511a-20a4-4005-ad4b-0e7885ef4695", "On Collision", Relay_OnEnterCollision_1)) return; 
      Relay_ShowLabel_9();
      Relay_In_6();
   }
   
   void Relay_OnExitCollision_1()
   {
      if (true == CheckDebugBreak("5362511a-20a4-4005-ad4b-0e7885ef4695", "On Collision", Relay_OnExitCollision_1)) return; 
   }
   
   void Relay_WhileInsideCollision_1()
   {
      if (true == CheckDebugBreak("5362511a-20a4-4005-ad4b-0e7885ef4695", "On Collision", Relay_WhileInsideCollision_1)) return; 
   }
   
   void Relay_In_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c9a4c85f-478b-4474-94e8-76dabc44681f", "Input Events Filter", Relay_In_2)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_2.In(logic_uScriptAct_OnInputEventFilter_KeyCode_2);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_2.KeyDown;
         bool test_1 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_2.KeyUp;
         
         if ( test_0 == true )
         {
            Relay_In_0();
         }
         if ( test_1 == true )
         {
            Relay_In_4();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleLogic_Graph.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnEnter_3()
   {
      if (true == CheckDebugBreak("e81a5b7b-1435-4c4a-837a-4c5d0dee717a", "Mouse Cursor Events", Relay_OnEnter_3)) return; 
   }
   
   void Relay_OnOver_3()
   {
      if (true == CheckDebugBreak("e81a5b7b-1435-4c4a-837a-4c5d0dee717a", "Mouse Cursor Events", Relay_OnOver_3)) return; 
      Relay_ShowLabel_7();
   }
   
   void Relay_OnExit_3()
   {
      if (true == CheckDebugBreak("e81a5b7b-1435-4c4a-837a-4c5d0dee717a", "Mouse Cursor Events", Relay_OnExit_3)) return; 
      Relay_HideLabel_7();
   }
   
   void Relay_OnDown_3()
   {
      if (true == CheckDebugBreak("e81a5b7b-1435-4c4a-837a-4c5d0dee717a", "Mouse Cursor Events", Relay_OnDown_3)) return; 
   }
   
   void Relay_OnUp_3()
   {
      if (true == CheckDebugBreak("e81a5b7b-1435-4c4a-837a-4c5d0dee717a", "Mouse Cursor Events", Relay_OnUp_3)) return; 
   }
   
   void Relay_OnDrag_3()
   {
      if (true == CheckDebugBreak("e81a5b7b-1435-4c4a-837a-4c5d0dee717a", "Mouse Cursor Events", Relay_OnDrag_3)) return; 
   }
   
   void Relay_In_4()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("80fb89e5-e340-49c8-b1f9-33310c220370", "Switch Cameras", Relay_In_4)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( Camera2_previous != Camera2 || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     Camera2_previous = Camera2;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_SwitchCameras_FromCamera_4 = Camera2;
               
            }
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( MainCamera_previous != MainCamera || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     MainCamera_previous = MainCamera;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_SwitchCameras_Target_4 = MainCamera;
               
            }
            {
            }
         }
         logic_uScriptAct_SwitchCameras_uScriptAct_SwitchCameras_4.In(logic_uScriptAct_SwitchCameras_FromCamera_4, logic_uScriptAct_SwitchCameras_Target_4, logic_uScriptAct_SwitchCameras_EnableAudioListener_4);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleLogic_Graph.uscript at Switch Cameras.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_uScriptStart_5()
   {
      if (true == CheckDebugBreak("6a046e38-655f-49eb-9bc8-a69830feddd1", "uScript Events", Relay_uScriptStart_5)) return; 
      Relay_In_8();
      Relay_ShowLabel_10();
   }
   
   void Relay_uScriptLateStart_5()
   {
      if (true == CheckDebugBreak("6a046e38-655f-49eb-9bc8-a69830feddd1", "uScript Events", Relay_uScriptLateStart_5)) return; 
   }
   
   void Relay_In_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("54cac139-791c-4225-80b8-3e2c681993a5", "Set Color", Relay_In_6)) return; 
         {
            {
            }
            {
            }
         }
         logic_uScriptAct_SetColor_uScriptAct_SetColor_6.In(logic_uScriptAct_SetColor_Value_6, out logic_uScriptAct_SetColor_TargetColor_6);
         property_color_Detox_ScriptEditor_Parameter_color_33 = logic_uScriptAct_SetColor_TargetColor_6;
         property_color_Detox_ScriptEditor_Parameter_color_33_Set_Refresh( );
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleLogic_Graph.uscript at Set Color.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d38a7f9a-796d-41df-b676-c9605310ff28", "Print Text", Relay_ShowLabel_7)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_7.ShowLabel(logic_uScriptAct_PrintText_Text_7, logic_uScriptAct_PrintText_FontSize_7, logic_uScriptAct_PrintText_FontStyle_7, logic_uScriptAct_PrintText_FontColor_7, logic_uScriptAct_PrintText_textAnchor_7, logic_uScriptAct_PrintText_EdgePadding_7, logic_uScriptAct_PrintText_time_7);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleLogic_Graph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_7()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("d38a7f9a-796d-41df-b676-c9605310ff28", "Print Text", Relay_HideLabel_7)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_7.HideLabel(logic_uScriptAct_PrintText_Text_7, logic_uScriptAct_PrintText_FontSize_7, logic_uScriptAct_PrintText_FontStyle_7, logic_uScriptAct_PrintText_FontColor_7, logic_uScriptAct_PrintText_textAnchor_7, logic_uScriptAct_PrintText_EdgePadding_7, logic_uScriptAct_PrintText_time_7);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleLogic_Graph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_8()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("0165ef15-e126-4920-b64a-d505ddd3d460", "Log", Relay_In_8)) return; 
         {
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_Log_uScriptAct_Log_8.In(logic_uScriptAct_Log_Prefix_8, logic_uScriptAct_Log_Target_8, logic_uScriptAct_Log_Postfix_8);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleLogic_Graph.uscript at Log.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("41bd28dd-9789-4f5f-a29d-cb156e159362", "Print Text", Relay_ShowLabel_9)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_9.ShowLabel(logic_uScriptAct_PrintText_Text_9, logic_uScriptAct_PrintText_FontSize_9, logic_uScriptAct_PrintText_FontStyle_9, logic_uScriptAct_PrintText_FontColor_9, logic_uScriptAct_PrintText_textAnchor_9, logic_uScriptAct_PrintText_EdgePadding_9, logic_uScriptAct_PrintText_time_9);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleLogic_Graph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("41bd28dd-9789-4f5f-a29d-cb156e159362", "Print Text", Relay_HideLabel_9)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_9.HideLabel(logic_uScriptAct_PrintText_Text_9, logic_uScriptAct_PrintText_FontSize_9, logic_uScriptAct_PrintText_FontStyle_9, logic_uScriptAct_PrintText_FontColor_9, logic_uScriptAct_PrintText_textAnchor_9, logic_uScriptAct_PrintText_EdgePadding_9, logic_uScriptAct_PrintText_time_9);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript SimpleLogic_Graph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("9020d966-4b89-4e47-b346-70862f90b4c1", "Print Text", Relay_ShowLabel_10)) return; 
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
         if (true == CheckDebugBreak("9020d966-4b89-4e47-b346-70862f90b4c1", "Print Text", Relay_HideLabel_10)) return; 
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
   
   void Relay_KeyEvent_14()
   {
      if (true == CheckDebugBreak("13138bbc-a045-47f3-a720-2ecdcd5fd26e", "Input Events", Relay_KeyEvent_14)) return; 
      Relay_In_2();
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SimpleLogic_Graph.uscript:MainCamera", MainCamera);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "eb19681a-a617-432a-8d2c-76b4d4d3d72a", MainCamera);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SimpleLogic_Graph.uscript:Camera2", Camera2);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "44fdaa97-18a9-4d23-9900-fb519089881d", Camera2);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SimpleLogic_Graph.uscript:Box1", Box1);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "fa63d3db-795b-4254-a3fb-26f7750f58fe", Box1);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SimpleLogic_Graph.uscript:Box2", Box2);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "1c301b87-c695-4fbd-b5d6-95f9fe24d77a", Box2);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "SimpleLogic_Graph.uscript:Light", Light);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f5bd3fbc-04a4-4a48-9631-2020f79602da", Light);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "dc1e5edb-3e3d-406d-becd-a50409b07502", property_color_Detox_ScriptEditor_Parameter_color_33);
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
