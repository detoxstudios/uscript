using UnityEngine;
using System.Collections;

public class SubSeq_uScript_TestBed : uScriptLogic
{

   #pragma warning disable 414
   //external output properties
   
   //externally exposed events
   
   //external parameters
   
   //local nodes
   UnityEngine.Ray local_0_UnityEngine_Ray = new UnityEngine.Ray( );
   System.Single local_1_System_Single = (float) 5;
   UnityEngine.RaycastHit local_2_UnityEngine_RaycastHit = new UnityEngine.RaycastHit( );
   System.Boolean local_3_System_Boolean = (bool) false;
   
   //logic nodes
   //pointer to script instanced logic node
   uScriptAct_PrintList logic_uScriptAct_PrintList_uScriptAct_PrintList_4 = null;
   System.String[] logic_uScriptAct_PrintList_strings_4 = new System.String[] {"on update"};
   bool logic_uScriptAct_PrintList_Out_4 = true;
   
   //event nodes
   uScript_Input event_uScript_Input_Instance_5 = null;
   uScript_Update event_uScript_Update_Instance_6 = null;
   
   //property nodes
   
   //method nodes
   UnityEngine.Ray method_Detox_ScriptEditor_Plug_UnityEngine_BoxCollider_ray_7 = new UnityEngine.Ray( );
   UnityEngine.RaycastHit method_Detox_ScriptEditor_Plug_UnityEngine_BoxCollider_hitInfo_7 = new UnityEngine.RaycastHit( );
   System.Single method_Detox_ScriptEditor_Plug_UnityEngine_BoxCollider_distance_7 = (float) 0;
   System.Boolean method_Detox_ScriptEditor_Plug_UnityEngine_BoxCollider_Return_7 = (bool) false;
   UnityEngine.BoxCollider method_Detox_ScriptEditor_Plug_UnityEngine_BoxCollider_Instance_7 = null;
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void FillComponents( )
   {
      if ( null == method_Detox_ScriptEditor_Plug_UnityEngine_BoxCollider_Instance_7 )
      {
         GameObject gameObject = GameObject.Find( "Player" );
         if ( null != gameObject )
         {
            method_Detox_ScriptEditor_Plug_UnityEngine_BoxCollider_Instance_7 = gameObject.GetComponent<UnityEngine.BoxCollider>();
         }
      }
      if ( null == event_uScript_Input_Instance_5 )
      {
         GameObject gameObject = GameObject.Find( "_uScript" );
         if ( null != gameObject )
         {
            event_uScript_Input_Instance_5 = gameObject.GetComponent<uScript_Input>();
            if ( null != event_uScript_Input_Instance_5 )
            {
            }
         }
      }
      if ( null == event_uScript_Update_Instance_6 )
      {
         GameObject gameObject = GameObject.Find( "_uScript" );
         if ( null != gameObject )
         {
            event_uScript_Update_Instance_6 = gameObject.GetComponent<uScript_Update>();
            if ( null != event_uScript_Update_Instance_6 )
            {
            }
         }
      }
   }
   
   public void Awake()
   {
      FillComponents( );
      
      event_uScript_Input_Instance_5.KeyPress += Instance_KeyPress_5;
      
      event_uScript_Update_Instance_6.OnUpdate += Instance_OnUpdate_6;
      
      logic_uScriptAct_PrintList_uScriptAct_PrintList_4 = ScriptableObject.CreateInstance(typeof(uScriptAct_PrintList)) as uScriptAct_PrintList;
      
   }
   
   public void Destroy()
   {
      ScriptableObject.Destroy( logic_uScriptAct_PrintList_uScriptAct_PrintList_4 );
      logic_uScriptAct_PrintList_uScriptAct_PrintList_4 = null;
      
   }
   void Instance_KeyPress_5(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_KeyPress_5( );
   }
   
   void Instance_OnUpdate_6(object o, System.EventArgs e)
   {
      //fill globals
      //relay event to nodes
      Relay_OnUpdate_6( );
   }
   
   void Relay_In_4()
   {
      //args = logic_uScriptAct_PrintList_strings_4
      FillComponents( );
      #pragma warning disable 219
      #pragma warning disable 168
      int index = 0;
      System.Array properties;
      #pragma warning restore 219
      #pragma warning restore 168
      index = 0;
      properties = null;
      logic_uScriptAct_PrintList_uScriptAct_PrintList_4.In(logic_uScriptAct_PrintList_strings_4);
      FillComponents( );
      if ( logic_uScriptAct_PrintList_uScriptAct_PrintList_4.Out == true )
      {
      }
   }
   
   void Relay_KeyPress_5()
   {
      FillComponents( );
      Relay_Raycast_7();
   }
   
   void Relay_OnUpdate_6()
   {
      FillComponents( );
      Relay_In_4();
   }
   
   void Relay_Raycast_7()
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
      method_Detox_ScriptEditor_Plug_UnityEngine_BoxCollider_ray_7 = local_0_UnityEngine_Ray;
      index = 0;
      properties = null;
      index = 0;
      properties = null;
      method_Detox_ScriptEditor_Plug_UnityEngine_BoxCollider_distance_7 = local_1_System_Single;
      index = 0;
      properties = null;
      method_Detox_ScriptEditor_Plug_UnityEngine_BoxCollider_Return_7 = method_Detox_ScriptEditor_Plug_UnityEngine_BoxCollider_Instance_7.Raycast(method_Detox_ScriptEditor_Plug_UnityEngine_BoxCollider_ray_7, out method_Detox_ScriptEditor_Plug_UnityEngine_BoxCollider_hitInfo_7, method_Detox_ScriptEditor_Plug_UnityEngine_BoxCollider_distance_7);
      FillComponents( );
      local_2_UnityEngine_RaycastHit = method_Detox_ScriptEditor_Plug_UnityEngine_BoxCollider_hitInfo_7;
      local_3_System_Boolean = method_Detox_ScriptEditor_Plug_UnityEngine_BoxCollider_Return_7;
   }
   
}
