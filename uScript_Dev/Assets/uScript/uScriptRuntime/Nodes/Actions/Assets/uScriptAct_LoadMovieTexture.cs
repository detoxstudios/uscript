// uScript Action Node
// (C) 2011 Detox Studios LLC

#if (UNITY_ANDROID || UNITY_IPHONE || UNITY_FLASH || UNITY_PS4)

   // This node is not supported on these platforms at this time. This compiler directive is needed for the project to compile for these devices without error.

#else

using UnityEngine;
using System.Collections;
#if (UNITY_2017 || UNITY_2017_1_OR_NEWER)
using UnityEngine.Video;
#endif

[NodePath("Actions/Assets")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Loads a MovieTexture")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Load MovieTexture", "Loads a MovieTexture file from your Resources directory.")]
public class uScriptAct_LoadMovieTexture : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Asset Path", "The MovieTexture file to load.  Supported file types are what your QuickTime installation can play (usually \"mov\", \"mpg\", \"mpeg\", \"mp4\", \"avi\", and \"asf\").\n\nWhen a video file is added to your Project, it will automatically be imported and converted to Ogg Theora format, therefore \"ogg\" files can also be loaded directly.")]
      [AssetPathField(AssetType.MovieTexture)]
      string name,

#if (UNITY_2017 || UNITY_2017_1_OR_NEWER)
      [FriendlyName("Loaded Asset", "The VideoPlayer loaded from the specified file path.")]
      out VideoPlayer textureFile
#else
      [FriendlyName("Loaded Asset", "The MovieTexture loaded from the specified file path.")]
      out MovieTexture textureFile
#endif
   )
   {
#if (UNITY_2017 || UNITY_2017_1_OR_NEWER)
      textureFile = Resources.Load(name) as VideoPlayer;
#else
      textureFile = Resources.Load(name) as MovieTexture;
#endif

        if ( null == textureFile )
      {
         uScriptDebug.Log( "Asset " + name + " couldn't be loaded, are you sure it's in a Resources folder?", uScriptDebug.Type.Warning );
      }
   }

   
#if UNITY_EDITOR
   public override Hashtable EditorDragDrop( object o )
   {
#if (UNITY_2017 || UNITY_2017_1_OR_NEWER)
      if ( typeof(VideoPlayer).IsAssignableFrom( o.GetType() ) )
      {
         VideoPlayer ac = (VideoPlayer)o;
#else
      if ( typeof(MovieTexture).IsAssignableFrom( o.GetType() ) )
      {
         MovieTexture ac = (MovieTexture)o;
#endif

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
#endif
