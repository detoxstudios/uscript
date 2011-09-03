// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Loads a Flare from your Resources directory.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Assets")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Loads a Flare")]
[NodeDescription("Loads a Flare file from your Resources directory.\n\nAsset Path: The Flare file to load.  The supported file format is: \"flare\".\n\nLoaded Asset (out): The Flare loaded from the specified file path.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Load_Flare")]

[FriendlyName("Load Flare", "Loads a Flare file from your Resources directory.")]
public class uScriptAct_LoadFlare : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [AssetPathField(AssetType.Flare)]
      [FriendlyName("Asset Path", "The Flare file to load.  The supported file format is: \"flare\".")]
      string name,
      [FriendlyName("Loaded Asset", "The Flare loaded from the specified file path.")]
      out Flare asset
   )
   {
      asset = Resources.Load(name) as Flare;

      if ( null == asset )
      {
         uScriptDebug.Log( "Asset " + name + " couldn't be loaded, are you sure it's in a Resources folder?", uScriptDebug.Type.Warning );
      }
   }

   
#if UNITY_EDITOR
   public override Hashtable EditorDragDrop( object o )
   {
      if ( typeof(Flare).IsAssignableFrom( o.GetType() ) )
      {
         Flare ac = (Flare)o;

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