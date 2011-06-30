//uScript Generated Code - Build 0.6.0905
using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/Graphs/uScript_StressTest")]
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
   void Start( )
   {
      uScript.Start( );
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
      }
   #endif
}
