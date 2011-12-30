//uScript Generated Code - Build 0.9.1556
using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/Graphs/uScript_TestBed")]
public class uScript_TestBed_Component : uScriptCode
{
   #pragma warning disable 414
   public uScript_TestBed uScript = new uScript_TestBed( ); 
   #pragma warning restore 414
   
   
   void Awake( )
   {
      useGUILayout = false;
      uScript.Awake( );
      uScript.SetParent( this.gameObject );
      if ( "1.CMR" != uScript_MasterComponent.Version )
      {
         uScriptDebug.Log( "The generated code is not compatible with your current uScript Runtime " + uScript_MasterComponent.Version, uScriptDebug.Type.Error );
         uScript = null;
         UnityEngine.Debug.Break();
      }
   }
   void Start( )
   {
      uScript.Start( );
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
