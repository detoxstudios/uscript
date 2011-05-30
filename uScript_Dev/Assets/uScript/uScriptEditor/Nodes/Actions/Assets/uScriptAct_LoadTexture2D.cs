// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Loads a Texture from your Resources directory.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Assets")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Loads an image file into a Texture2D")]
[NodeDescription("Loads an image file into a Texture2D variable from your Resources directory.\n \nName: The texture file to load. \nLoaded Texture (out): The texture loaded from the specified file name.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Load Texture2D")]
public class uScriptAct_LoadTexture2D : uScriptLogic
{
   
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Name")]
      string name,
      [FriendlyName("Loaded Texture2D")]
      out Texture2D textureFile
   )
   {

      textureFile = Resources.Load(name) as Texture2D;

      if (null == textureFile) 
      {
         uScriptDebug.Log("Texture " + name + " couldn't be loaded, are you sure it's in a Resources folder?", uScriptDebug.Type.Warning);
      }
   }

   
#if UNITY_EDITOR
   public override Hashtable EditorDragDrop( object o )
   {
      if (typeof(Texture2D).IsAssignableFrom(o.GetType()))
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