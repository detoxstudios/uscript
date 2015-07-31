// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Assets")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Loads a Texture2D")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Load Texture2D", "Loads a Texture2D file from your Resources directory.")]
public class uScriptAct_LoadTexture2D : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Asset Path", "The Texture2D file to load.  The supported file formats are: \"psd\", \"tiff\", \"jpg\", \"tga\", \"png\", \"gif\", \"bmp\", \"iff\", and \"pict\"")]
      [AssetPathField(AssetType.Texture2D)]
      string name,

      [FriendlyName("Loaded Asset", "The Texture2D loaded from the specified file path.")]
      out Texture2D textureFile
   )
   {
      textureFile = Resources.Load(name) as Texture2D;

      if ( null == textureFile )
      {
         uScriptDebug.Log( "Asset " + name + " couldn't be loaded, are you sure it's in a Resources folder?", uScriptDebug.Type.Warning );
      }
   }

   
#if UNITY_EDITOR
   public override Hashtable EditorDragDrop( object o )
   {
      if ( typeof(Texture2D).IsAssignableFrom( o.GetType() ) )
      {
         Texture2D ac = (Texture2D)o;

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