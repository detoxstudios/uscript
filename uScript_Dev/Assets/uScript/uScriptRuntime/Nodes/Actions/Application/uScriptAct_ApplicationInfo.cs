// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Shows a GUILabel on the screen.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Access to application run-time data.")]
[NodeDescription("ReturnsThis class contains static methods for looking up information about and controlling the run-time data." +
 "  Shows a GUILabel on the screen.\n \nText: The text you want to display. \nPosition: The position and size of the label.\nTexture: The background image to use for the label.\nControl Name: Name to give to this label GUI control.\nTool Tip: The tool tip to display when the label is being hovered over.\nGUI Style: The name of a custom GUI style to use when displaying this label.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUI_Label")]

[FriendlyName("Application Info")]
public class uScriptAct_ApplicationInfo : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      // "levelCount", "The total number of levels available."
      [SocketState(false, false)]
      out int levelCount,

      // "loadedLevel", "The level index that was last loaded."
      [SocketState(false, false)]
      out int loadedLevel,

      // "loadedLevelName", "The name of the level that was last loaded."
      [SocketState(false, false)]
      out string loadedLevelName,

      // "isEditor", "Are we running inside the Unity editor?"
      [SocketState(false, false)]
      out bool isEditor,

      // "isLoadingLevel", "Is some level being loaded?"
      [SocketState(false, false)]
      out bool isLoadingLevel,

      // "isPlaying", "Returns true when in any kind of player."
      [SocketState(false, false)]
      out bool isPlaying,

      // "isWebPlayer", "Are we running inside a web player?"
      [SocketState(false, false)]
      out bool isWebPlayer,

      // "streamedBytes", "Returns the number of bytes that have been downloaded from the main unity web stream."
      [SocketState(false, false)]
      out int streamedBytes,

      // "platform", "Returns the platform the game is running (Read Only)."
      [SocketState(false, false)]
      out RuntimePlatform platform,

      // "dataPath", "Contains the path to the game data folder (Read Only)."
      [SocketState(false, false)]
      out string dataPath,

      // "persistentDataPath", "Contains the path to a persistent data directory (Read Only)."
      [SocketState(false, false)]
      out string persistentDataPath,

      // "temporaryCachePath", "Contains the path to a temporary data / cache directory (Read Only)."
      [SocketState(false, false)]
      out string temporaryCachePath,

      // "srcValue", "The path to the web player data file relative to the html file (Read Only)."
      [SocketState(false, false)]
      out string srcValue,

      // "absoluteURL", "The absolute path to the web player data file (Read Only)."
      [SocketState(false, false)]
      out string absoluteURL,

      // "systemLanguage", "The language the user's operating system is running in."
      [SocketState(false, false)]
      out SystemLanguage systemLanguage,

      // "internetReachability", "Returns internet reachability status."
      [SocketState(false, false)]
      out NetworkReachability internetReachability,

      // "webSecurityEnabled", "Indicates whether Unity's webplayer security model is enabled."
      [SocketState(false, false)]
      out bool webSecurityEnabled,

      // "webSecurityHostUrl", "[This appears to be undocumented!]"
      [SocketState(false, false)]
      out string webSecurityHostUrl,

      // "runInBackground", "Returns the application background play state."
      [SocketState(false, false)]
      out bool runInBackground,

      // "targetFrameRate", "Returns the frame rate the game is instructed to use. The value is the ideal frame rate and may not reflect the actual frame rate."
      [SocketState(false, false)]
      out int targetFrameRate,

      // "backgroundLoadingPriority", "Returns the priority of background loading thread."
      [SocketState(false, false)]
      out ThreadPriority backgroundLoadingPriority,

      // "unityVersion", "The version of the Unity runtime used to play the content."
      out string unityVersion
      )
   {
      levelCount = Application.levelCount;
      loadedLevel = Application.loadedLevel;
      loadedLevelName = Application.loadedLevelName;

      isEditor = Application.isEditor;
      isLoadingLevel = Application.isLoadingLevel;
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
