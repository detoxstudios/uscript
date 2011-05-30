//uScript Generated Code - Build 0.4.110530a
using UnityEngine;
using System.Collections;

public class uScript_StressTest_Component : uScriptCode
{
   #pragma warning disable 414
   uScript_StressTest uScript; 
   #pragma warning restore 414
   
   void Awake( )
   {
      uScript = ScriptableObject.CreateInstance(typeof(uScript_StressTest)) as uScript_StressTest;
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
