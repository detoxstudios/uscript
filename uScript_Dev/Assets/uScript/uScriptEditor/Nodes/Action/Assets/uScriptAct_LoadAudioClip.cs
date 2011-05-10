// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Counts the amount of time that elapses between starting and stopping.

using UnityEngine;
using System.Collections;

[NodePath("Action/Audio")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Loads an AudioClip")]
[NodeDescription("Loads an AudioClip from your Resources directory.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Load AudioClip")]
public class uScriptAct_LoadAudioClip : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Audio Clip")]
      string name, 
      [FriendlyName("Loaded AudioClip")]
      out AudioClip audioClip
   )
   {
      audioClip = Resources.Load( name ) as AudioClip;
    
      if ( null == audioClip ) 
      {
         uScriptDebug.Log( "AudioClip " + name + " couldn't be loaded, are you sure it's in a Resources folder?", uScriptDebug.Type.Warning );
      }
   }

   
#if UNITY_EDITOR
   public override Hashtable EditorDragDrop( object o )
   {
      if ( typeof(AudioClip).IsAssignableFrom(o.GetType()) )
      {
         AudioClip ac = (AudioClip) o;

         string path = UnityEditor.AssetDatabase.GetAssetPath( ac.GetInstanceID( ) );

         int index = path.IndexOf( "Resources/" );
         
         if ( index > 0 )
         {
            path = path.Substring( index + "Resources/".Length );

            int dot = path.LastIndexOf( '.' );
            if ( dot >= 0 ) path = path.Substring( 0, dot );

            Hashtable hashtable = new Hashtable( );
            hashtable[ "name" ] = path;

            return hashtable;
         }
      }

      return null;
   }
#endif
}