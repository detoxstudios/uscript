// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Assets")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Loads a TextAsset")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Load TextAsset", "Loads a TextAsset file from your Resources directory. Binary files can be loaded as a TextAsset, but they must use the \"bytes\" file extension.")]
public class uScriptAct_LoadTextAsset : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Asset Path", "The TextAsset file to load.  The supported text formats are: \"txt\", \"htm\", \"html\", \"xml\", and \"bytes\".")]
      [AssetPathField(AssetType.TextAsset)]
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