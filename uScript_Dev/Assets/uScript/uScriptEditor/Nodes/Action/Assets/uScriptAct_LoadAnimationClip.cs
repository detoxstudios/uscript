// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Loads an AnimationClip from your Resources directory.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Assets")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Loads an AnimationClip")]
[NodeDescription("Loads an AnimationClip from your Resources directory.\n \nAnimation Clip: The audio file to load. \nLoaded AnimationClip (out): The AnimationClip loaded from the specified file.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Load AnimationClip")]
public class uScriptAct_LoadAnimationClip : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Animation Clip")]
      string name,
      [FriendlyName("Loaded AnimationClip")]
      out AnimationClip animationClip
   )
   {
      animationClip = Resources.Load(name) as AnimationClip;

      if (null == animationClip) 
      {
         uScriptDebug.Log("AnimationClip " + name + " couldn't be loaded, are you sure it's in a Resources folder?", uScriptDebug.Type.Warning);
      }
   }

   
#if UNITY_EDITOR
   public override Hashtable EditorDragDrop( object o )
   {
      if (typeof(AnimationClip).IsAssignableFrom(o.GetType()))
      {
         AnimationClip ac = (AnimationClip)o;

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