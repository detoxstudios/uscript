//uScript Generated Code - Build 0.9.1613
using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/Graphs/FadeGraph")]
public class FadeGraph_Component : uScriptCode
{
   #pragma warning disable 414
   public FadeGraph uScript = new FadeGraph( ); 
   #pragma warning restore 414
   
   public UnityEngine.Material FadeMaterial { get { return uScript.FadeMaterial; } set { uScript.FadeMaterial = value; } } 
   
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
   void OnGUI( )
   {
      uScript.OnGUI( );
   }
   #if UNITY_EDITOR
      void OnDrawGizmos( )
      {
         {
            GameObject gameObject;
            gameObject = GameObject.Find( "FadePlane" ); 
            if ( null != gameObject ) Gizmos.DrawIcon(gameObject.transform.position, "uscript_gizmo_variables.png");
         }
      }
   #endif
}
