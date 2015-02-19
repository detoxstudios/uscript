//uScript Generated Code - Build 1.0.2740
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This is the component script that you should assign to GameObjects to use this graph on them. Use the uScript/Graphs section of Unity's "Component" menu to assign this graph to a selected GameObject.

[AddComponentMenu("uScript/Graphs/AlarmGameplay_MainGame")]
public class AlarmGameplay_MainGame_Component : uScriptCode
{
   #pragma warning disable 414
   public AlarmGameplay_MainGame PublicVariables = new AlarmGameplay_MainGame( ); 
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
   void OnGUI( )
   {
      PublicVariables.OnGUI( );
   }
   #if UNITY_EDITOR
      void OnDrawGizmos( )
      {
         {
            GameObject gameObject;
            gameObject = GameObject.Find( "Trigger_Console" ); 
            if ( null != gameObject ) Gizmos.DrawIcon(gameObject.transform.position, "uscript_gizmo_events.png");
         }
         {
            GameObject gameObject;
            gameObject = GameObject.Find( "Trigger_Alarm" ); 
            if ( null != gameObject ) Gizmos.DrawIcon(gameObject.transform.position, "uscript_gizmo_events.png");
         }
      }
   #endif
}
