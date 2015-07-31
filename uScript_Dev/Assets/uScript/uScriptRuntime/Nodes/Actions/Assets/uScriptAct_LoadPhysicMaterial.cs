// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Assets")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Loads a PhysicMaterial")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Load PhysicMaterial", "Loads a PhysicMaterial file from your Resources directory.")]
public class uScriptAct_LoadPhysicMaterial : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Asset Path", "The PhysicMaterial file to load.  The supported file format is: \"physicMaterial\".")]
      [AssetPathField(AssetType.PhysicMaterial)]
      string name,

      [FriendlyName("Loaded Asset", "The PhysicMaterial loaded from the specified file path.")]
      out PhysicMaterial asset
   )
   {
      asset = Resources.Load(name) as PhysicMaterial;

      if ( null == asset )
      {
         uScriptDebug.Log( "Asset " + name + " couldn't be loaded, are you sure it's in a Resources folder?", uScriptDebug.Type.Warning );
      }
   }

   
#if UNITY_EDITOR
   public override Hashtable EditorDragDrop( object o )
   {
      if ( typeof(PhysicMaterial).IsAssignableFrom( o.GetType() ) )
      {
         PhysicMaterial ac = (PhysicMaterial)o;

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