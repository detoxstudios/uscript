//uScript Generated Code - Build 1.0.2740
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This is the component script that you should assign to GameObjects to use this graph on them. Use the uScript/Graphs section of Unity's "Component" menu to assign this graph to a selected GameObject.

[AddComponentMenu("uScript/Graphs/FireBot_Gameplay")]
public class FireBot_Gameplay_Component : uScriptCode
{
   #pragma warning disable 414
   public FireBot_Gameplay PublicVariables = new FireBot_Gameplay( ); 
   #pragma warning restore 414
   
   public System.Single BotTurnPerSecond { get { return PublicVariables.BotTurnPerSecond; } set { PublicVariables.BotTurnPerSecond = value; } } 
   public System.Single BotSpeedPerSecond { get { return PublicVariables.BotSpeedPerSecond; } set { PublicVariables.BotSpeedPerSecond = value; } } 
   
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
   void OnGUI( )
   {
      PublicVariables.OnGUI( );
   }
   #if UNITY_EDITOR
      void OnDrawGizmos( )
      {
         {
            GameObject gameObject;
            gameObject = GameObject.Find( "FireBot" ); 
            if ( null != gameObject ) Gizmos.DrawIcon(gameObject.transform.position, "uscript_gizmo_variables.png");
         }
         {
            GameObject gameObject;
            gameObject = GameObject.Find( "Main Camera" ); 
            if ( null != gameObject ) Gizmos.DrawIcon(gameObject.transform.position, "uscript_gizmo_variables.png");
         }
         {
            GameObject gameObject;
            gameObject = GameObject.Find( "MuzzleEnd" ); 
            if ( null != gameObject ) Gizmos.DrawIcon(gameObject.transform.position, "uscript_gizmo_variables.png");
         }
         {
            GameObject gameObject;
            gameObject = GameObject.Find( "KillTrigger" ); 
            if ( null != gameObject ) Gizmos.DrawIcon(gameObject.transform.position, "uscript_gizmo_events.png");
         }
      }
   #endif
}
