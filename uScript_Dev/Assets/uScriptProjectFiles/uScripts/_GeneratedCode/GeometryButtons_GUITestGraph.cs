//uScript Generated Code - Build 0.9.2275
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class GeometryButtons_GUITestGraph : uScriptLogic
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
   UnityEngine.GameObject local_1_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_1_UnityEngine_GameObject_previous = null;
   UnityEngine.Vector2 local_15_UnityEngine_Vector2 = new Vector2( (float)0, (float)0 );
   UnityEngine.Camera local_16_UnityEngine_Camera = null;
   UnityEngine.GameObject local_19_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_19_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_2_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_2_UnityEngine_GameObject_previous = null;
   System.String local_23_System_String = "Light";
   UnityEngine.GameObject local_4_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_4_UnityEngine_GameObject_previous = null;
   UnityEngine.GameObject local_5_UnityEngine_GameObject = null;
   UnityEngine.GameObject local_5_UnityEngine_GameObject_previous = null;
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_ToggleComponent logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_0 = new uScriptAct_ToggleComponent( );
   UnityEngine.GameObject[] logic_uScriptAct_ToggleComponent_Target_0 = new UnityEngine.GameObject[] {};
   System.String[] logic_uScriptAct_ToggleComponent_ComponentName_0 = new System.String[] {};
   bool logic_uScriptAct_ToggleComponent_Out_0 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareGameObjects logic_uScriptCon_CompareGameObjects_uScriptCon_CompareGameObjects_3 = new uScriptCon_CompareGameObjects( );
   UnityEngine.GameObject logic_uScriptCon_CompareGameObjects_A_3 = null;
   UnityEngine.GameObject logic_uScriptCon_CompareGameObjects_B_3 = null;
   System.Boolean logic_uScriptCon_CompareGameObjects_CompareByTag_3 = (bool) false;
   System.Boolean logic_uScriptCon_CompareGameObjects_CompareByName_3 = (bool) false;
   System.Boolean logic_uScriptCon_CompareGameObjects_ReportNull_3 = (bool) true;
   bool logic_uScriptCon_CompareGameObjects_Same_3 = true;
   bool logic_uScriptCon_CompareGameObjects_Different_3 = true;
   //pointer to script instanced logic node
   uScriptCon_CompareGameObjects logic_uScriptCon_CompareGameObjects_uScriptCon_CompareGameObjects_8 = new uScriptCon_CompareGameObjects( );
   UnityEngine.GameObject logic_uScriptCon_CompareGameObjects_A_8 = null;
   UnityEngine.GameObject logic_uScriptCon_CompareGameObjects_B_8 = null;
   System.Boolean logic_uScriptCon_CompareGameObjects_CompareByTag_8 = (bool) false;
   System.Boolean logic_uScriptCon_CompareGameObjects_CompareByName_8 = (bool) false;
   System.Boolean logic_uScriptCon_CompareGameObjects_ReportNull_8 = (bool) true;
   bool logic_uScriptCon_CompareGameObjects_Same_8 = true;
   bool logic_uScriptCon_CompareGameObjects_Different_8 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_9 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_9 = UnityEngine.KeyCode.DownArrow;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_9 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_9 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_9 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_10 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_10 = UnityEngine.KeyCode.LeftArrow;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_10 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_10 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_10 = true;
   //pointer to script instanced logic node
   uScriptAct_ToggleComponent logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_11 = new uScriptAct_ToggleComponent( );
   UnityEngine.GameObject[] logic_uScriptAct_ToggleComponent_Target_11 = new UnityEngine.GameObject[] {};
   System.String[] logic_uScriptAct_ToggleComponent_ComponentName_11 = new System.String[] {};
   bool logic_uScriptAct_ToggleComponent_Out_11 = true;
   //pointer to script instanced logic node
   uScriptAct_RaycastFromScreenPoint logic_uScriptAct_RaycastFromScreenPoint_uScriptAct_RaycastFromScreenPoint_12 = new uScriptAct_RaycastFromScreenPoint( );
   UnityEngine.Camera logic_uScriptAct_RaycastFromScreenPoint_Camera_12 = null;
   UnityEngine.Vector2 logic_uScriptAct_RaycastFromScreenPoint_ScreenPosition_12 = new Vector2( );
   System.Single logic_uScriptAct_RaycastFromScreenPoint_Distance_12 = (float) 100;
   UnityEngine.LayerMask logic_uScriptAct_RaycastFromScreenPoint_layerMask_12 = 256;
   System.Boolean logic_uScriptAct_RaycastFromScreenPoint_include_12 = (bool) true;
   System.Boolean logic_uScriptAct_RaycastFromScreenPoint_showRay_12 = (bool) false;
   UnityEngine.GameObject logic_uScriptAct_RaycastFromScreenPoint_HitObject_12;
   System.Single logic_uScriptAct_RaycastFromScreenPoint_HitDistance_12;
   UnityEngine.Vector3 logic_uScriptAct_RaycastFromScreenPoint_HitLocation_12;
   UnityEngine.Vector3 logic_uScriptAct_RaycastFromScreenPoint_HitNormal_12;
   bool logic_uScriptAct_RaycastFromScreenPoint_NotObstructed_12 = true;
   bool logic_uScriptAct_RaycastFromScreenPoint_Obstructed_12 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_13 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_13 = UnityEngine.KeyCode.UpArrow;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_13 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_13 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_13 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_17 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_17 = "Press buttons to turn light on (green) and off (red)";
   System.Int32 logic_uScriptAct_PrintText_FontSize_17 = (int) 14;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_17 = UnityEngine.FontStyle.Bold;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_17 = new UnityEngine.Color( (float)1, (float)1, (float)1, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_17 = UnityEngine.TextAnchor.UpperCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_17 = (int) 60;
   System.Single logic_uScriptAct_PrintText_time_17 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_17 = true;
   //pointer to script instanced logic node
   uScriptAct_IsometricCharacterController logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_18 = new uScriptAct_IsometricCharacterController( );
   UnityEngine.GameObject logic_uScriptAct_IsometricCharacterController_target_18 = null;
   System.Single logic_uScriptAct_IsometricCharacterController_translation_18 = (float) 5;
   System.Single logic_uScriptAct_IsometricCharacterController_rotation_18 = (float) 1.5;
   System.Boolean logic_uScriptAct_IsometricCharacterController_filterTranslation_18 = (bool) false;
   System.Single logic_uScriptAct_IsometricCharacterController_translationFilterConstant_18 = (float) 0.7;
   System.Boolean logic_uScriptAct_IsometricCharacterController_filterRotation_18 = (bool) false;
   System.Single logic_uScriptAct_IsometricCharacterController_rotationFilterConstant_18 = (float) 0.1;
   bool logic_uScriptAct_IsometricCharacterController_Out_18 = true;
   //pointer to script instanced logic node
   uScriptAct_OnInputEventFilter logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_22 = new uScriptAct_OnInputEventFilter( );
   UnityEngine.KeyCode logic_uScriptAct_OnInputEventFilter_KeyCode_22 = UnityEngine.KeyCode.RightArrow;
   bool logic_uScriptAct_OnInputEventFilter_KeyDown_22 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyHeld_22 = true;
   bool logic_uScriptAct_OnInputEventFilter_KeyUp_22 = true;
   //pointer to script instanced logic node
   uScriptAct_PrintText logic_uScriptAct_PrintText_uScriptAct_PrintText_24 = new uScriptAct_PrintText( );
   System.String logic_uScriptAct_PrintText_Text_24 = "Use arrow keys to move";
   System.Int32 logic_uScriptAct_PrintText_FontSize_24 = (int) 14;
   UnityEngine.FontStyle logic_uScriptAct_PrintText_FontStyle_24 = UnityEngine.FontStyle.Bold;
   UnityEngine.Color logic_uScriptAct_PrintText_FontColor_24 = new UnityEngine.Color( (float)1, (float)1, (float)1, (float)1 );
   UnityEngine.TextAnchor logic_uScriptAct_PrintText_textAnchor_24 = UnityEngine.TextAnchor.UpperCenter;
   System.Int32 logic_uScriptAct_PrintText_EdgePadding_24 = (int) 32;
   System.Single logic_uScriptAct_PrintText_time_24 = (float) 0;
   bool logic_uScriptAct_PrintText_Out_24 = true;
   
   //event nodes
   System.Int32 event_UnityEngine_GameObject_FingerId_6 = (int) 0;
   UnityEngine.Vector2 event_UnityEngine_GameObject_Position_6 = new Vector2( );
   UnityEngine.Vector2 event_UnityEngine_GameObject_DeltaPosition_6 = new Vector2( (float)0, (float)0 );
   System.Single event_UnityEngine_GameObject_DeltaTime_6 = (float) 0;
   System.Int32 event_UnityEngine_GameObject_TapCount_6 = (int) 0;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_6 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_7 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_14 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_20 = null;
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_21 = null;
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      if ( null == local_1_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_1_UnityEngine_GameObject = GameObject.Find( "Button_LightOn" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_1_UnityEngine_GameObject_previous != local_1_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_1_UnityEngine_GameObject_previous = local_1_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_2_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_2_UnityEngine_GameObject = GameObject.Find( "Button_LightOff" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_2_UnityEngine_GameObject_previous != local_2_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_2_UnityEngine_GameObject_previous = local_2_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_4_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         local_4_UnityEngine_GameObject = GameObject.Find( "MyLight" ) as UnityEngine.GameObject;
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
         local_5_UnityEngine_GameObject = GameObject.Find( "Player" ) as UnityEngine.GameObject;
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_5_UnityEngine_GameObject_previous != local_5_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_5_UnityEngine_GameObject_previous = local_5_UnityEngine_GameObject;
         
         //setup new listeners
      }
      if ( null == local_16_UnityEngine_Camera || false == m_RegisteredForEvents )
      {
         GameObject gameObject = GameObject.Find( "GUI_Camera" );
         if ( null != gameObject )
         {
            local_16_UnityEngine_Camera = gameObject.GetComponent<UnityEngine.Camera>();
         }
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_19_UnityEngine_GameObject_previous != local_19_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_19_UnityEngine_GameObject_previous = local_19_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( local_1_UnityEngine_GameObject_previous != local_1_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_1_UnityEngine_GameObject_previous = local_1_UnityEngine_GameObject;
         
         //setup new listeners
      }
      //if our game object reference was changed then we need to reset event listeners
      if ( local_2_UnityEngine_GameObject_previous != local_2_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_2_UnityEngine_GameObject_previous = local_2_UnityEngine_GameObject;
         
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
      if ( local_19_UnityEngine_GameObject_previous != local_19_UnityEngine_GameObject || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         local_19_UnityEngine_GameObject_previous = local_19_UnityEngine_GameObject;
         
         //setup new listeners
      }
   }
   
   void SyncEventListeners( )
   {
      if ( null == event_UnityEngine_GameObject_Instance_6 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_6 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_6 )
         {
            {
               uScript_Touch component = event_UnityEngine_GameObject_Instance_6.GetComponent<uScript_Touch>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_6.AddComponent<uScript_Touch>();
               }
               if ( null != component )
               {
                  component.OnTouchBegan += Instance_OnTouchBegan_6;
                  component.OnTouchMoved += Instance_OnTouchMoved_6;
                  component.OnTouchStationary += Instance_OnTouchStationary_6;
                  component.OnTouchEnded += Instance_OnTouchEnded_6;
                  component.OnTouchCanceled += Instance_OnTouchCanceled_6;
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
               uScript_Global component = event_UnityEngine_GameObject_Instance_7.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_7.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_7;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_14 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_14 = GameObject.Find( "Button_LightOff" ) as UnityEngine.GameObject;
         if ( null != event_UnityEngine_GameObject_Instance_14 )
         {
            {
               uScript_Mouse component = event_UnityEngine_GameObject_Instance_14.GetComponent<uScript_Mouse>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_14.AddComponent<uScript_Mouse>();
               }
               if ( null != component )
               {
                  component.OnEnter += Instance_OnEnter_14;
                  component.OnOver += Instance_OnOver_14;
                  component.OnExit += Instance_OnExit_14;
                  component.OnDown += Instance_OnDown_14;
                  component.OnUp += Instance_OnUp_14;
                  component.OnDrag += Instance_OnDrag_14;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_20 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_20 = GameObject.Find( "Button_LightOn" ) as UnityEngine.GameObject;
         if ( null != event_UnityEngine_GameObject_Instance_20 )
         {
            {
               uScript_Mouse component = event_UnityEngine_GameObject_Instance_20.GetComponent<uScript_Mouse>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_20.AddComponent<uScript_Mouse>();
               }
               if ( null != component )
               {
                  component.OnEnter += Instance_OnEnter_20;
                  component.OnOver += Instance_OnOver_20;
                  component.OnExit += Instance_OnExit_20;
                  component.OnDown += Instance_OnDown_20;
                  component.OnUp += Instance_OnUp_20;
                  component.OnDrag += Instance_OnDrag_20;
               }
            }
         }
      }
      if ( null == event_UnityEngine_GameObject_Instance_21 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_21 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_21 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_21.GetComponent<uScript_Input>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_21.AddComponent<uScript_Input>();
               }
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_21;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != event_UnityEngine_GameObject_Instance_6 )
      {
         {
            uScript_Touch component = event_UnityEngine_GameObject_Instance_6.GetComponent<uScript_Touch>();
            if ( null != component )
            {
               component.OnTouchBegan -= Instance_OnTouchBegan_6;
               component.OnTouchMoved -= Instance_OnTouchMoved_6;
               component.OnTouchStationary -= Instance_OnTouchStationary_6;
               component.OnTouchEnded -= Instance_OnTouchEnded_6;
               component.OnTouchCanceled -= Instance_OnTouchCanceled_6;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_7 )
      {
         {
            uScript_Global component = event_UnityEngine_GameObject_Instance_7.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_7;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_14 )
      {
         {
            uScript_Mouse component = event_UnityEngine_GameObject_Instance_14.GetComponent<uScript_Mouse>();
            if ( null != component )
            {
               component.OnEnter -= Instance_OnEnter_14;
               component.OnOver -= Instance_OnOver_14;
               component.OnExit -= Instance_OnExit_14;
               component.OnDown -= Instance_OnDown_14;
               component.OnUp -= Instance_OnUp_14;
               component.OnDrag -= Instance_OnDrag_14;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_20 )
      {
         {
            uScript_Mouse component = event_UnityEngine_GameObject_Instance_20.GetComponent<uScript_Mouse>();
            if ( null != component )
            {
               component.OnEnter -= Instance_OnEnter_20;
               component.OnOver -= Instance_OnOver_20;
               component.OnExit -= Instance_OnExit_20;
               component.OnDown -= Instance_OnDown_20;
               component.OnUp -= Instance_OnUp_20;
               component.OnDrag -= Instance_OnDrag_20;
            }
         }
      }
      if ( null != event_UnityEngine_GameObject_Instance_21 )
      {
         {
            uScript_Input component = event_UnityEngine_GameObject_Instance_21.GetComponent<uScript_Input>();
            if ( null != component )
            {
               component.KeyEvent -= Instance_KeyEvent_21;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_0.SetParent(g);
      logic_uScriptCon_CompareGameObjects_uScriptCon_CompareGameObjects_3.SetParent(g);
      logic_uScriptCon_CompareGameObjects_uScriptCon_CompareGameObjects_8.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_9.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_10.SetParent(g);
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_11.SetParent(g);
      logic_uScriptAct_RaycastFromScreenPoint_uScriptAct_RaycastFromScreenPoint_12.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_13.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_17.SetParent(g);
      logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_18.SetParent(g);
      logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_22.SetParent(g);
      logic_uScriptAct_PrintText_uScriptAct_PrintText_24.SetParent(g);
   }
   public void Awake()
   {
      
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_0.OnOut += uScriptAct_ToggleComponent_OnOut_0;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_0.OffOut += uScriptAct_ToggleComponent_OffOut_0;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_0.ToggleOut += uScriptAct_ToggleComponent_ToggleOut_0;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_11.OnOut += uScriptAct_ToggleComponent_OnOut_11;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_11.OffOut += uScriptAct_ToggleComponent_OffOut_11;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_11.ToggleOut += uScriptAct_ToggleComponent_ToggleOut_11;
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
      
      logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_18.Update( );
   }
   
   public void OnDestroy()
   {
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_0.OnOut -= uScriptAct_ToggleComponent_OnOut_0;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_0.OffOut -= uScriptAct_ToggleComponent_OffOut_0;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_0.ToggleOut -= uScriptAct_ToggleComponent_ToggleOut_0;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_11.OnOut -= uScriptAct_ToggleComponent_OnOut_11;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_11.OffOut -= uScriptAct_ToggleComponent_OffOut_11;
      logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_11.ToggleOut -= uScriptAct_ToggleComponent_ToggleOut_11;
   }
   
   public void OnGUI()
   {
      logic_uScriptAct_PrintText_uScriptAct_PrintText_17.OnGUI( );
      logic_uScriptAct_PrintText_uScriptAct_PrintText_24.OnGUI( );
   }
   
   void Instance_OnTouchBegan_6(object o, uScript_Touch.TouchEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_FingerId_6 = e.FingerId;
      event_UnityEngine_GameObject_Position_6 = e.Position;
      event_UnityEngine_GameObject_DeltaPosition_6 = e.DeltaPosition;
      event_UnityEngine_GameObject_DeltaTime_6 = e.DeltaTime;
      event_UnityEngine_GameObject_TapCount_6 = e.TapCount;
      //relay event to nodes
      Relay_OnTouchBegan_6( );
   }
   
   void Instance_OnTouchMoved_6(object o, uScript_Touch.TouchEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_FingerId_6 = e.FingerId;
      event_UnityEngine_GameObject_Position_6 = e.Position;
      event_UnityEngine_GameObject_DeltaPosition_6 = e.DeltaPosition;
      event_UnityEngine_GameObject_DeltaTime_6 = e.DeltaTime;
      event_UnityEngine_GameObject_TapCount_6 = e.TapCount;
      //relay event to nodes
      Relay_OnTouchMoved_6( );
   }
   
   void Instance_OnTouchStationary_6(object o, uScript_Touch.TouchEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_FingerId_6 = e.FingerId;
      event_UnityEngine_GameObject_Position_6 = e.Position;
      event_UnityEngine_GameObject_DeltaPosition_6 = e.DeltaPosition;
      event_UnityEngine_GameObject_DeltaTime_6 = e.DeltaTime;
      event_UnityEngine_GameObject_TapCount_6 = e.TapCount;
      //relay event to nodes
      Relay_OnTouchStationary_6( );
   }
   
   void Instance_OnTouchEnded_6(object o, uScript_Touch.TouchEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_FingerId_6 = e.FingerId;
      event_UnityEngine_GameObject_Position_6 = e.Position;
      event_UnityEngine_GameObject_DeltaPosition_6 = e.DeltaPosition;
      event_UnityEngine_GameObject_DeltaTime_6 = e.DeltaTime;
      event_UnityEngine_GameObject_TapCount_6 = e.TapCount;
      //relay event to nodes
      Relay_OnTouchEnded_6( );
   }
   
   void Instance_OnTouchCanceled_6(object o, uScript_Touch.TouchEventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      event_UnityEngine_GameObject_FingerId_6 = e.FingerId;
      event_UnityEngine_GameObject_Position_6 = e.Position;
      event_UnityEngine_GameObject_DeltaPosition_6 = e.DeltaPosition;
      event_UnityEngine_GameObject_DeltaTime_6 = e.DeltaTime;
      event_UnityEngine_GameObject_TapCount_6 = e.TapCount;
      //relay event to nodes
      Relay_OnTouchCanceled_6( );
   }
   
   void Instance_uScriptStart_7(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_7( );
   }
   
   void Instance_OnEnter_14(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnEnter_14( );
   }
   
   void Instance_OnOver_14(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnOver_14( );
   }
   
   void Instance_OnExit_14(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnExit_14( );
   }
   
   void Instance_OnDown_14(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnDown_14( );
   }
   
   void Instance_OnUp_14(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUp_14( );
   }
   
   void Instance_OnDrag_14(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnDrag_14( );
   }
   
   void Instance_OnEnter_20(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnEnter_20( );
   }
   
   void Instance_OnOver_20(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnOver_20( );
   }
   
   void Instance_OnExit_20(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnExit_20( );
   }
   
   void Instance_OnDown_20(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnDown_20( );
   }
   
   void Instance_OnUp_20(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnUp_20( );
   }
   
   void Instance_OnDrag_20(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_OnDrag_20( );
   }
   
   void Instance_KeyEvent_21(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_21( );
   }
   
   void uScriptAct_ToggleComponent_OnOut_0(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnOut_0( );
   }
   
   void uScriptAct_ToggleComponent_OffOut_0(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OffOut_0( );
   }
   
   void uScriptAct_ToggleComponent_ToggleOut_0(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_ToggleOut_0( );
   }
   
   void uScriptAct_ToggleComponent_OnOut_11(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnOut_11( );
   }
   
   void uScriptAct_ToggleComponent_OffOut_11(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OffOut_11( );
   }
   
   void uScriptAct_ToggleComponent_ToggleOut_11(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_ToggleOut_11( );
   }
   
   void Relay_OnOut_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c36f3a75-465b-4e89-b78f-57cf004e8b38", "Toggle Component", Relay_OnOut_0)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OffOut_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c36f3a75-465b-4e89-b78f-57cf004e8b38", "Toggle Component", Relay_OffOut_0)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ToggleOut_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c36f3a75-465b-4e89-b78f-57cf004e8b38", "Toggle Component", Relay_ToggleOut_0)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_TurnOn_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c36f3a75-465b-4e89-b78f-57cf004e8b38", "Toggle Component", Relay_TurnOn_0)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_4_UnityEngine_GameObject_previous != local_4_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_4_UnityEngine_GameObject_previous = local_4_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_4_UnityEngine_GameObject);
               logic_uScriptAct_ToggleComponent_Target_0 = properties.ToArray();
            }
            {
               List<System.String> properties = new List<System.String>();
               properties.Add((System.String)local_23_System_String);
               logic_uScriptAct_ToggleComponent_ComponentName_0 = properties.ToArray();
            }
         }
         logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_0.TurnOn(logic_uScriptAct_ToggleComponent_Target_0, logic_uScriptAct_ToggleComponent_ComponentName_0);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_TurnOff_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c36f3a75-465b-4e89-b78f-57cf004e8b38", "Toggle Component", Relay_TurnOff_0)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_4_UnityEngine_GameObject_previous != local_4_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_4_UnityEngine_GameObject_previous = local_4_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_4_UnityEngine_GameObject);
               logic_uScriptAct_ToggleComponent_Target_0 = properties.ToArray();
            }
            {
               List<System.String> properties = new List<System.String>();
               properties.Add((System.String)local_23_System_String);
               logic_uScriptAct_ToggleComponent_ComponentName_0 = properties.ToArray();
            }
         }
         logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_0.TurnOff(logic_uScriptAct_ToggleComponent_Target_0, logic_uScriptAct_ToggleComponent_ComponentName_0);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Toggle_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c36f3a75-465b-4e89-b78f-57cf004e8b38", "Toggle Component", Relay_Toggle_0)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_4_UnityEngine_GameObject_previous != local_4_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_4_UnityEngine_GameObject_previous = local_4_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_4_UnityEngine_GameObject);
               logic_uScriptAct_ToggleComponent_Target_0 = properties.ToArray();
            }
            {
               List<System.String> properties = new List<System.String>();
               properties.Add((System.String)local_23_System_String);
               logic_uScriptAct_ToggleComponent_ComponentName_0 = properties.ToArray();
            }
         }
         logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_0.Toggle(logic_uScriptAct_ToggleComponent_Target_0, logic_uScriptAct_ToggleComponent_ComponentName_0);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_3()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("8afbaaca-cd6b-4fa6-abdd-d5407d4eb0e7", "Compare GameObjects", Relay_In_3)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_19_UnityEngine_GameObject_previous != local_19_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_19_UnityEngine_GameObject_previous = local_19_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptCon_CompareGameObjects_A_3 = local_19_UnityEngine_GameObject;
               
            }
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_2_UnityEngine_GameObject_previous != local_2_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_2_UnityEngine_GameObject_previous = local_2_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptCon_CompareGameObjects_B_3 = local_2_UnityEngine_GameObject;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptCon_CompareGameObjects_uScriptCon_CompareGameObjects_3.In(logic_uScriptCon_CompareGameObjects_A_3, logic_uScriptCon_CompareGameObjects_B_3, logic_uScriptCon_CompareGameObjects_CompareByTag_3, logic_uScriptCon_CompareGameObjects_CompareByName_3, logic_uScriptCon_CompareGameObjects_ReportNull_3);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareGameObjects_uScriptCon_CompareGameObjects_3.Same;
         
         if ( test_0 == true )
         {
            Relay_TurnOff_11();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Compare GameObjects.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnTouchBegan_6()
   {
      if (true == CheckDebugBreak("9d4bf783-b062-4a6d-8626-02af71e1be1a", "Touch Events", Relay_OnTouchBegan_6)) return; 
      local_15_UnityEngine_Vector2 = event_UnityEngine_GameObject_Position_6;
      Relay_In_12();
   }
   
   void Relay_OnTouchMoved_6()
   {
      if (true == CheckDebugBreak("9d4bf783-b062-4a6d-8626-02af71e1be1a", "Touch Events", Relay_OnTouchMoved_6)) return; 
      local_15_UnityEngine_Vector2 = event_UnityEngine_GameObject_Position_6;
   }
   
   void Relay_OnTouchStationary_6()
   {
      if (true == CheckDebugBreak("9d4bf783-b062-4a6d-8626-02af71e1be1a", "Touch Events", Relay_OnTouchStationary_6)) return; 
      local_15_UnityEngine_Vector2 = event_UnityEngine_GameObject_Position_6;
   }
   
   void Relay_OnTouchEnded_6()
   {
      if (true == CheckDebugBreak("9d4bf783-b062-4a6d-8626-02af71e1be1a", "Touch Events", Relay_OnTouchEnded_6)) return; 
      local_15_UnityEngine_Vector2 = event_UnityEngine_GameObject_Position_6;
   }
   
   void Relay_OnTouchCanceled_6()
   {
      if (true == CheckDebugBreak("9d4bf783-b062-4a6d-8626-02af71e1be1a", "Touch Events", Relay_OnTouchCanceled_6)) return; 
      local_15_UnityEngine_Vector2 = event_UnityEngine_GameObject_Position_6;
   }
   
   void Relay_uScriptStart_7()
   {
      if (true == CheckDebugBreak("2360ec9c-0bba-489d-ac62-d94fe3fa47ca", "uScript Events", Relay_uScriptStart_7)) return; 
      Relay_ShowLabel_24();
   }
   
   void Relay_In_8()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("bf77f9e7-de77-4624-bef5-888ce401d346", "Compare GameObjects", Relay_In_8)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_19_UnityEngine_GameObject_previous != local_19_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_19_UnityEngine_GameObject_previous = local_19_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptCon_CompareGameObjects_A_8 = local_19_UnityEngine_GameObject;
               
            }
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_1_UnityEngine_GameObject_previous != local_1_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_1_UnityEngine_GameObject_previous = local_1_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptCon_CompareGameObjects_B_8 = local_1_UnityEngine_GameObject;
               
            }
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptCon_CompareGameObjects_uScriptCon_CompareGameObjects_8.In(logic_uScriptCon_CompareGameObjects_A_8, logic_uScriptCon_CompareGameObjects_B_8, logic_uScriptCon_CompareGameObjects_CompareByTag_8, logic_uScriptCon_CompareGameObjects_CompareByName_8, logic_uScriptCon_CompareGameObjects_ReportNull_8);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptCon_CompareGameObjects_uScriptCon_CompareGameObjects_8.Same;
         
         if ( test_0 == true )
         {
            Relay_TurnOn_0();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Compare GameObjects.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_9()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c34be803-5ce5-4a0d-aa94-bc32dda6d6d8", "Input Events Filter", Relay_In_9)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_9.In(logic_uScriptAct_OnInputEventFilter_KeyCode_9);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_9.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_MoveBackward_18();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_10()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("b638b2e1-a308-43ee-ac2b-07d0589dc6ec", "Input Events Filter", Relay_In_10)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_10.In(logic_uScriptAct_OnInputEventFilter_KeyCode_10);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_10.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_RotateLeft_18();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnOut_11()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("28297236-f9c6-43b2-8704-8e3068b5e644", "Toggle Component", Relay_OnOut_11)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OffOut_11()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("28297236-f9c6-43b2-8704-8e3068b5e644", "Toggle Component", Relay_OffOut_11)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ToggleOut_11()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("28297236-f9c6-43b2-8704-8e3068b5e644", "Toggle Component", Relay_ToggleOut_11)) return; 
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_TurnOn_11()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("28297236-f9c6-43b2-8704-8e3068b5e644", "Toggle Component", Relay_TurnOn_11)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_4_UnityEngine_GameObject_previous != local_4_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_4_UnityEngine_GameObject_previous = local_4_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_4_UnityEngine_GameObject);
               logic_uScriptAct_ToggleComponent_Target_11 = properties.ToArray();
            }
            {
               List<System.String> properties = new List<System.String>();
               properties.Add((System.String)local_23_System_String);
               logic_uScriptAct_ToggleComponent_ComponentName_11 = properties.ToArray();
            }
         }
         logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_11.TurnOn(logic_uScriptAct_ToggleComponent_Target_11, logic_uScriptAct_ToggleComponent_ComponentName_11);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_TurnOff_11()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("28297236-f9c6-43b2-8704-8e3068b5e644", "Toggle Component", Relay_TurnOff_11)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_4_UnityEngine_GameObject_previous != local_4_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_4_UnityEngine_GameObject_previous = local_4_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_4_UnityEngine_GameObject);
               logic_uScriptAct_ToggleComponent_Target_11 = properties.ToArray();
            }
            {
               List<System.String> properties = new List<System.String>();
               properties.Add((System.String)local_23_System_String);
               logic_uScriptAct_ToggleComponent_ComponentName_11 = properties.ToArray();
            }
         }
         logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_11.TurnOff(logic_uScriptAct_ToggleComponent_Target_11, logic_uScriptAct_ToggleComponent_ComponentName_11);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_Toggle_11()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("28297236-f9c6-43b2-8704-8e3068b5e644", "Toggle Component", Relay_Toggle_11)) return; 
         {
            {
               List<UnityEngine.GameObject> properties = new List<UnityEngine.GameObject>();
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_4_UnityEngine_GameObject_previous != local_4_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_4_UnityEngine_GameObject_previous = local_4_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               properties.Add((UnityEngine.GameObject)local_4_UnityEngine_GameObject);
               logic_uScriptAct_ToggleComponent_Target_11 = properties.ToArray();
            }
            {
               List<System.String> properties = new List<System.String>();
               properties.Add((System.String)local_23_System_String);
               logic_uScriptAct_ToggleComponent_ComponentName_11 = properties.ToArray();
            }
         }
         logic_uScriptAct_ToggleComponent_uScriptAct_ToggleComponent_11.Toggle(logic_uScriptAct_ToggleComponent_Target_11, logic_uScriptAct_ToggleComponent_ComponentName_11);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Toggle Component.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_12()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("2176e13f-d5b3-445c-9e10-9f00629b135d", "Raycast From Screen Point", Relay_In_12)) return; 
         {
            {
               logic_uScriptAct_RaycastFromScreenPoint_Camera_12 = local_16_UnityEngine_Camera;
               
            }
            {
               logic_uScriptAct_RaycastFromScreenPoint_ScreenPosition_12 = local_15_UnityEngine_Vector2;
               
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
            {
            }
            {
            }
         }
         logic_uScriptAct_RaycastFromScreenPoint_uScriptAct_RaycastFromScreenPoint_12.In(logic_uScriptAct_RaycastFromScreenPoint_Camera_12, logic_uScriptAct_RaycastFromScreenPoint_ScreenPosition_12, logic_uScriptAct_RaycastFromScreenPoint_Distance_12, logic_uScriptAct_RaycastFromScreenPoint_layerMask_12, logic_uScriptAct_RaycastFromScreenPoint_include_12, logic_uScriptAct_RaycastFromScreenPoint_showRay_12, out logic_uScriptAct_RaycastFromScreenPoint_HitObject_12, out logic_uScriptAct_RaycastFromScreenPoint_HitDistance_12, out logic_uScriptAct_RaycastFromScreenPoint_HitLocation_12, out logic_uScriptAct_RaycastFromScreenPoint_HitNormal_12);
         local_19_UnityEngine_GameObject = logic_uScriptAct_RaycastFromScreenPoint_HitObject_12;
         {
            //if our game object reference was changed then we need to reset event listeners
            if ( local_19_UnityEngine_GameObject_previous != local_19_UnityEngine_GameObject || false == m_RegisteredForEvents )
            {
               //tear down old listeners
               
               local_19_UnityEngine_GameObject_previous = local_19_UnityEngine_GameObject;
               
               //setup new listeners
            }
         }
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_RaycastFromScreenPoint_uScriptAct_RaycastFromScreenPoint_12.Obstructed;
         
         if ( test_0 == true )
         {
            Relay_In_3();
            Relay_In_8();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Raycast From Screen Point.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_13()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("800fe30b-fb17-4a94-8a2d-5f88d0e7afdf", "Input Events Filter", Relay_In_13)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_13.In(logic_uScriptAct_OnInputEventFilter_KeyCode_13);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_13.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_MoveForward_18();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnEnter_14()
   {
      if (true == CheckDebugBreak("b5cbeb20-cd76-4625-8881-cb1379b44551", "Mouse Cursor Events", Relay_OnEnter_14)) return; 
   }
   
   void Relay_OnOver_14()
   {
      if (true == CheckDebugBreak("b5cbeb20-cd76-4625-8881-cb1379b44551", "Mouse Cursor Events", Relay_OnOver_14)) return; 
   }
   
   void Relay_OnExit_14()
   {
      if (true == CheckDebugBreak("b5cbeb20-cd76-4625-8881-cb1379b44551", "Mouse Cursor Events", Relay_OnExit_14)) return; 
   }
   
   void Relay_OnDown_14()
   {
      if (true == CheckDebugBreak("b5cbeb20-cd76-4625-8881-cb1379b44551", "Mouse Cursor Events", Relay_OnDown_14)) return; 
   }
   
   void Relay_OnUp_14()
   {
      if (true == CheckDebugBreak("b5cbeb20-cd76-4625-8881-cb1379b44551", "Mouse Cursor Events", Relay_OnUp_14)) return; 
      Relay_TurnOff_11();
   }
   
   void Relay_OnDrag_14()
   {
      if (true == CheckDebugBreak("b5cbeb20-cd76-4625-8881-cb1379b44551", "Mouse Cursor Events", Relay_OnDrag_14)) return; 
   }
   
   void Relay_ShowLabel_17()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3c9cdd1a-f20c-4fe1-8a30-77f537588986", "Print Text", Relay_ShowLabel_17)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_17.ShowLabel(logic_uScriptAct_PrintText_Text_17, logic_uScriptAct_PrintText_FontSize_17, logic_uScriptAct_PrintText_FontStyle_17, logic_uScriptAct_PrintText_FontColor_17, logic_uScriptAct_PrintText_textAnchor_17, logic_uScriptAct_PrintText_EdgePadding_17, logic_uScriptAct_PrintText_time_17);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_17()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("3c9cdd1a-f20c-4fe1-8a30-77f537588986", "Print Text", Relay_HideLabel_17)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_17.HideLabel(logic_uScriptAct_PrintText_Text_17, logic_uScriptAct_PrintText_FontSize_17, logic_uScriptAct_PrintText_FontStyle_17, logic_uScriptAct_PrintText_FontColor_17, logic_uScriptAct_PrintText_textAnchor_17, logic_uScriptAct_PrintText_EdgePadding_17, logic_uScriptAct_PrintText_time_17);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_MoveForward_18()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5fe39876-0e2b-495c-a27e-e496d27fc8e9", "Isometric Character Controller", Relay_MoveForward_18)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_5_UnityEngine_GameObject_previous != local_5_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_5_UnityEngine_GameObject_previous = local_5_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_IsometricCharacterController_target_18 = local_5_UnityEngine_GameObject;
               
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
         logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_18.MoveForward(logic_uScriptAct_IsometricCharacterController_target_18, logic_uScriptAct_IsometricCharacterController_translation_18, logic_uScriptAct_IsometricCharacterController_rotation_18, logic_uScriptAct_IsometricCharacterController_filterTranslation_18, logic_uScriptAct_IsometricCharacterController_translationFilterConstant_18, logic_uScriptAct_IsometricCharacterController_filterRotation_18, logic_uScriptAct_IsometricCharacterController_rotationFilterConstant_18);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Isometric Character Controller.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_MoveBackward_18()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5fe39876-0e2b-495c-a27e-e496d27fc8e9", "Isometric Character Controller", Relay_MoveBackward_18)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_5_UnityEngine_GameObject_previous != local_5_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_5_UnityEngine_GameObject_previous = local_5_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_IsometricCharacterController_target_18 = local_5_UnityEngine_GameObject;
               
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
         logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_18.MoveBackward(logic_uScriptAct_IsometricCharacterController_target_18, logic_uScriptAct_IsometricCharacterController_translation_18, logic_uScriptAct_IsometricCharacterController_rotation_18, logic_uScriptAct_IsometricCharacterController_filterTranslation_18, logic_uScriptAct_IsometricCharacterController_translationFilterConstant_18, logic_uScriptAct_IsometricCharacterController_filterRotation_18, logic_uScriptAct_IsometricCharacterController_rotationFilterConstant_18);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Isometric Character Controller.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_StrafeRight_18()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5fe39876-0e2b-495c-a27e-e496d27fc8e9", "Isometric Character Controller", Relay_StrafeRight_18)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_5_UnityEngine_GameObject_previous != local_5_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_5_UnityEngine_GameObject_previous = local_5_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_IsometricCharacterController_target_18 = local_5_UnityEngine_GameObject;
               
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
         logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_18.StrafeRight(logic_uScriptAct_IsometricCharacterController_target_18, logic_uScriptAct_IsometricCharacterController_translation_18, logic_uScriptAct_IsometricCharacterController_rotation_18, logic_uScriptAct_IsometricCharacterController_filterTranslation_18, logic_uScriptAct_IsometricCharacterController_translationFilterConstant_18, logic_uScriptAct_IsometricCharacterController_filterRotation_18, logic_uScriptAct_IsometricCharacterController_rotationFilterConstant_18);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Isometric Character Controller.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_StrafeLeft_18()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5fe39876-0e2b-495c-a27e-e496d27fc8e9", "Isometric Character Controller", Relay_StrafeLeft_18)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_5_UnityEngine_GameObject_previous != local_5_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_5_UnityEngine_GameObject_previous = local_5_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_IsometricCharacterController_target_18 = local_5_UnityEngine_GameObject;
               
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
         logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_18.StrafeLeft(logic_uScriptAct_IsometricCharacterController_target_18, logic_uScriptAct_IsometricCharacterController_translation_18, logic_uScriptAct_IsometricCharacterController_rotation_18, logic_uScriptAct_IsometricCharacterController_filterTranslation_18, logic_uScriptAct_IsometricCharacterController_translationFilterConstant_18, logic_uScriptAct_IsometricCharacterController_filterRotation_18, logic_uScriptAct_IsometricCharacterController_rotationFilterConstant_18);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Isometric Character Controller.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_RotateRight_18()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5fe39876-0e2b-495c-a27e-e496d27fc8e9", "Isometric Character Controller", Relay_RotateRight_18)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_5_UnityEngine_GameObject_previous != local_5_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_5_UnityEngine_GameObject_previous = local_5_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_IsometricCharacterController_target_18 = local_5_UnityEngine_GameObject;
               
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
         logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_18.RotateRight(logic_uScriptAct_IsometricCharacterController_target_18, logic_uScriptAct_IsometricCharacterController_translation_18, logic_uScriptAct_IsometricCharacterController_rotation_18, logic_uScriptAct_IsometricCharacterController_filterTranslation_18, logic_uScriptAct_IsometricCharacterController_translationFilterConstant_18, logic_uScriptAct_IsometricCharacterController_filterRotation_18, logic_uScriptAct_IsometricCharacterController_rotationFilterConstant_18);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Isometric Character Controller.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_RotateLeft_18()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5fe39876-0e2b-495c-a27e-e496d27fc8e9", "Isometric Character Controller", Relay_RotateLeft_18)) return; 
         {
            {
               {
                  //if our game object reference was changed then we need to reset event listeners
                  if ( local_5_UnityEngine_GameObject_previous != local_5_UnityEngine_GameObject || false == m_RegisteredForEvents )
                  {
                     //tear down old listeners
                     
                     local_5_UnityEngine_GameObject_previous = local_5_UnityEngine_GameObject;
                     
                     //setup new listeners
                  }
               }
               logic_uScriptAct_IsometricCharacterController_target_18 = local_5_UnityEngine_GameObject;
               
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
         logic_uScriptAct_IsometricCharacterController_uScriptAct_IsometricCharacterController_18.RotateLeft(logic_uScriptAct_IsometricCharacterController_target_18, logic_uScriptAct_IsometricCharacterController_translation_18, logic_uScriptAct_IsometricCharacterController_rotation_18, logic_uScriptAct_IsometricCharacterController_filterTranslation_18, logic_uScriptAct_IsometricCharacterController_translationFilterConstant_18, logic_uScriptAct_IsometricCharacterController_filterRotation_18, logic_uScriptAct_IsometricCharacterController_rotationFilterConstant_18);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Isometric Character Controller.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_OnEnter_20()
   {
      if (true == CheckDebugBreak("a29b1374-1b68-4bf4-97f7-1518fe50504e", "Mouse Cursor Events", Relay_OnEnter_20)) return; 
   }
   
   void Relay_OnOver_20()
   {
      if (true == CheckDebugBreak("a29b1374-1b68-4bf4-97f7-1518fe50504e", "Mouse Cursor Events", Relay_OnOver_20)) return; 
   }
   
   void Relay_OnExit_20()
   {
      if (true == CheckDebugBreak("a29b1374-1b68-4bf4-97f7-1518fe50504e", "Mouse Cursor Events", Relay_OnExit_20)) return; 
   }
   
   void Relay_OnDown_20()
   {
      if (true == CheckDebugBreak("a29b1374-1b68-4bf4-97f7-1518fe50504e", "Mouse Cursor Events", Relay_OnDown_20)) return; 
   }
   
   void Relay_OnUp_20()
   {
      if (true == CheckDebugBreak("a29b1374-1b68-4bf4-97f7-1518fe50504e", "Mouse Cursor Events", Relay_OnUp_20)) return; 
      Relay_TurnOn_0();
   }
   
   void Relay_OnDrag_20()
   {
      if (true == CheckDebugBreak("a29b1374-1b68-4bf4-97f7-1518fe50504e", "Mouse Cursor Events", Relay_OnDrag_20)) return; 
   }
   
   void Relay_KeyEvent_21()
   {
      if (true == CheckDebugBreak("151bf802-2aa4-4f2e-96fd-b9cf76376f2c", "Input Events", Relay_KeyEvent_21)) return; 
      Relay_In_22();
      Relay_In_10();
      Relay_In_13();
      Relay_In_9();
   }
   
   void Relay_In_22()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("35e6f2a7-407c-430b-a6af-525edf79e278", "Input Events Filter", Relay_In_22)) return; 
         {
            {
            }
         }
         logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_22.In(logic_uScriptAct_OnInputEventFilter_KeyCode_22);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_OnInputEventFilter_uScriptAct_OnInputEventFilter_22.KeyHeld;
         
         if ( test_0 == true )
         {
            Relay_RotateRight_18();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Input Events Filter.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_ShowLabel_24()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c861776c-8e37-4d84-a7f2-d02c7a551f94", "Print Text", Relay_ShowLabel_24)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_24.ShowLabel(logic_uScriptAct_PrintText_Text_24, logic_uScriptAct_PrintText_FontSize_24, logic_uScriptAct_PrintText_FontStyle_24, logic_uScriptAct_PrintText_FontColor_24, logic_uScriptAct_PrintText_textAnchor_24, logic_uScriptAct_PrintText_EdgePadding_24, logic_uScriptAct_PrintText_time_24);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_PrintText_uScriptAct_PrintText_24.Out;
         
         if ( test_0 == true )
         {
            Relay_ShowLabel_17();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_HideLabel_24()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("c861776c-8e37-4d84-a7f2-d02c7a551f94", "Print Text", Relay_HideLabel_24)) return; 
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
         logic_uScriptAct_PrintText_uScriptAct_PrintText_24.HideLabel(logic_uScriptAct_PrintText_Text_24, logic_uScriptAct_PrintText_FontSize_24, logic_uScriptAct_PrintText_FontStyle_24, logic_uScriptAct_PrintText_FontColor_24, logic_uScriptAct_PrintText_textAnchor_24, logic_uScriptAct_PrintText_EdgePadding_24, logic_uScriptAct_PrintText_time_24);
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_PrintText_uScriptAct_PrintText_24.Out;
         
         if ( test_0 == true )
         {
            Relay_ShowLabel_17();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript GeometryButtons_GUITestGraph.uscript at Print Text.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GeometryButtons_GUITestGraph.uscript:1", local_1_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "41c26daa-3283-4cd0-9117-c22d734d2e8d", local_1_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GeometryButtons_GUITestGraph.uscript:2", local_2_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "162d5102-17f8-479c-8c2b-392f5da552c0", local_2_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GeometryButtons_GUITestGraph.uscript:4", local_4_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "beeae3f3-c35e-4ba7-9c97-d2ec74c87ddf", local_4_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GeometryButtons_GUITestGraph.uscript:5", local_5_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "22b56ca5-093d-4d4b-8b61-b355258af2a2", local_5_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GeometryButtons_GUITestGraph.uscript:15", local_15_UnityEngine_Vector2);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "d2ee395b-52a2-4862-87bc-59e5a48a8b03", local_15_UnityEngine_Vector2);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GeometryButtons_GUITestGraph.uscript:16", local_16_UnityEngine_Camera);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "76f76ee2-37bb-4304-ae77-9ff8fc72cada", local_16_UnityEngine_Camera);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GeometryButtons_GUITestGraph.uscript:19", local_19_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "18784abc-90d9-4ff8-be17-0887f3221256", local_19_UnityEngine_GameObject);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "GeometryButtons_GUITestGraph.uscript:23", local_23_System_String);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "79f6a8c2-4a96-4000-a800-f1b45928a4af", local_23_System_String);
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
