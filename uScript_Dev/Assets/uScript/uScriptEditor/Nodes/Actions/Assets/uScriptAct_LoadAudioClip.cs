// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Loads an AudioClip from your Resources directory.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Assets")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Loads an AudioClip")]
[NodeDescription("Loads an AudioClip from your Resources directory.\n \nAudio Clip: The audio file to load. \nLoaded AudioClip (out): The AudioClip loaded from the specified file.")]
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