// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WelcomeWindow.cs" company="Detox Studios, LLC">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the WelcomeWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

   using UnityEditor;
   using UnityEngine;

public class WelcomeWindow : EditorWindow
{
   private const int WindowWidth = 560;

   private static WelcomeWindow window;

   private bool firstRun = true;

   public static void Init()
   {
      // Get existing open window or if none, make a new one:
      window = EditorWindow.GetWindow<WelcomeWindow>(true, "Welcome To uScript", true);
      window.firstRun = true; // unnecessary, but we'll get a warning that 'window' is unused, otherwise
   }

   public void OnGUI()
   {
      GUILayout.BeginVertical(Style.Clear, GUILayout.Width(WindowWidth));
      {
         GUILayout.BeginVertical();
         {
            ShowHeader(Content.Header);

            GUILayout.Space(16);

            ShowItem(Content.QuickStart);
            ShowItem(Content.Documentation);
            ShowItem(Content.Tutorials);
            ShowItem(Content.Examples);
            ShowItem(Content.Community);
            ShowItem(Content.Feedback);
         }

         GUILayout.EndVertical();

         GUILayout.Space(8);

         GUILayout.BeginHorizontal(GUILayout.Height(20));
         {
            GUILayout.FlexibleSpace();

            GUI.changed = false;
            uScript.Preferences.ShowAtStartup = GUILayout.Toggle(
               uScript.Preferences.ShowAtStartup, Content.ShowAtStartupText);
            if (GUI.changed)
            {
               uScript.Preferences.Save();
            }

            GUILayout.Space(16);
         }

         GUILayout.EndHorizontal();

         GUILayout.Space(16);
      }

      GUILayout.EndVertical();

      this.ResizeWindow();
   }

   private static void ShowHelpPageOrBrowseURL(string url)
   {
      if (url.StartsWith("file"))
      {
         Help.ShowHelpPage(url);
      }
      else
      {
         Help.BrowseURL(url);
      }
   }

   private static void ShowHeader(Content.Item item)
   {
      GUILayout.BeginHorizontal(Style.HeaderRow);

      GUILayout.Label(item.Icon, Style.HeaderIcon);

      GUILayout.Space(16);

      GUILayout.BeginVertical(GUILayout.ExpandWidth(true));

      GUILayout.Label(item.Label, Style.HeaderLabel);
      GUILayout.Label(item.Text, "WordWrappedLabel");

      GUILayout.EndVertical();

      GUILayout.EndHorizontal();
   }

   private static void ShowItem(Content.Item item)
   {
      GUILayout.BeginHorizontal(Style.ItemRow);

      if (GUILayout.Button(item.Icon, Style.ItemIcon))
      {
         ShowHelpPageOrBrowseURL(item.URL);
      }

      if (Event.current.type == EventType.Repaint)
      {
         EditorGUIUtility.AddCursorRect(GUILayoutUtility.GetLastRect(), MouseCursor.Link);
      }

      GUILayout.Space(8);

      GUILayout.BeginVertical(GUILayout.ExpandWidth(true));

      if (GUILayout.Button(item.Label, Style.ItemLabel))
      {
         ShowHelpPageOrBrowseURL(item.URL);
      }

      if (Event.current.type == EventType.Repaint)
      {
         EditorGUIUtility.AddCursorRect(GUILayoutUtility.GetLastRect(), MouseCursor.Link);
      }

      GUILayout.Label(item.Text, "WordWrappedLabel");

      GUILayout.EndVertical();

      GUILayout.EndHorizontal();
   }

   private void ResizeWindow()
   {
      if (Event.current.type != EventType.Repaint)
      {
         return;
      }

      var lastRect = GUILayoutUtility.GetLastRect();

      if (this.firstRun)
      {
         this.firstRun = false;

         // Force the window to a position relative to the uScript window
         lastRect.x = uScript.Instance.position.x + 50;
         lastRect.y = uScript.Instance.position.y + 50;

         window.position = new Rect();

         if (Application.platform == RuntimePlatform.WindowsEditor)
         {
            window.Focus();
         }
      }

      // Force the window dimesions to accommodate its content
      if ((int)window.position.width != (int)lastRect.width || (int)window.position.height != (int)lastRect.height)
      {
         window.position = lastRect;
         window.minSize = new Vector2(lastRect.width, lastRect.height);
         window.maxSize = window.minSize;
      }
   }

   private static class Content
   {
      static Content()
      {
         Header = new Item(
            "iconWelcomeLogo",
            "Welcome To uScript",
            "We've worked hard to get this into your hands, and we cannot wait to see the wonderful things you create with it!",
            string.Empty);

         QuickStart = new Item(
            "iconWelcomeQuickstart",
            "Quick Start",
            "Do you want to jump right in?  Check out our Getting Started guide to get you up and running.",
            "http://www.uscript.net/docs/index.php?title=Getting_Started");

         Documentation = new Item(
            "iconWelcomeDocumentation",
            "Documentation",
            "For more extensive information on uScript, including the Node Reference Guide, check out our online documentation.",
            "http://uscript.net/docs/");

         Tutorials = new Item(
            "iconWelcomeVideoTutorials",
            "Video Tutorials",
            "We have a selection of video tutorials that cover many uScript topics from basic to advanced.",
            "http://www.uscript.net/docs/index.php?title=Tutorials");

         Examples = new Item(
            "iconWelcomeExamples",
            "Example Projects",
            "Deconstruct our example projects to see exactly how they function.  Each project is well documented.",
            "http://www.uscript.net/docs/index.php?title=Example_Projects");

         Community = new Item(
            "iconWelcomeCommunity",
            "Community",
            "The uScript community is growing daily. Visit the forum and join the conversation.",
            "http://www.uscript.net/forum/");

         Feedback = new Item(
            "iconWelcomeFeedback",
            "Feedback",
            "Your feedback is important to us!  We setup a UserVoice account where you can vote on existing suggestions or add your own.",
            "http://uscript.uservoice.com/forums/125157-uscript-feedback");

         ShowAtStartupText = new GUIContent("Show at Startup");
      }

      public static Item Header { get; private set; }

      public static Item QuickStart { get; private set; }

      public static Item Documentation { get; private set; }

      public static Item Tutorials { get; private set; }

      public static Item Examples { get; private set; }

      public static Item Community { get; private set; }

      public static Item Feedback { get; private set; }

      public static GUIContent ShowAtStartupText { get; private set; }

      public class Item
      {
         public Item(string icon, string label, string text, string url)
         {
            // TODO: Replace the LoadAssetAtPath call with the call from uScriptGUI
            this.Icon = new GUIContent(AssetDatabase.LoadAssetAtPath("Assets/uScript/uScriptEditor/Editor/_GUI/EditorImages/" + icon + ".png", typeof(Texture)) as Texture);
            this.Label = new GUIContent(label);
            this.Text = new GUIContent(text);
            this.URL = url;
         }

         public GUIContent Icon { get; private set; }

         public GUIContent Label { get; private set; }

         public GUIContent Text { get; private set; }

         public string URL { get; private set; }
      }
   }

   private static class Style
   {
      static Style()
      {
         Clear = new GUIStyle();
         Clear.border = GUI.skin.box.border;
         Clear.margin = new RectOffset();
         Clear.padding = new RectOffset();

         HeaderRow = new GUIStyle(Clear);
         HeaderRow.margin = new RectOffset(40, 40, 0, 16);

         HeaderIcon = new GUIStyle();
         HeaderIcon.margin = new RectOffset(0, 0, 4, 4);

         HeaderLabel = new GUIStyle(Clear);
         HeaderLabel.normal.textColor = EditorStyles.boldLabel.normal.textColor;
         HeaderLabel.fontStyle = FontStyle.Bold;
         HeaderLabel.fontSize = 32;

         ItemRow = new GUIStyle(Clear);
         ItemRow.margin = new RectOffset(64, 64, 16, 16);

         ItemIcon = new GUIStyle();
         ItemIcon.margin = new RectOffset(2, 2, 2, 2);

         ItemLabel = new GUIStyle(Clear);
         ItemLabel.normal.textColor = EditorStyles.boldLabel.active.textColor;
         ItemLabel.fontSize = EditorStyles.boldLabel.fontSize;
         ItemLabel.fontStyle = FontStyle.Bold;
         ItemLabel.margin = new RectOffset(4, 4, 0, 4);
         ItemLabel.stretchWidth = false;
      }

      public static GUIStyle Clear { get; private set; }

      public static GUIStyle HeaderRow { get; private set; }

      public static GUIStyle HeaderIcon { get; private set; }

      public static GUIStyle HeaderLabel { get; private set; }

      public static GUIStyle ItemRow { get; private set; }

      public static GUIStyle ItemIcon { get; private set; }

      public static GUIStyle ItemLabel { get; private set; }
   }
}
