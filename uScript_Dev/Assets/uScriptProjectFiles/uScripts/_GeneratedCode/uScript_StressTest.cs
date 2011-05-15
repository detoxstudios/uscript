//uScript Generated Code - Build 0.3.110514a
using UnityEngine;
using System.Collections;

public class uScript_StressTest : uScriptCode
{
   #pragma warning disable 414
   uScript_StressTest_Nested uScript; 
   #pragma warning restore 414
   
   void Awake( )
   {
      uScript = ScriptableObject.CreateInstance(typeof(uScript_StressTest_Nested)) as uScript_StressTest_Nested;
      uScript.SetParent( this.gameObject );
   }
   void Update( )
   {
      uScript.Update( );
   }
   void LateUpdate( )
   {
      uScript.LateUpdate( );
   }
   void FixedUpdate( )
   {
      uScript.FixedUpdate( );
   }
   void OnGUI( )
   {
      uScript.OnGUI( );
   }
   #if UNITY_EDITOR
      void OnDrawGizmos( )
      {
         GameObject gameObject;
         
         gameObject = GameObject.Find( "_uScript" ); 
         if ( null != gameObject ) Gizmos.DrawIcon(gameObject.transform.position, "uscript_gizmo_events.png");
         
      }
   #endif
}
