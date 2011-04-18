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
   System.String logic_uScriptAct_Log_Prefix_0 = "";
   System.Object[] logic_uScriptAct_Log_Target_0 = new System.Object[] {"Trigger fired!"};
   System.String logic_uScriptAct_Log_Postfix_0 = "";
   bool logic_uScriptAct_Log_Out_0 = true;
   
   //event nodes
   System.Int32 event_uScript_Triggers_TimesToTrigger_1 = (int) 0;
   UnityEngine.GameObject event_uScript_Triggers_GameObject_1 = null;
   uScript_Triggers event_uScript_Triggers_Instance_1 = null;
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void FillComponents( )
   {
      if ( null == event_uScript_Triggers_Instance_1 )
      {
         GameObject gameObject = GameObject.Find( "Trigger" );
         if ( null != gameObject )
         {
            event_uScript_Triggers_Instance_1 = gameObject.GetComponent<uScript_Triggers>();
            if ( null != event_uScript_Triggers_Instance_1 )
            {
               event_uScript_Triggers_Instance_1.TimesToTrigger = event_uScript_Triggers_TimesToTrigger_1;
            }
         }
      }
   }
   
   public void Awake()
   {
      FillComponents( );
      
      event_uScript_Triggers_Instance_1.OnEnterTrigger += Instance_OnEnterTrigger_1;
      event_uScript_Triggers_Instance_1.OnExitTrigger += Instance_OnExitTrigger_1;
      event_uScript_Triggers_Instance_1.WhileInsideTrigger += Instance_WhileInsideTrigger_1;
      
      logic_uScriptAct_Log_uScriptAct_Log_0 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      
   }
   
   public override void Update()
   {
      logic_uScriptAct_Log_uScriptAct_Log_0.Update( );
   }
   
   public override void LateUpdate()
   {
      logic_uScriptAct_Log_uScriptAct_Log_0.LateUpdate( );
   }
   
   public override void FixedUpdate()
   {
      logic_uScriptAct_Log_uScriptAct_Log_0.FixedUpdate( );
   }
   
   public override void OnGUI()
   {
      logic_uScriptAct_Log_uScriptAct_Log_0.OnGUI( );
   }
   
   public void OnDestroy()
   {
      if (false == Application.isEditor )
      {
         ScriptableObject.Destroy( logic_uScriptAct_Log_uScriptAct_Log_0 );
      }
      else
      {
         ScriptableObject.DestroyImmediate( logic_uScriptAct_Log_uScriptAct_Log_0 );
      }
      
      logic_uScriptAct_Log_uScriptAct_Log_0 = null;
      
   }
   void Instance_OnEnterTrigger_1(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //fill globals
      event_uScript_Triggers_GameObject_1 = e. GameObject;
      //relay event to nodes
      Relay_OnEnterTrigger_1( );
   }
   
   void Instance_OnExitTrigger_1(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //fill globals
      event_uScript_Triggers_GameObject_1 = e. GameObject;
      //relay event to nodes
      Relay_OnExitTrigger_1( );
   }
   
   void Instance_WhileInsideTrigger_1(object o, uScript_Triggers.TriggerEventArgs e)
   {
      //fill globals
      event_uScript_Triggers_GameObject_1 = e. GameObject;
      //relay event to nodes
      Relay_WhileInsideTrigger_1( );
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
   
   void Relay_OnEnterTrigger_1()
   {
      FillComponents( );
      Relay_In_0();
   }
   
   void Relay_OnExitTrigger_1()
   {
      FillComponents( );
   }
   
   void Relay_WhileInsideTrigger_1()
   {
      FillComponents( );
   }
   
}
