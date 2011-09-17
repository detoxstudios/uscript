// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Loads a MovieTexture from your Resources directory.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Assets")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Loads a MovieTexture")]
[NodeDescription("Loads a MovieTexture file from your Resources directory.\n\nAsset Path: The MovieTexture file to load.  The supported file formats are: \"mov\", \"mpg\", \"mpeg\", \"mp4\", \"avi\", and \"asf\".\n\nLoaded Asset (out): The MovieTexture loaded from the specified file.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Load_MovieTexture")]

[FriendlyName("Load MovieTexture", "Loads a MovieTexture file from your Resources directory.")]
public class uScriptAct_LoadMovieTexture : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [AssetPathField(AssetType.MovieTexture)]
      [FriendlyName("Asset Path", "The MovieTexture file to load.  The supported file formats are: \"mov\", \"mpg\", \"mpeg\", \"mp4\", \"avi\", and \"asf\".")]
      string name,
      [FriendlyName("Loaded Asset", "The MovieTexture loaded from the specified file path.")]
      out MovieTexture asset
   )
   {
      asset = Resources.Load(name) as MovieTexture;

      if ( null == asset )
      {
         uScriptDebug.Log( "Asset " + name + " couldn't be loaded, are you sure it's in a Resources folder?", uScriptDebug.Type.Warning );
      }
   }

   
#if UNITY_EDITOR
   public override Hashtable EditorDragDrop( object o )
   {
      if ( typeof(MovieTexture).IsAssignableFrom( o.GetType() ) )
      {
         MovieTexture ac = (MovieTexture)o;

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
