//uScript Generated Code - Build 1.0.3055
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This is the component script that you should assign to GameObjects to use this graph on them. Use the uScript/Graphs section of Unity's "Component" menu to assign this graph to a selected GameObject.

[AddComponentMenu("uScript/Graphs/CoinCollection_GameplayGlobals")]
public class CoinCollection_GameplayGlobals_Component : uScriptCode
{
   #pragma warning disable 414
   public CoinCollection_GameplayGlobals ExposedVariables = new CoinCollection_GameplayGlobals( ); 
   #pragma warning restore 414
   
   public System.Int32 CoinPointsGold { get { return ExposedVariables.CoinPointsGold; } set { ExposedVariables.CoinPointsGold = value; } } 
   public System.Int32 CoinPointsSilver { get { return ExposedVariables.CoinPointsSilver; } set { ExposedVariables.CoinPointsSilver = value; } } 
   public UnityEngine.GameObject Player { get { return ExposedVariables.Player; } set { ExposedVariables.Player = value; } } 
   public UnityEngine.AudioClip CoinAudioSilver { get { return ExposedVariables.CoinAudioSilver; } set { ExposedVariables.CoinAudioSilver = value; } } 
   public UnityEngine.AudioClip CoinAudioGold { get { return ExposedVariables.CoinAudioGold; } set { ExposedVariables.CoinAudioGold = value; } } 
   public UnityEngine.AudioClip JumpAudio { get { return ExposedVariables.JumpAudio; } set { ExposedVariables.JumpAudio = value; } } 
   
   void Awake( )
   {
      #if !(UNITY_FLASH)
      useGUILayout = false;
      #endif
      ExposedVariables.Awake( );
      ExposedVariables.SetParent( this.gameObject );
      if ( "1.CMR" != uScript_MasterComponent.Version )
      {
         uScriptDebug.Log( "The generated code is not compatible with your current uScript Runtime " + uScript_MasterComponent.Version, uScriptDebug.Type.Error );
         ExposedVariables = null;
         UnityEngine.Debug.Break();
      }
   }
   void Start( )
   {
      ExposedVariables.Start( );
   }
   void OnEnable( )
   {
      ExposedVariables.OnEnable( );
   }
   void OnDisable( )
   {
      ExposedVariables.OnDisable( );
   }
   void Update( )
   {
      ExposedVariables.Update( );
   }
   void OnDestroy( )
   {
      ExposedVariables.OnDestroy( );
   }
   #if UNITY_EDITOR
      void OnDrawGizmos( )
      {
      }
   #endif
}
