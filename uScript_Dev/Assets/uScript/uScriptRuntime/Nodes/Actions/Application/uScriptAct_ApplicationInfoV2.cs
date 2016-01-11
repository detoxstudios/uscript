// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

#if (!UNITY_3_5 && !UNITY_4_6 && !UNITY_4_7 && !UNITY_5_0 && !UNITY_5_1 && !UNITY_5_2)
[NodePath("Actions/Application")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Access to application run-time data.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Application Info", "This node allows access to application run-time data.")]
public class uScriptAct_ApplicationInfoV2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("levelCount", "The total number of levels available.")]
      [SocketState(false, false)]
      out int levelCount,

      [FriendlyName("loadedLevel", "The level index that was last loaded.")]
      [SocketState(false, false)]
      out int[] loadedLevels,

      [FriendlyName("loadedLevelName", "The name of the level that was last loaded.")]
      [SocketState(false, false)]
      out string[] loadedLevelNames,

      [FriendlyName("isEditor", "Are we running inside the Unity editor?")]
      [SocketState(false, false)]
      out bool isEditor,

      [FriendlyName("isPlaying", "Returns true when in any kind of player.")]
      [SocketState(false, false)]
      out bool isPlaying,

      [FriendlyName("isWebPlayer", "Are we running inside a web player?")]
      [SocketState(false, false)]
      out bool isWebPlayer,

      [FriendlyName("streamedBytes", "Returns the number of bytes that have been downloaded from the main unity web stream.")]
      [SocketState(false, false)]
      out int streamedBytes,

      [FriendlyName("platform", "Returns the platform the game is running (Read Only).")]
      [SocketState(false, false)]
      out RuntimePlatform platform,

      [FriendlyName("dataPath", "Contains the path to the game data folder (Read Only).")]
      [SocketState(false, false)]
      out string dataPath,

      [FriendlyName("persistentDataPath", "Contains the path to a persistent data directory (Read Only).")]
      [SocketState(false, false)]
      out string persistentDataPath,

      [FriendlyName("temporaryCachePath", "Contains the path to a temporary data / cache directory (Read Only).")]
      [SocketState(false, false)]
      out string temporaryCachePath,

      [FriendlyName("srcValue", "The path to the web player data file relative to the html file (Read Only).")]
      [SocketState(false, false)]
      out string srcValue,

      [FriendlyName("absoluteURL", "The absolute path to the web player data file (Read Only).")]
      [SocketState(false, false)]
      out string absoluteURL,

      [FriendlyName("systemLanguage", "The language the user's operating system is running in.")]
      [SocketState(false, false)]
      out SystemLanguage systemLanguage,

      [FriendlyName("internetReachability", "Returns internet reachability status.")]
      [SocketState(false, false)]
      out NetworkReachability internetReachability,

      [FriendlyName("webSecurityEnabled", "Indicates whether Unity's webplayer security model is enabled.")]
      [SocketState(false, false)]
      out bool webSecurityEnabled,

      [FriendlyName("webSecurityHostUrl", "[This appears to be undocumented!]")]
      [SocketState(false, false)]
      out string webSecurityHostUrl,

      [FriendlyName("runInBackground", "Returns the application background play state.")]
      [SocketState(false, false)]
      out bool runInBackground,
      
      [FriendlyName("targetFrameRate", "Returns the frame rate the game is instructed to use. The value is the ideal frame rate and may not reflect the actual frame rate.")]
      [SocketState(false, false)]
      out int targetFrameRate,

      [FriendlyName("backgroundLoadingPriority", "Returns the priority of background loading thread.")]
      [SocketState(false, false)]
      out ThreadPriority backgroundLoadingPriority,

      [FriendlyName("unityVersion", "The version of the Unity runtime used to play the content.")]
      out string unityVersion
      )
   {
      levelCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;

#if UNITY_5_3
      loadedLevels = new int[UnityEngine.SceneManagement.SceneManager.sceneCount];
      loadedLevelNames = new string[UnityEngine.SceneManagement.SceneManager.sceneCount];

      for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCount; i++)
      {
         UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetSceneAt(i);
         loadedLevels[i] = scene.buildIndex;
         loadedLevelNames[i] = scene.name;
      }
#else
      UnityEngine.SceneManagement.Scene[] scenes = UnityEngine.SceneManagement.SceneManager.GetAllScenes();
      loadedLevels = new int[scenes.Length];
      loadedLevelNames = new string[scenes.Length];

      for (int i = 0; i < scenes.Length; i++)
      {
         loadedLevels[i] = scenes[i].buildIndex;
         loadedLevelNames[i] = scenes[i].name;
      }
#endif

      isEditor = Application.isEditor;

      isPlaying = Application.isPlaying;
      isWebPlayer = Application.isWebPlayer;
      streamedBytes = Application.streamedBytes;

      platform = Application.platform;
      dataPath = Application.dataPath;
      persistentDataPath = Application.persistentDataPath;
      temporaryCachePath = Application.temporaryCachePath;

      srcValue = Application.srcValue;
      absoluteURL = Application.absoluteURL;
      unityVersion = Application.unityVersion;
      systemLanguage = Application.systemLanguage;

      internetReachability = Application.internetReachability;

      webSecurityEnabled = Application.webSecurityEnabled;
      webSecurityHostUrl = Application.webSecurityHostUrl;

      backgroundLoadingPriority = Application.backgroundLoadingPriority;
      runInBackground = Application.runInBackground;
      targetFrameRate = Application.targetFrameRate;
   }
}
#endif //#if (!UNITY_3_5 && !UNITY_4_6 && !UNITY_4_7 && !UNITY_5_0 && !UNITY_5_1 && !UNITY_5_2)
