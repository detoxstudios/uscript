// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Loads a level by its index value as defined in Unity's Build Settings.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Level")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Loads a level by its index value as defined in Unity's Build Settings.")]
[NodeDescription("Loads a level by its index value as defined in Unity's Build Settings.\n \nLevel Index: The level index to load (make sure it's been added to Unity through File->Build Settings...).\n" +
                 "Unload Others: Whether or not to destroy the other objects in the scene.\n" + 
                 "Block Until Loaded: Halt execution of the game until the level has loaded.  (Requires Unity Pro if set to false).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Load Level By Index")]
public class uScriptAct_LoadLevelByIndex : uScriptLogic
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   public bool Out { get { return true; } }
   
   [FriendlyName("Loaded")]
   public event uScriptEventHandler Loaded;

   private bool m_IsLoading;
   private AsyncOperation m_Async;

   public void In(
      [FriendlyName("Level Index")] int index,       
      [FriendlyName("Unload Others"), DefaultValue(true), SocketState(false, false)] bool destroyOtherObjects,
      [FriendlyName("Block Until Loaded"), DefaultValue(true), SocketState(false, false)] bool blockUntilLoaded
   )
   {
      if ( true == blockUntilLoaded )
      {
         if ( true == destroyOtherObjects )
         {
            Application.LoadLevel(index);
         }
         else
         {
            Application.LoadLevelAdditive(index);
         }

         if ( null != Loaded ) Loaded( this, System.EventArgs.Empty );
      }
      else
      {
         m_IsLoading = true;

         if ( true == destroyOtherObjects )
         {
            m_Async = Application.LoadLevelAsync(index);
         }
         else
         {
            m_Async = Application.LoadLevelAdditiveAsync(index);
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