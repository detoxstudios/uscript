// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AboutWindow.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the AboutWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#if !UNITY_3_5
namespace Detox.Editor.GUI
{
#endif
   using UnityEditor;

   using UnityEngine;

   using Application = UnityEngine.Application;
   using GUI = UnityEngine.GUI;

   public class AboutWindow : EditorWindow
   {
      private const int WindowWidth = 320;

      private const int WindowHeight = 260;

      private static AboutWindow window;

      private bool isFirstRun;

      public static void Open()
      {
         window = GetWindow<AboutWindow>(true, "About uScript", true);
         window.isFirstRun = true;
         window.wantsMouseMove = true;
      }

      public void OnGUI()
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
         }

         if (Event.current.type == EventType.MouseMove)
         {
            this.Repaint();
         }

         GUILayout.Label(Content.Header, Style.Header);

         GUILayout.Space(16);

         GUILayout.Label("uScript " + uScriptBuild.Name, Style.ProductName);
         GUILayout.Label("Build " + uScriptBuild.Number, Style.ProductVersion);
         GUILayout.Label("\n" + uScriptBuild.Copyright + "\nAll rights reserved.\n", Style.ProductCopyright);

         if (GUILayout.Button("www.detoxstudios.com", Style.WebsiteLink))
         {
            Application.OpenURL("http://detoxstudios.com/");
         }
      }

      private static class Content
      {
         static Content()
         {
            Header = new GUIContent(uScriptGUI.GetTexture("AboutLogo"));
         }

         public static GUIContent Header { get; private set; }
      }

      private static class Style
      {
         static Style()
         {
            Header = new GUIStyle { padding = new RectOffset(0, 32, 0, 0), stretchWidth = false };

            ProductCopyright = new GUIStyle(EditorStyles.label) { alignment = TextAnchor.UpperCenter };
            ProductName = new GUIStyle(EditorStyles.boldLabel) { alignment = TextAnchor.UpperCenter };
            ProductVersion = new GUIStyle(EditorStyles.label) { alignment = TextAnchor.UpperCenter };

            WebsiteLink = new GUIStyle(GUI.skin.button) { alignment = TextAnchor.UpperCenter };
            WebsiteLink.hover.background = WebsiteLink.normal.background;
            WebsiteLink.hover.textColor = WebsiteLink.normal.textColor;
            WebsiteLink.normal.background = null;
            WebsiteLink.margin = new RectOffset(80, 80, 3, 3);
         }

         public static GUIStyle Header { get; private set; }

         public static GUIStyle ProductCopyright { get; private set; }

         public static GUIStyle ProductName { get; private set; }

         public static GUIStyle ProductVersion { get; private set; }

         public static GUIStyle WebsiteLink { get; private set; }
      }
   }
#if !UNITY_3_5
}
#endif
