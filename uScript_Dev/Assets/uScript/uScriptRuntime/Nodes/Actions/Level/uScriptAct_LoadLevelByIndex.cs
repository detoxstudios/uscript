// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Level")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Loads a level by its index value as defined in Unity's Build Settings.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Load Level By Index", "Loads a level by its index value as defined in Unity's Build Settings.")]
public class uScriptAct_LoadLevelByIndex : uScriptLogic
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   public bool Out { get { return true; } }
   
   [FriendlyName("Loaded")]
   public event uScriptEventHandler Loaded;

   private bool m_IsLoading;
   private AsyncOperation m_Async;

   public void In(
      [FriendlyName("Level Index", "The level index to load (make sure it's been added to Unity through File->Build Settings...).")] int index,
      
      [FriendlyName("Unload Others", "Whether or not to destroy the other objects in the scene.")]
      [DefaultValue(true), SocketState(false, false)]
      bool destroyOtherObjects,

      [FriendlyName("Block Until Loaded", "Halt execution of the game until the level has loaded.  (Requires Unity Pro if set to false).")]
      [DefaultValue(true), SocketState(false, false)]
      bool blockUntilLoaded
      )
   {
      if ( true == blockUntilLoaded )
      {
         if ( true == destroyOtherObjects )
         {
            #if (UNITY_3_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2)
               Application.LoadLevel(index);
            #else
               UnityEngine.SceneManagement.SceneManager.LoadScene(index);
            #endif
         }
         else
         {
            #if (UNITY_3_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2)
               Application.LoadLevelAdditive(index);
            #else
               UnityEngine.SceneManagement.SceneManager.LoadScene(index, UnityEngine.SceneManagement.LoadSceneMode.Additive);
            #endif
         }

         if ( null != Loaded ) Loaded( this, System.EventArgs.Empty );
      }
      else
      {
         m_IsLoading = true;

         if ( true == destroyOtherObjects )
         {
            #if (UNITY_3_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2)
               m_Async = Application.LoadLevelAsync(index);
            #else
               m_Async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(index);
            #endif
         }
         else
         {
            #if (UNITY_3_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2)
               m_Async = Application.LoadLevelAdditiveAsync(index);
            #else
               m_Async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(index, UnityEngine.SceneManagement.LoadSceneMode.Additive);
            #endif
         }
      }
   }

   public void Update()
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
