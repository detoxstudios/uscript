// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Loads a Texture from your Resources directory.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Assets")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Loads an image file into a Texture2D")]
[NodeDescription("Loads an image file into a Texture2D variable from your Resources directory.\n \nName: The texture file to load. \nLoaded Material (out): The material loaded from the specified file name.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Load_Material")]

[FriendlyName("Load Material")]
public class uScriptAct_LoadMaterial : uScriptLogic
{
   
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Name")]
      string name,
      [FriendlyName("Loaded Material")]
      out Material materialFile
   )
   {

      materialFile = Resources.Load(name) as Material;

      if (null == materialFile) 
      {
         uScriptDebug.Log("Material " + name + " couldn't be loaded, are you sure it's in a Resources folder?", uScriptDebug.Type.Warning);
      }
   }

   
#if UNITY_EDITOR
   public override Hashtable EditorDragDrop( object o )
   {
      if (typeof(Material).IsAssignableFrom(o.GetType()))
      {
         Material ac = (Material)o;

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