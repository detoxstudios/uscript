// uScript Action Node
// (C) 2011 Detox Studios LLC

#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2
using UnityEngine;
using System.Collections;

[NodePath("Actions/Assets")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip("Loads a PhysicMaterial2D file.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Load PhysicMaterial2D", "Loads a PhysicMaterial2D file from your Resources directory.")]
public class uScriptAct_LoadPhysicMaterial2D : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Asset Path", "The PhysicMaterial2D file to load.  The supported file format is: \".physicMaterial2D\".")]
      [AssetPathField(AssetType.PhysicMaterial)]
      string name,

      [FriendlyName("Loaded Asset", "The PhysicMaterial2D loaded from the specified file path.")]
      out PhysicsMaterial2D asset
   )
   {
      asset = Resources.Load(name) as PhysicsMaterial2D;

      if ( null == asset )
      {
         uScriptDebug.Log( "Asset " + name + " couldn't be loaded, are you sure it's in a Resources folder?", uScriptDebug.Type.Warning );
      }
   }

   
#if UNITY_EDITOR
   public override Hashtable EditorDragDrop( object o )
   {
      if (typeof(PhysicsMaterial2D).IsAssignableFrom(o.GetType()))
      {
         PhysicsMaterial2D ac = (PhysicsMaterial2D)o;

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