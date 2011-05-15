//uScript Generated Code - Build 0.3.110514a
using UnityEngine;
using System.Collections;

public class uScript_TestBed_Nested : uScriptLogic
{

   #pragma warning disable 414
   GameObject parentGameObject = null;
   //external output properties
   
   //externally exposed events
   
   //external parameters
   
   //local nodes
   
   //owner nodes
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_0 = null;
   System.String logic_uScriptAct_Log_Prefix_0 = "Down";
   System.Object[] logic_uScriptAct_Log_Target_0 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_0 = "";
   bool logic_uScriptAct_Log_Out_0 = true;
   //pointer to script instanced logic node
   uScriptAct_OnKeyPressFilter logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_1 = null;
   UnityEngine.KeyCode logic_uScriptAct_OnKeyPressFilter_KeyCode_1 = UnityEngine.KeyCode.A;
   bool logic_uScriptAct_OnKeyPressFilter_KeyHeld_1 = true;
   bool logic_uScriptAct_OnKeyPressFilter_KeyDown_1 = true;
   bool logic_uScriptAct_OnKeyPressFilter_KeyUp_1 = true;
   //pointer to script instanced logic node
   uScriptAct_Log logic_uScriptAct_Log_uScriptAct_Log_2 = null;
   System.String logic_uScriptAct_Log_Prefix_2 = "Up";
   System.Object[] logic_uScriptAct_Log_Target_2 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_2 = "";
   bool logic_uScriptAct_Log_Out_2 = true;
   
   //event nodes
   UnityEngine.GameObject event_UnityEngine_GameObject_Instance_3 = null;
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      if ( null == event_UnityEngine_GameObject_Instance_3 )
      {
         event_UnityEngine_GameObject_Instance_3 = GameObject.Find( "_uScript" ) as UnityEngine.GameObject;
         if ( null != event_UnityEngine_GameObject_Instance_3 )
         {
            {
               uScript_Input component = event_UnityEngine_GameObject_Instance_3.GetComponent<uScript_Input>();
               if ( null != component )
               {
                  component.KeyEvent += Instance_KeyEvent_3;
               }
            }
         }
      }
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      SyncUnityHooks( );
      
      logic_uScriptAct_Log_uScriptAct_Log_0.SetParent(g);
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_1.SetParent(g);
      logic_uScriptAct_Log_uScriptAct_Log_2.SetParent(g);
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
      
      logic_uScriptAct_Log_uScriptAct_Log_0 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_1 = ScriptableObject.CreateInstance(typeof(uScriptAct_OnKeyPressFilter)) as uScriptAct_OnKeyPressFilter;
      logic_uScriptAct_Log_uScriptAct_Log_2 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      
   }
   
   public override void Update()
   {
      logic_uScriptAct_Log_uScriptAct_Log_0.Update( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_1.Update( );
      logic_uScriptAct_Log_uScriptAct_Log_2.Update( );
   }
   
   public override void LateUpdate()
   {
      logic_uScriptAct_Log_uScriptAct_Log_0.LateUpdate( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_1.LateUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_2.LateUpdate( );
   }
   
   public override void FixedUpdate()
   {
      logic_uScriptAct_Log_uScriptAct_Log_0.FixedUpdate( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_1.FixedUpdate( );
      logic_uScriptAct_Log_uScriptAct_Log_2.FixedUpdate( );
   }
   
   public override void OnGUI()
   {
      logic_uScriptAct_Log_uScriptAct_Log_0.OnGUI( );
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_1.OnGUI( );
      logic_uScriptAct_Log_uScriptAct_Log_2.OnGUI( );
   }
   
   void Instance_KeyEvent_3(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_KeyEvent_3( );
   }
   
   void Relay_In_0()
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
      logic_uScriptAct_Log_uScriptAct_Log_0.In(logic_uScriptAct_Log_Prefix_0, logic_uScriptAct_Log_Target_0, logic_uScriptAct_Log_Postfix_0);
      SyncUnityHooks( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_0.Out == true )
      {
      }
   }
   
   void Relay_In_1()
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
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_1.In(logic_uScriptAct_OnKeyPressFilter_KeyCode_1);
      SyncUnityHooks( );
      if ( logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_1.KeyHeld == true )
      {
      }
      if ( logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_1.KeyDown == true )
      {
         Relay_In_0();
      }
      if ( logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_1.KeyUp == true )
      {
         Relay_In_2();
      }
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
   
   void Relay_KeyEvent_3()
   {
      SyncUnityHooks( );
      Relay_In_1();
   }
   
}
