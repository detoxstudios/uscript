// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Assets")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Loads a Shader")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Load Shader", "Loads a Shader file from your Resources directory.")]
public class uScriptAct_LoadShader : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Asset Path", "The Shader file to load.  The supported file format is: \"shader\".")]
      [AssetPathField(AssetType.Shader)]
      string name,

      [FriendlyName("Loaded Asset", "The Shader loaded from the specified file path.")]
      out Shader asset
   )
   {
      asset = Resources.Load(name) as Shader;

      if ( null == asset )
      {
         uScriptDebug.Log( "Asset " + name + " couldn't be loaded, are you sure it's in a Resources folder?", uScriptDebug.Type.Warning );
      }
   }

   
#if UNITY_EDITOR
   public override Hashtable EditorDragDrop( object o )
   {
      if ( typeof(Shader).IsAssignableFrom( o.GetType() ) )
      {
         Shader ac = (Shader)o;

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