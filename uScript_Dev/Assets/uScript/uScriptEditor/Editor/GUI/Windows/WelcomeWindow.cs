// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WelcomeWindow.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the WelcomeWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#if !UNITY_3_5
namespace Detox.Editor.GUI.Windows
{
#endif
   using System.Collections.Generic;

   using Detox.Editor;

   using UnityEditor;

   using UnityEngine;

   public class WelcomeWindow : EditorWindow
   {
      private bool isFirstRun = true;

      public static void Open()
      {
         GetWindow<WelcomeWindow>(true, "Welcome To uScript", true);
      }

      public void OnGUI()
      {
         this.LayoutGUI();

         DrawHeader();
         DrawItems();
         DrawToggle();
      }

      private static bool ShouldUpdateRects()
      {
         return Content.HeaderIcon.Rect.x < 1;
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

      private static void DrawHeader()
      {
         GUI.Label(Content.HeaderIcon.Rect, Content.HeaderIcon.GUIContent, Style.Image);
         GUI.Label(Content.HeaderTitle.Rect, Content.HeaderTitle.GUIContent, Style.Image);
         GUI.Label(Content.HeaderText.Rect, Content.HeaderText.GUIContent, Style.WrappedText);
      }

      private static void DrawItems()
      {
         foreach (var item in Content.Items)
         {
            if (GUI.Button(item.Icon.Rect, item.Icon.GUIContent, Style.Image))
            {
               ShowHelpPageOrBrowseURL(item.URL);
            }

            if (GUI.Button(item.Label.Rect, item.Label.GUIContent, Style.Label))
            {
               ShowHelpPageOrBrowseURL(item.URL);
            }

            GUI.Label(item.Text.Rect, item.Text.GUIContent, Style.WrappedText);

            if (Event.current.type == EventType.Repaint)
            {
               EditorGUIUtility.AddCursorRect(item.Icon.Rect, MouseCursor.Link);
               EditorGUIUtility.AddCursorRect(item.Label.Rect, MouseCursor.Link);
            }
         }
      }

      private static void DrawToggle()
      {
         var toggle = Preferences.ShowAtStartup;
         EditorGUI.BeginChangeCheck();
         toggle = GUI.Toggle(Content.Toggle.Rect, toggle, Content.Toggle.GUIContent);
         if (EditorGUI.EndChangeCheck())
         {
            Preferences.ShowAtStartup = toggle;
         }
      }

      private static Vector2 UpdateRects()
      {
         const int VPad = 16;
         const int HPad = 24;
         const int Spacer = 20;

         const int WindowWidth = 512;
         const int TextWidth = WindowWidth - HPad - HPad - HPad - HPad - Spacer;

         // The icon is 64x64 with a left and top margin
         Content.HeaderIcon.Rect = new Rect(HPad, VPad, 64, 64);

         // The title is at the top-right of the icon, with a space separating them.
         Content.HeaderTitle.Rect = new Rect(
            Content.HeaderIcon.Rect.xMax + Spacer,
            VPad,
            Content.HeaderTitle.GUIContent.image.width,
            Content.HeaderTitle.GUIContent.image.height);

         // The header text is directly below the header title and has the same width.
         Content.HeaderText.Rect = new Rect(
            Content.HeaderTitle.Rect.x,
            Content.HeaderTitle.Rect.yMax,
            Content.HeaderTitle.Rect.width,
            Style.WrappedText.CalcHeight(Content.HeaderText.GUIContent, Content.HeaderTitle.Rect.width));

         Vector2 size;
         var y = Content.HeaderText.Rect.yMax + (VPad * 1.5f);

         // Layout for each of the items
         foreach (var item in Content.Items)
         {
            size = Style.Image.CalcSize(item.Icon.GUIContent);
            item.Icon.Rect = new Rect(HPad * 2, y, size.x, size.y);

            size = Style.Label.CalcSize(item.Label.GUIContent);
            item.Label.Rect = new Rect(item.Icon.Rect.xMax + Spacer, y, TextWidth - item.Icon.Rect.width, size.y);

            var height = Style.WrappedText.CalcHeight(item.Text.GUIContent, item.Label.Rect.width);
            item.Text.Rect = new Rect(item.Label.Rect.x, item.Label.Rect.yMax, item.Label.Rect.width, height);

            var rowHeight = Mathf.Max(item.Icon.Rect.height, item.Label.Rect.height + item.Text.Rect.height);
            y += rowHeight + VPad;
         }

         // The preference toggle
         size = GUI.skin.toggle.CalcSize(Content.Toggle.GUIContent);
         Content.Toggle.Rect = new Rect(WindowWidth - 8 - size.x, y, size.x, size.y);

         return new Vector2(WindowWidth, Content.Toggle.Rect.yMax + 8);
      }

      private void LayoutGUI()
      {
         if (ShouldUpdateRects())
         {
            this.minSize = this.maxSize = UpdateRects();
         }

         if (this.isFirstRun)
         {
            this.isFirstRun = false;

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
               this.Focus();
            }
         }
      }

      private static class Content
      {
         static Content()
         {
            HeaderIcon = new PositionedContent(uScriptGUI.GetTexture("iconWelcomeLogo"));

            HeaderTitle = new PositionedContent(uScriptGUI.GetSkinnedTexture("WelcomeHeader"));

            HeaderText =
               new PositionedContent(
                  "We've worked hard to get this into your hands, and we cannot wait to see the wonderful things you create with it!");

            Items = new List<Item>
                       {
                          new Item(
                             "iconWelcomeQuickstart",
                             "Key Concepts",
                             "Do you want to jump right in?  Check out the Key Concepts section of our User Guide to help get you started.",
                             "http://docs.uscript.net/Default.htm#3-Working_With_uScript/3.2-Key_Concepts.htm"),
                          new Item(
                             "iconWelcomeDocumentation",
                             "Documentation",
                             "For more extensive information on uScript check out our full User Guide online documentation.",
                             "http://docs.uscript.net/"),
                          new Item(
                             "iconWelcomeVideoTutorials",
                             "Video Tutorials",
                             "We have a selection of video tutorials that cover many uScript topics from basic to advanced.",
                             "http://www.uscript.net/home/tutorials"),
                          new Item(
                             "iconWelcomeExamples",
                             "Example Projects",
                             "Deconstruct our example projects to see exactly how they function.  Each project is well documented.",
                             "http://www.uscript.net/home/tutorials"),
                          new Item(
                             "iconWelcomeCommunity",
                             "Community",
                             "The uScript community is growing daily. Visit the forum and join the conversation.",
                             "http://www.uscript.net/forum/"),
                          new Item(
                             "iconWelcomeFeedback",
                             "Feedback",
                             "Your feedback is important to us!  Please add any suggestions you have for features on the 'Requests' section of the uScript Forum.",
                             "http://www.uscript.net/forum/viewforum.php?f=10"), // old - http://uscript.uservoice.com/forums/125157-uscript-feedback
                       };

            Toggle = new PositionedContent("Show at Startup");
         }

         public static PositionedContent HeaderIcon { get; private set; }

         public static PositionedContent HeaderTitle { get; private set; }

         public static PositionedContent HeaderText { get; private set; }

         public static PositionedContent Toggle { get; private set; }

         public static List<Item> Items { get; private set; }

         public class Item
         {
            public Item(string icon, string label, string text, string url)
            {
               this.Icon = new PositionedContent(uScriptGUI.GetTexture(icon));
               this.Label = new PositionedContent(label);
               this.Text = new PositionedContent(text);
               this.URL = url;
            }

            public PositionedContent Icon { get; private set; }

            public PositionedContent Label { get; private set; }

            public PositionedContent Text { get; private set; }

            public string URL { get; private set; }
         }

         public class PositionedContent
         {
            public PositionedContent(string text)
            {
               this.GUIContent = new GUIContent(text);
            }

            public PositionedContent(Texture image)
            {
               this.GUIContent = new GUIContent(image);
            }

            public GUIContent GUIContent { get; private set; }

            public Rect Rect { get; set; }
         }
      }

      private static class Style
      {
         static Style()
         {
            Image = new GUIStyle();

            Label = new GUIStyle(EditorStyles.boldLabel);

            WrappedText = new GUIStyle(EditorStyles.wordWrappedLabel);
         }

         public static GUIStyle Image { get; private set; }

         public static GUIStyle Label { get; private set; }

         public static GUIStyle WrappedText { get; private set; }
      }
   }
#if !UNITY_3_5
}
#endif
