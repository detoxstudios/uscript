// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Play the specified animation on the target object. Animation must exist in the GameObject's AnimationClip.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Level")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Loads a level.")]
[NodeDescription("Loads a level.\n \nLevel Name: The level to load (make sure it's been added to Unity through File->Build Settings...).\n" +
                 "Unload Others: Whether or not to destroy the other objects in the scene.\n" + 
                 "Block Until Loaded: Halt execution of the game until the level has loaded.  (Requires Unity Pro if set to false).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Load Level")]
public class uScriptAct_LoadLevel : uScriptLogic
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   public bool Out { get { return true; } }
   
   [FriendlyName("Loaded")]
   public event uScriptEventHandler Loaded;

   private bool m_IsLoading;
   private AsyncOperation m_Async;

   public void In(
      [FriendlyName("Level Name")]
      string name,       

      [FriendlyName("Unload Others")]
      [DefaultValue(true)]
      bool destroyOtherObjects, 
      
      [FriendlyName("Block Until Loaded")]
      [DefaultValue(true)]
      bool blockUntilLoaded
   )
   {
      if ( true == blockUntilLoaded )
      {
         if ( true == destroyOtherObjects )
         {
            Application.LoadLevel(name);
         }
         else
         {
            Application.LoadLevelAdditive(name);
         }
      }
      else
      {
         m_IsLoading = true;

         if ( true == destroyOtherObjects )
         {
            m_Async = Application.LoadLevelAsync(name);
         }
         else
         {
            m_Async = Application.LoadLevelAdditiveAsync(name);
         }
      }
   }

   public override void Update()
   {
      if ( true == m_IsLoading && true == m_Async.isDone )
      {
         m_IsLoading = false;
         if ( null != Loaded ) Loaded( this, System.EventArgs.Empty );
      }
   }


#if UNITY_EDITOR
   public override Hashtable EditorDragDrop(object o)
   {
      return null;
   }
#endif



}