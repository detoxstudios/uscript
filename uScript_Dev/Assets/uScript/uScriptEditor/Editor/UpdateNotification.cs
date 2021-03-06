// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateNotification.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the UpdateNotification type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.Linq;

   using Detox.Editor;
   using Detox.Editor.Extensions;

   using UnityEditor;

   using UnityEngine;

public class UpdateNotification : EditorWindow
{
   private const int WindowHeight = 160;

   private const int WindowWidth = 420;

   private static bool shouldRunSilent;

   private static UpdateStatus updateStatus;

   private static UpdateNotification window;

   private static WWW webRequest;

   private static IEnumerator e;

   private bool isFirstRun;

   private bool shouldUpdateLayout;

   public enum UpdateStatus
   {
      None,
      CheckNeeded,
      CheckInProgress,
      ClientBuildCurrent,
      ClientBuildNewer,
      ClientBuildOlder,
      UpdateClientError,
      UpdateServerError
   }

   public static string LatestVersion { get; private set; }

   public static bool IsAsssetStoreProduct { get { return uScriptBuild.Source == uScriptBuild.SourceType.Unity; } }

   public GUIContent Title { get; set; }

   public GUIContent Body { get; set; }

   private GUIContent PreviousBody { get; set; }
  
   public static UpdateNotification Open()
   {
      window = (UpdateNotification)GetWindow(typeof(UpdateNotification), true, string.Empty, true);
      window.isFirstRun = true;
      window.shouldUpdateLayout = true;

      updateStatus = UpdateStatus.CheckNeeded;
      return window;
   }

   public static void ManualCheck()
   {
      Open();
      shouldRunSilent = false;
   }

   public static void StartupCheck()
   {
      shouldRunSilent = true;

      // Introduce the user to the update system on the first launch
      // LastUpdateCheck will be 0 when uScript it first run, or when the uScriptSettings file is removed
      if (Preferences.LastUpdateCheck <= 0)
      {
         const string Message =
            "This update check will send basic, anonymous Unity and uScript version details to our update server."
            + " No personally identifiable information or proprietary data is transmitted or collected.\n\nThis"
            + " service can be enabled or disabled at any time from within the uScript Preferences panel.\n";

         var enable = EditorUtility.DisplayDialog(
            "Automatically check for uScript updates?",
            Message,
            "Enable",
            "Disable");

         Preferences.LastUpdateCheck = int.Parse(DateTime.Now.AddDays(-1).ToString("yyyyMMdd"));
         Preferences.CheckForUpdate = enable;
      }

      // If the update system is enabled, we *might* check for update availability
      if (Preferences.CheckForUpdate)
      {
         // Only check once per day
         var today = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
         if (Preferences.LastUpdateCheck < today)
         {
            // Update the date so we won't check again until tomorrow
            Preferences.LastUpdateCheck = today;

            SilentlyCheckServerForUpdate();
         }
      }
   }

   internal static string GetProductType()
   {
      // NOTE: uScriptBuild.Source and Edition are constants defined within conditional compile directives
#pragma warning disable 429
// ReSharper disable UnreachableCode
      const string Source = uScriptBuild.Source == uScriptBuild.SourceType.Unity ? "UNITY" : "DETOX";
      const string Edition = uScriptBuild.Edition == uScriptBuild.EditionType.Pro ? "PRO" : "PLE";
// ReSharper restore UnreachableCode
#pragma warning restore 429

      var product = string.Format("uScript_{0}_STORE_{1}", Source, Edition);
      return product;
   }

   internal void OnEnabled()
   {
      this.shouldUpdateLayout = true;
   }

   internal void OnGUI()
   {
      if (this.isFirstRun)
      {
         this.isFirstRun = false;

         // Set the min and max window dimensions to prevent resizing
         this.minSize = new Vector2(WindowWidth, WindowHeight);
         this.maxSize = this.minSize;

         if (Application.platform == RuntimePlatform.WindowsEditor)
         {
            window.Focus();
         }

         // It seems like OnGUI() is first on Mac, but Update() is called first on Windows.
         // Initialize some GUI members here just in case.
         if (updateStatus == UpdateStatus.CheckNeeded)
         {
            this.Title = Content.TitleCheckInProgress;
            this.Body = Content.BodyCheckInProgress;
         }
      }

      if ((this.shouldUpdateLayout || this.PreviousBody != this.Body) && Event.current.type == EventType.Layout)
      {
         this.PreviousBody = this.Body;
         this.LayoutGUI();

         this.shouldUpdateLayout = false;

         //if (shouldRunSilent && hidden == false)
         //{
         //   window.position = new Rect(
         //      window.position.x,
         //      window.position.y + 5000,
         //      window.position.width,
         //      window.position.height);
         //   hidden = true;
         //}
      }

      if (Event.current.type == EventType.MouseMove)
      {
         this.Repaint();
      }

      GUI.Label(Content.RectIcon, Content.Icon, Style.Icon);
      GUI.Label(Content.RectTitle, this.Title, Style.Title);
      GUI.Label(Content.RectBody, this.Body, Style.Body);
      DrawButtons();
   }

   internal void Update()
   {
      if (updateStatus == UpdateStatus.CheckNeeded)
      {
         e = CheckServerForUpdate();
         this.Title = Content.TitleCheckInProgress;
         this.Body = Content.BodyCheckInProgress;
         updateStatus = UpdateStatus.CheckInProgress;
      }

      if (e != null)
      {
         e.MoveNext();
      }
   }

   private static IEnumerator CheckServerForUpdate()
   {
      webRequest = CreateWebRequest();

      while (!webRequest.isDone)
      {
         yield return webRequest;
      }

      ProcessWebResponse();

      e = null;
   }

   private static void SilentlyCheckServerForUpdate()
   {
#if (UNITY_5_4_OR_NEWER)
      if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.WebGL)
#else
      if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.WebPlayer || EditorUserBuildSettings.activeBuildTarget == BuildTarget.WebGL)
#endif
      {
         // Abort, because the web targets do not support WWW calls in the editor.
         //
         // Exception: Expected root element to be < cross - domain - policy >.found html instead
         //    MonoForks.System.Windows.Browser.Net.FlashCrossDomainPolicy + Handler.OnStartElement(System.String name, IAttrList attrs)
         //    MonoForks.Mono.Xml.MiniParser.Parse(IReader reader, IHandler handler)
         //    MonoForks.System.Windows.Browser.Net.FlashCrossDomainPolicy.FromStream(System.IO.Stream originalStream)
         //    MonoForks.System.Windows.Browser.Net.CrossDomainPolicyManager.BuildFlashPolicy(Boolean statuscodeOK, MonoForks.System.Uri uri, System.IO.Stream responsestream, System.Collections.Generic.Dictionary`2 responseheaders)
         //    UnityEngine.WWW:get_isDone()
         return;
      }

      webRequest = CreateWebRequest();

      if (webRequest == null)
      {
         Debug.Log("Webrequest is null.\n");
         return;
      }

      // Coroutines do not work in the editor, but we still need to handle the request in a non-blocking manner.
      JobManager.Add(
         () => webRequest.isDone,
         () =>
            {
               SilentlyProcessWebResponse();
               webRequest.Dispose();
            });
   }

   private static WWW CreateWebRequest()
   {
      // TODO: Look into making this a POST form rather than a GET request
      var uri =
         string.Format(
            "http://detoxstudios.com/download/versionCheck.php?productName={0}&productBuild={1}&platformName={2}&platformBuild={3}&platformPro={4}",
            WWW.EscapeURL(GetProductType()),
            WWW.EscapeURL(uScriptBuild.Number),
            WWW.EscapeURL(Application.platform.ToString()),
            WWW.EscapeURL(Application.unityVersion),
            WWW.EscapeURL(uScript.IsUnityPro.ToString()));

      return new WWW(uri);
   }

   private static void ProcessWebResponse()
   {
      BuildInfo clientBuild;
      BuildInfo serverBuild;

      if (string.IsNullOrEmpty(webRequest.error) == false)
      {
         window.Title = Content.TitleError;
         window.Body = new GUIContent(string.Format("{0}\n\nIs this device connected to the internet?", webRequest.error));
         updateStatus = UpdateStatus.UpdateServerError;
      }
      else if (BuildInfo.TryParse(webRequest.text, out serverBuild) == false)
      {
         window.Title = Content.TitleError;
         window.Body = new GUIContent(string.Format("Failed to parse server response: '{0}'", webRequest.text));
         updateStatus = UpdateStatus.UpdateServerError;
      }
      else if (BuildInfo.TryParse(uScriptBuild.Number, out clientBuild) == false)
      {
         window.Title = Content.TitleError;
         window.Body = new GUIContent(string.Format("Failed to parse client build number: '{0}'", uScriptBuild.Number));
         updateStatus = UpdateStatus.UpdateClientError;
      }
      else
      {
         updateStatus = clientBuild == serverBuild
                           ? UpdateStatus.ClientBuildCurrent
                           : (clientBuild > serverBuild ? UpdateStatus.ClientBuildNewer : UpdateStatus.ClientBuildOlder);

         // Add build information
         var clientVersion = clientBuild.ToString();
         var serverVersion = LatestVersion = serverBuild.ToString();

         if (updateStatus == UpdateStatus.ClientBuildNewer)
         {
            clientVersion = clientVersion.Bold();
         }
         else if (updateStatus == UpdateStatus.ClientBuildOlder)
         {
            serverVersion = serverVersion.Bold();
         }

         clientVersion = string.Format("        Your version: \t{0}", clientVersion);
         serverVersion = string.Format("        Latest version: \t{0}", serverVersion);

         if (updateStatus == UpdateStatus.ClientBuildCurrent)
         {
            window.Title = Content.TitleClientBuildCurrent;
            window.Body = new GUIContent(string.Format("{0}\n\n{1}", Content.BodyClientBuildCurrent.text, clientVersion));
         }
         else if (updateStatus == UpdateStatus.ClientBuildNewer)
         {
            window.Title = Content.TitleClientBuildNewer;
            window.Body = new GUIContent(string.Format("{0}\n\n{1}\n{2}", Content.BodyClientBuildNewer.text, clientVersion, serverVersion));
         }
         else
         {
            window.Title = Content.TitleClientBuildOlder;
            var msg = IsAsssetStoreProduct
                         ? Content.BodyClientBuildOlderUnity.text
                         : Content.BodyClientBuildOlderDetox.text;
            window.Body = new GUIContent(string.Format("{0}\n\n{1}\n{2}", msg, clientVersion, serverVersion));
         }
      }

      window.Repaint();
   }

   private static void SilentlyProcessWebResponse()
   {
      BuildInfo clientBuild;
      BuildInfo serverBuild;

      if (string.IsNullOrEmpty(webRequest.error) == false)
      {
         // DO NOTHING - Better to silently fail than to report a web request error during the startup check.
         // An error will be generated when WWW fails to connect to the internet, and we don't want to annoy
         // users with daily warning messages, if they frequently run offline.

         // var msg = string.Format("{0}: \"{1}\"", Content.TitleError.text, webRequest.error);
         // uScriptDebug.Log(msg, uScriptDebug.Type.Warning);
      }
      else if (BuildInfo.TryParse(webRequest.text, out serverBuild) == false)
      {
         var msg = string.Format("Failed to parse server response: '{0}'", webRequest.text);
         uScriptDebug.Log(msg, uScriptDebug.Type.Error);
      }
      else if (BuildInfo.TryParse(uScriptBuild.Number, out clientBuild) == false)
      {
         var msg = string.Format("Failed to parse client build number: '{0}'", uScriptBuild.Number);
         uScriptDebug.Log(msg, uScriptDebug.Type.Error);
      }
      else
      {
         updateStatus = clientBuild == serverBuild
                           ? UpdateStatus.ClientBuildCurrent
                           : (clientBuild > serverBuild ? UpdateStatus.ClientBuildNewer : UpdateStatus.ClientBuildOlder);

         if (updateStatus == UpdateStatus.ClientBuildCurrent || updateStatus == UpdateStatus.ClientBuildNewer)
         {
            return;
         }

         // Add build information
         var clientVersion = clientBuild.ToString();
         var serverVersion = LatestVersion = serverBuild.ToString();

         if (Preferences.IgnoreUpdateBuild == serverVersion)
         {
            return;
         }

         if (updateStatus == UpdateStatus.ClientBuildOlder)
         {
            serverVersion = serverVersion.Bold();
         }

         clientVersion = string.Format("        Your version: \t{0}", clientVersion);
         serverVersion = string.Format("        Latest version: \t{0}", serverVersion);

         Open();
         updateStatus = UpdateStatus.ClientBuildOlder;
         window.Title = Content.TitleClientBuildOlder;
         var msg = IsAsssetStoreProduct
                      ? Content.BodyClientBuildOlderUnity.text
                      : Content.BodyClientBuildOlderDetox.text;
         window.Body = new GUIContent(string.Format("{0}\n\n{1}\n{2}", msg, clientVersion, serverVersion));
         window.Repaint();
      }
   }

   private static List<Vector2> CalcActiveButtonSizes()
   {
      return Content.ActiveButtons.Select(button => Style.Button.CalcSize(button)).ToList();
   }

   private static void LayoutButton(ICollection<Vector2> sizes, float x)
   {
      uScriptDebug.Assert(sizes != null && sizes.Count > 0 && sizes.Count < 4, "The Update Notification panel must have 1 to 3 buttons");

      const int Margin = 16;
      x -= Margin;
      var top = Mathf.Max(Content.RectIcon.yMax, Content.RectBody.yMax) + Margin;

      var rectList = new List<Rect>();

      foreach (var size in sizes)
      {
         var width = size.x;
         var height = size.y;
         var rect = new Rect(x - width, top, width, height);
         rectList.Add(rect);
         x = rect.x - Margin;
      }

      Content.ActiveButtonRects = rectList;
   }

   //if (errorMessage != string.Empty)
   //{
   //   if (updateStatus == UpdateStatus.UpdateServerError)
   //   {
   //      Debug.LogWarning(
   //         string.Format("{0}\nPlease report this issue to support@detoxstudios.com", errorMessage));
   //   }
   //   else
   //   {
   //      Debug.Log(string.Format("{0}\n", errorMessage));
   //   }
   //}

   private static void DrawButtons()
   {
      for (var i = 0; i < Content.ActiveButtons.Count; i++)
      {
         DrawButton(Content.ActiveButtonRects[i], Content.ActiveButtons[i]);
      }
   }

   private static void DrawButton(Rect rect, GUIContent content)
   {
      if (GUI.Button(rect, content, Style.Button))
      {
         if (content == Content.ButtonCancel)
         {
            webRequest.Dispose();
         }
         else if (content == Content.ButtonOpenAssetStore)
         {
            CommandOpenAssetStorePage();
         }
         else if (content == Content.ButtonOpenDetoxStore)
         {
            CommandOpenDetoxStoreWebpage();
         }
         else if (content == Content.ButtonRemind)
         {
            CommandRemindLater();
         }
         else if (content == Content.ButtonSkip)
         {
            CommandSkipUpdate();
         }

         window.Close();
      }
   }

   private static void CommandOpenAssetStorePage()
   {
      // Former URI: com.unity3d.kharma:content/1808
      UnityEditorInternal.AssetStore.Open("content/1808");
   }

   private static void CommandOpenDetoxStoreWebpage()
   {
      Application.OpenURL("http://detoxstudios.com/products/uscript/download/");
   }

   private static void CommandRemindLater()
   {
      Preferences.LastUpdateCheck = int.Parse(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));
   }

   private static void CommandSkipUpdate()
   {
      Preferences.IgnoreUpdateBuild = LatestVersion;
   }

   private void LayoutGUI()
   {
      const int Top = 16;
      const int Left = 24;
      const int H = 20;
      const int V = 8;

      switch (updateStatus)
      {
         case UpdateStatus.CheckNeeded:
         case UpdateStatus.CheckInProgress:
            Content.ActiveButtons = new List<GUIContent> { Content.ButtonCancel };
            break;
         case UpdateStatus.ClientBuildOlder:
            var storeButton = IsAsssetStoreProduct ? Content.ButtonOpenAssetStore : Content.ButtonOpenDetoxStore;

            Content.ActiveButtons = shouldRunSilent
                                       ? new List<GUIContent> { Content.ButtonRemind, storeButton, Content.ButtonSkip }
                                       : new List<GUIContent> { Content.ButtonOkay, storeButton };
            break;
         default:
            Content.ActiveButtons = new List<GUIContent> { Content.ButtonOkay };
            break;
      }

      var sizes = CalcActiveButtonSizes();
      var buttonRowWidth = sizes.Sum(size => size.x) + (Top * (sizes.Count - 1));

      // The icon is 64x64 with a left and top margin
      Content.RectIcon = new Rect(Left, Top, 64, 64);

      // The title is at the top-right of the icon, with a space separating them.
      // The title width stretches to fill the window horizontally, but must be at least as wide as the button row.
      Content.RectTitle = new Rect(
         Content.RectIcon.xMax + H,
         Top,
         Mathf.Max(buttonRowWidth - (Left - Top), WindowWidth - Content.RectIcon.xMax - H - Left),
         20);

      // The body is directly below the title with a space separating them.
      // The body height is determined by its text and style.
      Content.RectBody = new Rect(
         Content.RectTitle.x,
         Content.RectTitle.yMax + V,
         Content.RectTitle.width,
         Style.Body.CalcHeight(new GUIContent(this.Body), Content.RectTitle.width));

      // Update the window width, now that we know the buttons may force it larger
      var windowWidth = Mathf.Max(WindowWidth, Left + 64 + H + (buttonRowWidth - (Left - Top)) + Left);

      // The first button is at the lower-left corner of the window, and following buttons are positioned to the right.
      LayoutButton(sizes, windowWidth);

      // Update the window height, now that we know the button positions
      var windowHeight = Content.ActiveButtonRects[0].yMax + Top;

      // Set the min and max window dimensions to prevent resizing
      this.minSize = new Vector2(windowWidth, windowHeight);
      this.maxSize = this.minSize;
   }

   private static class Content
   {
      static Content()
      {
         BodyCheckInProgress = new GUIContent("Contacting the update server. Please wait.");
         BodyClientBuildCurrent = new GUIContent("The uScript build you are using is currently the newest version available.");
         BodyClientBuildNewer = new GUIContent("The uScript build you are using is newer than the version publicly available.");
         BodyClientBuildOlderDetox = new GUIContent("There is a new version of uScript available for download from the Detox Studios website.");
         BodyClientBuildOlderUnity = new GUIContent("A new version of uScript has been uploaded to the Unity Asset Store, and should be available for download.");

         ButtonCancel = new GUIContent("Cancel");
         ButtonOpenAssetStore = new GUIContent("Open Asset Store");
         ButtonOpenDetoxStore = new GUIContent("Open Download Page");
         ButtonOkay = new GUIContent("Okay");
         ButtonRemind = new GUIContent("Remind in 7 Days");
         ButtonSkip = new GUIContent("Skip this Update");

         Icon = new GUIContent(uScriptGUI.GetTexture("iconWelcomeLogo"));

         TitleCheckInProgress = new GUIContent("Check for Updates");
         TitleClientBuildCurrent = new GUIContent("You're up to date!");
         TitleClientBuildNewer = new GUIContent("You're on the cutting edge!");
         TitleClientBuildOlder = new GUIContent("uScript Update Available!");
         TitleError = new GUIContent("An Error Occurred!");
      }

      public static GUIContent BodyCheckInProgress { get; private set; }

      public static GUIContent BodyClientBuildCurrent { get; private set; }

      public static GUIContent BodyClientBuildNewer { get; private set; }

      public static GUIContent BodyClientBuildOlderDetox { get; private set; }

      public static GUIContent BodyClientBuildOlderUnity { get; private set; }

      public static GUIContent ButtonCancel { get; private set; }

      public static GUIContent ButtonOpenAssetStore { get; private set; }

      public static GUIContent ButtonOpenDetoxStore { get; private set; }

      public static GUIContent ButtonOkay { get; private set; }

      public static GUIContent ButtonRemind { get; private set; }

      public static GUIContent ButtonSkip { get; private set; }

      public static GUIContent Icon { get; private set; }

      public static GUIContent TitleCheckInProgress { get; private set; }

      public static GUIContent TitleClientBuildCurrent { get; private set; }

      public static GUIContent TitleClientBuildNewer { get; private set; }

      public static GUIContent TitleClientBuildOlder { get; private set; }

      public static GUIContent TitleError { get; private set; }

      public static Rect RectBody { get; set; }
      
      public static Rect RectIcon { get; set; }

      public static Rect RectTitle { get; set; }

      public static List<GUIContent> ActiveButtons { get; set; }

      public static List<Rect> ActiveButtonRects { get; set; } 
   }

   private static class Style
   {
      static Style()
      {
         Body = new GUIStyle(GUI.skin.label)
         {
            stretchWidth = false,
            fixedWidth = 0,
            wordWrap = true,
            padding = new RectOffset(),
            margin = new RectOffset(),
            fontSize = 11,
            richText = true
         };

         Button = new GUIStyle(GUI.skin.button) { fixedHeight = 20, padding = new RectOffset(12, 12, 3, 4) };

         Icon = new GUIStyle();

         Title = new GUIStyle(EditorStyles.boldLabel)
         {
            fontSize = 12,
            margin = new RectOffset(),
            padding = new RectOffset()
         };
      }

      public static GUIStyle Body { get; private set; }

      public static GUIStyle Button { get; private set; }

      public static GUIStyle Icon { get; private set; }

      public static GUIStyle Title { get; private set; }
   }
}
