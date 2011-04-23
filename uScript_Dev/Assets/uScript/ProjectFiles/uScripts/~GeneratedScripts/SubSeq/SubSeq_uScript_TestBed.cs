using UnityEngine;
using System.Collections;

public class SubSeq_uScript_TestBed : uScriptLogic
{

   #pragma warning disable 414
   //external output properties
   
   //externally exposed events
   
   //external parameters
   
   //local nodes
   
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
   uScript_Input event_uScript_Input_Instance_3 = null;
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void FillComponents( )
   {
      if ( null == event_uScript_Input_Instance_3 )
      {
         GameObject gameObject = GameObject.Find( "_uScript" );
         if ( null != gameObject )
         {
            event_uScript_Input_Instance_3 = gameObject.GetComponent<uScript_Input>();
            if ( null != event_uScript_Input_Instance_3 )
            {
               event_uScript_Input_Instance_3.KeyEvent += Instance_KeyEvent_3;
            }
         }
      }
   }
   
   public void Awake()
   {
      FillComponents( );
      
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
      FillComponents( );
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
      logic_uScriptAct_Log_uScriptAct_Log_0.In(logic_uScriptAct_Log_Prefix_0, logic_uScriptAct_Log_Target_0, logic_uScriptAct_Log_Postfix_0);
      FillComponents( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_0.Out == true )
      {
      }
   }
   
   void Relay_In_1()
   {
      FillComponents( );
      #pragma warning disable 219
      #pragma warning disable 168
      int index = 0;
      System.Array properties;
      #pragma warning restore 219
      #pragma warning restore 168
      index = 0;
      properties = null;
      logic_uScriptAct_OnKeyPressFilter_uScriptAct_OnKeyPressFilter_1.In(logic_uScriptAct_OnKeyPressFilter_KeyCode_1);
      FillComponents( );
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
      FillComponents( );
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
      logic_uScriptAct_Log_uScriptAct_Log_2.In(logic_uScriptAct_Log_Prefix_2, logic_uScriptAct_Log_Target_2, logic_uScriptAct_Log_Postfix_2);
      FillComponents( );
      if ( logic_uScriptAct_Log_uScriptAct_Log_2.Out == true )
      {
      }
   }
   
   void Relay_KeyEvent_3()
   {
      FillComponents( );
      Relay_In_1();
   }
   
}
