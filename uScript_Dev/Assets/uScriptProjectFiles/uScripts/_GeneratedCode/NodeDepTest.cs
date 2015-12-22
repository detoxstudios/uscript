//uScript Generated Code - Build 1.0.3008
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("Untitled", "")]
public class NodeDepTest : uScriptLogic
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
   UnityEngine.Rect[] local_14_UnityEngine_RectArray = new Rect[] {new Rect((float)1,(float)1,(float)1,(float)1)};
   UnityEngine.Rect local_15_UnityEngine_Rect = new Rect( (float)2, (float)2, (float)2, (float)2 );
   UnityEngine.Rect local_16_UnityEngine_Rect = new Rect( (float)0, (float)0, (float)0, (float)0 );
   UnityEngine.Rect local_17_UnityEngine_Rect = new Rect( (float)0, (float)0, (float)0, (float)0 );
   UnityEngine.Vector4 local_19_UnityEngine_Vector4 = new Vector4( (float)0, (float)0, (float)0, (float)0 );
   UnityEngine.Vector4 local_20_UnityEngine_Vector4 = new Vector4( (float)1, (float)1, (float)1, (float)1 );
   UnityEngine.Vector4 local_21_UnityEngine_Vector4 = new Vector4( (float)2, (float)2, (float)2, (float)2 );
   UnityEngine.Vector4 local_22_UnityEngine_Vector4 = new Vector4( (float)0, (float)0, (float)0, (float)0 );
   UnityEngine.Vector2 local_24_UnityEngine_Vector2 = new Vector2( (float)1, (float)1 );
   UnityEngine.Vector2 local_25_UnityEngine_Vector2 = new Vector2( (float)2, (float)2 );
   UnityEngine.Vector2 local_26_UnityEngine_Vector2 = new Vector2( (float)0, (float)0 );
   UnityEngine.Vector2 local_27_UnityEngine_Vector2 = new Vector2( (float)0, (float)0 );
   UnityEngine.Vector4 local_29_UnityEngine_Vector4 = new Vector4( (float)0, (float)0, (float)0, (float)0 );
   UnityEngine.Vector4 local_30_UnityEngine_Vector4 = new Vector4( (float)1, (float)1, (float)1, (float)1 );
   UnityEngine.Vector4 local_31_UnityEngine_Vector4 = new Vector4( (float)2, (float)2, (float)2, (float)2 );
   UnityEngine.Vector4 local_32_UnityEngine_Vector4 = new Vector4( (float)0, (float)0, (float)0, (float)0 );
   UnityEngine.Vector2 local_33_UnityEngine_Vector2 = new Vector2( (float)0, (float)0 );
   UnityEngine.Vector2 local_34_UnityEngine_Vector2 = new Vector2( (float)0, (float)0 );
   UnityEngine.Vector2 local_36_UnityEngine_Vector2 = new Vector2( (float)1, (float)1 );
   UnityEngine.Vector2 local_37_UnityEngine_Vector2 = new Vector2( (float)2, (float)2 );
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_SubtractVector4_v2 logic_uScriptAct_SubtractVector4_v2_uScriptAct_SubtractVector4_v2_0 = new uScriptAct_SubtractVector4_v2( );
   UnityEngine.Vector4 logic_uScriptAct_SubtractVector4_v2_A_0 = new Vector4( (float)0, (float)0, (float)0, (float)0 );
   UnityEngine.Vector4 logic_uScriptAct_SubtractVector4_v2_B_0 = new Vector4( (float)0, (float)0, (float)0, (float)0 );
   UnityEngine.Vector4 logic_uScriptAct_SubtractVector4_v2_Result_0;
   bool logic_uScriptAct_SubtractVector4_v2_Out_0 = true;
   //pointer to script instanced logic node
   uScriptAct_SubtractRect logic_uScriptAct_SubtractRect_uScriptAct_SubtractRect_1 = new uScriptAct_SubtractRect( );
   UnityEngine.Rect[] logic_uScriptAct_SubtractRect_A_1 = new Rect[] {new Rect((float)1,(float)1,(float)1,(float)1)};
   UnityEngine.Rect[] logic_uScriptAct_SubtractRect_B_1 = new Rect[] {new Rect((float)2,(float)2,(float)2,(float)2)};
   UnityEngine.Rect logic_uScriptAct_SubtractRect_Result_1;
   bool logic_uScriptAct_SubtractRect_Out_1 = true;
   //pointer to script instanced logic node
   uScriptAct_MultiplyVector2 logic_uScriptAct_MultiplyVector2_uScriptAct_MultiplyVector2_2 = new uScriptAct_MultiplyVector2( );
   UnityEngine.Vector2[] logic_uScriptAct_MultiplyVector2_A_2 = new Vector2[] {new Vector2((float)1,(float)1)};
   UnityEngine.Vector2[] logic_uScriptAct_MultiplyVector2_B_2 = new Vector2[] {new Vector2((float)2,(float)2)};
   UnityEngine.Vector2 logic_uScriptAct_MultiplyVector2_Result_2;
   bool logic_uScriptAct_MultiplyVector2_Out_2 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector4 logic_uScriptAct_AddVector4_uScriptAct_AddVector4_6 = new uScriptAct_AddVector4( );
   UnityEngine.Vector4[] logic_uScriptAct_AddVector4_A_6 = new Vector4[] {new Vector4((float)1,(float)1,(float)1,(float)1)};
   UnityEngine.Vector4[] logic_uScriptAct_AddVector4_B_6 = new Vector4[] {new Vector4((float)2,(float)2,(float)2,(float)2)};
   UnityEngine.Vector4 logic_uScriptAct_AddVector4_Result_6;
   bool logic_uScriptAct_AddVector4_Out_6 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector2 logic_uScriptAct_AddVector2_uScriptAct_AddVector2_8 = new uScriptAct_AddVector2( );
   UnityEngine.Vector2[] logic_uScriptAct_AddVector2_A_8 = new Vector2[] {new Vector2((float)1,(float)1)};
   UnityEngine.Vector2[] logic_uScriptAct_AddVector2_B_8 = new Vector2[] {new Vector2((float)2,(float)2)};
   UnityEngine.Vector2 logic_uScriptAct_AddVector2_Result_8;
   bool logic_uScriptAct_AddVector2_Out_8 = true;
   //pointer to script instanced logic node
   uScriptAct_SubtractRect logic_uScriptAct_SubtractRect_uScriptAct_SubtractRect_13 = new uScriptAct_SubtractRect( );
   UnityEngine.Rect[] logic_uScriptAct_SubtractRect_A_13 = new Rect[] {};
   UnityEngine.Rect[] logic_uScriptAct_SubtractRect_B_13 = new Rect[] {};
   UnityEngine.Rect logic_uScriptAct_SubtractRect_Result_13;
   bool logic_uScriptAct_SubtractRect_Out_13 = true;
   //pointer to script instanced logic node
   uScriptAct_SubtractVector4_v2 logic_uScriptAct_SubtractVector4_v2_uScriptAct_SubtractVector4_v2_18 = new uScriptAct_SubtractVector4_v2( );
   UnityEngine.Vector4 logic_uScriptAct_SubtractVector4_v2_A_18 = new Vector4( );
   UnityEngine.Vector4 logic_uScriptAct_SubtractVector4_v2_B_18 = new Vector4( );
   UnityEngine.Vector4 logic_uScriptAct_SubtractVector4_v2_Result_18;
   bool logic_uScriptAct_SubtractVector4_v2_Out_18 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector2 logic_uScriptAct_AddVector2_uScriptAct_AddVector2_23 = new uScriptAct_AddVector2( );
   UnityEngine.Vector2[] logic_uScriptAct_AddVector2_A_23 = new Vector2[] {};
   UnityEngine.Vector2[] logic_uScriptAct_AddVector2_B_23 = new Vector2[] {};
   UnityEngine.Vector2 logic_uScriptAct_AddVector2_Result_23;
   bool logic_uScriptAct_AddVector2_Out_23 = true;
   //pointer to script instanced logic node
   uScriptAct_AddVector4 logic_uScriptAct_AddVector4_uScriptAct_AddVector4_28 = new uScriptAct_AddVector4( );
   UnityEngine.Vector4[] logic_uScriptAct_AddVector4_A_28 = new Vector4[] {};
   UnityEngine.Vector4[] logic_uScriptAct_AddVector4_B_28 = new Vector4[] {};
   UnityEngine.Vector4 logic_uScriptAct_AddVector4_Result_28;
   bool logic_uScriptAct_AddVector4_Out_28 = true;
   //pointer to script instanced logic node
   uScriptAct_MultiplyVector2 logic_uScriptAct_MultiplyVector2_uScriptAct_MultiplyVector2_35 = new uScriptAct_MultiplyVector2( );
   UnityEngine.Vector2[] logic_uScriptAct_MultiplyVector2_A_35 = new Vector2[] {};
   UnityEngine.Vector2[] logic_uScriptAct_MultiplyVector2_B_35 = new Vector2[] {};
   UnityEngine.Vector2 logic_uScriptAct_MultiplyVector2_Result_35;
   bool logic_uScriptAct_MultiplyVector2_Out_35 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_12 = default(UnityEngine.GameObject);
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
   }
   
   void SyncEventListeners( )
   {
      if ( null == event_UnityEngine_GameObject_Instance_12 || false == m_RegisteredForEvents )
      {
         event_UnityEngine_GameObject_Instance_12 = uScript_MasterComponent.LatestMaster;
         if ( null != event_UnityEngine_GameObject_Instance_12 )
         {
            {
               uScript_Global component = event_UnityEngine_GameObject_Instance_12.GetComponent<uScript_Global>();
               if ( null == component )
               {
                  component = event_UnityEngine_GameObject_Instance_12.AddComponent<uScript_Global>();
               }
               if ( null != component )
               {
                  component.uScriptStart += Instance_uScriptStart_12;
                  component.uScriptLateStart += Instance_uScriptLateStart_12;
               }
            }
         }
      }
   }
   
   void UnregisterEventListeners( )
   {
      if ( null != event_UnityEngine_GameObject_Instance_12 )
      {
         {
            uScript_Global component = event_UnityEngine_GameObject_Instance_12.GetComponent<uScript_Global>();
            if ( null != component )
            {
               component.uScriptStart -= Instance_uScriptStart_12;
               component.uScriptLateStart -= Instance_uScriptLateStart_12;
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
      logic_uScriptAct_SubtractVector4_v2_uScriptAct_SubtractVector4_v2_0.SetParent(g);
      logic_uScriptAct_SubtractRect_uScriptAct_SubtractRect_1.SetParent(g);
      logic_uScriptAct_MultiplyVector2_uScriptAct_MultiplyVector2_2.SetParent(g);
      logic_uScriptAct_AddVector4_uScriptAct_AddVector4_6.SetParent(g);
      logic_uScriptAct_AddVector2_uScriptAct_AddVector2_8.SetParent(g);
      logic_uScriptAct_SubtractRect_uScriptAct_SubtractRect_13.SetParent(g);
      logic_uScriptAct_SubtractVector4_v2_uScriptAct_SubtractVector4_v2_18.SetParent(g);
      logic_uScriptAct_AddVector2_uScriptAct_AddVector2_23.SetParent(g);
      logic_uScriptAct_AddVector4_uScriptAct_AddVector4_28.SetParent(g);
      logic_uScriptAct_MultiplyVector2_uScriptAct_MultiplyVector2_35.SetParent(g);
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
   
   void Instance_uScriptStart_12(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptStart_12( );
   }
   
   void Instance_uScriptLateStart_12(object o, System.EventArgs e)
   {
      //reset event call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      
      //fill globals
      //relay event to nodes
      Relay_uScriptLateStart_12( );
   }
   
   void Relay_In_0()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("6ae17941-83b4-43b6-96e6-752c0e29cd1d", "Subtract_Vector4", Relay_In_0)) return; 
         {
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SubtractVector4_v2_uScriptAct_SubtractVector4_v2_0.In(logic_uScriptAct_SubtractVector4_v2_A_0, logic_uScriptAct_SubtractVector4_v2_B_0, out logic_uScriptAct_SubtractVector4_v2_Result_0);
         local_19_UnityEngine_Vector4 = logic_uScriptAct_SubtractVector4_v2_Result_0;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SubtractVector4_v2_uScriptAct_SubtractVector4_v2_0.Out;
         
         if ( test_0 == true )
         {
            Relay_In_18();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript NodeDepTest.uscript at Subtract Vector4.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_1()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("42a3fbd7-c5e9-428d-abf8-2901359f6224", "Subtract_Rect__OLD_", Relay_In_1)) return; 
         {
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_SubtractRect_uScriptAct_SubtractRect_1.In(logic_uScriptAct_SubtractRect_A_1, logic_uScriptAct_SubtractRect_B_1, out logic_uScriptAct_SubtractRect_Result_1);
         local_16_UnityEngine_Rect = logic_uScriptAct_SubtractRect_Result_1;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_SubtractRect_uScriptAct_SubtractRect_1.Out;
         
         if ( test_0 == true )
         {
            Relay_In_13();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript NodeDepTest.uscript at Subtract Rect (OLD).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_2()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("569749b3-42c1-4da5-a9d0-5fba32701997", "Multiply_Vector2__OLD_", Relay_In_2)) return; 
         {
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_MultiplyVector2_uScriptAct_MultiplyVector2_2.In(logic_uScriptAct_MultiplyVector2_A_2, logic_uScriptAct_MultiplyVector2_B_2, out logic_uScriptAct_MultiplyVector2_Result_2);
         local_33_UnityEngine_Vector2 = logic_uScriptAct_MultiplyVector2_Result_2;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_MultiplyVector2_uScriptAct_MultiplyVector2_2.Out;
         
         if ( test_0 == true )
         {
            Relay_In_35();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript NodeDepTest.uscript at Multiply Vector2 (OLD).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_6()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("17a11acd-392c-4bb3-8af5-dff7ba54474f", "Add_Vector4__OLD_", Relay_In_6)) return; 
         {
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddVector4_uScriptAct_AddVector4_6.In(logic_uScriptAct_AddVector4_A_6, logic_uScriptAct_AddVector4_B_6, out logic_uScriptAct_AddVector4_Result_6);
         local_29_UnityEngine_Vector4 = logic_uScriptAct_AddVector4_Result_6;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector4_uScriptAct_AddVector4_6.Out;
         
         if ( test_0 == true )
         {
            Relay_In_28();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript NodeDepTest.uscript at Add Vector4 (OLD).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_8()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("5b8c202c-0ba5-44d5-89a3-7ac2457b6773", "Add_Vector2__OLD_", Relay_In_8)) return; 
         {
            {
            }
            {
            }
            {
            }
         }
         logic_uScriptAct_AddVector2_uScriptAct_AddVector2_8.In(logic_uScriptAct_AddVector2_A_8, logic_uScriptAct_AddVector2_B_8, out logic_uScriptAct_AddVector2_Result_8);
         local_27_UnityEngine_Vector2 = logic_uScriptAct_AddVector2_Result_8;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         bool test_0 = logic_uScriptAct_AddVector2_uScriptAct_AddVector2_8.Out;
         
         if ( test_0 == true )
         {
            Relay_In_23();
         }
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript NodeDepTest.uscript at Add Vector2 (OLD).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_uScriptStart_12()
   {
      if (true == CheckDebugBreak("57b11682-00ec-430c-8cd5-7f807f4ca5ea", "uScript_Events", Relay_uScriptStart_12)) return; 
      Relay_In_1();
      Relay_In_0();
      Relay_In_8();
      Relay_In_6();
      Relay_In_2();
   }
   
   void Relay_uScriptLateStart_12()
   {
      if (true == CheckDebugBreak("57b11682-00ec-430c-8cd5-7f807f4ca5ea", "uScript_Events", Relay_uScriptLateStart_12)) return; 
   }
   
   void Relay_In_13()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("20abfc54-833d-452a-937e-b95c694dec43", "Subtract_Rect__OLD_", Relay_In_13)) return; 
         {
            {
               System.Array properties;
               int index = 0;
               properties = local_14_UnityEngine_RectArray;
               if ( logic_uScriptAct_SubtractRect_A_13.Length != index + properties.Length)
               {
                  System.Array.Resize(ref logic_uScriptAct_SubtractRect_A_13, index + properties.Length);
               }
               System.Array.Copy(properties, 0, logic_uScriptAct_SubtractRect_A_13, index, properties.Length);
               index += properties.Length;
               
            }
            {
               int index = 0;
               if ( logic_uScriptAct_SubtractRect_B_13.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_SubtractRect_B_13, index + 1);
               }
               logic_uScriptAct_SubtractRect_B_13[ index++ ] = local_15_UnityEngine_Rect;
               
            }
            {
            }
         }
         logic_uScriptAct_SubtractRect_uScriptAct_SubtractRect_13.In(logic_uScriptAct_SubtractRect_A_13, logic_uScriptAct_SubtractRect_B_13, out logic_uScriptAct_SubtractRect_Result_13);
         local_17_UnityEngine_Rect = logic_uScriptAct_SubtractRect_Result_13;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript NodeDepTest.uscript at Subtract Rect (OLD).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_18()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("ee9951b5-44c1-476f-b114-c8101d3505d7", "Subtract_Vector4", Relay_In_18)) return; 
         {
            {
               logic_uScriptAct_SubtractVector4_v2_A_18 = local_20_UnityEngine_Vector4;
               
            }
            {
               logic_uScriptAct_SubtractVector4_v2_B_18 = local_21_UnityEngine_Vector4;
               
            }
            {
            }
         }
         logic_uScriptAct_SubtractVector4_v2_uScriptAct_SubtractVector4_v2_18.In(logic_uScriptAct_SubtractVector4_v2_A_18, logic_uScriptAct_SubtractVector4_v2_B_18, out logic_uScriptAct_SubtractVector4_v2_Result_18);
         local_22_UnityEngine_Vector4 = logic_uScriptAct_SubtractVector4_v2_Result_18;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript NodeDepTest.uscript at Subtract Vector4.  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_23()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("4bfa5f5a-b656-4540-abd8-55e6308d0073", "Add_Vector2__OLD_", Relay_In_23)) return; 
         {
            {
               int index = 0;
               if ( logic_uScriptAct_AddVector2_A_23.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_AddVector2_A_23, index + 1);
               }
               logic_uScriptAct_AddVector2_A_23[ index++ ] = local_24_UnityEngine_Vector2;
               
            }
            {
               int index = 0;
               if ( logic_uScriptAct_AddVector2_B_23.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_AddVector2_B_23, index + 1);
               }
               logic_uScriptAct_AddVector2_B_23[ index++ ] = local_25_UnityEngine_Vector2;
               
            }
            {
            }
         }
         logic_uScriptAct_AddVector2_uScriptAct_AddVector2_23.In(logic_uScriptAct_AddVector2_A_23, logic_uScriptAct_AddVector2_B_23, out logic_uScriptAct_AddVector2_Result_23);
         local_26_UnityEngine_Vector2 = logic_uScriptAct_AddVector2_Result_23;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript NodeDepTest.uscript at Add Vector2 (OLD).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_28()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("51a00afa-779b-49e0-99a8-15ef583cf0de", "Add_Vector4__OLD_", Relay_In_28)) return; 
         {
            {
               int index = 0;
               if ( logic_uScriptAct_AddVector4_A_28.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_AddVector4_A_28, index + 1);
               }
               logic_uScriptAct_AddVector4_A_28[ index++ ] = local_30_UnityEngine_Vector4;
               
            }
            {
               int index = 0;
               if ( logic_uScriptAct_AddVector4_B_28.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_AddVector4_B_28, index + 1);
               }
               logic_uScriptAct_AddVector4_B_28[ index++ ] = local_31_UnityEngine_Vector4;
               
            }
            {
            }
         }
         logic_uScriptAct_AddVector4_uScriptAct_AddVector4_28.In(logic_uScriptAct_AddVector4_A_28, logic_uScriptAct_AddVector4_B_28, out logic_uScriptAct_AddVector4_Result_28);
         local_32_UnityEngine_Vector4 = logic_uScriptAct_AddVector4_Result_28;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript NodeDepTest.uscript at Add Vector4 (OLD).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   void Relay_In_35()
   {
      if ( relayCallCount++ < MaxRelayCallCount )
      {
         if (true == CheckDebugBreak("018f9360-a0c2-4636-a31b-46d6db7eb3e2", "Multiply_Vector2__OLD_", Relay_In_35)) return; 
         {
            {
               int index = 0;
               if ( logic_uScriptAct_MultiplyVector2_A_35.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_MultiplyVector2_A_35, index + 1);
               }
               logic_uScriptAct_MultiplyVector2_A_35[ index++ ] = local_36_UnityEngine_Vector2;
               
            }
            {
               int index = 0;
               if ( logic_uScriptAct_MultiplyVector2_B_35.Length <= index)
               {
                  System.Array.Resize(ref logic_uScriptAct_MultiplyVector2_B_35, index + 1);
               }
               logic_uScriptAct_MultiplyVector2_B_35[ index++ ] = local_37_UnityEngine_Vector2;
               
            }
            {
            }
         }
         logic_uScriptAct_MultiplyVector2_uScriptAct_MultiplyVector2_35.In(logic_uScriptAct_MultiplyVector2_A_35, logic_uScriptAct_MultiplyVector2_B_35, out logic_uScriptAct_MultiplyVector2_Result_35);
         local_34_UnityEngine_Vector2 = logic_uScriptAct_MultiplyVector2_Result_35;
         
         //save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested
         
      }
      else
      {
         uScriptDebug.Log( "Possible infinite loop detected in uScript NodeDepTest.uscript at Multiply Vector2 (OLD).  If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.", uScriptDebug.Type.Error);
      }
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "NodeDepTest.uscript:14", local_14_UnityEngine_RectArray);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "38ea9093-e19e-4934-ba84-cfc9ac6fcecc", local_14_UnityEngine_RectArray);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "NodeDepTest.uscript:15", local_15_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "8e570178-e3f3-472b-80fd-6151ce5f0d7f", local_15_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "NodeDepTest.uscript:16", local_16_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "96d7b319-0223-4382-9362-0b3358157b85", local_16_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "NodeDepTest.uscript:17", local_17_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "177d88be-7710-4ada-a958-f1a3cf8a1aa1", local_17_UnityEngine_Rect);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "NodeDepTest.uscript:19", local_19_UnityEngine_Vector4);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "73d3c65b-0b7e-4d87-8046-9e5fcb504d9e", local_19_UnityEngine_Vector4);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "NodeDepTest.uscript:20", local_20_UnityEngine_Vector4);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "f37fdc41-a541-42cb-9b83-afc66e5de348", local_20_UnityEngine_Vector4);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "NodeDepTest.uscript:21", local_21_UnityEngine_Vector4);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "ba8bc0e4-b710-4635-993b-f92d5aba7111", local_21_UnityEngine_Vector4);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "NodeDepTest.uscript:22", local_22_UnityEngine_Vector4);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "c043a1a5-8a71-45fa-ad44-21d22cadb5bd", local_22_UnityEngine_Vector4);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "NodeDepTest.uscript:24", local_24_UnityEngine_Vector2);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b5f419f2-1e39-42b0-b043-22763cd7006c", local_24_UnityEngine_Vector2);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "NodeDepTest.uscript:25", local_25_UnityEngine_Vector2);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "e19fe45b-bb07-495d-917e-295e2b190dbe", local_25_UnityEngine_Vector2);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "NodeDepTest.uscript:26", local_26_UnityEngine_Vector2);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "9dc8b713-0b5c-4ff1-8c0d-cd7b95550141", local_26_UnityEngine_Vector2);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "NodeDepTest.uscript:27", local_27_UnityEngine_Vector2);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "8810ab18-3985-4645-8304-fc022617136c", local_27_UnityEngine_Vector2);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "NodeDepTest.uscript:29", local_29_UnityEngine_Vector4);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "3139dc30-1a5f-456e-876a-e58b4fd48123", local_29_UnityEngine_Vector4);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "NodeDepTest.uscript:30", local_30_UnityEngine_Vector4);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b0ee2f68-85c3-4200-9eb4-4ceeb67058fb", local_30_UnityEngine_Vector4);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "NodeDepTest.uscript:31", local_31_UnityEngine_Vector4);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "df029490-593a-4eae-b3f3-6732232edbc2", local_31_UnityEngine_Vector4);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "NodeDepTest.uscript:32", local_32_UnityEngine_Vector4);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "db1a0729-ab44-4be8-abda-fb8c415eba07", local_32_UnityEngine_Vector4);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "NodeDepTest.uscript:33", local_33_UnityEngine_Vector2);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "8e184bea-952c-4084-9502-74a2e0c2500f", local_33_UnityEngine_Vector2);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "NodeDepTest.uscript:34", local_34_UnityEngine_Vector2);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "b1aabc93-1510-4655-9e10-0ccb95eeeaae", local_34_UnityEngine_Vector2);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "NodeDepTest.uscript:36", local_36_UnityEngine_Vector2);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "3d4769ff-ba78-4174-ab52-242582cd1400", local_36_UnityEngine_Vector2);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "NodeDepTest.uscript:37", local_37_UnityEngine_Vector2);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "12c3886b-b915-4686-b565-4229834924fa", local_37_UnityEngine_Vector2);
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
