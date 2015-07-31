// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Assets")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Loads an AudioClip")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Load AudioClip", "Loads an AudioClip file from your Resources directory.")]
public class uScriptAct_LoadAudioClip : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Asset Path", "The AudioClip file to load.  The supported file formats are: \"aif\", \"wav\", \"mp3\", \"ogg\", \"xm\", \"mod\", \"it\", and \"s3m\".")]
      [AssetPathField(AssetType.AudioClip)]
      string name,

      [FriendlyName("Loaded Asset", "The AudioClip loaded from the specified file path.")]
      out AudioClip audioClip
   )
   {
      audioClip = Resources.Load(name) as AudioClip;

      if ( null == audioClip )
      {
         uScriptDebug.Log( "Asset " + name + " couldn't be loaded, are you sure it's in a Resources folder?", uScriptDebug.Type.Warning );
      }
   }

   
#if UNITY_EDITOR
   public override Hashtable EditorDragDrop( object o )
   {
      if ( typeof( AudioClip ).IsAssignableFrom( o.GetType() ) )
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
