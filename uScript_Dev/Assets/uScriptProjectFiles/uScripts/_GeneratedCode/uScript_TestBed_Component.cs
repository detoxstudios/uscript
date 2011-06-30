//uScript Generated Code - Build 0.6.0905
using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/Graphs/uScript_TestBed")]
public class uScript_TestBed_Component : uScriptCode
{
   #pragma warning disable 414
   uScript_TestBed uScript; 
   #pragma warning restore 414
   
   void Awake( )
   {
      uScript = ScriptableObject.CreateInstance(typeof(uScript_TestBed)) as uScript_TestBed;
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
