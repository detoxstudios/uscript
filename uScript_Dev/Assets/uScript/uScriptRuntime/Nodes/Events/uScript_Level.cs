// uScript uScript_Level.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

#if !(UNITY_3_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3)
using UnityEngine.SceneManagement;
#endif

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Game Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a level is finished loading.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Level Load", "Fires an event signal when a level is finished loading.")]

#if (UNITY_3_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3)
public class uScript_Level : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, LevelWasLoadedEventArgs args);

   public class LevelWasLoadedEventArgs : System.EventArgs
   {
      private int m_Level;
      
      [FriendlyName("Level Index", "The index of the level that was loaded.")]
      public int Level { get { return m_Level; } }

      public LevelWasLoadedEventArgs(int level)
      {
         m_Level = level;
      }
   }

   [FriendlyName("On Level Was Loaded")]
   public event uScriptEventHandler LevelWasLoaded;

   void OnLevelWasLoaded(int level)
   {
      if ( LevelWasLoaded != null ) LevelWasLoaded(this, new LevelWasLoadedEventArgs(level));
   }
}
#else

public class uScript_Level : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, LevelWasLoadedEventArgs args);

   [FriendlyName("On Level Was Loaded")]
   public event uScriptEventHandler LevelWasLoaded;

   public class LevelWasLoadedEventArgs : System.EventArgs
   {
      private Scene m_Scene;
      private LoadSceneMode m_Mode;
      
      [FriendlyName("Scene", "The Scene which was loaded.")]
      public Scene Scene { get { return m_Scene; } }

      [FriendlyName("Load Scene Mode", "How the scene was loaded; Additive or Single.")]
      public LoadSceneMode LoadSceneMode{ get { return m_Mode; } }

      public LevelWasLoadedEventArgs(Scene scene, LoadSceneMode mode)
      {
         m_Scene = scene;
         m_Mode = mode;
      }
   }

   void Start( )
   {
      SceneManager.sceneLoaded += SceneManager_sceneLoaded;
   }

   private void SceneManager_sceneLoaded( UnityEngine.SceneManagement.Scene arg0, UnityEngine.SceneManagement.LoadSceneMode arg1 )
   {
      if ( LevelWasLoaded != null )
         LevelWasLoaded( this, new LevelWasLoadedEventArgs( arg0, arg1 ) );
   }

}
#endif
