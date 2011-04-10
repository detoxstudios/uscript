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
   System.String logic_uScriptAct_Log_Prefix_0 = "Trigger Fired!";
   System.Object[] logic_uScriptAct_Log_Target_0 = new System.Object[] {""};
   System.String logic_uScriptAct_Log_Postfix_0 = "";
   bool logic_uScriptAct_Log_Out_0 = true;
   
   //event nodes
   System.Int32 event_uScript_Triggers_TimesToTrigger_1 = (int) 0;
   UnityEngine.GameObject event_uScript_Triggers_GameObject_1 = null;
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void FillComponents( )
   {
   }
   
   public override void _InternalAwake()
   {
      FillComponents( );
      
      
      logic_uScriptAct_Log_uScriptAct_Log_0 = ScriptableObject.CreateInstance(typeof(uScriptAct_Log)) as uScriptAct_Log;
      logic_uScriptAct_Log_uScriptAct_Log_0._InternalAwake( );
      
   }
   
   public override void _InternalDestroy()
   {
      logic_uScriptAct_Log_uScriptAct_Log_0._InternalDestroy( );
      ScriptableObject.Destroy( logic_uScriptAct_Log_uScriptAct_Log_0 );
      logic_uScriptAct_Log_uScriptAct_Log_0 = null;
      
   }
   public override void _InternalUpdate()
   {
      logic_uScriptAct_Log_uScriptAct_Log_0._InternalUpdate( );
   }
   public override void _InternalOnGUI()
   {
      logic_uScriptAct_Log_uScriptAct_Log_0._InternalOnGUI( );
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
   
}
/*[[BEGIN BASE64
AQAAAIezAAAmAAAAEE9iamVjdFNlcmlhbGl6ZXIBAAAAAAAAAAAERGF0YQEAAAACAAAAAARUeXBlDVN5c3RlbS5TdHJpbmcoAAAARGV0b3guRGF0YS5TY3JpcHRFZGl0b3IuU2NyaXB0RWRpdG9yRGF0YQdWZXJzaW9uDFN5c3RlbS5JbnQzMgQAAAABAAAACU5vZGVEYXRhcwMAAAAAAAAADFN5c3RlbS5JbnQzMgQAAAADAAAABUl0ZW0wBQAAAAIAAAAABFR5cGUNU3lzdGVtLlN0cmluZycAAABEZXRveC5EYXRhLlNjcmlwdEVkaXRvci5FbnRpdHlFdmVudERhdGEHVmVyc2lvbgxTeXN0ZW0uSW50MzIEAAAABQAAAARCYXNlBQAAAAIAAAAABFR5cGUNU3lzdGVtLlN0cmluZyYAAABEZXRveC5EYXRhLlNjcmlwdEVkaXRvci5FbnRpdHlOb2RlRGF0YQdWZXJzaW9uDFN5c3RlbS5JbnQzMgQAAAACAAAABEd1aWQAAAAAAgAAAA1TeXN0ZW0uU3RyaW5nJAAAAGQ0Yjc4ODNjLTE1OTMtNGM1Yy04NjE4LThkZjNmNjIzYjE5YgRUeXBlDVN5c3RlbS5TdHJpbmcLAAAAU3lzdGVtLkd1aWQHVmVyc2lvbgxTeXN0ZW0uSW50MzIEAAAAAQAAAAFYAAAAAAIAAAAMU3lzdGVtLkludDMyBAAAAKYHAAAEVHlwZQ1TeXN0ZW0uU3RyaW5nDAAAAFN5c3RlbS5JbnQzMgdWZXJzaW9uDFN5c3RlbS5JbnQzMgQAAAABAAAAAVkAAAAAAgAAAAxTeXN0ZW0uSW50MzIEAAAAagcAAARUeXBlDVN5c3RlbS5TdHJpbmcMAAAAU3lzdGVtLkludDMyB1ZlcnNpb24MU3lzdGVtLkludDMyBAAAAAEAAAALU2hvd0NvbW1lbnQAAAAAAgAAAA1TeXN0ZW0uQnl0ZVtdJwAAAAxTaG93IENvbW1lbnQMU2hvdyBDb21tZW50BWZhbHNlBEJvb2wBAARUeXBlDVN5c3RlbS5TdHJpbmchAAAARGV0b3guRGF0YS5TY3JpcHRFZGl0b3IuUGFyYW1ldGVyB1ZlcnNpb24MU3lzdGVtLkludDMyBAAAAAIAAAAHQ29tbWVudAAAAAACAAAADVN5c3RlbS5CeXRlW10aAAAAB0NvbW1lbnQHQ29tbWVudAAGU3RyaW5nAQAEVHlwZQ1TeXN0ZW0uU3RyaW5nIQAAAERldG94LkRhdGEuU2NyaXB0RWRpdG9yLlBhcmFtZXRlcgdWZXJzaW9uDFN5c3RlbS5JbnQzMgQAAAACAAAAB091dHB1dHMAAAAAAgAAAA1TeXN0ZW0uQnl0ZVtdZAAAAAMAAAAOT25FbnRlclRyaWdnZXIOT25FbnRlclRyaWdnZXINT25FeGl0VHJpZ2dlcg1PbkV4aXRUcmlnZ2VyEldoaWxlSW5zaWRlVHJpZ2dlchJXaGlsZUluc2lkZVRyaWdnZXIEVHlwZQ1TeXN0ZW0uU3RyaW5nHgAAAERldG94LkRhdGEuU2NyaXB0RWRpdG9yLlBsdWdbXQdWZXJzaW9uDFN5c3RlbS5JbnQzMgQAAAABAAAACEluc3RhbmNlAAAAAAIAAAANU3lzdGVtLkJ5dGVbXSwAAAAISW5zdGFuY2UOVHJpZ2dlciBFdmVudHMAEHVTY3JpcHRfVHJpZ2dlcnMBAARUeXBlDVN5c3RlbS5TdHJpbmchAAAARGV0b3guRGF0YS5TY3JpcHRFZGl0b3IuUGFyYW1ldGVyB1ZlcnNpb24MU3lzdGVtLkludDMyBAAAAAIAAAAKUGFyYW1ldGVycwAAAAACAAAADVN5c3RlbS5CeXRlW11jAAAAAgAAAA5UaW1lc1RvVHJpZ2dlcg5UaW1lc1RvVHJpZ2dlcgEwDFN5c3RlbS5JbnQzMgEACkdhbWVPYmplY3QKSW5zdGlnYXRvcgAWVW5pdHlFbmdpbmUuR2FtZU9iamVjdAABBFR5cGUNU3lzdGVtLlN0cmluZyMAAABEZXRveC5EYXRhLlNjcmlwdEVkaXRvci5QYXJhbWV0ZXJbXQdWZXJzaW9uDFN5c3RlbS5JbnQzMgQAAAACAAAACUV2ZW50QXJncwAAAAACAAAADVN5c3RlbS5TdHJpbmchAAAAdVNjcmlwdF9UcmlnZ2Vycy5UcmlnZ2VyRXZlbnRBcmdzBFR5cGUNU3lzdGVtLlN0cmluZw0AAABTeXN0ZW0uU3RyaW5nB1ZlcnNpb24MU3lzdGVtLkludDMyBAAAAAEAAAAFSXRlbTEFAAAAAgAAAAAEVHlwZQ1TeXN0ZW0uU3RyaW5nJAAAAERldG94LkRhdGEuU2NyaXB0RWRpdG9yLkxpbmtOb2RlRGF0YQdWZXJzaW9uDFN5c3RlbS5JbnQzMgQAAAABAAAABEJhc2UFAAAAAgAAAAAEVHlwZQ1TeXN0ZW0uU3RyaW5nJgAAAERldG94LkRhdGEuU2NyaXB0RWRpdG9yLkVudGl0eU5vZGVEYXRhB1ZlcnNpb24MU3lzdGVtLkludDMyBAAAAAIAAAAER3VpZAAAAAACAAAADVN5c3RlbS5TdHJpbmckAAAAMDJmNjFhYWUtM2RlZS00Y2JiLWIwNTEtOTRhM2E4MDMwNTZiBFR5cGUNU3lzdGVtLlN0cmluZwsAAABTeXN0ZW0uR3VpZAdWZXJzaW9uDFN5c3RlbS5JbnQzMgQAAAABAAAAAVgAAAAAAgAAAAxTeXN0ZW0uSW50MzIEAAAAAAAAAARUeXBlDVN5c3RlbS5TdHJpbmcMAAAAU3lzdGVtLkludDMyB1ZlcnNpb24MU3lzdGVtLkludDMyBAAAAAEAAAABWQAAAAACAAAADFN5c3RlbS5JbnQzMgQAAAAAAAAABFR5cGUNU3lzdGVtLlN0cmluZwwAAABTeXN0ZW0uSW50MzIHVmVyc2lvbgxTeXN0ZW0uSW50MzIEAAAAAQAAAAtTaG93Q29tbWVudAAAAAACAAAADVN5c3RlbS5CeXRlW10nAAAADFNob3cgQ29tbWVudAxTaG93IENvbW1lbnQFZmFsc2UEQm9vbAEABFR5cGUNU3lzdGVtLlN0cmluZyEAAABEZXRveC5EYXRhLlNjcmlwdEVkaXRvci5QYXJhbWV0ZXIHVmVyc2lvbgxTeXN0ZW0uSW50MzIEAAAAAgAAAAdDb21tZW50AAAAAAIAAAANU3lzdGVtLkJ5dGVbXRoAAAAHQ29tbWVudAdDb21tZW50AAZTdHJpbmcBAARUeXBlDVN5c3RlbS5TdHJpbmchAAAARGV0b3guRGF0YS5TY3JpcHRFZGl0b3IuUGFyYW1ldGVyB1ZlcnNpb24MU3lzdGVtLkludDMyBAAAAAIAAAAKU291cmNlR3VpZAAAAAACAAAADVN5c3RlbS5TdHJpbmckAAAAZDRiNzg4M2MtMTU5My00YzVjLTg2MTgtOGRmM2Y2MjNiMTliBFR5cGUNU3lzdGVtLlN0cmluZwsAAABTeXN0ZW0uR3VpZAdWZXJzaW9uDFN5c3RlbS5JbnQzMgQAAAABAAAADFNvdXJjZUFuY2hvcgAAAAACAAAADVN5c3RlbS5TdHJpbmcOAAAAT25FbnRlclRyaWdnZXIEVHlwZQ1TeXN0ZW0uU3RyaW5nDQAAAFN5c3RlbS5TdHJpbmcHVmVyc2lvbgxTeXN0ZW0uSW50MzIEAAAAAQAAAA9EZXN0aW5hdGlvbkd1aWQAAAAAAgAAAA1TeXN0ZW0uU3RyaW5nJAAAADIyMjkxNjE5LWQ5OTEtNDZhNS04NzdiLTY0YjExOTYzY2QwMQRUeXBlDVN5c3RlbS5TdHJpbmcLAAAAU3lzdGVtLkd1aWQHVmVyc2lvbgxTeXN0ZW0uSW50MzIEAAAAAQAAABFEZXN0aW5hdGlvbkFuY2hvcgAAAAACAAAADVN5c3RlbS5TdHJpbmcCAAAASW4EVHlwZQ1TeXN0ZW0uU3RyaW5nDQAAAFN5c3RlbS5TdHJpbmcHVmVyc2lvbgxTeXN0ZW0uSW50MzIEAAAAAQAAAAVJdGVtMgcAAAACAAAAAARUeXBlDVN5c3RlbS5TdHJpbmclAAAARGV0b3guRGF0YS5TY3JpcHRFZGl0b3IuTG9naWNOb2RlRGF0YQdWZXJzaW9uDFN5c3RlbS5JbnQzMgQAAAACAAAABEJhc2UFAAAAAgAAAAAEVHlwZQ1TeXN0ZW0uU3RyaW5nJgAAAERldG94LkRhdGEuU2NyaXB0RWRpdG9yLkVudGl0eU5vZGVEYXRhB1ZlcnNpb24MU3lzdGVtLkludDMyBAAAAAIAAAAER3VpZAAAAAACAAAADVN5c3RlbS5TdHJpbmckAAAAMjIyOTE2MTktZDk5MS00NmE1LTg3N2ItNjRiMTE5NjNjZDAxBFR5cGUNU3lzdGVtLlN0cmluZwsAAABTeXN0ZW0uR3VpZAdWZXJzaW9uDFN5c3RlbS5JbnQzMgQAAAABAAAAAVgAAAAAAgAAAAxTeXN0ZW0uSW50MzIEAAAAkAgAAARUeXBlDVN5c3RlbS5TdHJpbmcMAAAAU3lzdGVtLkludDMyB1ZlcnNpb24MU3lzdGVtLkludDMyBAAAAAEAAAABWQAAAAACAAAADFN5c3RlbS5JbnQzMgQAAACPBwAABFR5cGUNU3lzdGVtLlN0cmluZwwAAABTeXN0ZW0uSW50MzIHVmVyc2lvbgxTeXN0ZW0uSW50MzIEAAAAAQAAAAtTaG93Q29tbWVudAAAAAACAAAADVN5c3RlbS5CeXRlW10nAAAADFNob3cgQ29tbWVudAxTaG93IENvbW1lbnQFZmFsc2UEQm9vbAEABFR5cGUNU3lzdGVtLlN0cmluZyEAAABEZXRveC5EYXRhLlNjcmlwdEVkaXRvci5QYXJhbWV0ZXIHVmVyc2lvbgxTeXN0ZW0uSW50MzIEAAAAAgAAAAdDb21tZW50AAAAAAIAAAANU3lzdGVtLkJ5dGVbXRoAAAAHQ29tbWVudAdDb21tZW50AAZTdHJpbmcBAARUeXBlDVN5c3RlbS5TdHJpbmchAAAARGV0b3guRGF0YS5TY3JpcHRFZGl0b3IuUGFyYW1ldGVyB1ZlcnNpb24MU3lzdGVtLkludDMyBAAAAAIAAAAEVHlwZQAAAAACAAAADVN5c3RlbS5TdHJpbmcOAAAAdVNjcmlwdEFjdF9Mb2cEVHlwZQ1TeXN0ZW0uU3RyaW5nDQAAAFN5c3RlbS5TdHJpbmcHVmVyc2lvbgxTeXN0ZW0uSW50MzIEAAAAAQAAAAxGcmllbmRseU5hbWUAAAAAAgAAAA1TeXN0ZW0uU3RyaW5nAwAAAExvZwRUeXBlDVN5c3RlbS5TdHJpbmcNAAAAU3lzdGVtLlN0cmluZwdWZXJzaW9uDFN5c3RlbS5JbnQzMgQAAAABAAAABklucHV0cwAAAAACAAAADVN5c3RlbS5CeXRlW10KAAAAAQAAAAJJbgJJbgRUeXBlDVN5c3RlbS5TdHJpbmceAAAARGV0b3guRGF0YS5TY3JpcHRFZGl0b3IuUGx1Z1tdB1ZlcnNpb24MU3lzdGVtLkludDMyBAAAAAEAAAAHT3V0cHV0cwAAAAACAAAADVN5c3RlbS5CeXRlW10MAAAAAQAAAANPdXQDT3V0BFR5cGUNU3lzdGVtLlN0cmluZx4AAABEZXRveC5EYXRhLlNjcmlwdEVkaXRvci5QbHVnW10HVmVyc2lvbgxTeXN0ZW0uSW50MzIEAAAAAQAAAAZFdmVudHMAAAAAAgAAAA1TeXN0ZW0uQnl0ZVtdBAAAAAAAAAAEVHlwZQ1TeXN0ZW0uU3RyaW5nHgAAAERldG94LkRhdGEuU2NyaXB0RWRpdG9yLlBsdWdbXQdWZXJzaW9uDFN5c3RlbS5JbnQzMgQAAAABAAAAClBhcmFtZXRlcnMAAAAAAgAAAA1TeXN0ZW0uQnl0ZVtdcwAAAAMAAAAGUHJlZml4BlByZWZpeA5UcmlnZ2VyIEZpcmVkIQ1TeXN0ZW0uU3RyaW5nAQAGVGFyZ2V0BlRhcmdldAAPU3lzdGVtLk9iamVjdFtdAQAHUG9zdGZpeAdQb3N0Zml4AA1TeXN0ZW0uU3RyaW5nAQAEVHlwZQ1TeXN0ZW0uU3RyaW5nIwAAAERldG94LkRhdGEuU2NyaXB0RWRpdG9yLlBhcmFtZXRlcltdB1ZlcnNpb24MU3lzdGVtLkludDMyBAAAAAIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=
END BASE64]]*/