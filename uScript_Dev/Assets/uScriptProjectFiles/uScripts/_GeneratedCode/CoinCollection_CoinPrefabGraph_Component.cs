//uScript Generated Code - Build 1.0.2740
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This is the component script that you should assign to GameObjects to use this graph on them. Use the uScript/Graphs section of Unity's "Component" menu to assign this graph to a selected GameObject.

[AddComponentMenu("uScript/Graphs/CoinCollection_CoinPrefabGraph")]
public class CoinCollection_CoinPrefabGraph_Component : uScriptCode
{
   #pragma warning disable 414
   public CoinCollection_CoinPrefabGraph PublicVariables = new CoinCollection_CoinPrefabGraph( ); 
   #pragma warning restore 414
   
   
   void Awake( )
   {
      #if !(UNITY_FLASH)
      useGUILayout = false;
      #endif
      PublicVariables.Awake( );
      PublicVariables.SetParent( this.gameObject );
      if ( "1.CMR" != uScript_MasterComponent.Version )
      {
         uScriptDebug.Log( "The generated code is not compatible with your current uScript Runtime " + uScript_MasterComponent.Version, uScriptDebug.Type.Error );
         PublicVariables = null;
         UnityEngine.Debug.Break();
      }
   }
   void Start( )
   {
      PublicVariables.Start( );
   }
   void OnEnable( )
   {
      PublicVariables.OnEnable( );
   }
   void OnDisable( )
   {
      PublicVariables.OnDisable( );
   }
   void Update( )
   {
      PublicVariables.Update( );
   }
   void OnDestroy( )
   {
      PublicVariables.OnDestroy( );
   }
   #if UNITY_EDITOR
      void OnDrawGizmos( )
      {
      }
   #endif
}
