//uScript Generated Code - Build 0.9.1613
using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/Graphs/uScript_StressTest")]
public class uScript_StressTest_Component : uScriptCode
{
   #pragma warning disable 414
   public uScript_StressTest uScript = new uScript_StressTest( ); 
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
   void OnDestroy( )
   {
      uScript.OnDestroy( );
   }
   #if UNITY_EDITOR
      void OnDrawGizmos( )
      {
      }
   #endif
}
