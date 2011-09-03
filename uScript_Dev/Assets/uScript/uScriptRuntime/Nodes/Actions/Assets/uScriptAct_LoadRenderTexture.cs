// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Loads a RenderTexture from your Resources directory.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Assets")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Loads a RenderTexture")]
[NodeDescription("Loads a RenderTexture file from your Resources directory.\n\nAsset Path: The RenderTexture file to load.  The supported file format is: \"renderTexture\".\n\nLoaded Asset (out): The RenderTexture loaded from the specified file path.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Load_RenderTexture")]

[FriendlyName("Load RenderTexture", "Loads a RenderTexture file from your Resources directory.")]
public class uScriptAct_LoadRenderTexture : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [AssetPathField(AssetType.RenderTexture)]
      [FriendlyName("Asset Path", "The RenderTexture file to load.  The supported file format is: \"renderTexture\".")]
      string name,
      [FriendlyName("Loaded Asset", "The RenderTexture loaded from the specified file path.")]
      out RenderTexture asset
   )
   {
      asset = Resources.Load(name) as RenderTexture;

      if ( null == asset )
      {
         uScriptDebug.Log( "Asset " + name + " couldn't be loaded, are you sure it's in a Resources folder?", uScriptDebug.Type.Warning );
      }
   }

   
#if UNITY_EDITOR
   public override Hashtable EditorDragDrop( object o )
   {
      if ( typeof(RenderTexture).IsAssignableFrom( o.GetType() ) )
      {
         RenderTexture ac = (RenderTexture)o;

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