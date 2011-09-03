// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Loads a TextAsset from your Resources directory.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Assets")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Loads a TextAsset")]
[NodeDescription("Loads a TextAsset file from your Resources directory.  Binary files can be loaded as a TextAsset, but they must use the \"bytes\" file extension\n\nAsset Path: The TextAsset file to load.  The supported file formats are: \"txt\", \"htm\", \"html\", \"xml\", and \"bytes\".\n\nLoaded Asset (out): The TextAsset loaded from the specified file.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Load_TextAsset")]

[FriendlyName("Load TextAsset", "Loads a TextAsset file from your Resources directory.  Binary files can be loaded as a TextAsset, but they must use the \"bytes\" file extension.")]
public class uScriptAct_LoadTextAsset : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [AssetPathField(AssetType.TextAsset)]
      [FriendlyName("Asset Path", "The TextAsset file to load.  The supported text formats are: \"txt\", \"htm\", \"html\", \"xml\", and \"bytes\".")]
      string name,
      [FriendlyName("Loaded Asset", "The TextAsset loaded from the specified file path.")]
      out TextAsset asset
   )
   {
      asset = Resources.Load(name) as TextAsset;

      if ( null == asset )
      {
         uScriptDebug.Log( "Asset " + name + " couldn't be loaded, are you sure it's in a Resources folder?", uScriptDebug.Type.Warning );
      }
   }

   
#if UNITY_EDITOR
   public override Hashtable EditorDragDrop( object o )
   {
      if ( typeof(TextAsset).IsAssignableFrom( o.GetType() ) )
      {
         TextAsset ac = (TextAsset)o;

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