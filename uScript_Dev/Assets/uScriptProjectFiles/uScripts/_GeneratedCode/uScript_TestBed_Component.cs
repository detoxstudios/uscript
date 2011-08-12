//uScript Generated Code - Build 0.9.1104
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
      useGUILayout = false;
      uScript = ScriptableObject.CreateInstance(typeof(uScript_TestBed)) as uScript_TestBed;
      uScript.SetParent( this.gameObject );
   }
   void Update( )
   {
      uScript.Update( );
   }
   #if UNITY_EDITOR
      void OnDrawGizmos( )
      {
      }
   #endif
}
